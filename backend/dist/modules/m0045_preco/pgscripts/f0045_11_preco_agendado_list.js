"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class f0045_11_preco_agendado_list {
    static sqlScript_VERSION() { return `f0045_11_1012003_preco_agendado_list`; }
    static SELECT(filter) {
        let sqlscript = `Select * from ${this.sqlScript_VERSION()}
        ( 
                        vtipo_relatorio:= '${filter.tipo_relatorio}' 
                    ,   vtab_pre_cd:= ${filter.tab_pre_cd}						
                    ,   vdata_log_filter:= ${filter.data_log_filter}
                    ,   vdata_log_ini:= '${Tools_1.default.format_Date_toStr_ShortDataBase(filter.data_log_ini)}'
                    ,   vdata_log_fim:= '${Tools_1.default.format_Date_toStr_ShortDataBase(filter.data_log_fim)}'
                    ,   vpr_cdproduto:= ${filter.pr_cdproduto}
                    ,   vprb_cdprodutobluesoft_unitario:= ${filter.prb_cdprodutobluesoft_unitario}
                    ,   vprb_cdprodutobluesoft:= ${filter.prb_cdprodutobluesoft}
                    ,   vpr_descricao:= '${filter.pr_descricao}'
                    ,   vprb_descricao:= '${filter.prb_descricao}'
                    ,   vtipo_produto:= '${filter.tipo_produto}'
                    ,	vdata_agendamento_filter:= ${filter.data_agendamento_filter}
	                ,   vdata_agendamento_inicial:= '${Tools_1.default.format_Date_toStr_ShortDataBase(filter.data_agendamento_inicial)}' 
	                ,   vdata_agendamento_final:= '${Tools_1.default.format_Date_toStr_ShortDataBase(filter.data_agendamento_final)}' 
                    )`;
        return sqlscript;
    }
}
exports.default = f0045_11_preco_agendado_list;
