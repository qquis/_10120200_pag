using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.R0028
{
    
     public static class Select
    {
        public static DataTable get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            F0020_Produto.Defaut_Filter Filter_Produto,
            int vproc_log_seq,
            bool SelecionaDataAlteracaoPreco,
            DateTime DataAlteracaoPreco_Inicial,
            DateTime DataAlteracaoPreco_Final

            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM r0028_01_1011857_precolistagem_etiqueta({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}', '{17}' )",
                                                         Filter_Produto.CdProduto.ToString(),
                                                         Filter_Produto.CdProdutoBluesoft.ToString(),
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
                                                         vproc_log_seq.ToString(),
                                                         Filter_Produto.Codigo_de_Barra.ToString(), 
                                                         SelecionaDataAlteracaoPreco.ToString(),
                                                         DataAlteracaoPreco_Inicial.ToString("yyyy-MM-dd"),
                                                         DataAlteracaoPreco_Final.ToString("yyyy-MM-dd")
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