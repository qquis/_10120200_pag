namespace Pag_Form.forms
{
    partial class frm_Loja_Atualizacao_Balanca
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
            this.dtgPreco_BALANCA = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.dtgPreco_BALANCA_prs_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_BALANCA_pr_cdproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_BALANCA_descricao_balanca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_BALANCA_pre_embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_BALANCA_preg_cdbarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_Balanca_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPreco_BALANCA_Linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreco_BALANCA)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPreco_BALANCA
            // 
            this.dtgPreco_BALANCA.AllowUserToAddRows = false;
            this.dtgPreco_BALANCA.AllowUserToDeleteRows = false;
            this.dtgPreco_BALANCA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPreco_BALANCA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgPreco_BALANCA_prs_descricao,
            this.dtgPreco_BALANCA_pr_cdproduto,
            this.dtgPreco_BALANCA_descricao_balanca,
            this.dtgPreco_BALANCA_pre_embalagem,
            this.dtgPreco_BALANCA_preg_cdbarra,
            this.dtgPreco_Balanca_Valor,
            this.dtgPreco_BALANCA_Linha});
            this.dtgPreco_BALANCA.Location = new System.Drawing.Point(12, 88);
            this.dtgPreco_BALANCA.Name = "dtgPreco_BALANCA";
            this.dtgPreco_BALANCA.ReadOnly = true;
            this.dtgPreco_BALANCA.RowHeadersVisible = false;
            this.dtgPreco_BALANCA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPreco_BALANCA.Size = new System.Drawing.Size(717, 409);
            this.dtgPreco_BALANCA.TabIndex = 250;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 21);
            this.label1.TabIndex = 249;
            this.label1.Text = "Total de Produtos a serem exportados para as BALANÇAS MGV";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(623, 12);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 252;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(717, 35);
            this.label12.TabIndex = 251;
            this.label12.Text = "Loja | Atualização de Dados: CONSULTA DE PRODUTOS MGV";
            // 
            // lbl_total
            // 
            this.lbl_total.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.White;
            this.lbl_total.Location = new System.Drawing.Point(623, 55);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(100, 21);
            this.lbl_total.TabIndex = 253;
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgPreco_BALANCA_prs_descricao
            // 
            this.dtgPreco_BALANCA_prs_descricao.DataPropertyName = "prs_descricao";
            this.dtgPreco_BALANCA_prs_descricao.HeaderText = "Seção ";
            this.dtgPreco_BALANCA_prs_descricao.Name = "dtgPreco_BALANCA_prs_descricao";
            this.dtgPreco_BALANCA_prs_descricao.ReadOnly = true;
            this.dtgPreco_BALANCA_prs_descricao.Width = 120;
            // 
            // dtgPreco_BALANCA_pr_cdproduto
            // 
            this.dtgPreco_BALANCA_pr_cdproduto.DataPropertyName = "pr_cdproduto";
            this.dtgPreco_BALANCA_pr_cdproduto.HeaderText = "Produto";
            this.dtgPreco_BALANCA_pr_cdproduto.Name = "dtgPreco_BALANCA_pr_cdproduto";
            this.dtgPreco_BALANCA_pr_cdproduto.ReadOnly = true;
            this.dtgPreco_BALANCA_pr_cdproduto.Width = 60;
            // 
            // dtgPreco_BALANCA_descricao_balanca
            // 
            this.dtgPreco_BALANCA_descricao_balanca.DataPropertyName = "prb_descricao_balanca";
            this.dtgPreco_BALANCA_descricao_balanca.HeaderText = "Descrição";
            this.dtgPreco_BALANCA_descricao_balanca.Name = "dtgPreco_BALANCA_descricao_balanca";
            this.dtgPreco_BALANCA_descricao_balanca.ReadOnly = true;
            this.dtgPreco_BALANCA_descricao_balanca.Width = 150;
            // 
            // dtgPreco_BALANCA_pre_embalagem
            // 
            this.dtgPreco_BALANCA_pre_embalagem.DataPropertyName = "pre_embalagem";
            this.dtgPreco_BALANCA_pre_embalagem.HeaderText = "";
            this.dtgPreco_BALANCA_pre_embalagem.Name = "dtgPreco_BALANCA_pre_embalagem";
            this.dtgPreco_BALANCA_pre_embalagem.ReadOnly = true;
            this.dtgPreco_BALANCA_pre_embalagem.Width = 50;
            // 
            // dtgPreco_BALANCA_preg_cdbarra
            // 
            this.dtgPreco_BALANCA_preg_cdbarra.DataPropertyName = "preg_cdbarra";
            this.dtgPreco_BALANCA_preg_cdbarra.HeaderText = "Código de Barra";
            this.dtgPreco_BALANCA_preg_cdbarra.Name = "dtgPreco_BALANCA_preg_cdbarra";
            this.dtgPreco_BALANCA_preg_cdbarra.ReadOnly = true;
            // 
            // dtgPreco_Balanca_Valor
            // 
            this.dtgPreco_Balanca_Valor.DataPropertyName = "prc_valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgPreco_Balanca_Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPreco_Balanca_Valor.HeaderText = "Valor";
            this.dtgPreco_Balanca_Valor.Name = "dtgPreco_Balanca_Valor";
            this.dtgPreco_Balanca_Valor.ReadOnly = true;
            this.dtgPreco_Balanca_Valor.Width = 60;
            // 
            // dtgPreco_BALANCA_Linha
            // 
            this.dtgPreco_BALANCA_Linha.DataPropertyName = "linha";
            this.dtgPreco_BALANCA_Linha.HeaderText = "Linha Mgv";
            this.dtgPreco_BALANCA_Linha.Name = "dtgPreco_BALANCA_Linha";
            this.dtgPreco_BALANCA_Linha.ReadOnly = true;
            this.dtgPreco_BALANCA_Linha.Width = 120;
            // 
            // frm_Loja_Atualizacao_Balanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(746, 506);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtgPreco_BALANCA);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Loja_Atualizacao_Balanca";
            this.Text = "frm_Loja_Atualizacao_Balanca";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreco_BALANCA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgPreco_BALANCA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_prs_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_pr_cdproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_descricao_balanca;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_pre_embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_preg_cdbarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_Balanca_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPreco_BALANCA_Linha;
    }
}