using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Cadastros.ProdutoBluesoft
{
    public partial class frm_ProdutoBlueSoftTributacao : Form
    {
        Pag_Net.src.F0021_ProdutoBluesoft._index F0021;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_ProdutoBlueSoftTributacao(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _Screen_load();
        }
        public frm_ProdutoBlueSoftTributacao(Pag_Net.Models.modelSistemaUsuario _myConnect, int prb_cdprodutobluesoft)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            txtprb_cdprodutobluesoft.Text = prb_cdprodutobluesoft.ToString();
            _Screen_load();
        }
        private void _Screen_load()
        {
            try
            {

                F0021 = new Pag_Net.src.F0021_ProdutoBluesoft._index(MyConnect);
                F0021.reports.PropertyChanged += _databinding;

                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_Form_Format_DataGridView(dtgProdutoBlueSoftTributacao, true);


                foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if (((TextBox)i).Tag != null)  if (((TextBox)i).Tag.ToString() != "") ((TextBox)i).LostFocus += new EventHandler(_Screen_lostFocus); }
                foreach (object i in this.Controls) { if (i.GetType().Name == "Button") ((Button)i).Click += new EventHandler(_Screen_Click); }


                if (txtprb_cdprodutobluesoft.Text.Trim() != "")
                {
                    cmdConsultar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }
        private void _Screen_Click(object sender, EventArgs e)
        {

        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "TextBox") { }

                if (sender.GetType().Name == "DateTimePicker") { }


                if (sender.GetType().Name == "CheckBox") { }
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                MessageBox.Show(ErroMessage.Message);
            }

        }

        private void _Screen_lostFocus(object sender, EventArgs e) { }
        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_ProdutoBlueSoftTributacao")
            {
                dtgProdutoBlueSoftTributacao.DataSource = F0021.reports.dbList_ProdutoBlueSoftTributacao.List;

            }


        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                F0021.reports.FilterClear();
                F0021.reports.filtro.prb_descricao = txtpr_descricao.Text;
                F0021.reports.filtro.prb_descricao_fiscal = txtprb_descricao_fiscal.Text;

                if (txtpr_cdproduto.Text != "")
                {
                    F0021.reports.filtro.pr_cdproduto = Convert.ToInt32(txtpr_cdproduto.Text);
                }

                if (txtprb_cdprodutobluesoft.Text != "")
                {
                    F0021.reports.filtro.prb_cdprodutoBlueSoft = Convert.ToInt32(txtprb_cdprodutobluesoft.Text);
                }
                F0021.reports.ProdutoBlueSoftTributacao_Consultar();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                
                UserTools._Screen_MessageBox(this, ex);
                txtpr_cdproduto.Text = "0";
                txtprb_cdprodutobluesoft.Text = "0";
            }
        }
    }
}
