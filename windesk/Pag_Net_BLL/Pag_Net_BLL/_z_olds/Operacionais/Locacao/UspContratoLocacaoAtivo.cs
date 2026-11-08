using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pag_Net.Bll;


namespace Pag_Net.Bll.Operacionais.Locacao
{
    public class UspContratoLocacaoAtivo: Bll.USPDataContext
    {
        public ParametroContratoLocacaoAtivo Parametros;
        public UspContratoLocacaoAtivo(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametroContratoLocacaoAtivo();

        }

        public void Select()
        {
            List<UVWContratoLocacaoAtivo> L = new List<UVWContratoLocacaoAtivo>();
            base.Select();
            
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWContratoLocacaoAtivo l = new UVWContratoLocacaoAtivo();
                l.SeqContrato = Convert.ToInt32(i["SeqContrato"].ToString());
                l.DescricaoAtivoImobilizado = i["DescricaoAtivoImobilizado"].ToString();
                l.SeqAtivoImobilizado = Convert.ToInt32(i["SeqAtivoImobilizado"].ToString());
                l.DescricaoContrato = i["DescricaoContrato"].ToString();
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
            return "USPContratoLocacaoAtivo";
        }

    }

    public class UVWContratoLocacaoAtivo 
    {
        public int SeqContrato { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public string DescricaoContrato { get; set; }
        public string DescricaoAtivoImobilizado { get; set; }



    }


    public class ParametroContratoLocacaoAtivo 
    {
        public int SeqContrato { get; set; }
        public int SeqAtivoImobilizado { get; set; }
    }
}
