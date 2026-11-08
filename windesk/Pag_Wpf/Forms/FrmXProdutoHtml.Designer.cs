namespace Pag_Wpf.Forms
{
    partial class FrmXProdutoHtml
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmdProcessarArquivos = new System.Windows.Forms.Button();
            this.cmdArquivoProdutos = new System.Windows.Forms.Button();
            this.txtArquivoProdutos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgProduto = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtEmbalagem_Tamanho = new System.Windows.Forms.TextBox();
            this.txtEmbalagem_INI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescricao_Tamanho = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescricao_INI = new System.Windows.Forms.TextBox();
            this.txtCodigoBlueSoftUnitario_Tamanho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoBlueSoftUnitario_INI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoBlueSoft_Tamanho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoBlueSoft_INI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdAplicar = new System.Windows.Forms.Button();
            this.txtCDBARRA_FIM = new System.Windows.Forms.TextBox();
            this.txtCDBARRA_INI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFatorEstoque_FIM = new System.Windows.Forms.TextBox();
            this.txtFatorEstoque_INI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 203;
            this.label6.Text = "Processar dados";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdProcessarArquivos
            // 
            this.cmdProcessarArquivos.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdProcessarArquivos.Location = new System.Drawing.Point(551, 22);
            this.cmdProcessarArquivos.Name = "cmdProcessarArquivos";
            this.cmdProcessarArquivos.Size = new System.Drawing.Size(39, 23);
            this.cmdProcessarArquivos.TabIndex = 202;
            this.cmdProcessarArquivos.UseVisualStyleBackColor = true;
            this.cmdProcessarArquivos.Click += new System.EventHandler(this.cmdProcessarArquivos_Click);
            // 
            // cmdArquivoProdutos
            // 
            this.cmdArquivoProdutos.Location = new System.Drawing.Point(12, 25);
            this.cmdArquivoProdutos.Name = "cmdArquivoProdutos";
            this.cmdArquivoProdutos.Size = new System.Drawing.Size(26, 23);
            this.cmdArquivoProdutos.TabIndex = 201;
            this.cmdArquivoProdutos.Text = "...";
            this.cmdArquivoProdutos.UseVisualStyleBackColor = true;
            this.cmdArquivoProdutos.Click += new System.EventHandler(this.cmdArquivoProdutos_Click);
            // 
            // txtArquivoProdutos
            // 
            this.txtArquivoProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArquivoProdutos.Enabled = false;
            this.txtArquivoProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivoProdutos.Location = new System.Drawing.Point(44, 25);
            this.txtArquivoProdutos.Name = "txtArquivoProdutos";
            this.txtArquivoProdutos.Size = new System.Drawing.Size(349, 20);
            this.txtArquivoProdutos.TabIndex = 199;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Arquivo Texto de Produtos - Validação Código Unitário";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(493, 398);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 204;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 341);
            this.tabControl1.TabIndex = 222;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.txtTotal);
            this.tabPage1.Controls.Add(this.dtgProduto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(573, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listagem";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgProduto
            // 
            this.dtgProduto.AllowUserToAddRows = false;
            this.dtgProduto.AllowUserToDeleteRows = false;
            this.dtgProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProduto.Location = new System.Drawing.Point(8, 15);
            this.dtgProduto.Name = "dtgProduto";
            this.dtgProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProduto.Size = new System.Drawing.Size(559, 252);
            this.dtgProduto.TabIndex = 162;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtFatorEstoque_FIM);
            this.tabPage2.Controls.Add(this.txtFatorEstoque_INI);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtCDBARRA_FIM);
            this.tabPage2.Controls.Add(this.txtCDBARRA_INI);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtEmbalagem_Tamanho);
            this.tabPage2.Controls.Add(this.txtEmbalagem_INI);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtDescricao_Tamanho);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtDescricao_INI);
            this.tabPage2.Controls.Add(this.txtCodigoBlueSoftUnitario_Tamanho);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtCodigoBlueSoftUnitario_INI);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtCodigoBlueSoft_Tamanho);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtCodigoBlueSoft_INI);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(573, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuração";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtEmbalagem_Tamanho
            // 
            this.txtEmbalagem_Tamanho.BackColor = System.Drawing.Color.White;
            this.txtEmbalagem_Tamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmbalagem_Tamanho.Location = new System.Drawing.Point(257, 102);
            this.txtEmbalagem_Tamanho.Name = "txtEmbalagem_Tamanho";
            this.txtEmbalagem_Tamanho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmbalagem_Tamanho.Size = new System.Drawing.Size(72, 20);
            this.txtEmbalagem_Tamanho.TabIndex = 252;
            this.txtEmbalagem_Tamanho.Text = "2";
            this.txtEmbalagem_Tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmbalagem_INI
            // 
            this.txtEmbalagem_INI.BackColor = System.Drawing.Color.White;
            this.txtEmbalagem_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmbalagem_INI.Location = new System.Drawing.Point(179, 102);
            this.txtEmbalagem_INI.Name = "txtEmbalagem_INI";
            this.txtEmbalagem_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmbalagem_INI.Size = new System.Drawing.Size(72, 20);
            this.txtEmbalagem_INI.TabIndex = 251;
            this.txtEmbalagem_INI.Text = "95";
            this.txtEmbalagem_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 250;
            this.label8.Text = "Embalagem";
            // 
            // txtDescricao_Tamanho
            // 
            this.txtDescricao_Tamanho.BackColor = System.Drawing.Color.White;
            this.txtDescricao_Tamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao_Tamanho.Location = new System.Drawing.Point(257, 76);
            this.txtDescricao_Tamanho.Name = "txtDescricao_Tamanho";
            this.txtDescricao_Tamanho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescricao_Tamanho.Size = new System.Drawing.Size(72, 20);
            this.txtDescricao_Tamanho.TabIndex = 249;
            this.txtDescricao_Tamanho.Text = "60";
            this.txtDescricao_Tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 248;
            this.label7.Text = "Código BlueSoft Unit.";
            // 
            // txtDescricao_INI
            // 
            this.txtDescricao_INI.BackColor = System.Drawing.Color.White;
            this.txtDescricao_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao_INI.Location = new System.Drawing.Point(179, 76);
            this.txtDescricao_INI.Name = "txtDescricao_INI";
            this.txtDescricao_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescricao_INI.Size = new System.Drawing.Size(72, 20);
            this.txtDescricao_INI.TabIndex = 247;
            this.txtDescricao_INI.Text = "30";
            this.txtDescricao_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodigoBlueSoftUnitario_Tamanho
            // 
            this.txtCodigoBlueSoftUnitario_Tamanho.BackColor = System.Drawing.Color.White;
            this.txtCodigoBlueSoftUnitario_Tamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBlueSoftUnitario_Tamanho.Location = new System.Drawing.Point(257, 24);
            this.txtCodigoBlueSoftUnitario_Tamanho.Name = "txtCodigoBlueSoftUnitario_Tamanho";
            this.txtCodigoBlueSoftUnitario_Tamanho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigoBlueSoftUnitario_Tamanho.Size = new System.Drawing.Size(72, 20);
            this.txtCodigoBlueSoftUnitario_Tamanho.TabIndex = 246;
            this.txtCodigoBlueSoftUnitario_Tamanho.Text = "15";
            this.txtCodigoBlueSoftUnitario_Tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 245;
            this.label5.Text = "Descrição";
            // 
            // txtCodigoBlueSoftUnitario_INI
            // 
            this.txtCodigoBlueSoftUnitario_INI.BackColor = System.Drawing.Color.White;
            this.txtCodigoBlueSoftUnitario_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBlueSoftUnitario_INI.Location = new System.Drawing.Point(179, 24);
            this.txtCodigoBlueSoftUnitario_INI.Name = "txtCodigoBlueSoftUnitario_INI";
            this.txtCodigoBlueSoftUnitario_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigoBlueSoftUnitario_INI.Size = new System.Drawing.Size(72, 20);
            this.txtCodigoBlueSoftUnitario_INI.TabIndex = 244;
            this.txtCodigoBlueSoftUnitario_INI.Text = "0";
            this.txtCodigoBlueSoftUnitario_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 243;
            this.label3.Text = "Tamanho";
            // 
            // txtCodigoBlueSoft_Tamanho
            // 
            this.txtCodigoBlueSoft_Tamanho.BackColor = System.Drawing.Color.White;
            this.txtCodigoBlueSoft_Tamanho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBlueSoft_Tamanho.Location = new System.Drawing.Point(257, 50);
            this.txtCodigoBlueSoft_Tamanho.Name = "txtCodigoBlueSoft_Tamanho";
            this.txtCodigoBlueSoft_Tamanho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigoBlueSoft_Tamanho.Size = new System.Drawing.Size(72, 20);
            this.txtCodigoBlueSoft_Tamanho.TabIndex = 242;
            this.txtCodigoBlueSoft_Tamanho.Text = "15";
            this.txtCodigoBlueSoft_Tamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 241;
            this.label2.Text = "Posição Inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 240;
            this.label1.Text = "Código BlueSoft ";
            // 
            // txtCodigoBlueSoft_INI
            // 
            this.txtCodigoBlueSoft_INI.BackColor = System.Drawing.Color.White;
            this.txtCodigoBlueSoft_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBlueSoft_INI.Location = new System.Drawing.Point(179, 50);
            this.txtCodigoBlueSoft_INI.Name = "txtCodigoBlueSoft_INI";
            this.txtCodigoBlueSoft_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigoBlueSoft_INI.Size = new System.Drawing.Size(72, 20);
            this.txtCodigoBlueSoft_INI.TabIndex = 239;
            this.txtCodigoBlueSoft_INI.Text = "15";
            this.txtCodigoBlueSoft_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 224;
            this.label10.Text = "Aplicar";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdAplicar
            // 
            this.cmdAplicar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdAplicar.Location = new System.Drawing.Point(448, 398);
            this.cmdAplicar.Name = "cmdAplicar";
            this.cmdAplicar.Size = new System.Drawing.Size(39, 23);
            this.cmdAplicar.TabIndex = 223;
            this.cmdAplicar.UseVisualStyleBackColor = true;
            this.cmdAplicar.Click += new System.EventHandler(this.cmdAplicar_Click);
            // 
            // txtCDBARRA_FIM
            // 
            this.txtCDBARRA_FIM.BackColor = System.Drawing.Color.White;
            this.txtCDBARRA_FIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCDBARRA_FIM.Location = new System.Drawing.Point(257, 127);
            this.txtCDBARRA_FIM.Name = "txtCDBARRA_FIM";
            this.txtCDBARRA_FIM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCDBARRA_FIM.Size = new System.Drawing.Size(72, 20);
            this.txtCDBARRA_FIM.TabIndex = 255;
            this.txtCDBARRA_FIM.Text = "25";
            this.txtCDBARRA_FIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCDBARRA_INI
            // 
            this.txtCDBARRA_INI.BackColor = System.Drawing.Color.White;
            this.txtCDBARRA_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCDBARRA_INI.Location = new System.Drawing.Point(179, 127);
            this.txtCDBARRA_INI.Name = "txtCDBARRA_INI";
            this.txtCDBARRA_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCDBARRA_INI.Size = new System.Drawing.Size(72, 20);
            this.txtCDBARRA_INI.TabIndex = 254;
            this.txtCDBARRA_INI.Text = "99";
            this.txtCDBARRA_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 253;
            this.label9.Text = "Código de Barra";
            // 
            // txtFatorEstoque_FIM
            // 
            this.txtFatorEstoque_FIM.BackColor = System.Drawing.Color.White;
            this.txtFatorEstoque_FIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorEstoque_FIM.Location = new System.Drawing.Point(257, 153);
            this.txtFatorEstoque_FIM.Name = "txtFatorEstoque_FIM";
            this.txtFatorEstoque_FIM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFatorEstoque_FIM.Size = new System.Drawing.Size(72, 20);
            this.txtFatorEstoque_FIM.TabIndex = 258;
            this.txtFatorEstoque_FIM.Text = "15";
            this.txtFatorEstoque_FIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFatorEstoque_INI
            // 
            this.txtFatorEstoque_INI.BackColor = System.Drawing.Color.White;
            this.txtFatorEstoque_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatorEstoque_INI.Location = new System.Drawing.Point(179, 153);
            this.txtFatorEstoque_INI.Name = "txtFatorEstoque_INI";
            this.txtFatorEstoque_INI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFatorEstoque_INI.Size = new System.Drawing.Size(72, 20);
            this.txtFatorEstoque_INI.TabIndex = 257;
            this.txtFatorEstoque_INI.Text = "139";
            this.txtFatorEstoque_INI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 256;
            this.label11.Text = "Fator";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(460, 273);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(107, 20);
            this.txtTotal.TabIndex = 225;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 226;
            this.label12.Text = "Número de Linhas";
            // 
            // FrmXProdutoHtml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 433);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdAplicar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdProcessarArquivos);
            this.Controls.Add(this.cmdArquivoProdutos);
            this.Controls.Add(this.txtArquivoProdutos);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXProdutoHtml";
            this.Text = "Produto - Importação ERP BlueSoft ON";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdProcessarArquivos;
        private System.Windows.Forms.Button cmdArquivoProdutos;
        private System.Windows.Forms.TextBox txtArquivoProdutos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtgProduto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtEmbalagem_Tamanho;
        private System.Windows.Forms.TextBox txtEmbalagem_INI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescricao_Tamanho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricao_INI;
        private System.Windows.Forms.TextBox txtCodigoBlueSoftUnitario_Tamanho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoBlueSoftUnitario_INI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoBlueSoft_Tamanho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoBlueSoft_INI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdAplicar;
        private System.Windows.Forms.TextBox txtFatorEstoque_FIM;
        private System.Windows.Forms.TextBox txtFatorEstoque_INI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCDBARRA_FIM;
        private System.Windows.Forms.TextBox txtCDBARRA_INI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotal;
    }
}