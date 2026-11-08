using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using Pag_Net.Models;
using Pag_Net.Dal;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;
using Pag_Net.Tools;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using Pag_Net.Bll.Tools;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Pag_Net.Bll.Faturamento
{
    public static class BlueSoft_Select_FVNotasFiscais
    {
        public static DataTable List(modelSistemaUsuario _myConnect, DateTime DataInicial, DateTime DataFinal)
        {
            string SqlRedSHIFT = "           select           Convert(int,1)                                as cdempresa " +
                                     "                    ,   Convert(int,1)                                as cdoperacao  " +
                                     "                    ,   pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft " +
                                     "                    ,   nf.NF_NUMERO                                  AS NumeroNotaFiscal " +
                                     "                    ,   ISNULL(dv.NF_NUMERO,0)                        AS NumeroNotaFiscalDevolucao " +
                                     "                    ,   pd.data_emissao                               as DataPedido " +
                                     "                    ,   pd.data_faturamento                           AS DataNotaFiscal " +
                                     "                    ,   pd.status_pedido                              As PedidoStatus " +
                                     "                    ,   pd.prazo_pagamento                            As PedidoPrazoPagamento " +
                                     "                    ,   pd.vendedor_key                               As VendedorKey " +
                                     "                    ,   cast(ps.cpf_cnpj as varchar(14))              As PedidoVendedorCPFCNPJ " +
                                     "                    ,   ps.nome_razao                                 AS VENDEDOR " +
                                     "                    ,   cl.nome_razao                                 AS CLIENTE " +
                                     "                    ,   cast(cl.cpf_cnpj as varchar(14))              AS PedidoClienteCPFCNPJ " +
                                     "                    ,   CASE " +
                                     "                           WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                     "                           WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                     "                           WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                     "                        END AS TipoVenda         " +
                                     "                    ,   case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                     "                    ,   convert(int, 1)                               AS OrigemNotaFiscalBlueSoft " +
                                     "                    ,   cast(coalesce(nf.nf_key,0) as bigint)         as df_nf_seq_blue" + 
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
            "                    where       pd.data_faturamento >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
            "                    and         pd.data_faturamento <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
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
            "                    ,   case when nf.data_cancelamento is null then 0 else 1 end " + 
            "                    ,   coalesce(nf.nf_key,0) "; 

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
                      "                   ,  cast('21814585885' as varchar(14))             as  pedidovendedorcpfcnpj " +
                      "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                      "                   ,  cl.nome_razao                                  as  CLIENTE " +
                      "                   ,  cast(cl.cpf_cnpj as varchar(14))               AS  PedidoClienteCPFCNPJ " +
                      "                   ,  CASE  " +
                      "                        WHEN nf.codigo_operacao_fiscal = '5102' THEN 'VENDA'  " +
                      "                        WHEN nf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO'  " +
                      "                        WHEN nf.codigo_operacao_fiscal = '5405' THEN 'VENDA'   " +
                      "                      END AS TipoVenda  " +
                      "                   ,  case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                      "                    ,   convert(int, 1)                               AS OrigemNotaFiscalBlueSoft " +
                      "                    ,   cast( coalesce(nf.nf_key,0) as bigint)                         as df_nf_seq_blue " + 
                      "          from        fato_nota_fiscal n  " +
                      "          inner join  nota_fiscal      nf on nf.nf_key = n.nf_key  and n.loja_key = nf.loja_key " +
                      "          inner join  pessoa           cl on cl.pessoa_key = nf.fornecedor_key  " +
                      "          inner join  produto_d        pr on pr.produto_key = n.produto_key  " +
                      "          where       nf.data_emissao >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
                      "          and         nf.data_emissao <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
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
                      "                    , case when nf.data_cancelamento is null then 0 else 1 end " +
                      "                    ,   coalesce(nf.nf_key,0) "; 



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
                                    "                   ,  cast('21814585885' as varchar(14))             as  pedidovendedorcpfcnpj " +
                                    "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                                    "                   ,  cl.nome_razao                                  as  CLIENTE " +
                                    "                   ,  cast(cl.cpf_cnpj as varchar(14))               AS  PedidoClienteCPFCNPJ " +
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
                                    "                   ,   cast(coalesce(nf.nf_key,0) as bigint)        as df_nf_seq_blue " + 
                                    "          from        fato_nota_fiscal            n " +
                                    "          inner join  nota_fiscal                 nf on nf.nf_key = n.nf_key  and n.loja_key = nf.loja_key " +
                                    "          inner join  pessoa                      cl on cl.pessoa_key = nf.fornecedor_key " +
                                    "          inner join  cliente_grupo_economico     GP on gp.cliente_key = cl.pessoa_key " +
                                    "          INNER JOIN  GRUPO_ECONOMICO             GE ON GE.GRUPO_ECONOMICO_KEY = GP.GRUPO_ECONOMICO_KEY " +
                                    "          inner join  produto_d        pr on pr.produto_key = n.produto_key " +
                                    "          where       1 = 1  " +
                                    "          AND         nf.data_emissao >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
                                    "          and         nf.data_emissao <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
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
                                    "                          ,  case when nf.data_cancelamento is null then 0 else 1 end "  +
                                    "                    ,   coalesce(nf.nf_key,0) "; 

            DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
            return DX.Tables[0];
        }
    }

    public static class BlueSoft_Select_FVNotasFiscais_Itens
    {
        public static DataTable List(modelSistemaUsuario _myConnect, DateTime DataInicial, DateTime DataFinal, int NumeroNotaFiscal)
        {

            string SqlRedSHIFT = "            SELECT      Convert(int,1)                                as cdempresa " +
                                 "                    ,   Convert(int,1)                                as cdoperacao  " +
                                 "                    ,   pd.pedido_forca_venda_cliente_key             AS NumeroPedidoBlueSOft " +
                                 "                    ,   nf.NF_NUMERO                                  AS NumeroNotaFiscal " +
                                 "                    ,   ISNULL(dv.NF_NUMERO,0)                        AS NumeroNotaFiscalDevolucao " +
                                 "                    ,   coalesce(pd.data_emissao,'1900-01-01')                              as DataPedido " +
                                 "                    ,   coalesce(pd.data_faturamento ,'1900-01-01')                          AS DataNotaFiscal " +
                                 "                    ,   coalesce(pd.status_pedido,'')                 As PedidoStatus " +
                                 "                    ,   coalesce(pd.prazo_pagamento,'')               As PedidoPrazoPagamento " +
                                 "                    ,   coalesce(pd.vendedor_key ,0)                  As VendedorKey " +
                                 "                    ,   cast(coalesce(ps.cpf_cnpj,'57895328000130') as varchar(14))      As PedidoVendedorCPFCNPJ " +
                                 "                    ,   coalesce(ps.nome_razao,'')                                 AS VENDEDOR " +
                                 "                    ,   coalesce(nf.nf_numero,0)                                  AS NOTA " +
                                 "                    ,   coalesce(cl.nome_razao,'')                                 AS CLIENTE " +
                                 "                    ,   cast(coalesce(cl.cpf_cnpj ,'57895328000130') as varchar(14))  AS PedidoClienteCPFCNPJ " +
                                 "                    ,   coalesce(pd.produto_key ,0)                               AS PedidoCdProdutoBlueSoft " +
                                 "                    ,   coalesce(pf.produto_origem_key,0)                         AS NotaFiscalCdProdutoBlueSoft " +
                                 "                    ,   coalesce(pd.produto,'')                                   AS PedidoProdutoDescricao " +
                                 "                    ,   coalesce(pd.volume_faturado,0)                            AS PedidoVolumeFaturado " +
                                 "                    ,   coalesce(pr.produto_unitario_key ,0)                      As PedidoCdProdutoBlueSoftUnitario " +
                                 "                    ,   coalesce(pr.fator_estoque,1)                             as PedidoProdutoUnitarioFator " +
                                 "                    ,   (pd.volume_faturado * isnull(pr.fator_estoque,1) )      as VolumeUnitarioCalculado " +
                                 "                    ,   coalesce(ct.CUSTO_UNITARIO_COM_ICM ,0)                    as ValorCustoUnitario " +
                                 "                    ,   coalesce(pf.ni_valor_bruto,0)                             AS ValorNotaFiscal  " +
                                 "                    ,   isnull(pd.desconto_financeiro,0)              as DescontoFinanceiro  " +
                                 "                    ,   isnull(pd.valor_unitario_verba_vend,0)        as PedidoValorVerba  " +
                                 "                    ,   isnull(pd.perc_est_comissao_vendedor,0)       as PedidoPercentualComissao " +
                                 "                    ,   coalesce(pd.preco_aplicado,0)                             as ValorPrecoVendaCustoFinanceiro " +
                                 "                    ,   coalesce(pd.preco_tabela,0)                               as ValorPrecoTabela  " +
                                 "                    ,   coalesce(pd.embalagem , 'UN')                                 as PedidoTipoEmbalagem " +
                                 "                    ,   CASE " +
                                 "                           WHEN pf.codigo_operacao_fiscal = '5102' THEN 'VENDA' " +
                                 "                           WHEN pf.codigo_operacao_fiscal = '5910' THEN 'BONIFICACAO' " +
                                 "                           WHEN pf.codigo_operacao_fiscal = '5405' THEN 'VENDA' " +
                                 "                        END AS TipoVenda  " +
                                 "                    ,   CONVERT(NUMERIC(17,4), pf.ni_valor_bruto_TOTAL - pf.NI_DESCONTO_TOTAL) as ValorTotalNotaFiscalItem " +
                                 "                    ,   case when nf.data_cancelamento is null then 0 else 1 end as statusnotacancelamento " +
                                 "                    ,   COALESCE(case when pd.embalagem = 'UNIDADE' " +
                                 "                             THEN " +
                                 "                                  CONVERT(NUMERIC(13,2), (pf.ni_valor_bruto - pd.preco_aplicado ) * pd.volume_faturado) " +
                                 "                             else  " +
                                 "                                  CONVERT(NUMERIC(13,2), ( ((pf.ni_valor_bruto/pr.fator_estoque) - pd.preco_aplicado) * pr.fator_estoque ) * pd.volume_faturado) " +
                                 "                             end ,0)                                     AS ValorVerbaCalculadaTotalItem  " +
                                 "                    ,    coalesce(CB.BARRA_KEY,0)                                as PedidoCdProdutoBlueSoftCodigoBarra " +
                                  "                   ,  isnull(fr.nome_transportadora,'')              As TransportadoraDescricao " +
                                  "                   ,  isnull(fr.placa_veiculo,'')                    As TransportadoraPlacaVeiculo " +
                                  "                   ,   cast(coalesce(nf.nf_key,0) as bigint)                         as df_nf_seq_blue " + 
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
                                 "                    where       pd.data_faturamento >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
                                 "                    and         pd.data_faturamento <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
                                 "                    and         nf.loja_key = 1" +
                                 "                    and         isnull(pd.volume_faturado,0) > 0 " +
                                 "                    and         isnull(nf.nf_numero,0) > 0" +
                                 "                    and         pd.status_pedido in ('Faturado por Nota Fiscal','Entregue') ";




            if (NumeroNotaFiscal > 0)
            {
                SqlRedSHIFT += "and         nf.NF_NUMERO = " + NumeroNotaFiscal.ToString();
            }

            SqlRedSHIFT += "          union " +
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
                                  "                   ,  cast('21814585885' as varchar(14))             as  pedidovendedorcpfcnpj " +
                                  "                   ,  'ELIAS DA SILVA'                               as  vendedor " +
                                  "                   ,  n.nf_numero                                    as  NOTA  " +
                                  "                   ,  cl.nome_razao                                  as  CLIENTE " +
                                  "                   ,  cast(cl.cpf_cnpj as varchar(14))               AS  PedidoClienteCPFCNPJ " +
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
                                  "                    ,   cast(coalesce(nf.nf_key,0) as bigint)        as df_nf_seq_blue " + 
                                  "          from        fato_nota_fiscal                   n  " +
                                  "          inner join  nota_fiscal                        nf on nf.nf_key = n.nf_key and nf.loja_key = n.loja_key " +
                                  "          left  join  nota_fiscal                        dv on dv.numero_documento_origem = nf.nf_numero and dv.loja_key = nf.loja_key" +
                                  "          left  join  fato_nota_fiscal_frete             fr on fr.nf_key = nf.nf_key and fr.loja_key = nf.loja_key and fr.nf_numero = nf.nf_numero " +
                                  "          inner join  pessoa                             cl on cl.pessoa_key = nf.fornecedor_key  " +
                                  "          inner join  produto_d                          pr on pr.produto_key = n.produto_key  " +
                                  "          where       nf.data_emissao >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
                                  "          and         nf.data_emissao <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
                                  "          and         n.loja_key = 991  " +
                                  "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405')  " +
                                  "          and         n.nf_tipo_descricao = 'Nota fiscal de venda a cliente por pedido'  " +
                                  "          and         isnull(n.quantidade_faturada,0) > 0 ";


            if (NumeroNotaFiscal > 0)
            {
                SqlRedSHIFT += "and         n.nf_numero = " + NumeroNotaFiscal.ToString();
            }


            SqlRedSHIFT += "          union " +


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
                                  "          ,  cast('21814585885' as varchar(14))                                  as  pedidovendedorcpfcnpj " +
                                  "          ,  'ELIAS DA SILVA'                                                    as  vendedor " +
                                  "          ,  n.nf_numero                                                         as  NOTA " +
                                  "          ,  cl.nome_razao                                                       as  CLIENTE " +
                                  "          ,  cast(cl.cpf_cnpj as varchar(14))                                    AS  PedidoClienteCPFCNPJ " +
                                  "          ,  n.produto_key                                                       AS  PedidoCdProdutoBlueSoft " +
                                  "          ,  n.produto_key                                                       AS  NotaFiscalCdProdutoBlueSoft " +
                                  "          ,  pr.descricao                                                        AS  PedidoProdutoDescricao " +
                                  "          ,  n.quantidade_faturada                                               as  PedidoVolumeFaturado " +
                                  "          ,  PR.produto_unitario_key                                             as  PedidoCdProdutoBlueSoftUnitario " +
                                  "          ,  pr.fator_estoque                                                    as  PedidoProdutoUnitarioFator " +
                                  "          ,  n.quantidade_faturada * isnull(pr.fator_estoque,1)                  as  VolumeUnitarioCalculado " +
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
                                  "          ,   cast(coalesce(nf.nf_key,0) as bigint)         as df_nf_seq_blue " + 
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
                                  "          AND         nf.data_emissao >= '" + DataInicial.ToString("yyyy-MM-dd") + "'" +
                                  "          and         nf.data_emissao <= '" + DataFinal.ToString("yyyy-MM-dd") + "'" +
                                  "          and         n.loja_key = 1  " +
                                  "          and         n.nf_key not in ( select nf_key from fato_pedido_forca_venda where data_faturamento >= '20200301' group by nf_key  )  " +
                                  "          and         ge.descricao like '%5ASEC%' " +
                                  "          and         nf.codigo_operacao_fiscal in ('5102','5910','5405', '6102','6910','6405', '6108')   " +
                                  "          and         n.nf_tipo_descricao IN ( 'Nota fiscal de venda a cliente por pedido', 'Nota fiscal de venda a cliente')  " +
                                  "          and         isnull(n.quantidade_faturada,0)  > 0 ";


            if (NumeroNotaFiscal > 0)
            {
                SqlRedSHIFT += "and         nf.NF_NUMERO = " + NumeroNotaFiscal.ToString();
            }


            DataSet DX = DbSelect.GetDataSet(_myConnect, DataBaseName.ODBCBI32, SqlRedSHIFT, "");
            return DX.Tables[0];
        }
    }

    public static class BlueSoft_Import
    {
        public static int Start(modelSistemaUsuario _myConnect, DateTime DataInicial, DateTime DataFinal)
        {
            try
            {

                DateTime vDataInicial = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(_myConnect, "OLD08", 37);
                DateTime vDataFinal = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(_myConnect, "OLD08", 37);


                UpdateNotasFiscais(_myConnect, vDataInicial, vDataFinal);
                InsertNotasFiscaisItens(_myConnect, vDataInicial, vDataFinal);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        private static int UpdateNotasFiscais(modelSistemaUsuario _myConnect, DateTime DataInicial, DateTime DataFinal)
        {
            /* Get datatable redshift */
            DataTable TbBlue = Pag_Net.Bll.Faturamento.BlueSoft_Select_FVNotasFiscais.List(_myConnect, DataInicial, DataFinal);

            /* Var's */
            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);

            List<ParameterQuey> Parametros = new List<ParameterQuey>();
            //string ErroMessageInfo = "Erro não identificado";

            /* Begin Command */
            x.Begin();

            /* Limpa os parametros para um novo insert*/
            Parametros.Clear();


            for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
            {
                Parametros.Clear();

                //Proc Execute
                /*
                Parametros.Add(new ParameterQuey("CdEmpresa", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["CdEmpresa"].ToString())));
                Parametros.Add(new ParameterQuey("CdOperacao", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["CdOperacao"].ToString())));
                Parametros.Add(new ParameterQuey("NumeroPedidoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroPedidoBlueSoft"].ToString())));
                Parametros.Add(new ParameterQuey("NumeroNotaFiscal", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroNotaFiscal"].ToString())));
                Parametros.Add(new ParameterQuey("NumeroNotaFiscalDevolucao", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroNotaFiscalDevolucao"].ToString())));
                Parametros.Add(new ParameterQuey("statusnotacancelamento", SqlDbType.Bit, false, Convert.ToInt16(TbBlue.Rows[i]["statusnotacancelamento"].ToString())));

                Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "UPDATE"));

                x.Execute("SP_FaturamentoBlueSoft", Parametros.ToArray());
                 * */

                string SqlServer_SCRIPT = string.Format(" EXEC SP_FaturamentoBlueSoft " +
                                                         "       @COMMAND                         = 'UPDATE'  " +
                                                         "   ,   @cdempresa                       = {0}       " +
                                                         "   ,   @cdoperacao                      = {1}       " +
                                                         "   ,   @NumeroPedidoBlueSoft            = {2}       " +
                                                         "   ,   @NumeroNotaFiscal                = {3}       " +
                                                         "   ,   @NumeroNotaFiscalDevolucao       = {4}       " +
                                                         "   ,   @statusnotacancelamento          = {5}       ",

                                                         TbBlue.Rows[i]["CdEmpresa"].ToString(),
                                                         TbBlue.Rows[i]["CdOperacao"].ToString(),
                                                         TbBlue.Rows[i]["NumeroPedidoBlueSoft"].ToString(),
                                                         TbBlue.Rows[i]["NumeroNotaFiscal"].ToString(),
                                                         TbBlue.Rows[i]["NumeroNotaFiscalDevolucao"].ToString(),
                                                         TbBlue.Rows[i]["statusnotacancelamento"].ToString());
                x.Execute(SqlServer_SCRIPT, null, DataBaseName.DBAMAINADM, true);
            }
            /* Commit tran*/
            x.Commit();

            /* Close*/
            x.Close();


            return 0;


        }
        private static int InsertNotasFiscaisItens(modelSistemaUsuario _myConnect, DateTime DataInicial, DateTime DataFinal)
        {
            /* Get datatable redshift */
            DataTable TbBlue = Pag_Net.Bll.Faturamento.BlueSoft_Select_FVNotasFiscais_Itens.List(_myConnect, DataInicial, DataFinal, 0);

            /* Var's */
            DbUpdate x = new DbUpdate(_myConnect, DataBaseName.DBAMAINADM);
            List<ParameterQuey> Parametros = new List<ParameterQuey>();
            string ErroMessageInfo = "Erro não identificado";

            /* Begin Command */
            x.Begin();

            /* Limpa os parametros para um novo insert*/
            Parametros.Clear();

            /*criar seq*/




            for (int i = 0; i <= TbBlue.Rows.Count - 1; i++)
            {


                ErroMessageInfo = string.Format("Registro seq for (i): {0} | Numero do Pedido: {1}, Nota Fiscal: {2} ", i.ToString(), TbBlue.Rows[i]["NumeroPedidoBlueSoft"].ToString(), TbBlue.Rows[i]["NumeroNotaFiscal"].ToString());
                try
                {

                    DateTime dateSeqItem = Convert.ToDateTime(TbBlue.Rows[i]["DataPedido"].ToString());

                    string SeqItemYeardateEmissaodoPedido = dateSeqItem.Year.ToString("D4");
                    string SeqItemMonthdateEmissaodoPedido = dateSeqItem.Month.ToString("D2");
                    string SeqItemDaydateEmissaodoPedido = dateSeqItem.Day.ToString("D2");
                    string SeqItemCdProduto = Convert.ToInt32(TbBlue.Rows[i]["PedidoCdProdutoBlueSoft"].ToString()).ToString("D7");
                    string Seq = (i + 1).ToString("D5");

                    //string SeqItemBulder = string.Format("{0}{1}{2}{3}",SeqItemYeardateEmissaodoPedido, SeqItemMonthdateEmissaodoPedido,SeqItemDaydateEmissaodoPedido, SeqItemCdProduto);
                    string SeqItemBulder = string.Format("{0}", Seq);

                    int SeqItem = Convert.ToInt32(SeqItemBulder);

                    Parametros.Clear();



                    //int fields 
                    Parametros.Add(new ParameterQuey("CdEmpresa", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["CdEmpresa"].ToString())));
                    Parametros.Add(new ParameterQuey("CdOperacao", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["CdOperacao"].ToString())));
                    Parametros.Add(new ParameterQuey("NumeroPedidoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroPedidoBlueSoft"].ToString())));
                    Parametros.Add(new ParameterQuey("NumeroNotaFiscal", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroNotaFiscal"].ToString())));
                    Parametros.Add(new ParameterQuey("NumeroNotaFiscalDevolucao", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NumeroNotaFiscalDevolucao"].ToString())));
                    Parametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["PedidoCdProdutoBlueSoft"].ToString())));
                    Parametros.Add(new ParameterQuey("NotaFiscalCdProdutoBlueSoft", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["NotaFiscalCdProdutoBlueSoft"].ToString())));
                    Parametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoftUnitario", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["PedidoCdProdutoBlueSoftUnitario"].ToString())));
                    Parametros.Add(new ParameterQuey("SeqItem", SqlDbType.Int, false, SeqItem));
                    Parametros.Add(new ParameterQuey("df_nf_seq_blue", SqlDbType.Int, false, Convert.ToInt32(TbBlue.Rows[i]["df_nf_seq_blue"].ToString())));

                    //Date Time Fields
                    Parametros.Add(new ParameterQuey("DataPedido", SqlDbType.SmallDateTime, false, Convert.ToDateTime(TbBlue.Rows[i]["DataPedido"].ToString())));
                    Parametros.Add(new ParameterQuey("DataNotaFiscal", SqlDbType.SmallDateTime, false, Convert.ToDateTime(TbBlue.Rows[i]["DataNotaFiscal"].ToString())));

                    //chars fields 
                    Parametros.Add(new ParameterQuey("PedidoStatus", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoStatus"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoPrazoPagamento", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoPrazoPagamento"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoVendedorCPFCNPJ", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoVendedorCPFCNPJ"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoClienteCPFCNPJ", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoClienteCPFCNPJ"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoProdutoDescricao", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoProdutoDescricao"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoTipoEmbalagem", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoTipoEmbalagem"].ToString()));
                    Parametros.Add(new ParameterQuey("TipoVenda", SqlDbType.VarChar, false, TbBlue.Rows[i]["TipoVenda"].ToString()));
                    Parametros.Add(new ParameterQuey("PedidoCdProdutoBlueSoftCodigoBarra", SqlDbType.VarChar, false, TbBlue.Rows[i]["PedidoCdProdutoBlueSoftCodigoBarra"].ToString()));
                    Parametros.Add(new ParameterQuey("TransportadoraDescricao", SqlDbType.VarChar, false, TbBlue.Rows[i]["TransportadoraDescricao"].ToString()));
                    Parametros.Add(new ParameterQuey("TransportadoraPlacaVeiculo", SqlDbType.VarChar, false, TbBlue.Rows[i]["TransportadoraPlacaVeiculo"].ToString()));

                    //decimals fields
                    Parametros.Add(new ParameterQuey("PedidoVolumeFaturado", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PedidoVolumeFaturado"].ToString())));
                    Parametros.Add(new ParameterQuey("PedidoProdutoUnitarioFator", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PedidoProdutoUnitarioFator"].ToString())));
                    Parametros.Add(new ParameterQuey("VolumeUnitarioCalculado", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["VolumeUnitarioCalculado"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorCustoUnitario", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorCustoUnitario"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorNotaFiscal", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorNotaFiscal"].ToString())));
                    Parametros.Add(new ParameterQuey("DescontoFinanceiro", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["DescontoFinanceiro"].ToString())));
                    Parametros.Add(new ParameterQuey("PedidoValorVerba", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PedidoValorVerba"].ToString())));
                    Parametros.Add(new ParameterQuey("PedidoPercentualComissao", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["PedidoPercentualComissao"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorPrecoVendaCustoFinanceiro", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorPrecoVendaCustoFinanceiro"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorPrecoTabela", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorPrecoTabela"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorTotalNotaFiscalItem", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorTotalNotaFiscalItem"].ToString())));
                    Parametros.Add(new ParameterQuey("ValorVerbaCalculadaTotalItem", SqlDbType.Decimal, false, Convert.ToDouble(TbBlue.Rows[i]["ValorVerbaCalculadaTotalItem"].ToString())));




                    //bit-int fields


                    Parametros.Add(new ParameterQuey("COMMAND", SqlDbType.VarChar, false, "INSERT"));

                    x.Execute("SP_FaturamentoBlueSoft", Parametros.ToArray());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + ErroMessageInfo);
                }

            }
            /* Commit tran*/
            x.Commit();

            /* Close*/
            x.Close();


            return 0;
        }
    }

}
