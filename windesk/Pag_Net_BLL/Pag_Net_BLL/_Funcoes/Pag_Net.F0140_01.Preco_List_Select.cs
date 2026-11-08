using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;



namespace Pag_Net.Bll.F0140_01_Preco_List_Select
{

    

    public static class RedShift { }
    public static class Postgre 
    {
        public static string VERSION()
        {
            return "f0045_05_1012003_preco";
        }

        public static string Get(
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
            ,   bool _agendamento_consulta
            ,   DateTime _data_agendamento
            ,   bool _Seleciona_data_mov_entrada
            ,   DateTime _vdt_data_entrada_ini
            ,   DateTime _vdt_data_entrada_fim
            ,   int _pr_status_comercial_preco_inativo
            ,   int Tipo_Visuzalizacao_Custo

            )
        {

            string SQL_POSTGRE = "";

            try
            {
                SQL_POSTGRE = string.Format("Select * FROM " + VERSION() + "({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}', '{17}', '{18}', {19}, {20})",
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
                                                      _agendamento_consulta.ToString(),
                                                      _data_agendamento.ToString("yyyy-MM-dd"),
                                                      _Seleciona_data_mov_entrada,
                                                      _vdt_data_entrada_ini.ToString("yyyy-MM-dd"),
                                                      _vdt_data_entrada_fim.ToString("yyyy-MM-dd"),
                                                      _pr_status_comercial_preco_inativo,
                                                      Tipo_Visuzalizacao_Custo.ToString()


                    );
                return SQL_POSTGRE;
            }
            catch (Exception Ex)
            {
                throw new Exception("Pag_Net.F0140_01.Bll " + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "ScriptSQL: " + SQL_POSTGRE + Environment.NewLine +
                                    "-------------------------------------------------------------" + Environment.NewLine +
                                    "Erro Message: " + Ex.Message);
            }

        }

        
    
    }
    public class Db { }

}
