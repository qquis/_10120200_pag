using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspProcessos: Bll.USPDataContext
    {

        public UspProcessos(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            //Parametros = new ParametrosProdutoCategoria();
            Select();
        }
        public void Select()
        {
            List<VWProcessos> L = new List<VWProcessos>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VWProcessos l = new VWProcessos();
                l.SeqProcesso = Convert.ToInt32(i["SeqProcesso"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.StoredProcedure = i["StoredProcedure"].ToString();
                l.Ref = i["Ref"].ToString();
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            //List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            //ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, true, this.Parametros.SeqProdutoCategoria));
            //return ListParameters.ToArray();
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspProcessos";
        }
    }


    public class VWProcessos
    {
        public int SeqProcesso { get; set; }
        public string Descricao { get; set; }
        public string TipoProcesso { get; set; }
        public string StoredProcedure { get; set; }
        public string RecipientsDefault { get; set; }
        public string Ref { get; set; }


    }
}

