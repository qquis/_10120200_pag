namespace Pag_Wpf.Forms
{
    partial class FrmXProdutoPreco
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ChkDataAlteracaoCusto = new System.Windows.Forms.CheckBox();
            this.GroupBoxDataAlteracaoCusto = new System.Windows.Forms.GroupBox();
            this.DtpDataAlteracaoCustoFinal = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DtpDataAlteracaoCustoInicial = new System.Windows.Forms.DateTimePicker();
            this.dtgProdutoPreco = new System.Windows.Forms.DataGridView();
            this.cmdSair = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtTotalItens = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFiltroCusto = new System.Windows.Forms.Label();
            this.lblinfo_x = new System.Windows.Forms.Label();
            this.TbProduto_CdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProduto_CdProdutoBlueSoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProduto_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProduto_EmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbEstoque_Qtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgMgEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProdutoOperacaoCusto_ValorCustoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgMgMedia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProdutoOperacaoPreco_ValorPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GroupBoxDataAlteracaoCusto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutoPreco)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 139);
            this.tabControl1.TabIndex = 160;
            // 
            // TabPage1
            // 
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
            this.TabPage1.Size = new System.Drawing.Size(594, 113);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Produto";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(443, 12);
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
            this.label7.Location = new System.Drawing.Point(290, 11);
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
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(458, 55);
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
            this.label6.Location = new System.Drawing.Point(290, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 169;
            this.label6.Text = "Código de Barra Associado";
            // 
            // txtCodigoBarraAssociado
            // 
            this.txtCodigoBarraAssociado.Location = new System.Drawing.Point(293, 71);
            this.txtCodigoBarraAssociado.Name = "txtCodigoBarraAssociado";
            this.txtCodigoBarraAssociado.Size = new System.Drawing.Size(147, 20);
            this.txtCodigoBarraAssociado.TabIndex = 168;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(14, 71);
            this.txtDescricao.MaxLength = 60;
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
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 165;
            this.label4.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 163;
            this.label3.Text = "Códigos Pag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 161;
            this.label2.Text = "Códigos BlueSoft";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "Códigos Target";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ChkDataAlteracaoCusto);
            this.tabPage2.Controls.Add(this.GroupBoxDataAlteracaoCusto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(594, 113);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dados do Custo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ChkDataAlteracaoCusto
            // 
            this.ChkDataAlteracaoCusto.AutoSize = true;
            this.ChkDataAlteracaoCusto.Location = new System.Drawing.Point(15, 6);
            this.ChkDataAlteracaoCusto.Name = "ChkDataAlteracaoCusto";
            this.ChkDataAlteracaoCusto.Size = new System.Drawing.Size(526, 17);
            this.ChkDataAlteracaoCusto.TabIndex = 180;
            this.ChkDataAlteracaoCusto.Text = "Filtrar a Lista pela Data de Alteração do Custo (Data de Registro de acordo com I" +
    "ntegração Pag/BlueSoft)";
            this.ChkDataAlteracaoCusto.UseVisualStyleBackColor = true;
            this.ChkDataAlteracaoCusto.CheckedChanged += new System.EventHandler(this.ChkDataAlteracaoCusto_CheckedChanged);
            // 
            // GroupBoxDataAlteracaoCusto
            // 
            this.GroupBoxDataAlteracaoCusto.Controls.Add(this.DtpDataAlteracaoCustoFinal);
            this.GroupBoxDataAlteracaoCusto.Controls.Add(this.label9);
            this.GroupBoxDataAlteracaoCusto.Controls.Add(this.label10);
            this.GroupBoxDataAlteracaoCusto.Controls.Add(this.DtpDataAlteracaoCustoInicial);
            this.GroupBoxDataAlteracaoCusto.Location = new System.Drawing.Point(15, 27);
            this.GroupBoxDataAlteracaoCusto.Name = "GroupBoxDataAlteracaoCusto";
            this.GroupBoxDataAlteracaoCusto.Size = new System.Drawing.Size(291, 65);
            this.GroupBoxDataAlteracaoCusto.TabIndex = 179;
            this.GroupBoxDataAlteracaoCusto.TabStop = false;
            // 
            // DtpDataAlteracaoCustoFinal
            // 
            this.DtpDataAlteracaoCustoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDataAlteracaoCustoFinal.Location = new System.Drawing.Point(118, 32);
            this.DtpDataAlteracaoCustoFinal.Name = "DtpDataAlteracaoCustoFinal";
            this.DtpDataAlteracaoCustoFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpDataAlteracaoCustoFinal.TabIndex = 179;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 178;
            this.label9.Text = "Data Final";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 177;
            this.label10.Text = "Data Inicial";
            // 
            // DtpDataAlteracaoCustoInicial
            // 
            this.DtpDataAlteracaoCustoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDataAlteracaoCustoInicial.Location = new System.Drawing.Point(16, 32);
            this.DtpDataAlteracaoCustoInicial.Name = "DtpDataAlteracaoCustoInicial";
            this.DtpDataAlteracaoCustoInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpDataAlteracaoCustoInicial.TabIndex = 176;
            // 
            // dtgProdutoPreco
            // 
            this.dtgProdutoPreco.AllowUserToAddRows = false;
            this.dtgProdutoPreco.AllowUserToDeleteRows = false;
            this.dtgProdutoPreco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProdutoPreco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TbProduto_CdProduto,
            this.TbProduto_CdProdutoBlueSoft,
            this.TbProduto_Descricao,
            this.TbProduto_EmbalagemEstoque,
            this.TbEstoque_Qtde,
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada,
            this.DtgMgEntrada,
            this.TbProdutoOperacaoCusto_ValorCustoBruto,
            this.DtgMgMedia,
            this.TbProdutoOperacaoPreco_ValorPreco,
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco,
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque});
            this.dtgProdutoPreco.Location = new System.Drawing.Point(12, 157);
            this.dtgProdutoPreco.Name = "dtgProdutoPreco";
            this.dtgProdutoPreco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProdutoPreco.Size = new System.Drawing.Size(998, 375);
            this.dtgProdutoPreco.TabIndex = 161;
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(910, 538);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 162;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(757, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 179;
            this.label5.Text = "Buscar";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(803, 34);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 178;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtTotalItens
            // 
            this.txtTotalItens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalItens.Enabled = false;
            this.txtTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItens.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalItens.Location = new System.Drawing.Point(90, 538);
            this.txtTotalItens.Name = "txtTotalItens";
            this.txtTotalItens.Size = new System.Drawing.Size(82, 20);
            this.txtTotalItens.TabIndex = 180;
            this.txtTotalItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 538);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 181;
            this.label11.Text = "Total de Itens";
            // 
            // lblFiltroCusto
            // 
            this.lblFiltroCusto.AutoSize = true;
            this.lblFiltroCusto.Location = new System.Drawing.Point(188, 538);
            this.lblFiltroCusto.Name = "lblFiltroCusto";
            this.lblFiltroCusto.Size = new System.Drawing.Size(131, 13);
            this.lblFiltroCusto.TabIndex = 182;
            this.lblFiltroCusto.Text = "Filtro de Custo Desativado";
            // 
            // lblinfo_x
            // 
            this.lblinfo_x.AutoSize = true;
            this.lblinfo_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo_x.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblinfo_x.Location = new System.Drawing.Point(689, 0);
            this.lblinfo_x.Name = "lblinfo_x";
            this.lblinfo_x.Size = new System.Drawing.Size(153, 9);
            this.lblinfo_x.TabIndex = 183;
            this.lblinfo_x.Text = "FrmXProdutoPreco / SP_ProdutoPreco_k02";
            // 
            // TbProduto_CdProduto
            // 
            this.TbProduto_CdProduto.DataPropertyName = "TbProduto_CdProduto";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProduto_CdProduto.DefaultCellStyle = dataGridViewCellStyle9;
            this.TbProduto_CdProduto.HeaderText = "Cód Pag";
            this.TbProduto_CdProduto.Name = "TbProduto_CdProduto";
            this.TbProduto_CdProduto.ReadOnly = true;
            this.TbProduto_CdProduto.Width = 55;
            // 
            // TbProduto_CdProdutoBlueSoft
            // 
            this.TbProduto_CdProdutoBlueSoft.DataPropertyName = "TbProduto_CdProdutoBlueSoft";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProduto_CdProdutoBlueSoft.DefaultCellStyle = dataGridViewCellStyle10;
            this.TbProduto_CdProdutoBlueSoft.HeaderText = "Cod Blue";
            this.TbProduto_CdProdutoBlueSoft.Name = "TbProduto_CdProdutoBlueSoft";
            this.TbProduto_CdProdutoBlueSoft.Width = 55;
            // 
            // TbProduto_Descricao
            // 
            this.TbProduto_Descricao.DataPropertyName = "TbProduto_Descricao";
            this.TbProduto_Descricao.HeaderText = "Descrição";
            this.TbProduto_Descricao.Name = "TbProduto_Descricao";
            this.TbProduto_Descricao.ReadOnly = true;
            this.TbProduto_Descricao.Width = 250;
            // 
            // TbProduto_EmbalagemEstoque
            // 
            this.TbProduto_EmbalagemEstoque.DataPropertyName = "TbProduto_EmbalagemEstoque";
            this.TbProduto_EmbalagemEstoque.HeaderText = "";
            this.TbProduto_EmbalagemEstoque.Name = "TbProduto_EmbalagemEstoque";
            this.TbProduto_EmbalagemEstoque.ReadOnly = true;
            this.TbProduto_EmbalagemEstoque.Width = 25;
            // 
            // TbEstoque_Qtde
            // 
            this.TbEstoque_Qtde.DataPropertyName = "TbEstoque_Qtde";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbEstoque_Qtde.DefaultCellStyle = dataGridViewCellStyle11;
            this.TbEstoque_Qtde.HeaderText = "Qtde";
            this.TbEstoque_Qtde.Name = "TbEstoque_Qtde";
            this.TbEstoque_Qtde.Width = 55;
            // 
            // TbProdutoOperacaoCusto_ValorCustoBrutoEntrada
            // 
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada.DataPropertyName = "TbProdutoOperacaoCusto_ValorCustoBrutoEntrada";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada.DefaultCellStyle = dataGridViewCellStyle12;
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada.HeaderText = "Vl. Custo Entrada";
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada.Name = "TbProdutoOperacaoCusto_ValorCustoBrutoEntrada";
            this.TbProdutoOperacaoCusto_ValorCustoBrutoEntrada.Width = 55;
            // 
            // DtgMgEntrada
            // 
            this.DtgMgEntrada.HeaderText = "%E";
            this.DtgMgEntrada.Name = "DtgMgEntrada";
            this.DtgMgEntrada.Width = 25;
            // 
            // TbProdutoOperacaoCusto_ValorCustoBruto
            // 
            this.TbProdutoOperacaoCusto_ValorCustoBruto.DataPropertyName = "TbProdutoOperacaoCusto_ValorCustoBruto";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProdutoOperacaoCusto_ValorCustoBruto.DefaultCellStyle = dataGridViewCellStyle13;
            this.TbProdutoOperacaoCusto_ValorCustoBruto.HeaderText = "Vl. Custo Br";
            this.TbProdutoOperacaoCusto_ValorCustoBruto.Name = "TbProdutoOperacaoCusto_ValorCustoBruto";
            this.TbProdutoOperacaoCusto_ValorCustoBruto.Width = 55;
            // 
            // DtgMgMedia
            // 
            this.DtgMgMedia.HeaderText = "%M";
            this.DtgMgMedia.Name = "DtgMgMedia";
            this.DtgMgMedia.Width = 25;
            // 
            // TbProdutoOperacaoPreco_ValorPreco
            // 
            this.TbProdutoOperacaoPreco_ValorPreco.DataPropertyName = "TbProdutoOperacaoPreco_ValorPreco";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProdutoOperacaoPreco_ValorPreco.DefaultCellStyle = dataGridViewCellStyle14;
            this.TbProdutoOperacaoPreco_ValorPreco.HeaderText = "Valor Preço";
            this.TbProdutoOperacaoPreco_ValorPreco.Name = "TbProdutoOperacaoPreco_ValorPreco";
            this.TbProdutoOperacaoPreco_ValorPreco.Width = 55;
            // 
            // TbProdutoOperacaoPreco_DataAtualizacaoPreco
            // 
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco.DataPropertyName = "TbProdutoOperacaoPreco_DataAtualizacaoPreco";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco.DefaultCellStyle = dataGridViewCellStyle15;
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco.HeaderText = "Data Preço";
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco.Name = "TbProdutoOperacaoPreco_DataAtualizacaoPreco";
            this.TbProdutoOperacaoPreco_DataAtualizacaoPreco.Width = 75;
            // 
            // TbProdutoOperacaoPreco_DataAtualizacaoEstoque
            // 
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque.DataPropertyName = "TbProdutoOperacaoPreco_DataAtualizacaoEstoque";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque.DefaultCellStyle = dataGridViewCellStyle16;
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque.HeaderText = "Data Estoque";
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque.Name = "TbProdutoOperacaoPreco_DataAtualizacaoEstoque";
            this.TbProdutoOperacaoPreco_DataAtualizacaoEstoque.Width = 75;
            // 
            // FrmXProdutoPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 566);
            this.Controls.Add(this.lblinfo_x);
            this.Controls.Add(this.lblFiltroCusto);
            this.Controls.Add(this.txtTotalItens);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.dtgProdutoPreco);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXProdutoPreco";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Pag - Consulta de Preços v.k02";
            this.tabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.GroupBoxDataAlteracaoCusto.ResumeLayout(false);
            this.GroupBoxDataAlteracaoCusto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProdutoPreco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CMBFabricante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CMBFornecedorTroca;
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
        private System.Windows.Forms.DataGridView dtgProdutoPreco;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox GroupBoxDataAlteracaoCusto;
        private System.Windows.Forms.CheckBox ChkDataAlteracaoCusto;
        private System.Windows.Forms.DateTimePicker DtpDataAlteracaoCustoFinal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DtpDataAlteracaoCustoInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtTotalItens;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFiltroCusto;
        private System.Windows.Forms.Label lblinfo_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProduto_CdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProduto_CdProdutoBlueSoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProduto_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProduto_EmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbEstoque_Qtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProdutoOperacaoCusto_ValorCustoBrutoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgMgEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProdutoOperacaoCusto_ValorCustoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgMgMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProdutoOperacaoPreco_ValorPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProdutoOperacaoPreco_DataAtualizacaoPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn TbProdutoOperacaoPreco_DataAtualizacaoEstoque;
    }
}