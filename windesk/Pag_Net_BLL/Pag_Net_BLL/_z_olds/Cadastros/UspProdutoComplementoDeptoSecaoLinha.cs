using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Cadastros
{
    public class DeptoSecaoLinha: Bll.USPDataContext
    {
        public string MenuFormProc { get; set; }
        public DeptoSecaoLinha(Models.modelSistemaUsuario _myConnect)
            :base(_myConnect)
        {
            
        }

        public void Select()
        {
            List<UVWProdutoComplementoDeptoSecaoLinha> L = new List<UVWProdutoComplementoDeptoSecaoLinha>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWProdutoComplementoDeptoSecaoLinha l = new UVWProdutoComplementoDeptoSecaoLinha();
                l.CdProdutoDepartamento = i["CdProdutoDepartamento"].ToString();
                l.CdProdutoLinha = i["CdProdutoLinha"].ToString();
                l.CdProdutoSecao = i["CdProdutoSecao"].ToString();
                l.DescricaoDepartamento= i["DescricaoDepartamento"].ToString();
                l.DescricaoSecao = i["DescricaoSecao"].ToString();
                l.DescricaoLinha = i["DescricaoLinha"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "SPP0080DeptoSecaoGrupo";
        }
    }

    public class UVWProdutoComplementoDeptoSecaoLinha
    {
        public string CdProdutoDepartamento {get;set;}
        public string DescricaoDepartamento {get;set;}
        public string CdProdutoSecao {get;set;} 
        public string DescricaoSecao {get;set;}
        public string CdProdutoLinha {get;set;}
        public string DescricaoLinha { get; set; }
        public UVWProdutoComplementoDeptoSecaoLinha() { }

    }
}
