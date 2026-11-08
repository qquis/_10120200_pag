using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0001_Sistema
{
    public static class F0001_10_Login_acesso_list
    {
        private static string _VERSION() { return "f0001_10_1011915_login_acesso_list"; }
        public static string Get(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            int sis_id , 
			string email_main ,
			string user_name , 
			string password 


            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + string.Format("({0}, '{1}', '{2}', '{3}')", 
                    sis_id.ToString(), 
					email_main.ToString(), 
					user_name.ToString(), 
					password.ToString()
                    ));
                return SQL_POSTGRE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
