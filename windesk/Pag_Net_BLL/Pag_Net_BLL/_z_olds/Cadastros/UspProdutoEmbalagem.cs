using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Pag_Net.Bll.Cadastros
{
    public class UspProdutoEmbalagem : Bll.USPDataContext
    {
         public int CdProduto { get; set; }
         public UspProdutoEmbalagem(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            try
            {
                List<UVWProdutoEmbalagens> L = new List<UVWProdutoEmbalagens>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWProdutoEmbalagens l = new UVWProdutoEmbalagens();
                    //l.SeqProdutoGestor   = Convert.ToInt32(i["SeqProdutoGestor"]);
                    l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    l.EmbalagemDescricao = i["EmbalagemDescricao"].ToString();
                    l.Embalagem = i["Embalagem"].ToString();
                    l.Relacao = i["Relacao"].ToString();
                    l.FatorEstoque = Convert.ToDouble(i["FatorEstoque"].ToString());
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
            return ListParameters.ToArray();   
        }
        public override string SQLCommnad()
        {
            return "UspProdutoEmbalagens";
        }
    }

    public class UVWProdutoEmbalagens : Pag_Net.Models.mdoVWProduto
    {
        public string Embalagem { get; set; }
        public string Relacao { get; set; }
        public string EmbalagemDescricao { get; set; }
        public double FatorEstoque { get; set; }
    }
}
