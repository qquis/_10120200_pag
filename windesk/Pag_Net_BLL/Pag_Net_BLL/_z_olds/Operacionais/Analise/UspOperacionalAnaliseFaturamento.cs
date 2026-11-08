using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.Operacionais.Analise
{
    public class UspOperacionalAnaliseFaturamento : Bll.USPDataContext
    {
        public string cdProdutoErro;
        public Filtros Filtros;
        public int TotalItens { get; set; }
        public double TotalCusto { get; set; }
        public double TotalCustoSubsidio { get; set; }
        public double TotalVolume { get; set; }
        public double TotalFaturamentoBase { get; set; }
        public double TotalSubsidiosCorrentes { get; set; }
        public double TotalFaturamento { get; set; }
        public double TotalDescontosFinanceiros { get; set; }
        public double TotalFaturamentoOperacional { get; set; }
        public double TotalSubsidiosAplicados { get; set; }
        public double TotalFaturamentoLiquido { get; set; }

        public double TotalFaturamentoMargem { get; set; }
        public double TotalMargemFaturamento { get; set; }

        public double TotalFaturamentoOperacionalMargem { get; set; }
        public double TotalMargemOperacional { get; set; }

        public double TotalFaturamentoLiquidoMargem { get; set; }
        public double TotalMargemLiquida { get; set; }


        public UspOperacionalAnaliseFaturamento(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new Filtros();
        }
        public void Select()
        {
            string linhaEmProcessamento = "";
            try
            {
                this.TotalItens = 0;
                this.TotalCusto = 0;
                this.TotalVolume = 0;
                this.TotalFaturamentoBase = 0;
                this.TotalSubsidiosCorrentes = 0;
                this.TotalFaturamento = 0;
                this.TotalDescontosFinanceiros = 0;
                this.TotalFaturamentoOperacional = 0;
                this.TotalSubsidiosAplicados = 0;
                this.TotalFaturamentoLiquido = 0;
                this.TotalCustoSubsidio = 0;

                base.ViewData = null;
                Double TotalFaturamentoParticipacao = 0;
                
                List<FaturamentoItem> L = new List<FaturamentoItem>();
                base.Select();

                if (base.DataTableResult == null)
                {
                    return;
                }

                if (!DBNull.Value.Equals(base.DataTableResult))
                {
                    if (base.DataTableResult.Rows.Count > 0)
                    {
                        TotalFaturamentoParticipacao = Convert.ToDouble(base.DataTableResult.Compute("Sum(FaturamentoLiquido)", ""));
                    }
                    else
                    {
                        return;
                    }
                }

                else
                {
                    return;
                }


                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    FaturamentoItem l = new FaturamentoItem();
                    linhaEmProcessamento = i["Codigo"].ToString();
                    
                    l.Codigo = i["Codigo"].ToString();
                    cdProdutoErro = l.Codigo;
                    l.Descricao = i["Descricao"].ToString();
                    l.CustoPadrao = Convert.ToDouble(i["CustoPadrao"].ToString());
                    l.CustoSubsidio = Convert.ToDouble(i["CustoSubsidio"].ToString());
                    l.Volume = Convert.ToDouble(i["Volume"]);
                    l.FaturamentoBase = Convert.ToDouble(i["FaturamentoBase"]);
                    l.SubsidiosCorrentes = Convert.ToDouble(i["SubsidiosCorrentes"]);
                    l.Faturamento = Convert.ToDouble(i["Faturamento"]);
                    l.DescontosFinanceiros = Convert.ToDouble(i["DescontosFinanceiros"]);
                    l.FaturamentoOperacional = Convert.ToDouble(i["FaturamentoOperacional"]);
                    l.SubsidiosAplicados = Convert.ToDouble(i["SubsidiosAplicados"]);
                    l.FaturamentoLiquido = Convert.ToDouble(i["FaturamentoLiquido"]);
                    l.Mix = Convert.ToInt32(i["MiX"]);
                    l.Clientes = Convert.ToInt32(i["Clientes"]);
                    l.Positivacao = Convert.ToInt32(i["Positivacao"]);
                    l.MargemFaturamento = Convert.ToDouble(i["MargemFaturamento"]);
                    l.MargemFaturamentoBase = Convert.ToDouble(i["MargemFaturamentoBase"]);
                    l.MargemFaturamentoBruto = Convert.ToDouble(i["MargemFaturamentoBruto"]);
                    l.MargemFaturamentoLiquido = Convert.ToDouble(i["MargemFaturamentoLiquido"]);
                    if (l.FaturamentoLiquido > 0)
                    {
                        l.TicketMedio = Math.Round(l.FaturamentoLiquido / l.Positivacao, 2); ;
                    }
                    if (l.FaturamentoLiquido > 0)
                    {
                        l.Participacao = (l.FaturamentoLiquido / TotalFaturamentoParticipacao) * 100;
                    }
                    else
                    {
                        l.Participacao = 0;
                    }

                    TotalVolume += l.Volume;
                    TotalFaturamentoBase += l.FaturamentoBase;
                    TotalSubsidiosCorrentes += l.SubsidiosCorrentes;
                    TotalFaturamento += l.Faturamento;
                    TotalDescontosFinanceiros += l.DescontosFinanceiros;
                    TotalFaturamentoOperacional += l.FaturamentoOperacional;
                    TotalSubsidiosAplicados += l.SubsidiosAplicados;
                    TotalFaturamentoLiquido += l.FaturamentoLiquido;
                    TotalCustoSubsidio += l.CustoSubsidio;
                    TotalCusto += l.CustoPadrao;
                    TotalItens += 1;
                    L.Add(l);
                }



                this.TotalFaturamentoMargem = TotalFaturamento - TotalCusto;
                this.TotalFaturamentoOperacionalMargem = TotalFaturamentoOperacional - TotalCusto;
                this.TotalFaturamentoLiquidoMargem = TotalFaturamentoLiquido - (TotalCusto - TotalCustoSubsidio);
                if (TotalCusto < TotalCustoSubsidio)
                {
                    TotalCustoSubsidio = TotalCusto;
                }

                if (TotalFaturamento > TotalCusto)
                {
                    TotalMargemFaturamento = ((TotalFaturamento - TotalCusto) / TotalFaturamento * 100);
                }
                else
                {
                    if (TotalFaturamento < TotalCusto)
                    {
                        TotalMargemFaturamento = ((TotalFaturamento - TotalCusto) / TotalCusto * 100);
                    }
                    else
                    {
                        if (TotalFaturamento == TotalCusto) TotalMargemFaturamento = -100;
                    }
                }

                if (TotalFaturamentoOperacional > TotalCusto)
                {
                    TotalMargemOperacional = ((TotalFaturamentoOperacional - TotalCusto) / TotalFaturamentoOperacional * 100);
                }
                else
                {
                    if (TotalFaturamentoOperacional < TotalCusto)
                    {
                        TotalMargemOperacional = ((TotalFaturamento - TotalCusto) / TotalCusto * 100);
                    }
                    else
                    {
                        if (TotalFaturamentoOperacional == TotalCusto) TotalMargemOperacional = -100;
                    }
                }

                if (TotalFaturamentoLiquido > (TotalCusto - TotalCustoSubsidio))
                {
                    TotalMargemLiquida = ((TotalFaturamentoLiquido - (TotalCusto - TotalCustoSubsidio)) / TotalFaturamentoLiquido * 100);
                }
                else
                {
                    if (TotalFaturamentoLiquido < TotalCusto)
                    {
                        TotalMargemLiquida = ((TotalFaturamentoLiquido - TotalCusto) / TotalCusto * 100);
                    }
                    else
                    {
                        if (TotalFaturamentoLiquido == (TotalCusto - TotalCustoSubsidio)) TotalMargemLiquida = -100;
                    }
                }

                base.ViewData = L.ToArray();




                //public double TotalMargemFaturamento { get; set; }

                //public double TotalFaturamentoOperacionalMargem { get; set; }
                //public double TotalMargemOperacional { get; set; }

                //public double TotalFaturamentoLiquidoMargem { get; set; }
                //public double TotalMargemLiquida { get; set; }
            }
            catch (Exception ex)
            {
               throw new Exception("ERRO - " + cdProdutoErro + " " + ex.Message);
            }

        }

        public override Models.ParameterQuey[] ListParametros()
        {
            
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("dt_faturamento_ini", SqlDbType.DateTime, true, Filtros.DataInicial));
            ListParameters.Add(new Models.ParameterQuey("dt_faturamento_fim", SqlDbType.DateTime, true, Filtros.DataFinal));
            ListParameters.Add(new Models.ParameterQuey("TipoPesquisa", SqlDbType.VarChar, true, Filtros.TipoPesquisa));
            ListParameters.Add(new Models.ParameterQuey("Departamento", SqlDbType.VarChar, true, Filtros.Departamento));
            ListParameters.Add(new Models.ParameterQuey("Secao", SqlDbType.VarChar, true, Filtros.Secao));
            ListParameters.Add(new Models.ParameterQuey("Linha", SqlDbType.VarChar, true, Filtros.Linha));
            ListParameters.Add(new Models.ParameterQuey("Vendedor", SqlDbType.Int, true, Filtros.Vendedor));
            ListParameters.Add(new Models.ParameterQuey("Fabricante", SqlDbType.VarChar, true, Filtros.Fabricante));
            ListParameters.Add(new Models.ParameterQuey("NomeCliente", SqlDbType.VarChar, true, Filtros.NomeCliente));
            ListParameters.Add(new Models.ParameterQuey("EmbalagemFornecedor", SqlDbType.Bit, true, Filtros.EmbalagemFornecedor));
            ListParameters.Add(new Models.ParameterQuey("StatusFaturamento", SqlDbType.Char, true, Filtros.StatusFaturamento));
            ListParameters.Add(new Models.ParameterQuey("ProdutosCodigoLista", SqlDbType.VarChar, true, Filtros.ProdutosCodigoLista));
            ListParameters.Add(new Models.ParameterQuey("DescricaoProduto", SqlDbType.VarChar, true, Filtros.DescricaoProduto));
            ListParameters.Add(new Models.ParameterQuey("NumerosPedidos", SqlDbType.VarChar, true, Filtros.NumerosPedidos));
            ListParameters.Add(new Models.ParameterQuey("CdOperacao", SqlDbType.Int, true, Filtros.CdOperacao));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoGestor", SqlDbType.Int, true, Filtros.SeqProdutoGestor));
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, true, Filtros.SeqProdutoCategoria));
            ListParameters.Add(new Models.ParameterQuey("OperacoesComOutrosTiposDeProduto", SqlDbType.Bit, true, Filtros.OperacoesComOutrosTiposDeProduto));
            ListParameters.Add(new Models.ParameterQuey("FVBlueSoft", SqlDbType.Bit, true, Filtros.FvBlueSoft)); 
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            /* FATURAMENTO 23/02/2021 */
            return "SPR0100_Faturamento_Analise_b";
        }
    }

    public class FaturamentoItem
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Embalagem { get; set; }
        public double Volume { get; set; }
        public double CustoPadrao { get; set; }
        public double CustoSubsidio { get; set; }
        public double FaturamentoBase { get; set; }
        public double SubsidiosCorrentes { get; set; }
        public double Faturamento { get; set; }
        public double DescontosFinanceiros { get; set; }
        public double FaturamentoOperacional { get; set; }
        public double SubsidiosAplicados { get; set; }
        public double FaturamentoLiquido { get; set; }
        public int Mix { get; set; }
        public int Clientes { get; set; }
        public int Positivacao { get; set; }
        public double MargemFaturamento { get; set; }
        public double MargemFaturamentoBase { get; set; }
        public double MargemFaturamentoBruto { get; set; }
        public double MargemFaturamentoLiquido { get; set; }
        public double Participacao { get; set; }
        public double TicketMedio { get; set; }
        public double CustoUnitarioMedio 
        {
            get
            {
                if (this.CustoPadrao != null )
                {
                    if (this.CustoPadrao > 0)
                    {
                        return Math.Round(CustoPadrao / Volume, 2);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        
        }
        
        public double PrecoBaseUnitarioMedio
        {

            get
            {
                if (this.FaturamentoBase != null)
                {
                    if (this.FaturamentoBase > 0)
                    {
                        return Math.Round(FaturamentoBase / Volume, 2);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public double PrecoUnitarioMedio
        {
            get
            {
                if (this.FaturamentoLiquido != null)
                {
                    if (this.FaturamentoLiquido > 0)
                    {
                        return Math.Round(FaturamentoLiquido / Volume, 2);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

        }
    }
}
