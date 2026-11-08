using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Pag_Net.src.F0080_Financeiro.model;

namespace Pag_Form.user_control
{
    public partial class frmUC_Financeiro_AutorizacaoPgto_Consulta : UserControl
    {
        Pag_Net.Models.modelSistemaUsuario Myconnect;
        model_AutorizacaoPagamento __MODEL_AUTORIZACAO_PGTO;
        public frmUC_Financeiro_AutorizacaoPgto_Consulta(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {

            InitializeComponent();
            Myconnect = _Myconnect;
            __MODEL_AUTORIZACAO_PGTO = new model_AutorizacaoPagamento();
            
        }

        private void _Screen_load()
        {
 
        }

        public void _Binding(model_AutorizacaoPagamento __MODEL_AUTORIZACAO_PGTO)
        {
            try
            {
                


                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        foreach (PropertyInfo PROP in __MODEL_AUTORIZACAO_PGTO.GetType().GetProperties())
                        {
                            if (PROP.Name == name)
                            {
                                item.Text = PROP.GetValue(__MODEL_AUTORIZACAO_PGTO).ToString();
                            }
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void _Clear()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name.Substring(0, 4) == "lbl_")
                {
                    item.Text = "";
                }
            }

        }
    }
}
