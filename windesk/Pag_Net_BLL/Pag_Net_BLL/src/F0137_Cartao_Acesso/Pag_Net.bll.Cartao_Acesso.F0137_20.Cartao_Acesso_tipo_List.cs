using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class f0137_20_CartaoAcessoTipoList
    {



        public f0137_20_CartaoAcessoTipoList()
        {

        }

        private string _VERSION() { return "f0137_20_1011922_cartao_acesso_tipo_list"; }
        public string PostGre_Get_Function()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() + "()");

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}