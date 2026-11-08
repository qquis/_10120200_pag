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
class clientes {
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultData;
            try {
                resultData = yield this.call(parametros);
                return resultData.data;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `clientes.get()`, e, true);
                throw new Error(`modules | CRM VIP | Error ${e.message}`);
            }
        });
    }
    static pagination(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let numeroPaginas = 0;
            try {
                let result = yield this.call(parametros);
                if (result && result.pagination) {
                    numeroPaginas = parseInt(result.pagination.page_count);
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `clientes.pagination()`, e, true);
                throw new Error(`modules | CRM VIP | Error ${e.message}`);
            }
            finally {
                return numeroPaginas;
            }
        });
    }
    static call(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultData = {};
            try {
                if (!parametros.page) {
                    parametros.page = 1;
                }
                if (!parametros.data_ultima_alteracao_ini) {
                    parametros.data_ultima_alteracao_ini = '2025-01-01';
                }
                if (!parametros.data_ultima_alteracao_fim) {
                    const now = new Date();
                    const yyyy = now.getFullYear();
                    const mm = String(now.getMonth() + 1).padStart(2, '0');
                    const dd = String(now.getDate()).padStart(2, '0');
                    parametros.data_ultima_alteracao_fim = `${yyyy}-${mm}-${dd}`;
                }
                let url = `/importacao/clientes`;
                if (parametros.id) {
                    url += `/${parametros.id}`;
                }
                else {
                    url += `?page=${parametros.page}`;
                    if (parametros.data_ultima_alteracao_ini) {
                        url += `&modified_inicial=${parametros.data_ultima_alteracao_ini}`;
                    }
                    if (parametros.data_ultima_alteracao_fim) {
                        url += `&modified_final=${parametros.data_ultima_alteracao_fim}`;
                    }
                }
                resultData = yield myBase.vipApi.vip_api_get(url);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `clientes.call()`, e, true);
            }
            finally {
                return resultData;
            }
        });
    }
}
exports.default = clientes;
