using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.tbs
{
    public class TbProdutoEmbalagem
    {

        public int pr_cdproduto { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string pre_embalagem { get; set; }
        public string prb_embalagemestoque { get; set; }
        public double pre_fatorestoque { get; set; }
        public double pre_fatorpreco { get; set; }
        public string prb_descricao { get; set; }
        public string label_prb_status { get; set; }
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public DateTime dtlog_update_api { get; set; }
        //public string prb_cdbarra_principal { get; set; }
        //public string prbt_pis_saida_cst { get; set; }
        //public double prbt_pis_saida_aliquota { get; set; }
        //public string prbt_pis_cofins_cst { get; set; }
        //public double prbt_pis_cofins_aliquota { get; set; }
        //public string prbt_icms_saida_cst { get; set; }
        //public double prbt_icms_aliquota_interna { get; set; }
        //public double prbt_icms_reducao { get; set; }
        //public string prbt_ncm { get; set; }
        //public string prbt_cest { get; set; }
        //public string pre_embalagem_descricao { get; set; }


        public TbProdutoEmbalagem() { }
        public TbProdutoEmbalagem(DataRow i) { _binding(i); }
        public void _constructor()
        {
            pr_cdproduto = 0;
        }

        public void _binding(DataRow i)
        {
            try
            {
                pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"].ToString());
                prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
                pre_embalagem = Convert.ToString(i["pre_embalagem"].ToString());
                prb_embalagemestoque = Convert.ToString(i["prb_embalagemestoque"].ToString());
                pre_fatorestoque = Convert.ToDouble(i["pre_fatorestoque"].ToString());
                pre_fatorpreco = Convert.ToDouble(i["pre_fatorpreco"].ToString());
                prb_descricao = Convert.ToString(i["prb_descricao"].ToString());
                label_prb_status = Convert.ToString(i["label_prb_status"].ToString());
                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
                dtlog_update_api = Convert.ToDateTime(i["dtlog_update_api"].ToString());
                //prb_cdbarra_principal = Convert.ToString(i["prb_cdbarra_principal"].ToString());
                //prbt_pis_saida_cst = Convert.ToString(i["prbt_pis_saida_cst"].ToString());
                //prbt_pis_saida_aliquota = Convert.ToDouble(i["prbt_pis_saida_aliquota"].ToString());
                //prbt_pis_cofins_cst = Convert.ToString(i["prbt_pis_cofins_cst"].ToString());
                //prbt_pis_cofins_aliquota = Convert.ToDouble(i["prbt_pis_cofins_aliquota"].ToString());
                //prbt_icms_saida_cst = Convert.ToString(i["prbt_icms_saida_cst"].ToString());
                //prbt_icms_aliquota_interna = Convert.ToDouble(i["prbt_icms_aliquota_interna"].ToString());
                //prbt_icms_reducao = Convert.ToDouble(i["prbt_icms_reducao"].ToString());
                //prbt_ncm = Convert.ToString(i["prbt_ncm"].ToString());
                //prbt_cest = Convert.ToString(i["prbt_cest"].ToString());
                //pre_embalagem_descricao = i["pre_embalagem_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        
    }
}
