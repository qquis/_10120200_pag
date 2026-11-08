using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0059
{
    public static class Select  
    {
        public static DataTable Dt(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int vcompetencia_cd
                , int vcdr_cd
                , int vcdr_subgrupo_cd
                , int vcdr_fechamento_linha
            
            )

        {

            try
            {
                string SQL_POSTGRE = string.Format("select * from r0059_0001_centrodr_fechamento({0} , {1}, {2}, {3})",
                                                      vcdr_cd
                                                    , vcdr_subgrupo_cd
                                                    , vcompetencia_cd
                                                    , vcdr_fechamento_linha
                                                      );

                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DX.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }




        public static DataTable list(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd, int _Cdr_fechamento_linha)
        {
            try
            {
                return Dt(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, _Cdr_fechamento_linha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable list(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {
                return list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public static double ReceitaOperecional(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {

                return Convert.ToDouble(list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 30).Rows[0]["cdr_valor"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double ReceitaOperecionalBruta(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {
                return Convert.ToDouble(list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 70).Rows[0]["cdr_valor"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double ReceitaComercial(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {
                return Convert.ToDouble(list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 90).Rows[0]["cdr_valor"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double ReceitaBase(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {
                return Convert.ToDouble(list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 130).Rows[0]["cdr_valor"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double ReceitaSemDespesasVariaveis(Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
        {
            try
            {
                return Convert.ToDouble(list(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, 130).Rows[0]["cdr_valor"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }



}


