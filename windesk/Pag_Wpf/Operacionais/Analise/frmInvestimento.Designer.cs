namespace Pag_Wpf.Operacionais.Analise
{
    partial class frmInvestimento
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTSeqContrato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CMBFabricante = new System.Windows.Forms.ComboBox();
            this.dtgContratos = new System.Windows.Forms.DataGridView();
            this.SeqContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMDAdicionar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CMDLocalizar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TXTSeqContrato);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TXTDescricao);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CMBFabricante);
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 100);
            this.panel1.TabIndex = 75;
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Location = new System.Drawing.Point(631, 62);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(75, 23);
            this.CMDLocalizar.TabIndex = 12;
            this.CMDLocalizar.Text = "Localiza";
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Seq Contrato";
            // 
            // TXTSeqContrato
            // 
            this.TXTSeqContrato.Location = new System.Drawing.Point(310, 25);
            this.TXTSeqContrato.Name = "TXTSeqContrato";
            this.TXTSeqContrato.Size = new System.Drawing.Size(146, 20);
            this.TXTSeqContrato.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descrição";
            // 
            // TXTDescricao
            // 
            this.TXTDescricao.Location = new System.Drawing.Point(15, 25);
            this.TXTDescricao.Name = "TXTDescricao";
            this.TXTDescricao.Size = new System.Drawing.Size(289, 20);
            this.TXTDescricao.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fabricante";
            // 
            // CMBFabricante
            // 
            this.CMBFabricante.FormattingEnabled = true;
            this.CMBFabricante.Location = new System.Drawing.Point(462, 24);
            this.CMBFabricante.Name = "CMBFabricante";
            this.CMBFabricante.Size = new System.Drawing.Size(244, 21);
            this.CMBFabricante.TabIndex = 6;
            // 
            // dtgContratos
            // 
            this.dtgContratos.AllowDrop = true;
            this.dtgContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqContrato,
            this.Descricao});
            this.dtgContratos.Location = new System.Drawing.Point(12, 128);
            this.dtgContratos.Name = "dtgContratos";
            this.dtgContratos.Size = new System.Drawing.Size(713, 272);
            this.dtgContratos.TabIndex = 76;
            // 
            // SeqContrato
            // 
            this.SeqContrato.DataPropertyName = "SeqContrato";
            this.SeqContrato.HeaderText = "Seq";
            this.SeqContrato.Name = "SeqContrato";
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "DESCRICAO_CONTRATO";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // CMDAdicionar
            // 
            this.CMDAdicionar.Location = new System.Drawing.Point(650, 406);
            this.CMDAdicionar.Name = "CMDAdicionar";
            this.CMDAdicionar.Size = new System.Drawing.Size(75, 23);
            this.CMDAdicionar.TabIndex = 77;
            this.CMDAdicionar.Text = "Novo ";
            this.CMDAdicionar.UseVisualStyleBackColor = true;
            this.CMDAdicionar.Click += new System.EventHandler(this.CMDAdicionar_Click);
            // 
            // frmInvestimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 437);
            this.Controls.Add(this.CMDAdicionar);
            this.Controls.Add(this.dtgContratos);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestimento";
            this.Text = "Investimentos de Terceiros";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTSeqContrato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CMBFabricante;
        private System.Windows.Forms.DataGridView dtgContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.Button CMDAdicionar;
    }
}