using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Pag_Net.Bll.Cadastros
{
    public class UspAtivoImobilizadoItem: Bll.USPDataContext
    {
        public UspAtivoImobilizadoItem(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Select();
        }
        public void Select()
        {
            List<UVWAtivoImobilizadoItem> L = new List<UVWAtivoImobilizadoItem>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                UVWAtivoImobilizadoItem l = new UVWAtivoImobilizadoItem();
                l.SeqAtivoImobilizadoItem = Convert.ToInt32(i["SeqAtivoImobilizadoItem"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.SeqAtivoImobilizado = Convert.ToInt32(i["SeqAtivoImobilizado"].ToString());
                l.Cadastro = Convert.ToDateTime(i["Cadastro"].ToString());
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
            return "UspAtivoImobilizadoItem";
        }
    }

    public class UVWAtivoImobilizadoItem
    {
        public int SeqAtivoImobilizadoItem { get; set; }
        public int SeqAtivoImobilizado { get; set; }
        public DateTime Cadastro { get; set; }
        public string Descricao { get; set; }
    }

}