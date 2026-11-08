using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_53_Controle_Reg_Pessoa_Consultar
    {
        private static string _VERSION() { return "f0130_53_1011922_controle_reg_pessoa_consultar"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            int CONTROLE_REG_SEQ ,
            int CONTROLE_PESSOA_CD, 
            string PESSOAS_DE_CPFCNPJ 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("( {0}, {1}, '{2}' )",
                    CONTROLE_REG_SEQ.ToString(),
                    CONTROLE_PESSOA_CD.ToString(),
                    PESSOAS_DE_CPFCNPJ.ToString().Trim()
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


