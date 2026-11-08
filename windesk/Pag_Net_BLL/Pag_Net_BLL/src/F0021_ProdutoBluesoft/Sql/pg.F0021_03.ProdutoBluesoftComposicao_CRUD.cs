using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0021_ProdutoBlueSoft;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class F0021_03_ProdutoBlueSoftComposicao_CRUD
    {
        private static string _VERSION() { return "f0021_03_1011924_produtobluesoftcomposicao_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbProdutoBlueSoftComposicao item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + _VERSION() + "('{0}', {1}, {2}, {3}, '{4}', {5}, {6}, '{7}', '{8}')",
                                             BDCommnadType.ToString(),
                                             item.prb_CdProdutoBlueSoft,
                                             item.prb_CdProdutoBlueSoft_Unitario,
                                             item.prbc_qtde.ToString().Replace(",", "."),
                                             item.prbc_descricao.Replace("'", ""),
                                             item.prbc_percentual_composicao.ToString().Replace(",", "."),
                                             item.prbc_bluesoft_seq.ToString(),
                                             item.prbc_data.ToString("yyyy-MM-dd"),
                                             "false");

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {
            string SQL = "   select       produto_final                   as prb_cdprodutobluesoft_unitario  " +
                               "              , produto_parte                   as prb_cdprodutobluesoft           " +
                               "              , quantidade                      as prbc_qtde                       " +
                               "              , 'kits'                          as prbc_descricao                  " +
                               "              , percentual_do_item_na_compra    as prbc_percentual_composicao      " +
                               "              , composicao_key                  as prbc_bluesoft_seq               " +
                               "              , ultima_alteracao                as prbc_data                       " +
                               "      from      composicao " +
                               "      where     1 = 1 " +
                               "        AND     ISNULL(percentual_do_item_na_compra, 0) > 0 ";
            /*
                         "      group by  produto_final  " +
                         "              , produto_parte " +
                         "              , quantidade " +
                         "              , percentual_do_item_na_compra ";*/
            return SQL;

        }
    }
}
