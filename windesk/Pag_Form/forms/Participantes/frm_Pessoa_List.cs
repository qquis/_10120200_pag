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
    public partial class frm_Pessoa_List : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0011_Participante.Wk WKParticipante {get; set;}
        public Pag_Net.Bll.F0011_Participante.ModelParticipante ParticipateSelecionado;
        private int CdParticipanteSelecionado;
        private bool TipoFormularioPesquisa = false;


        public frm_Pessoa_List(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load(Pag_Net.Bll.F0011_Participante.enumParticipanteTipoCd.todos);

        }


        public frm_Pessoa_List(Pag_Net.Models.modelSistemaUsuario _MyConnect,  Pag_Net.Bll.F0011_Participante.enumParticipanteTipoCd TipoDeParticipante)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            TipoFormularioPesquisa = true;
            _Screen_load(TipoDeParticipante);
            
        }

        private void _Screen_load(Pag_Net.Bll.F0011_Participante.enumParticipanteTipoCd TipoDeParticipante)
        {
            try
            {
                WKParticipante = new Pag_Net.Bll.F0011_Participante.Wk(MyConnect);
                ParticipateSelecionado = new Pag_Net.Bll.F0011_Participante.ModelParticipante();
                UserTools._Screen_ButtonImage(cmdLocalizarGrupoEconomico, UserTools.PagButtonsIcons.Localizar);
                UserTools._Screen_ButtonImage(cmdCancelaSelecaoGrupoEconomico, UserTools.PagButtonsIcons.DeleteError);
                
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_Form_Format_DataGridView(dtgParticipante);
                UserTools._Screen_Form_Format_DataGridView(dtgParticipanteTipo);
                dtgParticipanteTipo.DataSource = Pag_Net.Bll.F0011_Participante.MyGets.mParticipante_Tipos(MyConnect, TipoDeParticipante);


                cmdBlueSoftInteg.Enabled = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 151001); ;

                lbl_cdparticipante.TextChanged += new EventHandler(_SelecionarParticipante);

                WKParticipante.PropertyChanged += _ListParticipantes_Show;
                if (TipoFormularioPesquisa)
                {
                    if (TipoDeParticipante != Pag_Net.Bll.F0011_Participante.enumParticipanteTipoCd.todos)
                    {

                        for (int i = 0; i <= dtgParticipanteTipo.Rows.Count - 1; i++)
                        {
                            //dtgParticipanteTipo.Rows[i].Cells[2].Value = 1;
                            //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgParticipanteTipo.Rows[i].Cells[2];
                            //bool SELECAO = true;
                            //chk.Value = SELECAO;

                            dtgParticipanteTipo.Rows[i].Cells[2].Value = true;

                        }
                        dtgParticipanteTipo.Refresh();
                        cmdconsultar_Click(null, null);
                    }
                    
                    WKParticipante.Filtros.list_participante_tipo = Pag_Net.Bll.F0011_Participante.MyGets.enumParticipanteTipoCd_get(TipoDeParticipante);
                    cmdDetalhe.Enabled = false;
                    cmdSelecionar.Enabled = true;
                    dtgParticipanteTipo.Enabled = false;
                }
                else
                {
                    cmdDetalhe.Enabled = true;
                    cmdSelecionar.Enabled = false;
                }
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



                if (sender.GetType().Name == "Label") { }
                if (sender.GetType().Name == "TextBox")
                {
    


                }
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox")
                {


                }
                if (sender.GetType().Name == "ComboBox")
                {

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

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _Screen_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Button"){}
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }



        private void cmdBlueSoftInteg_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização dos dados?"))
                {
                    UserTools._Screen_Wait(this);
                    Pag_Net.Bll.F0011_Participante.Service.F0011_1103.start(MyConnect);
                    UserTools._Screen_Wait(this, false);
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Atualização Realizada com sucesso!");
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                WKParticipante.Filtros.cdparticipante = 0;
                WKParticipante.Filtros.cdpessoabluesoft = 0;
                WKParticipante.Filtros.nome_razao = "";
                WKParticipante.Filtros.cpf_cnpj = "";
                

                txtnome_razao.Text = txtnome_razao.Text.ToString().ToUpper();


                if (txtcdparticipante.Text != "")
                    WKParticipante.Filtros.cdparticipante = Convert.ToInt32(txtcdparticipante.Text);

                if (txtcdpessoabluesoft.Text != "")
                    WKParticipante.Filtros.cdpessoabluesoft = Convert.ToInt32(txtcdpessoabluesoft.Text);

                WKParticipante.Filtros.nome_razao = txtnome_razao.Text.ToString().Replace("'", "").ToUpper();

                if (txtcpf_cnpj.Text != "")
                    WKParticipante.Filtros.cpf_cnpj = txtcpf_cnpj.Text;

                WKParticipante.Filtros.bluesoftcliente = chkBlueSoftCliente.Checked ? 1 : 0;
                WKParticipante.Filtros.bluesoftvendedor = chkBlueSoftVendedor.Checked ? 1 : 0;
                WKParticipante.Filtros.bluesoftfornecedor = chkBlueSoftFornecedor.Checked ? 1 : 0;
                WKParticipante.Filtros.bluesoftfabricante = chkBlueSoftFabricante.Checked ? 1 : 0;

                WKParticipante.Filtros.list_participante_tipo_clean();
                foreach (DataGridViewRow row in dtgParticipanteTipo.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                    if (chk.Value != null)
                    {
                        if (Convert.ToBoolean(chk.Value))
                        WKParticipante.Filtros.list_participante_tipo_add((Pag_Net.Bll.F0011_Participante.TbParticipanteTipo)row.DataBoundItem);
                    }
                }

                if (txt_cdgrupoeconomico.Text != "")
                {
                    WKParticipante.Filtros.cdgrupoeconomico = Convert.ToInt32(txt_cdgrupoeconomico.Text);
                }
                
                UserTools._Screen_Wait(this);
                WKParticipante.ParticipantePessoaList_Get();

                UserTools._Screen_DataBinding_Set(lbl_cdparticipante, dtgParticipante.DataSource, "cdparticipante");

                UserTools._Screen_Wait(this, false);
                //_ListParticipantes_Show();
            }
            catch (Exception ex)
            {
                txtnome_razao.Text = "";
                txtcdparticipante.Text = "0";
                txtcdpessoabluesoft.Text = "0";
                txtcpf_cnpj.Text = "";
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                _Detalhe();
                UserTools._Screen_Wait(this, false);
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

        private void cmdSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                ParticipateSelecionado = new Pag_Net.Bll.F0011_Participante.ModelParticipante(CdParticipanteSelecionado);
                ParticipateSelecionado.__Consultar(MyConnect);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdLocalizarGrupoEconomico_Click(object sender, EventArgs e)
        {
            try
            {
                txt_cdgrupoeconomico.Text = "0";
                lbl_descricaoGrupoEconomico.Text = "";

                using (forms.Participantes.frm_GrupoEconomico frm = new forms.Participantes.frm_GrupoEconomico(MyConnect, true))
                {


                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txt_cdgrupoeconomico.Text = frm.GrupoEconomicoSelecionado.cdgrupoeconomico.ToString();
                        lbl_descricaoGrupoEconomico.Text = frm.GrupoEconomicoSelecionado.descricao;
                    }
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdCancelaSelecaoGrupoEconomico_Click(object sender, EventArgs e)
        {
            txt_cdgrupoeconomico.Text = "0";
            lbl_descricaoGrupoEconomico.Text = "";
        }


        /*Locals Voids */
        private void _ListParticipantes_Show(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                UserTools._Screen_Wait(this);
                lblNumeroRegistros.Text = "0";
                dtgParticipante.DataSource = WKParticipante.DbParticipanteList.List;
                lblNumeroRegistros.Text = WKParticipante.DbParticipanteList.Count.ToString();
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {

                UserTools._Screen_MessageBox(this, ex);
                UserTools._Screen_Wait(this, false);
            }
        }
        private void _Detalhe()
        {
            try
            {
                if (lbl_cdparticipante.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Selecione um participante");
                    return;
                }
                Pag_Net.Bll.F0011_Participante.ModelParticipante SELECAO = new Pag_Net.Bll.F0011_Participante.ModelParticipante(Convert.ToInt32(lbl_cdparticipante.Text));
                frm_Participante frm = new frm_Participante(MyConnect, SELECAO);
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void _SelecionarParticipante(object sender, EventArgs e)
        {
            CdParticipanteSelecionado = 0;
            if (lbl_cdparticipante.Text != "")
            CdParticipanteSelecionado = Convert.ToInt32(lbl_cdparticipante.Text);
        }


    }
}
