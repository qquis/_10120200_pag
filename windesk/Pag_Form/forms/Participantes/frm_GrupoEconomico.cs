using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Participantes
{
    public partial class frm_GrupoEconomico : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0012_GrupoEconomico.Wk WK;

        public Pag_Net.Bll.F0012_GrupoEconomico.ModelGrupoEconomico GrupoEconomicoSelecionado;

        bool TipoScrenBuscar = false;
        bool isEdit = false;

        public frm_GrupoEconomico(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }
        
        public frm_GrupoEconomico(Pag_Net.Models.modelSistemaUsuario _MyConnect, bool _TipoScrenBuscar)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            TipoScrenBuscar = _TipoScrenBuscar; 
            _Screen_load();
            
        }

        private void _Screen_load()
        {
            try
            {
                WK = new Pag_Net.Bll.F0012_GrupoEconomico.Wk(MyConnect);
                UserTools._Screen_Form_Open(this);
                UserTools._Screen_ButtonImage(cmdEfetivar_dados, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdCancela_Alteracao, UserTools.PagButtonsIcons.CancelUndo);
                UserTools._Screen_ButtonImage(cmdEditar, UserTools.PagButtonsIcons.Editar);
                UserTools._Screen_Form_Format_DataGridView(Mydtg);
                WK.PropertyChanged += _List_Show;
                __screen_Edit_Cancel(false);

                if (TipoScrenBuscar)
                {
                    cmdEditar.Enabled = false;
                    cmdEditar.Visible = false;
                    cmdCancela_Alteracao.Visible = false;
                    cmdEfetivar_dados.Visible = false;
                }
                else
                {
                    cmdSelecionar.Visible = false;
                }
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

        private void cmdconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                txtdescricao.Text = txtdescricao.Text.ToString().ToUpper();



                WK.Filtros.descricao = txtdescricao.Text.Replace("'","");
                WK.Filtros.grupoeconomico_status = chkgrupoeconomico_status.Checked ? 1 : 0;
                WK.Filtros.johnson_cliente_top = chkjohnson_cliente_top_selecioa.Checked ? 1 : 0;
                WK.GrupoEconomicoList_Get();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }

        }

        /*Locals Voids */
        private void _List_Show(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                UserTools._Screen_Wait(this);
                lblNumeroRegistros.Text = "0";
                Mydtg.DataSource = WK.DbModelGrupoEconomicoList;
                lblNumeroRegistros.Text = WK.DbModelGrupoEconomicoList.Count().ToString();

                UserTools._Screen_DataBinding_Set(lbl_cdgrupoeconomico, WK.DbModelGrupoEconomicoList, "cdgrupoeconomico");
                UserTools._Screen_DataBinding_Set(lbl_descricao, WK.DbModelGrupoEconomicoList, "descricao");
                UserTools._Screen_DataBinding_Set(txt_descricaoresumida, WK.DbModelGrupoEconomicoList, "descricaoresumida");
                UserTools._Screen_DataBinding_Set(txt_referencia, WK.DbModelGrupoEconomicoList, "referencia");

                chkjohnson_cliente_top.DataBindings.Clear();
                chkjohnson_cliente_top.DataBindings.Add("Checked", WK.DbModelGrupoEconomicoList, "Local_bool_johnson_cliente_top");
                
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {

                UserTools._Screen_MessageBox(this, ex);
                UserTools._Screen_Wait(this, false);
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            try
            {
                __screen_Edit_Cancel(true);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        public void __screen_Edit_Cancel(bool _edit)
        {
            isEdit = _edit;

            if (isEdit)
            {
                cmdEfetivar_dados.Enabled = true;
                cmdCancela_Alteracao.Enabled = true;
                cmdEditar.Enabled = false;
            }
            else
            {
                cmdEfetivar_dados.Enabled = false;
                cmdCancela_Alteracao.Enabled = false;
                cmdEditar.Enabled = true;                
            }

            txt_referencia.Enabled = isEdit;
            txt_descricaoresumida.Enabled = isEdit;
            chkjohnson_cliente_top.Enabled = isEdit;



        }

        private void cmdCancela_Alteracao_Click(object sender, EventArgs e)
        {
            __screen_Edit_Cancel(false);
        }

        private void cmdEfetivar_dados_Click(object sender, EventArgs e)
        {
            try
            {


                GrupoEconomicoSelecionado = (Pag_Net.Bll.F0012_GrupoEconomico.ModelGrupoEconomico)Mydtg.SelectedRows[0].DataBoundItem;
                if (UserTools._Screen_MessageBox_OkCancel(this, string.Format("Confirma atualização dos dados do Grupo {0}?", GrupoEconomicoSelecionado.descricao)))
                {
                    UserTools._Screen_Wait(this);
                    GrupoEconomicoSelecionado.descricaoresumida = txt_descricaoresumida.Text.ToString().ToUpper().Replace("'", "");
                    GrupoEconomicoSelecionado.referencia = txt_referencia.Text;
                    GrupoEconomicoSelecionado.johnson_cliente_top = chkjohnson_cliente_top.Checked ? 1 : 0;
                    GrupoEconomicoSelecionado.__Atualizar(MyConnect);
                    __screen_Edit_Cancel(false);
                    UserTools._Screen_Wait(this);
                }

            }
            catch ( Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdBlueSoftInteg_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch ( Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                GrupoEconomicoSelecionado = (Pag_Net.Bll.F0012_GrupoEconomico.ModelGrupoEconomico)Mydtg.SelectedRows[0].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch ( Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);                
            }
        }
    }
}
