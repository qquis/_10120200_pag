namespace Pag_Form.forms.Participantes
{
    partial class frm_GrupoEconomico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdescricao = new System.Windows.Forms.TextBox();
            this.chkgrupoeconomico_status = new System.Windows.Forms.CheckBox();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkjohnson_cliente_top_selecioa = new System.Windows.Forms.CheckBox();
            this.Mydtg = new System.Windows.Forms.DataGridView();
            this.lbl_cdparticipante = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumeroRegistros = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_cdgrupoeconomico = new System.Windows.Forms.Label();
            this.lbl_descricao = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkjohnson_cliente_top = new System.Windows.Forms.CheckBox();
            this.cmdBlueSoftInteg = new System.Windows.Forms.Button();
            this.cmdconsultar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_descricaoresumida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_referencia = new System.Windows.Forms.TextBox();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdCancela_Alteracao = new System.Windows.Forms.Button();
            this.cmdEfetivar_dados = new System.Windows.Forms.Button();
            this.dtg_cdgrupoeconomico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_johnson_cliente_top = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtg_grupoeconomico_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdSelecionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mydtg)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 25);
            this.label5.TabIndex = 324;
            this.label5.Text = "Descrição";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdescricao
            // 
            this.txtdescricao.AcceptsTab = true;
            this.txtdescricao.Location = new System.Drawing.Point(5, 85);
            this.txtdescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtdescricao.MaxLength = 60;
            this.txtdescricao.Name = "txtdescricao";
            this.txtdescricao.Size = new System.Drawing.Size(282, 22);
            this.txtdescricao.TabIndex = 323;
            // 
            // chkgrupoeconomico_status
            // 
            this.chkgrupoeconomico_status.AutoSize = true;
            this.chkgrupoeconomico_status.Location = new System.Drawing.Point(351, 85);
            this.chkgrupoeconomico_status.Margin = new System.Windows.Forms.Padding(4);
            this.chkgrupoeconomico_status.Name = "chkgrupoeconomico_status";
            this.chkgrupoeconomico_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkgrupoeconomico_status.Size = new System.Drawing.Size(113, 21);
            this.chkgrupoeconomico_status.TabIndex = 322;
            this.chkgrupoeconomico_status.Text = "Apenas Ativo";
            this.chkgrupoeconomico_status.UseVisualStyleBackColor = true;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(978, 12);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 318;
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
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1114, 43);
            this.label12.TabIndex = 317;
            this.label12.Text = "Grupos Econômicos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(310, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 329;
            this.label1.Text = "Apenas Status Ativo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(476, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 331;
            this.label2.Text = "Grupo Econômico Johnson Top";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkjohnson_cliente_top_selecioa
            // 
            this.chkjohnson_cliente_top_selecioa.AutoSize = true;
            this.chkjohnson_cliente_top_selecioa.Location = new System.Drawing.Point(476, 85);
            this.chkjohnson_cliente_top_selecioa.Margin = new System.Windows.Forms.Padding(4);
            this.chkjohnson_cliente_top_selecioa.Name = "chkjohnson_cliente_top_selecioa";
            this.chkjohnson_cliente_top_selecioa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkjohnson_cliente_top_selecioa.Size = new System.Drawing.Size(154, 21);
            this.chkjohnson_cliente_top_selecioa.TabIndex = 330;
            this.chkjohnson_cliente_top_selecioa.Text = "Top Conta Johnson";
            this.chkjohnson_cliente_top_selecioa.UseVisualStyleBackColor = true;
            // 
            // Mydtg
            // 
            this.Mydtg.AllowUserToAddRows = false;
            this.Mydtg.AllowUserToDeleteRows = false;
            this.Mydtg.AllowUserToResizeRows = false;
            this.Mydtg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mydtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.Mydtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mydtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtg_cdgrupoeconomico,
            this.dtg_descricao,
            this.dtg_johnson_cliente_top,
            this.dtg_grupoeconomico_status});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mydtg.DefaultCellStyle = dataGridViewCellStyle26;
            this.Mydtg.Location = new System.Drawing.Point(3, 114);
            this.Mydtg.Margin = new System.Windows.Forms.Padding(4);
            this.Mydtg.Name = "Mydtg";
            this.Mydtg.ReadOnly = true;
            this.Mydtg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mydtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.Mydtg.RowHeadersVisible = false;
            this.Mydtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Mydtg.Size = new System.Drawing.Size(705, 422);
            this.Mydtg.TabIndex = 332;
            // 
            // lbl_cdparticipante
            // 
            this.lbl_cdparticipante.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_cdparticipante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cdparticipante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cdparticipante.ForeColor = System.Drawing.Color.White;
            this.lbl_cdparticipante.Location = new System.Drawing.Point(717, 165);
            this.lbl_cdparticipante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cdparticipante.Name = "lbl_cdparticipante";
            this.lbl_cdparticipante.Size = new System.Drawing.Size(163, 25);
            this.lbl_cdparticipante.TabIndex = 336;
            this.lbl_cdparticipante.Tag = "";
            this.lbl_cdparticipante.Text = "Código";
            this.lbl_cdparticipante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(716, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 45);
            this.label3.TabIndex = 335;
            this.label3.Text = "Grupo Econômico Selecionado";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumeroRegistros
            // 
            this.lblNumeroRegistros.BackColor = System.Drawing.Color.SlateGray;
            this.lblNumeroRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumeroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroRegistros.ForeColor = System.Drawing.Color.White;
            this.lblNumeroRegistros.Location = new System.Drawing.Point(219, 540);
            this.lblNumeroRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroRegistros.Name = "lblNumeroRegistros";
            this.lblNumeroRegistros.Size = new System.Drawing.Size(102, 25);
            this.lblNumeroRegistros.TabIndex = 334;
            this.lblNumeroRegistros.Text = "0";
            this.lblNumeroRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 540);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 25);
            this.label4.TabIndex = 333;
            this.label4.Text = "Número de Registros";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(717, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 337;
            this.label6.Text = "Descrição";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_cdgrupoeconomico
            // 
            this.lbl_cdgrupoeconomico.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_cdgrupoeconomico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cdgrupoeconomico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cdgrupoeconomico.ForeColor = System.Drawing.Color.White;
            this.lbl_cdgrupoeconomico.Location = new System.Drawing.Point(884, 165);
            this.lbl_cdgrupoeconomico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cdgrupoeconomico.Name = "lbl_cdgrupoeconomico";
            this.lbl_cdgrupoeconomico.Size = new System.Drawing.Size(70, 25);
            this.lbl_cdgrupoeconomico.TabIndex = 339;
            this.lbl_cdgrupoeconomico.Tag = "cdgrupoeconomico";
            this.lbl_cdgrupoeconomico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_descricao
            // 
            this.lbl_descricao.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_descricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descricao.ForeColor = System.Drawing.Color.White;
            this.lbl_descricao.Location = new System.Drawing.Point(884, 192);
            this.lbl_descricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_descricao.Name = "lbl_descricao";
            this.lbl_descricao.Size = new System.Drawing.Size(233, 62);
            this.lbl_descricao.TabIndex = 340;
            this.lbl_descricao.Tag = "descricao";
            this.lbl_descricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SlateGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(717, 317);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 53);
            this.label9.TabIndex = 342;
            this.label9.Text = "Indicar como Johnson Top";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkjohnson_cliente_top
            // 
            this.chkjohnson_cliente_top.AutoSize = true;
            this.chkjohnson_cliente_top.Enabled = false;
            this.chkjohnson_cliente_top.Location = new System.Drawing.Point(884, 321);
            this.chkjohnson_cliente_top.Margin = new System.Windows.Forms.Padding(4);
            this.chkjohnson_cliente_top.Name = "chkjohnson_cliente_top";
            this.chkjohnson_cliente_top.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkjohnson_cliente_top.Size = new System.Drawing.Size(113, 21);
            this.chkjohnson_cliente_top.TabIndex = 341;
            this.chkjohnson_cliente_top.Text = "Johnson Top";
            this.chkjohnson_cliente_top.UseVisualStyleBackColor = true;
            // 
            // cmdBlueSoftInteg
            // 
            this.cmdBlueSoftInteg.BackColor = System.Drawing.Color.White;
            this.cmdBlueSoftInteg.Enabled = false;
            this.cmdBlueSoftInteg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBlueSoftInteg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBlueSoftInteg.ForeColor = System.Drawing.Color.Blue;
            this.cmdBlueSoftInteg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBlueSoftInteg.Location = new System.Drawing.Point(707, 12);
            this.cmdBlueSoftInteg.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBlueSoftInteg.Name = "cmdBlueSoftInteg";
            this.cmdBlueSoftInteg.Size = new System.Drawing.Size(133, 37);
            this.cmdBlueSoftInteg.TabIndex = 343;
            this.cmdBlueSoftInteg.Text = "BlueSoft Integ";
            this.cmdBlueSoftInteg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBlueSoftInteg.UseVisualStyleBackColor = false;
            this.cmdBlueSoftInteg.Click += new System.EventHandler(this.cmdBlueSoftInteg_Click);
            // 
            // cmdconsultar
            // 
            this.cmdconsultar.BackColor = System.Drawing.Color.White;
            this.cmdconsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdconsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdconsultar.Location = new System.Drawing.Point(842, 12);
            this.cmdconsultar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdconsultar.Name = "cmdconsultar";
            this.cmdconsultar.Size = new System.Drawing.Size(133, 37);
            this.cmdconsultar.TabIndex = 344;
            this.cmdconsultar.Text = "Consultar";
            this.cmdconsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdconsultar.UseVisualStyleBackColor = false;
            this.cmdconsultar.Click += new System.EventHandler(this.cmdconsultar_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(717, 260);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 25);
            this.label7.TabIndex = 346;
            this.label7.Text = "Descrição Resumida";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_descricaoresumida
            // 
            this.txt_descricaoresumida.AcceptsTab = true;
            this.txt_descricaoresumida.Location = new System.Drawing.Point(884, 260);
            this.txt_descricaoresumida.Margin = new System.Windows.Forms.Padding(4);
            this.txt_descricaoresumida.MaxLength = 20;
            this.txt_descricaoresumida.Name = "txt_descricaoresumida";
            this.txt_descricaoresumida.Size = new System.Drawing.Size(154, 22);
            this.txt_descricaoresumida.TabIndex = 345;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(717, 289);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 25);
            this.label8.TabIndex = 348;
            this.label8.Text = "Referência";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_referencia
            // 
            this.txt_referencia.AcceptsTab = true;
            this.txt_referencia.Location = new System.Drawing.Point(884, 290);
            this.txt_referencia.Margin = new System.Windows.Forms.Padding(4);
            this.txt_referencia.MaxLength = 10;
            this.txt_referencia.Name = "txt_referencia";
            this.txt_referencia.Size = new System.Drawing.Size(220, 22);
            this.txt_referencia.TabIndex = 347;
            // 
            // cmdEditar
            // 
            this.cmdEditar.BackColor = System.Drawing.Color.White;
            this.cmdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditar.ForeColor = System.Drawing.Color.Blue;
            this.cmdEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditar.Location = new System.Drawing.Point(982, 117);
            this.cmdEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(39, 37);
            this.cmdEditar.TabIndex = 351;
            this.cmdEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditar.UseVisualStyleBackColor = false;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdCancela_Alteracao
            // 
            this.cmdCancela_Alteracao.BackColor = System.Drawing.Color.White;
            this.cmdCancela_Alteracao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancela_Alteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancela_Alteracao.ForeColor = System.Drawing.Color.Blue;
            this.cmdCancela_Alteracao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancela_Alteracao.Location = new System.Drawing.Point(1029, 117);
            this.cmdCancela_Alteracao.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancela_Alteracao.Name = "cmdCancela_Alteracao";
            this.cmdCancela_Alteracao.Size = new System.Drawing.Size(39, 37);
            this.cmdCancela_Alteracao.TabIndex = 350;
            this.cmdCancela_Alteracao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancela_Alteracao.UseVisualStyleBackColor = false;
            this.cmdCancela_Alteracao.Click += new System.EventHandler(this.cmdCancela_Alteracao_Click);
            // 
            // cmdEfetivar_dados
            // 
            this.cmdEfetivar_dados.BackColor = System.Drawing.Color.White;
            this.cmdEfetivar_dados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEfetivar_dados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetivar_dados.ForeColor = System.Drawing.Color.Blue;
            this.cmdEfetivar_dados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEfetivar_dados.Location = new System.Drawing.Point(1077, 117);
            this.cmdEfetivar_dados.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEfetivar_dados.Name = "cmdEfetivar_dados";
            this.cmdEfetivar_dados.Size = new System.Drawing.Size(39, 37);
            this.cmdEfetivar_dados.TabIndex = 349;
            this.cmdEfetivar_dados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEfetivar_dados.UseVisualStyleBackColor = false;
            this.cmdEfetivar_dados.Click += new System.EventHandler(this.cmdEfetivar_dados_Click);
            // 
            // dtg_cdgrupoeconomico
            // 
            this.dtg_cdgrupoeconomico.DataPropertyName = "cdgrupoeconomico";
            this.dtg_cdgrupoeconomico.HeaderText = "Cod.";
            this.dtg_cdgrupoeconomico.Name = "dtg_cdgrupoeconomico";
            this.dtg_cdgrupoeconomico.ReadOnly = true;
            this.dtg_cdgrupoeconomico.Width = 60;
            // 
            // dtg_descricao
            // 
            this.dtg_descricao.DataPropertyName = "descricao";
            this.dtg_descricao.HeaderText = "Nome / Razão Social";
            this.dtg_descricao.Name = "dtg_descricao";
            this.dtg_descricao.ReadOnly = true;
            this.dtg_descricao.Width = 250;
            // 
            // dtg_johnson_cliente_top
            // 
            this.dtg_johnson_cliente_top.DataPropertyName = "johnson_cliente_top";
            this.dtg_johnson_cliente_top.FalseValue = "0";
            this.dtg_johnson_cliente_top.HeaderText = "Johnson Top Conta";
            this.dtg_johnson_cliente_top.Name = "dtg_johnson_cliente_top";
            this.dtg_johnson_cliente_top.ReadOnly = true;
            this.dtg_johnson_cliente_top.TrueValue = "1";
            // 
            // dtg_grupoeconomico_status
            // 
            this.dtg_grupoeconomico_status.DataPropertyName = "grupoeconomico_status";
            this.dtg_grupoeconomico_status.FalseValue = "0";
            this.dtg_grupoeconomico_status.HeaderText = "Ativo";
            this.dtg_grupoeconomico_status.Name = "dtg_grupoeconomico_status";
            this.dtg_grupoeconomico_status.ReadOnly = true;
            this.dtg_grupoeconomico_status.TrueValue = "1";
            this.dtg_grupoeconomico_status.Width = 45;
            // 
            // cmdSelecionar
            // 
            this.cmdSelecionar.BackColor = System.Drawing.Color.White;
            this.cmdSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelecionar.ForeColor = System.Drawing.Color.Blue;
            this.cmdSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSelecionar.Location = new System.Drawing.Point(575, 540);
            this.cmdSelecionar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelecionar.Name = "cmdSelecionar";
            this.cmdSelecionar.Size = new System.Drawing.Size(133, 37);
            this.cmdSelecionar.TabIndex = 352;
            this.cmdSelecionar.Text = "Selecionar";
            this.cmdSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelecionar.UseVisualStyleBackColor = false;
            this.cmdSelecionar.Click += new System.EventHandler(this.cmdSelecionar_Click);
            // 
            // frm_GrupoEconomico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1124, 584);
            this.Controls.Add(this.cmdSelecionar);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdCancela_Alteracao);
            this.Controls.Add(this.cmdEfetivar_dados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_referencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_descricaoresumida);
            this.Controls.Add(this.cmdBlueSoftInteg);
            this.Controls.Add(this.cmdconsultar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkjohnson_cliente_top);
            this.Controls.Add(this.lbl_descricao);
            this.Controls.Add(this.lbl_cdgrupoeconomico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_cdparticipante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumeroRegistros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Mydtg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkjohnson_cliente_top_selecioa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdescricao);
            this.Controls.Add(this.chkgrupoeconomico_status);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GrupoEconomico";
            this.Text = "M1511 - Grupo Econômico";
            ((System.ComponentModel.ISupportInitialize)(this.Mydtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdescricao;
        private System.Windows.Forms.CheckBox chkgrupoeconomico_status;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkjohnson_cliente_top_selecioa;
        private System.Windows.Forms.DataGridView Mydtg;
        private System.Windows.Forms.Label lbl_cdparticipante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumeroRegistros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_cdgrupoeconomico;
        private System.Windows.Forms.Label lbl_descricao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkjohnson_cliente_top;
        private System.Windows.Forms.Button cmdBlueSoftInteg;
        private System.Windows.Forms.Button cmdconsultar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_descricaoresumida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_referencia;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdCancela_Alteracao;
        private System.Windows.Forms.Button cmdEfetivar_dados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_cdgrupoeconomico;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtg_johnson_cliente_top;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtg_grupoeconomico_status;
        private System.Windows.Forms.Button cmdSelecionar;
    }
}