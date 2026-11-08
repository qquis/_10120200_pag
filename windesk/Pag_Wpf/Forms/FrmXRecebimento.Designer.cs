namespace Pag_Wpf.Forms
{
    partial class FrmXRecebimento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Cmd_PARAMETRO_024_CdImport = new System.Windows.Forms.Button();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpInicial = new System.Windows.Forms.DateTimePicker();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtCdProdutoTgt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.dtgProduto = new System.Windows.Forms.DataGridView();
            this.CdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdProdutoBluesoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgNotaFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCFOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDtEmissão = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDataRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEmbalagemCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEmbalagemCompraQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEmbalagemEstoqueQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEmbalagemEstoqueValorCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtCdProdutoBlueSoft = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PrgPagAtualizaProduto = new System.Windows.Forms.ProgressBar();
            this.LBL_INFO_PROGRESS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmd_PARAMETRO_024_CdImport
            // 
            this.Cmd_PARAMETRO_024_CdImport.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.Cmd_PARAMETRO_024_CdImport.Location = new System.Drawing.Point(779, 29);
            this.Cmd_PARAMETRO_024_CdImport.Name = "Cmd_PARAMETRO_024_CdImport";
            this.Cmd_PARAMETRO_024_CdImport.Size = new System.Drawing.Size(39, 23);
            this.Cmd_PARAMETRO_024_CdImport.TabIndex = 187;
            this.Cmd_PARAMETRO_024_CdImport.UseVisualStyleBackColor = true;
            this.Cmd_PARAMETRO_024_CdImport.Click += new System.EventHandler(this.Cmd_PARAMETRO_024_CdImport_Click);
            // 
            // DtpFinal
            // 
            this.DtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFinal.Location = new System.Drawing.Point(114, 32);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpFinal.TabIndex = 186;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 185;
            this.label4.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 184;
            this.label2.Text = "Data Inicial";
            // 
            // DtpInicial
            // 
            this.DtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicial.Location = new System.Drawing.Point(12, 32);
            this.DtpInicial.Name = "DtpInicial";
            this.DtpInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpInicial.TabIndex = 183;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(824, 29);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 182;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtCdProdutoTgt
            // 
            this.txtCdProdutoTgt.Location = new System.Drawing.Point(216, 31);
            this.txtCdProdutoTgt.Name = "txtCdProdutoTgt";
            this.txtCdProdutoTgt.Size = new System.Drawing.Size(95, 20);
            this.txtCdProdutoTgt.TabIndex = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Código Prd ";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(763, 450);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 189;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // dtgProduto
            // 
            this.dtgProduto.AllowUserToAddRows = false;
            this.dtgProduto.AllowUserToDeleteRows = false;
            this.dtgProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdProduto,
            this.CdProdutoBluesoft,
            this.Descricao,
            this.EmbalagemEstoque,
            this.dtgNotaFiscal,
            this.dtgCFOP,
            this.dtgDtEmissão,
            this.dtgDataRecebimento,
            this.dtgEmbalagemCompra,
            this.dtgEmbalagemCompraQtde,
            this.dtgEmbalagemEstoqueQtde,
            this.dtgEmbalagemEstoqueValorCusto});
            this.dtgProduto.Location = new System.Drawing.Point(12, 67);
            this.dtgProduto.Name = "dtgProduto";
            this.dtgProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProduto.Size = new System.Drawing.Size(851, 377);
            this.dtgProduto.TabIndex = 190;
            // 
            // CdProduto
            // 
            this.CdProduto.DataPropertyName = "CdProduto";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CdProduto.DefaultCellStyle = dataGridViewCellStyle21;
            this.CdProduto.HeaderText = "Cod.";
            this.CdProduto.Name = "CdProduto";
            this.CdProduto.ReadOnly = true;
            this.CdProduto.Width = 55;
            // 
            // CdProdutoBluesoft
            // 
            this.CdProdutoBluesoft.DataPropertyName = "CdProdutoBluesoft";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CdProdutoBluesoft.DefaultCellStyle = dataGridViewCellStyle22;
            this.CdProdutoBluesoft.HeaderText = "Cod Blue";
            this.CdProdutoBluesoft.Name = "CdProdutoBluesoft";
            this.CdProdutoBluesoft.Width = 55;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle23;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // EmbalagemEstoque
            // 
            this.EmbalagemEstoque.DataPropertyName = "EmbalagemEstoque";
            this.EmbalagemEstoque.HeaderText = "Emb";
            this.EmbalagemEstoque.Name = "EmbalagemEstoque";
            this.EmbalagemEstoque.ReadOnly = true;
            this.EmbalagemEstoque.Width = 30;
            // 
            // dtgNotaFiscal
            // 
            this.dtgNotaFiscal.DataPropertyName = "NumeroNotaFiscal";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgNotaFiscal.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgNotaFiscal.HeaderText = "N. Nota Fiscal";
            this.dtgNotaFiscal.Name = "dtgNotaFiscal";
            this.dtgNotaFiscal.Width = 70;
            // 
            // dtgCFOP
            // 
            this.dtgCFOP.DataPropertyName = "CFOP";
            this.dtgCFOP.HeaderText = "CFOP";
            this.dtgCFOP.Name = "dtgCFOP";
            this.dtgCFOP.Width = 60;
            // 
            // dtgDtEmissão
            // 
            this.dtgDtEmissão.DataPropertyName = "DataEmissao";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgDtEmissão.DefaultCellStyle = dataGridViewCellStyle25;
            this.dtgDtEmissão.HeaderText = "Dt. Emis";
            this.dtgDtEmissão.Name = "dtgDtEmissão";
            this.dtgDtEmissão.Width = 60;
            // 
            // dtgDataRecebimento
            // 
            this.dtgDataRecebimento.DataPropertyName = "DataRecebimento";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgDataRecebimento.DefaultCellStyle = dataGridViewCellStyle26;
            this.dtgDataRecebimento.HeaderText = "Dt Rec";
            this.dtgDataRecebimento.Name = "dtgDataRecebimento";
            this.dtgDataRecebimento.Width = 60;
            // 
            // dtgEmbalagemCompra
            // 
            this.dtgEmbalagemCompra.DataPropertyName = "EmbalagemCompra";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgEmbalagemCompra.DefaultCellStyle = dataGridViewCellStyle27;
            this.dtgEmbalagemCompra.HeaderText = "E.C";
            this.dtgEmbalagemCompra.Name = "dtgEmbalagemCompra";
            this.dtgEmbalagemCompra.Width = 60;
            // 
            // dtgEmbalagemCompraQtde
            // 
            this.dtgEmbalagemCompraQtde.DataPropertyName = "EmbalagemCompraQtde";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgEmbalagemCompraQtde.DefaultCellStyle = dataGridViewCellStyle28;
            this.dtgEmbalagemCompraQtde.HeaderText = "Qtde.C";
            this.dtgEmbalagemCompraQtde.Name = "dtgEmbalagemCompraQtde";
            this.dtgEmbalagemCompraQtde.Width = 60;
            // 
            // dtgEmbalagemEstoqueQtde
            // 
            this.dtgEmbalagemEstoqueQtde.DataPropertyName = "EmbalagemEstoqueQtde";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgEmbalagemEstoqueQtde.DefaultCellStyle = dataGridViewCellStyle29;
            this.dtgEmbalagemEstoqueQtde.HeaderText = "Qtde.Unit";
            this.dtgEmbalagemEstoqueQtde.Name = "dtgEmbalagemEstoqueQtde";
            this.dtgEmbalagemEstoqueQtde.Width = 60;
            // 
            // dtgEmbalagemEstoqueValorCusto
            // 
            this.dtgEmbalagemEstoqueValorCusto.DataPropertyName = "EmbalagemEstoqueValorCusto";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgEmbalagemEstoqueValorCusto.DefaultCellStyle = dataGridViewCellStyle30;
            this.dtgEmbalagemEstoqueValorCusto.HeaderText = "Vl Unit";
            this.dtgEmbalagemEstoqueValorCusto.Name = "dtgEmbalagemEstoqueValorCusto";
            this.dtgEmbalagemEstoqueValorCusto.Width = 60;
            // 
            // TxtCdProdutoBlueSoft
            // 
            this.TxtCdProdutoBlueSoft.Location = new System.Drawing.Point(317, 29);
            this.TxtCdProdutoBlueSoft.Name = "TxtCdProdutoBlueSoft";
            this.TxtCdProdutoBlueSoft.Size = new System.Drawing.Size(95, 20);
            this.TxtCdProdutoBlueSoft.TabIndex = 191;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 192;
            this.label3.Text = "Código Prd Blue";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(418, 29);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(282, 20);
            this.txtDescricao.TabIndex = 193;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 194;
            this.label5.Text = "Descrição";
            // 
            // PrgPagAtualizaProduto
            // 
            this.PrgPagAtualizaProduto.Location = new System.Drawing.Point(428, 450);
            this.PrgPagAtualizaProduto.Name = "PrgPagAtualizaProduto";
            this.PrgPagAtualizaProduto.Size = new System.Drawing.Size(272, 23);
            this.PrgPagAtualizaProduto.TabIndex = 196;
            // 
            // LBL_INFO_PROGRESS
            // 
            this.LBL_INFO_PROGRESS.AutoSize = true;
            this.LBL_INFO_PROGRESS.Location = new System.Drawing.Point(10, 450);
            this.LBL_INFO_PROGRESS.Name = "LBL_INFO_PROGRESS";
            this.LBL_INFO_PROGRESS.Size = new System.Drawing.Size(0, 13);
            this.LBL_INFO_PROGRESS.TabIndex = 195;
            // 
            // FrmXRecebimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 485);
            this.Controls.Add(this.PrgPagAtualizaProduto);
            this.Controls.Add(this.LBL_INFO_PROGRESS);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtCdProdutoBlueSoft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgProduto);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.Cmd_PARAMETRO_024_CdImport);
            this.Controls.Add(this.DtpFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpInicial);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtCdProdutoTgt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXRecebimento";
            this.Text = "Recebimentos / Dados Históricos (d-1)";
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cmd_PARAMETRO_024_CdImport;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpInicial;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtCdProdutoTgt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.DataGridView dtgProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProdutoBluesoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgNotaFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDtEmissão;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDataRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgEmbalagemCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgEmbalagemCompraQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgEmbalagemEstoqueQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgEmbalagemEstoqueValorCusto;
        private System.Windows.Forms.TextBox TxtCdProdutoBlueSoft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar PrgPagAtualizaProduto;
        private System.Windows.Forms.Label LBL_INFO_PROGRESS;
    }
}