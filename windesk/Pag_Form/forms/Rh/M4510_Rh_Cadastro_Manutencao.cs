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
    public partial class M4510_Rh_Cadastro_Manutencao : Form
    {
        Pag_Net.Bll.F0141_Rh.WK WK;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public M4510_Rh_Cadastro_Manutencao(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0141_Rh.WK(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdEfetivar_dados, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_ButtonImage(cmdPesquisar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_Form_Format_DataGridView(dtgFuncionario);
                WK.PropertyChanged += __BindingList;

                dtpDataAdmissao_INI.DataBindings.Add("Enabled", chk_funcionario_data_admissao_filtrar, "Checked");
                dtpDataAdmissao_FIM.DataBindings.Add("Enabled", chk_funcionario_data_admissao_filtrar, "Checked");

                dtpDataRescisao_INI.DataBindings.Add("Enabled", chk_funcionario_data_rescisao_filtrar, "Checked");
                dtpDataRescisao_FIM.DataBindings.Add("Enabled", chk_funcionario_data_rescisao_filtrar, "Checked");

                cmbrh_tipo_contrato_descricao.ValueMember = "rh_tipo_contrato_cd";
                cmbrh_tipo_contrato_descricao.DisplayMember = "rh_tipo_contrato_descricao";
                cmbrh_tipo_contrato_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyComboBoxList.Tipo_Contratos(MyConnect, 0);


                cmbrh_setor_operacional_descricao.ValueMember = "rh_setor_operacional_cd";
                cmbrh_setor_operacional_descricao.DisplayMember = "rh_setor_operacional_descricao";
                cmbrh_setor_operacional_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyComboBoxList.Setor_Operacional(MyConnect);


                cmbrh_setor_operacional_descricao_edit.ValueMember = "rh_setor_operacional_cd";
                cmbrh_setor_operacional_descricao_edit.DisplayMember = "rh_setor_operacional_descricao";
                cmbrh_setor_operacional_descricao_edit.DataSource = Pag_Net.Bll.F0141_Rh.MyComboBoxList.Setor_Operacional(MyConnect);
                

                /* Enableds */
                cmdEfetivar_dados.Enabled = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 451001);
                cmbrh_setor_operacional_descricao_edit.Enabled = Pag_Net.Bll.PagConnection.ConsultarPostgreTarefas(MyConnect, 451001);




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
       private void cmdDetalhe_Click(object sender, EventArgs e)
       {
           _Detalhe();
       }
       private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                WK._Filter.nome = txtnome_razao.Text;
                WK._Filter.data_admissao_filtrar = chk_funcionario_data_admissao_filtrar.Checked ? 1 : 0;

                WK._Filter.data_admissao_ini = dtpDataAdmissao_INI.Value;
                WK._Filter.data_admissao_fim = dtpDataAdmissao_FIM.Value;

                WK._Filter.data_rescicao_filtrar = chk_funcionario_data_rescisao_filtrar.Checked ? 1 : 0;
                WK._Filter.data_rescisao_ini = dtpDataRescisao_INI.Value;
                WK._Filter.data_rescisao_fim = dtpDataRescisao_FIM.Value;

                WK._Filter.dtm_setor_descricao = txt_funcionario_dtm_setor.Text;
                WK._Filter.dtm_secao_descricao = txt_funcionario_dtm_secao.Text;

                WK._Filter.rh_status_ativo = chkFuncionario_Status_Ativo.Checked ? 1 : 0;
                WK._Filter.rh_status_inativo = chkFuncionario_Status_Inativo.Checked ? 1 : 0;

                UserTools._Screen_Wait(this);
                WK.FuncionarioList_Get();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

       public void __BindingList(object sender, PropertyChangedEventArgs e)
       {
           try
           {
               UserTools._Screen_Wait(this);
               dtgFuncionario.DataSource = WK.DbParticipanteList.List;
               UserTools._Screen_DataBinding_Set(lbl_cdparticipante, dtgFuncionario.DataSource, "cdparticipante");
               lbl_list_count.Text = WK.DbParticipanteList.Count.ToString();
               UserTools._Screen_Wait(this);
           }
           catch (Exception ex)
           {
               UserTools._Screen_MessageBox(this, ex);
           }
       }

       private void cmbrh_tipo_contrato_descricao_SelectionChangeCommitted(object sender, EventArgs e)
       {
           try
           {
               Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato TipoContratoSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato)cmbrh_tipo_contrato_descricao.SelectedItem);
               WK._Filter.rh_tipo_contrato_cd = TipoContratoSelecionado.rh_tipo_contrato_cd;
           }
           catch (Exception ex)
           {
               UserTools._Screen_MessageBox(this, ex);
           }
       }

       private void cmbrh_setor_operacional_descricao_SelectionChangeCommitted(object sender, EventArgs e)
       {
           try
           {
               Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional SetorOperacionalSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional)cmbrh_setor_operacional_descricao.SelectedItem);
               WK._Filter.rh_setor_operacional_cd = SetorOperacionalSelecionado.rh_setor_operacional_cd;
           }
           catch (Exception ex)
           {
               UserTools._Screen_MessageBox(this, ex);
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

       private void cmdEfetivar_dados_Click(object sender, EventArgs e)
       {
           try
           {
               WK.FuncionarioList_Clear();
               Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional SetorOperacionalSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional)cmbrh_setor_operacional_descricao_edit.SelectedItem);

               if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma atualização"))
               {
                   UserTools._Screen_Wait(this);
                   foreach (DataGridViewRow item in dtgFuncionario.SelectedRows)
                   {


                       Pag_Net.Bll.F0141_Rh.ModelParticipanteFuncionario Funcionario = new Pag_Net.Bll.F0141_Rh.ModelParticipanteFuncionario();
                       Funcionario.rh_funcionario_cd = Convert.ToInt32(item.Cells["dtf_rh_funcionario_cd"].Value);
                       Funcionario.SetorOperacional.rh_setor_operacional_cd = SetorOperacionalSelecionado.rh_setor_operacional_cd;
                       WK.MyListFuncionario_Add(Funcionario);

                       /*Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario FuncionarioEdit = new Pag_Net.Bll.F0011_Participante.TbParticipanteFuncionario();
                       FuncionarioEdit.funcionario_cd = Convert.ToInt32(item.Cells["dtf_rh_funcionario_cd"].Value);
                       FuncionarioEdit.__Consultar(MyConnect);
                       FuncionarioEdit.SetorOperacional.rh_setor_operacional_cd = SetorOperacionalSelecionado.rh_setor_operacional_cd;
                       FuncionarioEdit._DBUPDATE(MyConnect);
                       */


                   }
                   WK.MylistFuncionario_Update_SetorOperacional();
                   __BindingList(null, null);
                   UserTools._Screen_Wait(this);
                   UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Atualização realizada com sucesso!");
                   
               }

           }
           catch ( Exception ex)
           {
               UserTools._Screen_MessageBox(this, ex);
           }
       }


    }
}
