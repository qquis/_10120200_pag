using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.Faturamento
{
    public static class Integration
    {
        public static void Cupons(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            string SCRIPT_Sql_Ultimo_Processamento = "  SELECT 		coalesce(fizanthus_sat_ecf,100) as  	fizanthus_sat_ecf				   " +
                                                         "           ,  coalesce(fizanthus_ctl_dtlog_update_ult,'2021-01-01 01:01:01')  as fizanthus_ctl_dtlog_insert_ult " +
                                                         "           ,	coalesce(fizanthus_ctl_data_ult, '2021-01-01')   as fizanthus_ctl_data_ult" +
                                                         "           ,	coalesce(fizanthus_ctl_cupomfiscal_ult , 1) as fizanthus_ctl_cupomfiscal_ult        " +
                                                         "   FROM 		tbfaturamento_integracao_zanthus_controle " +
                                                         "   group by 	fizanthus_sat_ecf " +
                                                         "   order by 	2 ASC";

            DataSet _DataSet_Parametros = new DataSet();
            _DataSet_Parametros = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SCRIPT_Sql_Ultimo_Processamento, "");

            DateTime _DataUltimaCUPOM = Convert.ToDateTime(_DataSet_Parametros.Tables[0].Rows[0]["fizanthus_ctl_data_ult"].ToString());
            int _Zanthus_Sat_ECF = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["fizanthus_sat_ecf"].ToString());
            int _Zanthus_ULTIMO_CUPOM = Convert.ToInt32(_DataSet_Parametros.Tables[0].Rows[0]["fizanthus_ctl_cupomfiscal_ult"].ToString());

            string SCRIPT_SQL =
                string.Format("	select		         fizanthus_notafiscal            =  N.NUMNOTA                   "  +
                                     "			,	 fizanthus_notafiscal_serie      =  N.SERIE_NF                  "  +
                                     "			,	 fizanthus_data			         =	I.M00AF                     "  +
                                     "			,	 fizanthus_sat_ecf   	         =	I.M00AC                     "  +
                                     "			,	 fizanthus_cupomfiscal	         =	I.M00AD                     "  +
                                     "			,	 fizanthus_cupomfiscalid	     =	i.M00_id_unico              "  +
                                     "			,	 fizanthus_cupomfiscal_seqitem	 =	i.M43CD                     "  +
                                     "			,	 fizanthus_cdbarra				 =	I.M43AH                     "  +
                                     "			,	 fizanthus_qtde					 =	I.M43AO                     "  +
                                     "			,	 fizanthus_valor				 =	I.M43AP                     "  +
                                     "          ,    fizanthus_cupomfiscal_cancelado =  A.m45bo                     "  + 
                                     "   from		 ZEUSRETAIL.dbo.ZAN_M43	I                               " +
                                     "   INNER JOIN  ZEUSRETAIL.DBO.ZAN_M45  A ON A.M00AF = I.M00AF AND A.M00AC = I.M00AC AND A.M00AD = I.M00AD " +
                                     "   INNER JOIN  ZEUSRETAIL.dbo.tab_nota_header	n ON A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF" +
                                     "   WHERE		 I.M00AF >= '{0}' " +
                                     "   AND		 I.M00AC = {1}" +
                                     "   AND         I.M00AD >= {2}" +
                                     "   ORDER BY	 I.M00AF , I.M00AC, I.M00AD , i.M43CD   ASC",
                                             _DataUltimaCUPOM.ToString("yyyy-MM-dd"),
                                             _Zanthus_Sat_ECF.ToString(),
                                             _Zanthus_ULTIMO_CUPOM.ToString());
            DataSet DX = new DataSet();
            DX = DbSelect.GetDataSet(MyConnect, DataBaseName.DBAMAINADM, SCRIPT_SQL, null, true);
            /*Postgre INSERT */
            DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
            int x = 1;
            int seq = 0;
            int count = DX.Tables[0].Rows.Count;
            foreach (DataRow i in DX.Tables[0].Rows)
            {

                if (x == 0)
                {
                    BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                }
                ErroInfo = "ID: " + i["fizanthus_cupomfiscal"].ToString();
                BDExecute.Execute(
                    Pag_Net.Bll.F0053.Postgres.Post(new F0053.Parametros(
                                                        Convert.ToDateTime(i["fizanthus_data"].ToString()),
                                                        Convert.ToInt32(i["fizanthus_sat_ecf"].ToString()),
                                                        Convert.ToInt32(i["fizanthus_cupomfiscal"].ToString()),
                                                        i["fizanthus_cupomfiscalid"].ToString(),
                                                        Convert.ToInt32(i["fizanthus_notafiscal"].ToString()),
                                                        Convert.ToInt32(i["fizanthus_notafiscal_serie"].ToString()),
                                                        Convert.ToInt32(i["fizanthus_cupomfiscal_seqitem"].ToString()),
                                                        i["fizanthus_cdbarra"].ToString(),
                                                        Convert.ToDouble(i["fizanthus_qtde"].ToString()),
                                                        Convert.ToDouble(i["fizanthus_valor"].ToString())
                                                                )
                                                ),                                  
                        null, DataBaseName.ODBCOXAN);

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


            if (DX.Tables[0].Rows.Count < 1)
            {
                string script_controle = String.Format("UPDATE tbfaturamento_integracao_zanthus_controle SET fizanthus_ctl_dtlog_update_ult = current_timestamp, fizanthus_ctl_data_ult = current_date, fizanthus_ctl_cupomfiscal_ult = 1 where fizanthus_sat_ecf = {0}", _Zanthus_Sat_ECF);
                BDExecute.Execute(script_controle, null, DataBaseName.ODBCOXAN);
            }

        }

        
    }
}

