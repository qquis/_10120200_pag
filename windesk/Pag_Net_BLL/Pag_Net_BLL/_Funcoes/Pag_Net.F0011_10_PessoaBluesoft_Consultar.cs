using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_10
{
    public static class PostGre
    {
        public static string Get(filter filter)
        {
            return string.Format("SELECT * from " +
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0011_10_tbpessoabluesoft_consultar) +
                                                   "   (         {0}     )",
                                                    filter.CdPesssoaBlueSoft.ToString());

        }
    }


    public class filter
    {
        public int CdPesssoaBlueSoft { get; set; }
        public filter() { }
        public filter( int _CdPesssoaBlueSoft) {
            CdPesssoaBlueSoft = _CdPesssoaBlueSoft;
        }
    }

}
