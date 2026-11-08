namespace Pag_Form.forms.Loja.Preco
{
    partial class frm_ProdutoPrecoLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.dtpData_Aplicacao_Fim = new System.Windows.Forms.DateTimePicker();
            this.dtpData_Aplicacao_Ini = new System.Windows.Forms.DateTimePicker();
            this.label36 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTabelaPrecificacao = new System.Windows.Forms.ComboBox();
            this.dtgPrecoLog = new System.Windows.Forms.DataGridView();
            this.dtgPrecoLog_proc_log_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_dtlog_insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_sis_us_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_prc_data_aplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_Agendamento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgPreco_Log_prca_dt_validade_agendamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_tab_pre_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgPrecoLog_pr_cdproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgPrecoLog__prb_cdprodutobluesoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgPrecoLog__pr_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_prb_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgPrecoLog_pr_embalagemestoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_prc_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecoLog_prc_valor_promocional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAtualiza = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcdprodutobluesoft = new System.Windows.Forms.TextBox();
            this.txtcdproduto = new System.Windows.Forms.TextBox();
            this.txtdescricao = new System.Windows.Forms.TextBox();
            this.cmdAtualizaBlueSoftD1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdAtualizaBlueSoftGeral = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrecoLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(3, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1012, 35);
            this.label12.TabIndex = 204;
            this.label12.Text = "Produto | Preços - Consulta de Logs de Alterações";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.SlateGray;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(306, 71);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(38, 21);
            this.label35.TabIndex = 337;
            this.label35.Text = "à";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpData_Aplicacao_Fim
            // 
            this.dtpData_Aplicacao_Fim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData_Aplicacao_Fim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData_Aplicacao_Fim.Location = new System.Drawing.Point(350, 71);
            this.dtpData_Aplicacao_Fim.Name = "dtpData_Aplicacao_Fim";
            this.dtpData_Aplicacao_Fim.Size = new System.Drawing.Size(105, 21);
            this.dtpData_Aplicacao_Fim.TabIndex = 336;
            // 
            // dtpData_Aplicacao_Ini
            // 
            this.dtpData_Aplicacao_Ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData_Aplicacao_Ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData_Aplicacao_Ini.Location = new System.Drawing.Point(198, 71);
            this.dtpData_Aplicacao_Ini.Name = "dtpData_Aplicacao_Ini";
            this.dtpData_Aplicacao_Ini.Size = new System.Drawing.Size(102, 21);
            this.dtpData_Aplicacao_Ini.TabIndex = 335;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.SlateGray;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(198, 46);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(257, 21);
            this.label36.TabIndex = 334;
            this.label36.Text = "Data da Alteração";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 21);
            this.label2.TabIndex = 332;
            this.label2.Text = "Tabela Operacional";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTabelaPrecificacao
            // 
            this.cmbTabelaPrecificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabelaPrecificacao.FormattingEnabled = true;
            this.cmbTabelaPrecificacao.Location = new System.Drawing.Point(4, 71);
            this.cmbTabelaPrecificacao.Name = "cmbTabelaPrecificacao";
            this.cmbTabelaPrecificacao.Size = new System.Drawing.Size(188, 21);
            this.cmbTabelaPrecificacao.TabIndex = 331;
            // 
            // dtgPrecoLog
            // 
            this.dtgPrecoLog.AllowUserToAddRows = false;
            this.dtgPrecoLog.AllowUserToDeleteRows = false;
            this.dtgPrecoLog.AllowUserToResizeRows = false;
            this.dtgPrecoLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPrecoLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dtgPrecoLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrecoLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgPrecoLog_proc_log_seq,
            this.dtgPrecoLog_dtlog_insert,
            this.dtgPrecoLog_sis_us_seq,
            this.dtgPrecoLog_user_name,
            this.dtgPrecoLog_prc_data_aplicacao,
            this.dtgPrecoLog_Agendamento,
            this.dtgPreco_Log_prca_dt_validade_agendamento,
            this.dtgPrecoLog_tab_pre_cd,
            this.DtgPrecoLog_pr_cdproduto,
            this.DtgPrecoLog__prb_cdprodutobluesoft,
            this.DtgPrecoLog__pr_descricao,
            this.dtgPrecoLog_prb_descricao,
            this.DtgPrecoLog_pr_embalagemestoque,
            this.dtgPrecoLog_prc_valor,
            this.dtgPrecoLog_prc_valor_promocional});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPrecoLog.DefaultCellStyle = dataGridViewCellStyle26;
            this.dtgPrecoLog.Location = new System.Drawing.Point(3, 98);
            this.dtgPrecoLog.Name = "dtgPrecoLog";
            this.dtgPrecoLog.ReadOnly = true;
            this.dtgPrecoLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPrecoLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dtgPrecoLog.RowHeadersVisible = false;
            this.dtgPrecoLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrecoLog.Size = new System.Drawing.Size(1012, 275);
            this.dtgPrecoLog.TabIndex = 338;
            // 
            // dtgPrecoLog_proc_log_seq
            // 
            this.dtgPrecoLog_proc_log_seq.DataPropertyName = "proc_log_seq";
            this.dtgPrecoLog_proc_log_seq.Frozen = true;
            this.dtgPrecoLog_proc_log_seq.HeaderText = "Log Seq";
            this.dtgPrecoLog_proc_log_seq.Name = "dtgPrecoLog_proc_log_seq";
            this.dtgPrecoLog_proc_log_seq.ReadOnly = true;
            this.dtgPrecoLog_proc_log_seq.Width = 10;
            // 
            // dtgPrecoLog_dtlog_insert
            // 
            this.dtgPrecoLog_dtlog_insert.DataPropertyName = "dtlog_insert";
            dataGridViewCellStyle20.Format = "dd/MM/yyyy HH:mm";
            this.dtgPrecoLog_dtlog_insert.DefaultCellStyle = dataGridViewCellStyle20;
            this.dtgPrecoLog_dtlog_insert.Frozen = true;
            this.dtgPrecoLog_dtlog_insert.HeaderText = "Log Insert";
            this.dtgPrecoLog_dtlog_insert.Name = "dtgPrecoLog_dtlog_insert";
            this.dtgPrecoLog_dtlog_insert.ReadOnly = true;
            // 
            // dtgPrecoLog_sis_us_seq
            // 
            this.dtgPrecoLog_sis_us_seq.DataPropertyName = "sis_us_seq";
            this.dtgPrecoLog_sis_us_seq.Frozen = true;
            this.dtgPrecoLog_sis_us_seq.HeaderText = "Usuário Seq";
            this.dtgPrecoLog_sis_us_seq.Name = "dtgPrecoLog_sis_us_seq";
            this.dtgPrecoLog_sis_us_seq.ReadOnly = true;
            this.dtgPrecoLog_sis_us_seq.Width = 5;
            // 
            // dtgPrecoLog_user_name
            // 
            this.dtgPrecoLog_user_name.DataPropertyName = "user_name";
            this.dtgPrecoLog_user_name.Frozen = true;
            this.dtgPrecoLog_user_name.HeaderText = "User Name";
            this.dtgPrecoLog_user_name.Name = "dtgPrecoLog_user_name";
            this.dtgPrecoLog_user_name.ReadOnly = true;
            this.dtgPrecoLog_user_name.Width = 80;
            // 
            // dtgPrecoLog_prc_data_aplicacao
            // 
            this.dtgPrecoLog_prc_data_aplicacao.DataPropertyName = "prc_data_aplicacao";
            this.dtgPrecoLog_prc_data_aplicacao.Frozen = true;
            this.dtgPrecoLog_prc_data_aplicacao.HeaderText = "Aplicação";
            this.dtgPrecoLog_prc_data_aplicacao.Name = "dtgPrecoLog_prc_data_aplicacao";
            this.dtgPrecoLog_prc_data_aplicacao.ReadOnly = true;
            this.dtgPrecoLog_prc_data_aplicacao.Width = 80;
            // 
            // dtgPrecoLog_Agendamento
            // 
            this.dtgPrecoLog_Agendamento.DataPropertyName = "agendamento";
            this.dtgPrecoLog_Agendamento.FalseValue = "0";
            this.dtgPrecoLog_Agendamento.Frozen = true;
            this.dtgPrecoLog_Agendamento.HeaderText = "Tipo Agendamento";
            this.dtgPrecoLog_Agendamento.Name = "dtgPrecoLog_Agendamento";
            this.dtgPrecoLog_Agendamento.ReadOnly = true;
            this.dtgPrecoLog_Agendamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPrecoLog_Agendamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgPrecoLog_Agendamento.TrueValue = "1";
            this.dtgPrecoLog_Agendamento.Width = 45;
            // 
            // dtgPreco_Log_prca_dt_validade_agendamento
            // 
            this.dtgPreco_Log_prca_dt_validade_agendamento.DataPropertyName = "prca_dt_validade_agendamento";
            this.dtgPreco_Log_prca_dt_validade_agendamento.Frozen = true;
            this.dtgPreco_Log_prca_dt_validade_agendamento.HeaderText = "Data Agendamento";
            this.dtgPreco_Log_prca_dt_validade_agendamento.Name = "dtgPreco_Log_prca_dt_validade_agendamento";
            this.dtgPreco_Log_prca_dt_validade_agendamento.ReadOnly = true;
            this.dtgPreco_Log_prca_dt_validade_agendamento.Width = 80;
            // 
            // dtgPrecoLog_tab_pre_cd
            // 
            this.dtgPrecoLog_tab_pre_cd.DataPropertyName = "tab_pre_cd";
            this.dtgPrecoLog_tab_pre_cd.Frozen = true;
            this.dtgPrecoLog_tab_pre_cd.HeaderText = "Tab";
            this.dtgPrecoLog_tab_pre_cd.Name = "dtgPrecoLog_tab_pre_cd";
            this.dtgPrecoLog_tab_pre_cd.ReadOnly = true;
            this.dtgPrecoLog_tab_pre_cd.Width = 35;
            // 
            // DtgPrecoLog_pr_cdproduto
            // 
            this.DtgPrecoLog_pr_cdproduto.DataPropertyName = "pr_cdproduto";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DtgPrecoLog_pr_cdproduto.DefaultCellStyle = dataGridViewCellStyle21;
            this.DtgPrecoLog_pr_cdproduto.Frozen = true;
            this.DtgPrecoLog_pr_cdproduto.HeaderText = "Cód Pag";
            this.DtgPrecoLog_pr_cdproduto.Name = "DtgPrecoLog_pr_cdproduto";
            this.DtgPrecoLog_pr_cdproduto.ReadOnly = true;
            this.DtgPrecoLog_pr_cdproduto.Width = 45;
            // 
            // DtgPrecoLog__prb_cdprodutobluesoft
            // 
            this.DtgPrecoLog__prb_cdprodutobluesoft.DataPropertyName = "prb_cdprodutobluesoft";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DtgPrecoLog__prb_cdprodutobluesoft.DefaultCellStyle = dataGridViewCellStyle22;
            this.DtgPrecoLog__prb_cdprodutobluesoft.Frozen = true;
            this.DtgPrecoLog__prb_cdprodutobluesoft.HeaderText = "Cód Blue";
            this.DtgPrecoLog__prb_cdprodutobluesoft.Name = "DtgPrecoLog__prb_cdprodutobluesoft";
            this.DtgPrecoLog__prb_cdprodutobluesoft.ReadOnly = true;
            this.DtgPrecoLog__prb_cdprodutobluesoft.Width = 45;
            // 
            // DtgPrecoLog__pr_descricao
            // 
            this.DtgPrecoLog__pr_descricao.DataPropertyName = "pr_descricao";
            this.DtgPrecoLog__pr_descricao.Frozen = true;
            this.DtgPrecoLog__pr_descricao.HeaderText = "Desc Unit";
            this.DtgPrecoLog__pr_descricao.Name = "DtgPrecoLog__pr_descricao";
            this.DtgPrecoLog__pr_descricao.ReadOnly = true;
            this.DtgPrecoLog__pr_descricao.Width = 30;
            // 
            // dtgPrecoLog_prb_descricao
            // 
            this.dtgPrecoLog_prb_descricao.DataPropertyName = "prb_descricao";
            this.dtgPrecoLog_prb_descricao.Frozen = true;
            this.dtgPrecoLog_prb_descricao.HeaderText = "Descrição";
            this.dtgPrecoLog_prb_descricao.Name = "dtgPrecoLog_prb_descricao";
            this.dtgPrecoLog_prb_descricao.ReadOnly = true;
            this.dtgPrecoLog_prb_descricao.Width = 270;
            // 
            // DtgPrecoLog_pr_embalagemestoque
            // 
            this.DtgPrecoLog_pr_embalagemestoque.DataPropertyName = "pr_embalagemestoque";
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = null;
            this.DtgPrecoLog_pr_embalagemestoque.DefaultCellStyle = dataGridViewCellStyle23;
            this.DtgPrecoLog_pr_embalagemestoque.Frozen = true;
            this.DtgPrecoLog_pr_embalagemestoque.HeaderText = "";
            this.DtgPrecoLog_pr_embalagemestoque.Name = "DtgPrecoLog_pr_embalagemestoque";
            this.DtgPrecoLog_pr_embalagemestoque.ReadOnly = true;
            this.DtgPrecoLog_pr_embalagemestoque.Width = 25;
            // 
            // dtgPrecoLog_prc_valor
            // 
            this.dtgPrecoLog_prc_valor.DataPropertyName = "prc_valor";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            this.dtgPrecoLog_prc_valor.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgPrecoLog_prc_valor.FillWeight = 70F;
            this.dtgPrecoLog_prc_valor.HeaderText = "Preço";
            this.dtgPrecoLog_prc_valor.Name = "dtgPrecoLog_prc_valor";
            this.dtgPrecoLog_prc_valor.ReadOnly = true;
            this.dtgPrecoLog_prc_valor.Width = 65;
            // 
            // dtgPrecoLog_prc_valor_promocional
            // 
            this.dtgPrecoLog_prc_valor_promocional.DataPropertyName = "prc_valor_promocional";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N2";
            this.dtgPrecoLog_prc_valor_promocional.DefaultCellStyle = dataGridViewCellStyle25;
            this.dtgPrecoLog_prc_valor_promocional.FillWeight = 70F;
            this.dtgPrecoLog_prc_valor_promocional.HeaderText = "Preço Prom.";
            this.dtgPrecoLog_prc_valor_promocional.Name = "dtgPrecoLog_prc_valor_promocional";
            this.dtgPrecoLog_prc_valor_promocional.ReadOnly = true;
            this.dtgPrecoLog_prc_valor_promocional.Width = 65;
            // 
            // cmdAtualiza
            // 
            this.cmdAtualiza.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdAtualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAtualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAtualiza.ForeColor = System.Drawing.Color.Blue;
            this.cmdAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAtualiza.Location = new System.Drawing.Point(809, 4);
            this.cmdAtualiza.Name = "cmdAtualiza";
            this.cmdAtualiza.Size = new System.Drawing.Size(100, 30);
            this.cmdAtualiza.TabIndex = 340;
            this.cmdAtualiza.Text = "Pesquisar";
            this.cmdAtualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAtualiza.UseVisualStyleBackColor = false;
            this.cmdAtualiza.Click += new System.EventHandler(this.cmdAtualiza_Click);
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(911, 4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 339;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(666, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 21);
            this.label8.TabIndex = 346;
            this.label8.Text = "Descrição";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(566, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 345;
            this.label6.Text = "Código Blue";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(466, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 344;
            this.label5.Text = "Código Pag";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcdprodutobluesoft
            // 
            this.txtcdprodutobluesoft.Location = new System.Drawing.Point(566, 69);
            this.txtcdprodutobluesoft.Name = "txtcdprodutobluesoft";
            this.txtcdprodutobluesoft.Size = new System.Drawing.Size(95, 20);
            this.txtcdprodutobluesoft.TabIndex = 342;
            this.txtcdprodutobluesoft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcdproduto
            // 
            this.txtcdproduto.AcceptsTab = true;
            this.txtcdproduto.Location = new System.Drawing.Point(465, 69);
            this.txtcdproduto.Name = "txtcdproduto";
            this.txtcdproduto.Size = new System.Drawing.Size(95, 20);
            this.txtcdproduto.TabIndex = 341;
            this.txtcdproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtdescricao
            // 
            this.txtdescricao.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtdescricao.Location = new System.Drawing.Point(666, 69);
            this.txtdescricao.Name = "txtdescricao";
            this.txtdescricao.Size = new System.Drawing.Size(230, 20);
            this.txtdescricao.TabIndex = 343;
            // 
            // cmdAtualizaBlueSoftD1
            // 
            this.cmdAtualizaBlueSoftD1.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdAtualizaBlueSoftD1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAtualizaBlueSoftD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAtualizaBlueSoftD1.ForeColor = System.Drawing.Color.Blue;
            this.cmdAtualizaBlueSoftD1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAtualizaBlueSoftD1.Location = new System.Drawing.Point(976, 376);
            this.cmdAtualizaBlueSoftD1.Name = "cmdAtualizaBlueSoftD1";
            this.cmdAtualizaBlueSoftD1.Size = new System.Drawing.Size(39, 30);
            this.cmdAtualizaBlueSoftD1.TabIndex = 348;
            this.cmdAtualizaBlueSoftD1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAtualizaBlueSoftD1.UseVisualStyleBackColor = false;
            this.cmdAtualizaBlueSoftD1.Click += new System.EventHandler(this.cmdAtualizaBlueSoftD1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(611, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 38);
            this.label4.TabIndex = 347;
            this.label4.Text = "Gerar Batch para integrar preços (NÃO PROMOCIONAIS) com a Bluesoft alterados em D" +
    "1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdAtualizaBlueSoftGeral
            // 
            this.cmdAtualizaBlueSoftGeral.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdAtualizaBlueSoftGeral.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAtualizaBlueSoftGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAtualizaBlueSoftGeral.ForeColor = System.Drawing.Color.Blue;
            this.cmdAtualizaBlueSoftGeral.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAtualizaBlueSoftGeral.Location = new System.Drawing.Point(976, 418);
            this.cmdAtualizaBlueSoftGeral.Name = "cmdAtualizaBlueSoftGeral";
            this.cmdAtualizaBlueSoftGeral.Size = new System.Drawing.Size(39, 30);
            this.cmdAtualizaBlueSoftGeral.TabIndex = 350;
            this.cmdAtualizaBlueSoftGeral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAtualizaBlueSoftGeral.UseVisualStyleBackColor = false;
            this.cmdAtualizaBlueSoftGeral.Click += new System.EventHandler(this.cmdAtualizaBlueSoftGeral_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(611, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 39);
            this.label1.TabIndex = 349;
            this.label1.Text = "Gerar Batch para integrar preços (NÃO PROMOCIONAIS) com a Bluesoft alterados (TOD" +
    "OS OS ITENS)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_ProdutoPrecoLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1020, 474);
            this.Controls.Add(this.cmdAtualizaBlueSoftGeral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdAtualizaBlueSoftD1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcdprodutobluesoft);
            this.Controls.Add(this.txtcdproduto);
            this.Controls.Add(this.txtdescricao);
            this.Controls.Add(this.cmdAtualiza);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.dtgPrecoLog);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.dtpData_Aplicacao_Fim);
            this.Controls.Add(this.dtpData_Aplicacao_Ini);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTabelaPrecificacao);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ProdutoPrecoLog";
            this.Text = "frm_ProdutoPrecoLog";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrecoLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DateTimePicker dtpData_Aplicacao_Fim;
        private System.Windows.Forms.DateTimePicker dtpData_Aplicacao_Ini;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTabelaPrecificacao;
        private System.Windows.Forms.DataGridView dtgPrecoLog;
        private System.Windows.Forms.Button cmdAtualiza;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcdprodutobluesoft;
        private System.Windows.Forms.TextBox txtcdproduto;
        private System.Windows.Forms.TextBox txtdescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_proc_log_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_dtlog_insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_sis_us_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_prc_data_aplicacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgPrecoLog_Agendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_Log_prca_dt_validade_agendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_tab_pre_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgPrecoLog_pr_cdproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgPrecoLog__prb_cdprodutobluesoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgPrecoLog__pr_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_prb_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgPrecoLog_pr_embalagemestoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_prc_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecoLog_prc_valor_promocional;
        private System.Windows.Forms.Button cmdAtualizaBlueSoftD1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdAtualizaBlueSoftGeral;
        private System.Windows.Forms.Label label1;
    }
}