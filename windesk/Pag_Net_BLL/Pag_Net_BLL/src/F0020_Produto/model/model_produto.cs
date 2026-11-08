using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.model
{
    public class model_produto : Pag_Net.src.F0020_Produto.tbs.TbProduto
    {
        /*        public int pr_cdproduto { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string pr_descricao { get; set; }
        public string pr_embalagemestoque { get; set; }
        public DateTime prb_dt_cadastro { get; set; }
        public string status_descricao { get; set; }
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public DateTime dtlog_update_api { get; set; }
        public bool pr_cesta { get; set; }
        public bool pr_status { get; set; }

        public double prb_pesobruto { get; set;  }
        public double prb_pesoliquido { get; set; } */

        public string label_descricao_pr_status { get; set; }
        public string label_descricao_pr_cesta { get; set; }

        public tbs.TbProdutoBlueSoft ProdutoBlueSoftUnitarioVinculado;
        public model_produtoembalagem EmbalagemSelecionada;


        public DBDataTable DBDataTableListEmbalagem { get; set;  }

        public model_produto() : base() { }
        public model_produto(Pag_Net.Models.modelSistemaUsuario MyConnect, int pr_cdproduto)
        {
            try
            {
                _modelconstructor();
                Select(MyConnect, pr_cdproduto);
                ConsultarEmbalagens(MyConnect);
                
            }

            catch (Exception ex)
            {
                throw new Exception("Src.F0020_Produto.model.model_produto \n Inicialização \n \n" + ex.Message);
            }
        }
        public void _modelconstructor()
        {
            ProdutoBlueSoftUnitarioVinculado = new tbs.TbProdutoBlueSoft();
            EmbalagemSelecionada = new model_produtoembalagem();
            
        }

        public void Select(Pag_Net.Models.modelSistemaUsuario MyConnect, int pr_cdproduto) 
        {
            string MessageError = "";
            try
            {
                DataRow i = BDCommand.DBDataTableGet(MyConnect,scripts.report_SELECT_Produto.Get(MyConnect, new interfaces.iF0020_Produto_filter(pr_cdproduto))).List.Rows[0];
                
                MessageError = "Binding classe Base _ TbProduto";
                base._binding(i);

                this.label_descricao_pr_status = i["label_descricao_pr_status"].ToString();
                this.label_descricao_pr_cesta = i["label_descricao_pr_cesta"].ToString();

                MessageError = "Binding classe Base _ TbProdutoBlueSoft - Unitário Vinculado ao MDO";
                ProdutoBlueSoftUnitarioVinculado._binding(i);
            }

            catch (Exception ex)
            {
                throw new Exception("Src.F0020_Produto.model.model_produto \n Select \n \n Observação: " + MessageError + "\n \n Error: \n " + ex.Message); 
            }

        }



        public void ConsultarEmbalagens(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
               DBDataTableListEmbalagem =  BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoEmbalagem.Get(MyConnect, new interfaces.iF0020_Produto_filter(this.pr_cdproduto))); 
            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public DBDataTable ConsultarCestaComposicao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoComposicao.Get(MyConnect, new interfaces.iF0020_Produto_filter(this.pr_cdproduto))); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public void EmbalagemSelecionar()
        {

        }

        public void EmbalagemGtinSelecionar()
        {

        }


    }
}
