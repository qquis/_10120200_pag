using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.Bll.F0004_Forca_Venda;

namespace Pag_Form.forms.Distribuicao
{
    public partial class frm_FV_Comissao_Apuracao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public frm_FV_Comissao_Apuracao(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            //WKParticipante = new Pag_Net.Bll.F0011_Participante.Wk(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_ButtonImage(cmdConsolidar, UserTools.PagButtonsIcons.Efetiva_Seleciona);
                UserTools._Screen_Form_Format_DataGridView(dtgC);
                UserTools._Screen_Form_Format_DataGridView(dtgD);
                cmbCompetencia.Text = "0";
                dtpInicio.Value = DateTime.Now;
                dtpFim.Value = DateTime.Now;

                /*COMBO VENDEDOR*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("FRM DISTRIBUIÇÃO | Load \n " + ex.Message);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblinfo_qtde_lancamentos.Text = "";
                UserTools._Screen_Wait(this);
                dtgD.DataSource = null;
                _lbl_clear();
                this.Refresh();
                DataTable Registros = Comissao.Apuracao(MyConnect, 0, 0, dtpInicio.Value, dtpFim.Value);
                
                dtgC.DataSource = Registros;
                UserTools._Screen_DataBinding_Set(lbl_nome, dtgC.DataSource, "nome");
                UserTools._Screen_DataBinding_Set(lbl_valortotalfaturamento, dtgC.DataSource, "valortotalfaturamento");
                UserTools._Screen_DataBinding_Set(lbl_valorbase, dtgC.DataSource, "valorbase");
                UserTools._Screen_DataBinding_Set(lbl_cdparticipantevendedor, dtgC.DataSource, "cdparticipantevendedor"); 
                UserTools._Screen_Wait(this, false);
                Registros.Dispose();
                
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void _lbl_clear()
        {
            lbl_nome.Text = "";
            lbl_valorbase.Text = "";
            lbl_valortotalfaturamento.Text = "";
            lbl_cdparticipantevendedor.Text = ""; 
        }


        private void cmdDetalhe_Click(object sender, EventArgs e)
        {
            try
            {
                lblinfo_qtde_lancamentos.Text = "";
                if (lbl_cdparticipantevendedor.Text.Trim() == "")
                {
                    MessageBox.Show("Favor informar o vendedor para a busca do detalhe");
                    return;
                }
                UserTools._Screen_Wait(this);
                DataTable Registrosi = Comissao.Apuracao_Item(MyConnect, 0, Convert.ToInt32(lbl_cdparticipantevendedor.Text), dtpInicio.Value, dtpFim.Value);
                lblinfo_qtde_lancamentos.Text = Registrosi.Rows.Count.ToString();
                dtgD.DataSource = null;
                this.Refresh();
                dtgD.DataSource = Registrosi;
                UserTools._Screen_Wait(this, false);
            }
            catch(Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdConsolidar_Click(object sender, EventArgs e)
        {
            try
            {
                if ( Convert.ToInt32(cmbCompetencia.Text) == 0)
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Informe a competência! ");
                    return; 
                }

                if (!UserTools._Screen_MessageBox_OkCancel(this, "Confirma consolidação da Competência " + cmbCompetencia.Text  + " ?"))
                    return;

                UserTools._Screen_Wait(this);
                Comissao.Consolidar(MyConnect, Convert.ToInt32(cmbCompetencia.Text), 0, dtpInicio.Value, dtpFim.Value);
                UserTools._Screen_Wait(this, false);

                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Info, "Consolidação efetuada com sucesso! ");
                this.Close();


            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
