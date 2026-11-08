using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;
using System.Data;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class UspInterfaceInfo : Bll.USPDataContext
    {
        public UspInterfaceInfo(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Select();
        }
        public void Select()
        {
            try
            {
                List<UVWInterfaceInfo> L = new List<UVWInterfaceInfo>();
                base.Select();
                if (base.DataTableResult != null)
                {
                    foreach (DataRow i in base.DataTableResult.Rows)
                    {
                        UVWInterfaceInfo l = new UVWInterfaceInfo();
                        l.SeqInterfaceInfo = Convert.ToInt32(i["SeqInterfaceInfo"].ToString());
                        l.Descricao = i["Descricao"].ToString();
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
            return "UspInterfaceInfo";
        }
    }
    public class UVWInterfaceInfo
    {
        public int SeqInterfaceInfo { get; set; }
        public string Descricao { get; set; }

    }
}
