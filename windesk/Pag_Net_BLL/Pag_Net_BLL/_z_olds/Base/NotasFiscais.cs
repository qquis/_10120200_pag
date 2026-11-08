using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Pag_Net.Bll.Base
{
    public class NotasFiscais : INotifyPropertyChanged
    {
        private Pag_Net.Models.ModeloBase.TbNotasFiscais[] _Lista;
        public Pag_Net.Models.ModeloBase.TbNotasFiscais[] Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (_Lista != value)
                {
                    _Lista = value;
                    this.OnPropertyChanged(this, new PropertyChangedEventArgs("Lista"));
                }
            }

        }
        public Models.modelSistemaUsuario MyConnect { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public NotasFiscais(Models.modelSistemaUsuario _myConnect)
        {
            MyConnect = _myConnect;

        }
        public virtual void Select()
        {

        }
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }
    }
}
