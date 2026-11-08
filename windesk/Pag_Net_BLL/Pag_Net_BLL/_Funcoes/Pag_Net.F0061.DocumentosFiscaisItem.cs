using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0061;
using Pag_Net.F0061.Models;




namespace Pag_Net.F0061.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                string SQL_REDSHIFT = 
                   string.Format(     "     SELECT   it.loja_key                                    as em_cdempresabluesoft " + 
                                      "           ,   it.nf_key 								        as df_nf_seq_blue " + 
                                      "           ,  it.nota_fiscal_item_key 					    as df_nf_i_seq_blue " +
                                      "           ,  it.produto_key 							    as prb_cdprodutobluesoft " + 
	                                  "           ,  it.produto_origem_key                          as prb_cdprodutobluesoft_nf " + 
                                      "           ,  it.ni_unidade_medida_faturamento 	            as df_nf_i_embalagem " + 
	                                  "           ,  it.quantidade_faturada 					    as df_nf_i_qtde " + 
	                                  "           ,  it.custo_embalagem_final                       as df_nf_i_valor_total " + 
                                      "           ,  it.codigo_operacao_fiscal 				        as df_nf_i_cfop " + 
                                      "           ,  coalesce(it.ni_valor_bruto_total,0)            as df_nf_i_custo_bruto_total " +
                                      "           ,  coalesce(it.ni_fator_estoque,0)                as df_nf_i_fator_estoque" +
                                      "           ,  coalesce(it.ni_ipi_valor,0)                    as df_nf_valor_ipi" +
                                      "           ,  coalesce(it.ni_valor_icms,0)                   as df_nf_valor_icms" +
                                      "           ,  coalesce(it.ni_pis_valor,0)                    as df_nf_valor_pis" +
                                      "           ,  coalesce(it.ni_cofins_Valor,0)                 as df_nf_valor_cofins" +
                                      "           ,  coalesce(it.ni_base_calculo_icms,0)            as df_nf_base_icms_unitario" +
                                      "           ,  coalesce(it.ni_base_calculo_icms_total,0)      as df_nf_base_icms " +
                                      "           ,  coalesce(it.ni_base_calculo_icms_st_total,0)   as df_nf_base_icms_st" +
                                      "           ,  coalesce(it.ni_base_pis_total,0)               as df_nf_base_pis" +
                                      "           ,  coalesce(it.ni_base_cofins_total,0)            as df_nf_base_cofins" +
                                      "           ,  coalesce(it.ni_custo_contabil_total,0)         as df_nf_custo_contabil " +
                                      "           ,  coalesce(it.icm_key,0)                         as trib_cd_icms" +
                                      "           ,  coalesce(it.pis_key,0)                         as trib_cd_pis" +
                                      "           ,  coalesce(it.cofins_key,0)                      as trib_cd_cofins " +                              
                                      "      FROM        FATO_NOTA_FISCAL it  " + 
                                      "      inner join  nota_fiscal      nf on nf.nf_key = it.nf_key and nf.loja_key = it.loja_key " + 
                                      "      inner join  nota_fiscal_tipo tp on tp.nf_tipo_key = nf.nf_tipo_key " +
                                      "      where       1 = 1                                                                  " +
                                      "      and         nf.data_emissao >= '{0}'                                               " +
                                      "      and         nf.data_emissao <= '{1}'                                               " +
                                      "      order by    1,2,3 asc",  
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0061", 41).ToString("yyyy-MM-dd"),
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0061", 41).ToString("yyyy-MM-dd"));


       







                /*RedShift BlueSoft SELECT */
                List<Pag_Net.F0061.Models.Db> List = new List<Pag_Net.F0061.Models.Db>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, SQL_REDSHIFT, "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["df_nf_i_seq_blue"];
                    List.Add(new Pag_Net.F0061.Models.Db(dr));
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

                    ErroInfo = "ID: " + item.df_nf_seq_blue.ToString();
                    BDExecute.Execute(Pag_Net.F0061.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);

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


namespace Pag_Net.F0061.Bll
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
            return string.Format("SELECT f0061_01_1011860_crud_tbdocumentofiscalitem (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,     {2}             " +
                                   "       ,     {3}             " +
                                   "       ,    '{4}'            " +
                                   "       ,    '{5}'            " +
                                   "       ,     {6}             " + 
                                   "       ,     {7}             " +
                                   "       ,     {8}             " +
                                   "       ,     {9}             " +
                                   "       ,     {10}             " +
                                   "       ,     {11}             " +
                                   "       ,     {12}             " +
                                   "       ,     {13}             " +
                                   "       ,     {14}             " +
                                   "       ,     {15}             " +
                                   "       ,     {16}             " +
                                   "       ,     {17}             " +
                                   "       ,     {18}             " +
                                   "       ,     {19}             " +
                                   "       ,     {20}             " +
                                   "       ,     {21}             " +
                                   "       ,     {22}             " +
                                   "       ,     {23}             )" ,
                                   item.df_nf_seq_blue.ToString(), 
                                   item.df_nf_i_seq_blue.ToString(),
                                   item.prb_cdprodutobluesoft.ToString(), 
                                   item.prb_cdprodutobluesoft_nf.ToString(),
                                   item.df_nf_i_embalagem.ToString(), 
                                   item.df_nf_i_cfop.ToString(), 
                                   item.df_nf_i_valor_total.ToString("0.00").Replace(",","."),
                                   item.df_nf_i_qtde.ToString("0.0000").Replace(",","."),
                                   item.df_nf_i_custo_bruto_total.ToString("0.00").Replace(",","."),   
                                   item.df_nf_i_fator_estoque.ToString("0.00").Replace(",","."),       
                                   item.df_nf_valor_ipi.ToString("0.00").Replace(",","."),             
                                   item.df_nf_valor_icms.ToString("0.00").Replace(",","."),            
                                   item.df_nf_valor_pis.ToString("0.00").Replace(",","."),             
                                   item.df_nf_valor_cofins.ToString("0.00").Replace(",","."),          
                                   item.df_nf_base_icms_unitario.ToString("0.00").Replace(",","."),    
                                   item.df_nf_base_icms.ToString("0.00").Replace(",","."),             
                                   item.df_nf_base_icms_st.ToString("0.00").Replace(",","."),          
                                   item.df_nf_base_pis.ToString("0.00").Replace(",","."),              
                                   item.df_nf_base_cofins.ToString("0.00").Replace(",","."),           
                                   item.df_nf_custo_contabil.ToString("0.00").Replace(",","."),        
                                   item.trib_cd_icms.ToString(),                
                                   item.trib_cd_pis.ToString(),                 
                                   item.trib_cd_cofins.ToString()   ,
                                   item.em_cdempresabluesoft.ToString()
                                   );

        }
    }
}

