using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{
    public static class F0135_01_Transporte_Ctrl_CRUD
    {
        private static string _VERSION() { return "f0135_01_1011970_transporte_ctrl_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbTransporte_Ctrl TRANSPORTE_CTRL
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, {4}, {5})",
                    BDCommnadType.ToString(),
                    TRANSPORTE_CTRL.controle_reg_seq.ToString(),
                    TRANSPORTE_CTRL.tranporte_Ctrl_Seq.ToString(),
                    TRANSPORTE_CTRL.veiculo_seq.ToString(),
                    TRANSPORTE_CTRL.pallet_qtde.ToString(),
                    TRANSPORTE_CTRL.pallet_valor_unitario.ToString("0.00").Replace(",", ".")
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


