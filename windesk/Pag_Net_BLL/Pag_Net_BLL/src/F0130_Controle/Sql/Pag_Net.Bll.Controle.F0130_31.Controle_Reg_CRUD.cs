using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class F0130_31_Controle_Reg_CRUD
    {

        private static string _VERSION() { return "f0130_31_1011915_controle_reg_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbControle_Reg Controle_Reg
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, '{3}', {4})",
                    BDCommnadType.ToString(),
                    MyConnect.SEQUENCIAL_DE_PROCESSO.ToString(),
                    Controle_Reg.controle_reg_numero.ToString(), 
                    Controle_Reg.controle_reg_data.ToString("yyyy-MM-dd"), 
                    Controle_Reg.controle_cd.ToString()
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


