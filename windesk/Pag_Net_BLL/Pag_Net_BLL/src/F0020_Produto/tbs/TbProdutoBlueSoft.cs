using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.F0020_Produto.tbs
{
    public class TbProdutoBlueSoft
    {
        public int prb_cdprodutobluesoft { get; set; }
        public string prb_descricao { get; set; }

        public TbProdutoBlueSoft() { _constructor(); }
        public TbProdutoBlueSoft(DataRow i) { _binding(i); }
        public double prb_pesobruto { get; set; }
        public double prb_pesoliquido { get; set; }

        public void _binding(DataRow i)
        {
            try
            {
                prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"]);
                prb_descricao = i["prb_descricao"].ToString();

                prb_pesobruto = Convert.ToDouble(i["prb_pesobruto"].ToString());
                prb_pesoliquido = Convert.ToDouble(i["prb_pesoliquido"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _constructor() 
        {
            try
            {
                prb_cdprodutobluesoft = 0;
                prb_descricao = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
