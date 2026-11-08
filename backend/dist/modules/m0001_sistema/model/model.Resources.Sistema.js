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
const tbsistemanucleoprocedimento_1 = __importDefault(require("../tbs/tbsistemanucleoprocedimento"));
class modelSistemaRelational {
    static limiteRegBloqUpdateGet(sis_nucleo_prc_cd) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = tbsistemanucleoprocedimento_1.default.sqlSelectLimiteRegBloqUpdate(sis_nucleo_prc_cd);
            let myclsBase = new modelbase_1.clsBase();
            let result = yield myclsBase.myDataBase.pag.DataGet(sql);
            if (result && result.length > 0) {
                return result[0].limite_reg_bloq_update;
            }
            else {
                return 0;
            }
        });
    }
}
exports.default = modelSistemaRelational;
