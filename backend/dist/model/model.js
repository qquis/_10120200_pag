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
exports.clsBase = exports.clsBasicReport = exports.modelbase = exports.mdoReport = exports.modelReport = exports.modelTb = void 0;
require("dotenv/config");
const Tools_1 = __importDefault(require("../tools/Tools"));
const uuid_1 = require("uuid");
const DataBase_1 = __importDefault(require("../database/DataBase"));
const events_1 = require("events");
const myDataBase = new DataBase_1.default();
var BDCommand;
(function (BDCommand) {
    BDCommand["DBSELECT"] = "DBSELECT";
    BDCommand["DBUPDATE"] = "DBUPDATE";
    BDCommand["DBINSERT"] = "DBINSERT";
    BDCommand["DBCRUD"] = "DBCRUD";
    BDCommand["DBINSERT_API"] = "DBINSERT_API";
})(BDCommand || (BDCommand = {}));
class modelbase extends events_1.EventEmitter {
    constructor() {
        super();
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`;
    }
}
exports.modelbase = modelbase;
class modelTb {
    constructor() {
        this.ENVIRONMENT = process.env.ENVIRONMENT;
        this.__defaultDateNow = Tools_1.default.pagDateTime_getDate();
        this.id_insert = ``;
        this.dtlog_update = this.__defaultDateNow;
        this.dtlog_insert = this.__defaultDateNow;
    }
    /* SCRIPT POSTGRE */
    _Db_Pg_script_Select() { return this._Db_Pg_script("DBSELECT"); }
    _Db_Pg_script_Insert() { return this._Db_Pg_script("DBINSERT"); }
    _Db_Pg_script_Update() { return this._Db_Pg_script("DBUPDATE"); }
    _Db_Pg_script_ToCheck() { return this._Db_Pg_script("TOCHECK"); }
    _Db_Pg_script_CRUD() { return this._Db_Pg_script("CRUD"); }
    _Db_Pg_script_DBCRUD() { return this._Db_Pg_script("DBCRUD"); }
    _myScriptBDCommand(_BDCommand = BDCommand.DBINSERT) {
        return this._Db_Pg_script(_BDCommand);
    }
    _Db_Pg_script(_stringCommand) { return ''; }
    /* DATA BINDING */
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () { });
    }
    bindingBlueSoftApi(item) {
        return __awaiter(this, void 0, void 0, function* () { });
    }
    /* Data Sql Commands */
    _uuid() {
        return __awaiter(this, void 0, void 0, function* () {
            return `${(0, uuid_1.v4)().substring(0, 10)}`;
        });
    }
    /* Data PostGre Comands */
    _Db_Pg_ToCheck() {
        return __awaiter(this, void 0, void 0, function* () { this._Db_Pg_DataBinding(this._Db_Pg_script_ToCheck()); });
    }
    _Db_Pg_INSERT() {
        return __awaiter(this, void 0, void 0, function* () { this._Db_Pg_DataPost(this._Db_Pg_script_Insert()); });
    }
    _Db_Pg_UPDATE() {
        return __awaiter(this, void 0, void 0, function* () { this._Db_Pg_DataPost(this._Db_Pg_script_Update()); });
    }
    _Db_Pg_CRUD() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield this._Db_Pg_DataGet(this._Db_Pg_script_CRUD());
                yield this.binding(result[0]);
            }
            catch (e) {
                console.log(`modelTb (extends) | _CRUD Method \n Error --->>  ${e}`);
            }
        });
    }
    /* New Events */
    __Consultar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield this._Db_Pg_DataGet(this._Db_Pg_script_Select());
                yield this.binding(result[0]);
            }
            catch (e) {
                console.log(`modelTb (extends) | __Consultar Method \n Error --->>  ${e}`);
            }
        });
    }
    __Atualizar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield this._Db_Pg_DataGet(this._Db_Pg_script_DBCRUD());
                if (!result[0]) {
                    Tools_1.default.pagConsoleLog(`MODELDB | Atualizar(): \n Return Record 0 from UPDATE Process `, true);
                }
                yield this.binding(result[0]);
            }
            catch (e) {
                console.log(`modelTb (extends) | __Atualizar Method \n Error --->>  ${e}`);
            }
        });
    }
    __INSERT() {
        return __awaiter(this, void 0, void 0, function* () { this._Db_Pg_DataPost(this._Db_Pg_script_Insert()); });
    }
    __UPDATE() {
        return __awaiter(this, void 0, void 0, function* () { this._Db_Pg_DataPost(this._Db_Pg_script_Update()); });
    }
    __CRUD() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield this._Db_Pg_DataGet(this._Db_Pg_script_DBCRUD());
                yield this.binding(result[0]);
            }
            catch (e) {
                console.log(`modelTb (extends) | _CRUD Method \n Error --->>  ${e}`);
            }
        });
    }
    _Db_Pg_DataGetResult(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield myDataBase.pag.DataGet(scriptSQL);
                return result[0];
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true);
                return {};
            }
        });
    }
    _Db_Pg_DataPost(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataPost / Var scriptSQL \n ${scriptSQL} `);
                yield myDataBase.pag.Execute(scriptSQL);
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true);
            }
        });
    }
    _Db_Pg_DataGet(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataGet / Var scriptSQL \n ${scriptSQL} `);
                return yield myDataBase.pag.DataGet(scriptSQL);
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true);
                return {};
            }
        });
    }
    _Db_Pg_DataBinding(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /* 16/12/2023 Method que será excluído em breve */
                yield this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataBinding / Var scriptSQL \n ${scriptSQL} `);
                const result = yield myDataBase.pag.DataGet(this._Db_Pg_script(scriptSQL));
                yield this.binding(result[0]);
            }
            catch (e) {
                Tools_1.default.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true);
                throw `MODELDB | ERRO ${e} \n SCRIPT SQL \n ${scriptSQL}`;
            }
        });
    }
    _DEBUG(stringMessage) {
        return __awaiter(this, void 0, void 0, function* () {
            if (this.ENVIRONMENT == "DEB")
                Tools_1.default.pagConsoleLog(stringMessage, true);
        });
    }
    ZanthusSQL_DataGet(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dados = {};
                //dados = await sqlserver_pool.DataGet(scriptSQL) 26/09/2024
                dados = yield myDataBase.zanthusSQL.DataGet(scriptSQL);
                return Promise.resolve(dados);
            }
            catch (e) {
                console.log(`modelTb (extends) | Sql Server Data Get \n Error --->> ${e}`);
                return {};
            }
        });
    }
    ZanthusPostgre_DataGet(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let dados = {};
                //dados = await sqlserver_pool.DataGet(scriptSQL) 26/09/2024
                dados = yield myDataBase.zanthusSQL.DataGet(scriptSQL);
                return Promise.resolve(dados);
            }
            catch (e) {
                console.log(`modelTb (extends) | Sql Server Data Get \n Error --->> ${e}`);
                return {};
            }
        });
    }
}
exports.modelTb = modelTb;
class modelReport {
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`;
    }
    static Get(DataResultFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield myDataBase.pag.DataGet(DataResultFunction);
                return result;
            }
            catch (e) {
                throw `modelTb ERROR | ${e}`;
            }
        });
    }
    static Execute(DataExecuteFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield myDataBase.pag.Execute(DataExecuteFunction);
                return true;
            }
            catch (e) {
                throw `Execute Error: | ${e}`;
            }
        });
    }
}
exports.modelReport = modelReport;
class mdoReport {
    constructor() { }
    dataPag_get(DataResultFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield myDataBase.pag.DataGet(DataResultFunction);
                return result;
            }
            catch (e) {
                throw `modelTb ERROR | ${e}`;
            }
        });
    }
    dataPag_execute(DataResultFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield myDataBase.pag.Execute(DataResultFunction);
                return true;
            }
            catch (e) {
                throw `Execute Error: | ${e}`;
            }
        });
    }
    dataZanthus_get(DataResultFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const result = yield myDataBase.zanthusSQL.DataGet(DataResultFunction);
                return result;
            }
            catch (e) {
                throw `modelTb ERROR | ${e}`;
            }
        });
    }
    filterset(request) { }
}
exports.mdoReport = mdoReport;
class clsBase {
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`;
        this.myTools = new Tools_1.default();
    }
}
exports.clsBase = clsBase;
class clsBasicReport {
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`;
        this.myTools = new Tools_1.default();
        this.myDataBase = new DataBase_1.default();
    }
}
exports.clsBasicReport = clsBasicReport;
