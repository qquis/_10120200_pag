using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.CO03.Models
{

    
    public class FaturamentoBlueItens
    {
        public string SQLSP
        {
            get
            {
                return "SPC03FaturamentoBlueItens";
            }
        }
        public enum Reports {
            Items
        }

        
        public DateTime PARAMETRO_DataInicial       		{ get; set; }
        public DateTime PARAMETRO_DataFinal         		{ get; set; }
        public int      PARAMETRO_SeqFaturamentoBlue		{ get; set; }

		public int      NumeroPedidoForca		            { get; set; }
		public int      NumeroPedidoCliente		            { get; set; }

        public int      NotaFiscalSeq                       { get; set; }
        public int      NotaFiscalNumero                    { get; set; }

		public int      CdProdutoBlueSoft					{ get; set; }
		public int      PedidoCdProdutoBlueSoft			    { get; set; }
		public string   EmbalagemEstoque					{ get; set; }
		public string   EmbalagemCompra					    { get; set; }
		public double   EmbalagemEstoqueQtde				{ get; set; }
		public double   EmbalagemCompraQtde				    { get; set; }
			



        public double   BlueSoftEmbalagemVendaFator			{ get; set; }
        public int      BlueSoftEmbalagemCompraCdProduto	{ get; set; }
        public double   BlueSoftEmbalagemCompraFator		{ get; set; }
        public double   BlueSoftValorCustoMedio				{ get; set; }
        public double   BlueSoftPrecoAplicado				{ get; set; }
        public double   BlueSoftPrecoTabela					{ get; set; }
        public double   BlueSoftPrecoFinal					{ get; set; }
        public double   BlueSoftVolume						{ get; set; }
        public double   BlueSoftVolumeFaturado              { get; set; }




			
		public double   ValorCustoPadraoUnitario			{ get; set; }
		public double   ValorFaturamentoBase				{ get; set; }
		public double   ValorSubsidiosCorrentes			    { get; set; }
		public double   ValorFaturamento					{ get; set; }
        public double   PercentualDescontoFinanceiro        { get; set; }
		public double   ValorSubsidioAplicado				{ get; set; }



		public double   ValorCustoPadrao					{ get; set; }
		public double   ValorTotalFaturamentoBase			{ get; set; }
		public double   ValorTotalSubsidiosCorrentes		{ get; set; }
		public double   ValorTotalFaturamento				{ get; set; }
		public double   ValorTotalDescontosFinanceiros		{ get; set; }
		public double   ValorTotalFaturamentoBruto			{ get; set; }
		public double   ValorTotalSubsidiosAplicado		    { get; set; }
		public double   ValorTotalFaturamentoLiquido		{ get; set; }



        public FaturamentoBlueItens(System.Data.DataRow i)
        {
            string errorString = i["NumeroPedidoCliente"].ToString();
            try
            {

                //FiltroDePesquisa_NumeroPedidoForca = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoForca"]);
                //FiltroDePesquisa_NumeroPedidoCliente = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoCliente"]);
                //FiltroDePesquisa_NotaFiscalSeq = Convert.ToInt32(i["FiltroDePesquisa_NotaFiscalSeq"]);




                PARAMETRO_SeqFaturamentoBlue = 0;
                
                NumeroPedidoForca		                = Convert.ToInt32(i["NumeroPedidoForca"]);
                NumeroPedidoCliente	                    = Convert.ToInt32(i["NumeroPedidoCliente"]);
                NotaFiscalSeq                           = Convert.ToInt32(i["NotaFiscalSeq"]);
                NotaFiscalNumero                        = Convert.ToInt32(i["NotaFiscalNumero"]);
                
                CdProdutoBlueSoft				        = Convert.ToInt32(i["CdProdutoBlueSoft"]);
                PedidoCdProdutoBlueSoft			        = Convert.ToInt32(i["PedidoCdProdutoBlueSoft"]);
                EmbalagemEstoque				        = Convert.ToString(i["EmbalagemEstoque"]);
                EmbalagemCompra					        = Convert.ToString(i["EmbalagemCompra"]);
                EmbalagemEstoqueQtde			        = Convert.ToDouble(i["EmbalagemEstoqueQtde"]);
                EmbalagemCompraQtde				        = Convert.ToDouble(i["EmbalagemCompraQtde"]);


                BlueSoftEmbalagemVendaFator             = Convert.ToDouble(i["BlueSoftEmbalagemVendaFator"]);
                BlueSoftEmbalagemCompraCdProduto        = Convert.ToInt32(i["BlueSoftEmbalagemCompraCdProduto"]);
                BlueSoftEmbalagemCompraFator            = Convert.ToDouble(i["BlueSoftEmbalagemCompraFator"]);
                BlueSoftValorCustoMedio                 = Convert.ToDouble(i["BlueSoftValorCustoMedio"]);
                BlueSoftPrecoAplicado                   = Convert.ToDouble(i["BlueSoftPrecoAplicado"]);
                BlueSoftPrecoTabela                     = Convert.ToDouble(i["BlueSoftPrecoTabela"]);
                BlueSoftPrecoFinal                      = Convert.ToDouble(i["BlueSoftPrecoFinal"]);
                BlueSoftVolume                          = Convert.ToDouble(i["BlueSoftVolume"]);
                BlueSoftVolumeFaturado                  = Convert.ToDouble(i["BlueSoftVolumeFaturado"]);


                
                ValorCustoPadraoUnitario		        = Convert.ToDouble(i["ValorCustoPadraoUnitario"]);
                ValorFaturamentoBase			        = Convert.ToDouble(i["ValorFaturamentoBase"]);
                ValorSubsidiosCorrentes			        = Convert.ToDouble(i["ValorSubsidiosCorrentes"]);
                ValorFaturamento				        = Convert.ToDouble(i["ValorFaturamento"]);
                PercentualDescontoFinanceiro            = Convert.ToDouble(i["PercentualDescontoFinanceiro"]);
                ValorSubsidioAplicado			        = Convert.ToDouble(i["ValorSubsidioAplicado"]);
                
                
                
                ValorCustoPadrao				        = Convert.ToDouble(i["ValorCustoPadrao"]);
                ValorTotalFaturamentoBase		        = Convert.ToDouble(i["ValorTotalFaturamentoBase"]);
                ValorTotalSubsidiosCorrentes	        = Convert.ToDouble(i["ValorTotalSubsidiosCorrentes"]);
                ValorTotalFaturamento			        = Convert.ToDouble(i["ValorTotalFaturamento"]);
                ValorTotalDescontosFinanceiros	        = Convert.ToDouble(i["ValorTotalDescontosFinanceiros"]);
                ValorTotalFaturamentoBruto		        = Convert.ToDouble(i["ValorTotalFaturamentoBruto"]);
                ValorTotalSubsidiosAplicado		        = Convert.ToDouble(i["ValorTotalSubsidiosAplicado"]);
                ValorTotalFaturamentoLiquido	        = Convert.ToDouble(i["ValorTotalFaturamentoLiquido"]);


            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.CO03.Models.FaturamentoBlueItems.FaturamentoBlueItems(datarow) " + Environment.NewLine + 
                                    "Referência - Número do Pedido: " + errorString  + Environment.NewLine + 
                                    "Erro: " +  ex.Message);
            }



        }


        public FaturamentoBlueItens(DateTime filtroDataPedidoInicial, DateTime filtroDataPedidoFinal)
        {
            PARAMETRO_DataInicial = filtroDataPedidoInicial;
            PARAMETRO_DataFinal = filtroDataPedidoFinal;

        }


        public List<ParameterQuey> SqlServer_SPC03FaturamentoBlueItems_DBINSERT
        {

            get
            {
                string LinhaEmExecucao = "Pedido do Pedido do Cliente: " + NumeroPedidoCliente.ToString();
                try
                {
            
                    List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                    SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, "DBINSERT"));
                    //SQLParametros.Add(new ParameterQuey("PARAMETRO_DataInicial", SqlDbType.SmallDateTime, false, Convert.ToDateTime(PARAMETRO_DataInicial)));
                    //SQLParametros.Add(new ParameterQuey("PARAMETRO_DataFinal", SqlDbType.SmallDateTime, false, Convert.ToDateTime(PARAMETRO_DataFinal)));
                    SQLParametros.Add(new ParameterQuey("PARAMETRO_SeqFaturamentoBlue", SqlDbType.Int, false, Convert.ToInt32(PARAMETRO_SeqFaturamentoBlue)));

                    SQLParametros.Add(new ParameterQuey("NumeroPedidoForca", SqlDbType.Int, false, Convert.ToInt32(NumeroPedidoForca)));
                    SQLParametros.Add(new ParameterQuey("NumeroPedidoCliente", SqlDbType.Int, false, Convert.ToInt32(NumeroPedidoCliente)));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalSeq", SqlDbType.Int, false, Convert.ToInt32(NotaFiscalSeq)));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalNumero", SqlDbType.Int, false, Convert.ToInt32(NotaFiscalNumero)));


                    SQLParametros.Add(new ParameterQuey("CdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(CdProdutoBlueSoft)));
                    SQLParametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(PedidoCdProdutoBlueSoft)));
                    SQLParametros.Add(new ParameterQuey("EmbalagemEstoque", SqlDbType.VarChar, false, Convert.ToString(EmbalagemEstoque)));
                    SQLParametros.Add(new ParameterQuey("EmbalagemCompra", SqlDbType.VarChar, false, Convert.ToString(EmbalagemCompra)));
                    SQLParametros.Add(new ParameterQuey("EmbalagemEstoqueQtde", SqlDbType.Decimal, false, Convert.ToDouble(EmbalagemEstoqueQtde)));
                    SQLParametros.Add(new ParameterQuey("EmbalagemCompraQtde", SqlDbType.Decimal, false, Convert.ToDouble(EmbalagemCompraQtde)));


                    SQLParametros.Add(new ParameterQuey("BlueSoftEmbalagemVendaFator", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftEmbalagemVendaFator)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftEmbalagemCompraCdProduto", SqlDbType.Int, false, Convert.ToInt32(BlueSoftEmbalagemCompraCdProduto)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftEmbalagemCompraFator", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftEmbalagemCompraFator)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftValorCustoMedio", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftValorCustoMedio)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftPrecoAplicado", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftPrecoAplicado)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftPrecoTabela", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftPrecoTabela)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftPrecoFinal", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftPrecoFinal)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftVolume", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftVolume)));
                    SQLParametros.Add(new ParameterQuey("BlueSoftVolumeFaturado", SqlDbType.Decimal, false, Convert.ToDouble(BlueSoftVolumeFaturado)));					





                    SQLParametros.Add(new ParameterQuey("ValorCustoPadraoUnitario", SqlDbType.Decimal, false, Convert.ToDouble(ValorCustoPadraoUnitario)));
                    SQLParametros.Add(new ParameterQuey("ValorFaturamentoBase", SqlDbType.Decimal, false, Convert.ToDouble(ValorFaturamentoBase)));
                    SQLParametros.Add(new ParameterQuey("ValorSubsidiosCorrentes", SqlDbType.Decimal, false, Convert.ToDouble(ValorSubsidiosCorrentes)));
                    SQLParametros.Add(new ParameterQuey("ValorFaturamento", SqlDbType.Decimal, false, Convert.ToDouble(ValorFaturamento)));
                    SQLParametros.Add(new ParameterQuey("PercentualDescontoFinanceiro", SqlDbType.Decimal, false, Convert.ToDouble(PercentualDescontoFinanceiro)));
                    SQLParametros.Add(new ParameterQuey("ValorSubsidioAplicado", SqlDbType.Decimal, false, Convert.ToDouble(ValorSubsidioAplicado)));



                    SQLParametros.Add(new ParameterQuey("ValorCustoPadrao", SqlDbType.Decimal, false, Convert.ToDouble(ValorCustoPadrao)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalFaturamentoBase", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalFaturamentoBase)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalSubsidiosCorrentes", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalSubsidiosCorrentes)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalFaturamento", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalFaturamento)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalDescontosFinanceiros", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalDescontosFinanceiros)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalFaturamentoBruto", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalFaturamentoBruto)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalSubsidiosAplicado", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalSubsidiosAplicado)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalFaturamentoLiquido", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalFaturamentoLiquido)));

                  
                    return SQLParametros;
                }
                catch (Exception ex)
                {
                    throw new Exception("Pag_Net.CO03.Models | Número do Pedido em PROCESSAMENTO: " + LinhaEmExecucao + Environment.NewLine + "Erro: " + ex.Message);
                }

            }
        
        
        }



        public string RedShiftDbSelectItems()
        {
            string SQL = "SELECT      " +
                         "       pd.Numero_Pedido_Forca_Venda                                    as NumeroPedidoForca   " +
                         " ,     pd.Pedido_forca_venda_cliente_key                               as NumeroPedidoCliente   " +
                         " ,     isnull(pd.nf_key,0)                                             as NotaFiscalSeq " +
                         " ,     isnull(nf.nf_numero,0)                                          as NotaFiscalNumero " +
                         " ,     pu.produto_unitario_key                                         as CdProdutoBlueSoft  " +
                         " ,     pd.produto_key                                                  as PedidoCdProdutoBlueSoft  " +
                         " ,     pu.fator_estoque                                                as BlueSoftEmbalagemVendaFator " + 
                         " ,     isnull(cx.produto_key,0)                                        as BlueSoftEmbalagemCompraCdProduto " + 
                         " ,     isnull(cx.fator_estoque, 1)                                     as BlueSoftEmbalagemCompraFator "  + 
                         " ,     isnull(pd.custo_medio,0)                                        as BlueSoftValorCustoMedio " + 
                         " ,     isnull(pd.preco_aplicado,0)                                     as BlueSoftPrecoAplicado " + 
                         " ,     isnull(pd.preco_tabela,0)                                       as BlueSoftPrecoTabela  " + 
                         " ,     isnull(pd.preco_final,0)                                        as BlueSoftPrecoFinal " + 
                         " ,     isnull(pd.volume,0)                                             as BlueSoftVolume " + 
                         " ,     isnull(pd.volume_faturado,0)                                    as BlueSoftVolumeFaturado " + 

                         " ,     isnull(pr.embalagem_key,'UN')                                   as EmbalagemEstoque  " +
                         " ,     isnull(cx.embalagem_key,ISNULL(pu.embalagem_key,'UN'))          as EmbalagemCompra  " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0  " +
                         "            THEN cast (pd.volume_faturado * ISNULL(pu.fator_estoque,1) as numeric(17,4))   " +
                         "            else cast (pd.volume * ISNULL(pu.fator_estoque,1) as numeric(17,4))    " +
                         "            END As EmbalagemEstoqueQtde   " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0    " +
                         "            THEN cast (pd.volume_faturado * ISNULL(pu.fator_estoque,1) / ISNULL(cx.fator_estoque,1) as numeric(17,4))   " +
                         "            else cast (pd.volume * ISNULL(pu.fator_estoque,1) / isnull(cx.fator_estoque,1) as numeric(17,4))    " +
                         "            END As EmbalagemCompraQtde  " +

                         " ,     es.custo_unitario_com_icm                                       as ValorCustoPadraoUnitario   " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0    " +
                         "            THEN cast (pd.volume_faturado * pd.preco_aplicado / (pd.volume * ISNULL(pu.fator_estoque,1))    as numeric(17,4) )   " +
                         "            else cast (pd.volume * pd.preco_aplicado / (pd.volume * ISNULL(pu.fator_estoque,1))             as numeric(17,4) )    " +
                         "       END As ValorFaturamentoBase  " +



                         " ,     cast(0 as numeric(13,2))  as ValorSubsidiosCorrentes " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0   " +
                         "            THEN cast (pd.volume_faturado * pd.preco_final / (pd.volume * ISNULL(pu.fator_estoque,1))       as numeric(17,4))   " +
                         "            else cast (pd.volume * pd.preco_final / (pd.volume * ISNULL(pu.fator_estoque,1))                as numeric(17,4))    " +
                         "       END As ValorFaturamento  " +


                         " ,     isnull(pd.desconto_financeiro,0) as PercentualDescontoFinanceiro " +


                         " ,     cast(0 as numeric(17,2)) as ValorSubsidioAplicado " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0    " +
                         "            THEN cast (isnull(pd.custo_medio, es.custo_unitario_com_icm * pu.fator_estoque) * pd.volume_faturado      as numeric(17,4) )   " +
                         "            else cast (isnull(pd.custo_medio, es.custo_unitario_com_icm * pu.fator_estoque) * pd.volume               as numeric(17,4) )    " +
                         "            END As ValorCustoPadrao  " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0    " +
                         "            THEN cast (pd.volume_faturado * pd.preco_aplicado as numeric(17,4))   " +
                         "            else cast (pd.volume * pd.preco_aplicado as numeric(17,4))    " +
                         "            END As ValorTotalFaturamentoBase  " +


                         " ,     cast(isnull(pd.valor_unitario_verba_vend,0) as numeric(17,2)) as ValorTotalSubsidiosCorrentes " +


                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0   " +
                         "            THEN cast (pd.volume_faturado * pd.preco_final as numeric(17,4))   " +
                         "            else cast (pd.volume * pd.preco_final as numeric(17,4))    " +
                         "            END As ValorTotalFaturamento  " +

                         " ,     CASE WHEN isnull(pd.Volume_faturado,0) > 0    " +
                         "            THEN cast (pd.volume_faturado * pd.preco_final * (isnull(pd.desconto_financeiro,0) / 100) as numeric(17,4))   " +
                         "            else cast (pd.volume * pd.preco_final * (isnull(pd.desconto_financeiro,0) / 100) as numeric(17,4))    " +
                         "            END As ValorTotalDescontosFinanceiros  " +

                         " ,     cast(0 as numeric(13,2)) as ValorTotalFaturamentoBruto " +

                         " ,     cast(0 as numeric(13,2)) as ValorTotalSubsidiosAplicado   " +

                         " ,     cast(0 as numeric(13,2)) as ValorTotalFaturamentoLiquido  " +

                         " FROM          FATO_PEDIDO_FORCA_VENDA pd  " +
                         " INNER JOIN    PRODUTO_D               pu on pu.produto_key = pd.produto_key " +
                         " INNER JOIN    PRODUTO_D               pr on pr.produto_key = pu.produto_unitario_key " + 
                         " LEFT  JOIN    NOTA_FISCAL             nf on nf.nf_key = pd.nf_key    " +
                         " LEFT  JOIN    FORNECEDOR_PRODUTO      fx on fx.fornecedor_produto_key = pr.fornecedor_produto_padrao_key   " +
                         " LEFT JOIN     PRODUTO_D               cx on cx.produto_key = fx.produto_key   " +

                         " INNER JOIN    ESTOQUE_DIARIO          es on es.produto_key = pu.produto_unitario_key and es.data = pd.data_emissao   " +
                         "   WHERE       1 = 1  " +
                         "     AND       pd.loja_key = 1  " +
                         "     AND       pd.data_emissao >= '" + PARAMETRO_DataInicial.ToString("yyyy-MM-dd") + "'" +
                         "     AND       pd.data_emissao <= '" + PARAMETRO_DataFinal.ToString("yyyy-MM-dd") + "'" +
                         //"     and       pd.pedido_forca_venda_cliente_key = 33793 " + 
                         "     and       isnull(pd.volume,0) > 0   ";


                         
            return SQL;  
        }

    }
}

