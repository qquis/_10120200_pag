using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.rules
{
    public static class CentroDr_Fechamento
    {
        public static DataTable list (Pag_Net.Models.modelSistemaUsuario MyConnect , int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd)
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
        public static DataTable list (Pag_Net.Models.modelSistemaUsuario MyConnect, int _Competencia_cd, int _Cdr_cd, int _Cdr_subgrupo_cd, int _Cdr_fechamento_linha)
        {
            try
            {
                return Pag_Net.Bll.R0059.Select.Dt(MyConnect, _Competencia_cd, _Cdr_cd, _Cdr_subgrupo_cd, _Cdr_fechamento_linha);
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
    }
}
