namespace Pag_Wpf.Financeiro.Titulo
{
    partial class FrmTituloComando
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TXTSeqContrato = new System.Windows.Forms.TextBox();
            this.LBLDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTGTitulos = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.CMDSeleciona = new System.Windows.Forms.Button();
            this.DTGColumnSeqTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdParticipanteSacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnNomeSacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEspécie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnSituação = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnValorSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTDescricaoContrato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CMBEspecieTitulo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DTPDataInicio = new System.Windows.Forms.DateTimePicker();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNumeroParcelas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGTitulos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXTSeqContrato
            // 
            this.TXTSeqContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTSeqContrato.Enabled = false;
            this.TXTSeqContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTSeqContrato.Location = new System.Drawing.Point(227, 28);
            this.TXTSeqContrato.MaxLength = 14;
            this.TXTSeqContrato.Name = "TXTSeqContrato";
            this.TXTSeqContrato.Size = new System.Drawing.Size(734, 26);
            this.TXTSeqContrato.TabIndex = 115;
            this.TXTSeqContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LBLDocumento
            // 
            this.LBLDocumento.AutoSize = true;
            this.LBLDocumento.BackColor = System.Drawing.Color.Silver;
            this.LBLDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDocumento.Location = new System.Drawing.Point(12, 28);
            this.LBLDocumento.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLDocumento.Name = "LBLDocumento";
            this.LBLDocumento.Size = new System.Drawing.Size(200, 22);
            this.LBLDocumento.TabIndex = 114;
            this.LBLDocumento.Text = "Comando";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(809, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 117;
            this.label2.Text = "Ações sobre o Título";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 116;
            this.label1.Text = "Cadastros";
            // 
            // DTGTitulos
            // 
            this.DTGTitulos.AllowUserToAddRows = false;
            this.DTGTitulos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGTitulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DTGTitulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGTitulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnSeqTitulo,
            this.DTGColumnCdEmpresa,
            this.DTGColumnCdParticipanteSacado,
            this.DTGColumnNomeSacado,
            this.DTGColumnVencimento,
            this.DTGColumnEspécie,
            this.DTGColumnSituação,
            this.DTGColumnValor,
            this.DTGColumnValorSaldo});
            this.DTGTitulos.Location = new System.Drawing.Point(12, 60);
            this.DTGTitulos.Name = "DTGTitulos";
            this.DTGTitulos.ReadOnly = true;
            this.DTGTitulos.Size = new System.Drawing.Size(949, 190);
            this.DTGTitulos.TabIndex = 118;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(13, 256);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(948, 189);
            this.tabControl1.TabIndex = 119;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(940, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lançamentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TXTDescricaoContrato);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(940, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Abatimento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TxtNumeroParcelas);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textBox5);
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.DTPDataInicio);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.CMBEspecieTitulo);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(940, 160);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Liquidação";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CmdCancela
            // 
            this.CmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(874, 447);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(87, 33);
            this.CmdCancela.TabIndex = 121;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            // 
            // CMDSeleciona
            // 
            this.CMDSeleciona.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CMDSeleciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDSeleciona.Location = new System.Drawing.Point(770, 447);
            this.CMDSeleciona.Name = "CMDSeleciona";
            this.CMDSeleciona.Size = new System.Drawing.Size(98, 33);
            this.CMDSeleciona.TabIndex = 120;
            this.CMDSeleciona.Text = "Efetivar";
            this.CMDSeleciona.UseVisualStyleBackColor = true;
            // 
            // DTGColumnSeqTitulo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DTGColumnSeqTitulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.DTGColumnSeqTitulo.HeaderText = "Título";
            this.DTGColumnSeqTitulo.Name = "DTGColumnSeqTitulo";
            this.DTGColumnSeqTitulo.ReadOnly = true;
            this.DTGColumnSeqTitulo.Width = 70;
            // 
            // DTGColumnCdEmpresa
            // 
            this.DTGColumnCdEmpresa.HeaderText = "Empresa";
            this.DTGColumnCdEmpresa.Name = "DTGColumnCdEmpresa";
            this.DTGColumnCdEmpresa.ReadOnly = true;
            this.DTGColumnCdEmpresa.Width = 45;
            // 
            // DTGColumnCdParticipanteSacado
            // 
            this.DTGColumnCdParticipanteSacado.DataPropertyName = "CdParticipanteSacado";
            this.DTGColumnCdParticipanteSacado.HeaderText = "Participante";
            this.DTGColumnCdParticipanteSacado.Name = "DTGColumnCdParticipanteSacado";
            this.DTGColumnCdParticipanteSacado.ReadOnly = true;
            this.DTGColumnCdParticipanteSacado.Width = 90;
            // 
            // DTGColumnNomeSacado
            // 
            this.DTGColumnNomeSacado.DataPropertyName = "NomeSacado";
            this.DTGColumnNomeSacado.HeaderText = "Nome";
            this.DTGColumnNomeSacado.Name = "DTGColumnNomeSacado";
            this.DTGColumnNomeSacado.ReadOnly = true;
            this.DTGColumnNomeSacado.Width = 250;
            // 
            // DTGColumnVencimento
            // 
            this.DTGColumnVencimento.HeaderText = "Vencimento";
            this.DTGColumnVencimento.Name = "DTGColumnVencimento";
            this.DTGColumnVencimento.ReadOnly = true;
            // 
            // DTGColumnEspécie
            // 
            this.DTGColumnEspécie.HeaderText = "Tipo";
            this.DTGColumnEspécie.Name = "DTGColumnEspécie";
            this.DTGColumnEspécie.ReadOnly = true;
            this.DTGColumnEspécie.Width = 70;
            // 
            // DTGColumnSituação
            // 
            this.DTGColumnSituação.HeaderText = "Situação";
            this.DTGColumnSituação.Name = "DTGColumnSituação";
            this.DTGColumnSituação.ReadOnly = true;
            this.DTGColumnSituação.Width = 70;
            // 
            // DTGColumnValor
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DTGColumnValor.DefaultCellStyle = dataGridViewCellStyle3;
            this.DTGColumnValor.HeaderText = "Valor";
            this.DTGColumnValor.Name = "DTGColumnValor";
            this.DTGColumnValor.ReadOnly = true;
            // 
            // DTGColumnValorSaldo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.DTGColumnValorSaldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.DTGColumnValorSaldo.HeaderText = "Saldo";
            this.DTGColumnValorSaldo.Name = "DTGColumnValorSaldo";
            this.DTGColumnValorSaldo.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(734, 9);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 94;
            this.label4.Text = "Valor do Abatimento";
            // 
            // TXTDescricaoContrato
            // 
            this.TXTDescricaoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDescricaoContrato.Location = new System.Drawing.Point(734, 34);
            this.TXTDescricaoContrato.MaxLength = 60;
            this.TXTDescricaoContrato.Name = "TXTDescricaoContrato";
            this.TXTDescricaoContrato.Size = new System.Drawing.Size(200, 26);
            this.TXTDescricaoContrato.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.MinimumSize = new System.Drawing.Size(200, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 22);
            this.label5.TabIndex = 105;
            this.label5.Text = "Liquidar com";
            // 
            // CMBEspecieTitulo
            // 
            this.CMBEspecieTitulo.DropDownHeight = 150;
            this.CMBEspecieTitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBEspecieTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBEspecieTitulo.FormattingEnabled = true;
            this.CMBEspecieTitulo.IntegralHeight = false;
            this.CMBEspecieTitulo.Location = new System.Drawing.Point(221, 13);
            this.CMBEspecieTitulo.Name = "CMBEspecieTitulo";
            this.CMBEspecieTitulo.Size = new System.Drawing.Size(214, 28);
            this.CMBEspecieTitulo.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.MinimumSize = new System.Drawing.Size(200, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 22);
            this.label3.TabIndex = 107;
            this.label3.Text = "Valor do Abatimento";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(221, 113);
            this.textBox1.MaxLength = 60;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 26);
            this.textBox1.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.MinimumSize = new System.Drawing.Size(200, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 22);
            this.label6.TabIndex = 108;
            this.label6.Text = "Vencimento";
            // 
            // DTPDataInicio
            // 
            this.DTPDataInicio.CustomFormat = "dd/MM/yyyy";
            this.DTPDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataInicio.Location = new System.Drawing.Point(313, 83);
            this.DTPDataInicio.Name = "DTPDataInicio";
            this.DTPDataInicio.Size = new System.Drawing.Size(122, 26);
            this.DTPDataInicio.TabIndex = 126;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(680, 14);
            this.textBox6.MaxLength = 14;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(238, 26);
            this.textBox6.TabIndex = 158;
            this.textBox6.Text = "DUPLICATA BB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(465, 14);
            this.label11.MinimumSize = new System.Drawing.Size(200, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 22);
            this.label11.TabIndex = 157;
            this.label11.Text = "Produto Financeiro";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(773, 113);
            this.textBox5.MaxLength = 14;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(145, 26);
            this.textBox5.TabIndex = 156;
            this.textBox5.Text = "40876-6";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(680, 113);
            this.textBox4.MaxLength = 14;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(87, 26);
            this.textBox4.TabIndex = 155;
            this.textBox4.Text = "5555";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(465, 113);
            this.label10.MinimumSize = new System.Drawing.Size(200, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 22);
            this.label10.TabIndex = 154;
            this.label10.Text = "Agênia / Conta";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(680, 81);
            this.textBox3.MaxLength = 14;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(238, 26);
            this.textBox3.TabIndex = 153;
            this.textBox3.Text = "BANCO DO BRASIL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(465, 81);
            this.label9.MinimumSize = new System.Drawing.Size(200, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 22);
            this.label9.TabIndex = 152;
            this.label9.Text = "Descrição";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(680, 49);
            this.textBox2.MaxLength = 14;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 26);
            this.textBox2.TabIndex = 151;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(465, 49);
            this.label7.MinimumSize = new System.Drawing.Size(200, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 22);
            this.label7.TabIndex = 150;
            this.label7.Text = "Cod. Conta Financeira";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.MinimumSize = new System.Drawing.Size(200, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 22);
            this.label8.TabIndex = 159;
            this.label8.Text = "Número Parcelas";
            // 
            // TxtNumeroParcelas
            // 
            this.TxtNumeroParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeroParcelas.Location = new System.Drawing.Point(221, 51);
            this.TxtNumeroParcelas.MaxLength = 60;
            this.TxtNumeroParcelas.Name = "TxtNumeroParcelas";
            this.TxtNumeroParcelas.Size = new System.Drawing.Size(214, 26);
            this.TxtNumeroParcelas.TabIndex = 160;
            // 
            // FrmTituloComando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 490);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.CMDSeleciona);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.DTGTitulos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTSeqContrato);
            this.Controls.Add(this.LBLDocumento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTituloComando";
            this.Text = "FrmTituloComando";
            ((System.ComponentModel.ISupportInitialize)(this.DTGTitulos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTSeqContrato;
        private System.Windows.Forms.Label LBLDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DTGTitulos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button CMDSeleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnSeqTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdParticipanteSacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnNomeSacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEspécie;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnSituação;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnValorSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTDescricaoContrato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMBEspecieTitulo;
        private System.Windows.Forms.DateTimePicker DTPDataInicio;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtNumeroParcelas;
        private System.Windows.Forms.Label label8;
    }
}