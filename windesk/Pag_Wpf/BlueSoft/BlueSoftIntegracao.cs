using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using Pag_Net.Tools;
using Pag_Net.Bll.Services;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
namespace Pag_Wpf.BlueSoft
{
    public partial class BlueSoftIntegracao : Form
    {
        //Excel.Application xlApp = new Excel.Application();
        List<BlueSoftFile> _BlueSoftListFiles;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Tools.ManagerFile _ManagerFile;
         
        List<ManagerFileInfo> _Arquivos;

        public BlueSoftIntegracao(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            _BlueSoftListFiles = new List<BlueSoftFile>();
            MyConnect = _MyConnect;

            _ManagerFile = new Pag_Net.Tools.ManagerFile();

            dtgArquivos.AutoGenerateColumns = true;
            dtgArquivos.MultiSelect = false;
            
            /*dtgArquivos.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            dtgArquivos.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            dtgArquivos.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            dtgArquivos.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            dtgArquivos.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            dtgArquivos.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
             */


        }

        private void BlueSoftIntegracao_Load(object sender, EventArgs e)
        {

        }

        private void cmdImportacao_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtFolderSelect.Text = folderBrowserDialog1.SelectedPath.ToString();
            
        }

        private void cmdAveriguarArquivos_Click(object sender, EventArgs e)
        {
            try
            {

                lblAguardar.Text = "Localizando e verificando os arquivos. Aguarde por favor ... ! ";
                    Cursor.Current = Cursors.WaitCursor;
                
                /*_BlueSoftListFiles.Clear();
                dtgArquivos.Rows.Clear();


                

                string[] FilesList = Directory.GetFiles(txtFolderSelect.Text);
                int linha = 0;

                foreach (Pag_Net.Tools.  i in FilesList)
                {
                    dtgArquivos.Rows.Add();
                    BlueSoftFile _BlueSoftFile = BlueSoftFileOut(new FileInfo(i.ToString()));
                    _BlueSoftListFiles.Add(_BlueSoftFile);
                    dtgArquivos[0, linha].Value = _BlueSoftFile.NomeDoArquivo;
                    dtgArquivos[1, linha].Value = _BlueSoftFile.Data;
                    dtgArquivos[2, linha].Value = _BlueSoftFile.Tipo;
                    dtgArquivos[3, linha].Value = _BlueSoftFile.NumeroDeLinhas;
                    dtgArquivos[4, linha].Value = _BlueSoftFile.NumeroDeColunas;
                    dtgArquivos[5, linha].Value = _BlueSoftFile.Extencao;
                    
                    linha += 1;
                }
                 */


                _Arquivos = _ManagerFile.DirectoryList(txtFolderSelect.Text);
                dtgArquivos.DataSource = _Arquivos;

                lblAguardar.Text = "";
                Cursor.Current = Cursors.WaitCursor;

                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /*
        private BlueSoftFile BlueSoftFileOut(FileInfo _file)
        {
            BlueSoftFile Arquivo = new BlueSoftFile();
            Arquivo.NomeDoArquivo = _file.FullName;
            Arquivo.Data = _file.LastAccessTime.ToShortDateString();
            Arquivo.Extencao = _file.Extension.ToString();
            if (_file.Extension.ToString() == ".xlsx" || _file.Extension.ToString() == ".xls")
            {
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@_file.FullName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                Arquivo.NumeroDeLinhas  = xlRange.Rows.Count;
                Arquivo.NumeroDeColunas = xlRange.Columns.Count;
                xlWorkbook.Close();
            }
            return Arquivo;
        }*/

        private class BlueSoftFile
        {

            public string NomeDoArquivo { get; set; }
            public string Tipo {get;set;}
            public string Data {get;set;}
            public int NumeroDeColunas  {get;set;}
            public int NumeroDeLinhas { get; set; }
            public string Extencao { get; set; }

        }

        private void CmdFileOpen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                
                lblAguardar.Text = "Abrindo e processando o arquivo selecionado. Aguarde por favor...!";
                Cursor.Current = Cursors.WaitCursor;
                /*BlueSoftFile bluefile = _BlueSoftListFiles[dtgArquivos.CurrentRow.Index];
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@bluefile.NomeDoArquivo);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int l = xlRange.Rows.Count;
                int c = xlRange.Columns.Count;
                
                dtgViewFile.Rows.Clear();
                dtgViewFile.Columns.Clear();

                for (int i = 1; i <= c + 1; i++)
                {
                    dtgViewFile.Columns.Add(i.ToString(), i.ToString());
                }
                for (int x = 1; x <= l; x++)
                {
                    dtgViewFile.Rows.Add();
                }
                for (int x = 1; x <= l; x++)
                {
                    for (int i = 0; i <= c; i++)
                    {
                        if (xlRange.Cells[x, i + 1] != null && xlRange.Cells[x, i + 1].Value2 != null)
                            dtgViewFile[i, x].Value = xlRange.Cells[x, i + 1].Value2.ToString();
                    }
                }
                xlWorkbook.Close();*/

                txtArquivoSelecionado.Text = "";
                ManagerFileInfo fi = _Arquivos[dtgArquivos.CurrentRow.Index];
                txtArquivoSelecionado.Text = _Arquivos[dtgArquivos.CurrentRow.Index].FileName;
                
                dtgViewFile.DataSource = _ManagerFile.View(fi);
                lblAguardar.Text = "";
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                lblAguardar.Text = "";
                MessageBox.Show(ex.Message.ToString());
            }
            
        }


