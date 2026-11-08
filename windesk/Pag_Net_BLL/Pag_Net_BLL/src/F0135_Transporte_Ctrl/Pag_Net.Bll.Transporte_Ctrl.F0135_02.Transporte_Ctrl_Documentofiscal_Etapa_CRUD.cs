using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{
    public static class F0135_02_Transporte_Ctrl_Documentofiscal_Etapa_CRUD
    {
        private static string _VERSION() { return "f0135_02_1011915_transporte_ctrl_documentofiscal_etapa_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            Tbtransporte_Ctrl_DocumentoFiscal_Etapa TBTRANSPORTE_CTRL_DOCUMENTOFISCAL_ETAPA
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3})",
                    BDCommnadType.ToString(),
                    TBTRANSPORTE_CTRL_DOCUMENTOFISCAL_ETAPA.controle_reg_seq.ToString(),
                    TBTRANSPORTE_CTRL_DOCUMENTOFISCAL_ETAPA.controle_reg_etapa_seq.ToString(),
                    TBTRANSPORTE_CTRL_DOCUMENTOFISCAL_ETAPA.dfr_seq.ToString()
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


