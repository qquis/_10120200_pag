using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
//using Pag_Net.F0021;



namespace Pag_Net.CO03.Models
{
    public class FaturamentoBlueHeader
    {
        public string SQLSP
        {
            get
            {
                return "SPC03FaturamentoBlueHeader";
            }
        }
        public enum Reports
        {
            Header
        }


        public int FiltroDePesquisa_NumeroPedidoForca { get; set; }
        public int FiltroDePesquisa_NumeroPedidoCliente { get; set; }
        public int FiltroDePesquisa_NotaFiscalSeq { get; set; }
        public DateTime FiltroDataPedidoInicial { get; set; }
        public DateTime FiltroDataPedidoFinal { get; set; }

        public int NumeroPedidoForca { get; set; }
        public int NumeroPedidoCliente { get; set; }
        public int NotaFiscalSeq { get; set; }
        public int NotaFiscalNumero { get; set; }
        public int TabelaPrecoSeq { get; set; }
        public int TabelaPrecoVersao { get; set; }
        public string PedidoOrigem { get; set; }
        public string PedidoStatus { get; set; }
        public int ClienteSeq { get; set; }
        public int VendedorSeq { get; set; }
        public string PrazoPagamento { get; set; }
        public string TipoPedidoVenda { get; set; }
        public DateTime PedidoEmissao { get; set; }
        public DateTime NotaFiscalEmissao { get; set; }
        public Double Valor { get; set; }
        public Double ValorFaturado { get; set; }
        public Double ValorTotalNotaFiscalMercadorias { get; set; }
        public Double ValorTotalNotaFiscalFrete { get; set; }
        public Double ValorTotalNotaFiscal { get; set; }


        public FaturamentoBlueHeader(System.Data.DataRow i)
        {
            string errorString = i["NumeroPedidoForca"].ToString();
            try
            {

                //FiltroDePesquisa_NumeroPedidoForca = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoForca"]);
                //FiltroDePesquisa_NumeroPedidoCliente = Convert.ToInt32(i["FiltroDePesquisa_NumeroPedidoCliente"]);
                //FiltroDePesquisa_NotaFiscalSeq = Convert.ToInt32(i["FiltroDePesquisa_NotaFiscalSeq"]);
                NumeroPedidoForca = Convert.ToInt32(i["NumeroPedidoForca"]);
                NumeroPedidoCliente = Convert.ToInt32(i["NumeroPedidoCliente"]);
                NotaFiscalSeq = Convert.ToInt32(i["NotaFiscalSeq"]);
                NotaFiscalNumero = Convert.ToInt32(i["NotaFiscalNumero"]);
                TabelaPrecoSeq = Convert.ToInt32(i["TabelaPrecoSeq"]);
                TabelaPrecoVersao = Convert.ToInt32(i["TabelaPrecoVersao"]);
                PedidoOrigem = i["PedidoOrigem"].ToString();
                PedidoStatus = i["PedidoStatus"].ToString();
                ClienteSeq = Convert.ToInt32(i["ClienteSeq"]);
                VendedorSeq = Convert.ToInt32(i["VendedorSeq"]);
                PrazoPagamento = i["PrazoPagamento"].ToString();
                PedidoEmissao = Convert.ToDateTime(i["PedidoEmissao"]);
                NotaFiscalEmissao = Convert.ToDateTime(i["NotaFiscalEmissao"]);
                Valor = Convert.ToDouble(i["Valor"]);
                ValorFaturado = Convert.ToDouble(i["ValorFaturado"]);
                ValorTotalNotaFiscalMercadorias = Convert.ToDouble(i["ValorTotalNotaFiscalMercadorias"]);
                ValorTotalNotaFiscalFrete = Convert.ToDouble(i["ValorTotalNotaFiscalFrete"]);
                ValorTotalNotaFiscal = Convert.ToDouble(i["ValorTotalNotaFiscal"]);
                TipoPedidoVenda = Convert.ToString(i["TipoPedidoVenda"]);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }



        }


        public FaturamentoBlueHeader(DateTime filtroDataPedidoInicial, DateTime filtroDataPedidoFinal)
        {
            FiltroDataPedidoInicial = filtroDataPedidoInicial;
            FiltroDataPedidoFinal = filtroDataPedidoFinal;

        }


        public List<ParameterQuey> SqlServer_SPC03FaturamentoBlueHeader_DBINSERT
        {

            get
            {
                string LinhaEmExecucao = "Pedido do Pedido: " + NumeroPedidoForca.ToString();
                try
                {

                    List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                    SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, "DBINSERT"));
                    SQLParametros.Add(new ParameterQuey("FiltroDePesquisa_NumeroPedidoForca", SqlDbType.Int, false, Convert.ToInt32(FiltroDePesquisa_NumeroPedidoForca)));
                    SQLParametros.Add(new ParameterQuey("FiltroDePesquisa_NumeroPedidoCliente", SqlDbType.Int, false, Convert.ToInt32(FiltroDePesquisa_NumeroPedidoCliente)));
                    SQLParametros.Add(new ParameterQuey("FiltroDePesquisa_NotaFiscalSeq", SqlDbType.Int, false, Convert.ToInt32(FiltroDePesquisa_NotaFiscalSeq)));
                    SQLParametros.Add(new ParameterQuey("NumeroPedidoForca", SqlDbType.Int, false, Convert.ToInt32(NumeroPedidoForca)));
                    SQLParametros.Add(new ParameterQuey("NumeroPedidoCliente", SqlDbType.Int, false, Convert.ToInt32(NumeroPedidoCliente)));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalSeq", SqlDbType.Int, false, Convert.ToInt32(NotaFiscalSeq)));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalNumero", SqlDbType.Int, false, Convert.ToInt32(NotaFiscalNumero)));
                    SQLParametros.Add(new ParameterQuey("TabelaPrecoSeq", SqlDbType.Int, false, Convert.ToInt32(TabelaPrecoSeq)));
                    SQLParametros.Add(new ParameterQuey("TabelaPrecoVersao", SqlDbType.Int, false, Convert.ToInt32(TabelaPrecoVersao)));
                    SQLParametros.Add(new ParameterQuey("PedidoOrigem", SqlDbType.VarChar, false, Convert.ToString(PedidoOrigem)));
                    SQLParametros.Add(new ParameterQuey("PedidoStatus", SqlDbType.VarChar, false, Convert.ToString(PedidoStatus)));
                    SQLParametros.Add(new ParameterQuey("TipoPedidoVenda", SqlDbType.VarChar, false, Convert.ToString(TipoPedidoVenda)));
                    SQLParametros.Add(new ParameterQuey("ClienteSeq", SqlDbType.Int, false, Convert.ToInt32(ClienteSeq)));
                    SQLParametros.Add(new ParameterQuey("VendedorSeq", SqlDbType.Int, false, Convert.ToInt32(VendedorSeq)));
                    SQLParametros.Add(new ParameterQuey("PrazoPagamento", SqlDbType.VarChar, false, Convert.ToString(PrazoPagamento)));
                    SQLParametros.Add(new ParameterQuey("PedidoEmissao", SqlDbType.SmallDateTime, false, PedidoEmissao));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalEmissao", SqlDbType.SmallDateTime, false, NotaFiscalEmissao));
                    SQLParametros.Add(new ParameterQuey("Valor", SqlDbType.Decimal, false, Valor));
                    SQLParametros.Add(new ParameterQuey("ValorFaturado", SqlDbType.Decimal, false, ValorFaturado));
                    SQLParametros.Add(new ParameterQuey("ValorTotalNotaFiscalMercadorias", SqlDbType.Decimal, false, ValorTotalNotaFiscalMercadorias));
                    SQLParametros.Add(new ParameterQuey("ValorTotalNotaFiscalFrete", SqlDbType.Decimal, false, ValorTotalNotaFiscalFrete));
                    SQLParametros.Add(new ParameterQuey("ValorTotalNotaFiscal", SqlDbType.Decimal, false, ValorTotalNotaFiscal));
                    return SQLParametros;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " | " + LinhaEmExecucao);
                }

            }


        }



        public string RedShiftDbSelectHeader()
        {
            string SQL = "SELECT                pd.Numero_Pedido_Forca_Venda                                    as NumeroPedidoForca " +
                         "                ,     pd.Pedido_forca_venda_cliente_key                               as NumeroPedidoCliente " +
                         "                ,     isnull(pd.nf_key,0)                                             as NotaFiscalSeq " +
                         "                ,     isnull(nf.nf_numero,0)                                          as NotaFiscalNumero " +
                         "                ,     pd.tabela_preco_venda_key                                       as TabelaPrecoSeq " +
                         "                ,     pd.tabela_preco_venda_versao                                    as TabelaPrecoVersao " +
                         "                ,     pd.Origem_Pedido                                                as PedidoOrigem " +
                         "                ,     pd.status_pedido                                                as PedidoStatus " +
                         "                ,     pd.cliente_key                                                  as ClienteSeq " +
                         "                ,     pd.vendedor_key                                                 as VendedorSeq  " +
                         "                ,     pd.prazo_pagamento                                              as PrazoPagamento  " +
                         "                ,     pd.data_emissao                                                 as PedidoEmissao  " +
                         "                ,     isnull(pd.data_Faturamento, pd.data_emissao)                    as NotaFiscalEmissao " +
                         "                ,     isnull(pd.tipo_pedido_venda, 'Venda')                           as TipoPedidoVenda " +
                         "                ,     SUM(cast(pd.volume * pd.preco_final as numeric(13,2)))          as Valor " +
                         "                ,     SUM(cast(pd.volume_faturado * pd.preco_final as numeric(13,2))) as ValorFaturado  " +
                         "                ,     ISNULL(nt.valor_total_mercadorias, 0)                           as ValorTotalNotaFiscalMercadorias " +
                         "                ,     ISNULL(nt.valor_total_frete, 0)                                 as ValorTotalNotaFiscalFrete         " +
                         "                ,     ISNULL(nt.valor_total_nota, 0)                                  as ValorTotalNotaFiscal         " +
                         "        FROM          FATO_PEDIDO_FORCA_VENDA pd " +
                         "        LEFT JOIN     NOTA_FISCAL             nf on nf.nf_key = pd.nf_key  " +
                         "        LEFT JOIN     NOTA_FISCAL_TOTAL       nt on nt.nf_key = nf.nf_key  " +
                         "        WHERE         1 = 1 " +
                         "          AND         pd.loja_key = 1" +
                         "          AND         pd.data_emissao >= '" + FiltroDataPedidoInicial.ToString("yyyy-MM-dd") + "'" +
                         "          AND         pd.data_emissao <= '" + FiltroDataPedidoFinal.ToString("yyyy-MM-dd") + "'" +
                         "          AND         isnull(pd.volume,0) > 0 " +
                //"                  and       pd.pedido_forca_venda_cliente_key = 33793 " + 
                         "        group by            pd.Numero_Pedido_Forca_Venda   " +
                         "                      ,     pd.Pedido_forca_venda_cliente_key " +
                         "                      ,     isnull(pd.nf_key,0) " +
                         "                      ,     isnull(nf.nf_numero,0) " +
                         "                      ,     pd.tabela_preco_venda_key " +
                         "                      ,     pd.tabela_preco_venda_versao " +
                         "                      ,     pd.Origem_Pedido " +
                         "                      ,     pd.status_pedido " +
                         "                      ,     pd.cliente_key " +
                         "                      ,     pd.vendedor_key " +
                         "                      ,     pd.prazo_pagamento " +
                         "                      ,     ISNULL(nt.valor_total_mercadorias, 0) " +
                         "                      ,     ISNULL(nt.valor_total_frete, 0) " +
                         "                      ,     ISNULL(nt.valor_total_nota, 0) " +
                         "                      ,     pd.data_emissao " +
                         "                      ,     isnull(pd.data_Faturamento, pd.data_emissao) " +
                         "                      ,     isnull(pd.tipo_pedido_venda, 'Venda') " +
                         "        order by      pd.Numero_Pedido_Forca_Venda, pd.Pedido_forca_venda_cliente_key, isnull(pd.nf_key,0), isnull(nf.nf_numero,0) asc ";
            return SQL;
        }

    }
}


