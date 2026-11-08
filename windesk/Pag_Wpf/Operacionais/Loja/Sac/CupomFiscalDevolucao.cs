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
using Pag_Net.Bll.Sac;

namespace Pag_Wpf.Operacionais
{
    public partial class CupomFiscalDevolucao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnection;
        private Pag_Net.Bll.Tables.bllPessoa _BllPessoa;
        private bllOperacaoSac _BllOperacaoSac;


        private TbPessoas _TbPessoa;
        private TbCuponsItens[] _CupomFiscalItens;
        private TbCupons _CupomFiscalSelecionado;
        private TbOperacoesSac.TiposOperacaoSac _TipoOperacao;


        public CupomFiscalDevolucao(Pag_Net.Models.modelSistemaUsuario myconnection, TbOperacoesSac.TiposOperacaoSac tipooperacao, TbCupons tbcupomfiscal, TbCuponsItens[] tbcupomfiscalitensdevolucao)
        {
            InitializeComponent();
            MyConnection = myconnection;
            _CupomFiscalItens = tbcupomfiscalitensdevolucao;
            _CupomFiscalSelecionado = tbcupomfiscal;
            _BllPessoa = new Pag_Net.Bll.Tables.bllPessoa(MyConnection);
            _BllOperacaoSac = new bllOperacaoSac(MyConnection);
            _TipoOperacao = tipooperacao;

            GroupBoxItensDevolucao.Enabled = false;
            GroupBoxNfe.Enabled = false;

            if (_TipoOperacao == TbOperacoesSac.TiposOperacaoSac.Devolucao)
            {
                lbldescprocedimento.Text = "DEVOLUÇÃO CUPOM C/PRODUTO";
                GroupBoxItensDevolucao.Enabled = true;
                CalculaTotalDevolucao();
            }

            if (_TipoOperacao == TbOperacoesSac.TiposOperacaoSac.DevolucaoDinheiro)
            {
                lbldescprocedimento.Text = "DEVOLUÇÃO CUPOM C/DINHEIRO";
                GroupBoxItensDevolucao.Enabled = true;
                CalculaTotalDevolucao();
            }
            if (_TipoOperacao == TbOperacoesSac.TiposOperacaoSac.EmiteNfe)
            {
                lbldescprocedimento.Text = "EMISSÃO NFE";
                GroupBoxNfe.Enabled = true;
            }
            
        }
        private void CupomFiscalDevolucao_Load(object sender, EventArgs e)
        {
            dtitensdevolucao.AutoGenerateColumns = false;
            datagridPessoa.AutoGenerateColumns = false;
            dtitensdevolucao.DataSource = _CupomFiscalItens;
            lblECF.Text = _CupomFiscalSelecionado.Ecf.ToString();
            lblCupomFiscal.Text = _CupomFiscalSelecionado.Cupom.ToString();

        }
        private void dtitensdevolucao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToDouble(dtitensdevolucao[e.ColumnIndex, e.RowIndex].Value.ToString()) <= 0.01 || Convert.ToDecimal(dtitensdevolucao[e.ColumnIndex, e.RowIndex].Value.ToString()) > _CupomFiscalItens[e.RowIndex].Qtde)
            {
                MessageBox.Show("Valor Inválido!");
                _CupomFiscalItens[e.RowIndex].QtdeDevolvida = _CupomFiscalItens[e.RowIndex].Qtde;
                dtitensdevolucao[e.ColumnIndex, e.RowIndex].Value = _CupomFiscalItens[e.RowIndex].Qtde;
            }
            dtitensdevolucao[e.ColumnIndex + 2, e.RowIndex].Value =string.Format("{0,00}", Convert.ToDouble(_CupomFiscalItens[e.RowIndex].Valor) * Convert.ToDouble(_CupomFiscalItens[e.RowIndex].QtdeDevolvida));
            CalculaTotalDevolucao();
        }
        private void CalculaTotalDevolucao()
        {
            double totalDevolucaoCupom = 0;
            foreach (TbCuponsItens x in _CupomFiscalItens)
            {
                totalDevolucaoCupom += Convert.ToDouble(x.QtdeDevolvida) * Convert.ToDouble(x.Valor);
                x.ValorTotal = Convert.ToDecimal(x.QtdeDevolvida) * Convert.ToDecimal (x.Valor);
            }
            lbltotaldevolucao.Text = string.Format("{0,00}", Convert.ToString(Math.Round(totalDevolucaoCupom,2)));
        }
        private void datagridPessoa_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridPessoa.SelectedRows.Count > 0)
            {
                int x = datagridPessoa.SelectedRows[0].Index;
                _TbPessoa = (TbPessoas)datagridPessoa.SelectedRows[0].DataBoundItem;
                lblCodigoClienteSelecionado.Text = datagridPessoa[0, x].Value.ToString();
                lblNomeClienteSelecionado.Text = datagridPessoa[1, x].Value.ToString();
            }
        }
        private void cmdEfetiva_Click(object sender, EventArgs e)
        {
            //Pag_Net.Bll.Tables.bllTbCupons.Devolucao(MyConnection, Convert.ToInt32(_Ecf), Convert.ToInt32(_CupomFiscal), 1, _arrayListItensDevolucao);
            //TbPessoa _tbpessoa = new TbPessoa();
            //datagridPessoa[0, datagridPessoa.SelectedRows[0].Index].Value.ToString();

            try 
            {
                _TbPessoa = new TbPessoas();
                _TbPessoa.CdPessoa = 1;
                _TbPessoa.RazaoSocialNome = "";
                _TbPessoa.Documento = new TbDocumentos(0, "0");
                TbOperacoesSac.TiposOperacaoSac _tipooperacaosac = TbOperacoesSac.TiposOperacaoSac.Devolucao;
                if (_TipoOperacao == TbOperacoesSac.TiposOperacaoSac.EmiteNfe)
                {
                    if (lblCodigoClienteSelecionado.Text == "")
                    {
                        throw new Exception("Selecione um cliente!");
                    }
                    _TbPessoa.CdPessoa = Convert.ToInt32(lblCodigoClienteSelecionado.Text);
                    _TbPessoa.RazaoSocialNome = lblNomeClienteSelecionado.Text.ToString();
                }
                else
                {
                    _tipooperacaosac = TbOperacoesSac.TiposOperacaoSac.Devolucao;
                    _CupomFiscalSelecionado.ValorDevolucao = Convert.ToDouble(lbltotaldevolucao.Text.ToString());
                    //TbDocumentos.TiposDocumentos tiposdocumentos = new TbDocumentos.TiposDocumentos();
                    //if (optCNPJ.Checked)
                     //   tiposdocumentos = TbDocumentos.TiposDocumentos.Cnpj;
                    //if (optCPF.Checked)
                        //tiposdocumentos = TbDocumentos.TiposDocumentos.Cpf;
                    //_TbPessoa = new TbPessoas();
                    //_TbPessoa.RazaoSocialNome = txtDevNomeCliente.ToString();
                    // _TbPessoa.Documento = new TbDocumentos(tiposdocumentos, txtDevDocumento.Text.ToString());
                }
                _BllOperacaoSac.setTbPessoa(_TbPessoa);
                _BllOperacaoSac.Insert(_tipooperacaosac, _CupomFiscalSelecionado, _CupomFiscalItens);
                MessageBox.Show("Operação Realizada com Sucesso");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdNfeBuscaCliente_Click(object sender, EventArgs e)
        {
            //TbPessoa[] _ListaPessoa = Pag_Net.Bll.Tables.bllTbPessoa.GetList(MyConnection, TipoPessoa.Cliente, txtNomeClienteBusca.Text, txtCNPJCPFbusca.Text, txtCNPJCPFbusca.Text, 0);
            //datagridPessoa.DataSource = Pag_Net.Bll.Tables.bllTbPessoa.GetList(MyConnection, TbPessoas.TiposPessoa.Cliente , txtNomeClienteBusca.Text, txtCNPJCPFbusca.Text,  0);//_ListaPessoa;
            
            _BllPessoa.GetList(TbPessoas.TiposPessoa.Cliente, txtNomeClienteBusca.Text, txtCNPJCPFbusca.Text, 0);
            datagridPessoa.DataSource = _BllPessoa.TbPessoas; 
        }

        private void CupomFiscalDevolucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void cmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        




    }
}
