using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Pag_Net.Bll.Sistemas
{
    public class UspSp_Who: Bll.USPDataContext
    {


        public enum eServidor { ADM, PRD }
        public eServidor Servidor;
        public UspSp_Who(Models.modelSistemaUsuario __myConnect)
            : base(__myConnect)
        {
            //Parametros = new ParametrosProdutoCategoria();
            Servidor = eServidor.ADM;
        }
        public void Select()
        {
            List<VwSp_Who> L = new List<VwSp_Who>();

            if (Servidor == eServidor.ADM)
            {
                base.Select();
            }
            else
            {
                base.Select(Dal.DataBaseName.DBAMAINERP);

            }



            foreach (DataRow i in base.DataTableResult.Rows)
            {
                VwSp_Who l = new VwSp_Who();
                

                l.Spid = Convert.ToInt32(i["Spid"].ToString());
                l.Status = i["Status"].ToString();
                l.LoginName = i["Login"].ToString();
                l.Command = i["Command"].ToString();
                l.HostName = i["HostName"].ToString();
                l.BlkBy =  i["BlkBy"].ToString();
                l.DbName = i["DbName"].ToString();
                l.Command  = i["Command"].ToString();
                l.CPUTime  = Convert.ToDouble( i["CPUTime"].ToString());
                l.DiskIo = Convert.ToDouble( i["DiskIo"].ToString());
                //l.LastBatch = Convert.ToDateTime(i["LastBatch"].ToString());
                l.ProgramName = i["ProgramName"].ToString();
                l.Request = i["RequestId"].ToString();
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
            return "uspSPWho";
        }
    }


    public class VwSp_Who
    {
        public int Spid { get; set; }
        public string Status { get; set; }
        public string LoginName { get; set; }
        public string Command { get; set; }
        public string HostName { get; set; }
        public string BlkBy { get; set; }
        public string DbName { get; set; }
        public double CPUTime { get; set; }
        public double DiskIo { get; set; }
        public DateTime  LastBatch { get; set; }
        public string ProgramName { get; set; }
        public string Request { get; set; }
    }
}


