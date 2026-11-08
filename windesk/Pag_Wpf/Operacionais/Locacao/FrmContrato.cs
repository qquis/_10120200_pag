using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Pag_Net.Bll;

namespace Pag_Wpf.Operacionais.Locacao
{
    public partial class FrmContrato : Form
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacao BLL;
        Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao ContratoSelecionado;

        public FrmContrato(modelSistemaUsuario __myConnect, Pag_Net.Bll.Operacionais.Locacao.UVWContratoLocacao  __contratoSelecionado)
        {

            try
            {
                InitializeComponent();
                DTPDataContrato.Value = DateTime.Now;
                DTPDataInicio.Value =  DateTime.Now;
                DTPDataFim.Value = DateTime.Now;


                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Operacionais.Locacao.UspContratoLocacao(MyConnect);
                ContratoSelecionado = __contratoSelecionado;
                CMBOperacao.ValueMember = "CdOperacao";
                CMBOperacao.DisplayMember = "DescricaoOperacao";
                CMBOperacao.DataSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, "m2910");

                if (ContratoSelecionado != null)
                {
                    TXTSeqContrato.Text = ContratoSelecionado.SeqContrato.ToString();
                    CMBOperacao.SelectedIndex = CMBOperacao.FindString(ContratoSelecionado.DescricaoOperacao);
                    TXTDescricaoContrato.Text = ContratoSelecionado.Descricao.ToString();
                    DTPDataContrato.Value = ContratoSelecionado.DataContrato;
                    DTPDataInicio.Value = ContratoSelecionado.DataInicio;
                    DTPDataFim.Value = ContratoSelecionado.DataFim;



                    CMBOperacao.Enabled = false;
                    DTPDataContrato.Enabled = false;
                    DTPDataInicio.Enabled = false;
                    DTPDataFim.Enabled = false;


                }
                else
                {


                    CMBOperacao.Enabled = true;
                    DTPDataContrato.Enabled = true;
                    DTPDataInicio.Enabled = true;
                    DTPDataFim.Enabled = true;

                }

            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (((Pag_Net.Models.TbSysTbOperacoes)CMBOperacao.SelectedItem).CdOperacao == 0)
                {
                    MessageBox.Show("Favor a operação");
                }

                this.Cursor = Cursors.WaitCursor;
                if (TXTSeqContrato.Text.Trim() != "")
                {
                       BLL.Parametros.SeqContrato = Convert.ToInt32(TXTSeqContrato.Text.ToString().Trim());
                }
                BLL.Parametros.Descricao = TXTDescricaoContrato.Text.ToString();
                BLL.Parametros.DataInicio = DTPDataInicio.Value;
                BLL.Parametros.DataFim = DTPDataFim.Value;
                BLL.Parametros.SeqTipoContrato = Pag_Net.Bll.Util.TiposGetSeq(MyConnect.Tipos, "TbContrato", "SeqTipoContrato", "LOC_IMOVEL");
                BLL.Parametros.CdOperacao = ((Pag_Net.Models.TbSysTbOperacoes)CMBOperacao.SelectedItem).CdOperacao;



                if (this.ContratoSelecionado == null)
                {
                    BLL.Insert();
                }
                else
                {
                    BLL.Update();
                }
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Registro efetivado com sucesso!");

                this.Close();
                
            }
            catch ( Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