namespace Pag_Net.F0061.Models
{
    public class Db
    {
        
        public int	    df_nf_seq_blue				{get;set;}
	    public int	    df_nf_i_seq_blue			{get;set;}
	    public int	    prb_cdprodutobluesoft 	    {get;set;}
	    public int	    prb_cdprodutobluesoft_nf	{get;set;}
	    public string	df_nf_i_embalagem 			{get;set;}
	    public string	df_nf_i_cfop 				{get;set;}
        public double   df_nf_i_valor_total         {get;set;}
        public double   df_nf_i_qtde                {get;set;}
        public double   df_nf_i_custo_bruto_total   {get;set;}
        public double   df_nf_i_fator_estoque       {get;set;}
        public double   df_nf_valor_ipi             {get;set;}
        public double   df_nf_valor_icms            {get;set;}
        public double   df_nf_valor_pis             {get;set;}
        public double   df_nf_valor_cofins          {get;set;}
        public double   df_nf_base_icms_unitario    {get;set;}
        public double   df_nf_base_icms             {get;set;}
        public double   df_nf_base_icms_st          {get;set;}
        public double   df_nf_base_pis              {get;set;}
        public double   df_nf_base_cofins           {get;set;}
        public double   df_nf_custo_contabil        {get;set;}
        public int      trib_cd_icms                {get;set;}
        public int      trib_cd_pis                 {get;set;}
        public int      trib_cd_cofins              {get;set;}
        public int em_cdempresabluesoft { get; set; }

        public Db() {}
        public Db(DataRow i)
        {
            df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            df_nf_i_seq_blue = Convert.ToInt32(i["df_nf_i_seq_blue"].ToString());
            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            prb_cdprodutobluesoft_nf = Convert.ToInt32(i["prb_cdprodutobluesoft_nf"].ToString());
            df_nf_i_embalagem = i["df_nf_i_embalagem"].ToString();
            df_nf_i_cfop = i["df_nf_i_cfop"].ToString();
            df_nf_i_valor_total = Convert.ToDouble(i["df_nf_i_valor_total"].ToString());
            df_nf_i_qtde = Convert.ToDouble(i["df_nf_i_qtde"].ToString());

            df_nf_i_custo_bruto_total  = Convert.ToDouble(i["df_nf_i_custo_bruto_total"].ToString());
            df_nf_i_fator_estoque      = Convert.ToDouble(i["df_nf_i_fator_estoque"].ToString());
            df_nf_valor_ipi            = Convert.ToDouble(i["df_nf_valor_ipi"].ToString());
            df_nf_valor_icms           = Convert.ToDouble(i["df_nf_valor_icms"].ToString());
            df_nf_valor_pis            = Convert.ToDouble(i["df_nf_valor_pis"].ToString());
            df_nf_valor_cofins         = Convert.ToDouble(i["df_nf_valor_cofins"].ToString());
            df_nf_base_icms_unitario   = Convert.ToDouble(i["df_nf_base_icms_unitario"].ToString());
            df_nf_base_icms            = Convert.ToDouble(i["df_nf_base_icms"].ToString());
            df_nf_base_icms_st         = Convert.ToDouble(i["df_nf_base_icms_st"].ToString());
            df_nf_base_pis             = Convert.ToDouble(i["df_nf_base_pis"].ToString());
            df_nf_base_cofins          = Convert.ToDouble(i["df_nf_base_cofins"].ToString());
            df_nf_custo_contabil       = Convert.ToDouble(i["df_nf_custo_contabil"].ToString());
            trib_cd_icms               = Convert.ToInt32(i["trib_cd_icms"].ToString());
            trib_cd_pis                = Convert.ToInt32(i["trib_cd_pis"].ToString());
            trib_cd_cofins             = Convert.ToInt32(i["trib_cd_cofins"].ToString());
            em_cdempresabluesoft = Convert.ToInt32(i["em_cdempresabluesoft"].ToString());
        }
    }
}

