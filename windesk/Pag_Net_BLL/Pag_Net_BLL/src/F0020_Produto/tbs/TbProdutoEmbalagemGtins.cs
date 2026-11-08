using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.tbs
{
    public class TbProdutoEmbalagemGtins
    {
        public int pr_cdproduto { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string pre_embalagem { get; set; }
        public string preg_cdbarra { get; set; }
        public string status_descricao { get; set; }
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public DateTime dtlog_update_api { get; set; }

        public TbProdutoEmbalagemGtins() { }
        public TbProdutoEmbalagemGtins(DataRow i) { _binding(i); }
        public void _contructor()
        {
            pr_cdproduto = 0;
        }
        
        public void _binding(DataRow i)
        {
            try
            {
                pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"].ToString());
                prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
                pre_embalagem = i["pre_embalagem"].ToString();
                preg_cdbarra = i["preg_cdbarra"].ToString();
                status_descricao = i["status_descricao"].ToString();
                dtlog_insert = Convert.ToDateTime(i["dtlog_insert"].ToString());
                dtlog_update = Convert.ToDateTime(i["dtlog_update"].ToString());
                dtlog_update_api = Convert.ToDateTime(i["dtlog_update_api"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
