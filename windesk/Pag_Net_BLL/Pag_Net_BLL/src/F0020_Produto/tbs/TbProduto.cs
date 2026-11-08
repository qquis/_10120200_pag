using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.F0020_Produto.tbs
{
    public class TbProduto
    {
        public int pr_cdproduto { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string pr_descricao { get; set; }
        public string pr_embalagemestoque { get; set; }
        public DateTime prb_dt_cadastro { get; set; }
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public DateTime dtlog_update_api { get; set; }
        public bool pr_cesta { get; set; }
        public bool pr_status { get; set; }

        public double prb_pesobruto { get; set; }
        public double prb_pesoliquido { get; set; }


        public TbProduto() { _constructor(); }
        public TbProduto(DataRow i) { _binding(i);}
        public void _binding(DataRow i)
        {
            try
            {
                pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"]);
                prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"]);
                pr_descricao = i["pr_descricao"].ToString();
                pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
                prb_dt_cadastro = Convert.ToDateTime(i["prb_dt_cadastro"]);

                prb_pesobruto = Convert.ToDouble(i["prb_pesobruto"].ToString());
                prb_pesoliquido = Convert.ToDouble(i["prb_pesoliquido"].ToString());

                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"]);
                dtlog_update = Convert.ToDateTime(i["dtlog_update"]);
                dtlog_update_api = Convert.ToDateTime(i["dtlog_update_api"]);

                pr_cesta = false;
                pr_cesta = Pag_Net.Models.BDTools.boolColumnResult(i["pr_cesta"].ToString());

                pr_status = false;
                pr_status = Pag_Net.Models.BDTools.boolColumnResult(i["pr_status"].ToString());

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
                pr_cdproduto = 0;
                prb_cdprodutobluesoft = 0;
                pr_descricao = "";
                pr_embalagemestoque = "";
                prb_dt_cadastro = Convert.ToDateTime("1900-01-01");
                pr_cesta = false;
                pr_status = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
