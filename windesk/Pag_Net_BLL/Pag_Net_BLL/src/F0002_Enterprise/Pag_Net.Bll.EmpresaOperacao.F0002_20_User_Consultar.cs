using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0002_Enterprise.F0002_20_Empresa_Operacao_User_consulta
{

    public class filter
    {
        public int sis_ac_cd { get; set; }


        public filter(

            int _sis_ac_cd
            
            )
        {


            sis_ac_cd = _sis_ac_cd;

        }
    }

    public static class RedShift
    {
        public static string get()
        {
            return "";
        }
    }

    public static class Postgre
    {
        public static string Get(
             Pag_Net.Bll.F0002_Enterprise.F0002_20_Empresa_Operacao_User_consulta.filter _filter, 
             Pag_Net.Models.modelSistemaUsuario InfoSysUserInfo 
            )
        {
            try
            {
                string _PostGre = string.Format("SELECT * FROM " +
                    Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0002_20_Empresa_Operacao_User_Consulta) + "( {0}, {1}) ",
                            InfoSysUserInfo.sis_us_seq.ToString(), 
                            _filter.sis_ac_cd.ToString()
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
