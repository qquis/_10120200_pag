using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class F0137_30_CartaoAcessoList
    {



            public int      cartao_acesso_seq  		        {get; set; }
		 	public int      cartao_acesso_numero 		    {get; set; }
		 	public string   cartao_acesso_cdbr			    {get; set; }
		 	public int      cartao_acesso_tipo_cd 		    {get; set; }
			public int      data_validade				    {get; set; }
			public DateTime cartao_acesso_validade_ini      {get; set; }
		 	public DateTime cartao_acesso_validade_fim      {get; set; }
			public int      cartao_acesso_status		    {get; set; }
		 	public int      cdparticipante				    {get; set; }
		 	public int      cdpessoabluesoft			    {get; set; }
		 	public int      rh_funcionario 			        {get; set; }
            public bool cartao_acesso_reg_status_filter { get; set;  }
            public int      cartao_acesso_reg_status        {get; set; }

        public F0137_30_CartaoAcessoList()
        {
            cartao_acesso_seq  		       = 0;    
            cartao_acesso_numero 		   = 0;    
            cartao_acesso_cdbr			   = "";
            cartao_acesso_tipo_cd 	       = 0;
            data_validade                  = 0;		   
            cartao_acesso_validade_ini     = DateTime.Now;
            cartao_acesso_validade_fim     = DateTime.Now; 
            cartao_acesso_status		   = 0;
            cdparticipante				   =0;
            cdpessoabluesoft			   =0;
            rh_funcionario 			       =0;
            cartao_acesso_reg_status_filter = false;
            cartao_acesso_reg_status       =0;

        }
        public F0137_30_CartaoAcessoList(


        int         _cartao_acesso_seq  		   , 
        int         _cartao_acesso_numero 		   ,
        string      _cartao_acesso_cdbr			   ,
        int         _cartao_acesso_tipo_cd 		   ,
        int         _data_validade				   ,
        DateTime    _cartao_acesso_validade_ini    ,
        DateTime    _cartao_acesso_validade_fim    ,
        int         _cartao_acesso_status		   ,
        int         _cdparticipante				   ,
        int         _cdpessoabluesoft			   ,
        int         _rh_funcionario 			   , 
        bool        _cartao_acesso_reg_status_filter,
            int         _cartao_acesso_reg_status  
           )
        {

        cartao_acesso_seq  		    = _cartao_acesso_seq  		     ;  
        cartao_acesso_numero 		= _cartao_acesso_numero 		 ;
        cartao_acesso_cdbr			= _cartao_acesso_cdbr			 ;
        cartao_acesso_tipo_cd 	    = _cartao_acesso_tipo_cd 		 ;
        data_validade               = _data_validade				 ;
        cartao_acesso_validade_ini  = _cartao_acesso_validade_ini    ;
        cartao_acesso_validade_fim  = _cartao_acesso_validade_fim    ;
        cartao_acesso_status		= _cartao_acesso_status		     ;
        cdparticipante				= _cdparticipante				 ;
        cdpessoabluesoft			= _cdpessoabluesoft			     ;
        rh_funcionario 			    = _rh_funcionario 			     ;
        cartao_acesso_reg_status = _cartao_acesso_reg_status;
        cartao_acesso_reg_status_filter = _cartao_acesso_reg_status_filter; 

        }

        private string _VERSION() { return "f0137_30_1011922_cartao_acesso_list"; }
        public string PostGre_Get_Function()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1}, '{2}', {3}, {4}, '{5}', '{6}', {7}, {8}, {9}, {10}, {11}, {12})",
                    cartao_acesso_seq.ToString() , 		  
                    cartao_acesso_numero.ToString() , 		   		
                    cartao_acesso_cdbr.ToString() , 		
                    cartao_acesso_tipo_cd.ToString() , 		  
                    data_validade.ToString() , 	           
                    cartao_acesso_validade_ini.ToString("yyyy-MM-dd") , 	
                    cartao_acesso_validade_fim.ToString("yyyy-MM-dd") , 	
                    cartao_acesso_status.ToString() , 	    		
                    cdparticipante.ToString() , 	    				
                    cdpessoabluesoft.ToString() ,
                    rh_funcionario.ToString(), 
	     			cartao_acesso_reg_status_filter? "1".ToString(): "0".ToString(),  
                    cartao_acesso_reg_status.ToString() 	     
                   ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}