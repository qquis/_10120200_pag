using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Administrativo
{
    public partial class frm_Controle : Form
    {

        System.Windows.Forms.Timer _TIMER_tProc;
        int _TIMER_EXECUTE;
        int _TIMER_EXECUTE_LIMIT = 15;

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


        public frm_Controle(Pag_Net.Models.modelSistemaUsuario _MyConnect)
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

                UserTools._Screen_Form_Format_DataGridView(dtgCONTROLE_REG);
                UserTools._Screen_Form_Format_DataGridView(dtg_etapa);
                UserTools._Screen_Form_Format_DataGridView(dtg_Pessoas);
                UserTools._Screen_Form_Format_DataGridView(dtg_Controle_OBS);

                /*Icones -----------------------------------------------------------------*/
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdConsultar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdDetalhe.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
                cmdAbrir.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
                

                /*WK EVENT*/
                WK.PropertyChanged += _Controle_DataBinding;

                
                
                /*Butons Events  -----------------------------------------------------------------*/
                //cmdsair.Click += new EventHandler(_Screen_Click);
                //cmdDetalhe.Click += new EventHandler(_Screen_Click);
                //cmdAbrir.Click += new EventHandler(_Screen_Click);

                cmdDetalhe.Enabled = false;
                cmdAbrir.Enabled = false; 
                lbl_controle_reg_seq.TextChanged += new EventHandler(_Screen_changed);



                chkSomenteEtapasPendentes.Checked = true;


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

        private void frm_Controle_MouseMove(object sender, MouseEventArgs e)
        {
            _TIMER_EXECUTE = 0;
        }

        private void _Screen_Click(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                //if (((Button)sender).Name == "cmdConsultar") { _DataGrid_Controle_Binding(); }
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


        private void _Controle_DataBinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                

                dtgCONTROLE_REG.DataSource = WK.dbList.List;

                foreach( Control item in this.Controls)
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
                    if (Convert.ToInt32(row.Cells[12].Value) > 0){row.DefaultCellStyle.BackColor = Color.LightCoral;}

                    if (Convert.ToInt32(row.Cells[13].Value) == 15) { row.DefaultCellStyle.BackColor = Color.DarkSeaGreen; }

                    if (Convert.ToInt32(row.Cells[13].Value) == 12) { row.DefaultCellStyle.BackColor = Color.AliceBlue; }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                

                if (WK.CONTROLE_REG.Controle_Reg_Obs.Count() > 0)
                {
                    dtg_Controle_OBS.DataSource = WK.CONTROLE_REG.Controle_Reg_Obs;
                    lbl_controle_reg_obs.DataBindings.Clear();
                    lbl_controle_reg_obs.DataBindings.Add("Text", dtg_Controle_OBS.DataSource, "controle_reg_obs");
                }

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
            dtg_Controle_OBS.DataSource = null;
            lbl_controle_reg_obs.Text = "";
        }
        private void _Controle_Reg_Open()
        {
            try
            {
                if (lbl_controle_cd.Text != "")
                {
                    if (lbl_controle_cd.Text == "10")
                    {
                        _TIMER_tProc.Stop();
                        UserTools._Screen_Wait(this, cmdAbrir, true);
                        frm_Transporte_Ctrl frm = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text), null);
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        frm.ShowDialog();
                        _TIMER_EXECUTE = -15;
                        _TIMER_tProc.Start();
                    }
                    if (lbl_controle_cd.Text == "15")
                    {
                        _TIMER_tProc.Stop();
                        //frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa, new Pag_Net.Bll.F0130_Controle.model_controle_reg(15, Convert.ToInt32(lbl_controle_reg_numero.Text), DateTime.Now, Convert.ToInt32(lbl_controle_reg_seq.Text), 0, 0));
                        frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        FrmServicoExecucaoCtrl.ShowDialog();
                        _TIMER_EXECUTE = -15;
                        _TIMER_tProc.Start();
                    }

                    if (lbl_controle_cd.Text == "12")
                    {
                        _TIMER_tProc.Stop();
                        //frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa, new Pag_Net.Bll.F0130_Controle.model_controle_reg(15, Convert.ToInt32(lbl_controle_reg_numero.Text), DateTime.Now, Convert.ToInt32(lbl_controle_reg_seq.Text), 0, 0));
                        Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl frmRecursoCtrl = new Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl(MyConnect, Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        frmRecursoCtrl.ShowDialog();
                        _TIMER_EXECUTE = -15;
                        _TIMER_tProc.Start();
                    }

                    __Consultar();


                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdAbrir, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }


        private void tProc_Elapsed(object sender, EventArgs e)
        {
            try
            {
                _TIMER_EXECUTE += 1;
                if (_TIMER_EXECUTE >= _TIMER_EXECUTE_LIMIT)
                {
                    Pag_Form.UserTools._Screen_Wait(this, true);
                    __Consultar();
                    Pag_Form.UserTools._Screen_Wait(this, false);
                    _TIMER_EXECUTE = 0;
                }
                lblatualizacao_timer.Text = string.Format("Atualização em: {0}/{1}", _TIMER_EXECUTE.ToString(), _TIMER_EXECUTE_LIMIT.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgCONTROLE_REG_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            _Controle_Reg_Clear();
        }

        private void cmdRecurso_Ctrl_Click(object sender, EventArgs e)
        {
            try
            {
                //_TIMER_tProc.Stop();
                Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl frm = new Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl(MyConnect, Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl.Form_Action.Incluir, 0);
                frm.ShowDialog();
                //_TIMER_tProc.Start();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            __Consultar();
        }

        private void __Consultar()
        {
            _Controle_Reg_Clear();
            WK.__Filtro.controle_reg_data_inicial = dtpcontrole_reg_data_inicial.Value;
            WK.__Filtro.controle_reg_data_final = dtpcontrole_reg_data_final.Value;
            WK.__Filtro.controle_etapa_cd_list = "";
            WK.__Filtro.controle_status_cd = chkSomenteEtapasPendentes.Checked? 1: 0; 

            try
            {
                WK.ControleRegList_Get();
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAbrir_Click(object sender, EventArgs e)
        {
            _Controle_Reg_Open();
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            _Controle_Reg_Consultar();
        }

    }
}
