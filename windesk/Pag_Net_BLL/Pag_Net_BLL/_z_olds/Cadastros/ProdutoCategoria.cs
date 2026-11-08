using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class ProdutoCategoria : Bll.PRDataContext
    {
        public ParametrosProdutoCategoria Parametros;
        public ProdutoCategoria(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            Parametros = new ParametrosProdutoCategoria();
            Select();
        }
        public void Select()
        {
            List<VWProdutoCategoria> L = new List<VWProdutoCategoria>();
            base.Select();
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VWProdutoCategoria l = new VWProdutoCategoria();
                l.SeqProdutoCategoria = Convert.ToInt32(i["SeqProdutoCategoria"].ToString());
                l.Descricao = i["Descricao"].ToString();
                l.StatusProdutoCategoria = Convert.ToBoolean(i["StatusProdutoCategoria"]);
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }
        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("SeqProdutoCategoria", SqlDbType.Int, true, this.Parametros.SeqProdutoCategoria));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, this.Parametros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("StatusProdutoCategoria", SqlDbType.VarChar, true, this.Parametros.StatusProdutoCategoria));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "PrProdutoCategoria";
        }
    }
    public class ParametrosProdutoCategoria
    {
        public int SeqProdutoCategoria { get; set; }
        public string Descricao { get; set; }
        public bool StatusProdutoCategoria { get; set; }
    }

    public class VWProdutoCategoria
    {
        public int SeqProdutoCategoria { get; set; }
        public string Descricao { get; set; }
        public bool StatusProdutoCategoria { get; set; }

    }
}
