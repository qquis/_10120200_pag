using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0021_ProdutoBlueSoft;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class F0021_01_ProdutoBlueSoft_CRUD
    {
        private static string _VERSION() { return "f0021_01_1012018_produtobluesoft_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbProdutoBlueSoft item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + _VERSION() 
                
                
                
                                            + " ( sqlcommand:='" +  BDCommnadType.ToString() + "' "
                                            + " , vprb_cdprodutobluesoft_pk:= " + item.prb_CdProdutoBlueSoft_pk.ToString() + " "
                                            + " , vprb_cdprodutobluesoftunitario:= " + item.prb_CdProdutoBlueSoft_Unitario.ToString()
                                            + " , vprb_descricao:= '" + item.prb_Descricao.Replace("'", "") + "' "
                                            + " , vprb_embalagemestoque:= '" + item.prb_EmbalagemEstoque + "' "
                                            + " , vprb_fatorestoque:= " + item.prb_FatorEstoque.ToString("0.00").Replace(",", ".") + " "
                                            + " , vprb_status_embalagemcaixa:= " + item.prb_status_embalagemcaixa + " "
                                            + " , vprb_embalagemcompra:= '" + item.prb_EmbalagemCompra + "' "
                                            + " , vprb_embalagemcompra_qtdeunitaria:= " + item.prb_EmbalagemCompraQtdeUnitaria.ToString("0.00").Replace(",", ".") + " "
                                            + " , vprb_cdbarra_principal:= '" + item.prb_cdbarra_principal + "' "
                                            + " , vprb_cdprodutobluesoft_controleestoque:= " + item.prb_CdProdutoBlueSoft_ControleEstoque + " "
                                            + " , vprb_cdprodutobluesoft_controlepreco:=    " + item.prb_CdProdutoBlueSoft_ControlePreco + " "
                                            + " , vprb_cdsubgrupo:= " + item.prb_cdsubgrupo + " "
                                            + " , vprb_dt_cadastro:= '" + item.prb_dt_cadastro.ToString("yyyy-MM-dd") + "' "
                                            + " , vprb_dt_ultimaalteracao:= '" + item.prb_dt_ultimaalteracao.ToString("yyyy-MM-dd") + "' "
                                            + " , vprb_cdpessoabluesoft_fabricante:= " + item.prb_cdpessoabluesoft_fabricante + " "
                                            + " , vprb_vendaexterna:= " + item.prb_VendaExterna + " "
                                            + " , vprb_descricao_fiscal:= '" + item.prb_descricao_fiscal + "' "
                                            + " , vprb_cdproduto_compra_padrao:= " + item.prb_cdproduto_compra_padrao + " "
                                            + " , vprbf_seq:= " + item.prbf_seq + " "
                                            + " , vprb_status:= " + item.prb_Status + " "
                                            + " , vprb_tipo_composicao_cd:= " + item.prb_tipo_composicao_cd + " "
                                            + " , vprb_descricao_gondola:= '" + item.prb_descricao_gondola.Replace("'", "") + "' "
                                            + " , vprb_descricao_cupom:= '" + item.prb_descricao_cupom.Replace("'", "") + "' "
                                            + " , vprb_descricao_balanca:= '" + item.prb_descricao_balanca.Replace("'", "") + "' "
                                            + " , vprb_cdpessoabluesoft_fornecedor:= " + item.prb_cdpessoabluesoft_fornecedor.ToString() + " "
                                            + " , vprb_cdpessoabluesoft_fornecedor_troca:= " + item.prb_cdpessoabluesoft_fornecedor_troca.ToString() + " "
                                            + " , vprb_pesobruto:= " + item.prb_pesobruto.ToString("0.0000").Replace(",", ".") + " "
                                            + " , vprb_pesoliquido:= " + item.prb_pesoliquido.ToString("0.0000").Replace(",", ".") + " "
                                            + " , vprb_largura:= 0 "
                                            + " , vprb_altura:= 0 " 
                                            + " , vprb_pesoaproximado:= 0 "
                                            + " , vprb_comprimento:= 0 " 
                                            + " , vprb_blue_fc_cbenef_cd:= '' "
                                            + " , vcommand_api:= false "
                                            + " , vatualizalog:= 0"
                                            + " ) "
                                             
                    );


                    /*


                      sqlcommand character varying
        , vprb_cdprodutobluesoft_pk integer
        , vprb_cdprodutobluesoftunitario integer
        , vprb_descricao character varying
        , vprb_embalagemestoque character
        , vprb_fatorestoque numeric
        , vprb_status_embalagemcaixa boolean
        , vprb_embalagemcompra character
        , vprb_embalagemcompra_qtdeunitaria numeric
        , vprb_cdbarra_principal character
        , vprb_cdprodutobluesoft_controleestoque integer
        , vprb_cdprodutobluesoft_controlepreco integer
        , vprb_cdsubgrupo integer
        , vprb_dt_cadastro date
        , vprb_dt_ultimaalteracao date
        , vprb_cdpessoabluesoft_fabricante integer
        , vprb_vendaexterna boolean
        , vprb_descricao_fiscal character varying
        , vprb_cdproduto_compra_padrao integer
        , vprbf_seq integer
        , vprb_status boolean
        , vprb_tipo_composicao_cd integer
        , vprb_descricao_gondola character varying
        , vprb_descricao_cupom character varying
        , vprb_descricao_balanca character varying
        , vprb_cdpessoabluesoft_fornecedor integer
        , vprb_cdpessoabluesoft_fornecedor_troca integer
        , vprb_pesobruto numeric
        , vprb_pesoliquido numeric
        , vprb_largura numeric
        , vprb_altura numeric
        , vprb_pesoaproximado numeric
        , vprb_comprimento numeric
        , vprb_blue_fc_cbenef_cd character varying
        , vcommand_api boolean
        , vatualizalogpendenciazanthus int

        */









                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {

            /*
             20.15.7.3 _ AJUSTE DO CAMPO DE CADASTRO QUE ESTAVA INVERTIDO COM O CAMPO DA DATA DE ULTIMA ALTERAÇÃO
             
             */
            string SQL = "SELECT            COALESCE(X.PRODUTO_KEY,0)                      AS  prb_CdProdutoBlueSoft_pk" +
                             "           ,  COALESCE(X.PRODUTO_UNITARIO_KEY,0)             AS  prb_CdProdutoBlueSoft_Unitario" +
                             "           ,  X.DESCRICAO                                    AS  prb_Descricao" +
                             "           ,  X.EMBALAGEM_KEY                                AS  prb_EmbalagemEstoque" +
                             "           ,  COALESCE(X.FATOR_ESTOQUE,1)                    AS  prb_FatorEstoque" +
                             "           ,  X.caixa                                        AS  prb_status_embalagemcaixa " +
                             "           ,  COALESCE(X1.EMBALAGEM_KEY,X.EMBALAGEM_KEY)     AS  prb_EmbalagemCompra " +
                             "           ,  COALESCE(X1.FATOR_ESTOQUE,1)                   AS  prb_EmbalagemCompraQtdeUnitaria " +
                             "           ,  X.GTIN_PRINCIPAL                               AS  prb_cdbarra_principal" +
                             "           ,  COALESCE(X.CONTROLE_ESTOQUE,0)                 AS  prb_CdProdutoBlueSoft_ControleEstoque" +
                             "           ,  COALESCE(X.PRECO_EQUIVALENTE,0)                AS  prb_CdProdutoBlueSoft_ControlePreco" +
                             "           ,  COALESCE(X.SUB_GRUPO_PRODUTO_KEY,0)            AS  prb_cdsubgrupo" +
                             "           ,  COALESCE(X.ULTIMA_ALTERACAO,'1900-01-01')      AS  prb_dt_ultimaalteracao " +
                             "           ,  COALESCE(x.DATA_CADASTRO,'1900-01-01')         AS  prb_dt_cadastro" +
                             "           ,  COALESCE(X.FABRICANTE_KEY,0)                   AS  prb_cdpessoabluesoft_fabricante" +
                             "           ,  COALESCE(vx.VendaExterna,0)                    AS  prb_VendaExterna " +
                             "           ,  COALESCE(X.STATUS,0)                           AS  prb_Status " +
                             "           ,  COALESCE(FP.PRODUTO_KEY,0)                     AS  prb_cdproduto_compra_padrao " +
                             "           ,  COALESCE(FP.FORNECEDOR_PRODUTO_KEY,0)          AS  prbf_seq " +
                             "           ,  COALESCE(X.TIPO_COMPOSICAO_KEY,0)              AS  prb_tipo_composicao_cd " +
                             "           ,  COALESCE(X.DESCRICAO_GONDOLA, '')              AS  prb_descricao_gondola " +
                             "           ,  COALESCE(X.DESCRICAO_CUPOM, '')                AS  prb_descricao_cupom " +
                             "           ,  COALESCE(X.DESCRICAO_BALANCA, '')              AS  prb_descricao_balanca " +
                             "           ,  COALESCE(X.fornecedor_key, 0)                  AS  prb_cdpessoabluesoft_fornecedor " +
                             "           ,  COALESCE(X.troca_fornecedor_key, 0)            AS  prb_cdpessoabluesoft_fornecedor_troca " + 
                             "           ,  COALESCE(x.peso_bruto,0)                       AS  prb_pesobruto " +
                             "           ,  COALESCE(x.peso_liquido,0)                     AS  prb_pesoliquido " + 
                             " FROM         PRODUTO_D     X " +
                             " LEFT JOIN    FORNECEDOR_PRODUTO           FP ON FP.FORNECEDOR_PRODUTO_KEY = X.FORNECEDOR_PRODUTO_PADRAO_KEY " +
                             " LEFT JOIN    PRODUTO_D                    X1 ON X1.PRODUTO_KEY = FP.PRODUTO_KEY" +
                             " LEFT JOIN    (   SELECT   produto_key            as CdProdutoBlueSoft " +
                             "                         , convert(int, 1)        as VendaExterna " +
                             "                  FROM     produto_loja_venda_externa   " +
                             "                  GROUP BY Produto_key " +
                             "              ) vx on vx.CdProdutoBlueSoft = ISNULL(X.PRODUTO_KEY,0) " +
                             " WHERE        x.produto_key > 0 " +
                             " order by     x.produto_key asc ";
            //"        where pessoa_key = 1 ";
            return SQL;

        }
    }
}
