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

    public partial class frm_FV_Frete_Controle : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;



        Pag_Net.Bll.F0004_Forca_Venda.WKFrete WK;



        public frm_FV_Frete_Controle(Pag_Net.Models.modelSistemaUsuario  _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0004_Forca_Venda.WKFrete(MyConnect);
            _Screen_load();
        }
        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_Form_Format_DataGridView(_dtg_roteiro);
                UserTools._Screen_Form_Format_DataGridView(_dtg_roteiro_item);
                UserTools._Screen_Form_Format_DataGridView(_dtg_frete_fechamento);
                UserTools._Screen_Form_Format_DataGridView(_dtg_roteiro_compl);

                //UserTools._Screen_ButtonImage(cmdConsolidar, UserTools.PagButtonsIcons.Efetiva);
                dtpInicio.Value = DateTime.Now;
                dtpFim.Value = DateTime.Now;

                /*COMBO MOTORISTA*/
                cmbParticipanteMotorista.DisplayMember = "nome_razao";
                cmbParticipanteMotorista.ValueMember = "cdpessoabluesoft";
                cmbParticipanteMotorista.DataSource = Pag_Net.Bll.F0011_Participante.ComboBox.Motorista(MyConnect);
                lbl_fv_frete_seq.TextChanged += new EventHandler(_Screen_changed);
                txt_fv_frete_vl_compl.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_inss.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_irpf.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_sest.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_senat.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_antec_bb.LostFocus += new EventHandler(_Screen_lostfocus);
                txt_fv_frete_vl_antec_especie.LostFocus += new EventHandler(_Screen_lostfocus);
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                lblroteiro_cd.DataBindings.Clear();

                int cdcompetencia = 0; 
                if (cmbCompetencia.Text != "")
                {
                    cdcompetencia =  Convert.ToInt32(cmbCompetencia.Text);
                }
                int cdParticipante = ((Pag_Net.Bll.F0011_Participante.ModelParticipante)cmbParticipanteMotorista.SelectedItem).cdparticipante;
                _dtg_roteiro.DataSource = Pag_Net.Bll.F0004_Forca_Venda.Frete.Roteiros(MyConnect, cdcompetencia, cdParticipante,  dtpInicio.Value, dtpFim.Value);

                UserTools._Screen_DataBinding_Set(lblroteiro_cd, _dtg_roteiro.DataSource, "roteiro_cd");
                _frete_consultar();
                UserTools._Screen_Wait(this,false);
                

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

        private void cmdConsultar_Roteiro_Click(object sender, EventArgs e)
        {
            try
            {

                int cdcompetencia = 0;
                int roteiro_cd = 0;

                UserTools._Screen_Wait(this);
                if (lblroteiro_cd.Text == "")
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Info, "Selecione um roteiro");
                    return;
                }

                roteiro_cd = Convert.ToInt32(lblroteiro_cd.Text);
                
                
                if (cmbCompetencia.Text != "")
                    cdcompetencia = Convert.ToInt32(cmbCompetencia.Text);
                int cdParticipante = ((Pag_Net.Bll.F0011_Participante.ModelParticipante)cmbParticipanteMotorista.SelectedItem).cdparticipante;


                _dtg_roteiro_compl.DataSource = Pag_Net.Bll.F0004_Forca_Venda.Frete.RoteirosComplementos(MyConnect, cdcompetencia, cdParticipante, dtpInicio.Value, dtpFim.Value, roteiro_cd);
                _dtg_roteiro_item.DataSource = Pag_Net.Bll.F0004_Forca_Venda.Frete.RoteirosItem(MyConnect, cdcompetencia, cdParticipante, dtpInicio.Value, dtpFim.Value, roteiro_cd);



                UserTools._Screen_Wait(this, false);
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void lblroteiro_cd_TextChanged(object sender, EventArgs e)
        {
            _screen_clear_item_roteiro();
        }



        private void _frete_consultar()
        {
            try
            {
                UserTools._Screen_Wait(this);
                int cdcompetencia = 0;
                if (cmbCompetencia.Text != "")
                {
                    cdcompetencia = Convert.ToInt32(cmbCompetencia.Text);
                }
                int cdParticipante = ((Pag_Net.Bll.F0011_Participante.ModelParticipante)cmbParticipanteMotorista.SelectedItem).cdparticipante;
                _dtg_frete_fechamento.DataSource = Pag_Net.Bll.F0004_Forca_Venda.Frete.FreteConsultar(MyConnect, cdcompetencia, cdParticipante, 0);

                //WK.Frete.Consultar(MyConnect);

                UserTools._Screen_DataBinding_Set(lbl_fv_frete_seq, _dtg_frete_fechamento.DataSource, "fv_frete_seq");
                UserTools._Screen_DataBinding_Set(lbl_nome_razao, _dtg_frete_fechamento.DataSource, "nome_razao");
                UserTools._Screen_DataBinding_Set(lbl_fv_frete_valor, _dtg_frete_fechamento.DataSource, "fv_frete_valor");
                UserTools._Screen_DataBinding_Set(lbl_fv_frete_ajuste_adicao, _dtg_frete_fechamento.DataSource, "fv_frete_ajuste_adicao");
                UserTools._Screen_DataBinding_Set(lbl_fv_frete_ajuste_desconto, _dtg_frete_fechamento.DataSource, "fv_frete_ajuste_desconto");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_compl, _dtg_frete_fechamento.DataSource, "fv_frete_vl_compl");
                UserTools._Screen_DataBinding_Set(lbl_fv_frete_vl_base, _dtg_frete_fechamento.DataSource, "fv_frete_vl_base");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_inss, _dtg_frete_fechamento.DataSource, "fv_frete_vl_inss");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_irpf, _dtg_frete_fechamento.DataSource, "fv_frete_vl_irpf");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_sest, _dtg_frete_fechamento.DataSource, "fv_frete_vl_sest");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_senat, _dtg_frete_fechamento.DataSource, "fv_frete_vl_senat");
                UserTools._Screen_DataBinding_Set(lbl_fv_frete_valor_liq, _dtg_frete_fechamento.DataSource, "fv_frete_valor_liq");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_antec_bb, _dtg_frete_fechamento.DataSource, "fv_frete_vl_antec_bb");
                UserTools._Screen_DataBinding_Set(txt_fv_frete_vl_antec_especie, _dtg_frete_fechamento.DataSource, "fv_frete_vl_antec_especie");




                UserTools._Screen_Wait(this,false);
                //_screen_recalcular();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsolidarFrete_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                int cdcompetencia = 0;
                if (cmbCompetencia.Text != "")
                {
                    cdcompetencia = Convert.ToInt32(cmbCompetencia.Text);
                }
                int cdParticipante = ((Pag_Net.Bll.F0011_Participante.ModelParticipante)cmbParticipanteMotorista.SelectedItem).cdparticipante;
                Pag_Net.Bll.F0004_Forca_Venda.Frete.FreteConsolidar(MyConnect, cdcompetencia, cdParticipante, dtpInicio.Value, dtpFim.Value);
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAplicarValores_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                WK.Frete.UPDATE(MyConnect);
                UserTools._Screen_Wait(this, false);
                //UserReports.ControleFin_Recibo(MyConnect, __WKTransporte_Ctrl.Transporte_Ctrl);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _screen_clear_item_roteiro()
        {
            _dtg_roteiro_item.DataSource = null;
        }
        private void _screen_recalcular()
        {
            try
            {
                if (lbl_fv_frete_seq.Text == "")
                {
                    return;
                }

                
                WK.Frete.fv_frete_seq = Convert.ToInt32(lbl_fv_frete_seq.Text);

                if (lbl_fv_frete_valor.Text == "") lbl_fv_frete_valor.Text = "0";
                if (txt_fv_frete_vl_compl.Text == "") txt_fv_frete_vl_compl.Text = "0";
                if (txt_fv_frete_vl_inss.Text == "") txt_fv_frete_vl_inss.Text = "0";
                if (txt_fv_frete_vl_irpf.Text == "") txt_fv_frete_vl_irpf.Text = "0";
                if (txt_fv_frete_vl_sest.Text == "") txt_fv_frete_vl_sest.Text = "0";
                if (txt_fv_frete_vl_senat.Text == "") txt_fv_frete_vl_senat.Text = "0";
                if (txt_fv_frete_vl_antec_bb.Text == "") txt_fv_frete_vl_antec_bb.Text = "0";
                if (txt_fv_frete_vl_antec_especie.Text == "") txt_fv_frete_vl_antec_especie.Text = "0";
                if (lbl_fv_frete_vl_base.Text == "") lbl_fv_frete_vl_base.Text = "0";

                WK.Frete.fv_frete_seq = 0;
                WK.Frete.fv_frete_valor = 0;
                WK.Frete.fv_frete_vl_compl = 0;
                WK.Frete.fv_frete_vl_base = 0;
                WK.Frete.fv_frete_vl_inss = 0;
                WK.Frete.fv_frete_vl_irpf = 0;
                WK.Frete.fv_frete_vl_sest = 0;
                WK.Frete.fv_frete_vl_senat = 0;
                WK.Frete.fv_frete_valor_liq = 0;
                WK.Frete.fv_frete_vl_antec_bb = 0;
                WK.Frete.fv_frete_vl_antec_especie = 0;

                WK.Frete.fv_frete_seq = Convert.ToInt32(lbl_fv_frete_seq.Text);
                WK.Frete.fv_frete_valor = Convert.ToDouble(lbl_fv_frete_valor.Text);
                WK.Frete.fv_frete_ajuste_adicao = Convert.ToDouble(lbl_fv_frete_ajuste_adicao.Text);
                WK.Frete.fv_frete_ajuste_desconto = Convert.ToDouble(lbl_fv_frete_ajuste_desconto.Text);


                WK.Frete.fv_frete_vl_compl = Convert.ToDouble(txt_fv_frete_vl_compl.Text);
                WK.Frete.fv_frete_vl_base = Convert.ToDouble(lbl_fv_frete_vl_base.Text);
                WK.Frete.fv_frete_vl_inss = Convert.ToDouble(txt_fv_frete_vl_inss.Text);
                WK.Frete.fv_frete_vl_irpf = Convert.ToDouble(txt_fv_frete_vl_irpf.Text);
                WK.Frete.fv_frete_vl_sest = Convert.ToDouble(txt_fv_frete_vl_sest.Text);
                WK.Frete.fv_frete_vl_senat = Convert.ToDouble(txt_fv_frete_vl_senat.Text);
                WK.Frete.fv_frete_valor_liq = Convert.ToDouble(lbl_fv_frete_valor_liq.Text);
                WK.Frete.fv_frete_vl_antec_bb = Convert.ToDouble(txt_fv_frete_vl_antec_bb.Text);
                WK.Frete.fv_frete_vl_antec_especie = Convert.ToDouble(txt_fv_frete_vl_antec_especie.Text);



                WK.Frete.fv_frete_valor = Convert.ToDouble(lbl_fv_frete_valor.Text);
                WK.Frete.fv_frete_vl_compl = Convert.ToDouble(txt_fv_frete_vl_compl.Text);

                WK.Frete.fv_frete_vl_base = WK.Frete.fv_frete_valor + WK.Frete.fv_frete_ajuste_adicao - WK.Frete.fv_frete_ajuste_desconto + WK.Frete.fv_frete_vl_compl;


                WK.Frete.fv_frete_valor_liq = WK.Frete.fv_frete_vl_base - WK.Frete.fv_frete_vl_inss - WK.Frete.fv_frete_vl_irpf - WK.Frete.fv_frete_vl_sest - WK.Frete.fv_frete_vl_senat;



                lbl_fv_frete_vl_base.Text = WK.Frete.fv_frete_vl_base.ToString("0.00");
                lbl_fv_frete_valor_liq.Text = WK.Frete.fv_frete_valor_liq.ToString("0.00");

                WK.Frete.LOCAL_Vl_Deposito_Motorista = WK.Frete.fv_frete_valor_liq - WK.Frete.fv_frete_vl_antec_bb - WK.Frete.fv_frete_vl_antec_especie;
                lbl_Calculado_Vl_Deposito_Motorista.Text = WK.Frete.LOCAL_Vl_Deposito_Motorista.ToString("0.00");



                lbl_Calculado_Vl_BlueSoft.Text = WK.Frete.LOCAL_Vl_Deposito_Motorista.ToString("0.00");
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_Sender_getName(sender) == "lbl_fv_frete_seq")
                {
                    lbl_Calculado_Vl_Deposito_Motorista.Text = (Convert.ToDouble(lbl_fv_frete_valor_liq.Text) - Convert.ToDouble(txt_fv_frete_vl_antec_bb.Text) - Convert.ToDouble(txt_fv_frete_vl_antec_especie.Text)).ToString();
                    lbl_Calculado_Vl_BlueSoft.Text = WK.Frete.LOCAL_Vl_Deposito_Motorista.ToString("0.00");

                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_lostfocus(object sender, EventArgs e) {
            try
            {
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_compl") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_inss") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_irpf") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_sest") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_senat") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_antec_bb") _screen_recalcular();
                if (UserTools._Screen_Sender_getName(sender) == "txt_fv_frete_vl_antec_especie") _screen_recalcular(); 
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                WK.Frete = new Pag_Net.Bll.F0004_Forca_Venda.ModelTbForca_Venda_Frete();
                WK.Frete.fv_frete_seq = Convert.ToInt32(lbl_fv_frete_seq.Text);
                WK.Frete.Consultar(MyConnect);

                

                UserReports.ForcaVenda_Frete_Capa(MyConnect, WK.Frete);
            }

            catch(Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdImprimirDetalhe_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

 
        
    }


}

