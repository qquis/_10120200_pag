namespace Pag_Wpf.Operacionais.Locacao
{
    partial class FrmContrato
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
            this.LBLDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTDescricaoContrato = new System.Windows.Forms.TextBox();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.cmdEfetiva = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CMBOperacao = new System.Windows.Forms.ComboBox();
            this.TXTSeqContrato = new System.Windows.Forms.TextBox();
            this.LblDataInicio = new System.Windows.Forms.Label();
            this.DTPDataContrato = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.DTPDataInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPDataFim = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBLDocumento
            // 
            this.LBLDocumento.AutoSize = true;
            this.LBLDocumento.BackColor = System.Drawing.Color.Silver;
            this.LBLDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDocumento.Location = new System.Drawing.Point(30, 60);
            this.LBLDocumento.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLDocumento.Name = "LBLDocumento";
            this.LBLDocumento.Size = new System.Drawing.Size(200, 22);
            this.LBLDocumento.TabIndex = 97;
            this.LBLDocumento.Text = "Contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(542, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 96;
            this.label2.Text = "Contratos de Locação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 95;
            this.label1.Text = "Cadastros";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 127);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 92;
            this.label4.Text = "Descrição";
            // 
            // TXTDescricaoContrato
            // 
            this.TXTDescricaoContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDescricaoContrato.Location = new System.Drawing.Point(245, 126);
            this.TXTDescricaoContrato.MaxLength = 60;
            this.TXTDescricaoContrato.Name = "TXTDescricaoContrato";
            this.TXTDescricaoContrato.Size = new System.Drawing.Size(420, 26);
            this.TXTDescricaoContrato.TabIndex = 91;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Blue;
            this.lineShape2.BorderWidth = 5;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 20;
            this.lineShape2.X2 = 691;
            this.lineShape2.Y1 = 233;
            this.lineShape2.Y2 = 233;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Blue;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 28;
            this.lineShape1.X2 = 701;
            this.lineShape1.Y1 = 48;
            this.lineShape1.Y2 = 48;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1,
            this.lineShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(712, 286);
            this.shapeContainer1.TabIndex = 99;
            this.shapeContainer1.TabStop = false;
            // 
            // CmdCancela
            // 
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(617, 244);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(75, 33);
            this.CmdCancela.TabIndex = 101;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            this.CmdCancela.Click += new System.EventHandler(this.CmdCancela_Click);
            // 
            // cmdEfetiva
            // 
            this.cmdEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetiva.Location = new System.Drawing.Point(536, 244);
            this.cmdEfetiva.Name = "cmdEfetiva";
            this.cmdEfetiva.Size = new System.Drawing.Size(75, 33);
            this.cmdEfetiva.TabIndex = 100;
            this.cmdEfetiva.Text = "Efetiva";
            this.cmdEfetiva.UseVisualStyleBackColor = true;
            this.cmdEfetiva.Click += new System.EventHandler(this.cmdEfetiva_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 92);
            this.label5.MinimumSize = new System.Drawing.Size(200, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 22);
            this.label5.TabIndex = 103;
            this.label5.Text = "Operação";
            // 
            // CMBOperacao
            // 
            this.CMBOperacao.DropDownHeight = 150;
            this.CMBOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBOperacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBOperacao.FormattingEnabled = true;
            this.CMBOperacao.IntegralHeight = false;
            this.CMBOperacao.Location = new System.Drawing.Point(245, 92);
            this.CMBOperacao.Name = "CMBOperacao";
            this.CMBOperacao.Size = new System.Drawing.Size(420, 28);
            this.CMBOperacao.TabIndex = 102;
            // 
            // TXTSeqContrato
            // 
            this.TXTSeqContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTSeqContrato.Enabled = false;
            this.TXTSeqContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTSeqContrato.Location = new System.Drawing.Point(245, 60);
            this.TXTSeqContrato.MaxLength = 14;
            this.TXTSeqContrato.Name = "TXTSeqContrato";
            this.TXTSeqContrato.Size = new System.Drawing.Size(122, 26);
            this.TXTSeqContrato.TabIndex = 113;
            this.TXTSeqContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblDataInicio
            // 
            this.LblDataInicio.AutoSize = true;
            this.LblDataInicio.BackColor = System.Drawing.Color.Silver;
            this.LblDataInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDataInicio.Location = new System.Drawing.Point(30, 162);
            this.LblDataInicio.MinimumSize = new System.Drawing.Size(200, 2);
            this.LblDataInicio.Name = "LblDataInicio";
            this.LblDataInicio.Size = new System.Drawing.Size(200, 22);
            this.LblDataInicio.TabIndex = 123;
            this.LblDataInicio.Text = "Assinatura ";
            // 
            // DTPDataContrato
            // 
            this.DTPDataContrato.CustomFormat = "dd/MM/yyyy";
            this.DTPDataContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataContrato.Location = new System.Drawing.Point(245, 162);
            this.DTPDataContrato.Name = "DTPDataContrato";
            this.DTPDataContrato.Size = new System.Drawing.Size(122, 26);
            this.DTPDataContrato.TabIndex = 122;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 196);
            this.label7.MinimumSize = new System.Drawing.Size(200, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 22);
            this.label7.TabIndex = 124;
            this.label7.Text = "Validade";
            // 
            // DTPDataInicio
            // 
            this.DTPDataInicio.CustomFormat = "dd/MM/yyyy";
            this.DTPDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataInicio.Location = new System.Drawing.Point(245, 196);
            this.DTPDataInicio.Name = "DTPDataInicio";
            this.DTPDataInicio.Size = new System.Drawing.Size(122, 26);
            this.DTPDataInicio.TabIndex = 125;
            // 
            // DTPDataFim
            // 
            this.DTPDataFim.CustomFormat = "dd/MM/yyyy";
            this.DTPDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataFim.Location = new System.Drawing.Point(399, 196);
            this.DTPDataFim.Name = "DTPDataFim";
            this.DTPDataFim.Size = new System.Drawing.Size(122, 26);
            this.DTPDataFim.TabIndex = 126;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(373, 196);
            this.label8.MinimumSize = new System.Drawing.Size(10, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 22);
            this.label8.TabIndex = 127;
            this.label8.Text = "a";
            // 
            // FrmContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 286);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DTPDataFim);
            this.Controls.Add(this.DTPDataInicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblDataInicio);
            this.Controls.Add(this.DTPDataContrato);
            this.Controls.Add(this.TXTSeqContrato);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMBOperacao);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.cmdEfetiva);
            this.Controls.Add(this.LBLDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTDescricaoContrato);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContrato";
            this.Text = "FrmContrato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTDescricaoContrato;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button cmdEfetiva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMBOperacao;
        private System.Windows.Forms.TextBox TXTSeqContrato;
        private System.Windows.Forms.Label LblDataInicio;
        private System.Windows.Forms.DateTimePicker DTPDataContrato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DTPDataInicio;
        private System.Windows.Forms.DateTimePicker DTPDataFim;
        private System.Windows.Forms.Label label8;
    }
}