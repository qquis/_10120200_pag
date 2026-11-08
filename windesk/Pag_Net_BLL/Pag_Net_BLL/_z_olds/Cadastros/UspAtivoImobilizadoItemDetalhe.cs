using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspAtivoImobilizadoItemDetalhe : Bll.USPDataContext
    {
        public ParametrosAtivoImobilizadoItemDetalhe Parametros;
        public UspAtivoImobilizadoItemDetalhe(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosAtivoImobilizadoItemDetalhe();
        }
        public void Select()
        {
            List<UVWAtivoImobilizadoItemDetalhe> L = new List<UVWAtivoImobilizadoItemDetalhe>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWAtivoImobilizadoItemDetalhe l = new UVWAtivoImobilizadoItemDetalhe();
                l.CdEmpresa = Convert.ToInt32(i["CdEmpresa"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.Empresa = i["Empresa"].ToString();
                l.SeqAtivoImobilizado = Convert.ToInt32(i["SeqAtivoImobilizado"].ToString());
                l.SeqAtivoImobilizadoItem = Convert.ToInt32(i["SeqAtivoImobilizadoItem"].ToString());
                l.Cadastro = Convert.ToDateTime(i["Cadastro"].ToString());
                l.DataAquisicao = Convert.ToDateTime(i["DataAquisicao"].ToString());
                l.SeqDocumentoFiscal = Convert.ToInt32(i["SeqDocumentoFiscal"].ToString());
                l.ValorAquisicao = Convert.ToDouble(i["ValorAquisicao"].ToString());
                l.ValorReposicao = Convert.ToDouble(i["ValorReposicao"].ToString());
                l.CdProduto = i["CdProduto"].ToString();
                l.CodigodeBarra = i["CodigoDeBarra"].ToString();
                l.Tipo = i["Tipo"].ToString();
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
            return "UspAtivoImobilizadoItemDetalhe";
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
    }
    public class UVWAtivoImobilizadoItemDetalhe
    {
        public int CdEmpresa { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public int SeqAtivoImobilizadoItem { get; set; }
        public string Empresa { get; set; }
        public DateTime Cadastro { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string CdProduto { get; set; }
        public string CodigodeBarra { get; set; }
        public DateTime DataAquisicao { get; set; }
        public int SeqDocumentoFiscal { get; set; }
        public double ValorAquisicao { get; set; }
        public double ValorReposicao { get; set; }
    }
    public class ParametrosAtivoImobilizadoItemDetalhe
    {
        public int SeqAtivoImobilizado { get; set; }
        public int SeqAtivoImobilizadoItem { get; set; }
        public int CdEmpresa { get; set; }
        public string Descricao { get; set; }
        public int SeqTipoAtivo { get; set; }


    }
}
