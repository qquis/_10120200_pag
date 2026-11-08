using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models
{
    public class TbSysDatabase
    {
        public string Id { get; set; }
        public string Environment { get; set; }
        public string TimeConnection { get; set; }
        public string TimeCommand { get; set; }
        public string DataSourceLAN { get; set; }
        public string DataSourceWAN { get; set; }
        public string LanPort { get; set; }
        public string WanPort { get; set; }
        public string DataBase { get; set; }
        public string UsrDataBase { get; set; }
        public string PwdDataBase { get; set; }
        public string Referencia { get; set; }
        public TbSysDatabase(string Id,
                                string Environment,
                                string TimeConnection,
                                string TimeCommand,
                                string DataSourceLAN,
                                string DataSourceWAN,
                                string LanPort,
                                string WanPort,
                                string DataBase,
                                string UsrDataBase,
                                string PwdDataBase,
                                string referencia)
        {
            this.Id = Id.ToString();
            this.Environment = Environment.ToString();
            this.TimeCommand = TimeCommand.ToString();
            this.TimeConnection = TimeConnection.ToString();
            this.DataSourceLAN = DataSourceLAN.ToString();
            this.DataSourceWAN = DataSourceWAN.ToString();
            this.LanPort = LanPort.ToString();
            this.WanPort = WanPort.ToString();
            this.DataBase = DataBase.ToString();
            this.UsrDataBase = UsrDataBase.ToString();
            this.PwdDataBase = PwdDataBase.ToString();
            this.Referencia = referencia.ToString();
        }
    }

}
