namespace Pag_Wpf.Comercial.Interface
{
    partial class FrmInterfaceComercialFaturamentoSimulado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DTGInterfaceComercialFaturamentoSimulado = new System.Windows.Forms.DataGridView();
            this.DTGColumnDataFaturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdVendedorERP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnNomeParticipanteVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdClienteERP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnNomeParticipanteCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEmbalagemEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEmbalagemEstoqueQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnValorFaturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DTGColumnCdParticipanteVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCdParticipanteCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTP_INI = new System.Windows.Forms.DateTimePicker();
            this.DTP_FIM = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.CMDEfetiva = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTProdutos = new System.Windows.Forms.TextBox();
            this.CMDLocalizarProdutos = new System.Windows.Forms.Button();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.CMBVendedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTInterfaceInfoDescricao = new System.Windows.Forms.TextBox();
            this.DTPDataFaturamentoRegistroFim = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.DTPDataFaturamentoRegistroIni = new System.Windows.Forms.DateTimePicker();
            this.CMDDesmarcaTodos = new System.Windows.Forms.Button();
            this.CMDSelecionaTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGInterfaceComercialFaturamentoSimulado)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGInterfaceComercialFaturamentoSimulado
            // 
            this.DTGInterfaceComercialFaturamentoSimulado.AllowUserToAddRows = false;
            this.DTGInterfaceComercialFaturamentoSimulado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGInterfaceComercialFaturamentoSimulado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DTGInterfaceComercialFaturamentoSimulado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGInterfaceComercialFaturamentoSimulado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTGColumnDataFaturamento,
            this.DTGColumnCdVendedorERP,
            this.DTGColumnNomeParticipanteVendedor,
            this.DTGColumnCdClienteERP,
            this.DTGColumnNomeParticipanteCliente,
            this.DTGColumnCdProduto,
            this.DTGColumnDescricao,
            this.DTGColumnEmbalagemEstoque,
            this.DTGColumnEmbalagemEstoqueQtde,
            this.DTGColumnValorFaturamento,
            this.DTGColumnSelecionar,
            this.DTGColumnCdParticipanteVendedor,
            this.DTGColumnCdParticipanteCliente});
            this.DTGInterfaceComercialFaturamentoSimulado.Location = new System.Drawing.Point(24, 147);
            this.DTGInterfaceComercialFaturamentoSimulado.Name = "DTGInterfaceComercialFaturamentoSimulado";
            this.DTGInterfaceComercialFaturamentoSimulado.Size = new System.Drawing.Size(915, 404);
            this.DTGInterfaceComercialFaturamentoSimulado.TabIndex = 75;
            // 
            // DTGColumnDataFaturamento
            // 
            this.DTGColumnDataFaturamento.DataPropertyName = "DataFaturamento";
            this.DTGColumnDataFaturamento.HeaderText = "Data";
            this.DTGColumnDataFaturamento.Name = "DTGColumnDataFaturamento";
            this.DTGColumnDataFaturamento.ReadOnly = true;
            this.DTGColumnDataFaturamento.Width = 90;
            // 
            // DTGColumnCdVendedorERP
            // 
            this.DTGColumnCdVendedorERP.DataPropertyName = "CdVendedorERP";
            this.DTGColumnCdVendedorERP.HeaderText = "Vendedor";
            this.DTGColumnCdVendedorERP.Name = "DTGColumnCdVendedorERP";
            this.DTGColumnCdVendedorERP.ReadOnly = true;
            this.DTGColumnCdVendedorERP.Width = 50;
            // 
            // DTGColumnNomeParticipanteVendedor
            // 
            this.DTGColumnNomeParticipanteVendedor.DataPropertyName = "NomeParticipanteVendedor";
            this.DTGColumnNomeParticipanteVendedor.HeaderText = "Nome Vendedor";
            this.DTGColumnNomeParticipanteVendedor.Name = "DTGColumnNomeParticipanteVendedor";
            this.DTGColumnNomeParticipanteVendedor.ReadOnly = true;
            this.DTGColumnNomeParticipanteVendedor.Width = 140;
            // 
            // DTGColumnCdClienteERP
            // 
            this.DTGColumnCdClienteERP.DataPropertyName = "CdClienteERP";
            this.DTGColumnCdClienteERP.HeaderText = "Cliente";
            this.DTGColumnCdClienteERP.Name = "DTGColumnCdClienteERP";
            this.DTGColumnCdClienteERP.ReadOnly = true;
            this.DTGColumnCdClienteERP.Width = 50;
            // 
            // DTGColumnNomeParticipanteCliente
            // 
            this.DTGColumnNomeParticipanteCliente.DataPropertyName = "NomeParticipanteCliente";
            this.DTGColumnNomeParticipanteCliente.HeaderText = "Nome Cliente";
            this.DTGColumnNomeParticipanteCliente.Name = "DTGColumnNomeParticipanteCliente";
            this.DTGColumnNomeParticipanteCliente.ReadOnly = true;
            this.DTGColumnNomeParticipanteCliente.Width = 160;
            // 
            // DTGColumnCdProduto
            // 
            this.DTGColumnCdProduto.DataPropertyName = "CdProduto";
            this.DTGColumnCdProduto.HeaderText = "Produto";
            this.DTGColumnCdProduto.Name = "DTGColumnCdProduto";
            this.DTGColumnCdProduto.ReadOnly = true;
            this.DTGColumnCdProduto.Width = 60;
            // 
            // DTGColumnDescricao
            // 
            this.DTGColumnDescricao.DataPropertyName = "Descricao";
            this.DTGColumnDescricao.HeaderText = "Descrição";
            this.DTGColumnDescricao.Name = "DTGColumnDescricao";
            this.DTGColumnDescricao.ReadOnly = true;
            this.DTGColumnDescricao.Width = 140;
            // 
            // DTGColumnEmbalagemEstoque
            // 
            this.DTGColumnEmbalagemEstoque.DataPropertyName = "EmbalagemEstoque";
            this.DTGColumnEmbalagemEstoque.HeaderText = "Embalagem";
            this.DTGColumnEmbalagemEstoque.Name = "DTGColumnEmbalagemEstoque";
            this.DTGColumnEmbalagemEstoque.ReadOnly = true;
            this.DTGColumnEmbalagemEstoque.Width = 25;
            // 
            // DTGColumnEmbalagemEstoqueQtde
            // 
            this.DTGColumnEmbalagemEstoqueQtde.DataPropertyName = "EmbalagemEstoqueQtde";
            this.DTGColumnEmbalagemEstoqueQtde.HeaderText = "Qtde";
            this.DTGColumnEmbalagemEstoqueQtde.Name = "DTGColumnEmbalagemEstoqueQtde";
            this.DTGColumnEmbalagemEstoqueQtde.Width = 50;
            // 
            // DTGColumnValorFaturamento
            // 
            this.DTGColumnValorFaturamento.DataPropertyName = "ValorTotalFaturamento";
            this.DTGColumnValorFaturamento.HeaderText = "Valor";
            this.DTGColumnValorFaturamento.Name = "DTGColumnValorFaturamento";
            this.DTGColumnValorFaturamento.ReadOnly = true;
            this.DTGColumnValorFaturamento.Width = 50;
            // 
            // DTGColumnSelecionar
            // 
            this.DTGColumnSelecionar.HeaderText = "";
            this.DTGColumnSelecionar.Name = "DTGColumnSelecionar";
            this.DTGColumnSelecionar.Width = 30;
            // 
            // DTGColumnCdParticipanteVendedor
            // 
            this.DTGColumnCdParticipanteVendedor.HeaderText = "Vendedor";
            this.DTGColumnCdParticipanteVendedor.Name = "DTGColumnCdParticipanteVendedor";
            this.DTGColumnCdParticipanteVendedor.Visible = false;
            // 
            // DTGColumnCdParticipanteCliente
            // 
            this.DTGColumnCdParticipanteCliente.HeaderText = "Cliente";
            this.DTGColumnCdParticipanteCliente.Name = "DTGColumnCdParticipanteCliente";
            this.DTGColumnCdParticipanteCliente.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(873, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "Inclusão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "Interface Comercial - Simulação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(593, 35);
            this.label3.MinimumSize = new System.Drawing.Size(230, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 22);
            this.label3.TabIndex = 79;
            this.label3.Text = "Período Análise";
            // 
            // DTP_INI
            // 
            this.DTP_INI.CustomFormat = "dd/MM/yyyy";
            this.DTP_INI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTP_INI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_INI.Location = new System.Drawing.Point(593, 60);
            this.DTP_INI.Name = "DTP_INI";
            this.DTP_INI.Size = new System.Drawing.Size(112, 26);
            this.DTP_INI.TabIndex = 78;
            this.DTP_INI.ValueChanged += new System.EventHandler(this.DTP_INI_ValueChanged);
            // 
            // DTP_FIM
            // 
            this.DTP_FIM.CustomFormat = "dd/MM/yyyy";
            this.DTP_FIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTP_FIM.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_FIM.Location = new System.Drawing.Point(711, 60);
            this.DTP_FIM.Name = "DTP_FIM";
            this.DTP_FIM.Size = new System.Drawing.Size(112, 26);
            this.DTP_FIM.TabIndex = 80;
            this.DTP_FIM.ValueChanged += new System.EventHandler(this.DTP_FIM_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 33);
            this.label4.MinimumSize = new System.Drawing.Size(145, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 81;
            this.label4.Text = "Interface";
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(763, 557);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(85, 32);
            this.CMDCancelar.TabIndex = 100;
            this.CMDCancelar.Text = "Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            // 
            // CMDEfetiva
            // 
            this.CMDEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDEfetiva.Location = new System.Drawing.Point(854, 557);
            this.CMDEfetiva.Name = "CMDEfetiva";
            this.CMDEfetiva.Size = new System.Drawing.Size(85, 32);
            this.CMDEfetiva.TabIndex = 99;
            this.CMDEfetiva.Text = "Efetivar";
            this.CMDEfetiva.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDEfetiva.UseVisualStyleBackColor = true;
            this.CMDEfetiva.Click += new System.EventHandler(this.CMDEfetiva_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(260, 90);
            this.label5.MinimumSize = new System.Drawing.Size(230, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 22);
            this.label5.TabIndex = 101;
            this.label5.Text = "Lista de Produtos";
            // 
            // TXTProdutos
            // 
            this.TXTProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTProdutos.Location = new System.Drawing.Point(260, 114);
            this.TXTProdutos.MaxLength = 0;
            this.TXTProdutos.Name = "TXTProdutos";
            this.TXTProdutos.Size = new System.Drawing.Size(515, 26);
            this.TXTProdutos.TabIndex = 102;
            this.TXTProdutos.TextChanged += new System.EventHandler(this.TXTProdutos_TextChanged);
            this.TXTProdutos.DoubleClick += new System.EventHandler(this.TXTProdutos_DoubleClick);
            // 
            // CMDLocalizarProdutos
            // 
            this.CMDLocalizarProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLocalizarProdutos.Location = new System.Drawing.Point(781, 114);
            this.CMDLocalizarProdutos.Name = "CMDLocalizarProdutos";
            this.CMDLocalizarProdutos.Size = new System.Drawing.Size(42, 26);
            this.CMDLocalizarProdutos.TabIndex = 103;
            this.CMDLocalizarProdutos.Text = "...";
            this.CMDLocalizarProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLocalizarProdutos.UseVisualStyleBackColor = true;
            this.CMDLocalizarProdutos.Click += new System.EventHandler(this.CMDLocalizarProdutos_Click);
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLocalizar.ForeColor = System.Drawing.Color.Black;
            this.CMDLocalizar.Location = new System.Drawing.Point(839, 33);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(100, 32);
            this.CMDLocalizar.TabIndex = 104;
            this.CMDLocalizar.Text = "&Localizar";
            this.CMDLocalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // CMBVendedor
            // 
            this.CMBVendedor.DisplayMember = "Nome";
            this.CMBVendedor.DropDownHeight = 150;
            this.CMBVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBVendedor.FormattingEnabled = true;
            this.CMBVendedor.IntegralHeight = false;
            this.CMBVendedor.Location = new System.Drawing.Point(178, 58);
            this.CMBVendedor.MaxDropDownItems = 12;
            this.CMBVendedor.Name = "CMBVendedor";
            this.CMBVendedor.Size = new System.Drawing.Size(409, 28);
            this.CMBVendedor.TabIndex = 106;
            this.CMBVendedor.ValueMember = "CdParticipante";
            this.CMBVendedor.SelectedValueChanged += new System.EventHandler(this.CMBVendedor_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(178, 33);
            this.label6.MinimumSize = new System.Drawing.Size(410, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 22);
            this.label6.TabIndex = 105;
            this.label6.Text = "Vendedor";
            // 
            // TXTInterfaceInfoDescricao
            // 
            this.TXTInterfaceInfoDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTInterfaceInfoDescricao.Enabled = false;
            this.TXTInterfaceInfoDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTInterfaceInfoDescricao.Location = new System.Drawing.Point(24, 58);
            this.TXTInterfaceInfoDescricao.MaxLength = 0;
            this.TXTInterfaceInfoDescricao.Name = "TXTInterfaceInfoDescricao";
            this.TXTInterfaceInfoDescricao.Size = new System.Drawing.Size(145, 26);
            this.TXTInterfaceInfoDescricao.TabIndex = 107;
            // 
            // DTPDataFaturamentoRegistroFim
            // 
            this.DTPDataFaturamentoRegistroFim.CustomFormat = "dd/MM/yyyy";
            this.DTPDataFaturamentoRegistroFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataFaturamentoRegistroFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataFaturamentoRegistroFim.Location = new System.Drawing.Point(142, 115);
            this.DTPDataFaturamentoRegistroFim.Name = "DTPDataFaturamentoRegistroFim";
            this.DTPDataFaturamentoRegistroFim.Size = new System.Drawing.Size(112, 26);
            this.DTPDataFaturamentoRegistroFim.TabIndex = 110;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 90);
            this.label7.MinimumSize = new System.Drawing.Size(230, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 22);
            this.label7.TabIndex = 109;
            this.label7.Text = "Período para Registro ";
            // 
            // DTPDataFaturamentoRegistroIni
            // 
            this.DTPDataFaturamentoRegistroIni.CustomFormat = "dd/MM/yyyy";
            this.DTPDataFaturamentoRegistroIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DTPDataFaturamentoRegistroIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDataFaturamentoRegistroIni.Location = new System.Drawing.Point(24, 115);
            this.DTPDataFaturamentoRegistroIni.Name = "DTPDataFaturamentoRegistroIni";
            this.DTPDataFaturamentoRegistroIni.Size = new System.Drawing.Size(112, 26);
            this.DTPDataFaturamentoRegistroIni.TabIndex = 108;
            // 
            // CMDDesmarcaTodos
            // 
            this.CMDDesmarcaTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDDesmarcaTodos.Location = new System.Drawing.Point(854, 114);
            this.CMDDesmarcaTodos.Name = "CMDDesmarcaTodos";
            this.CMDDesmarcaTodos.Size = new System.Drawing.Size(42, 26);
            this.CMDDesmarcaTodos.TabIndex = 111;
            this.CMDDesmarcaTodos.Text = "[  ]";
            this.CMDDesmarcaTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDDesmarcaTodos.UseVisualStyleBackColor = true;
            this.CMDDesmarcaTodos.Click += new System.EventHandler(this.CMDDesmarcaTodos_Click);
            // 
            // CMDSelecionaTodos
            // 
            this.CMDSelecionaTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDSelecionaTodos.Location = new System.Drawing.Point(902, 114);
            this.CMDSelecionaTodos.Name = "CMDSelecionaTodos";
            this.CMDSelecionaTodos.Size = new System.Drawing.Size(42, 26);
            this.CMDSelecionaTodos.TabIndex = 112;
            this.CMDSelecionaTodos.Text = "[v]";
            this.CMDSelecionaTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDSelecionaTodos.UseVisualStyleBackColor = true;
            this.CMDSelecionaTodos.Click += new System.EventHandler(this.CMDSelecionaTodos_Click);
            // 
            // FrmInterfaceComercialFaturamentoSimulado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 601);
            this.Controls.Add(this.CMDSelecionaTodos);
            this.Controls.Add(this.CMDDesmarcaTodos);
            this.Controls.Add(this.DTPDataFaturamentoRegistroFim);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DTPDataFaturamentoRegistroIni);
            this.Controls.Add(this.TXTInterfaceInfoDescricao);
            this.Controls.Add(this.CMBVendedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CMDLocalizar);
            this.Controls.Add(this.CMDLocalizarProdutos);
            this.Controls.Add(this.TXTProdutos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDEfetiva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DTP_FIM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTP_INI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTGInterfaceComercialFaturamentoSimulado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInterfaceComercialFaturamentoSimulado";
            this.Text = "Interface Comercial Faturamento Simulado";
            ((System.ComponentModel.ISupportInitialize)(this.DTGInterfaceComercialFaturamentoSimulado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGInterfaceComercialFaturamentoSimulado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTP_INI;
        private System.Windows.Forms.DateTimePicker DTP_FIM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.Button CMDEfetiva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTProdutos;
        private System.Windows.Forms.Button CMDLocalizarProdutos;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.ComboBox CMBVendedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDataFaturamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdVendedorERP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnNomeParticipanteVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdClienteERP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnNomeParticipanteCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEmbalagemEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEmbalagemEstoqueQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnValorFaturamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DTGColumnSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdParticipanteVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCdParticipanteCliente;
        private System.Windows.Forms.TextBox TXTInterfaceInfoDescricao;
        private System.Windows.Forms.DateTimePicker DTPDataFaturamentoRegistroFim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DTPDataFaturamentoRegistroIni;
        private System.Windows.Forms.Button CMDDesmarcaTodos;
        private System.Windows.Forms.Button CMDSelecionaTodos;
    }
}