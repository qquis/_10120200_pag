namespace Pag_Wpf.Forms
{
    partial class FrmXContratos
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
            this.DtgContratos = new System.Windows.Forms.DataGridView();
            this.dtgfat_base_Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalhe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtgSeqContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgDataInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDataFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTipoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgParticipante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgNumeroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgNumeroNfe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpInicial = new System.Windows.Forms.DateTimePicker();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.LblTipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgContratos
            // 
            this.DtgContratos.AllowUserToAddRows = false;
            this.DtgContratos.AllowUserToDeleteRows = false;
            this.DtgContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgfat_base_Operacao,
            this.Detalhe,
            this.dtgSeqContrato,
            this.DtgDataInicial,
            this.dtgDataFinal,
            this.DtgDescricao,
            this.dtgTipoDescricao,
            this.dtgParticipante,
            this.dtgNumeroPedido,
            this.dtgNumeroNfe});
            this.DtgContratos.Location = new System.Drawing.Point(12, 70);
            this.DtgContratos.Name = "DtgContratos";
            this.DtgContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgContratos.Size = new System.Drawing.Size(889, 320);
            this.DtgContratos.TabIndex = 184;
            this.DtgContratos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgContratos_CellContentClick);
            // 
            // dtgfat_base_Operacao
            // 
            this.dtgfat_base_Operacao.DataPropertyName = "CdOperacao";
            this.dtgfat_base_Operacao.HeaderText = "Operação";
            this.dtgfat_base_Operacao.Name = "dtgfat_base_Operacao";
            this.dtgfat_base_Operacao.Width = 25;
            // 
            // Detalhe
            // 
            this.Detalhe.HeaderText = "Detalhe";
            this.Detalhe.Name = "Detalhe";
            this.Detalhe.Width = 15;
            // 
            // dtgSeqContrato
            // 
            this.dtgSeqContrato.DataPropertyName = "SeqContrato";
            this.dtgSeqContrato.HeaderText = "Seq";
            this.dtgSeqContrato.Name = "dtgSeqContrato";
            this.dtgSeqContrato.Width = 60;
            // 
            // DtgDataInicial
            // 
            this.DtgDataInicial.DataPropertyName = "DataInicio";
            this.DtgDataInicial.HeaderText = "Início";
            this.DtgDataInicial.Name = "DtgDataInicial";
            this.DtgDataInicial.Width = 60;
            // 
            // dtgDataFinal
            // 
            this.dtgDataFinal.DataPropertyName = "DataFim";
            this.dtgDataFinal.HeaderText = "Fim";
            this.dtgDataFinal.Name = "dtgDataFinal";
            this.dtgDataFinal.Width = 60;
            // 
            // DtgDescricao
            // 
            this.DtgDescricao.DataPropertyName = "Descricao";
            this.DtgDescricao.HeaderText = "Descrição";
            this.DtgDescricao.Name = "DtgDescricao";
            this.DtgDescricao.Width = 90;
            // 
            // dtgTipoDescricao
            // 
            this.dtgTipoDescricao.DataPropertyName = "TipoDescricao";
            this.dtgTipoDescricao.HeaderText = "Tipo";
            this.dtgTipoDescricao.Name = "dtgTipoDescricao";
            // 
            // dtgParticipante
            // 
            this.dtgParticipante.DataPropertyName = "CdParticipante";
            this.dtgParticipante.HeaderText = "Sacado";
            this.dtgParticipante.Name = "dtgParticipante";
            // 
            // dtgNumeroPedido
            // 
            this.dtgNumeroPedido.DataPropertyName = "NumeroPedido";
            this.dtgNumeroPedido.HeaderText = "N. Pedido";
            this.dtgNumeroPedido.Name = "dtgNumeroPedido";
            // 
            // dtgNumeroNfe
            // 
            this.dtgNumeroNfe.DataPropertyName = "NumeroNfe";
            this.dtgNumeroNfe.HeaderText = "Nfe";
            this.dtgNumeroNfe.Name = "dtgNumeroNfe";
            // 
            // DtpFinal
            // 
            this.DtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFinal.Location = new System.Drawing.Point(114, 33);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpFinal.TabIndex = 183;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 182;
            this.label4.Text = "Data Final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 181;
            this.label2.Text = "Data Inicial";
            // 
            // DtpInicial
            // 
            this.DtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicial.Location = new System.Drawing.Point(12, 33);
            this.DtpInicial.Name = "DtpInicial";
            this.DtpInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpInicial.TabIndex = 180;
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(801, 396);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 186;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(862, 29);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 185;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DisplayMember = "Descricao";
            this.cmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(216, 32);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(221, 24);
            this.cmbTipo.TabIndex = 187;
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new System.Drawing.Point(213, 13);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(164, 13);
            this.LblTipo.TabIndex = 188;
            this.LblTipo.Text = "Tipo de Contrato de Investimento";
            // 
            // FrmXContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 431);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.DtgContratos);
            this.Controls.Add(this.DtpFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpInicial);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXContratos";
            this.Text = "Contratos";
            ((System.ComponentModel.ISupportInitialize)(this.DtgContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgContratos;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpInicial;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgfat_base_Operacao;
        private System.Windows.Forms.DataGridViewButtonColumn Detalhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgSeqContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgDataInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDataFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTipoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgParticipante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgNumeroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgNumeroNfe;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label LblTipo;
    }
}