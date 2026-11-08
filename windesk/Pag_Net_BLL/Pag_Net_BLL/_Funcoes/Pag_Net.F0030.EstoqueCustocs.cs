using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Pag_Net.Bll.F0030
{
    public class Db
    {


        public int		vproc_log_seq						{ get; set; }
        public int		vcdproduto							{ get; set; }
		public double	vec_embalagemestoque_qtde			{ get; set; }					
		public double	vec_embalagemestoque_qtde_online	{ get; set; }			
		public double	vec_embalagemestoque_fv_pendente	{ get; set; }			
		public double	vec_valor_custo_precificacao		{ get; set; }				
		public double	vec_valor_custo_faturamento			{ get; set; }				
		public double	vec_valor_customedio_comimposto		{ get; set; }			
		public double	vec_valor_customedio_semimposto		{ get; set; }			
		public double	vec_valor_ultimacompra_bruto		{ get; set; }				
		public double	vec_valor_ultimacompra_liq			{ get; set; }

		public Db ()  { }
		public Db (
            
            int		_vproc_log_seq						,
			int		_vcdproduto							,
			double	_vec_embalagemestoque_qtde			,
			double	_vec_embalagemestoque_qtde_online	,
			double	_vec_embalagemestoque_fv_pendente	,
			double	_vec_valor_custo_precificacao		,
			double	_vec_valor_custo_faturamento		,	
			double	_vec_valor_customedio_comimposto	,	
			double	_vec_valor_customedio_semimposto	,	
			double	_vec_valor_ultimacompra_bruto		,
			double	_vec_valor_ultimacompra_liq			
           )
        {

		vproc_log_seq						=		_vproc_log_seq						;
		vcdproduto							=		_vcdproduto							;
		vec_embalagemestoque_qtde			=		_vec_embalagemestoque_qtde			;
		vec_embalagemestoque_qtde_online	=		_vec_embalagemestoque_qtde_online	;
		vec_embalagemestoque_fv_pendente	=		_vec_embalagemestoque_fv_pendente	;
		vec_valor_custo_precificacao		=		_vec_valor_custo_precificacao		;
		vec_valor_custo_faturamento			=		_vec_valor_custo_faturamento		;
		vec_valor_customedio_comimposto		=		_vec_valor_customedio_comimposto	;
		vec_valor_customedio_semimposto		=		_vec_valor_customedio_semimposto	;
		vec_valor_ultimacompra_bruto		=		_vec_valor_ultimacompra_bruto		;
        vec_valor_ultimacompra_liq = _vec_valor_ultimacompra_liq;
        }


    }

    public static class Postgres
    {
        public static string Post(
				string _SqlCommand,
				bool _Api ,
                Pag_Net.Bll.F0030.Db _db
            )
        {

            try
            {
                string _sql_post = string.Format("             '{0}'   " +
                                                   "          ,'{1}'      " +
                                                   "          , {2}         " +
                                                   "          , {3}         " +
                                                   "          , {4}         " +
                                                   "          , {5}         " +
                                                   "          , {6}         " +
                                                   "          , {7}         " +
                                                   "          , {8}         " +
                                                   "          , {9}         " +
                                                   "          , {10}         " +
                                                   "          , {11}         " +
                                                   "          , {12}        ",
												   _SqlCommand.ToString(),
												   _Api? "true": "false",
                                                   _db.vproc_log_seq.ToString() ,
												   _db.vcdproduto.ToString()	,					
												   _db.vec_embalagemestoque_qtde.ToString("0.0000").Replace(",","."),
												   _db.vec_embalagemestoque_qtde_online.ToString("0.0000").Replace(",","."),  
												   _db.vec_embalagemestoque_fv_pendente.ToString("0.0000").Replace(",","."), 
												   _db.vec_valor_custo_precificacao.ToString("0.0000").Replace(",","."),	
												   _db.vec_valor_custo_faturamento.ToString("0.0000").Replace(",","."),		
												   _db.vec_valor_customedio_comimposto.ToString("0.0000").Replace(",","."),	
												   _db.vec_valor_customedio_semimposto.ToString("0.0000").Replace(",","."),	
												   _db.vec_valor_ultimacompra_bruto.ToString("0.0000").Replace(",","."),	
												   _db.vec_valor_ultimacompra_liq.ToString("0.0000").Replace(",",".")		
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

