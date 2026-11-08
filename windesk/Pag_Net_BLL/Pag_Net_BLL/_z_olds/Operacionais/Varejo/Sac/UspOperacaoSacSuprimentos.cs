using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Operacionais.Varejo.Sac
{
    public class UspOperacaoSacSuprimentos : Bll.USPDataContext
    {
        public int ECF;
        public int Operador;
        public DateTime Data;

        public double TOTALCARREGAMENTO;
        public double TOTALQTDE;
        public double TOTALSALDO;

        public UspOperacaoSacSuprimentos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {


        }
        public void Select()
        {
            try
            {
                List<UVWOperacaoSacSuprimentos> L = new List<UVWOperacaoSacSuprimentos>();
                base.Select();
                int index = 0;

                this.TOTALSALDO = 0;

                foreach (DataRow i in base.DataTableResult.Rows)
                {
                    UVWOperacaoSacSuprimentos l = new UVWOperacaoSacSuprimentos();
                    l.CdProduto = Convert.ToInt32(i["CdProduto"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.Embalagem = i["Embalagem"].ToString();
                    l.Qtde = Convert.ToDouble(i["Qtde"].ToString());
                    l.Carregamento = Convert.ToDouble(i["Carregamento"].ToString());
                    l.Saldo = Convert.ToDouble(i["Saldo"].ToString());
                    this.TOTALSALDO = this.TOTALSALDO + l.Saldo;

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

            ListParameters.Add(new Models.ParameterQuey("CDOPERADOR", SqlDbType.Int, true, this.Operador));
            ListParameters.Add(new Models.ParameterQuey("ECF", SqlDbType.Int, true, this.ECF ));
            ListParameters.Add(new Models.ParameterQuey("DATA", SqlDbType.Date, true, this.Data ));

            return ListParameters.ToArray();

        }
        public override string SQLCommnad()
        {
            return "UspOperacaoSacSuprimentos";
        }
    }

    public class UVWOperacaoSacSuprimentos
    {
        public int CdProduto { get; set; }
        public string Descricao { get; set; }
        public string Embalagem { get; set; }
        public double Qtde { get; set; }
        public double Carregamento { get; set; }
        public double Saldo { get; set; }        

    }
}