namespace Pag_Net.CO03.Models
{


    public class FaturamentoBlueSoft
    {
        public string SQLSP
        {
            get
            {
                return "SPC0030FaturamentoBlueSoft";
            }
        }
        public enum Reports
        {
            Header,
            RegistrosFaturados,
            RegistrosEmAberto

        }

        public DateTime PDataNofaFiscal_Inicial { get; set; }
        public DateTime PDataNofaFiscal_Final { get; set; }
        public int PNumeroNotaFiscal { get; set; }

        public int CdEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int NumeroPedidoBlueSoft { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int NumeroNotaFiscalDevolucao { get; set; }
        public int PedidoCdProdutoBlueSoft { get; set; }
        public int SeqItem { get; set; }
        public int PedidoCdProdutoBlueSoftUnitario { get; set; }
        public int NotaFiscalCdProdutoBlueSoft { get; set; }

        public DateTime DataPedido { get; set; }
        public DateTime DataNotaFiscal { get; set; }

        public string PedidoStatus { get; set; }
        public string PedidoPrazoPagamento { get; set; }
        public string PedidoClienteCPFCNPJ { get; set; }
        public string PedidoVendedorCPFCNPJ { get; set; }
        public string PedidoProdutoDescricao { get; set; }
        public string PedidoTipoEmbalagem { get; set; }
        public string TipoVenda { get; set; }
        public string PedidoCdProdutoBlueSoftCodigoBarra { get; set; }
        public string TransportadoraDescricao { get; set; }
        public string TransportadoraPlacaVeiculo { get; set; }

        public double PedidoVolumeFaturado { get; set; }
        public double PedidoProdutoUnitarioFator { get; set; }
        public double VolumeUnitarioCalculado { get; set; }
        public double ValorCustoUnitario { get; set; }
        public double ValorNotaFiscal { get; set; }
        public double DescontoFinanceiro { get; set; }
        public double PedidoValorVerba { get; set; }
        public double PedidoPercentualComissao { get; set; }
        public double ValorPrecoVendaCustoFinanceiro { get; set; }
        public double ValorPrecoTabela { get; set; }
        public double ValorTotalNotaFiscalItem { get; set; }
        public double ValorVerbaCalculadaTotalItem { get; set; }

        public FaturamentoBlueSoft(DateTime pDataNotaFiscal_Inicial, DateTime pDataNotaFiscal_Final)
        {
            this.PDataNofaFiscal_Inicial = pDataNotaFiscal_Inicial;
            this.PDataNofaFiscal_Final = pDataNotaFiscal_Final;

        }

        public FaturamentoBlueSoft(DateTime pDataNotaFiscal_Inicial, DateTime pDataNotaFiscal_Final, int pNumeroNotaFiscal)
        {
            this.PDataNofaFiscal_Inicial = pDataNotaFiscal_Inicial;
            this.PDataNofaFiscal_Final = pDataNotaFiscal_Final;
            this.PNumeroNotaFiscal = pNumeroNotaFiscal;
        }

        public FaturamentoBlueSoft(System.Data.DataRow i)
        {

            string errorString = "Número do Pedido: " + i["NumeroPedidoBlueSoft"].ToString() + " Item: " + i["PedidoCdProdutoBlueSoft"].ToString();
            try
            {


                PDataNofaFiscal_Inicial = Convert.ToDateTime(i["DataNotaFiscal"]);
                PDataNofaFiscal_Final = Convert.ToDateTime(i["DataNotaFiscal"]);
                PNumeroNotaFiscal = 0;

                CdEmpresa = Convert.ToInt32(i["CdEmpresa"]);
                CdOperacao = Convert.ToInt32(i["CdOperacao"]);
                NumeroPedidoBlueSoft = Convert.ToInt32(i["NumeroPedidoBlueSoft"]);
                NumeroNotaFiscal = Convert.ToInt32(i["NumeroNotaFiscal"]);
                PedidoCdProdutoBlueSoft = Convert.ToInt32(i["PedidoCdProdutoBlueSoft"]);
                SeqItem = 1;
                PedidoCdProdutoBlueSoftUnitario = Convert.ToInt32(i["PedidoCdProdutoBlueSoftUnitario"]);
                NotaFiscalCdProdutoBlueSoft = Convert.ToInt32(i["NotaFiscalCdProdutoBlueSoft"]);
                NumeroNotaFiscalDevolucao = Convert.ToInt32(i["NumeroNotaFiscalDevolucao"]);
                DataPedido = Convert.ToDateTime(i["DataPedido"]);
                DataNotaFiscal = Convert.ToDateTime(i["DataNotaFiscal"]);

                PedidoStatus = i["PedidoStatus"].ToString();
                PedidoPrazoPagamento = i["PedidoPrazoPagamento"].ToString();
                PedidoVendedorCPFCNPJ = i["PedidoVendedorCPFCNPJ"].ToString();
                PedidoClienteCPFCNPJ = i["PedidoClienteCPFCNPJ"].ToString();
                PedidoProdutoDescricao = i["PedidoProdutoDescricao"].ToString();
                PedidoTipoEmbalagem = i["PedidoTipoEmbalagem"].ToString();
                TipoVenda = i["TipoVenda"].ToString();
                PedidoCdProdutoBlueSoftCodigoBarra = i["PedidoCdProdutoBlueSoftCodigoBarra"].ToString();
                TransportadoraDescricao = i["TransportadoraDescricao"].ToString();
                TransportadoraPlacaVeiculo = i["TransportadoraPlacaVeiculo"].ToString();

                PedidoVolumeFaturado = Convert.ToDouble(i["PedidoVolumeFaturado"]);
                PedidoProdutoUnitarioFator = Convert.ToDouble(i["PedidoProdutoUnitarioFator"]);
                VolumeUnitarioCalculado = Convert.ToDouble(i["VolumeUnitarioCalculado"]);
                ValorCustoUnitario = Convert.ToDouble(i["ValorCustoUnitario"]);
                ValorNotaFiscal = Convert.ToDouble(i["ValorNotaFiscal"]);
                DescontoFinanceiro = Convert.ToDouble(i["DescontoFinanceiro"]);
                PedidoValorVerba = Convert.ToDouble(i["PedidoValorVerba"]);
                PedidoPercentualComissao = Convert.ToDouble(i["PedidoPercentualComissao"]);
                ValorPrecoVendaCustoFinanceiro = Convert.ToDouble(i["ValorPrecoVendaCustoFinanceiro"]);
                ValorPrecoTabela = Convert.ToDouble(i["ValorPrecoTabela"]);
                ValorTotalNotaFiscalItem = Convert.ToDouble(i["ValorTotalNotaFiscalItem"]);
                ValorVerbaCalculadaTotalItem = Convert.ToDouble(i["ValorVerbaCalculadaTotalItem"]);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }



        }

        public string RSTSPCO003000_RegistrosFaturados
        {
            get
            {
                string
                rSTSPCO003000 = "            SELECT      Convert(int,1)                                As cdempresa " +
                                "                    ,   Convert(int,1)                                as cdoperacao  " +
                                "                    ,   pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft " +
                                "                    ,   nf.NF_NUMERO                                  AS NumeroNotaFiscal " +
                                "                    ,   ISNULL(dv.NF_NUMERO,0)                        AS NumeroNotaFiscalDevolucao " +
                                "                    ,   pd.data_emissao                               as DataPedido " +
                                "                    ,   pd.data_faturamento                           AS DataNotaFiscal " +
                                "                    ,   pd.status_pedido                              As PedidoStatus " +
                                "                    ,   pd.prazo_pagamento                            As PedidoPrazoPagamento " +
                                "                    ,   pd.vendedor_key                               As VendedorKey " +
                                "                    ,   ps.cpf_cnpj                                   As PedidoVendedorCPFCNPJ " +
                                "                    ,   ps.nome_razao                                 AS VENDEDOR " +
                                "                    ,   nf.nf_numero                                  AS NOTA " +
                                "                    ,   cl.nome_razao                                 AS CLIENTE " +
                                "                    ,   cl.cpf_cnpj                                   AS PedidoClienteCPFCNPJ " +
                                "                    ,   pd.produto_key                                AS PedidoCdProdutoBlueSoft " +
                                "                    ,   pf.produto_origem_key                         AS NotaFiscalCdProdutoBlueSoft " +
                                "                    ,   pd.produto                                    AS PedidoProdutoDescricao " +
                                "                    ,   pd.volume_faturado                            AS PedidoVolumeFaturado " +
                                "                    ,   pr.produto_unitario_key                       As PedidoCdProdutoBlueSoftUnitario " +
                                "                    ,   pr.fator_estoque                              as PedidoProdutoUnitarioFator " +
                                "                    ,   (pd.volume_faturado * pr.fator_estoque )      as VolumeUnitarioCalculado " +
                                "                    ,   ct.CUSTO_UNITARIO_COM_ICM                     as ValorCustoUnitario " +
                                "                    ,   pf.ni_valor_bruto                             AS ValorNotaFiscal  " +
                                "                    ,   isnull(pd.desconto_financeiro,0)              as DescontoFinanceiro  " +
                                "                    ,   isnull(pd.valor_unitario_verba_vend,0)        as PedidoValorVerba  " +
                                "                    ,   isnull(pd.perc_est_comissao_vendedor,0)       as PedidoPercentualComissao " +
                                "                    ,   pd.preco_aplicado                             as ValorPrecoVendaCustoFinanceiro " +
                                "                    ,   pd.preco_tabela                               as ValorPrecoTabela  " +
                                "                    ,   pd.embalagem                                  as PedidoTipoEmbalagem " +
                                "                    ,   CASE " +
                                "                           WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                "                           WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                "                           WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                "                        END AS TipoVenda  " +
                                "                    ,   CONVERT(NUMERIC(17,4), pf.ni_valor_bruto_TOTAL - pf.NI_DESCONTO_TOTAL) as ValorTotalNotaFiscalItem " +
                                "                    ,   case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                "                    ,   case when pd.embalagem = 'UNIDADE' " +
                                "                             THEN " +
                                "                                  CONVERT(NUMERIC(13,2), (pf.ni_valor_bruto - pd.preco_aplicado ) * pd.volume_faturado) " +
                                "                             else  " +
                                "                                  CONVERT(NUMERIC(13,2), ( ((pf.ni_valor_bruto/pr.fator_estoque) - pd.preco_aplicado) * pr.fator_estoque ) * pd.volume_faturado) " +
                                "                             end                                      AS ValorVerbaCalculadaTotalItem  " +
                                "                    ,    CB.BARRA_KEY                                 as PedidoCdProdutoBlueSoftCodigoBarra " +
                                 "                   ,  isnull(fr.nome_transportadora,'')              As TransportadoraDescricao " +
                                 "                   ,  isnull(fr.placa_veiculo,'')                    As TransportadoraPlacaVeiculo " +
                                "                    FROM        fato_pedido_forca_venda pd " +
                                "                    left  join  produto_d          pr on pr.produto_key = pd.produto_key  " +
                    //"                    left  join  produto_d          pn on pn.produto_key = pr.produto_unitario_key " +
                                "                    LEFT  JOIN  fornecedor_produto fp ON fp.fornecedor_produto_key = pr.produto_unitario_key " +
                                "                    LEFT  JOIN  produto_d          cx ON cx.produto_key = fp.produto_key " +
                                "                    inner join  pessoa             ps on ps.pessoa_key = pd.vendedor_key " +
                                "                    inner join  nota_fiscal        nf on nf.nf_key = pd.nf_key and nf.loja_key = pd.loja_key  " +
                                "                    left  join  nota_fiscal        dv on dv.numero_documento_origem = nf.nf_numero and dv.loja_key = nf.loja_key" +
                                "                    left join   fato_nota_fiscal_frete fr on fr.nf_key = nf.nf_key and fr.loja_key = nf.loja_key and fr.nf_numero = nf.nf_numero " +
                                "                    left  join  fato_nota_fiscal   pf on pf.nf_key = nf.nf_key and pf.produto_origem_key = pd.produto_key and pf.loja_key = nf.loja_key " +
                                "                    left  join  produto_d          pe on pe.produto_key = pf.produto_origem_key  " +
                                "                    left  join  pessoa             cl on cl.pessoa_key = pd.cliente_key " +
                                "                    LEFT JOIN   ESTOQUE_DIARIO     ct on ct.produto_key = pr.produto_unitario_key and ct.data = pd.data_Faturamento " +
                                "                    LEFT JOIN   (SELECT      X.PRODUTO_KEY AS PRODUTO_KEY" +
                                "                                         ,   X.TIPO_CODIGO AS TIPO_CODIGO " +
                                "                                         ,   X.BARRA_KEY   AS BARRA_KEY " +
                                "                                 FROM        ITEM          X " +
                                "                                 INNER JOIN  ( SELECT      PRODUTO_KEY   AS PRODUTO_KEY " +
                                "                                                       ,   MAX(ITEM_KEY) AS ITEM_KEY " +
                                "                                               FROM        ITEM " +
                                "                                               WHERE       PRODUTO_KEY " +
                                "                                               GROUP BY    PRODUTO_KEY " +
                                "                                              ) A ON A.PRODUTO_KEY = X.PRODUTO_KEY AND X.ITEM_KEY = A.ITEM_KEY " +
                                "                                ) CB ON CB.PRODUTO_KEY = pd.produto_key " +
                                "                    where       pd.data_faturamento >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
                                "                    and         pd.data_faturamento <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
                                "                    and         pd.status_pedido in ('Entregue', 'Faturado por Nota Fiscal') " +
                                "                    and         nf.loja_key = 1";


                if (PNumeroNotaFiscal > 0)
                {
                    rSTSPCO003000 += "and         nf.NF_NUMERO = " + PNumeroNotaFiscal.ToString();
                }

                rSTSPCO003000 += "          union " +
                                      "          select     Convert(int,3)                                  as  cdempresa " +
                                      "                   , Convert(int,6)                                  as  cdoperacao  " +
                                      "                   ,  n.nf_numero                                    as  NumeroPedidoBlueSOft  " +
                                      "                   ,  n.nf_numero                                    as  NumeroNotaFiscal  " +
                                      "                   ,  ISNULL(dv.NF_NUMERO,0)                         as  NumeroNotaFiscalDevolucao " +
                                      "                   ,  n.data_emissao                                 as  DataPedido  " +
                                      "                   ,  n.data_emissao                                 as  DataNotaFiscal  " +
                                      "                   ,  'Faturado por Nota Fiscal'                     as  PedidoStatus  " +
                                      "                   ,  'A VISTA'                                      as  pedidoprazopagamento  " +
                                      "                   ,  0                                              as  vendedorkey " +
                                      "                   ,  21814585885                                    as  pedidovendedorcpfcnpj " +
                                      "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                                      "                   ,  n.nf_numero                                    as  NOTA  " +
                                      "                   ,  cl.nome_razao                                  as  CLIENTE " +
                                      "                   ,  cl.cpf_cnpj                                    AS  PedidoClienteCPFCNPJ " +
                                      "                   ,  n.produto_key                                  AS  PedidoCdProdutoBlueSoft " +
                                      "                   ,  n.produto_key                                  AS  NotaFiscalCdProdutoBlueSoft " +
                                      "                   ,  pr.descricao                                   AS  PedidoProdutoDescricao " +
                                      "                   ,  n.quantidade_faturada                          as  PedidoVolumeFaturado " +
                                      "                   ,  n.produto_key                                  as  PedidoCdProdutoBlueSoftUnitario " +
                                      "                   ,  1                                              as  PedidoProdutoUnitarioFator " +
                                      "                   ,  n.quantidade_faturada                          as  VolumeUnitarioCalculado " +
                                      "                   ,  n.ni_valor_bruto                               as  ValorCustoUnitario " +
                                      "                   ,  n.ni_valor_bruto                               AS  ValorNotaFiscal " +
                                      "                   ,  0                                              as  DescontoFinanceiro " +
                                      "                   ,  0                                              as  PedidoValorVerba " +
                                      "                   ,  0                                              as  PedidoPercentualComissao " +
                                      "                   ,  n.ni_valor_bruto                               as  ValorPrecoVendaCustoFinanceiro " +
                                      "                   ,  0                                              as  ValorPrecoTabela " +
                                      "                   ,  pr.embalagem_key                               as  PedidoTipoEmbalagem  " +
                                      "                   ,  CASE  " +
                                      "                         WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'  " +
                                      "                         WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'  " +
                                      "                         WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'   " +
                                      "                      END AS TipoVenda  " +
                                      "                   ,  CONVERT(NUMERIC(17,4), n.ni_valor_bruto_TOTAL - n.NI_DESCONTO_TOTAL) as ValorTotalNotaFiscalItem " +
                                      "                   ,  case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                      "                   ,  convert(numeric(13,2), 0)                      AS ValorVerbaCalculadaTotalItem  " +
                                      "                   ,  '0'                                            AS PedidoCdProdutoBlueSoftCodigoBarra " +
                                      "                   ,  isnull(fr.nome_transportadora,'')              As TransportadoraDescricao " +
                                      "                   ,  isnull(fr.placa_veiculo,'')                    As TransportadoraPlacaVeiculo " +
                                      "          from        fato_nota_fiscal                   n  " +
                                      "          inner join  nota_fiscal                        nf on nf.nf_key = n.nf_key and nf.loja_key = n.loja_key " +
                                      "          left  join  nota_fiscal                        dv on dv.numero_documento_origem = nf.nf_numero and dv.loja_key = nf.loja_key" +
                                      "          left  join  fato_nota_fiscal_frete             fr on fr.nf_key = nf.nf_key and fr.loja_key = nf.loja_key and fr.nf_numero = nf.nf_numero " +
                                      "          inner join  pessoa                             cl on cl.pessoa_key = nf.fornecedor_key  " +
                                      "          inner join  produto_d                          pr on pr.produto_key = n.produto_key  " +
                                      "          where       nf.data_emissao >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
                                      "          and         nf.data_emissao <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
                                      "          and         n.loja_key = 991  " +
                                      "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405')  " +
                                      "          and         n.nf_tipo_descricao = 'Nota fiscal de venda a cliente por pedido'  ";


                if (PNumeroNotaFiscal > 0)
                {
                    rSTSPCO003000 += "and         n.nf_numero = " + PNumeroNotaFiscal.ToString();
                }


                rSTSPCO003000 += "          union " +


                                      "  select     Convert(int,1)                                                      as  cdempresa " +
                                      "          ,  Convert(int,1)                                                      as  cdoperacao " +
                                      "          ,  n.nf_numero                                                         as  NumeroPedidoBlueSOft " +
                                      "          ,  n.nf_numero                                                         as  NumeroNotaFiscal " +
                                      "          ,  ISNULL(dv.NF_NUMERO,0)                                              as  NumeroNotaFiscalDevolucao " +
                                      "          ,  n.data_emissao                                                      as  DataPedido " +
                                      "          ,  n.data_emissao                                                      as  DataNotaFiscal " +
                                      "          ,  'Faturado por Nota Fiscal'                                          as  PedidoStatus " +
                                      "          ,  '28 DIAS'                                                           as  pedidoprazopagamento " +
                                      "          ,  0                                                                   as  vendedorkey " +
                                      "          ,  21814585885                                                         as  pedidovendedorcpfcnpj " +
                                      "          ,  'ELIAS DA SILVA'                                                    as  vendedor " +
                                      "          ,  n.nf_numero                                                         as  NOTA " +
                                      "          ,  cl.nome_razao                                                       as  CLIENTE " +
                                      "          ,  cl.cpf_cnpj                                                         AS  PedidoClienteCPFCNPJ " +
                                      "          ,  n.produto_key                                                       AS  PedidoCdProdutoBlueSoft " +
                                      "          ,  n.produto_key                                                       AS  NotaFiscalCdProdutoBlueSoft " +
                                      "          ,  pr.descricao                                                        AS  PedidoProdutoDescricao " +
                                      "          ,  n.quantidade_faturada                                               as  PedidoVolumeFaturado " +
                                      "          ,  PR.produto_unitario_key                                             as  PedidoCdProdutoBlueSoftUnitario " +
                                      "          ,  pr.fator_estoque                                                    as  PedidoProdutoUnitarioFator " +
                                      "          ,  n.quantidade_faturada * pr.fator_estoque                            as  VolumeUnitarioCalculado " +
                                      "          ,  isnull(ct.CUSTO_UNITARIO_COM_ICM, n.ni_valor_bruto)                 as  ValorCustoUnitario " +
                                      "          ,  (n.ni_valor_bruto)                                                  AS  ValorNotaFiscal " +
                                      "          ,  0                                                                   as  DescontoFinanceiro " +
                                      "          ,  0                                                                   as  PedidoValorVerba " +
                                      "          ,  0                                                                   as  PedidoPercentualComissao  " +
                                      "          ,  n.ni_valor_bruto                                                    as  ValorPrecoVendaCustoFinanceiro " +
                                      "          ,  0                                                                   as  ValorPrecoTabela " +
                                      "          ,  pr.embalagem_key                                                    as  PedidoTipoEmbalagem " +
                                      "          ,  CASE " +
                                      "             WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '6102' THEN 'VENDA' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '6108' THEN 'VENDA' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '6910' THEN 'BONIFICACAO' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                      "             WHEN nf.codigo_operacao_fiscal = '6405' THEN 'VENDA' " +
                                      "          END                                                        AS TipoVenda " +
                                      "          ,  CONVERT(NUMERIC(17,4), n.ni_valor_bruto_TOTAL - n.NI_DESCONTO_TOTAL) as ValorTotalNotaFiscalItem " +
                                      "          ,  case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                      "          ,  convert(numeric(13,2), 0)                      AS ValorVerbaCalculadaTotalItem " +
                                      "          ,  '0'                                            AS PedidoCdProdutoBlueSoftCodigoBarra " +
                                      "          ,  isnull(fr.nome_transportadora,'')              As TransportadoraDescricao " +
                                      "          ,  isnull(fr.placa_veiculo,'')                    As TransportadoraPlacaVeiculo " +
                                      "          from        fato_nota_fiscal n " +
                                      "          inner join  nota_fiscal                            nf on nf.nf_key = n.nf_key and nf.loja_key = n.loja_key  " +
                                      "          left  join  nota_fiscal                            dv on dv.numero_documento_origem = nf.nf_numero and dv.loja_key = nf.loja_key" +
                                      "          left join   fato_nota_fiscal_frete                 fr on fr.nf_key = nf.nf_key and fr.loja_key = nf.loja_key and fr.nf_numero = nf.nf_numero  " +
                                      "          inner join  pessoa                                 cl on cl.pessoa_key = nf.fornecedor_key " +
                                      "          inner join  cliente_grupo_economico                GP on gp.cliente_key = cl.pessoa_key  " +
                                      "          INNER JOIN  GRUPO_ECONOMICO                        GE ON GE.GRUPO_ECONOMICO_KEY = GP.GRUPO_ECONOMICO_KEY           " +
                                      "          inner join  produto_d                              pr on pr.produto_key = n.produto_origem_key   " +
                                      "          LEFT JOIN   ESTOQUE_DIARIO                         ct on ct.produto_key = pr.produto_unitario_key and ct.data = n.data_emissao " +
                                      "          where       1 = 1  " +
                                      "          AND         nf.data_emissao >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
                                      "          and         nf.data_emissao <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
                                      "          and         n.loja_key = 1  " +
                                      "          and         n.nf_key not in ( select nf_key from fato_pedido_forca_venda where data_faturamento >= '20200301' group by nf_key  )  " +
                                      "          and         ge.descricao like '%5ASEC%' " +
                                      "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405', '6102','6910','6405', '6108')   " +
                                      "          and         n.nf_tipo_descricao IN ( 'Nota fiscal de venda a cliente por pedido', 'Nota fiscal de venda a cliente')  ";

                if (PNumeroNotaFiscal > 0)
                {
                    rSTSPCO003000 += "and         nf.NF_NUMERO = " + PNumeroNotaFiscal.ToString();
                }

                return rSTSPCO003000;

            }


        }

        public string RSTSPCO003000_RegistrosEmAbertos
        {
            get
            {
                string
                rSTSPCO003000 = "             SELECT    Convert(int,1)                                As cdempresa " +
                                 "                  ,   Convert(int,1)                                as cdoperacao " +
                                 "                  ,   pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft " +
                                 "                  ,   0                                             AS NumeroNotaFiscal  " +
                                 "                  ,   0                                             AS NumeroNotaFiscalDevolucao " +
                                 "                  ,   isnull(pd.data_emissao,'19990101')            as DataPedido  " +
                                 "                  ,   isnull(pd.data_emissao,'19990101')            AS DataNotaFiscal " +
                                 "                  ,   isnull(pd.status_pedido, 'Cancelado')         As PedidoStatus  " +
                                 "                  ,   isnull(pd.prazo_pagamento, '7 DIAS.')         As PedidoPrazoPagamento" +
                                 "                  ,   isnull(pd.vendedor_key,1)                     As VendedorKey" +
                                 "                  ,   isnull(ps.cpf_cnpj,'21814585885')             As PedidoVendedorCPFCNPJ " +
                                 "                  ,   isnull(ps.nome_razao, 'ERRO')                 AS VENDEDOR " +
                                 "                  ,   0                                             AS NOTA  " +
                                 "                  ,   isnull(cl.nome_razao, 'ERRO')                 AS CLIENTE  " +
                                 "                  ,   isnull(cl.cpf_cnpj, '21814585885')            AS PedidoClienteCPFCNPJ " +
                                 "                  ,   isnull(pd.produto_key,1)                      AS PedidoCdProdutoBlueSoft  " +
                                 "                  ,   pd.produto_key                                AS NotaFiscalCdProdutoBlueSoft  " +
                                 "                  ,   pd.produto                                    AS PedidoProdutoDescricao " +
                                 "                  ,   pd.volume                                     AS PedidoVolumeFaturado " +
                                 "                  ,   pr.produto_unitario_key                       As PedidoCdProdutoBlueSoftUnitario  " +
                                 "                  ,   pr.fator_estoque                              as PedidoProdutoUnitarioFator " +
                                 "                  ,   (pd.volume * pr.fator_estoque )               as VolumeUnitarioCalculado  " +
                                 "                  ,   ct.CUSTO_UNITARIO_COM_ICM                     as ValorCustoUnitario " +
                                 "                  ,   pd.preco_final                                AS ValorNotaFiscal" +
                                 "                  ,   isnull(pd.desconto_financeiro,0)              as DescontoFinanceiro " +
                                 "                  ,   isnull(pd.valor_unitario_verba_vend,0)        as PedidoValorVerba   " +
                                 "                  ,   isnull(pd.perc_est_comissao_vendedor,0)       as PedidoPercentualComissao " +
                                 "                  ,   isnull(pd.preco_aplicado,0)                   as ValorPrecoVendaCustoFinanceiro " +
                                 "                  ,   isnull(pd.preco_tabela,0)                     as ValorPrecoTabela " +
                                 "                  ,   pd.embalagem                                  as PedidoTipoEmbalagem  " +
                                 "                  ,   CASE  " +
                                 "                         WHEN pd.tipo_pedido_venda = 'Venda' THEN 'VENDA'" +
                                 "                         WHEN pd.tipo_pedido_venda = 'Doação ou Bonificação' THEN 'BONIFICACAO' " +
                                 "                         ELSE 'VENDA' " +
                                "                       END AS TipoVenda   " +
                                "                   ,   CONVERT(NUMERIC(17,4), pd.preco_final * PD.VOLUME) as ValorTotalNotaFiscalItem" +
                                "                   ,   CASE WHEN PD.STATUS_PEDIDO = 'Cancelado' then 1 else 0 end statusnotacancelamento " +
                                "                   ,   case when pd.embalagem = 'UNIDADE' " +
                                "                            THEN  " +
                                "                                 CONVERT(NUMERIC(13,2), (pd.preco_final - pd.preco_aplicado ) * pd.volume_faturado) " +
                                "                            else   " +
                                "                                 CONVERT(NUMERIC(13,2), ( ((pd.preco_final - pd.preco_aplicado) / pr.fator_estoque ) * pd.volume))  " +
                                "                            end                                      AS ValorVerbaCalculadaTotalItem" +
                                "                   ,    isnull(CB.BARRA_KEY,0)                       as PedidoCdProdutoBlueSoftCodigoBarra  " +
                                "                   ,   'NÃO DEFINIDO'                                As TransportadoraDescricao  " +
                                "                   ,   'NÃO DEFINIDO'                                As TransportadoraPlacaVeiculo " +
                                "               FROM        fato_pedido_forca_venda pd " +
                                "               left  join  produto_d          pr on pr.produto_key = pd.produto_key   " +
                                "               LEFT  JOIN  fornecedor_produto fp ON fp.fornecedor_produto_key = pr.produto_unitario_key  " +
                                "               LEFT  JOIN  produto_d          cx ON cx.produto_key = fp.produto_key " +
                                "               inner join  pessoa             ps on ps.pessoa_key = pd.vendedor_key  " +
                                "               left  join  produto_d          pe on pe.produto_key = pd.produto_key " +
                                "               left  join  pessoa             cl on cl.pessoa_key = pd.cliente_key  " +
                                "               LEFT JOIN   ESTOQUE_DIARIO     ct on ct.produto_key = pr.produto_unitario_key  and ct.data = pd.data_emissao  " +
                                "               LEFT JOIN   (SELECT      X.PRODUTO_KEY AS PRODUTO_KEY " +
                                "                                    ,   X.TIPO_CODIGO AS TIPO_CODIGO  " +
                                "                                    ,   X.BARRA_KEY   AS BARRA_KEY  " +
                                "                            FROM        ITEM          X  " +
                                "                            INNER JOIN  ( SELECT      PRODUTO_KEY   AS PRODUTO_KEY  " +
                                "                                                  ,   MAX(ITEM_KEY) AS ITEM_KEY  " +
                                "                                          FROM        ITEM  " +
                                "                                          WHERE       PRODUTO_KEY  " +
                                "                                          GROUP BY    PRODUTO_KEY  " +
                                "                                         ) A ON A.PRODUTO_KEY = X.PRODUTO_KEY AND X.ITEM_KEY = A.ITEM_KEY  " +
                                "                           ) CB ON CB.PRODUTO_KEY = pd.produto_key  " +
                                "               where       1 = 1 " +
                                "               and         pd.data_emissao >= '2020-06-01' " +
                                "               and         pd.data_emissao <= '2020-07-30' " +
                                "               and         pd.status_pedido NOT in ('Em Digitação', 'Faturado por Nota Fiscal', 'Entregue')   " +
                                "               and         pd.loja_key = 1";

                return rSTSPCO003000;

            }
        }

        public string RSTSPCO003001_Header
        {
            get
            {
                string SqlRedSHIFT = "           select        Convert(int,1)                                as cdempresa " +
                                      "                    ,   Convert(int,1)                                as cdoperacao  " +
                                      "                    ,   pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft " +
                                      "                    ,   nf.NF_NUMERO                                  AS NumeroNotaFiscal " +
                                      "                    ,   ISNULL(dv.NF_NUMERO,0)                        AS NumeroNotaFiscalDevolucao " +
                                      "                    ,   pd.data_emissao                               as DataPedido " +
                                      "                    ,   pd.data_faturamento                           AS DataNotaFiscal " +
                                      "                    ,   pd.status_pedido                              As PedidoStatus " +
                                      "                    ,   pd.prazo_pagamento                            As PedidoPrazoPagamento " +
                                      "                    ,   pd.vendedor_key                               As VendedorKey " +
                                      "                    ,   ps.cpf_cnpj                                   As PedidoVendedorCPFCNPJ " +
                                      "                    ,   ps.nome_razao                                 AS VENDEDOR " +
                                      "                    ,   cl.nome_razao                                 AS CLIENTE " +
                                      "                    ,   cl.cpf_cnpj                                   AS PedidoClienteCPFCNPJ " +
                                      "                    ,   CASE " +
                                      "                           WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                      "                           WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                      "                           WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                      "                        END AS TipoVenda         " +
                                      "                    ,   case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                      "                    ,   convert(int, 1)                               AS OrigemNotaFiscalBlueSoft " +
             "                    FROM        fato_pedido_forca_venda pd " +
             "                    left  join  produto_d          pr on pr.produto_key = pd.produto_key  " +
             "                    left  join  produto_d          pn on pn.produto_key = pr.produto_unitario_key " +
             "                    LEFT JOIN   fornecedor_produto fp ON fp.fornecedor_produto_key = pn.fornecedor_produto_padrao_key " +
             "                    LEFT JOIN   produto_d          cx ON cx.produto_key = fp.produto_key " +
             "                    inner join  pessoa             ps on ps.pessoa_key = pd.vendedor_key " +
             "                    inner join  nota_fiscal        nf on nf.nf_key = pd.nf_key and nf.loja_key = pd.loja_key " +
             "                    left  join  nota_fiscal        dv on dv.numero_documento_origem = nf.nf_numero and dv.loja_key = nf.loja_key " +
             "                    left  join  fato_nota_fiscal   pf on pf.nf_key = nf.nf_key and pf.loja_key = nf.loja_key and pf.produto_origem_key = pd.produto_key  " +
             "                    left  join  produto_d          pe on pe.produto_key = pf.produto_origem_key  " +
             "                    left  join  pessoa             cl on cl.pessoa_key = pd.cliente_key " +
             "                    LEFT JOIN   ESTOQUE_DIARIO     ct on ct.produto_key = pn.produto_key and ct.data = pd.data_Faturamento " +
             "                    where       pd.data_faturamento >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
             "                    and         pd.data_faturamento <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
             "                    GROUP BY         pd.pedido_forca_venda_cliente_key" +
             "                                 ,   nf.NF_NUMERO " +
             "                                 ,   dv.NF_NUMERO " +
             "                                 ,   pd.data_emissao " +
             "                                 ,   pd.data_faturamento " +
             "                                 ,   pd.status_pedido " +
             "                                 ,   pd.prazo_pagamento " +
             "                                 ,   pd.vendedor_key " +
             "                                 ,   ps.cpf_cnpj " +
             "                                 ,   ps.nome_razao " +
             "                                 ,   cl.nome_razao " +
             "                                 ,   cl.cpf_cnpj " +
             "                    ,   CASE " +
             "                           WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
             "                           WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
             "                           WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
             "                        END " +
             "                    ,   case when nf.data_cancelamento is null then 0 else 1 end ";

                SqlRedSHIFT += "          union " +
                          "          select      Convert(int,3)                                 as  cdempresa " +
                          "                   ,  Convert(int,6)                                 as  cdoperacao  " +
                          "                   ,  n.nf_numero                                    as  NumeroPedidoBlueSOft  " +
                          "                   ,  n.nf_numero                                    as  NumeroNotaFiscal  " +
                          "                   ,  0                                              as  NumeroNotaFiscalDevolucao " +
                          "                   ,  n.data_emissao                                 as  DataPedido  " +
                          "                   ,  n.data_emissao                                 as  DataNotaFiscal  " +
                          "                   ,  'Faturado por Nota Fiscal'                     as  PedidoStatus  " +
                          "                   ,  'A VISTA'                                      as  pedidoprazopagamento  " +
                          "                   ,  0                                              as  vendedorkey " +
                          "                   ,  21814585885                                    as  pedidovendedorcpfcnpj " +
                          "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                          "                   ,  cl.nome_razao                                  as  CLIENTE " +
                          "                   ,  cl.cpf_cnpj                                    AS  PedidoClienteCPFCNPJ " +
                          "                   ,  CASE  " +
                          "                        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'  " +
                          "                        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'  " +
                          "                        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'   " +
                          "                      END AS TipoVenda  " +
                          "                   ,  case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                          "                    ,   convert(int, 1)                               AS OrigemNotaFiscalBlueSoft " +
                          "          from        fato_nota_fiscal n  " +
                          "          inner join  nota_fiscal      nf on nf.nf_key = n.nf_key  and n.loja_key = nf.loja_key " +
                          "          inner join  pessoa           cl on cl.pessoa_key = nf.fornecedor_key  " +
                          "          inner join  produto_d        pr on pr.produto_key = n.produto_key  " +
                          "          where       nf.data_emissao >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
                          "          and         nf.data_emissao <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
                          "          and         n.loja_key = 991  " +
                          "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405')  " +
                          "          and         n.nf_tipo_descricao = 'Nota fiscal de venda a cliente por pedido'  " +
                          "          group by        n.nf_key " +
                          "                       ,  n.nf_numero " +
                          "                       ,  n.data_emissao " +
                          "                       ,  n.data_emissao " +
                          "                       ,  cl.nome_razao " +
                          "                       ,  cl.cpf_cnpj " +
                          "                       ,  CASE " +
                          "                            WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                          "                            WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                          "                            WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                          "                          END " +
                          "                       , case when nf.data_cancelamento is null then 0 else 1 end ";



                SqlRedSHIFT += "          union " +

                                        "          select      Convert(int,1)                                 as  cdempresa " +
                                        "                   ,  Convert(int,1)                                 as  cdoperacao " +
                                        "                   ,  n.nf_numero                                    as  NumeroPedidoBlueSOft " +
                                        "                   ,  n.nf_numero                                    as  NumeroNotaFiscal " +
                                        "                   ,  0                                              as  NumeroNotaFiscalDevolucao " +
                                        "                   ,  n.data_emissao                                 as  DataPedido " +
                                        "                   ,  n.data_emissao                                 as  DataNotaFiscal " +
                                        "                   ,  'Faturado por Nota Fiscal'                     as  PedidoStatus " +
                                        "                   ,  '28 DIAS'                                      as  pedidoprazopagamento " +
                                        "                   ,  0                                              as  vendedorkey " +
                                        "                   ,  21814585885                                    as  pedidovendedorcpfcnpj " +
                                        "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                                        "                   ,  cl.nome_razao                                  as  CLIENTE " +
                                        "                   ,  cl.cpf_cnpj                                    AS  PedidoClienteCPFCNPJ " +
                                        "                   ,  CASE " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '6102' THEN 'VENDA' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '6108' THEN 'VENDA' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '6910' THEN 'BONIFICACAO' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                        "                         WHEN nf.codigo_operacao_fiscal = '6405' THEN 'VENDA' " +
                                        "                      END AS TipoVenda " +
                                        "                   ,  case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                        "                   ,  convert(int, 1)                               AS OrigemNotaFiscalBlueSoft " +
                                        "          from        fato_nota_fiscal            n " +
                                        "          inner join  nota_fiscal                 nf on nf.nf_key = n.nf_key  and n.loja_key = nf.loja_key " +
                                        "          inner join  pessoa                      cl on cl.pessoa_key = nf.fornecedor_key " +
                                        "          inner join  cliente_grupo_economico     GP on gp.cliente_key = cl.pessoa_key " +
                                        "          INNER JOIN  GRUPO_ECONOMICO             GE ON GE.GRUPO_ECONOMICO_KEY = GP.GRUPO_ECONOMICO_KEY " +
                                        "          inner join  produto_d        pr on pr.produto_key = n.produto_key " +
                                        "          where       1 = 1  " +
                                        "          AND         nf.data_emissao >= '" + PDataNofaFiscal_Inicial.ToString("yyyy-MM-dd") + "'" +
                                        "          and         nf.data_emissao <= '" + PDataNofaFiscal_Final.ToString("yyyy-MM-dd") + "'" +
                                        "          and         n.loja_key = 1 " +
                                        "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405', '6102','6910','6405', '6108')  " +
                                        "          and         n.nf_tipo_descricao IN ( 'Nota fiscal de venda a cliente por pedido', 'Nota fiscal de venda a cliente') " +
                                        "          and         n.nf_key not in ( select nf_key from fato_pedido_forca_venda where data_faturamento >= '20200301' group by nf_key  ) " +
                                        "          and         ge.descricao like '%5ASEC%' " +
                                        "          group by        n.nf_key " +
                                        "                       ,  n.nf_numero " +
                                        "                       ,  n.data_emissao " +
                                        "                       ,  n.data_emissao " +
                                        "                       ,  cl.nome_razao " +
                                        "                       ,  cl.cpf_cnpj  " +
                                        "                       ,  CASE " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'  " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '6102' THEN 'VENDA'  " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '6108' THEN 'VENDA'   " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '6910' THEN 'BONIFICACAO' " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                        "                          WHEN nf.codigo_operacao_fiscal = '6405' THEN 'VENDA' " +
                                        "                          END  " +
                                        "                          ,  case when nf.data_cancelamento is null then 0 else 1 end ";
                return SqlRedSHIFT;
            }
        }

        public List<ParameterQuey> SQLSPC0030_DBInsert
        {

            get
            {
                string LinhaEmExecucao = "Pedido do Pedido: " + NumeroPedidoBlueSoft.ToString();
                try
                {


                    if (SeqItem == 0)
                    {
                        throw new Exception("Pag_Net.CO0030.Models.FaturamentoBlueSoft.SQLSPC0030_DBInsert: Valor Sequencial de Item SeqItem não definido");
                    }

                    List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                    DateTime dateSeqItem = Convert.ToDateTime(DataPedido.ToString());
                    SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, "DBINSERT"));


                    SQLParametros.Add(new ParameterQuey("CdEmpresa", SqlDbType.Int, false, Convert.ToInt32(CdEmpresa)));
                    SQLParametros.Add(new ParameterQuey("CdOperacao", SqlDbType.Int, false, Convert.ToInt32(CdOperacao)));
                    SQLParametros.Add(new ParameterQuey("NumeroPedidoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(NumeroPedidoBlueSoft)));
                    SQLParametros.Add(new ParameterQuey("NumeroNotaFiscal", SqlDbType.Int, false, Convert.ToInt32(NumeroNotaFiscal)));
                    SQLParametros.Add(new ParameterQuey("NumeroNotaFiscalDevolucao", SqlDbType.Int, false, Convert.ToInt32(NumeroNotaFiscalDevolucao)));
                    SQLParametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(PedidoCdProdutoBlueSoft)));
                    SQLParametros.Add(new ParameterQuey("NotaFiscalCdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(NotaFiscalCdProdutoBlueSoft)));
                    SQLParametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoftUnitario", SqlDbType.Int, false, Convert.ToInt32(PedidoCdProdutoBlueSoftUnitario)));
                    SQLParametros.Add(new ParameterQuey("SeqItem", SqlDbType.Int, false, SeqItem));

                    //Date Time Fields
                    SQLParametros.Add(new ParameterQuey("DataPedido", SqlDbType.SmallDateTime, false, Convert.ToDateTime(DataPedido)));
                    SQLParametros.Add(new ParameterQuey("DataNotaFiscal", SqlDbType.SmallDateTime, false, Convert.ToDateTime(DataNotaFiscal)));

                    //chars fields 
                    SQLParametros.Add(new ParameterQuey("PedidoStatus", SqlDbType.VarChar, false, PedidoStatus));
                    SQLParametros.Add(new ParameterQuey("PedidoPrazoPagamento", SqlDbType.VarChar, false, PedidoPrazoPagamento));
                    SQLParametros.Add(new ParameterQuey("PedidoVendedorCPFCNPJ", SqlDbType.VarChar, false, PedidoVendedorCPFCNPJ));
                    SQLParametros.Add(new ParameterQuey("PedidoClienteCPFCNPJ", SqlDbType.VarChar, false, PedidoClienteCPFCNPJ));
                    SQLParametros.Add(new ParameterQuey("PedidoProdutoDescricao", SqlDbType.VarChar, false, PedidoProdutoDescricao));
                    SQLParametros.Add(new ParameterQuey("PedidoTipoEmbalagem", SqlDbType.VarChar, false, PedidoTipoEmbalagem));
                    SQLParametros.Add(new ParameterQuey("TipoVenda", SqlDbType.VarChar, false, TipoVenda));
                    SQLParametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoftCodigoBarra", SqlDbType.VarChar, false, PedidoCdProdutoBlueSoftCodigoBarra));
                    SQLParametros.Add(new ParameterQuey("TransportadoraDescricao", SqlDbType.VarChar, false, TransportadoraDescricao));
                    SQLParametros.Add(new ParameterQuey("TransportadoraPlacaVeiculo", SqlDbType.VarChar, false, TransportadoraPlacaVeiculo));

                    //decimals fields
                    SQLParametros.Add(new ParameterQuey("PedidoVolumeFaturado", SqlDbType.Decimal, false, Convert.ToDouble(PedidoVolumeFaturado)));
                    SQLParametros.Add(new ParameterQuey("PedidoProdutoUnitarioFator", SqlDbType.Decimal, false, Convert.ToDouble(PedidoProdutoUnitarioFator)));
                    SQLParametros.Add(new ParameterQuey("VolumeUnitarioCalculado", SqlDbType.Decimal, false, Convert.ToDouble(VolumeUnitarioCalculado)));
                    SQLParametros.Add(new ParameterQuey("ValorCustoUnitario", SqlDbType.Decimal, false, Convert.ToDouble(ValorCustoUnitario)));
                    SQLParametros.Add(new ParameterQuey("ValorNotaFiscal", SqlDbType.Decimal, false, Convert.ToDouble(ValorNotaFiscal)));
                    SQLParametros.Add(new ParameterQuey("DescontoFinanceiro", SqlDbType.Decimal, false, Convert.ToDouble(DescontoFinanceiro)));
                    SQLParametros.Add(new ParameterQuey("PedidoValorVerba", SqlDbType.Decimal, false, Convert.ToDouble(PedidoValorVerba)));
                    SQLParametros.Add(new ParameterQuey("PedidoPercentualComissao", SqlDbType.Decimal, false, Convert.ToDouble(PedidoPercentualComissao)));
                    SQLParametros.Add(new ParameterQuey("ValorPrecoVendaCustoFinanceiro", SqlDbType.Decimal, false, Convert.ToDouble(ValorPrecoVendaCustoFinanceiro)));
                    SQLParametros.Add(new ParameterQuey("ValorPrecoTabela", SqlDbType.Decimal, false, Convert.ToDouble(ValorPrecoTabela)));
                    SQLParametros.Add(new ParameterQuey("ValorTotalNotaFiscalItem", SqlDbType.Decimal, false, Convert.ToDouble(ValorTotalNotaFiscalItem)));
                    SQLParametros.Add(new ParameterQuey("ValorVerbaCalculadaTotalItem", SqlDbType.Decimal, false, Convert.ToDouble(ValorVerbaCalculadaTotalItem)));
                    return SQLParametros;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + " | " + LinhaEmExecucao);
                }

            }


        }


    }
}


