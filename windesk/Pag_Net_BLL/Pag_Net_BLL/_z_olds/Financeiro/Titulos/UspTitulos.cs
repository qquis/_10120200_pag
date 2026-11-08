using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Models;

namespace Pag_Net.Bll.Financeiro.Titulos
{
    public class UspTitulos : Bll.USPDataContext
    {
        public ParametrosTitulo Parametros;
        public UspTitulos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

            Parametros = new ParametrosTitulo();

        }
        public void Select()
        {
            List<UVWTitulo> L = new List<UVWTitulo>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWTitulo l = new UVWTitulo();
                l.CdEmpresa = Convert.ToInt32(i["CdEmpresa"]);
                l.CdOperacao = Convert.ToInt32(i["CdOperacao"]);
                l.CdParticipanteSacado = Convert.ToInt32(i["CdParticipanteSacado"]);
                l.DataEmissao = Convert.ToDateTime(i["DataEmissao"]);
                l.DataVencimento = Convert.ToDateTime(i["DataVencimento"]);
                l.NomeSacado = i["NomeSacado"].ToString();
                l.DescricaoEmpresa = i["DescricaoEmpresa"].ToString();
                l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                l.DescricaoSituacao = i["DescricaoSituacao"].ToString();
                l.ValorSaldo = Convert.ToDouble(i["ValorSaldo"]);
                l.Valor = Convert.ToDouble(i["Valor"]);
                l.SeqTitulo = Convert.ToInt32(i["SeqTitulo"]);
                l.CdTituloEspecie = Convert.ToInt32(i["SeqTitulo"]);
                l.DescricaoTituloEspecie = i["DescricaoTituloEspecie"].ToString();



                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspTitulo";
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
    }
    public class UVWTitulo
    {
        public int CdEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int CdParticipanteSacado { get; set; }
        public string NomeSacado { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public double ValorSaldo { get; set; }
        public bool StatusTitulo { get; set; }
        public int SeqSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public int SeqTitulo { get; set; }
        public int CdTituloEspecie { get; set; }
        public string DescricaoTituloEspecie { get; set; }
    }

    public class ParametrosTitulo
    {
        public int CdEmpresa {get;set;}
        public int CdOperacao {get;set;}
        public DateTime DataEmissao { get; set; }
        public DateTime DataEmissaoFinal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataVencimentoFinal { get; set; }
        public double Valor { get; set; }
        public double ValorFinal { get; set; }
        public double ValorSaldo { get; set; }
        public double ValorSaldoFinal { get; set; }
        public bool StatusTitulo { get; set; }
        public int SeqSituacao { get; set; }
        public string ListaTitulos { get; set; }
    }
}
