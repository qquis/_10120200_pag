using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.src.F0070_Faturamento.Models;

namespace Pag_Net.src.F0070_Faturamento.reports
{


    public class rptFaturamentoAnalise 
    {
        public model_rpt_faturamento_analise[] report { get; set;  }
        public double __Wk_Total_embalagemestoqueqtde { get; set; }
        public double __Wk_Total_embalagemcompraqtde { get; set; }
        public double __Wk_Total_ec_valorcusto_faturamento_total { get; set; }
        public double __Wk_Total_valortotalfaturamentoBASE { get; set; }
        public double __Wk_Total_valortotalSubsidiosCorrentes { get; set; }
        public double __Wk_Total_valortotalfaturamento  { get; set;  }
        public double __Wk_Total_valortotalfaturamentoliquido { get; set; }
        public double __Wk_MG_valortotalfaturamento { get; set; }
        public double __Wk_MG_valortotalfaturamentoliquido { get; set; }
        public double __Wk_MG_valortotalfaturamentoBASE { get; set; }
        public bool _orderbyCrescente { get; set;  }
        public int __Wk_Numero_Itens { get; set; }
        public rptFaturamentoAnalise()
        {
            report = null;
            __Wk_Total_embalagemestoqueqtde = 0;
            __Wk_Total_embalagemcompraqtde = 0;
            __Wk_Total_ec_valorcusto_faturamento_total = 0;
            __Wk_Total_valortotalfaturamentoBASE = 0;
            __Wk_Total_valortotalSubsidiosCorrentes = 0;
            __Wk_Total_valortotalfaturamento = 0;
            __Wk_Total_valortotalfaturamentoliquido = 0;
            __Wk_MG_valortotalfaturamento = 0;
            __Wk_MG_valortotalfaturamentoliquido = 0;
            __Wk_MG_valortotalfaturamentoBASE = 0;
            __Wk_Numero_Itens = 0;
        }
    }