namespace Pag_Net.Models
{
    public class SPR0080RLComissao
    {
        public int _SPParameterCdProdutoBlueSoft { get; set; }
        public string _SPParameterDescricao { get; set; }


        public int CdPessoa { get; set; }
        public string NomePessoa { get; set; }



        public SPR0080RLComissao() { }
        public SPR0080RLComissao(DataRow i)
        {
            CdPessoa = Convert.ToInt32(i["CdPessoa"].ToString());
            NomePessoa = i["NomePessoa"].ToString();

            //if (Convert.ToInt32(i["StatusProduto"]) == 1) { StatusProduto = true; } else { StatusProduto = false; }
            //if (Convert.ToInt32(i["VendaExterna"]) == 1) { VendaExterna = true; } else { VendaExterna = false; }
        }

    }
}



namespace Pag_Net.Models
{
    public class SPR0050ServicesTimes
    {
        public string _SPParameterServiceOwner { get; set; }


        public string serviceid { get; set; }
        public string servicetimeid { get; set; }
        public string DateIni { get; set; }
        public string DateFim { get; set; }
        public string hour { get; set; }
        public string minute { get; set; }
        public string Second { get; set; }
        public string WeekDay { get; set; }


        public SPR0050ServicesTimes(string _sPParameterServiceOwner)
        {
            this._SPParameterServiceOwner = _sPParameterServiceOwner;

        }


