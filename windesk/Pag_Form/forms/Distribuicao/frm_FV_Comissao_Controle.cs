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
    public partial class frm_FV_Comissao_Controle : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        //Pag_Net.Bll.F0011_Participante.Wk WKParticipante;
        public frm_FV_Comissao_Controle(Pag_Net.Models.modelSistemaUsuario _MyConnect)
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
                UserTools._Screen_ButtonImage(cmdDetalhe_Comissao,  UserTools.PagButtonsIcons.Detalhe);
                UserTools._Screen_Form_Format_DataGridView(dtgComissaoList);
                UserTools._Screen_Form_Format_DataGridView(_dtgI);
                UserTools._Screen_Form_Format_DataGridView(_dtgPREMIO);
                
                dtpInicio.Value = DateTime.Now.AddDays(-45);
                dtpFim.Value = DateTime.Now;
                dtpInicio.DataBindings.Add("Enabled", chkData, "Checked");
                dtpFim.DataBindings.Add("Enabled", chkData, "Checked");
                    

                /*COMBO VENDEDOR*/
                cmbParticipanteVendedor.DisplayMember = "nome_razao";
                cmbParticipanteVendedor.ValueMember = "cdparticipante";
                cmbParticipanteVendedor.DataSource = Pag_Net.Bll.F0011_Participante.ComboBox.Vendedores(MyConnect);

            }
            catch (Exception ex)
            {
                MessageBox.Show("FRM DISTRIBUIÇÃO | Load \n " + ex.Message);
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
                __clear_item();

                int cdparticipanteVendedor = Convert.ToInt32(cmbParticipanteVendedor.SelectedValue);
                int competencia = 0;

                DateTime DataINI = Convert.ToDateTime("01/01/1900");
                DateTime DataFim = Convert.ToDateTime("31/12/2099");

                if (chkData.Checked)
                {
                    DataINI = dtpInicio.Value ;
                    DataFim = dtpFim.Value;
                }
                try
                {
                    if (cmbCompetencia.Text != "")
                        competencia = Convert.ToInt32(cmbCompetencia.Text);
                }
                catch (Exception)
                {
                    UserTools._Screen_MessageBox(this, "Valor inválido no campo Competência");
                    return;
                }


                UserTools._Screen_Wait(this);
                dtgComissaoList.DataSource = Comissao.List(MyConnect, competencia, cdparticipanteVendedor, DataINI, DataFim);
                UserTools._Screen_DataBinding_Set(lbl_fvc_seq, dtgComissaoList.DataSource, "fvc_seq");
                UserTools._Screen_DataBinding_Set(lbl_cdparticipantevendedor, dtgComissaoList.DataSource, "cdparticipantevendedor");
                UserTools._Screen_DataBinding_Set(lbl_cdparticipantevendedor_faturamento, dtgComissaoList.DataSource, "cdparticipantevendedor_faturamento");
                UserTools._Screen_DataBinding_Set(lbl_nome_razao, dtgComissaoList.DataSource, "nome_razao");
                UserTools._Screen_DataBinding_Set(lbl_nome_razao_vendedor, dtgComissaoList.DataSource, "nome_razao_vendedor");
                UserTools._Screen_DataBinding_Set(lbl_fvc_competencia, dtgComissaoList.DataSource, "fvc_competencia");
                UserTools._Screen_DataBinding_Set(lbl_cpf_cnpj_faturamento, dtgComissaoList.DataSource, "cpf_cnpj_faturamento");
                UserTools._Screen_DataBinding_Set(txt_fvc_comissao_valor_base, dtgComissaoList.DataSource, "fvc_comissao_valor_base");
                UserTools._Screen_DataBinding_Set(txt_fvc_comissao_valor, dtgComissaoList.DataSource, "fvc_comissao_valor");
                UserTools._Screen_DataBinding_Set(txt_fvc_comissao_valor_estorno, dtgComissaoList.DataSource, "fvc_comissao_valor_estorno");
                UserTools._Screen_DataBinding_Set(txt_fvc_fat_valor_pgto_total, dtgComissaoList.DataSource, "fvc_fat_valor_pgto_total");
                UserTools._Screen_DataBinding_Set(txt_fvc_fat_valor_pgto_premio, dtgComissaoList.DataSource, "fvc_fat_valor_pgto_premio");
                UserTools._Screen_DataBinding_Set(txt_fvc_valor_faturamento, dtgComissaoList.DataSource, "fvc_valor_faturamento");
                UserTools._Screen_DataBinding_Set(txt_fvc_fat_valor_pgto_complemento, dtgComissaoList.DataSource, "fvc_fat_valor_pgto_complemento");
                UserTools._Screen_DataBinding_Set(txt_fvc_fat_valor_pgto_impostos, dtgComissaoList.DataSource, "fvc_fat_valor_pgto_impostos");
                UserTools._Screen_DataBinding_Set(txt_fvc_fat_valor_pgto_adiantamentos, dtgComissaoList.DataSource, "fvc_fat_valor_pgto_adiantamentos");
                


                UserTools._Screen_Wait(this,false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdNovaApuracao_Click(object sender, EventArgs e)
        {
            try
            {
                forms.Distribuicao.frm_FV_Comissao_Apuracao frmApuracao = new forms.Distribuicao.frm_FV_Comissao_Apuracao(MyConnect);
                frmApuracao.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDetalhe_Comissao_Click(object sender, EventArgs e)
        {
            __Detalhe();
        }

        private void __Detalhe()
        {
            try
            {
                __clear_item();
                if (lbl_fvc_seq.Text == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Comissão Não selecionada");
                    return;

                }
                int vfvc_seq = Convert.ToInt32(lbl_fvc_seq.Text);
                int competencia = Convert.ToInt32(lbl_fvc_competencia.Text);
                int cdparticipantevendedor = Convert.ToInt32(lbl_cdparticipantevendedor.Text);

                UserTools._Screen_Wait(this);
                _dtgI.DataSource = Comissao.Detalhe(MyConnect, competencia, cdparticipantevendedor, vfvc_seq);
                UserTools._Screen_DataBinding_Set(lbl_fvc_it_seq, _dtgI.DataSource, "fvc_it_seq");
                UserTools._Screen_DataBinding_Set(txt_fvc_percentual, _dtgI.DataSource, "fvc_percentual");


                _dtgPREMIO.DataSource = Comissao.Premio_List(MyConnect, competencia, cdparticipantevendedor);
                UserTools._Screen_Wait(this, false);
            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, ex);
            }
        }

        private void lbl_fvc_seq_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                _dtgPREMIO.DataSource = null;
                _dtgI.DataSource = null;
                __clear_item();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void __clear_item()
        {
            lbl_fvc_it_seq.Text = "";
            txt_fvc_percentual.Text = "0";

        }

  

        private void cmdAtualizarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lbl_fvc_it_seq.Text) == 0)
                    throw new Exception("Sequencial Não definido");
                if (Convert.ToDouble(txt_fvc_percentual.Text) == 0)
                    throw new Exception("Sequencial Não definido");

                if (!UserTools._Screen_MessageBox_OkCancel(this, "Confirma alteração do percentual?"))
                    return;


                Comissao.Alterar_Item(MyConnect, Convert.ToInt32(lbl_fvc_it_seq.Text), Convert.ToDouble(txt_fvc_percentual.Text));
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lbl_fvc_seq.Text) == 0)
                    throw new Exception("Sequencial Não definido");
                if (txt_fvc_fat_valor_pgto_complemento.Text == "")
                    throw new Exception("Valor Não definido");

                if (!UserTools._Screen_MessageBox_OkCancel(this, "Confirma alteração do valor do Complemento?"))
                    return;


                Comissao.Alterar(MyConnect, Convert.ToInt32(lbl_fvc_seq.Text)
                    , Convert.ToDouble(txt_fvc_fat_valor_pgto_complemento.Text)
                    , Convert.ToDouble(txt_fvc_fat_valor_pgto_impostos.Text)
                    , Convert.ToDouble(txt_fvc_fat_valor_pgto_adiantamentos.Text)                                             
                    
                    );

            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
