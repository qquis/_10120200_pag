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
    public partial class frm_ControleFin : Form
    {

        _TipoAcao __SCREEN_TIPO_ACAO;

        public enum _TipoAcao
        {
            CONSULTAR_CONTROLE = 0,
            INCLUSAO_CONTROLE = 1,
            ALTERACAO_ETAPA = 2,
            ALTERACAO_PGTO = 3

        }

        Pag_Net.Models.modelSistemaUsuario MyConnect;

        
        Pag_Net.Bll.F0130_Controle.Wk _WKCONTROLE;
        Pag_Net.src.F0080_Financeiro._index _WK_Financeiro;
        Pag_Net.Bll.F0130_Controle.model_controle_reg _CONTROLE_REG; 

        public frm_ControleFin(Pag_Net.Models.modelSistemaUsuario _MyConnect, Pag_Net.Bll.F0130_Controle.model_controle_reg __controle_reg)
        {
            InitializeComponent();
            MyConnect = _MyConnect;

            _WKCONTROLE = new Pag_Net.Bll.F0130_Controle.Wk(MyConnect);
            _WK_Financeiro = new Pag_Net.src.F0080_Financeiro._index(MyConnect);
            _CONTROLE_REG = __controle_reg;
            
            __SCREEN_TIPO_ACAO = _TipoAcao.CONSULTAR_CONTROLE;
            _Screen_load();
        }



        private void _Screen_load()
        {
            try
            {
                //__WKControle_REG = new Pag_Net.Bll.F0130_Controle.WKControle_Reg(MyConnect);

                /*Icones -----------------------------------------------------------------*/
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons.SetaDupla_Esquerda);
                UserTools._Screen_ButtonImage(cmdConsultar,UserTools.PagButtonsIcons.SetaSimples_Baixo);
                UserTools._Screen_ButtonImage(cmdControle_Reg_Fin_Lancamento, UserTools.PagButtonsIcons.SetaSimples_Baixo);

                //cmdDetalhe.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\baixo.ico");
                //cmdAbrir.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\detalhe.ico");
                ///cmdControle_Reg_Alterar_Etapa.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\baixo.ico");

                /*Butons Events  -----------------------------------------------------------------*/
                cmdsair.Click += new EventHandler(_Screen_Click);
                cmdConsultar.Click += new EventHandler(_Screen_Click);
                cmdControle_Reg_Fin_Lancamento.Click += new EventHandler(_Screen_Click);

                //cmdDetalhe.Click += new EventHandler(_Screen_Click);
                //cmdAbrir.Click += new EventHandler(_Screen_Click);
                //cmdControle_Reg_Alterar_Etapa.Click += new EventHandler(_Screen_Click);
                //cmdDetalhe.Enabled = false;
                //cmdAbrir.Enabled = false;
                lbl_controle_reg_seq.TextChanged += new EventHandler(_Screen_changed);

                //dtg_etapa.AutoGenerateColumns = false;
                //dtg_Pessoas.AutoGenerateColumns = false;
                dtgCONTROLE_REG.AutoGenerateColumns = false;

                cmbforma_pgto_descricao.ValueMember = "fin_forma_pgto_cd";
                cmbforma_pgto_descricao.DisplayMember = "fin_forma_pgto_descricao";
                _WK_Financeiro.Binding_Forma_Pgto_List();
                cmbforma_pgto_descricao.DataSource = _WK_Financeiro.Forma_Pgto_List;
                cmbforma_pgto_descricao.SelectedValueChanged += new EventHandler(_Screen_changed);
                _DataGrid_Controle_Binding();
                optfin_tipo_lancamento_cd_DEBITO.Checked = true;
                optfin_tipo_lancamento_cd_CREDITO.Checked = false;


                //grpPESSOAS.Enabled = false;

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
                if (((Button)sender).Name == "cmdConsultar") { _DataGrid_Controle_Binding(); }
                if (((Button)sender).Name == "cmdsair") { this.Close(); }
                if (((Button)sender).Name == "cmdControle_Reg_Fin_Lancamento") { _Controle_Reg_Fin_Lancamento(); }
                
                
                
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label")
                {
                    //if (((Label)sender).Name == "lbl_controle_reg_seq") { _Controle_Reg_Selecionar(); }
                }
                if (sender.GetType().Name == "TextBox") { }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") 
                { 
                    if (((ComboBox)sender).Name == "cmbforma_pgto_descricao")
                    {
                        switch (((Pag_Net.src.F0080_Financeiro.tbs.TbFin_Forma_Pgto)cmbforma_pgto_descricao.SelectedItem).fin_forma_pgto_cd)
                        {
                            case 0:
                                optfin_tipo_lancamento_cd_DEBITO.Checked = true;
                                optfin_tipo_lancamento_cd_CREDITO.Checked = false;
                                break;
                            default:
                                optfin_tipo_lancamento_cd_DEBITO.Checked = false;
                                optfin_tipo_lancamento_cd_CREDITO.Checked = true;
                                break;
                        }
                    }
                    
                }
                if (sender.GetType().Name == "TabControl") { if (((TabControl)sender).Name == "tabPortaria") { } }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void _DataGrid_Controle_Binding()
        {
            try
            {
                //_Controle_Reg_Clear();
                Pag_Form.UserTools._Screen_Wait(this, true);
                _CONTROLE_REG.Binding_Fin(MyConnect);
                dtgCONTROLE_REG.DataSource = _CONTROLE_REG.Financeiro_Lancamentos;
                Pag_Form.UserTools._Screen_Wait(this, false);

                lbl_controle_cd.Text = _CONTROLE_REG.controle_cd.ToString();
                lbl_controle_descricao.Text = _CONTROLE_REG.Controle.controle_descricao;
                lbl_controle_reg_seq.Text = _CONTROLE_REG.controle_reg_seq.ToString();
                lbl_controle_reg_numero.Text = _CONTROLE_REG.controle_reg_numero.ToString(); 

                foreach (Control item in this.Controls)
                {
                    if (item.Name.Substring(0, 4) == "lbl_")
                    {
                        string name = item.Name.Substring(4);
                        item.DataBindings.Clear();
                        //item.DataBindings.Add("Text", dtgCONTROLE_REG.DataSource, name);
                    }
                }

                lblinfoTotalDebito.Text = _CONTROLE_REG.Financeiro_Total_Debito.ToString("0.00");
                lblinfoTotalCredito.Text = _CONTROLE_REG.Financeiro_Total_Credito.ToString("0.00");
                lblinfoTotalSaldo.Text = _CONTROLE_REG.Financeiro_Total_Saldo.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _Controle_Reg_Fin_Lancamento()
        {
            try
            {
                if (txtcontrole_reg_fin_valor.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar o Valor do lançamento");
                    txtcontrole_reg_fin_valor.Text = "0";
                    txtcontrole_reg_fin_valor.Focus();
                    return;
                  
                }

                double local_controle_reg_fin_valor = 0;
                local_controle_reg_fin_valor = Convert.ToDouble(txtcontrole_reg_fin_valor.Text);

                if (local_controle_reg_fin_valor <= 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar um Valor válido (maior que zero) para o lançamento");
                    txtcontrole_reg_fin_valor.Text = "0";
                    txtcontrole_reg_fin_valor.Focus();
                    return;
                }

                
                int local_fin_tipo_lancamento_cd = 1;
                if (optfin_tipo_lancamento_cd_CREDITO.Checked)
                    local_fin_tipo_lancamento_cd = 2;

                Pag_Net.src.F0080_Financeiro.tbs.TbFin_Forma_Pgto local_TbFin_Forma_pgto = ((Pag_Net.src.F0080_Financeiro.tbs.TbFin_Forma_Pgto)cmbforma_pgto_descricao.SelectedItem);


                int local_autpgto_seq = 0; 
                if (txtautpgto_seq.Text != "")
                    local_autpgto_seq = Convert.ToInt32(txtautpgto_seq.Text);


                UserTools._Screen_Wait(this, true);
                _CONTROLE_REG.Set_Fin_Add(MyConnect, txtcontrole_reg_fin_descritivo.Text, local_fin_tipo_lancamento_cd, local_TbFin_Forma_pgto, local_autpgto_seq, local_controle_reg_fin_valor);
                UserTools._Screen_Wait(this, false);

                txtautpgto_seq.Text = "0";
                txtcontrole_reg_fin_descritivo.Text = "";
                txtcontrole_reg_fin_valor.Text = "0";
                _DataGrid_Controle_Binding();

            }
            catch(Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Error: ", ex);
           
            }
        }

    }
}
