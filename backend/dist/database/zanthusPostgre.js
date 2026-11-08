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
const Tools_1 = __importDefault(require("../tools/Tools"));
const pg_1 = require("pg");
const modelbase_1 = require("../model/modelbase");
const SERVER_DATABASE_LOG_LIMIT_QUERY_STRING = parseInt(process.env.SERVER_DATABASE_LOG_LIMIT_QUERY_STRING || '150');
const pool = new pg_1.Pool({
    host: process.env.SERVER_zanthusPOSTGRESQL_HOST,
    user: process.env.SERVER_zanthusPOSTGRESQL_USER,
    database: process.env.SERVER_zanthusPOSTGRESQL_DATABASE,
    password: process.env.SERVER_zanthusPOSTGRESQL_PWD,
    port: parseInt(process.env.SERVER_zanthusPOSTGRESQL_PORT || '5432')
});
let MyQueryResultRow;
const zanthusPostgre_pool = {
    DataGet: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        try {
            if (!query_string) {
                throw new Error("query string não informada");
            }
            const result = yield pool.query(query_string);
            MyQueryResultRow = result.rows;
            return MyQueryResultRow;
        }
        catch (e) {
            Tools_1.default.pagConsoleLog(`ZANTHUS POSTGRE - ERROR DATA GET | 
                                    -----------------------------------------------------
                                    ERROR
                                    -----------------------------------------------------  
                                    ${e} 
                                    QUERY
                                    -----------------------------------------------------  
                                    ${query_string.length > SERVER_DATABASE_LOG_LIMIT_QUERY_STRING ? query_string.substring(0, SERVER_DATABASE_LOG_LIMIT_QUERY_STRING) + '...' : query_string}`, true);
            return MyQueryResultRow;
        }
    }),
    Execute: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        try {
            if (!query_string) {
                throw new Error("query string não informada");
            }
            yield pool.query(query_string);
            return 1;
        }
        catch (e) {
            let numArquivo = Math.random() * 1000;
            Tools_1.default.pagConsoleLog(`ZANTHUS POSTGRE - ERROR EXECUTE | 
                                    -----------------------------------------------------
                                    ERROR
                                    -----------------------------------------------------  
                                    ${e} 
                                    QUERY
                                    -----------------------------------------------------  
                                    ${query_string.length > SERVER_DATABASE_LOG_LIMIT_QUERY_STRING ? query_string.substring(0, SERVER_DATABASE_LOG_LIMIT_QUERY_STRING) + '...' : query_string}`, true);
            yield modelbase_1.clsTools.PagErrorException(`ZANTHUS POSTGRE - ERROR EXECUTE`, `Execute QUERY \n ${query_string}`, e, false, "Erro QUERY", `POSTGRE_ERROR_${numArquivo}`);
            return 0;
        }
    })
};
exports.default = zanthusPostgre_pool;
