namespace Pag_Wpf.Cadastro
{
    partial class ProdutoLocaliza
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSeleciona = new System.Windows.Forms.Button();
            this.cmdCancela = new System.Windows.Forms.Button();
            this.DataGridProdutoLocaliza = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.TXTCodigoProduto = new System.Windows.Forms.TextBox();
            this.TXTDescricaoProduto = new System.Windows.Forms.TextBox();
            this.CMBFabricante = new System.Windows.Forms.ComboBox();
            this.CMBLinha = new System.Windows.Forms.ComboBox();
            this.CMBSecao = new System.Windows.Forms.ComboBox();
            this.CMBDepartamento = new System.Windows.Forms.ComboBox();
            this.LBLINFO_QTDE_LINHAS_SELECIONADA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnStatusProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutoLocaliza)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSeleciona
            // 
            this.cmdSeleciona.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSeleciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmdSeleciona.Location = new System.Drawing.Point(701, 408);
            this.cmdSeleciona.Name = "cmdSeleciona";
            this.cmdSeleciona.Size = new System.Drawing.Size(93, 32);
            this.cmdSeleciona.TabIndex = 3;
            this.cmdSeleciona.Text = "Selecionar";
            this.cmdSeleciona.UseVisualStyleBackColor = true;
            this.cmdSeleciona.Click += new System.EventHandler(this.cmdSeleciona_Click);
            // 
            // cmdCancela
            // 
            this.cmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmdCancela.Location = new System.Drawing.Point(620, 408);
            this.cmdCancela.Name = "cmdCancela";
            this.cmdCancela.Size = new System.Drawing.Size(75, 32);
            this.cmdCancela.TabIndex = 2;
            this.cmdCancela.Text = "Cancela";
            this.cmdCancela.UseVisualStyleBackColor = true;
            this.cmdCancela.Click += new System.EventHandler(this.cmdCancela_Click);
            // 
            // DataGridProdutoLocaliza
            // 
            this.DataGridProdutoLocaliza.AllowUserToAddRows = false;
            this.DataGridProdutoLocaliza.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridProdutoLocaliza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridProdutoLocaliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridProdutoLocaliza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnCdProduto,
            this.DTGColumnDescricao,
            this.DTGColumnEmbalagemEstoque,
            this.DTGColumnStatusProduto});
            this.DataGridProdutoLocaliza.Location = new System.Drawing.Point(15, 135);
            this.DataGridProdutoLocaliza.Name = "DataGridProdutoLocaliza";
            this.DataGridProdutoLocaliza.ReadOnly = true;
            this.DataGridProdutoLocaliza.Size = new System.Drawing.Size(779, 267);
            this.DataGridProdutoLocaliza.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CMDLocalizar);
            this.panel1.Controls.Add(this.TXTCodigoProduto);
            this.panel1.Controls.Add(this.TXTDescricaoProduto);
            this.panel1.Controls.Add(this.CMBFabricante);
            this.panel1.Controls.Add(this.CMBLinha);
            this.panel1.Controls.Add(this.CMBSecao);
            this.panel1.Controls.Add(this.CMBDepartamento);
            this.panel1.Location = new System.Drawing.Point(14, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 126);
            this.panel1.TabIndex = 73;
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.CMDLocalizar.Location = new System.Drawing.Point(621, 70);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(85, 32);
            this.CMDLocalizar.TabIndex = 12;
            this.CMDLocalizar.Text = "Localiza";
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // TXTCodigoProduto
            // 
            this.TXTCodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TXTCodigoProduto.Location = new System.Drawing.Point(309, 92);
            this.TXTCodigoProduto.Name = "TXTCodigoProduto";
            this.TXTCodigoProduto.Size = new System.Drawing.Size(146, 26);
            this.TXTCodigoProduto.TabIndex = 2;
            // 
            // TXTDescricaoProduto
            // 
            this.TXTDescricaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TXTDescricaoProduto.Location = new System.Drawing.Point(14, 92);
            this.TXTDescricaoProduto.Name = "TXTDescricaoProduto";
            this.TXTDescricaoProduto.Size = new System.Drawing.Size(289, 26);
            this.TXTDescricaoProduto.TabIndex = 0;
            // 
            // CMBFabricante
            // 
            this.CMBFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBFabricante.FormattingEnabled = true;
            this.CMBFabricante.Location = new System.Drawing.Point(462, 36);
            this.CMBFabricante.Name = "CMBFabricante";
            this.CMBFabricante.Size = new System.Drawing.Size(244, 28);
            this.CMBFabricante.TabIndex = 6;
            // 
            // CMBLinha
            // 
            this.CMBLinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBLinha.FormattingEnabled = true;
            this.CMBLinha.Location = new System.Drawing.Point(310, 36);
            this.CMBLinha.Name = "CMBLinha";
            this.CMBLinha.Size = new System.Drawing.Size(146, 28);
            this.CMBLinha.TabIndex = 4;
            // 
            // CMBSecao
            // 
            this.CMBSecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBSecao.FormattingEnabled = true;
            this.CMBSecao.Location = new System.Drawing.Point(156, 36);
            this.CMBSecao.Name = "CMBSecao";
            this.CMBSecao.Size = new System.Drawing.Size(148, 28);
            this.CMBSecao.TabIndex = 2;
            // 
            // CMBDepartamento
            // 
            this.CMBDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBDepartamento.FormattingEnabled = true;
            this.CMBDepartamento.Location = new System.Drawing.Point(15, 36);
            this.CMBDepartamento.Name = "CMBDepartamento";
            this.CMBDepartamento.Size = new System.Drawing.Size(135, 28);
            this.CMBDepartamento.TabIndex = 0;
            // 
            // LBLINFO_QTDE_LINHAS_SELECIONADA
            // 
            this.LBLINFO_QTDE_LINHAS_SELECIONADA.AutoSize = true;
            this.LBLINFO_QTDE_LINHAS_SELECIONADA.Location = new System.Drawing.Point(12, 262);
            this.LBLINFO_QTDE_LINHAS_SELECIONADA.Name = "LBLINFO_QTDE_LINHAS_SELECIONADA";
            this.LBLINFO_QTDE_LINHAS_SELECIONADA.Size = new System.Drawing.Size(0, 13);
            this.LBLINFO_QTDE_LINHAS_SELECIONADA.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 67);
            this.label5.MinimumSize = new System.Drawing.Size(290, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 22);
            this.label5.TabIndex = 70;
            this.label5.Text = "Descrição";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(309, 67);
            this.label6.MinimumSize = new System.Drawing.Size(145, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 22);
            this.label6.TabIndex = 71;
            this.label6.Text = "Códigos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 11);
            this.label7.MinimumSize = new System.Drawing.Size(135, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 22);
            this.label7.TabIndex = 72;
            this.label7.Text = "Departamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 11);
            this.label1.MinimumSize = new System.Drawing.Size(150, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 73;
            this.label1.Text = "Seção";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(310, 11);
            this.label2.MinimumSize = new System.Drawing.Size(145, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 74;
            this.label2.Text = "Linha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(462, 11);
            this.label3.MinimumSize = new System.Drawing.Size(245, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 22);
            this.label3.TabIndex = 75;
            this.label3.Text = "Fabricante";
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "CdProduto";
            this.DTGColumnCdProduto.HeaderText = "Produto";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 90;
            // 
            // DTGColumnDescricao
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DTGColumnDescricao.DefaultCellStyle = dataGridViewCellStyle10;
            this.DTGColumnDescricao.HeaderText = "Descrição";
            this.DTGColumnDescricao.Name = "DTGColumnDescricao";
            this.DTGColumnDescricao.ReadOnly = true;
            this.DTGColumnDescricao.Width = 400;
            // 
            // DTGColumnEmbalagemEstoque
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DTGColumnEmbalagemEstoque.DefaultCellStyle = dataGridViewCellStyle11;
            this.DTGColumnEmbalagemEstoque.HeaderText = "Emb.";
            this.DTGColumnEmbalagemEstoque.Name = "DTGColumnEmbalagemEstoque";
            this.DTGColumnEmbalagemEstoque.ReadOnly = true;
            // 
            // DTGColumnStatusProduto
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DTGColumnStatusProduto.DefaultCellStyle = dataGridViewCellStyle12;
            this.DTGColumnStatusProduto.HeaderText = "Status";
            this.DTGColumnStatusProduto.Name = "DTGColumnStatusProduto";
            this.DTGColumnStatusProduto.ReadOnly = true;
            // 
            // ProdutoLocaliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 442);
            this.Controls.Add(this.LBLINFO_QTDE_LINHAS_SELECIONADA);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataGridProdutoLocaliza);
            this.Controls.Add(this.cmdSeleciona);
            this.Controls.Add(this.cmdCancela);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdutoLocaliza";
            this.Text = "ProdutoLocaliza";
            this.Load += new System.EventHandler(this.ProdutoLocaliza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutoLocaliza)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSeleciona;
        private System.Windows.Forms.Button cmdCancela;
        private System.Windows.Forms.DataGridView DataGridProdutoLocaliza;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TXTCodigoProduto;
        private System.Windows.Forms.TextBox TXTDescricaoProduto;
        private System.Windows.Forms.ComboBox CMBFabricante;
        private System.Windows.Forms.ComboBox CMBLinha;
        private System.Windows.Forms.ComboBox CMBSecao;
        private System.Windows.Forms.ComboBox CMBDepartamento;
        private System.Windows.Forms.Label LBLINFO_QTDE_LINHAS_SELECIONADA;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnStatusProduto;
    }
}