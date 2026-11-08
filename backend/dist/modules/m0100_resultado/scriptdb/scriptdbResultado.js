"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class scriptdbResultado {
    static get(parametros) {
        let sql = ` SELECT 	 	x.r_cd
                                ,	x.r_descricao 
                        FROM	 	tbresultado x
                        WHERE  1 = 1
                        ORDER BY 2
                    `;
        return sql;
    }
}
exports.default = scriptdbResultado;
