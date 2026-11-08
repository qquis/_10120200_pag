using Pag_Net.Bll.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Forms
{
    public partial class FRMxProdutoCustos : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        DataTable TbBlueSoftEstoqueCusto;
        DataTable TbBlueSoftEntrada;
        Pag_Net.Tools.ManagerFileInfo ArquivoDeEstoque;
        Pag_Net.Tools.ManagerFileInfo ArquivoDeEntrada;
        Pag_Net.Tools.ManagerFile _ManagerFile = new Pag_Net.Tools.ManagerFile();

        int _LINHA_INICIAL_ESTOQUE = 0;
        int _LINHA_INICIAL_ENTRADA = 0;

        public FRMxProdutoCustos(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            TbBlueSoftEstoqueCusto = new DataTable();
            TbBlueSoftEntrada = new DataTable();
            chkPostgre_CustosDiferentes.Checked = false;
            chkPostgre_DataCusto_Seleciona.Checked = false;
            DtpPostgre_data_atualizacao.Enabled = false;
            DtpPostgre_data_atualizacao.Value = DateTime.Now;

            dtgProdutoCustoImporta.ReadOnly = true;

            dtgProdutoCusto.ReadOnly = true;
            dtgProdutoCustoImporta.ReadOnly = true;
            
            dtgProdutoCusto.AutoGenerateColumns = false;
            dtgProdutoCusto.ReadOnly = true;
            dtpConsultaDataInicial.Enabled = false;
            dtpConsultaDataFinal.Enabled = false;


            dtgProdutoCustoImporta.AutoGenerateColumns = false;
            dtgProdutoCustoImporta.ReadOnly = true;

            dtgProdutoEntradaImportacao.AutoGenerateColumns = false;
            dtgProdutoEntradaImportacao.ReadOnly = true;


            //dtg_custo_online.AutoGenerateColumns = false; 



            //TxtArquivoEstoqueLinhaInicialValida.Text = "25";
            //TxtArquivoEntradaLinhaInicialValida.Text = "7";
            txtresultadoAplicacaoPAG.Text = "";
            txtresultadoAplicacaoTGT.Text = "";
            
        }

        private void chkdataconsultainicial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdataconsultainicial.Checked)
            {
                dtpConsultaDataInicial.Enabled = true;
            }
            else
            {
                dtpConsultaDataInicial.Enabled = false;
            }

        }

        private void chkdataconsultafinal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdataconsultafinal.Checked)
            {
                dtpConsultaDataFinal.Enabled = true;
            }
            else
            {
                dtpConsultaDataFinal.Enabled = false;
            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                cmdBuscar.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                dtgProdutoCusto_FILL(false);
                cmdBuscar.Enabled = true;
                this.Cursor = Cursors.Default; 
            }
            catch (Exception ex)
            {
                cmdBuscar.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }

        private void dtgProdutoCusto_FILL(bool MargemNegativa)
        {

            try
            {
                Pag_Net.Bll.ProdutoEstoqueCusto.List List = new Pag_Net.Bll.ProdutoEstoqueCusto.List(MyConnect);

                int cdProdutoPag = 0;
                int cdProdutoBlueSoft = 0;
                int cdProdutoTarget = 0;
                string strBusca = txtDescricao.Text;

                if (txtCodPag.Text.Trim() != "")
                {
                    cdProdutoPag = Convert.ToInt32(txtCodPag.Text);
                }

                if (txtCodBlue.Text.Trim() != "")
                {
                    cdProdutoBlueSoft = Convert.ToInt32(txtCodBlue.Text);
                }

                if (txtCodTarget.Text.Trim() != "")
                {
                    cdProdutoTarget = Convert.ToInt32(txtCodTarget.Text);
                }


                DataTable dt = List.start(chkdataconsultainicial.Checked, dtpConsultaDataInicial.Value, chkdataconsultafinal.Checked, dtpConsultaDataFinal.Value, MargemNegativa, strBusca, cdProdutoPag, cdProdutoBlueSoft, cdProdutoTarget);
                //dtgProdutoCusto.DataSource = List.start();
                dtgProdutoCusto.Rows.Clear();
                int ilinha = 0;
                foreach (DataRow item in dt.Rows)
                {

                    dtgProdutoCusto.Rows.Add();
                    dtgProdutoCusto["CdProduto", ilinha].Value = item["CdProduto"];
                    dtgProdutoCusto["CdProdutoBlueSoft", ilinha].Value = item["CdProdutoBlueSoft"];
                    dtgProdutoCusto["Descricao", ilinha].Value = item["Descricao"];
                    dtgProdutoCusto["EmbalagemEstoque", ilinha].Value = item["EmbalagemEstoque"];
                    dtgProdutoCusto["DataAtualizacao", ilinha].Value = Convert.ToDateTime(item["DataAtualizacao"]);
                    dtgProdutoCusto["ValorCustoPadrao", ilinha].Value = Convert.ToDouble(item["ValorCustoPadrao"]);
                    dtgProdutoCusto["ValorCustoPadraoAtual", ilinha].Value = Convert.ToDouble(item["ValorCustoPadraoAtual"]);
                    dtgProdutoCusto["ValorCustoBrtUnitComercial", ilinha].Value = item["ValorCustoBrtUnitComercial"];
                    dtgProdutoCusto["ValorPreco", ilinha].Value = item["ValorPreco"];
                    dtgProdutoCusto["EmbalagemEstoqueQtde", ilinha].Value = item["EmbalagemEstoqueQtde"];

                    double MargemMedia = 0;
                    double Preco = Convert.ToDouble(item["ValorPreco"].ToString());
                    double CustoBrutoMedio = Convert.ToDouble(item["ValorCustoPadrao"].ToString());
                    if (Preco > 0)
                    {
                        MargemMedia = Math.Round((Preco - CustoBrutoMedio) / Preco * 100, 2);
                    }
                    dtgProdutoCusto["MgM", ilinha].Value = MargemMedia;
                    if (MargemMedia < 0)
                    {
                        dtgProdutoCusto.Rows[ilinha].DefaultCellStyle.BackColor = Color.Red;
                    }
                    ilinha = ilinha + 1;
                }
                txtProdutoCustoNumeroLinhas.Text = ilinha.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
        private void cmdBuscarMgNegativa_Click(object sender, EventArgs e)
        {

            try
            {
                cmdBuscarMgNegativa.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                dtgProdutoCusto_FILL(true);
                cmdBuscarMgNegativa.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                cmdBuscarMgNegativa.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdSelecionaArquivoEstoque_Click(object sender, EventArgs e)
        {
            ClearDados("ESTOQUE");
            ClearDados("ENTRADA");
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                TxtArquivoEstoque.Text = openFileDialog1.FileName.ToString();
                if (!File.Exists(TxtArquivoEstoque.Text))
                {
                    TxtArquivoEstoque.Text = "";
                    MessageBox.Show("Arquivo de Estoque não encontrado");
                }
            }
            this.Cursor = Cursors.Default;

        }

        private void cmdSelecionaArquivoEntrada_Click(object sender, EventArgs e)
        {

            try
            {

                ClearDados("ENTRADA");
                
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName.ToString() != "")
                {
                    TxtArquivoEntrada.Text = openFileDialog1.FileName.ToString();
                }
            }

            catch( Exception ex )
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdValidaArquivoEstoque_Click(object sender, EventArgs e)
        {
            try
            {

                //_LINHA_INICIAL_ESTOQUE = Convert.ToInt16(TxtArquivoEstoqueLinhaInicialValida.Text);

                this.Cursor = Cursors.WaitCursor;
                Pag_Net.Bll.Container.Importacao_Arquivo_Estoque obj = new Pag_Net.Bll.Container.Importacao_Arquivo_Estoque();

                try
                {
                    obj.LinhaInicial = Convert.ToInt32(TxtArquivoEstoqueLinhaInicialValida.Text);
                }
                catch
                {
                    MessageBox.Show("VALOR DA LINHA inicial do arquivo de ESTOQUE inválido ou não indicado!. O Valor será definido como 1");
                    obj.LinhaInicial = 1;
                    TxtArquivoEstoqueLinhaInicialValida.Text = "1";
                }



                
                TbBlueSoftEstoqueCusto = obj.Import(@TxtArquivoEstoque.Text);

                if (TbBlueSoftEstoqueCusto.Rows.Count > 0)
                {
                    ArquivoDeEstoque = obj.ArquivoDeEstoque;
                    dtgProdutoCustoImporta.DataSource = TbBlueSoftEstoqueCusto;
                    TXTEstoqueLinhasProcessadas.Text = obj.LinhasProcessadas.ToString();
                    TXTEstoqueLinhasNaoValidadas.Text = obj.LinhasNaoValidada.ToString();
                    TXTEstoqueLogResult.Text = string.Join("\r", obj._logResult);
                } 
                this.Cursor = Cursors.Default;
                
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdValidaArquivoEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Pag_Net.Bll.Container.Importacao_Arquivo_Entrada obj = new Pag_Net.Bll.Container.Importacao_Arquivo_Entrada();
                try
                {
                    obj.LinhaInicial = Convert.ToInt32(TxtArquivoEntradaLinhaInicialValida.Text);
                }
                catch
                {
                    MessageBox.Show("VALOR DA LINHA inicial do arquivo de ENTRADA inválido ou não indicado!. O Valor será definido como 1");
                    obj.LinhaInicial = 1;
                    TxtArquivoEntradaLinhaInicialValida.Text = "1";
                }
                TbBlueSoftEntrada = obj.Import(@TxtArquivoEntrada.Text);
                if (TbBlueSoftEntrada.Rows.Count > 0)
                {
                    ArquivoDeEntrada = obj.ArquivoDeEntrada;
                    dtgProdutoEntradaImportacao.DataSource = TbBlueSoftEntrada;
                    TXTEntradaLinhasProcessadas.Text = obj.LinhasProcessadas.ToString();
                    TXTEntradaLinhasNaoValidadas.Text = obj.LinhasNaoValidada.ToString();
                    TXTEntradaLogResult.Text = string.Join("\r", obj._logResult);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void ClearDados(string TipoArquivo)
        {
            if (TipoArquivo == "ESTOQUE")
            {
                TxtArquivoEstoque.Text = "";
                TbBlueSoftEstoqueCusto.Rows.Clear();
            }

            if (TipoArquivo == "ENTRADA")
            {
                TxtArquivoEntrada.Text = "";
                TbBlueSoftEntrada.Rows.Clear();
            }

        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            try
            {
                txtresultadoAplicacaoArqEstoque.Text = "";
                txtresultadoAplicacaoArqEntrada.Text = "";
                txtresultadoAplicacaoArqAjustes.Text = "";

                if (TxtArquivoEstoque.Text.Trim() == "")
                {
                    MessageBox.Show("Informar o arquivo de ESTOQUE");
                }
                else
                {
                    if (TbBlueSoftEstoqueCusto.Rows.Count < 1)
                    {
                        MessageBox.Show("Não há dados importados na tabela de Estoque. Informe o arquivo e clique em <Processar Arquivo>");
                        return;
                    }


                    cmdImportar.Enabled = false;
                    if (MessageBox.Show("Confirma importação do arquivo?", "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Refresh();
                        txtresultadoAplicacaoArqEstoque.Text = "..";
                        this.Refresh();

                        /*Arquivo de Estoque*/
                        int SeqArquivoEstoque = Pag_Net.Bll.Services.PagServiceImportarArquivos.Processar(MyConnect, ArquivoDeEstoque, false);
                        Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Estoque X = new Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Estoque();
                        X.Start(MyConnect, TbBlueSoftEstoqueCusto, SeqArquivoEstoque);
                        txtresultadoAplicacaoArqEstoque.Text = "Ok";
                        this.Refresh();

                        /*Arquivo de Entradas*/
                        this.Refresh();
                        txtresultadoAplicacaoArqEntrada.Text = "..";
                        this.Refresh();

                        if (TbBlueSoftEntrada.Rows.Count > 0)
                        {
                            int SeqArquivoEntrada = Pag_Net.Bll.Services.PagServiceImportarArquivos.Processar(MyConnect, ArquivoDeEntrada, false);
                            Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Entradas Xe = new Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Entradas();
                            Xe.Start(MyConnect, TbBlueSoftEntrada, SeqArquivoEntrada);
                        }
                        
                        this.Refresh();
                        txtresultadoAplicacaoArqEntrada.Text = "Ok";
                        this.Refresh();

                        /*Atualizacoes Gerais*/
                        this.Refresh();
                        txtresultadoAplicacaoArqAjustes.Text = "..";
                        this.Refresh();

                        Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update.Start(MyConnect);
                        
                        this.Refresh();
                        txtresultadoAplicacaoArqAjustes.Text = "Ok";
                        this.Refresh();


                        cmdImportar.Enabled = true;
                        this.Cursor = Cursors.Default;

                        MessageBox.Show("Arquivos Importados com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                cmdImportar.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdValidacaoListagem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cmdValidacaoListagem.Enabled = false;
                dtgListagemValidacao.DataSource = Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Select.List(MyConnect);
                cmdValidacaoListagem.Enabled = true;
                this.Cursor = Cursors.Default ;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }

        private void TxtArquivoEstoqueLinhaInicialValida_Validated(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(TxtArquivoEstoqueLinhaInicialValida.Text);
            }
            catch (Exception x)
            {
                TxtArquivoEstoqueLinhaInicialValida.Text = "25";
                MessageBox.Show("Favor inserir um número válido");
            }
        }

        private void TxtArquivoEntradaLinhaInicialValida_Validated(object sender, EventArgs e)
        {
            try
            {
                int temp = Convert.ToInt32(TxtArquivoEntradaLinhaInicialValida.Text);
            }
            catch (Exception x)
            {
                TxtArquivoEntradaLinhaInicialValida.Text = "7";
                MessageBox.Show("Favor inserir um número válido");
            }
        }

        private void cmdValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbBlueSoftEstoqueCusto.Rows.Count <= 0)
                {
                    MessageBox.Show("Não foi encontrado nenhum arquivo recentemente importado na tela");
                    return;

                }
                cmdValidar.Enabled = false;
                string Msg = "Confirma APLICAÇÃO DOS CUSTOS?" + "\n" +
                            "1. Processo pode demorar algunas minutos. Favor fazer print caso ocorra algum erro." +
                            "2. Este comando não pode ser executado caso as Notas Fiscais emitidas pelo sistema Target já tenha sido expotada para a BLUESOFT " +
                            "3. Faça análises periódicas sobre a eficácia do processo: Consulta Custo/Estoque BlueSoft x Custo/Estoque Target para conferir os valores";
                if (MessageBox.Show(Msg, "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    txtresultadoAplicacaoPAG.Text = "...";
                    this.Cursor = Cursors.WaitCursor;
                    Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Pag.Start(MyConnect);
                    txtresultadoAplicacaoPAG.Text = "OK";
                    txtresultadoAplicacaoTGT.Text = "...";
                    this.Refresh();
                    this.Refresh();
                    this.Refresh();
                    Pag_Net.Bll.BlueSoft.ProdutoEstoqueCusto.Update_Target.Start(MyConnect);
                    txtresultadoAplicacaoTGT.Text = "OK";
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Processo finalizado com sucesso!");
                }
                cmdValidar.Enabled = true;
            }
            catch( Exception ex)
            {
                this.Cursor = Cursors.Default;
                cmdValidar.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdIF0017_Click(object sender, EventArgs e)
        {
            try
            {
                cmdIF0017.Enabled = false;
                if (MessageBox.Show("Confirma envio do relatório IF0017", "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Pag_Net.Bll.IFs.IF0017.Start(MyConnect);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Relatório enviado com sucesso!");
                }
                cmdIF0017.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                cmdIF0017.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdImportaCustoPostGre_Click(object sender, EventArgs e)
        {
            try
            {
                CustoPostGre_Select();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAtualizarBase_Postgre_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, "PSQ06", 19);
                Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, "PSQ07", 20);
                CustoPostGre_Select();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void CustoPostGre_Select()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lbl_info_total.Text = "0";
                this.Refresh();
                DataTable DataTableGrid;
                DataTableGrid = Pag_Net.Services.Bll.TEMP.SqlServer.Select_ProdutoCusto(MyConnect, chkPostgre_DataCusto_Seleciona.Checked, chkPostgre_CustosDiferentes.Checked , DtpPostgre_data_atualizacao.Value);
                dtg_custo_online.DataSource = DataTableGrid;
                lbl_info_total.Text = DataTableGrid.Rows.Count.ToString();

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void chkPostgre_DataCusto_Seleciona_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPostgre_DataCusto_Seleciona.Checked)
            {
                DtpPostgre_data_atualizacao.Enabled = true;
            }
            else
            {
                DtpPostgre_data_atualizacao.Enabled = false;
            }
        }

        private void cmdAplicar_Custos_Postgre_API_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Confirma a atualização dos dados de Custos conforme informações da API/BLUESOFT", "PAG", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Pag_Net.Services.Bll.TEMP.SqlServer.ProdutoCustoAtualiza(MyConnect);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Informações Atualizadas com sucesso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message, "Erro no processamento do custo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


/*
        private void ProcessarArquivos()
        {
            string strError = "";

            try
            {

                if (!File.Exists(TxtArquivoEstoque.Text))
                {
                    MessageBox.Show("Arquivo de Estoque Não encontrado. Processamento cancelado!");
                    return;
                    
                }



                _LINHA_INICIAL_ESTOQUE = Convert.ToInt16(TxtArquivoEstoqueLinhaInicialValida.Text);
                _LINHA_INICIAL_ENTRADA = Convert.ToInt16(TxtArquivoEntradaLinhaInicialValida.Text);

                if (_LINHA_INICIAL_ENTRADA == 0 || _LINHA_INICIAL_ESTOQUE == 0)
                {
                    MessageBox.Show("Favor confirmar linha inicial do(s) arquivo(s)");
                    return; 
                }


                DataColumn column;
                TbBlueSoftEstoqueCusto = new DataTable();
                TbBlueSoftEntrada = new DataTable();

                //TbBlueSoftEstoqueCusto.Columns.Clear();
                //TbBlueSoftEstoqueCusto.Rows.Clear();
                //TbBlueSoftEntrada.Columns.Clear();
                //TbBlueSoftEntrada.Rows.Clear();

                //TbBlueSoftEstoqueCusto
                column = new DataColumn("NumeroLinha", System.Type.GetType("System.Int32")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("CdProdutoBlueSoft", System.Type.GetType("System.Int32")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("DescricaoImportacao", System.Type.GetType("System.String")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("CodigoBarra", System.Type.GetType("System.String")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("Fornecedor", System.Type.GetType("System.String")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("EmbalagemEstoqueQtde", System.Type.GetType("System.Double")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("ValorCustoBruto", System.Type.GetType("System.Double")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                column = new DataColumn("ValorCustoLiquido", System.Type.GetType("System.Double")); TbBlueSoftEstoqueCusto.Columns.Add(column);
                

                //TbBlueSoftEntrada
                column = new DataColumn("NumeroLinha", System.Type.GetType("System.Int32")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("CdProdutoBlueSoft", System.Type.GetType("System.Int32")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("DescricaoImportacao", System.Type.GetType("System.String")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("CFOP", System.Type.GetType("System.String")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("CodigoBarra", System.Type.GetType("System.String")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("NumeroDocumentoFiscal", System.Type.GetType("System.Int32")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("EmbalagemEstoqueQtde", System.Type.GetType("System.Double")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("ValorCustoBruto", System.Type.GetType("System.Double")); TbBlueSoftEntrada.Columns.Add(column);
                column = new DataColumn("ValorCustoLiquido", System.Type.GetType("System.Double")); TbBlueSoftEntrada.Columns.Add(column);

               
                


                
                if (File.Exists(TxtArquivoEstoque.Text))
                {
                    int linha = 0;
                    foreach (DataRow DataRowLinha in (_ManagerFile.View(ArquivoDeEstoque)).Rows)
                    {
                        if (linha >= _LINHA_INICIAL_ESTOQUE && DataRowLinha[1].ToString().Trim() != "")
                        {
                            DataRow TbBlueRow = TbBlueSoftEstoqueCusto.NewRow();
                            TbBlueRow["CdProdutoBlueSoft"] = DataRowLinha[1];
                            TbBlueRow["DescricaoImportacao"] = DataRowLinha[0];
                            TbBlueRow["CodigoBarra"] = DataRowLinha[2];
                            TbBlueRow["Fornecedor"] = DataRowLinha[3];
                            TbBlueRow["EmbalagemEstoqueQtde"] = DataRowLinha[5];
                            TbBlueRow["ValorCustoBruto"] = DataRowLinha[6];
                            TbBlueRow["ValorCustoLiquido"] = DataRowLinha[7];
                            TbBlueRow["NumeroLinha"] = linha;
                            TbBlueSoftEstoqueCusto.Rows.Add(TbBlueRow);
                        }
                        linha = linha + 1;
                    }

                    //dtgProdutoCustoImporta.DataSource = _ManagerFile.View(ArquivoDeEstoque);
                    dtgProdutoCustoImporta.DataSource = TbBlueSoftEstoqueCusto;
                }
                else
                {
                    MessageBox.Show("Arquivo de Estoque Não encontrado. Processamento cancelado!");
                    return;

                }

                if (File.Exists(TxtArquivoEntrada.Text))
                {
                    

                    int linha = 0;
                    foreach (DataRow DataRowLinha in (_ManagerFile.View(ArquivoDeEntrada)).Rows)
                    {
                        if (linha >= _LINHA_INICIAL_ENTRADA && DataRowLinha[1].ToString().Trim() != "")
                        {
                            DataRow TbBlueRow = TbBlueSoftEntrada.NewRow();
                            TbBlueRow["CdProdutoBlueSoft"] = DataRowLinha[4];
                            TbBlueRow["DescricaoImportacao"] = DataRowLinha[5];
                            TbBlueRow["CFOP"] = DataRowLinha[17].ToString().Replace(".","");
                            TbBlueRow["CodigoBarra"] = string.Format(DataRowLinha[3].ToString(), "00000000000000");
                            TbBlueRow["NumeroDocumentoFiscal"] = DataRowLinha[2];
                            TbBlueRow["EmbalagemEstoqueQtde"] = DataRowLinha[6];
                            TbBlueRow["ValorCustoBruto"] = DataRowLinha[7];
                            TbBlueRow["ValorCustoLiquido"] = DataRowLinha[8];
                            TbBlueRow["NumeroLinha"] = linha;
                            TbBlueSoftEntrada.Rows.Add(TbBlueRow);
                        }
                        linha = linha + 1;
                    }
                    txtArquivoEntradaNumerodeProdutos.Text = TbBlueSoftEntrada.Rows.Count.ToString();
                    //dtgProdutoCustoImporta.DataSource = _ManagerFile.View(ArquivoDeEstoque);
                    dtgProdutoEntradaImportacao.DataSource = TbBlueSoftEntrada;
                }
                else
                {
                    MessageBox.Show("Arquivo de Entrada Não encontrado");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(strError + ex.Message);
            }
        }

 
 
 
      private void cmdProcessarArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cmdProcessarArquivos.Enabled = false;
                ProcessarArquivos();
                cmdProcessarArquivos.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch(Exception ex)
            {
                cmdProcessarArquivos.Enabled = true; 
                MessageBox.Show(ex.Message);
            }
        }

 
 
 
 
 
 
 */