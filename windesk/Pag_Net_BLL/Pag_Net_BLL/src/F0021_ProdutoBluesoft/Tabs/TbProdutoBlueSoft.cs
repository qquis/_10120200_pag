using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class TbProdutoBlueSoft
    {

        public int prb_CdProdutoBlueSoft_pk { get; set; }
        public int prb_CdProdutoBlueSoft_Unitario { get; set; }
        public string prb_Descricao { get; set; }
        public string prb_EmbalagemEstoque { get; set; }
        public double prb_FatorEstoque { get; set; }
        public bool prb_status_embalagemcaixa { get; set; }
        public string prb_EmbalagemCompra { get; set; }
        public double prb_EmbalagemCompraQtdeUnitaria { get; set; }
        public string prb_cdbarra_principal { get; set; }
        public int prb_CdProdutoBlueSoft_ControleEstoque { get; set; }
        public int prb_CdProdutoBlueSoft_ControlePreco { get; set; }
        public int prb_cdsubgrupo { get; set; }
        public DateTime prb_dt_cadastro { get; set; }
        public DateTime prb_dt_ultimaalteracao { get; set; }
        public int prb_cdpessoabluesoft_fabricante { get; set; }
        public bool prb_VendaExterna { get; set; }
        public string prb_descricao_fiscal { get; set; }
        public int prb_cdproduto_compra_padrao { get; set; }
        public int prbf_seq { get; set; }
        public bool prb_Status { get; set; }
        public int prb_tipo_composicao_cd { get; set; }
        public DateTime dtupdate_from_api { get; set; }
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public string prb_descricao_gondola { get; set; }
        public string prb_descricao_cupom { get; set; }
        public string prb_descricao_balanca { get; set; }
        public int prb_cdpessoabluesoft_fornecedor { get; set;  }
        public int prb_cdpessoabluesoft_fornecedor_troca { get; set;  }
        public double prb_pesobruto { get; set; }
        public double prb_pesoliquido { get; set; }


        public TbProdutoBlueSoft() { }
        public TbProdutoBlueSoft(DataRow i)
        {
            try
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
                prb_descricao_gondola = i["prb_descricao_gondola"].ToString();
                prb_descricao_cupom = i["prb_descricao_cupom"].ToString();
                prb_descricao_balanca = i["prb_descricao_balanca"].ToString();
                prb_cdpessoabluesoft_fornecedor = Convert.ToInt32(i["prb_cdpessoabluesoft_fornecedor"].ToString());
                prb_cdpessoabluesoft_fornecedor_troca = Convert.ToInt32(i["prb_cdpessoabluesoft_fornecedor_troca"].ToString());
                prb_pesobruto = Convert.ToDouble(i["prb_pesobruto"].ToString());
                prb_pesoliquido = Convert.ToDouble(i["prb_pesoliquido"].ToString());
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
