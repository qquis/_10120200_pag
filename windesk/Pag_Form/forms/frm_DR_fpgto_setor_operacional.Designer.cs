namespace Pag_Form.forms
{
    partial class frm_DR_fpgto_setor_operacional
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
            this.label12 = new System.Windows.Forms.Label();
            this.cmdatualiza = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_setor_operacional = new System.Windows.Forms.Label();
            this.lbl_setor_selecionado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtrcentro_dr_mapa = new System.Windows.Forms.DataGridView();
            this._CDR_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_SUBGRUPO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_SUBGRUPO_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CDR_TIPO_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgsetor_operacional = new System.Windows.Forms.DataGridView();
            this._setor_operacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._setor_operacional_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fpgto_salario_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fpgto_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_fpgto_funcionario_setor = new System.Windows.Forms.DataGridView();
            this._fpgto_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fpgto_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcontrol.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtrcentro_dr_mapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsetor_operacional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_fpgto_funcionario_setor)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(884, 35);
            this.label12.TabIndex = 237;
            this.label12.Text = "Setor Operacional x Folha de Pgto";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // cmdatualiza
            // 
            this.cmdatualiza.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdatualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdatualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdatualiza.ForeColor = System.Drawing.Color.Blue;
            this.cmdatualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdatualiza.Location = new System.Drawing.Point(689, 11);
            this.cmdatualiza.Name = "cmdatualiza";
            this.cmdatualiza.Size = new System.Drawing.Size(100, 30);
            this.cmdatualiza.TabIndex = 242;
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
            this.cmdsair.Location = new System.Drawing.Point(790, 11);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 241;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tabPage1);
            this.tbcontrol.Location = new System.Drawing.Point(12, 52);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(884, 507);
            this.tbcontrol.TabIndex = 243;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.lbl_setor_operacional);
            this.tabPage1.Controls.Add(this.lbl_setor_selecionado);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dtrcentro_dr_mapa);
            this.tabPage1.Controls.Add(this.dtgsetor_operacional);
            this.tabPage1.Controls.Add(this.dtg_fpgto_funcionario_setor);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(876, 481);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Listagem Geral Setor Operacional x Funcionários";
            // 
            // lbl_setor_operacional
            // 
            this.lbl_setor_operacional.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_setor_operacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_setor_operacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_setor_operacional.ForeColor = System.Drawing.Color.White;
            this.lbl_setor_operacional.Location = new System.Drawing.Point(486, 3);
            this.lbl_setor_operacional.Name = "lbl_setor_operacional";
            this.lbl_setor_operacional.Size = new System.Drawing.Size(132, 21);
            this.lbl_setor_operacional.TabIndex = 249;
            this.lbl_setor_operacional.Text = "label3";
            this.lbl_setor_operacional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_setor_selecionado
            // 
            this.lbl_setor_selecionado.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_setor_selecionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_setor_selecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_setor_selecionado.ForeColor = System.Drawing.Color.White;
            this.lbl_setor_selecionado.Location = new System.Drawing.Point(624, 3);
            this.lbl_setor_selecionado.Name = "lbl_setor_selecionado";
            this.lbl_setor_selecionado.Size = new System.Drawing.Size(249, 21);
            this.lbl_setor_selecionado.TabIndex = 248;
            this.lbl_setor_selecionado.Text = "lbl_setor_selecionado";
            this.lbl_setor_selecionado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(862, 21);
            this.label2.TabIndex = 247;
            this.label2.Text = "Centro de Receitas Alocados";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(486, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 21);
            this.label1.TabIndex = 246;
            this.label1.Text = "Lista de Colaboradores";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtrcentro_dr_mapa
            // 
            this.dtrcentro_dr_mapa.AllowUserToAddRows = false;
            this.dtrcentro_dr_mapa.AllowUserToDeleteRows = false;
            this.dtrcentro_dr_mapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtrcentro_dr_mapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._CDR_DESCRICAO,
            this._CDR_SUBGRUPO_CD,
            this._CDR_SUBGRUPO_DESCRICAO,
            this._CDR_TIPO_DESCRICAO});
            this.dtrcentro_dr_mapa.Location = new System.Drawing.Point(11, 275);
            this.dtrcentro_dr_mapa.Name = "dtrcentro_dr_mapa";
            this.dtrcentro_dr_mapa.ReadOnly = true;
            this.dtrcentro_dr_mapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtrcentro_dr_mapa.Size = new System.Drawing.Size(862, 203);
            this.dtrcentro_dr_mapa.TabIndex = 191;
            // 
            // _CDR_DESCRICAO
            // 
            this._CDR_DESCRICAO.DataPropertyName = "CDR_DESCRICAO";
            this._CDR_DESCRICAO.HeaderText = "Operação";
            this._CDR_DESCRICAO.Name = "_CDR_DESCRICAO";
            this._CDR_DESCRICAO.ReadOnly = true;
            this._CDR_DESCRICAO.Width = 150;
            // 
            // _CDR_SUBGRUPO_CD
            // 
            this._CDR_SUBGRUPO_CD.DataPropertyName = "CDR_SUBGRUPO_CD";
            this._CDR_SUBGRUPO_CD.HeaderText = "Cod. ";
            this._CDR_SUBGRUPO_CD.Name = "_CDR_SUBGRUPO_CD";
            this._CDR_SUBGRUPO_CD.ReadOnly = true;
            this._CDR_SUBGRUPO_CD.Width = 45;
            // 
            // _CDR_SUBGRUPO_DESCRICAO
            // 
            this._CDR_SUBGRUPO_DESCRICAO.DataPropertyName = "CDR_SUBGRUPO_DESCRICAO";
            this._CDR_SUBGRUPO_DESCRICAO.HeaderText = "C. Receita";
            this._CDR_SUBGRUPO_DESCRICAO.Name = "_CDR_SUBGRUPO_DESCRICAO";
            this._CDR_SUBGRUPO_DESCRICAO.ReadOnly = true;
            this._CDR_SUBGRUPO_DESCRICAO.Width = 250;
            // 
            // _CDR_TIPO_DESCRICAO
            // 
            this._CDR_TIPO_DESCRICAO.DataPropertyName = "CDR_TIPO_DESCRICAO";
            this._CDR_TIPO_DESCRICAO.HeaderText = "Tipo";
            this._CDR_TIPO_DESCRICAO.Name = "_CDR_TIPO_DESCRICAO";
            this._CDR_TIPO_DESCRICAO.ReadOnly = true;
            this._CDR_TIPO_DESCRICAO.Width = 150;
            // 
            // dtgsetor_operacional
            // 
            this.dtgsetor_operacional.AllowUserToAddRows = false;
            this.dtgsetor_operacional.AllowUserToDeleteRows = false;
            this.dtgsetor_operacional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgsetor_operacional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._setor_operacional,
            this._setor_operacional_descricao,
            this._fpgto_salario_valor,
            this._fpgto_count});
            this.dtgsetor_operacional.Location = new System.Drawing.Point(11, 3);
            this.dtgsetor_operacional.Name = "dtgsetor_operacional";
            this.dtgsetor_operacional.ReadOnly = true;
            this.dtgsetor_operacional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgsetor_operacional.Size = new System.Drawing.Size(469, 245);
            this.dtgsetor_operacional.TabIndex = 190;
            // 
            // _setor_operacional
            // 
            this._setor_operacional.DataPropertyName = "setor_operacional";
            this._setor_operacional.HeaderText = "Setor";
            this._setor_operacional.Name = "_setor_operacional";
            this._setor_operacional.ReadOnly = true;
            this._setor_operacional.Width = 50;
            // 
            // _setor_operacional_descricao
            // 
            this._setor_operacional_descricao.DataPropertyName = "setor_operacional_descricao";
            this._setor_operacional_descricao.HeaderText = "Descrição";
            this._setor_operacional_descricao.Name = "_setor_operacional_descricao";
            this._setor_operacional_descricao.ReadOnly = true;
            this._setor_operacional_descricao.Width = 180;
            // 
            // _fpgto_salario_valor
            // 
            this._fpgto_salario_valor.DataPropertyName = "fpgto_salario_valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this._fpgto_salario_valor.DefaultCellStyle = dataGridViewCellStyle1;
            this._fpgto_salario_valor.HeaderText = "Salário Base";
            this._fpgto_salario_valor.Name = "_fpgto_salario_valor";
            this._fpgto_salario_valor.ReadOnly = true;
            // 
            // _fpgto_count
            // 
            this._fpgto_count.DataPropertyName = "fpgto_count";
            this._fpgto_count.HeaderText = "N. Regs";
            this._fpgto_count.Name = "_fpgto_count";
            this._fpgto_count.ReadOnly = true;
            this._fpgto_count.Width = 60;
            // 
            // dtg_fpgto_funcionario_setor
            // 
            this.dtg_fpgto_funcionario_setor.AllowUserToAddRows = false;
            this.dtg_fpgto_funcionario_setor.AllowUserToDeleteRows = false;
            this.dtg_fpgto_funcionario_setor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_fpgto_funcionario_setor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._fpgto_registro,
            this._fpgto_nome});
            this.dtg_fpgto_funcionario_setor.Location = new System.Drawing.Point(486, 52);
            this.dtg_fpgto_funcionario_setor.Name = "dtg_fpgto_funcionario_setor";
            this.dtg_fpgto_funcionario_setor.ReadOnly = true;
            this.dtg_fpgto_funcionario_setor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_fpgto_funcionario_setor.Size = new System.Drawing.Size(387, 196);
            this.dtg_fpgto_funcionario_setor.TabIndex = 189;
            // 
            // _fpgto_registro
            // 
            this._fpgto_registro.DataPropertyName = "fpgto_registro";
            this._fpgto_registro.HeaderText = "Registro";
            this._fpgto_registro.Name = "_fpgto_registro";
            this._fpgto_registro.ReadOnly = true;
            this._fpgto_registro.Width = 70;
            // 
            // _fpgto_nome
            // 
            this._fpgto_nome.DataPropertyName = "fpgto_nome";
            this._fpgto_nome.HeaderText = "Nome";
            this._fpgto_nome.Name = "_fpgto_nome";
            this._fpgto_nome.ReadOnly = true;
            this._fpgto_nome.Width = 250;
            // 
            // frm_DR_fpgto_setor_operacional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(915, 593);
            this.Controls.Add(this.tbcontrol);
            this.Controls.Add(this.cmdatualiza);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DR_fpgto_setor_operacional";
            this.Text = "PAG | M5210";
            this.tbcontrol.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtrcentro_dr_mapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsetor_operacional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_fpgto_funcionario_setor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdatualiza;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtg_fpgto_funcionario_setor;
        private System.Windows.Forms.DataGridView dtgsetor_operacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fpgto_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fpgto_nome;
        private System.Windows.Forms.DataGridView dtrcentro_dr_mapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_setor_selecionado;
        private System.Windows.Forms.Label lbl_setor_operacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn _setor_operacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn _setor_operacional_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fpgto_salario_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fpgto_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_SUBGRUPO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_SUBGRUPO_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CDR_TIPO_DESCRICAO;
    }
}