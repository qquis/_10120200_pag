namespace Pag_Wpf.Operacionais.Locacao
{
    partial class frmContratoLocacaoFaturamento
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
            this.TXTSeqContrato = new System.Windows.Forms.TextBox();
            this.LBLDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.cmdEfetiva = new System.Windows.Forms.Button();
            this.TXTSeqContratoLocacaoFaturamento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTDiaVencimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTNumeroParcelas = new System.Windows.Forms.TextBox();
            this.DTPDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CMBTituloEspecie = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TXTSeqContrato
            // 
            this.TXTSeqContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTSeqContrato.Enabled = false;
            this.TXTSeqContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTSeqContrato.Location = new System.Drawing.Point(280, 50);
            this.TXTSeqContrato.MaxLength = 14;
            this.TXTSeqContrato.Name = "TXTSeqContrato";
            this.TXTSeqContrato.Size = new System.Drawing.Size(122, 26);
            this.TXTSeqContrato.TabIndex = 119;
            this.TXTSeqContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TXTSeqContrato.TextChanged += new System.EventHandler(this.TXTSeqContrato_TextChanged);
            // 
            // LBLDocumento
            // 
            this.LBLDocumento.AutoSize = true;
            this.LBLDocumento.BackColor = System.Drawing.Color.Silver;
            this.LBLDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDocumento.Location = new System.Drawing.Point(24, 54);
            this.LBLDocumento.MinimumSize = new System.Drawing.Size(250, 2);
            this.LBLDocumento.Name = "LBLDocumento";
            this.LBLDocumento.Size = new System.Drawing.Size(250, 22);
            this.LBLDocumento.TabIndex = 116;
            this.LBLDocumento.Text = "Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(240, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 16);
            this.label2.TabIndex = 115;
            this.label2.Text = "Configuração de Faturamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 114;
            this.label1.Text = "Locação de Imóveis";
            // 
            // CmdCancela
            // 
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(757, 212);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(75, 33);
            this.CmdCancela.TabIndex = 128;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            this.CmdCancela.Click += new System.EventHandler(this.CmdCancela_Click);
            // 
            // cmdEfetiva
            // 
            this.cmdEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetiva.Location = new System.Drawing.Point(838, 212);
            this.cmdEfetiva.Name = "cmdEfetiva";
            this.cmdEfetiva.Size = new System.Drawing.Size(75, 33);
            this.cmdEfetiva.TabIndex = 127;
            this.cmdEfetiva.Text = "Efetiva";
            this.cmdEfetiva.UseVisualStyleBackColor = true;
            this.cmdEfetiva.Click += new System.EventHandler(this.cmdEfetiva_Click);
            // 
            // TXTSeqContratoLocacaoFaturamento
            // 
            this.TXTSeqContratoLocacaoFaturamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTSeqContratoLocacaoFaturamento.Enabled = false;
            this.TXTSeqContratoLocacaoFaturamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTSeqContratoLocacaoFaturamento.Location = new System.Drawing.Point(280, 86);
            this.TXTSeqContratoLocacaoFaturamento.MaxLength = 14;
            this.TXTSeqContratoLocacaoFaturamento.Name = "TXTSeqContratoLocacaoFaturamento";
            this.TXTSeqContratoLocacaoFaturamento.Size = new System.Drawing.Size(122, 26);
            this.TXTSeqContratoLocacaoFaturamento.TabIndex = 130;
            this.TXTSeqContratoLocacaoFaturamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TXTSeqContratoLocacaoFaturamento.TextChanged += new System.EventHandler(this.TXTSeqContratoLocacaoFaturamento_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 86);
            this.label6.MinimumSize = new System.Drawing.Size(250, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 22);
            this.label6.TabIndex = 129;
            this.label6.Text = "Conf. Cod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.MinimumSize = new System.Drawing.Size(250, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 22);
            this.label4.TabIndex = 134;
            this.label4.Text = "Dia de Vencimento";
            // 
            // TXTDiaVencimento
            // 
            this.TXTDiaVencimento.BackColor = System.Drawing.Color.LightGray;
            this.TXTDiaVencimento.Enabled = false;
            this.TXTDiaVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDiaVencimento.Location = new System.Drawing.Point(280, 118);
            this.TXTDiaVencimento.MaxLength = 60;
            this.TXTDiaVencimento.Name = "TXTDiaVencimento";
            this.TXTDiaVencimento.Size = new System.Drawing.Size(122, 26);
            this.TXTDiaVencimento.TabIndex = 133;
            this.TXTDiaVencimento.TextChanged += new System.EventHandler(this.TXTDiaVencimento_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 150);
            this.label5.MinimumSize = new System.Drawing.Size(250, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 22);
            this.label5.TabIndex = 135;
            this.label5.Text = "Número de Parcelas";
            // 
            // TXTNumeroParcelas
            // 
            this.TXTNumeroParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNumeroParcelas.Location = new System.Drawing.Point(280, 150);
            this.TXTNumeroParcelas.MaxLength = 60;
            this.TXTNumeroParcelas.Name = "TXTNumeroParcelas";
            this.TXTNumeroParcelas.Size = new System.Drawing.Size(122, 26);
            this.TXTNumeroParcelas.TabIndex = 136;
            this.TXTNumeroParcelas.TextChanged += new System.EventHandler(this.TXTNumeroParcelas_TextChanged);
            // 
            // DTPDataInicial
            // 
            this.DTPDataInicial.CustomFormat = "dd/MM/yyyy";
            this.DTPDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataInicial.Location = new System.Drawing.Point(280, 183);
            this.DTPDataInicial.Name = "DTPDataInicial";
            this.DTPDataInicial.Size = new System.Drawing.Size(122, 26);
            this.DTPDataInicial.TabIndex = 138;
            this.DTPDataInicial.ValueChanged += new System.EventHandler(this.DTPDataInicial_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 183);
            this.label7.MinimumSize = new System.Drawing.Size(250, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 22);
            this.label7.TabIndex = 137;
            this.label7.Text = "Data Inicial";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(675, 121);
            this.textBox1.MaxLength = 14;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 26);
            this.textBox1.TabIndex = 140;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(419, 121);
            this.label3.MinimumSize = new System.Drawing.Size(200, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 22);
            this.label3.TabIndex = 139;
            this.label3.Text = "Cod. Conta Financeira";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(419, 51);
            this.label8.MinimumSize = new System.Drawing.Size(200, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 22);
            this.label8.TabIndex = 141;
            this.label8.Text = "Espécie de Pagamento";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(675, 153);
            this.textBox3.MaxLength = 14;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(238, 26);
            this.textBox3.TabIndex = 144;
            this.textBox3.Text = "BANCO DO BRASIL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(419, 153);
            this.label9.MinimumSize = new System.Drawing.Size(200, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 22);
            this.label9.TabIndex = 143;
            this.label9.Text = "Descrição";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(675, 185);
            this.textBox4.MaxLength = 14;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(87, 26);
            this.textBox4.TabIndex = 146;
            this.textBox4.Text = "5555";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(419, 185);
            this.label10.MinimumSize = new System.Drawing.Size(200, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 22);
            this.label10.TabIndex = 145;
            this.label10.Text = "Agênia / Conta";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(768, 185);
            this.textBox5.MaxLength = 14;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(145, 26);
            this.textBox5.TabIndex = 147;
            this.textBox5.Text = "40876-6";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(675, 86);
            this.textBox6.MaxLength = 14;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(238, 26);
            this.textBox6.TabIndex = 149;
            this.textBox6.Text = "DUPLICATA BB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(419, 86);
            this.label11.MinimumSize = new System.Drawing.Size(200, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 22);
            this.label11.TabIndex = 148;
            this.label11.Text = "Produto Financeiro";
            // 
            // CMBTituloEspecie
            // 
            this.CMBTituloEspecie.DropDownHeight = 150;
            this.CMBTituloEspecie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBTituloEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBTituloEspecie.FormattingEnabled = true;
            this.CMBTituloEspecie.IntegralHeight = false;
            this.CMBTituloEspecie.Location = new System.Drawing.Point(675, 48);
            this.CMBTituloEspecie.Name = "CMBTituloEspecie";
            this.CMBTituloEspecie.Size = new System.Drawing.Size(238, 28);
            this.CMBTituloEspecie.TabIndex = 150;
            // 
            // frmContratoLocacaoFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 257);
            this.Controls.Add(this.CMBTituloEspecie);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTPDataInicial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXTNumeroParcelas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTDiaVencimento);
            this.Controls.Add(this.TXTSeqContratoLocacaoFaturamento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.cmdEfetiva);
            this.Controls.Add(this.TXTSeqContrato);
            this.Controls.Add(this.LBLDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContratoLocacaoFaturamento";
            this.Text = "frmContratoLocacaoFaturamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTSeqContrato;
        private System.Windows.Forms.Label LBLDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button cmdEfetiva;
        private System.Windows.Forms.TextBox TXTSeqContratoLocacaoFaturamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTDiaVencimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTNumeroParcelas;
        private System.Windows.Forms.DateTimePicker DTPDataInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CMBTituloEspecie;

    }
}