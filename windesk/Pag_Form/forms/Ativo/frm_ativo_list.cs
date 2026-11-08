using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Ativo
{
    public partial class frm_ativo_list : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0035_Ativo.WkAtivo WK;
        public frm_ativo_list(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_Form_Format_DataGridView(dtga);
                UserTools._Screen_ButtonImage(cmdpesquisar, UserTools.PagButtonsIcons.Localizar);
                UserTools._Screen_ButtonImage(cmdDetalhe, UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_ButtonImage(cmdSelecionar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdIncluir, UserTools.PagButtonsIcons.Novo);

                cmdSelecionar.Enabled = false;
                /*Class Work*/
                WK = new Pag_Net.Bll.F0035_Ativo.WkAtivo(MyConnect);
                WK.PropertyChanged += __BindingWK;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void __BindingWK(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "DbAtivos_List")
                {
                    dtga.DataSource = WK.DbAtivos_List.List;
                    UserTools._Screen_DataBinding_Set(lblat_seq, WK.DbAtivos_List.List, "at_seq");
                    
                    
                }  


            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void cmdpesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                WK.ativoList_Obter();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                frm_ativo_cadastro frm_cadastro = new frm_ativo_cadastro(MyConnect, WK.ativoList_Selecionar(lblat_seq.Text));
                frm_cadastro.ShowDialog(); 

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                frm_ativo_cadastro frm_cadastro = new frm_ativo_cadastro(MyConnect, WK.ativoList_Selecionar("0"));
                frm_cadastro.ShowDialog();

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
