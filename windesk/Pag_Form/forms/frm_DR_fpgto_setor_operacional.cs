
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.rules;

namespace Pag_Form.forms
{
    public partial class frm_DR_fpgto_setor_operacional : Form
    {
        Bll_DemonstrativoResultado_fpgto_Setor BLL;
        int SetorSecionado;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_DR_fpgto_setor_operacional(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            
            InitializeComponent();
            MyConnect = _myConnect;
            BLL = new Bll_DemonstrativoResultado_fpgto_Setor(MyConnect);
            _Screen_load();
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
        
        private void _Screen_load()
        {
            dtg_fpgto_funcionario_setor.AutoGenerateColumns = false;
            dtgsetor_operacional.AutoGenerateColumns = false;
            dtgsetor_operacional.DataSource = BLL.Consultar_FolhaPgto_SetorOperacional(0);
            dtrcentro_dr_mapa.AutoGenerateColumns = false;
            dtrcentro_dr_mapa.DataSource = BLL.Consultar_CentroDr_Mapa(0);
            lbl_setor_selecionado.DataBindings.Add("Text", dtgsetor_operacional.DataSource, "setor_operacional_descricao");
            lbl_setor_operacional.DataBindings.Add("Text", dtgsetor_operacional.DataSource, "setor_operacional");
            lbl_setor_operacional.TextChanged += new EventHandler(_Screen_changed);
            SetorSecionado = 0;
            _pesquisar();

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
                            SetorSecionado = Convert.ToInt32(lbl_setor_operacional.Text);
                            _databinding();
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
            dtg_fpgto_funcionario_setor.DataSource = BLL.Consultar_FolhaPgto_SetorOperacional_Lista(SetorSecionado);
            dtrcentro_dr_mapa.DataSource = BLL.Consultar_CentroDr_Mapa(SetorSecionado);
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

  

    }
}
