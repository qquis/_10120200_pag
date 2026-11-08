using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspParticipanteEmpresa: Bll.USPDataContext
    {
        public ParametrosParticipanteEmpresa Parametros;
        public UspParticipanteEmpresa(Models.modelSistemaUsuario __myconnect)
            : base(__myconnect)
        {
            Parametros = new ParametrosParticipanteEmpresa();
        }

        public void Select()
        {
            List<UVWParticipanteEmpresa> L = new List<UVWParticipanteEmpresa>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWParticipanteEmpresa x = new UVWParticipanteEmpresa();
                x.CdParticipante = Convert.ToInt32(i["CdParticipante"]);
                x.CdOperacao = Convert.ToInt32(i["CdOperacao"]);
                x.CdEmpresa = Convert.ToInt32(i["CdEmpresa"]);
                x.SeqTipoParticipanteEmpresa = Convert.ToInt32(i["SeqTipoParticipanteEmpresa"]);
                x.DescricaoEmpresa = i["DescricaoEmpresa"].ToString();
                x.DescricaoOperacao = i["DescricaoOperacao"].ToString();
                x.DescricaoTipoParticipanteEmpresa = i["DescricaoTipoParticipanteEmpresa"].ToString();
                L.Add(x);
            }
            base.ViewData = L.ToArray();
        }
        public override object GetParametros()
        {
            return this.Parametros;
        }
        public override string SQLCommnad()
        {
            return "UspParticipanteEmpresa";
        }

    }

    public class ParametrosParticipanteEmpresa
    {
        public int CdParticipante { get; set; }
        public int SeqTipoParticipanteEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int CdEmpresa { get; set; }
    }
    public class UVWParticipanteEmpresa
    {
        public int CdParticipante { get; set; }
        public string DescricaoTipoParticipanteEmpresa { get; set; }
        public string DescricaoOperacao { get; set; }
        public string DescricaoEmpresa { get; set; }
        public int SeqTipoParticipanteEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public int CdEmpresa { get; set; }

    }
}
