using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0052;
using Pag_Net.F0052.Models;

namespace Pag_Net.F0052.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                string SQL_REDSHIFT =
                   string.Format(     "select      conta_contabil_key                      as plc_conta_cd " + 
                                      "       ,    coalesce(plano_conta_key,0)             as plc_plano_conta_cd " +
                                      "       ,    cast(conta_reduzida as varchar(15))     as plc_conta " +
                                      "       ,    cast(codigo_descritivo as varchar(30))  as plc_conta_descricao " +
                                      "       ,    cast(descricao as varchar(60))          as plc_descricao " +
                                      "       ,    status                                  as plc_conta_status " +
                                      "       ,    grau                                    as plc_grau " +
                                      "       ,    tipo_despesa                            as plc_tipo_despesa " +
                                      "       from        conta_contabil " +
                                      "       where       1 = 1 " +
                                      "       and         status in( 1,0) " +
                                      "       order by    descricao asc ");

                /*RedShift BlueSoft SELECT */
                List<TbPlanoContasContabil> List = new List<TbPlanoContasContabil>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[0].ToString();
                    List.Add(new TbPlanoContasContabil(dr));
                }
                
                /*Postgre INSERT */
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                foreach (Models.TbPlanoContasContabil item in List)
                {
                    ErroInfo = "ID: " + item.plc_conta.ToString();
                    BDExecute.Execute(Pag_Net.F0052.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);
                }
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0051 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0052.Bll
{

    public static class Postgres
    {
        public static void CRUD(Pag_Net.Models.modelSistemaUsuario MyConnect, TbPlanoContasContabil item)
        {
            try
            {

                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(StringCRUD(item), null, DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.F0052 | Update: " + ex.Message);
            }
        }
        public static string StringCRUD(TbPlanoContasContabil item)
        {
            return string.Format("SELECT f0052_crud_tbplanocontacontabil (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,    '{2}'            " +
                                   "       ,    '{3}'            " +
                                   "       ,    '{4}'            " +
                                   "       ,    '{5}'            " +
                                   "       ,     {6}            " +
                                   "       ,    '{7}'            " +
                                   "       ,    'false'          )",
                                   item.plc_conta_cd,
                                   item.plc_plano_conta_cd  ,
                                   item.plc_conta			 ,
                                   item.plc_conta_descricao ,
                                   item.plc_descricao		 ,
                                   item.plc_conta_status	 ,
                                   item.plc_grau			 ,
                                   item.plc_tipo_despesa	 
              );


        }
    }
}

namespace Pag_Net.F0052.Models
{
    public class TbPlanoContasContabil
    {
        public int      plc_conta_cd                        {get;set;}
        public int      plc_plano_conta_cd                  { get; set; }
        public string   plc_conta                           { get; set; }
        public string   plc_conta_descricao                 { get; set; }
        public string   plc_descricao                       { get; set; }
        public bool     plc_conta_status                    { get; set; }
        public int      plc_grau                            { get; set; }
        public string   plc_tipo_despesa                    { get; set; }
        public TbPlanoContasContabil() {}
        public TbPlanoContasContabil(DataRow i)
        {
             plc_conta_cd           = Convert.ToInt32(i["plc_conta_cd"].ToString())  ;
             plc_plano_conta_cd     = Convert.ToInt32(i["plc_plano_conta_cd"].ToString())  ;
             plc_conta              = i["plc_conta"].ToString();
             plc_conta_descricao    = i["plc_conta_descricao"].ToString();
             plc_descricao          = i["plc_descricao"].ToString();
             if (i["plc_conta_status"].ToString().Trim() == "1")
                 plc_conta_status   = true;
             else
                 plc_conta_status   = false;
             plc_grau               = Convert.ToInt32(i["plc_grau"].ToString());
             plc_tipo_despesa       = i["plc_tipo_despesa"].ToString();
        }
    }
}
