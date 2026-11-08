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
/* database */
const DataBase_1 = __importDefault(require("../../../../database/DataBase"));
const myDataBase = new DataBase_1.default();
/*Script ZANTHUS SQL SERVER */
const Zanthus_Ctrl_1 = __importDefault(require("../../scriptsql/Zanthus_Ctrl"));
const Zanthus_Ctrl_Cupom_1 = __importDefault(require("../../scriptsql/Zanthus_Ctrl_Cupom"));
const Zanthus_Cupom_1 = __importDefault(require("../../scriptsql/Zanthus_Cupom"));
const Zanthus_CupomItem_1 = __importDefault(require("../../scriptsql/Zanthus_CupomItem"));
class Zanthus {
    /*
    private static async get(zanthus_script: string): Promise<object> {
        try {
            let dados = {}
                dados = await myDataBase.zanthusSQL.DataGet(zanthus_script)
                return Promise.resolve(dados);
        } catch (e){
            return Promise.reject({})
        }

    }*/
    static Ctrl_Get(filter_1) {
        return __awaiter(this, arguments, void 0, function* (filter, BaseDeDados = ``) {
            let dataObject = {};
            try {
                //if ( BaseDeDados == "ZANTHUSSQLSERVER") { 
                //     dataObject =  await myDataBase.zanthusSQL.DataGet(Zanthus_Ctrl.get(filter, BaseDeDados))
                //}
                if (BaseDeDados == "ZANTHUSPOSTGRE") {
                    dataObject = yield myDataBase.zanthusPostgre.DataGet(Zanthus_Ctrl_1.default.get(filter, BaseDeDados));
                }
                return dataObject;
            }
            catch (e) {
                return Promise.reject({});
            }
        });
    }
    static CtrlCupom_Get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield myDataBase.zanthusSQL.DataGet(Zanthus_Ctrl_Cupom_1.default.get(filter));
            }
            catch (e) {
                return Promise.reject({});
            }
        });
    }
    static CupomFiscal_Get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield myDataBase.zanthusSQL.DataGet(Zanthus_Cupom_1.default.getBaseZanthusSQLServer(filter));
            }
            catch (e) {
                return Promise.reject({});
            }
        });
    }
    static CupomFiscalItem_Get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return yield myDataBase.zanthusSQL.DataGet(Zanthus_CupomItem_1.default.getBaseZanthusSQLServer(filter));
            }
            catch (e) {
                return Promise.reject({});
            }
        });
    }
}
exports.default = Zanthus;
