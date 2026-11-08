using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0045_Preco
{
    public class _index : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public reports._indexReport Reports;


        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            Reports = new reports._indexReport(MyConnect); 
        }

    }

    public static class Notificar
    {
        public static void Email_1100045001_NotificarAlteracaoPreco(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                RESTAPI.post(MyConnect.PAG_API + "/notificacao/service/processar?notificacao_cd=1100045001", null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
