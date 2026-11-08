using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0011;
using Pag_Net.Models;

namespace Pag_Net.Bll.F0110_01
{
    public static class Postgres
    {
        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect
        , string _SqlCommand
        , bool _Api
        , string  voucher_cd
        , string cpf_cnpj
        , string documento_cnh
        , int Tipo_Voucher
                )
        {
            try
            {



                string SQL_POST = string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0110_01) +
                                          "(   'DBINSERT' " +
                                          "  , '{0}'  " + 
                                          "  , '{1}'  " +
                                          "  , '{2}'  " + 
                                          "  ,  {3} ) ",
                                         voucher_cd.ToString()
                                       , cpf_cnpj.ToString()
                                       , documento_cnh == null ? "" : documento_cnh.ToString().Replace("'", "")
                                       , Tipo_Voucher.ToString()
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

