using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0001_Sistema.sql
{
    public class F0001_10_Login_Acesso_List
    {
        //private static string _VERSION() { return "f0001_10_1012009_login_acesso_list"; }
        private static string _VERSION() { return "f0001_10_1012017_sistema_login_acesso_list"; }
        public static string Post( Pag_Net.Models.modelSistemaUsuario MyConnect )
        {
            try
            {
                /*
                string SQL_POSTGRE = "SELECT * FROM " + _VERSION() + 
                          " (	    vsis_id:= " + MyConnect.sis_cd.ToString() + 
	                      "     ,   vemail_main:= ''" + 
	                      "     ,   vuser_name:= '" + MyConnect.user_name.ToString() + "'" + 
	                      "     ,   vpasswd:= '" + MyConnect.passwd.ToString() + "'" +  
                          " ) "; */

                
                string SQL_POSTGRE = "SELECT * FROM " + _VERSION() +
                          " (	    vusuario_login_uuid:= '" + MyConnect.myBackEndLogin.usuario_login_uuid.ToString() + "'" + 
                          " ) ";

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
