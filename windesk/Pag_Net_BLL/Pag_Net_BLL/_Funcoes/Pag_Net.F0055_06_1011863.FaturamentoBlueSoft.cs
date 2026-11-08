using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.F0055_06
{
    public static class RedShift
    {
        public static string get(
            DateTime data_inicial, 
            DateTime data_final
            )
        {

            string _redshift_get = string.Format(
                                   "SELECT    fv.loja_key                                 as   un_cd                                        " +
                                   "      ,   fv.pedido_forca_venda_cliente_key           as   numeropedido                                 " +
                                   "      ,   fv.numero_pedido_forca_venda                as   numeropedido_fv                              " +
                                   "      ,   CASE fv.status_pedido                                                                         " +
                                   "          WHEN 'Em Digitação'                 THEN 10                                                   " +
                                   "          WHEN 'Aguardando Análise Gerencial' THEN 20                                                   " +
                                   "          WHEN 'Em Análise Gerencial'         THEN 25                                                   " +
                                   "          WHEN 'Em Análise de Crédito'        THEN 27                                                   " +
                                   "          WHEN 'Fechado'                      THEN 30                                                   " +
                                   "          WHEN 'Em Separação'                 THEN 40                                                   " +
                                   "          WHEN 'Separado'                     THEN 45                                                   " +
                                   "          WHEN 'Faturando'                    THEN 50                                                   " +
                                   "          WHEN 'Faturado por Nota Fiscal'     THEN 55                                                   " +
                                   "          WHEN 'Entregue'                     THEN 70                                                   " +
                                   "          WHEN 'Cancelado'                    THEN 90                                                   " +
                                   "          ELSE 99                                                                                       " +
                                   "          END as faturamento_fv_status_cd                                                               " +
                                   "      ,   CASE fv.tipo_pedido_venda                                                                     " +
                                   "               WHEN 'Venda'                 THEN 10                                                     " +
                                   "               WHEN 'Doação ou Bonificação' THEN 20                                                     " +
                                   "               WHEN 'Remessa de Troca'      THEN 30                                                     " +
                                   "              ELSE 99                                                                                   " +
                                   "          END as faturamento_fv_tipopedido                                                              " +
                                   "       ,   coalesce(fv.cliente_key,0)                  as   faturamento_fv_cdpessoabluesoft_cliente     " +
                                   "       ,   coalesce(fv.vendedor_key,0)                 as   faturamento_fv_cdpessoabluesoft_vendedor    " +
                                   "       ,   fv.tabela_preco_venda_key                   as   fv_tabelapreco_cd                           " +
                                   "       ,   fv.tabela_preco_venda_versao                as   fv_tabelapreco_versao_cd                    " +
                                   "       ,   fv.tipo_de_entrega                          as   faturamento_fv_tipo_entrega_descricao       " +
                                   "       ,   fv.origem_pedido                            as   faturamento_fv_origem_pedido                " +
                                   "       ,   fv.data_solicitacao                         as   faturamento_fv_data_solicitacao             " +
                                   "       ,   fv.data_emissao                             as   faturamento_fv_data_emissao                 " +
                                   "       ,   max(coalesce(fv.data_faturamento,'1900-01-01'))  as   faturamento_fv_data_faturamento             " +
                                   "       ,   count(distinct(produto_key))                as   faturamento_fv_numero_itens                 " +
                                   "       ,   sum(preco_final * volume)                   as   faturamento_fv_valor                        " +
                                   "       ,   sum(preco_final * volume_faturado)          as   faturamento_fv_valor_faturamento            " +
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
                                   "                                                     where data_ocorrencia = '{1}'                     " +
                                   "                                                     group by pedido_forca_venda_cliente_key            " + 
                                   "                                                     )                                                  " + 
                                   "                                                                                                        " +  
                                   " group by  fv.loja_key                                                                                  " +
                                   "       ,   fv.pedido_forca_venda_cliente_key                                                            " +
                                   "       ,   fv.numero_pedido_forca_venda                                                                 " +
                                   "       ,   fv.status_pedido                                                                             " +
                                   "       ,   fv.tipo_pedido_venda                                                                         " +
                                   "       ,   CASE fv.status_pedido                                                                        " +
                                   "           WHEN 'Em Digitação'                 THEN 10                                                  " +
                                   "           WHEN 'Aguardando Análise Gerencial' THEN 20                                                  " +
                                   "           WHEN 'Em Análise Gerencial'         THEN 25                                                  " +
                                   "           WHEN 'Em Análise de Crédito'        THEN 27                                                  " +
                                   "           WHEN 'Fechado'                      THEN 30                                                  " +
                                   "           WHEN 'Em Separação'                 THEN 40                                                  " +
                                   "           WHEN 'Separado'                     THEN 45                                                  " +
                                   "           WHEN 'Faturando'                    THEN 50                                                  " +
                                   "           WHEN 'Faturado por Nota Fiscal'     THEN 55                                                  " +
                                   "           WHEN 'Entregue'                     THEN 70                                                  " +
                                   "           WHEN 'Cancelado'                    THEN 90                                                  " +
                                   "           END                                                                                          " +
                                   "       ,   fv.cliente_key                                                                               " +
                                   "       ,   fv.vendedor_key                                                                              " +
                                   "       ,   fv.tabela_preco_venda_key                                                                    " +
                                   "       ,   fv.tabela_preco_venda_versao                                                                 " +
                                   "       ,   fv.tipo_de_entrega                                                                           " +
                                   "       ,   fv.origem_pedido                                                                             " +
                                   "       ,   fv.data_solicitacao                                                                          " +
                                   "       ,   fv.data_emissao                                                                              ",
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
                Pag_Net.Bll.F0055_06.Db _db
            )
        {

            try
            {
                string _sql_post = string.Format(  "SELECT " + 
                                                   " f0055_06_1011877_tbfaturamentoBlueSoft "  + 
                                                   "   ( 'DBINSERT'  " +                 
                                                   "          ,  {0}         " +        
                                                   "          ,  {1}         " +        	
                                                   "          ,  {2}         " +        	
                                                   "          ,  {3}         " +        	
                                                   "          ,  {4}         " +        	
                                                   "          ,  {5}         " +        	
                                                   "          ,  {6}         " +        	
                                                   "          ,  {7}         " +        	
                                                   "          ,  {8}         " +        	
//                                                   "          ,  {9}         " +        	
//                                                   "          ,  {10}        " +        	
                                                   "          , '{9}'       " +      		
                                                   "          , '{10}'       " +      	
                                                   "          , '{11}'       " +      		
                                                   "          , '{12}'       " +      		
                                                   "          , '{13}'       " +      		
                                                   "          ,  {14}        " +        	
                                                   "          ,  {15}        " +        	
                                                   "          ,  {16}        )"                     
		                                    ,	_db.un_cd									
		                                    ,	_db.numeropedido 								
		                                    ,	_db.numeropedido_fv								
		                                    ,	_db.faturamento_fv_status_cd					
		                                    ,	_db.faturamento_fv_tipopedido					
		                                    ,	_db.faturamento_fv_cdpessoabluesoft_cliente		
		                                    ,	_db.faturamento_fv_cdpessoabluesoft_vendedor	
		                                    ,	_db.fv_tabelapreco_cd							
		                                    ,	_db.fv_tabelapreco_versao_cd					
		                                    //,	_db.df_nf_seq_blue								
		                                    //,	_db.df_nf_seq_blue_dev							
		                                    ,	_db.faturamento_fv_tipo_entrega_descricao 		
		                                    , 	_db.faturamento_fv_origem_pedido 				
		                                    ,	_db.faturamento_fv_data_solicitacao.ToString("yyyy-MM-dd")
                                            ,   _db.faturamento_fv_data_emissao.ToString("yyyy-MM-dd")
                                            ,   _db.faturamento_fv_data_faturamento.ToString("yyyy-MM-dd")				
		                                    ,	_db.faturamento_fv_numero_itens					
		                                    ,	_db.faturamento_fv_valor.ToString("0.00").Replace(",",".")
                                            ,   _db.faturamento_fv_valor_faturamento.ToString("0.00").Replace(",",".")
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
        public int faturamento_fv_status_cd { get; set; }
        public int faturamento_fv_tipopedido { get; set; }
        public int faturamento_fv_cdpessoabluesoft_cliente { get; set; }
        public int faturamento_fv_cdpessoabluesoft_vendedor { get; set; }
        public int fv_tabelapreco_cd { get; set; }
        public int fv_tabelapreco_versao_cd { get; set; }
        //public int df_nf_seq_blue { get; set; }
        //public int df_nf_seq_blue_dev { get; set; }
        public string faturamento_fv_tipo_entrega_descricao { get; set; }
        public string faturamento_fv_origem_pedido { get; set; }
        public DateTime faturamento_fv_data_solicitacao { get; set; }
        public DateTime faturamento_fv_data_emissao { get; set; }
        public DateTime faturamento_fv_data_faturamento { get; set; }
        public int faturamento_fv_numero_itens { get; set; }
        public double faturamento_fv_valor { get; set; }
        public double faturamento_fv_valor_faturamento { get; set; }


        public Db(
                      int _un_cd
                 , int _numeropedido
                 , int _numeropedido_fv
                 , int _faturamento_fv_status_cd
                 , int _faturamento_fv_tipopedido
                 , int _faturamento_fv_cdpessoabluesoft_cliente
                 , int _faturamento_fv_cdpessoabluesoft_vendedor
                 , int _fv_tabelapreco_cd
                 , int _fv_tabelapreco_versao_cd
                 //, int _df_nf_seq_blue
                // , int _df_nf_seq_blue_dev
                 , string _faturamento_fv_tipo_entrega_descricao
                 , string _faturamento_fv_origem_pedido
                 , DateTime _faturamento_fv_data_solicitacao
                 , DateTime _faturamento_fv_data_emissao
                 , DateTime _faturamento_fv_data_faturamento
                 , int _faturamento_fv_numero_itens
                 , double _faturamento_fv_valor
                 , double _faturamento_fv_valor_faturamento
            )
        {
            un_cd = _un_cd;
            numeropedido = _numeropedido;
            numeropedido_fv = _numeropedido_fv;
            faturamento_fv_status_cd = _faturamento_fv_status_cd;
            faturamento_fv_tipopedido = _faturamento_fv_tipopedido;
            faturamento_fv_cdpessoabluesoft_cliente = _faturamento_fv_cdpessoabluesoft_cliente;
            faturamento_fv_cdpessoabluesoft_vendedor = _faturamento_fv_cdpessoabluesoft_vendedor;
            fv_tabelapreco_cd = _fv_tabelapreco_cd;
            fv_tabelapreco_versao_cd = _fv_tabelapreco_versao_cd;
            //df_nf_seq_blue = _df_nf_seq_blue;
            //df_nf_seq_blue_dev = _df_nf_seq_blue_dev;
            faturamento_fv_tipo_entrega_descricao = _faturamento_fv_tipo_entrega_descricao;
            faturamento_fv_origem_pedido = _faturamento_fv_origem_pedido;
            faturamento_fv_data_solicitacao = _faturamento_fv_data_solicitacao;
            faturamento_fv_data_emissao = _faturamento_fv_data_emissao;
            faturamento_fv_data_faturamento = _faturamento_fv_data_faturamento;
            faturamento_fv_numero_itens = _faturamento_fv_numero_itens;
            faturamento_fv_valor = _faturamento_fv_valor;
            faturamento_fv_valor_faturamento = _faturamento_fv_valor_faturamento;

        }

        public Db(DataRow i)
        {
            string _error_publish_dataRow = "";
            try
            {
                _error_publish_dataRow = "Publish field un_cd"; un_cd = Convert.ToInt32(i["un_cd"].ToString());
                _error_publish_dataRow = "Publish field numeropedido"; numeropedido = Convert.ToInt32(i["numeropedido"].ToString());
                _error_publish_dataRow = "Publish field numeropedido_fv"; numeropedido_fv = Convert.ToInt32(i["numeropedido_fv"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_status_cd"; faturamento_fv_status_cd = Convert.ToInt32(i["faturamento_fv_status_cd"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_tipopedido"; faturamento_fv_tipopedido = Convert.ToInt32(i["faturamento_fv_tipopedido"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_cdpessoabluesoft_cliente"; faturamento_fv_cdpessoabluesoft_cliente = Convert.ToInt32(i["faturamento_fv_cdpessoabluesoft_cliente"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_cdpessoabluesoft_vendedor"; faturamento_fv_cdpessoabluesoft_vendedor = Convert.ToInt32(i["faturamento_fv_cdpessoabluesoft_vendedor"].ToString());
                _error_publish_dataRow = "Publish field fv_tabelapreco_cd"; fv_tabelapreco_cd = Convert.ToInt32(i["fv_tabelapreco_cd"].ToString());
                _error_publish_dataRow = "Publish field fv_tabelapreco_versao_cd"; fv_tabelapreco_versao_cd = Convert.ToInt32(i["fv_tabelapreco_versao_cd"].ToString());
                //_error_publish_dataRow = "Publish field df_nf_seq_blue"; df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                //_error_publish_dataRow = "Publish field df_nf_seq_blue_dev"; df_nf_seq_blue_dev = Convert.ToInt32(i["df_nf_seq_blue_dev"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_tipo_entrega_descricao"; faturamento_fv_tipo_entrega_descricao = i["faturamento_fv_tipo_entrega_descricao"].ToString();
                _error_publish_dataRow = "Publish field faturamento_fv_origem_pedido"; faturamento_fv_origem_pedido = i["faturamento_fv_origem_pedido"].ToString();
                _error_publish_dataRow = "Publish field faturamento_fv_data_solicitacao"; faturamento_fv_data_solicitacao = Convert.ToDateTime(i["faturamento_fv_data_solicitacao"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_data_emissao"; faturamento_fv_data_emissao = Convert.ToDateTime(i["faturamento_fv_data_emissao"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_data_faturamento"; faturamento_fv_data_faturamento = Convert.ToDateTime(i["faturamento_fv_data_faturamento"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_numero_itens"; faturamento_fv_numero_itens = Convert.ToInt32(i["faturamento_fv_numero_itens"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_valor"; faturamento_fv_valor = Convert.ToDouble(i["faturamento_fv_valor"].ToString());
                _error_publish_dataRow = "Publish field faturamento_fv_valor_faturamento"; faturamento_fv_valor_faturamento = Convert.ToDouble(i["faturamento_fv_valor_faturamento"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Class {0}\x0A Command: {1} - Error: {2}", "Pag_Net.Bll.F0055_01.Db(DataRow i)\x0A", _error_publish_dataRow, ex.Message));
            }

        }
    }
}








