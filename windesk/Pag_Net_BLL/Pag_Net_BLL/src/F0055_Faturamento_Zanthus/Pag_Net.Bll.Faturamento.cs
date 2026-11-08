using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0055_Faturamento_Zanthus;
using Pag_Net.Dal;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus
{

    public class Filter
    {
        public int sis_us_seq { get; set;  }
        public int tipo_visualizacao { get; set; }
        public string em_cdempresa_list { get; set; }
        public string op_cdoperacao_list { get; set; }
        public int filtra_data_faturamento { get; set; }
        public DateTime datafaturamento_ini { get; set; }
        public DateTime datafaturamento_fim { get; set; }
        public int filtra_data_emissao { get; set; }
        public DateTime dataemissao_ini { get; set; }
        public DateTime dataemissao_fim { get; set; }
        public int prd_cddepartamento { get; set; }
        public int prs_cdsecao { get; set; }
        public int prg_cdgrupo { get; set; }
        public int prsg_cdsubgrupo { get; set; }
        public int pr_cdproduto { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string pr_descricao { get; set; }
        public int cdpessoabluesoft_secao_encarregado { get; set; }
        public int faturamento_cdparticipante_vendedor { get; set; }
        public int faturamento_cdparticipante_cliente { get; set; }
	    public int cdgrupoeconomico { get; set; }
        public string nome_razao { get; set; }
        public int statusfaturamento { get; set;  }
        public int cdpessoabluesoft_fabricante { get; set;  }
        public int grupo_economico_top { get; set;  }

        

        public Filter()
        {
            tipo_visualizacao = 10;
            em_cdempresa_list = "1";
            op_cdoperacao_list = "";
            filtra_data_faturamento = 1;
            datafaturamento_ini = DateTime.Now;
            datafaturamento_fim = DateTime.Now;
            filtra_data_emissao = 0;
            dataemissao_ini = DateTime.Now;
            dataemissao_fim = DateTime.Now;

            prd_cddepartamento = 0;
            prs_cdsecao = 0;
            prg_cdgrupo = 0;
            prsg_cdsubgrupo = 0;
            pr_cdproduto = 0;
            prb_cdprodutobluesoft = 0;
            pr_descricao = "";
            cdpessoabluesoft_secao_encarregado = 0;
            faturamento_cdparticipante_vendedor = 0;
            faturamento_cdparticipante_cliente = 0;
            cdgrupoeconomico = 0;
            nome_razao = "";
            cdpessoabluesoft_fabricante = 0;
            grupo_economico_top = 0;



        }
        public Filter(
            int _tipo_visualizacao,
            string _em_cdempresa_list,
            string _op_cdoperacao_list,
            int _data_faturamento,
            DateTime _datafaturamento_ini,
            DateTime _datafaturamento_fim,
            int _data_emissao,
            DateTime _dataemissao_ini,
            DateTime _dataemissao_fim,
             int _prd_cddepartamento,
             int _prs_cdsecao,
             int _prg_cdgrupo,
             int _prsg_cdsubgrupo,
               int _pr_cdproduto,
               int _prb_cdprodutobluesoft,
               string _pr_descricao,
            int _cdpessoabluesoft_secao_encarregado,
            int _cdpessoabluesoft_fabricante

            )
        {

            tipo_visualizacao = _tipo_visualizacao;
            em_cdempresa_list = _em_cdempresa_list;
            op_cdoperacao_list = _op_cdoperacao_list;
            filtra_data_faturamento = _data_faturamento;
            datafaturamento_ini = _datafaturamento_ini;
            datafaturamento_fim = _datafaturamento_fim;
            filtra_data_emissao = _data_emissao;
            dataemissao_ini = _dataemissao_ini;
            dataemissao_fim = _dataemissao_fim;

            prd_cddepartamento = _prd_cddepartamento;
            prs_cdsecao = _prs_cdsecao;
            prg_cdgrupo = _prg_cdgrupo;
            prsg_cdsubgrupo = _prsg_cdsubgrupo;
            pr_cdproduto = _pr_cdproduto;
            prb_cdprodutobluesoft = _prb_cdprodutobluesoft;
            pr_descricao = _pr_descricao;
            cdpessoabluesoft_secao_encarregado = _cdpessoabluesoft_secao_encarregado;
            faturamento_cdparticipante_vendedor = 0;
            faturamento_cdparticipante_cliente = 0;
            cdgrupoeconomico = 0;
            nome_razao = "";

            cdpessoabluesoft_fabricante = _cdpessoabluesoft_fabricante;
        }
    }

    public class Filter_Zanthus
    {
        public DateTime data_m00af_inicial { get; set;  }
		public DateTime data_m00af_final 	{get;set;}
		public int status_cancelado 	{get;set; }
        public int cupomfiscal_m00ad { get; set;  }
        public int Sat_ECF_m00ac { get; set;  }
        public double vvalor_cupom_ini { get; set; }
        public double vvalor_cupom_fim { get; set; }
        public double vvalor_desconto_ini { get; set;  }
	    public double vvalor_desconto_fim { get; set;  }
        public double vstatus_processamento { get; set; }
        public int vstatus_com_cpf { get; set; }
        public string cd_barra_item_contem { get; set;  }

        public Filter_Zanthus()
        {
            data_m00af_inicial = DateTime.Now;
            data_m00af_final = DateTime.Now;
            status_cancelado = 0;
            vvalor_cupom_ini = 0;
            vvalor_cupom_fim = 0;
            vvalor_desconto_ini = 0;
            vvalor_desconto_fim = 0;
            vstatus_processamento = 0;
            vstatus_com_cpf = 0;
            cd_barra_item_contem = "";
        }
    }

    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }

        public void Excluir(int SeqFaturamento)
        {
            try
            {
                Tool.Faturamento_Excluir(MyConnect, SeqFaturamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ProcessaCupom (Faturamento_Processamento _faturamento_processamento)
        {
            try
            {
                Tool.Faturamento_Processamento_CUPOM(MyConnect, _faturamento_processamento);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable Faturamento_Zanthus_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter_Zanthus _filter, Wk_RelatorioZanthus_Tipo Tipo)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0055_Faturamento_Zanthus.F0055_20_Faturamento_Zanthus_Consultar.Postgre.Get(_filter, Tipo));
            }
            catch (Exception ex)
            {
                throw new Exception("Faturamento_Zanthus_Consultar:" + ex.Message);
            }
        }
        public DataTable Faturamento_Zanthus_Item_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime Data, int ECF, int NumeroCupomFiscal )
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0055_Faturamento_Zanthus.F0055_21_Faturamento_Zanthus_Item_Consultar.Postgre.Get(Data, ECF, NumeroCupomFiscal));
            }
            catch (Exception ex)
            {
                throw new Exception("Faturamento_Zanthus_Item_Consultar:" + ex.Message);
            }
        }

    }

    public class WkFaturamento_Relatorio_Analise_Basica: Wk
    {

        public double __Wk_Total_embalagemestoqueqtde = 0;
        public double __Wk_Total_embalagemcompraqtde = 0;
        public double __Wk_Total_ec_valorcusto_faturamento_total = 0;
        public double __Wk_Total_valortotalfaturamentoBASE = 0;
        public double __Wk_Total_valortotalSubsidiosCorrentes = 0;
        public double __Wk_Total_valortotalfaturamento = 0;
        public double __Wk_Total_valortotalfaturamentoliquido = 0;
        public double __Wk_MG_valortotalfaturamento = 0;
        public double __Wk_MG_valortotalfaturamentoliquido = 0;
        public double __Wk_MG_valortotalfaturamentoBASE = 0;
        public int __Wk_Numero_Itens = 0;        
        
        public Pag_Net.Bll.F0055_Faturamento_Zanthus.Filter _filter;
        public Wkdb_Faturamento_StatusFaturamento[] StatusList;
        public Wkdb_Faturamento_TipoVisualizacao[] TipoVisualizaçãoList;
        public Model_Relatorio_FaturamentoAnaliseBasica[] FaturamentoRelatorioAnaliseBasica_List;
        private bool _orderbyCrecente;
        public WkFaturamento_Relatorio_Analise_Basica(Pag_Net.Models.modelSistemaUsuario _MyConnect): base(_MyConnect)
        {
            _filter = new Filter();
            _filter.sis_us_seq = _MyConnect.sis_us_seq;
            BindingStatus();
            BindingTipoVisualizacao();
            _orderbyCrecente = false;
            
        }
        public DataTable Obter()
        {
            try
            {
                return Tool.FaturamentoAnaliseBasica_Select(MyConnect, _filter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Binding()
        {
            __Wk_MG_valortotalfaturamento = 0;
            __Wk_MG_valortotalfaturamentoliquido = 0;
            __Wk_MG_valortotalfaturamentoBASE = 0;


            DataTable _DataTableFaturamento = Tool.FaturamentoAnaliseBasica_Select(MyConnect, _filter);
            List<Model_Relatorio_FaturamentoAnaliseBasica> _ListFaturamento = new List<Model_Relatorio_FaturamentoAnaliseBasica>();

            __Wk_MG_valortotalfaturamento = 0;
            __Wk_MG_valortotalfaturamentoliquido = 0;
            __Wk_MG_valortotalfaturamentoBASE = 0;

            __Wk_Total_embalagemestoqueqtde = 0;
            __Wk_Total_embalagemcompraqtde = 0;
            __Wk_Total_valortotalfaturamento = 0;
            __Wk_Total_valortotalfaturamentoliquido = 0;
            __Wk_Total_ec_valorcusto_faturamento_total = 0;
            __Wk_Total_valortotalfaturamentoBASE = 0;
            __Wk_Numero_Itens = 0;


            foreach(DataRow i in _DataTableFaturamento.Rows)
            {
                Model_Relatorio_FaturamentoAnaliseBasica item = new Model_Relatorio_FaturamentoAnaliseBasica(i);
                __Wk_Numero_Itens += 1;
                __Wk_Total_embalagemestoqueqtde += item.embalagemestoqueqtde;
                __Wk_Total_embalagemcompraqtde += item.embalagemcompraqtde;
                __Wk_Total_ec_valorcusto_faturamento_total += item.ec_valorcusto_faturamento_total;
                __Wk_Total_valortotalfaturamento += item.valortotalfaturamento;
                __Wk_Total_valortotalfaturamentoliquido += item.valortotalfaturamentoliquido;

                __Wk_Total_valortotalfaturamentoBASE += item.valortotalfaturamentobase;
                __Wk_Total_valortotalSubsidiosCorrentes += item.valortotalsubsidioscorrentes;


                _ListFaturamento.Add(item);
            }

            FaturamentoRelatorioAnaliseBasica_List = _ListFaturamento.ToArray();

            if (__Wk_Total_valortotalfaturamento > 0)
                    __Wk_MG_valortotalfaturamento = Math.Round((__Wk_Total_valortotalfaturamento - __Wk_Total_ec_valorcusto_faturamento_total) / __Wk_Total_valortotalfaturamento *100, 2);


            if (__Wk_Total_valortotalfaturamentoliquido > 0)
                __Wk_MG_valortotalfaturamentoliquido = Math.Round((__Wk_Total_valortotalfaturamentoliquido - __Wk_Total_ec_valorcusto_faturamento_total) / __Wk_Total_valortotalfaturamento * 100, 2);

            if (__Wk_Total_valortotalfaturamentoBASE > 0)
                __Wk_MG_valortotalfaturamentoBASE = Math.Round((__Wk_Total_valortotalfaturamentoBASE - __Wk_Total_ec_valorcusto_faturamento_total) / __Wk_Total_valortotalfaturamentoBASE * 100, 2);

        }
        private void BindingStatus()
        {
            List<Wkdb_Faturamento_StatusFaturamento> _Wkdb_Faturamento_StatusFaturamentoList = new List<Wkdb_Faturamento_StatusFaturamento>();
            _Wkdb_Faturamento_StatusFaturamentoList.Add(new Wkdb_Faturamento_StatusFaturamento(99, 0, "Todos"));
            _Wkdb_Faturamento_StatusFaturamentoList.Add(new Wkdb_Faturamento_StatusFaturamento(0, 0, "Em Aberto"));
            _Wkdb_Faturamento_StatusFaturamentoList.Add(new Wkdb_Faturamento_StatusFaturamento(1, 0, "Faturado"));
            StatusList = _Wkdb_Faturamento_StatusFaturamentoList.ToArray();
        }
        private void BindingTipoVisualizacao()
        {
            List<Wkdb_Faturamento_TipoVisualizacao> _Wkdb_Faturamento_TipoVisualizacaoList = new List<Wkdb_Faturamento_TipoVisualizacao>();
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(10, "Produto"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(11, "Sub Grupo"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(12, "Grupo"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(13, "Seção"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(14, "Departamento"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(15, "Fabricante"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(16, "Encarregado de Seção"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(20, "Vendedor"));
            //_Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(21, "Vendedor/Cliente"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(30, "Grupo Econômico"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(31, "Cliente"));
            //_Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(31, "Cliente/Endereço"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(90, "Empresa"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(91, "Empresa/Operação"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(100, "Mês/Ano"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(101, "Data"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(110, "ECF"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(115, "Cupom Fiscal"));
            _Wkdb_Faturamento_TipoVisualizacaoList.Add(new Wkdb_Faturamento_TipoVisualizacao(120, "Pedido de Venda"));
            TipoVisualizaçãoList = _Wkdb_Faturamento_TipoVisualizacaoList.ToArray();
        }

        public void OrderBy(string _columnName)
        {
            if (_orderbyCrecente)
            {
                _orderbyCrecente = false;
                switch (_columnName)
                {
                    case "referencia_id":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.referencia_id).ToArray();
                        break;
                    case "referencia_descricao":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.referencia_descricao).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pr_embalagemcompra":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.pr_embalagemcompra).ToArray();
                        break;
                    case "_static_referencia":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_referencia).ToArray();
                        break;
                    case "_static_pontos":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.referencia_id).ToArray();
                        break;
                    case "_static_clientes":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_clientes).ToArray();
                        break;
                    case "_static_mix":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_mix).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Unitario":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_EmbalagemEstoque_FaturamentoBase_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Unitario":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Caixa":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_EmbalagemEstoque_FaturamentoBase_Caixa).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Caixa":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Caixa).ToArray();
                        break;
                    case "_static_faturamentobase_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_faturamentobase_margem).ToArray();
                        break;
                    case "_static_faturamento_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_faturamento_margem).ToArray();
                        break;
                    case "_static_faturamentobruto_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_faturamentobruto_margem).ToArray();
                        break;
                    case "_static_faturamentoliquido_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c._static_faturamentoliquido_margem).ToArray();
                        break;

                    case "embalagemestoqueqtde":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.embalagemestoqueqtde).ToArray();
                        break;

                    case "embalagemcompraqtde":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.embalagemcompraqtde).ToArray();
                        break;

                    case "ec_valorcusto_faturamento_total":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.ec_valorcusto_faturamento_total).ToArray();
                        break;

                    case "valortotalfaturamento":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.valortotalfaturamento).ToArray();
                        break;

                    case "valortotalfaturamentoliquido":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderBy(c => c.valortotalfaturamentoliquido).ToArray();
                        break;

                }
            }
            else
            {
                _orderbyCrecente = true;
                switch (_columnName)
                {
                    case "referencia_id":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.referencia_id).ToArray();
                        break;
                    case "referencia_descricao":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.referencia_descricao).ToArray();
                        break;
                    case "pr_embalagemestoque":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.pr_embalagemestoque).ToArray();
                        break;
                    case "pr_embalagemcompra":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.pr_embalagemcompra).ToArray();
                        break;
                    case "_static_referencia":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_referencia).ToArray();
                        break;
                    case "_static_pontos":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.referencia_id).ToArray();
                        break;
                    case "_static_clientes":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_clientes).ToArray();
                        break;
                    case "_static_mix":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_mix).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Unitario":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_EmbalagemEstoque_FaturamentoBase_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Unitario":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Unitario).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_FaturamentoBase_Caixa":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_EmbalagemEstoque_FaturamentoBase_Caixa).ToArray();
                        break;
                    case "_static_EmbalagemEstoque_ValorCustoFaturamento_Caixa":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_EmbalagemEstoque_ValorCustoFaturamento_Caixa).ToArray();
                        break;
                    case "_static_faturamentobase_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_faturamentobase_margem).ToArray();
                        break;
                    case "_static_faturamento_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_faturamento_margem).ToArray();
                        break;
                    case "_static_faturamentobruto_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_faturamentobruto_margem).ToArray();
                        break;
                    case "_static_faturamentoliquido_margem":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c._static_faturamentoliquido_margem).ToArray();
                        break;

                    case "embalagemestoqueqtde":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.embalagemestoqueqtde).ToArray();
                        break;

                    case "embalagemcompraqtde":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.embalagemcompraqtde).ToArray();
                        break;

                    case "ec_valorcusto_faturamento_total":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.ec_valorcusto_faturamento_total).ToArray();
                        break;

                    case "valortotalfaturamento":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.valortotalfaturamento).ToArray();
                        break;

                    case "valortotalfaturamentoliquido":
                        FaturamentoRelatorioAnaliseBasica_List = FaturamentoRelatorioAnaliseBasica_List.OrderByDescending(c => c.valortotalfaturamentoliquido).ToArray();
                        break;
                }
            }
        }
    }

    public class WkFaturamento_Zanthus_CupomFiscal : Wk
    {
        public Model_Relatorio_FaturamentoZanthus CupomFiscal;
        public Model_Relatorio_FaturamentoZanthus_Item[] Itens;
        public DateTime Data;
        public int      Sat_ECF;
        public int      NumeroCupomFiscal;
        public WkFaturamento_Zanthus_CupomFiscal(Pag_Net.Models.modelSistemaUsuario _MyConnect)
            : base(_MyConnect)
        {
            MyConnect = _MyConnect;
            Data = DateTime.Now;
            Sat_ECF = 0;
            NumeroCupomFiscal = 0; ;
        }

        public void Consultar()
        {
            try
            {

              if (Sat_ECF ==  0 || NumeroCupomFiscal == 0 )
              {
                  throw new Exception("Favor informar SAT/ECF e o Número do Cupom");
              }


                Filter_Zanthus _Filter_Zanthus = new Filter_Zanthus();
                _Filter_Zanthus.cupomfiscal_m00ad = NumeroCupomFiscal;
                _Filter_Zanthus.Sat_ECF_m00ac = Sat_ECF;
                _Filter_Zanthus.data_m00af_final = Data;
                _Filter_Zanthus.data_m00af_inicial = Data;

                DataTable _Relatorio_FaturamentoZanthus = this.Faturamento_Zanthus_Consultar(MyConnect, _Filter_Zanthus, Wk_RelatorioZanthus_Tipo.DataCupom);
                CupomFiscal = new Model_Relatorio_FaturamentoZanthus();

                if (_Relatorio_FaturamentoZanthus.Rows.Count > 0)
                {
                    CupomFiscal = new Model_Relatorio_FaturamentoZanthus(this.Faturamento_Zanthus_Consultar(MyConnect, _Filter_Zanthus, Wk_RelatorioZanthus_Tipo.DataCupom).Rows[0]);

                    DataTable DataTable_Relatorio_FaturamentoZanthus_Item = this.Faturamento_Zanthus_Item_Consultar(MyConnect, Data, Sat_ECF, NumeroCupomFiscal);

                    if (DataTable_Relatorio_FaturamentoZanthus_Item.Rows.Count > 0)
                    {
                        List<Model_Relatorio_FaturamentoZanthus_Item> _List_Relatorio_FaturamentoZanthus_Item = new List<Model_Relatorio_FaturamentoZanthus_Item>();
                        foreach (DataRow i in DataTable_Relatorio_FaturamentoZanthus_Item.Rows)
                        {
                            _List_Relatorio_FaturamentoZanthus_Item.Add(new Model_Relatorio_FaturamentoZanthus_Item(i));
                        }
                        Itens = _List_Relatorio_FaturamentoZanthus_Item.ToArray();
                    }
                }
                else
                {
                    new Exception(string.Format("Registro de Cupom NÃO LOCALIZADO  \n Data {0}  \n ECF {1}  \n Número do Cupom: {3}", 
                        Data.ToString("dd/MM/yyyy"), 
                        Sat_ECF.ToString(), 
                        NumeroCupomFiscal.ToString()));
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class WkFaturamento_Zanthus: Wk
    {
        public Filter_Zanthus Filtros;
        public Model_Relatorio_FaturamentoZanthus[] Cupons_List;
        public Model_Relatorio_FaturamentoZanthus[] ECF_Operadora_List;
        

        public double valor_base_total;
        public double valor_desconto_total;
        public double valor_total;


        public object HORA_List;
        public object Voucher_List;
        public object ECF_List;

        private bool _orderbyCrecente;
        public WkFaturamento_Zanthus(Pag_Net.Models.modelSistemaUsuario _MyConnect): base(_MyConnect)
        {
            Filtros = new Filter_Zanthus();
            _orderbyCrecente = false;
        }

        public void Binding()
        {
            try
            {
                try
                {

                    Cupons_List = null;
                    ECF_Operadora_List = null;
                    HORA_List = null;
                    Voucher_List = null;
                    ECF_List = null;

                    valor_base_total = 0;
                    valor_desconto_total = 0;
                    valor_total = 0;

                    //Cupons_List[0]

                    DataTable FaturamentoZanthus_CUPOM_DataTable = Tool.Faturamento_Zanthus_Select(MyConnect, Filtros, Wk_RelatorioZanthus_Tipo.DataCupom);
                    List<Model_Relatorio_FaturamentoZanthus> lstWK_Relatorio_CUPOM_FaturamentoZanthus = new List<Model_Relatorio_FaturamentoZanthus>();
                    foreach (DataRow i in FaturamentoZanthus_CUPOM_DataTable.Rows)
                    {
                        Model_Relatorio_FaturamentoZanthus item = new Model_Relatorio_FaturamentoZanthus(i);
                        lstWK_Relatorio_CUPOM_FaturamentoZanthus.Add(item);
                        valor_base_total += item.fat_zanthus_item_valor_m43ap;
                        valor_desconto_total += item.fat_zanthus_item_valor_desconto_m43aq;
                        valor_total += item.fat_zanthus_cupomfiscal_valor_m45ak;
                    }
                    Cupons_List = lstWK_Relatorio_CUPOM_FaturamentoZanthus.ToArray();

                    DataTable FaturamentoZanthus_ECF_DataTable = Tool.Faturamento_Zanthus_Select(MyConnect, Filtros, Wk_RelatorioZanthus_Tipo.ECF);
                    List<Model_Relatorio_FaturamentoZanthus> lstWK_Relatorio_ECF_FaturamentoZanthus = new List<Model_Relatorio_FaturamentoZanthus>();
                    foreach (DataRow i in FaturamentoZanthus_ECF_DataTable.Rows)
                    {
                        lstWK_Relatorio_ECF_FaturamentoZanthus.Add(new Model_Relatorio_FaturamentoZanthus(i));
                    }
                    ECF_Operadora_List = lstWK_Relatorio_ECF_FaturamentoZanthus.ToArray();

                    
                    /*
                    DataTable FaturamentoZanthus_HORA_DataTable = Tool.Faturamento_Zanthus_Select(MyConnect, Filtros, Wk_RelatorioZanthus_Tipo.Hora);
                    List<WK_Relatorio_FaturamentoZanthus> lstWK_Relatorio_HORA_FaturamentoZanthus = new List<WK_Relatorio_FaturamentoZanthus>();
                    foreach (DataRow i in FaturamentoZanthus_HORA_DataTable.Rows)
                    {
                        lstWK_Relatorio_HORA_FaturamentoZanthus.Add(new WK_Relatorio_FaturamentoZanthus(i));
                    }
                    HORA_List = lstWK_Relatorio_HORA_FaturamentoZanthus.ToArray();
                     */


                    HORA_List =
                             Cupons_List.GroupBy(x => x.fat_zanthus_hora_inicial).Select(dados => new
                             {

                                 fat_zanthus_hora_inicial = dados.Key,
                                 fat_zanthus_cupomfiscal_m00ad = dados.Select(x => x.fat_zanthus_cupomfiscal_m00ad).Distinct().Count(),
                                 fat_zanthus_notafiscal_chave_m45xb = dados.Select(x => x.fat_zanthus_notafiscal_chave_m45xb).Distinct().Count(),
                                 fat_zanthus_status_cancelado = dados.Select(x => x.fat_zanthus_status_cancelado != 0).Count(),
                                 fat_zanthus_cupomfiscal_valor_m45ak = dados.Sum(x => x.fat_zanthus_cupomfiscal_valor_m45ak),
                                 fat_zanthus_item_valor_desconto_m43aq = dados.Sum(x => x.fat_zanthus_item_valor_desconto_m43aq),
                                 fat_zanthus_cpf_cnpj_m45bv = dados.Select(x => x.fat_zanthus_cpf_cnpj_m45bv).Distinct().Count()
                             }).ToArray();

                    Voucher_List =
                             Cupons_List.GroupBy(x => x.voucher_descricao).Select(dados => new
                             {

                                 fat_zanthus_hora_inicial = dados.Key,
                                 fat_zanthus_cupomfiscal_m00ad = dados.Select(x => x.fat_zanthus_cupomfiscal_m00ad).Distinct().Count(),
                                 fat_zanthus_notafiscal_chave_m45xb = dados.Select(x => x.fat_zanthus_notafiscal_chave_m45xb).Distinct().Count(),
                                 fat_zanthus_status_cancelado = dados.Select(x => x.fat_zanthus_status_cancelado != 0).Count(),
                                 fat_zanthus_cupomfiscal_valor_m45ak = dados.Sum(x => x.fat_zanthus_cupomfiscal_valor_m45ak),
                                 fat_zanthus_item_valor_desconto_m43aq = dados.Sum(x => x.fat_zanthus_item_valor_desconto_m43aq),
                                 fat_zanthus_cpf_cnpj_m45bv = dados.Select(x => x.fat_zanthus_cpf_cnpj_m45bv).Distinct().Count()
                             }).ToArray();


                    ECF_List = Cupons_List.GroupBy(x => x.fat_zanthus_sat_ecf_m00ac).Select(dados => new
                    {

                        fat_zanthus_hora_inicial = dados.Key,
                        fat_zanthus_cupomfiscal_m00ad = dados.Select(x => x.fat_zanthus_cupomfiscal_m00ad).Distinct().Count(),
                        fat_zanthus_notafiscal_chave_m45xb = dados.Select(x => x.fat_zanthus_notafiscal_chave_m45xb).Distinct().Count(),
                        fat_zanthus_status_cancelado = dados.Select(x => x.fat_zanthus_status_cancelado != 0).Count(),
                        fat_zanthus_cupomfiscal_valor_m45ak = dados.Sum(x => x.fat_zanthus_cupomfiscal_valor_m45ak),
                        fat_zanthus_item_valor_desconto_m43aq = dados.Sum(x => x.fat_zanthus_item_valor_desconto_m43aq),
                        fat_zanthus_cpf_cnpj_m45bv = dados.Select(x => x.fat_zanthus_cpf_cnpj_m45bv).Distinct().Count()
                    }).ToArray();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void OrderBy(string _columnName)
        {
            if (_orderbyCrecente)
            {
                _orderbyCrecente = false;
                switch (_columnName)
                {
                    case "dtlog_insert":
                        Cupons_List = Cupons_List.OrderBy(c => c.dtlog_insert).ToArray();
                        break;

                    case "dtlog_update":
                        Cupons_List = Cupons_List.OrderBy(c => c.dtlog_update).ToArray();
                        break;

                    case "fat_zanthus_seq":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_seq).ToArray();
                        break;


                    case "fat_zanthus_data_m00af":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_data_m00af).ToArray();
                        break;

                    case "fat_zanthus_sat_ecf_m00ac":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_sat_ecf_m00ac).ToArray();
                        break;


                    case "fat_zanthus_cupomfiscal_m00ad":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_cupomfiscal_m00ad).ToArray();
                        break;

                    case "fat_zanthus_cupomfiscalid_M00_id_unico":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_cupomfiscalid_M00_id_unico).ToArray();
                        break;


                    case "fat_zanthus_cupomfiscal_cancelador_m45bo":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_cupomfiscal_cancelador_m45bo).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_numnota":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_notafiscal_numnota).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_serie_nf":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_notafiscal_serie_nf).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_chave_m45xb":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_notafiscal_chave_m45xb).ToArray();
                        break;


                    case "fat_zanthus_status_cancelado":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_status_cancelado).ToArray();
                        break;

                    case "fat_zanthus_cpf_cnpj_m45bv":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_cpf_cnpj_m45bv).ToArray();
                        break;


                    case "fat_zanthus_hora_ini_m45ai":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_hora_ini_m45ai).ToArray();
                        break;

                    case "fat_zanthus_hora_fim_m45au":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_hora_fim_m45au).ToArray();
                        break;

                    case "fat_zanthus_cupomfiscal_valor_m45ak":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_cupomfiscal_valor_m45ak).ToArray();
                        break;


                    case "fat_zanthus_percentual_desconto":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_percentual_desconto).ToArray();
                        break;

                    case "zanthus_nome_funcionario":
                        Cupons_List = Cupons_List.OrderBy(c => c.zanthus_nome_funcionario).ToArray();
                        break;
                    case "fat_zanthus_voucher_cod_m50ar":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_voucher_cod_m50ar).ToArray();
                        break;
                    case "voucher_descricao":
                        Cupons_List = Cupons_List.OrderBy(c => c.voucher_descricao).ToArray();
                        break;
                    case "fat_zanthus_voucher_valor_m50at":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_voucher_valor_m50at).ToArray();
                        break;
                    case "fat_zanthus_voucher_count_m50ag":
                        Cupons_List = Cupons_List.OrderBy(c => c.fat_zanthus_voucher_count_m50ag).ToArray();
                        break;

                }
            }
            else
            {
                _orderbyCrecente = true;
                switch (_columnName)
                {
                    case "dtlog_insert":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.dtlog_insert).ToArray();
                        break;

                    case "dtlog_update":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.dtlog_update).ToArray();
                        break;

                    case "fat_zanthus_seq":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_seq).ToArray();
                        break;
                    case "fat_zanthus_data_m00af":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_data_m00af).ToArray();
                        break;

                    case "fat_zanthus_sat_ecf_m00ac":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_sat_ecf_m00ac).ToArray();
                        break;


                    case "fat_zanthus_cupomfiscal_m00ad":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_cupomfiscal_m00ad).ToArray();
                        break;

                    case "fat_zanthus_cupomfiscalid_M00_id_unico":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_cupomfiscalid_M00_id_unico).ToArray();
                        break;


                    case "fat_zanthus_cupomfiscal_cancelador_m45bo":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_cupomfiscal_cancelador_m45bo).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_numnota":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_notafiscal_numnota).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_serie_nf":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_notafiscal_serie_nf).ToArray();
                        break;

                    case "fat_zanthus_notafiscal_chave_m45xb":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_notafiscal_chave_m45xb).ToArray();
                        break;


                    case "fat_zanthus_status_cancelado":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_status_cancelado).ToArray();
                        break;

                    case "fat_zanthus_cpf_cnpj_m45bv":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_cpf_cnpj_m45bv).ToArray();
                        break;


                    case "fat_zanthus_hora_ini_m45ai":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_hora_ini_m45ai).ToArray();
                        break;

                    case "fat_zanthus_hora_fim_m45au":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_hora_fim_m45au).ToArray();
                        break;

                    case "fat_zanthus_cupomfiscal_valor_m45ak":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_cupomfiscal_valor_m45ak).ToArray();
                        break;

                    case "fat_zanthus_percentual_desconto":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_percentual_desconto).ToArray();
                        break;
                    case "zanthus_nome_funcionario":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.zanthus_nome_funcionario).ToArray();
                        break;
                    case "fat_zanthus_voucher_cod_m50ar":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_voucher_cod_m50ar).ToArray();
                        break;
                    case "voucher_descricao":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.voucher_descricao).ToArray();
                        break;
                    case "fat_zanthus_voucher_valor_m50at":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_voucher_valor_m50at).ToArray();
                        break;
                    case "fat_zanthus_voucher_count_m50ag":
                        Cupons_List = Cupons_List.OrderByDescending(c => c.fat_zanthus_voucher_count_m50ag).ToArray();
                        break;

                }
            }
        }

    }
    
    public static class Tool
    {
        public static DataTable FaturamentoAnaliseBasica_Select(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0055_Faturamento_Zanthus.F0055_50_Relatorio_Analise_Basica.Postgre.Get(filter));
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0055_Faturamento.Tool.FaturamentoAnaliseBasica:" + ex.Message);
            }
        }
        public static DataTable Zanthus_ZeusRetail_PDVS_Ctrl_Select()
        {
            return null;
        }
        public static DataTable Faturamento_Zanthus_Select(Pag_Net.Models.modelSistemaUsuario MyConnect, Filter_Zanthus _filter, Wk_RelatorioZanthus_Tipo Tipo)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, F0055_Faturamento_Zanthus.F0055_20_Faturamento_Zanthus_Consultar.Postgre.Get(_filter, Tipo));
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.F0055_Faturamento.Tool.F0055_Faturamento.Faturamento_Zanthus_Select:" + ex.Message);
            }
        }
        public static void Faturamento_Excluir(Pag_Net.Models.modelSistemaUsuario MyConnect, int seqfaturamento)
        {
            DbUpdate BDExecute;
            BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
            BDExecute.Execute(Pag_Net.Bll.F0055_Faturamento_Zanthus.F0055_03_Faturamento_Excluir.Postgre.Post(seqfaturamento), null, DataBaseName.ODBCOXAN);
            BDExecute.Close(DataBaseName.ODBCOXAN);
            BDExecute.Dispose();
        }
        public static void Faturamento_Processamento_CUPOM(Pag_Net.Models.modelSistemaUsuario MyConnect, Faturamento_Processamento _faturamento_processamento)
        {
            try
            {
                string url = string.Format("{0}/faturamentocupomprocessamento?data={1}&ecf={2}&cupomfiscal={3}",

                    MyConnect.PAG_API,
                    _faturamento_processamento.data.ToString("dd/MM/yyyy"),
                    _faturamento_processamento.ecf.ToString(),
                    _faturamento_processamento.cupomfiscal.ToString()
                    );

                Pag_Net.Bll.RESTAPI.get(url, null);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
            
        }
    }

    public class Wkdb_Faturamento_StatusFaturamento
    {
        public int      FaturamentoStatus                { get; set; }
        public int      FaturamentoStatusItem            { get; set;  }
        public string   FaturamentoStatusDescricao    { get; set; }

        public Wkdb_Faturamento_StatusFaturamento()
        {
            FaturamentoStatus = 0;
            FaturamentoStatusItem = 0;
            FaturamentoStatusDescricao = "";

        }
        public Wkdb_Faturamento_StatusFaturamento(
            
            int _FaturamentoStatus,            
            int _FaturamentoStatusItem,
            string _FaturamentoStatusDescricao
            ) 
        {
            FaturamentoStatus = _FaturamentoStatus;
            FaturamentoStatusItem = _FaturamentoStatusItem;
            FaturamentoStatusDescricao = _FaturamentoStatusDescricao;
        
        }

    }

    public class Wkdb_Faturamento_TipoVisualizacao
    {
        public int FaturamentoTipoVisualizacao { get; set; }
        public string FaturamentoTipoVisualizacaoDescricao { get; set; }

        public Wkdb_Faturamento_TipoVisualizacao()
        {
            FaturamentoTipoVisualizacao = 0;
            FaturamentoTipoVisualizacaoDescricao = "";

        }
        public Wkdb_Faturamento_TipoVisualizacao(
            int _FaturamentoTipoVisualizacao,
            string _FaturamentoTipoVisualizacaoDescricao
            )
        {
            FaturamentoTipoVisualizacao = _FaturamentoTipoVisualizacao;
            FaturamentoTipoVisualizacaoDescricao = _FaturamentoTipoVisualizacaoDescricao;
        }

    }

    public class Model_Relatorio_FaturamentoAnaliseBasica : tbFaturamentoitens
    {
        public string referencia_id { get; set; }
        public string referencia_descricao { get; set; }
        public string pr_embalagemestoque { get; set; }
        public string pr_embalagemcompra { get; set; }


        public string _static_referencia
        {
            get
            {
                return string.Format("{1} | Ref.: {0}", referencia_id, referencia_descricao);
            }
        }

        public int _static_pontos { get; set; }
        public int _static_clientes { get; set; }
        public int _static_mix { get; set; }


        public double _static_EmbalagemEstoque_FaturamentoBase_Unitario
        {
            get
            {
                if (valortotalfaturamentobase != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(valortotalfaturamentobase / embalagemestoqueqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_ValorCustoFaturamento_Unitario
        {
            get
            {
                if (ec_valorcusto_faturamento_total != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(ec_valorcusto_faturamento_total / embalagemestoqueqtde, 2);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_FaturamentoBase_Caixa
        {
            get
            {
                if (valortotalfaturamentobase != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(valortotalfaturamentobase / embalagemcompraqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_EmbalagemEstoque_ValorCustoFaturamento_Caixa
        {
            get
            {
                if (ec_valorcusto_faturamento_total != 0 && embalagemestoqueqtde > 0)
                {
                    return Math.Round(ec_valorcusto_faturamento_total / embalagemcompraqtde, 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentobase_margem
        {
            get
            {
                if (valortotalfaturamentobase > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentobase, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamento_margem
        {
            get
            {
                if (valortotalfaturamento > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamento, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentobruto_margem
        {
            get
            {
                if (valortotalfaturamentobruto > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentobruto, ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double _static_faturamentoliquido_margem
        {
            get
            {
                if (valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(valortotalfaturamentoliquido, ec_valorcusto_faturamento_total);
                }
                else
                {

                    return 0;
                }
            }


        }

        public Model_Relatorio_FaturamentoAnaliseBasica()
        {
            referencia_id = "0";
            referencia_descricao = "";
            pr_embalagemestoque = "UN";
            pr_embalagemcompra = "CX";
        }
        public Model_Relatorio_FaturamentoAnaliseBasica(
                string _referencia_id,
                string _referencia_descricao,
                string _pr_embalagemestoque,
                string _pr_embalagemcompra
            )
        {

            referencia_id = _referencia_id;
            referencia_descricao = _referencia_descricao;
            pr_embalagemestoque = _pr_embalagemestoque;
            pr_embalagemcompra = _pr_embalagemcompra;
        }

        public Model_Relatorio_FaturamentoAnaliseBasica(DataRow i)
        {

            referencia_id = i["referencia_id"].ToString();
            referencia_descricao = i["referencia_descricao"].ToString();
            pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
            pr_embalagemcompra = i["pr_embalagemcompra"].ToString();
            embalagemestoqueqtde = Convert.ToDouble(i["embalagemestoqueqtde"].ToString());
            embalagemcompraqtde = Convert.ToDouble(i["embalagemcompraqtde"].ToString());

            _static_pontos = Convert.ToInt32(i["pontos"].ToString());
            _static_clientes = Convert.ToInt32(i["clientes"].ToString());
            _static_mix = Convert.ToInt32(i["mix"].ToString());

            ec_valorcusto_faturamento_total = Convert.ToDouble(i["ec_valorcusto_faturamento_total"].ToString());
            valortotalfaturamentobase = Convert.ToDouble(i["valortotalfaturamentobase"].ToString());
            valortotalsubsidioscorrentes = Convert.ToDouble(i["valortotalsubsidioscorrentes"].ToString());
            valortotalfaturamento = Convert.ToDouble(i["valortotalfaturamento"].ToString());
            valortotaldescontofinanceiro = Convert.ToDouble(i["valortotaldescontofinanceiro"].ToString());
            valortotalfaturamentobruto = Convert.ToDouble(i["valortotalfaturamentobruto"].ToString());
            valortotalsubsidiosaplicados = Convert.ToDouble(i["valortotalsubsidiosaplicados"].ToString());
            valortotalfaturamentoliquido = Convert.ToDouble(i["valortotalfaturamentoliquido"].ToString());

        }

    }

    public class Model_Relatorio_FaturamentoZanthus : tbfaturamentozanthus
    {

        public double fat_zanthus_item_valor_m43ap              { get; set;  }
        public double fat_zanthus_item_valor_desconto_m43aq     { get; set; }
        public int seqfaturamento { get; set; }
        public int seqfaturamentoorigem { get; set; }
        public string zanthus_nome_funcionario { get; set; }
        public string voucher_descricao { get; set; }
        //public string fat_zanthus_cpf_cnpj_m45bv { get; set;  }
        public TimeSpan Tempo_de_Pedagio
        {
            get 
            {
                TimeSpan MIN;
                try
                {
                    MIN = this.fat_zanthus_hora_fim_m45au - this.fat_zanthus_hora_ini_m45ai;
                }
                catch (Exception ex)
                {
                    MIN = new TimeSpan(0,0,0);
                }
                return MIN;
            }
        }
        public string fat_zanthus_hora_inicial
        {
            get
            {
                return this.fat_zanthus_hora_ini_m45ai.ToString("HH");
            }
        }
        public double fat_zanthus_percentual_desconto
        {
            get
            {
                double percentual = 0;
                if (fat_zanthus_item_valor_desconto_m43aq > 0)
                {
                    percentual = fat_zanthus_item_valor_desconto_m43aq / fat_zanthus_item_valor_m43ap * 100;
                }
                return percentual;
            }
        }

        

        public Model_Relatorio_FaturamentoZanthus() 
        {
            
            fat_zanthus_seq						        = 0 ;
            fat_zanthus_data_m00af = DateTime.Now;
            fat_zanthus_sat_ecf_m00ac 			        = 0 ;
            fat_zanthus_cupomfiscal_m00ad 			    = 0 ;
            fat_zanthus_cupomfiscalid_M00_id_unico 		= "0" ;
            fat_zanthus_cupomfiscal_cancelador_m45bo          = 0 ;
            fat_zanthus_notafiscal_numnota 			    = 0 ;
            fat_zanthus_notafiscal_serie_nf 		    = 0 ;
            fat_zanthus_notafiscal_chave_m45xb		    = "0" ;
            fat_zanthus_status_cancelado                = 0;
            fat_zanthus_cupomfiscal_valor_m45ak = 0;
            fat_zanthus_item_valor_m43ap          = 0;
            fat_zanthus_item_valor_desconto_m43aq = 0;
            fat_zanthus_cpf_cnpj_m45bv = "0";
        }
       

        public Model_Relatorio_FaturamentoZanthus(DataRow i)
        {

            string erro = "Class/Publish WK_Relatorio_FaturamentoZanthus: ";
            try
            {
                erro = "fat_zanthus_seq";
                fat_zanthus_seq = Convert.ToInt32(i["fat_zanthus_seq"].ToString());
                erro = "fat_zanthus_data_m00af";
                fat_zanthus_data_m00af = Convert.ToDateTime(i["fat_zanthus_data_m00af"].ToString());
                erro = "fat_zanthus_sat_ecf_m00ac";
                fat_zanthus_sat_ecf_m00ac = Convert.ToInt32(i["fat_zanthus_sat_ecf_m00ac"].ToString());
                erro = "fat_zanthus_cupomfiscal_m00ad";
                fat_zanthus_cupomfiscal_m00ad = Convert.ToInt32(i["fat_zanthus_cupomfiscal_m00ad"].ToString());
                erro = "fat_zanthus_cupomfiscalid_M00_id_unico";
                fat_zanthus_cupomfiscalid_M00_id_unico = i["fat_zanthus_cupomfiscalid_M00_id_unico"].ToString();
                erro = "fat_zanthus_cupomfiscal_cancelador_m45bo";
                fat_zanthus_cupomfiscal_cancelador_m45bo = Convert.ToInt32(i["fat_zanthus_cupomfiscal_cancelado_m45bo"].ToString());
                erro = "fat_zanthus_notafiscal_numnota";
                fat_zanthus_notafiscal_numnota = Convert.ToInt32(i["fat_zanthus_notafiscal_numnota"].ToString());
                erro = "fat_zanthus_notafiscal_serie_nf";
                fat_zanthus_notafiscal_serie_nf = Convert.ToInt32(i["fat_zanthus_notafiscal_serie_nf"].ToString());
                erro = "fat_zanthus_notafiscal_chave_m45xb";
                fat_zanthus_notafiscal_chave_m45xb = i["fat_zanthus_notafiscal_chave_m45xb"].ToString();
                erro = "fat_zanthus_status_cancelado";
                fat_zanthus_status_cancelado = Convert.ToInt32(i["fat_zanthus_status_cancelado"].ToString());
                erro = "fat_zanthus_cupomfiscal_valor_m45ak";
                fat_zanthus_cupomfiscal_valor_m45ak = Convert.ToDouble(i["fat_zanthus_cupomfiscal_valor_m45ak"].ToString());
                erro = "fat_zanthus_item_valor_m43ap";
                fat_zanthus_item_valor_m43ap = Convert.ToDouble(i["fat_zanthus_item_valor_m43ap"].ToString());
                erro = "fat_zanthus_item_valor_desconto_m43aq";
                fat_zanthus_item_valor_desconto_m43aq = Convert.ToDouble(i["fat_zanthus_item_valor_desconto_m43aq"].ToString());
                erro = "fat_zanthus_hora_ini_m45ai";
                fat_zanthus_hora_ini_m45ai = Convert.ToDateTime(i["fat_zanthus_hora_ini_m45ai"].ToString());
                erro = "fat_zanthus_hora_fim_m45au";
                fat_zanthus_hora_fim_m45au = Convert.ToDateTime(i["fat_zanthus_hora_fim_m45au"].ToString());
                erro = "fat_zanthus_cpf_cnpj_m45bv";
                fat_zanthus_cpf_cnpj_m45bv = i["fat_zanthus_cpf_cnpj_m45bv"].ToString();
                erro = "seqfaturamento";
                seqfaturamento = Convert.ToInt32(i["seqfaturamento"].ToString());
                erro = "seqfaturamentoorigem";
                seqfaturamentoorigem = Convert.ToInt32(i["seqfaturamentoorigem"].ToString());
                erro = "dtlog_insert";
                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                erro = "dtlog_update";
                dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
                erro = "fat_zanthus_cod_funcionario_m45ah";
                fat_zanthus_cod_funcionario_m45ah = Convert.ToInt32(i["fat_zanthus_cod_funcionario_m45ah"].ToString());
                erro = "zanthus_nome_funcionario";
                zanthus_nome_funcionario = i["zanthus_nome_funcionario"].ToString();
                erro = "voucher";
                fat_zanthus_voucher_cod_m50ar = i["fat_zanthus_voucher_cod_m50ar"].ToString();
                fat_zanthus_voucher_valor_m50at = Convert.ToDouble(i["fat_zanthus_voucher_valor_m50at"].ToString());
                fat_zanthus_voucher_count_m50ag = Convert.ToInt32(i["fat_zanthus_voucher_count_m50ag"].ToString());
                voucher_descricao =   i["voucher_descricao"].ToString();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + " : " + erro);
            }


        }

    }

    public class Model_Relatorio_FaturamentoZanthus_Item: tbfaturamentozanthusitem
    {
        public int      pr_cdproduto            {get; set;}
        public int      prb_cdprodutobluesoft   {get; set;}		
        public string   pr_descricao 	            {get; set;}			
        public string   pr_embalagemestoque     {get; set;}		
        public string   pre_embalagem 	        {get; set;}
        public double   pre_fatorestoque        { get; set; }		



        public Model_Relatorio_FaturamentoZanthus_Item ()
        {
            pr_cdproduto = 0;

            prb_cdprodutobluesoft = 0;
            pr_descricao = "";
            pr_embalagemestoque = "";
            pre_embalagem = "";
            pre_fatorestoque = 0;  

            fat_zanthus_seq = 0;
            fat_zanthus_data_m00af = DateTime.Now;
            fat_zanthus_sat_ecf_m00ac = 0;
            fat_zanthus_cupomfiscal_m00ad = 0;

            fat_zanthus_item_seq_m43eg = 0;
            fat_zanthus_item_cdbarra_m43ah = "0";
            fat_zanthus_item_cdbarra_M43BK_m43ah = "0";
            fat_zanthus_item_qtde_m43ao = 0;
            fat_zanthus_item_valor_m43ap = 0;
            fat_zanthus_M43BK = "0";
            fat_zanthus_M43AH = "0";
            fat_zanthus_Decomp_Insumo = 0;
            fat_zanthus_val_liquido = 0;

        }


        public Model_Relatorio_FaturamentoZanthus_Item(DataRow i)
        {

            pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"].ToString()); ;

            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            pr_descricao = i["pr_descricao"].ToString();
            pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
            pre_embalagem = i["pre_embalagem"].ToString();
            pre_fatorestoque = Convert.ToDouble(i["pre_fatorestoque"].ToString());


            fat_zanthus_seq = Convert.ToInt32(i["fat_zanthus_seq"].ToString());
            fat_zanthus_data_m00af = Convert.ToDateTime(i["fat_zanthus_data_m00af"].ToString());
            fat_zanthus_sat_ecf_m00ac = Convert.ToInt32(i["fat_zanthus_sat_ecf_m00ac"].ToString());
            fat_zanthus_cupomfiscal_m00ad = Convert.ToInt32(i["fat_zanthus_cupomfiscal_m00ad"].ToString());
            fat_zanthus_item_seq_m43eg = Convert.ToDouble(i["fat_zanthus_item_seq_m43eg"].ToString());
            fat_zanthus_item_cdbarra_m43ah = i["fat_zanthus_item_cdbarra_m43ah"].ToString();
            fat_zanthus_item_cdbarra_M43BK_m43ah = i["fat_zanthus_item_cdbarra_M43BK_m43ah"].ToString();
            fat_zanthus_item_qtde_m43ao = Convert.ToDouble(i["fat_zanthus_item_qtde_m43ao"].ToString());
            fat_zanthus_item_valor_m43ap = Convert.ToDouble(i["fat_zanthus_item_valor_m43ap"].ToString());
            fat_zanthus_item_valor_desconto_m43aq = Convert.ToDouble(i["fat_zanthus_item_valor_desconto_m43aq"].ToString());
            
            //fat_zanthus_M43BK = i["fat_zanthus_M43BK"].ToString();
            fat_zanthus_M43AH = i["fat_zanthus_M43AH"].ToString();
            fat_zanthus_Decomp_Insumo = Convert.ToDouble(i["fat_zanthus_Decomp_Insumo"].ToString());
            fat_zanthus_val_liquido = Convert.ToDouble(i["fat_zanthus_val_liquido"].ToString());
        }

    }

    public enum Wk_RelatorioZanthus_Tipo
    {
        DataCupom, 
        ECF,
        Hora

    }

    public class Faturamento_Processamento
    {
        public DateTime data { get; set;  }
        public int ecf { get; set; }
        public int cupomfiscal { get; set; }
        public Faturamento_Processamento() { }
        public Faturamento_Processamento(DateTime _data, int _ecf, int _cupomfiscal) 
        {
            data = _data;
            ecf = _ecf;
            cupomfiscal = _cupomfiscal;
        }
    }

    public class WKProcessamento
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public WKProcessamento(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
        public DataTable ProcessamentoECF_Consultar(Boolean Processar, DateTime dataProcessamentoIni, DateTime dataProcessamentoFim, int vdiferenca)
        {
            try
            {
                if (Processar)
                {
                    for (DateTime itemdata = dataProcessamentoIni.Date; itemdata.Date <= dataProcessamentoFim.Date; itemdata = itemdata.AddDays(1))
                    {
                        backendJs_Faturamento_ZanthusCtrl(MyConnect, itemdata);
                    }
                }


                string SQL_CTLR_CONSULTAR = "SELECT * FROM f0055_15_1011998_faturamentozanthus_ctrl_consultar ( " +
                            " vdatafaturamento_ini:= '" + dataProcessamentoIni.ToString("yyyy-MM-dd") + "', " +
                            " vdatafaturamento_fim:= '" + dataProcessamentoFim.ToString("yyyy-MM-dd") + "', " +
                            " vsat_ecf:= 0,  " +
                            " vdiferenca:= " + vdiferenca.ToString() +
                            " )";
                return BDCommand.get_DataTable(MyConnect, SQL_CTLR_CONSULTAR);
                
                /*
                string SCRIPT_SQLSERVER_Update_Processamento = string.Format(
                                     "        select	    fat_zanthus_sat_ecf_m00ac	= a.m00ac             " + 
                                     "               ,		fat_zanthus_data_m00af		= a.m00af             " + 
                                     "               ,		fz_cupom_qtde				= count(a.m00ad)      " + 			 
                                     "               ,		fz_cupom_inicial			= min(a.m00ad)        " +
                                     "               ,		fz_cupom_final				= max(a.m00ad)        " + 
                                     "               ,		fz_valor					= sum(a.m45ak)        " +
                                     "               ,       fz_pag_cupom_qtde           = 0  " +
                                     "               ,       fz_pag_cupom_inicial        = 0  " + 
                                     "               ,       fz_pag_cupom_final          = 0  " +
                                     "               ,       fz_pag_valor                = 0  " +
                                     "               ,       fat_cupom_qtde           = 0  " +
                                     "               ,       fat_cupom_inicial        = 0  " +
                                     "               ,       fat_cupom_final          = 0  " +
                                     "               ,       fat_cupom_valor                = 0  " +
                                     "        from		ZEUSRETAIL.DBO.ZAN_M45	A  " +
                                     "        WHERE		1 = 1  " +
                                     "          AND      A.M00AF >= '{0}' "  +
                                     "          AND      A.M00AF <= '{1}' " + 
                                     "        GROUP BY	A.M00AF ,	A.M00AC ",
                                              dataProcessamentoIni.ToString("yyyy-MM-dd"), dataProcessamentoFim.ToString("yyyy-MM-dd")
                                     );

                DataTable SqlServer_ECF_CTRL = (DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SCRIPT_SQLSERVER_Update_Processamento, null, true)).Tables[0];
                if (SqlServer_ECF_CTRL.Rows.Count > 0)
                {
                    foreach (DataRow i in SqlServer_ECF_CTRL.Rows)
                    {
                        tbfaturamentozanthus_ctrl item = new tbfaturamentozanthus_ctrl(i);
                        item._ToCheck(MyConnect);
                    }

                    string SQL_CTLR_CONSULTAR = "SELECT * FROM f0055_15_1011998_faturamentozanthus_ctrl_consultar ( " +
                                                " vdatafaturamento_ini:= '" + dataProcessamentoIni.ToString("yyyy-MM-dd") + "', " +
                                                " vdatafaturamento_fim:= '" + dataProcessamentoFim.ToString("yyyy-MM-dd") + "', " +
                                                " vsat_ecf:= 0,  " + 
                                                " vdiferenca:= " + vdiferenca.ToString() + 
                                                " )";
                    return BDCommand.get_DataTable(MyConnect, SQL_CTLR_CONSULTAR);
                }
                else
                {
                    return null;
                }*/
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ProcessamentoZanthus_Cupons_Get(int ECF, DateTime DATA)
        {
            try
            {


                string SCRIPT_SQLSERVER_Update_Processamento = string.Format(
                    "        Select		fat_zanthus_data_m00af = A.M00AF                                                    " +
                    "                ,	fat_zanthus_sat_ecf_m00ac = A.M00AC                                                 " +
                    "                ,	fat_zanthus_cupomfiscal_m00ad = A.M00AD                                             " +
                    "                ,	0                                                                                   " +
                    "                ,	0                                                                                   " +
                    "        from		ZEUSRETAIL.DBO.ZAN_M45	A                                                           " +
                    "        WHERE		1 = 1  " +                                                                  
                    "          AND      A.M00AF = '{0}'                                                                     " +
                    "          AND      A.M00AC =  {1}                                                                      " 
                    //"        AND			NOT EXISTS (	SELECT 1                                                        " +
                    //"			                        FROM   POSTSQL.oxan.[public].tbfaturamentozanthus_ctrl_cupom        " +
                    //"			                        WHERE  fat_zanthus_data_m00af = CONVERT(VARCHAR(12), A.M00AF )      " +
                    //"			                        AND     fat_zanthus_sat_ecf_m00ac = A.M00AC                         " +
                    //"			                        AND		fat_zanthus_cupomfiscal_m00ad = A.M00AD                     " +
                    //"		                        )"
                    , DATA.ToString("yyyy-MM-dd")
                    , ECF.ToString()
                    
                    );

                DataTable DT_CUPOM_PROCESSAMENTO = (DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SCRIPT_SQLSERVER_Update_Processamento, null, true)).Tables[0];


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;

                _COUNT = DT_CUPOM_PROCESSAMENTO.Rows.Count;
                
                foreach (DataRow row in DT_CUPOM_PROCESSAMENTO.Rows)
                {
                    string SCRIPT_SQL = string.Format("SELECT f0055_11_1011970_faturamentozanthus_ctrl_cupom (     " + 
                                                       "        sqlcommand                         := 'DBINSERT'            " + 
                                                       "     ,	vfat_zanthus_data_m00af 		   := '{0}'                 " + 
                                                       "     ,	vfat_zanthus_sat_ecf_m00ac		   := {1}                   " + 
                                                       "     ,	vfat_zanthus_cupomfiscal_m00ad 	   := {2}                   " + 
                                                       "     ,	vfat_zanthus_conferencia 		   := 0                     " + 
                                                       "     ,	vfat_zanthus_processado			   := 0                     " + 
                                                       "     ,  vfat_zanthus_pag			       := 0                     " + 
                                                       "     ) ; ", 
                                                       Convert.ToDateTime(row["fat_zanthus_data_m00af"].ToString()).ToString("yyyy-MM-dd") ,
                                                       Convert.ToInt32(row["fat_zanthus_sat_ecf_m00ac"].ToString()).ToString() ,
                                                       Convert.ToInt32(row["fat_zanthus_cupomfiscal_m00ad"].ToString()).ToString() 
                                                       );
                    _Command_All = _Command_All + SCRIPT_SQL;
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    
                    if (_SEQ_UPDATE > 50 || _SEQ_COUNT >= _COUNT)
                    {
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }

                }


                string Sql_Cupom_Processamento = string.Format(" SELECT   fat_zanthus_data_m00af  " +
                                                               "        , fat_zanthus_sat_ecf_m00ac " + 
                                                               "        , fat_zanthus_cupomfiscal_m00ad " + 
                                                               "        , fat_zanthus_conferencia  " + 
                                                               "        , fat_zanthus_processado " + 
                                                               "        , fat_zanthus_pag " + 
                                                               " FROM   tbfaturamentozanthus_ctrl_cupom   " +
                                                               " WHERE  1 = 1 " +
                                                               "  AND   fat_zanthus_sat_ecf_m00ac = {0} " +
                                                               "  AND   fat_zanthus_data_m00af = '{1}' ",
                                                               ECF.ToString(),
                                                               DATA.ToString("yyyy-MM-dd")
                                                               );

                DataTable DT = BDCommand.get_DataTable(MyConnect, Sql_Cupom_Processamento);
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Processamento_Cupom (int ECF, DateTime Data, int NumeroCupom)
        {
            try
            {
                /*Dados do Cupom */
                string SQL_POSTGRE_INSERT = _Postgre_Cupom_Insert(((DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, _SqlServer_Cupom_Select(ECF, Data, NumeroCupom), null, true)).Tables[0]).Rows[0]);


                /*Obtendo itens do Cupom*/
                DataTable DT_CUPOM_ITEM = (DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, _SqlServer_CupomItem_Select(ECF, Data, NumeroCupom), null, true)).Tables[0];
                
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                string _Command_All = "";
                //int _SEQ_UPDATE = 0;
                //int _SEQ_COUNT = 0;
                int _COUNT = DT_CUPOM_ITEM.Rows.Count;

                foreach (DataRow row_item in DT_CUPOM_ITEM.Rows)
                {
                    string SQL_POSTGRE_INSERT_ITEM = _Postgre_Cupom_ItemInsert(row_item);
                    _Command_All = _Command_All + SQL_POSTGRE_INSERT_ITEM;
                }

                //INSERINDO CUPOM 
                BDExecute.Execute(SQL_POSTGRE_INSERT, null, DataBaseName.ODBCOXAN);

                //INSERINDO INSERINDO ITENS
                BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);

                BDExecute.Dispose();

                System.Threading.Thread.Sleep(110);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Processamento_ECF(int ECF, DateTime Data, bool processa_pag, bool processa_vendas_pendentes)
        {
            try
            {

                backendJs_Faturamento_Ecf(MyConnect, Data, ECF, processa_vendas_pendentes);

                /*
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;
                
                
                //Dados do Cupom e Processamento dos Cupons 

                DataTable DT_CUPOM = (DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, _SqlServer_Cupom_Select(ECF, Data, 0), null, true)).Tables[0];

                _COUNT = DT_CUPOM.Rows.Count;

                foreach (DataRow row_cupom in DT_CUPOM.Rows)
                {

                    string SQL_POSTGRE_CUPOM_INSERT = _Postgre_Cupom_Insert(row_cupom);

                    _Command_All = _Command_All + SQL_POSTGRE_CUPOM_INSERT;
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    
                    if (_SEQ_UPDATE > 50 || _SEQ_COUNT >= _COUNT)
                    {
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }

                 // Dados dos itens e processamento
                _Command_All = "";
                _SEQ_UPDATE = 0;
                _SEQ_COUNT = 0;
                _COUNT = 0;


                DataTable DT_CUPOM_ITEM = (DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, _SqlServer_CupomItem_Select(ECF, Data, 0 ), null, true)).Tables[0];
                _COUNT = DT_CUPOM_ITEM.Rows.Count;

                foreach (DataRow row_item in DT_CUPOM_ITEM.Rows)
                {
                    string SQL_POSTGRE_INSERT_ITEM = _Postgre_Cupom_ItemInsert(row_item);
                    _Command_All = _Command_All + SQL_POSTGRE_INSERT_ITEM;

                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;

                    if (_SEQ_UPDATE > 25 || _SEQ_COUNT >= _COUNT)
                    {
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(100);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }


                if (processa_pag) {
                    string SQL_Processa_Pag = String.Format("SELECT f0055_60_1011970_faturamento_cupom_processamento('{0}',{1} ,0); select f0055_61_1011940_faturamento_cupom_cancelamento('{0}');", Data.ToString("yyyy-MM-dd"), ECF);
                    BDExecute.Execute(SQL_Processa_Pag, null, DataBaseName.ODBCOXAN);
                }

                BDExecute.Dispose();

                System.Threading.Thread.Sleep(110);
                */

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string _SqlServer_Cupom_Select(int ECF, DateTime Data, int NumeroCupom)
        {
            string StringSql = string.Format("     SELECT " +
                                              "                 fat_zanthus_data_m00af							= A.M00AF  " +
                                              "             ,   fat_zanthus_sat_ecf_m00ac						= A.M00Ac  " +
                                              "             ,   fat_zanthus_cupomfiscal_m00ad					= A.M00Ad  " +
                                              "             ,   fat_zanthus_cupomfiscalid_M00_id_unico			= A.M00_id_unico" +
                                              "             ,	fat_zanthus_cupomfiscal_cancelado_m45bo			= A.M45BO" +
                                              "             ,   fat_zanthus_notafiscal_numnota					= isnull(A.M45XD,0)" +
                                              "             ,   fat_zanthus_notafiscal_serie_nf					= isnull(N.serie_nf,0)                                              " +
                                              "             ,	fat_zanthus_notafiscal_chave_m45xb				= isnull(a.M45XB,'')                                                           " +
                                              "             ,	fat_zanthus_status_cancelado					=case  " +
                                              "				                                                    when A.M00Ad <> A.M45BO then 9                                  " +
                                              "				                                                    else case when isnull(x.M45BO,0) <> 0 then 1 else 0 end         " +
                                              "				                                                    end   " +
                                              "             ,	fat_zanthus_cupomfiscal_valor_m45ak				= A.M45AK " +
                                              "             ,	fat_zanthus_cpf_cnpj_m45bv						= A.m45bv " +
                                              "             ,	fat_zanthus_hora_ini_m45ai						= substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45ai	))) + CONVERT(VARCHAR(4),  A.m45ai)))),1,2) + ':' +  substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45ai	))) + CONVERT(VARCHAR(4),  A.m45ai)))),3,2) + ':00' " +
                                              "             ,	fat_zanthus_hora_fim_m45au						= substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45au	))) + CONVERT(VARCHAR(4),  A.m45au)))),1,2) + ':' +  substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45au	))) + CONVERT(VARCHAR(4),  A.m45au)))),3,2) + ':00' " +
                                              "             ,	fat_zanthus_cod_funcionario_m45ah				= A.M45AH " +
                                              "             ,	fat_zanthus_voucher_cod_m50ar					= isnull(voucher.M50AR, '')   " +
                                              "             ,	fat_zanthus_voucher_valor_m50at					= isnull(voucher.m50at,0 ) " +
                                              "             ,	fat_zanthus_voucher_count_m50ag					= isnull(voucher.m50ag,0) " +
                                              "             ,   fat_zanthus_conferencia = 0 " + 
                                              "             ,   fat_zanthus_processado = 0 " + 
                                              "             ,   fat_zanthus_pag  = 0 " + 
                                              "     from		ZEUSRETAIL.DBO.ZAN_M45									A                                                                                               " +
                                              "     left join   ZEUSRETAIL.DBO.ZAN_M45			x		on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad                        " +
                                              "     left JOIN	ZEUSRETAIL.dbo.tab_nota_header	n		ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF                                         " +
                                              "     left join   (                                               " +
                                              "                         select		m00af                       " +
                                              "                                 ,	m00ac                       " +
                                              "                                 ,	m00ad                       " +
                                              "                                 ,	m50ar = min(m50ar)          " +
                                              "                                 ,	m50ag = count(m50ag)        " +
                                              "                                 ,	m50at = sum(m50at)          " +
                                              "                         from		ZeusRetail.dbo.Zan_M50 q    " +
                                              "                         where		 1= 1                       " +
                                              "                         and			q.m00af = '{0}'   " +
                                              "                         and         q.m00ac =  {1}     " + 
                                              "                         group by m00af, m00ac, m00ad  " +
                                              "                 ) voucher on voucher.M00AF = a.m00af and voucher.m00ac = a.m00ac  and voucher.M00AD = a.M00AD   " +
                                              "     WHERE		A.M00AF = '{0}'  " +
                                              "       AND       A.M00AC =  {1} " +
                                              "       AND       A.M00AD =  CASE WHEN {2} = 0 THEN A.M00AD ELSE {2} END " +
                                              "     group by	A.M00AF                " +
                                              "             ,	A.M00Ac                " +
                                              "             ,	A.M00Ad                " +
                                              "             ,	A.M00_id_unico         " +
                                              "             ,	A.M45BO                " +
                                              "             ,	isnull(A.M45XD,0)      " +
                                              "             ,	isnull(N.serie_nf,0)   " +
                                              "             ,	isnull(a.M45XB,'')     " +
                                              "             ,	case                   " +
                                              "                 when A.M00Ad <> A.M45BO then 9                                      " +
                                              "                 else case when isnull(x.M45BO,0) <> 0 then 1 else 0 end             " +
                                              "                 end     " +
                                              "             ,	A.M45AK " +
                                              "             ,	A.m45bv " +
                                              "             ,	A.m45ai " +
                                              "             ,	A.m45au " +
                                              "             ,	A.M45AH " +
                                              "             ,	isnull(voucher.M50AR,'') " +
                                              "             ,	isnull(voucher.m50at,0) " +
                                              "             ,	isnull(voucher.m50ag,0) "
                                              , Data.ToString("yyyy-MM-dd"), ECF.ToString(), NumeroCupom.ToString());
            return StringSql;
        }
        public static string _SqlServer_CupomItem_Select(int ECF, DateTime Data, int NumeroCupom)
        {
             string StringSql =  string.Format( "           select	  	fat_zanthus_data_m00af					=			a.m00af 									    " + 
		                                        "                    ,	fat_zanthus_sat_ecf_m00ac				=			a.M00AC                                         " + 
		                                        "                    ,	fat_zanthus_cupomfiscal_m00ad			=			a.M00AD                                         " + 
		                                        "                    ,	fat_zanthus_item_seq_m43eg				=			i.M43EG                                         " + 
		                                        "                    ,	fat_zanthus_item_cdbarra_m43ah			=			replicate('0', 14 - len(convert(varchar(14), m43ah))) + convert(varchar(14), m43ah) " + 
		                                        "                    ,	fat_zanthus_item_cdbarra_M43BK_m43ah	=			replicate('0', 14 - len(convert(varchar(14) ,  case when isnull(M43BK,'0') != '0' then isnull(M43BK,'0') else  i.m43ah end  ))) + convert(varchar(14) ,  case when isnull(M43BK,'0') != '0' then isnull(M43BK,'0') else  i.m43ah end  ) " + 
		                                        "                    ,	fat_zanthus_item_qtde_m43ao				=			isnull(M43AO,0)                                " +  
		                                        "                    ,	fat_zanthus_item_valor_m43ap			=			ISNULL(i.M43AP,0)                              " + 
		                                        "                    ,	fat_zanthus_item_valor_desconto_m43aq	=			ISNULL(i.M43Aq,0)                              " + 
		                                        "                    ,	fat_zanthus_M43BK						=			isnull(M43BK,'0')                              " + 
		                                        "                    ,	fat_zanthus_Decomp_Insumo				=			isnull(DECOMP.percentual_insumo,0)             " + 
		                                        "                    ,	fat_zanthus_val_liquido					=			ISNULL(i.val_liquido,0)                        " + 
		                                        "                    ,	fat_zanthus_qtde						=			convert(numeric(17,4), case when isnull(M43BK,'0') != '0' then (DECOMP.percentual_insumo / 100) * M43AO else  i.m43ao end ) " + 
                                                "           from		zeusretail.dbo.zan_m43								i with (nolock) " + 
                                                "           inner join  ZEUSretail.dbo.zan_m45								a on a.m00af = i.m00af and a.m00ac = i.m00ac and a.m00ad = i.m00ad " + 
                                                "           LEFT JOIN	ZeusRetail.DBO.tab_produto_decomposicao_insum DECOMP ON CONVERT(NUMERIC(14,0) , DECOMP.cod_insumo) = CONVERT(NUMERIC(14,0), I.M43AH)  " +
							                    "                                       and CONVERT(NUMERIC(14,0) , DECOMP.cod_mercadoria) = CONVERT(NUMERIC(14,0), I.M43BK) " +
                                                "           WHERE	1 = 1 " + 
                                                "           AND		A.M00AF = '{0}' " +
                                                "           AND		A.M00AC = {1} " +
                                                "           AND     A.M00AD =  CASE WHEN {2} = 0 THEN A.M00AD ELSE {2} END " +
                                                "           order by a.m00ad, 	i.M43EG ", Data.ToString("yyyy-MM-dd"), ECF.ToString(), NumeroCupom.ToString());
             return StringSql;
        }
        public static string _Postgre_Cupom_Insert(DataRow row_cupom)
        {
            try 
            {
                string SQL_POSTGRE_INSERT = string.Format("SELECT f0055_12_1011970_faturamento_zanthus_crud( " +
                                         "		sqlcommand                                  :=               'DBINSERT'      " +
                                         "	,	vfat_zanthus_data_m00af	                    := 				 '{0}'	 " +
                                         "	,   vfat_zanthus_sat_ecf_m00ac					:=                {1}	 " +
                                         "	,   vfat_zanthus_cupomfiscal_m00ad				:=                {2}    " +
                                         "	,   vfat_zanthus_cupomfiscalid_M00_id_unico		:=               '{3}'	 " +
                                         "	,	vfat_zanthus_cupomfiscal_cancelado_m45bo	:=                {4}    " +
                                         "	,   vfat_zanthus_notafiscal_numnota				:=                {5}    " +
                                         "	,   vfat_zanthus_notafiscal_serie_nf			:=                {6}    " +
                                         "	,	vfat_zanthus_notafiscal_chave_m45xb			:=               '{7}'   " +
                                         "	,	vfat_zanthus_status_cancelado				:=                {8}    " +
                                         "	,	vfat_zanthus_cupomfiscal_valor_m45ak		:=                {9}    " +
                                         "	,	vfat_zanthus_cpf_cnpj_m45bv					:=               '{10}'  " +
                                         "	,	vfat_zanthus_hora_ini_m45ai					:=               '{11}'  " +
                                         "	,	vfat_zanthus_hora_fim_m45au					:=               '{12}'  " +
                                         "	,	vfat_zanthus_cod_funcionario_m45ah			:=                {13}   " +
                                         "	,	vfat_zanthus_voucher_cod_m50ar				:=               '{14}'  " +
                                         "	,	vfat_zanthus_voucher_valor_m50at			:=                {15}   " +
                                         "	,	vfat_zanthus_voucher_count_m50ag			:=                {16}   " +
                                         "	,	vfat_zanthus_conferencia			        :=                0      " +
                                         "	,	vfat_zanthus_processado  			        :=                0      " +
                                         "	,	vfat_zanthus_pag    			            :=                0      );",
                                             Convert.ToDateTime(row_cupom["fat_zanthus_data_m00af"]).ToString("yyyy-MM-dd"),
                                             Convert.ToInt32(row_cupom["fat_zanthus_sat_ecf_m00ac"].ToString()),
                                             Convert.ToInt32(row_cupom["fat_zanthus_cupomfiscal_m00ad"].ToString()),
                                             row_cupom["fat_zanthus_cupomfiscalid_M00_id_unico"].ToString(),
                                             Convert.ToInt32(row_cupom["fat_zanthus_cupomfiscal_cancelado_m45bo"].ToString()),
                                             Convert.ToInt32(row_cupom["fat_zanthus_notafiscal_numnota"].ToString()),
                                             Convert.ToInt32(row_cupom["fat_zanthus_notafiscal_serie_nf"].ToString()),
                                             row_cupom["fat_zanthus_notafiscal_chave_m45xb"].ToString(),
                                             Convert.ToInt32(row_cupom["fat_zanthus_status_cancelado"].ToString()),
                                             Convert.ToDouble(row_cupom["fat_zanthus_cupomfiscal_valor_m45ak"].ToString()).ToString("0.00").Replace(",", "."),
                                             row_cupom["fat_zanthus_cpf_cnpj_m45bv"].ToString(),
                                             row_cupom["fat_zanthus_hora_ini_m45ai"].ToString(),
                                             row_cupom["fat_zanthus_hora_fim_m45au"].ToString(),
                                             Convert.ToInt32(row_cupom["fat_zanthus_cod_funcionario_m45ah"].ToString()),
                                             row_cupom["fat_zanthus_voucher_cod_m50ar"].ToString(),
                                             Convert.ToDouble(row_cupom["fat_zanthus_voucher_valor_m50at"].ToString()).ToString("0.00").Replace(",", "."),
                                             Convert.ToInt32(row_cupom["fat_zanthus_voucher_count_m50ag"].ToString())
                                         );
                return SQL_POSTGRE_INSERT;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }

        }
        public static string _Postgre_Cupom_ItemInsert(DataRow row_item)
        {
            try
            {
                string SQL_POSTGRE_INSERT_ITEM = string.Format("SELECT f0055_13_1011970_faturamento_zanthus_item_crud(          " +
                                            "		sqlcommand                                  := 'DBINSERT'            " +
                                            "	,	vfat_zanthus_data_m00af	                    := 				 '{0}'	 " +
                                            "	,   vfat_zanthus_sat_ecf_m00ac					:=                {1}	 " +
                                            "	,   vfat_zanthus_cupomfiscal_m00ad				:=                {2}    " +
                                            "   ,   vfat_zanthus_item_seq_m43eg				    :=                {3}    " +
                                            "   ,   vfat_zanthus_item_cdbarra_m43ah		        :=               '{4}'   " +
                                            "   ,	vfat_zanthus_item_cdbarra_M43BK_m43ah		:=               '{5}'   " +
                                            "   ,   vfat_zanthus_item_qtde_m43ao				:=                {6}    " +
                                            "   ,   vfat_zanthus_item_valor_m43ap				:=                {7}    " +
                                            "   ,   vfat_zanthus_item_valor_desconto_m43aq		:=                {8}    " +
                                            "   ,	vfat_zanthus_M43BK 						    :=               '{9}'   " +
                                            "   ,	vfat_zanthus_Decomp_Insumo					:=                {10}   " +
                                            "   ,	vfat_zanthus_val_liquido					:=                {11}   " +
                                            "   ,	vfat_zanthus_qtde							:=                {12}  ); ",
                                            Convert.ToDateTime(row_item["fat_zanthus_data_m00af"].ToString()).ToString("yyyy-MM-dd"),
                                            Convert.ToInt32(row_item["fat_zanthus_sat_ecf_m00ac"].ToString()),
                                            Convert.ToInt32(row_item["fat_zanthus_cupomfiscal_m00ad"].ToString()),
                                            Convert.ToInt32(row_item["fat_zanthus_item_seq_m43eg"].ToString()),
                                            row_item["fat_zanthus_item_cdbarra_m43ah"].ToString(),
                                            row_item["fat_zanthus_item_cdbarra_M43BK_m43ah"].ToString(),
                                            Convert.ToDouble(row_item["fat_zanthus_item_qtde_m43ao"].ToString()).ToString("0.00").Replace(",", "."),
                                            Convert.ToDouble(row_item["fat_zanthus_item_valor_m43ap"].ToString()).ToString("0.00").Replace(",", "."),
                                            Convert.ToDouble(row_item["fat_zanthus_item_valor_desconto_m43aq"].ToString()).ToString("0.00").Replace(",", "."),
                                            row_item["fat_zanthus_M43BK"].ToString(),
                                            Convert.ToDouble(row_item["fat_zanthus_Decomp_Insumo"].ToString()).ToString("0.00").Replace(",", "."),
                                            Convert.ToDouble(row_item["fat_zanthus_val_liquido"].ToString()).ToString("0.00").Replace(",", "."),
                                            Convert.ToDouble(row_item["fat_zanthus_qtde"].ToString()).ToString("0.00").Replace(",", ".")
                                            );
                return SQL_POSTGRE_INSERT_ITEM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void backendJs_Faturamento_ZanthusCtrl(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime Data) 
        {
            try 
            {
                Pag_Net.Bll.RESTAPI.get(string.Format("{0}/faturamentozanthus/filter/integratectrl?data={1}", MyConnect.PAG_API, Data.ToString("dd/MM/yyyy")), null);

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void backendJs_Faturamento_Ecf(Pag_Net.Models.modelSistemaUsuario MyConnect, DateTime Data, int satEcf, bool pendente)
        {
            try
            {
                Pag_Net.Bll.RESTAPI.get(string.Format("{0}/faturamentozanthus/filter/integratedata?data={1}&satecf={2}&processavendapendente={3}", MyConnect.PAG_API, Data.ToString("dd/MM/yyyy"), satEcf, pendente ? "1" : "0"), null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
    }

    public static class Service 
    {
        public static void start(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                WKProcessamento WK = new WKProcessamento(MyConnect);
                DataTable DT = WK.ProcessamentoECF_Consultar(true, DateTime.Now, DateTime.Now,0);
                DateTime DATA = DateTime.Now;
                int ECF = Convert.ToInt32(DT.Rows[0]["fat_zanthus_sat_ecf_m00ac"].ToString());
                int fz_cupom_qtde = Convert.ToInt32(DT.Rows[0]["fz_cupom_qtde"].ToString());
                int fz_pag_cupom_qtde = Convert.ToInt32(DT.Rows[0]["fz_pag_cupom_qtde"].ToString());
                if (fz_cupom_qtde != fz_pag_cupom_qtde) 
                {
                    WK.Processamento_Cupom(ECF, DATA, 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                
        }
    }

    
}
