using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Pag_Net.Bll;
using System.IO;

namespace Pag_Wpf.Financeiro.CartaoCredito
{
    public partial class InterfaceImportacaoArquivo : Form
    {
        public Pag_Net.Bll.Financeiro.CartaoCredito.InterfaceImportacaoArquivo BLL;
        public InterfaceImportacaoArquivo( modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            
            BLL = new Pag_Net.Bll.Financeiro.CartaoCredito.InterfaceImportacaoArquivo(_myConnect);
            BLL.PropertyChanged += new PropertyChangedEventHandler(LogProcessamentoOn);
        }

        private void CmdExplorer_Click(object sender, EventArgs e)
        {
            dtArquivos.Rows.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            List<string> Arquivos = new List<string>();
            Arquivos = openFileDialog1.FileNames.ToList();

            if (Arquivos.Count < 1) 
            {
                MessageBox.Show("Selecione ao menos um arquivo!");
                return;
            }
            foreach (string i in Arquivos)
            {
                dtArquivos.Rows.Add(i);
            }

        }
        private void cmdEfetiva_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (DataGridViewRow i in dtArquivos.Rows)
                {

                    BLL.ArquivoSitefInterface = i.Cells["Arquivo"].Value.ToString();
                    BLL.Processa();
                    i.Cells["Interface"].Value = BLL.Interface;
                }

                LogProcessamentoOn(null, null);
                MessageBox.Show("Arquivo Processado com Sucesso", "Pag - CC Interface - Importação");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                LogProcessamentoOn(null,null);
            }
            Cursor.Current = Cursors.Default;
            
        }

        //private void txtArquivoImportacao_TextChanged(object sender, EventArgs e)
        //{
            //BLL.ArquivoSitefInterface = txtArquivoImportacao.Text;
        //}

        private void LogProcessamentoOn(object sender, PropertyChangedEventArgs e)
        {

            DataGridLogProcessamento.Rows.Clear();
            foreach (string i in BLL.ProcessamentoLog)
            {
                DataGridLogProcessamento.Rows.Add(i.ToString());
            }
        }

        private void dtArquivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridLogProcessamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
