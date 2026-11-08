using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.F0090;
using Pag_Net.F0090.Models;




namespace Pag_Net.F0090.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

       

            string ErroInfo = "";
            try
            {



                string SQL_REDSHIFT =
                   string.Format(   "    SELECT " + 
                                    "                cc.ano_mes                  as competencia_Cd      " + 
                                    "        ,       MV.PARTIDA_DOBRADA_KEY      as partida_dobrada_cd  " + 
                                    "        ,       MV.CONTA_CONTABIL_KEY       as plc_conta_cd  " + 
                                    "        ,       mv.movimento_contabil_key   as plcm_seq     " + 
                                    "        ,       PD.DATA_LANCAMENTO          as plcm_data_lancamento  " + 
                                    "        ,       MV.VALOR * MV.SINAL         as plcm_valor  " + 
                                    "        ,       pd.excluida                 as plcm_status_excluido  " + 
                                    "        ,       N.NF_KEY                    as df_nf_seq_blue   " +   
                                    "    FROM        NOTA_FISCAL         N " + 
                                    "    LEFT JOIN   MOVIMENTO_CONTABIL  MV ON MV.ORIGEM_KEY = N.NF_KEY AND MV.TIPO_ORIGEM_KEY = 1 " + 
                                    "    LEFT JOIN   PARTIDA_DOBRADA     PD ON PD.partida_dobrada_key = MV.partida_dobrada_key  " + 
                                    "    left join   competencia_contabil cc on cc.competencia_contabil_key = pd.competencia_Contabil_key  " + 
                                    "    WHERE       1 = 1 " +
                                    "    and         pd.loja_key = 1 " +
                                    "    AND         PD.DATA_LANCAMENTO >= '{0}' " + 
                                    "    AND         PD.DATA_LANCAMENTO <= '{1}' " + 
                                    "    order by    cc.ano_mes, n.nf_key asc",
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0090", 45).ToString("yyyy-MM-dd"),
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0090", 45).ToString("yyyy-MM-dd")
                                    );



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

                    ErroInfo = "ID: " + item.plcm_seq.ToString();
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
                throw new Exception("F0090 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}


namespace Pag_Net.F0090.Bll
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
                throw new Exception("Pag_Net.F0080 | Update: " + ex.Message);
            }
        }
        public static string StringCRUD(Db item)
        {
            return string.Format("SELECT f0090_crud_planocontacontabil_movimento (	    " +
                                   "           'DBINSERT'  , " +
                                   "           {0}         , " + 
                                   "           {1}   , " +  
                                   "           {2}   , " +  
                                   "           {3}   , " +
                                   "          '{4}'  , " +
                                   "           {5}   , " +
                                   "           {6}   , " +  
                                   "           {7}   ) ",
                                   item.competencia_cd,
                                   item.partida_dobrada_cd,
                                   item.plc_conta_cd,
                                   item.plcm_seq,
                                   item.plcm_data_lancamento.ToString("yyyy-MM-dd"),
                                   item.plcm_valor.ToString("0.00").Replace(",","."),
                                   item.plcm_status_excluido.ToString(),
                                   item.df_nf_seq_blue.ToString()
                                   );
        }
    }
}

namespace Pag_Net.F0090.Models
{
    public class Db
    {

        public int	    competencia_cd 			    {get;set;}
		public int	    partida_dobrada_cd		    {get;set;}
		public int	    plc_conta_cd			    {get;set;}
		public int	    plcm_seq				    {get;set;}
		public DateTime	plcm_data_lancamento	    {get;set;}
		public double	plcm_valor				    {get;set;}
		public int      plcm_status_excluido	    {get;set;}
        public int      df_nf_seq_blue              { get; set; }

        public Db() { }
        public Db(DataRow i)
        {
            competencia_cd = Convert.ToInt32(i["competencia_cd"].ToString());
            partida_dobrada_cd = Convert.ToInt32(i["partida_dobrada_cd"].ToString());
            plc_conta_cd = Convert.ToInt32(i["plc_conta_cd"].ToString());
            plcm_seq = Convert.ToInt32(i["plcm_seq"].ToString());
            plcm_data_lancamento = Convert.ToDateTime(i["plcm_data_lancamento"].ToString());
            plcm_valor = Convert.ToDouble(i["plcm_valor"].ToString());
            plcm_status_excluido = Convert.ToInt32(i["plcm_status_excluido"].ToString());
            df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            

            
        }
    }
}




