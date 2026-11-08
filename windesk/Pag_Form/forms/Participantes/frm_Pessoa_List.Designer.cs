namespace Pag_Form.forms
{
    partial class frm_Pessoa_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdconsultar = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl_Filtros = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgParticipanteTipo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgParticipanteTipoCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkBlueSoftFabricante = new System.Windows.Forms.CheckBox();
            this.chkBlueSoftFornecedor = new System.Windows.Forms.CheckBox();
            this.chkBlueSoftVendedor = new System.Windows.Forms.CheckBox();
            this.chkBlueSoftCliente = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtcpf_cnpj = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcdparticipante = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcdpessoabluesoft = new System.Windows.Forms.TextBox();
            this.txtnome_razao = new System.Windows.Forms.TextBox();
            this.dtgParticipante = new System.Windows.Forms.DataGridView();
            this.dtgparticipante_cdparticipante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_cdpessoabluesoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_rh_funcionario_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_cpf_cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_nome_razao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_email_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_celular_dd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_celular_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgparticipante_participante_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumeroRegistros = new System.Windows.Forms.Label();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.cmdBlueSoftInteg = new System.Windows.Forms.Button();
            this.lbl_cdparticipante = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelecionar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdLocalizarGrupoEconomico = new System.Windows.Forms.Button();
            this.lbl_descricaoGrupoEconomico = new System.Windows.Forms.Label();
            this.txt_cdgrupoeconomico = new System.Windows.Forms.TextBox();
            this.cmdCancelaSelecaoGrupoEconomico = new System.Windows.Forms.Button();
            this.tabControl_Filtros.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipanteTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipante)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdconsultar
            // 
            this.cmdconsultar.BackColor = System.Drawing.Color.White;
            this.cmdconsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdconsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdconsultar.Location = new System.Drawing.Point(924, 7);
            this.cmdconsultar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdconsultar.Name = "cmdconsultar";
            this.cmdconsultar.Size = new System.Drawing.Size(133, 37);
            this.cmdconsultar.TabIndex = 305;
            this.cmdconsultar.Text = "Consultar";
            this.cmdconsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdconsultar.UseVisualStyleBackColor = false;
            this.cmdconsultar.Click += new System.EventHandler(this.cmdconsultar_Click);
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(1058, 7);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 310;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(7, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1459, 43);
            this.label12.TabIndex = 235;
            this.label12.Text = "Participantes | Pesquisar";
            // 
            // tabControl_Filtros
            // 
            this.tabControl_Filtros.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_Filtros.Controls.Add(this.tabPage1);
            this.tabControl_Filtros.Controls.Add(this.tabPage2);
            this.tabControl_Filtros.Location = new System.Drawing.Point(7, 52);
            this.tabControl_Filtros.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl_Filtros.Name = "tabControl_Filtros";
            this.tabControl_Filtros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl_Filtros.SelectedIndex = 0;
            this.tabControl_Filtros.Size = new System.Drawing.Size(1185, 167);
            this.tabControl_Filtros.TabIndex = 258;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.dtgParticipanteTipo);
            this.tabPage1.Controls.Add(this.chkBlueSoftFabricante);
            this.tabPage1.Controls.Add(this.chkBlueSoftFornecedor);
            this.tabPage1.Controls.Add(this.chkBlueSoftVendedor);
            this.tabPage1.Controls.Add(this.chkBlueSoftCliente);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtcpf_cnpj);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtcdparticipante);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtcdpessoabluesoft);
            this.tabPage1.Controls.Add(this.txtnome_razao);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1177, 135);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Filtros Básicos";
            // 
            // dtgParticipanteTipo
            // 
            this.dtgParticipanteTipo.AllowUserToAddRows = false;
            this.dtgParticipanteTipo.AllowUserToDeleteRows = false;
            this.dtgParticipanteTipo.AllowUserToResizeRows = false;
            this.dtgParticipanteTipo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipanteTipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgParticipanteTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipanteTipo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dtgParticipanteTipoCheckBox});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgParticipanteTipo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgParticipanteTipo.Location = new System.Drawing.Point(521, 4);
            this.dtgParticipanteTipo.Margin = new System.Windows.Forms.Padding(4);
            this.dtgParticipanteTipo.Name = "dtgParticipanteTipo";
            this.dtgParticipanteTipo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipanteTipo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgParticipanteTipo.RowHeadersVisible = false;
            this.dtgParticipanteTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipanteTipo.Size = new System.Drawing.Size(436, 113);
            this.dtgParticipanteTipo.TabIndex = 266;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "participante_tipo_cd";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod. Part";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "participante_tipo_descricao";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo de Participante";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 210;
            // 
            // dtgParticipanteTipoCheckBox
            // 
            this.dtgParticipanteTipoCheckBox.FalseValue = "false";
            this.dtgParticipanteTipoCheckBox.HeaderText = "";
            this.dtgParticipanteTipoCheckBox.IndeterminateValue = "false";
            this.dtgParticipanteTipoCheckBox.Name = "dtgParticipanteTipoCheckBox";
            this.dtgParticipanteTipoCheckBox.TrueValue = "true";
            this.dtgParticipanteTipoCheckBox.Width = 50;
            // 
            // chkBlueSoftFabricante
            // 
            this.chkBlueSoftFabricante.AutoSize = true;
            this.chkBlueSoftFabricante.Location = new System.Drawing.Point(965, 96);
            this.chkBlueSoftFabricante.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlueSoftFabricante.Name = "chkBlueSoftFabricante";
            this.chkBlueSoftFabricante.Size = new System.Drawing.Size(154, 21);
            this.chkBlueSoftFabricante.TabIndex = 128;
            this.chkBlueSoftFabricante.Text = "BlueSoft Fabricante";
            this.chkBlueSoftFabricante.UseVisualStyleBackColor = true;
            // 
            // chkBlueSoftFornecedor
            // 
            this.chkBlueSoftFornecedor.AutoSize = true;
            this.chkBlueSoftFornecedor.Location = new System.Drawing.Point(965, 68);
            this.chkBlueSoftFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlueSoftFornecedor.Name = "chkBlueSoftFornecedor";
            this.chkBlueSoftFornecedor.Size = new System.Drawing.Size(160, 21);
            this.chkBlueSoftFornecedor.TabIndex = 127;
            this.chkBlueSoftFornecedor.Text = "BlueSoft Fornecedor";
            this.chkBlueSoftFornecedor.UseVisualStyleBackColor = true;
            // 
            // chkBlueSoftVendedor
            // 
            this.chkBlueSoftVendedor.AutoSize = true;
            this.chkBlueSoftVendedor.Location = new System.Drawing.Point(965, 39);
            this.chkBlueSoftVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlueSoftVendedor.Name = "chkBlueSoftVendedor";
            this.chkBlueSoftVendedor.Size = new System.Drawing.Size(149, 21);
            this.chkBlueSoftVendedor.TabIndex = 125;
            this.chkBlueSoftVendedor.Text = "BlueSoft Vendedor";
            this.chkBlueSoftVendedor.UseVisualStyleBackColor = true;
            // 
            // chkBlueSoftCliente
            // 
            this.chkBlueSoftCliente.AutoSize = true;
            this.chkBlueSoftCliente.Location = new System.Drawing.Point(965, 12);
            this.chkBlueSoftCliente.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlueSoftCliente.Name = "chkBlueSoftCliente";
            this.chkBlueSoftCliente.Size = new System.Drawing.Size(130, 21);
            this.chkBlueSoftCliente.TabIndex = 120;
            this.chkBlueSoftCliente.Text = "BlueSoft Cliente";
            this.chkBlueSoftCliente.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SlateGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(270, 7);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 25);
            this.label14.TabIndex = 228;
            this.label14.Text = "CPF/CNPJ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcpf_cnpj
            // 
            this.txtcpf_cnpj.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtcpf_cnpj.Location = new System.Drawing.Point(270, 36);
            this.txtcpf_cnpj.Margin = new System.Windows.Forms.Padding(4);
            this.txtcpf_cnpj.Name = "txtcpf_cnpj";
            this.txtcpf_cnpj.Size = new System.Drawing.Size(242, 22);
            this.txtcpf_cnpj.TabIndex = 106;
            this.txtcpf_cnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(13, 7);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 25);
            this.label10.TabIndex = 226;
            this.label10.Text = "Participante";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcdparticipante
            // 
            this.txtcdparticipante.Location = new System.Drawing.Point(13, 36);
            this.txtcdparticipante.Margin = new System.Windows.Forms.Padding(4);
            this.txtcdparticipante.Name = "txtcdparticipante";
            this.txtcdparticipante.Size = new System.Drawing.Size(108, 22);
            this.txtcdparticipante.TabIndex = 100;
            this.txtcdparticipante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(500, 25);
            this.label8.TabIndex = 224;
            this.label8.Text = "Nome / Razão Social";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(128, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 25);
            this.label6.TabIndex = 221;
            this.label6.Text = "Cd BlueSoft";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcdpessoabluesoft
            // 
            this.txtcdpessoabluesoft.Location = new System.Drawing.Point(128, 36);
            this.txtcdpessoabluesoft.Margin = new System.Windows.Forms.Padding(4);
            this.txtcdpessoabluesoft.Name = "txtcdpessoabluesoft";
            this.txtcdpessoabluesoft.Size = new System.Drawing.Size(108, 22);
            this.txtcdpessoabluesoft.TabIndex = 105;
            this.txtcdpessoabluesoft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtnome_razao
            // 
            this.txtnome_razao.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtnome_razao.Location = new System.Drawing.Point(13, 97);
            this.txtnome_razao.Margin = new System.Windows.Forms.Padding(4);
            this.txtnome_razao.Name = "txtnome_razao";
            this.txtnome_razao.Size = new System.Drawing.Size(500, 22);
            this.txtnome_razao.TabIndex = 107;
            // 
            // dtgParticipante
            // 
            this.dtgParticipante.AllowUserToAddRows = false;
            this.dtgParticipante.AllowUserToDeleteRows = false;
            this.dtgParticipante.AllowUserToResizeRows = false;
            this.dtgParticipante.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgParticipante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgparticipante_cdparticipante,
            this.dtgparticipante_cdpessoabluesoft,
            this.dtgparticipante_rh_funcionario_cd,
            this.dtgparticipante_cpf_cnpj,
            this.dtgparticipante_nome_razao,
            this.dtgparticipante_email_main,
            this.dtgparticipante_celular_dd,
            this.dtgparticipante_celular_numero,
            this.dtgparticipante_participante_status});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgParticipante.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgParticipante.Location = new System.Drawing.Point(8, 226);
            this.dtgParticipante.Margin = new System.Windows.Forms.Padding(4);
            this.dtgParticipante.Name = "dtgParticipante";
            this.dtgParticipante.ReadOnly = true;
            this.dtgParticipante.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParticipante.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgParticipante.RowHeadersVisible = false;
            this.dtgParticipante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipante.Size = new System.Drawing.Size(1184, 352);
            this.dtgParticipante.TabIndex = 200;
            // 
            // dtgparticipante_cdparticipante
            // 
            this.dtgparticipante_cdparticipante.DataPropertyName = "cdparticipante";
            this.dtgparticipante_cdparticipante.HeaderText = "Cod. Part";
            this.dtgparticipante_cdparticipante.Name = "dtgparticipante_cdparticipante";
            this.dtgparticipante_cdparticipante.ReadOnly = true;
            this.dtgparticipante_cdparticipante.Width = 55;
            // 
            // dtgparticipante_cdpessoabluesoft
            // 
            this.dtgparticipante_cdpessoabluesoft.DataPropertyName = "cdpessoabluesoft";
            this.dtgparticipante_cdpessoabluesoft.HeaderText = "Cod. Blue";
            this.dtgparticipante_cdpessoabluesoft.Name = "dtgparticipante_cdpessoabluesoft";
            this.dtgparticipante_cdpessoabluesoft.ReadOnly = true;
            this.dtgparticipante_cdpessoabluesoft.Width = 55;
            // 
            // dtgparticipante_rh_funcionario_cd
            // 
            this.dtgparticipante_rh_funcionario_cd.DataPropertyName = "funcionario_cd";
            this.dtgparticipante_rh_funcionario_cd.HeaderText = "Cod. Rh";
            this.dtgparticipante_rh_funcionario_cd.Name = "dtgparticipante_rh_funcionario_cd";
            this.dtgparticipante_rh_funcionario_cd.ReadOnly = true;
            this.dtgparticipante_rh_funcionario_cd.Width = 55;
            // 
            // dtgparticipante_cpf_cnpj
            // 
            this.dtgparticipante_cpf_cnpj.DataPropertyName = "cpf_cnpj";
            this.dtgparticipante_cpf_cnpj.HeaderText = "CPF/CNPJ";
            this.dtgparticipante_cpf_cnpj.Name = "dtgparticipante_cpf_cnpj";
            this.dtgparticipante_cpf_cnpj.ReadOnly = true;
            this.dtgparticipante_cpf_cnpj.Width = 80;
            // 
            // dtgparticipante_nome_razao
            // 
            this.dtgparticipante_nome_razao.DataPropertyName = "nome_razao";
            this.dtgparticipante_nome_razao.HeaderText = "Nome / Razão Social";
            this.dtgparticipante_nome_razao.Name = "dtgparticipante_nome_razao";
            this.dtgparticipante_nome_razao.ReadOnly = true;
            this.dtgparticipante_nome_razao.Width = 280;
            // 
            // dtgparticipante_email_main
            // 
            this.dtgparticipante_email_main.DataPropertyName = "email_main";
            this.dtgparticipante_email_main.HeaderText = "E-mail ";
            this.dtgparticipante_email_main.Name = "dtgparticipante_email_main";
            this.dtgparticipante_email_main.ReadOnly = true;
            this.dtgparticipante_email_main.Width = 120;
            // 
            // dtgparticipante_celular_dd
            // 
            this.dtgparticipante_celular_dd.DataPropertyName = "celular_dd";
            this.dtgparticipante_celular_dd.HeaderText = "Telefone (dd)";
            this.dtgparticipante_celular_dd.Name = "dtgparticipante_celular_dd";
            this.dtgparticipante_celular_dd.ReadOnly = true;
            this.dtgparticipante_celular_dd.Width = 45;
            // 
            // dtgparticipante_celular_numero
            // 
            this.dtgparticipante_celular_numero.DataPropertyName = "celular_numero";
            this.dtgparticipante_celular_numero.HeaderText = "Telefone Número";
            this.dtgparticipante_celular_numero.Name = "dtgparticipante_celular_numero";
            this.dtgparticipante_celular_numero.ReadOnly = true;
            this.dtgparticipante_celular_numero.Width = 60;
            // 
            // dtgparticipante_participante_status
            // 
            this.dtgparticipante_participante_status.DataPropertyName = "participante_status";
            this.dtgparticipante_participante_status.FalseValue = "0";
            this.dtgparticipante_participante_status.HeaderText = "Ativo";
            this.dtgparticipante_participante_status.Name = "dtgparticipante_participante_status";
            this.dtgparticipante_participante_status.ReadOnly = true;
            this.dtgparticipante_participante_status.TrueValue = "1";
            this.dtgparticipante_participante_status.Width = 45;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 262;
            this.label2.Text = "Número de Registros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumeroRegistros
            // 
            this.lblNumeroRegistros.BackColor = System.Drawing.Color.SlateGray;
            this.lblNumeroRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumeroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroRegistros.ForeColor = System.Drawing.Color.White;
            this.lblNumeroRegistros.Location = new System.Drawing.Point(221, 582);
            this.lblNumeroRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroRegistros.Name = "lblNumeroRegistros";
            this.lblNumeroRegistros.Size = new System.Drawing.Size(102, 25);
            this.lblNumeroRegistros.TabIndex = 263;
            this.lblNumeroRegistros.Text = "0";
            this.lblNumeroRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.BackColor = System.Drawing.Color.White;
            this.cmdDetalhe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDetalhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetalhe.ForeColor = System.Drawing.Color.Blue;
            this.cmdDetalhe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDetalhe.Location = new System.Drawing.Point(917, 582);
            this.cmdDetalhe.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(133, 37);
            this.cmdDetalhe.TabIndex = 205;
            this.cmdDetalhe.Text = "Detalhe";
            this.cmdDetalhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDetalhe.UseVisualStyleBackColor = false;
            this.cmdDetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // cmdBlueSoftInteg
            // 
            this.cmdBlueSoftInteg.BackColor = System.Drawing.Color.White;
            this.cmdBlueSoftInteg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBlueSoftInteg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBlueSoftInteg.ForeColor = System.Drawing.Color.Blue;
            this.cmdBlueSoftInteg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBlueSoftInteg.Location = new System.Drawing.Point(789, 6);
            this.cmdBlueSoftInteg.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBlueSoftInteg.Name = "cmdBlueSoftInteg";
            this.cmdBlueSoftInteg.Size = new System.Drawing.Size(133, 37);
            this.cmdBlueSoftInteg.TabIndex = 300;
            this.cmdBlueSoftInteg.Text = "BlueSoft Integ";
            this.cmdBlueSoftInteg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBlueSoftInteg.UseVisualStyleBackColor = false;
            this.cmdBlueSoftInteg.Click += new System.EventHandler(this.cmdBlueSoftInteg_Click);
            // 
            // lbl_cdparticipante
            // 
            this.lbl_cdparticipante.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_cdparticipante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cdparticipante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cdparticipante.ForeColor = System.Drawing.Color.White;
            this.lbl_cdparticipante.Location = new System.Drawing.Point(676, 582);
            this.lbl_cdparticipante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cdparticipante.Name = "lbl_cdparticipante";
            this.lbl_cdparticipante.Size = new System.Drawing.Size(102, 25);
            this.lbl_cdparticipante.TabIndex = 267;
            this.lbl_cdparticipante.Tag = "cdparticipante";
            this.lbl_cdparticipante.Text = "0";
            this.lbl_cdparticipante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(462, 582);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 266;
            this.label3.Text = "Participante Selecionado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSelecionar
            // 
            this.cmdSelecionar.BackColor = System.Drawing.Color.White;
            this.cmdSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelecionar.ForeColor = System.Drawing.Color.Blue;
            this.cmdSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSelecionar.Location = new System.Drawing.Point(1058, 582);
            this.cmdSelecionar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelecionar.Name = "cmdSelecionar";
            this.cmdSelecionar.Size = new System.Drawing.Size(133, 37);
            this.cmdSelecionar.TabIndex = 210;
            this.cmdSelecionar.Text = "Selecionar";
            this.cmdSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelecionar.UseVisualStyleBackColor = false;
            this.cmdSelecionar.Click += new System.EventHandler(this.cmdSelecionar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.cmdCancelaSelecaoGrupoEconomico);
            this.tabPage2.Controls.Add(this.cmdLocalizarGrupoEconomico);
            this.tabPage2.Controls.Add(this.lbl_descricaoGrupoEconomico);
            this.tabPage2.Controls.Add(this.txt_cdgrupoeconomico);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1177, 135);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Grupo Econômico";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(715, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 25);
            this.label1.TabIndex = 225;
            this.label1.Text = "Grupo Econômico";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdLocalizarGrupoEconomico
            // 
            this.cmdLocalizarGrupoEconomico.BackColor = System.Drawing.Color.White;
            this.cmdLocalizarGrupoEconomico.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLocalizarGrupoEconomico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLocalizarGrupoEconomico.ForeColor = System.Drawing.Color.Blue;
            this.cmdLocalizarGrupoEconomico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdLocalizarGrupoEconomico.Location = new System.Drawing.Point(1073, 38);
            this.cmdLocalizarGrupoEconomico.Margin = new System.Windows.Forms.Padding(4);
            this.cmdLocalizarGrupoEconomico.Name = "cmdLocalizarGrupoEconomico";
            this.cmdLocalizarGrupoEconomico.Size = new System.Drawing.Size(39, 26);
            this.cmdLocalizarGrupoEconomico.TabIndex = 513;
            this.cmdLocalizarGrupoEconomico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdLocalizarGrupoEconomico.UseVisualStyleBackColor = false;
            this.cmdLocalizarGrupoEconomico.Click += new System.EventHandler(this.cmdLocalizarGrupoEconomico_Click);
            // 
            // lbl_descricaoGrupoEconomico
            // 
            this.lbl_descricaoGrupoEconomico.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_descricaoGrupoEconomico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_descricaoGrupoEconomico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descricaoGrupoEconomico.ForeColor = System.Drawing.Color.White;
            this.lbl_descricaoGrupoEconomico.Location = new System.Drawing.Point(809, 38);
            this.lbl_descricaoGrupoEconomico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_descricaoGrupoEconomico.Name = "lbl_descricaoGrupoEconomico";
            this.lbl_descricaoGrupoEconomico.Size = new System.Drawing.Size(256, 25);
            this.lbl_descricaoGrupoEconomico.TabIndex = 512;
            this.lbl_descricaoGrupoEconomico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_cdgrupoeconomico
            // 
            this.txt_cdgrupoeconomico.AcceptsTab = true;
            this.txt_cdgrupoeconomico.Enabled = false;
            this.txt_cdgrupoeconomico.Location = new System.Drawing.Point(715, 38);
            this.txt_cdgrupoeconomico.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cdgrupoeconomico.MaxLength = 11;
            this.txt_cdgrupoeconomico.Name = "txt_cdgrupoeconomico";
            this.txt_cdgrupoeconomico.Size = new System.Drawing.Size(86, 22);
            this.txt_cdgrupoeconomico.TabIndex = 511;
            // 
            // cmdCancelaSelecaoGrupoEconomico
            // 
            this.cmdCancelaSelecaoGrupoEconomico.BackColor = System.Drawing.Color.White;
            this.cmdCancelaSelecaoGrupoEconomico.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancelaSelecaoGrupoEconomico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelaSelecaoGrupoEconomico.ForeColor = System.Drawing.Color.Blue;
            this.cmdCancelaSelecaoGrupoEconomico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelaSelecaoGrupoEconomico.Location = new System.Drawing.Point(1125, 38);
            this.cmdCancelaSelecaoGrupoEconomico.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancelaSelecaoGrupoEconomico.Name = "cmdCancelaSelecaoGrupoEconomico";
            this.cmdCancelaSelecaoGrupoEconomico.Size = new System.Drawing.Size(39, 26);
            this.cmdCancelaSelecaoGrupoEconomico.TabIndex = 514;
            this.cmdCancelaSelecaoGrupoEconomico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelaSelecaoGrupoEconomico.UseVisualStyleBackColor = false;
            this.cmdCancelaSelecaoGrupoEconomico.Click += new System.EventHandler(this.cmdCancelaSelecaoGrupoEconomico_Click);
            // 
            // frm_Pessoa_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.cmdsair;
            this.ClientSize = new System.Drawing.Size(1199, 619);
            this.Controls.Add(this.cmdSelecionar);
            this.Controls.Add(this.lbl_cdparticipante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBlueSoftInteg);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.lblNumeroRegistros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgParticipante);
            this.Controls.Add(this.tabControl_Filtros);
            this.Controls.Add(this.cmdconsultar);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Pessoa_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F0011";
            this.tabControl_Filtros.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipanteTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipante)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdconsultar;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl_Filtros;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcdpessoabluesoft;
        private System.Windows.Forms.TextBox txtnome_razao;
        private System.Windows.Forms.DataGridView dtgParticipante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcdparticipante;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtcpf_cnpj;
        private System.Windows.Forms.CheckBox chkBlueSoftFabricante;
        private System.Windows.Forms.CheckBox chkBlueSoftFornecedor;
        private System.Windows.Forms.CheckBox chkBlueSoftVendedor;
        private System.Windows.Forms.CheckBox chkBlueSoftCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumeroRegistros;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.Button cmdBlueSoftInteg;
        private System.Windows.Forms.DataGridView dtgParticipanteTipo;
        private System.Windows.Forms.Label lbl_cdparticipante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_cdparticipante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_cdpessoabluesoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_rh_funcionario_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_cpf_cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_nome_razao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_email_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_celular_dd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgparticipante_celular_numero;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgparticipante_participante_status;
        private System.Windows.Forms.Button cmdSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgParticipanteTipoCheckBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdLocalizarGrupoEconomico;
        private System.Windows.Forms.Label lbl_descricaoGrupoEconomico;
        private System.Windows.Forms.TextBox txt_cdgrupoeconomico;
        private System.Windows.Forms.Button cmdCancelaSelecaoGrupoEconomico;
    }
}