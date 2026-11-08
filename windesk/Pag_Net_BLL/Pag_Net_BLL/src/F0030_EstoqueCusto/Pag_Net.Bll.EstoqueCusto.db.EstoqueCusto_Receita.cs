using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0030_EstoqueCusto
{
    public class TbEstoqueCusto_Receita
    {
        public int      proc_log_seq                    {get; set; }
        public int      ecr_receita_seq                 {get; set; }
        public int      pr_cdproduto                    {get; set; }
        public int      prb_cdprodutobluesoft           {get; set; }
        public double   ecr_peso_total_item             {get; set; }
        public double   ecr_valor_custo_precificacao    {get; set; }
        public double   ecr_valor_custo_faturamento     {get; set; }		
        public double   ecr_valor_custo_comercial       {get; set; }		
        public double   ecr_valor_peso_por_embalagem	{get; set; }
        public double   ecr_valor_custo                 {get; set; }

        public TbEstoqueCusto_Receita() {EstoqueCusto_Receita_Binding(); }
        public TbEstoqueCusto_Receita(DataRow i) { EstoqueCusto_Receita_Binding(); EstoqueCusto_Receita_DataBinding(i);  }

        public void EstoqueCusto_Receita_Binding()
        {
            proc_log_seq = 0;
            ecr_receita_seq = 0;                 
            pr_cdproduto = 0;                    
            prb_cdprodutobluesoft = 0;                               
            ecr_peso_total_item = 0;                                 
            ecr_valor_custo_precificacao  = 0;                       
            ecr_valor_custo_faturamento = 0;                         
            ecr_valor_custo_comercial = 0;                           
            ecr_valor_peso_por_embalagem = 0;
            ecr_valor_custo = 0;  
        }

        public void EstoqueCusto_Receita_DataBinding( DataRow i ) 
        {
            EstoqueCusto_Receita_Binding();
            proc_log_seq = 0;
            ecr_receita_seq = Convert.ToInt32(i["ecr_receita_seq"].ToString());
            pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"].ToString());
            prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"].ToString());
            ecr_peso_total_item = Convert.ToDouble(i["ecr_peso_total_item"].ToString());
            ecr_valor_custo_precificacao = Convert.ToDouble(i["ecr_valor_custo_precificacao"].ToString());
            ecr_valor_custo_faturamento = Convert.ToDouble(i["ecr_valor_custo_faturamento"].ToString());
            ecr_valor_custo_comercial = Convert.ToDouble(i["ecr_valor_custo_comercial"].ToString());
            ecr_valor_peso_por_embalagem = Convert.ToDouble(i["ecr_valor_peso_por_embalagem"].ToString());
            ecr_valor_custo = Convert.ToDouble(i["ecr_valor_custo"].ToString());
        }

        public void _INSERT(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, f0030_30_tbestoquecusto_receita_crud.Post(BDCommandTypes.DBINSERT, this));
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
