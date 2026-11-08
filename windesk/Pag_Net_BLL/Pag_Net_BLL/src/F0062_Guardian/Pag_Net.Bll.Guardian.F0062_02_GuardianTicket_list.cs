using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0062_Guardian.F0062_02_GuardianTicket_List
{
    public static class Postgre
    {

        public static string Get(Pag_Net.Bll.F0062_Guardian.Filter _filter)
        {
            try
            {
                string _PostGre = string.Format("SELECT * FROM " +
                    Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0062_02_GuardianTicket_List)
                                 + "( '{0}', {1}, '{2}', '{3}', '{4}' ) ",
                                 _filter.gtk_uuid.ToString(), 
                                 _filter.gtk_numero.ToString(), 
                                 _filter.gtk_placa.ToString(), 
                                 _filter.gtk_data_inicial.ToString("yyyy-MM-dd"), 
                                 _filter.gtk_data_final.ToString("yyyy-MM-dd")
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
