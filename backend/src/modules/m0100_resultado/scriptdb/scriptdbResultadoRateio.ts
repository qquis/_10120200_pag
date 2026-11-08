export default class scriptdbResultadoRateio { 
    static get(parametros : any) : string { 
            let sql = ` select 	 	x.r_rateio_cd 
                                ,	x.r_rateio_tipo_cd 
                                ,	t.r_rateio_tipo_descricao 
                                ,	x.r_rateio_descricao
                from	 	tbresultado_rateio x
                left join 	tbresultado_rateio_tipo t on t.r_rateio_tipo_cd = x.r_rateio_tipo_cd
                WHERE  1 = 1
                ${(parametros.r_rateio_sistema)? "AND x.r_rateio_sistema = " + parametros.r_rateio_sistema: "AND x.r_rateio_sistema = 0"}                  
                ORDER BY 4
            `
            return sql 
    } 
}