using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class F0137_70_Cartao_Acesso_Visitante_Numero
    {

        private string _VERSION() { return "f0137_70_1011922_cartao_acesso_visitante_numero"; }
        public string PostGre_Get_Function()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT " + _VERSION() + "()");

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}