        public SPR0050ServicesTimes(string serviceid,
                                        string servicetimeid,
                                        string dateIni,
                                        string dateFin,
                                        string hor,
                                        string min,
                                        string second,
                                        string weekday)
        {
            this._SPParameterServiceOwner = "";
            this.serviceid = serviceid.ToString();
            this.servicetimeid = servicetimeid.ToString();
            this.DateIni = dateIni.ToString();
            this.DateFim = dateFin.ToString();
            this.hour = hor.ToString();
            this.minute = min.ToString();
            this.Second = second.ToString();
            this.WeekDay = weekday.ToString();
        }


        public SPR0050ServicesTimes(DataRow i)
        {
            try
            {
                this.serviceid = i["serviceid"].ToString();
                this.servicetimeid = i["servicetimeid"].ToString();
                this.DateIni = i["DateIni"].ToString();
                this.DateFim = i["datefim"].ToString();
                this.hour = i["hour"].ToString();
                this.minute = i["minute"].ToString();
                this.Second = i["Second"].ToString();
                this.WeekDay = i["WeekDay"].ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Models.SPR0050ServicesTimes: " + ex.Message);
            }
        }

    }
}


namespace Pag_Net.Models
{
    public class ModelMarketingCli_AE
    {
        public string Name { get; set; }
        public string Fone_code { get; set; }
        public string Fone_number { get; set; }
        public string Zip_code { get; set; }
        public string Sex { get; set; }
        public string StatusMaritalDescription { get; set; }
        public string E_mail { get; set; }
        public string RemarkTypeDescription { get; set; }
        public string Remark { get; set; }

