namespace Pag_Wpf
{
    partial class ReportViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.UVWComercialPedidoCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ModelTbErpZanthusStatusProdutoPrecoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.UVWComercialPedidoCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelTbErpZanthusStatusProdutoPrecoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UVWComercialPedidoCompraBindingSource
            // 
            this.UVWComercialPedidoCompraBindingSource.DataSource = typeof(Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra);
            // 
            // ModelTbErpZanthusStatusProdutoPrecoBindingSource
            // 
            this.ModelTbErpZanthusStatusProdutoPrecoBindingSource.DataSource = typeof(Pag_Net.Models.TbStatusProdutoPreco);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.BackColor = System.Drawing.SystemColors.Menu;
            reportDataSource1.Name = "DSPedidoCompra";
            reportDataSource1.Value = this.UVWComercialPedidoCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pag_Wpf.ReportForm.rptPedidoCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.MaximumSize = new System.Drawing.Size(980, 960);
            this.reportViewer1.MinimumSize = new System.Drawing.Size(600, 960);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.PromptAreaCollapsed = true;
            this.reportViewer1.Size = new System.Drawing.Size(851, 960);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // ReportViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(844, 861);
            this.Controls.Add(this.reportViewer1);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 900);
            this.Name = "ReportViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UVWComercialPedidoCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelTbErpZanthusStatusProdutoPrecoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ModelTbErpZanthusStatusProdutoPrecoBindingSource;
        private System.Windows.Forms.BindingSource UVWComercialPedidoCompraBindingSource;
    }
}