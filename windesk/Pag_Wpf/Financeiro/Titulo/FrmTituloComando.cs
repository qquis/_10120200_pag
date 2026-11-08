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

namespace Pag_Wpf.Financeiro.Titulo
{
    public partial class FrmTituloComando : Form
    {
        modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Financeiro.Titulos.UspTitulos BLL;
        public FrmTituloComando(modelSistemaUsuario __myConnect, string ListaTitulos)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                BLL = new Pag_Net.Bll.Financeiro.Titulos.UspTitulos(MyConnect);
                BLL.Parametros.ListaTitulos = ListaTitulos;
                BLL.Select();
                //TitulosList = __titulosList;
                FillTitulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillTitulos()
        {
            DTGTitulos.AutoGenerateColumns = false;
            DTGTitulos.MultiSelect = false;
            DTGTitulos.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[7].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;
            DTGTitulos.Rows.Clear();
            int row = 0;
            foreach (Pag_Net.Bll.Financeiro.Titulos.UVWTitulo item in ((Pag_Net.Bll.Financeiro.Titulos.UVWTitulo[])BLL.ViewData))
            {
                DTGTitulos.Rows.Add();
                DTGTitulos[0, row].Value = item.SeqTitulo.ToString();
                DTGTitulos[1, row].Value  = item.CdEmpresa.ToString("000");
                DTGTitulos[2, row].Value = item.CdParticipanteSacado.ToString();
                DTGTitulos[3, row].Value = item.NomeSacado.ToString();
                DTGTitulos[4, row].Value = item.DataVencimento.ToShortDateString();
                DTGTitulos[5, row].Value = item.DescricaoTituloEspecie.ToString();
                DTGTitulos[6, row].Value = item.DescricaoSituacao.ToString();
                DTGTitulos[7, row].Value = item.Valor.ToString("0.00");
                DTGTitulos[8, row].Value = item.ValorSaldo.ToString("0.00");
                row = row + 1;
            }
        }
    }
}

