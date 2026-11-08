using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Cadastros.Produto
{
    public partial class frm_Produto : Form
    {


        Pag_Net.src.F0020_Produto._index F0020;

        Pag_Net.Bll.F0020_Produto.WkProduto _WkProduto;
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public frm_Produto(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _WkProduto = new Pag_Net.Bll.F0020_Produto.WkProduto(MyConnect);
            _Screen_load();
        }

        public frm_Produto(Pag_Net.Models.modelSistemaUsuario _myConnect, int _pr_CdProduto)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _WkProduto = new Pag_Net.Bll.F0020_Produto.WkProduto(MyConnect);
            _Screen_load();
            if (_pr_CdProduto != 0)
            {
                txtpr_cdproduto.Text = _pr_CdProduto.ToString();
                
            }
        }

        private void _Screen_load()
        {
            try
            {

                F0020 = new Pag_Net.src.F0020_Produto._index(MyConnect);
                F0020.reports.PropertyChanged += _databinding;

                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdDetalhe, UserTools.PagButtonsIcons.Detalhe);


                foreach (object i in this.Controls) { if (i.GetType().Name == "TextBox") if(((TextBox)i).Tag != null)  if (((TextBox)i).Tag.ToString() != "") ((TextBox)i).LostFocus += new EventHandler(_Screen_lostFocus); }
                foreach (object i in this.Controls) { if (i.GetType().Name == "Button") ((Button)i).Click += new EventHandler(_Screen_Click); }

                dtpDataCadastroIni.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
                dtpDataCadastroFim.DataBindings.Add("Enabled", chkSeleciona_Data_Cadastro, "Checked");
                chkSeleciona_Data_Cadastro.Checked = false;
                chkAtvo.Checked = true;
                chkInativo.Checked = false;

            } 
            catch ( Exception ex)
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
                if (sender.GetType().Name == "TextBox"){}

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

    

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProduto.Rows[dtgProduto.SelectedRows[0].Index].ToString() == string.Empty)
                {
                    MessageBox.Show("Selecione um item");
                }

                int _pr_cdproduto = Convert.ToInt32(dtgProduto[0, dtgProduto.SelectedRows[0].Index].Value.ToString());
 
                frm_Produto_Embalagem frm = new frm_Produto_Embalagem(MyConnect, _pr_cdproduto);
                frm.ShowDialog();


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

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);

                F0020.reports.FilterClear();

                F0020.reports.filtro.Status_Ativo = chkAtvo.Checked;
                F0020.reports.filtro.Status_Inativo = chkInativo.Checked;

                if (txtpr_descricao.Text != "")
                    F0020.reports.filtro.pr_descricao = txtpr_descricao.Text.ToString().TrimEnd();

                if (txtpr_descricao.Text != "")
                    F0020.reports.filtro.prb_descricao = txtpr_descricao.Text.ToString().TrimEnd();


                if (txtpr_cdproduto.Text.ToString().Trim() != "")
                    F0020.reports.filtro.pr_cdproduto = Convert.ToInt32(txtpr_cdproduto.Text.Trim());

                if (txtprb_cdprodutobluesoft_unitario.Text.ToString().Trim() != "")
                    F0020.reports.filtro.prb_cdprodutoBlueSoft = Convert.ToInt32(txtprb_cdprodutobluesoft_unitario.Text.Trim());

                if (txtprbg_cdbarra_pk.Text.Trim() != "")
                    F0020.reports.filtro.prbg_cdbarra_pk = txtprbg_cdbarra_pk.Text.Trim();


                if (txtprb_descricao_fiscal.Text != "")
                    F0020.reports.filtro.prb_descricao_fiscal = txtprb_descricao_fiscal.Text;

                F0020.reports.filtro.Seleciona_Data_Cadastro = chkSeleciona_Data_Cadastro.Checked;
                F0020.reports.filtro.prb_dt_cadastro_ini = dtpDataCadastroIni.Value;
                F0020.reports.filtro.prb_dt_cadastro_fim = dtpDataCadastroFim.Value;

                F0020.reports.Produto_Consultar();

                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }



        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_Produto")
            {
                dtgProduto.DataSource = F0020.reports.dbList_Produto.List;
                UserTools._Screen_DataBinding_Set(lbl_pr_cdproduto, dtgProduto.DataSource, "pr_cdproduto");
                UserTools._Screen_DataBinding_Set(lbl_pr_descricao, dtgProduto.DataSource, "pr_descricao");
                UserTools._Screen_DataBinding_Set(lbl_prb_cdprodutobluesoft, dtgProduto.DataSource, "prb_cdprodutobluesoft");
                UserTools._Screen_DataBinding_Set(lbl_dtlog_insert, dtgProduto.DataSource, "dtlog_insert");
                UserTools._Screen_DataBinding_Set(lbl_dtlog_update, dtgProduto.DataSource, "dtlog_update");
                UserTools._Screen_DataBinding_Set(lbl_dtlog_update, dtgProduto.DataSource, "dtlog_update_api");
                UserTools._Screen_DataBinding_Set(lbl_label_descricao_pr_cesta, dtgProduto.DataSource, "label_descricao_pr_cesta");
                lbl_info_total.Text = F0020.reports.dbList_Produto.Count.ToString(); 
            }


        }

    


        

    }
}
