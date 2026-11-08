using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class Frm_EstoqueCusto_Importacao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Frm_EstoqueCusto_Importacao(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void cmdArquivoEntradaImportar_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName.ToString() != "")
                {
                    TxtArquivoEntrada.Text = openFileDialog1.FileName.ToString();
                }
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
                _Screen_wait(cmdimportar, true);
                Pag_Net.Bll.EstoqueCusto.ArquivoEntrada.Importar(MyConnect, TxtArquivoEntrada.Text);
                _binding_dtgProcessoArquivo();
                _binding_dtgArquivoDeEntrada();

                _Screen_wait(cmdimportar, false);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
            cmdprocessar_custos_validados.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            cmdArquivoEntradaImportar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\open.ico");
            cmdimportar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\baixo.ico");
            cmdConsultarLinhasArquivos.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\detalhe.ico");
            
            dtgProcessoArquivo.AutoGenerateColumns = false;
            dtgArquivoDeEntrada.AutoGenerateColumns = false;
            
            //cmdDetalheEmbalagem.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\detalhe.ico");
            //cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\ok.ico");
            //cmdDetalhe.Image = Image.FromFile(Pag_Net.Models.PagVersion.GetPathIco + @"\detalhe.ico");

            /* Text Box Format All */

        }
        private void _binding_dtgProcessoArquivo()
        {
            dtgProcessoArquivo.DataSource = Pag_Net.Bll.EstoqueCusto.ArquivoEntrada.List(MyConnect);
            lbl_info_seq_arquivo.DataBindings.Clear();
            lbl_info_seq_arquivo.DataBindings.Add("Text", dtgProcessoArquivo.DataSource, "proc_log_seq");
        }

        private void _binding_dtgArquivoDeEntrada()
        {
            lbl_total_registros.Text = "";
            if (lbl_info_seq_arquivo.Text != "")
            {
                DataTable _DetalheArquivo = Pag_Net.Bll.R0031.Select.get(MyConnect, Convert.ToInt32(lbl_info_seq_arquivo.Text));

                dtgArquivoDeEntrada.DataSource = _DetalheArquivo;
                lbl_total_registros.Text = _DetalheArquivo.Rows.Count.ToString("#,###");
                
                lbl_info_proc_log_arquivo_linha_seq.DataBindings.Clear();
                lbl_info_eci_processamento.DataBindings.Clear();
                lbl_info_eci_prb_cdprodutobluesoft.DataBindings.Clear();
                lbl_info_eci_processamento_erro.DataBindings.Clear();
                lbl_info_proc_log_arquivo_linha.DataBindings.Clear();
                lbl_info_ec_valor_custo_precificacao.DataBindings.Clear();
                lbl_info_pr_cdproduto.DataBindings.Clear();
                lbl_info_eci_valorcustobruto.DataBindings.Clear();
                lbl_info_prb_cdprodutobluesoft_unitario.DataBindings.Clear();
                lbl_info_proc_log_arquivo_linha_ordem.DataBindings.Clear();
                lbl_info_pr_descricao.DataBindings.Clear();
                lbl_info_diferenca.DataBindings.Clear();
                lbl_info_eci_processamento.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "eci_processamento");
                lbl_info_eci_prb_cdprodutobluesoft.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "eci_prb_cdprodutobluesoft");
                lbl_info_eci_processamento_erro.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "eci_processamento_erro");
                lbl_info_proc_log_arquivo_linha.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "proc_log_arquivo_linha");
                //lbl_info_calc_valorcustobruto.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "calc_valorcustobruto");
                lbl_info_pr_cdproduto.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "pr_cdproduto");
                lbl_info_eci_valorcustobruto.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "eci_valorcustobruto");
                lbl_info_prb_cdprodutobluesoft_unitario.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "prb_cdprodutobluesoft_unitario");
                lbl_info_proc_log_arquivo_linha_ordem.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "proc_log_arquivo_linha_ordem");
                lbl_info_pr_descricao.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "pr_descricao");
                lbl_info_proc_log_arquivo_linha_seq.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "proc_log_seq");
                lbl_info_diferenca.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "calc_valorcustobruto");
                lbl_info_ec_valor_custo_precificacao.DataBindings.Add("Text", dtgArquivoDeEntrada.DataSource, "ec_valor_custo_precificacao");
            }

        }
        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {

                if (sender.GetType().Name == "Label")
                {
     
                }

                if (sender.GetType().Name == "TextBox")
                {
             

                }

                if (sender.GetType().Name == "DateTimePicker")
                {
     
                }


                if (sender.GetType().Name == "CheckBox")
                {
  
                }


                if (sender.GetType().Name == "ComboBox")
                {
       
                }
            }

            catch (Exception ErroMessage)
            {
                if (sender.GetType().Name == "TextBox")
                {
                    ((TextBox)sender).Text = "0";
                }
                MessageBox.Show(ErroMessage.Message);
            }
        }
        private void DG_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _binding_dtgProcessoArquivo();
      
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdConsultarLinhasArquivos_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdConsultarLinhasArquivos, true);
                _binding_dtgArquivoDeEntrada();
                _Screen_wait(cmdConsultarLinhasArquivos, false);
            }
            catch (Exception ex )
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void cmdprocessar_custos_validados_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdprocessar_custos_validados, true);
                Pag_Net.Bll.EstoqueCusto.ArquivoEntrada.Processar(MyConnect, Convert.ToInt32(lbl_info_seq_arquivo.Text));
                _binding_dtgProcessoArquivo();
                _binding_dtgArquivoDeEntrada();
                _Screen_wait(cmdprocessar_custos_validados, false);
                MessageBox.Show("Arquivo " + lbl_info_seq_arquivo.Text + " Processado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" * ERRO | Arquivo NÃO processao: " + ex.Message);
            }

        }


    }
}

