export default class scriptdbResultado { 
    static get(parametros : any) : string { 
            let sql = ` SELECT 	 	x.r_cd
                                ,	x.r_descricao 
                        FROM	 	tbresultado x
                        WHERE  1 = 1
                        ORDER BY 2
                    `
            return sql 
    } 
}