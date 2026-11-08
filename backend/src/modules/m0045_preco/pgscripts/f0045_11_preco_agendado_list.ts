import myTools from "../../../tools/Tools"
import reportPrecoFilter from "../interfaces"


export default class f0045_11_preco_agendado_list {
    public static sqlScript_VERSION(): string {return `f0045_11_1012003_preco_agendado_list`}
    public static SELECT(filter: reportPrecoFilter) : string {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()}
        ( 
                        vtipo_relatorio:= '${filter.tipo_relatorio}' 
                    ,   vtab_pre_cd:= ${filter.tab_pre_cd}						
                    ,   vdata_log_filter:= ${filter.data_log_filter}
                    ,   vdata_log_ini:= '${myTools.format_Date_toStr_ShortDataBase(filter.data_log_ini)}'
                    ,   vdata_log_fim:= '${myTools.format_Date_toStr_ShortDataBase(filter.data_log_fim)}'
                    ,   vpr_cdproduto:= ${filter.pr_cdproduto}
                    ,   vprb_cdprodutobluesoft_unitario:= ${filter.prb_cdprodutobluesoft_unitario}
                    ,   vprb_cdprodutobluesoft:= ${filter.prb_cdprodutobluesoft}
                    ,   vpr_descricao:= '${filter.pr_descricao}'
                    ,   vprb_descricao:= '${filter.prb_descricao}'
                    ,   vtipo_produto:= '${filter.tipo_produto}'
                    ,	vdata_agendamento_filter:= ${filter.data_agendamento_filter}
	                ,   vdata_agendamento_inicial:= '${myTools.format_Date_toStr_ShortDataBase(filter.data_agendamento_inicial)}' 
	                ,   vdata_agendamento_final:= '${myTools.format_Date_toStr_ShortDataBase(filter.data_agendamento_final)}' 
                    )`;


         return sqlscript;
    }
}


