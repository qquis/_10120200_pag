using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0020_Produto
{
    public static class F0020_12_ProdutoEmbalagemGtins_Consultar
    {



        private static string _VERSION() { return "F0020_12_1011924_ProdutoEmbalagemGtins_Consultar"; }
        public static string Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Defaut_Filter _Filters

            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("select * from " + _VERSION() + " ({0} , {1}) ",
                                                      _Filters.CdProduto.ToString(),
                                                      _Filters.CdProdutoBluesoft.ToString()
                                                );
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}