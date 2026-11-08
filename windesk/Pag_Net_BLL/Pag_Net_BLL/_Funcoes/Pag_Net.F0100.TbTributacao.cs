using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Dal;
using Pag_Net.F0100;
using Pag_Net.F0100.Models;

namespace Pag_Net.F0100.Bll.Migration
{
    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                string SQL_REDSHIFT =
                   string.Format(   "    SELECT       cast('ICMS' as varchar(10))                                           as  trib_tipo " + 
                                    "               , cast(icm_key as int)                                                  as  trib_cd " + 
                                    "               , cast(codigo_origem as varchar(2))  " + 
                                    "                       + case len( cast(codigo_tributacao as varchar(3))) " + 
                                    "                              when 1 then '0' + cast(codigo_tributacao as varchar(3)) " + 
                                    "                              else cast(codigo_tributacao as varchar(3)) end  " + 
                                    "                                                                                       as trib_cst_icms  " + 
                                    "           , cast(0 as int)                                                            as trib_cst_pis_cofins " + 
                                    "           , cast(descricao as varchar(60))                                            as trib_descricao " + 
                                    "           , cast(descricao_abreviada as varchar(60))                                  as trib_descricao_res  " + 
                                    "           , cast(aliquota as numeric(17,4))                                           as trib_aliq  " + 
                                    "           , cast(reducao  as numeric(17,4))                                           as trib_aliq_reducao  " + 
                                    "           , cast(codigo_tributacao as int)                                            as trib_cod  " + 
                                    "           , cast(codigo_origem as int)                                                as trib_icms_cod_origem         " + 
                                    "           , cast(coalesce(csosn_key,0) as int)                                        as trib_icms_csosn " + 
                                    "   FROM    ICM " + 
                                    "   UNION " + 
                                    "   SELECT    cast('PIS' as varchar(10))                                                as trib_tipo  " + 
                                    "           , cast(pis_key as int)                                                      as trib_cd " + 
                                    "           , cast(0 as VARCHAR(3))                                                     as trib_cst_icms  " + 
                                    "           , cast(cst_pis_cofins_key as int)                                           as trib_cst_pis_cofins " + 
                                    "           , cast(descricao as varchar(60))                                            as trib_descricao " + 
                                    "           , cast('' as varchar(60))                                                   as trib_descricao_res  " + 
                                    "           , cast(aliquota as numeric(17,4))                                           as trib_aliq  " + 
                                    "           , cast(0    as numeric(17,4))                                               as trib_aliq_reducao  " + 
                                    "           , cast(cst_pis_cofins_key as int)                                           as trib_cod  " + 
                                    "           , cast(0 as int)                                                            as trib_icms_cod_origem " + 
                                    "           , cast(0 as int)                                                            as trib_icms_csosn " + 
                                    "   FROM    PIS " + 
                                    "   UNION " + 
                                    "   SELECT    cast('COFINS' as varchar(10))                                             as trib_tipo  " + 
                                    "           , cast(cofins_key as int)                                                   as trib_cd " + 
                                    "           , cast(0 as VARCHAR(3))                                                     as trib_cst_icms  " + 
                                    "           , cast(cst_pis_cofins_key as int)                                           as trib_cst_pis_cofins " + 
                                    "           , cast(descricao as varchar(60))                                            as trib_descricao " + 
                                    "           , cast('' as varchar(60))                                                   as trib_descricao_res  " + 
                                    "           , cast(aliquota as numeric(17,4))                                           as trib_aliq  " + 
                                    "           , cast(0    as numeric(17,4))                                               as trib_aliq_reducao  " + 
                                    "           , cast(cst_pis_cofins_key as int)                                           as trib_cod  " + 
                                    "           , cast(0 as int)                                                            as trib_icms_cod_origem  " + 
                                    "           , cast(0 as int)                                                            as trib_icms_csosn " + 
                                    "   FROM    COFINS " + 
                                    "   ORDER BY 1,2 ") ; 



                /*RedShift BlueSoft SELECT */
                List<Db> List = new List<Db>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[0].ToString() + "-" +  dr[1].ToString();
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

                    ErroInfo = "ID: " + item.trib_cd.ToString();
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
                throw new Exception("Pag_Net.F0100: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0100.Bll
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
                throw new Exception("Pag_Net.F0100: " + ex.Message);
            }
        }
        public static string StringCRUD(Db item)
        {
            return string.Format("SELECT f0100_tbtributacao (	    " +
                                   "           'DBINSERT'    , " +
                                   "           '{0}'         , " + 
                                   "            {1}          , " +  
                                   "           '{2}'         , " +  
                                   "            {3}          , " +
                                   "           '{4}'         , " +
                                   "           '{5}'         , " +
                                   "            {6}          , " +
                                   "            {7}          , " +
                                   "            {8}          , " +  
                                   "            {9}          , " + 
                                   "            {10}         ) " ,
                                   item.trib_tipo,
                                   item.trib_cd,
                                   item.trib_cst_icms,
                                   item.trib_cst_pis_cofins,
                                   item.trib_descricao,
                                   item.trib_descricao_res,
                                   item.trib_aliq.ToString("0.00").Replace(",","."),
                                   item.trib_aliq_reducao.ToString("0.00").Replace(",", "."),
                                   item.trib_cod.ToString(),
                                   item.trib_icms_cod_origem.ToString(),
                                   item.trib_icms_csosn.ToString()
                                   );
        }
    }
}

namespace Pag_Net.F0100.Models
{
    public class Db
    {

		public string	trib_tipo 				{get;set;}
		public int	    trib_cd					{get;set;}
		public string	trib_cst_icms			{get;set;}
		public int  	trib_cst_pis_cofins		{get;set;}
		public string	trib_descricao 			{get;set;}
		public string	trib_descricao_res		{get;set;}
		public double	trib_aliq				{get;set;}
		public double	trib_aliq_reducao		{get;set;}
		public int	    trib_cod 				{get;set;}
		public int  	trib_icms_cod_origem	{get;set;}
        public int      trib_icms_csosn         { get; set; }

        public Db() { }
        public Db(DataRow i)
        {
            trib_tipo = i["trib_tipo"].ToString();
            trib_cd = Convert.ToInt32(i["trib_cd"].ToString());
            trib_cst_icms = i["trib_cst_icms"].ToString();
            trib_cst_pis_cofins = Convert.ToInt32(i["trib_cst_pis_cofins"].ToString());
            trib_descricao = i["trib_descricao"].ToString();
            trib_descricao_res = i["trib_descricao_res"].ToString();
            trib_aliq = Convert.ToDouble(i["trib_aliq"].ToString());
            trib_aliq_reducao = Convert.ToDouble(i["trib_aliq_reducao"].ToString());
            trib_cod = Convert.ToInt32(i["trib_cod"].ToString());
            trib_icms_cod_origem = Convert.ToInt32(i["trib_icms_cod_origem"].ToString());
            trib_icms_csosn = Convert.ToInt32(i["trib_icms_csosn"].ToString());
        }
    }
}




