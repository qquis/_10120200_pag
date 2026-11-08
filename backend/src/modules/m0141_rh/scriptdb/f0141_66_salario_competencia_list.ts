export default class f0141_66_salario_competencia_list {
        public static sqlScript_VERSION(): string {return `f0141_66_1012013_salario_competencia_list`}
        public static get(parametros : any) : string { 
                let sql =  `SELECT * FROM ${f0141_66_salario_competencia_list.sqlScript_VERSION()}
                        (
                                        vtipo_relatorio:= '${(parametros.tipo_relatorio)? parametros.tipo_relatorio : 'F'}'
                                ,	vcdparticipante:= ${(parametros.cdparticipante)? parametros.cdparticipante : 0}
                                ,	vrh_tipo_contrato_cd:= ${(parametros.rh_tipo_contrato_cd)? parametros.rh_tipo_contrato_cd : 0}
                                ,	vrh_setor_operacional_cd:= ${(parametros.rh_setor_operacional_cd)? parametros.rh_setor_operacional_cd : 0}
                                ,	vnome_razao:= '${(parametros.nome_razao)? parametros.nome_razao : ''}'
                                ,	vcompetencia_cd:= ${(parametros.competencia_cd)? parametros.competencia_cd : 0}
                                ,	vr_conta_cd:= ${(parametros.r_conta_cd)? parametros.r_conta_cd : 0}
                                ,       vorderbycolumnnumber:= ${(parametros.orderbycolumnnumber && parametros.orderbycolumnnumber > 0)? parametros.orderbycolumnnumber : 1}
                                ,       vorderbydirection:= '${(parametros.orderbydirection)? parametros.orderbydirection : 'ASC'}'
                        )
                
                `
                return sql;
        }

}