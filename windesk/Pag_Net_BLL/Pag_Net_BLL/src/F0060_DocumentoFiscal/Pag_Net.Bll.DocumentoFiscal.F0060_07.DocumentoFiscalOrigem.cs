using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.F0060_DocumentoFiscal._07_DocumentoFiscalOrigem
{
    public static class RedShift
    {
        public static string get(
            DateTime data_inicial, 
            DateTime data_final
            )
        {

            string _redshift_get = string.Format(
                                 "   select      a.nf_key          as df_nf_seq_blue, "   +
                                 "               a.origem_nf_key   as df_nf_seq_blue_origem " + 
                                 "   from        nota_fiscal_origem            a " + 
                                 "   inner join  nota_fiscal nf on nf.nf_key = a.nf_key " + 
                                 "   inner join  nota_fiscal no on no.nf_key = a.origem_nf_key " + 
                                 "   where       1 = 1  " + 
                                 "     and ( " +
                                 "               (  nf.data_emissao >= '{0}' and  nf.data_emissao <= '{1}' ) " +
                                 "            or (  no.data_emissao >= '{0}' and  no.data_emissao <= '{1}' )  " +
                                 " ) ",
                                                        data_inicial.ToString("yyyy-MM-dd"), 
                                                        data_final.ToString("yyyy-MM-dd")
                                   );
            return _redshift_get;
        }
    }

    public static class Postgre
    {
  
        public static string Post(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
				string _SqlCommand,
				bool _Api ,
                Pag_Net.Bll.F0060_DocumentoFiscal.Db.DocumentoFiscalOrigem DB
            )
        {

            try
            {
                string _sql_post = string.Format(  "SELECT " + 
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0060_07_DocumentoFiscalOrigem)  + 
                                                   "   ( 'DBINSERT'  " +                 
                                                   "          ,  {0}         " +        
                                                   "          ,  {1}         " +
                                                   "          ,  {2}         ) ",
                                                   
                                                   	    DB.Df_nf_origem_seq.ToString()
                                                   ,    DB.Df_nf_seq_blue.ToString()
                                                   , DB.Df_nf_seq_blue_origem.ToString()  
                                            );

                return _sql_post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    
    }

  
}








