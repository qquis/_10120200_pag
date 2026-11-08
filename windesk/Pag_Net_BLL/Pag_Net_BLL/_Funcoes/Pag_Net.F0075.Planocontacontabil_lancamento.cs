using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0075;
using Pag_Net.F0075.Models;




namespace Pag_Net.F0075.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {

                //string SIS_NUCLEO_CD_FK = "F0075";
                //int SIS_NUCLEO_PRC_CD = 42;

            


                string SQL_REDSHIFT =
                   string.Format(" select        cp.ano_mes                        as competencia_cd " +
                                    "       ,    mv.conta_contabil_key             as plc_conta_cd " +
                                    "       ,    SUM(mv.valor * mv.sinal)          as plcm_valor " +
                                    "       from       partida_dobrada         pd " +
                                    "       inner join movimento_contabil      mv on mv.partida_dobrada_key = pd.partida_dobrada_key and mv.loja_key = pd.loja_key " +
                                    "       inner join conta_contabil          cc on cc.conta_contabil_key  = mv.conta_contabil_key " +
                                    "       inner join competencia_contabil    cp on cp.competencia_contabil_key = pd.competencia_contabil_key " +
                                    "       where      1 = 1 " +
                                    "       and        pd.loja_key = 1 " +
                                    "       and        cp.ano >= 2021 " +
                                    "       AND        CP.MES >= 1 " +
                                    "       AND        pd.excluida = 0 " + 
                                    "       GROUP BY   cp.ano_mes  " +
                                    "             ,    mv.conta_contabil_key  " +

                                    " UNION " + 
                                    " select     cpp.ano_mes  AS ANO_MES " + 
                                    "         ,  ccc.conta_contabil_key AS conta_contabil_key " + 
                                    "         ,  0 " + 
                                    " from      competencia_contabil cpp, conta_contabil ccc " + 
                                    " where     cpp.ano >= 2021 " + 
                                    " and       cpp.ano <= date_part('year', current_date) + 1 " + 
                                    " and not exists (  " + 
                                    " select        1 " + 
                                    " from          partida_dobrada         pd " + 
                                    " inner join    movimento_contabil      mv on mv.partida_dobrada_key = pd.partida_dobrada_key and mv.loja_key = pd.loja_key " + 
                                    " inner join    conta_contabil          cc on cc.conta_contabil_key  = mv.conta_contabil_key" + 
                                    " inner join    competencia_contabil    cp on cp.competencia_contabil_key = pd.competencia_contabil_key " + 
                                    " where      1 = 1 " + 
                                    " and        pd.loja_key = 1 " + 
                                    " and        cp.ano >= 2021 " + 
                                    " AND        CP.MES >= 1 " + 
                                    " and        cp.ano_mes = cpp.ano_mes " + 
                                    " and        ccc.conta_contabil_key = cc.conta_contabil_key  ) " + 
                                    " ORDER BY   1, 2 ASC    ");



                /*RedShift BlueSoft SELECT */
                List<Db> List = new List<Db>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[0];
                    List.Add(new Db(dr));
                }
                
                /*Postgre INSERT */
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.Db item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }

                    ErroInfo = "ID: " + item.plc_conta_cd.ToString();
                    BDExecute.Execute(Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);

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
                throw new Exception("F0070 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}


namespace Pag_Net.F0075.Bll
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
            return string.Format("SELECT f0075_crud_tbplanocontacontabil_lancamento (	    " +
                                   "           'DBINSERT'         " +
                                   "       ,     {0}              " +
                                   "       ,     {1}              " +
                                   "       ,     {2}              )",
                                   item.plc_conta_cd.ToString(),
                                   item.competencia_cd.ToString(),
                                   item.plcm_valor.ToString("0.00").Replace(",",".")
                                   );
        }
    }
}

namespace Pag_Net.F0075.Models
{
    public class Db
    {
        
        public int	    	plc_conta_cd 			{get;set;}
		public int      	competencia_cd			{get;set;}
        public double       plcm_valor              {get;set;}

        public Db() {}
        public Db(DataRow i)
        {
            plc_conta_cd = Convert.ToInt32(i["plc_conta_cd"].ToString());
            competencia_cd = Convert.ToInt32(i["competencia_cd"].ToString());
            plcm_valor = Convert.ToDouble(i["plcm_valor"].ToString());
        }
    }
}



