namespace Pag_Wpf.Financeiro.CartaoCredito
{
    partial class InterfaceImportacaoArquivo
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
            this.cmdCancela = new System.Windows.Forms.Button();
            this.cmdEfetiva = new System.Windows.Forms.Button();
            this.CmdExplorer = new System.Windows.Forms.Button();
            this.DataGridLogProcessamento = new System.Windows.Forms.DataGridView();
            this.LogTransacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtArquivos = new System.Windows.Forms.DataGridView();
            this.Arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLogProcessamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancela
            // 
            this.cmdCancela.Location = new System.Drawing.Point(663, 351);
            this.cmdCancela.Name = "cmdCancela";
            this.cmdCancela.Size = new System.Drawing.Size(75, 23);
            this.cmdCancela.TabIndex = 0;
            this.cmdCancela.Text = "Cancela";
            this.cmdCancela.UseVisualStyleBackColor = true;
            this.cmdCancela.Click += new System.EventHandler(this.cmdCancela_Click);
            // 
            // cmdEfetiva
            // 
            this.cmdEfetiva.Location = new System.Drawing.Point(744, 351);
            this.cmdEfetiva.Name = "cmdEfetiva";
            this.cmdEfetiva.Size = new System.Drawing.Size(75, 23);
            this.cmdEfetiva.TabIndex = 1;
            this.cmdEfetiva.Text = "Efetiva";
            this.cmdEfetiva.UseVisualStyleBackColor = true;
            this.cmdEfetiva.Click += new System.EventHandler(this.cmdEfetiva_Click);
            // 
            // CmdExplorer
            // 
            this.CmdExplorer.Location = new System.Drawing.Point(788, 12);
            this.CmdExplorer.Name = "CmdExplorer";
            this.CmdExplorer.Size = new System.Drawing.Size(31, 23);
            this.CmdExplorer.TabIndex = 4;
            this.CmdExplorer.Text = "...";
            this.CmdExplorer.UseVisualStyleBackColor = true;
            this.CmdExplorer.Click += new System.EventHandler(this.CmdExplorer_Click);
            // 
            // DataGridLogProcessamento
            // 
            this.DataGridLogProcessamento.AllowUserToAddRows = false;
            this.DataGridLogProcessamento.AllowUserToDeleteRows = false;
            this.DataGridLogProcessamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridLogProcessamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogTransacao});
            this.DataGridLogProcessamento.Location = new System.Drawing.Point(15, 195);
            this.DataGridLogProcessamento.Name = "DataGridLogProcessamento";
            this.DataGridLogProcessamento.ReadOnly = true;
            this.DataGridLogProcessamento.Size = new System.Drawing.Size(804, 150);
            this.DataGridLogProcessamento.TabIndex = 5;
            this.DataGridLogProcessamento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridLogProcessamento_CellContentClick);
            // 
            // LogTransacao
            // 
            this.LogTransacao.HeaderText = "Log Importação do Arquivo";
            this.LogTransacao.Name = "LogTransacao";
            this.LogTransacao.ReadOnly = true;
            this.LogTransacao.Width = 500;
            // 
            // dtArquivos
            // 
            this.dtArquivos.AllowUserToAddRows = false;
            this.dtArquivos.AllowUserToDeleteRows = false;
            this.dtArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arquivo,
            this.Interface});
            this.dtArquivos.Location = new System.Drawing.Point(15, 41);
            this.dtArquivos.Name = "dtArquivos";
            this.dtArquivos.ReadOnly = true;
            this.dtArquivos.Size = new System.Drawing.Size(804, 126);
            this.dtArquivos.TabIndex = 6;
            this.dtArquivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtArquivos_CellContentClick);
            // 
            // Arquivo
            // 
            this.Arquivo.HeaderText = "Arquivos a Processar";
            this.Arquivo.Name = "Arquivo";
            this.Arquivo.ReadOnly = true;
            this.Arquivo.Width = 500;
            // 
            // Interface
            // 
            this.Interface.HeaderText = "Interface";
            this.Interface.Name = "Interface";
            this.Interface.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Arquivos Extratos CIELO/REDE CARD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // InterfaceImportacaoArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtArquivos);
            this.Controls.Add(this.DataGridLogProcessamento);
            this.Controls.Add(this.CmdExplorer);
            this.Controls.Add(this.cmdEfetiva);
            this.Controls.Add(this.cmdCancela);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceImportacaoArquivo";
            this.Text = "Importação Interface Cartões de Crédito";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLogProcessamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancela;
        private System.Windows.Forms.Button cmdEfetiva;
        private System.Windows.Forms.Button CmdExplorer;
        private System.Windows.Forms.DataGridView DataGridLogProcessamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogTransacao;
        private System.Windows.Forms.DataGridView dtArquivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interface;
    }
}