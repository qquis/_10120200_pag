using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh._02_funcionario_ctrl_crud
{
    public static class RedShift
    {
        public static string get()     
        {
            return "";
        }
    }

    public static class Postgre
    {

        public static string Post(
            
            Pag_Net.Bll.F0141_Rh.TbRhFuncionarioCtrl Db
            )
        {
            try
            {
               string _PostGre = string.Format("SELECT * FROM " + 
                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0141_02_rh_funcionario_ctrl_crud) + "( {0}, '{1}', {2}, {3}, {4} ) ",
                                Db.rh_funcionario_ctrl_seq.ToString(),
                                Db.rh_funcionario_ctrl_data.ToString("yyyy-MM-dd"),
                                Db.rh_funcionario_ctrl_tipo.ToString(),
                                Db.rh_funcionario_cd.ToString(), 
                                Db.controle_reg_seq.ToString()
                   );
               return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
