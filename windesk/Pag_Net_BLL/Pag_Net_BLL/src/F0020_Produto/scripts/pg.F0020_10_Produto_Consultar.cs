using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0020_Produto
{
    public static class F0020_10_ProdutoConsultar
    {



        private static string _VERSION() { return "f0020_10_1011970_produto_consultar"; }
        public static string Get(Pag_Net.Models.modelSistemaUsuario MyConnect, Defaut_Filter _Filters

            )
        {
            try
            {
                string SQL_POSTGRE = string.Format("select * from " + _VERSION() + "( {0} , {1} ,{2}, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' )",
                                                                   _Filters.CdProduto.ToString(),
                                                                   _Filters.CdProdutoBluesoft.ToString(),
                                                                   _Filters.Seleciona_Data_Cadastro? "1": "0", 
                                                                   _Filters.Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                                   _Filters.Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                                   _Filters.Descricao,
                                                                   _Filters.Descricao_Fiscal,
                                                                   _Filters.Status_Ativo.ToString(),
                                                                   _Filters.Status_Inativo.ToString(),
                                                                   _Filters.Codigo_de_Barra.ToString()
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