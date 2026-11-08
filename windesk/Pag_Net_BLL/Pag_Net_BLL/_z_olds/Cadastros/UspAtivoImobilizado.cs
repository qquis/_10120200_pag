using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspAtivoImobilizado : Bll.USPDataContext
    {

        public ParametrosAtivoImobilizado Parametros;
        public UspAtivoImobilizado(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosAtivoImobilizado();
            
        }
        public void Select()
        {
            List<UVWAtivoImobilizado> L = new List<UVWAtivoImobilizado>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWAtivoImobilizado l = new UVWAtivoImobilizado();
                l.CdEmpresa  = Convert.ToInt32(i["CdEmpresa"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.Empresa = i["Empresa"].ToString();
                l.SeqAtivoImobilizado = Convert.ToInt32(i["SeqAtivoImobilizado"].ToString());
                l.SeqAtivoComponente = Convert.ToInt32(i["SeqAtivoComponente"].ToString());
                l.Cadastro = Convert.ToDateTime(i["Cadastro"].ToString());
                l.Tipo  = i["Tipo"].ToString();
                l.ValorAquisicao = Convert.ToDouble(i["ValorAquisicao"].ToString());
                l.ValorReposicao = Convert.ToDouble(i["ValorReposicao"].ToString());
                l.CodigoBarra = i["CodigoBarra"].ToString();
                l.CdProduto = i["CdProduto"].ToString();
                l.DataAquisicao = Convert.ToDateTime( i["DataAquisicao"].ToString()); 

                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }

        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "UspAtivoImobilizado";
        }
    }

    public class UVWAtivoImobilizado
    {
        public int CdEmpresa { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public int SeqAtivoComponente { get; set; }
        public string Empresa { get; set; }
        public DateTime Cadastro { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int SeqTipoAtivo {get;set;}
        public string ComponenteDescricao {get;set;}
        public DateTime DataAquisicao {get;set;}

        public Double ValorAquisicao {get;set;}
        public Double ValorReposicao {get;set;}
        public string CodigoBarra {get;set;}
        public string CdProduto {get;set;}
        public int SeqDocumentoFiscal { get; set; }


    }


    public class ParametrosAtivoImobilizado
    {
        public int CdEmpresa { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public int SeqAtivoComponente { get; set; }
        public string Descricao { get; set; }
        public int SeqTipoAtivo { get; set; }
        public DateTime DataAquisicao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataCadastroFim { get; set; }
        public Double ValorAquisicao { get; set; }
        public Double ValorReposicao { get; set; }
        public string CodigoBarra { get; set; }
        public string CdProduto { get; set; }
        public int SeqDocumentoFiscal { get; set; }
        public bool SelecionaTipoComponentes { get; set; }


    }
}
