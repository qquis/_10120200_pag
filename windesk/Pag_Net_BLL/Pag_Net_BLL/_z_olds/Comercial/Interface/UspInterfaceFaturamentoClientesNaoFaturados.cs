using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{

    public class UspInterfaceFaturamentoClientesNaoFaturados : Bll.USPDataContext
    {
        public ParametrosInterfaceFaturamentoClientesNaoFaturados Parametros;
        public UspInterfaceFaturamentoClientesNaoFaturados(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Parametros = new ParametrosInterfaceFaturamentoClientesNaoFaturados();
        }

        public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoClientesNaoFaturados> L = new List<UVWInterfaceFaturamentoClientesNaoFaturados>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoClientesNaoFaturados l = new UVWInterfaceFaturamentoClientesNaoFaturados();
                        l.CdParticipanteErp = i["CdParticipanteErp"].ToString().Trim();
                        l.StatusParticipanteErp = i["StatusParticipanteErp"].ToString();
                        l.Nome = i["Nome"].ToString();
                        l.Endereco = i["Endereco"].ToString();
                        l.Bairro = i["Bairro"].ToString();
                        l.Municipio = i["Municipio"].ToString();
                        l.Cep  = i["Cep"].ToString();
                        L.Add(l);
                    }
                    base.ViewData = L.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspInterfaceFaturamentoClientesNaoFaturados";
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
    }



    public class UVWInterfaceFaturamentoClientesNaoFaturados
    {
        public int CdParticipante { get; set; }
        public string CdParticipanteErp { get; set; }
        public string StatusParticipanteErp { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
    }

    public class ParametrosInterfaceFaturamentoClientesNaoFaturados
    {
        public DateTime DataFaturamento { get; set; }
        public DateTime DataFaturamentoFinal { get; set; }
        public string ListaProduto { get; set; }
        public string Cdfabricante { get; set; }
    }
}


