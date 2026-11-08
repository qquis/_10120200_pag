using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.scripts
{
    public class f0045_10_Report_TabelaPreco
    {
        public static string _VERSION() { return "f0045_10_1012003_report_tabelapreco"; }
        public static string Get()
        {
            string SQL = "SELECT * FROM " + _VERSION() + "()";

            return SQL;
        }
    }
}
