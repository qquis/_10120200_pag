using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspProdutoConteudo : Bll.USPDataContext
    {
        public int CdProduto { get; set; } 
        public UspProdutoConteudo(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            try
            {
                List<UVWProdutoConteudo> L = new List<UVWProdutoConteudo>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWProdutoConteudo l = new UVWProdutoConteudo();
                    //l.SeqProdutoGestor   = Convert.ToInt32(i["SeqProdutoGestor"]);
                    l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.EmbalagemEstoque = i["EmbalagemEstoque"].ToString();
                    l.EmbalagemCompra = i["EmbalagemCompra"].ToString();
                    l.EmbalagemCompraQtdeUnitaria = Convert.ToDouble(i["EmbalagemCompraQtdeUnitaria"]);
                    l.CategoriaDescricao = i["CategoriaDescricao"].ToString();
                    l.LinhaDescricao =  l.LinhaDescricao = i["LinhaDescricao"].ToString();
                    l.SecaoDescricao = i["SecaoDescricao"].ToString();
                    l.DepartamentoDescricao = i["DepartamentoDescricao"].ToString();
                    l.GestorDescricao = i["GestorDescricao"].ToString();
                    
                    
                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("CdProduto", SqlDbType.Int, true, this.CdProduto));
            return ListParameters.ToArray();   
        }
        public override string SQLCommnad()
        {
            return "UspProdutoConteudo";
        }

    }

    public class UVWProdutoConteudo: Pag_Net.Models.mdoVWProduto 
    {
        public string FabricanteDescricao { get; set; }
        public string DepartamentoDescricao { get; set; }
        public string SecaoDescricao { get; set; }
        public string LinhaDescricao { get; set; }
        public string CategoriaDescricao { get; set; }
        public string GestorDescricao { get; set; }
    }

    
}
