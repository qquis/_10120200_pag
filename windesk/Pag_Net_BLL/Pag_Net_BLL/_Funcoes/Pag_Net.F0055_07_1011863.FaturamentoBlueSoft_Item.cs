using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.F0055_07
{
    public static class RedShift
    {
        public static string get(
            DateTime data_inicial, 
            DateTime data_final
            )
        {

            string _redshift_get = string.Format(
                                   "SELECT     fv.loja_key                                 as   un_cd " + 
                                   "       ,   fv.pedido_forca_venda_cliente_key           as   numeropedido " + 
                                   "       ,   fv.numero_pedido_forca_venda                as   numeropedido_fv " + 
                                   "       ,   coalesce(fv.nf_key,0)                       as   df_nf_seq_blue " + 
                                   "       ,   fv.PRODUTO_KEY                              as   prb_cdprodutobluesoft " + 
                                   "       ,   pr.produto_unitario_key                     as   prb_cdprodutobluesoft_unitario " + 
                                   "       ,   case coalesce(pr.embalagem_key,'UN') "  + 
                                   "                WHEN 'UNIDADE' then 'UN' " + 
                                   "                WHEN 'CAIXA'   then 'CX' " + 
                                   "                WHEN 'BANDEJA' then 'BD' " + 
                                   "                WHEN 'KILO'    then 'KG' " + 
                                   "                else 'UN'      end as   prb_embalagem " + 
                                   "       ,   coalesce(pr.fator_estoque,1)                as   prb_fatorestoque " + 
                                   "       ,   coalesce(pr.descricao,'-')                  as   prb_descricao " + 
                                   "       ,   coalesce(fv.embalagem,'-')                  as   faturamento_fv_i_embalagem_desc " + 
                                   "       ,   fv.volume                                   as   faturamento_fv_i_qtde_solicitado " + 
                                   "       ,   fv.volume_faturado                          as   faturamento_fv_i_qtde_faturado " + 
                                   "       ,   coalesce(fv.custo_medio,0)                  as   faturamento_fv_i_valor_custo_blue " + 
                                   "       ,   coalesce(fv.preco_tabela,0)                 as   faturamento_fv_i_preco_tabela " + 
                                   "       ,   coalesce(fv.preco_aplicado,0)               as   faturamento_fv_i_preco " + 
                                   "       ,   coalesce(fv.preco_final,0)                  as   faturamento_fv_i_preco_aplicado " + 
                                   "       ,   coalesce(fv.valor_unitario_verba_vend,0)    as   faturamento_fv_i_verba " + 
                                   "       ,   coalesce(fv.valor_unitario_verba_ger,0)     as   faturamento_fv_i_gerencia " + 
                                   "       ,   coalesce(fv.valor_unitario_verba_sup,0)     as   faturamento_fv_i_supervisao  " + 
                                   " FROM        FATO_PEDIDO_FORCA_VENDA fv " + 
                                   " INNER JOIN  PRODUTO_D pr on pr.produto_key = fv.produto_key  " + 
                                   " WHERE       1 = 1  " +
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
                                   "                                                                                                        ",
                //" AND       FV.DATA_EMISSAO >= '{0}'                                                                     " +
                //" AND       FV.DATA_EMISSAO <= '{1}'                                                                     " + ",
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
                Pag_Net.Bll.F0055_07.Db _db
            )
        {

            try
            {
                string _sql_post = string.Format(  "SELECT " + 
                                                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0055_07_tbfaturamentoBlueSoft_item)  + 
                                                   "   ( 'DBINSERT'  " +                 
                                                   "          ,  {0}         " +        
                                                   "          ,  {1}         " +        	
                                                   "          ,  {2}         " +        	
                                                   "          ,  {3}         " +        	
                                                   "          ,  {4}         " +        	
                                                   "          , '{5}'       " +        	
                                                   "          ,  {6}         " +        	
                                                   "          , '{7}'       " +        	
                                                   "          ,  {8}         " +        	
                                                   "          ,  {9}         " +        	
                                                   "          ,  {10}        " +        	
                                                   "          ,  {11}        " +      		
                                                   "          ,  {12}        " +      	
                                                   "          ,  {13}        " +      		
                                                   "          ,  {14}        " +      		
                                                   "          ,  {15}        " +      		
                                                   "          ,  {16}        " + 
                                                   "          ,  {17} )"
                                                , _db.un_cd
                                                , _db.numeropedido
                                                , _db.numeropedido_fv
                                                , _db.prb_cdprodutobluesoft
                                                , _db.prb_cdprodutobluesoft_unitario
                                                , _db.prb_embalagem.ToString()
                                                , _db.prb_fatorestoque.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_embalagem_desc.ToString()
                                                , _db.faturamento_fv_i_qtde_solicitado.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_qtde_faturado.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_valor_custo_blue.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_preco_tabela.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_preco.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_preco_aplicado.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_verba.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_gerencia.ToString("0.00").Replace(",", ".")
                                                , _db.faturamento_fv_i_supervisao.ToString("0.00").Replace(",",".")
                                                , _db.df_nf_seq_blue.ToString()
                                            );

                return _sql_post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    
    }
}
namespace Pag_Net.Bll.F0055_07
{

    public class Db
    {
        public int      un_cd                                   {get;set;}            
        public int      numeropedido                            {get;set;}            
        public int      numeropedido_fv                         {get;set;}            
	 	public int	    prb_cdprodutobluesoft                   {get;set;}            
	 	public int	    prb_cdprodutobluesoft_unitario          {get;set;}            
		public string   prb_embalagem 					        {get;set;}               
		public double	prb_fatorestoque				        {get;set;}               
		public string	faturamento_fv_i_embalagem_desc         {get;set;}               
		public double	faturamento_fv_i_qtde_solicitado        {get;set;}               
		public double	faturamento_fv_i_qtde_faturado	        {get;set;}                   
		public double	faturamento_fv_i_valor_custo_blue       {get;set;}                   
		public double	faturamento_fv_i_preco_tabela	        {get;set;}               
		public double	faturamento_fv_i_preco			        {get;set;}                   
		public double	faturamento_fv_i_preco_aplicado	        {get;set;}                   
		public double	faturamento_fv_i_verba 			        {get;set;}               
		public double	faturamento_fv_i_gerencia 		        {get;set;}
        public double   faturamento_fv_i_supervisao             {get;set;}
        public int df_nf_seq_blue { get; set; }

        public Db(
                   int      _un_cd                                 
                 , int      _numeropedido
                 , int      _numeropedido_fv
                 , int      _prb_cdprodutobluesoft
                 , int      _prb_cdprodutobluesoft_unitario
                 , string   _prb_embalagem
                 , double   _prb_fatorestoque
                 , string   _faturamento_fv_i_embalagem_desc
                 , double   _faturamento_fv_i_qtde_solicitado
                 , double   _faturamento_fv_i_qtde_faturado
                 , double   _faturamento_fv_i_valor_custo_blue
                 , double   _faturamento_fv_i_preco_tabela
                 , double   _faturamento_fv_i_preco
                 , double   _faturamento_fv_i_preco_aplicado
                 , double   _faturamento_fv_i_verba
                 , double   _faturamento_fv_i_gerencia 		      
                 , double   _faturamento_fv_i_supervisao
                 , int  _df_nf_seq_blue

            )
        {


            un_cd                                      =     _un_cd                                         ;
            numeropedido                               =     _numeropedido                                  ;
            numeropedido_fv                            =     _numeropedido_fv                               ;
            prb_cdprodutobluesoft                      =     _prb_cdprodutobluesoft                         ;    
            prb_cdprodutobluesoft_unitario             =     _prb_cdprodutobluesoft_unitario                ;
            prb_embalagem 					           =     _prb_embalagem                                 ;
            prb_fatorestoque				           =     _prb_fatorestoque                              ;
            faturamento_fv_i_embalagem_desc            =     _faturamento_fv_i_embalagem_desc               ;
            faturamento_fv_i_qtde_solicitado           =     _faturamento_fv_i_qtde_solicitado              ;
            faturamento_fv_i_qtde_faturado	           =     _faturamento_fv_i_qtde_faturado                ;
            faturamento_fv_i_valor_custo_blue          =     _faturamento_fv_i_valor_custo_blue             ;
            faturamento_fv_i_preco_tabela	           =     _faturamento_fv_i_preco_tabela                 ;
            faturamento_fv_i_preco			           =     _faturamento_fv_i_preco                        ;
            faturamento_fv_i_preco_aplicado	           =     _faturamento_fv_i_preco_aplicado               ;
            faturamento_fv_i_verba 			           =     _faturamento_fv_i_verba                        ;
            faturamento_fv_i_gerencia 		           =     _faturamento_fv_i_gerencia 		            ;
            faturamento_fv_i_supervisao                =     _faturamento_fv_i_supervisao                   ;
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
              _error_publish_dataRow = "Publish field prb_cdprodutobluesoft"; prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
              _error_publish_dataRow = "Publish field prb_cdprodutobluesoft_unitario"; prb_cdprodutobluesoft_unitario = Convert.ToInt32(i["prb_cdprodutobluesoft_unitario"].ToString());
              _error_publish_dataRow = "Publish field prb_embalagem"; prb_embalagem = i["prb_embalagem"].ToString();
              _error_publish_dataRow = "Publish field prb_fatorestoque"; prb_fatorestoque = Convert.ToDouble(i["prb_fatorestoque"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_embalagem_desc"; faturamento_fv_i_embalagem_desc = i["faturamento_fv_i_embalagem_desc"].ToString();
              _error_publish_dataRow = "Publish field faturamento_fv_i_qtde_solicitado"; faturamento_fv_i_qtde_solicitado = Convert.ToDouble(i["faturamento_fv_i_qtde_solicitado"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_qtde_faturado"; faturamento_fv_i_qtde_faturado = Convert.ToDouble(i["faturamento_fv_i_qtde_faturado"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_valor_custo_blue"; faturamento_fv_i_valor_custo_blue = Convert.ToDouble(i["faturamento_fv_i_valor_custo_blue"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_preco_tabela"; faturamento_fv_i_preco_tabela = Convert.ToDouble(i["faturamento_fv_i_preco_tabela"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_preco"; faturamento_fv_i_preco = Convert.ToDouble(i["faturamento_fv_i_preco"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_preco_aplicado"; faturamento_fv_i_preco_aplicado = Convert.ToDouble(i["faturamento_fv_i_preco_aplicado"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_verba"; faturamento_fv_i_verba = Convert.ToDouble(i["faturamento_fv_i_verba"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_gerencia"; faturamento_fv_i_gerencia = Convert.ToDouble(i["faturamento_fv_i_gerencia"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_supervisao"; faturamento_fv_i_supervisao = Convert.ToDouble(i["faturamento_fv_i_supervisao"].ToString());
              _error_publish_dataRow = "Publish field faturamento_fv_i_supervisao"; df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());

          }
          catch (Exception ex)
          {
              throw new Exception( string.Format("Class {0}\x0A Command: {1} - Error: {2}", "Pag_Net.Bll.F0055_07.Db(DataRow i)\x0A",  _error_publish_dataRow, ex.Message));
          }

      }
    }
}




				