namespace Pag_Wpf.Operacionais.Analise
{
    partial class frmInvestimentosAdicionar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgContratos = new System.Windows.Forms.DataGridView();
            this.SeqContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DTPDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DTPDataFinal = new System.Windows.Forms.DateTimePicker();
            this.TABCONTROLTipoContrato = new System.Windows.Forms.TabControl();
            this.TABCONTROLItem = new System.Windows.Forms.TabPage();
            this.TABCONTROLPedido = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.CMBFabricante = new System.Windows.Forms.ComboBox();
            this.TXTCodigosProdutos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Descriçao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).BeginInit();
            this.TABCONTROLTipoContrato.SuspendLayout();
            this.TABCONTROLItem.SuspendLayout();
            this.TABCONTROLPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.TABCONTROLTipoContrato);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.DTPDataFinal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.DTPDataInicial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 176);
            this.panel1.TabIndex = 76;
            // 
            // dtgContratos
            // 
            this.dtgContratos.AllowDrop = true;
            this.dtgContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqContrato,
            this.Descricao});
            this.dtgContratos.Location = new System.Drawing.Point(12, 194);
            this.dtgContratos.Name = "dtgContratos";
            this.dtgContratos.Size = new System.Drawing.Size(779, 223);
            this.dtgContratos.TabIndex = 77;
            // 
            // SeqContrato
            // 
            this.SeqContrato.DataPropertyName = "SeqContrato";
            this.SeqContrato.HeaderText = "Seq";
            this.SeqContrato.Name = "SeqContrato";
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "DESCRICAO_CONTRATO";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(716, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 78;
            this.button2.Text = "Localiza";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Operaço (Canal de Venda)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 21);
            this.comboBox1.TabIndex = 83;
            // 
            // DTPDataInicial
            // 
            this.DTPDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataInicial.Location = new System.Drawing.Point(500, 19);
            this.DTPDataInicial.Name = "DTPDataInicial";
            this.DTPDataInicial.Size = new System.Drawing.Size(77, 20);
            this.DTPDataInicial.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Data Inicial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(583, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "Data Final";
            // 
            // DTPDataFinal
            // 
            this.DTPDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataFinal.Location = new System.Drawing.Point(583, 19);
            this.DTPDataFinal.Name = "DTPDataFinal";
            this.DTPDataFinal.Size = new System.Drawing.Size(77, 20);
            this.DTPDataFinal.TabIndex = 87;
            // 
            // TABCONTROLTipoContrato
            // 
            this.TABCONTROLTipoContrato.Controls.Add(this.TABCONTROLItem);
            this.TABCONTROLTipoContrato.Controls.Add(this.TABCONTROLPedido);
            this.TABCONTROLTipoContrato.Location = new System.Drawing.Point(15, 44);
            this.TABCONTROLTipoContrato.Name = "TABCONTROLTipoContrato";
            this.TABCONTROLTipoContrato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TABCONTROLTipoContrato.SelectedIndex = 0;
            this.TABCONTROLTipoContrato.Size = new System.Drawing.Size(649, 116);
            this.TABCONTROLTipoContrato.TabIndex = 89;
            // 
            // TABCONTROLItem
            // 
            this.TABCONTROLItem.Controls.Add(this.textBox2);
            this.TABCONTROLItem.Controls.Add(this.Descriçao);
            this.TABCONTROLItem.Controls.Add(this.CMDLocalizar);
            this.TABCONTROLItem.Controls.Add(this.TXTCodigosProdutos);
            this.TABCONTROLItem.Controls.Add(this.label1);
            this.TABCONTROLItem.Controls.Add(this.label4);
            this.TABCONTROLItem.Controls.Add(this.CMBFabricante);
            this.TABCONTROLItem.Location = new System.Drawing.Point(4, 22);
            this.TABCONTROLItem.Name = "TABCONTROLItem";
            this.TABCONTROLItem.Padding = new System.Windows.Forms.Padding(3);
            this.TABCONTROLItem.Size = new System.Drawing.Size(641, 90);
            this.TABCONTROLItem.TabIndex = 0;
            this.TABCONTROLItem.Text = "Investimento em Itens";
            this.TABCONTROLItem.UseVisualStyleBackColor = true;
            // 
            // TABCONTROLPedido
            // 
            this.TABCONTROLPedido.Controls.Add(this.label2);
            this.TABCONTROLPedido.Controls.Add(this.textBox1);
            this.TABCONTROLPedido.Location = new System.Drawing.Point(4, 22);
            this.TABCONTROLPedido.Name = "TABCONTROLPedido";
            this.TABCONTROLPedido.Padding = new System.Windows.Forms.Padding(3);
            this.TABCONTROLPedido.Size = new System.Drawing.Size(641, 90);
            this.TABCONTROLPedido.TabIndex = 1;
            this.TABCONTROLPedido.Text = "Investimento em Pedido de Venda Distribuiçao";
            this.TABCONTROLPedido.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fabricante / Fornecedor";
            // 
            // CMBFabricante
            // 
            this.CMBFabricante.FormattingEnabled = true;
            this.CMBFabricante.Location = new System.Drawing.Point(6, 19);
            this.CMBFabricante.Name = "CMBFabricante";
            this.CMBFabricante.Size = new System.Drawing.Size(300, 21);
            this.CMBFabricante.TabIndex = 8;
            // 
            // TXTCodigosProdutos
            // 
            this.TXTCodigosProdutos.Location = new System.Drawing.Point(329, 19);
            this.TXTCodigosProdutos.Name = "TXTCodigosProdutos";
            this.TXTCodigosProdutos.Size = new System.Drawing.Size(158, 20);
            this.TXTCodigosProdutos.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Códigos";
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Location = new System.Drawing.Point(558, 17);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(75, 23);
            this.CMDLocalizar.TabIndex = 83;
            this.CMDLocalizar.Text = "Localiza";
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(481, 20);
            this.textBox2.TabIndex = 85;
            // 
            // Descriçao
            // 
            this.Descriçao.AutoSize = true;
            this.Descriçao.Location = new System.Drawing.Point(3, 48);
            this.Descriçao.Name = "Descriçao";
            this.Descriçao.Size = new System.Drawing.Size(45, 13);
            this.Descriçao.TabIndex = 84;
            this.Descriçao.Text = "Códigos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "Tipo de Lançamento";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(164, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(319, 21);
            this.comboBox2.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "N. Pedido de Vend (Distribuicao)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 83;
            // 
            // frmInvestimentosAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtgContratos);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvestimentosAdicionar";
            this.Text = "Investimentos - Adicionar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContratos)).EndInit();
            this.TABCONTROLTipoContrato.ResumeLayout(false);
            this.TABCONTROLItem.ResumeLayout(false);
            this.TABCONTROLItem.PerformLayout();
            this.TABCONTROLPedido.ResumeLayout(false);
            this.TABCONTROLPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl TABCONTROLTipoContrato;
        private System.Windows.Forms.TabPage TABCONTROLItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Descriçao;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.TextBox TXTCodigosProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CMBFabricante;
        private System.Windows.Forms.TabPage TABCONTROLPedido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPDataFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DTPDataInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}