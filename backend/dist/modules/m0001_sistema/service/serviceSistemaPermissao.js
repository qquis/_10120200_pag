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
const reportSistemaPermissaoList_1 = __importDefault(require("../report/reportSistemaPermissaoList"));
class serviceSistemaPermissao {
    static getFindPermissaoTarefa() {
        return __awaiter(this, arguments, void 0, function* (parametros = {}, sis_ta_cd_find) {
            let find = false;
            try {
                let list = yield reportSistemaPermissaoList_1.default.getModel(parametros);
                if (list && list.length > 0) {
                    list.find((item) => {
                        if (item.sis_ta_cd == sis_ta_cd_find) {
                            find = true;
                            return true;
                        }
                    });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`serviceSistemaPermissao`, 'getFindPermissaoTarefa', e);
                throw new Error(`serviceSistemaPermissao.getFindPermissaoTarefa`);
            }
            finally {
                return find;
            }
        });
    }
}
exports.default = serviceSistemaPermissao;
