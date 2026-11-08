namespace Pag_Form.forms.Loja
{
    partial class frm_Loja_Agendamento_Lote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblwait = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.dtgdataprocessamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgprd_cddepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgprd_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgprs_cdsecao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgprs_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgprg_cdgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prg_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgqtde_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgqtde_produto_registrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgqtde_produto_processados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgqtde_produto_embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblwait
            // 
            this.lblwait.BackColor = System.Drawing.Color.Red;
            this.lblwait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait.ForeColor = System.Drawing.Color.White;
            this.lblwait.Location = new System.Drawing.Point(299, 16);
            this.lblwait.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(403, 25);
            this.lblwait.TabIndex = 371;
            this.lblwait.Text = "Processando dados...";
            this.lblwait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(925, 11);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 370;
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
            this.label12.Location = new System.Drawing.Point(1, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1060, 43);
            this.label12.TabIndex = 369;
            this.label12.Text = "Loja | Preços em Lote";
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgdataprocessamento,
            this.dtgprd_cddepartamento,
            this.dtgprd_descricao,
            this.dtgprs_cdsecao,
            this.dtgprs_descricao,
            this.dtgprg_cdgrupo,
            this.prg_descricao,
            this.dtgqtde_produto,
            this.dtgqtde_produto_registrado,
            this.dtgqtde_produto_processados,
            this.dtgqtde_produto_embalagem});
            this.dtg.Location = new System.Drawing.Point(1, 56);
            this.dtg.Margin = new System.Windows.Forms.Padding(4);
            this.dtg.Name = "dtg";
            this.dtg.ReadOnly = true;
            this.dtg.RowHeadersVisible = false;
            this.dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg.Size = new System.Drawing.Size(1060, 403);
            this.dtg.TabIndex = 687;
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.BackColor = System.Drawing.Color.White;
            this.cmdPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.cmdPesquisar.ForeColor = System.Drawing.Color.Blue;
            this.cmdPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPesquisar.Location = new System.Drawing.Point(790, 11);
            this.cmdPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(133, 37);
            this.cmdPesquisar.TabIndex = 688;
            this.cmdPesquisar.Text = "Pesquisar";
            this.cmdPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPesquisar.UseVisualStyleBackColor = false;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // dtgdataprocessamento
            // 
            this.dtgdataprocessamento.DataPropertyName = "data_processamento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgdataprocessamento.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgdataprocessamento.HeaderText = "Processamento";
            this.dtgdataprocessamento.Name = "dtgdataprocessamento";
            this.dtgdataprocessamento.ReadOnly = true;
            this.dtgdataprocessamento.Width = 70;
            // 
            // dtgprd_cddepartamento
            // 
            this.dtgprd_cddepartamento.DataPropertyName = "prd_cddepartamento";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dtgprd_cddepartamento.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgprd_cddepartamento.HeaderText = "Dpto";
            this.dtgprd_cddepartamento.Name = "dtgprd_cddepartamento";
            this.dtgprd_cddepartamento.ReadOnly = true;
            this.dtgprd_cddepartamento.Visible = false;
            this.dtgprd_cddepartamento.Width = 55;
            // 
            // dtgprd_descricao
            // 
            this.dtgprd_descricao.DataPropertyName = "prd_descricao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dtgprd_descricao.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgprd_descricao.HeaderText = "Departamento";
            this.dtgprd_descricao.Name = "dtgprd_descricao";
            this.dtgprd_descricao.ReadOnly = true;
            this.dtgprd_descricao.Width = 75;
            // 
            // dtgprs_cdsecao
            // 
            this.dtgprs_cdsecao.DataPropertyName = "prs_cdsecao";
            this.dtgprs_cdsecao.HeaderText = "Sec";
            this.dtgprs_cdsecao.Name = "dtgprs_cdsecao";
            this.dtgprs_cdsecao.ReadOnly = true;
            this.dtgprs_cdsecao.Visible = false;
            this.dtgprs_cdsecao.Width = 50;
            // 
            // dtgprs_descricao
            // 
            this.dtgprs_descricao.DataPropertyName = "prs_descricao";
            this.dtgprs_descricao.HeaderText = "Seção";
            this.dtgprs_descricao.Name = "dtgprs_descricao";
            this.dtgprs_descricao.ReadOnly = true;
            // 
            // dtgprg_cdgrupo
            // 
            this.dtgprg_cdgrupo.DataPropertyName = "prg_cdgrupo";
            this.dtgprg_cdgrupo.HeaderText = "Cd Grupo";
            this.dtgprg_cdgrupo.Name = "dtgprg_cdgrupo";
            this.dtgprg_cdgrupo.ReadOnly = true;
            this.dtgprg_cdgrupo.Width = 50;
            // 
            // prg_descricao
            // 
            this.prg_descricao.DataPropertyName = "prg_descricao";
            this.prg_descricao.HeaderText = "Grupo";
            this.prg_descricao.Name = "prg_descricao";
            this.prg_descricao.ReadOnly = true;
            this.prg_descricao.Width = 150;
            // 
            // dtgqtde_produto
            // 
            this.dtgqtde_produto.DataPropertyName = "qtde_produto";
            this.dtgqtde_produto.HeaderText = "Qtde Prds Previstos";
            this.dtgqtde_produto.Name = "dtgqtde_produto";
            this.dtgqtde_produto.ReadOnly = true;
            this.dtgqtde_produto.Width = 90;
            // 
            // dtgqtde_produto_registrado
            // 
            this.dtgqtde_produto_registrado.DataPropertyName = "qtde_produto_registrados";
            this.dtgqtde_produto_registrado.HeaderText = "Produtos Registrados";
            this.dtgqtde_produto_registrado.Name = "dtgqtde_produto_registrado";
            this.dtgqtde_produto_registrado.ReadOnly = true;
            this.dtgqtde_produto_registrado.Width = 90;
            // 
            // dtgqtde_produto_processados
            // 
            this.dtgqtde_produto_processados.DataPropertyName = "qtde_produto_processados";
            this.dtgqtde_produto_processados.HeaderText = "Qtde Prds Processados";
            this.dtgqtde_produto_processados.Name = "dtgqtde_produto_processados";
            this.dtgqtde_produto_processados.ReadOnly = true;
            this.dtgqtde_produto_processados.Width = 90;
            // 
            // dtgqtde_produto_embalagem
            // 
            this.dtgqtde_produto_embalagem.DataPropertyName = "qtde_produto_embalagem";
            this.dtgqtde_produto_embalagem.HeaderText = "Qtde Embalagens";
            this.dtgqtde_produto_embalagem.Name = "dtgqtde_produto_embalagem";
            this.dtgqtde_produto_embalagem.ReadOnly = true;
            this.dtgqtde_produto_embalagem.Width = 90;
            // 
            // frm_Loja_Agendamento_Lote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1077, 483);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(this.dtg);
            this.Controls.Add(this.lblwait);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Loja_Agendamento_Lote";
            this.Text = "Consulta de Alterações de Preços em Lotes";
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgdataprocessamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgprd_cddepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgprd_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgprs_cdsecao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgprs_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgprg_cdgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prg_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgqtde_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgqtde_produto_registrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgqtde_produto_processados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgqtde_produto_embalagem;
    }
}