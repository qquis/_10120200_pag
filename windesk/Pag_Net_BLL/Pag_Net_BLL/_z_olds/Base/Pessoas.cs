using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Pag_Net.Bll.Base
{
    class Pessoas
    {
        private Models.modelSistemaUsuario _MyConnect;
        private Pag_Net.Models.TbPessoas[] _List;
        public Pag_Net.Models.TbPessoas[] List
        {
            get
            {
                return _List;
            }
            set
            {
                _List = value;
                this.OnPropertyChanged(this, new PropertyChangedEventArgs("Lista"));
            }
        }
        public Pessoas(Models.modelSistemaUsuario _myConnect)
        {
            _MyConnect = _myConnect;
        }
        public virtual void Select() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }
    }
}
