namespace Pag_Form.forms.Sistema.sistema_batch
{
    partial class frmSistema_Batch
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
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgsistema_batch = new System.Windows.Forms.DataGridView();
            this.dtgsistema_batch_sis_batch_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgsistema_batch_sis_batch_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgsistema_batch_sis_batch_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgsistema_batch_sis_batch_service_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_sis_batch_descricao = new System.Windows.Forms.Label();
            this.lbl_sis_batch_cd = new System.Windows.Forms.Label();
            this.txtfilter_sis_batch_cd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsistema_batch)).BeginInit();
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
            this.cmdsair.Location = new System.Drawing.Point(1089, 12);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(108, 37);
            this.cmdsair.TabIndex = 752;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.White;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(981, 12);
            this.cmdConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(108, 37);
            this.cmdConsultar.TabIndex = 751;
            this.cmdConsultar.Text = "Buscar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1185, 39);
            this.label12.TabIndex = 750;
            this.label12.Text = "Sistema Batchs Manager | Serviços / Batchs";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1183, 24);
            this.label5.TabIndex = 762;
            this.label5.Text = "Batchs (Bh)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgsistema_batch
            // 
            this.dtgsistema_batch.AllowUserToAddRows = false;
            this.dtgsistema_batch.AllowUserToDeleteRows = false;
            this.dtgsistema_batch.AllowUserToResizeRows = false;
            this.dtgsistema_batch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgsistema_batch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgsistema_batch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgsistema_batch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgsistema_batch_sis_batch_cd,
            this.dtgsistema_batch_sis_batch_descricao,
            this.dtgsistema_batch_sis_batch_status,
            this.dtgsistema_batch_sis_batch_service_cd});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgsistema_batch.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgsistema_batch.Location = new System.Drawing.Point(16, 127);
            this.dtgsistema_batch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgsistema_batch.Name = "dtgsistema_batch";
            this.dtgsistema_batch.ReadOnly = true;
            this.dtgsistema_batch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgsistema_batch.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgsistema_batch.RowHeadersVisible = false;
            this.dtgsistema_batch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgsistema_batch.Size = new System.Drawing.Size(1185, 320);
            this.dtgsistema_batch.TabIndex = 761;
            // 
            // dtgsistema_batch_sis_batch_cd
            // 
            this.dtgsistema_batch_sis_batch_cd.DataPropertyName = "sis_batch_cd";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgsistema_batch_sis_batch_cd.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgsistema_batch_sis_batch_cd.HeaderText = "Batch Cd";
            this.dtgsistema_batch_sis_batch_cd.Name = "dtgsistema_batch_sis_batch_cd";
            this.dtgsistema_batch_sis_batch_cd.ReadOnly = true;
            this.dtgsistema_batch_sis_batch_cd.Width = 45;
            // 
            // dtgsistema_batch_sis_batch_descricao
            // 
            this.dtgsistema_batch_sis_batch_descricao.DataPropertyName = "sis_batch_descricao";
            this.dtgsistema_batch_sis_batch_descricao.HeaderText = "Descrição";
            this.dtgsistema_batch_sis_batch_descricao.Name = "dtgsistema_batch_sis_batch_descricao";
            this.dtgsistema_batch_sis_batch_descricao.ReadOnly = true;
            this.dtgsistema_batch_sis_batch_descricao.Width = 450;
            // 
            // dtgsistema_batch_sis_batch_status
            // 
            this.dtgsistema_batch_sis_batch_status.DataPropertyName = "sis_batch_status";
            this.dtgsistema_batch_sis_batch_status.HeaderText = "Status";
            this.dtgsistema_batch_sis_batch_status.Name = "dtgsistema_batch_sis_batch_status";
            this.dtgsistema_batch_sis_batch_status.ReadOnly = true;
            this.dtgsistema_batch_sis_batch_status.Width = 60;
            // 
            // dtgsistema_batch_sis_batch_service_cd
            // 
            this.dtgsistema_batch_sis_batch_service_cd.DataPropertyName = "sis_batch_service_cd";
            this.dtgsistema_batch_sis_batch_service_cd.HeaderText = "Código Serviço";
            this.dtgsistema_batch_sis_batch_service_cd.Name = "dtgsistema_batch_sis_batch_service_cd";
            this.dtgsistema_batch_sis_batch_service_cd.ReadOnly = true;
            this.dtgsistema_batch_sis_batch_service_cd.Width = 60;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 450);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 24);
            this.label7.TabIndex = 800;
            this.label7.Text = "Batch cd";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_sis_batch_descricao
            // 
            this.lbl_sis_batch_descricao.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_sis_batch_descricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_sis_batch_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sis_batch_descricao.ForeColor = System.Drawing.Color.White;
            this.lbl_sis_batch_descricao.Location = new System.Drawing.Point(111, 486);
            this.lbl_sis_batch_descricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sis_batch_descricao.Name = "lbl_sis_batch_descricao";
            this.lbl_sis_batch_descricao.Size = new System.Drawing.Size(482, 24);
            this.lbl_sis_batch_descricao.TabIndex = 799;
            this.lbl_sis_batch_descricao.Text = "Batchs";
            this.lbl_sis_batch_descricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_sis_batch_cd
            // 
            this.lbl_sis_batch_cd.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_sis_batch_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_sis_batch_cd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sis_batch_cd.ForeColor = System.Drawing.Color.White;
            this.lbl_sis_batch_cd.Location = new System.Drawing.Point(16, 486);
            this.lbl_sis_batch_cd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sis_batch_cd.Name = "lbl_sis_batch_cd";
            this.lbl_sis_batch_cd.Size = new System.Drawing.Size(86, 24);
            this.lbl_sis_batch_cd.TabIndex = 798;
            this.lbl_sis_batch_cd.Text = "Batchs";
            this.lbl_sis_batch_cd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtfilter_sis_batch_cd
            // 
            this.txtfilter_sis_batch_cd.AcceptsTab = true;
            this.txtfilter_sis_batch_cd.Location = new System.Drawing.Point(247, 62);
            this.txtfilter_sis_batch_cd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtfilter_sis_batch_cd.MaxLength = 60;
            this.txtfilter_sis_batch_cd.Name = "txtfilter_sis_batch_cd";
            this.txtfilter_sis_batch_cd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfilter_sis_batch_cd.Size = new System.Drawing.Size(103, 22);
            this.txtfilter_sis_batch_cd.TabIndex = 812;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.SlateGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(17, 62);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(221, 24);
            this.label14.TabIndex = 811;
            this.label14.Text = "Filtrar Código";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 450);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 24);
            this.label1.TabIndex = 815;
            this.label1.Text = "Descrição";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSistema_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1207, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfilter_sis_batch_cd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_sis_batch_descricao);
            this.Controls.Add(this.lbl_sis_batch_cd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgsistema_batch);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSistema_Batch";
            this.Text = "frmSistema_Batch";
            ((System.ComponentModel.ISupportInitialize)(this.dtgsistema_batch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgsistema_batch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_sis_batch_descricao;
        private System.Windows.Forms.Label lbl_sis_batch_cd;
        private System.Windows.Forms.TextBox txtfilter_sis_batch_cd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgsistema_batch_sis_batch_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgsistema_batch_sis_batch_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgsistema_batch_sis_batch_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgsistema_batch_sis_batch_service_cd;
    }
}