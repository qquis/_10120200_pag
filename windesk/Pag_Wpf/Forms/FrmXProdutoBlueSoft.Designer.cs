namespace Pag_Wpf.Forms
{
    partial class FrmXProdutoBlueSoft
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
            this.dtgProdutoBlueSoft = new System.Windows.Forms.DataGridView();
            this.CdProdutoBlueSoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarraReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdProdutoBlueSoftUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcdProdutoBluePesquisar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescricaoBluePesquisar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.dtgEmbalagem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.prgProduto = new System.Windows.Forms.ProgressBar();
            this.LBLProdutoSelecionado = new System.Windows.Forms.Label();
            this.txtcdProdutoBlueSoftSelecionado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdescricaoblueselecionado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdCodigoUnitario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutoBlueSoft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagem)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProdutoBlueSoft
            // 
            this.dtgProdutoBlueSoft.AllowUserToAddRows = false;
            this.dtgProdutoBlueSoft.AllowUserToDeleteRows = false;
            this.dtgProdutoBlueSoft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProdutoBlueSoft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdProdutoBlueSoft,
            this.Descricao,
            this.CodigoBarraReferencia,
            this.EmbalagemEstoque,
            this.CdProdutoBlueSoftUnitario});
            this.dtgProdutoBlueSoft.Location = new System.Drawing.Point(12, 62);
            this.dtgProdutoBlueSoft.Name = "dtgProdutoBlueSoft";
            this.dtgProdutoBlueSoft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProdutoBlueSoft.Size = new System.Drawing.Size(831, 230);
            this.dtgProdutoBlueSoft.TabIndex = 161;
            this.dtgProdutoBlueSoft.SelectionChanged += new System.EventHandler(this.dtgProdutoBlueSoft_SelectionChanged);
            // 
            // CdProdutoBlueSoft
            // 
            this.CdProdutoBlueSoft.DataPropertyName = "CdProdutoBlueSoft";
            this.CdProdutoBlueSoft.HeaderText = "Cód BlueSoft";
            this.CdProdutoBlueSoft.Name = "CdProdutoBlueSoft";
            this.CdProdutoBlueSoft.ReadOnly = true;
            this.CdProdutoBlueSoft.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 250;
            // 
            // CodigoBarraReferencia
            // 
            this.CodigoBarraReferencia.DataPropertyName = "CodigoBarraReferencia";
            this.CodigoBarraReferencia.HeaderText = "Cd Barra Ref";
            this.CodigoBarraReferencia.Name = "CodigoBarraReferencia";
            // 
            // EmbalagemEstoque
            // 
            this.EmbalagemEstoque.DataPropertyName = "EmbalagemEstoque";
            this.EmbalagemEstoque.HeaderText = "Emb";
            this.EmbalagemEstoque.Name = "EmbalagemEstoque";
            this.EmbalagemEstoque.ReadOnly = true;
            this.EmbalagemEstoque.Width = 70;
            // 
            // CdProdutoBlueSoftUnitario
            // 
            this.CdProdutoBlueSoftUnitario.DataPropertyName = "CdProdutoBlueSoftUnitario";
            this.CdProdutoBlueSoftUnitario.HeaderText = "Cd BlueSoft Unit";
            this.CdProdutoBlueSoftUnitario.Name = "CdProdutoBlueSoftUnitario";
            this.CdProdutoBlueSoftUnitario.ReadOnly = true;
            this.CdProdutoBlueSoftUnitario.Width = 70;
            // 
            // txtcdProdutoBluePesquisar
            // 
            this.txtcdProdutoBluePesquisar.Location = new System.Drawing.Point(12, 36);
            this.txtcdProdutoBluePesquisar.Name = "txtcdProdutoBluePesquisar";
            this.txtcdProdutoBluePesquisar.Size = new System.Drawing.Size(87, 20);
            this.txtcdProdutoBluePesquisar.TabIndex = 166;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 167;
            this.label7.Text = "Código BlueSoft";
            // 
            // txtDescricaoBluePesquisar
            // 
            this.txtDescricaoBluePesquisar.Location = new System.Drawing.Point(105, 36);
            this.txtDescricaoBluePesquisar.Name = "txtDescricaoBluePesquisar";
            this.txtDescricaoBluePesquisar.Size = new System.Drawing.Size(293, 20);
            this.txtDescricaoBluePesquisar.TabIndex = 168;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 169;
            this.label3.Text = "Descrição";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(788, 520);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 172;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // dtgEmbalagem
            // 
            this.dtgEmbalagem.AllowUserToAddRows = false;
            this.dtgEmbalagem.AllowUserToDeleteRows = false;
            this.dtgEmbalagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmbalagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.CodigoBarra,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.dtgEmbalagem.Location = new System.Drawing.Point(12, 347);
            this.dtgEmbalagem.Name = "dtgEmbalagem";
            this.dtgEmbalagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmbalagem.Size = new System.Drawing.Size(876, 167);
            this.dtgEmbalagem.TabIndex = 173;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CdProdutoBlueSoft";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cód";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EmbalagemProdutoDescricao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Embalagem";
            this.dataGridViewTextBoxColumn3.HeaderText = "Emb";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // CodigoBarra
            // 
            this.CodigoBarra.DataPropertyName = "CodigoBarra";
            this.CodigoBarra.HeaderText = "Código de Barra";
            this.CodigoBarra.Name = "CodigoBarra";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EmbalagemProdutoFator_Estoque";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fator";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "statusproduto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(669, 33);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 175;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.Image = global::Pag_Wpf.Properties.Resources.detalhe;
            this.cmdDetalhe.Location = new System.Drawing.Point(849, 62);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(39, 23);
            this.cmdDetalhe.TabIndex = 171;
            this.cmdDetalhe.UseVisualStyleBackColor = true;
            this.cmdDetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(439, 33);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 170;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // prgProduto
            // 
            this.prgProduto.Location = new System.Drawing.Point(714, 33);
            this.prgProduto.Name = "prgProduto";
            this.prgProduto.Size = new System.Drawing.Size(174, 23);
            this.prgProduto.TabIndex = 176;
            // 
            // LBLProdutoSelecionado
            // 
            this.LBLProdutoSelecionado.AutoSize = true;
            this.LBLProdutoSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLProdutoSelecionado.Location = new System.Drawing.Point(153, 298);
            this.LBLProdutoSelecionado.Name = "LBLProdutoSelecionado";
            this.LBLProdutoSelecionado.Size = new System.Drawing.Size(0, 13);
            this.LBLProdutoSelecionado.TabIndex = 177;
            // 
            // txtcdProdutoBlueSoftSelecionado
            // 
            this.txtcdProdutoBlueSoftSelecionado.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtcdProdutoBlueSoftSelecionado.Enabled = false;
            this.txtcdProdutoBlueSoftSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcdProdutoBlueSoftSelecionado.Location = new System.Drawing.Point(12, 321);
            this.txtcdProdutoBlueSoftSelecionado.Name = "txtcdProdutoBlueSoftSelecionado";
            this.txtcdProdutoBlueSoftSelecionado.Size = new System.Drawing.Size(80, 20);
            this.txtcdProdutoBlueSoftSelecionado.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 179;
            this.label1.Text = "Código";
            // 
            // txtdescricaoblueselecionado
            // 
            this.txtdescricaoblueselecionado.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtdescricaoblueselecionado.Enabled = false;
            this.txtdescricaoblueselecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescricaoblueselecionado.Location = new System.Drawing.Point(98, 321);
            this.txtdescricaoblueselecionado.Name = "txtdescricaoblueselecionado";
            this.txtdescricaoblueselecionado.Size = new System.Drawing.Size(223, 20);
            this.txtdescricaoblueselecionado.TabIndex = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 181;
            this.label2.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 13);
            this.label4.TabIndex = 182;
            this.label4.Text = "Atualizar Base Pag com os dados da BlueSoft";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 183;
            this.label5.Text = "Buscar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 528);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 185;
            this.label6.Text = "Validação do Rel. Código Unit";
            // 
            // cmdCodigoUnitario
            // 
            this.cmdCodigoUnitario.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdCodigoUnitario.Location = new System.Drawing.Point(12, 520);
            this.cmdCodigoUnitario.Name = "cmdCodigoUnitario";
            this.cmdCodigoUnitario.Size = new System.Drawing.Size(39, 23);
            this.cmdCodigoUnitario.TabIndex = 184;
            this.cmdCodigoUnitario.UseVisualStyleBackColor = true;
            this.cmdCodigoUnitario.Click += new System.EventHandler(this.cmdCodigoUnitario_Click);
            // 
            // FrmXProdutoBlueSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdCodigoUnitario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdescricaoblueselecionado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcdProdutoBlueSoftSelecionado);
            this.Controls.Add(this.LBLProdutoSelecionado);
            this.Controls.Add(this.prgProduto);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.dtgEmbalagem);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtDescricaoBluePesquisar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcdProdutoBluePesquisar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgProdutoBlueSoft);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXProdutoBlueSoft";
            this.Text = "Produto BlueSoft Base B.I.";
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutoBlueSoft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmbalagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgProdutoBlueSoft;
        private System.Windows.Forms.TextBox txtcdProdutoBluePesquisar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricaoBluePesquisar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.DataGridView dtgEmbalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProdutoBlueSoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarraReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProdutoBlueSoftUnitario;
        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.ProgressBar prgProduto;
        private System.Windows.Forms.Label LBLProdutoSelecionado;
        private System.Windows.Forms.TextBox txtcdProdutoBlueSoftSelecionado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdescricaoblueselecionado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdCodigoUnitario;
    }
}