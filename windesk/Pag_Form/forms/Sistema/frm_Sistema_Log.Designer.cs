namespace Pag_Form.forms.Sistema
{
    partial class frm_Sistema_Log
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtproc_log_seq = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.dtg_uuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtguuid_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlog_insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_sis_log_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_proc_log_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_sis_nucleo_prc_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_sis_batch_run_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_sis_log_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_sis_log_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.txtsis_batch_run_seq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsis_log_tag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsis_log_info = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.txtsis_nucleo_prc_cd_filter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttag = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsis_nucleo_prc_cd = new System.Windows.Forms.TextBox();
            this.txtdtlog_insert = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsis_log_seq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtuuid = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtuuid_start = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtuuid_start_filter = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // txtproc_log_seq
            // 
            this.txtproc_log_seq.AcceptsTab = true;
            this.txtproc_log_seq.Location = new System.Drawing.Point(280, 73);
            this.txtproc_log_seq.MaxLength = 60;
            this.txtproc_log_seq.Name = "txtproc_log_seq";
            this.txtproc_log_seq.Size = new System.Drawing.Size(86, 20);
            this.txtproc_log_seq.TabIndex = 814;
            this.txtproc_log_seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SlateGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(279, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 813;
            this.label14.Text = "Proc Log Seq";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            this.dtg.AllowUserToResizeRows = false;
            this.dtg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtg_uuid,
            this.dtguuid_start,
            this.dtlog_insert,
            this.dtg_sis_log_seq,
            this.dtg_proc_log_seq,
            this.dtg_sis_nucleo_prc_cd,
            this.dtg_sis_batch_run_seq,
            this.dtg_sis_log_tag,
            this.dtg_sis_log_info});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtg.Location = new System.Drawing.Point(3, 104);
            this.dtg.Name = "dtg";
            this.dtg.ReadOnly = true;
            this.dtg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtg.RowHeadersVisible = false;
            this.dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg.Size = new System.Drawing.Size(926, 303);
            this.dtg.TabIndex = 811;
            // 
            // dtg_uuid
            // 
            this.dtg_uuid.DataPropertyName = "uuid";
            this.dtg_uuid.HeaderText = "uuid";
            this.dtg_uuid.Name = "dtg_uuid";
            this.dtg_uuid.ReadOnly = true;
            this.dtg_uuid.Width = 45;
            // 
            // dtguuid_start
            // 
            this.dtguuid_start.DataPropertyName = "uuid_start";
            this.dtguuid_start.HeaderText = "uuid Start";
            this.dtguuid_start.Name = "dtguuid_start";
            this.dtguuid_start.ReadOnly = true;
            this.dtguuid_start.Width = 90;
            // 
            // dtlog_insert
            // 
            this.dtlog_insert.DataPropertyName = "dtlog_insert";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm:ss";
            this.dtlog_insert.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtlog_insert.HeaderText = "Log";
            this.dtlog_insert.Name = "dtlog_insert";
            this.dtlog_insert.ReadOnly = true;
            this.dtlog_insert.Width = 150;
            // 
            // dtg_sis_log_seq
            // 
            this.dtg_sis_log_seq.DataPropertyName = "sis_log_seq";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtg_sis_log_seq.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_sis_log_seq.HeaderText = "Seq";
            this.dtg_sis_log_seq.Name = "dtg_sis_log_seq";
            this.dtg_sis_log_seq.ReadOnly = true;
            this.dtg_sis_log_seq.Width = 45;
            // 
            // dtg_proc_log_seq
            // 
            this.dtg_proc_log_seq.DataPropertyName = "proc_log_seq";
            this.dtg_proc_log_seq.HeaderText = "Proc Log";
            this.dtg_proc_log_seq.Name = "dtg_proc_log_seq";
            this.dtg_proc_log_seq.ReadOnly = true;
            this.dtg_proc_log_seq.Width = 45;
            // 
            // dtg_sis_nucleo_prc_cd
            // 
            this.dtg_sis_nucleo_prc_cd.DataPropertyName = "sis_nucleo_prc_cd";
            this.dtg_sis_nucleo_prc_cd.HeaderText = "Nucleo Proc Cd";
            this.dtg_sis_nucleo_prc_cd.Name = "dtg_sis_nucleo_prc_cd";
            this.dtg_sis_nucleo_prc_cd.ReadOnly = true;
            this.dtg_sis_nucleo_prc_cd.Width = 45;
            // 
            // dtg_sis_batch_run_seq
            // 
            this.dtg_sis_batch_run_seq.DataPropertyName = "sis_batch_run_seq";
            this.dtg_sis_batch_run_seq.HeaderText = "Sis Batch Run Seq";
            this.dtg_sis_batch_run_seq.Name = "dtg_sis_batch_run_seq";
            this.dtg_sis_batch_run_seq.ReadOnly = true;
            this.dtg_sis_batch_run_seq.Width = 45;
            // 
            // dtg_sis_log_tag
            // 
            this.dtg_sis_log_tag.DataPropertyName = "sis_log_tag";
            this.dtg_sis_log_tag.HeaderText = "Tag";
            this.dtg_sis_log_tag.Name = "dtg_sis_log_tag";
            this.dtg_sis_log_tag.ReadOnly = true;
            this.dtg_sis_log_tag.Width = 150;
            // 
            // dtg_sis_log_info
            // 
            this.dtg_sis_log_info.DataPropertyName = "sis_log_info";
            this.dtg_sis_log_info.HeaderText = "Info";
            this.dtg_sis_log_info.Name = "dtg_sis_log_info";
            this.dtg_sis_log_info.ReadOnly = true;
            this.dtg_sis_log_info.Width = 250;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(926, 32);
            this.label12.TabIndex = 815;
            this.label12.Text = "Sistema Logs";
            // 
            // txtsis_batch_run_seq
            // 
            this.txtsis_batch_run_seq.AcceptsTab = true;
            this.txtsis_batch_run_seq.Location = new System.Drawing.Point(467, 72);
            this.txtsis_batch_run_seq.MaxLength = 60;
            this.txtsis_batch_run_seq.Name = "txtsis_batch_run_seq";
            this.txtsis_batch_run_seq.Size = new System.Drawing.Size(81, 20);
            this.txtsis_batch_run_seq.TabIndex = 817;
            this.txtsis_batch_run_seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(467, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 816;
            this.label1.Text = "Bath R Seq";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsis_log_tag
            // 
            this.txtsis_log_tag.AcceptsTab = true;
            this.txtsis_log_tag.Location = new System.Drawing.Point(554, 72);
            this.txtsis_log_tag.MaxLength = 60;
            this.txtsis_log_tag.Name = "txtsis_log_tag";
            this.txtsis_log_tag.Size = new System.Drawing.Size(117, 20);
            this.txtsis_log_tag.TabIndex = 819;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(554, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 818;
            this.label2.Text = "Log Tag";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsis_log_info
            // 
            this.txtsis_log_info.AcceptsTab = true;
            this.txtsis_log_info.Location = new System.Drawing.Point(676, 72);
            this.txtsis_log_info.MaxLength = 60;
            this.txtsis_log_info.Name = "txtsis_log_info";
            this.txtsis_log_info.Size = new System.Drawing.Size(138, 20);
            this.txtsis_log_info.TabIndex = 821;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(676, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 820;
            this.label3.Text = "Log Info";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(845, 8);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(81, 30);
            this.cmdsair.TabIndex = 823;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.White;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(763, 8);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(81, 30);
            this.cmdConsultar.TabIndex = 822;
            this.cmdConsultar.Text = "Buscar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // txtsis_nucleo_prc_cd_filter
            // 
            this.txtsis_nucleo_prc_cd_filter.AcceptsTab = true;
            this.txtsis_nucleo_prc_cd_filter.Location = new System.Drawing.Point(371, 73);
            this.txtsis_nucleo_prc_cd_filter.MaxLength = 60;
            this.txtsis_nucleo_prc_cd_filter.Name = "txtsis_nucleo_prc_cd_filter";
            this.txtsis_nucleo_prc_cd_filter.Size = new System.Drawing.Size(92, 20);
            this.txtsis_nucleo_prc_cd_filter.TabIndex = 825;
            this.txtsis_nucleo_prc_cd_filter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(370, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 824;
            this.label4.Text = "Nucleo Prc CD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicial.Location = new System.Drawing.Point(3, 73);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(132, 20);
            this.dtpDataInicial.TabIndex = 826;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 827;
            this.label5.Text = "Lançamento Inicial";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(141, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 829;
            this.label6.Text = "Lançamento Final";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFinal.Location = new System.Drawing.Point(141, 73);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(132, 20);
            this.dtpDataFinal.TabIndex = 828;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(451, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(478, 20);
            this.label7.TabIndex = 830;
            this.label7.Text = "Info";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtinfo
            // 
            this.txtinfo.AcceptsTab = true;
            this.txtinfo.BackColor = System.Drawing.Color.Silver;
            this.txtinfo.Location = new System.Drawing.Point(450, 433);
            this.txtinfo.MaxLength = 0;
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtinfo.Size = new System.Drawing.Size(479, 166);
            this.txtinfo.TabIndex = 831;
            this.txtinfo.Tag = "sis_log_info";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(269, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 20);
            this.label8.TabIndex = 832;
            this.label8.Text = "Tag";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txttag
            // 
            this.txttag.AcceptsTab = true;
            this.txttag.BackColor = System.Drawing.Color.Silver;
            this.txttag.Enabled = false;
            this.txttag.Location = new System.Drawing.Point(269, 433);
            this.txttag.MaxLength = 60;
            this.txttag.Multiline = true;
            this.txttag.Name = "txttag";
            this.txttag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txttag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txttag.Size = new System.Drawing.Size(178, 166);
            this.txttag.TabIndex = 833;
            this.txttag.Tag = "sis_log_tag";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SlateGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 456);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 20);
            this.label9.TabIndex = 834;
            this.label9.Text = "Nucleo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsis_nucleo_prc_cd
            // 
            this.txtsis_nucleo_prc_cd.AcceptsTab = true;
            this.txtsis_nucleo_prc_cd.BackColor = System.Drawing.Color.Silver;
            this.txtsis_nucleo_prc_cd.Enabled = false;
            this.txtsis_nucleo_prc_cd.Location = new System.Drawing.Point(3, 479);
            this.txtsis_nucleo_prc_cd.MaxLength = 60;
            this.txtsis_nucleo_prc_cd.Name = "txtsis_nucleo_prc_cd";
            this.txtsis_nucleo_prc_cd.Size = new System.Drawing.Size(260, 20);
            this.txtsis_nucleo_prc_cd.TabIndex = 835;
            this.txtsis_nucleo_prc_cd.Tag = "sis_nucleo_prc_cd";
            this.txtsis_nucleo_prc_cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtdtlog_insert
            // 
            this.txtdtlog_insert.AcceptsTab = true;
            this.txtdtlog_insert.BackColor = System.Drawing.Color.Silver;
            this.txtdtlog_insert.Enabled = false;
            this.txtdtlog_insert.Location = new System.Drawing.Point(3, 433);
            this.txtdtlog_insert.MaxLength = 60;
            this.txtdtlog_insert.Name = "txtdtlog_insert";
            this.txtdtlog_insert.Size = new System.Drawing.Size(132, 20);
            this.txtdtlog_insert.TabIndex = 837;
            this.txtdtlog_insert.Tag = "dtlog_insert";
            this.txtdtlog_insert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 836;
            this.label10.Text = "Log";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsis_log_seq
            // 
            this.txtsis_log_seq.AcceptsTab = true;
            this.txtsis_log_seq.BackColor = System.Drawing.Color.Silver;
            this.txtsis_log_seq.Enabled = false;
            this.txtsis_log_seq.Location = new System.Drawing.Point(141, 433);
            this.txtsis_log_seq.MaxLength = 60;
            this.txtsis_log_seq.Name = "txtsis_log_seq";
            this.txtsis_log_seq.Size = new System.Drawing.Size(122, 20);
            this.txtsis_log_seq.TabIndex = 839;
            this.txtsis_log_seq.Tag = "sis_log_seq";
            this.txtsis_log_seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SlateGray;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(141, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 838;
            this.label11.Text = "Sequencial";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtuuid
            // 
            this.txtuuid.AcceptsTab = true;
            this.txtuuid.BackColor = System.Drawing.Color.Silver;
            this.txtuuid.Enabled = false;
            this.txtuuid.Location = new System.Drawing.Point(3, 525);
            this.txtuuid.MaxLength = 60;
            this.txtuuid.Name = "txtuuid";
            this.txtuuid.Size = new System.Drawing.Size(260, 20);
            this.txtuuid.TabIndex = 841;
            this.txtuuid.Tag = "uuid";
            this.txtuuid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SlateGray;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 502);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(260, 20);
            this.label13.TabIndex = 840;
            this.label13.Text = "uuid";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtuuid_start
            // 
            this.txtuuid_start.AcceptsTab = true;
            this.txtuuid_start.BackColor = System.Drawing.Color.Silver;
            this.txtuuid_start.Location = new System.Drawing.Point(3, 571);
            this.txtuuid_start.MaxLength = 60;
            this.txtuuid_start.Name = "txtuuid_start";
            this.txtuuid_start.Size = new System.Drawing.Size(260, 20);
            this.txtuuid_start.TabIndex = 843;
            this.txtuuid_start.Tag = "uuid_start";
            this.txtuuid_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SlateGray;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 548);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 20);
            this.label15.TabIndex = 842;
            this.label15.Text = "uuid start";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtuuid_start_filter
            // 
            this.txtuuid_start_filter.AcceptsTab = true;
            this.txtuuid_start_filter.Location = new System.Drawing.Point(820, 72);
            this.txtuuid_start_filter.MaxLength = 30;
            this.txtuuid_start_filter.Name = "txtuuid_start_filter";
            this.txtuuid_start_filter.Size = new System.Drawing.Size(109, 20);
            this.txtuuid_start_filter.TabIndex = 845;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.SlateGray;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(820, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 20);
            this.label16.TabIndex = 844;
            this.label16.Text = "uuid start";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_Sistema_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.txtuuid_start_filter);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtuuid_start);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtuuid);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtsis_log_seq);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtdtlog_insert);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtsis_nucleo_prc_cd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txttag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtinfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDataInicial);
            this.Controls.Add(this.txtsis_nucleo_prc_cd_filter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.txtsis_log_info);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsis_log_tag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsis_batch_run_seq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtproc_log_seq);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dtg);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Sistema_Log";
            this.Text = "Sistema - Log";
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtproc_log_seq;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtsis_batch_run_seq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsis_log_tag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsis_log_info;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.TextBox txtsis_nucleo_prc_cd_filter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtinfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtsis_nucleo_prc_cd;
        private System.Windows.Forms.TextBox txtdtlog_insert;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtsis_log_seq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtuuid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtuuid_start;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtuuid_start_filter;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_uuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtguuid_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlog_insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_sis_log_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_proc_log_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_sis_nucleo_prc_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_sis_batch_run_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_sis_log_tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_sis_log_info;
    }
}