using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspAtivoImobilizadoInformacao : Bll.USPDataContext
    {
        public  ParametrosAtivoImobilizadoInformacao Parametros;
        public UspAtivoImobilizadoInformacao(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosAtivoImobilizadoInformacao();

        }

        public void Select()
        {
            List<UVWAtivoImobilizadoInformacao> L = new List<UVWAtivoImobilizadoInformacao>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWAtivoImobilizadoInformacao l = new UVWAtivoImobilizadoInformacao();
                l.Informacao = i["Informacao"].ToString();
                l.Observacao = i["Observacao"].ToString();
                l.DescricaoTipoInformacao = i["DescricaoTipoInformacao"].ToString();
                l.SeqAtivoImobilizado = Convert.ToInt32(i["SeqAtivoImobilizado"].ToString());
                l.CdTipoInformacao = Convert.ToInt32(i["CdTipoInformacao"].ToString());
                l.DescricaoAtivoImobilizado = i["DescricaoAtivoImobilizado"].ToString();
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
            return "UspAtivoImobilizadoInformacao";
        }
    }

    public class UVWAtivoImobilizadoInformacao
    {
        public int SeqAtivoImobilizado { get; set; }
        public int SeqTipoInformacao { get; set; }
        public int CdTipoInformacao { get; set; }
        public string DescricaoTipoInformacao { get; set; }
        public string Informacao { get; set; }
        public string Observacao { get; set; }
        public string DescricaoAtivoImobilizado { get; set; }
    }


    public class ParametrosAtivoImobilizadoInformacao
    {
        public int SeqAtivoImobilizado { get; set; }
        public int CdTipoInformacao { get; set; }
        public string Informacao { get; set; }
        public string Observacao { get; set; }
        
    }
}
