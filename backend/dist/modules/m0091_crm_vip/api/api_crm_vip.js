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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const myBase = new modelbase_1.clsBase();
class api_crm_vip {
    static getClientesAll(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultData = {};
            try {
                if (!parametros.page) {
                    parametros.page = 1;
                }
                if (!parametros.datal_alteracao_inicial) {
                    parametros.datal_alteracao_inicial = '2025-01-01';
                }
                if (!parametros.datal_alteracao_final) {
                    parametros.datal_alteracao_final = '2025-10-08';
                }
                let result = yield myBase.vipApi.vip_api_get(`/importacao/clientes?page=${parametros.page}&modified_inicial=${parametros.datal_alteracao_inicial}&modified_final=${parametros.datal_alteracao_final}`);
                resultData = result.data;
                return resultData;
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`modules | CRM VIP | Error \n ${e.message}`);
                throw new Error(`modules | CRM VIP | Error ${e.message}`);
            }
        });
    }
}
exports.default = api_crm_vip;
