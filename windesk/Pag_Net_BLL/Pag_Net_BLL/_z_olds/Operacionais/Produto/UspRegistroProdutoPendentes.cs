using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Produto
{
    public class UspRegistroProdutoPendentes: Bll.USPDataContext
    {
        public int TotalRegistros { get; set; }
        public UspRegistroProdutoPendentes(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

        }
        public void Select()
        {
            try
            {
                TotalRegistros = 0;
                List<UVWRegistroProdutoPendentes> L = new List<UVWRegistroProdutoPendentes>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWRegistroProdutoPendentes l = new UVWRegistroProdutoPendentes();
                    l.Sequencial = Convert.ToInt32(i["Sequencial"]);
                    l.CdProduto  = Convert.ToInt32(i["CdProduto"]);
                    l.Descricao  = i["Descricao"].ToString();
                    l.Descricao = i["Descricao"].ToString();
                    l.Embalagem = i["Embalagem"].ToString();
                    l.Qtde  = Convert.ToDouble( i["Qtde"].ToString());
                    l.TipoRegistro = i["TipoRegistro"].ToString();
                    l.Lista = i["Lista"].ToString();
                    l.DataRegistro = Convert.ToDateTime(i["DataRegistro"]);
                    L.Add(l);
                    index = index + 1;
                }
                TotalRegistros = index;
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            //List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            //ListParameters.Add(new Models.ParameterQuey("CdEmpresa", SqlDbType.Int, true, 1));
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspRegistroProdutoPendentes";
        }
    }
    public class UVWRegistroProdutoPendentes
    {
        public int Sequencial { get; set; }
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string Embalagem {get;set;}
        public double Qtde { get; set; }
        public string TipoRegistro { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Lista { get; set; }
    }
}

