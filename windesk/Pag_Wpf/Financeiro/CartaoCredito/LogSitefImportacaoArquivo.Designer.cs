namespace Pag_Wpf.Financeiro.CartaoCredito
{
    partial class LogSitefImportacaoArquivo
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtArquivos = new System.Windows.Forms.DataGridView();
            this.Arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusProcessamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridLogProcessamento = new System.Windows.Forms.DataGridView();
            this.LogTransacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdExplorer = new System.Windows.Forms.Button();
            this.cmdEfetiva = new System.Windows.Forms.Button();
            this.cmdCancela = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLogProcessamento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Log Sitef - Arquivo";
            // 
            // dtArquivos
            // 
            this.dtArquivos.AllowUserToAddRows = false;
            this.dtArquivos.AllowUserToDeleteRows = false;
            this.dtArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arquivo,
            this.StatusProcessamento});
            this.dtArquivos.Location = new System.Drawing.Point(12, 36);
            this.dtArquivos.Name = "dtArquivos";
            this.dtArquivos.ReadOnly = true;
            this.dtArquivos.Size = new System.Drawing.Size(804, 126);
            this.dtArquivos.TabIndex = 12;
            // 
            // Arquivo
            // 
            this.Arquivo.HeaderText = "Arquivos a Processar";
            this.Arquivo.Name = "Arquivo";
            this.Arquivo.ReadOnly = true;
            this.Arquivo.Width = 500;
            // 
            // StatusProcessamento
            // 
            this.StatusProcessamento.HeaderText = "Status Processamento";
            this.StatusProcessamento.Name = "StatusProcessamento";
            this.StatusProcessamento.ReadOnly = true;
            // 
            // DataGridLogProcessamento
            // 
            this.DataGridLogProcessamento.AllowUserToAddRows = false;
            this.DataGridLogProcessamento.AllowUserToDeleteRows = false;
            this.DataGridLogProcessamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridLogProcessamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogTransacao});
            this.DataGridLogProcessamento.Location = new System.Drawing.Point(12, 190);
            this.DataGridLogProcessamento.Name = "DataGridLogProcessamento";
            this.DataGridLogProcessamento.ReadOnly = true;
            this.DataGridLogProcessamento.Size = new System.Drawing.Size(804, 150);
            this.DataGridLogProcessamento.TabIndex = 11;
            // 
            // LogTransacao
            // 
            this.LogTransacao.HeaderText = "Log Importação do Arquivo";
            this.LogTransacao.Name = "LogTransacao";
            this.LogTransacao.ReadOnly = true;
            this.LogTransacao.Width = 500;
            // 
            // CmdExplorer
            // 
            this.CmdExplorer.Location = new System.Drawing.Point(785, 7);
            this.CmdExplorer.Name = "CmdExplorer";
            this.CmdExplorer.Size = new System.Drawing.Size(31, 23);
            this.CmdExplorer.TabIndex = 10;
            this.CmdExplorer.Text = "...";
            this.CmdExplorer.UseVisualStyleBackColor = true;
            this.CmdExplorer.Click += new System.EventHandler(this.CmdExplorer_Click);
            // 
            // cmdEfetiva
            // 
            this.cmdEfetiva.Location = new System.Drawing.Point(741, 346);
            this.cmdEfetiva.Name = "cmdEfetiva";
            this.cmdEfetiva.Size = new System.Drawing.Size(75, 23);
            this.cmdEfetiva.TabIndex = 9;
            this.cmdEfetiva.Text = "Efetiva";
            this.cmdEfetiva.UseVisualStyleBackColor = true;
            this.cmdEfetiva.Click += new System.EventHandler(this.cmdEfetiva_Click);
            // 
            // cmdCancela
            // 
            this.cmdCancela.Location = new System.Drawing.Point(660, 346);
            this.cmdCancela.Name = "cmdCancela";
            this.cmdCancela.Size = new System.Drawing.Size(75, 23);
            this.cmdCancela.TabIndex = 8;
            this.cmdCancela.Text = "Cancela";
            this.cmdCancela.UseVisualStyleBackColor = true;
            this.cmdCancela.Click += new System.EventHandler(this.cmdCancela_Click);
            // 
            // LogSitefImportacaoArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtArquivos);
            this.Controls.Add(this.DataGridLogProcessamento);
            this.Controls.Add(this.CmdExplorer);
            this.Controls.Add(this.cmdEfetiva);
            this.Controls.Add(this.cmdCancela);
            this.Name = "LogSitefImportacaoArquivo";
            this.Text = "Log Sitef - Importação de Arquivo";
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridLogProcessamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtArquivos;
        private System.Windows.Forms.DataGridView DataGridLogProcessamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogTransacao;
        private System.Windows.Forms.Button CmdExplorer;
        private System.Windows.Forms.Button cmdEfetiva;
        private System.Windows.Forms.Button cmdCancela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusProcessamento;

    }
}