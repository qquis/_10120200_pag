namespace Pag_Form.forms
{
    partial class frm_DocumentoFiscalRegistro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.tabcontrol_doc_reg = new System.Windows.Forms.TabControl();
            this.tabRecebimento = new System.Windows.Forms.TabPage();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_registro_data_fim = new System.Windows.Forms.DateTimePicker();
            this.dtp_registro_data_ini = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatusNfeManifestacao = new System.Windows.Forms.ComboBox();
            this.chkRecebida = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLancada = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgNotasFiscaisListas_Consulta = new System.Windows.Forms.DataGridView();
            this.tNOME_RAZAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_cnpj_cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_dfr_nf_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_data_emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdfr_nf_chave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDF_STATUS_RECEBIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDF_MANIFESTACAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDF_MANIFESTACAO_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdf_ceop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDocumentoFiscal_Registro_Consulta = new System.Windows.Forms.Button();
            this.tabcontrol_doc_reg.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasFiscaisListas_Consulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1255, 46);
            this.label12.TabIndex = 201;
            this.label12.Text = "Operações | ADM - Documento Fiscal/Registro";
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(1127, 16);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 10;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // tabcontrol_doc_reg
            // 
            this.tabcontrol_doc_reg.Controls.Add(this.tabRecebimento);
            this.tabcontrol_doc_reg.Controls.Add(this.tabConsulta);
            this.tabcontrol_doc_reg.Location = new System.Drawing.Point(16, 60);
            this.tabcontrol_doc_reg.Margin = new System.Windows.Forms.Padding(4);
            this.tabcontrol_doc_reg.Name = "tabcontrol_doc_reg";
            this.tabcontrol_doc_reg.SelectedIndex = 0;
            this.tabcontrol_doc_reg.Size = new System.Drawing.Size(1244, 603);
            this.tabcontrol_doc_reg.TabIndex = 0;
            // 
            // tabRecebimento
            // 
            this.tabRecebimento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabRecebimento.Location = new System.Drawing.Point(4, 25);
            this.tabRecebimento.Margin = new System.Windows.Forms.Padding(4);
            this.tabRecebimento.Name = "tabRecebimento";
            this.tabRecebimento.Padding = new System.Windows.Forms.Padding(4);
            this.tabRecebimento.Size = new System.Drawing.Size(1236, 574);
            this.tabRecebimento.TabIndex = 0;
            this.tabRecebimento.Text = "Recebimento";
            // 
            // tabConsulta
            // 
            this.tabConsulta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabConsulta.Controls.Add(this.label3);
            this.tabConsulta.Controls.Add(this.label7);
            this.tabConsulta.Controls.Add(this.dtp_registro_data_fim);
            this.tabConsulta.Controls.Add(this.dtp_registro_data_ini);
            this.tabConsulta.Controls.Add(this.label2);
            this.tabConsulta.Controls.Add(this.cmbStatusNfeManifestacao);
            this.tabConsulta.Controls.Add(this.chkRecebida);
            this.tabConsulta.Controls.Add(this.label1);
            this.tabConsulta.Controls.Add(this.chkLancada);
            this.tabConsulta.Controls.Add(this.label10);
            this.tabConsulta.Controls.Add(this.dtgNotasFiscaisListas_Consulta);
            this.tabConsulta.Location = new System.Drawing.Point(4, 25);
            this.tabConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(4);
            this.tabConsulta.Size = new System.Drawing.Size(1236, 574);
            this.tabConsulta.TabIndex = 1;
            this.tabConsulta.Text = "Consulta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(893, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 271;
            this.label3.Text = "à";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(753, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 25);
            this.label7.TabIndex = 270;
            this.label7.Text = "Data de Registro do Doc. Fiscal";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_registro_data_fim
            // 
            this.dtp_registro_data_fim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_registro_data_fim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_registro_data_fim.Location = new System.Drawing.Point(915, 42);
            this.dtp_registro_data_fim.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_registro_data_fim.Name = "dtp_registro_data_fim";
            this.dtp_registro_data_fim.Size = new System.Drawing.Size(135, 24);
            this.dtp_registro_data_fim.TabIndex = 269;
            // 
            // dtp_registro_data_ini
            // 
            this.dtp_registro_data_ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_registro_data_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_registro_data_ini.Location = new System.Drawing.Point(753, 42);
            this.dtp_registro_data_ini.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_registro_data_ini.Name = "dtp_registro_data_ini";
            this.dtp_registro_data_ini.Size = new System.Drawing.Size(135, 24);
            this.dtp_registro_data_ini.TabIndex = 268;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(519, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 29);
            this.label2.TabIndex = 267;
            this.label2.Text = "Status NF";
            // 
            // cmbStatusNfeManifestacao
            // 
            this.cmbStatusNfeManifestacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusNfeManifestacao.FormattingEnabled = true;
            this.cmbStatusNfeManifestacao.Location = new System.Drawing.Point(519, 44);
            this.cmbStatusNfeManifestacao.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatusNfeManifestacao.Name = "cmbStatusNfeManifestacao";
            this.cmbStatusNfeManifestacao.Size = new System.Drawing.Size(225, 24);
            this.cmbStatusNfeManifestacao.TabIndex = 266;
            // 
            // chkRecebida
            // 
            this.chkRecebida.AutoSize = true;
            this.chkRecebida.Checked = true;
            this.chkRecebida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecebida.Location = new System.Drawing.Point(480, 48);
            this.chkRecebida.Margin = new System.Windows.Forms.Padding(4);
            this.chkRecebida.Name = "chkRecebida";
            this.chkRecebida.Size = new System.Drawing.Size(18, 17);
            this.chkRecebida.TabIndex = 265;
            this.chkRecebida.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(312, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 59);
            this.label1.TabIndex = 264;
            this.label1.Text = "Notas Fiscais NÃO Recebidas ";
            // 
            // chkLancada
            // 
            this.chkLancada.AutoSize = true;
            this.chkLancada.Checked = true;
            this.chkLancada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLancada.Location = new System.Drawing.Point(275, 48);
            this.chkLancada.Margin = new System.Windows.Forms.Padding(4);
            this.chkLancada.Name = "chkLancada";
            this.chkLancada.Size = new System.Drawing.Size(18, 17);
            this.chkLancada.TabIndex = 263;
            this.chkLancada.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(8, 11);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(295, 59);
            this.label10.TabIndex = 262;
            this.label10.Text = "Registros Lançados e NÃO encontrados na BLUESOFT";
            // 
            // dtgNotasFiscaisListas_Consulta
            // 
            this.dtgNotasFiscaisListas_Consulta.AllowUserToAddRows = false;
            this.dtgNotasFiscaisListas_Consulta.AllowUserToDeleteRows = false;
            this.dtgNotasFiscaisListas_Consulta.AllowUserToResizeRows = false;
            this.dtgNotasFiscaisListas_Consulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotasFiscaisListas_Consulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgNotasFiscaisListas_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotasFiscaisListas_Consulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tNOME_RAZAO,
            this.tdfr_cnpj_cpf,
            this.t_dfr_nf_numero,
            this.tdfr_nf_serie,
            this.tdfr_nf_data_emissao,
            this.tdfr_nf_chave,
            this.tDF_STATUS_RECEBIMENTO,
            this.tDF_MANIFESTACAO,
            this.tDF_MANIFESTACAO_DESCRICAO,
            this.tdf_ceop});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNotasFiscaisListas_Consulta.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgNotasFiscaisListas_Consulta.Location = new System.Drawing.Point(8, 78);
            this.dtgNotasFiscaisListas_Consulta.Margin = new System.Windows.Forms.Padding(4);
            this.dtgNotasFiscaisListas_Consulta.Name = "dtgNotasFiscaisListas_Consulta";
            this.dtgNotasFiscaisListas_Consulta.ReadOnly = true;
            this.dtgNotasFiscaisListas_Consulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotasFiscaisListas_Consulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgNotasFiscaisListas_Consulta.RowHeadersVisible = false;
            this.dtgNotasFiscaisListas_Consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotasFiscaisListas_Consulta.Size = new System.Drawing.Size(1217, 473);
            this.dtgNotasFiscaisListas_Consulta.TabIndex = 260;
            // 
            // tNOME_RAZAO
            // 
            this.tNOME_RAZAO.DataPropertyName = "NOME_RAZAO";
            this.tNOME_RAZAO.HeaderText = "Razão Social";
            this.tNOME_RAZAO.Name = "tNOME_RAZAO";
            this.tNOME_RAZAO.ReadOnly = true;
            this.tNOME_RAZAO.Width = 210;
            // 
            // tdfr_cnpj_cpf
            // 
            this.tdfr_cnpj_cpf.DataPropertyName = "dfr_cnpj_cpf";
            this.tdfr_cnpj_cpf.HeaderText = "CNPJ";
            this.tdfr_cnpj_cpf.Name = "tdfr_cnpj_cpf";
            this.tdfr_cnpj_cpf.ReadOnly = true;
            this.tdfr_cnpj_cpf.Width = 85;
            // 
            // t_dfr_nf_numero
            // 
            this.t_dfr_nf_numero.DataPropertyName = "dfr_nf_numero";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.t_dfr_nf_numero.DefaultCellStyle = dataGridViewCellStyle6;
            this.t_dfr_nf_numero.HeaderText = "N. NF";
            this.t_dfr_nf_numero.Name = "t_dfr_nf_numero";
            this.t_dfr_nf_numero.ReadOnly = true;
            this.t_dfr_nf_numero.Width = 70;
            // 
            // tdfr_nf_serie
            // 
            this.tdfr_nf_serie.DataPropertyName = "dfr_nf_serie";
            this.tdfr_nf_serie.HeaderText = "S";
            this.tdfr_nf_serie.Name = "tdfr_nf_serie";
            this.tdfr_nf_serie.ReadOnly = true;
            this.tdfr_nf_serie.Width = 40;
            // 
            // tdfr_nf_data_emissao
            // 
            this.tdfr_nf_data_emissao.DataPropertyName = "dfr_nf_data_emissao";
            this.tdfr_nf_data_emissao.HeaderText = "Data Emissão";
            this.tdfr_nf_data_emissao.Name = "tdfr_nf_data_emissao";
            this.tdfr_nf_data_emissao.ReadOnly = true;
            this.tdfr_nf_data_emissao.Width = 70;
            // 
            // tdfr_nf_chave
            // 
            this.tdfr_nf_chave.DataPropertyName = "dfr_nf_chave";
            this.tdfr_nf_chave.HeaderText = "Chave";
            this.tdfr_nf_chave.Name = "tdfr_nf_chave";
            this.tdfr_nf_chave.ReadOnly = true;
            this.tdfr_nf_chave.Width = 70;
            // 
            // tDF_STATUS_RECEBIMENTO
            // 
            this.tDF_STATUS_RECEBIMENTO.DataPropertyName = "df_status_recebimento";
            this.tDF_STATUS_RECEBIMENTO.HeaderText = "Status Nfe";
            this.tDF_STATUS_RECEBIMENTO.Name = "tDF_STATUS_RECEBIMENTO";
            this.tDF_STATUS_RECEBIMENTO.ReadOnly = true;
            this.tDF_STATUS_RECEBIMENTO.Width = 60;
            // 
            // tDF_MANIFESTACAO
            // 
            this.tDF_MANIFESTACAO.DataPropertyName = "df_manifestacao";
            this.tDF_MANIFESTACAO.HeaderText = "Nfe Status Id";
            this.tDF_MANIFESTACAO.Name = "tDF_MANIFESTACAO";
            this.tDF_MANIFESTACAO.ReadOnly = true;
            this.tDF_MANIFESTACAO.Width = 10;
            // 
            // tDF_MANIFESTACAO_DESCRICAO
            // 
            this.tDF_MANIFESTACAO_DESCRICAO.DataPropertyName = "df_manifestacao_descricao";
            this.tDF_MANIFESTACAO_DESCRICAO.HeaderText = "Status Recebimento";
            this.tDF_MANIFESTACAO_DESCRICAO.Name = "tDF_MANIFESTACAO_DESCRICAO";
            this.tDF_MANIFESTACAO_DESCRICAO.ReadOnly = true;
            this.tDF_MANIFESTACAO_DESCRICAO.Width = 150;
            // 
            // tdf_ceop
            // 
            this.tdf_ceop.DataPropertyName = "df_cfop";
            this.tdf_ceop.HeaderText = "CFOP";
            this.tdf_ceop.Name = "tdf_ceop";
            this.tdf_ceop.ReadOnly = true;
            this.tdf_ceop.Width = 80;
            // 
            // cmdDocumentoFiscal_Registro_Consulta
            // 
            this.cmdDocumentoFiscal_Registro_Consulta.BackColor = System.Drawing.Color.White;
            this.cmdDocumentoFiscal_Registro_Consulta.CausesValidation = false;
            this.cmdDocumentoFiscal_Registro_Consulta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDocumentoFiscal_Registro_Consulta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDocumentoFiscal_Registro_Consulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDocumentoFiscal_Registro_Consulta.ForeColor = System.Drawing.Color.Blue;
            this.cmdDocumentoFiscal_Registro_Consulta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDocumentoFiscal_Registro_Consulta.Location = new System.Drawing.Point(986, 15);
            this.cmdDocumentoFiscal_Registro_Consulta.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDocumentoFiscal_Registro_Consulta.Name = "cmdDocumentoFiscal_Registro_Consulta";
            this.cmdDocumentoFiscal_Registro_Consulta.Size = new System.Drawing.Size(133, 37);
            this.cmdDocumentoFiscal_Registro_Consulta.TabIndex = 272;
            this.cmdDocumentoFiscal_Registro_Consulta.Text = "Buscar";
            this.cmdDocumentoFiscal_Registro_Consulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDocumentoFiscal_Registro_Consulta.UseVisualStyleBackColor = false;
            this.cmdDocumentoFiscal_Registro_Consulta.Click += new System.EventHandler(this.cmdDocumentoFiscal_Registro_Consulta_Click);
            // 
            // frm_DocumentoFiscalRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1287, 678);
            this.Controls.Add(this.cmdDocumentoFiscal_Registro_Consulta);
            this.Controls.Add(this.tabcontrol_doc_reg);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DocumentoFiscalRegistro";
            this.Text = "Pag | M4310";
            this.tabcontrol_doc_reg.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasFiscaisListas_Consulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.TabControl tabcontrol_doc_reg;
        private System.Windows.Forms.TabPage tabRecebimento;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_registro_data_fim;
        private System.Windows.Forms.DateTimePicker dtp_registro_data_ini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatusNfeManifestacao;
        private System.Windows.Forms.CheckBox chkRecebida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLancada;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgNotasFiscaisListas_Consulta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tNOME_RAZAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_cnpj_cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_dfr_nf_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_data_emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdfr_nf_chave;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDF_STATUS_RECEBIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDF_MANIFESTACAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDF_MANIFESTACAO_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdf_ceop;
        private System.Windows.Forms.Button cmdDocumentoFiscal_Registro_Consulta;
        
    }
}