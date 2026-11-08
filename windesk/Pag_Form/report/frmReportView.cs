using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.report
{

    public class PagReportDataSource
    {
        public Object[] Dados { get; set; }
        public string DataSetReport { get; set; }
        public PagReportDataSource(Object[] _Dados, string _DataSetReport)
        {
            this.Dados = _Dados;
            this.DataSetReport = _DataSetReport;
        }
        
    }

    public partial class frmReportView : Form
    {
        List<PagReportDataSource> _ListDataSources; 
        private Object[] _Dados;
        private string _Report;
        private string _DataSetReport;
        Microsoft.Reporting.WinForms.ReportParameterCollection _ReporteParametros;
        public frmReportView(Object[] dados, string report, string datasetreport, Microsoft.Reporting.WinForms.ReportParameterCollection ReporteParametros)
        {
            try
            {
                InitializeComponent();

                _ListDataSources = new List<PagReportDataSource>();

                _Dados = dados;
                _Report = report;
                _DataSetReport = datasetreport;
                _ReporteParametros = ReporteParametros;

                _ListDataSources.Add(new PagReportDataSource(dados, _DataSetReport));
                
                
                OpenReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmReportView(List<PagReportDataSource> _PagReportDataSource, string report, Microsoft.Reporting.WinForms.ReportParameterCollection ReporteParametros)
        {
            try
            {
                InitializeComponent();

                _ListDataSources = new List<PagReportDataSource>();

                _Report = report;
                _ReporteParametros = ReporteParametros;

                _ListDataSources = _PagReportDataSource;


                OpenReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmReportView_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OpenReport()
        {
            try
            {
                
                this.reportViewer1.Reset();
                reportViewer1.LocalReport.EnableExternalImages = true; 
                //set processing to local mode
                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                
                
                //BindingSource bs = new BindingSource();
                //bs.DataSource = _Dados;
                //reportViewer1.LocalReport.ReportEmbeddedResource = "Pag_Net.ProcessZanthusStatusPreco.rdlc";

                reportViewer1.LocalReport.ReportEmbeddedResource = _Report;


                //ReportDataSource z = new ReportDataSource(_DataSetReport, bs);


                reportViewer1.LocalReport.DataSources.Clear();
                foreach (PagReportDataSource item in _ListDataSources)
                {

                    BindingSource Dados = new BindingSource();
                    Dados.DataSource = item.Dados;
                    ReportDataSource ReportDataSourceItem = new ReportDataSource(item.DataSetReport, Dados);
                    reportViewer1.LocalReport.DataSources.Add(ReportDataSourceItem);
                }
                
                // reportViewer1.LocalReport.DataSources.Add(z);



                reportViewer1.LocalReport.SetParameters(_ReporteParametros);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
