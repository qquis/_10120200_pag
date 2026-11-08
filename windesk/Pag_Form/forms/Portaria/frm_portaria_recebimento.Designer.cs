namespace Pag_Form.forms
{
    partial class frm_portaria_recebimento
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
            this.label12 = new System.Windows.Forms.Label();
            this.tabcontrol_doc_reg = new System.Windows.Forms.TabControl();
            this.tabRecebimento = new System.Windows.Forms.TabPage();
            this.cmdsair = new System.Windows.Forms.Button();
            this.lbl_controle_Seq = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Motorista_CPF = new System.Windows.Forms.TextBox();
            this.dtgControle_dados_historico = new System.Windows.Forms.DataGridView();
            this.dtgControle_dados_historico_controle_reg_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_motorista_cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_motorista_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_veiculo_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgControle_dados_historico_controle_reg_numero_pallet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Motorista_Nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Motorista_CNH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Veiculo_Placa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Transportadora_CNPJ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtControle_Reg_Transportadora_RazaoSocial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtControle_reg_numero_pallet = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbVeiculoModelo = new System.Windows.Forms.ComboBox();
            this.TxtCNPJ_Consulta_Dados = new System.Windows.Forms.TextBox();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.cmdFILA_MERCEARIA = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.TXTcontrole_reg_numero_celular_dd = new System.Windows.Forms.TextBox();
            this.cmdFILA_PERECIVEIS = new System.Windows.Forms.Button();
            this.cmdFILA_HORTIFRUTI = new System.Windows.Forms.Button();
            this.cmdFILA_SUPRIMENTO = new System.Windows.Forms.Button();
            this.txtcontrole_reg_numero_celular_numero = new System.Windows.Forms.TextBox();
            this.tabcontrol_doc_reg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgControle_dados_historico)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1100, 32);
            this.label12.TabIndex = 200;
            this.label12.Text = "Portaria | Entrada e Saída de transportadoras de Mercadorias";
            // 
            // tabcontrol_doc_reg
            // 
            this.tabcontrol_doc_reg.Controls.Add(this.tabRecebimento);
            this.tabcontrol_doc_reg.Location = new System.Drawing.Point(12, 44);
            this.tabcontrol_doc_reg.Name = "tabcontrol_doc_reg";
            this.tabcontrol_doc_reg.SelectedIndex = 0;
            this.tabcontrol_doc_reg.Size = new System.Drawing.Size(590, 301);
            this.tabcontrol_doc_reg.TabIndex = 219;
            // 
            // tabRecebimento
            // 
            this.tabRecebimento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabRecebimento.Location = new System.Drawing.Point(4, 22);
            this.tabRecebimento.Name = "tabRecebimento";
            this.tabRecebimento.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecebimento.Size = new System.Drawing.Size(582, 275);
            this.tabRecebimento.TabIndex = 0;
            this.tabRecebimento.Text = "Documentos Fiscais";
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(1010, 9);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 254;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // lbl_controle_Seq
            // 
            this.lbl_controle_Seq.BackColor = System.Drawing.Color.Red;
            this.lbl_controle_Seq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_controle_Seq.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_controle_Seq.ForeColor = System.Drawing.Color.White;
            this.lbl_controle_Seq.Location = new System.Drawing.Point(713, 119);
            this.lbl_controle_Seq.Name = "lbl_controle_Seq";
            this.lbl_controle_Seq.Size = new System.Drawing.Size(91, 116);
            this.lbl_controle_Seq.TabIndex = 255;
            this.lbl_controle_Seq.Text = "0";
            this.lbl_controle_Seq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(612, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 21);
            this.label6.TabIndex = 327;
            this.label6.Text = "CPF";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Motorista_CPF
            // 
            this.txtControle_Reg_Motorista_CPF.AcceptsTab = true;
            this.txtControle_Reg_Motorista_CPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Motorista_CPF.Location = new System.Drawing.Point(797, 448);
            this.txtControle_Reg_Motorista_CPF.MaxLength = 11;
            this.txtControle_Reg_Motorista_CPF.Name = "txtControle_Reg_Motorista_CPF";
            this.txtControle_Reg_Motorista_CPF.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Motorista_CPF.TabIndex = 2;
            // 
            // dtgControle_dados_historico
            // 
            this.dtgControle_dados_historico.AllowUserToAddRows = false;
            this.dtgControle_dados_historico.AllowUserToDeleteRows = false;
            this.dtgControle_dados_historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgControle_dados_historico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgControle_dados_historico_controle_reg_seq,
            this.dtgControle_dados_historico_controle_reg_data,
            this.dtgControle_dados_historico_controle_reg_numero,
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa,
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social,
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa,
            this.dtgControle_dados_historico_controle_reg_motorista_cpf,
            this.dtgControle_dados_historico_controle_reg_motorista_nome,
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh,
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento,
            this.dtgControle_dados_historico_veiculo_seq,
            this.dtgControle_dados_historico_controle_reg_numero_pallet});
            this.dtgControle_dados_historico.Location = new System.Drawing.Point(12, 376);
            this.dtgControle_dados_historico.Name = "dtgControle_dados_historico";
            this.dtgControle_dados_historico.ReadOnly = true;
            this.dtgControle_dados_historico.RowHeadersVisible = false;
            this.dtgControle_dados_historico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgControle_dados_historico.Size = new System.Drawing.Size(590, 237);
            this.dtgControle_dados_historico.TabIndex = 328;
            // 
            // dtgControle_dados_historico_controle_reg_seq
            // 
            this.dtgControle_dados_historico_controle_reg_seq.DataPropertyName = "controle_reg_seq";
            this.dtgControle_dados_historico_controle_reg_seq.HeaderText = "Seq";
            this.dtgControle_dados_historico_controle_reg_seq.Name = "dtgControle_dados_historico_controle_reg_seq";
            this.dtgControle_dados_historico_controle_reg_seq.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_seq.Width = 5;
            // 
            // dtgControle_dados_historico_controle_reg_data
            // 
            this.dtgControle_dados_historico_controle_reg_data.DataPropertyName = "controle_reg_data";
            this.dtgControle_dados_historico_controle_reg_data.HeaderText = "Data";
            this.dtgControle_dados_historico_controle_reg_data.Name = "dtgControle_dados_historico_controle_reg_data";
            this.dtgControle_dados_historico_controle_reg_data.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_data.Width = 45;
            // 
            // dtgControle_dados_historico_controle_reg_numero
            // 
            this.dtgControle_dados_historico_controle_reg_numero.DataPropertyName = "controle_reg_numero";
            this.dtgControle_dados_historico_controle_reg_numero.HeaderText = "Número";
            this.dtgControle_dados_historico_controle_reg_numero.Name = "dtgControle_dados_historico_controle_reg_numero";
            this.dtgControle_dados_historico_controle_reg_numero.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_numero.Width = 45;
            // 
            // dtgControle_dados_historico_controle_reg_transportadora_cdpessoa
            // 
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa.DataPropertyName = "controle_reg_transportadora_cdpessoa";
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa.HeaderText = "Cód Pessoa";
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa.Name = "dtgControle_dados_historico_controle_reg_transportadora_cdpessoa";
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_transportadora_cdpessoa.Width = 5;
            // 
            // dtgControle_dados_historico_controle_reg_transportadora_razao_social
            // 
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social.DataPropertyName = "controle_reg_transportadora_razao_social";
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social.HeaderText = "Razão Social Transportadora";
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social.Name = "dtgControle_dados_historico_controle_reg_transportadora_razao_social";
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_transportadora_razao_social.Width = 120;
            // 
            // dtgControle_dados_historico_controle_reg_motorista_cdpessoa
            // 
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa.DataPropertyName = "controle_reg_motorista_cdpessoa";
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa.HeaderText = "Cod. Pessoa Motorista";
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa.Name = "dtgControle_dados_historico_controle_reg_motorista_cdpessoa";
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_motorista_cdpessoa.Width = 5;
            // 
            // dtgControle_dados_historico_controle_reg_motorista_cpf
            // 
            this.dtgControle_dados_historico_controle_reg_motorista_cpf.DataPropertyName = "controle_reg_motorista_cpf";
            this.dtgControle_dados_historico_controle_reg_motorista_cpf.HeaderText = "CPF Motorista";
            this.dtgControle_dados_historico_controle_reg_motorista_cpf.Name = "dtgControle_dados_historico_controle_reg_motorista_cpf";
            this.dtgControle_dados_historico_controle_reg_motorista_cpf.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_motorista_cpf.Width = 60;
            // 
            // dtgControle_dados_historico_controle_reg_motorista_nome
            // 
            this.dtgControle_dados_historico_controle_reg_motorista_nome.DataPropertyName = "controle_reg_motorista_nome";
            this.dtgControle_dados_historico_controle_reg_motorista_nome.HeaderText = "Nome";
            this.dtgControle_dados_historico_controle_reg_motorista_nome.Name = "dtgControle_dados_historico_controle_reg_motorista_nome";
            this.dtgControle_dados_historico_controle_reg_motorista_nome.ReadOnly = true;
            // 
            // dtgControle_dados_historico_controle_reg_motorista_documento_cnh
            // 
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.DataPropertyName = "controle_reg_motorista_documento_cnh";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.FillWeight = 45F;
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.HeaderText = "CNH";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.Name = "dtgControle_dados_historico_controle_reg_motorista_documento_cnh";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh.Width = 70;
            // 
            // dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento
            // 
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.DataPropertyName = "controle_reg_motorista_documento_cnh_vencimento";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.FillWeight = 45F;
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.HeaderText = "CNH Vencimento";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.Name = "dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento";
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento.Width = 70;
            // 
            // dtgControle_dados_historico_veiculo_seq
            // 
            this.dtgControle_dados_historico_veiculo_seq.DataPropertyName = "historico_veiculo_seq";
            this.dtgControle_dados_historico_veiculo_seq.FillWeight = 30F;
            this.dtgControle_dados_historico_veiculo_seq.HeaderText = "Veículo Cod. ";
            this.dtgControle_dados_historico_veiculo_seq.Name = "dtgControle_dados_historico_veiculo_seq";
            this.dtgControle_dados_historico_veiculo_seq.ReadOnly = true;
            this.dtgControle_dados_historico_veiculo_seq.Width = 45;
            // 
            // dtgControle_dados_historico_controle_reg_numero_pallet
            // 
            this.dtgControle_dados_historico_controle_reg_numero_pallet.DataPropertyName = "controle_reg_numero_pallet";
            this.dtgControle_dados_historico_controle_reg_numero_pallet.HeaderText = "N. Pallet";
            this.dtgControle_dados_historico_controle_reg_numero_pallet.Name = "dtgControle_dados_historico_controle_reg_numero_pallet";
            this.dtgControle_dados_historico_controle_reg_numero_pallet.ReadOnly = true;
            this.dtgControle_dados_historico_controle_reg_numero_pallet.Width = 45;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(612, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 21);
            this.label1.TabIndex = 330;
            this.label1.Text = "Nome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Motorista_Nome
            // 
            this.txtControle_Reg_Motorista_Nome.AcceptsTab = true;
            this.txtControle_Reg_Motorista_Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Motorista_Nome.Location = new System.Drawing.Point(797, 496);
            this.txtControle_Reg_Motorista_Nome.MaxLength = 60;
            this.txtControle_Reg_Motorista_Nome.Name = "txtControle_Reg_Motorista_Nome";
            this.txtControle_Reg_Motorista_Nome.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Motorista_Nome.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(612, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 21);
            this.label2.TabIndex = 332;
            this.label2.Text = "N. CNH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Motorista_CNH
            // 
            this.txtControle_Reg_Motorista_CNH.AcceptsTab = true;
            this.txtControle_Reg_Motorista_CNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Motorista_CNH.Location = new System.Drawing.Point(797, 472);
            this.txtControle_Reg_Motorista_CNH.MaxLength = 11;
            this.txtControle_Reg_Motorista_CNH.Name = "txtControle_Reg_Motorista_CNH";
            this.txtControle_Reg_Motorista_CNH.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Motorista_CNH.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(612, 544);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 21);
            this.label3.TabIndex = 338;
            this.label3.Text = "Placa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Veiculo_Placa
            // 
            this.txtControle_Reg_Veiculo_Placa.AcceptsTab = true;
            this.txtControle_Reg_Veiculo_Placa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Veiculo_Placa.Location = new System.Drawing.Point(797, 544);
            this.txtControle_Reg_Veiculo_Placa.MaxLength = 7;
            this.txtControle_Reg_Veiculo_Placa.Name = "txtControle_Reg_Veiculo_Placa";
            this.txtControle_Reg_Veiculo_Placa.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Veiculo_Placa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(612, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 21);
            this.label4.TabIndex = 340;
            this.label4.Text = "Modelo do Veículo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(612, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(491, 21);
            this.label5.TabIndex = 342;
            this.label5.Text = "Transportadora";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(612, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 21);
            this.label7.TabIndex = 344;
            this.label7.Text = "CNPJ ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Transportadora_CNPJ
            // 
            this.txtControle_Reg_Transportadora_CNPJ.AcceptsTab = true;
            this.txtControle_Reg_Transportadora_CNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Transportadora_CNPJ.Location = new System.Drawing.Point(797, 376);
            this.txtControle_Reg_Transportadora_CNPJ.MaxLength = 14;
            this.txtControle_Reg_Transportadora_CNPJ.Name = "txtControle_Reg_Transportadora_CNPJ";
            this.txtControle_Reg_Transportadora_CNPJ.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Transportadora_CNPJ.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(612, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 21);
            this.label8.TabIndex = 346;
            this.label8.Text = "Razão Social";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_Reg_Transportadora_RazaoSocial
            // 
            this.txtControle_Reg_Transportadora_RazaoSocial.AcceptsTab = true;
            this.txtControle_Reg_Transportadora_RazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_Reg_Transportadora_RazaoSocial.Location = new System.Drawing.Point(797, 399);
            this.txtControle_Reg_Transportadora_RazaoSocial.MaxLength = 60;
            this.txtControle_Reg_Transportadora_RazaoSocial.Name = "txtControle_Reg_Transportadora_RazaoSocial";
            this.txtControle_Reg_Transportadora_RazaoSocial.Size = new System.Drawing.Size(306, 21);
            this.txtControle_Reg_Transportadora_RazaoSocial.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SlateGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(612, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(491, 21);
            this.label9.TabIndex = 347;
            this.label9.Text = "Motorista";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(612, 520);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(491, 21);
            this.label10.TabIndex = 348;
            this.label10.Text = "Veículo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SlateGray;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(612, 592);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(491, 21);
            this.label11.TabIndex = 349;
            this.label11.Text = "Dados da Carga";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtControle_reg_numero_pallet
            // 
            this.txtControle_reg_numero_pallet.AcceptsTab = true;
            this.txtControle_reg_numero_pallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControle_reg_numero_pallet.Location = new System.Drawing.Point(797, 616);
            this.txtControle_reg_numero_pallet.MaxLength = 3;
            this.txtControle_reg_numero_pallet.Name = "txtControle_reg_numero_pallet";
            this.txtControle_reg_numero_pallet.Size = new System.Drawing.Size(54, 21);
            this.txtControle_reg_numero_pallet.TabIndex = 10;
            this.txtControle_reg_numero_pallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SlateGray;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(612, 616);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 21);
            this.label13.TabIndex = 351;
            this.label13.Text = "Número de Pallet";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SlateGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(713, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(323, 21);
            this.label14.TabIndex = 352;
            this.label14.Text = "Encaminhar para a fila do Recebimento de: ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.SlateGray;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(12, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(270, 21);
            this.label15.TabIndex = 353;
            this.label15.Text = "Histórico de Motorista / Transportadora";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbVeiculoModelo
            // 
            this.CmbVeiculoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVeiculoModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CmbVeiculoModelo.FormattingEnabled = true;
            this.CmbVeiculoModelo.Location = new System.Drawing.Point(797, 568);
            this.CmbVeiculoModelo.Name = "CmbVeiculoModelo";
            this.CmbVeiculoModelo.Size = new System.Drawing.Size(306, 23);
            this.CmbVeiculoModelo.TabIndex = 354;
            // 
            // TxtCNPJ_Consulta_Dados
            // 
            this.TxtCNPJ_Consulta_Dados.AcceptsTab = true;
            this.TxtCNPJ_Consulta_Dados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtCNPJ_Consulta_Dados.Enabled = false;
            this.TxtCNPJ_Consulta_Dados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCNPJ_Consulta_Dados.ForeColor = System.Drawing.Color.Black;
            this.TxtCNPJ_Consulta_Dados.Location = new System.Drawing.Point(296, 352);
            this.TxtCNPJ_Consulta_Dados.MaxLength = 14;
            this.TxtCNPJ_Consulta_Dados.Name = "TxtCNPJ_Consulta_Dados";
            this.TxtCNPJ_Consulta_Dados.Size = new System.Drawing.Size(306, 21);
            this.TxtCNPJ_Consulta_Dados.TabIndex = 355;
            this.TxtCNPJ_Consulta_Dados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdDetalhe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDetalhe.Location = new System.Drawing.Point(572, 616);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(30, 24);
            this.cmdDetalhe.TabIndex = 356;
            this.cmdDetalhe.UseVisualStyleBackColor = false;
            // 
            // cmdFILA_MERCEARIA
            // 
            this.cmdFILA_MERCEARIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdFILA_MERCEARIA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFILA_MERCEARIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFILA_MERCEARIA.Location = new System.Drawing.Point(820, 119);
            this.cmdFILA_MERCEARIA.Name = "cmdFILA_MERCEARIA";
            this.cmdFILA_MERCEARIA.Size = new System.Drawing.Size(216, 24);
            this.cmdFILA_MERCEARIA.TabIndex = 357;
            this.cmdFILA_MERCEARIA.Text = "MERCEARIA";
            this.cmdFILA_MERCEARIA.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.SlateGray;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(857, 616);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 21);
            this.label16.TabIndex = 358;
            this.label16.Text = "N. Celular";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TXTcontrole_reg_numero_celular_dd
            // 
            this.TXTcontrole_reg_numero_celular_dd.AcceptsTab = true;
            this.TXTcontrole_reg_numero_celular_dd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTcontrole_reg_numero_celular_dd.Location = new System.Drawing.Point(934, 616);
            this.TXTcontrole_reg_numero_celular_dd.MaxLength = 2;
            this.TXTcontrole_reg_numero_celular_dd.Name = "TXTcontrole_reg_numero_celular_dd";
            this.TXTcontrole_reg_numero_celular_dd.Size = new System.Drawing.Size(29, 21);
            this.TXTcontrole_reg_numero_celular_dd.TabIndex = 11;
            this.TXTcontrole_reg_numero_celular_dd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdFILA_PERECIVEIS
            // 
            this.cmdFILA_PERECIVEIS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdFILA_PERECIVEIS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFILA_PERECIVEIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFILA_PERECIVEIS.Location = new System.Drawing.Point(820, 149);
            this.cmdFILA_PERECIVEIS.Name = "cmdFILA_PERECIVEIS";
            this.cmdFILA_PERECIVEIS.Size = new System.Drawing.Size(216, 24);
            this.cmdFILA_PERECIVEIS.TabIndex = 360;
            this.cmdFILA_PERECIVEIS.Text = "PERECÍVEIS";
            this.cmdFILA_PERECIVEIS.UseVisualStyleBackColor = false;
            // 
            // cmdFILA_HORTIFRUTI
            // 
            this.cmdFILA_HORTIFRUTI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdFILA_HORTIFRUTI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFILA_HORTIFRUTI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFILA_HORTIFRUTI.Location = new System.Drawing.Point(820, 181);
            this.cmdFILA_HORTIFRUTI.Name = "cmdFILA_HORTIFRUTI";
            this.cmdFILA_HORTIFRUTI.Size = new System.Drawing.Size(216, 24);
            this.cmdFILA_HORTIFRUTI.TabIndex = 361;
            this.cmdFILA_HORTIFRUTI.Text = "HORTIFRUTI";
            this.cmdFILA_HORTIFRUTI.UseVisualStyleBackColor = false;
            // 
            // cmdFILA_SUPRIMENTO
            // 
            this.cmdFILA_SUPRIMENTO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmdFILA_SUPRIMENTO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFILA_SUPRIMENTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFILA_SUPRIMENTO.Location = new System.Drawing.Point(820, 211);
            this.cmdFILA_SUPRIMENTO.Name = "cmdFILA_SUPRIMENTO";
            this.cmdFILA_SUPRIMENTO.Size = new System.Drawing.Size(216, 24);
            this.cmdFILA_SUPRIMENTO.TabIndex = 362;
            this.cmdFILA_SUPRIMENTO.Text = "SUPRIMENTO";
            this.cmdFILA_SUPRIMENTO.UseVisualStyleBackColor = false;
            // 
            // txtcontrole_reg_numero_celular_numero
            // 
            this.txtcontrole_reg_numero_celular_numero.AcceptsTab = true;
            this.txtcontrole_reg_numero_celular_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontrole_reg_numero_celular_numero.Location = new System.Drawing.Point(969, 616);
            this.txtcontrole_reg_numero_celular_numero.MaxLength = 9;
            this.txtcontrole_reg_numero_celular_numero.Name = "txtcontrole_reg_numero_celular_numero";
            this.txtcontrole_reg_numero_celular_numero.Size = new System.Drawing.Size(134, 21);
            this.txtcontrole_reg_numero_celular_numero.TabIndex = 12;
            this.txtcontrole_reg_numero_celular_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frm_portaria_recebimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1115, 642);
            this.Controls.Add(this.txtcontrole_reg_numero_celular_numero);
            this.Controls.Add(this.cmdFILA_SUPRIMENTO);
            this.Controls.Add(this.cmdFILA_HORTIFRUTI);
            this.Controls.Add(this.cmdFILA_PERECIVEIS);
            this.Controls.Add(this.TXTcontrole_reg_numero_celular_dd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmdFILA_MERCEARIA);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.TxtCNPJ_Consulta_Dados);
            this.Controls.Add(this.dtgControle_dados_historico);
            this.Controls.Add(this.CmbVeiculoModelo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtControle_reg_numero_pallet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtControle_Reg_Transportadora_RazaoSocial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtControle_Reg_Transportadora_CNPJ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtControle_Reg_Veiculo_Placa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtControle_Reg_Motorista_CNH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtControle_Reg_Motorista_Nome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_controle_Seq);
            this.Controls.Add(this.txtControle_Reg_Motorista_CPF);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.tabcontrol_doc_reg);
            this.Controls.Add(this.label12);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_portaria_recebimento";
            this.Text = "Pag | M4210";
            this.tabcontrol_doc_reg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgControle_dados_historico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabcontrol_doc_reg;
        private System.Windows.Forms.TabPage tabRecebimento;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label lbl_controle_Seq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtControle_Reg_Motorista_CPF;
        private System.Windows.Forms.DataGridView dtgControle_dados_historico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtControle_Reg_Motorista_Nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtControle_Reg_Motorista_CNH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtControle_Reg_Veiculo_Placa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtControle_Reg_Transportadora_CNPJ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtControle_Reg_Transportadora_RazaoSocial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtControle_reg_numero_pallet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbVeiculoModelo;
        private System.Windows.Forms.TextBox TxtCNPJ_Consulta_Dados;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_transportadora_cdpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_transportadora_razao_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_motorista_cdpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_motorista_cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_motorista_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_motorista_documento_cnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_motorista_documento_cnh_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_veiculo_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgControle_dados_historico_controle_reg_numero_pallet;
        private System.Windows.Forms.Button cmdFILA_MERCEARIA;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TXTcontrole_reg_numero_celular_dd;
        private System.Windows.Forms.Button cmdFILA_PERECIVEIS;
        private System.Windows.Forms.Button cmdFILA_HORTIFRUTI;
        private System.Windows.Forms.Button cmdFILA_SUPRIMENTO;
        private System.Windows.Forms.TextBox txtcontrole_reg_numero_celular_numero;
    }
}