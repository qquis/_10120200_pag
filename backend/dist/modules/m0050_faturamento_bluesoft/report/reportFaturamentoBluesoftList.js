"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const modelFaturamentoBluesoft_1 = __importDefault(require("../model/modelFaturamentoBluesoft"));
const myBase = new modelbase_1.clsBase();
class reportFaturamentoBluesoftList {
    static sql(filter) {
        let sql = `SELECT 		em.em_cdempresa                                    
                   ,	em.em_descricao                                    
                   ,	f.op_cdoperacao                                    
                   ,	op.op_descricao                                    
                   ,	f.fat_blue_seq                                     
                   ,	f.numeropedido                                     
                   ,	f.numeropedido_fv
                   ,    f.df_nf_seq_blue
                   ,    f.df_nf_seq_blue_dev                                  
                   ,	f.fat_blue_status_cd                               
                   ,	st.fat_blue_status_descricao
                   ,    st.statusfaturamento
                   ,    sf.statusfaturamento_descricao                        
                   ,	f.fat_blue_tipo_cd                                 
                   ,    tp.fat_blue_tipo_descricao                         
                   ,	f.cdpessoabluesoft_cliente  as cdpessoabluesoft_cliente 
                   ,    cp.cpf_cnpj as cpf_cnpj_cliente 
                   ,	cb.nome_razao               as cliente_nome_razao        
                   ,	cp.cdparticipante           as cliente_cdparticipante    
                   ,	f.cdpessoabluesoft_vendedor                              
                   ,	f.tabelapreco_cd                                   
                   ,	vb.nome_razao               as vendedor_nome_razao        
                   ,	vp.cdparticipante           as vendedor_cdparticipante    
                   ,	f.tabelapreco_versao_cd                            
                   ,	f.fv_prazopgto_cd                                  
                   ,	f.tipo_entrega_descricao                           
                   ,	f.origem_pedido                                    
                   ,	f.data_emissao                                     
                   ,	f.data_faturamento                                 
                   ,	f.numero_itens                                     
                   ,	f.valor_pedido                                     
                   ,	f.valor_faturamento                                
                   ,	COALESCE(f.transportadora_descricao,'') AS transportadora_descricao 
                   ,	COALESCE(f.transportadora_placaveiculo, '') AS transportadora_placaveiculo 
                   ,    tb.fv_tabelapreco_descricao 
                   ,    pz.fv_prazopgto_descricao
                   ,    gr.descricao as descricaogrupoeconomico
				   ,    nf.df_nf_seq_blue as nf_seq_blue
				   ,    nf.df_nf_numero   as nf_numero
				   ,	coalesce(ne.df_nf_seq_blue,0) as nf_seq_blue_dev 
				   ,	coalesce(ne.df_nf_numero,0)   as nf_numero_dev                    
           FROM 		tbfaturamento_bluesoft			 f 
           left join    tbdocumentofiscal                nf on nf.df_nf_seq_blue = f.df_nf_seq_blue
		   left join 	tbdocumentofiscalorigem 		 o  on o.df_nf_seq_blue_origem = f.df_nf_seq_blue 
		   left join    tbdocumentofiscal                ne on ne.df_nf_seq_blue = o.df_nf_seq_blue and ne.df_entrada_saida = 'E' and coalesce(ne.df_data_cancelamento, '1900-01-01') = '1900-01-01'            
           left join 	tboperacao						 op on op.op_cdoperacao = f.op_cdoperacao 
           left join    tbempresa						 em on em.em_cdempresa = op.em_cdempresa 
           left join    tbfaturamento_bluesoft_status    st on st.fat_blue_status_cd = f.fat_blue_status_cd 
           left join    tbfaturamento_bluesoft_tipo      tp on tp.fat_blue_tipo_cd = f.fat_blue_tipo_cd 
           left join    tbpessoabluesoft				    cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente 
           left join    tbparticipante_bluesoft          cp on cp.cdpessoabluesoft = f.cdpessoabluesoft_cliente 
           left join    tbpessoabluesoft                 vb on vb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
           left join    tbparticipante_bluesoft          vp on vp.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
           left join    tbfaturamentostatus              sf on sf.statusfaturamento = st.statusfaturamento
           left join    tbgrupoeconomico                 gr on gr.cdgrupoeconomico = cp.cdgrupoeconomico
           left join    tbforca_venda_tabpreco           tb on tb.fv_tabelapreco_cd = f.tabelapreco_cd 
           left join    tbforca_venda_prazopgto          pz on pz.fv_prazopgto_cd = f.fv_prazopgto_cd
         where		1 = 1 `;
        if (filter.em_cdempresa) {
            sql += ` and em.em_cdempresa = ${filter.em_cdempresa}`;
        }
        if (filter.op_cdoperacao) {
            sql += ` and f.op_cdoperacao = ${filter.op_cdoperacao}`;
        }
        if (filter.statusfaturamentoFiltrar) {
            /* Se existir o statusfaturamentofilter */
            if (parseInt(filter.statusfaturamentoFiltrar) === 1) {
                if (filter.statusfaturamento) {
                    sql += ` and st.statusfaturamento = ${filter.statusfaturamento}`;
                    //Vendas não devolvidas 
                    if (filter.statusfaturamento === 1) {
                        sql += ` and coalesce(f.df_nf_seq_blue_dev ,0) = 0`;
                    }
                }
                if (filter.fat_blue_status_cd && filter.fat_blue_status_cd != 0) {
                    sql += ` and f.fat_blue_status_cd = ${filter.fat_blue_status_cd}`;
                }
            }
            else if (parseInt(filter.statusfaturamentoFiltrar) === 0) {
                sql += ` and st.statusfaturamento in (0,1) `;
            }
        }
        if (filter.numeropedido && filter.numeropedido != 0) {
            sql += ` and f.numeropedido = ${filter.numeropedido}`;
        }
        else {
            if (filter.dataFaturamento_filter && filter.dataFaturamento_filter == 1) {
                let dataFaturamento_ini = modelbase_1.clsTools._datemomentDatStrToDate(`${filter.dataFaturamento_ini}`, `YYYY-MM-DD`);
                let dataFaturamento_fim = modelbase_1.clsTools._datemomentDatStrToDate(`${filter.dataFaturamento_fim}`, `YYYY-MM-DD`);
                sql += ` and f.data_faturamento >= '${modelbase_1.clsTools._datemomentDateToStr(dataFaturamento_ini, `YYYY-MM-DD`)}'
                        and f.data_faturamento <= '${modelbase_1.clsTools._datemomentDateToStr(dataFaturamento_fim, `YYYY-MM-DD`)}'
                    `;
            }
            if (filter.dataPedidoEmissao_filter && filter.dataPedidoEmissao_filter == 1) {
                let dataPedidoEmissao_ini = modelbase_1.clsTools._datemomentDatStrToDate(`${filter.dataPedidoEmissao_ini}`, `YYYY-MM-DD`);
                let dataPedidoEmissao_fim = modelbase_1.clsTools._datemomentDatStrToDate(`${filter.dataPedidoEmissao_fim}`, `YYYY-MM-DD`);
                sql += ` and f.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataPedidoEmissao_ini, `YYYY-MM-DD`)}'
                        and f.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataPedidoEmissao_fim, `YYYY-MM-DD`)}'
                    `;
            }
            if (filter.descricaogrupoeconomico && filter.descricaogrupoeconomico != "") {
                sql += ` and UPPER(gr.descricao) like '%${filter.descricaogrupoeconomico.toUpperCase()}%'`;
            }
        }
        if (filter.cdparticipantevendedor) {
            sql += ` and vp.cdparticipante = ${filter.cdparticipantevendedor}`;
        }
        //console.log(`reportFaturamentoBluesoftList | sql \n ${sql}`)
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield myBase.myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
    static getModel(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let list = [];
            let result = yield this.get(filter);
            for (const [key, value] of Object.entries(result)) {
                let item = new modelFaturamentoBluesoft_1.default();
                item.model_binding(value);
                list.push(item);
            }
            return list;
        });
    }
}
exports.default = reportFaturamentoBluesoftList;
