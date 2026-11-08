using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0021_ProdutoBlueSoft;

namespace Pag_Net.Bll.F0065_Forca_Venda
{
    public class F0065_15_ForcaVenda_TabPreco_CRUD
    {
        private static string _VERSION() { return "f0065_15_1011980_forca_venda_tabpreco_CRUD"; }
        public static string Post(
            BDCommandTypes BDCommnadType
	      ,	int fv_tabelapreco_cd 
	      ,	string fv_tabelapreco_descricao
          ,  int fv_tabelapreco_status
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = "SELECT " + _VERSION() + " ( " +
                              "   sqlcommand:= '" + BDCommnadType.ToString() + "'" + 
                              " , vfv_tabelapreco_cd:= " + fv_tabelapreco_cd.ToString() +
                              " , vfv_tabelapreco_descricao:= '" + fv_tabelapreco_descricao.ToString() + "'" +
                              " , vfv_tabelapreco_status:= " + fv_tabelapreco_status.ToString() +
                                       "       ); ";
                                             
                    

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static string RedShift_Select()
        {
            string SQL = "select   tabela_preco_venda_key as fv_tabelapreco_cd " +
                         "       , descricao as fv_tabelapreco_descricao " +
                         "       , ativo as fv_tabelapreco_status" +
                         " from tabela_preco_venda";
            //"        where pessoa_key = 1 ";
            return SQL;

        }
    }
}
