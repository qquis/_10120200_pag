using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class TbProdutoBlueSoftComposicao
    {

        public int prb_CdProdutoBlueSoft { get; set; }
        public int prb_CdProdutoBlueSoft_Unitario { get; set; }
        public double prbc_qtde { get; set; }
        public string prbc_descricao { get; set; }
        public double prbc_percentual_composicao { get; set; }
        public int prbc_bluesoft_seq { get; set; }
        public DateTime prbc_data { get; set; }

        public TbProdutoBlueSoftComposicao() { }
        public TbProdutoBlueSoftComposicao(DataRow i)
        {
            prb_CdProdutoBlueSoft = Convert.ToInt32(i["prb_CdProdutoBlueSoft"]);
            prb_CdProdutoBlueSoft_Unitario = Convert.ToInt32(i["prb_CdProdutoBlueSoft_Unitario"]);
            prbc_qtde = Convert.ToDouble(i["prbc_qtde"]);
            prbc_descricao = i["prbc_descricao"].ToString();
            prbc_percentual_composicao = Convert.ToDouble(i["prbc_percentual_composicao"].ToString());
            prbc_bluesoft_seq = Convert.ToInt32(i["prbc_bluesoft_seq"].ToString());
            prbc_data = Convert.ToDateTime(i["prbc_data"].ToString());
        }
    }
}
