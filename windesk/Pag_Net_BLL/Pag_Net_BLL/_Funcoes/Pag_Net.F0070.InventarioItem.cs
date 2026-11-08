using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0070;
using Pag_Net.F0070.Models;




namespace Pag_Net.F0070.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {

                string SIS_NUCLEO_CD_FK = "F0070";
                int SIS_NUCLEO_PRC_CD = 42;

                DateTime data_inicial = DateTime.Now.AddDays(-45);
                DateTime data_final = DateTime.Now.AddDays(-1);
                DateTime data_default = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, SIS_NUCLEO_CD_FK, SIS_NUCLEO_PRC_CD);
                DateTime data_default_fim = Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, SIS_NUCLEO_CD_FK, SIS_NUCLEO_PRC_CD);

                if (data_default != Convert.ToDateTime("1900-01-01"))
                {
                    data_inicial = data_default;
                }

                if (data_default_fim != Convert.ToDateTime("1900-01-01"))
                {

                    data_final = data_default_fim;
                }
              

                string SQL_REDSHIFT = 
                   string.Format(     "     SELECT    coalesce(IC.INVENTARIO_CONTABIL_KEY,0)               as inv_seq_blue_contabil " + 
                                      "           ,   coalesce(IM.INVENTARIO_KEY,0)                        as inv_seq_blue " + 
                                      "           ,   coalesce(IC.DATA_CONTABIL,'1900-01-01')              as inv_data_contabil  " + 
                                      "           ,   coalesce(IM.PRODUTO_KEY,0)                           as prb_cdprodutobluesoft " + 
                                      "           ,   CAST(coalesce(IM.QUANTIDADE_CONTABIL,0.00) AS NUMERIC(17,4))                as inv_contabil_qtde  " +
                                      "           ,   coalesce(IM.CUSTO_CONTABIL,0.00)                     as inv_contabil_valor_custo " +
                                      "           ,   coalesce(IM.CUSTO_CONTABIL_TOTAL,0.00)               as inv_contabil_valor_custo_total " +
                                      "           ,   CAST(coalesce(IM.QUANTIDADE_CONTADA ,0.00) AS NUMERIC(17,4))   as inv_qtde " +
                                      "           ,   CAST(coalesce(IM.QUEBRA_QUANTIDADE,0.00)  AS NUMERIC(17,4))    as inv_diferenca_qtde " +
                                      "           ,   coalesce(IM.QUEBRA_VALOR,0.00)                                 as inv_diferenca_valor " +
                                      "           ,   CAST(coalesce(IM.ALIQUOTA_PIS,0.0000)    AS NUMERIC(17,4))     as inv_aliq_pis " +
                                      "           ,   CAST(coalesce(IM.ALIQUOTA_COFINS,0.0000) AS NUMERIC(17,4))     as inv_aliq_cofins  " +
                                      "           ,   CAST(coalesce(IM.ALIQUOTA_ICMS,0.0000)   AS NUMERIC(17,4))     as inv_aliq_icms " + 
                                      "     FROM        INVENTARIO_MOVIMENTO IM " + 
                                      "     INNER JOIN  INVENTARIO_CONTABIL  IC ON IC.INVENTARIO_KEY = IM.INVENTARIO_KEY  " + 
                                      "     WHERE      1 = 1 " + 
                                      "     AND        IC.STATUS_INVENTARIO_CONTABIL_KEY = 'ENCERRADO' " +
                                      "     AND        IC.DATA_CONTABIL >= '{0}' " + 
                                      "     AND        IC.DATA_CONTABIL <= '{1}' ", data_inicial.ToString("yyyy-MM-dd"), data_final.ToString("yyyy-MM-dd"));


                /*RedShift BlueSoft SELECT */
                List<Pag_Net.F0070.Models.Db> List = new List<Pag_Net.F0070.Models.Db>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["inv_seq_blue_contabil"];
                    List.Add(new Pag_Net.F0070.Models.Db(dr));
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

                    ErroInfo = "ID: " + item.inv_seq_blue_contabil.ToString();
                    BDExecute.Execute(Pag_Net.F0070.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);

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


