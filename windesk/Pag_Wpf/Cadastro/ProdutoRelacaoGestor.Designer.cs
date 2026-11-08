namespace Pag_Wpf.Cadastro
{
    partial class ProdutoRelacaoGestor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridProdutoLocaliza = new System.Windows.Forms.DataGridView();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnStatusProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMBGestor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.CMDEfetiva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutoLocaliza)).BeginInit();
            this.SuspendLayout();
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Blue;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 638;
            this.lineShape1.Y1 = 32;
            this.lineShape1.Y2 = 32;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.Blue;
            this.lineShape4.BorderWidth = 3;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 192;
            this.lineShape4.X2 = 192;
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
            this.shapeContainer1.Size = new System.Drawing.Size(645, 273);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(493, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Definição de Gestor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Cadastro - Produto";
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
            this.DataGridProdutoLocaliza.Location = new System.Drawing.Point(6, 75);
            this.DataGridProdutoLocaliza.Name = "DataGridProdutoLocaliza";
            this.DataGridProdutoLocaliza.ReadOnly = true;
            this.DataGridProdutoLocaliza.Size = new System.Drawing.Size(632, 139);
            this.DataGridProdutoLocaliza.TabIndex = 74;
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "CdProduto";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTGColumnCdProduto.DefaultCellStyle = dataGridViewCellStyle13;
            this.DTGColumnCdProduto.HeaderText = "Produto";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 90;
            // 
            // DTGColumnDescricao
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnDescricao.DefaultCellStyle = dataGridViewCellStyle14;
            this.DTGColumnDescricao.HeaderText = "Descrição";
            this.DTGColumnDescricao.Name = "DTGColumnDescricao";
            this.DTGColumnDescricao.ReadOnly = true;
            this.DTGColumnDescricao.Width = 300;
            // 
            // DTGColumnEmbalagemEstoque
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnEmbalagemEstoque.DefaultCellStyle = dataGridViewCellStyle15;
            this.DTGColumnEmbalagemEstoque.HeaderText = "Emb.";
            this.DTGColumnEmbalagemEstoque.Name = "DTGColumnEmbalagemEstoque";
            this.DTGColumnEmbalagemEstoque.ReadOnly = true;
            // 
            // DTGColumnStatusProduto
            // 
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DTGColumnStatusProduto.DefaultCellStyle = dataGridViewCellStyle16;
            this.DTGColumnStatusProduto.HeaderText = "Status";
            this.DTGColumnStatusProduto.Name = "DTGColumnStatusProduto";
            this.DTGColumnStatusProduto.ReadOnly = true;
            // 
            // CMBGestor
            // 
            this.CMBGestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBGestor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBGestor.FormattingEnabled = true;
            this.CMBGestor.Location = new System.Drawing.Point(218, 41);
            this.CMBGestor.Name = "CMBGestor";
            this.CMBGestor.Size = new System.Drawing.Size(420, 28);
            this.CMBGestor.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 72;
            this.label4.Text = "Categoria";
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Blue;
            this.lineShape2.BorderWidth = 5;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -1;
            this.lineShape2.X2 = 640;
            this.lineShape2.Y1 = 229;
            this.lineShape2.Y2 = 229;
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(462, 238);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(85, 32);
            this.CMDCancelar.TabIndex = 76;
            this.CMDCancelar.Text = "Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            this.CMDCancelar.Click += new System.EventHandler(this.CMDCancelar_Click);
            // 
            // CMDEfetiva
            // 
            this.CMDEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDEfetiva.Location = new System.Drawing.Point(553, 238);
            this.CMDEfetiva.Name = "CMDEfetiva";
            this.CMDEfetiva.Size = new System.Drawing.Size(85, 32);
            this.CMDEfetiva.TabIndex = 75;
            this.CMDEfetiva.Text = "Efetivar";
            this.CMDEfetiva.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDEfetiva.UseVisualStyleBackColor = true;
            this.CMDEfetiva.Click += new System.EventHandler(this.CMDEfetiva_Click);
            // 
            // ProdutoRelacaoGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 273);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDEfetiva);
            this.Controls.Add(this.DataGridProdutoLocaliza);
            this.Controls.Add(this.CMBGestor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdutoRelacaoGestor";
            this.Text = "ProdutoRelacaoGestor";
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
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.DataGridView DataGridProdutoLocaliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnStatusProduto;
        private System.Windows.Forms.ComboBox CMBGestor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.Button CMDEfetiva;
    }
}