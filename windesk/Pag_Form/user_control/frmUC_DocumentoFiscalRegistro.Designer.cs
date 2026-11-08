namespace Pag_Form.user_control
{
    partial class frmUC_DocumentoFiscalRegistro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdfr_nf_numero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdfr_nf_serie = new System.Windows.Forms.TextBox();
            this.dtgNotasFiscaisListas = new System.Windows.Forms.DataGridView();
            this.t_dfr_nf_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_data_emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_chave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_cnpj_cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdfr_nf_chave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdfr_cnpj_cpf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdnotasfiscais_incluir = new System.Windows.Forms.Button();
            this.cmdnotasfiscais_efetivar = new System.Windows.Forms.Button();
            this.dtpdata_emissao = new System.Windows.Forms.DateTimePicker();
            this.cmdlimpa = new System.Windows.Forms.Button();
            this.cmdcancela_lista = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasFiscaisListas)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 21);
            this.label5.TabIndex = 222;
            this.label5.Text = "NFe Número";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdfr_nf_numero
            // 
            this.txtdfr_nf_numero.AcceptsTab = true;
            this.txtdfr_nf_numero.Location = new System.Drawing.Point(8, 83);
            this.txtdfr_nf_numero.Name = "txtdfr_nf_numero";
            this.txtdfr_nf_numero.Size = new System.Drawing.Size(89, 20);
            this.txtdfr_nf_numero.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(104, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 224;
            this.label1.Text = "Série";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdfr_nf_serie
            // 
            this.txtdfr_nf_serie.AcceptsTab = true;
            this.txtdfr_nf_serie.Location = new System.Drawing.Point(103, 83);
            this.txtdfr_nf_serie.Name = "txtdfr_nf_serie";
            this.txtdfr_nf_serie.Size = new System.Drawing.Size(42, 20);
            this.txtdfr_nf_serie.TabIndex = 1;
            // 
            // dtgNotasFiscaisListas
            // 
            this.dtgNotasFiscaisListas.AllowUserToAddRows = false;
            this.dtgNotasFiscaisListas.AllowUserToDeleteRows = false;
            this.dtgNotasFiscaisListas.AllowUserToResizeRows = false;
            this.dtgNotasFiscaisListas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotasFiscaisListas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgNotasFiscaisListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotasFiscaisListas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.t_dfr_nf_numero,
            this.tdfr_nf_serie,
            this.tdfr_nf_data_emissao,
            this.tdfr_nf_chave,
            this.tdfr_cnpj_cpf});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNotasFiscaisListas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgNotasFiscaisListas.Location = new System.Drawing.Point(10, 109);
            this.dtgNotasFiscaisListas.Name = "dtgNotasFiscaisListas";
            this.dtgNotasFiscaisListas.ReadOnly = true;
            this.dtgNotasFiscaisListas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotasFiscaisListas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgNotasFiscaisListas.RowHeadersVisible = false;
            this.dtgNotasFiscaisListas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotasFiscaisListas.Size = new System.Drawing.Size(548, 140);
            this.dtgNotasFiscaisListas.TabIndex = 6;
            // 
            // t_dfr_nf_numero
            // 
            this.t_dfr_nf_numero.DataPropertyName = "dfr_nf_numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.t_dfr_nf_numero.DefaultCellStyle = dataGridViewCellStyle2;
            this.t_dfr_nf_numero.Frozen = true;
            this.t_dfr_nf_numero.HeaderText = "N. NF";
            this.t_dfr_nf_numero.Name = "t_dfr_nf_numero";
            this.t_dfr_nf_numero.ReadOnly = true;
            this.t_dfr_nf_numero.Width = 60;
            // 
            // tdfr_nf_serie
            // 
            this.tdfr_nf_serie.DataPropertyName = "dfr_nf_serie";
            this.tdfr_nf_serie.HeaderText = "S";
            this.tdfr_nf_serie.Name = "tdfr_nf_serie";
            this.tdfr_nf_serie.ReadOnly = true;
            // 
            // tdfr_nf_data_emissao
            // 
            this.tdfr_nf_data_emissao.DataPropertyName = "dfr_nf_data_emissao";
            this.tdfr_nf_data_emissao.HeaderText = "Data Emissão";
            this.tdfr_nf_data_emissao.Name = "tdfr_nf_data_emissao";
            this.tdfr_nf_data_emissao.ReadOnly = true;
            // 
            // tdfr_nf_chave
            // 
            this.tdfr_nf_chave.DataPropertyName = "dfr_nf_chave";
            this.tdfr_nf_chave.HeaderText = "Chave";
            this.tdfr_nf_chave.Name = "tdfr_nf_chave";
            this.tdfr_nf_chave.ReadOnly = true;
            this.tdfr_nf_chave.Width = 150;
            // 
            // tdfr_cnpj_cpf
            // 
            this.tdfr_cnpj_cpf.DataPropertyName = "dfr_cnpj_cpf";
            this.tdfr_cnpj_cpf.HeaderText = "CNPJ";
            this.tdfr_cnpj_cpf.Name = "tdfr_cnpj_cpf";
            this.tdfr_cnpj_cpf.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(447, 21);
            this.label2.TabIndex = 227;
            this.label2.Text = "Chave do Documento Fiscal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdfr_nf_chave
            // 
            this.txtdfr_nf_chave.AcceptsTab = true;
            this.txtdfr_nf_chave.Location = new System.Drawing.Point(9, 33);
            this.txtdfr_nf_chave.Name = "txtdfr_nf_chave";
            this.txtdfr_nf_chave.Size = new System.Drawing.Size(448, 20);
            this.txtdfr_nf_chave.TabIndex = 0;
            this.txtdfr_nf_chave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdfr_nf_chave_KeyPress);
            this.txtdfr_nf_chave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdfr_nf_chave_KeyUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(151, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 21);
            this.label3.TabIndex = 229;
            this.label3.Text = "CNPJ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdfr_cnpj_cpf
            // 
            this.txtdfr_cnpj_cpf.AcceptsTab = true;
            this.txtdfr_cnpj_cpf.Location = new System.Drawing.Point(150, 83);
            this.txtdfr_cnpj_cpf.Name = "txtdfr_cnpj_cpf";
            this.txtdfr_cnpj_cpf.Size = new System.Drawing.Size(141, 20);
            this.txtdfr_cnpj_cpf.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(297, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 21);
            this.label4.TabIndex = 231;
            this.label4.Text = "Data Emissão";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdnotasfiscais_incluir
            // 
            this.cmdnotasfiscais_incluir.Location = new System.Drawing.Point(519, 77);
            this.cmdnotasfiscais_incluir.Name = "cmdnotasfiscais_incluir";
            this.cmdnotasfiscais_incluir.Size = new System.Drawing.Size(39, 30);
            this.cmdnotasfiscais_incluir.TabIndex = 5;
            this.cmdnotasfiscais_incluir.UseVisualStyleBackColor = true;
            this.cmdnotasfiscais_incluir.Click += new System.EventHandler(this.cmdnotasfiscais_incluir_Click);
            // 
            // cmdnotasfiscais_efetivar
            // 
            this.cmdnotasfiscais_efetivar.Location = new System.Drawing.Point(519, 253);
            this.cmdnotasfiscais_efetivar.Name = "cmdnotasfiscais_efetivar";
            this.cmdnotasfiscais_efetivar.Size = new System.Drawing.Size(39, 30);
            this.cmdnotasfiscais_efetivar.TabIndex = 7;
            this.cmdnotasfiscais_efetivar.UseVisualStyleBackColor = true;
            this.cmdnotasfiscais_efetivar.Click += new System.EventHandler(this.cmdnotasfiscais_efetivar_Click);
            // 
            // dtpdata_emissao
            // 
            this.dtpdata_emissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdata_emissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdata_emissao.Location = new System.Drawing.Point(297, 83);
            this.dtpdata_emissao.Name = "dtpdata_emissao";
            this.dtpdata_emissao.Size = new System.Drawing.Size(160, 21);
            this.dtpdata_emissao.TabIndex = 3;
            // 
            // cmdlimpa
            // 
            this.cmdlimpa.Location = new System.Drawing.Point(474, 77);
            this.cmdlimpa.Name = "cmdlimpa";
            this.cmdlimpa.Size = new System.Drawing.Size(39, 30);
            this.cmdlimpa.TabIndex = 232;
            this.cmdlimpa.UseVisualStyleBackColor = true;
            this.cmdlimpa.Click += new System.EventHandler(this.cmdlimpa_Click);
            // 
            // cmdcancela_lista
            // 
            this.cmdcancela_lista.Location = new System.Drawing.Point(474, 252);
            this.cmdcancela_lista.Name = "cmdcancela_lista";
            this.cmdcancela_lista.Size = new System.Drawing.Size(39, 30);
            this.cmdcancela_lista.TabIndex = 233;
            this.cmdcancela_lista.UseVisualStyleBackColor = true;
            this.cmdcancela_lista.Click += new System.EventHandler(this.cmdcancela_lista_Click);
            // 
            // frmUC_DocumentoFiscalRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.cmdcancela_lista);
            this.Controls.Add(this.cmdlimpa);
            this.Controls.Add(this.dtpdata_emissao);
            this.Controls.Add(this.cmdnotasfiscais_efetivar);
            this.Controls.Add(this.cmdnotasfiscais_incluir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdfr_cnpj_cpf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdfr_nf_chave);
            this.Controls.Add(this.dtgNotasFiscaisListas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdfr_nf_serie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdfr_nf_numero);
            this.Name = "frmUC_DocumentoFiscalRegistro";
            this.Size = new System.Drawing.Size(566, 299);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasFiscaisListas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdfr_nf_numero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdfr_nf_serie;
        private System.Windows.Forms.DataGridView dtgNotasFiscaisListas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdfr_nf_chave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdfr_cnpj_cpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdnotasfiscais_incluir;
        private System.Windows.Forms.Button cmdnotasfiscais_efetivar;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_dfr_nf_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_data_emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_chave;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_cnpj_cpf;
        private System.Windows.Forms.DateTimePicker dtpdata_emissao;
        private System.Windows.Forms.Button cmdlimpa;
        private System.Windows.Forms.Button cmdcancela_lista;
    }
}
