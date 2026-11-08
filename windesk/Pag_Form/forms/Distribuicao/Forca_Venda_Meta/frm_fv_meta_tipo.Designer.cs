namespace Pag_Form.forms.Distribuicao.Forca_Venda_Meta
{
    partial class frm_fv_meta_tipo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgC = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.dtgCfv_meta_tipo_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCfv_meta_tipo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCfv_meta_regra_base_proporcional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgC)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgC
            // 
            this.dtgC.AllowUserToAddRows = false;
            this.dtgC.AllowUserToDeleteRows = false;
            this.dtgC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgCfv_meta_tipo_Cd,
            this.dtgCfv_meta_tipo_descricao,
            this.dtgCfv_meta_regra_base_proporcional});
            this.dtgC.Location = new System.Drawing.Point(12, 54);
            this.dtgC.Name = "dtgC";
            this.dtgC.ReadOnly = true;
            this.dtgC.RowHeadersVisible = false;
            this.dtgC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgC.Size = new System.Drawing.Size(720, 193);
            this.dtgC.TabIndex = 684;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(720, 32);
            this.label12.TabIndex = 685;
            this.label12.Text = "Distribuição | Força de Venda - Tipos de Metas";
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(629, 10);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 686;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // dtgCfv_meta_tipo_Cd
            // 
            this.dtgCfv_meta_tipo_Cd.DataPropertyName = "fv_meta_tipo_cd";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtgCfv_meta_tipo_Cd.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCfv_meta_tipo_Cd.HeaderText = "Cd Tipo Meta";
            this.dtgCfv_meta_tipo_Cd.Name = "dtgCfv_meta_tipo_Cd";
            this.dtgCfv_meta_tipo_Cd.ReadOnly = true;
            this.dtgCfv_meta_tipo_Cd.Width = 65;
            // 
            // dtgCfv_meta_tipo_descricao
            // 
            this.dtgCfv_meta_tipo_descricao.DataPropertyName = "fv_meta_tipo_descricao";
            this.dtgCfv_meta_tipo_descricao.FillWeight = 200F;
            this.dtgCfv_meta_tipo_descricao.HeaderText = "Descrição";
            this.dtgCfv_meta_tipo_descricao.Name = "dtgCfv_meta_tipo_descricao";
            this.dtgCfv_meta_tipo_descricao.ReadOnly = true;
            this.dtgCfv_meta_tipo_descricao.Width = 350;
            // 
            // dtgCfv_meta_regra_base_proporcional
            // 
            this.dtgCfv_meta_regra_base_proporcional.DataPropertyName = "LABEL_fv_meta_regra_base_proporcional";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dtgCfv_meta_regra_base_proporcional.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgCfv_meta_regra_base_proporcional.FillWeight = 65F;
            this.dtgCfv_meta_regra_base_proporcional.HeaderText = "Requisito Proporcional (regra_base_proporcional)";
            this.dtgCfv_meta_regra_base_proporcional.Name = "dtgCfv_meta_regra_base_proporcional";
            this.dtgCfv_meta_regra_base_proporcional.ReadOnly = true;
            this.dtgCfv_meta_regra_base_proporcional.Width = 150;
            // 
            // frm_fv_meta_tipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(739, 259);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtgC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_fv_meta_tipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M4831";
            ((System.ComponentModel.ISupportInitialize)(this.dtgC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCfv_meta_tipo_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCfv_meta_tipo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCfv_meta_regra_base_proporcional;
    }
}