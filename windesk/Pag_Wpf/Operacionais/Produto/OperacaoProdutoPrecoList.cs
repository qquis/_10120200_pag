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

namespace Pag_Wpf.Operacionais.Produto
{
    public partial class OperacaoProdutoPrecoList : Form
    {
        private Pag_Net.Bll.Operacionais.Produto.Kit _BLL;
        modelSistemaUsuario MyConnect;
        public OperacaoProdutoPrecoList(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            MyConnect = __myConnect;
            _BLL = new Pag_Net.Bll.Operacionais.Produto.Kit(__myConnect);


            DataGridProdutoLocaliza.AutoGenerateColumns = false;
            DataGridProdutoLocaliza.MultiSelect = true;
            DataGridProdutoLocaliza.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[7].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[9].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[10].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[11].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[12].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[13].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[14].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[15].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[16].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridProdutoLocaliza.Columns[17].SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridProdutoLocaliza.Columns[0].Frozen = true;
            DataGridProdutoLocaliza.Columns[1].Frozen = true;
            DataGridProdutoLocaliza.Columns[2].Frozen = true;

            DataGridProdutoLocaliza.AllowUserToAddRows = false;
            //DataGridProdutoLocaliza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CMBFabricante.ValueMember = "CdFabricante";
            CMBFabricante.DisplayMember = "Descricao";
            CMBDepartamento.ValueMember = "CdProdutoDepartamento";
            CMBDepartamento.DisplayMember = "DescricaoDepartamento";
            CMBSecao.ValueMember = "CdProdutoSecao";
            CMBSecao.DisplayMember = "DescricaoSecao";
            CMBLinha.ValueMember = "CdProdutoLinha";
            CMBLinha.DisplayMember = "DescricaoLinha";
            CMBDepartamento.DataSource = _BLL.Cadastros.Complementos.Departamento;
            CMBSecao.DataSource = _BLL.Cadastros.Complementos.Secao;
            CMBLinha.DataSource = _BLL.Cadastros.Complementos.Linha;
            CMBFabricante.DataSource = _BLL.Fabricantes.ViewData;

            //CMBCategoria.ValueMember = "SeqProdutoCategoria";
            //CMBCategoria.DisplayMember = "Descricao";
            //CMBCategoria.DataSource = _BLL.Categoria.ViewData;

            DtpDataAplicacao.Value = DateTime.Now;

        }

        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                TXTTotalItens.Text = "0";
                TXTTotalValor.Text = "0,00";
                TXTTotalCusto.Text = "0,00";
                TXTTotalQtde.Text = "0,00";
                TXTTotalMargem.Text = "0,00";
                TXTMargemSimulada.Text  = "0,00";
                TXTTotalSimulado.Text  = "0,00";
                TXTTotalSimuladoCusto.Text = "0,00"; 

                DataGridProdutoLocaliza.Rows.Clear();

                _BLL.PrecoList.Filtros.DataCadastro = false;
                _BLL.PrecoList.Filtros.DataCadastroInicial = DateTime.Now;
                _BLL.PrecoList.Filtros.DataCadastroFinal = DateTime.Now;
                _BLL.PrecoList.Filtros.StatusProduto = true;
                _BLL.PrecoList.Filtros.CdProdutoDepartamento = "";
                _BLL.PrecoList.Filtros.CdProdutoSecao = "";
                _BLL.PrecoList.Filtros.CdProdutoLinha = "";
                _BLL.PrecoList.Filtros.SeqProdutoCategoria = 0;
                _BLL.PrecoList.Filtros.CdFabricante = "";


                _BLL.PrecoList.Filtros.DataVendaInicial = DTPVendasInicio.Value.Date;
                _BLL.PrecoList.Filtros.DataVendaFinal = DTPVendasFim.Value.Date;


