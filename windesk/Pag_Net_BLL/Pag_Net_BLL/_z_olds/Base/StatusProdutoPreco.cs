using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Pag_Net.Dal;
using Pag_Net.Models;

namespace Pag_Net.Bll.Base
{
    public class StatusProdutoPreco
    {
        #region Property
        public Pag_Net.Models.ModeloBase.TbStatusProdutoPreco[] Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (value != null)
                {
                    _Lista = value;
                    this.OnPropertyChanged(this, new PropertyChangedEventArgs("Lista"));
                }
            }
        }
        #endregion

        #region Varieble
        private modelSistemaUsuario _MyConnect;
        private Pag_Net.Models.ModeloBase.TbStatusProdutoPreco[] _Lista;
        #endregion

        #region Constructor
        public StatusProdutoPreco(modelSistemaUsuario _myConnect)
        {
            _MyConnect = _myConnect;
        }
        #endregion

        #region Events Publics
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methodos Virtuals
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
        #endregion
    }
}