        public ModelMarketingCli_AE() { }
        public ModelMarketingCli_AE(string Name,
                            string Fone_code,
                            string Fone_number,
                            string Zip_code,
                            string Sex,
                            string StatusMaritalDescription,
                            string E_mail,
                            string RemarkTypeDescription,
                            string Remark)
        {
            this.Name = Name;
            this.Fone_code = Fone_code;
            this.Fone_number = Fone_number;
            this.Zip_code = Zip_code;
            this.Sex = Sex;
            this.StatusMaritalDescription = StatusMaritalDescription;
            this.E_mail = E_mail;
            this.RemarkTypeDescription = RemarkTypeDescription;
            this.Remark = Remark;
        }


    }





    /* _____________Modelos agregados ________________________________*/
    public class ModelTbPedidosEletronicosEmAberto
    {
        public TbPedidos[] ArrayListPedidos { get; set; }
        public TbItens[] ArrayListItens { get; set; }

    }





    /* Tabelas Basicas */

    public abstract class mdoVWProduto
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemEstoque { get; set; }
        public string EmbalagemCompra { get; set; }
        public double EmbalagemCompraQtdeUnitaria { get; set; }
        public bool StatusProduto { get; set; }
        public string CdFabricante { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
    }

    public abstract class mdoVwRegistroProduto
    {

