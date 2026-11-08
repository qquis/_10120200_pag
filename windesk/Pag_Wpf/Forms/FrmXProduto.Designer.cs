namespace Pag_Wpf.Forms
{
    partial class FrmXProduto
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
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.cmddetalhe = new System.Windows.Forms.Button();
            this.dtgProduto = new System.Windows.Forms.DataGridView();
            this.CdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CdProdutoBluesoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdeProdutosAssociados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusProduto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CMBFabricante = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CMBFornecedorTroca = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CHKInativo = new System.Windows.Forms.CheckBox();
            this.CHKAtivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoBarraAssociado = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.TXTCdProdutoList = new System.Windows.Forms.TextBox();
            this.txtCdProdutoBlueSoftList = new System.Windows.Forms.TextBox();
            this.txtCdProdutoTgtList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdProcessamentoGeral_Produto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtg_processamento_geral_produto = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdpost_to_sql = new System.Windows.Forms.Button();
            this.cmdred_to_post = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dtg_Postgre_sqlserver = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.dtg_RedShift_Postgre = new System.Windows.Forms.DataGridView();
            this.DtgIntegracaoCheckBoxAtualizar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtg_col_sis_nucleo_cd_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_col_sis_nucleo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_col_sis_nucleo_prc_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.cmdAtualizarBase_ZanthusTributacao = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.LBL_INFO_PROGRESS = new System.Windows.Forms.Label();
            this.PrgPagAtualizaProduto = new System.Windows.Forms.ProgressBar();
            this.chkAtualizacaoParcial = new System.Windows.Forms.CheckBox();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_processamento_geral_produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Postgre_sqlserver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_RedShift_Postgre)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.cmddetalhe);
            this.TabPage1.Controls.Add(this.dtgProduto);
            this.TabPage1.Controls.Add(this.label5);
            this.TabPage1.Controls.Add(this.cmdBuscar);
            this.TabPage1.Controls.Add(this.label8);
            this.TabPage1.Controls.Add(this.CMBFabricante);
            this.TabPage1.Controls.Add(this.label7);
            this.TabPage1.Controls.Add(this.CMBFornecedorTroca);
            this.TabPage1.Controls.Add(this.groupBox1);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.txtCodigoBarraAssociado);
            this.TabPage1.Controls.Add(this.txtDescricao);
            this.TabPage1.Controls.Add(this.TXTCdProdutoList);
            this.TabPage1.Controls.Add(this.txtCdProdutoBlueSoftList);
            this.TabPage1.Controls.Add(this.txtCdProdutoTgtList);
            this.TabPage1.Controls.Add(this.label4);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.label2);
            this.TabPage1.Controls.Add(this.label1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(823, 458);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Produto";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // cmddetalhe
            // 
            this.cmddetalhe.Location = new System.Drawing.Point(712, 424);
            this.cmddetalhe.Name = "cmddetalhe";
            this.cmddetalhe.Size = new System.Drawing.Size(100, 23);
            this.cmddetalhe.TabIndex = 181;
            this.cmddetalhe.Text = "Detalhe";
            this.cmddetalhe.UseVisualStyleBackColor = true;
            this.cmddetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // dtgProduto
            // 
            this.dtgProduto.AllowUserToAddRows = false;
            this.dtgProduto.AllowUserToDeleteRows = false;
            this.dtgProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CdProduto,
            this.CdProdutoBluesoft,
            this.Descricao,
            this.EmbalagemEstoque,
            this.QtdeProdutosAssociados,
            this.DescricaoFabricante,
            this.StatusProduto});
            this.dtgProduto.Location = new System.Drawing.Point(14, 100);
            this.dtgProduto.Name = "dtgProduto";
            this.dtgProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProduto.Size = new System.Drawing.Size(798, 318);
            this.dtgProduto.TabIndex = 178;
            // 
            // CdProduto
            // 
            this.CdProduto.DataPropertyName = "TbProduto_CdProduto";
            this.CdProduto.HeaderText = "Cód Pag";
            this.CdProduto.Name = "CdProduto";
            this.CdProduto.ReadOnly = true;
            this.CdProduto.Width = 75;
            // 
            // CdProdutoBluesoft
            // 
            this.CdProdutoBluesoft.DataPropertyName = "TbProduto_CdProdutoBluesoft";
            this.CdProdutoBluesoft.HeaderText = "Cod Blue";
            this.CdProdutoBluesoft.Name = "CdProdutoBluesoft";
            this.CdProdutoBluesoft.Width = 75;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "TbProduto_Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 250;
            // 
            // EmbalagemEstoque
            // 
            this.EmbalagemEstoque.DataPropertyName = "TbProduto_EmbalagemEstoque";
            this.EmbalagemEstoque.HeaderText = "Emb";
            this.EmbalagemEstoque.Name = "EmbalagemEstoque";
            this.EmbalagemEstoque.ReadOnly = true;
            this.EmbalagemEstoque.Width = 30;
            // 
            // QtdeProdutosAssociados
            // 
            this.QtdeProdutosAssociados.DataPropertyName = "XCount_QtdeProdutosAssociados";
            this.QtdeProdutosAssociados.HeaderText = "QPA";
            this.QtdeProdutosAssociados.Name = "QtdeProdutosAssociados";
            this.QtdeProdutosAssociados.ReadOnly = true;
            this.QtdeProdutosAssociados.Width = 45;
            // 
            // DescricaoFabricante
            // 
            this.DescricaoFabricante.DataPropertyName = "TbFabricante_Descricao";
            this.DescricaoFabricante.HeaderText = "Fabricante";
            this.DescricaoFabricante.Name = "DescricaoFabricante";
            this.DescricaoFabricante.ReadOnly = true;
            this.DescricaoFabricante.Width = 150;
            // 
            // StatusProduto
            // 
            this.StatusProduto.DataPropertyName = "TbProduto_StatusProduto";
            this.StatusProduto.HeaderText = "Status";
            this.StatusProduto.Name = "StatusProduto";
            this.StatusProduto.ReadOnly = true;
            this.StatusProduto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusProduto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StatusProduto.Width = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(727, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 177;
            this.label5.Text = "Buscar";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(773, 8);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 176;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(526, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 174;
            this.label8.Text = "Fabricante";
            // 
            // CMBFabricante
            // 
            this.CMBFabricante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CMBFabricante.Enabled = false;
            this.CMBFabricante.FormattingEnabled = true;
            this.CMBFabricante.Location = new System.Drawing.Point(446, 28);
            this.CMBFabricante.Name = "CMBFabricante";
            this.CMBFabricante.Size = new System.Drawing.Size(137, 21);
            this.CMBFabricante.TabIndex = 173;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 172;
            this.label7.Text = "Fornecedor de Troca";
            // 
            // CMBFornecedorTroca
            // 
            this.CMBFornecedorTroca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CMBFornecedorTroca.Enabled = false;
            this.CMBFornecedorTroca.FormattingEnabled = true;
            this.CMBFornecedorTroca.Location = new System.Drawing.Point(293, 28);
            this.CMBFornecedorTroca.Name = "CMBFornecedorTroca";
            this.CMBFornecedorTroca.Size = new System.Drawing.Size(147, 21);
            this.CMBFornecedorTroca.TabIndex = 171;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHKInativo);
            this.groupBox1.Controls.Add(this.CHKAtivo);
            this.groupBox1.Location = new System.Drawing.Point(458, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 40);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            // 
            // CHKInativo
            // 
            this.CHKInativo.AutoSize = true;
            this.CHKInativo.Location = new System.Drawing.Point(62, 17);
            this.CHKInativo.Name = "CHKInativo";
            this.CHKInativo.Size = new System.Drawing.Size(58, 17);
            this.CHKInativo.TabIndex = 1;
            this.CHKInativo.Text = "Inativo";
            this.CHKInativo.UseVisualStyleBackColor = true;
            // 
            // CHKAtivo
            // 
            this.CHKAtivo.AutoSize = true;
            this.CHKAtivo.Location = new System.Drawing.Point(6, 17);
            this.CHKAtivo.Name = "CHKAtivo";
            this.CHKAtivo.Size = new System.Drawing.Size(50, 17);
            this.CHKAtivo.TabIndex = 0;
            this.CHKAtivo.Text = "Ativo";
            this.CHKAtivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 169;
            this.label6.Text = "Código de Barra Associado";
            // 
            // txtCodigoBarraAssociado
            // 
            this.txtCodigoBarraAssociado.Location = new System.Drawing.Point(293, 74);
            this.txtCodigoBarraAssociado.Name = "txtCodigoBarraAssociado";
            this.txtCodigoBarraAssociado.Size = new System.Drawing.Size(147, 20);
            this.txtCodigoBarraAssociado.TabIndex = 168;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(14, 74);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(273, 20);
            this.txtDescricao.TabIndex = 164;
            // 
            // TXTCdProdutoList
            // 
            this.TXTCdProdutoList.Location = new System.Drawing.Point(14, 29);
            this.TXTCdProdutoList.Name = "TXTCdProdutoList";
            this.TXTCdProdutoList.Size = new System.Drawing.Size(82, 20);
            this.TXTCdProdutoList.TabIndex = 162;
            // 
            // txtCdProdutoBlueSoftList
            // 
            this.txtCdProdutoBlueSoftList.Location = new System.Drawing.Point(195, 28);
            this.txtCdProdutoBlueSoftList.Name = "txtCdProdutoBlueSoftList";
            this.txtCdProdutoBlueSoftList.Size = new System.Drawing.Size(92, 20);
            this.txtCdProdutoBlueSoftList.TabIndex = 160;
            // 
            // txtCdProdutoTgtList
            // 
            this.txtCdProdutoTgtList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCdProdutoTgtList.Enabled = false;
            this.txtCdProdutoTgtList.Location = new System.Drawing.Point(102, 28);
            this.txtCdProdutoTgtList.Name = "txtCdProdutoTgtList";
            this.txtCdProdutoTgtList.Size = new System.Drawing.Size(87, 20);
            this.txtCdProdutoTgtList.TabIndex = 158;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 165;
            this.label4.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 163;
            this.label3.Text = "Códigos Pag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Códigos BlueSoft";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "Códigos Target";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 484);
            this.tabControl1.TabIndex = 159;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkAtualizacaoParcial);
            this.tabPage2.Controls.Add(this.cmdProcessamentoGeral_Produto);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dtg_processamento_geral_produto);
            this.tabPage2.Controls.Add(this.cmdpost_to_sql);
            this.tabPage2.Controls.Add(this.cmdred_to_post);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.dtg_Postgre_sqlserver);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.dtg_RedShift_Postgre);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.cmdAtualizarBase_ZanthusTributacao);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cmdAtualizarBase);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(823, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Atualizações";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdProcessamentoGeral_Produto
            // 
            this.cmdProcessamentoGeral_Produto.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdProcessamentoGeral_Produto.Location = new System.Drawing.Point(332, 281);
            this.cmdProcessamentoGeral_Produto.Name = "cmdProcessamentoGeral_Produto";
            this.cmdProcessamentoGeral_Produto.Size = new System.Drawing.Size(39, 23);
            this.cmdProcessamentoGeral_Produto.TabIndex = 216;
            this.cmdProcessamentoGeral_Produto.UseVisualStyleBackColor = true;
            this.cmdProcessamentoGeral_Produto.Click += new System.EventHandler(this.cmdProcessamentoGeral_Produto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 13);
            this.label10.TabIndex = 215;
            this.label10.Text = "Processamento Geral de Produto";
            // 
            // dtg_processamento_geral_produto
            // 
            this.dtg_processamento_geral_produto.AllowUserToAddRows = false;
            this.dtg_processamento_geral_produto.AllowUserToDeleteRows = false;
            this.dtg_processamento_geral_produto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_processamento_geral_produto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dtg_processamento_geral_produto.Location = new System.Drawing.Point(22, 307);
            this.dtg_processamento_geral_produto.Name = "dtg_processamento_geral_produto";
            this.dtg_processamento_geral_produto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_processamento_geral_produto.Size = new System.Drawing.Size(349, 125);
            this.dtg_processamento_geral_produto.TabIndex = 214;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Upd";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sis_nucleo_cd_fk";
            this.dataGridViewTextBoxColumn4.HeaderText = "Núcleo Cd";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "sis_nucleo_descricao";
            this.dataGridViewTextBoxColumn5.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 210;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "sis_nucleo_prc_cd";
            this.dataGridViewTextBoxColumn6.HeaderText = "Procedimento CD";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 45;
            // 
            // cmdpost_to_sql
            // 
            this.cmdpost_to_sql.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdpost_to_sql.Location = new System.Drawing.Point(696, 53);
            this.cmdpost_to_sql.Name = "cmdpost_to_sql";
            this.cmdpost_to_sql.Size = new System.Drawing.Size(39, 23);
            this.cmdpost_to_sql.TabIndex = 213;
            this.cmdpost_to_sql.UseVisualStyleBackColor = true;
            this.cmdpost_to_sql.Click += new System.EventHandler(this.cmdpost_to_sql_Click);
            // 
            // cmdred_to_post
            // 
            this.cmdred_to_post.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdred_to_post.Location = new System.Drawing.Point(332, 55);
            this.cmdred_to_post.Name = "cmdred_to_post";
            this.cmdred_to_post.Size = new System.Drawing.Size(39, 23);
            this.cmdred_to_post.TabIndex = 212;
            this.cmdred_to_post.UseVisualStyleBackColor = true;
            this.cmdred_to_post.Click += new System.EventHandler(this.cmdred_to_post_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(383, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(209, 13);
            this.label16.TabIndex = 211;
            this.label16.Text = "Atualizações Produto PostGre -> SqlServer";
            // 
            // dtg_Postgre_sqlserver
            // 
            this.dtg_Postgre_sqlserver.AllowUserToAddRows = false;
            this.dtg_Postgre_sqlserver.AllowUserToDeleteRows = false;
            this.dtg_Postgre_sqlserver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Postgre_sqlserver.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dtg_Postgre_sqlserver.Location = new System.Drawing.Point(386, 87);
            this.dtg_Postgre_sqlserver.Name = "dtg_Postgre_sqlserver";
            this.dtg_Postgre_sqlserver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_Postgre_sqlserver.Size = new System.Drawing.Size(349, 184);
            this.dtg_Postgre_sqlserver.TabIndex = 210;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Upd";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sis_nucleo_cd_fk";
            this.dataGridViewTextBoxColumn1.HeaderText = "Núcleo Cd";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sis_nucleo_descricao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 210;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sis_nucleo_prc_cd";
            this.dataGridViewTextBoxColumn3.HeaderText = "Procedimento CD";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(198, 13);
            this.label15.TabIndex = 209;
            this.label15.Text = "Atualizações Produto RedShift - PostGre";
            // 
            // dtg_RedShift_Postgre
            // 
            this.dtg_RedShift_Postgre.AllowUserToAddRows = false;
            this.dtg_RedShift_Postgre.AllowUserToDeleteRows = false;
            this.dtg_RedShift_Postgre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_RedShift_Postgre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DtgIntegracaoCheckBoxAtualizar,
            this.dtg_col_sis_nucleo_cd_fk,
            this.dtg_col_sis_nucleo_descricao,
            this.dtg_col_sis_nucleo_prc_cd});
            this.dtg_RedShift_Postgre.Location = new System.Drawing.Point(22, 87);
            this.dtg_RedShift_Postgre.Name = "dtg_RedShift_Postgre";
            this.dtg_RedShift_Postgre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_RedShift_Postgre.Size = new System.Drawing.Size(349, 184);
            this.dtg_RedShift_Postgre.TabIndex = 208;
            // 
            // DtgIntegracaoCheckBoxAtualizar
            // 
            this.DtgIntegracaoCheckBoxAtualizar.HeaderText = "Upd";
            this.DtgIntegracaoCheckBoxAtualizar.Name = "DtgIntegracaoCheckBoxAtualizar";
            this.DtgIntegracaoCheckBoxAtualizar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgIntegracaoCheckBoxAtualizar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DtgIntegracaoCheckBoxAtualizar.Width = 45;
            // 
            // dtg_col_sis_nucleo_cd_fk
            // 
            this.dtg_col_sis_nucleo_cd_fk.DataPropertyName = "sis_nucleo_cd_fk";
            this.dtg_col_sis_nucleo_cd_fk.HeaderText = "Núcleo Cd";
            this.dtg_col_sis_nucleo_cd_fk.Name = "dtg_col_sis_nucleo_cd_fk";
            this.dtg_col_sis_nucleo_cd_fk.ReadOnly = true;
            this.dtg_col_sis_nucleo_cd_fk.Width = 60;
            // 
            // dtg_col_sis_nucleo_descricao
            // 
            this.dtg_col_sis_nucleo_descricao.DataPropertyName = "sis_nucleo_descricao";
            this.dtg_col_sis_nucleo_descricao.HeaderText = "Descrição";
            this.dtg_col_sis_nucleo_descricao.Name = "dtg_col_sis_nucleo_descricao";
            this.dtg_col_sis_nucleo_descricao.ReadOnly = true;
            this.dtg_col_sis_nucleo_descricao.Width = 210;
            // 
            // dtg_col_sis_nucleo_prc_cd
            // 
            this.dtg_col_sis_nucleo_prc_cd.DataPropertyName = "sis_nucleo_prc_cd";
            this.dtg_col_sis_nucleo_prc_cd.HeaderText = "Procedimento CD";
            this.dtg_col_sis_nucleo_prc_cd.Name = "dtg_col_sis_nucleo_prc_cd";
            this.dtg_col_sis_nucleo_prc_cd.ReadOnly = true;
            this.dtg_col_sis_nucleo_prc_cd.Width = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(496, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(239, 13);
            this.label17.TabIndex = 206;
            this.label17.Text = "* Executado Diariamente no SRV03 | ServicePag";
            // 
            // cmdAtualizarBase_ZanthusTributacao
            // 
            this.cmdAtualizarBase_ZanthusTributacao.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase_ZanthusTributacao.Location = new System.Drawing.Point(386, 334);
            this.cmdAtualizarBase_ZanthusTributacao.Name = "cmdAtualizarBase_ZanthusTributacao";
            this.cmdAtualizarBase_ZanthusTributacao.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase_ZanthusTributacao.TabIndex = 198;
            this.cmdAtualizarBase_ZanthusTributacao.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase_ZanthusTributacao.Click += new System.EventHandler(this.cmdAtualizarBase_ZanthusTributacao_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(431, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(301, 33);
            this.label11.TabIndex = 197;
            this.label11.Text = "2. Atualiza a Base ZANTHUS com os dados de Tributação armazenados na base SQL SER" +
    "VER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(277, 13);
            this.label9.TabIndex = 194;
            this.label9.Text = "1. Atualizações Gerais RedShift (D-1) para SQL SERVER";
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(386, 302);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 193;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(725, 502);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 161;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // LBL_INFO_PROGRESS
            // 
            this.LBL_INFO_PROGRESS.AutoSize = true;
            this.LBL_INFO_PROGRESS.Location = new System.Drawing.Point(12, 502);
            this.LBL_INFO_PROGRESS.Name = "LBL_INFO_PROGRESS";
            this.LBL_INFO_PROGRESS.Size = new System.Drawing.Size(40, 13);
            this.LBL_INFO_PROGRESS.TabIndex = 193;
            this.LBL_INFO_PROGRESS.Text = "Buscar";
            // 
            // PrgPagAtualizaProduto
            // 
            this.PrgPagAtualizaProduto.Location = new System.Drawing.Point(208, 502);
            this.PrgPagAtualizaProduto.Name = "PrgPagAtualizaProduto";
            this.PrgPagAtualizaProduto.Size = new System.Drawing.Size(176, 23);
            this.PrgPagAtualizaProduto.TabIndex = 194;
            // 
            // chkAtualizacaoParcial
            // 
            this.chkAtualizacaoParcial.AutoSize = true;
            this.chkAtualizacaoParcial.Checked = true;
            this.chkAtualizacaoParcial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtualizacaoParcial.Location = new System.Drawing.Point(22, 18);
            this.chkAtualizacaoParcial.Name = "chkAtualizacaoParcial";
            this.chkAtualizacaoParcial.Size = new System.Drawing.Size(116, 17);
            this.chkAtualizacaoParcial.TabIndex = 217;
            this.chkAtualizacaoParcial.Text = "Atualização Parcial";
            this.chkAtualizacaoParcial.UseVisualStyleBackColor = true;
            // 
            // FrmXProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 531);
            this.Controls.Add(this.PrgPagAtualizaProduto);
            this.Controls.Add(this.LBL_INFO_PROGRESS);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXProduto";
            this.Text = "Produtos";
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProduto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_processamento_geral_produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Postgre_sqlserver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_RedShift_Postgre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHKInativo;
        private System.Windows.Forms.CheckBox CHKAtivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoBarraAssociado;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox TXTCdProdutoList;
        private System.Windows.Forms.TextBox txtCdProdutoBlueSoftList;
        private System.Windows.Forms.TextBox txtCdProdutoTgtList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CMBFabricante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CMBFornecedorTroca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label LBL_INFO_PROGRESS;
        private System.Windows.Forms.ProgressBar PrgPagAtualizaProduto;
        private System.Windows.Forms.DataGridView dtgProduto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button cmddetalhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CdProdutoBluesoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdeProdutosAssociados;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoFabricante;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StatusProduto;
        private System.Windows.Forms.Button cmdAtualizarBase_ZanthusTributacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dtg_RedShift_Postgre;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dtg_Postgre_sqlserver;
        private System.Windows.Forms.Button cmdpost_to_sql;
        private System.Windows.Forms.Button cmdred_to_post;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DtgIntegracaoCheckBoxAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_cd_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_prc_cd;
        private System.Windows.Forms.Button cmdProcessamentoGeral_Produto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtg_processamento_geral_produto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.CheckBox chkAtualizacaoParcial;

    }
}