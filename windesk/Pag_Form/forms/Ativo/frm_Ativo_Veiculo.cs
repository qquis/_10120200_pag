using Pag_Net.Bll.F0011_Participante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Ativo
{
    public partial class frm_Ativo_Veiculo : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0035_Ativo.WkAtivoVeiculo WK;
        public frm_Ativo_Veiculo(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load(1==1);
        }
        private void _Screen_load(bool OpenForm)
        {
            try
            {
                if (OpenForm)
                {
                    UserTools._Screen_Form_Format_DataGridView(dtga);
                    UserTools._Screen_Form_Format_DataGridView(dtgR);
                    UserTools._Screen_ButtonImage(cmdpesquisar, UserTools.PagButtonsIcons.Localizar);
                    UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons.SetaSimples_Direita);
                    UserTools._Screen_ButtonImage(cmdCancelar, UserTools.PagButtonsIcons.CancelUndo);
                    UserTools._Screen_ButtonImage(cmdEfetivar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                    //UserTools._Screen_Form_Format_DataGridView(dtgparticipante);


                    /* Ativo Veiculos */ 
                    WK = new Pag_Net.Bll.F0035_Ativo.WkAtivoVeiculo(MyConnect);
                    WK.Filtros.at_tipo_cd = 200;
                    WK.PropertyChanged += __BindingWKAtivo;


                    /* Consulta veículos cadastrados */ 
                    WK.ativoList_Obter();
                    
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void __BindingWKAtivo(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "DbAtivos_List")
                {
                    dtga.DataSource = WK.DbAtivosVeiculos_List.List;
                    UserTools._Screen_DataBinding_Set(txtat_seq, WK.DbAtivosVeiculos_List.List, "at_seq");
                }

                if (e.PropertyName == "DbAtivos_Registro_List")
                {
                    dtgR.DataSource = WK.DbAtivosRegistro_List.List;
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void __BindingWKAtivoRegistro(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "DbAtivos_List")
                {
                    dtga.DataSource = WK.DbAtivosVeiculos_List.List;
                    UserTools._Screen_DataBinding_Set(txtat_seq, WK.DbAtivosVeiculos_List.List, "at_seq");
                    txtat_seq.Text = "0";

                }

                if (e.PropertyName == "DbAtivos_Registro_List")
                {
                    dtgR.DataSource = WK.DbAtivosRegistro_List.List;
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdpesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                WK.Filtros.at_tipo_cd = 200;
                WK.Filtros.at_seq = 0;
                if (txtat_seq.Text != "")
                    WK.Filtros.at_seq = Convert.ToInt32(txtat_seq.Text);
                WK.ativoRegistroList_Obter();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);

                WK.ativoRegistroList_Obter();
                UserTools._Screen_Wait(this);
            }

            catch ( Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 

        }

        private void cmdLocalizarParticipante_Click(object sender, EventArgs e)
        {

            try
            {
                using (frm_Pessoa_List frm = new frm_Pessoa_List(MyConnect, enumParticipanteTipoCd.todos))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txt_cdparticipante.Text = frm.ParticipateSelecionado.cdparticipante.ToString();
                        lbl_nome_razao.Text = frm.ParticipateSelecionado.nome_razao.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
