using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Bll;
using Pag_Net.Bll.Operacionais.Produto;

namespace Pag_Wpf.Operacionais.Produto
{
    public partial class OperacaoPrecoAplicacao : Form
    {


        private Pag_Net.Models.modelSistemaUsuario MyConnect;
        private Pag_Net.Bll.Operacionais.Produto.Precos BLL;
        private string FormularioMenu = "m2312";

        private double ValoremEdicao;

        public int IndexSelFabricante { get; set; }
        public int IndexSelDepartamento { get; set; }
        public int IndexSelSecao { get; set; }
        public int IndexSelLinha { get; set; }
        public int IndexSelCdOperacao { get; set; }


        public string ProdutoDescricaoSelecionado { get; set; }
        public string CdProdutoSelecionado {get;set;}
        public DateTime DataAplicacao { get; set; }

        //public VWProdutoOperacaoPreco[] Lista { get; set; }

        private void OperacaoPrecoAplicacao_Shown(object sender, EventArgs e)
        {
            
        }
        public OperacaoPrecoAplicacao(Pag_Net.Models.modelSistemaUsuario __MyConnect)
        {
            
            InitializeComponent();
            MyConnect = __MyConnect;

            BLL = new Pag_Net.Bll.Operacionais.Produto.Precos(MyConnect);
            
            
        }
        public OperacaoPrecoAplicacao (Pag_Net.Bll.Operacionais.Produto.Precos __BLL, Pag_Net.Models.modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            BLL = __BLL;
            MyConnect = __myConnect;

            
            fill(DGLista, BLL.SelectProdutoList);
            LBLQtdeItens.Text = BLL.SelectProdutoList.Count().ToString();
            
        }
        private void OperacaoPrecoAplicacao_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                Cursor.Current = Cursors.WaitCursor;
                //DTPDataAplicacao.Value = this.DataAplicacao;

                DGLista.AutoGenerateColumns = false;
                DGListaEmbalagem.AutoGenerateColumns = false;
                DGListaEmbalagem.MultiSelect = false;
                DGListaEmbalagem.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
                DGListaEmbalagem.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
                DGListaEmbalagem.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
                DGListaEmbalagem.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
                DGListaEmbalagem.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
                DGListaEmbalagem.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;


                DGLista.AllowUserToAddRows = false;
                DGLista.SelectionMode = DataGridViewSelectionMode.CellSelect;

                //foreach (DataGridViewColumn column in DGLista.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                //}
                //DGLista.Sort(DGLista.Columns[1], ListSortDirection.Ascending);
                //DGLista.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Ascending;

                CMBOperacoes.ValueMember = "CdOperacao";
                CMBOperacoes.DisplayMember = "DescricaoOperacao";
                CMBOperacoes.DataSource = Pag_Net.Bll.Operacoes.Get(MyConnect.Operacoes, FormularioMenu);
                CMBOperacoes.SelectedIndex = IndexSelCdOperacao;

                

                //if (this.IndexSelSecao != 0) { CMBSecao.SelectedIndex = this.IndexSelSecao; }
                //if (this.IndexSelLinha != 0) { CMBLinha.SelectedIndex = this.IndexSelLinha; }
                //if (this.IndexSelDepartamento != 0) { CMBDepartamento.SelectedIndex = this.IndexSelDepartamento; }
                //if (this.IndexSelFabricante != 0) { CMBFabricante.SelectedIndex = this.IndexSelFabricante; }
                //if (this.IndexSelCdOperacao != 0) { CMBOperacoes.SelectedIndex = this.IndexSelCdOperacao; }
                //TXTDescricaoProduto.Text = Descricao;
                //TXTCodigoProduto.Text = Convert.ToString(cdProduto);

                fill(DGLista, BLL.SelectProdutoList);
                if (BLL.SelectProdutoList != null)
                {
                    LBLQtdeItens.Text = BLL.SelectProdutoList.Count().ToString();
                }
                Cursor.Current = Cursors.Arrow;
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        
        
