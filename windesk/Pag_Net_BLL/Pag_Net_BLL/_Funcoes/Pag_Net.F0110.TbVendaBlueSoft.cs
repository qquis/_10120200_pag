using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0110;
using Pag_Net.F0110.Models;




namespace Pag_Net.F0110.Bll.Migration
{

    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {
                
        
                
          
                

                string SQL_REDSHIFT =
                   string.Format(" select  coalesce(pedido_cliente_venda_key,pedido_forca_venda_cliente_key)      as   vb_seq_blue " + 
                                      "   ,     pedido_forca_venda_cliente_key            as   numeropedido  " + 
                                      "   ,     cliente_key                               as   cdpessoabluesoft_cliente  " + 
                                      "   ,     vendedor_key                              as   cdpessoablueosft_vendedor  " + 
                                      "   ,     numero_pedido_forca_venda                 as   vb_numeropedido_fv  " + 
                                      "   ,     coalesce(data_emissao,'1900-01-01')       as   vb_data_emissao  " +
                                      "   ,     coalesce(data_solicitacao,'1900-01-01')   as   vb_data_solicitacao  " + 
                                      "   ,     coalesce(data_faturamento,'1900-01-01')   as   vb_data_faturamento  " + 
                                      "   ,     coalesce(nf_key,0)                        as   df_nf_seq_blue  " + 
                                      "   ,     status_pedido                             as   vb_status_descricao  " + 
                                      "   ,     coalesce(tabela_preco_venda_key,0)        as   tab_preco_seq  " + 
                                      "   ,     coalesce(tabela_preco_venda_versao,0)     as   tab_preco_versao_seq   " + 
                                      " from    fato_pedido_forca_venda  " + 
                                      "      where       1 = 1                        " + 
                                      "      and         data_emissao >= '{0}'     " + 
                                      "      and         data_emissao <= '{1}'     " +
                                      "      and         (       (status_pedido = 'Faturado por Nota Fiscal' and coalesce(nf_key,0) <> 0) " + 
                                      "                       or (status_pedido = 'Entregue' and coalesce(nf_key,0) <> 0) " + 
                                      "                       or status_pedido not in ('Faturado por Nota Fiscal', 'Entregue' )" +
                                      "                  )" + 
                                      "  group by pedido_cliente_venda_key     " +                 
                                      "     ,     pedido_forca_venda_cliente_key     " +           
                                      "     ,     cliente_key     " +                              
                                      "     ,     vendedor_key     " +                             
                                      "     ,     numero_pedido_forca_venda      " +               
                                      "     ,     data_emissao      " +                            
                                      "     ,     data_solicitacao      " +                        
                                      "     ,     coalesce(data_faturamento,'1900-01-01')     " +  
                                      "     ,     coalesce(nf_key,0)     " +                       
                                      "     ,     status_pedido      " +                           
                                      "     ,     coalesce(tabela_preco_venda_key,0)      " +      
                                      "     ,     coalesce(tabela_preco_venda_versao,0)      ",   
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefult(MyConnect, "F0110", 48).ToString("yyyy-MM-dd"),
                                                Pag_Net.Bll._ServiceTools.ObterDataProcessamentoDefultFim(MyConnect, "F0110", 48).ToString("yyyy-MM-dd"));


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
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                foreach (Models.Db item in List)
                {
                    ErroInfo = "ID: " + item.df_nf_seq_blue.ToString();
                    BDExecute.Execute(Pag_Net.F0110.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);
                }
                BDExecute.Commit(DataBaseName.ODBCOXAN);
            }
            catch (Exception ex)
            {
                throw new Exception("F0110 | Migration: " + ErroInfo + " - " + ex.Message);
            }
        }
    }
}

namespace Pag_Net.F0110.Bll
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
            return string.Format("SELECT f0110_crud_tbvendabluesoft (	    " +
                                   "           'DBINSERT'        " +
                                   "       ,     {0}             " +
                                   "       ,     {1}             " +
                                   "       ,     {2}             " +
                                   "       ,     {3}            " +
                                   "       ,     {4}             " +
                                   "       ,    '{5}'            " +
                                   "       ,    '{6}'            " +
                                   "       ,    '{7}'            " +
                                   "       ,    '{8}'            " + 
                                   "       ,    {9}            " +
                                   "       ,    {10}           " +
                                   "       ,    {11}           )",
                                   
                                   
                                 item.vb_seq_blue
                               , item.numeropedido
                               , item.cdpessoabluesoft_cliente
                               , item.cdpessoablueosft_vendedor
                               , item.vb_numeropedido_fv
                               , item.vb_data_emissao.ToString("yyyy-MM-dd")
                               , item.vb_data_faturamento.ToString("yyyy-MM-dd")
                               , item.vb_data_solicitacao.ToString("yyyy-MM-dd")
                               , item.vb_status_descricao
                               , item.df_nf_seq_blue
                               , item.tab_preco_seq
                               , item.tab_preco_versao_seq		   
                            );


        }
    }
}

namespace Pag_Net.F0110.Models
{
    public class Db
    {
        
        public int      vb_seq_blue                      { get; set; }
        public int      numeropedido                     { get; set; }
        public int      cdpessoabluesoft_cliente	     { get; set; }   
        public int      cdpessoablueosft_vendedor	     { get; set; }   
        public int      vb_numeropedido_fv			     { get; set; }   
        public DateTime vb_data_emissao 			     { get; set; }   
        public DateTime vb_data_faturamento			     { get; set; }   
        public DateTime vb_data_solicitacao			     { get; set; }   
        public string   vb_status_descricao			     { get; set; }
        public int      df_nf_seq_blue				     { get; set; }
        public int      tab_preco_seq				     { get; set; }
        public int      tab_preco_versao_seq		     { get; set; }

        
        public Db() {}
        public Db(DataRow i)
        {
             vb_seq_blue                        = Convert.ToInt32(i["vb_seq_blue"].ToString());
             numeropedido                       = Convert.ToInt32(i["numeropedido"].ToString());
             cdpessoabluesoft_cliente	        = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString());
             cdpessoablueosft_vendedor	        = Convert.ToInt32(i["cdpessoablueosft_vendedor"].ToString());
             vb_numeropedido_fv			        = Convert.ToInt32(i["vb_numeropedido_fv"].ToString());
             vb_data_emissao 			        = Convert.ToDateTime(i["vb_data_emissao"].ToString());
             vb_data_faturamento			    = Convert.ToDateTime(i["vb_data_faturamento"].ToString());
             vb_data_solicitacao                = Convert.ToDateTime(i["vb_data_solicitacao"].ToString());
             vb_status_descricao                = i["vb_status_descricao"].ToString();
             df_nf_seq_blue				        = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
             tab_preco_seq				        = Convert.ToInt32(i["tab_preco_seq"].ToString());
             tab_preco_versao_seq		        = Convert.ToInt32(i["tab_preco_versao_seq"].ToString());
        }





    }
}
