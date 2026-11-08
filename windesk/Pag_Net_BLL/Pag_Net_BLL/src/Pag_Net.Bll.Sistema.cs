using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Sistema
{
    public static class Parametros
    {
        public static string Value (Pag_Net.Models.modelSistemaUsuario Myconnect, int vsis_pr_cd)
        {

            string _VALOR = "";
            try 
            {
                 _VALOR = Pag_Net.Bll.R0006.Select.get_DataTable(Myconnect, vsis_pr_cd).Rows[0]["sis_pr_value"].ToString();
                 return _VALOR;
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.Bll.Sistema.Parametros: " + ex.Message);
            }
           
        }
    }
}
