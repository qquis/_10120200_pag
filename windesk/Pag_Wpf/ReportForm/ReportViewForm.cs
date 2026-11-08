using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Microsoft.Reporting.WinForms;

namespace Pag_Wpf
{
    public partial class ReportViewForm : Form
    {
        private Object[] _Dados;
        private string _Report;
        private string _DataSetReport;
        public ReportViewForm(Object[] dados, string report, string datasetreport)
        {
            try
            {
                InitializeComponent();
                _Dados = dados;
                _Report = report;
                _DataSetReport = datasetreport;
                OpenReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Report_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }

        public void OpenReport()
        {
            this.reportViewer1.Reset();
            //set processing to local mode
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            BindingSource bs = new BindingSource();
            bs.DataSource = _Dados;

            //reportViewer1.LocalReport.ReportEmbeddedResource = "Pag_Net.ProcessZanthusStatusPreco.rdlc";


            reportViewer1.LocalReport.ReportEmbeddedResource = _Report;
            ReportDataSource z = new ReportDataSource(_DataSetReport, bs);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(z);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

    }
}
