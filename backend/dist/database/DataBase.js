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
const sqlserver_1 = __importDefault(require("./sqlserver"));
const pagPostgre_1 = __importDefault(require("./pagPostgre"));
const redshift_1 = __importDefault(require("./redshift"));
const zanthusPostgre_1 = __importDefault(require("./zanthusPostgre"));
const Tools_1 = __importDefault(require("../tools/Tools"));
const modelbase_1 = require("../model/modelbase");
class pag {
    DataGet(query_string_1) {
        return __awaiter(this, arguments, void 0, function* (query_string, generateError = false) {
            try {
                return yield pagPostgre_1.default.DataGet(query_string, generateError);
            }
            catch (e) {
                if (generateError) {
                    throw new Error(`DataGet _ SQL Error: ${e}`);
                }
                else {
                    yield Tools_1.default.pagConsoleLog(`Pag.DataBase.DataGet | 
                            -----------------------------------------------------
                            ERROR
                            -----------------------------------------------------  
                            ${e} 
                            QUERY
                            -----------------------------------------------------  
                            ${query_string}`, true);
                    return {};
                }
            }
        });
    }
    Execute(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield pagPostgre_1.default.Execute(query_string);
        });
    }
    FunctionNoParameterExecute(nameFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            yield pagPostgre_1.default.Execute(`SELECT ${nameFunction} ()`);
        });
    }
}
class zanthusPostgre {
    DataGet(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield zanthusPostgre_1.default.DataGet(query_string);
        });
    }
    Execute(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield zanthusPostgre_1.default.Execute(query_string);
                return 1;
            }
            catch (e) {
                let numArquivo = Math.random() * 1000;
                yield modelbase_1.clsTools.PagErrorException('M0085_ZANTHUS', 'zanthusPostgre.DataBase.Execute', e, false, query_string, `POSTGRE_ERROR_${numArquivo}`);
                return -1;
                /*
                myTools.pagConsoleLog(`ZanthusPostgre.DataBase.Execute |
                                -----------------------------------------------------
                                ERROR
                                -----------------------------------------------------
                                ${e}
                                QUERY
                                -----------------------------------------------------
                                ${query_string}`, true)
                return -1*/
            }
        });
    }
    FunctionNoParameterExecute(nameFunction) {
        return __awaiter(this, void 0, void 0, function* () {
            yield zanthusPostgre_1.default.Execute(`SELECT ${nameFunction} ()`);
        });
    }
}
class zanthusSQL {
    DataGet(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield sqlserver_1.default.DataGet(query_string);
        });
    }
    Execute(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield sqlserver_1.default.Execute(query_string);
        });
    }
}
class redshift {
    DataGet(query_string) {
        return __awaiter(this, void 0, void 0, function* () {
            return yield redshift_1.default.DataGet(query_string);
        });
    }
}
class DataBase {
    constructor() {
        this.MAX_UPDATE_DEFAULT = 200;
        this.pag = new pag();
        this.zanthusSQL = new zanthusSQL();
        this.redshift = new redshift();
        this.zanthusPostgre = new zanthusPostgre();
        this.MAX_UPDATE_DEFAULT = parseInt(process.env.SERVER_DATABASE_MAX_UPDATE_DEFAULT || '200');
    }
    test() {
        return __awaiter(this, void 0, void 0, function* () {
            return yield sqlserver_1.default.test();
        });
    }
    RecordItem(object, indexRecord) {
        return __awaiter(this, void 0, void 0, function* () {
            if (object && Object.entries(object).length > 0) {
                return Object.entries(object)[indexRecord][1];
            }
            else {
                return {};
            }
        });
    }
}
exports.default = DataBase;
