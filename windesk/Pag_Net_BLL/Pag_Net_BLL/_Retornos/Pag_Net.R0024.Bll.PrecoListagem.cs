using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0024
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
            ,   bool ItensComPreco
            )
        {

            try
            {
                string SQL_POSTGRE = "";


                SQL_POSTGRE = string.Format("SELECT * FROM f0045_50_1012003_report_precolistagem( " +
                                "   vcdproduto:= " + _cdProduto.ToString() +
                                " , vcdprodutobluesoft:= " + _cdProdutoBluesoft.ToString() +
                                " , vseleciona_data_cadastro:= " + (_selecionaDataCadastro ? "1" : "0").ToString() +
                                " , vdt_cadastro_ini:= '" + _dt_cadastro_ini.ToString("yyyy-MM-dd") + "'" +
                                " , vdt_cadastro_fim:= '" + _dt_cadastro_fim.ToString("yyyy-MM-dd") + "'" +
                                " , vdescricao:= '" + _descricao.ToString() + "'" +
                                " , vdescricao_fiscal:= '" + _descricao_fiscal.ToString() + "'" +
                                " , vstatus_ativo:= " + (Status_Ativo ? "1" : "0").ToString() +
                                " , vstatus_inativo:= " + (Status_Inativo ? "1" : "0").ToString() +
                                " , vprd_cddepartamento:= " + _prd_cddepartamento.ToString() +
                                " , vprs_cdsecao:= " + _prd_cdsecao.ToString() +
                                " , vprg_cdgrupo:= " + _prd_cdgrupo.ToString() +
                                " , vprsg_cdsubgrupo:= " + _prd_subcdgrupo.ToString() +
                                " , vtab_pre_cd:= " + _tab_pre_cd.ToString() +
                                " , vunitario:= " + (Unitario ? "1" : "0").ToString() +
                                " , vproc_log_seq:= " + proc_log_seq.ToString() +
                                " , vitenscompreco:= " + (ItensComPreco ? "1" : "0").ToString() +
                                ")");
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