        private void CmdProcessarArquivo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblAguardar.Text = "Importando o arquivo. Aguarde por favor...!";
            try
            {
                ManagerFileInfo fi = _Arquivos[dtgArquivos.CurrentRow.Index];
                Pag_Net.Bll.Services.PagServiceImportarArquivos.Processar(MyConnect, fi);
                lblAguardar.Text = "Arquivo importado com sucesso";
                Cursor.Current = Cursors.Arrow;
            }

            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
                lblAguardar.Text = ex.Message.ToString();
            }

        }

        private void CmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

       



        private void cmdProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma processamento dos arquivos?", "PagNet", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Pag_Net.Bll.Tools.ManagerFileProcess.Proc(MyConnect);
                    MessageBox.Show("Processamento realizado");
                    Cursor.Current = Cursors.Arrow;
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdListarArquivos_Click(object sender, EventArgs e)
        {
            ListarArquivos();

        }

        private void cmdExcluirArquivar_Click(object sender, EventArgs e)
        {
            try
            {
                string stringArquivoSelecionado = "Arquivo: " + dtgArquivosImportados[0, dtgArquivosImportados.CurrentRow.Index].Value.ToString() + " Sequencial: " + dtgArquivosImportados[1, dtgArquivosImportados.CurrentRow.Index].Value.ToString();
                int _ArquivoSequencial = Convert.ToInt32(dtgArquivosImportados[1, dtgArquivosImportados.CurrentRow.Index].Value);
                if (MessageBox.Show("Confirma o arquivamento do registro: " + stringArquivoSelecionado + "?", "Pag", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Pag_Net.Bll.Tools.ManagerFileProcess.Arquivar(MyConnect, _ArquivoSequencial);
                    MessageBox.Show("Processamento realizado");
                    ListarArquivos();
                    Cursor.Current = Cursors.Arrow;
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }

        }


        private void ListarArquivos()
        {

            try
            {
                dtgArquivosImportados.DataSource = null;
                dtgArquivosImportados.Rows.Clear();

                Cursor.Current = Cursors.WaitCursor;
                Pag_Net.Bll.Tools.ManagerFilesImports clsImports = new ManagerFilesImports(MyConnect);
                clsImports.Reflesh();
                dtgArquivosImportados.DataSource = clsImports.DataTableResult;
                Cursor.Current = Cursors.Arrow;
            }

            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
