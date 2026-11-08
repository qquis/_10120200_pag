using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0030
{
    public static class Select
    {
        public static DataTable get(
                Pag_Net.Models.modelSistemaUsuario MyConnect
            ,   F0020_Produto.Defaut_Filter Filter_Produto        
            ,   int _tab_pre_cd
            ,   bool SelecionaDataEntradaCusto 
            ,   DateTime DataEntradaCusto_Inicial
            ,   DateTime DataEntradaCusto_Final
            )
        {
            try
            {
                string SQL_POSTGRE = "";

                SQL_POSTGRE = string.Format("SELECT * FROM f0030_50_1011970_estoquecusto_list({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}')",
                                                         Filter_Produto.CdProduto.ToString(),
                                                         Filter_Produto.CdProdutoBluesoft .ToString(),
                                                         Filter_Produto.Seleciona_Data_Cadastro.ToString(),
                                                         Filter_Produto.Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                         Filter_Produto.Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                         Filter_Produto.Descricao,
                                                         Filter_Produto.Descricao_Fiscal,
                                                         Filter_Produto.Status_Ativo.ToString(),
                                                         Filter_Produto.Status_Inativo.ToString(),
                                                         Filter_Produto.Prd_cddepartamento.ToString(),
                                                         Filter_Produto.Prd_cdsecao.ToString(),
                                                         Filter_Produto.Prd_cdgrupo.ToString(),
                                                         Filter_Produto.Prd_subcdgrupo.ToString(),
                                                         _tab_pre_cd.ToString(), 
                                                         SelecionaDataEntradaCusto.ToString(), 
                                                         DataEntradaCusto_Inicial.ToString("yyyy-MM-dd"), 
                                                         DataEntradaCusto_Final.ToString("yyyy-MM-dd")
                                                         );
         

                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DT.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}













