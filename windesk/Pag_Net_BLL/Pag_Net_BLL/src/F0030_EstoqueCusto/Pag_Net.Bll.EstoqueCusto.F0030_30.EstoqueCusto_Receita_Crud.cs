using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public static class f0030_30_tbestoquecusto_receita_crud
    {
        private static string _VERSION() { return "f0030_30_1011970_tbestoquecusto_receita_crud"; }
        public static string Post(
            BDCommandTypes BDCommnadType,
            TbEstoqueCusto_Receita item
            )
        {
            try
            {
                string SELECT = String.Format("SELECT  " + _VERSION() + " ('{0}', {1}, {2}, {3}, {4})",
                                              BDCommnadType,
                                              item.pr_cdproduto.ToString(),
                                              item.prb_cdprodutobluesoft.ToString(),
                                              item.ecr_peso_total_item.ToString("0.00").Replace(",","."),
                                              item.ecr_valor_peso_por_embalagem.ToString("0.00").Replace(",", "."));
                return SELECT;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
