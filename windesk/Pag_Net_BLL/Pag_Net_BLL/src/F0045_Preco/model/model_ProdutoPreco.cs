using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco.model
{
    public class model_preco
    {
        public int      pr_cdproduto                    { get; set; }
        public int      prb_cdprodutobluesoft           { get; set; }
        public int      prb_cdprodutobluesoft_unitario  { get; set; }
        public string   pr_descricao                    { get; set; }
        public bool     pr_status                       { get; set; }
        public string   pr_embalagemestoque             { get; set; }
        public string   pre_embalagem                   { get; set; }
        public double   pre_fatorestoque                { get; set; }
        public double   prc_qtde_promocional           { get; set; }
        public double   LOCAL_prc_qtde_promocional { get; set; }
        public double   prc_valor_promocional          { get; set; }
        public double   LOCAL_prc_valor_promocional { get; set; }
        public double   pre_fatorpreco                  { get; set; }
        public double   _local_FATORPRECO_ALTERADO      { get; set; }
        public double   prc_valor                       { get; set; }
        public double   ec_valor_custo_precificacao     { get; set; }
        public double   ec_valor_custo_faturamento      { get; set; }
        public double   ec_embalagemestoque_qtde        { get; set; }
        public bool     pr_cesta                        { get; set; }
        public int      consulta_agendamento            { get; set; }
        public bool     bool_pr_status_comercial_preco_inativo { get; set; }
        public double consulta_valor_custo_precificacao { get; set; }
        public DateTime data_ultima_compra { get; set; }
        public DateTime data_ultima_venda { get; set; }


	 	public DateTime est_satual_data_ini							{ get; set; }
	 	public DateTime est_satual_data_fim							{ get; set; }
	 	public double   est_satual_embalagemcompraqtde				{ get; set; }
	 	public double   est_satual_embalagemestoqueqtde 			{ get; set; }
	 	public double   est_satual_ec_valorcusto_faturamento_total	{ get; set; }
	 	public double   est_satual_valortotalfaturamentoliquido		{ get; set; }
	 	public int      est_satual_clientes							{ get; set; }
	 	public int      est_satual_pontos							{ get; set; }
        public double calc_est_satual_margem 
        {
            get
            {
                if (est_satual_valortotalfaturamentoliquido > 0 )
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_satual_valortotalfaturamentoliquido, est_satual_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            } 
        }
        public double calc_est_satual_preco_medio 
        {
            get
            {
                if (est_satual_valortotalfaturamentoliquido > 0)
                {
                    return est_satual_valortotalfaturamentoliquido / est_satual_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_satual_custo_medio
        {
            get
            {
                if (est_satual_ec_valorcusto_faturamento_total > 0)
                {
                    return est_satual_ec_valorcusto_faturamento_total / est_satual_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }


	 	public double    est_s4_embalagemcompraqtde					{ get; set; }
	 	public double    est_s4_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s4_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s4_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s4_clientes							{ get; set; }
	 	public int       est_s4_pontos								{ get; set; }
        public double       calc_est_s4_margem
        {
            get
            {
                if (est_s4_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s4_valortotalfaturamentoliquido, est_s4_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double       calc_est_s4_preco_medio
        {
            get
            {
                if (est_s4_valortotalfaturamentoliquido > 0)
                {
                    return est_s4_valortotalfaturamentoliquido / est_s4_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s4_custo_medio
        {
            get
            {
                if (est_s4_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s4_ec_valorcusto_faturamento_total / est_s4_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
	 	
  
	 	public double    est_s3_embalagemcompraqtde					{ get; set; }
	 	public double    est_s3_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s3_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s3_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s3_clientes							{ get; set; }
	 	public int       est_s3_pontos								{ get; set; }
        public double calc_est_s3_margem
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s3_valortotalfaturamentoliquido, est_s3_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s3_preco_medio
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return est_s3_valortotalfaturamentoliquido / est_s3_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s3_custo_medio
        {
            get
            {
                if (est_s3_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s3_ec_valorcusto_faturamento_total / est_s3_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

   
	 	public double    est_s2_embalagemcompraqtde					{ get; set; }
	 	public double    est_s2_embalagemestoqueqtde 				{ get; set; }
	 	public double    est_s2_ec_valorcusto_faturamento_total		{ get; set; }
	 	public double    est_s2_valortotalfaturamentoliquido		{ get; set; }
	 	public int       est_s2_clientes							{ get; set; }
	 	public int       est_s2_pontos								{ get; set; }
        public double calc_est_s2_margem
        {
            get
            {
                if (est_s3_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s2_valortotalfaturamentoliquido, est_s2_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s2_preco_medio
        {
            get
            {
                if (est_s2_valortotalfaturamentoliquido > 0)
                {
                    return est_s2_valortotalfaturamentoliquido / est_s2_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s2_custo_medio
        {
            get
            {
                if (est_s2_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s2_ec_valorcusto_faturamento_total / est_s2_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

   
        public double est_s1_embalagemcompraqtde { get; set; }
        public double est_s1_embalagemestoqueqtde { get; set; }
        public double est_s1_ec_valorcusto_faturamento_total { get; set; }
        public double est_s1_valortotalfaturamentoliquido { get; set; }
        public int est_s1_clientes { get; set; }
        public int est_s1_pontos { get; set; }
        public double calc_est_s1_margem
        {
            get
            {
                if (est_s1_valortotalfaturamentoliquido > 0)
                {
                    return Pag_Net.Tools.Calculo.MargemPreco.get(est_s1_valortotalfaturamentoliquido, est_s1_ec_valorcusto_faturamento_total);
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s1_preco_medio
        {
            get
            {
                if (est_s1_valortotalfaturamentoliquido > 0)
                {
                    return est_s1_valortotalfaturamentoliquido / est_s1_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double calc_est_s1_custo_medio
        {
            get
            {
                if (est_s1_ec_valorcusto_faturamento_total > 0)
                {
                    return est_s1_ec_valorcusto_faturamento_total / est_s1_embalagemestoqueqtde;
                }
                else
                {
                    return 0;
                }
            }
        }

        

        public int dias_sem_venda 
        {
            get 
            {

                int date_diff = (DateTime.Now - this.data_ultima_venda).Days;
                if (date_diff > 730)
                    date_diff = -1;
                return date_diff;
            }
        
        }

        public int dias_sem_compra
        {
            get
            {
                int date_diff =  (DateTime.Now - this.data_ultima_compra).Days;
                if ( date_diff > 730 )
                    date_diff = -1;
                return date_diff;
            }

        }
      


        public string   local_TIPO_CESTA 
        {
            get
            {
                if (pr_cesta)
                    return "SIM";
                else
                    return "NÃO";
            }
        
        }
            
        public bool local_ITEM_ALTERADO {
            get
            {
                bool _preco_alterado = false;
                if (_local_PRECO_ALTERADO != prc_valor  || _local_FATORPRECO_ALTERADO != pre_fatorpreco || prc_qtde_promocional != LOCAL_prc_qtde_promocional || prc_valor_promocional  != LOCAL_prc_valor_promocional)
                {
                    _preco_alterado = true;
                }
                return _preco_alterado;
            }
        }
        public double local_MARGEM_MEDIA
        {
            get
            {
                double _margem_media = 0;
                /*if (_local_PRECO_ALTERADO != 0)
                {

                    if (_local_PRECO_ALTERADO != ec_valor_custo_faturamento)
                    {
                        _margem_media = (_local_PRECO_ALTERADO - ec_valor_custo_faturamento) / _local_PRECO_ALTERADO * 100;
                    }
                    else
                    {
                        _margem_media = 0;
                    }
                }
                else
                {
                    _margem_media = 0;
                }*/

                _margem_media = Pag_Net.Tools.Calculo.MargemPreco.get(_local_PRECO_ALTERADO, ec_valor_custo_faturamento);

                return _margem_media;
            }
        }


        private double _local_PRECO_ALTERADO;
        public double local_PRECO_ALTERADO
        {
            get
            {
                return _local_PRECO_ALTERADO;
                
            }

            set
            {
                _local_PRECO_ALTERADO = value;
            }
        }

        private double _local_MARGEM_PRECIFICACAO;
        public double local_MARGEM_PRECIFICACAO
        {
            get
            {
                 return _local_MARGEM_PRECIFICACAO;

                /*
                 double _margem_precificacao = 0;
                 if (_local_PRECO_ALTERADO > ec_valor_custo_faturamento)
                 {
                     _margem_precificacao = (_local_PRECO_ALTERADO - ec_valor_custo_precificacao) / _local_PRECO_ALTERADO * 100;
                 }
                 if (_local_PRECO_ALTERADO <= ec_valor_custo_precificacao)
                 {
                     _margem_precificacao = 0;
                 }
                 return _margem_precificacao;
                */


            }
            set
            {
                try
                {
                    if (Convert.ToDouble(value) > -100.00)
                    {
                        _local_MARGEM_PRECIFICACAO = value;
                    }
                   // else
                   // {
                   //     throw new Exception("Valor inválido");
                   // }
                }
                catch (Exception)
                {
                    throw new Exception("Valor inválido");
                }
            } 
        }


        public double LOCAL_prc_margem_promocional
        {
            get
            {
                try
                {
                    double _LOCAL_prc_margem_promocional;
                    if (LOCAL_prc_valor_promocional > 0)
                    {
                        _LOCAL_prc_margem_promocional = Math.Round(Pag_Net.Tools.Calculo.MargemPreco.get(LOCAL_prc_valor_promocional, ec_valor_custo_precificacao),2);

                    }
                    else
                    {
                        _LOCAL_prc_margem_promocional = 0;
                    }
                    return _LOCAL_prc_margem_promocional;
                }
                catch (Exception ex)
                {
                    throw new Exception("Pag_Net.Bll.ProdutoPreco...Local_prc_margem_promocional: " + ex.Message);
                }
            } 
          
        }

        public model_preco() { }

        public model_preco(
                 int     _pr_cdproduto                   
             ,   int     _prb_cdprodutobluesoft   
             ,   int     _prb_cdprodutobluesoft_unitario 
             ,   string  _pr_descricao                   
             ,   bool    _pr_status                      
             ,   string  _pr_embalagemestoque            
             ,   string  _pre_embalagem                  
             ,   double  _pre_fatorestoque               
             ,   double  _pre_fatorpreco     
             ,   double  _prc_valor                      
             ,   double  _ec_valor_custo_precificacao    
             ,   double  _ec_valor_custo_faturamento
             ,   double  _ec_embalagemestoque_qtde
             ,   bool    _pr_cesta 
             ,   int     _consulta_agendamento
             ,   double  _prc_qtde_promocional
             ,   double  _prc_valor_promocional 
            )
        {

            data_ultima_compra = Convert.ToDateTime("1900-01-01");
            data_ultima_venda = Convert.ToDateTime("1900-01-01");

            pr_cdproduto                    =          _pr_cdproduto                   ;
            prb_cdprodutobluesoft_unitario  =          _prb_cdprodutobluesoft_unitario ;
            prb_cdprodutobluesoft           =          _prb_cdprodutobluesoft          ;
            pr_descricao                    =          _pr_descricao;
            pr_status                       =          _pr_status                      ;
            pr_embalagemestoque             =          _pr_embalagemestoque            ;
            pre_embalagem                   =          _pre_embalagem                  ;
            pre_fatorestoque                =          _pre_fatorestoque               ;
            pre_fatorpreco                  =          _pre_fatorpreco                 ;
            prc_valor                       =          _prc_valor                      ;
            ec_valor_custo_precificacao     =          _ec_valor_custo_precificacao    ;
            ec_valor_custo_faturamento      =          _ec_valor_custo_faturamento;
            ec_embalagemestoque_qtde        =          _ec_embalagemestoque_qtde;
            pr_cesta                        =          _pr_cesta;
            consulta_agendamento            =          _consulta_agendamento;
            prc_qtde_promocional            =          _prc_qtde_promocional;
            prc_valor_promocional           =          _prc_valor_promocional;


        }

        
        public void _AlterarMargem( double _valorMargem )
        {
            if (_valorMargem == 0)
            {
                local_PRECO_ALTERADO = ec_valor_custo_precificacao;
            }
        }

 



        public model_preco(DataRow i) 
        {
            
            string error_info = "";
            try
            {
                error_info = "pr_cdproduto"; pr_cdproduto = Convert.ToInt32(i["pr_cdproduto"]);
                error_info = "prb_cdprodutobluesoft"; prb_cdprodutobluesoft = Convert.ToInt32(i["prb_cdprodutobluesoft"]);
                error_info = "prb_cdprodutobluesoft_unitario"; prb_cdprodutobluesoft_unitario = Convert.ToInt32(i["prb_cdprodutobluesoft_unitario"]);
                error_info = "pr_descricao"; pr_descricao = i["pr_descricao"].ToString();
                error_info = "pr_status"; pr_status = Pag_Net.Models.BDTools.boolColumnResult(i["pr_status"].ToString());
                error_info = "pr_embalagemestoque"; pr_embalagemestoque = i["pr_embalagemestoque"].ToString();
                error_info = "pre_embalagem"; pre_embalagem = i["pre_embalagem"].ToString();
                error_info = "pre_fatorestoque"; pre_fatorestoque = Convert.ToDouble(i["pre_fatorestoque"]);
                error_info = "pre_fatorpreco"; pre_fatorpreco = Convert.ToDouble(i["pre_fatorpreco"]);
                error_info = "_local_FATORPRECO_ALTERADO"; _local_FATORPRECO_ALTERADO = Convert.ToDouble(i["pre_fatorpreco"]);

                error_info = "prc_valor"; prc_valor = Convert.ToDouble(i["prc_valor"]);
                error_info = "_local_PRECO_ALTERADO"; _local_PRECO_ALTERADO = Convert.ToDouble(i["prc_valor"]);

                error_info = "prc_qtde_promocional"; prc_qtde_promocional = Convert.ToDouble(i["prc_qtde_promocional"]);
                error_info = "LOCAL_prc_qtde_promocional"; LOCAL_prc_qtde_promocional = Convert.ToDouble(i["prc_qtde_promocional"]);

                error_info = "prc_valor_promocional"; prc_valor_promocional = Convert.ToDouble(i["prc_valor_promocional"]);
                error_info = "LOCAL_prc_valor_promocional"; LOCAL_prc_valor_promocional = Convert.ToDouble(i["prc_valor_promocional"]);

                error_info = "ec_valor_custo_precificacao"; ec_valor_custo_precificacao = Convert.ToDouble(i["ec_valor_custo_precificacao"]);
                error_info = "ec_valor_custo_faturamento"; ec_valor_custo_faturamento = Convert.ToDouble(i["ec_valor_custo_faturamento"]);
                error_info = "ec_embalagemestoque_qtde"; ec_embalagemestoque_qtde = Convert.ToDouble(i["ec_embalagemestoque_qtde"]);
                error_info = "consulta_agendamento"; consulta_agendamento = Convert.ToInt32(i["consulta_agendamento"]);

                error_info = "pr_cesta"; pr_cesta = Pag_Net.Models.BDTools.boolColumnResult(i["pr_cesta"].ToString());

                error_info = "pr_status_comercial_preco_inativo"; 
                if (Convert.ToInt32(Pag_Net.Models.BDTools.boolColumnResult(i["pr_status_comercial_preco_inativo"].ToString())) == 0)
                {
                    bool_pr_status_comercial_preco_inativo = false;

                }
                else
                {
                    bool_pr_status_comercial_preco_inativo = true;
                }


                error_info = "_local_MARGEM_PRECIFICACAO"; _local_MARGEM_PRECIFICACAO = Pag_Net.Tools.Calculo.MargemPreco.get(_local_PRECO_ALTERADO, ec_valor_custo_precificacao);


                error_info = "consulta_valor_custo_precificacao"; consulta_valor_custo_precificacao = Convert.ToDouble(i["consulta_valor_custo_precificacao"]);
                error_info = "data_ultima_compra"; data_ultima_compra = Convert.ToDateTime(i["data_ultima_compra"]);
                error_info = "data_ultima_venda"; data_ultima_venda = Convert.ToDateTime(i["data_ultima_venda"]);


     
                error_info = "est_satual_embalagemcompraqtde"; est_satual_embalagemcompraqtde = Convert.ToDouble(i["est_satual_embalagemcompraqtde"].ToString());
                error_info = "est_satual_embalagemestoqueqtde"; est_satual_embalagemestoqueqtde = Convert.ToDouble(i["est_satual_embalagemestoqueqtde"].ToString());
                error_info = "est_satual_ec_valorcusto_faturamento_total"; est_satual_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_satual_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_satual_valortotalfaturamentoliquido"; est_satual_valortotalfaturamentoliquido = Convert.ToDouble(i["est_satual_valortotalfaturamentoliquido"].ToString());
                error_info = "est_satual_clientes"; est_satual_clientes = Convert.ToInt32(i["est_satual_clientes"].ToString());
                error_info = "est_satual_pontos"; est_satual_pontos = Convert.ToInt32(i["est_satual_pontos"].ToString());


       
                error_info = "est_s4_embalagemcompraqtde"; est_s4_embalagemcompraqtde = Convert.ToDouble(i["est_s4_embalagemcompraqtde"].ToString());
                error_info = "est_s4_embalagemestoqueqtde"; est_s4_embalagemestoqueqtde = Convert.ToDouble(i["est_s4_embalagemestoqueqtde"].ToString());
                error_info = "est_s4_ec_valorcusto_faturamento_total"; est_s4_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s4_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s4_valortotalfaturamentoliquido"; est_s4_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s4_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s4_clientes"; est_s4_clientes = Convert.ToInt32(i["est_s4_clientes"].ToString());
                error_info = "est_s4_pontos"; est_s4_pontos = Convert.ToInt32(i["est_s4_pontos"].ToString());

        
                error_info = "est_s3_embalagemcompraqtde"; est_s3_embalagemcompraqtde = Convert.ToDouble(i["est_s3_embalagemcompraqtde"].ToString());
                error_info = "est_s3_embalagemestoqueqtde"; est_s3_embalagemestoqueqtde = Convert.ToDouble(i["est_s3_embalagemestoqueqtde"].ToString());
                error_info = "est_s3_ec_valorcusto_faturamento_total"; est_s3_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s3_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s3_valortotalfaturamentoliquido"; est_s3_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s3_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s3_clientes"; est_s3_clientes = Convert.ToInt32(i["est_s3_clientes"].ToString());
                error_info = "est_s3_pontos"; est_s3_pontos = Convert.ToInt32(i["est_s3_pontos"].ToString());

      
                error_info = "est_s2_embalagemcompraqtde"; est_s2_embalagemcompraqtde = Convert.ToDouble(i["est_s2_embalagemcompraqtde"].ToString());
                error_info = "est_s2_embalagemestoqueqtde"; est_s2_embalagemestoqueqtde = Convert.ToDouble(i["est_s2_embalagemestoqueqtde"].ToString());
                error_info = "est_s2_ec_valorcusto_faturamento_total"; est_s2_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s2_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s2_valortotalfaturamentoliquido"; est_s2_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s2_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s2_clientes"; est_s2_clientes = Convert.ToInt32(i["est_s2_clientes"].ToString());
                error_info = "est_s2_pontos"; est_s2_pontos = Convert.ToInt32(i["est_s2_pontos"].ToString());


         
                error_info = "est_s1_embalagemcompraqtde"; est_s1_embalagemcompraqtde = Convert.ToDouble(i["est_s1_embalagemcompraqtde"].ToString());
                error_info = "est_s1_embalagemestoqueqtde"; est_s1_embalagemestoqueqtde = Convert.ToDouble(i["est_s1_embalagemestoqueqtde"].ToString());
                error_info = "est_s1_ec_valorcusto_faturamento_total"; est_s1_ec_valorcusto_faturamento_total = Convert.ToDouble(i["est_s1_ec_valorcusto_faturamento_total"].ToString());
                error_info = "est_s1_valortotalfaturamentoliquido"; est_s1_valortotalfaturamentoliquido = Convert.ToDouble(i["est_s1_valortotalfaturamentoliquido"].ToString());
                error_info = "est_s1_clientes"; est_s1_clientes = Convert.ToInt32(i["est_s1_clientes"].ToString());
                error_info = "est_s1_pontos"; est_s1_pontos = Convert.ToInt32(i["est_s1_pontos"].ToString());
            }

            catch (Exception ex)
            {
                error_info += " | pr_cdproduto: " + pr_cdproduto.ToString();
                throw new Exception("\n" + "\n" + "Pag_Net.Bll.ProdutoPreco.cs | Mdo_ProdutoPreco" + "\n" + "Função PostGRE [f0140_01_XXXXXXX_preco_list_select]): " + "\n" + "Erro: " +  ex.Message + "\n" + "\n" + "Binding Data: " + "\n" + error_info);
            }
        }

    }
    
}
