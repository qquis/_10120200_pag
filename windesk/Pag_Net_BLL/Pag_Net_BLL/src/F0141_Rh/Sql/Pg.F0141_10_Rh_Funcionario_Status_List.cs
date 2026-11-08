using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;


namespace Pag_Net.Bll.F0141_Rh
{
    public class F0147_10_RhFuncionarioStatusList
    {
   
        public int rh_funcionario_status_cd { get; set; }

        public F0147_10_RhFuncionarioStatusList()
        {
            rh_funcionario_status_cd = 0;
        }
        public F0147_10_RhFuncionarioStatusList(
             int _rh_funcionario_status_cd

            )
        {
            rh_funcionario_status_cd = _rh_funcionario_status_cd;
   
        }

        private string _VERSION() { return "f0141_10_1011925_rh_funcionario_status_list"; }
        public string sql_Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0})",
                    rh_funcionario_status_cd.ToString() ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
