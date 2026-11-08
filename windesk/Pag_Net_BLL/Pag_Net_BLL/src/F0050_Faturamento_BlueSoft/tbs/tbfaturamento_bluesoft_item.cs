using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0050_Faturamento_BlueSoft.tbs
{
    public class tbfaturamento_bluesoft_item
    {
        
        
        //CHAVES
        public int	fat_blue_origem_seq			        {get; set;}
        public int op_cdoperacao { get; set; }
        public int numeropedido { get; set; }
        public int numeropedido_fv { get; set; }
		public int	fat_blue_item_seq					{get; set;}
        public int df_nf_seq_blue { get; set; }
        public int cdpessoabluesoft_cliente { get; set; }

        //PRODUTO
        public int	prb_cdprodutobluesoft				{get; set;}
		public int	prb_cdprodutobluesoft_unitario 		{get; set;}
		public string	prb_embalagem 		    {get; set;}
		public double	prb_fatorestoque 		{get; set;}
        public string   embalagem_descricao       {get;set;}

        //QTDE 
        public double qtde_unitaria_solicitada { get; set; }
        public double qtde_unitaria_faturada { get; set; }
        public double qtde_solicitada			{get;set;}
		public double qtde_faturada			{get;set;}		

        //CUSTO 
		public double	valor_custo				{get;set;}
        public double valor_custo_com_icm_unit { get; set; }
        public double valor_custo_com_icm { get; set; }
        
        //PRECOS
        public double	valor_preco_tabela		{get;set;}
		public double	valor_preco				{get;set;}
		public double	valor_preco_aplicado	{get;set;}

        //VERBAS 
		public double	valor_verba				{get;set;}
		public double	valor_verba_gerencia	{get;set;}
		public double	valor_verba_supervisao	{get;set;}
        public double valor_verba_calculada { get; set; }


        //DESCONTO FINANCEIRO  
        public double percentual_desconto_financeiro { get; set; }

        //NOTA
        public double valor_nf_item_bruto { get; set; }
        public double valor_nf_item { get; set; }
        public double item_nf_bonificado { get; set; }

        public tbfaturamento_bluesoft_item() { constructor();  }
        public void constructor()
        {
            this.fat_blue_origem_seq = 0;
		    this.fat_blue_item_seq = 0;
		    this.prb_cdprodutobluesoft = 0;	
            this.prb_cdprodutobluesoft_unitario = 0;
            this.prb_embalagem = "";    
            this.prb_fatorestoque = 0; 		
            this.embalagem_descricao = ""; 		
            this.qtde_solicitada = 0;			
            this.qtde_faturada = 0;			
            this.valor_custo = 0;				
            this.valor_preco_tabela = 0;
            this.valor_preco = 0;				
            this.valor_preco_aplicado = 0;
            this.valor_verba = 0;
            this.valor_verba_gerencia = 0;
            this.valor_verba_supervisao = 0;
            this.op_cdoperacao = 0;
            this.df_nf_seq_blue = 0;
            this.cdpessoabluesoft_cliente = 0;
        }

        public void binding(DataRow i )
        {
            string filder_read = "";

            try
            {



                //CHAVE
                filder_read = "fat_blue_origem_seq";  this.fat_blue_origem_seq = Convert.ToInt32(i["fat_blue_origem_seq"].ToString());
                filder_read = "numeropedido"; this.numeropedido = Convert.ToInt32(i["numeropedido"].ToString());
                filder_read = "numeropedido_fv"; this.numeropedido_fv = Convert.ToInt32(i["numeropedido_fv"].ToString());
                filder_read = "fat_blue_item_seq"; this.fat_blue_item_seq = Convert.ToInt32(i["fat_blue_origem_seq"].ToString());
                filder_read = "df_nf_seq_blue"; this.df_nf_seq_blue = Convert.ToInt32(i["df_nf_seq_blue"].ToString());
                filder_read = "cdpessoabluesoft_cliente"; this.cdpessoabluesoft_cliente = Convert.ToInt32(i["cdpessoabluesoft_cliente"].ToString());
                filder_read = "op_cdoperacao"; this.op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"].ToString()); 
                
                //PRODUTO
                filder_read = "prb_cdprodutobluesoft"; this.prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
                filder_read = "prb_cdprodutobluesoft_unitario"; this.prb_cdprodutobluesoft_unitario = Convert.ToInt32(i["prb_cdprodutobluesoft_unitario"].ToString());
                filder_read = "prb_embalagem"; this.prb_embalagem = i["prb_embalagem"].ToString();
                filder_read = "prb_fatorestoque"; this.prb_fatorestoque = Convert.ToDouble(i["prb_fatorestoque"].ToString());
                filder_read = "embalagem_descricao"; this.embalagem_descricao = i["embalagem_descricao"].ToString();

                //QTDE                 
                filder_read = "qtde_unitaria_solicitada"; this.qtde_unitaria_solicitada = Convert.ToDouble(i["qtde_unitaria_solicitada"].ToString());
                filder_read = "qtde_unitaria_faturada"; this.qtde_unitaria_faturada = Convert.ToDouble(i["qtde_unitaria_faturada"].ToString());
                filder_read = "qtde_solicitada"; this.qtde_solicitada = Convert.ToDouble(i["qtde_solicitada"].ToString());
                filder_read = "qtde_faturada"; this.qtde_faturada = Convert.ToDouble(i["qtde_faturada"].ToString());
                
                //CUSTO
                filder_read = "valor_custo_com_icm_unit"; this.valor_custo_com_icm_unit = Convert.ToDouble(i["valor_custo_com_icm_unit"].ToString());
                filder_read = "valor_custo_com_icm"; this.valor_custo_com_icm = Convert.ToDouble(i["valor_custo_com_icm"].ToString());
                filder_read = "valor_custo"; this.valor_custo = Convert.ToDouble(i["valor_custo"].ToString());

                //PRECO
                filder_read = "valor_preco_tabela"; this.valor_preco_tabela = Convert.ToDouble(i["valor_preco_tabela"].ToString());
                filder_read = "valor_preco"; this.valor_preco = Convert.ToDouble(i["valor_preco"].ToString());
                filder_read = "valor_preco_aplicado"; this.valor_preco_aplicado = Convert.ToDouble(i["valor_preco_aplicado"].ToString());
                
                //VERBA 
                filder_read = "valor_verba"; this.valor_verba = Convert.ToDouble(i["valor_verba"].ToString());
                filder_read = "valor_verba_gerencia"; this.valor_verba_gerencia = Convert.ToDouble(i["valor_verba_gerencia"].ToString());
                filder_read = "valor_verba_supervisao"; this.valor_verba_supervisao = Convert.ToDouble(i["valor_verba_supervisao"].ToString());
                filder_read = "valor_verba_calculada"; this.valor_verba_calculada = Convert.ToDouble(i["valor_verba_calculada"].ToString());

                //DESCONTO FINANCEIRO
                filder_read = "percentual_desconto_financeiro"; this.percentual_desconto_financeiro = Convert.ToDouble(i["percentual_desconto_financeiro"].ToString());


                //DESCONTO FINANCEIRO
                filder_read = "valor_nf_item_bruto"; this.valor_nf_item_bruto = Convert.ToDouble(i["valor_nf_item_bruto"].ToString());
                filder_read = "valor_nf_item"; this.valor_nf_item = Convert.ToDouble(i["valor_nf_item"].ToString());
                filder_read = "item_nf_bonificado"; this.item_nf_bonificado = Convert.ToInt32(i["item_nf_bonificado"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Pag_Net.src.F0050_Faturamento_BlueSoft.tbs \n" + 
                                    "Binding | Filde : " + filder_read.ToString().ToUpper() + "\n" + 
                                    "Error: " +  ex.Message);
            }
        }
        
        
    }
}
