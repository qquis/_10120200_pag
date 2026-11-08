using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Distribuicao
{
    public class UspStatusOperacaoVenda : Bll.USPDataContext
    {

        public UspStatusOperacaoVenda(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {

            
        }

        public void Select()
        {

            List<VwStatusOperacaoVenda> L = new List<VwStatusOperacaoVenda>();
            base.Select(Pag_Net.Dal.DataBaseName.DBAMAINERP);
            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VwStatusOperacaoVenda l = new VwStatusOperacaoVenda();
                l.Cliente  = Convert.ToInt32(i["Cliente"].ToString());
                L.Add(l);
            }
            base.ViewData = L.ToArray();
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            //List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();
            //ListParameters.Add(new Models.ParameterQuey("DataCadastroIni", SqlDbType.DateTime, true, this.DataInicial));
            //ListParameters.Add(new Models.ParameterQuey("DataFinal", SqlDbType.DateTime, true, this.DataFinal));
            //return ListParameters.ToArray();
            return null;
        }
        public override string SQLCommnad()
        {
            return "UspStatusOperacaoVenda";
        }

    }


    public class VwStatusOperacaoVenda
    {

        public string Tp { get; set; }
        public string FormPgto { get; set; }
        public string CondPgto { get; set; }
        public int Nota { get; set; }
        public int Pedido { get; set; }
        public int Cliente { get; set; }
        public string Nome { get; set; }
        public string Vend { get; set; }
        public double Valor { get; set; }
        public string St { get; set; }
    }

}
