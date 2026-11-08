using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0130_Controle
{

    public static class F0130_35_Controle_Reg_Fin_CRUD
    {
        private static string _VERSION() { return "f0130_35_1011915_controle_reg_fin_CRUD"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType ,
            tbcontrole_reg_fin TbControle_Reg_Fin 
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, '{4}', {5}, {6}, {7}, '{8}', {9})",
                    BDCommnadType.ToString(),
                    TbControle_Reg_Fin.proc_log_seq.ToString(),				
                    TbControle_Reg_Fin.controle_reg_seq.ToString(),			
                    TbControle_Reg_Fin.controle_reg_fin_seq.ToString(),		
                    TbControle_Reg_Fin.controle_reg_fin_data.ToString("yyyy-MM-dd"),		
                    TbControle_Reg_Fin.autpgto_seq.ToString(),				
                    TbControle_Reg_Fin.fin_tipo_lancamento_cd.ToString(),		
                    TbControle_Reg_Fin.fin_forma_pgto_cd.ToString(),
                    TbControle_Reg_Fin.controle_reg_fin_descritivo.ToString(),
                    TbControle_Reg_Fin.controle_reg_fin_valor.ToString("0.00").Replace(",", ".")
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


