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
class FaturamentoVipPedido {
    static get(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let resultData;
            try {
                resultData = yield this.call(parametros);
                return resultData.data;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.get()`, e, true);
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
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.pagination()`, e, true);
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
                let url = `/importacao/pedidos?filter=1`;
                if (parametros.page) {
                    url += `&page=${parametros.page}`;
                }
                if (parametros.start_created) {
                    url += `&start_created=${parametros.start_created}`;
                }
                if (parametros.end_created) {
                    url += `&end_created=${parametros.end_created}`;
                }
                resultData = yield myBase.vipApi.vip_api_get(url);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modules | CRM VIP`, `FaturamentoVipPedido.call()`, e, true);
            }
            finally {
                return resultData;
            }
        });
    }
}
exports.default = FaturamentoVipPedido;
