using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0105_Zanthus.F0105_20_Zanthus_Voucher_Cli_Consultar
{
    public static class Postgre
    {
        public static string Get(
             Pag_Net.Bll.F0105_Zanthus.Filter_Zanthus _filter
            )
        {
                string _PostGre = string.Format("SELECT * FROM " +
                    Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0105_20_zanthus_voucher_cli_consultar) + "( '{0}', '{1}', '{2}' ) ",
                        _filter.voucher.ToString(),
                        _filter.voucher_data.ToString("yyyy-MM-dd"),
                        _filter.voucher_cliente.ToString()
                    );
                return _PostGre;
       
        }

    }

}
