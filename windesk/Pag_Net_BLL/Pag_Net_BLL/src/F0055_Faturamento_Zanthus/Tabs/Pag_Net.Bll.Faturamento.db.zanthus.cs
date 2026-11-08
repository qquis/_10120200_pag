using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0055_Faturamento_Zanthus
{
    public class tbfaturamentozanthus
    {
            public DateTime     dtlog_insert                                    { get; set;  }
            public DateTime     dtlog_update                                    { get; set; }
	        public int          fat_zanthus_seq						            {get;set;}
            public DateTime     fat_zanthus_data_m00af                          { get; set; }
	        public int          fat_zanthus_sat_ecf_m00ac 			            {get;set;}
	        public int          fat_zanthus_cupomfiscal_m00ad 			        {get;set;}
	        public string       fat_zanthus_cupomfiscalid_M00_id_unico 	        {get;set;}
	        public int          fat_zanthus_cupomfiscal_cancelador_m45bo      {get;set;}
	        public int          fat_zanthus_notafiscal_numnota 			    {get;set;}
	        public int          fat_zanthus_notafiscal_serie_nf 		    {get;set;}
	        public string       fat_zanthus_notafiscal_chave_m45xb		    {get;set;}
            public int          fat_zanthus_status_cancelado                {get;set;}
            public string       fat_zanthus_cpf_cnpj_m45bv                  { get; set; }    
            public DateTime     fat_zanthus_hora_ini_m45ai                  { get; set; }
            public DateTime     fat_zanthus_hora_fim_m45au                  { get; set; }
            public double       fat_zanthus_cupomfiscal_valor_m45ak         { get; set; }
            public int          fat_zanthus_cod_funcionario_m45ah                    { get; set;  }
            public string       fat_zanthus_voucher_cod_m50ar                   { get; set;  }
            public double       fat_zanthus_voucher_valor_m50at                 { get; set; }
            public int          fat_zanthus_voucher_count_m50ag                 { get; set;  }
            public int  	    fat_zanthus_conferencia 	{ get; set; } 
	        public int          fat_zanthus_processado 		{ get; set; }
            public int          fat_zanthus_pag { get; set; }
            
            
        public tbfaturamentozanthus() 
        {
            fat_zanthus_seq						        = 0 ;
            fat_zanthus_data_m00af = DateTime.Now;
            fat_zanthus_sat_ecf_m00ac 			        = 0 ;
            fat_zanthus_cupomfiscal_m00ad 			    = 0 ;
            fat_zanthus_cupomfiscalid_M00_id_unico 		= "0" ;
            fat_zanthus_cupomfiscal_cancelador_m45bo          = 0 ;
            fat_zanthus_notafiscal_numnota 			    = 0 ;
            fat_zanthus_notafiscal_serie_nf 		    = 0 ;
            fat_zanthus_notafiscal_chave_m45xb		    = "0" ;
            fat_zanthus_status_cancelado                = 0;
            fat_zanthus_cupomfiscal_valor_m45ak = 0;
            fat_zanthus_cpf_cnpj_m45bv = "0";
            fat_zanthus_hora_ini_m45ai = DateTime.Now;
            fat_zanthus_hora_fim_m45au = DateTime.Now;
            fat_zanthus_cod_funcionario_m45ah = 0;
            fat_zanthus_voucher_cod_m50ar  = "";
            fat_zanthus_voucher_valor_m50at = 0;
            fat_zanthus_voucher_count_m50ag = 0;
            fat_zanthus_conferencia = 0;
            fat_zanthus_processado = 0;
            fat_zanthus_pag = 0;


        }
        public tbfaturamentozanthus(

     

               int          _fat_zanthus_seq
            , DateTime _fat_zanthus_data_m00af                 
            ,  int          _fat_zanthus_sat_ecf_m00ac
            ,  int          _fat_zanthus_cupomfiscal_m00ad
            ,  string       _fat_zanthus_cupomfiscalid_M00_id_unico
            , int _fat_zanthus_cupomfiscal_cancelador_m45bo
            ,  int          _fat_zanthus_notafiscal_numnota 			    
            ,  int          _fat_zanthus_notafiscal_serie_nf 		    
            ,  string       _fat_zanthus_notafiscal_chave_m45xb		    
            ,  int          _fat_zanthus_status_cancelado
            , double _fat_zanthus_cupomfiscal_valor_m45ak
            , DateTime _fat_zanthus_hora_ini_m45ai
            , DateTime _fat_zanthus_hora_fim_m45au
            , int _fat_zanthus_cod_funcionario_m45ah
            , string _fat_zanthus_voucher_cod_m50ar  
            , double _fat_zanthus_voucher_valor_m50at
            , int _fat_zanthus_voucher_count_m50ag

            ) 
        {

            fat_zanthus_seq						        = _fat_zanthus_seq						    ;
            fat_zanthus_data_m00af = _fat_zanthus_data_m00af;  
            fat_zanthus_sat_ecf_m00ac 			        = _fat_zanthus_sat_ecf_m00ac 			    ;    
            fat_zanthus_cupomfiscal_m00ad 			    = _fat_zanthus_cupomfiscal_m00ad 			;    
            fat_zanthus_cupomfiscalid_M00_id_unico 		= _fat_zanthus_cupomfiscalid_M00_id_unico 	;
            fat_zanthus_cupomfiscal_cancelador_m45bo = _fat_zanthus_cupomfiscal_cancelador_m45bo;  
            fat_zanthus_notafiscal_numnota 				= _fat_zanthus_notafiscal_numnota 			;
            fat_zanthus_notafiscal_serie_nf 		    = _fat_zanthus_notafiscal_serie_nf 		    ;
            fat_zanthus_notafiscal_chave_m45xb		    = _fat_zanthus_notafiscal_chave_m45xb		;
            fat_zanthus_status_cancelado = _fat_zanthus_status_cancelado;
            fat_zanthus_cupomfiscal_valor_m45ak = _fat_zanthus_cupomfiscal_valor_m45ak;
            fat_zanthus_hora_ini_m45ai = _fat_zanthus_hora_ini_m45ai;
            fat_zanthus_hora_fim_m45au = _fat_zanthus_hora_fim_m45au;
            fat_zanthus_cod_funcionario_m45ah = _fat_zanthus_cod_funcionario_m45ah;
            fat_zanthus_voucher_cod_m50ar       = _fat_zanthus_voucher_cod_m50ar     ;
            fat_zanthus_voucher_valor_m50at     = _fat_zanthus_voucher_valor_m50at   ;
            fat_zanthus_voucher_count_m50ag = _fat_zanthus_voucher_count_m50ag;
        }
            
        public tbfaturamentozanthus(DataRow i )
        {
             fat_zanthus_seq						    =               Convert.ToInt32(i["fat_zanthus_seq"].ToString());
             fat_zanthus_data_m00af = Convert.ToDateTime(i["fat_zanthus_data_m00af"].ToString());
             fat_zanthus_sat_ecf_m00ac                  =               Convert.ToInt32(i["fat_zanthus_sat_ecf_m00ac"].ToString());
             fat_zanthus_cupomfiscal_m00ad = Convert.ToInt32(i["fat_zanthus_cupomfiscal_m00ad"].ToString());
             fat_zanthus_cupomfiscalid_M00_id_unico = i["fat_zanthus_cupomfiscalid_M00_id_unico"].ToString();
             fat_zanthus_cupomfiscal_cancelador_m45bo = Convert.ToInt32(i["fat_zanthus_cupomfiscal_cancelador_m45bo"].ToString());
             fat_zanthus_notafiscal_numnota = Convert.ToInt32(i["fat_zanthus_notafiscal_numnota"].ToString());
             fat_zanthus_notafiscal_serie_nf = Convert.ToInt32(i["fat_zanthus_notafiscal_serie_nf"].ToString());
             fat_zanthus_notafiscal_chave_m45xb = i["fat_zanthus_notafiscal_chave_m45xb"].ToString();
             fat_zanthus_status_cancelado = Convert.ToInt32(i["fat_zanthus_status_cancelado"].ToString());
             fat_zanthus_cupomfiscal_valor_m45ak =  Convert.ToDouble(i["fat_zanthus_cupomfiscal_valor_m45ak"].ToString());
             fat_zanthus_hora_ini_m45ai = Convert.ToDateTime(i["fat_zanthus_hora_ini_m45ai"].ToString());
             fat_zanthus_hora_fim_m45au = Convert.ToDateTime(i["fat_zanthus_hora_fim_m45au"].ToString());
             fat_zanthus_cpf_cnpj_m45bv = i["fat_zanthus_cupomfiscal_valor_m45ak"].ToString();
             fat_zanthus_cod_funcionario_m45ah = Convert.ToInt32(i["fat_zanthus_cod_funcionario_m45ah"].ToString());
             fat_zanthus_voucher_cod_m50ar  = i["fat_zanthus_voucher_cod_m50ar"].ToString(); 
             fat_zanthus_voucher_valor_m50at = Convert.ToDouble(i["fat_zanthus_voucher_valor_m50at"].ToString());
             fat_zanthus_voucher_count_m50ag = Convert.ToInt32(i["fat_zanthus_voucher_count_m50ag"].ToString());

        }
    }
}