        // Privates Voids
        private void Filtrar()
        {

            Cursor.Current = Cursors.WaitCursor;
            BLL.Produtos();
            fill(DGLista, BLL.SelectProdutoList);
            LBLQtdeItens.Text = BLL.SelectProdutoList.Count().ToString();
            Cursor.Current = Cursors.Default;


        }
        private void fill(DataGridView DG, VWProdutoOperacaoPreco[] List)
        {
            //DGLista.DataSource = BLL.Produtos;
            int linha = 0;
            DG.Rows.Clear();
            if (List != null)
            {
                foreach (VWProdutoOperacaoPreco item in List)
                {
                    DG.Rows.Add();
                    DGListaFill(DG, item, linha);
                    linha = linha + 1;
                }
            }
        }

        private void DGListaFill(DataGridView DG, VWProdutoOperacaoPreco item,int __linha)
        {
            DG[0, __linha].Value = item.CdProduto;
            DG[1, __linha].Value = item.Descricao;
            DG[2, __linha].Value = item.Embalagem;
            DG[3, __linha].Value = item.ValorPrecoAlterado;
            DG[4, __linha].Value = 0;
            DG[5, __linha].Value = item.ValorCusto;
            DG[6, __linha].Value = item.MargemAlterada;
            DG[7, __linha].Value = item.ValorPreco;
            DG[8, __linha].Value = item.FatorEstoque;
            DG[9, __linha].Value = item.FatorPrecoAlterado;
            DG[10, __linha].Value = item.IndexLocal;
            DG[11, __linha].Value = item.ValorCustoFaturamento;
            DG[12, __linha].Value = item.ValorVariacaoCusto;
            DG[13, __linha].Value = item.ValorEstoque;


            if (DG.Name == "DGLista")
            {
                DG[14, __linha].Value = item.EmbalagemCdprodutobluesoft;
            }


            if (DG.Name == "DGListaEmbalagem")
            {
                DG[17, __linha].Value = item.EmbalagemCdprodutobluesoft;
            }

            
            if (DG.Name == "DGListAlterados")
            {
                DG[16, __linha].Value = item.EmbalagemCdprodutobluesoft;
            }


            if (DG.Name == "DGListaEmbalagem" || DG.Name == "DGListAlterados")
            {
                DG[14, __linha].Value = item.QtdePromocionalAlterada;
            }

            if (DG.Name == "DGListaEmbalagem" )
            {
                DG[15, __linha].Value = Math.Round( Convert.ToDouble( (1 - item.FatorPrecoAlterado) * 100),2);
                DG[16, __linha].Value = item.EmbalagemEstoquePreco;
            }



            


            //Image _Image = _ImageVermelho;
            //if (item.Margem <= 0) _Image = _ImageVermelho;
            //if (item.Margem > 0) _Image = _ImageAzul;
            //DG[8, item.IndexLocal].Value = _Image;
            // if (DG.Name.ToUpper() == "DGLISTA" && click)
            // {
            //     BLL.Embalagens(Convert.ToInt32(DGLista[0, item.IndexLocal].Value));
            //     fill(DGListaEmbalagem, BLL.SelectEmbalagensList);
            // }
        }
        private void DGListaCellSelection(DataGridView DG, int RowIndex, int ColumnIndex)
        {

            try
            {
                
                int SeqLocalSelecionado = Convert.ToInt32(((DataGridView)DG)[10, RowIndex].Value.ToString());

                LBLEMBALAGEMVENDA.Text = "";
                //TXTEmbalagemVisualiza.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Embalagem.ToString();
                LBLPrecoAlteradoEmbalagemVisualizacao.Text = "";
                LBLPrecoEmbalagemVisualizacao.Text = "";
                LBLMargemEmbalagemVisualizacao.Text = "";
                LBLMargemAlteradaEmbalagemVisualizacao.Text = "";
                LBLESTOQUEEMBALAGEM.Text = "";
                LBLFatorEstoqueEmbalagem.Text = "";
                LBLCustoEmbalagemVisualiza.Text = "";


                if (DG.Name == "DGLista")
                {
                    BLL.SelectItem = BLL.SelectProdutoList[SeqLocalSelecionado];
                    BLL.Embalagens(Convert.ToInt32(DGLista[0, RowIndex].Value));
                    fill(DGListaEmbalagem, BLL.SelectEmbalagensList);
                    LBLCodigoProdutoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].CdProduto.ToString();
                    LBLPRODUTOSELECIONADO.Text = BLL.SelectProdutoList[SeqLocalSelecionado].Descricao.ToString();
                    
                    // TXTEmbalagemProdutoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].EmbalagemEstoque.ToString();


                     LBLEMBALAGEMESTOQUE.Text = BLL.SelectProdutoList[SeqLocalSelecionado].EmbalagemEstoque.ToString();

                    if (LBLEMBALAGEMESTOQUE.Text.Trim() == "KG")
                    {
                        CHKManterPrecoEmbalagem.Checked = true;
                    }
                    else
                    {
                        CHKManterPrecoEmbalagem.Checked = false;
                    }

                    
                    LBLPrecoAnteriorVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorPreco.ToString("0.00");
                    LBLMargemAnteriorVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].Margem.ToString("0.00");
                    LBLPrecoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorPrecoAlterado.ToString("0.00");
                    //TXTPrecoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorPrecoAlterado.ToString("0.00");
                    LBLCustoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorCusto.ToString("0.00");
                    LBLMargemVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].MargemAlterada.ToString("0.00");
                    // lblSEQ_SELECIONADO.Text = SeqLocalSelecionado.ToString();
                    LBLFatorEstoque.Text = BLL.SelectProdutoList[SeqLocalSelecionado].FatorEstoque.ToString("0.00");
                    LBLESTOQUE.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorEstoque.ToString("0.00");
                    if (BLL.SelectProdutoList[SeqLocalSelecionado].ValorPrecoAlterado != BLL.SelectProdutoList[SeqLocalSelecionado].ValorPreco)
                    {
                        LBLPrecoVisualiza.ForeColor = Color.Red;
                    }
                    else
                    {
                        LBLPrecoVisualiza.ForeColor = Color.Black;
                    }
                }

