namespace Pag_Form.forms.Ativo
{
    partial class frm_ativo_list
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
            this.dtga = new System.Windows.Forms.DataGridView();
            this.atga_at_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtga_at_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtga_at_tipo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbat_tipo_descricao_buscar = new System.Windows.Forms.ComboBox();
            this.cmdpesquisar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtat_descricao_buscar = new System.Windows.Forms.TextBox();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.cmdSelecionar = new System.Windows.Forms.Button();
            this.lbl_a = new System.Windows.Forms.Label();
            this.lblat_seq = new System.Windows.Forms.Label();
            this.cmdIncluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtga)).BeginInit();
            this.SuspendLayout();
            // 
            // dtga
            // 
            this.dtga.AllowUserToAddRows = false;
            this.dtga.AllowUserToDeleteRows = false;
            this.dtga.AllowUserToResizeRows = false;
            this.dtga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtga.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.atga_at_seq,
            this.dtga_at_descricao,
            this.dtga_at_tipo_descricao});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtga.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtga.Location = new System.Drawing.Point(13, 122);
            this.dtga.Margin = new System.Windows.Forms.Padding(4);
            this.dtga.Name = "dtga";
            this.dtga.ReadOnly = true;
            this.dtga.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtga.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtga.RowHeadersVisible = false;
            this.dtga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtga.Size = new System.Drawing.Size(848, 287);
            this.dtga.TabIndex = 764;
            // 
            // atga_at_seq
            // 
            this.atga_at_seq.DataPropertyName = "at_seq";
            this.atga_at_seq.HeaderText = "Seq.";
            this.atga_at_seq.Name = "atga_at_seq";
            this.atga_at_seq.ReadOnly = true;
            this.atga_at_seq.Width = 90;
            // 
            // dtga_at_descricao
            // 
            this.dtga_at_descricao.DataPropertyName = "at_descricao";
            this.dtga_at_descricao.HeaderText = "Descrição";
            this.dtga_at_descricao.Name = "dtga_at_descricao";
            this.dtga_at_descricao.ReadOnly = true;
            this.dtga_at_descricao.Width = 270;
            // 
            // dtga_at_tipo_descricao
            // 
            this.dtga_at_tipo_descricao.DataPropertyName = "at_tipo_descricao";
            this.dtga_at_tipo_descricao.HeaderText = "Tipo";
            this.dtga_at_tipo_descricao.Name = "dtga_at_tipo_descricao";
            this.dtga_at_tipo_descricao.ReadOnly = true;
            this.dtga_at_tipo_descricao.Width = 300;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 763;
            this.label1.Text = "Tipo de Registro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbat_tipo_descricao_buscar
            // 
            this.cmbat_tipo_descricao_buscar.Enabled = false;
            this.cmbat_tipo_descricao_buscar.FormattingEnabled = true;
            this.cmbat_tipo_descricao_buscar.Location = new System.Drawing.Point(13, 91);
            this.cmbat_tipo_descricao_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.cmbat_tipo_descricao_buscar.Name = "cmbat_tipo_descricao_buscar";
            this.cmbat_tipo_descricao_buscar.Size = new System.Drawing.Size(217, 24);
            this.cmbat_tipo_descricao_buscar.TabIndex = 762;
            // 
            // cmdpesquisar
            // 
            this.cmdpesquisar.BackColor = System.Drawing.Color.White;
            this.cmdpesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdpesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdpesquisar.ForeColor = System.Drawing.Color.Blue;
            this.cmdpesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdpesquisar.Location = new System.Drawing.Point(588, 12);
            this.cmdpesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdpesquisar.Name = "cmdpesquisar";
            this.cmdpesquisar.Size = new System.Drawing.Size(133, 37);
            this.cmdpesquisar.TabIndex = 761;
            this.cmdpesquisar.Text = "Pesquisar";
            this.cmdpesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdpesquisar.UseVisualStyleBackColor = false;
            this.cmdpesquisar.Click += new System.EventHandler(this.cmdpesquisar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(238, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(500, 25);
            this.label8.TabIndex = 760;
            this.label8.Text = "Descrição do Ativo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtat_descricao_buscar
            // 
            this.txtat_descricao_buscar.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtat_descricao_buscar.Enabled = false;
            this.txtat_descricao_buscar.Location = new System.Drawing.Point(238, 92);
            this.txtat_descricao_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtat_descricao_buscar.Name = "txtat_descricao_buscar";
            this.txtat_descricao_buscar.Size = new System.Drawing.Size(500, 22);
            this.txtat_descricao_buscar.TabIndex = 759;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(723, 12);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 758;
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
            this.label12.Location = new System.Drawing.Point(13, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(848, 43);
            this.label12.TabIndex = 757;
            this.label12.Text = "Lista de Ativos";
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.BackColor = System.Drawing.Color.White;
            this.cmdDetalhe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDetalhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetalhe.ForeColor = System.Drawing.Color.Blue;
            this.cmdDetalhe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDetalhe.Location = new System.Drawing.Point(822, 417);
            this.cmdDetalhe.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(39, 37);
            this.cmdDetalhe.TabIndex = 765;
            this.cmdDetalhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDetalhe.UseVisualStyleBackColor = false;
            this.cmdDetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // cmdSelecionar
            // 
            this.cmdSelecionar.BackColor = System.Drawing.Color.White;
            this.cmdSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelecionar.ForeColor = System.Drawing.Color.Blue;
            this.cmdSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSelecionar.Location = new System.Drawing.Point(686, 417);
            this.cmdSelecionar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelecionar.Name = "cmdSelecionar";
            this.cmdSelecionar.Size = new System.Drawing.Size(133, 37);
            this.cmdSelecionar.TabIndex = 766;
            this.cmdSelecionar.Text = "Selecionar";
            this.cmdSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSelecionar.UseVisualStyleBackColor = false;
            // 
            // lbl_a
            // 
            this.lbl_a.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_a.ForeColor = System.Drawing.Color.White;
            this.lbl_a.Location = new System.Drawing.Point(13, 417);
            this.lbl_a.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_a.Name = "lbl_a";
            this.lbl_a.Size = new System.Drawing.Size(145, 24);
            this.lbl_a.TabIndex = 767;
            this.lbl_a.Text = "Ativo Selecionado";
            this.lbl_a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblat_seq
            // 
            this.lblat_seq.BackColor = System.Drawing.Color.SlateGray;
            this.lblat_seq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblat_seq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblat_seq.ForeColor = System.Drawing.Color.White;
            this.lblat_seq.Location = new System.Drawing.Point(166, 417);
            this.lblat_seq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblat_seq.Name = "lblat_seq";
            this.lblat_seq.Size = new System.Drawing.Size(145, 24);
            this.lblat_seq.TabIndex = 768;
            this.lblat_seq.Tag = "at_seq";
            this.lblat_seq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdIncluir
            // 
            this.cmdIncluir.BackColor = System.Drawing.Color.White;
            this.cmdIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIncluir.ForeColor = System.Drawing.Color.Blue;
            this.cmdIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdIncluir.Location = new System.Drawing.Point(547, 12);
            this.cmdIncluir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdIncluir.Name = "cmdIncluir";
            this.cmdIncluir.Size = new System.Drawing.Size(39, 37);
            this.cmdIncluir.TabIndex = 774;
            this.cmdIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdIncluir.UseVisualStyleBackColor = false;
            this.cmdIncluir.Click += new System.EventHandler(this.cmdIncluir_Click);
            // 
            // frm_ativo_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(874, 468);
            this.Controls.Add(this.cmdIncluir);
            this.Controls.Add(this.lblat_seq);
            this.Controls.Add(this.lbl_a);
            this.Controls.Add(this.cmdSelecionar);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.dtga);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbat_tipo_descricao_buscar);
            this.Controls.Add(this.cmdpesquisar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtat_descricao_buscar);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ativo_list";
            this.Text = "m4351 | Ativo List";
            ((System.ComponentModel.ISupportInitialize)(this.dtga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbat_tipo_descricao_buscar;
        private System.Windows.Forms.Button cmdpesquisar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtat_descricao_buscar;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn atga_at_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtga_at_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtga_at_tipo_descricao;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.Button cmdSelecionar;
        private System.Windows.Forms.Label lbl_a;
        private System.Windows.Forms.Label lblat_seq;
        private System.Windows.Forms.Button cmdIncluir;

    }
}