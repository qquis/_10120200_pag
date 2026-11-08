namespace Pag_Wpf.Forms
{
    partial class FrmXProdutoDetalhe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCdProduto = new System.Windows.Forms.TextBox();
            this.cmdSair = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgEmbalagens = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgTbProdutoEmbalagem_FatorEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgEmbalagemCdBarra = new System.Windows.Forms.DataGridView();
            this.CdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlueCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmbBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagemCdBarra)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(97, 25);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(421, 20);
            this.txtDescricao.TabIndex = 184;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 185;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 183;
            this.label1.Text = "Código";
            // 
            // txtCdProduto
            // 
            this.txtCdProduto.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCdProduto.Enabled = false;
            this.txtCdProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCdProduto.Location = new System.Drawing.Point(11, 25);
            this.txtCdProduto.Name = "txtCdProduto";
            this.txtCdProduto.Size = new System.Drawing.Size(80, 20);
            this.txtCdProduto.TabIndex = 182;
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(418, 409);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 186;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 356);
            this.tabControl1.TabIndex = 187;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgEmbalagens);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dtgEmbalagemCdBarra);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Embalagens / Códigos de Barra";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgEmbalagens
            // 
            this.dtgEmbalagens.AllowUserToAddRows = false;
            this.dtgEmbalagens.AllowUserToDeleteRows = false;
            this.dtgEmbalagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmbalagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DtgTbProdutoEmbalagem_FatorEstoque,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1});
            this.dtgEmbalagens.Location = new System.Drawing.Point(6, 6);
            this.dtgEmbalagens.Name = "dtgEmbalagens";
            this.dtgEmbalagens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmbalagens.Size = new System.Drawing.Size(484, 136);
            this.dtgEmbalagens.TabIndex = 185;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TbProdutoEmbalagem_CdProduto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cód Pag";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 55;
            // 
            // DtgTbProdutoEmbalagem_FatorEstoque
            // 
            this.DtgTbProdutoEmbalagem_FatorEstoque.DataPropertyName = "TbProdutoEmbalagem_FatorEstoque";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DtgTbProdutoEmbalagem_FatorEstoque.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgTbProdutoEmbalagem_FatorEstoque.HeaderText = "Fator";
            this.DtgTbProdutoEmbalagem_FatorEstoque.Name = "DtgTbProdutoEmbalagem_FatorEstoque";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TbProdutoEmbalagem_Embalagem";
            this.dataGridViewTextBoxColumn2.HeaderText = "Emb";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 35;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TbProdutoEmbalagem_EmbalagemDescricao";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "TbProdutoEmbalagem_StatusProdutoEmbalagem";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Status Pag";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 184;
            this.label3.Text = "Lista de Códigos Barra";
            // 
            // dtgEmbalagemCdBarra
            // 
            this.dtgEmbalagemCdBarra.AllowUserToAddRows = false;
            this.dtgEmbalagemCdBarra.AllowUserToDeleteRows = false;
            this.dtgEmbalagemCdBarra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmbalagemCdBarra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdProduto,
            this.EmbalagemEstoque,
            this.CdBarra,
            this.Tipo,
            this.BlueCod,
            this.EmbBlue,
            this.Ativo});
            this.dtgEmbalagemCdBarra.Location = new System.Drawing.Point(6, 161);
            this.dtgEmbalagemCdBarra.Name = "dtgEmbalagemCdBarra";
            this.dtgEmbalagemCdBarra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmbalagemCdBarra.Size = new System.Drawing.Size(484, 153);
            this.dtgEmbalagemCdBarra.TabIndex = 162;
            // 
            // CdProduto
            // 
            this.CdProduto.DataPropertyName = "CdProduto";
            this.CdProduto.HeaderText = "Cód Pag";
            this.CdProduto.Name = "CdProduto";
            this.CdProduto.ReadOnly = true;
            this.CdProduto.Width = 55;
            // 
            // EmbalagemEstoque
            // 
            this.EmbalagemEstoque.DataPropertyName = "Embalagem";
            this.EmbalagemEstoque.HeaderText = "Emb";
            this.EmbalagemEstoque.Name = "EmbalagemEstoque";
            this.EmbalagemEstoque.ReadOnly = true;
            this.EmbalagemEstoque.Width = 35;
            // 
            // CdBarra
            // 
            this.CdBarra.DataPropertyName = "CdBarra";
            this.CdBarra.HeaderText = "Cod Barra";
            this.CdBarra.Name = "CdBarra";
            this.CdBarra.Width = 110;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 45;
            // 
            // BlueCod
            // 
            this.BlueCod.DataPropertyName = "CdProdutoBlueSoft";
            this.BlueCod.HeaderText = "BlueSoft Cod";
            this.BlueCod.Name = "BlueCod";
            this.BlueCod.Width = 55;
            // 
            // EmbBlue
            // 
            this.EmbBlue.DataPropertyName = "EmbalagemBlueSoft";
            this.EmbBlue.HeaderText = "Emb. Blue";
            this.EmbBlue.Name = "EmbBlue";
            this.EmbBlue.Width = 45;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "StatusProdutosEmbalagemCb";
            this.Ativo.HeaderText = "Status Pag";
            this.Ativo.Name = "Ativo";
            this.Ativo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ativo.Width = 45;
            // 
            // FrmXProdutoDetalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 444);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCdProduto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXProdutoDetalhe";
            this.Text = "Detalhe";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagemCdBarra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCdProduto;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgEmbalagemCdBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlueCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmbBlue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridView dtgEmbalagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgTbProdutoEmbalagem_FatorEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}