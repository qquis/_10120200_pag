using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0060_DocumentoFiscal._09_DocumentoFiscalStatusRecebimento
{
 
    public static class Postgre
    {

        public static string Post()
        {

            try
            {
                string _sql_post = string.Format("SELECT " +
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_09_documentofiscalregistro_status_recebimento) + "()" );

                return _sql_post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }


}





