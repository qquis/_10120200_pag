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
    public partial class FrmLocalizaEndereco : Form
    {
        public int CepSelecionado { get; set; }
        private Pag_Net.Bll.Cadastros.UspEndereco BLL;
        public FrmLocalizaEndereco(modelSistemaUsuario __myConnect)
        {
            InitializeComponent();
            BLL = new Pag_Net.Bll.Cadastros.UspEndereco(__myConnect);
            CMDLocalizar.Enabled = true;
            //CMDSelecionar.Enabled = false;
            //CMDCancelar.Enabled = false;
        }

        private void FrmParticipanteLocalizaEndereco_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridParticipanteLocalizaEndereco.AutoGenerateColumns = false;
            DataGridParticipanteLocalizaEndereco.AutoGenerateColumns = false;
            DataGridParticipanteLocalizaEndereco.MultiSelect = true;
            DataGridParticipanteLocalizaEndereco.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridParticipanteLocalizaEndereco.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridParticipanteLocalizaEndereco.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridParticipanteLocalizaEndereco.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridParticipanteLocalizaEndereco.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridParticipanteLocalizaEndereco.AllowUserToAddRows = false;
            DataGridParticipanteLocalizaEndereco.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Cursor.Current = Cursors.Arrow;

        }


        private void CMDLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataGridParticipanteLocalizaEndereco.Rows.Clear();
                BLL.Select();
                int linha = 0;
                foreach (Pag_Net.Bll.Cadastros.UVWEndereco item in BLL.ViewData)
                {
                    DataGridParticipanteLocalizaEndereco.Rows.Add();
                    DataGridParticipanteLocalizaEndereco[0, linha].Value = item.CdEndereco.ToString();
                    DataGridParticipanteLocalizaEndereco[1, linha].Value = item.Cep.ToString();
                    DataGridParticipanteLocalizaEndereco[2, linha].Value = item.Logradouro.ToString();
                    DataGridParticipanteLocalizaEndereco[3, linha].Value = item.Bairro.ToString();
                    DataGridParticipanteLocalizaEndereco[4, linha].Value = item.Municipio.ToString();
                    DataGridParticipanteLocalizaEndereco[5, linha].Value = item.CdEstado.ToString();
                    linha += 1;
                }
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void TXTLogradouro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLL.Parametros.Logradouro = TXTLogradouro.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTCep_Para_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTCep_Para.Text.ToString().Trim() != "") 
                BLL.Parametros.CepFim = Convert.ToInt32( TXTCep_Para.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TXTCep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TXTCep.Text.ToString().Trim() != "") 
                BLL.Parametros.Cep = Convert.ToInt32(TXTCep.Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDLimpar_Click(object sender, EventArgs e)
        {
            TXTCep.Text = "";
            TXTCep_Para.Text = "";
            TXTLogradouro.Text = "";
            TXTCep.Focus();
        }

        private void CMDSelecionar_Click(object sender, EventArgs e)
        {
            CepSelecionado = Convert.ToInt32(DataGridParticipanteLocalizaEndereco[1, DataGridParticipanteLocalizaEndereco.SelectedRows[0].Index ].Value.ToString());
        }

        private void DataGridParticipanteLocalizaEndereco_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            CepSelecionado = Convert.ToInt32(DataGridParticipanteLocalizaEndereco[1, e.Cell.RowIndex].ToString());
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




     
   
    }
}
