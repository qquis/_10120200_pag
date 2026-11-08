using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0150_Estatistica
{

    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Pag_Net.Bll.F0150_Estatistica.TbEst_Info Info;
        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Info = Consultar_Data_Semana();
        }

        private Pag_Net.Bll.F0150_Estatistica.TbEst_Info Consultar_Data_Semana()
        {
            try
            {
                List<Pag_Net.Bll.F0150_Estatistica.TbEst_Info> _list = new List<TbEst_Info>();
                Pag_Net.Bll.F0150_Estatistica.TbEst_Info  Info =  new TbEst_Info(BDCommand.get_DataTable(MyConnect, F0150_Estatistica.Consultar_Info.Postgre.get()).Rows[0]);

                return Info;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }
    }


}
