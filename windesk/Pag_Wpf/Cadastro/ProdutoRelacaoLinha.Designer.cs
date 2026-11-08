namespace Pag_Wpf.Cadastro
{
    partial class ProdutoRelacaoLinha
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.CMDEfetiva = new System.Windows.Forms.Button();
            this.DataGridProdutoLocaliza = new System.Windows.Forms.DataGridView();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnStatusProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMBDepartamento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CMBSecao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CMBLinha = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutoLocaliza)).BeginInit();
            this.SuspendLayout();
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Blue;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 5;
            this.lineShape1.X2 = 774;
            this.lineShape1.Y1 = 29;
            this.lineShape1.Y2 = 29;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.Blue;
            this.lineShape4.BorderWidth = 3;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 198;
            this.lineShape4.X2 = 198;
            this.lineShape4.Y1 = 4;
            this.lineShape4.Y2 = 29;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape4,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(783, 258);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(638, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "Definição da Linha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Cadastro - Produto";
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(596, 214);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(85, 32);
            this.CMDCancelar.TabIndex = 79;
            this.CMDCancelar.Text = "Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            this.CMDCancelar.Click += new System.EventHandler(this.CMDCancelar_Click);
            // 
            // CMDEfetiva
            // 
            this.CMDEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDEfetiva.Location = new System.Drawing.Point(687, 214);
            this.CMDEfetiva.Name = "CMDEfetiva";
            this.CMDEfetiva.Size = new System.Drawing.Size(85, 32);
            this.CMDEfetiva.TabIndex = 78;
            this.CMDEfetiva.Text = "Efetivar";
            this.CMDEfetiva.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDEfetiva.UseVisualStyleBackColor = true;
            this.CMDEfetiva.Click += new System.EventHandler(this.CMDEfetiva_Click);
            // 
            // DataGridProdutoLocaliza
            // 
            this.DataGridProdutoLocaliza.AllowUserToAddRows = false;
            this.DataGridProdutoLocaliza.AllowUserToDeleteRows = false;
            this.DataGridProdutoLocaliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridProdutoLocaliza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnCdProduto,
            this.DTGColumnDescricao,
            this.DTGColumnEmbalagemEstoque,
            this.DTGColumnStatusProduto});
            this.DataGridProdutoLocaliza.Location = new System.Drawing.Point(377, 60);
            this.DataGridProdutoLocaliza.Name = "DataGridProdutoLocaliza";
            this.DataGridProdutoLocaliza.ReadOnly = true;
            this.DataGridProdutoLocaliza.Size = new System.Drawing.Size(394, 139);
            this.DataGridProdutoLocaliza.TabIndex = 77;
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "CdProduto";
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTGColumnCdProduto.DefaultCellStyle = dataGridViewCellStyle29;
            this.DTGColumnCdProduto.HeaderText = "Produto";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 90;
            // 
            // DTGColumnDescricao
            // 
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnDescricao.DefaultCellStyle = dataGridViewCellStyle30;
            this.DTGColumnDescricao.HeaderText = "Descrição";
            this.DTGColumnDescricao.Name = "DTGColumnDescricao";
            this.DTGColumnDescricao.ReadOnly = true;
            this.DTGColumnDescricao.Width = 300;
            // 
            // DTGColumnEmbalagemEstoque
            // 
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnEmbalagemEstoque.DefaultCellStyle = dataGridViewCellStyle31;
            this.DTGColumnEmbalagemEstoque.HeaderText = "Emb.";
            this.DTGColumnEmbalagemEstoque.Name = "DTGColumnEmbalagemEstoque";
            this.DTGColumnEmbalagemEstoque.ReadOnly = true;
            // 
            // DTGColumnStatusProduto
            // 
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnStatusProduto.DefaultCellStyle = dataGridViewCellStyle32;
            this.DTGColumnStatusProduto.HeaderText = "Status";
            this.DTGColumnStatusProduto.Name = "DTGColumnStatusProduto";
            this.DTGColumnStatusProduto.ReadOnly = true;
            // 
            // CMBDepartamento
            // 
            this.CMBDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBDepartamento.FormattingEnabled = true;
            this.CMBDepartamento.Location = new System.Drawing.Point(136, 60);
            this.CMBDepartamento.Name = "CMBDepartamento";
            this.CMBDepartamento.Size = new System.Drawing.Size(235, 28);
            this.CMBDepartamento.TabIndex = 76;
            this.CMBDepartamento.SelectedIndexChanged += new System.EventHandler(this.CMBDepartamento_SelectedIndexChanged);
            this.CMBDepartamento.SelectionChangeCommitted += new System.EventHandler(this.CMBDepartamento_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.MinimumSize = new System.Drawing.Size(120, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 22);
            this.label4.TabIndex = 75;
            this.label4.Text = "Departamento";
            // 
            // CMBSecao
            // 
            this.CMBSecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBSecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBSecao.FormattingEnabled = true;
            this.CMBSecao.Location = new System.Drawing.Point(136, 93);
            this.CMBSecao.Name = "CMBSecao";
            this.CMBSecao.Size = new System.Drawing.Size(235, 28);
            this.CMBSecao.TabIndex = 81;
            this.CMBSecao.SelectedIndexChanged += new System.EventHandler(this.CMBSecao_SelectedIndexChanged);
            this.CMBSecao.SelectionChangeCommitted += new System.EventHandler(this.CMBSecao_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.MinimumSize = new System.Drawing.Size(120, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 80;
            this.label3.Text = "Seção";
            // 
            // CMBLinha
            // 
            this.CMBLinha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBLinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBLinha.FormattingEnabled = true;
            this.CMBLinha.Location = new System.Drawing.Point(136, 127);
            this.CMBLinha.Name = "CMBLinha";
            this.CMBLinha.Size = new System.Drawing.Size(235, 28);
            this.CMBLinha.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 127);
            this.label5.MinimumSize = new System.Drawing.Size(120, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 82;
            this.label5.Text = "Linha";
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Blue;
            this.lineShape2.BorderWidth = 5;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 3;
            this.lineShape2.X2 = 772;
            this.lineShape2.Y1 = 205;
            this.lineShape2.Y2 = 205;
            // 
            // ProdutoRelacaoLinha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 258);
            this.Controls.Add(this.CMBLinha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMBSecao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDEfetiva);
            this.Controls.Add(this.DataGridProdutoLocaliza);
            this.Controls.Add(this.CMBDepartamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdutoRelacaoLinha";
            this.Text = "ProdutoRelacaoLinha";
            this.Load += new System.EventHandler(this.ProdutoRelacaoLinha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutoLocaliza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.Button CMDEfetiva;
        private System.Windows.Forms.DataGridView DataGridProdutoLocaliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnStatusProduto;
        private System.Windows.Forms.ComboBox CMBDepartamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CMBSecao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMBLinha;
        private System.Windows.Forms.Label label5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
    }
}