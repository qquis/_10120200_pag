using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{
    public class F0210_50_Notificacao_Procedimento
    {
        private static string _VERSION() { return "f0210_50_1011997_notificacao_procedimento"; }
        public static string Post(
            int notificacao_cd, 
            string texto
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, '{1}')",
                        notificacao_cd.ToString() , texto
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
