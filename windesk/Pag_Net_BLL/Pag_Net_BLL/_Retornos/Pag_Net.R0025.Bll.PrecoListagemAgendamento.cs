using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0025
{
    public static class Select
    {
        public static DataTable get(
                   Pag_Net.Models.modelSistemaUsuario MyConnect
            ,   int _cdProduto
            ,   int _cdProdutoBluesoft
            ,   bool _selecionaDataCadastro
            ,   DateTime _dt_cadastro_ini
            ,   DateTime _dt_cadastro_fim
            ,   string _descricao 
            ,   string _descricao_fiscal
            ,   bool Status_Ativo
            ,   bool Status_Inativo
            ,   int _prd_cddepartamento
            ,   int _prd_cdsecao
            ,   int _prd_cdgrupo
            ,   int _prd_subcdgrupo
            ,   int _tab_pre_cd
            ,   bool Unitario 
            ,   int proc_log_seq
            ,   DateTime dt_agendamento_inicial
            ,   DateTime dt_agendamento_final
            )
        {

            try
            {
                string SQL_POSTGRE = "";

                SQL_POSTGRE = string.Format("SELECT * FROM f0045_51_1012003_precoagendamentolistagem({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, " + (Unitario ? "'true'" : "'false'") + " , {14}, '{15}', '{16}' )",
                                                         _cdProduto.ToString(),
                                                         _cdProdutoBluesoft.ToString(),
                                                         _selecionaDataCadastro.ToString(),
                                                         _dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                         _dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                         _descricao,
                                                         _descricao_fiscal,
                                                         Status_Ativo.ToString(),
                                                         Status_Inativo.ToString(),
                                                         _prd_cddepartamento.ToString(),
                                                         _prd_cdsecao.ToString(),
                                                         _prd_cdgrupo.ToString(),
                                                         _prd_subcdgrupo.ToString(),
                                                         _tab_pre_cd.ToString(), 
                                                         proc_log_seq.ToString(), 
                                                         dt_agendamento_inicial.ToString("yyyy-MM-dd"),
                                                         dt_agendamento_final.ToString("yyyy-MM-dd")
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













