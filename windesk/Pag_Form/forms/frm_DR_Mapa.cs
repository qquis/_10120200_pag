using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_DR_Mapa : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Pag_Net.rules.CentroDr_Mapa BLL;

        public frm_DR_Mapa(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLL = new Pag_Net.rules.CentroDr_Mapa(MyConnect);
            _Screen_load();
        }


        private void _Screen_load()
        {
            try
            {
                dtgMapa.AutoGenerateColumns = false;

                dtgCentroDR_RESUMO.AutoGenerateColumns = false;
                dtgCentroDR_RESUMO.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
                dtgCentroDR_RESUMO.DataSource = BLL.Consultar_CentroDR_Resumo(0);
                dtgCentroDr_Resumo_Item.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);


                CmbCdr_tipo_descricao.TextChanged += new System.EventHandler(this._Screen_changed);
                CmbCdr_tipo_descricao.ValueMember = "cdr_tipo_cd";
                CmbCdr_tipo_descricao.DisplayMember = "cdr_tipo_descricao";
                CmbCdr_tipo_descricao.DataSource = BLL.Consultar_CentroDr_Tipo(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

                        
        }
        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_setor_operacional")
                    {

                        if (((Label)sender).Text.Length > 0)
                        {
                            _databinding();
                        }
                    }

                }
                if (sender.GetType().Name == "ComboBox")
                {
                    if (((ComboBox)sender).Name == "CmbCdr_tipo_descricao")
                    {

                        if (((ComboBox)sender).Text.Length > 0)
                        {
                            dtgCentroDR_RESUMO.DataSource = BLL.Consultar_CentroDR_Resumo(Convert.ToInt32(CmbCdr_tipo_descricao.SelectedValue));
                        }
                    }

                }
                    

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

        private void DG_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (((DataGridView)sender).Name == "dtgCentroDR_RESUMO")
                {
                    int CentroDr_Resumo_Cd = Convert.ToInt32(dtgCentroDR_RESUMO.CurrentRow.Cells[1].Value.ToString());
                    lblinfo_centrodr_resumo_cd.Text = dtgCentroDR_RESUMO.CurrentRow.Cells[1].Value.ToString();
                    lblinfo_centrodr_resumo_descricao.Text = dtgCentroDR_RESUMO.CurrentRow.Cells[2].Value.ToString();
                    dtgMapa.DataSource = BLL.Consultar_CentroDr_Mapa(CentroDr_Resumo_Cd);
                    dtgCentroDr_Resumo_Item.DataSource = BLL.Consultar_CentroDR_Resumo_item(CentroDr_Resumo_Cd);
                }

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }


        }

        private void _pesquisar()
        {
            try
            {
                _databinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _databinding()
        {
            dtgMapa.DataSource = BLL.Consultar_CentroDr_Mapa(0);
        }
        private void cmdatualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdatualiza, true);
                _pesquisar();
                _Screen_wait(cmdatualiza, false);

            }
            catch (Exception ex)
            {
                _Screen_wait(cmdatualiza, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
