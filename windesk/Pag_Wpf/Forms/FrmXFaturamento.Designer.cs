namespace Pag_Wpf.Forms
{
    partial class FrmXFaturamento
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
            this.dtgFaturamentoBlueSoftNotasFiscais = new System.Windows.Forms.DataGridView();
            this.dtgfat_base_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgfat_base_Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoClienteCPFCNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgtCancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpInicial = new System.Windows.Forms.DateTimePicker();
            this.txtCdProdutoTgt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoftNotasFiscais)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgFaturamentoBlueSoftNotasFiscais
            // 
            this.dtgFaturamentoBlueSoftNotasFiscais.AllowUserToAddRows = false;
            this.dtgFaturamentoBlueSoftNotasFiscais.AllowUserToDeleteRows = false;
            this.dtgFaturamentoBlueSoftNotasFiscais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFaturamentoBlueSoftNotasFiscais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgfat_base_empresa,
            this.dtgfat_base_Operacao,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.PedidoClienteCPFCNPJ,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dgtCancelada,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dtgFaturamentoBlueSoftNotasFiscais.Location = new System.Drawing.Point(12, 58);
            this.dtgFaturamentoBlueSoftNotasFiscais.Name = "dtgFaturamentoBlueSoftNotasFiscais";
            this.dtgFaturamentoBlueSoftNotasFiscais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFaturamentoBlueSoftNotasFiscais.Size = new System.Drawing.Size(889, 163);
            this.dtgFaturamentoBlueSoftNotasFiscais.TabIndex = 186;
            // 
            // dtgfat_base_empresa
            // 
            this.dtgfat_base_empresa.DataPropertyName = "CdEmpresa";
            this.dtgfat_base_empresa.HeaderText = "Empresa";
            this.dtgfat_base_empresa.Name = "dtgfat_base_empresa";
            this.dtgfat_base_empresa.Width = 25;
            // 
            // dtgfat_base_Operacao
            // 
            this.dtgfat_base_Operacao.DataPropertyName = "CdOperacao";
            this.dtgfat_base_Operacao.HeaderText = "Operação";
            this.dtgfat_base_Operacao.Name = "dtgfat_base_Operacao";
            this.dtgfat_base_Operacao.Width = 25;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "VENDEDOR";
            this.dataGridViewTextBoxColumn10.HeaderText = "Vend Nome";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CLIENTE";
            this.dataGridViewTextBoxColumn12.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // PedidoClienteCPFCNPJ
            // 
            this.PedidoClienteCPFCNPJ.DataPropertyName = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.HeaderText = "CNPJ";
            this.PedidoClienteCPFCNPJ.Name = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.Width = 45;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumeroPedidoBlueSoft";
            this.dataGridViewTextBoxColumn1.HeaderText = "N. Ped";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NumeroNotaFiscal";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nfv N.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 45;
            // 
            // dgtCancelada
            // 
            this.dgtCancelada.DataPropertyName = "statusnotacancelamento";
            this.dgtCancelada.HeaderText = "Cancelada";
            this.dgtCancelada.Name = "dgtCancelada";
            this.dgtCancelada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgtCancelada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgtCancelada.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NumeroNotaFiscalDevolucao";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nfd N.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DataPedido";
            this.dataGridViewTextBoxColumn4.HeaderText = "Data Ped";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DataNotaFiscal";
            this.dataGridViewTextBoxColumn5.HeaderText = "Data Nf";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PedidoStatus";
            this.dataGridViewTextBoxColumn6.HeaderText = "Sit Ped";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PedidoPrazoPagamento";
            this.dataGridViewTextBoxColumn7.HeaderText = "Prazo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VendedorKey";
            this.dataGridViewTextBoxColumn8.HeaderText = "Vkey";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PedidoVendedorCPFCNPJ";
            this.dataGridViewTextBoxColumn9.HeaderText = "VCPF";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 45;
            // 
            // DtpFinal
            // 
            this.DtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFinal.Location = new System.Drawing.Point(114, 32);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpFinal.TabIndex = 185;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 183;
            this.label2.Text = "Data Inicial";
            // 
            // DtpInicial
            // 
            this.DtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicial.Location = new System.Drawing.Point(12, 32);
            this.DtpInicial.Name = "DtpInicial";
            this.DtpInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpInicial.TabIndex = 182;
            // 
            // txtCdProdutoTgt
            // 
            this.txtCdProdutoTgt.Location = new System.Drawing.Point(216, 32);
            this.txtCdProdutoTgt.Name = "txtCdProdutoTgt";
            this.txtCdProdutoTgt.Size = new System.Drawing.Size(132, 20);
            this.txtCdProdutoTgt.TabIndex = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Código Prd Blue";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(862, 29);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 187;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            // 
            // FrmXFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 649);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtgFaturamentoBlueSoftNotasFiscais);
            this.Controls.Add(this.DtpFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpInicial);
            this.Controls.Add(this.txtCdProdutoTgt);
            this.Controls.Add(this.label1);
            this.Name = "FrmXFaturamento";
            this.Text = "FrmXFaturamento";
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoftNotasFiscais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgFaturamentoBlueSoftNotasFiscais;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgfat_base_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgfat_base_Operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoClienteCPFCNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgtCancelada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpInicial;
        private System.Windows.Forms.TextBox txtCdProdutoTgt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdBuscar;
    }
}