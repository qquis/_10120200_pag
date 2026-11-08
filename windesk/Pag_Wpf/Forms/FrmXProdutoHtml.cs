using Pag_Net.Bll.Produto_OLD;
using Pag_Net.Bll.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Forms
{
    public partial class FrmXProdutoHtml : Form
    {
        DataTable TbBlueSoftProduto;
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public FrmXProdutoHtml(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            TbBlueSoftProduto = new DataTable();
        }
        private void cmdArquivoProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName.ToString() != "")
                {
                    txtArquivoProdutos.Text = openFileDialog1.FileName.ToString();
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdProcessarArquivos_Click(object sender, EventArgs e)
        {

            try
            {

                //System.Int32
                //System.Double
                TbBlueSoftProduto.Columns.Clear();


                Pag_Net.Tools.ManagerFile _ManagerFile = new Pag_Net.Tools.ManagerFile();
                Pag_Net.Tools.ManagerFileInfo fi = _ManagerFile.FileOut(new System.IO.FileInfo(txtArquivoProdutos.Text));
                DataColumn column;
                column = new DataColumn("CdProdutoBlueSoft", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("CdProdutoBlueSoftUnitario", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("Embalagem", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("FatorEstoque", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("CodigoBarra", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("Descricao", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                column = new DataColumn("LT", System.Type.GetType("System.String")); TbBlueSoftProduto.Columns.Add(column);
                
                foreach (DataRow x in _ManagerFile.View(fi).Rows)
                {
                    if (x[0].ToString() != "")
                    {
                        DataRow TbBlueRow = TbBlueSoftProduto.NewRow();

                        TbBlueRow["CdProdutoBlueSoft"] = x[0].ToString().Substring(Convert.ToInt32(txtCodigoBlueSoft_INI.Text), Convert.ToInt32(txtCodigoBlueSoft_Tamanho.Text));
                        TbBlueRow["CdProdutoBlueSoftUnitario"] = x[0].ToString().Substring(Convert.ToInt32(txtCodigoBlueSoftUnitario_INI.Text), Convert.ToInt32(txtCodigoBlueSoftUnitario_Tamanho.Text));
                        TbBlueRow["Descricao"] = x[0].ToString().Substring(Convert.ToInt32(txtDescricao_INI.Text), Convert.ToInt32(txtDescricao_Tamanho.Text));
                        TbBlueRow["Embalagem"] = x[0].ToString().Substring(Convert.ToInt32(txtEmbalagem_INI.Text), Convert.ToInt32(txtEmbalagem_Tamanho.Text));
                        TbBlueRow["CodigoBarra"] = x[0].ToString().Substring(Convert.ToInt32(txtCDBARRA_INI.Text), Convert.ToInt32(txtCDBARRA_FIM.Text));
                        TbBlueRow["FatorEstoque"] = x[0].ToString().Substring(Convert.ToInt32(txtFatorEstoque_INI.Text), Convert.ToInt32(txtFatorEstoque_FIM.Text));
                        TbBlueRow["LT"] = x[0].ToString().Length.ToString();
                        TbBlueSoftProduto.Rows.Add(TbBlueRow);
                    }
                     
                }
                dtgProduto.DataSource = TbBlueSoftProduto; //_ManagerFile.View(fi);
                txtTotal.Text = TbBlueSoftProduto.Rows.Count.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cmdAplicar_Click(object sender, EventArgs e)
        {
            cmdAplicar.Enabled = false;
            try
            {
                if (TbBlueSoftProduto.Rows.Count > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Pag_Net.Bll.SP_Produto SP = new Pag_Net.Bll.SP_Produto(MyConnect);
                    SP.Execute_Import_FileTextBlueSoft_Produtos(TbBlueSoftProduto);
                    //Pag_Net.Bll.Produto.BlueSoft_Import_Val_Unit.start(MyConnect, TbBlueSoftProduto);
                    this.Cursor = Cursors.Default;
                    cmdAplicar.Enabled = true;
                    MessageBox.Show("Códigos Unitários atualizados com sucesso!");
                }
                else 
                {
                    cmdAplicar.Enabled = true;
                    MessageBox.Show("Não há dados a serem processados");
                }
            }

            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                cmdAplicar.Enabled = true;
                MessageBox.Show(ex.Message);
            }

        }

    }
}
