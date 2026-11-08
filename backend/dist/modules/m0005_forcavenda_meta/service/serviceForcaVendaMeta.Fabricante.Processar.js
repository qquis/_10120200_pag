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
const modelbase_1 = require("../../../model/modelbase");
/*  CONSTANTES _________________________________________________________________________________*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0005 FORCA VENDA META - Service | Meta Fabricante Processar";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE = ``;
/*  ____________________________________________________________________________________________*/
const sql_1 = __importDefault(require("../../m0005_forcavenda_meta/sql/sql"));
class serviceForcaVendaMetaFabricanteProcessar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = sql_1.default.f0005_30_fv_meta_fab_processar.get({
                    fv_fab_meta_cd: parametro.fv_fab_meta_cd
                });
                let result = yield this._db(sql);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "start", e);
            }
        });
    }
    static _db(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let __db = new modelbase_1.clsBase();
                result = yield __db.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "_db", e);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = serviceForcaVendaMetaFabricanteProcessar;
