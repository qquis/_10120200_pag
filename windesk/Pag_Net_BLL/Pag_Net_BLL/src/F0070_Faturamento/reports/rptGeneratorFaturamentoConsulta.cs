using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0070_Faturamento.reports
{

    public class rptFaturamentoConsulta
    {
        public DataTable report;
        public Models.model_faturamento registro;
        public int Count;
        public rptFaturamentoConsulta() { }
    }
    public static class rptGeneratorrptFaturamentoConsulta
    {
        public static rptFaturamentoConsulta Get(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.globalFilter filter)
        {
            rptFaturamentoConsulta RPT = new rptFaturamentoConsulta();
            try
            {
                DBDataTable DB = BDCommand.DBDataTableGet(MyConnect, sqlRegistro(filter));
                RPT.report = DB.List;
                RPT.Count = DB.Count;

                Models.model_faturamento _registro = new Models.model_faturamento();
                _registro.binding(DB.List.Rows[0]);

                RPT.registro = _registro;

                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static rptFaturamentoConsulta List(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.globalFilter filter)
        {
            rptFaturamentoConsulta RPT = new rptFaturamentoConsulta();
            try
            {
                DBDataTable DB = BDCommand.DBDataTableGet(MyConnect, sqlList(filter));
                RPT.report = DB.List;
                RPT.Count = DB.Count;
                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        private static string sqlRegistro(interfaces.globalFilter filter)
        {
            string sql = "	SELECT  f.seqfaturamento				                            as seqfaturamento"
                  + "          ,	o.seqfaturamentoorigem 			                            as seqfaturamentoorigem"
                  + "          ,	coalesce(ct.seqfaturamento_uuid,'') 			            as seqfaturamento_uuid"
                  + "          ,	f.em_cdempresa									            as em_cdempresa"
                  + "          ,	em.em_descricao 								            as em_descricao"
                  + "          ,	f.op_cdoperacao 								            as op_cdoperacao"
                  + "          ,	op.op_descricao 								            as op_descricao"
                  + "          ,	f.cdparticipantecliente 						            as cdparticipantecliente"
                  + "          ,	pc.cpf_cnpj 									            as cliente_cpf_cnpj"
                  + "          ,	pc.nome_razao 									            as cliente_nome_razao"
                  + "          ,    bc.cdpessoabluesoft                                         as cliente_cdpessoabluesoft "
                  + "          ,	f.cdparticipantevendedor 						            as cdparticipantevendedor"
                  + "          ,	pv.cpf_cnpj 									            as vendedor_cpf_cnpj"
                  + "          ,	pv.nome_razao 									            as vendedor_nome_razao"
                  + "          ,    bv.cdpessoabluesoft                                         as vendedor_cdpessoabluesoft "
                  + "          ,	f.dataemissao 									            as dataemissao"
                  + "          ,	f.datafaturamento								            as datafaturamento"
                  + "          ,	coalesce(o.numeropedido,0) 									as numeropedido"
                  + "          ,	coalesce(o.sat_ecf,0)										as sat_ecf"
                  + "          ,	coalesce(o.cupomfiscal,0)									as cupomfiscal"
                  + "          ,	coalesce(o.df_nf_seq_blue,0) 								as df_nf_seq_blue"
                  + "		   ,	coalesce(dz.fat_zanthus_cupomfiscal_valor_m45ak,0) 		    as cupomfiscal_valor "
                  + "          ,	coalesce(dz.fat_zanthus_notafiscal_chave_m45xb, '') 	    as cupomfiscal_chave "
                  + "          ,	coalesce(nf.df_nf_numero,0) 								as df_nf_numero"
                  + "          ,	coalesce(nf.df_data_emissao,'1900-01-01')   				as df_data_emissao"
                  + "          , 	coalesce(nf.df_valor_total,0) 								as df_valor_total"
                  + "          ,	coalesce(nf.df_chave,'')    					            as df_chave"
                  + "          ,    coalesce(nf.df_nf_tipo,9999)                                as df_nf_tipo "
                  + "          ,    coalesce(nt.df_nf_tipo_descricao,'')                        as df_nf_tipo_descricao "
                  + "          ,    f.statusfaturamento                                         as statusfaturamento "
                  + "          ,    st.statusfaturamento_descricao                              as statusfaturamento_descricao "
                  + "          ,	coalesce(itens.faturamento_pag_itens_qtde,0)                as faturamento_pag_itens_qtde "
                  + "          ,	coalesce(faturamento_pag_itens_qtde ,0)                     as faturamento_pag_itens_qtde"
                  + "          ,	coalesce(ec_valorcusto_faturamento_total,0)                 as ec_valorcusto_faturamento_total"
                  + "          ,	coalesce(ec_valorcusto_precificacao_total,0)                as ec_valorcusto_precificacao_total "
                  + "          ,	coalesce(valortotalfaturamentobase,0)                       as valortotalfaturamentobase "
                  + "          ,	coalesce(valortotalsubsidioscorrentes,0)                    as valortotalsubsidioscorrentes"
                  + "          ,	coalesce(valortotalfaturamento,0)                           as valortotalfaturamento"
                  + "          ,	coalesce(valortotaldescontofinanceiro,0)                    as valortotaldescontofinanceiro"
                  + "          ,	coalesce(valortotalfaturamentobruto,0)                      as valortotalfaturamentobruto"
                  + "          ,	coalesce(valortotalsubsidiosaplicados,0)                    as valortotalsubsidiosaplicados"
                  + "          ,	coalesce(valortotalfaturamentoliquido,0)                    as valortotalfaturamentoliquido"
                  + "  FROM 		tbfaturamento 			f"
                  + "  inner join	tbfaturamentoorigem 	o 	on o.seqfaturamento = f.seqfaturamento"
                  + "  left  join   tbfaturamento_controle	ct	on ct.seqfaturamento = f.seqfaturamento"
                  + "			                        and ct.seqfaturamentoorigem = o.seqfaturamentoorigem"
                  + "  left join 	tbempresa				em  on em.em_cdempresa = f.em_cdempresa"
                  + "  left join 	tboperacao				op  on op.op_cdoperacao = f.op_cdoperacao"
                  + "  left join    tbdocumentofiscal 		nf	on nf.df_nf_seq_blue = o.df_nf_seq_blue"
                  + "  left join    tbdocumentofiscal_tipo  nt  on nt.df_nf_tipo = nf.df_nf_tipo "
                  + "  left join    tbparticipante 			pc  on pc.cdparticipante = f.cdparticipantecliente"
                  + "  left join    tbparticipante 			pv  on pv.cdparticipante = f.cdparticipantevendedor"
                  + "  left join    tbpessoabluesoft 		bc  on bc.cdpessoabluesoft = pc.cdpessoabluesoft "
                  + "  left join    tbpessoabluesoft 	    bv  on bv.cdpessoabluesoft = pv.cdpessoabluesoft "
                  + "  left join    tbfaturamentozanthus    dz  on dz.fat_zanthus_sat_ecf_m00ac = o.sat_ecf "
                  + "				   and dz.fat_zanthus_cupomfiscal_m00ad = o.cupomfiscal "
                  + "   			   and dz.fat_zanthus_data_m00af = f.datafaturamento "
                  + "				   and dz.fat_zanthus_data_m00af = f.datafaturamento "
                  + "  left join    tbfaturamentostatus     st  on st.statusfaturamento = f.statusfaturamento "

                  + "  left join   (	select  xo.seqfaturamentoorigem "
                  + "                       ,   xf.seqfaturamento "
                  + "                       ,   count(*)                                                as faturamento_pag_itens_qtde "
                  + "                       ,	sum(xi.ec_valorcusto_faturamento_total)                  as ec_valorcusto_faturamento_total "
                  + "                       ,	sum(xi.ec_valorcusto_precificacao_total)                 as ec_valorcusto_precificacao_total  "
                  + "            	        ,   sum(xi.valortotalfaturamentobase)                       as valortotalfaturamentobase "
                  + "            	        ,   sum(coalesce(xi.valortotalsubsidioscorrentes,0))        as valortotalsubsidioscorrentes "
                  + "            	        ,   sum(xi.valortotalfaturamento)                           as valortotalfaturamento"
                  + "            	        ,   sum(coalesce(xi.valortotaldescontofinanceiro,0))         as valortotaldescontofinanceiro "
                  + "            	        ,   sum(coalesce(xi.valortotalfaturamentobruto,0))           as valortotalfaturamentobruto "
                  + "                       ,   sum(coalesce(xi.valortotalsubsidiosaplicados,0))         as valortotalsubsidiosaplicados "
                  + "            	        ,   sum(coalesce(xi.valortotalfaturamentoliquido,0))         as valortotalfaturamentoliquido "
                  + "              from 		tbfaturamentoitens   xi "
                  + "              inner join   tbfaturamentoorigem  xo on xo.seqfaturamentoorigem = xi.seqfaturamentoorigem "
                  + "              inner join   tbfaturamento        xf on xf.seqfaturamento = xo.seqfaturamento "
                  + "              where        1 = 1 "
                  + "              group by     xo.seqfaturamentoorigem , xf.seqfaturamento "
                  + "           )  itens on itens.seqfaturamentoorigem = o.seqfaturamentoorigem and itens.seqfaturamento = f.seqfaturamento "


                  + "  where		1 = 1";
                  sql += " and f.seqfaturamento = " + filter.seqfaturamento ;
            
            return sql;
        }

        private static string sqlList(interfaces.globalFilter filter)
        {
            string sql = "	SELECT 		f.seqfaturamento				                as seqfaturamento"
                       + "          ,	o.seqfaturamentoorigem 			                as seqfaturamentoorigem"
                       + "          ,	coalesce(ct.seqfaturamento_uuid,'') 			as seqfaturamento_uuid"
                       + "          ,	f.em_cdempresa									as em_cdempresa"
                       + "          ,	em.em_descricao 								as em_descricao"
                       + "          ,	f.op_cdoperacao 								as op_cdoperacao"
                       + "          ,	op.op_descricao 								as op_descricao"
                       + "          ,	f.cdparticipantecliente 						as cdparticipantecliente"
                       + "          ,	pc.cpf_cnpj 									as cliente_cpf_cnpj"
                       + "          ,	pc.nome_razao 									as cliente_nome_razao"
                       + "          ,	f.cdparticipantevendedor 						as cdparticipantevendedor"
                       + "          ,	pv.cpf_cnpj 									as vendedor_cpf_cnpj"
                       + "          ,	pv.nome_razao 									as vendedor_nome_razao"
                       + "          ,	f.dataemissao 									as dataemissao"
                       + "          ,	f.datafaturamento								as datafaturamento"
                       + "          ,	o.numeropedido 									as numeropedido"
                       + "          ,	o.sat_ecf										as sat_ecf"
                       + "          ,	o.cupomfiscal									as cupomfiscal"
                       + "          ,	o.df_nf_seq_blue 								as df_nf_seq_blue"
                       + "          ,	nf.df_nf_numero 								as df_nf_numero"
                       + "          , 	nf.df_valor_total 								as df_valor_total"
                       + "          ,	nf.df_chave 									            as df_chave"
                       + "			,	coalesce(dz.fat_zanthus_cupomfiscal_valor_m45ak,0) 		    as cupomfiscal_valor "
                       + "          ,	coalesce(dz.fat_zanthus_notafiscal_chave_m45xb, '') 	    as cupomfiscal_chave "
                       + "          ,	coalesce(itens.faturamento_pag_itens_qtde,0)   as faturamento_pag_itens_qtde "
                       + "          ,	coalesce(itens.faturamento_pag_itens_valor,0)  as faturamento_pag_itens_valor "
                       + "          ,   f.statusfaturamento                            as statusfaturamento "
                       + "          ,   st.statusfaturamento_descricao                 as statusfaturamento_descricao "
                       + "          ,   itens.faturamento_pag_itens_qtde               as faturamento_pag_itens_qtde "
                       + "          ,   itens.faturamento_pag_itens_valor              as faturamento_pag_itens_valor "
                       + "  FROM 		tbfaturamento 			f"
                       + "  inner join	tbfaturamentoorigem 	o 	on o.seqfaturamento = f.seqfaturamento"
                       
                       + "  left  join  tbfaturamento_controle	ct	on ct.seqfaturamento = f.seqfaturamento"
                       + "			                               and ct.seqfaturamentoorigem = o.seqfaturamentoorigem"

                       + "  left join 	tbempresa				em  on em.em_cdempresa = f.em_cdempresa "
                       + "  left join 	tboperacao				op  on op.op_cdoperacao = f.op_cdoperacao "
                       + "  left join   tbdocumentofiscal 		nf	on nf.df_nf_seq_blue = o.df_nf_seq_blue "
                       + "  left join   tbparticipante 			pc  on pc.cdparticipante = f.cdparticipantecliente"
                       + "  left join   tbparticipante 			pv  on pv.cdparticipante = f.cdparticipantevendedor"

                       + "  left join   tbfaturamentozanthus    dz  on  dz.fat_zanthus_sat_ecf_m00ac        = o.sat_ecf "
                       + "				                        and     dz.fat_zanthus_cupomfiscal_m00ad    = o.cupomfiscal "
                       + "   			                        and     dz.fat_zanthus_data_m00af           = f.datafaturamento "
                       
                       + "  left join   tbfaturamentostatus     st  on st.statusfaturamento = f.statusfaturamento "

                       + "  left join   (	select  count(*) as faturamento_pag_itens_qtde "
                       + "                      ,	sum(xi.valortotalfaturamento) as faturamento_pag_itens_valor "
                       + "                      , 	xo.seqfaturamentoorigem "
                       + "                      ,   xf.seqfaturamento "
                       + "              from 		tbfaturamentoitens   xi "
                       + "              inner join  tbfaturamentoorigem  xo on xo.seqfaturamentoorigem = xi.seqfaturamentoorigem "
                       + "              inner join  tbfaturamento        xf on xf.seqfaturamento = xo.seqfaturamento "
                       + "              where       1 = 1 "
                       + "              group by    xo.seqfaturamentoorigem , xf.seqfaturamento "
                       + "           )  itens on itens.seqfaturamentoorigem = o.seqfaturamentoorigem and itens.seqfaturamento = f.seqfaturamento "


                       + "  where		1 = 1";

            if (filter.em_cdempresa_list != "")
            {
                sql += " and f.em_cdempresa in (" + filter.em_cdempresa_list.ToString() + ")";
            }

            if (filter.op_cdoperacao_list != "")
            {
                sql += " and f.op_cdoperacao in (" + filter.op_cdoperacao_list.ToString() + ")";
            }

            if (filter.filtra_data_emissao == 1)
            {
                sql += " and f.dataemissao >= " + "'" + filter.dataemissao_ini.ToString("yyyy-MM-dd") + "'";
                sql += " and f.dataemissao <= " + "'" + filter.dataemissao_fim.ToString("yyyy-MM-dd") + "'";
            }

            if (filter.filtra_data_faturamento == 1)
            {
                sql += " and f.datafaturamento >= " + "'" + filter.datafaturamento_ini.ToString("yyyy-MM-dd") + "'";
                sql += " and f.datafaturamento <= " + "'" + filter.datafaturamento_fim.ToString("yyyy-MM-dd") + "'";
            }

            if (filter.numeroPedidoList != "")
            {
                sql += " and o.numeropedido in ( " + filter.numeroPedidoList.ToString() + ")";
            }

            if (filter.numeroNfeList != "")
            {
                sql += " and nf.df_nf_numero in ( " + filter.numeroNfeList.ToString() + ")";
            }

            if (filter.ECF != 0)
            {
                sql += " and o.sat_ecf = " + filter.ECF.ToString();
            }

            if (filter.numeroCupomFiscalList != "")
            {
                sql += " and o.cupomfiscal in ( " + filter.numeroCupomFiscalList.ToString() + ")";
            }

            return sql;
        }

    }
}
