using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacaoRubricas : Bll.USPDataContext
    {
        public ParametroContratoLocacaoRubricas Parametros;
        public UspContratoLocacaoRubricas(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacaoRubricas();

        }

        public void Select()
        {
            List<UVWContratoLocacaoRubricas> L = new List<UVWContratoLocacaoRubricas>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacaoRubricas l = new UVWContratoLocacaoRubricas();

                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.SeqTipoContratoRubrica = Convert.ToInt32(i["SeqTipoContratoRubrica"].ToString());
                l.Valor = Convert.ToDouble(i["Valor"].ToString());
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
            return "UspContratoLocacaoRubricas";
        }
    }

    public class UVWContratoLocacaoRubricas
    {
        public int SeqContrato { get; set; }
        public int SeqTipoContratoRubrica { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }


    public class ParametroContratoLocacaoRubricas
    {
        public int SeqContrato { get; set; }
        public int SeqTipoContratoRubrica { get; set; }
        public int SeqContratoLocacaoParcela { get; set; }
        public double Valor { get; set; }
    }
}

