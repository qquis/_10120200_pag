using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Bll;
using Pag_Net.Models;
using Pag_Net.Bll.Sistemas;

namespace Pag_Wpf.Sistema
{
    public partial class frmSistemaAcessos : Form
    {
        Pag_Net.Bll.Sistemas.CollectionAcesso BLL;
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Sistemas.UVWSistemaFormulario FormularioSelecionado;
        public frmSistemaAcessos(modelSistemaUsuario __myConnect, Pag_Net.Bll.Sistemas.UVWSistemaFormulario _formularioSelecionado)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Sistemas.CollectionAcesso(MyConnect);
                FormularioSelecionado = _formularioSelecionado;
                BLL.Tarefas.Parametros.Cd_Form_Proc = FormularioSelecionado.Cd_Form_Proc;
                TXTCdFormulario.Text = FormularioSelecionado.Cd_Form_Proc.ToString();
                TXTDescricaoFormulario.Text = FormularioSelecionado.Descricao;
                BLL.Tarefas.Select();

                CMBFuncao.ValueMember = "Cd_Funcao";
                CMBParametro.ValueMember = "Cd_Parametro";
                CMBTarefa.ValueMember = "Cd_Tarefa";
                CMBFuncao.DisplayMember = "Descricao";
                CMBParametro.DisplayMember = "Descricao";
                CMBTarefa.DisplayMember = "Observacao";
                
                CMBTarefa.DataSource  = BLL.Tarefas.ViewData;
                CMBParametro.DataSource = BLL.Parametros.ViewData;
                CMBFuncao.DataSource = BLL.Funcao.ViewData;
                

            }

            catch(Exception ex)
            {
                MessageBox.Show (ex.Message);

            }
        }

        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTValor.Text.Trim() != "")
                {
                    BLL.Acessos.Parametros.Cd_Form_Proc = FormularioSelecionado.Cd_Form_Proc;
                    BLL.Acessos.Parametros.Cd_Funcao = ((Pag_Net.Bll.Sistemas.UVWSistemaFuncao)CMBFuncao.SelectedItem).Cd_funcao;
                    BLL.Acessos.Parametros.Cd_Tarefa = ((Pag_Net.Bll.Sistemas.UVWSistemaTarefas)CMBTarefa.SelectedItem).Cd_tarefa;
                    BLL.Acessos.Parametros.Cd_Parametro = ((Pag_Net.Bll.Sistemas.UVWSistemaParametros)CMBParametro.SelectedItem).Cd_Parametro;
                    BLL.Acessos.Parametros.Valor = TXTValor.Text;
                    BLL.Acessos.Insert();
                    MessageBox.Show ("Registro incluido com sucesso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Informe o valor do parâmetro");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void CMBTarefa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TXTTarefa.Text = ((UVWSistemaTarefas)CMBTarefa.SelectedItem).Observacao;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void CMBParametro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TXTParametro.Text = ((UVWSistemaParametros)CMBParametro.SelectedItem).Observacao;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
    }
}
