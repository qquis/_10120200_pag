using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Rh
{
    public partial class frm_rh_Controle : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0130_Controle.Wk WK;
        public frm_rh_Controle(Pag_Net.Models.modelSistemaUsuario _MyConnect)
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

                /*DATA GRIDS -----------------------------------------------------------------*/
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
                WK = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
                WK.PropertyChanged += _Controle_DataBinding;

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
                __Consultar();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }


        private void __Consultar()
        {
            _Controle_Reg_Clear();
            WK.__Filtro.controle_reg_data_inicial = dtpcontrole_reg_data_inicial.Value;
            WK.__Filtro.controle_reg_data_final = dtpcontrole_reg_data_final.Value;
            WK.__Filtro.controle_etapa_cd_list = "12001, 12002, 12003, 12004, 12005, 12006";
            WK.__Filtro.controle_status_cd = chkSomenteEtapasPendentes.Checked ? 1 : 0;

            try
            {
                WK.ControleRegList_Get();
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
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
                MessageBox.Show(ex.Message);
            }

        }

        private void _Controle_Reg_Clear()
        {
            dtg_etapa.DataSource = null;
            dtg_Pessoas.DataSource = null;
            dtg_Controle_OBS.DataSource = null;
            lbl_controle_reg_obs.Text = "";
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

        private void cmdAbrir_Click(object sender, EventArgs e)
        {
            _Controle_Reg_Open();
        }

        private void _Controle_Reg_Open()
        {
            try
            {
                if (lbl_controle_cd.Text != "")
                {
                    if (lbl_controle_cd.Text == "10")
                    {
                        //_TIMER_tProc.Stop();
                        UserTools._Screen_Wait(this, cmdAbrir, true);
                        frm_Transporte_Ctrl frm = new frm_Transporte_Ctrl(MyConnect, frm_Transporte_Ctrl.Ctrl_Transporte_Form_Action.Ctrl_Transporte_Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text), null);
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        frm.ShowDialog();
                        //_TIMER_EXECUTE = -15;
                        //_TIMER_tProc.Start();
                    }
                    if (lbl_controle_cd.Text == "15")
                    {
                        //frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa, new Pag_Net.Bll.F0130_Controle.model_controle_reg(15, Convert.ToInt32(lbl_controle_reg_numero.Text), DateTime.Now, Convert.ToInt32(lbl_controle_reg_seq.Text), 0, 0));
                        frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        FrmServicoExecucaoCtrl.ShowDialog();
                    }

                    if (lbl_controle_cd.Text == "12")
                    {
                        //frm_Servico_Execucao_Ctrl FrmServicoExecucaoCtrl = new frm_Servico_Execucao_Ctrl(MyConnect, frm_Servico_Execucao_Ctrl.Form_Action.Alterar_Etapa, new Pag_Net.Bll.F0130_Controle.model_controle_reg(15, Convert.ToInt32(lbl_controle_reg_numero.Text), DateTime.Now, Convert.ToInt32(lbl_controle_reg_seq.Text), 0, 0));
                        Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl frmRecursoCtrl = new Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl(MyConnect, Pag_Form.forms.Ctrl.Recurso.frm_Recurso_Ctrl.Form_Action.Consultar, Convert.ToInt32(lbl_controle_reg_seq.Text));
                        UserTools._Screen_Wait(this, cmdAbrir, false);
                        frmRecursoCtrl.ShowDialog();
                    }

                    _Controle_DataBinding(null, null);


                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, cmdAbrir, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "", ex);
            }
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            _Controle_Reg_Consultar();
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
    }
}