    public static class rptGeneratorFaturamentoAnalise 
    {
        public static rptFaturamentoAnalise Get(Pag_Net.Models.modelSistemaUsuario MyConnect, interfaces.globalFilter filter) 
        {
            try
            {
                rptFaturamentoAnalise RPT = new rptFaturamentoAnalise();
                List<Models.model_rpt_faturamento_analise> _ListFaturamento = new List<Models.model_rpt_faturamento_analise>();

                DBDataTable _DataTableFaturamento = BDCommand.DBDataTableGet(MyConnect, sql(filter));
                foreach (DataRow i in _DataTableFaturamento.List.Rows)
                {

                    Models.model_rpt_faturamento_analise item = new Models.model_rpt_faturamento_analise(i);
                    RPT.__Wk_Numero_Itens += 1;
                    RPT.__Wk_Total_embalagemestoqueqtde += item.embalagemestoqueqtde;
                    RPT.__Wk_Total_embalagemcompraqtde += item.embalagemcompraqtde;
                    RPT.__Wk_Total_ec_valorcusto_faturamento_total += item.ec_valorcusto_faturamento_total;
                    RPT.__Wk_Total_valortotalfaturamento += item.valortotalfaturamento;
                    RPT.__Wk_Total_valortotalfaturamentoliquido += item.valortotalfaturamentoliquido;

                    RPT.__Wk_Total_valortotalfaturamentoBASE += item.valortotalfaturamentobase;
                    RPT.__Wk_Total_valortotalSubsidiosCorrentes += item.valortotalsubsidioscorrentes;


                    _ListFaturamento.Add(item);
                }
                if (RPT.__Wk_Total_valortotalfaturamento > 0)
                    RPT.__Wk_MG_valortotalfaturamento = Math.Round((RPT.__Wk_Total_valortotalfaturamento - RPT.__Wk_Total_ec_valorcusto_faturamento_total) / RPT.__Wk_Total_valortotalfaturamento * 100, 2);


                if (RPT.__Wk_Total_valortotalfaturamentoliquido > 0)
                    RPT.__Wk_MG_valortotalfaturamentoliquido = Math.Round((RPT.__Wk_Total_valortotalfaturamentoliquido - RPT.__Wk_Total_ec_valorcusto_faturamento_total) / RPT.__Wk_Total_valortotalfaturamentoliquido * 100, 2);

                if (RPT.__Wk_Total_valortotalfaturamentoBASE > 0)
                    RPT.__Wk_MG_valortotalfaturamentoBASE = Math.Round((RPT.__Wk_Total_valortotalfaturamentoBASE - RPT.__Wk_Total_ec_valorcusto_faturamento_total) / RPT.__Wk_Total_valortotalfaturamentoBASE * 100, 2);

                RPT.report = _ListFaturamento.ToArray();



                return RPT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static rptFaturamentoAnalise orderBy(rptFaturamentoAnalise ReportFaturamentoAnalise, string _columnName)
        {

            rptFaturamentoAnalise _rptFaturamentoAnalise = ReportFaturamentoAnalise;
            if (ReportFaturamentoAnalise._orderbyCrescente)
            {
                ReportFaturamentoAnalise._orderbyCrescente = false;
                switch (_columnName)
                {
                    case "referencia_id":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.referencia_id).ToArray();
                        break;
                    case "referencia_descricao":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.referencia_descricao).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pr_embalagemcompra":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.pr_embalagemcompra).ToArray();
                        break;
                    case "_static_referencia":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_referencia).ToArray();
                        break;
                    case "_static_pontos":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.referencia_id).ToArray();
                        break;
                    case "_static_clientes":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_clientes).ToArray();
                        break;
                    case "_static_mix":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_mix).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Unitario":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_EmbalagemEstoque_FaturamentoBase_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Unitario":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Caixa":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_EmbalagemEstoque_FaturamentoBase_Caixa).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Caixa":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Caixa).ToArray();
                        break;
                    case "_static_faturamentobase_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_faturamentobase_margem).ToArray();
                        break;
                    case "_static_faturamento_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_faturamento_margem).ToArray();
                        break;
                    case "_static_faturamentobruto_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_faturamentobruto_margem).ToArray();
                        break;
                    case "_static_faturamentoliquido_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c._static_faturamentoliquido_margem).ToArray();
                        break;

                    case "embalagemestoqueqtde":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.embalagemestoqueqtde).ToArray();
                        break;

                    case "embalagemcompraqtde":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.embalagemcompraqtde).ToArray();
                        break;

                    case "ec_valorcusto_faturamento_total":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.ec_valorcusto_faturamento_total).ToArray();
                        break;

                    case "valortotalfaturamento":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.valortotalfaturamento).ToArray();
                        break;

                    case "valortotalfaturamentoliquido":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderBy(c => c.valortotalfaturamentoliquido).ToArray();
                        break;

                }
            }
            else
            {
                ReportFaturamentoAnalise._orderbyCrescente = true;
                switch (_columnName)
                {
                    case "referencia_id":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.referencia_id).ToArray();
                        break;
                    case "referencia_descricao":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.referencia_descricao).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pr_embalagemcompra":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.pr_embalagemcompra).ToArray();
                        break;
                    case "_static_referencia":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_referencia).ToArray();
                        break;
                    case "_static_pontos":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.referencia_id).ToArray();
                        break;
                    case "_static_clientes":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_clientes).ToArray();
                        break;
                    case "_static_mix":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_mix).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Unitario":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_EmbalagemEstoque_FaturamentoBase_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Unitario":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Caixa":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_EmbalagemEstoque_FaturamentoBase_Caixa).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Caixa":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Caixa).ToArray();
                        break;
                    case "_static_faturamentobase_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_faturamentobase_margem).ToArray();
                        break;
                    case "_static_faturamento_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_faturamento_margem).ToArray();
                        break;
                    case "_static_faturamentobruto_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_faturamentobruto_margem).ToArray();
                        break;
                    case "_static_faturamentoliquido_margem":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c._static_faturamentoliquido_margem).ToArray();
                        break;

                    case "embalagemestoqueqtde":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.embalagemestoqueqtde).ToArray();
                        break;

                    case "embalagemcompraqtde":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.embalagemcompraqtde).ToArray();
                        break;

                    case "ec_valorcusto_faturamento_total":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.ec_valorcusto_faturamento_total).ToArray();
                        break;

                    case "valortotalfaturamento":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.valortotalfaturamento).ToArray();
                        break;

                    case "valortotalfaturamentoliquido":
                        _rptFaturamentoAnalise.report = ReportFaturamentoAnalise.report.OrderByDescending(c => c.valortotalfaturamentoliquido).ToArray();
                        break;
                }
                
            }
            return _rptFaturamentoAnalise;
        }

        private static string sql(interfaces.globalFilter _filter) 
        {
            string sql = string.Format("SELECT * FROM " + scripts.F0070_50_Faturamento_rel_analise_basica._VERSION()
                            + "( vtipo_visualizacao:= " + _filter.tipo_visualizacao.ToString()
                            + " , vem_cdempresa_list:= '" + _filter.em_cdempresa_list.ToString() + "'"
                            + " , vop_cdoperacao_list:= '" + _filter.op_cdoperacao_list.ToString() + "'"
                            + " , vdata_faturamento:= " + _filter.filtra_data_faturamento.ToString()
                            + " , vdatafaturamento_ini:= '" + _filter.datafaturamento_ini.ToString("yyyy-MM-dd") + "'"
                            + " , vdatafaturamento_fim:= '" + _filter.datafaturamento_fim.ToString("yyyy-MM-dd") + "'"
                            + " , vdata_emissao:= " + _filter.filtra_data_emissao.ToString()
                            + " , vdataemissao_ini:= '" + _filter.dataemissao_ini.ToString("yyyy-MM-dd") + "'"
                            + " , vdataemissao_fim:= '" + _filter.dataemissao_fim.ToString("yyyy-MM-dd") + "'"
                            + " , vprd_cddepartamento:= " + _filter.prd_cddepartamento.ToString()
                            + " , vprs_cdsecao:= " + _filter.prs_cdsecao.ToString()
                            + " , vprg_cdgrupo:= " + _filter.prg_cdgrupo.ToString()
                            + " , vprsg_cdsubgrupo:= " + _filter.prsg_cdsubgrupo.ToString()
                            + " , vpr_cdproduto:= '" + _filter.pr_cdproduto.ToString() + "'"
                            + " , vprb_cdprodutobluesoft:= '" + _filter.prb_cdprodutobluesoft.ToString() + "'"
                            + " , vpr_descricao:=  '" + _filter.pr_descricao.ToString().Replace("'", "").ToUpper() + "'"
                            + " , vcdpessoabluesoft_secao_encarregado:= " + _filter.cdpessoabluesoft_secao_encarregado.ToString()
                            + " , vfaturamento_cdparticipante_vendedor:= " + _filter.faturamento_cdparticipante_vendedor.ToString()
                            + " , vfaturamento_cdparticipante_cliente:= " + _filter.faturamento_cdparticipante_cliente.ToString()
                            + " , vcdgrupoeconomico:= " + _filter.cdgrupoeconomico.ToString()
                            + " , vnome_razao:= '" + _filter.nome_razao.ToString() + "'"
                            + " , vstatusfaturamento:= " + _filter.statusfaturamento.ToString()
                            + " , vcdpessoabluesoft_fabricante:= " + _filter.cdpessoabluesoft_fabricante.ToString()
                            + " , vsis_us_seq:= " + _filter.sis_us_seq.ToString()
                            + " , vdistribuicao_cliente_top:=  " + _filter.grupo_economico_top.ToString()
                            + " , vnumeropedido:= '" + _filter.numeroPedidoList.ToString() + "'"
                            + " , vECF:= " + _filter.ECF.ToString()
                            + " , vnumeroCupomFiscalList:= '" + _filter.numeroCupomFiscalList.ToString() + "'"
                            + ")"
                    );

            return sql;
        }
    }

}
