using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0021_ProdutoBlueSoft;

namespace Pag_Net.Bll.F0021_ProdutoBlueSoft
{
    public class F0021_02_ProdutoBlueSoftGtins_CRUD
    {
        private static string _VERSION() { return "f0021_02_1012006_produtobluesoft_gtins_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbProdutoBlueSoftGtins item
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + _VERSION() + " ('{0}', '{1}', {2}, '{3}', '{4}', '{5}')",
                                             BDCommnadType.ToString(),
                                             item.prbg_cdbarra_pk,
                                             item.prb_CdProdutoBlueSoft,
                                             item.prbg_Embalagem,
                                             item.prbg_EmbalagemDescricao.Replace("'", ""),
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
            string SQL = "   SELECT    " +
                        "             i.barra_key                prbg_cdbarra_pk " +
                        "           , p.produto_key             prb_cdprodutobluesoft " +
                        "           , e.embalagem_key           prbg_Embalagem " +
                        "           , e.nome                    prbg_EmbalagemDescricao " +
                        "           , p.fator_estoque           prbg_EmbalagemProdutoFator_Estoque " +
                        "           , CASE WHEN len(i.barra_key) = 8  THEN 'EAN8' " +
                        "                  WHEN len(i.barra_key) = 13 THEN 'EAN13' " +
                        "                  WHEN len(i.barra_key) = 14 THEN 'DUN14' " +
                        "             ELSE 'PLU' END           prbg_tipo " +
                        "   FROM item i   " +
                        "   left JOIN produto_d p on i.produto_key = p.produto_key  " +
                        "   left JOIN embalagem e ON e.embalagem_key = p.embalagem_key  " +
                        "   WHERE p.produto_key > 0 " +
                        "     and coalesce(i.barra_key, 0) != 0 ";
            return SQL;

        }
    }
}