        public int CdEmpresa { get; set; }
        public int SeqRegistroProduto { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataLancamento { get; set; }
        public int SeqTipoRegistro { get; set; }
        public int CdProduto { get; set; }
        public string EmbalagemEstoque { get; set; }
        public Double EmbalagemEstoqueQtde { get; set; }
        public double ValorCustoPadrao { get; set; }
        public int SequencialERP { get; set; }

    }




    /* MVC / NET */

    public class TbRecebimento
    {
        public int SeqRecebimentoItem { get; set; }
        public int CdParticipante { get; set; }
        public int FornecedorKey { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJCPF { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public string CFOP { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int CdProduto { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public string Descricao { get; set; }
        public string EmbalagemCompra { get; set; }
        public double ValorCusto { get; set; }
        public double ValorCustoTotal { get; set; }
        public double FatorEstoque { get; set; }
        public double EmbalagemCompraQtde { get; set; }
        public double EmbalagemEstoqueQtde { get; set; }
        public double EmbalagemEstoqueQtde_Devolvida { get; set; }
        public double ValorBaseST { get; set; }
        public double ValorST { get; set; }
        public double EmbalagemEstoqueValorCusto { get; set; }
        public double NumeroAPS { get; set; }
        public DateTime DataVencimentoMaximo { get; set; }
        public DateTime DataVencimentoMinimo { get; set; }
        public DateTime DataLogInclusao { get; set; }





    }








    public class TbCodigoBarra
    {
        public int CdProdutoBlueSoft { get; set; }

        private string codigobarra;
        public string CodigoBarra
        {
            get
            {
                return codigobarra;
            }
            set
            {
                string X = value;
                int lenth = 21 - X.Length;
                string complemento = "";
                for (int i = 1; i <= lenth; i++)
                {
                    complemento = complemento + "0";
                }
                complemento = complemento + value;
                codigobarra = complemento;
                //codigobarra = value;
            }
        }

        public string Embalagem { get; set; }
        public string EmbalagemDescricao { get; set; }
        public string Tipo { get; set; }


    }
    public class TbProduto
    {
        public int CdProduto { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public string StatusDescricao { get; set; }

    }


}

namespace Pag_Net.Models
{
    public class SPC0015TbProdutoBlueSoft
    {
        public int _SPParameterCdProdutoBlueSoft { get; set; }
        public string _SPParameterDescricao { get; set; }


        public int CdProduto { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public int CdProdutoBlueSoftUnitario { get; set; }
        public int CdProdutoBlueSoftControleEstoque { get; set; }
        public int CdProdutoBlueSoftControlePreco { get; set; }
        public int DepartamentoKey { get; set; }
        public int SecaoKey { get; set; }
        public int GrupoKey { get; set; }
        public int SubGrupoKey { get; set; }
        public int FabricanteKey { get; set; }

        public string CodigoBarraReferencia { get; set; }
        public string Descricao { get; set; }

        public string EmbalagemEstoque { get; set; }
        public string EmbalagemCompra { get; set; }

        public double EmbalagemCompraQtdeUnitaria { get; set; }
        public double FatorEstoque { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool StatusProduto { get; set; }
        public bool VendaExterna { get; set; }

        public SPC0015TbProdutoBlueSoft() { }
        public SPC0015TbProdutoBlueSoft(DataRow i)
        {
            CdProduto = Convert.ToInt32(i["CdProduto"].ToString());
            CdProdutoBlueSoft = Convert.ToInt32(i["CdProdutoBlueSoft"].ToString());
            CdProdutoBlueSoftUnitario = Convert.ToInt32(i["CdProdutoBlueSoftUnitario"].ToString());
            CdProdutoBlueSoftControleEstoque = Convert.ToInt32(i["CdProdutoBlueSoftControleEstoque"].ToString());
            CdProdutoBlueSoftControlePreco = Convert.ToInt32(i["CdProdutoBlueSoftControlePreco"].ToString());
            DepartamentoKey = Convert.ToInt32(i["DepartamentoKey"]);
            SecaoKey = Convert.ToInt32(i["SecaoKey"]);
            GrupoKey = Convert.ToInt32(i["GrupoKey"]);
            SubGrupoKey = Convert.ToInt32(i["SubGrupoKey"]);
            FabricanteKey = Convert.ToInt32(i["FabricanteKey"]);

            CodigoBarraReferencia = i["CodigoBarraReferencia"].ToString();
            Descricao = i["Descricao"].ToString();

            DataCadastro = Convert.ToDateTime(i["DataCadastro"]);
            DataUltimaAlteracao = Convert.ToDateTime(i["DataUltimaAlteracao"]);

            EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
            EmbalagemCompra = i["EmbalagemCompra"].ToString();

            DataUltimaAlteracao = Convert.ToDateTime(i["DataUltimaAlteracao"]);
            DataCadastro = Convert.ToDateTime(i["DataCadastro"]);


            EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["EmbalagemCompraQtdeUnitaria"]);
            FatorEstoque = Convert.ToDouble(i["FatorEstoque"]);

            if (Convert.ToInt32(i["StatusProduto"]) == 1) { StatusProduto = true; } else { StatusProduto = false; }
            if (Convert.ToInt32(i["VendaExterna"]) == 1) { VendaExterna = true; } else { VendaExterna = false; }

            FatorEstoque = Convert.ToDouble(i["FatorEstoque"]);

        }




    }
}

namespace Pag_Net.Models
{
    public class SP_Produto_Parametros
    {
        public string SQLCommnd { get; set; }
        public int F_CdProduto { get; set; }
        public string F_CdProdutoList { get; set; }
        public string F_CdProdutoBlueSoftList { get; set; }
        public string F_CdProdutoTargetList { get; set; }
        public string F_Descricao { get; set; }
        public string F_StatusProduto { get; set; }
        public string F_CodigoBarraAssociado { get; set; }

        public int SET_CdProduto { get; set; }
        public int SET_CdProdutoBlueSoft { get; set; }
        public string SET_Descricao { get; set; }
        public string SET_CodigoBarraReferencia { get; set; }
        public string SET_EmbalagemEstoque { get; set; }
        public string SET_EmbalagemCompra { get; set; }
        public double SET_EmbalagemCompraQtdeUnitaria { get; set; }
        public int SET_CdProdutoBlueSoftUnitario { get; set; }
        public double SET_FatorEstoque { get; set; }
        public int SET_CdProdutoBlueSoftControleEstoque { get; set; }
        public int SET_CdProdutoBlueSoftControlePreco { get; set; }
        public int SET_DepartamentoKey { get; set; }
        public string SET_DepartamentoDescricao { get; set; }
        public int SET_SecaoKey { get; set; }
        public string SET_SecaoDescricao { get; set; }
        public int SET_GrupoKey { get; set; }
        public string SET_GrupoDescricao { get; set; }
        public int SET_SubGrupoKey { get; set; }
        public string SET_SubGrupoDescricao { get; set; }
        public DateTime SET_DataUltimaAlteracao { get; set; }
        public DateTime SET_DataCadastro { get; set; }
        public int SET_FabricanteKey { get; set; }
        public bool SET_ProdutoStatus { get; set; }
        public string SET_CodigoBarra { get; set; }
        public string SET_Embalagem { get; set; }
        public string SET_EmbalagemDescricao { get; set; }
        public string SET_Tipo { get; set; }


        public int SET_CdOperacao { get; set; }
        public int SET_CdRegraFiscal { get; set; }
        public int SET_CdRegraFiscalVersao { get; set; }
        public string SET_RegimeTributario { get; set; }
        public string SET_CFOP { get; set; }



        public string SET_PIS_Entrada_CST { get; set; }

        public double SET_PIS_Entrada_Aliquota { get; set; }
        public string SET_PIS_Saida_CST { get; set; }
        public double SET_PIS_Saida_Aliquota { get; set; }
        public string SET_COFINS_Entrada_CST { get; set; }
        public double SET_COFINS_Entrada_Aliquota { get; set; }
        public string SET_COFINS_Saida_CST { get; set; }
        public double SET_COFINS_Saida_Aliquota { get; set; }
        public string SET_ICMS_Saida_CST { get; set; }
        public string SET_ICMS_Entrada_CST { get; set; }
        public double SET_ICMS_Aliquota_Interna { get; set; }
        public double SET_ICMS_Reducao { get; set; }
        public string SET_NCM { get; set; }
        public string SET_CEST { get; set; }
        public double SET_ST_IVA { get; set; }
        public string SET_Observacao_Fiscal { get; set; }
        public string SET_Dados_Adicionais { get; set; }


        public bool SET_VendaExterna { get; set; }

        public SP_Produto_Parametros() { }

    }
}

namespace Pag_Net.Models
{

    #region Codigos SPS
    public static class SPs
    {
        public static string SP_PRODUTO()
        {
            return "sp_Produto_11a";
        }

        public static string SP_PRODUTOPRECO()
        {
            return "SP_ProdutoPreco_k02";
        }

        public static string SPGetVersion(string SP)
        {
            string Version = SP;
            switch (SP)
            {
                case "SP_ProdutoBlueSoftComposicao":
                    Version = "SP_ProdutoBlueSoftComposicao";
                    break;
                default:
                    Version = SP;
                    break;
            }
            return Version;

        }
    }
    #endregion

    #region SP_ProdutoComplemento
    public class SP_ProdutoComplemento
    {
        public int SeqDepartamento { get; set; }
        public int SeqSecao { get; set; }
        public int SeqGrupo { get; set; }
        public int SeqSubGrupo { get; set; }

        public string DescricaoDepartamento { get; set; }
        public string DescricaoSecao { get; set; }
        public string DescricaoGrupo { get; set; }
        public string DescricaoSubGrupo { get; set; }

        public SP_ProdutoComplemento(string descricaoDepartamento, int seqDepartamento)
        {
            SeqDepartamento = seqDepartamento;
            DescricaoDepartamento = descricaoDepartamento;
        }
    }

    #endregion

    #region SP_Contrato
    public class SP_Contrato
    {

        public SP_Contrato()
        {
            SQLCommnd = "";

        }
        public SP_Contrato(string sQLCommand, DateTime f_DataInicio, DateTime f_dataFim)
        {
            F_DataInicio = f_DataInicio;
            F_DataFim = f_dataFim;
            SQLCommnd = sQLCommand;
        }
        public SP_Contrato(string sQLCommand, DateTime f_DataInicio, DateTime f_dataFim, int f_SeqContrato, int f_SeqTipoContrato)
        {
            F_DataInicio = f_DataInicio;
            F_DataFim = f_dataFim;
            F_SeqContrato = f_SeqContrato;
            F_SeqTipoContrato = f_SeqTipoContrato;
            SQLCommnd = sQLCommand;

        }
        public string SQLCommnd { get; set; }
        public DateTime F_DataInicio { get; set; }
        public DateTime F_DataFim { get; set; }
        public int F_SeqContrato { get; set; }
        public int F_SeqTipoContrato { get; set; }
        public SP_Contrato_TbContrato Contrato { get { return new SP_Contrato_TbContrato(); } }
        public SP_Contrato_TbContratoItem ContratoItem { get { return new SP_Contrato_TbContratoItem(); } }
    }
    public class SP_Contrato_TbContrato
    {
        public int SeqContrato { get; set; }
        public string Descricao { get; set; }

        private DateTime _DataLancamento = Convert.ToDateTime("1900-01-01");
        public DateTime DataLancamento
        {
            get
            {
                return _DataLancamento;
            }
            set
            {
                _DataLancamento = value;
            }

        }

        private DateTime _DataInicio = Convert.ToDateTime("1900-01-01");
        public DateTime DataInicio
        {
            get
            {
                return _DataInicio;
            }
            set
            {
                _DataInicio = value;
            }

        }

        private DateTime _DataFim = Convert.ToDateTime("1900-01-01");
        public DateTime DataFim
        {
            get
            {
                return _DataFim;
            }
            set
            {
                _DataFim = value; ;
            }
        }

        public string CdTipoContrato { get; set; }
        public int CdOperacao { get; set; }
        public int SeqTipoContrato { get; set; }
        public string Tipos_Descricao { get; set; }
        public int NumeroPedido { get; set; }
        public int NumeroNfe { get; set; }
        public int Nfe { get; set; }
        public string Observacao { get; set; }
        public string CdFabricante { get; set; }
        public double ValorNegociado { get; set; }
        public double ValorAplicado { get; set; }
        public int NumeroDocumentoFiscal { get; set; }
        public bool AplicacaoCusto { get; set; }
        public int CdParticipante { get; set; }
    }
    public class SP_Contrato_TbContratoItem
    {
        public int SeqContratoItem { get; set; }
        public int CdProduto { get; set; }
        public string Produto_Descricao { get; set; }
        public double ValorInvestimento { get; set; }
        public int SeqItem { get; set; }
        public int ValorInvestimentoTotal { get; set; }
        public double EmbalagemEstoqueQtdeNegociada { get; set; }
        public double EmbalagemEstoqueQtdeAplicada { get; set; }
        public string EmbalagemFaturamento { get; set; }
        public bool ValidarEmbalagem { get; set; }
        public double ValorNegociado { get; set; }
        public double ValorAplicado { get; set; }

    }
    #endregion

    #region SP_Produto

    public class SP_Produto_TbProduto
    {
        public int TbProduto_CdProduto { get; set; }
        public int TbProduto_CdProdutoBluesoft { get; set; }
        public string TbProduto_Descricao { get; set; }
        public string TbProduto_EmbalagemEstoque { get; set; }
        public int XCount_QtdeProdutosAssociados { get; set; }
        public string TbFabricante_Descricao { get; set; }
        public bool TbProduto_StatusProduto { get; set; }

    }
    public class SP_Produto_TbProdutoBlueSoft
    {



        public int CdProduto { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarraReferencia { get; set; }
        public string EmbalagemEstoque { get; set; }
        public string EmbalagemCompra { get; set; }
        public int CdProdutoBlueSoftUnitario { get; set; }
        public double FatorEstoque { get; set; }
        public double EmbalagemCompraQtdeUnitaria { get; set; }
        public int CdProdutoBlueSoftControleEstoque { get; set; }
        public int CdProdutoBlueSoftControlePreco { get; set; }
        public int DepartamentoKey { get; set; }
        public int SecaoKey { get; set; }
        public int GrupoKey { get; set; }
        public int SubGrupoKey { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int FabricanteKey { get; set; }
        public Boolean ProdutoStatus { get; set; }
        public Boolean PagStatusNovoProduto { get; set; }
        public Boolean PagStatusAtualizacaoPendente { get; set; }
        public Boolean VendaExterna { get; set; }
        public SP_Produto_TbProdutoBlueSoft() { }

        public SP_Produto_TbProdutoBlueSoft(int cdproduto,
                                    int cdprodutobluesoft,
                                    string descricao,
                                    string codigobarrareferencia,
                                    string embalagemestoque,
                                    int cdprodutobluesoftunitario,
                                    double fatorestoque,
                                    int cdprodutobluesoftcontroleestoque,
                                    int cdprodutobluesoftcontrolepreco,
                                    int departamentokey,
                                    int secaokey,
                                    int grupoprodutokey,
                                    int subgrupokey,
                                    DateTime dataultimaalteracao,
                                    DateTime datacadastro,
                                    int fabricantekey,
                                    Boolean produtostatus,
                                    Boolean pagstatusnovoproduto,
                                    Boolean pagstatusatualizacaopendente
                                )
        {
            this.CdProduto = cdproduto;
            this.CdProdutoBlueSoft = cdprodutobluesoft;
            this.Descricao = descricao;
            this.CodigoBarraReferencia = codigobarrareferencia;
            this.EmbalagemEstoque = embalagemestoque;
            this.CdProdutoBlueSoftUnitario = cdprodutobluesoftunitario;
            this.FatorEstoque = fatorestoque;
            this.CdProdutoBlueSoftControleEstoque = cdprodutobluesoftcontroleestoque;
            this.CdProdutoBlueSoftControlePreco = cdprodutobluesoftcontrolepreco;
            this.DepartamentoKey = departamentokey;
            this.SecaoKey = secaokey;
            this.GrupoKey = grupoprodutokey;
            this.SubGrupoKey = subgrupokey;
            this.DataUltimaAlteracao = dataultimaalteracao;
            this.DataCadastro = datacadastro;
            this.FabricanteKey = fabricantekey;
            this.ProdutoStatus = produtostatus;
            this.PagStatusNovoProduto = pagstatusnovoproduto;
            this.PagStatusAtualizacaoPendente = pagstatusatualizacaopendente;
        }



    }
    #endregion

    #region SP_ProdutoPreco
    public class SP_ProdutoPreco_Parametros
    {
        public string SQLCommnd { get; set; }
        public int F_CdOperacao { get; set; }

        private DateTime f_DataAlteracaoCustoInicial = Convert.ToDateTime("1900-01-01");
        public DateTime F_DataAlteracaoCustoInicial
        {
            get
            {
                return f_DataAlteracaoCustoInicial;

            }
            set
            {
                f_DataAlteracaoCustoInicial = value;
            }
        }

        private DateTime f_DataAlteracaoCustoFinal = Convert.ToDateTime("1999-12-31");
        public DateTime F_DataAlteracaoCustoFinal
        {
            get
            {
                return f_DataAlteracaoCustoFinal;

            }
            set
            {
                f_DataAlteracaoCustoFinal = value;
            }
        }

        public bool F_FiltrarDataAlteracaoCusto { get; set; }
        public string F_StatusProduto { get; set; }

        public string F_Produto_Descricao { get; set; }
        public int F_CdParticipante_Fabricante { get; set; }
        public string F_CdProduto_List { get; set; }
        public string F_CdProdutoBlueSoft_List { get; set; }
        public string F_CdProdutoTarget_List { get; set; }
        public string F_CodigoBarra { get; set; }
        public SP_ProdutoPreco_Parametros(string sQLCommand, int f_CdOperacao)
        {
            SQLCommnd = sQLCommand;
            F_CdOperacao = f_CdOperacao;
        }
    }
    public class SP_ProdutoPreco_TbPreco
    {
        public int TbProduto_CdProduto { get; set; }
        public int TbProduto_CdProdutoBlueSoft { get; set; }
        public string TbProduto_Descricao { get; set; }
        public string TbProduto_EmbalagemEstoque { get; set; }
        public double TbEstoque_Qtde { get; set; }
        public double TbProdutoOperacaoPreco_ValorPreco { get; set; }
        public double TbProdutoOperacaoCusto_ValorCustoBruto { get; set; }
        public double TbProdutoOperacaoCusto_ValorCustoBrutoEntrada { get; set; }
        public DateTime TbProdutoOperacaoPreco_DataAtualizacaoPreco { get; set; }
        public DateTime TbProdutoOperacaoPreco_DataAtualizacaoEstoque { get; set; }
    }
    #endregion

    #region SP_Faturamento
    public class SP_Faturamento_TbFaturamento
    {
        public int TbFaturamento_SeqFaturamento { get; set; }
        public int TbFaturamento_CdParticipanteCliente { get; set; }
        public int TbFaturamento_CdParticipanteVendedor { get; set; }
        public bool TbFaturamento_StatusFaturamento { get; set; }
        public bool TbFaturamento_BlueSoft { get; set; }
        public string TbParticipante_CNPJCPF { get; set; }
        public string TbParticipante_Nome { get; set; }


    }
    #endregion

    #region SP_Integracao
    public class SP_Integracao_Parametro
    {
        public int F_Seq { get; set; }
        public int F_Descricao { get; set; }
        public string SQLCommnd { get; set; }
    }


    public class SP_Integracao_TbIntegracao
    {
        public int Seq { get; set; }
        public string Descricao { get; set; }
    }
    #endregion



    public class InfoClass
    {
        public static string Get()
        {
            return string.Format("Base de Dados: {0} Tabela de Leitura {1} Tabela de Gravação: {2} Procedure de Acesso: {3}, Modelo da Regra de Negócio Destino: {4}",
                          DataBase(),
                          ReadingTables(),
                          RecordingTable(),
                          AccessProcedure(),
                          BusinessRuleModel());
        }
        public static string Error(string _Method, string _ComplementaryInformation)
        {
            return string.Format("Informações {0}, Método {1}, Erro: {2}", Get(), _Method, _ComplementaryInformation);
        }
        public static string ClassName() { return "Não definida"; }
        public static string DataBase() { return "Não definida"; }
        public static string ReadingTables() { return "Não definida"; }
        public static string RecordingTable() { return "Não definida"; }
        public static string AccessProcedure() { return "Não definida"; }
        public static string BusinessRuleModel() { return "Não definida"; }
    }

}

namespace Pag_Net.Models
{
    public class SP_ProdutoBlueSoftComposicao
    {

        public int SeqComposicaoBlueSoft { get; set; }
        public int CdProdutoBlueSoft { get; set; }
        public int CdProdutoBlueSoftComposicao { get; set; }
        public double Qtde { get; set; }
    }
}


namespace Pag_Net.Models
{
    public class SPC5000TbDocumentosFiscais
    {
        public int _SPParameterNfe { get; set; }
        public int _SPParameterSerie { get; set; }
        public int _SPParameterRemetenteCNPJ { get; set; }
        public int _SPParameterDestinatarioCNPJ { get; set; }
        public DateTime _SPParameterDataFaturamentoInicial { get; set; }
        public DateTime _SPparameterDataFaturamentoFinal { get; set; }


        public int BlueSoftEmpresaId { get; set; }
        public int BlueSoftSequencial { get; set; }
        public int BlueSoftUsuarioCancelamento { get; set; }

        public int TargetEmpresaId { get; set; }
        public int TargetSequencial { get; set; }
        public int Nfe { get; set; }
        public string Serie { get; set; }
        public int SerieNumero { get; set; }


        public DateTime DataFaturamento { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime BlueSoftDataCancelamento { get; set; }




        public string ChaveNfe { get; set; }
        public double ValorProdutos { get; set; }
        public double ValorNotaFiscal { get; set; }
        public int CdParticipanteRemetente { get; set; }
        public string RemetenteCNPJ { get; set; }
        public int CdParticipanteDestinatario { get; set; }
        public string DestinatarioCNPJ { get; set; }
        public string DestinatarioUF { get; set; }
        public bool SistemaTarget { get; set; }
        public bool SistemaBlueSoft { get; set; }
        public bool BlueSoftRegistroCancelado { get; set; }

        public string StatusDocumentoFiscal { get; set; }
        public int TargetSequencialOrigem { get; set; }
        public int BlueSoftSequencialOrigem { get; set; }
        public int BlueSoftNfCdTipo { get; set; }
        public string BlueSoftNfDescricaoTipo { get; set; }

        public SPC5000TbDocumentosFiscais()
        {
            this.DataFaturamento = Convert.ToDateTime("1900-01-01");
            this.DataSaida = Convert.ToDateTime("1900-01-01");
            this.BlueSoftDataCancelamento = Convert.ToDateTime("1900-01-01");

        }
        public SPC5000TbDocumentosFiscais(
             int _sPParameterNfe
         , int _sPParameterSerie
         , int _sPParameterRemetenteCNPJ
         , int _sPParameterDestinatarioCNPJ
         , DateTime _sPParameterDataFaturamentoInicial
         , DateTime _sPparameterDataFaturamentoFinal
            )
        {

            this.DataFaturamento = Convert.ToDateTime("1900-01-01");
            this.DataSaida = Convert.ToDateTime("1900-01-01");
            this.BlueSoftDataCancelamento = Convert.ToDateTime("1900-01-01");
            this._SPParameterNfe = _sPParameterNfe;
            this._SPParameterSerie = _sPParameterSerie;
            this._SPParameterRemetenteCNPJ = _sPParameterRemetenteCNPJ;
            this._SPParameterDestinatarioCNPJ = _sPParameterDestinatarioCNPJ;
            this._SPParameterDataFaturamentoInicial = _sPParameterDataFaturamentoInicial.Date;
            this._SPparameterDataFaturamentoFinal = _sPparameterDataFaturamentoFinal.Date;
        }


        public SPC5000TbDocumentosFiscais(DataRow i)
        {


            _SPParameterDataFaturamentoInicial = Convert.ToDateTime(i["DataFaturamento"]);
            _SPparameterDataFaturamentoFinal = Convert.ToDateTime(i["DataFaturamento"]);

            //SeqDocumentoFiscal = Convert.ToInt32(i["SeqDocumentoFiscal"].ToString());
            BlueSoftSequencial = Convert.ToInt32(i["BlueSoftSequencial"].ToString());
            BlueSoftEmpresaId = Convert.ToInt32(i["BlueSoftEmpresaId"].ToString());
            TargetEmpresaId = Convert.ToInt32(i["TargetEmpresaId"].ToString());
            TargetSequencial = Convert.ToInt32(i["TargetSequencial"].ToString());
            Nfe = Convert.ToInt32(i["Nfe"].ToString());
            SerieNumero = Convert.ToInt32(i["SerieNumero"].ToString());
            CdParticipanteRemetente = Convert.ToInt32(i["CdParticipanteRemetente"].ToString());
            CdParticipanteDestinatario = Convert.ToInt32(i["CdParticipanteDestinatario"].ToString());
            TargetSequencialOrigem = Convert.ToInt32(i["TargetSequencialOrigem"].ToString());
            BlueSoftSequencialOrigem = Convert.ToInt32(i["BlueSoftSequencialOrigem"].ToString());
            BlueSoftNfCdTipo = Convert.ToInt32(i["BlueSoftNfCdTipo"].ToString());


            DataFaturamento = Convert.ToDateTime(i["DataFaturamento"]);
            DataSaida = Convert.ToDateTime(i["DataSaida"]);
            BlueSoftDataCancelamento = Convert.ToDateTime(i["BlueSoftDataCancelamento"]);


            Serie = i["Serie"].ToString();

            ChaveNfe = i["ChaveNfe"].ToString();
            RemetenteCNPJ = i["RemetenteCNPJ"].ToString();
            DestinatarioCNPJ = i["DestinatarioCNPJ"].ToString();
            DestinatarioUF = i["DestinatarioUF"].ToString();
            StatusDocumentoFiscal = i["StatusDocumentoFiscal"].ToString();
            BlueSoftNfDescricaoTipo = i["BlueSoftNfDescricaoTipo"].ToString();

            ValorNotaFiscal = Convert.ToDouble(i["ValorNotaFiscal"].ToString());
            ValorProdutos = Convert.ToDouble(i["ValorProdutos"].ToString());

            if (Convert.ToInt32(i["SistemaTarget"]) == 1) { SistemaTarget = true; } else { SistemaTarget = false; }
            if (Convert.ToInt32(i["SistemaBlueSoft"]) == 1) { SistemaBlueSoft = true; } else { SistemaBlueSoft = false; }
            if (Convert.ToInt32(i["BlueSoftRegistroCancelado"]) == 1) { BlueSoftRegistroCancelado = true; } else { BlueSoftRegistroCancelado = false; }
        }
    }
}
