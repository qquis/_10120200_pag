using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_01
{
    public static class Postgres
    {
        public static string post(
        Pag_Net.Models.modelSistemaUsuario MyConnect
    ,	int  controle_reg_numero	
	,	DateTime controle_reg_data		
	,	int controle_cd			    
	
     )
        {
            try
            {

                string SQL_POST = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0130_01) +
                                          "(   'DBINSERT' " +
                                          "  ,  {0}     " +
                                          "  ,  {1}     " +
                                          "  , '{2}'    " +
                                          "  ,  {3}     ) ",
                                         MyConnect.SEQUENCIAL_DE_PROCESSO.ToString()
                                       , controle_reg_numero.ToString()
                                       , controle_reg_data.ToString("yyyy-MM-dd")
                                       , controle_cd.ToString()
                                       );
                return SQL_POST;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}