                if (TXTEstoqueInicial.Text.Trim() == "" && TXTEstoqueFinal.Text.Trim() == "")
                {
                    _BLL.PrecoList.Filtros.FiltroEstoque = false;
                }
                else
                {
                    _BLL.PrecoList.Filtros.FiltroEstoque = true;
                    if (TXTEstoqueInicial.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.EstoqueInicial = Convert.ToDouble(TXTEstoqueInicial.Text);
                    }

                    if (TXTEstoqueFinal.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.EstoqueFinal = Convert.ToDouble(TXTEstoqueFinal.Text);
                    }
                }


                if (TxtMargemVendasFinal.Text.Trim() == "" && TxtMargemVendasInicial.Text.Trim() == "")
                {
                    _BLL.PrecoList.Filtros.FiltroMargemVendas = false;
                }
                else
                {
                    _BLL.PrecoList.Filtros.FiltroMargemVendas = true;
                    if (TxtMargemVendasInicial.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.MargemVendasInicial= Convert.ToDouble(TxtMargemVendasInicial.Text);
                    }

                    if (TxtMargemVendasFinal.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.MargemVendasFinal = Convert.ToDouble(TxtMargemVendasFinal.Text);
                    }
                }




                if (TXTValorVendasInicial.Text.Trim() == "" && TXTValorVendasFinal.Text.Trim() == "")
                {
                    _BLL.PrecoList.Filtros.FiltroValorVendas = false;
                }
                else
                {
                    _BLL.PrecoList.Filtros.FiltroValorVendas = true;
                    if (TXTValorVendasInicial.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.ValorVendasInicial = Convert.ToDouble(TXTValorVendasInicial.Text);
                    }

                    if (TXTValorVendasFinal.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.ValorVendasFinal = Convert.ToDouble(TXTValorVendasFinal.Text);
                    }
                }



                if (TXTQtdeVendidaInicial.Text.Trim() == "" && TXTQtdeVendidaFinal.Text.Trim() == "")
                {
                    _BLL.PrecoList.Filtros.FiltroQtdeVendas = false;
                }
                else
                {
                    _BLL.PrecoList.Filtros.FiltroQtdeVendas = true;
                    if (TXTQtdeVendidaInicial.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.QtdeVendasInicial= Convert.ToDouble(TXTQtdeVendidaInicial.Text);
                    }

                    if (TXTQtdeVendidaFinal.Text.Trim() != "")
                    {
                        _BLL.PrecoList.Filtros.QtdeVendasFinal = Convert.ToDouble(TXTQtdeVendidaFinal.Text);
                    }
                }




                if (Convert.ToString(CMBDepartamento.SelectedValue) != "" && CMBDepartamento.SelectedValue != null)
                {
                    _BLL.PrecoList.Filtros.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
                }
                if (Convert.ToString(CMBSecao.SelectedValue) != "" && CMBSecao.SelectedValue != null)
                {
                    _BLL.PrecoList.Filtros.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao;
                }
                if (Convert.ToString(CMBLinha.SelectedValue) != "" && CMBLinha.SelectedValue != null)
                {
                    _BLL.PrecoList.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
                }

                if (Convert.ToString(CMBLinha.SelectedValue) != "" && CMBLinha.SelectedValue != null)
                {
                    _BLL.PrecoList.Filtros.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
                }

