namespace Pag_Wpf.BlueSoft
{
    partial class BlueSoftIntegracao
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblAguardar = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.CmdProcessarArquivo = new System.Windows.Forms.Button();
            this.txtArquivoSelecionado = new System.Windows.Forms.TextBox();
            this.CmdFileOpen = new System.Windows.Forms.Button();
            this.dtgViewFile = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAveriguarArquivos = new System.Windows.Forms.Button();
            this.txtFolderSelect = new System.Windows.Forms.TextBox();
            this.dtgArquivos = new System.Windows.Forms.DataGridView();
            this.cmdImportacao = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdExcluirArquivar = new System.Windows.Forms.Button();
            this.cmdListarArquivos = new System.Windows.Forms.Button();
            this.cmdProcessar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgArquivosImportados = new System.Windows.Forms.DataGridView();
            this.CmdSair = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivosImportados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAguardar
            // 
            this.lblAguardar.AutoSize = true;
            this.lblAguardar.Location = new System.Drawing.Point(14, 520);
            this.lblAguardar.Name = "lblAguardar";
            this.lblAguardar.Size = new System.Drawing.Size(16, 13);
            this.lblAguardar.TabIndex = 141;
            this.lblAguardar.Text = "...";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 505);
            this.tabControl1.TabIndex = 143;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.CmdProcessarArquivo);
            this.tabPage1.Controls.Add(this.txtArquivoSelecionado);
            this.tabPage1.Controls.Add(this.CmdFileOpen);
            this.tabPage1.Controls.Add(this.dtgViewFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmdAveriguarArquivos);
            this.tabPage1.Controls.Add(this.txtFolderSelect);
            this.tabPage1.Controls.Add(this.dtgArquivos);
            this.tabPage1.Controls.Add(this.cmdImportacao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Importação";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 147;
            this.label3.Text = "Mensagens de Processamentos...";
            // 
            // CmdProcessarArquivo
            // 
            this.CmdProcessarArquivo.Location = new System.Drawing.Point(735, 453);
            this.CmdProcessarArquivo.Name = "CmdProcessarArquivo";
            this.CmdProcessarArquivo.Size = new System.Drawing.Size(111, 23);
            this.CmdProcessarArquivo.TabIndex = 146;
            this.CmdProcessarArquivo.Text = "Importar Arquivo";
            this.CmdProcessarArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdProcessarArquivo.UseVisualStyleBackColor = true;
            this.CmdProcessarArquivo.Click += new System.EventHandler(this.CmdProcessarArquivo_Click);
            // 
            // txtArquivoSelecionado
            // 
            this.txtArquivoSelecionado.Enabled = false;
            this.txtArquivoSelecionado.Location = new System.Drawing.Point(19, 193);
            this.txtArquivoSelecionado.Name = "txtArquivoSelecionado";
            this.txtArquivoSelecionado.Size = new System.Drawing.Size(478, 20);
            this.txtArquivoSelecionado.TabIndex = 145;
            // 
            // CmdFileOpen
            // 
            this.CmdFileOpen.Location = new System.Drawing.Point(735, 193);
            this.CmdFileOpen.Name = "CmdFileOpen";
            this.CmdFileOpen.Size = new System.Drawing.Size(111, 23);
            this.CmdFileOpen.TabIndex = 144;
            this.CmdFileOpen.Text = "Visualizar Arquivo";
            this.CmdFileOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdFileOpen.UseVisualStyleBackColor = true;
            this.CmdFileOpen.Click += new System.EventHandler(this.CmdFileOpen_Click);
            // 
            // dtgViewFile
            // 
            this.dtgViewFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewFile.Location = new System.Drawing.Point(19, 220);
            this.dtgViewFile.Name = "dtgViewFile";
            this.dtgViewFile.Size = new System.Drawing.Size(827, 227);
            this.dtgViewFile.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "Diretório";
            // 
            // cmdAveriguarArquivos
            // 
            this.cmdAveriguarArquivos.Location = new System.Drawing.Point(769, 18);
            this.cmdAveriguarArquivos.Name = "cmdAveriguarArquivos";
            this.cmdAveriguarArquivos.Size = new System.Drawing.Size(77, 23);
            this.cmdAveriguarArquivos.TabIndex = 141;
            this.cmdAveriguarArquivos.Text = "Listar Dir.";
            this.cmdAveriguarArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAveriguarArquivos.UseVisualStyleBackColor = true;
            this.cmdAveriguarArquivos.Click += new System.EventHandler(this.cmdAveriguarArquivos_Click);
            // 
            // txtFolderSelect
            // 
            this.txtFolderSelect.Location = new System.Drawing.Point(79, 16);
            this.txtFolderSelect.Name = "txtFolderSelect";
            this.txtFolderSelect.Size = new System.Drawing.Size(255, 20);
            this.txtFolderSelect.TabIndex = 140;
            this.txtFolderSelect.Text = "D:\\TI";
            // 
            // dtgArquivos
            // 
            this.dtgArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArquivos.Location = new System.Drawing.Point(19, 42);
            this.dtgArquivos.Name = "dtgArquivos";
            this.dtgArquivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgArquivos.Size = new System.Drawing.Size(827, 143);
            this.dtgArquivos.TabIndex = 139;
            // 
            // cmdImportacao
            // 
            this.cmdImportacao.Location = new System.Drawing.Point(340, 14);
            this.cmdImportacao.Name = "cmdImportacao";
            this.cmdImportacao.Size = new System.Drawing.Size(26, 23);
            this.cmdImportacao.TabIndex = 138;
            this.cmdImportacao.UseVisualStyleBackColor = true;
            this.cmdImportacao.Click += new System.EventHandler(this.cmdImportacao_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmdExcluirArquivar);
            this.tabPage2.Controls.Add(this.cmdListarArquivos);
            this.tabPage2.Controls.Add(this.cmdProcessar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dtgArquivosImportados);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista de Arquivos Importados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdExcluirArquivar
            // 
            this.cmdExcluirArquivar.Location = new System.Drawing.Point(15, 450);
            this.cmdExcluirArquivar.Name = "cmdExcluirArquivar";
            this.cmdExcluirArquivar.Size = new System.Drawing.Size(164, 23);
            this.cmdExcluirArquivar.TabIndex = 148;
            this.cmdExcluirArquivar.Text = "Arquivar Arquivo Selecionado";
            this.cmdExcluirArquivar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExcluirArquivar.UseVisualStyleBackColor = true;
            this.cmdExcluirArquivar.Click += new System.EventHandler(this.cmdExcluirArquivar_Click);
            // 
            // cmdListarArquivos
            // 
            this.cmdListarArquivos.Location = new System.Drawing.Point(668, 6);
            this.cmdListarArquivos.Name = "cmdListarArquivos";
            this.cmdListarArquivos.Size = new System.Drawing.Size(167, 23);
            this.cmdListarArquivos.TabIndex = 147;
            this.cmdListarArquivos.Text = "Buscar arquivos Importados";
            this.cmdListarArquivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdListarArquivos.UseVisualStyleBackColor = true;
            this.cmdListarArquivos.Click += new System.EventHandler(this.cmdListarArquivos_Click);
            // 
            // cmdProcessar
            // 
            this.cmdProcessar.Location = new System.Drawing.Point(671, 450);
            this.cmdProcessar.Name = "cmdProcessar";
            this.cmdProcessar.Size = new System.Drawing.Size(164, 23);
            this.cmdProcessar.TabIndex = 146;
            this.cmdProcessar.Text = "Processar Todos os Arquivos";
            this.cmdProcessar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProcessar.UseVisualStyleBackColor = true;
            this.cmdProcessar.Click += new System.EventHandler(this.cmdProcessar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 145;
            this.label2.Text = "Arquivos Importados";
            // 
            // dtgArquivosImportados
            // 
            this.dtgArquivosImportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgArquivosImportados.Location = new System.Drawing.Point(15, 40);
            this.dtgArquivosImportados.Name = "dtgArquivosImportados";
            this.dtgArquivosImportados.Size = new System.Drawing.Size(820, 406);
            this.dtgArquivosImportados.TabIndex = 144;
            // 
            // CmdSair
            // 
            this.CmdSair.Location = new System.Drawing.Point(756, 523);
            this.CmdSair.Name = "CmdSair";
            this.CmdSair.Size = new System.Drawing.Size(111, 23);
            this.CmdSair.TabIndex = 144;
            this.CmdSair.Text = "Sair";
            this.CmdSair.UseVisualStyleBackColor = true;
            this.CmdSair.Click += new System.EventHandler(this.CmdSair_Click);
            // 
            // BlueSoftIntegracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 552);
            this.Controls.Add(this.CmdSair);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAguardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlueSoftIntegracao";
            this.Text = "BlueSoft Integração ";
            this.Load += new System.EventHandler(this.BlueSoftIntegracao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgArquivosImportados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblAguardar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdProcessarArquivo;
        private System.Windows.Forms.TextBox txtArquivoSelecionado;
        private System.Windows.Forms.Button CmdFileOpen;
        private System.Windows.Forms.DataGridView dtgViewFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAveriguarArquivos;
        private System.Windows.Forms.TextBox txtFolderSelect;
        private System.Windows.Forms.DataGridView dtgArquivos;
        private System.Windows.Forms.Button cmdImportacao;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmdExcluirArquivar;
        private System.Windows.Forms.Button cmdListarArquivos;
        private System.Windows.Forms.Button cmdProcessar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgArquivosImportados;
        private System.Windows.Forms.Button CmdSair;
    }
}