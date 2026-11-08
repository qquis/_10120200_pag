
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
//using Pag_Net.F0021;


/*
namespace Pag_Net.F0021.Models
{
    public class ProdutoBlueSoft
    {
       
       public int prb_CdProdutoBlueSoft_pk {get;set;}
       public int prb_CdProdutoBlueSoft_Unitario {get;set;}
       public string prb_Descricao {get;set;}
       public string prb_EmbalagemEstoque {get;set;}
       public double prb_FatorEstoque {get;set;}
       public bool prb_status_embalagemcaixa {get;set;} 
       public string prb_EmbalagemCompra {get;set;}
       public double prb_EmbalagemCompraQtdeUnitaria {get;set;} 
       public string prb_cdbarra_principal {get;set;}
       public int prb_CdProdutoBlueSoft_ControleEstoque {get;set;}
       public int prb_CdProdutoBlueSoft_ControlePreco {get;set;}
       public int prb_cdsubgrupo {get;set;}
       public DateTime prb_dt_cadastro {get;set;}
       public DateTime prb_dt_ultimaalteracao {get;set;}
       public int  prb_cdpessoabluesoft_fabricante {get;set;}
       public bool prb_VendaExterna {get;set;}
       public string prb_descricao_fiscal { get; set; }
       public int prb_cdproduto_compra_padrao { get; set; }
       public int prbf_seq { get; set; }
       public bool prb_Status { get; set; }
       public int prb_tipo_composicao_cd { get; set; }
       public DateTime dtupdate_from_api  {get;set;}
       public DateTime dtlog_insert  {get;set;}
       public DateTime dtlog_update {get;set;}

        public ProdutoBlueSoft() { }
        public ProdutoBlueSoft(DataRow i)
        {
            prb_CdProdutoBlueSoft_pk = Convert.ToInt32(i["prb_CdProdutoBlueSoft_pk"].ToString());
            prb_CdProdutoBlueSoft_Unitario = Convert.ToInt32(i["prb_CdProdutoBlueSoft_Unitario"].ToString());
            prb_Descricao = i["prb_Descricao"].ToString();
            prb_EmbalagemEstoque = i["prb_EmbalagemEstoque"].ToString();
            prb_FatorEstoque = Convert.ToDouble(i["prb_FatorEstoque"]);
            prb_status_embalagemcaixa = Convert.ToBoolean(i["prb_status_embalagemcaixa"]);
            prb_EmbalagemCompra = i["prb_EmbalagemCompra"].ToString();
            prb_EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["prb_EmbalagemCompraQtdeUnitaria"]);
            prb_cdbarra_principal = i["prb_cdbarra_principal"].ToString();
            prb_CdProdutoBlueSoft_ControleEstoque = Convert.ToInt32(i["prb_CdProdutoBlueSoft_ControleEstoque"].ToString());
            prb_CdProdutoBlueSoft_ControlePreco = Convert.ToInt32(i["prb_CdProdutoBlueSoft_ControlePreco"].ToString());
            prb_cdsubgrupo = Convert.ToInt32(i["prb_cdsubgrupo"].ToString());
            prb_dt_cadastro = Convert.ToDateTime(i["prb_dt_cadastro"].ToString());
            prb_dt_ultimaalteracao = Convert.ToDateTime(i["prb_dt_ultimaalteracao"].ToString());
            prb_cdpessoabluesoft_fabricante = Convert.ToInt32(i["prb_cdpessoabluesoft_fabricante"].ToString());
            prb_VendaExterna = Convert.ToBoolean(i["prb_VendaExterna"]);
            prb_descricao_fiscal = " - ";
            prb_cdproduto_compra_padrao = Convert.ToInt32(i["prb_cdproduto_compra_padrao"]);
            prbf_seq = Convert.ToInt32(i["prbf_seq"]);
            prb_Status = Convert.ToBoolean(i["prb_Status"]);
            prb_tipo_composicao_cd = Convert.ToInt32(i["prb_tipo_composicao_cd"]);
            //dtupdate_from_api = Convert.ToDateTime(i["dtupdate_from_api"].ToString());
            //dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
            //dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
        }
    }
}

namespace Pag_Net.F0021.Models.BD
{
    public static class Postgres
    {
        public static string f0021_crud_tbprodutobluesoft(ProdutoBlueSoft item, Pag_Net.Models.BDCommandTypes _Type)
        {
            return string.Format("SELECT f0021_crud_tbprodutobluesoft ('{0}', {1}, {2}, '{3}', '{4}', {5}, " +
                                                                  " '{6}', '{7}', {8}, '{9}', {10}, {11}, {12}, " +
                                                                  " '{13}', '{14}', {15}, '{16}', '{17}',  {18},  {19}, '{20}', {21}, '{22}') ",
                                             BDTools.SqlCommandType(_Type).ToString(),
                                             item.prb_CdProdutoBlueSoft_pk,
                                             item.prb_CdProdutoBlueSoft_Unitario,
                                             item.prb_Descricao.Replace("'",""),
                                             item.prb_EmbalagemEstoque,
                                             item.prb_FatorEstoque.ToString("0.00").Replace(",", "."),
                                             item.prb_status_embalagemcaixa,
                                             item.prb_EmbalagemCompra,
                                             item.prb_EmbalagemCompraQtdeUnitaria.ToString("0.00").Replace(",", "."),
                                             item.prb_cdbarra_principal,
                                             item.prb_CdProdutoBlueSoft_ControleEstoque ,
                                             item.prb_CdProdutoBlueSoft_ControlePreco ,
                                             item.prb_cdsubgrupo,
                                             item.prb_dt_cadastro.ToString("yyyyMMdd"),
                                             item.prb_dt_ultimaalteracao.ToString("yyyyMMdd"),
                                             item.prb_cdpessoabluesoft_fabricante,
                                             item.prb_VendaExterna,
                                             item.prb_descricao_fiscal, 
                                             item.prb_cdproduto_compra_padrao,
                                             item.prbf_seq,
                                             item.prb_Status, 
                                             item.prb_tipo_composicao_cd,
                                             "false")



                ;
        }
    }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = "SELECT            ISNULL(X.PRODUTO_KEY,0)                      AS  prb_CdProdutoBlueSoft_pk" +
                             "           ,  ISNULL(X.PRODUTO_UNITARIO_KEY,0)             AS  prb_CdProdutoBlueSoft_Unitario" +
                             "           ,  X.DESCRICAO                                  AS  prb_Descricao" +
                             "           ,  X.EMBALAGEM_KEY                              AS  prb_EmbalagemEstoque" +
                             "           ,  ISNULL(X.FATOR_ESTOQUE,1)                    AS  prb_FatorEstoque" +
                             "           ,  X.caixa                                      AS  prb_status_embalagemcaixa " +
                             "           ,  ISNULL(X1.EMBALAGEM_KEY,X.EMBALAGEM_KEY)     AS  prb_EmbalagemCompra " +
                             "           ,  ISNULL(X1.FATOR_ESTOQUE,1)                   AS  prb_EmbalagemCompraQtdeUnitaria " +
                             "           ,  X.GTIN_PRINCIPAL                             AS  prb_cdbarra_principal" +
                             "           ,  ISNULL(X.CONTROLE_ESTOQUE,0)                 AS  prb_CdProdutoBlueSoft_ControleEstoque" +
                             "           ,  ISNULL(X.PRECO_EQUIVALENTE,0)                AS  prb_CdProdutoBlueSoft_ControlePreco" +
                             "           ,  ISNULL(X.SUB_GRUPO_PRODUTO_KEY,0)            AS  prb_cdsubgrupo" +
                             "           ,  ISNULL(X.ULTIMA_ALTERACAO,'1900-01-01')      AS  prb_dt_cadastro" +
                             "           ,  ISNULL(x.DATA_CADASTRO,'1900-01-01')         AS  prb_dt_ultimaalteracao" +
                             "           ,  ISNULL(X.FABRICANTE_KEY,0)                   AS  prb_cdpessoabluesoft_fabricante" +
                             "           ,  ISNULL(vx.VendaExterna,0)                    AS  prb_VendaExterna " +
                             "           ,  ISNULL(X.STATUS,0)                           AS  prb_Status " +
                             "           ,  ISNULL(FP.PRODUTO_KEY,0)                     AS  prb_cdproduto_compra_padrao " + 
                             "           ,  ISNULL(FP.FORNECEDOR_PRODUTO_KEY,0)          AS  prbf_seq " +
                             "           ,  ISNULL(X.TIPO_COMPOSICAO_KEY,0)              AS  prb_tipo_composicao_cd " + 
                             "           ,  ISNULL(X.DESCRICAO_GONDOLA, '')              AS  prb_descricao_gondola " +
                             "           ,  ISNULL(X.DESCRICAO_CUPOM, '')                AS  prb_descricao_cupom " +
                             "           ,  ISNULL(X.DESCRICAO_BALANCA, '')              AS  prb_descricao_balanca " + 
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
*/