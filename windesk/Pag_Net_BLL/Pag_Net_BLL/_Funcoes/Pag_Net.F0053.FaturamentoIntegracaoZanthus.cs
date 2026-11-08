using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0053;


namespace Pag_Net.F0053.Bll.Migration
{
    public static class SqlServer
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                Pag_Net.Bll.Faturamento.Integration.Cupons(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0053 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.Bll.F0053
{

    public class Parametros
    {
      public      DateTime        fizanthus_data;
      public      int             fizanthus_sat_ecf;
      public      int             fizanthus_cupomfiscal;
      public      string          fizanthus_cupomfiscalid;
      public      int             fizanthus_notafiscal;
      public      int             fizanthus_notafiscal_serie;
      public      int             fizanthus_cupomfiscal_seqitem;
      public      string          fizanthus_cdbarra;
      public      double          fizanthus_qtde;
      public      double          fizanthus_valor;


        public Parametros(
            DateTime        FIZANTHUS_DATA,
            int             FIZANTHUS_SAT_ECF,
            int             FIZANTHUS_CUPOMFISCAL,
            string          FIZANTHUS_CUPOMFISCALID,
            int             FIZANTHUS_NOTAFISCAL,
            int             FIZANTHUS_NOTAFISCAL_SERIE,
            int             FIZANTHUS_CUPOMFISCAL_SEQITEM,
            string          FIZANTHUS_CDBARRA,
            double          FIZANTHUS_QTDE,
            double          FIZANTHUS_VALOR 
           )
        {
            fizanthus_data =                        FIZANTHUS_DATA;
            fizanthus_sat_ecf =                     FIZANTHUS_SAT_ECF;
            fizanthus_cupomfiscal =                 FIZANTHUS_CUPOMFISCAL;
            fizanthus_cupomfiscalid =               FIZANTHUS_CUPOMFISCALID;
            fizanthus_notafiscal =                  FIZANTHUS_NOTAFISCAL;
            fizanthus_notafiscal_serie =            FIZANTHUS_NOTAFISCAL_SERIE;
            fizanthus_cupomfiscal_seqitem =         FIZANTHUS_CUPOMFISCAL_SEQITEM;
            fizanthus_cdbarra =                     FIZANTHUS_CDBARRA;
            fizanthus_qtde =                        FIZANTHUS_QTDE;
            fizanthus_valor = FIZANTHUS_VALOR;

        }
    }

    public static class Postgres
    {
        
        public static string Post(Pag_Net.Bll.F0053.Parametros _PARAMETROS
            )
        {

            string _parametros = string.Format(
                                   " 	    " +
                                   "           'DBINSERT'        " +
                                   "       ,    '{0}'            " +
                                   "       ,     {1}             " +
                                   "       ,     {2}             " +
                                   "       ,    '{3}'            " +
                                   "       ,     {4}             " +
                                   "       ,     {5}             " +
                                   "       ,     {6}             " +
                                   "       ,    '{7}'            " +
                                   "       ,     {8}             " +
                                   "       ,     {9}             " +
                                   "       ,    'false'          ",
                                  _PARAMETROS.fizanthus_data.ToString("yyyy-MM-dd"),
                                  _PARAMETROS.fizanthus_sat_ecf,
                                  _PARAMETROS.fizanthus_cupomfiscal,
                                  _PARAMETROS.fizanthus_cupomfiscalid,
                                  _PARAMETROS.fizanthus_notafiscal,
                                  _PARAMETROS.fizanthus_notafiscal_serie,
                                  _PARAMETROS.fizanthus_cupomfiscal_seqitem,
                                  _PARAMETROS.fizanthus_cdbarra,
                                  _PARAMETROS.fizanthus_qtde.ToString().Replace(",", "."),
                                  _PARAMETROS.fizanthus_valor.ToString().Replace(",", "."));
            return Pag_Net.Bll.BDCommand.ScriptSql_POST(Pag_Net.Bll.BDCommand.Name.F0053_01, _parametros);


        }


    }
}




