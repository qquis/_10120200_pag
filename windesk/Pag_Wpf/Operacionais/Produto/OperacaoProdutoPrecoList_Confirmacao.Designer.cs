namespace Pag_Wpf.Operacionais.Produto
{
    partial class OperacaoProdutoPrecoList_Confirmacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGListAlterados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMDEfetiva = new System.Windows.Forms.Button();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.TXTTotalItens = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DTPData = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DGListAlterados)).BeginInit();
            this.SuspendLayout();
            // 
            // DGListAlterados
            // 
            this.DGListAlterados.AllowUserToAddRows = false;
            this.DGListAlterados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGListAlterados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGListAlterados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGListAlterados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn15});
            this.DGListAlterados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGListAlterados.Location = new System.Drawing.Point(12, 38);
            this.DGListAlterados.MultiSelect = false;
            this.DGListAlterados.Name = "DGListAlterados";
            this.DGListAlterados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGListAlterados.Size = new System.Drawing.Size(662, 296);
            this.DGListAlterados.TabIndex = 62;
            this.DGListAlterados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGListAlterados_CellContentClick);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CdProduto";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn9.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Descricao";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn10.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 270;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "EmbalagemEstoque";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn11.HeaderText = "UN";
            this.dataGridViewTextBoxColumn11.MaxInputLength = 25;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 25;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ValorCusto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn14.HeaderText = "Custo";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ValorPrecoNew";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn12.HeaderText = "Preço";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Margem";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn15.HeaderText = "Margem";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 60;
            // 
            // CMDEfetiva
            // 
            this.CMDEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDEfetiva.Location = new System.Drawing.Point(595, 339);
            this.CMDEfetiva.Name = "CMDEfetiva";
            this.CMDEfetiva.Size = new System.Drawing.Size(79, 32);
            this.CMDEfetiva.TabIndex = 111;
            this.CMDEfetiva.Text = "Efetivar";
            this.CMDEfetiva.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDEfetiva.UseVisualStyleBackColor = true;
            this.CMDEfetiva.Click += new System.EventHandler(this.CMDEfetiva_Click);
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(510, 339);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(79, 32);
            this.CMDCancelar.TabIndex = 112;
            this.CMDCancelar.Text = "Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            this.CMDCancelar.Click += new System.EventHandler(this.CMDCancelar_Click);
            // 
            // TXTTotalItens
            // 
            this.TXTTotalItens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TXTTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTTotalItens.Location = new System.Drawing.Point(12, 360);
            this.TXTTotalItens.Name = "TXTTotalItens";
            this.TXTTotalItens.ReadOnly = true;
            this.TXTTotalItens.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TXTTotalItens.Size = new System.Drawing.Size(91, 21);
            this.TXTTotalItens.TabIndex = 129;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 339);
            this.label14.MinimumSize = new System.Drawing.Size(90, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 18);
            this.label14.TabIndex = 128;
            this.label14.Text = "Total de Itens";
            // 
            // DTPData
            // 
            this.DTPData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPData.Location = new System.Drawing.Point(587, 12);
            this.DTPData.Name = "DTPData";
            this.DTPData.Size = new System.Drawing.Size(87, 20);
            this.DTPData.TabIndex = 130;
            // 
            // OperacaoProdutoPrecoList_Confirmacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 389);
            this.Controls.Add(this.DTPData);
            this.Controls.Add(this.TXTTotalItens);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDEfetiva);
            this.Controls.Add(this.DGListAlterados);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperacaoProdutoPrecoList_Confirmacao";
            this.Text = "OperacaoProdutoPrecoList_Confirmacao";
            this.Load += new System.EventHandler(this.OperacaoProdutoPrecoList_Confirmacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGListAlterados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGListAlterados;
        private System.Windows.Forms.Button CMDEfetiva;
        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.TextBox TXTTotalItens;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker DTPData;
    }
}