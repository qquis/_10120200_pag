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

namespace Pag_Wpf.Cadastro
{
    public partial class FrmAtivoImobilizado : Form
    {
        public modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Cadastros.Imobilizado BLL;
        private int SeqAtivoImobilizado;
        private int SeqAtivoImobilizadoComponente;
        string Command;
        public FrmAtivoImobilizado(modelSistemaUsuario __myConnect, int __seqAtivoImobilizado, int __seqAtivoImobilizadoComponente, string __command)
        {
            InitializeComponent();
            try
            {
                MyConnect = __myConnect;

                CMBEmpresa.ValueMember = "CdEmpresa";
                CMBEmpresa.DisplayMember = "Descricao";
                this.SeqAtivoImobilizado = __seqAtivoImobilizado;
                this.SeqAtivoImobilizadoComponente = __seqAtivoImobilizadoComponente;
                this.Command = __command;
                
                CMBTipo.ValueMember = "SeqTipo";
                CMBTipo.DisplayMember = "DescricaoTipo";
                CMBTipo.DataSource = Util.TiposGetDataView(MyConnect.Tipos,"TbAtivoImobilizado", "SeqTipoAtivo");

                
                

                TXTSeqAtivoImobilizado.Text = this.SeqAtivoImobilizado.ToString();
                TXTSeqAtivoComponente.Text = this.SeqAtivoImobilizadoComponente.ToString();
                BLL = new Pag_Net.Bll.Cadastros.Imobilizado(__myConnect);
                if (SeqAtivoImobilizado > 0 && __command == "EDITAR")
                {
                    CMBEmpresa.Enabled = false;
                    BLL.Ativos.Parametros.SeqAtivoImobilizado = __seqAtivoImobilizado;
                    BLL.Ativos.Parametros.SelecionaTipoComponentes = true;
                    BLL.Ativos.Select();
                    if (BLL.Ativos.ViewData.Count() > 0)
                    {
                        TXTDescricao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).Descricao.ToString();
                        //TXTSeqAtivoComponente.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).SeqAtivoComponente.ToString();
                        TXTCodigoProduto.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).CdProduto.ToString();
                        DTPDataAquisicao.Value = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).DataAquisicao;
                        TXTDocumentoFiscal.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).SeqDocumentoFiscal.ToString();
                        TXTValorAquisicao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).ValorAquisicao.ToString("0.00");
                        TXTValorReposicao.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).ValorReposicao.ToString("0.00");
                        TXTCodigoDeBarra.Text = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).CodigoBarra.ToString();
                        BLL.Empresa.Parametros.CdEmpresa = ((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).CdEmpresa;
                        BLL.Empresa.Select();
                        CMBEmpresa.DataSource = BLL.Empresa.ViewData;
                        if (BLL.Empresa.ViewData.Count() == 1)
                            CMBEmpresa.SelectedIndex = 0;
                        CMBTipo.SelectedIndex = CMBTipo.FindString(((Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLL.Ativos.ViewData[0]).Tipo.ToString());
                        CMBTipo.Enabled = false;
                    }
                }
                else
                {
                    CMBEmpresa.DataSource = BLL.Empresa.ViewData;
                    if (BLL.Empresa.ViewData.Count() == 1)
                        CMBEmpresa.SelectedIndex = 0;
                }



                
                if (SeqAtivoImobilizadoComponente > 0 && __command == "INCLUIR")
                {

                    Pag_Net.Bll.Cadastros.UspAtivoImobilizado BLLAtivoBase = new Pag_Net.Bll.Cadastros.UspAtivoImobilizado(MyConnect);
                    BLLAtivoBase.Parametros.SeqAtivoImobilizado = SeqAtivoImobilizadoComponente;
                    BLLAtivoBase.Parametros.SelecionaTipoComponentes = false;
                    BLLAtivoBase.Select();
                    Pag_Net.Bll.Cadastros.UVWAtivoImobilizado UVWAtivoImobilizadoBase = (Pag_Net.Bll.Cadastros.UVWAtivoImobilizado)BLLAtivoBase.ViewData[0];
                    Pag_Net.Bll.Cadastros.USPEmpresa BLLEmpresaBase = new Pag_Net.Bll.Cadastros.USPEmpresa(MyConnect);
                    BLLEmpresaBase.Parametros.CdEmpresa = UVWAtivoImobilizadoBase.CdEmpresa;
                    BLLEmpresaBase.Select();
                    CMBEmpresa.DataSource = BLLEmpresaBase.ViewData;
                    if (BLL.Empresa.ViewData.Count() == 1)
                        CMBEmpresa.SelectedIndex = 0;
                    CMBEmpresa.Enabled = false;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BLL.Ativos.Parametros.Descricao = TXTDescricao.Text;
                BLL.Ativos.Parametros.CdProduto = TXTCodigoProduto.Text;
                BLL.Ativos.Parametros.DataAquisicao = DTPDataAquisicao.Value;
                BLL.Ativos.Parametros.SeqDocumentoFiscal = Convert.ToInt32(TXTDocumentoFiscal.Text.ToString());
                BLL.Ativos.Parametros.ValorAquisicao = Convert.ToDouble(TXTValorAquisicao.Text.ToString());
                BLL.Ativos.Parametros.ValorReposicao = Convert.ToDouble(TXTValorReposicao.Text.ToString());
                BLL.Ativos.Parametros.SeqTipoAtivo = Convert.ToInt32(CMBTipo.SelectedValue);
                BLL.Ativos.Parametros.CdEmpresa = Convert.ToInt32(CMBEmpresa.SelectedValue.ToString());
                if (TXTSeqAtivoComponente.Text == "")
                {
                    BLL.Ativos.Parametros.SeqAtivoComponente = 0;
                }
                else
                {
                BLL.Ativos.Parametros.SeqAtivoComponente = Convert.ToInt32(TXTSeqAtivoComponente.Text); 
                }
                if (SeqAtivoImobilizado == 0 && Command =="INCLUIR")
                {
                    BLL.Ativos.Insert();
                }
                if (SeqAtivoImobilizado != 0 && Command == "EDITAR")
                {
                    BLL.Ativos.Update();
                }
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Registro processado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Erro:" + ex.Message.ToString());
            }
        }

    }
}
