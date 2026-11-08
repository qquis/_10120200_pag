namespace Pag_Form.forms
{
    partial class frm_DR_Mapa
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
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dtgCentroDr_Resumo_Item = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plc_conta_cd_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblinfo_centrodr_resumo_descricao = new System.Windows.Forms.Label();
            this.lblinfo_centrodr_resumo_cd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCdr_tipo_descricao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgCentroDR_RESUMO = new System.Windows.Forms.DataGridView();
            this.@__cdr_tipo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__centrodr_resumo_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__centrodr_resumo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgMapa = new System.Windows.Forms.DataGridView();
            this._CDR_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_SUBGRUPO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_SUBGRUPO_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_TIPO_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._setor_operacional_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._plc_conta_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdatualiza = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbcontrol.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCentroDr_Resumo_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCentroDR_RESUMO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tabPage1);
            this.tbcontrol.Location = new System.Drawing.Point(10, 56);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(884, 595);
            this.tbcontrol.TabIndex = 247;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtgCentroDr_Resumo_Item);
            this.tabPage1.Controls.Add(this.lblinfo_centrodr_resumo_descricao);
            this.tabPage1.Controls.Add(this.lblinfo_centrodr_resumo_cd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.CmbCdr_tipo_descricao);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtgCentroDR_RESUMO);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dtgMapa);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(876, 569);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Mapeamentos";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(449, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(404, 21);
            this.label4.TabIndex = 255;
            this.label4.Text = "Item do Centralizador";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgCentroDr_Resumo_Item
            // 
            this.dtgCentroDr_Resumo_Item.AllowUserToAddRows = false;
            this.dtgCentroDr_Resumo_Item.AllowUserToDeleteRows = false;
            this.dtgCentroDr_Resumo_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCentroDr_Resumo_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.plc_conta_cd_,
            this.dataGridViewTextBoxColumn6});
            this.dtgCentroDr_Resumo_Item.Location = new System.Drawing.Point(449, 333);
            this.dtgCentroDr_Resumo_Item.Name = "dtgCentroDr_Resumo_Item";
            this.dtgCentroDr_Resumo_Item.ReadOnly = true;
            this.dtgCentroDr_Resumo_Item.RowHeadersVisible = false;
            this.dtgCentroDr_Resumo_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCentroDr_Resumo_Item.Size = new System.Drawing.Size(404, 222);
            this.dtgCentroDr_Resumo_Item.TabIndex = 254;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "setor_operacional";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod. Setor";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "setor_operacional_descricao";
            this.dataGridViewTextBoxColumn5.HeaderText = "Setor";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // plc_conta_cd_
            // 
            this.plc_conta_cd_.DataPropertyName = "plc_conta_cd";
            this.plc_conta_cd_.HeaderText = "Cod Plano de Contas";
            this.plc_conta_cd_.Name = "plc_conta_cd_";
            this.plc_conta_cd_.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "plc_descricao";
            this.dataGridViewTextBoxColumn6.HeaderText = "Plano de Contas";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // lblinfo_centrodr_resumo_descricao
            // 
            this.lblinfo_centrodr_resumo_descricao.BackColor = System.Drawing.Color.SlateGray;
            this.lblinfo_centrodr_resumo_descricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblinfo_centrodr_resumo_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo_centrodr_resumo_descricao.ForeColor = System.Drawing.Color.White;
            this.lblinfo_centrodr_resumo_descricao.Location = new System.Drawing.Point(449, 278);
            this.lblinfo_centrodr_resumo_descricao.Name = "lblinfo_centrodr_resumo_descricao";
            this.lblinfo_centrodr_resumo_descricao.Size = new System.Drawing.Size(413, 21);
            this.lblinfo_centrodr_resumo_descricao.TabIndex = 253;
            this.lblinfo_centrodr_resumo_descricao.Text = "Mapeamentos";
            this.lblinfo_centrodr_resumo_descricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblinfo_centrodr_resumo_cd
            // 
            this.lblinfo_centrodr_resumo_cd.BackColor = System.Drawing.Color.SlateGray;
            this.lblinfo_centrodr_resumo_cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblinfo_centrodr_resumo_cd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo_centrodr_resumo_cd.ForeColor = System.Drawing.Color.White;
            this.lblinfo_centrodr_resumo_cd.Location = new System.Drawing.Point(13, 278);
            this.lblinfo_centrodr_resumo_cd.Name = "lblinfo_centrodr_resumo_cd";
            this.lblinfo_centrodr_resumo_cd.Size = new System.Drawing.Size(404, 21);
            this.lblinfo_centrodr_resumo_cd.TabIndex = 252;
            this.lblinfo_centrodr_resumo_cd.Text = "Mapeamentos";
            this.lblinfo_centrodr_resumo_cd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 21);
            this.label3.TabIndex = 251;
            this.label3.Text = "Tipo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbCdr_tipo_descricao
            // 
            this.CmbCdr_tipo_descricao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCdr_tipo_descricao.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCdr_tipo_descricao.FormattingEnabled = true;
            this.CmbCdr_tipo_descricao.Location = new System.Drawing.Point(13, 37);
            this.CmbCdr_tipo_descricao.Name = "CmbCdr_tipo_descricao";
            this.CmbCdr_tipo_descricao.Size = new System.Drawing.Size(652, 23);
            this.CmbCdr_tipo_descricao.TabIndex = 250;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 21);
            this.label2.TabIndex = 249;
            this.label2.Text = "Mapeamentos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgCentroDR_RESUMO
            // 
            this.dtgCentroDR_RESUMO.AllowUserToAddRows = false;
            this.dtgCentroDR_RESUMO.AllowUserToDeleteRows = false;
            this.dtgCentroDR_RESUMO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCentroDR_RESUMO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__cdr_tipo_descricao,
            this.@__centrodr_resumo_cd,
            this.@__centrodr_resumo_descricao});
            this.dtgCentroDR_RESUMO.Location = new System.Drawing.Point(13, 87);
            this.dtgCentroDR_RESUMO.Name = "dtgCentroDR_RESUMO";
            this.dtgCentroDR_RESUMO.ReadOnly = true;
            this.dtgCentroDR_RESUMO.RowHeadersVisible = false;
            this.dtgCentroDR_RESUMO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCentroDR_RESUMO.Size = new System.Drawing.Size(849, 188);
            this.dtgCentroDR_RESUMO.TabIndex = 248;
            // 
            // __cdr_tipo_descricao
            // 
            this.@__cdr_tipo_descricao.DataPropertyName = "cdr_tipo_descricao";
            this.@__cdr_tipo_descricao.HeaderText = "Tipo";
            this.@__cdr_tipo_descricao.Name = "__cdr_tipo_descricao";
            this.@__cdr_tipo_descricao.ReadOnly = true;
            this.@__cdr_tipo_descricao.Width = 360;
            // 
            // __centrodr_resumo_cd
            // 
            this.@__centrodr_resumo_cd.DataPropertyName = "centrodr_resumo_cd";
            this.@__centrodr_resumo_cd.HeaderText = "Código";
            this.@__centrodr_resumo_cd.Name = "__centrodr_resumo_cd";
            this.@__centrodr_resumo_cd.ReadOnly = true;
            this.@__centrodr_resumo_cd.Width = 70;
            // 
            // __centrodr_resumo_descricao
            // 
            this.@__centrodr_resumo_descricao.DataPropertyName = "centrodr_resumo_descricao";
            this.@__centrodr_resumo_descricao.HeaderText = "Descrição";
            this.@__centrodr_resumo_descricao.Name = "__centrodr_resumo_descricao";
            this.@__centrodr_resumo_descricao.ReadOnly = true;
            this.@__centrodr_resumo_descricao.Width = 340;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(849, 21);
            this.label1.TabIndex = 247;
            this.label1.Text = "Centralizadores";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgMapa
            // 
            this.dtgMapa.AllowUserToAddRows = false;
            this.dtgMapa.AllowUserToDeleteRows = false;
            this.dtgMapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._CDR_DESCRICAO,
            this._CDR_SUBGRUPO_CD,
            this._CDR_SUBGRUPO_DESCRICAO,
            this._CDR_TIPO_DESCRICAO,
            this._setor_operacional_descricao,
            this._plc_conta_descricao});
            this.dtgMapa.Location = new System.Drawing.Point(13, 333);
            this.dtgMapa.Name = "dtgMapa";
            this.dtgMapa.ReadOnly = true;
            this.dtgMapa.RowHeadersVisible = false;
            this.dtgMapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMapa.Size = new System.Drawing.Size(404, 222);
            this.dtgMapa.TabIndex = 191;
            // 
            // _CDR_DESCRICAO
            // 
            this._CDR_DESCRICAO.DataPropertyName = "CDR_DESCRICAO";
            this._CDR_DESCRICAO.HeaderText = "Operação";
            this._CDR_DESCRICAO.Name = "_CDR_DESCRICAO";
            this._CDR_DESCRICAO.ReadOnly = true;
            // 
            // _CDR_SUBGRUPO_CD
            // 
            this._CDR_SUBGRUPO_CD.DataPropertyName = "CDR_SUBGRUPO_CD";
            this._CDR_SUBGRUPO_CD.HeaderText = "Cod. ";
            this._CDR_SUBGRUPO_CD.Name = "_CDR_SUBGRUPO_CD";
            this._CDR_SUBGRUPO_CD.ReadOnly = true;
            this._CDR_SUBGRUPO_CD.Width = 40;
            // 
            // _CDR_SUBGRUPO_DESCRICAO
            // 
            this._CDR_SUBGRUPO_DESCRICAO.DataPropertyName = "CDR_SUBGRUPO_DESCRICAO";
            this._CDR_SUBGRUPO_DESCRICAO.HeaderText = "C. Receita";
            this._CDR_SUBGRUPO_DESCRICAO.Name = "_CDR_SUBGRUPO_DESCRICAO";
            this._CDR_SUBGRUPO_DESCRICAO.ReadOnly = true;
            // 
            // _CDR_TIPO_DESCRICAO
            // 
            this._CDR_TIPO_DESCRICAO.DataPropertyName = "CDR_TIPO_DESCRICAO";
            this._CDR_TIPO_DESCRICAO.HeaderText = "Tipo";
            this._CDR_TIPO_DESCRICAO.Name = "_CDR_TIPO_DESCRICAO";
            this._CDR_TIPO_DESCRICAO.ReadOnly = true;
            // 
            // _setor_operacional_descricao
            // 
            this._setor_operacional_descricao.DataPropertyName = "setor_operacional_descricao";
            this._setor_operacional_descricao.HeaderText = "Setor";
            this._setor_operacional_descricao.Name = "_setor_operacional_descricao";
            this._setor_operacional_descricao.ReadOnly = true;
            // 
            // _plc_conta_descricao
            // 
            this._plc_conta_descricao.DataPropertyName = "plc_conta_descricao";
            this._plc_conta_descricao.HeaderText = "Plano de Contas";
            this._plc_conta_descricao.Name = "_plc_conta_descricao";
            this._plc_conta_descricao.ReadOnly = true;
            // 
            // cmdatualiza
            // 
            this.cmdatualiza.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdatualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdatualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdatualiza.ForeColor = System.Drawing.Color.Blue;
            this.cmdatualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdatualiza.Location = new System.Drawing.Point(687, 15);
            this.cmdatualiza.Name = "cmdatualiza";
            this.cmdatualiza.Size = new System.Drawing.Size(100, 30);
            this.cmdatualiza.TabIndex = 246;
            this.cmdatualiza.Text = "Pesquisar";
            this.cmdatualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdatualiza.UseVisualStyleBackColor = false;
            this.cmdatualiza.Click += new System.EventHandler(this.cmdatualiza_Click);
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(788, 15);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 245;
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
            this.label12.Location = new System.Drawing.Point(10, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(884, 35);
            this.label12.TabIndex = 244;
            this.label12.Text = "Mapeamento de Contas";
            // 
            // frm_DR_Mapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(909, 663);
            this.Controls.Add(this.tbcontrol);
            this.Controls.Add(this.cmdatualiza);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DR_Mapa";
            this.Text = "PAG | M5300";
            this.tbcontrol.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCentroDr_Resumo_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCentroDR_RESUMO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtgMapa;
        private System.Windows.Forms.Button cmdatualiza;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgCentroDR_RESUMO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn __cdr_tipo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn __centrodr_resumo_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn __centrodr_resumo_descricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbCdr_tipo_descricao;
        private System.Windows.Forms.Label lblinfo_centrodr_resumo_cd;
        private System.Windows.Forms.Label lblinfo_centrodr_resumo_descricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgCentroDr_Resumo_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_SUBGRUPO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_SUBGRUPO_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_TIPO_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _setor_operacional_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn _plc_conta_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn plc_conta_cd_;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}