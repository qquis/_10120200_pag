export default class scriptdbResultadoResponvael { 
    static get(parametros : any) : string { 
            let sql = ` select 	 	x.r_resp_cd
                                ,	x.r_resp_descricao 
                                ,	coalesce(t.r_rateio_cd,0) as r_rateio_cd 
                                ,   coalesce(t.r_rateio_descricao,'') as r_rateio_descricao
                from	 	tbresultado_resp x
                left join 	tbresultado_rateio t on t.r_rateio_cd = x.r_rateio_cd
                WHERE  1 = 1
                union 
                select 0 as r_resp_cd, 'Todos' as r_resp_descricao, 0 as r_rateio_cd, '' as r_rateio_descricao
                ORDER BY 1
            `
            return sql 
    } 
}