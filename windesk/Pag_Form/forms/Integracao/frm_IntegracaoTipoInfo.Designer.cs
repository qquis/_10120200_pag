namespace Pag_Form.forms.Integracao
{
    partial class frm_IntegracaoTipoInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdsair = new System.Windows.Forms.Button();
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgI = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsis_batch_cd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntegracaoTipoCd = new System.Windows.Forms.TextBox();
            this.dtgPIintegracao_produto_seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dti_integracao_tipo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_sis_batch_service_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_sis_batch_service_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_module_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_sis_batch_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_sis_batch_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgi_script_select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtscript_select = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgI)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(1321, 11);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 207;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(1187, 11);
            this.cmdConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(133, 37);
            this.cmdConsultar.TabIndex = 205;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(9, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1449, 43);
            this.label12.TabIndex = 206;
            this.label12.Text = "Informações de Tipo de Integrações";
            // 
            // dtgI
            // 
            this.dtgI.AllowUserToAddRows = false;
            this.dtgI.AllowUserToDeleteRows = false;
            this.dtgI.AllowUserToResizeRows = false;
            this.dtgI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgPIintegracao_produto_seq,
            this.dti_integracao_tipo_descricao,
            this.dtgi_sis_batch_service_cd,
            this.dtgi_sis_batch_service_descricao,
            this.dtgi_module_cd,
            this.dtgi_sis_batch_cd,
            this.dtgi_sis_batch_descricao,
            this.dtgi_script_select});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgI.DefaultCellStyle = dataGridViewCellStyle15;
            this.dtgI.Location = new System.Drawing.Point(9, 126);
            this.dtgI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgI.Name = "dtgI";
            this.dtgI.ReadOnly = true;
            this.dtgI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgI.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgI.RowHeadersVisible = false;
            this.dtgI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgI.Size = new System.Drawing.Size(1456, 254);
            this.dtgI.TabIndex = 283;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 25);
            this.label5.TabIndex = 287;
            this.label5.Text = "Batch Cd";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsis_batch_cd
            // 
            this.txtsis_batch_cd.AcceptsTab = true;
            this.txtsis_batch_cd.Location = new System.Drawing.Point(9, 79);
            this.txtsis_batch_cd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsis_batch_cd.Name = "txtsis_batch_cd";
            this.txtsis_batch_cd.Size = new System.Drawing.Size(176, 22);
            this.txtsis_batch_cd.TabIndex = 286;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(195, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 289;
            this.label1.Text = "Integração Tipo  Cd";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIntegracaoTipoCd
            // 
            this.txtIntegracaoTipoCd.AcceptsTab = true;
            this.txtIntegracaoTipoCd.Location = new System.Drawing.Point(195, 79);
            this.txtIntegracaoTipoCd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIntegracaoTipoCd.Name = "txtIntegracaoTipoCd";
            this.txtIntegracaoTipoCd.Size = new System.Drawing.Size(176, 22);
            this.txtIntegracaoTipoCd.TabIndex = 288;
            // 
            // dtgPIintegracao_produto_seq
            // 
            this.dtgPIintegracao_produto_seq.DataPropertyName = "integracao_tipo_cd";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgPIintegracao_produto_seq.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtgPIintegracao_produto_seq.HeaderText = "CTipo de Integração ";
            this.dtgPIintegracao_produto_seq.Name = "dtgPIintegracao_produto_seq";
            this.dtgPIintegracao_produto_seq.ReadOnly = true;
            this.dtgPIintegracao_produto_seq.Width = 55;
            // 
            // dti_integracao_tipo_descricao
            // 
            this.dti_integracao_tipo_descricao.DataPropertyName = "integracao_tipo_descricao";
            this.dti_integracao_tipo_descricao.HeaderText = "Tipo de Integração";
            this.dti_integracao_tipo_descricao.Name = "dti_integracao_tipo_descricao";
            this.dti_integracao_tipo_descricao.ReadOnly = true;
            // 
            // dtgi_sis_batch_service_cd
            // 
            this.dtgi_sis_batch_service_cd.DataPropertyName = "sis_batch_service_cd";
            this.dtgi_sis_batch_service_cd.HeaderText = "Service Batch Cd";
            this.dtgi_sis_batch_service_cd.Name = "dtgi_sis_batch_service_cd";
            this.dtgi_sis_batch_service_cd.ReadOnly = true;
            // 
            // dtgi_sis_batch_service_descricao
            // 
            this.dtgi_sis_batch_service_descricao.DataPropertyName = "sis_batch_service_descricao";
            this.dtgi_sis_batch_service_descricao.HeaderText = "Batch Service Descrição";
            this.dtgi_sis_batch_service_descricao.Name = "dtgi_sis_batch_service_descricao";
            this.dtgi_sis_batch_service_descricao.ReadOnly = true;
            // 
            // dtgi_module_cd
            // 
            this.dtgi_module_cd.DataPropertyName = "module_cd";
            this.dtgi_module_cd.HeaderText = "Módulo";
            this.dtgi_module_cd.Name = "dtgi_module_cd";
            this.dtgi_module_cd.ReadOnly = true;
            // 
            // dtgi_sis_batch_cd
            // 
            this.dtgi_sis_batch_cd.DataPropertyName = "sis_batch_cd";
            this.dtgi_sis_batch_cd.HeaderText = "Código do Batch";
            this.dtgi_sis_batch_cd.Name = "dtgi_sis_batch_cd";
            this.dtgi_sis_batch_cd.ReadOnly = true;
            // 
            // dtgi_sis_batch_descricao
            // 
            this.dtgi_sis_batch_descricao.DataPropertyName = "sis_batch_descricao";
            this.dtgi_sis_batch_descricao.HeaderText = "Batch";
            this.dtgi_sis_batch_descricao.Name = "dtgi_sis_batch_descricao";
            this.dtgi_sis_batch_descricao.ReadOnly = true;
            // 
            // dtgi_script_select
            // 
            this.dtgi_script_select.DataPropertyName = "script_select";
            this.dtgi_script_select.HeaderText = "Fonte no Postgre (Script Select)";
            this.dtgi_script_select.Name = "dtgi_script_select";
            this.dtgi_script_select.ReadOnly = true;
            // 
            // txtscript_select
            // 
            this.txtscript_select.AcceptsTab = true;
            this.txtscript_select.Location = new System.Drawing.Point(357, 413);
            this.txtscript_select.Margin = new System.Windows.Forms.Padding(4);
            this.txtscript_select.Multiline = true;
            this.txtscript_select.Name = "txtscript_select";
            this.txtscript_select.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtscript_select.Size = new System.Drawing.Size(1101, 167);
            this.txtscript_select.TabIndex = 290;
            this.txtscript_select.Tag = "script_select";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(357, 384);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 291;
            this.label2.Text = "Script Select Padrão";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_IntegracaoTipoInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1465, 582);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtscript_select);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntegracaoTipoCd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsis_batch_cd);
            this.Controls.Add(this.dtgI);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_IntegracaoTipoInfo";
            this.Text = "Tipo Integração informações ";
            this.Shown += new System.EventHandler(this.frm_IntegracaoTipoInfo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsis_batch_cd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIntegracaoTipoCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPIintegracao_produto_seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dti_integracao_tipo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_sis_batch_service_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_sis_batch_service_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_module_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_sis_batch_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_sis_batch_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgi_script_select;
        private System.Windows.Forms.TextBox txtscript_select;
        private System.Windows.Forms.Label label2;
    }
}