namespace Pag_Net.F0070.Bll
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
            return string.Format("SELECT f0070_crud_TbInventarioItem (	    " +
                                   "           'DBINSERT'         " +
                                   "       ,     {0}              " +
                                   "       ,     {1}              " +
                                   "       ,    '{2}'             " +
                                   "       ,     {3}              " +
                                   "       ,     {4}              " +
                                   "       ,     {5}              " +
                                   "       ,     {6}              " +
                                   "       ,     {7}              " +
                                   "       ,     {8}              " +
                                   "       ,     {9}              " +
                                   "       ,     {10}             " +
                                   "       ,     {11}             " +
                                   "       ,     {12}             )",
                                   item.inv_seq_blue_contabil.ToString(),
                                   item.inv_seq_blue.ToString(),
                                   item.inv_data_contabil.ToString("yyyy-MM-dd"),
                                   item.prb_cdprodutobluesoft.ToString(),
                                   item.inv_contabil_qtde.ToString("0.0000").Replace(",","."),
                                   item.inv_contabil_valor_custo.ToString("0.00").Replace(",","."),
                                   item.inv_contabil_valor_custo_total.ToString("0,00").Replace(",","."),
                                   item.inv_qtde.ToString("0.0000").Replace(",","."),
                                   item.inv_diferenca_qtde.ToString("0.0000").Replace(",","."),
                                   item.inv_diferenca_valor.ToString("0.00").Replace(",","."),
                                   item.inv_aliq_pis.ToString("0.0000").Replace(",","."),
                                   item.inv_aliq_cofins.ToString("0.0000").Replace(",","."),
                                   item.inv_aliq_icms.ToString("0.0000").Replace(",",".")
                                   );
        }
    }
}

namespace Pag_Net.F0070.Models
{
    public class Db
    {
        
        public int	    inv_seq_blue_contabil						{get;set;}
		public int	    inv_seq_blue								{get;set;}
		public DateTime inv_data_contabil 							{get;set;}
		public int	    prb_cdprodutobluesoft						{get;set;}
		public double	inv_contabil_qtde 							{get;set;}
		public double	inv_contabil_valor_custo					{get;set;}
		public double	inv_contabil_valor_custo_total				{get;set;}
		public double	inv_qtde									{get;set;}
		public double	inv_diferenca_qtde							{get;set;}
		public double	inv_diferenca_valor						{get;set;}
		public double	inv_aliq_pis								{get;set;}
		public double	inv_aliq_cofins     			    { get;set;}
        public double   inv_aliq_icms                      { get; set; }

        public Db() {}
        public Db(DataRow i)
        {
            inv_seq_blue_contabil = Convert.ToInt32(i["inv_seq_blue_contabil"].ToString());
            inv_seq_blue = Convert.ToInt32(i["inv_seq_blue"].ToString());
            inv_data_contabil = Convert.ToDateTime(i["inv_data_contabil"].ToString());
            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            inv_contabil_qtde = Convert.ToDouble(i["prb_cdprodutobluesoft"].ToString());
            inv_contabil_valor_custo = Convert.ToDouble(i["inv_contabil_valor_custo"].ToString());
            inv_contabil_valor_custo_total = Convert.ToDouble(i["inv_contabil_valor_custo_total"].ToString());
            inv_qtde = Convert.ToDouble(i["inv_qtde"].ToString());
            inv_diferenca_qtde = Convert.ToDouble(i["inv_diferenca_qtde"].ToString());
            inv_diferenca_valor = Convert.ToDouble(i["inv_diferenca_valor"].ToString());
            inv_aliq_pis = Convert.ToDouble(i["inv_aliq_pis"].ToString());
            inv_aliq_cofins = Convert.ToDouble(i["inv_aliq_cofins"].ToString());
            inv_aliq_icms = Convert.ToDouble(i["inv_aliq_icms"].ToString());
        }
    }
}



