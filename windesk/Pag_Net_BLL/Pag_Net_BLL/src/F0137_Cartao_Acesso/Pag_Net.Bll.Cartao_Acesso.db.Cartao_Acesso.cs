using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class tbcartao_acesso
    {
		public DateTime     dtlog_insert				                { get; set; }
		public DateTime	    dtlog_update				                { get; set; }
		public int 	        cartao_acesso_seq  			                { get; set; }
        public DateTime     cartao_acesso_data                          { get; set; }
		public int 	        cartao_acesso_numero 		                { get; set; }
		public string 	    cartao_acesso_cdbr			                { get; set; }
		public int 	        cartao_acesso_tipo_cd 		                { get; set; }
		public DateTime	    cartao_acesso_validade_ini 	                { get; set; }
		public DateTime 	cartao_acesso_validade_fim 	                { get; set; }
		public int	        cartao_acesso_status		                { get; set; }
		public int 	        cdparticipante				                { get; set; }
		public int 	        cdpessoabluesoft			                { get; set; }
		public int 	        rh_funcionario_cd 				                { get; set; }

        public tbcartao_acesso()
        {

                dtlog_insert			        = DateTime.Now;
                dtlog_update				    = DateTime.Now;
                cartao_acesso_data              = DateTime.Now;
                cartao_acesso_seq  			    =        0;
                cartao_acesso_numero 		    =        0;
                cartao_acesso_cdbr			    =        "";
                cartao_acesso_tipo_cd 		    =        0;
                cartao_acesso_validade_ini 	    = DateTime.Now;                
                cartao_acesso_validade_fim 	    = DateTime.Now;               
                cartao_acesso_status		    = 0;       
                cdparticipante				    = 0;       
                cdpessoabluesoft			    = 0;
                rh_funcionario_cd = 0;       

        }

		public tbcartao_acesso(DataRow i)
        {

            cartao_acesso_tipo_cd = Convert.ToInt32(i["cartao_acesso_tipo_cd"].ToString());
            cartao_acesso_seq = Convert.ToInt32(i["cartao_acesso_seq"].ToString());
            cartao_acesso_data = Convert.ToDateTime(i["cartao_acesso_data"].ToString());
            cartao_acesso_numero = Convert.ToInt32(i["cartao_acesso_numero"].ToString());
            cartao_acesso_cdbr = i["cartao_acesso_cdbr"].ToString();
            cartao_acesso_tipo_cd = Convert.ToInt32(i["cartao_acesso_tipo_cd"].ToString());
            cartao_acesso_validade_ini = Convert.ToDateTime(i["cartao_acesso_validade_ini"].ToString());
            cartao_acesso_validade_fim = Convert.ToDateTime(i["cartao_acesso_validade_fim"].ToString());
            cartao_acesso_status = Convert.ToInt32(i["cartao_acesso_status"].ToString());
            cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
            cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString()); ;       

        }
    }

}
