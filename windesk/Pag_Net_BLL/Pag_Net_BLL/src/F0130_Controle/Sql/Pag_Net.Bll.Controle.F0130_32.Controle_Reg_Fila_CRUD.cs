using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class F0130_32_Controle_Reg_Fila_CRUD
    {
        private static string _VERSION() { return "f0130_32_1011915_controle_reg_fila_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbControle_Reg_Fila Controle_Reg_Fila
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3})",
                    BDCommnadType.ToString(),
                    Controle_Reg_Fila.controle_reg_fila_seq.ToString(),
                    Controle_Reg_Fila.controle_reg_seq.ToString(),
                    Controle_Reg_Fila.controle_fila_cd.ToString()
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


