using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.tbs
{
    public class tbfaturamento_bluesoft : Pag_Net.Bll.Tb
    {
        public int op_cdoperacao	{get; set;}					
		public int fat_blue_seq	{get; set;}									
		public int numeropedido {get; set;}			 				
		public int numeropedido_fv {get; set;}
        public int df_nf_seq_blue { get; set; }
        public int df_nf_seq_blue_dev { get; set; }		
		public int fat_blue_status_cd {get; set;}						
		public int fat_blue_tipo_cd {get; set;}						
		public int cdpessoabluesoft_cliente {get; set;}							
		public int cdpessoabluesoft_vendedor {get; set;}							
		public int tabelapreco_cd {get; set;}										
		public int tabelapreco_versao_cd {get; set;}								
		public int fv_prazopgto_cd {get; set;}										
		public string tipo_entrega_descricao  {get; set;}								
		public string origem_pedido  {get; set;}										
		public DateTime data_solicitacao {get; set;}						 			
		public DateTime	data_emissao  {get; set;}						 							
		public DateTime	data_faturamento {get; set;}						 						
		public int numero_itens  {get; set;}						 							
		public double valor_pedido  {get; set;}
        public double valor_faturamento { get; set; }

        public tbfaturamento_bluesoft()
        {
            _constructor();
        }

        public void _constructor()
        {
            this.op_cdoperacao = 0;
            this.fat_blue_seq = 0;
            this.numeropedido = 0;
            this.numeropedido_fv = 0;
            this.fat_blue_status_cd = 0;
            this.fat_blue_tipo_cd = 0;
            this.cdpessoabluesoft_cliente = 0;
            this.cdpessoabluesoft_vendedor = 0;
            this.tabelapreco_cd = 0;
            this.tabelapreco_versao_cd = 0;
            this.fv_prazopgto_cd = 0;
            this.tipo_entrega_descricao = "";
            this.origem_pedido = "";
            this.data_solicitacao = DateTime.Now;
            this.data_emissao = DateTime.Now;
            this.data_faturamento = DateTime.Now;
            this.numero_itens = 0;
            this.valor_pedido = 0;
            this.valor_faturamento = 0;
        }

        public void binding(DataRow i)
        {
            try
            {
                this.op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"].ToString());
                this.fat_blue_seq = Convert.ToInt32(i["fat_blue_seq"].ToString()); ;
                this.numeropedido = Convert.ToInt32(i["numeropedido"].ToString()); ;
                this.numeropedido_fv = Convert.ToInt32(i["numeropedido_fv"].ToString()); ;
                this.df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString()); ;
                this.df_nf_seq_blue_dev = Convert.ToInt32(i["df_nf_seq_blue_dev"].ToString()); ;
                this.fat_blue_status_cd = Convert.ToInt32(i["fat_blue_status_cd"].ToString()); ;
                this.fat_blue_tipo_cd = Convert.ToInt32(i["fat_blue_tipo_cd"].ToString()); ;
                this.cdpessoabluesoft_cliente = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString()); ;
                this.cdpessoabluesoft_vendedor = Convert.ToInt32(i["cdpessoabluesoft_vendedor"].ToString()); ;
                this.tabelapreco_cd = Convert.ToInt32(i["tabelapreco_cd"].ToString()); ;
                this.tabelapreco_versao_cd = Convert.ToInt32(i["tabelapreco_versao_cd"].ToString()); ;
                this.fv_prazopgto_cd = Convert.ToInt32(i["fv_prazopgto_cd"].ToString()); ;
                this.tipo_entrega_descricao = i["tipo_entrega_descricao"].ToString();
                this.origem_pedido = i["origem_pedido"].ToString();
                this.data_solicitacao = Convert.ToDateTime(i["data_solicitacao"]);
                this.data_emissao = Convert.ToDateTime(i["data_emissao"]);
                this.data_faturamento = Convert.ToDateTime(i["data_faturamento"]);
                this.numero_itens = Convert.ToInt32(i["numero_itens"].ToString()); ;
                this.valor_pedido = Convert.ToDouble(i["valor_pedido"].ToString()); ;
                this.valor_faturamento = Convert.ToDouble(i["valor_faturamento"].ToString()); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
