using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0020_Produto.model
{
    public class model_produtoembalagem : Pag_Net.src.F0020_Produto.tbs.TbProdutoEmbalagem
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



        public model_produtoembalagem() : base() { }
        public model_produtoembalagem(Pag_Net.Models.modelSistemaUsuario MyConnect, int pr_cdproduto, int prb_cdprodutobluesofft)
        {
            try
            {
                _modelconstructor();
                Select(MyConnect, pr_cdproduto, prb_cdprodutobluesofft);

                
            }

            catch (Exception ex)
            {
                throw new Exception(" Src.F0020_Produto.model.model_produto \n Inicialização \n \n" + ex.Message);
            }
        }
        public void _modelconstructor()
        {

        }

        public void Select(Pag_Net.Models.modelSistemaUsuario MyConnect, int _pr_cdproduto, int _prb_cdprodutobluesoft) 
        {
            string MessageError = "";
            try
            {

                interfaces.iF0020_Produto_filter FILTRO = new interfaces.iF0020_Produto_filter();
                FILTRO.pr_cdproduto = _pr_cdproduto;
                FILTRO.prb_cdprodutoBlueSoft = _prb_cdprodutobluesoft;

                DataRow i = BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoEmbalagem.Get(MyConnect, FILTRO)).List.Rows[0];
                
                MessageError = "Binding classe Base _ TbProduto";
                base._binding(i);

                //this.label_descricao_pr_status = i["label_descricao_pr_status"].ToString();
                //this.label_descricao_pr_cesta = i["label_descricao_pr_cesta"].ToString();

                MessageError = "Binding classe Base _ TbProdutoBlueSoft - Unitário Vinculado ao MDO";

            }

            catch (Exception ex)
            {
                throw new Exception("Src.F0020_Produto.model.model_produto \n Select \n \n Observação: " + MessageError + "\n \n Error: \n " + ex.Message); 
            }

        }

        public DBDataTable GtinsGet(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string MessageError = "Consulta de GTINS";
            try
            {
                interfaces.iF0020_Produto_filter FILTRO = new interfaces.iF0020_Produto_filter();
                FILTRO.pr_cdproduto = this.pr_cdproduto;
                FILTRO.prb_cdprodutoBlueSoft = this.prb_cdprodutobluesoft;
                return BDCommand.DBDataTableGet(MyConnect, scripts.report_SELECT_ProdutoEmbalagemGtins.Get(MyConnect, FILTRO));
            }
            catch (Exception ex)
            {
                throw new Exception("Src.F0020_Produto.model.model_produto \n Select \n \n Observação: " + MessageError + "\n \n Error: \n " + ex.Message); 
            }

        }



    }
}
