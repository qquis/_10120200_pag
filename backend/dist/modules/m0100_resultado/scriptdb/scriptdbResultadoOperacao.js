"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class scriptdbResultadoOperacao {
    static get(parametros) {
        let sql = `  select 	 	x.op_cdoperacao 
                                ,	o.op_descricao 
                from	 	tbresultado_centro_operacional x
                left join 	tboperacao o on o.op_cdoperacao = x.op_cdoperacao
                WHERE 1 = 1
                GROUP BY            x.op_cdoperacao 
                                ,	o.op_descricao 
                                union 
                                   select 0 as op_cdoperacao, 'Todos' as op_descricao
                ORDER BY 1 asc
            `;
        return sql;
    }
}
exports.default = scriptdbResultadoOperacao;
