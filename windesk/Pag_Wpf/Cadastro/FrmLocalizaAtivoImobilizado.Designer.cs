namespace Pag_Wpf.Cadastro
{
    partial class FrmLocalizaAtivoImobilizado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.CMDSeleciona = new System.Windows.Forms.Button();
            this.DTGWFLocalizaAtivoImobilizado = new System.Windows.Forms.DataGridView();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTDescricaoAtivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CHKSelecionaAtivoTipoComponente = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGWFLocalizaAtivoImobilizado)).BeginInit();
            this.SuspendLayout();
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLocalizar.ForeColor = System.Drawing.Color.Black;
            this.CMDLocalizar.Location = new System.Drawing.Point(691, 54);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(100, 32);
            this.CMDLocalizar.TabIndex = 102;
            this.CMDLocalizar.Text = "&Localizar";
            this.CMDLocalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // CmdCancela
            // 
            this.CmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(716, 312);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(75, 33);
            this.CmdCancela.TabIndex = 101;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            // 
            // CMDSeleciona
            // 
            this.CMDSeleciona.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CMDSeleciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDSeleciona.Location = new System.Drawing.Point(612, 312);
            this.CMDSeleciona.Name = "CMDSeleciona";
            this.CMDSeleciona.Size = new System.Drawing.Size(98, 33);
            this.CMDSeleciona.TabIndex = 100;
            this.CMDSeleciona.Text = "Selecionar";
            this.CMDSeleciona.UseVisualStyleBackColor = true;
            this.CMDSeleciona.Click += new System.EventHandler(this.CMDSeleciona_Click);
            // 
            // DTGWFLocalizaAtivoImobilizado
            // 
            this.DTGWFLocalizaAtivoImobilizado.AllowUserToAddRows = false;
            this.DTGWFLocalizaAtivoImobilizado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGWFLocalizaAtivoImobilizado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DTGWFLocalizaAtivoImobilizado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGWFLocalizaAtivoImobilizado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnCdProduto,
            this.DTGColumnDescricao});
            this.DTGWFLocalizaAtivoImobilizado.Location = new System.Drawing.Point(25, 92);
            this.DTGWFLocalizaAtivoImobilizado.Name = "DTGWFLocalizaAtivoImobilizado";
            this.DTGWFLocalizaAtivoImobilizado.ReadOnly = true;
            this.DTGWFLocalizaAtivoImobilizado.Size = new System.Drawing.Size(766, 214);
            this.DTGWFLocalizaAtivoImobilizado.TabIndex = 99;
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "SeqAtivoImobilizado";
            this.DTGColumnCdProduto.HeaderText = "Ativo";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 90;
            // 
            // DTGColumnDescricao
            // 
            this.DTGColumnDescricao.DataPropertyName = "Descricao";
            this.DTGColumnDescricao.HeaderText = "Descrição";
            this.DTGColumnDescricao.Name = "DTGColumnDescricao";
            this.DTGColumnDescricao.ReadOnly = true;
            this.DTGColumnDescricao.Width = 450;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 59);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 96;
            this.label4.Text = "Descrição do Ativo";
            // 
            // TXTDescricaoAtivo
            // 
            this.TXTDescricaoAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDescricaoAtivo.Location = new System.Drawing.Point(231, 59);
            this.TXTDescricaoAtivo.MaxLength = 60;
            this.TXTDescricaoAtivo.Name = "TXTDescricaoAtivo";
            this.TXTDescricaoAtivo.Size = new System.Drawing.Size(213, 26);
            this.TXTDescricaoAtivo.TabIndex = 95;
            this.TXTDescricaoAtivo.TextChanged += new System.EventHandler(this.TXTDescricaoAtivo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(656, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 94;
            this.label2.Text = "Localiza Participante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 93;
            this.label1.Text = "Cadastros";
            // 
            // CHKSelecionaAtivoTipoComponente
            // 
            this.CHKSelecionaAtivoTipoComponente.AutoSize = true;
            this.CHKSelecionaAtivoTipoComponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKSelecionaAtivoTipoComponente.Location = new System.Drawing.Point(450, 58);
            this.CHKSelecionaAtivoTipoComponente.Name = "CHKSelecionaAtivoTipoComponente";
            this.CHKSelecionaAtivoTipoComponente.Size = new System.Drawing.Size(209, 24);
            this.CHKSelecionaAtivoTipoComponente.TabIndex = 103;
            this.CHKSelecionaAtivoTipoComponente.Text = "Componentes de Ativo";
            this.CHKSelecionaAtivoTipoComponente.UseVisualStyleBackColor = true;
            this.CHKSelecionaAtivoTipoComponente.CheckedChanged += new System.EventHandler(this.CHKSelecionaAtivoTipoComponente_CheckedChanged);
            // 
            // FrmLocalizaAtivoImobilizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 358);
            this.Controls.Add(this.CHKSelecionaAtivoTipoComponente);
            this.Controls.Add(this.CMDLocalizar);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.CMDSeleciona);
            this.Controls.Add(this.DTGWFLocalizaAtivoImobilizado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTDescricaoAtivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalizaAtivoImobilizado";
            this.Text = "FrmLocalizaAtivoImobilizado";
            ((System.ComponentModel.ISupportInitialize)(this.DTGWFLocalizaAtivoImobilizado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button CMDSeleciona;
        private System.Windows.Forms.DataGridView DTGWFLocalizaAtivoImobilizado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTDescricaoAtivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDescricao;
        private System.Windows.Forms.CheckBox CHKSelecionaAtivoTipoComponente;
    }
}