using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0115;
using Pag_Net.F0115.Models;


namespace Pag_Net.F0115.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                
                string SQL_REDSHIFT = 
                   string.Format(     "Select       nf.loja_key                     as      em_cdempresabluesoft                 " +
                                      "       ,     cast(0 as int)                  as      un_operacao_cd                       " + 
                                      "       ,     nf.nf_key                       as      df_nf_seq_blue                       " + 
                                      "       ,     nf.nf_numero                    as      df_nf_numero                         " + 
                                      "       ,     nf.nf_serie                     as      df_nf_serie                          " + 
                                      "       ,     nf.nf_tipo_key                  as      df_nf_tipo                           " + 
                                      "       ,     ps.pessoa_key                   as      cdpessoabluesoft                     " +
                                      "       ,     nf.data_emissao                 as      df_data_emissao                      " + 
                                      "      From        Nota_Fiscal         nf                                                 " + 
                                      "      inner join  pessoa              ps on ps.pessoa_key = nf.fornecedor_key            " + 
                                      "      INNER JOIN  NOTA_FISCAL_TOTAL   NT ON NT.NF_KEY = NF.NF_KEY                        " + 
                                      "      inner join  nota_fiscal_tipo    tp on tp.nf_tipo_key = nf.nf_tipo_key              " + 
                                      "      where       1 = 1                                                                  " + 
                                      "      and         nf.data_emissao >= '{0}'                                               " + 
                                      "      and         nf.data_emissao <= '{1}'                                               " +
                                      "      order by    ps.nome_razao asc", 
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0115", 50).ToString("yyyy-MM-dd"),
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0115", 50).ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                List<Db> List = new List<Db>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["df_nf_seq_blue"];
                    List.Add(new Db(dr));
                }


                /*Postgre INSERT 
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                foreach (Models.Db item in List)
                {
                    ErroInfo = "ID: " + item.df_nf_seq_blue.ToString();
                    BDExecute.Execute(Pag_Net.F0115.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);
                }
                BDExecute.Commit(DataBaseName.ODBCOXAN);
                */

                /*Postgre INSERT */
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.Db item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }

                    ErroInfo = "ID: " + item.df_nf_seq_blue.ToString();
                    BDExecute.Execute(Pag_Net.F0115.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);

                    x = x + 1;
                    seq = seq + 1;

                    if (x > 10000)
                    {
                        x = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        x = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                //BDExecute.Commit(DataBaseName.ODBCOXAN);












            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}


namespace Pag_Net.F0115.Bll
{

    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, Db item)
        {
            try
            {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(StringCRUD(item), null, DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Update: " + ex.Message);
            }
        }
        public static string StringCRUD(Db item)
        {
            return string.Format("SELECT f0115_01_1011860_documentofiscal_seq (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,    '{2}'            " +
                                   "       ,     {3}             " +
                                   "       ,     {4}             " +
                                   "       ,    '{5}'            " +
                                   "       ,    '{6}'            )",
                                   item.df_nf_seq_blue                              ,
                                   item.df_nf_numero                                ,
                                   item.df_nf_serie                                 ,
                                   item.df_nf_tipo                                  ,
                                   item.cdpessoabluesoft                            ,
                                   item.df_data_emissao.ToString("yyyy-MM-dd")      , 
                                   item.em_cdempresabluesoft.ToString());


        }
    }
}

namespace Pag_Net.F0115.Models
{
    public class Db
    {
        
        public int      df_nf_seq_blue                      { get; set; }
        public int      df_nf_numero                        { get; set; }
        public string   df_nf_serie                         { get; set; }
        public int      df_nf_tipo                          { get; set; }
        public int      cdpessoabluesoft                    { get; set; }
        public DateTime df_data_emissao                     { get; set; }
        public int em_cdempresabluesoft { get; set;  }


        public Db() {}
        public Db(DataRow i)
        {

             df_nf_seq_blue		               = Convert.ToInt32(i["df_nf_seq_blue"].ToString())  ;			             
             df_nf_numero		               = Convert.ToInt32(i["df_nf_numero"].ToString())  ;
             df_nf_serie                       = i["df_nf_serie"].ToString();	 
             df_nf_tipo			               = Convert.ToInt32(i["df_nf_tipo"].ToString())  ;						 
             cdpessoabluesoft		           = Convert.ToInt32(i["cdpessoabluesoft"].ToString())  ;					 
             df_data_emissao				   = Convert.ToDateTime(i["df_data_emissao"]);
             em_cdempresabluesoft              = Convert.ToInt32(i["em_cdempresabluesoft"]);
            

        }





    }
}
