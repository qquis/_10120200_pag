using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Cadastros
{
    public class UspProdutoGestor : Bll.USPDataContext
    {
        public UspProdutoGestor(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            this.Select();
        }
        public void Select()
        {
            try
            {
                List<UVWProdutoGestor> L = new List<UVWProdutoGestor>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWProdutoGestor l = new UVWProdutoGestor();
                    l.SeqProdutoGestor   = Convert.ToInt32(i["SeqProdutoGestor"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.StatusProdutoGestor = Convert.ToBoolean(i["StatusProdutoGestor"]);
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
            return null;                
        }
        public override string SQLCommnad()
        {
            return "UspProdutoGestor";
        }

    }
    public class UVWProdutoGestor
    {
        public int SeqProdutoGestor { get; set; }
        public string Descricao { get; set; }
        public bool StatusProdutoGestor {get;set;}
    }
}