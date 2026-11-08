using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class TbProdutoBlueSoftGtins
    {

        public string prbg_cdbarra_pk { get; set; }
        public int prb_CdProdutoBlueSoft { get; set; }
        public string prbg_Embalagem { get; set; }
        public string prbg_EmbalagemDescricao { get; set; }
        public double prbg_EmbalagemProdutoFator_Estoque { get; set; }


        public TbProdutoBlueSoftGtins() { }
        public TbProdutoBlueSoftGtins(DataRow i)
        {
            prbg_cdbarra_pk = i["prbg_cdbarra_pk"].ToString();
            prb_CdProdutoBlueSoft = Convert.ToInt32(i["prb_CdProdutoBlueSoft"].ToString());
            prbg_Embalagem = i["prbg_Embalagem"].ToString();
            prbg_EmbalagemDescricao = i["prbg_EmbalagemDescricao"].ToString();
            prbg_EmbalagemProdutoFator_Estoque = Convert.ToDouble(i["prbg_EmbalagemProdutoFator_Estoque"]);



        }
    }
}
