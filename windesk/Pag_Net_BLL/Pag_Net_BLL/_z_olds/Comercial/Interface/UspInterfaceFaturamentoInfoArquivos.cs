using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;


namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceFaturamentoInfoArquivos : Bll.USPDataContext
    {
        public UspInterfaceFaturamentoInfoArquivos(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Select();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceFaturamentoInfoArquivos> L = new List<UVWInterfaceFaturamentoInfoArquivos>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceFaturamentoInfoArquivos l = new UVWInterfaceFaturamentoInfoArquivos();
                        l.Arquivo = i["Arquivo"].ToString();
                        l.Clientes = Convert.ToInt32(i["Clientes"].ToString());
                        l.Linhas = Convert.ToInt32(i["Linhas"].ToString());
                        l.Volume = Convert.ToDouble(i["Volume"].ToString());
                        L.Add(l);
                    }
                    base.ViewData = L.ToArray();
                }
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
            return "UspInterfaceFaturamentoInfoArquivos";
        }
    }
    public class UVWInterfaceFaturamentoInfoArquivos
    {
        public string Arquivo { get; set; }
        public int Linhas { get; set; }
        public int Clientes { get; set; }
        public double Volume { get; set; }
        public bool Selecionado { get; set; }

        

    }
}
