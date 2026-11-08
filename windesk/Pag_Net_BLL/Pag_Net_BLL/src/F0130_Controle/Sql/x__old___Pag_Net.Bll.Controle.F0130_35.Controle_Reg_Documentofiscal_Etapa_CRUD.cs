using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class F0130_35_Controle_Reg_Documentofiscal_Etapa_CRUD
    {
        private static string _VERSION() { return "f0130_36_1011915_controle_reg_documentofiscal_etapa_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbControle_Reg_DocumentoFiscal_Etapa TbControle_Reg_DocumentoFiscal_Etapa
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, {4})",
                    BDCommnadType.ToString(),
                    TbControle_Reg_DocumentoFiscal_Etapa.controle_reg_seq.ToString(),
                    TbControle_Reg_DocumentoFiscal_Etapa.controle_reg_fila_seq.ToString(),
                    TbControle_Reg_DocumentoFiscal_Etapa.controle_reg_etapa_seq.ToString(), 
                    TbControle_Reg_DocumentoFiscal_Etapa.dfr_seq.ToString()
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


