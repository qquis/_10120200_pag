using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class F0130_36_Controle_Reg_Transporte_CRUD
    {
        private static string _VERSION() { return "f0130_36_1011915_controle_reg_transporte_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbControle_Reg_Transporte TRANSPORTE
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, {4}, {5})",
                    BDCommnadType.ToString(),
                    TRANSPORTE.controle_reg_seq.ToString(),
                    TRANSPORTE.controle_reg_transp_seq.ToString(), 
                    TRANSPORTE.veiculo_seq.ToString(), 
                    TRANSPORTE.pallet_qtde.ToString(), 
                    TRANSPORTE.pallet_valor_unitario.ToString("0.00").Replace(",",".")
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


