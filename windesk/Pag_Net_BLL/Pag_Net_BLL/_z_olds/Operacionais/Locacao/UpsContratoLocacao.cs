using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacao : Bll.USPDataContext
    {
        public ParametroContratoLocacao Parametros;
        public UspContratoLocacao(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacao();

        }

        public void Select()
        {
            List<UVWContratoLocacao> L = new List<UVWContratoLocacao>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacao l = new UVWContratoLocacao();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.DataInicio = Convert.ToDateTime(i["DataInicio"].ToString());
                l.DataFim = Convert.ToDateTime(i["DataFim"].ToString());
                l.DataContrato = Convert.ToDateTime(i["DataContrato"].ToString());
                l.Empresa = i["Empresa"].ToString();
                l.Descricao = i["Descricao"].ToString();
                l.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                l.ValorTotal = Convert.ToDouble(i["ValorTotal"].ToString());
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
            return "UspContratoLocacao";
        }
    }

    public class UVWContratoLocacao: Pag_Net.Bll.Administrativo.UVWContrato 
    {
        public int SeqContratoLocacao { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public string AtivoImobilizadoDescricao { get; set; }
        public DateTime DataContrato { get; set; }
        public double ValorTotal { get; set; }


    }


    public class ParametroContratoLocacao : Pag_Net.Bll.Administrativo.ParametroContrato
    {
        
    }
}
