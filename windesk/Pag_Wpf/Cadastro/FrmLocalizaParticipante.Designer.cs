namespace Pag_Wpf.Cadastro
{
    partial class FrmLocalizaParticipante
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTDocumento = new System.Windows.Forms.TextBox();
            this.DTGWFLocalizaParticipante = new System.Windows.Forms.DataGridView();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.CMDSeleciona = new System.Windows.Forms.Button();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnInformacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnTipoEntidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DTGWFLocalizaParticipante)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(656, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Localiza Participante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cadastros";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 53);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 71;
            this.label4.Text = "Nome";
            // 
            // TXTNome
            // 
            this.TXTNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNome.Location = new System.Drawing.Point(231, 53);
            this.TXTNome.MaxLength = 60;
            this.TXTNome.Name = "TXTNome";
            this.TXTNome.Size = new System.Drawing.Size(409, 26);
            this.TXTNome.TabIndex = 70;
            this.TXTNome.TextChanged += new System.EventHandler(this.TXTNome_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 85);
            this.label3.MinimumSize = new System.Drawing.Size(200, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 22);
            this.label3.TabIndex = 73;
            this.label3.Text = "Documento";
            // 
            // TXTDocumento
            // 
            this.TXTDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDocumento.Location = new System.Drawing.Point(231, 85);
            this.TXTDocumento.MaxLength = 60;
            this.TXTDocumento.Name = "TXTDocumento";
            this.TXTDocumento.Size = new System.Drawing.Size(409, 26);
            this.TXTDocumento.TabIndex = 72;
            this.TXTDocumento.TextChanged += new System.EventHandler(this.TXTDocumento_TextChanged);
            // 
            // DTGWFLocalizaParticipante
            // 
            this.DTGWFLocalizaParticipante.AllowUserToAddRows = false;
            this.DTGWFLocalizaParticipante.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGWFLocalizaParticipante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DTGWFLocalizaParticipante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGWFLocalizaParticipante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnCdProduto,
            this.DTGColumnNome,
            this.DTGColumnDocumento,
            this.DTGColumnInformacao,
            this.DTGColumnTipoEntidade});
            this.DTGWFLocalizaParticipante.Location = new System.Drawing.Point(12, 183);
            this.DTGWFLocalizaParticipante.Name = "DTGWFLocalizaParticipante";
            this.DTGWFLocalizaParticipante.ReadOnly = true;
            this.DTGWFLocalizaParticipante.Size = new System.Drawing.Size(779, 214);
            this.DTGWFLocalizaParticipante.TabIndex = 74;
            // 
            // CmdCancela
            // 
            this.CmdCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(716, 403);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(75, 33);
            this.CmdCancela.TabIndex = 88;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            this.CmdCancela.Click += new System.EventHandler(this.CmdCancela_Click);
            // 
            // CMDSeleciona
            // 
            this.CMDSeleciona.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CMDSeleciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDSeleciona.Location = new System.Drawing.Point(612, 403);
            this.CMDSeleciona.Name = "CMDSeleciona";
            this.CMDSeleciona.Size = new System.Drawing.Size(98, 33);
            this.CMDSeleciona.TabIndex = 87;
            this.CMDSeleciona.Text = "Selecionar";
            this.CMDSeleciona.UseVisualStyleBackColor = true;
            this.CMDSeleciona.Click += new System.EventHandler(this.CMDSeleciona_Click);
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLocalizar.ForeColor = System.Drawing.Color.Black;
            this.CMDLocalizar.Location = new System.Drawing.Point(691, 48);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(100, 32);
            this.CMDLocalizar.TabIndex = 89;
            this.CMDLocalizar.Text = "&Localizar";
            this.CMDLocalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 117);
            this.label5.MinimumSize = new System.Drawing.Size(200, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 22);
            this.label5.TabIndex = 91;
            this.label5.Text = "Tipo Entidade";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(231, 122);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(233, 24);
            this.checkBox1.TabIndex = 92;
            this.checkBox1.Text = "Apenas Entidade Jurídica";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "CdParticipante";
            this.DTGColumnCdProduto.HeaderText = "Participante";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 90;
            // 
            // DTGColumnNome
            // 
            this.DTGColumnNome.DataPropertyName = "Nome";
            this.DTGColumnNome.HeaderText = "Descrição";
            this.DTGColumnNome.Name = "DTGColumnNome";
            this.DTGColumnNome.ReadOnly = true;
            this.DTGColumnNome.Width = 300;
            // 
            // DTGColumnDocumento
            // 
            this.DTGColumnDocumento.DataPropertyName = "Documento";
            this.DTGColumnDocumento.HeaderText = "Tipo Documento";
            this.DTGColumnDocumento.Name = "DTGColumnDocumento";
            this.DTGColumnDocumento.ReadOnly = true;
            // 
            // DTGColumnInformacao
            // 
            this.DTGColumnInformacao.DataPropertyName = "Informacao";
            this.DTGColumnInformacao.HeaderText = "Número";
            this.DTGColumnInformacao.Name = "DTGColumnInformacao";
            this.DTGColumnInformacao.ReadOnly = true;
            // 
            // DTGColumnTipoEntidade
            // 
            this.DTGColumnTipoEntidade.DataPropertyName = "TipoEntidade";
            this.DTGColumnTipoEntidade.HeaderText = "Tipo Entidade";
            this.DTGColumnTipoEntidade.Name = "DTGColumnTipoEntidade";
            this.DTGColumnTipoEntidade.ReadOnly = true;
            // 
            // FrmLocalizaParticipante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 448);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMDLocalizar);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.CMDSeleciona);
            this.Controls.Add(this.DTGWFLocalizaParticipante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalizaParticipante";
            this.Text = "FrmLocalizaParticipante";
            ((System.ComponentModel.ISupportInitialize)(this.DTGWFLocalizaParticipante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTDocumento;
        private System.Windows.Forms.DataGridView DTGWFLocalizaParticipante;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button CMDSeleciona;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnInformacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnTipoEntidade;
    }
}