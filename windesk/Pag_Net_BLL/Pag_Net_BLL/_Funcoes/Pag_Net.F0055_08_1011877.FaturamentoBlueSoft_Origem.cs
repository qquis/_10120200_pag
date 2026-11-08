using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.F0055_08
{
    public static class RedShift
    {
        public static string get(
            DateTime data_inicial, 
            DateTime data_final
            )
        {

            string _redshift_get = string.Format(
                                   "SELECT     fv.loja_key                                 as   un_cd                                        " +
                                   "       ,   fv.pedido_forca_venda_cliente_key           as   numeropedido                                 " +
                                   "       ,   fv.numero_pedido_forca_venda                as   numeropedido_fv                              " +
                                   "       ,   coalesce(fv.nf_key,0)                       as   df_nf_seq_blue                              " +
                                   " FROM      FATO_PEDIDO_FORCA_VENDA fv                                                                   " +
                                   " WHERE     1 = 1                                                                                        " +
                                   " AND       FV.pedido_forca_venda_cliente_key  in (                                                      " +
                                   "                                                     select pedido_forca_venda_cliente_key              " +
                                   "                                                     from   fato_pedido_forca_venda                     " +
                                   "                                                     where  data_emissao >= '{0}'                       " +
                                   "                                                       and  data_emissao <= '{1}'                       " +
                                   "                                                     group  by pedido_forca_venda_cliente_key           " +
                                   "                                                     union                                              " +
                                   "                                                     select  pedido_forca_venda_cliente_key             " +
                                   "                                                     from    log_pedido_forca_venda                     " +
                                   "                                                     where data_ocorrencia  = '{1}'                     " +
                                  //"                                                       and data_ocorrencia >= '{1}'                     " +
                                   "                                                     group by pedido_forca_venda_cliente_key            " +
                                   "                                                     )                                                  " +
                                   "                                                                                                        " +
                                //" AND       FV.DATA_EMISSAO >= '{0}'                                                                     " +
                                //" AND       FV.DATA_EMISSAO <= '{1}'                                                                     " +
                                   " group by  fv.loja_key                                                                                  " +
                                   "       ,   fv.pedido_forca_venda_cliente_key                                                            " +
                                   "       ,   fv.numero_pedido_forca_venda                                                                 " +
                                   "       ,   coalesce(fv.nf_key,0)                                                                        " , 
                                                        data_inicial.ToString("yyyy-MM-dd"), 
                                                        data_final.ToString("yyyy-MM-dd")
                                   );
            return _redshift_get;
        }
    }


    public static class Postgre
    {
  
        public static string Post(
                Pag_Net.Models.modelSistemaUsuario MyConnect,
				string _SqlCommand,
				bool _Api ,
                Pag_Net.Bll.F0055_08.Db _db
            )
        {

            try
            {
                string _sql_post = string.Format(  "SELECT " + 
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0055_08_tbfaturamentoBlueSoft_origem)  + 
                                                   "   ( 'DBINSERT'  " +                 
                                                   "          ,  {0}         " +        
                                                   "          ,  {1}         " +        	
                                                   "          ,  {2}         " +        	
                                                   "          ,  {3}        )",                     
		                                    	_db.un_cd									
		                                    ,	_db.numeropedido 								
		                                    ,	_db.numeropedido_fv								
		                                    ,	_db.df_nf_seq_blue								
                                            );

                return _sql_post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class Db
    {
        public int un_cd { get; set; }
        public int numeropedido { get; set; }
        public int numeropedido_fv { get; set; }
        public int df_nf_seq_blue { get; set; }


        public Db(
                      int _un_cd
                 , int _numeropedido
                 , int _numeropedido_fv
                 , int _df_nf_seq_blue
            )
        {
            un_cd = _un_cd;
            numeropedido = _numeropedido;
            numeropedido_fv = _numeropedido_fv;
            df_nf_seq_blue = _df_nf_seq_blue;

        }

        public Db(DataRow i)
        {
            string _error_publish_dataRow = "";
            try
            {
                _error_publish_dataRow = "Publish field un_cd"; un_cd = Convert.ToInt32(i["un_cd"].ToString());
                _error_publish_dataRow = "Publish field numeropedido"; numeropedido = Convert.ToInt32(i["numeropedido"].ToString());
                _error_publish_dataRow = "Publish field numeropedido_fv"; numeropedido_fv = Convert.ToInt32(i["numeropedido_fv"].ToString());
                _error_publish_dataRow = "Publish field df_nf_seq_blue"; df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Class {0}\x0A Command: {1} - Error: {2}", "Pag_Net.Bll.F0055_01.Db(DataRow i)\x0A", _error_publish_dataRow, ex.Message));
            }

        }
    }
}