                else
                {
                    LBLESTOQUEEMBALAGEM.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorEstoque.ToString("0.00");
                    LBLEMBALAGEMVENDA.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Embalagem; // + " " + BLL.SelectEmbalagensList[SeqLocalSelecionado].Embalagem + "/" + BLL.SelectEmbalagensList[SeqLocalSelecionado].FatorEstoque.ToString();
                    LBLCustoEmbalagemVisualiza.Text =  BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorCusto.ToString("0.00");
                    LBLFatorEstoqueEmbalagem.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].FatorEstoque.ToString("0.00");
                    //TXTEmbalagemVisualiza.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Embalagem.ToString();
                    LBLPrecoAlteradoEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPrecoAlterado.ToString("0.00");
                    LBLPrecoEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPreco.ToString("0.00");
                    //BLL.SelectEmbalagensList[SeqLocalSelecionado].EmbalagemEstoqueQtde ELIAS
                    LBLMargemEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Margem.ToString("0.00");
                    LBLMargemAlteradaEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].MargemAlterada.ToString("0.00");
                    if (BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPrecoAlterado != BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPreco)
                    {
                        LBLPrecoAlteradoEmbalagemVisualizacao.ForeColor = Color.Red;
                    }
                    else
                    {
                        LBLPrecoAlteradoEmbalagemVisualizacao.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Sem Registros");
            }

        }
       
        
        //Events List
        private void DGLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // DGListaEdit((DataGridView)sender, e.RowIndex, e.ColumnIndex);
            //return;

            int SeqLocalSelecionado = Convert.ToInt32(((DataGridView)sender)[10, e.RowIndex].Value.ToString());
            try
            {
                if (ValoremEdicao != Convert.ToDouble(((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value))
                {
                    VWProdutoOperacaoPreco item;
                    if (((DataGridView)sender).Name.ToUpper() == "DGLISTA")
                    {
                        item = BLL.SelectProdutoList[SeqLocalSelecionado];
                    }
                    else
                    {
                        item = BLL.SelectEmbalagensList[SeqLocalSelecionado];
                    }

                    if (e.ColumnIndex == 3)
                    {
                        BLL.AlterarProduto(item, Convert.ToDouble(((DataGridView)sender)[3, e.RowIndex].Value), 0, CHKManterPrecoEmbalagem.Checked);
                    }

                    if (e.ColumnIndex == 6 )
                    {
                        BLL.AlterarProduto(item, 0, Convert.ToDouble(((DataGridView)sender)[6, e.RowIndex].Value), CHKManterPrecoEmbalagem.Checked, Convert.ToDouble(((DataGridView)sender)[14, e.RowIndex].Value));
                    }

                    if (e.ColumnIndex == 14)
                    {
                        if (item.EmbalagemEstoque != "UN")
                        {
                            DGListaEmbalagem[14, e.RowIndex].Value = 0;
                            MessageBox.Show("Quantidade promocional aplicável apenas a produtos com embalagem de estoque do tipo UNIDADE");
                            return;
                        }
                        if (Math.Round(Convert.ToDouble(DGListaEmbalagem[14, e.RowIndex].Value), 0) == 1)
                        {
                            DGListaEmbalagem[14, e.RowIndex].Value = item.QtdePromocional;
                            MessageBox.Show("Quantidade promocional deve ser diferente de 1");
                            return;
                        }
                        if (Math.Round(Convert.ToDouble(DGListaEmbalagem[14, e.RowIndex].Value), 0) >= item.FatorEstoque)
                        {
                            DGListaEmbalagem[14, e.RowIndex].Value = item.QtdePromocional;
                            MessageBox.Show("Quantidade promocional deve ser diferente da quantidade da Embalagem de venda: " + item.FatorEstoque.ToString());
                            return;
                        }


                        BLL.AlterarProduto(item, 0, 0, CHKManterPrecoEmbalagem.Checked, Convert.ToDouble(((DataGridView)sender)[14, e.RowIndex].Value));
                    }

                    if (e.ColumnIndex == 15)
                    {
           

                        double cValorDescontoAplicado = Convert.ToDouble(DGListaEmbalagem[15, e.RowIndex].Value);
                        double cValorPrecoEmbalagemEstoque = item.EmbalagemEstoquePrecoAlterado;
                        double cValorFatorEstoque = item.FatorEstoque;
                        double cValorFatorPrecoAnterior = item.FatorPreco;
                        if (cValorDescontoAplicado > 99)
                        {
                            DGListaEmbalagem[15, e.RowIndex].Value = Convert.ToDouble((1 - cValorFatorPrecoAnterior) * 100);
                            MessageBox.Show("Desconto Inválido!");
                            return;
                        }
                        if (cValorFatorEstoque < 2)
                        {
                            DGListaEmbalagem[15, e.RowIndex].Value = Convert.ToDouble((1 - cValorFatorPrecoAnterior) * 100);
                            MessageBox.Show("Não é permito a aplicação de Desconto em Embalagem igual a Embalagem de Estoque, ou seja sem quantidade unitária!");
                            return;
                        }
                        if (cValorDescontoAplicado < 0)
                        {
                            DGListaEmbalagem[15, e.RowIndex].Value = Convert.ToDouble((1 - cValorFatorPrecoAnterior) * 100);
                            MessageBox.Show("Para efetuar o aumento de preços, favor alterar diretamente a coluna de preços aplicando o novo valor.");
                            return;
                        }
                        if (cValorDescontoAplicado > 0)
                        {
                            double ValorPrecoEmbalagemNew = Math.Round( ((1 - (cValorDescontoAplicado / 100)) * cValorPrecoEmbalagemEstoque) * cValorFatorEstoque,2);
                            BLL.AlterarProduto(item, ValorPrecoEmbalagemNew, 0, CHKManterPrecoEmbalagem.Checked);
                        }


                        if (cValorDescontoAplicado == 0)
                        {
                            double ValorPrecoEmbalagemNew = Math.Round(cValorPrecoEmbalagemEstoque * cValorFatorEstoque, 2);
                            BLL.AlterarProduto(item, ValorPrecoEmbalagemNew, 0, CHKManterPrecoEmbalagem.Checked);
                        }


                    }

                    if (((DataGridView)sender).Name.ToUpper() == "DGLISTA")
                    {
                        DGListaFill(((DataGridView)sender), BLL.SelectProdutoList[SeqLocalSelecionado], e.RowIndex);
                    }
                    else
                    {
                        DGListaFill(((DataGridView)sender), BLL.SelectEmbalagensList[SeqLocalSelecionado], e.RowIndex);
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Valor inválido!");
                ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = ValoremEdicao;
                ((DataGridView)sender).CancelEdit();
            }

        }
        private void DGLista_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            DGListaCellSelection((DataGridView)sender, e.Cell.RowIndex, e.Cell.ColumnIndex);
            
            /*
            try
            {
                int SeqLocalSelecionado = Convert.ToInt32(((DataGridView)sender)[10, e.Cell.RowIndex].Value.ToString());

                if (((DataGridView)sender).Name == "DGLista")
                {
                    BLL.SelectItem = BLL.SelectProdutoList[SeqLocalSelecionado];
                    BLL.Embalagens(Convert.ToInt32(DGLista[0, e.Cell.RowIndex].Value));
                    fill(DGListaEmbalagem, BLL.SelectEmbalagensList);
                    TXTCodigoProdutoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].CdProduto.ToString();
                    TXTDescricaoProdutoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].Descricao.ToString();
                    TXTEmbalagemProdutoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].EmbalagemEstoque.ToString();
                    TXTPrecoAnteriorVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorPreco.ToString("0.00");
                    TXTMargemAnteriorVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].Margem.ToString("0.00");
                    TXTPrecoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorPrecoAlterado.ToString("0.00");
                    TXTCustoVisualiza.Text = BLL.SelectProdutoList[SeqLocalSelecionado].ValorCusto.ToString("0.00");
                }

                else
                {
                    TXTEmbalagemVisualiza.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Embalagem.ToString();
                    TXTPrecoAlteradoEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPrecoAlterado.ToString("0.00");
                    TXTPrecoEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].ValorPreco.ToString("0.00");
                    TXTMargemEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].Margem.ToString("0.00");
                    TXTMargemAlteradaEmbalagemVisualizacao.Text = BLL.SelectEmbalagensList[SeqLocalSelecionado].MargemAlterada.ToString("0.00");
                }
            }
            catch 
            {
                //MessageBox.Show("Sem Registros");
            }*/
        }
        private void DGLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ValoremEdicao = Convert.ToDouble( ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value);
            // TXTTESTE.Text = BLL.ListAll[e.RowIndex].FatorPrecoAlterado.ToString() + "-" + BLL.ListAll[e.RowIndex].FatorPreco.ToString();
        }
        private void DGLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex > -1 && e.ColumnIndex == 7)
            //{
            //    if (Convert.ToDouble(DGLista[6, e.RowIndex].Value) < 0)
            //    {
            //        e.Value = Image.FromFile(@"C:\Ti\TempPag\LegendaVermelho.gif");
            //    }
            //}
        }

        private void DGLista_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //DGListaEdit((DataGridView)sender, e.RowIndex, e.ColumnIndex);
        }
        private void DGLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //ComboBox
        private void CMBDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (Convert.ToString(CMBDepartamento.SelectedValue) != "" && CMBDepartamento.SelectedValue != null)
            //{
            //    BLL.CdProdutoDepartamento = ((Pag_Net.Bll.Cadastros.Departamento)CMBDepartamento.SelectedItem).CdProdutoDepartamento;
           // }
           // else
           // {
           //     BLL.CdProdutoDepartamento = "";
           // }
           // Filtrar();
        }
        private void CMBSecao_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (Convert.ToString(CMBSecao.SelectedValue) != "" && CMBSecao.SelectedValue != null)
           // {
           //     BLL.CdProdutoSecao = ((Pag_Net.Bll.Cadastros.Secao)CMBSecao.SelectedItem).CdProdutoSecao;
           // }
           // else
           // {
           //     BLL.CdProdutoSecao = "";
           // }
           // Filtrar();
        }
        private void CMBLinha_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (Convert.ToString(CMBLinha.SelectedValue) != "" && CMBLinha.SelectedValue != null)
           // {
           //     BLL.CdProdutoLinha = ((Pag_Net.Bll.Cadastros.Linha)CMBLinha.SelectedItem).CdProdutoLinha;
           // }
           // else
           // {
           //     BLL.CdProdutoLinha = "";
           // }
           // Filtrar();
        }
        private void CMBFabricante_SelectedValueChanged(object sender, EventArgs e)
        {
            BLL.CdFabricante = "";
        }
        private void CMBFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BLL.CdFabricante = "";
            //if (Convert.ToString(CMBFabricante.SelectedValue) != "" && CMBFabricante.SelectedValue != null)
           // {
            //    BLL.CdFabricante = ((Pag_Net.Bll.Cadastros.UVWFabricante)CMBFabricante.SelectedItem).CdFabricante;
            //}
            //Filtrar();
        }
        private void CMDBuscaPrecosAlterados_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DGListAlterados.Rows.Clear();
            int linha = 0;
            foreach (VWProdutoOperacaoPreco item in BLL.Alterados())
            {
                DGListAlterados.Rows.Add();
                DGListaFill(DGListAlterados, item, linha);
                linha = linha + 1;
            }
            Cursor = Cursors.Arrow;
        }
        
        //Texts
        private void TXTDescricaoProduto_TextChanged(object sender, EventArgs e)
        {
            BLL.Descricao = "";
            BLL.Descricao = TXTDescricaoProduto.Text.TrimEnd().TrimStart().ToUpper();
            Filtrar();
        }
        private void TXTCodigoProduto_TextChanged(object sender, EventArgs e)
        {
            BLL.CdProduto = 0;
            try
            {
                if (TXTCodigoProduto.Text != "")
                {
                    BLL.CdProduto = Convert.ToInt32(TXTCodigoProduto.Text);
                }
                Filtrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        //Button commands
        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int cdOperacao = 2;// ((Pag_Net.Models.ModelTbOperacoes)CMBOperacoes.SelectedItem).CdOperacao;
                BLL.Aplicacao(this.DataAplicacao, cdOperacao);
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Preços aplicados com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }
        private void CMDBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BLL.Produtos();
            fill(DGLista, BLL.SelectProdutoList);
            LBLQtdeItens.Text = BLL.SelectProdutoList.Count().ToString();
            Cursor.Current = Cursors.Default;
        }

        private void DGLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }


        }

        private void CHKManterPrecoEmbalagem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            CMDBuscaPrecosAlterados_Click(null, null);
        }

        private void OperacaoPrecoAplicacao_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (Pag_Net.Bll.Operacionais.Produto.VWProdutoOperacaoPreco item in BLL.ListAll)
                {
                    if (item.AplicacaoPendente == false)
                    {
                        BLL.ListAll[item.Index].FatorPrecoAlterado = BLL.ListAll[item.Index].FatorPreco;
                        BLL.ListAll[item.Index].EmbalagemEstoquePrecoAlterado = BLL.ListAll[item.Index].EmbalagemEstoquePreco;
                    }
                }
                BLL.Filtrar();
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void DGLista_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        




    }
}
