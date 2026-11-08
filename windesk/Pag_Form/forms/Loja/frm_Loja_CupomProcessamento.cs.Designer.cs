namespace Pag_Form.forms
{
    partial class frm_Loja_CupomProcessamento
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
            this.cmdefetiva = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtcupomfiscal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtecf = new System.Windows.Forms.TextBox();
            this.dtpdata_movimento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSQLSERVER = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkPostGreFaturamento = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblinfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAMBIENTE = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSQLSERVER_REPROCESSA_STATUS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdefetiva
            // 
            this.cmdefetiva.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdefetiva.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdefetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdefetiva.ForeColor = System.Drawing.Color.Blue;
            this.cmdefetiva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdefetiva.Location = new System.Drawing.Point(408, 6);
            this.cmdefetiva.Name = "cmdefetiva";
            this.cmdefetiva.Size = new System.Drawing.Size(100, 30);
            this.cmdefetiva.TabIndex = 324;
            this.cmdefetiva.Text = "Efetivar";
            this.cmdefetiva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdefetiva.UseVisualStyleBackColor = false;
            this.cmdefetiva.Click += new System.EventHandler(this.cmdefetiva_Click);
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(511, 6);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 323;
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
            this.label12.Location = new System.Drawing.Point(4, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(614, 35);
            this.label12.TabIndex = 322;
            this.label12.Text = "Loja | Processamento de Cupons";
            // 
            // txtcupomfiscal
            // 
            this.txtcupomfiscal.AcceptsTab = true;
            this.txtcupomfiscal.Location = new System.Drawing.Point(259, 86);
            this.txtcupomfiscal.Name = "txtcupomfiscal";
            this.txtcupomfiscal.Size = new System.Drawing.Size(63, 20);
            this.txtcupomfiscal.TabIndex = 334;
            this.txtcupomfiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(93, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 333;
            this.label3.Text = "ECF";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtecf
            // 
            this.txtecf.AcceptsTab = true;
            this.txtecf.Location = new System.Drawing.Point(93, 85);
            this.txtecf.Name = "txtecf";
            this.txtecf.Size = new System.Drawing.Size(64, 20);
            this.txtecf.TabIndex = 332;
            this.txtecf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpdata_movimento
            // 
            this.dtpdata_movimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdata_movimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdata_movimento.Location = new System.Drawing.Point(5, 85);
            this.dtpdata_movimento.Name = "dtpdata_movimento";
            this.dtpdata_movimento.Size = new System.Drawing.Size(82, 21);
            this.dtpdata_movimento.TabIndex = 331;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 330;
            this.label2.Text = "Data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(173, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 21);
            this.label1.TabIndex = 335;
            this.label1.Text = "Cupom Fiscal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSQLSERVER
            // 
            this.chkSQLSERVER.AutoSize = true;
            this.chkSQLSERVER.Checked = true;
            this.chkSQLSERVER.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSQLSERVER.Location = new System.Drawing.Point(594, 64);
            this.chkSQLSERVER.Name = "chkSQLSERVER";
            this.chkSQLSERVER.Size = new System.Drawing.Size(15, 14);
            this.chkSQLSERVER.TabIndex = 337;
            this.chkSQLSERVER.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSQLSERVER.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(343, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 41);
            this.label7.TabIndex = 336;
            this.label7.Text = "Exportação Base ZANTSHU para Base PAG";
            // 
            // chkPostGreFaturamento
            // 
            this.chkPostGreFaturamento.AutoSize = true;
            this.chkPostGreFaturamento.Checked = true;
            this.chkPostGreFaturamento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPostGreFaturamento.Location = new System.Drawing.Point(594, 112);
            this.chkPostGreFaturamento.Name = "chkPostGreFaturamento";
            this.chkPostGreFaturamento.Size = new System.Drawing.Size(15, 14);
            this.chkPostGreFaturamento.TabIndex = 339;
            this.chkPostGreFaturamento.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkPostGreFaturamento.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(343, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 22);
            this.label4.TabIndex = 338;
            this.label4.Text = "Processamento de Registro de Faturamento";
            // 
            // lblinfo
            // 
            this.lblinfo.BackColor = System.Drawing.Color.SlateGray;
            this.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.ForeColor = System.Drawing.Color.White;
            this.lblinfo.Location = new System.Drawing.Point(5, 133);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(613, 21);
            this.lblinfo.TabIndex = 340;
            this.lblinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 341;
            this.label5.Text = "Ambiente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAMBIENTE
            // 
            this.lblAMBIENTE.BackColor = System.Drawing.Color.SlateGray;
            this.lblAMBIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAMBIENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAMBIENTE.ForeColor = System.Drawing.Color.White;
            this.lblAMBIENTE.Location = new System.Drawing.Point(93, 39);
            this.lblAMBIENTE.Name = "lblAMBIENTE";
            this.lblAMBIENTE.Size = new System.Drawing.Size(82, 21);
            this.lblAMBIENTE.TabIndex = 342;
            this.lblAMBIENTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(343, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 22);
            this.label6.TabIndex = 343;
            this.label6.Text = "Com reprocessamento de Status";
            // 
            // chkSQLSERVER_REPROCESSA_STATUS
            // 
            this.chkSQLSERVER_REPROCESSA_STATUS.AutoSize = true;
            this.chkSQLSERVER_REPROCESSA_STATUS.Checked = true;
            this.chkSQLSERVER_REPROCESSA_STATUS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSQLSERVER_REPROCESSA_STATUS.Location = new System.Drawing.Point(532, 83);
            this.chkSQLSERVER_REPROCESSA_STATUS.Name = "chkSQLSERVER_REPROCESSA_STATUS";
            this.chkSQLSERVER_REPROCESSA_STATUS.Size = new System.Drawing.Size(15, 14);
            this.chkSQLSERVER_REPROCESSA_STATUS.TabIndex = 344;
            this.chkSQLSERVER_REPROCESSA_STATUS.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSQLSERVER_REPROCESSA_STATUS.UseVisualStyleBackColor = true;
            // 
            // frm_Loja_CupomProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(622, 162);
            this.Controls.Add(this.chkSQLSERVER_REPROCESSA_STATUS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAMBIENTE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.chkPostGreFaturamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSQLSERVER);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcupomfiscal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtecf);
            this.Controls.Add(this.dtpdata_movimento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdefetiva);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Loja_CupomProcessamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "M4141 | Loja | Cupom | Processamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdefetiva;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtcupomfiscal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtecf;
        private System.Windows.Forms.DateTimePicker dtpdata_movimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSQLSERVER;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPostGreFaturamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAMBIENTE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSQLSERVER_REPROCESSA_STATUS;
    }
}