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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class reportFaturamentoExport {
    static sql(parametro) {
        let sql = `			SELECT 					ct.faturamento_controle_seq 
				,		coalesce(df.df_nf_numero,0) as numero_nf 
				,		coalesce(df.df_entrada_saida, 'S') tipo_documento_fiscal 
				,		cast(ct.dataemissao as date) as dataemissao
				,		cast(ct.datafaturamento as date) as datafaturamento
				,		f.statusfaturamento
				,		sf.statusfaturamento_descricao 
				,		f.em_cdempresa 
                ,       em.em_descricao
                ,	    f.op_cdoperacao
                ,       op.op_descricao  
				,		f.cdparticipantevendedor
                ,       v.cdpessoabluesoft as cdpessoabluesoft_vendedor                
				,		v.cpf_cnpj as cpf_cnpj_vendedor
				,		v.nome_razao as nome_razao_vendedor
				,		f.cdparticipantecliente 
                ,       cl.cdpessoabluesoft as cdpessoabluesoft_cliente                
				,		cl.cpf_cnpj as cpf_cnpj_cliente
				,		cl.nome_razao as nome_razao_cliente
                ,       gr.cdgrupoeconomico as cdgrupoeconomico
                ,       gr.descricao as grupoeconomico                 
				,		pr.pr_cdproduto 
				,		pr.prb_cdprodutobluesoft 
				,		pr.pr_descricao 
				,		pr.pr_embalagemestoque
				,		pr.pr_embalagemcompra_fator
				,		pr.pr_embalagemcompra
                ,       pb.prb_cdbarra_principal 
                ,		cast(i.embalagemestoqueqtde as numeric(13,3))
				,		cast(i.embalagemcompraqtde as numeric(13,3))
				,		I.valortotalfaturamentobase
                ,		i.valortotalsubsidioscorrentes
                ,		i.valortotalfaturamento
                ,		i.valortotaldescontofinanceiro
                ,		i.valortotalsubsidiosaplicados
                ,		i.valortotalfaturamentoliquido				
				,		ff.fv_fabricante_descricao 
                ,       o.numeropedido 
                ,       o.numeronfe
                ,       case when coalesce(gr.johnson_cliente_top,0) = 1 then 'TOP' else 'VAREJO' end as tipo_cliente 
            FROM 		TBFATURAMENTO 		  f
			inner join  tbfaturamento_controle ct on ct.faturamento_controle_seq = f.faturamento_controle_seq 
            inner join 	tbfaturamentoorigem o on o.seqfaturamento = f.seqfaturamento
            inner join  tbfaturamentoitens  i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
			inner join  tbproduto          pr on pr.pr_cdproduto = i.pr_cdproduto 
			inner join  tbprodutobluesoft  pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft 
            inner join  tboperacao         op on op.op_cdoperacao = f.op_cdoperacao
            inner join  tbempresa          em on em.em_cdempresa = f.em_cdempresa 
			inner join  tbparticipante_bluesoft     cl on cl.cdparticipante = f.cdparticipantecliente
			inner join  tbparticipante     v on v.cdparticipante = f.cdparticipantevendedor
			inner join  tbfaturamentostatus sf on sf.statusfaturamento = f.statusfaturamento 
			inner join  tbforca_venda_fabricante ff on ff.fv_fabricante_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante
			left join   tbdocumentofiscal   df on df.df_nf_seq_blue = ct.df_nf_seq_blue 
            left join   tbgrupoeconomico    gr on gr.cdgrupoeconomico = cl.cdgrupoeconomico
            WHERE 		1 = 1
              and       f.statusfaturamento = 1
              and       i.statusfaturamentoitem = 1
              and       f.op_cdoperacao in (1,2,4)

        `;
        if (parametro.dataFaturamento_ini) {
            sql += ` AND f.datafaturamento >= '${parametro.dataFaturamento_ini}'`;
        }
        if (parametro.dataFaturamento_fim) {
            sql += ` AND f.datafaturamento <= '${parametro.dataFaturamento_fim}'`;
        }
        sql += ` ORDER BY f.datafaturamento, f.em_cdempresa, f.op_cdoperacao, f.cdparticipantevendedor, f.cdparticipantecliente `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                if (!filter.dataFaturamento_ini || !filter.dataFaturamento_fim) {
                    throw new Error('Parâmetros de filtro inválidos. dataFaturamento_ini e dataFaturamento_fim são obrigatórios.');
                }
                result = yield new modelbase_1.clsBase().myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoExport | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoExport;
