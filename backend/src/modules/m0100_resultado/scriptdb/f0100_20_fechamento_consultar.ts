
type f0100_20_fechamento_consultar_parametros = { 
        competencia_cd : number
        op_cdoperacao: number
        r_resp_cd: number
        r_centro_op_cd: number
        r_cd: number
}

export default class f0100_20_fechamento_consultar {
        public static sqlScript_VERSION(): string {return `f0100_20_1012011_fechamento_consultar`}
        public static get(parametros : f0100_20_fechamento_consultar_parametros) : string { 
                let sql =  `SELECT * FROM ${f0100_20_fechamento_consultar.sqlScript_VERSION()}
                        (
                                vcompetencia_cd:= ${parametros.competencia_cd}
                             ,  vop_cdoperacao:= ${parametros.op_cdoperacao} 
                             ,  vr_resp_cd:= ${parametros.r_resp_cd}
                             ,  vr_centro_op_cd:= ${parametros.r_centro_op_cd}
                             ,  vr_cd:= ${parametros.r_cd}
                        )
                
                `
                return sql;
        }

}