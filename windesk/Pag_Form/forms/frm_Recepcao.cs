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
    public partial class frm_Recepcao : Form
    {
        System.Windows.Forms.Timer _TIMER_tProc;
        int _TIMER_EXECUTE;

        _TipoAcao __SCREEN_TIPO_ACAO;

        public enum _TipoAcao
        {
            CONSULTAR_CONTROLE = 0,
            INCLUSAO_CONTROLE = 1,
            ALTERACAO_ETAPA = 2,
            ALTERACAO_PGTO = 3

        }

        Pag_Net.Models.modelSistemaUsuario MyConnect;


        Pag_Net.Bll.F0130_Controle.Wk WK;


        public frm_Recepcao(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            __SCREEN_TIPO_ACAO = _TipoAcao.CONSULTAR_CONTROLE;
            _Screen_load();
        }



        private void _Screen_load()
        {
            try
            {
                //__WKControle_REG = new Pag_Net.Bll.F0130_Controle.WKControle_Reg(MyConnect);

                /*Icones -----------------------------------------------------------------*/
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdConsultar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdDetalhe.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdAbrir.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
                ///cmdControle_Reg_Alterar_Etapa.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\baixo.ico");

                /*Butons Events  -----------------------------------------------------------------*/
                cmdsair.Click += new EventHandler(_Screen_Click);
                cmdDetalhe.Click += new EventHandler(_Screen_Click);
                cmdAbrir.Click += new EventHandler(_Screen_Click);
                //cmdControle_Reg_Alterar_Etapa.Click += new EventHandler(_Screen_Click);
                cmdDetalhe.Enabled = false;
                cmdAbrir.Enabled = false;
                lbl_controle_reg_seq.TextChanged += new EventHandler(_Screen_changed);

                dtg_etapa.AutoGenerateColumns = false;
                dtg_Pessoas.AutoGenerateColumns = false;
                dtgCONTROLE_REG.AutoGenerateColumns = false;

                chkSomenteEtapasPendentes.Checked = true;
                WK.PropertyChanged += _Controle_DataBinding; 


                _TIMER_tProc = new System.Windows.Forms.Timer();
                _TIMER_tProc.Tick += new EventHandler(tProc_Elapsed);
                _TIMER_tProc.Interval = 1000;
                _TIMER_tProc.Enabled = true;
                _TIMER_tProc.Start();
                _TIMER_EXECUTE = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                if (((Button)sender).Name == "cmdDetalhe") { _Controle_Reg_Consultar(); }
                if (((Button)sender).Name == "cmdAbrir") { _Controle_Reg_Open(); }

            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Name == "lbl_controle_reg_seq") { _Controle_Reg_Selecionar(); }
                }
                if (sender.GetType().Name == "TextBox") { }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
                if (sender.GetType().Name == "TabControl") { if (((TabControl)sender).Name == "tabPortaria") { } }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }




        private void tProc_Elapsed(object sender, EventArgs e)
        {
            try
            {
                _TIMER_EXECUTE += 1;
                if (_TIMER_EXECUTE >= 30)
                {
                    Pag_Form.UserTools._Screen_Wait(this, true);
                    _Consultar();
                    Pag_Form.UserTools._Screen_Wait(this, false);
                    _TIMER_EXECUTE = 0;
                }
                lblatualizacao_timer.Text = string.Format("Atualização em: {0}/30", _TIMER_EXECUTE.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdRecursoCtrl_Click(object sender, EventArgs e)
        {
            try
            {
                Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl frm = new Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl(MyConnect);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            _Consultar();
        }

        private void _Consultar()
        {
            try
            {
                _Controle_Reg_Clear();
                WK.__Filtro.controle_cd = 15;
                WK.__Filtro.controle_reg_data_inicial = dtpcontrole_reg_data_inicial.Value;
                WK.__Filtro.controle_reg_data_final = dtpcontrole_reg_data_final.Value;
                WK.__Filtro.controle_status_cd = chkSomenteEtapasPendentes.Checked ? 1 : 0;
                Pag_Form.UserTools._Screen_Wait(this);
                WK.ControleRegList_Get();
                Pag_Form.UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _Controle_DataBinding(object sender, PropertyChangedEventArgs e)
        {

            try
            {
                dtgCONTROLE_REG.DataSource = WK.dbList.List;
                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        item.DataBindings.Clear();
                        item.DataBindings.Add("Text", dtgCONTROLE_REG.DataSource, name);
                    }
                }


                foreach (DataGridViewRow row in dtgCONTROLE_REG.Rows)
                {
                    if (Convert.ToInt32(row.Cells[12].Value) > 0) { row.DefaultCellStyle.BackColor = Color.LightCoral; }

                    if (Convert.ToInt32(row.Cells[13].Value) == 15) { row.DefaultCellStyle.BackColor = Color.DarkSeaGreen; }

                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Controle_Reg_Selecionar()
        {
            if (lbl_controle_reg_seq.Text == "")
            {
                cmdAbrir.Enabled = false;
                cmdDetalhe.Enabled = false;
                _Controle_Reg_Clear();
            }
            else
            {
                cmdDetalhe.Enabled = true;
                cmdAbrir.Enabled = true;
            }
        }
        private void _Controle_Reg_Consultar()
        {
            try
            {
                Pag_Form.UserTools._Screen_Wait(this, true);
                WK.CONTROLE_REG.controle_reg_seq = Convert.ToInt32(lbl_controle_reg_seq.Text);
                WK.CONTROLE_REG.Binding(MyConnect, new Pag_Net.Bll.F0130_Controle.model_controle(Convert.ToInt32(lbl_controle_cd.Text), lbl_controle_descricao.Text));
                dtg_etapa.DataSource = WK.CONTROLE_REG.Etapas;
                dtg_Pessoas.DataSource = WK.CONTROLE_REG.Pessoas;
                Pag_Form.UserTools._Screen_Wait(this, false);
            }
            catch (Exception EX)
            {
                Pag_Form.UserTools._Screen_Wait(this, false);
                MessageBox.Show(EX.Message);
            }
        }
        private void _Controle_Reg_Clear()
        {
            dtg_etapa.DataSource = null;
            dtg_Pessoas.DataSource = null;
        }
        private void _Controle_Reg_Open()
        {
            try
            {
                if (lbl_controle_cd.Text != "")
                {
                    if (lbl_controle_cd.Text == "10")
                    {
                        UserTools._Screen_Wait(this, cmdAbrir, true);
                        frm_Transporte_Ctrl frm = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text), null);
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        frm.ShowDialog();
                    }
                    if (lbl_controle_cd.Text == "15")
                    {
                        //frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa, new Pag_Net.Bll.F0130_Controle.model_controle_reg(15, Convert.ToInt32(lbl_controle_reg_numero.Text), DateTime.Now, Convert.ToInt32(lbl_controle_reg_seq.Text), 0, 0));
                        frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        FrmServicoExecucaoCtrl.ShowDialog();
                    }
                    _Consultar();


                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdAbrir, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }


    }
}
