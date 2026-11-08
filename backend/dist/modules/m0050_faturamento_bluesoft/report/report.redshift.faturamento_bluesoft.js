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
class redshift_faturamento_bluesoft {
    static sql(filter) {
        let sql = `select pedido_forca_venda_cliente_key
                        , data_solicitacao
                        , data_faturamento
                        , data_emissao
                        , cliente
                        , vendedor 
                        , status_pedido 
                    from fato_pedido_forca_venda limit 10`;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            console.log(`reportFaturamentoBluesoft | get \n filter: ${JSON.stringify(filter)}`);
            try {
                let myBase = new modelbase_1.clsBase();
                result = yield myBase.myDataBase.redshift.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = redshift_faturamento_bluesoft;
