using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public static class F0030_50_EstoqueCusto_list
    {

        private static string _VERSION() { return "f0030_50_1011970_estoquecusto_list"; }
        public static string Get( F0030_EstoqueCusto.Filter_Custo_Select Filter    )
        {
            try
            {
                string SQL_POSTGRE = "";

                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + " ({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}')",
                                                         Filter.CdProduto.ToString(),
                                                         Filter.CdProdutoBluesoft.ToString(),
                                                         Filter.Seleciona_Data_Cadastro.ToString(),
                                                         Filter.Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                         Filter.Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                         Filter.Descricao,
                                                         Filter.Descricao_Fiscal,
                                                         Filter.Status_Ativo.ToString(),
                                                         Filter.Status_Inativo.ToString(),
                                                         Filter.Prd_cddepartamento.ToString(),
                                                         Filter.Prd_cdsecao.ToString(),
                                                         Filter.Prd_cdgrupo.ToString(),
                                                         Filter.Prd_subcdgrupo.ToString(),
                                                         Filter.Tab_pre_cd.ToString(),
                                                         Filter.SelecionaDataEntradaCusto.ToString(),
                                                         Filter.DataEntradaCusto_Inicial.ToString("yyyy-MM-dd"),
                                                         Filter.DataEntradaCusto_Final.ToString("yyyy-MM-dd")
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