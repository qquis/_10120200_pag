"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const mssql_1 = __importDefault(require("mssql"));
const Tools_1 = __importDefault(require("../tools/Tools"));
let result = {};
const sqlConfig = {
    user: `${process.env.SERVER_SQLSERVER_USER}`,
    password: `${process.env.SERVER_SQLSERVER_PASSWORD}`,
    database: `${process.env.SERVER_SQLSERVER_DATABASE}`,
    server: `${process.env.SERVER_SQLSERVER_HOST}`,
    pool: {
        max: 10,
        min: 0,
        idleTimeoutMillis: 30000,
    },
    options: {
        encrypt: false, // for azure
        trustServerCertificate: false, // change to true for local dev / self-signed certs
        enableArithAbort: true
    },
    requestTimeout: 120000
};
const sqlserver_pool = {
    DataGet: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        let Object_dados = {};
        try {
            yield mssql_1.default.connect(sqlConfig);
            Object_dados = (yield mssql_1.default.query(query_string)).recordset;
            return Promise.resolve(Object_dados);
        }
        catch (e) {
            Tools_1.default.pagConsoleLog(`sqlserver - DataGet | ${e}`, true);
            return Promise.resolve(Object_dados);
        }
    }),
    Execute: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        let resultROWS = 0;
        try {
            yield mssql_1.default.connect(sqlConfig);
            let result = yield mssql_1.default.query(query_string);
            if (result)
                resultROWS = parseInt(`${result.rowsAffected[0]}`);
            return resultROWS;
        }
        catch (e) {
            Tools_1.default.pagConsoleLog(`(ERROR) sqlserver - Execute | 
                                 Descricao do Errro 
                                 ${e}
                                 ---------------------------------------------
                                 Script 
                                 ${query_string}
                                 `, true);
            return resultROWS;
        }
    }),
    test: () => __awaiter(void 0, void 0, void 0, function* () {
        try {
            yield sqlserver_pool.Execute("insert into DBAMAIN.dbo.tbacessopaglog (dtlog_insert) select getdate()");
            let dados = yield sqlserver_pool.DataGet("SELECT info = convert(varchar(130), 'Server Name : ' + @@SERVERNAME + ' TimeDataBase: ' + convert(varchar(45), getdate()))");
            const [key] = Object.entries(dados);
            let testResult = `Connect ok _ ${key[1].info}`;
            return testResult;
        }
        catch (e) {
            Tools_1.default.pagConsoleLog(`Connect Error`, true);
            return Promise.reject(e);
        }
    })
};
exports.default = sqlserver_pool;
