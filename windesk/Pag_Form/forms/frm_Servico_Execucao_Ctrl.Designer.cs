namespace Pag_Form.forms
{
    partial class frm_Servico_Execucao_Ctrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.grpUC_Controle = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnome_razao_Fornecedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcontrato_servico_ctrl_descritivo = new System.Windows.Forms.TextBox();
            this.txtcpf_cnpj_Fornecedor = new System.Windows.Forms.TextBox();
            this.txtcelular_numero = new System.Windows.Forms.TextBox();
            this.txtcelular_dd = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dtgpessoa_historico = new System.Windows.Forms.DataGridView();
            this.dtgpessoa_historico_controle_reg_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.txtnome_razao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtcpf_cnpj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcontrato_servico_ctrl_observacao = new System.Windows.Forms.TextBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdNovo_Controle = new System.Windows.Forms.Button();
            this.cmdEfetivar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_PROCESSO = new System.Windows.Forms.Label();
            this.cmbContratoServico = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtfiltro_controle_reg_seq = new System.Windows.Forms.TextBox();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.cmdProximaEtapa = new System.Windows.Forms.Button();
            this.cmdRecusarEntrada = new System.Windows.Forms.Button();
            this.cmbcartaoCtrl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgpessoa_historico)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(980, 6);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(81, 30);
            this.cmdsair.TabIndex = 545;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1059, 32);
            this.label12.TabIndex = 544;
            this.label12.Text = "Contratos de Serviços";
            // 
            // grpUC_Controle
            // 
            this.grpUC_Controle.Location = new System.Drawing.Point(4, 83);
            this.grpUC_Controle.Name = "grpUC_Controle";
            this.grpUC_Controle.Size = new System.Drawing.Size(476, 400);
            this.grpUC_Controle.TabIndex = 546;
            this.grpUC_Controle.TabStop = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(498, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(567, 22);
            this.label13.TabIndex = 679;
            this.label13.Text = "Fornecedor do Serviço";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(813, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 21);
            this.label2.TabIndex = 693;
            this.label2.Text = "Nome / Razão Social";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnome_razao_Fornecedor
            // 
            this.txtnome_razao_Fornecedor.AcceptsTab = true;
            this.txtnome_razao_Fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnome_razao_Fornecedor.Location = new System.Drawing.Point(813, 130);
            this.txtnome_razao_Fornecedor.MaxLength = 60;
            this.txtnome_razao_Fornecedor.Name = "txtnome_razao_Fornecedor";
            this.txtnome_razao_Fornecedor.Size = new System.Drawing.Size(252, 21);
            this.txtnome_razao_Fornecedor.TabIndex = 681;
            this.txtnome_razao_Fornecedor.Tag = "nome_razao_Fornecedor";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(500, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 695;
            this.label1.Text = "Descritivo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(696, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 692;
            this.label3.Text = "CPF / CNPJ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcontrato_servico_ctrl_descritivo
            // 
            this.txtcontrato_servico_ctrl_descritivo.AcceptsTab = true;
            this.txtcontrato_servico_ctrl_descritivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontrato_servico_ctrl_descritivo.Location = new System.Drawing.Point(500, 398);
            this.txtcontrato_servico_ctrl_descritivo.MaxLength = 60;
            this.txtcontrato_servico_ctrl_descritivo.Name = "txtcontrato_servico_ctrl_descritivo";
            this.txtcontrato_servico_ctrl_descritivo.Size = new System.Drawing.Size(227, 21);
            this.txtcontrato_servico_ctrl_descritivo.TabIndex = 687;
            this.txtcontrato_servico_ctrl_descritivo.Tag = "contrato_servico_ctrl_descritivo";
            // 
            // txtcpf_cnpj_Fornecedor
            // 
            this.txtcpf_cnpj_Fornecedor.AcceptsTab = true;
            this.txtcpf_cnpj_Fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpf_cnpj_Fornecedor.Location = new System.Drawing.Point(696, 130);
            this.txtcpf_cnpj_Fornecedor.MaxLength = 14;
            this.txtcpf_cnpj_Fornecedor.Name = "txtcpf_cnpj_Fornecedor";
            this.txtcpf_cnpj_Fornecedor.Size = new System.Drawing.Size(111, 21);
            this.txtcpf_cnpj_Fornecedor.TabIndex = 680;
            this.txtcpf_cnpj_Fornecedor.Tag = "cpf_cnpj_Fornecedor";
            this.txtcpf_cnpj_Fornecedor.Text = "57895328000130";
            this.txtcpf_cnpj_Fornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcelular_numero
            // 
            this.txtcelular_numero.AcceptsTab = true;
            this.txtcelular_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcelular_numero.Location = new System.Drawing.Point(965, 276);
            this.txtcelular_numero.MaxLength = 9;
            this.txtcelular_numero.Name = "txtcelular_numero";
            this.txtcelular_numero.Size = new System.Drawing.Size(100, 21);
            this.txtcelular_numero.TabIndex = 686;
            this.txtcelular_numero.Tag = "celular_numero";
            this.txtcelular_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcelular_dd
            // 
            this.txtcelular_dd.AcceptsTab = true;
            this.txtcelular_dd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcelular_dd.Location = new System.Drawing.Point(930, 276);
            this.txtcelular_dd.MaxLength = 2;
            this.txtcelular_dd.Name = "txtcelular_dd";
            this.txtcelular_dd.Size = new System.Drawing.Size(29, 21);
            this.txtcelular_dd.TabIndex = 685;
            this.txtcelular_dd.Tag = "celular_dd";
            this.txtcelular_dd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.SlateGray;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(930, 253);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(135, 21);
            this.label32.TabIndex = 694;
            this.label32.Text = "N. Celular";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgpessoa_historico
            // 
            this.dtgpessoa_historico.AllowUserToAddRows = false;
            this.dtgpessoa_historico.AllowUserToDeleteRows = false;
            this.dtgpessoa_historico.AllowUserToResizeRows = false;
            this.dtgpessoa_historico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpessoa_historico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgpessoa_historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgpessoa_historico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgpessoa_historico_controle_reg_data,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgpessoa_historico.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgpessoa_historico.Location = new System.Drawing.Point(498, 180);
            this.dtgpessoa_historico.Name = "dtgpessoa_historico";
            this.dtgpessoa_historico.ReadOnly = true;
            this.dtgpessoa_historico.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgpessoa_historico.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgpessoa_historico.RowHeadersVisible = false;
            this.dtgpessoa_historico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgpessoa_historico.Size = new System.Drawing.Size(567, 70);
            this.dtgpessoa_historico.TabIndex = 682;
            // 
            // dtgpessoa_historico_controle_reg_data
            // 
            this.dtgpessoa_historico_controle_reg_data.DataPropertyName = "controle_reg_data";
            this.dtgpessoa_historico_controle_reg_data.HeaderText = "Data";
            this.dtgpessoa_historico_controle_reg_data.Name = "dtgpessoa_historico_controle_reg_data";
            this.dtgpessoa_historico_controle_reg_data.ReadOnly = true;
            this.dtgpessoa_historico_controle_reg_data.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cpf_cnpj";
            this.dataGridViewTextBoxColumn5.HeaderText = "CPF/CNPJ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "nome_razao";
            this.dataGridViewTextBoxColumn10.HeaderText = "Nome / Razão Social";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 320;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SlateGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(638, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(286, 21);
            this.label9.TabIndex = 689;
            this.label9.Text = "Nome";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnome_razao
            // 
            this.txtnome_razao.AcceptsTab = true;
            this.txtnome_razao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnome_razao.Location = new System.Drawing.Point(637, 275);
            this.txtnome_razao.MaxLength = 60;
            this.txtnome_razao.Name = "txtnome_razao";
            this.txtnome_razao.Size = new System.Drawing.Size(287, 21);
            this.txtnome_razao.TabIndex = 684;
            this.txtnome_razao.Tag = "nome_razao";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SlateGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(498, 253);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 21);
            this.label14.TabIndex = 688;
            this.label14.Text = "CPF";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcpf_cnpj
            // 
            this.txtcpf_cnpj.AcceptsTab = true;
            this.txtcpf_cnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpf_cnpj.Location = new System.Drawing.Point(498, 275);
            this.txtcpf_cnpj.MaxLength = 14;
            this.txtcpf_cnpj.Name = "txtcpf_cnpj";
            this.txtcpf_cnpj.Size = new System.Drawing.Size(134, 21);
            this.txtcpf_cnpj.TabIndex = 683;
            this.txtcpf_cnpj.Tag = "cpf_cnpj";
            this.txtcpf_cnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(498, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(567, 22);
            this.label4.TabIndex = 696;
            this.label4.Text = "Técnico";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(500, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(566, 22);
            this.label5.TabIndex = 697;
            this.label5.Text = "Informações";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(733, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(332, 21);
            this.label6.TabIndex = 699;
            this.label6.Text = "Observação";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcontrato_servico_ctrl_observacao
            // 
            this.txtcontrato_servico_ctrl_observacao.AcceptsTab = true;
            this.txtcontrato_servico_ctrl_observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontrato_servico_ctrl_observacao.Location = new System.Drawing.Point(733, 398);
            this.txtcontrato_servico_ctrl_observacao.MaxLength = 220;
            this.txtcontrato_servico_ctrl_observacao.Multiline = true;
            this.txtcontrato_servico_ctrl_observacao.Name = "txtcontrato_servico_ctrl_observacao";
            this.txtcontrato_servico_ctrl_observacao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtcontrato_servico_ctrl_observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcontrato_servico_ctrl_observacao.Size = new System.Drawing.Size(332, 54);
            this.txtcontrato_servico_ctrl_observacao.TabIndex = 698;
            this.txtcontrato_servico_ctrl_observacao.Tag = "contrato_servico_ctrl_observacao";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.White;
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.Color.Blue;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.Location = new System.Drawing.Point(893, 6);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(81, 30);
            this.cmdCancelar.TabIndex = 702;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.UseVisualStyleBackColor = false;
            // 
            // cmdNovo_Controle
            // 
            this.cmdNovo_Controle.BackColor = System.Drawing.Color.White;
            this.cmdNovo_Controle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdNovo_Controle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNovo_Controle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovo_Controle.ForeColor = System.Drawing.Color.Blue;
            this.cmdNovo_Controle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNovo_Controle.Location = new System.Drawing.Point(733, 6);
            this.cmdNovo_Controle.Name = "cmdNovo_Controle";
            this.cmdNovo_Controle.Size = new System.Drawing.Size(81, 30);
            this.cmdNovo_Controle.TabIndex = 701;
            this.cmdNovo_Controle.Text = "Novo";
            this.cmdNovo_Controle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdNovo_Controle.UseVisualStyleBackColor = false;
            // 
            // cmdEfetivar
            // 
            this.cmdEfetivar.BackColor = System.Drawing.Color.White;
            this.cmdEfetivar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEfetivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetivar.ForeColor = System.Drawing.Color.Blue;
            this.cmdEfetivar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEfetivar.Location = new System.Drawing.Point(813, 6);
            this.cmdEfetivar.Name = "cmdEfetivar";
            this.cmdEfetivar.Size = new System.Drawing.Size(81, 30);
            this.cmdEfetivar.TabIndex = 700;
            this.cmdEfetivar.Text = "Efetivar";
            this.cmdEfetivar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEfetivar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(713, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 20);
            this.label7.TabIndex = 704;
            this.label7.Text = "Cartão de Acesso Principal";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PROCESSO
            // 
            this.lbl_PROCESSO.BackColor = System.Drawing.Color.Red;
            this.lbl_PROCESSO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PROCESSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PROCESSO.ForeColor = System.Drawing.Color.White;
            this.lbl_PROCESSO.Location = new System.Drawing.Point(4, 40);
            this.lbl_PROCESSO.Name = "lbl_PROCESSO";
            this.lbl_PROCESSO.Size = new System.Drawing.Size(330, 37);
            this.lbl_PROCESSO.TabIndex = 706;
            this.lbl_PROCESSO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbContratoServico
            // 
            this.cmbContratoServico.BackColor = System.Drawing.SystemColors.Window;
            this.cmbContratoServico.DropDownWidth = 200;
            this.cmbContratoServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContratoServico.FormattingEnabled = true;
            this.cmbContratoServico.Location = new System.Drawing.Point(498, 129);
            this.cmbContratoServico.Name = "cmbContratoServico";
            this.cmbContratoServico.Size = new System.Drawing.Size(192, 23);
            this.cmbContratoServico.TabIndex = 708;
            this.cmbContratoServico.Tag = "cartaoCtrl";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(498, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 21);
            this.label8.TabIndex = 707;
            this.label8.Text = "Contrato de Serviço";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(195, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 21);
            this.label10.TabIndex = 710;
            this.label10.Text = "Consultar Controle de Serviço";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtfiltro_controle_reg_seq
            // 
            this.txtfiltro_controle_reg_seq.AcceptsTab = true;
            this.txtfiltro_controle_reg_seq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfiltro_controle_reg_seq.Location = new System.Drawing.Point(415, 9);
            this.txtfiltro_controle_reg_seq.MaxLength = 60;
            this.txtfiltro_controle_reg_seq.Name = "txtfiltro_controle_reg_seq";
            this.txtfiltro_controle_reg_seq.Size = new System.Drawing.Size(98, 21);
            this.txtfiltro_controle_reg_seq.TabIndex = 709;
            this.txtfiltro_controle_reg_seq.Tag = "";
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.White;
            this.cmdConsultar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(519, 6);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(81, 30);
            this.cmdConsultar.TabIndex = 711;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            // 
            // cmdProximaEtapa
            // 
            this.cmdProximaEtapa.BackColor = System.Drawing.Color.White;
            this.cmdProximaEtapa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdProximaEtapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProximaEtapa.ForeColor = System.Drawing.Color.Blue;
            this.cmdProximaEtapa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdProximaEtapa.Location = new System.Drawing.Point(498, 453);
            this.cmdProximaEtapa.Name = "cmdProximaEtapa";
            this.cmdProximaEtapa.Size = new System.Drawing.Size(136, 30);
            this.cmdProximaEtapa.TabIndex = 712;
            this.cmdProximaEtapa.Text = "Liberar Etapa";
            this.cmdProximaEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProximaEtapa.UseVisualStyleBackColor = false;
            // 
            // cmdRecusarEntrada
            // 
            this.cmdRecusarEntrada.BackColor = System.Drawing.Color.White;
            this.cmdRecusarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRecusarEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRecusarEntrada.ForeColor = System.Drawing.Color.Blue;
            this.cmdRecusarEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdRecusarEntrada.Location = new System.Drawing.Point(638, 453);
            this.cmdRecusarEntrada.Name = "cmdRecusarEntrada";
            this.cmdRecusarEntrada.Size = new System.Drawing.Size(136, 30);
            this.cmdRecusarEntrada.TabIndex = 713;
            this.cmdRecusarEntrada.Text = "Recusar Entrada";
            this.cmdRecusarEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRecusarEntrada.UseVisualStyleBackColor = false;
            // 
            // cmbcartaoCtrl
            // 
            this.cmbcartaoCtrl.FormattingEnabled = true;
            this.cmbcartaoCtrl.Location = new System.Drawing.Point(930, 299);
            this.cmbcartaoCtrl.Name = "cmbcartaoCtrl";
            this.cmbcartaoCtrl.Size = new System.Drawing.Size(135, 21);
            this.cmbcartaoCtrl.TabIndex = 714;
            // 
            // frm_Servico_Execucao_Ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1076, 491);
            this.Controls.Add(this.cmbcartaoCtrl);
            this.Controls.Add(this.cmdRecusarEntrada);
            this.Controls.Add(this.cmdProximaEtapa);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtfiltro_controle_reg_seq);
            this.Controls.Add(this.cmbContratoServico);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_PROCESSO);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdNovo_Controle);
            this.Controls.Add(this.cmdEfetivar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtcontrato_servico_ctrl_observacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnome_razao_Fornecedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcontrato_servico_ctrl_descritivo);
            this.Controls.Add(this.txtcpf_cnpj_Fornecedor);
            this.Controls.Add(this.txtcelular_numero);
            this.Controls.Add(this.txtcelular_dd);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.dtgpessoa_historico);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtnome_razao);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtcpf_cnpj);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.grpUC_Controle);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Servico_Execucao_Ctrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dtgpessoa_historico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpUC_Controle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnome_razao_Fornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcontrato_servico_ctrl_descritivo;
        private System.Windows.Forms.TextBox txtcpf_cnpj_Fornecedor;
        private System.Windows.Forms.TextBox txtcelular_numero;
        private System.Windows.Forms.TextBox txtcelular_dd;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView dtgpessoa_historico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtnome_razao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtcpf_cnpj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcontrato_servico_ctrl_observacao;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdNovo_Controle;
        private System.Windows.Forms.Button cmdEfetivar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_PROCESSO;
        private System.Windows.Forms.ComboBox cmbContratoServico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtfiltro_controle_reg_seq;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgpessoa_historico_controle_reg_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Button cmdProximaEtapa;
        private System.Windows.Forms.Button cmdRecusarEntrada;
        private System.Windows.Forms.ComboBox cmbcartaoCtrl;
    }
}