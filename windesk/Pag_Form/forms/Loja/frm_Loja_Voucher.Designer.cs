namespace Pag_Form.forms
{
    partial class frm_Loja_Voucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgvoucher = new System.Windows.Forms.DataGridView();
            this.dtgvoucher_voucher_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_voucher_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_voucher_data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_dtlog_insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_cpf_cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_documento_cnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_cdpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_nome_razao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvoucher_data_nascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_voucher = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdEfetivar_Voucher_Primeira_Compra = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.cmdlistar = new System.Windows.Forms.Button();
            this.cmdEfetivar_Voucher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvoucher)).BeginInit();
            this.tab_voucher.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(1017, 9);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 235;
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
            this.label12.Location = new System.Drawing.Point(8, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1149, 43);
            this.label12.TabIndex = 234;
            this.label12.Text = "Loja | Voucher";
            // 
            // dtgvoucher
            // 
            this.dtgvoucher.AllowUserToAddRows = false;
            this.dtgvoucher.AllowUserToDeleteRows = false;
            this.dtgvoucher.AllowUserToResizeRows = false;
            this.dtgvoucher.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvoucher.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvoucher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgvoucher_voucher_seq,
            this.dtgvoucher_voucher_cd,
            this.dtgvoucher_voucher_data,
            this.dtgvoucher_dtlog_insert,
            this.dtgvoucher_cpf_cnpj,
            this.dtgvoucher_documento_cnh,
            this.dtgvoucher_cdpessoa,
            this.dtgvoucher_nome_razao,
            this.dtgvoucher_data_nascimento});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvoucher.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvoucher.Location = new System.Drawing.Point(8, 170);
            this.dtgvoucher.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvoucher.Name = "dtgvoucher";
            this.dtgvoucher.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvoucher.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvoucher.RowHeadersVisible = false;
            this.dtgvoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvoucher.Size = new System.Drawing.Size(1141, 326);
            this.dtgvoucher.TabIndex = 283;
            // 
            // dtgvoucher_voucher_seq
            // 
            this.dtgvoucher_voucher_seq.DataPropertyName = "voucher_seq";
            this.dtgvoucher_voucher_seq.HeaderText = "Voucher Seq";
            this.dtgvoucher_voucher_seq.Name = "dtgvoucher_voucher_seq";
            this.dtgvoucher_voucher_seq.Width = 80;
            // 
            // dtgvoucher_voucher_cd
            // 
            this.dtgvoucher_voucher_cd.DataPropertyName = "voucher_cd";
            this.dtgvoucher_voucher_cd.HeaderText = "N. Voucher";
            this.dtgvoucher_voucher_cd.Name = "dtgvoucher_voucher_cd";
            // 
            // dtgvoucher_voucher_data
            // 
            this.dtgvoucher_voucher_data.DataPropertyName = "voucher_data";
            this.dtgvoucher_voucher_data.HeaderText = "Data";
            this.dtgvoucher_voucher_data.Name = "dtgvoucher_voucher_data";
            this.dtgvoucher_voucher_data.Width = 80;
            // 
            // dtgvoucher_dtlog_insert
            // 
            this.dtgvoucher_dtlog_insert.DataPropertyName = "dtlog_insert";
            dataGridViewCellStyle2.Format = "HH:mm:ss";
            this.dtgvoucher_dtlog_insert.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvoucher_dtlog_insert.HeaderText = "Hora";
            this.dtgvoucher_dtlog_insert.Name = "dtgvoucher_dtlog_insert";
            this.dtgvoucher_dtlog_insert.Width = 70;
            // 
            // dtgvoucher_cpf_cnpj
            // 
            this.dtgvoucher_cpf_cnpj.DataPropertyName = "voucher_cpf_cnpj";
            this.dtgvoucher_cpf_cnpj.HeaderText = "CPF";
            this.dtgvoucher_cpf_cnpj.Name = "dtgvoucher_cpf_cnpj";
            this.dtgvoucher_cpf_cnpj.Width = 90;
            // 
            // dtgvoucher_documento_cnh
            // 
            this.dtgvoucher_documento_cnh.DataPropertyName = "voucher_documento_cnh";
            this.dtgvoucher_documento_cnh.HeaderText = "CNH";
            this.dtgvoucher_documento_cnh.Name = "dtgvoucher_documento_cnh";
            this.dtgvoucher_documento_cnh.Width = 70;
            // 
            // dtgvoucher_cdpessoa
            // 
            this.dtgvoucher_cdpessoa.DataPropertyName = "cdpessoa";
            this.dtgvoucher_cdpessoa.HeaderText = "Cd Pessoa";
            this.dtgvoucher_cdpessoa.Name = "dtgvoucher_cdpessoa";
            this.dtgvoucher_cdpessoa.Width = 60;
            // 
            // dtgvoucher_nome_razao
            // 
            this.dtgvoucher_nome_razao.DataPropertyName = "nome_razao";
            this.dtgvoucher_nome_razao.HeaderText = "Nome ";
            this.dtgvoucher_nome_razao.Name = "dtgvoucher_nome_razao";
            this.dtgvoucher_nome_razao.Width = 250;
            // 
            // dtgvoucher_data_nascimento
            // 
            this.dtgvoucher_data_nascimento.DataPropertyName = "data_nascimento";
            this.dtgvoucher_data_nascimento.HeaderText = "Data Nascimento";
            this.dtgvoucher_data_nascimento.Name = "dtgvoucher_data_nascimento";
            this.dtgvoucher_data_nascimento.Width = 80;
            // 
            // tab_voucher
            // 
            this.tab_voucher.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tab_voucher.Controls.Add(this.tabPage1);
            this.tab_voucher.Location = new System.Drawing.Point(8, 53);
            this.tab_voucher.Margin = new System.Windows.Forms.Padding(4);
            this.tab_voucher.Name = "tab_voucher";
            this.tab_voucher.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tab_voucher.SelectedIndex = 0;
            this.tab_voucher.Size = new System.Drawing.Size(1143, 110);
            this.tab_voucher.TabIndex = 321;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.cmdEfetivar_Voucher);
            this.tabPage1.Controls.Add(this.cmdEfetivar_Voucher_Primeira_Compra);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtCPF);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1135, 78);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Novo VOUCHER";
            // 
            // cmdEfetivar_Voucher_Primeira_Compra
            // 
            this.cmdEfetivar_Voucher_Primeira_Compra.BackColor = System.Drawing.Color.White;
            this.cmdEfetivar_Voucher_Primeira_Compra.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdEfetivar_Voucher_Primeira_Compra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEfetivar_Voucher_Primeira_Compra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdEfetivar_Voucher_Primeira_Compra.ForeColor = System.Drawing.Color.Blue;
            this.cmdEfetivar_Voucher_Primeira_Compra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEfetivar_Voucher_Primeira_Compra.Location = new System.Drawing.Point(624, 15);
            this.cmdEfetivar_Voucher_Primeira_Compra.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEfetivar_Voucher_Primeira_Compra.Name = "cmdEfetivar_Voucher_Primeira_Compra";
            this.cmdEfetivar_Voucher_Primeira_Compra.Size = new System.Drawing.Size(206, 37);
            this.cmdEfetivar_Voucher_Primeira_Compra.TabIndex = 327;
            this.cmdEfetivar_Voucher_Primeira_Compra.Text = "Primeira Compra";
            this.cmdEfetivar_Voucher_Primeira_Compra.UseVisualStyleBackColor = false;
            this.cmdEfetivar_Voucher_Primeira_Compra.Click += new System.EventHandler(this.cmdEfetivar_Voucher_Primeira_Compra_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 25);
            this.label6.TabIndex = 325;
            this.label6.Text = "CPF";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCPF
            // 
            this.txtCPF.AcceptsTab = true;
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(332, 15);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(265, 24);
            this.txtCPF.TabIndex = 0;
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
            this.txtCPF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCPF_KeyUp);
            // 
            // cmdlistar
            // 
            this.cmdlistar.BackColor = System.Drawing.Color.White;
            this.cmdlistar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdlistar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdlistar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdlistar.ForeColor = System.Drawing.Color.Blue;
            this.cmdlistar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdlistar.Location = new System.Drawing.Point(876, 9);
            this.cmdlistar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdlistar.Name = "cmdlistar";
            this.cmdlistar.Size = new System.Drawing.Size(133, 37);
            this.cmdlistar.TabIndex = 322;
            this.cmdlistar.Text = "Listar";
            this.cmdlistar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdlistar.UseVisualStyleBackColor = false;
            this.cmdlistar.Click += new System.EventHandler(this.cmdlistar_Click);
            // 
            // cmdEfetivar_Voucher
            // 
            this.cmdEfetivar_Voucher.BackColor = System.Drawing.Color.White;
            this.cmdEfetivar_Voucher.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdEfetivar_Voucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEfetivar_Voucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdEfetivar_Voucher.ForeColor = System.Drawing.Color.Blue;
            this.cmdEfetivar_Voucher.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEfetivar_Voucher.Location = new System.Drawing.Point(850, 15);
            this.cmdEfetivar_Voucher.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEfetivar_Voucher.Name = "cmdEfetivar_Voucher";
            this.cmdEfetivar_Voucher.Size = new System.Drawing.Size(206, 37);
            this.cmdEfetivar_Voucher.TabIndex = 328;
            this.cmdEfetivar_Voucher.Text = "Promoção WhatsApp";
            this.cmdEfetivar_Voucher.UseVisualStyleBackColor = false;
            this.cmdEfetivar_Voucher.Click += new System.EventHandler(this.cmdEfetivar_Voucher_Click);
            // 
            // frm_Loja_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1164, 510);
            this.Controls.Add(this.cmdlistar);
            this.Controls.Add(this.tab_voucher);
            this.Controls.Add(this.dtgvoucher);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Loja_Voucher";
            this.Text = "m4130";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvoucher)).EndInit();
            this.tab_voucher.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgvoucher;
        private System.Windows.Forms.TabControl tab_voucher;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Button cmdlistar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_voucher_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_voucher_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_voucher_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_dtlog_insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_cpf_cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_documento_cnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_cdpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_nome_razao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgvoucher_data_nascimento;
        private System.Windows.Forms.Button cmdEfetivar_Voucher_Primeira_Compra;
        private System.Windows.Forms.Button cmdEfetivar_Voucher;
    }
}