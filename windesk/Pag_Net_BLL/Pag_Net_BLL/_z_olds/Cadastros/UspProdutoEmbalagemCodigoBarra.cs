using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspProdutoEmbalagemCodigoBarra : Bll.USPDataContext
    {
        public int CdProduto { get; set; }
        public string Embalagem { get; set; }
        public UspProdutoEmbalagemCodigoBarra(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            try
            {
                List<UVWProdutoEmbalagensCodigoBarra> L = new List<UVWProdutoEmbalagensCodigoBarra>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWProdutoEmbalagensCodigoBarra l = new UVWProdutoEmbalagensCodigoBarra();
                    //l.SeqProdutoGestor   = Convert.ToInt32(i["SeqProdutoGestor"]);
                    l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    l.CodigoBarra = i["CodigoBarra"].ToString();
                    l.Embalagem = i["Embalagem"].ToString();
                    l.TipoCodigoBarra = i["TipoCodigoBarra"].ToString();
                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            ListParameters.Add(new Models.ParameterQuey("CdProduto", SqlDbType.Int, true, this.CdProduto));
            ListParameters.Add(new Models.ParameterQuey("Embalagem", SqlDbType.VarChar, true, this.Embalagem));
            return ListParameters.ToArray();
        }
        public override string SQLCommnad()
        {
            return "UspProdutoEmbalagensCodigoBarra";
        }
    }

    public class UVWProdutoEmbalagensCodigoBarra : Pag_Net.Models.mdoVWProduto
    {
        public string Embalagem { get; set; }
        public string CodigoBarra { get; set; }
        public string TipoCodigoBarra { get; set; }
        
    }
}
