using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.Models;



namespace Pag_Net.Bll.F0049_01
{

    public static class RedShift
    {
        public static string get(
            DateTime data_inicial,
            DateTime data_final
            )
        {


            string SQL = string.Format(
                         " SELECT      coalesce(conta_bancaria_key,0)          as    cco_seq_blue                               " +
                         "         ,   coalesce(pessoa_key,0)                  as    cco_cdpessoabluesoft                       " +
                         "         ,   left(coalesce(banco,''),60)             as    cco_banco                                  " +
                         "         ,   coalesce(agencia_numero,0)              as    cco_agencia_numero                         " +
                         "         ,   coalesce(agencia_digito,'0')             as    cco_agencia_digito                         " +
                         "         ,   left(coalesce(agencia,''),60)                     as    cco_agencia                  " +
                         "         ,   coalesce(conta_bancaria_numero,0)      as    cco_conta_bancaria_numero                  " +
                         "         ,   coalesce(conta_bancaria_digito,'0')       as    cco_conta_bancaria_digito                  " +
                         "         ,   left(coalesce(titular,''),60)           as    cco_titular                                " +
                         "         ,   left(coalesce(tipo_conta_bancaria,''),60)        as    cco_conta_bancaria_tipo_descricao          " +
                         "         ,   cast( case when coalesce(situacao_conta,'') = 'Ativa' then 1 else 0 end as int)          " + 
                         "                                         as    cco_status                                             " +
                         "   FROM      CONTA_BANCARIA ORDER BY conta_bancaria_key ASC                                           "); 
                         
            return SQL;
        }
    }

    public static class Postgres
    {
        public static string post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            string _SqlCommand,
            bool _Api,
            Db item)
        {
            return string.Format("SELECT " + Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0049_01) +
                                       "  ('DBINSERT', " + 
                                       "  {0}   , " + 
                                       "  {1}   , " + 
                                       " '{2}'  , " +
                                       "  {3}   , " +
                                       "  {4}   , " +
                                       " '{5}'  , " +
                                       "  {6}   , " +
                                       "  {7}   , " +
                                       " '{8}'  , " +
                                       " '{9}'  , " +  
                                       " {10}   ) "
                                    , item.cco_seq_blue.ToString() 				      
                                    , item.cco_cdpessoabluesoft.ToString()
                                    , item.cco_banco.ToString()
                                    , item.cco_agencia_numero.ToString()
                                    , item.cco_agencia_digito.ToString()
                                    , item.cco_agencia.ToString()
                                    , item.cco_conta_bancaria_numero.ToString()
                                    , item.cco_conta_bancaria_digito.ToString()
                                    , item.cco_titular.ToString()
                                    , item.cco_conta_bancaria_tipo_descricao.ToString()
                                    , item.cco_status.ToString()    
                                     );
        }

    }

    public class Db
    {

		public int	        cco_seq_blue 				        {get;set;}
		public int	        cco_cdpessoabluesoft		        {get;set;}    
		public string       cco_banco					        {get;set;}
		public int	    	cco_agencia_numero				    {get;set;}	    
		public int	    	cco_agencia_digito				    {get;set;}	
		public string   	cco_agencia						    {get;set;}	
		public int	    	cco_conta_bancaria_numero 		    {get;set;}	
		public int	    	cco_conta_bancaria_digito 		    {get;set;}	
		public string   	cco_titular						    {get;set;}	
		public string   	cco_conta_bancaria_tipo_descricao   {get;set;}
        public int          cco_status                          { get; set; }	

        public Db()
        {

        }

        public Db(System.Data.DataRow i)
        {
            string errorString = i[0].ToString();
            try
            {
                cco_seq_blue = Convert.ToInt32(i["cco_seq_blue"]);
                cco_cdpessoabluesoft = Convert.ToInt32(i["cco_cdpessoabluesoft"]);
                cco_banco = i["cco_banco"].ToString();
                cco_agencia_numero = Convert.ToInt32(i["cco_agencia_numero"]);
                cco_agencia_digito = 0;
                //cco_agencia_digito = Convert.ToInt32(i["cco_agencia_digito"]);
                cco_agencia = i["cco_agencia"].ToString();
                cco_conta_bancaria_numero = Convert.ToInt32(i["cco_conta_bancaria_numero"]);
                //cco_conta_bancaria_digito = Convert.ToInt32(i["cco_conta_bancaria_digito"]);
                cco_conta_bancaria_digito = 0;
                cco_titular = i["cco_titular"].ToString();
                cco_conta_bancaria_tipo_descricao = i["cco_conta_bancaria_tipo_descricao"].ToString();
                cco_status = Convert.ToInt32(i["cco_status"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }
    }

}

                    