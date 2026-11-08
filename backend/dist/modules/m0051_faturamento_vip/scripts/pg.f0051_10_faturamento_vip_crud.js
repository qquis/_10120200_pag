"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class f0051_10_FaturamentoVip_CRUD {
    static sqlScript_VERSION() { return `f0051_10_1012017_faturamento_vip_crud`; }
    static get(parametros) {
        let sql = `SELECT ` + this.sqlScript_VERSION() +
            `(              sqlcommand := 'DBINSERT'				
                        ,   v_id := ${parametros.id}
                        ,   v_cliente_id := ${parametros.cliente_id}
                        ,   v_codigo := '${parametros.codigo}'
                        ,   v_data_entrega := '${modelbase_1.clsTools._datemomentDateToStr(parametros.data_entrega, 'YYYY-MM-DD HH:mm:ss')}'
                        ,   v_data_entregue := '${modelbase_1.clsTools._datemomentDateToStr(parametros.data_entregue, 'YYYY-MM-DD HH:mm:ss')}'
                        ,   v_data_faturamento := '${modelbase_1.clsTools._datemomentDateToStr(parametros.data_faturamento, 'YYYY-MM-DD HH:mm:ss')}'
                        ,   v_compra_status_id := ${parametros.compra_status_id}
                        ,   v_tipo_entrega_id := ${parametros.tipo_entrega_id}
                        ,   v_tipo_fiscal := '${parametros.tipo_fiscal}'
                        ,   v_qtd_itens := ${parametros.qtd_itens}
                        ,   v_qtd_produtos := ${parametros.qtd_produtos}
                        ,   v_volumes_frios := ${parametros.volumes_frios}
                        ,   v_volumes_comuns := ${parametros.volumes_comuns}
                        ,   v_tipo_pedido := '${parametros.tipo_pedido}' 
                        ,   v_created := '${modelbase_1.clsTools._datemomentDateToStr(parametros.created, 'YYYY-MM-DD HH:mm:ss')}'
                        ,   v_modified := '${modelbase_1.clsTools._datemomentDateToStr(parametros.modified, 'YYYY-MM-DD HH:mm:ss')}'
                        ,   v_valor_final := ${parametros.valor_final}
                        );`;
        return sql;
    }
}
exports.default = f0051_10_FaturamentoVip_CRUD;
