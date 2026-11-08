namespace Pag_Form.forms.Cadastros.Visualizacao.Notificacao
{
    partial class m1911_Notificacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblwait = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.dtg_notificacao_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_notificacao_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_notificacao_send_tipo_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_notificacao_send_tipo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbldtg_total = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgp = new System.Windows.Forms.DataGridView();
            this.dtgp_notificacao_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgp_cdparticipante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgp_nome_razao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgp_celular_dd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgp_celular_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgp_mail_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_notificacao_cd = new System.Windows.Forms.Label();
            this.lbl_notificacao_descricao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldtgp_total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdDetalheNotificacao = new System.Windows.Forms.Button();
            this.cmdAdicionar = new System.Windows.Forms.Button();
            this.cmdExcluir = new System.Windows.Forms.Button();
            this.lbl_cdparticipante = new System.Windows.Forms.Label();
            this.lbl_nome_razao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblwait
            // 
            this.lblwait.BackColor = System.Drawing.Color.Red;
            this.lblwait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait.ForeColor = System.Drawing.Color.White;
            this.lblwait.Location = new System.Drawing.Point(409, 17);
            this.lblwait.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(403, 25);
            this.lblwait.TabIndex = 903;
            this.lblwait.Text = "Processando dados...";
            this.lblwait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(977, 13);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 904;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(843, 13);
            this.cmdConsultar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(133, 37);
            this.cmdConsultar.TabIndex = 901;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(13, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1102, 43);
            this.label12.TabIndex = 902;
            this.label12.Text = "Notificações";
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            this.dtg.AllowUserToResizeRows = false;
            this.dtg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtg_notificacao_cd,
            this.dtg_notificacao_descricao,
            this.dtg_notificacao_send_tipo_cd,
            this.dtg_notificacao_send_tipo_descricao});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg.DefaultCellStyle = dataGridViewCellStyle19;
            this.dtg.Location = new System.Drawing.Point(13, 56);
            this.dtg.Margin = new System.Windows.Forms.Padding(4);
            this.dtg.Name = "dtg";
            this.dtg.ReadOnly = true;
            this.dtg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dtg.RowHeadersVisible = false;
            this.dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg.Size = new System.Drawing.Size(1102, 230);
            this.dtg.TabIndex = 905;
            // 
            // dtg_notificacao_cd
            // 
            this.dtg_notificacao_cd.DataPropertyName = "notificacao_cd";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtg_notificacao_cd.DefaultCellStyle = dataGridViewCellStyle18;
            this.dtg_notificacao_cd.HeaderText = "Cod Notificação";
            this.dtg_notificacao_cd.Name = "dtg_notificacao_cd";
            this.dtg_notificacao_cd.ReadOnly = true;
            this.dtg_notificacao_cd.Width = 50;
            // 
            // dtg_notificacao_descricao
            // 
            this.dtg_notificacao_descricao.DataPropertyName = "notificacao_descricao";
            this.dtg_notificacao_descricao.HeaderText = "Descrição";
            this.dtg_notificacao_descricao.Name = "dtg_notificacao_descricao";
            this.dtg_notificacao_descricao.ReadOnly = true;
            this.dtg_notificacao_descricao.Width = 450;
            // 
            // dtg_notificacao_send_tipo_cd
            // 
            this.dtg_notificacao_send_tipo_cd.DataPropertyName = "notificacao_send_tipo_cd";
            this.dtg_notificacao_send_tipo_cd.HeaderText = "Tipo de Envio (send)";
            this.dtg_notificacao_send_tipo_cd.Name = "dtg_notificacao_send_tipo_cd";
            this.dtg_notificacao_send_tipo_cd.ReadOnly = true;
            // 
            // dtg_notificacao_send_tipo_descricao
            // 
            this.dtg_notificacao_send_tipo_descricao.DataPropertyName = "notificacao_send_tipo_descricao";
            this.dtg_notificacao_send_tipo_descricao.HeaderText = "Tipo de Envio Descrição";
            this.dtg_notificacao_send_tipo_descricao.Name = "dtg_notificacao_send_tipo_descricao";
            this.dtg_notificacao_send_tipo_descricao.ReadOnly = true;
            this.dtg_notificacao_send_tipo_descricao.Width = 250;
            // 
            // lbldtg_total
            // 
            this.lbldtg_total.BackColor = System.Drawing.Color.SlateGray;
            this.lbldtg_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldtg_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldtg_total.ForeColor = System.Drawing.Color.White;
            this.lbldtg_total.Location = new System.Drawing.Point(175, 290);
            this.lbldtg_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldtg_total.Name = "lbldtg_total";
            this.lbldtg_total.Size = new System.Drawing.Size(85, 25);
            this.lbldtg_total.TabIndex = 907;
            this.lbldtg_total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 290);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 25);
            this.label7.TabIndex = 906;
            this.label7.Text = "Total de Registros";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgp
            // 
            this.dtgp.AllowUserToAddRows = false;
            this.dtgp.AllowUserToDeleteRows = false;
            this.dtgp.AllowUserToResizeRows = false;
            this.dtgp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dtgp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgp_notificacao_cd,
            this.dtgp_cdparticipante,
            this.dtgp_nome_razao,
            this.dtgp_celular_dd,
            this.dtgp_celular_numero,
            this.dtgp_mail_main});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgp.DefaultCellStyle = dataGridViewCellStyle23;
            this.dtgp.Location = new System.Drawing.Point(332, 356);
            this.dtgp.Margin = new System.Windows.Forms.Padding(4);
            this.dtgp.Name = "dtgp";
            this.dtgp.ReadOnly = true;
            this.dtgp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgp.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dtgp.RowHeadersVisible = false;
            this.dtgp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgp.Size = new System.Drawing.Size(734, 230);
            this.dtgp.TabIndex = 908;
            // 
            // dtgp_notificacao_cd
            // 
            this.dtgp_notificacao_cd.DataPropertyName = "notificacao_cd";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgp_notificacao_cd.DefaultCellStyle = dataGridViewCellStyle22;
            this.dtgp_notificacao_cd.HeaderText = "Cod Notificação";
            this.dtgp_notificacao_cd.Name = "dtgp_notificacao_cd";
            this.dtgp_notificacao_cd.ReadOnly = true;
            this.dtgp_notificacao_cd.Width = 50;
            // 
            // dtgp_cdparticipante
            // 
            this.dtgp_cdparticipante.DataPropertyName = "cdparticipante";
            this.dtgp_cdparticipante.HeaderText = "Cd Part.";
            this.dtgp_cdparticipante.Name = "dtgp_cdparticipante";
            this.dtgp_cdparticipante.ReadOnly = true;
            this.dtgp_cdparticipante.Width = 60;
            // 
            // dtgp_nome_razao
            // 
            this.dtgp_nome_razao.DataPropertyName = "nome_razao";
            this.dtgp_nome_razao.HeaderText = "Nome";
            this.dtgp_nome_razao.Name = "dtgp_nome_razao";
            this.dtgp_nome_razao.ReadOnly = true;
            this.dtgp_nome_razao.Width = 250;
            // 
            // dtgp_celular_dd
            // 
            this.dtgp_celular_dd.DataPropertyName = "celular_dd";
            this.dtgp_celular_dd.HeaderText = "Cel dd";
            this.dtgp_celular_dd.Name = "dtgp_celular_dd";
            this.dtgp_celular_dd.ReadOnly = true;
            this.dtgp_celular_dd.Width = 45;
            // 
            // dtgp_celular_numero
            // 
            this.dtgp_celular_numero.DataPropertyName = "celular_numero";
            this.dtgp_celular_numero.HeaderText = "Cel Número";
            this.dtgp_celular_numero.Name = "dtgp_celular_numero";
            this.dtgp_celular_numero.ReadOnly = true;
            this.dtgp_celular_numero.Width = 75;
            // 
            // dtgp_mail_main
            // 
            this.dtgp_mail_main.DataPropertyName = "mail_main";
            this.dtgp_mail_main.HeaderText = "E-mail";
            this.dtgp_mail_main.Name = "dtgp_mail_main";
            this.dtgp_mail_main.ReadOnly = true;
            this.dtgp_mail_main.Width = 250;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(332, 325);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(778, 27);
            this.label13.TabIndex = 909;
            this.label13.Text = "Destinatários Pré Cadastrados";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 290);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 910;
            this.label1.Text = "Notificação";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_notificacao_cd
            // 
            this.lbl_notificacao_cd.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_notificacao_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_notificacao_cd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notificacao_cd.ForeColor = System.Drawing.Color.White;
            this.lbl_notificacao_cd.Location = new System.Drawing.Point(437, 290);
            this.lbl_notificacao_cd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_notificacao_cd.Name = "lbl_notificacao_cd";
            this.lbl_notificacao_cd.Size = new System.Drawing.Size(61, 25);
            this.lbl_notificacao_cd.TabIndex = 911;
            this.lbl_notificacao_cd.Tag = "notificacao_cd";
            this.lbl_notificacao_cd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_notificacao_cd.TextChanged += new System.EventHandler(this.lbl_notificacao_cd_TextChanged);
            // 
            // lbl_notificacao_descricao
            // 
            this.lbl_notificacao_descricao.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_notificacao_descricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_notificacao_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notificacao_descricao.ForeColor = System.Drawing.Color.White;
            this.lbl_notificacao_descricao.Location = new System.Drawing.Point(605, 290);
            this.lbl_notificacao_descricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_notificacao_descricao.Name = "lbl_notificacao_descricao";
            this.lbl_notificacao_descricao.Size = new System.Drawing.Size(348, 25);
            this.lbl_notificacao_descricao.TabIndex = 913;
            this.lbl_notificacao_descricao.Tag = "notificacao_descricao";
            this.lbl_notificacao_descricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(502, 290);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 912;
            this.label3.Text = "Descrição";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbldtgp_total
            // 
            this.lbldtgp_total.BackColor = System.Drawing.Color.SlateGray;
            this.lbldtgp_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldtgp_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldtgp_total.ForeColor = System.Drawing.Color.White;
            this.lbldtgp_total.Location = new System.Drawing.Point(451, 590);
            this.lbldtgp_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldtgp_total.Name = "lbldtgp_total";
            this.lbldtgp_total.Size = new System.Drawing.Size(85, 25);
            this.lbldtgp_total.TabIndex = 915;
            this.lbldtgp_total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(332, 590);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 25);
            this.label5.TabIndex = 914;
            this.label5.Text = "Total de Parts";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdDetalheNotificacao
            // 
            this.cmdDetalheNotificacao.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdDetalheNotificacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDetalheNotificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetalheNotificacao.ForeColor = System.Drawing.Color.Blue;
            this.cmdDetalheNotificacao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDetalheNotificacao.Location = new System.Drawing.Point(1048, 286);
            this.cmdDetalheNotificacao.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDetalheNotificacao.Name = "cmdDetalheNotificacao";
            this.cmdDetalheNotificacao.Size = new System.Drawing.Size(62, 37);
            this.cmdDetalheNotificacao.TabIndex = 916;
            this.cmdDetalheNotificacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDetalheNotificacao.UseVisualStyleBackColor = false;
            this.cmdDetalheNotificacao.Click += new System.EventHandler(this.cmdDetalheNotificacao_Click);
            // 
            // cmdAdicionar
            // 
            this.cmdAdicionar.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdicionar.ForeColor = System.Drawing.Color.Blue;
            this.cmdAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAdicionar.Location = new System.Drawing.Point(1072, 397);
            this.cmdAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAdicionar.Name = "cmdAdicionar";
            this.cmdAdicionar.Size = new System.Drawing.Size(39, 37);
            this.cmdAdicionar.TabIndex = 917;
            this.cmdAdicionar.UseVisualStyleBackColor = false;
            this.cmdAdicionar.Click += new System.EventHandler(this.cmdAdicionar_Click);
            // 
            // cmdExcluir
            // 
            this.cmdExcluir.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcluir.ForeColor = System.Drawing.Color.Blue;
            this.cmdExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExcluir.Location = new System.Drawing.Point(1072, 442);
            this.cmdExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExcluir.Name = "cmdExcluir";
            this.cmdExcluir.Size = new System.Drawing.Size(39, 37);
            this.cmdExcluir.TabIndex = 918;
            this.cmdExcluir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExcluir.UseVisualStyleBackColor = false;
            this.cmdExcluir.Click += new System.EventHandler(this.cmdExcluir_Click);
            // 
            // lbl_cdparticipante
            // 
            this.lbl_cdparticipante.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_cdparticipante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cdparticipante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cdparticipante.ForeColor = System.Drawing.Color.White;
            this.lbl_cdparticipante.Location = new System.Drawing.Point(557, 590);
            this.lbl_cdparticipante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cdparticipante.Name = "lbl_cdparticipante";
            this.lbl_cdparticipante.Size = new System.Drawing.Size(101, 25);
            this.lbl_cdparticipante.TabIndex = 919;
            this.lbl_cdparticipante.Tag = "cdparticipante";
            this.lbl_cdparticipante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_nome_razao
            // 
            this.lbl_nome_razao.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_nome_razao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_nome_razao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome_razao.ForeColor = System.Drawing.Color.White;
            this.lbl_nome_razao.Location = new System.Drawing.Point(666, 590);
            this.lbl_nome_razao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nome_razao.Name = "lbl_nome_razao";
            this.lbl_nome_razao.Size = new System.Drawing.Size(400, 56);
            this.lbl_nome_razao.TabIndex = 922;
            this.lbl_nome_razao.Tag = "nome_razao";
            this.lbl_nome_razao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m1911_Notificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1124, 674);
            this.Controls.Add(this.lbl_nome_razao);
            this.Controls.Add(this.lbl_cdparticipante);
            this.Controls.Add(this.cmdExcluir);
            this.Controls.Add(this.cmdAdicionar);
            this.Controls.Add(this.cmdDetalheNotificacao);
            this.Controls.Add(this.lbldtgp_total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_notificacao_descricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_notificacao_cd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtgp);
            this.Controls.Add(this.lbldtg_total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtg);
            this.Controls.Add(this.lblwait);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "m1911_Notificacao";
            this.Text = "m1911_Notificacao";
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Label lbldtg_total;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_notificacao_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_cdparticipante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_nome_razao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_celular_dd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_celular_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgp_mail_main;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_notificacao_cd;
        private System.Windows.Forms.Label lbl_notificacao_descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbldtgp_total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdDetalheNotificacao;
        private System.Windows.Forms.Button cmdAdicionar;
        private System.Windows.Forms.Button cmdExcluir;
        private System.Windows.Forms.Label lbl_cdparticipante;
        private System.Windows.Forms.Label lbl_nome_razao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_notificacao_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_notificacao_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_notificacao_send_tipo_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_notificacao_send_tipo_descricao;
    }
}