                if (Convert.ToString(CMBFabricante.SelectedValue) != "" && CMBFabricante.SelectedValue != null)
                {
                    _BLL.PrecoList.Filtros.CdFabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)CMBFabricante.SelectedItem).CdFabricante;
                }

                _BLL.PrecoList.Filtros.Descricao = TXTDescricaoProduto.Text;
                _BLL.PrecoList.Filtros.Codigos = TXTCodigoProduto.Text;


                _BLL.PrecoList.Select();
                
                int linha = 0;
                double VendasCustoTotal = 0;
                double VendasValorTotal = 0;
                double VendasMargem = 0;
                double VendasQtde = 0;


                foreach (Pag_Net.Bll.Operacionais.Produto.UVWProdutoPrecoList item in _BLL.PrecoList.ViewData)
                {
                    DataGridProdutoLocaliza.Rows.Add();
                    DataGridProdutoLocaliza["DTGColumnCdProduto", linha].Value = item.CdProduto.ToString();
                    DataGridProdutoLocaliza["DTGColumnDescricao", linha].Value = item.Descricao.ToString();
                    DataGridProdutoLocaliza["DTGColumnEmbalagemEstoque", linha].Value = item.EmbalagemEstoque.ToString();
                    DataGridProdutoLocaliza["DTGColumnEmbalagemEstoqueQtde", linha].Value = item.EmbalegmEstoqueQtde;
                    DataGridProdutoLocaliza["DTGColumnVendasCustoTotal", linha].Value = item.ValorVendasCustoTotal;
                    DataGridProdutoLocaliza["DTGColumnVendasValorTotal", linha].Value = item.ValorVendasValorTotal;
                    if (item.ValorVendasValorTotal == 0)
                    {
                        if (item.ValorVendasQtdeTotal > 0)
                        {
                            DataGridProdutoLocaliza["DTGColumnVendasMargem", linha].Value = -100;
                        }
                        else
                        {
                            DataGridProdutoLocaliza["DTGColumnVendasMargem", linha].Value = 0;
                        }
                    }


                    if (item.ValorVendasValorTotal < item.ValorVendasCustoTotal)
                    {
                        DataGridProdutoLocaliza["DTGColumnVendasMargem", linha].Value = Math.Round((item.ValorVendasValorTotal - item.ValorVendasCustoTotal) / item.ValorVendasCustoTotal * 100, 2);
                    }

                    if (item.ValorVendasValorTotal > item.ValorVendasCustoTotal)
                    {
                        DataGridProdutoLocaliza["DTGColumnVendasMargem", linha].Value = Math.Round((item.ValorVendasValorTotal - item.ValorVendasCustoTotal) / item.ValorVendasValorTotal * 100, 2);
                    }

                    DataGridProdutoLocaliza["DTGColumnVendasCustoMedio", linha].Value = item.ValorVendasCustoMedio;
                    DataGridProdutoLocaliza["DTGColumnVendasPrecoMedio", linha].Value = item.ValorVendasPrecoMedio;
                    DataGridProdutoLocaliza["DTGColumnVendasQtde", linha].Value = item.ValorVendasQtdeTotal;
                    DataGridProdutoLocaliza["DTGColumnCusto", linha].Value = item.ValorCusto;
                    DataGridProdutoLocaliza["DTGColumnPrecoOld", linha].Value = item.ValorPrecoOriginal;

                    if (item.ValorPrecoOriginal == 0)
                    {
                        DataGridProdutoLocaliza["DTGColumnMargem", linha].Value = Convert.ToDouble(-100);
                    }

                    if (item.ValorPrecoOriginal < item.ValorCusto)
                    {
                        DataGridProdutoLocaliza["DTGColumnMargem", linha].Value = Convert.ToDouble((item.ValorPrecoOriginal - item.ValorCusto) / item.ValorCusto * 100);
                    }

                    if (item.ValorPrecoOriginal == item.ValorCusto)
                    {
                        DataGridProdutoLocaliza["DTGColumnMargem", linha].Value = Convert.ToDouble(0);
                    }

                    if (item.ValorPrecoOriginal > item.ValorCusto)
                    {
                        DataGridProdutoLocaliza["DTGColumnMargem", linha].Value = Convert.ToDouble((item.ValorPrecoOriginal - item.ValorCusto) / item.ValorPrecoOriginal * 100);
                    }
                    DataGridProdutoLocaliza["DTGColumnPrecoAplicao", linha].Value = item.ValorPrecoOriginal;
                    DataGridProdutoLocaliza["DTGColumnAplicacaoMargem", linha].Value = DataGridProdutoLocaliza["DTGColumnMargem", linha].Value;
                    DataGridProdutoLocaliza["DTGColumnSeleciona", linha].Value = true;
                    DataGridProdutoLocaliza["DTGColumnNFUltimaEntrada", linha].Value = item.NfUltimaEntrada;
                    DataGridProdutoLocaliza["DTGColumnNFDataUltimaEntrada", linha].Value = item.NfDataUltimaEntrada;
                    DataGridFormatColorMargem("DTGColumnVendasMargem", linha);
                    DataGridFormatColorMargem("DTGColumnMargem", linha);
                    DataGridFormatColorMargem("DTGColumnAplicacaoMargem", linha);

                    linha += 1;

                    VendasCustoTotal = item.ValorVendasCustoTotal + VendasCustoTotal;
                    VendasValorTotal = item.ValorVendasValorTotal + VendasValorTotal;
                    VendasQtde = item.EmbalegmEstoqueQtde + VendasQtde; 

                }


                if (VendasValorTotal == VendasCustoTotal)
                {
                    VendasMargem = 0;
                }

                if (VendasValorTotal > VendasCustoTotal )
                {
                    VendasMargem = Math.Round((VendasValorTotal - VendasCustoTotal) / VendasValorTotal * 100, 2);
                }

                if (VendasValorTotal < VendasCustoTotal )
                {
                    VendasMargem = Math.Round( (VendasValorTotal - VendasCustoTotal) / VendasCustoTotal * 100 ,2);
                }

                TXTTotalItens.Text = linha.ToString();
                TXTTotalValor.Text  = VendasValorTotal.ToString("#,###,##0.00");
                TXTTotalCusto.Text = VendasCustoTotal.ToString("#,###,##0.00");
                TXTTotalQtde.Text = VendasQtde.ToString("#,###,##0.00");
                TXTTotalMargem.Text = VendasMargem.ToString("#,###,##0.00");





                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DataGridProdutoLocaliza_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                double ValorCusto = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnCusto", e.RowIndex].Value);
                double MargemDigitada = 0;
                double PrecoAplicacao = 0;
                double ValorPrecoOld = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoOld", e.RowIndex].Value);
                if (DataGridProdutoLocaliza.Columns[e.ColumnIndex].Name == "DTGColumnPrecoAplicao")
                {
                    PrecoAplicacao = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoAplicao", e.RowIndex].Value);
                    if (PrecoAplicacao == 0)
                    {
                        MargemDigitada = -100;
                    }
                    if (PrecoAplicacao > ValorCusto)
                    {
                        MargemDigitada = (PrecoAplicacao - ValorCusto) / PrecoAplicacao * 100;
                    }
                    if (PrecoAplicacao < ValorCusto)
                    {
                        MargemDigitada = (PrecoAplicacao - ValorCusto) / ValorCusto * 100;
                    }
                }
                if (DataGridProdutoLocaliza.Columns[e.ColumnIndex].Name == "DTGColumnAplicacaoMargem")
                {
                    MargemDigitada = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnAplicacaoMargem", e.RowIndex].Value);
                    if (MargemDigitada < 0.01)
                    {
                        MessageBox.Show("Margem negativa deve ser aplicada diretamente ao preço");
                        DataGridProdutoLocaliza["DTGColumnAplicacaoMargem", e.RowIndex].Value = DataGridProdutoLocaliza["DTGColumnMargem", e.RowIndex].Value;
                        return;
                    }
                    PrecoAplicacao = Math.Round(ValorCusto / (1 - (MargemDigitada / 100)), 2);
                }
                if (DataGridProdutoLocaliza.Columns[e.ColumnIndex].Name == "DTGColumnAplicacaoMargem")
                {
                    DataGridProdutoLocaliza["DTGColumnPrecoAplicao", e.RowIndex].Value = PrecoAplicacao;
                }

                if (DataGridProdutoLocaliza.Columns[e.ColumnIndex].Name == "DTGColumnPrecoAplicao")
                {
                    DataGridProdutoLocaliza["DTGColumnAplicacaoMargem", e.RowIndex].Value = MargemDigitada;
                }
                DataGridFormatColorMargem("DTGColumnAplicacaoMargem", e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DataGridProdutoLocaliza["DTGColumnAplicacaoMargem", e.RowIndex].Value = DataGridProdutoLocaliza["DTGColumnMargem", e.RowIndex].Value;
                DataGridProdutoLocaliza["DTGColumnPrecoAplicao", e.RowIndex].Value = DataGridProdutoLocaliza["DTGColumnPrecoOld", e.RowIndex].Value;

            }
        }


        private void DataGridFormatColorMargem(string column, int linha)
        {
            if (Convert.ToDouble( DataGridProdutoLocaliza[column, linha].Value) < 0)
            {
                DataGridProdutoLocaliza[column, linha].Style.ForeColor = Color.Red;
            }
            else
            {
                DataGridProdutoLocaliza[column, linha].Style.ForeColor = Color.Black;
            }
        }

        private void CMDLimpaSelecao_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridProdutoLocaliza.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSeleciona"].Value = false;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void CMDSelecionaTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridProdutoLocaliza.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                row.Cells["DTGColumnSeleciona"].Value = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CMDSimulacao_Click(object sender, EventArgs e)
        {
            try
            {

                if (DataGridProdutoLocaliza.Rows.Count < 1)
                {
                    MessageBox.Show("Sem informações no Grid");
                    return;
                }

                double ValorSimulacaoVendasTotal = 0;
                double ValorSimuladaoCustoTotal = 0;

                Cursor.Current = Cursors.WaitCursor;
                for (int i = 0; i <= DataGridProdutoLocaliza.Rows.Count - 1; i++)
                {

                    ValorSimulacaoVendasTotal = ValorSimulacaoVendasTotal + (Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoAplicao", i].Value) * Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnVendasQtde", i].Value));
                    ValorSimuladaoCustoTotal = ValorSimuladaoCustoTotal + (Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnCusto", i].Value) * Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnVendasQtde", i].Value));
                }

                if (ValorSimulacaoVendasTotal == ValorSimuladaoCustoTotal)
                {
                    TXTMargemSimulada.Text = "0,00";
                }

                if (ValorSimulacaoVendasTotal > ValorSimuladaoCustoTotal)
                {
                    TXTMargemSimulada.Text = ((ValorSimulacaoVendasTotal - ValorSimuladaoCustoTotal) / ValorSimulacaoVendasTotal * 100).ToString("#,###,##0.00");
                }

                if (ValorSimulacaoVendasTotal < ValorSimuladaoCustoTotal)
                {
                    TXTMargemSimulada.Text = ((ValorSimulacaoVendasTotal - ValorSimuladaoCustoTotal) / ValorSimuladaoCustoTotal * 100).ToString("#,###,##0.00");
                }
                TXTTotalSimuladoCusto.Text = ValorSimuladaoCustoTotal.ToString("#,###,##0.00");
                TXTTotalSimulado.Text = ValorSimulacaoVendasTotal.ToString("#,###,##0.00");
                Cursor.Current = Cursors.Arrow;
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {

                List<Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco> Lista = new List<Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco>();

                for (int i = 0; i <= DataGridProdutoLocaliza.Rows.Count -1 ; i++)
                {
                    if (Convert.ToBoolean(DataGridProdutoLocaliza["DTGColumnSeleciona", i].Value) == true && Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoAplicao", i].Value) != Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoOld", i].Value))
                    {
                        Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco item = new Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco();
                        item.CdProduto = Convert.ToInt32(DataGridProdutoLocaliza["DTGColumnCdProduto", i].Value);
                        item.Descricao = DataGridProdutoLocaliza["DTGColumnDescricao", i].Value.ToString();
                        item.Embalagem = DataGridProdutoLocaliza["DTGColumnEmbalagemEstoque", i].Value.ToString();
                        item.EmbalagemEstoqueCusto = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnCusto", i].Value.ToString());
                        item.EmbalagemEstoque = DataGridProdutoLocaliza["DTGColumnEmbalagemEstoque", i].Value.ToString();
                        item.EmbalagemEstoqueQtde = 1;
                        item.FatorEstoque = 1;
                        item.FatorPrecoAlterado = 1;
                        item.EmbalagemEstoquePrecoAlterado = Convert.ToDouble(DataGridProdutoLocaliza["DTGColumnPrecoAplicao", i].Value.ToString());
                        Lista.Add(item);
                    }
                }

                if (Lista.Count() < 1)
                {
                    MessageBox.Show("Não há itens para efetivar");
                    return;
                }

                OperacaoProdutoPrecoList_Confirmacao frm = new OperacaoProdutoPrecoList_Confirmacao(MyConnect, Lista.ToArray());

                frm.ShowDialog();
                CMDLocalizar_Click(null, null);
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OperacaoProdutoPrecoList_Load(object sender, EventArgs e)
        {

        }

        private void cmdEditarPrecos_Click(object sender, EventArgs e)
        {

            /* TESTE */
            Pag_Net.Bll.Operacionais.Produto.Precos BLLaP = new Pag_Net.Bll.Operacionais.Produto.Precos(MyConnect);
            //BLLaP.CdProduto = 0;
            //BLLaP.CdProdutoDepartamento = "";
            //BLLaP.CdProdutoSecao = "";
            //BLLaP.CdProdutoLinha = "";
            //BLLaP.Descricao = "ACUCAR REFINADO UNIAO";
            BLLaP.DataCustoInicial = Convert.ToDateTime("01/01/1999");
            BLLaP.DataCustoFinal = Convert.ToDateTime("31/12/2030");
            BLLaP.DataAplicacao = DtpDataAplicacao.Value;
            BLLaP.CdOperacao = 2;
            //BLL.DataAplicacao = DTPDataAplicacao.SelectedDate.Value;
            BLLaP.Select();
            //BLL.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)cmbDepartamento.SelectedItem).CdProdutoDepartamento;
            //BLL.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao;
            //BLL.Cadastros.ProdutosComplementos.CdProdutoSecaoSelecionada = ((Pag_Net.Bll.Cadastros.Secao)cmbSecao.SelectedItem).CdProdutoSecao.ToString();
            //BLLaP.Descricao = "BEB";
            BLLaP.Filtrar();
            BLLaP.Produtos();
            try
            {
                //Mouse.OverrideCursor = Cursors.Wait;
                if (BLLaP.SelectProdutoList == null)
                {
                    MessageBox.Show("Selecione uma lista antes de editar");
                    //Mouse.OverrideCursor = Cursors.Arrow;
                    return;
                }

                OperacaoPrecoAplicacao form = new OperacaoPrecoAplicacao(BLLaP, MyConnect);
                //form.IndexSelFabricante = cmbFabricante.SelectedIndex;
                //form.IndexSelDepartamento = cmbDepartamento.SelectedIndex;
                //form.IndexSelSecao = cmbSecao.SelectedIndex;
                //form.IndexSelLinha = cmbLinha.SelectedIndex;
                //form.IndexSelCdOperacao = CmbOperacao.SelectedIndex;
                //form.DataAplicacao = DTPDataAplicacao.SelectedDate.Value;
                System.Windows.Forms.DialogResult Result = form.ShowDialog();
                //if (Result == System.Windows.Forms.DialogResult.OK)
                //{

                //Mouse.OverrideCursor = Cursors.Wait;
                //CMDAtualizar_Click(null, null);
                //}
                //Mouse.OverrideCursor = Cursors.Wait;
                form.DataAplicacao = DtpDataAplicacao.Value;
                BLLaP.Filtrar();
                //DataGridProdutoPreco.ItemsSource = BLLAplica.SelectProdutoList;
                //form.Dispose();
                //form = null;
                //Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                //Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }
    }
}


