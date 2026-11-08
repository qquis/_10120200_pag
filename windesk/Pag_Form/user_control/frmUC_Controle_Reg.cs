using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.user_control
{
    public partial class frmUC_Controle_Reg : UserControl
    {


        _TipoAcao __SCREEN_TIPO_ACAO = _TipoAcao.CONSULTAR_CONTROLE;

        public enum _TipoAcao
        {
            CONSULTAR_CONTROLE = 0,
            INCLUSAO_CONTROLE = 1,
            ALTERACAO_ETAPA = 2,
            ALTERACAO_PGTO = 3

        }

        Pag_Net.Models.modelSistemaUsuario MyConnect;


        public event EventHandler EventHandler_Tipo_Controle_Alterado;
        public event EventHandler EventHandler_Fila_Alterada;

        public Pag_Net.Bll.F0130_Controle.model_controle_reg __iWK_Controle;



        public frmUC_Controle_Reg(Pag_Net.Models.modelSistemaUsuario _MyConnect, Pag_Net.Bll.F0130_Controle.model_controle_reg CONTROLE_REG)
        {
            InitializeComponent();
            
            /*My Connect Init*/
            MyConnect = _MyConnect;

            /*Assinatura*/
            __iWK_Controle = CONTROLE_REG;

            /*Definição de Variáveis Class*/
            //__WKControle_REG.CONTROLE_REG = __controle_REG;

            /*Load Screen*/
            

            __iWK_Controle.Binding(MyConnect, __iWK_Controle.Controle);

            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {

                
                if (__iWK_Controle.controle_reg_seq == 0)
                {
                    __SCREEN_TIPO_ACAO = _TipoAcao.INCLUSAO_CONTROLE;

                }

                /*ComboBOX  CmbControle--------------------------------------------------------------*/
                //CmbControle.DisplayMember = "controle_descricao";
                //CmbControle.ValueMember = "controle_cd";
                //if (CmbControle.DataSource == null)
                //    CmbControle.DataSource = __iWK_Controle.Tipos;
                //CmbControle.SelectedIndex = 0;
                //CmbControle.SelectedValueChanged += new EventHandler(_Screen_changed);
                //CmbControle.LostFocus += new EventHandler(_Screen_lostFocus);

                lbl_controle_descricao.Text = __iWK_Controle.Controle.controle_descricao.ToString();
                lbl_controle_cd.Text = __iWK_Controle.Controle.controle_cd.ToString(); 

                /*ComboBOX  cmbcontrole_fila-------------------------------------------------------------*/
                cmbcontrole_fila_descricao.DisplayMember = "controle_fila_descricao";
                cmbcontrole_fila_descricao.ValueMember = "controle_fila_cd";
                cmbcontrole_fila_descricao.SelectedValueChanged += new EventHandler(_Screen_changed);
                cmbcontrole_fila_descricao.LostFocus += new EventHandler(_Screen_lostFocus);
                cmbcontrole_fila_descricao.DataSource = __iWK_Controle.Controle.Filas;

                if (__iWK_Controle.controle_reg_seq == 0)
                {
                    _ComboBox_Fila_Publish();
                }
                else
                {
                    grpCONTROLE.Enabled = false;
                }


                /*DataGrid */
                dtg_etapa.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox")
                {
                    if (((TextBox)sender).Name == "txtcontrole_reg_seq")
                    {
                    }

                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox")
                {
                    try
                    {

                        if (((ComboBox)sender).Name == "cmbcontrole_fila_descricao") { }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lista de Filas Não encontradas" + ex.Message);
                    }
                }
                if (sender.GetType().Name == "TabControl")
                {


                    if (((TabControl)sender).Name == "tabPortaria")
                    {


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void _Screen_lostFocus(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {
                    if (((ComboBox)sender).Name == "CmbVeiculoModelo") { }
                }
                if (sender.GetType().Name == "TextBox")
                {
                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox")
                {
                    //if (((ComboBox)sender).Name == "CmbControle") { _Controle_Tipo_Selecionar(); }
                    if (((ComboBox)sender).Name == "cmbcontrole_fila_descricao") { _Controle_Fila_Selecionar(); }
                }
            }

            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Focus();
                    ((TextBox)sender).SelectAll();

                }

            }

        }
        private void _Screen_Binding_dtgControlePessoa()
        {
            try
            {
                /*
                if (__WKControle_REG.CONTROLE_REG.Pessoas == null)
                {
                    return;
                }

                //dtgControlePessoa
                txtcpf_cnpj.DataBindings.Clear();
                txtcpf_cnpj.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "cpf_cnpj");

                txtcdparticipante.DataBindings.Clear();
                txtcdparticipante.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "cdparticipante");

                txtcdpessoabluesoft.DataBindings.Clear();
                txtcdpessoabluesoft.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "cdpessoabluesoft");

                txtrh_funcionario_cd.DataBindings.Clear();
                txtrh_funcionario_cd.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "rh_funcionario_cd");

                txtnome_razao.DataBindings.Clear();
                txtnome_razao.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "nome_razao");

                txtdocumento_cnh.DataBindings.Clear();
                txtdocumento_cnh.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "documento_cnh");

                txtendereco_cep.DataBindings.Clear();
                txtendereco_cep.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_cep");

                txtendereco_logradouro.DataBindings.Clear();
                txtendereco_logradouro.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_logradouro");

                txtendereco_numero.DataBindings.Clear();
                txtendereco_numero.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_numero");

                txtendereco_bairro.DataBindings.Clear();
                txtendereco_bairro.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_bairro");


                txtendereco_municipio.DataBindings.Clear();
                txtendereco_municipio.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_municipio");


                cmbendereco_uf.DataBindings.Clear();
                cmbendereco_uf.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "endereco_uf");


                txtcelular_dd.DataBindings.Clear();
                txtcelular_dd.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "celular_dd");

                txtcelular_numero.DataBindings.Clear();
                txtcelular_numero.DataBindings.Add("Text", __WKControle_REG.CONTROLE_REG.Pessoas, "celular_numero");
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _Controle_Fila_Selecionar()
        {

            if (__iWK_Controle.Fila.controle_fila_cd != ((Pag_Net.Bll.F0130_Controle.TbControle_Fila)cmbcontrole_fila_descricao.SelectedItem).controle_fila_cd)
            {

                __iWK_Controle.Set_Fila((Pag_Net.Bll.F0130_Controle.TbControle_Fila)cmbcontrole_fila_descricao.SelectedItem);

            }
            _Exibir_Fila();

            if (this.EventHandler_Fila_Alterada != null)
            {
                this.EventHandler_Fila_Alterada(this, null);
            }
        }


        public void _Exibir_Controle()
        {
            if (__iWK_Controle.controle_cd != 0)
            {
                lbl_controle_cd.Text = __iWK_Controle.controle_cd.ToString();

                if (__iWK_Controle.controle_reg_seq != 0)
                {
                    lbl_controle_reg_numero.Text = __iWK_Controle.controle_reg_numero.ToString();

                    CmbControle.Text = __iWK_Controle.Controle.controle_descricao;
                    lbl_controle_reg_seq.Text = __iWK_Controle.controle_reg_seq.ToString();

                    lbl_controle_status_pgto_descricao.Text = __iWK_Controle.controle_status_pgto_cd.ToString();
                    cmbcontrole_fila_descricao.Text = __iWK_Controle.Fila.controle_fila_descricao;
                    lbl_controle_fila_cd.Text = __iWK_Controle.Fila.controle_fila_cd.ToString();
                    lbl_controle_status_pgto_descricao.Text = __iWK_Controle.controle_status_pgto_descricao.ToString().ToUpper();

                }
            }

            if (__iWK_Controle.controle_status_descricao != "")
                lbl_controle_status_descricao.Text = __iWK_Controle.controle_status_descricao;

        }
        public void _Exibir_Fila()
        {
            if (__iWK_Controle.Fila.controle_fila_cd != 0)
                lbl_controle_fila_cd.Text = __iWK_Controle.Fila.controle_fila_cd.ToString();

            cmbcontrole_fila_descricao.Text = __iWK_Controle.Fila.controle_fila_descricao.ToString();
        }
        public  void _Exibir_Etapas()
        {
            try
            {
                dtg_etapa.DataSource = __iWK_Controle.Etapas;
                if (__iWK_Controle.Etapas != null)
                {
                    lbl_controle_etapa_descricao_atual.Text = __iWK_Controle.Etapa_Atual_Get().controle_etapa_descricao;
                    lbl_controle_etapa_descricao_proxima.Text = __iWK_Controle.Etapa_Proxima_Get().controle_etapa_descricao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _ComboBox_Fila_Publish()
        {
            try
            {
                
                cmbcontrole_fila_descricao.DataSource = __iWK_Controle.Controle.Filas;
                cmbcontrole_fila_descricao.SelectedIndex = 0;
                _Controle_Fila_Selecionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }

        }

        public void _Clear()
        {
            CmbControle.SelectedIndex = -1;
            //cmbcontrole_fila_descricao.Text = "";
            cmbcontrole_fila_descricao.SelectedIndex = -1;

            /* https://oxan.acelerato.com/tickets/31315 
             * Retiramos a linha abaixo do codigo pois, ao menos nesta implementação estava ocasionando erro. 
             * Teremos de ver qual impacto em relação as outras classes
             */

            // ---> _Controle_Fila_Selecionar();
            


            lbl_controle_reg_seq.Text = "";

            lbl_controle_cd.Text = "";
            lbl_controle_etapa_descricao_atual.Text = "";
            lbl_controle_fila_cd.Text = "";
            lbl_controle_reg_numero.Text = "";
            lbl_controle_status_descricao.Text = "";
            lbl_controle_status_pgto_descricao.Text = "";
            //lbl_controle_etapa_cd_atual.Text = "";
            //lbl_controle_etapa_cd_proxima.Text = "";
            lbl_controle_etapa_descricao_atual.Text = "";
            lbl_controle_etapa_descricao_proxima.Text = "";

            dtg_etapa.DataSource = null;

        }
        public void _Binding()
        {
            _Clear();
            _Exibir_Controle();
            _Exibir_Fila();
            _Exibir_Etapas();
        }

        public void _GrpControle_Enabled(Boolean _enabled)
        {
            grpCONTROLE.Enabled = _enabled;
            this.Refresh();
        }
    }
}
