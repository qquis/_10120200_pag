namespace Pag_Wpf.Forms
{
    partial class FrmXFaturamentoBlueSoft
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
            this.txtCdProdutoTgt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgFaturamentoBlueSoft = new System.Windows.Forms.DataGridView();
            this.PedidoProdutoKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaFiscalProdutoRelacionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoProdutoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoVolumeFaturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoProdutoKeyUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoUnitarioFatorEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumeUnitarioCalculado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCustoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaFiscalValorBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescontoFinanceiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerbaVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentualComissaoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoPrecoAplicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoPrecoTabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoEmbalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroNotaFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPedidoBlueSoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroNotaFiscalDevolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgItens_verba_calculada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgiten_cd_barra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.DtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.dtgFaturamentoBlueSoftNotasFiscais = new System.Windows.Forms.DataGridView();
            this.dtgfat_base_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgfat_base_Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoClienteCPFCNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgtCancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.txtNotaFiscalSelecionada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQtdeItens = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorNotaFiscal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorVerba = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorDescontoFinanceiro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNDocumentosFiscaisEncontrados = new System.Windows.Forms.TextBox();
            this.LBLInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoftNotasFiscais)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCdProdutoTgt
            // 
            this.txtCdProdutoTgt.Location = new System.Drawing.Point(219, 34);
            this.txtCdProdutoTgt.Name = "txtCdProdutoTgt";
            this.txtCdProdutoTgt.Size = new System.Drawing.Size(132, 20);
            this.txtCdProdutoTgt.TabIndex = 164;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "Código Prd Blue";
            // 
            // dtgFaturamentoBlueSoft
            // 
            this.dtgFaturamentoBlueSoft.AllowUserToAddRows = false;
            this.dtgFaturamentoBlueSoft.AllowUserToDeleteRows = false;
            this.dtgFaturamentoBlueSoft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFaturamentoBlueSoft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PedidoProdutoKey,
            this.NotaFiscalProdutoRelacionado,
            this.PedidoProdutoDescricao,
            this.PedidoVolumeFaturado,
            this.PedidoProdutoKeyUnitario,
            this.ProdutoUnitarioFatorEstoque,
            this.VolumeUnitarioCalculado,
            this.ProdutoCustoUnitario,
            this.NotaFiscalValorBruto,
            this.DescontoFinanceiro,
            this.VerbaVendedor,
            this.PercentualComissaoVendedor,
            this.PedidoPrecoAplicado,
            this.PedidoPrecoTabela,
            this.PedidoEmbalagem,
            this.NumeroNotaFiscal,
            this.NumeroPedidoBlueSoft,
            this.NumeroNotaFiscalDevolucao,
            this.dtgItens_verba_calculada,
            this.dtgiten_cd_barra});
            this.dtgFaturamentoBlueSoft.Location = new System.Drawing.Point(15, 258);
            this.dtgFaturamentoBlueSoft.Name = "dtgFaturamentoBlueSoft";
            this.dtgFaturamentoBlueSoft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFaturamentoBlueSoft.Size = new System.Drawing.Size(889, 270);
            this.dtgFaturamentoBlueSoft.TabIndex = 168;
            // 
            // PedidoProdutoKey
            // 
            this.PedidoProdutoKey.DataPropertyName = "PedidoCdProdutoBlueSoft";
            this.PedidoProdutoKey.HeaderText = "Ped Prod Key";
            this.PedidoProdutoKey.Name = "PedidoProdutoKey";
            this.PedidoProdutoKey.Width = 50;
            // 
            // NotaFiscalProdutoRelacionado
            // 
            this.NotaFiscalProdutoRelacionado.DataPropertyName = "NotaFiscalCdProdutoBlueSoft";
            this.NotaFiscalProdutoRelacionado.HeaderText = "Nf Prod Rel";
            this.NotaFiscalProdutoRelacionado.Name = "NotaFiscalProdutoRelacionado";
            this.NotaFiscalProdutoRelacionado.Width = 45;
            // 
            // PedidoProdutoDescricao
            // 
            this.PedidoProdutoDescricao.DataPropertyName = "PedidoProdutoDescricao";
            this.PedidoProdutoDescricao.HeaderText = "Prod Desc (Ped)";
            this.PedidoProdutoDescricao.Name = "PedidoProdutoDescricao";
            this.PedidoProdutoDescricao.Width = 140;
            // 
            // PedidoVolumeFaturado
            // 
            this.PedidoVolumeFaturado.DataPropertyName = "PedidoVolumeFaturado";
            this.PedidoVolumeFaturado.FillWeight = 70F;
            this.PedidoVolumeFaturado.HeaderText = "Ped Vol.F";
            this.PedidoVolumeFaturado.Name = "PedidoVolumeFaturado";
            this.PedidoVolumeFaturado.Width = 50;
            // 
            // PedidoProdutoKeyUnitario
            // 
            this.PedidoProdutoKeyUnitario.DataPropertyName = "PedidoCdProdutoBlueSoftUnitario";
            this.PedidoProdutoKeyUnitario.FillWeight = 70F;
            this.PedidoProdutoKeyUnitario.HeaderText = "Ped Prod Unit Key";
            this.PedidoProdutoKeyUnitario.Name = "PedidoProdutoKeyUnitario";
            this.PedidoProdutoKeyUnitario.Width = 50;
            // 
            // ProdutoUnitarioFatorEstoque
            // 
            this.ProdutoUnitarioFatorEstoque.DataPropertyName = "PedidoProdutoUnitarioFator";
            this.ProdutoUnitarioFatorEstoque.FillWeight = 70F;
            this.ProdutoUnitarioFatorEstoque.HeaderText = "Fator Est.";
            this.ProdutoUnitarioFatorEstoque.Name = "ProdutoUnitarioFatorEstoque";
            this.ProdutoUnitarioFatorEstoque.Width = 40;
            // 
            // VolumeUnitarioCalculado
            // 
            this.VolumeUnitarioCalculado.DataPropertyName = "VolumeUnitarioCalculado";
            this.VolumeUnitarioCalculado.FillWeight = 70F;
            this.VolumeUnitarioCalculado.HeaderText = "Vol Calc";
            this.VolumeUnitarioCalculado.Name = "VolumeUnitarioCalculado";
            this.VolumeUnitarioCalculado.Width = 40;
            // 
            // ProdutoCustoUnitario
            // 
            this.ProdutoCustoUnitario.DataPropertyName = "ValorCustoUnitario";
            this.ProdutoCustoUnitario.FillWeight = 70F;
            this.ProdutoCustoUnitario.HeaderText = "Custo Unit";
            this.ProdutoCustoUnitario.Name = "ProdutoCustoUnitario";
            this.ProdutoCustoUnitario.Width = 45;
            // 
            // NotaFiscalValorBruto
            // 
            this.NotaFiscalValorBruto.DataPropertyName = "ValorNotaFiscal";
            this.NotaFiscalValorBruto.FillWeight = 70F;
            this.NotaFiscalValorBruto.HeaderText = "NF Vl Brt";
            this.NotaFiscalValorBruto.Name = "NotaFiscalValorBruto";
            this.NotaFiscalValorBruto.Width = 45;
            // 
            // DescontoFinanceiro
            // 
            this.DescontoFinanceiro.DataPropertyName = "DescontoFinanceiro";
            this.DescontoFinanceiro.FillWeight = 70F;
            this.DescontoFinanceiro.HeaderText = "Vl Desc Fin";
            this.DescontoFinanceiro.Name = "DescontoFinanceiro";
            this.DescontoFinanceiro.Width = 45;
            // 
            // VerbaVendedor
            // 
            this.VerbaVendedor.DataPropertyName = "PedidoValorVerba";
            this.VerbaVendedor.FillWeight = 70F;
            this.VerbaVendedor.HeaderText = "Vl Verba";
            this.VerbaVendedor.Name = "VerbaVendedor";
            this.VerbaVendedor.Width = 45;
            // 
            // PercentualComissaoVendedor
            // 
            this.PercentualComissaoVendedor.DataPropertyName = "PedidoPercentualComissao";
            this.PercentualComissaoVendedor.FillWeight = 70F;
            this.PercentualComissaoVendedor.HeaderText = "% CS";
            this.PercentualComissaoVendedor.Name = "PercentualComissaoVendedor";
            this.PercentualComissaoVendedor.Width = 45;
            // 
            // PedidoPrecoAplicado
            // 
            this.PedidoPrecoAplicado.DataPropertyName = "ValorPrecoVendaCustoFinanceiro";
            this.PedidoPrecoAplicado.FillWeight = 70F;
            this.PedidoPrecoAplicado.HeaderText = "Vl Preco Apl";
            this.PedidoPrecoAplicado.Name = "PedidoPrecoAplicado";
            this.PedidoPrecoAplicado.Width = 45;
            // 
            // PedidoPrecoTabela
            // 
            this.PedidoPrecoTabela.DataPropertyName = "ValorPrecoTabela";
            this.PedidoPrecoTabela.FillWeight = 70F;
            this.PedidoPrecoTabela.HeaderText = "Vl Preco Tab";
            this.PedidoPrecoTabela.Name = "PedidoPrecoTabela";
            this.PedidoPrecoTabela.Width = 45;
            // 
            // PedidoEmbalagem
            // 
            this.PedidoEmbalagem.DataPropertyName = "PedidoTipoEmbalagem";
            this.PedidoEmbalagem.FillWeight = 70F;
            this.PedidoEmbalagem.HeaderText = "EMB";
            this.PedidoEmbalagem.Name = "PedidoEmbalagem";
            this.PedidoEmbalagem.Width = 45;
            // 
            // NumeroNotaFiscal
            // 
            this.NumeroNotaFiscal.DataPropertyName = "NumeroNotaFiscal";
            this.NumeroNotaFiscal.HeaderText = "Nfv N.";
            this.NumeroNotaFiscal.Name = "NumeroNotaFiscal";
            this.NumeroNotaFiscal.Width = 45;
            // 
            // NumeroPedidoBlueSoft
            // 
            this.NumeroPedidoBlueSoft.DataPropertyName = "NumeroNumeroPedido";
            this.NumeroPedidoBlueSoft.HeaderText = "N. Ped";
            this.NumeroPedidoBlueSoft.Name = "NumeroPedidoBlueSoft";
            this.NumeroPedidoBlueSoft.Width = 45;
            // 
            // NumeroNotaFiscalDevolucao
            // 
            this.NumeroNotaFiscalDevolucao.DataPropertyName = "NumeroNotaFiscalDevolucao";
            this.NumeroNotaFiscalDevolucao.HeaderText = "Nfd N.";
            this.NumeroNotaFiscalDevolucao.Name = "NumeroNotaFiscalDevolucao";
            this.NumeroNotaFiscalDevolucao.Width = 45;
            // 
            // dtgItens_verba_calculada
            // 
            this.dtgItens_verba_calculada.DataPropertyName = "VERBA_CALCULADA";
            this.dtgItens_verba_calculada.HeaderText = "Verba Calculada";
            this.dtgItens_verba_calculada.Name = "dtgItens_verba_calculada";
            // 
            // dtgiten_cd_barra
            // 
            this.dtgiten_cd_barra.DataPropertyName = "BARRA_KEY";
            this.dtgiten_cd_barra.HeaderText = "Cod Barra";
            this.dtgiten_cd_barra.Name = "dtgiten_cd_barra";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(865, 31);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 169;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // DtpInicial
            // 
            this.DtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicial.Location = new System.Drawing.Point(15, 34);
            this.DtpInicial.Name = "DtpInicial";
            this.DtpInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpInicial.TabIndex = 171;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Data Inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 174;
            this.label4.Text = "Data Final";
            // 
            // DtpFinal
            // 
            this.DtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFinal.Location = new System.Drawing.Point(117, 34);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpFinal.TabIndex = 175;
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(804, 548);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 176;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(820, 31);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 178;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // dtgFaturamentoBlueSoftNotasFiscais
            // 
            this.dtgFaturamentoBlueSoftNotasFiscais.AllowUserToAddRows = false;
            this.dtgFaturamentoBlueSoftNotasFiscais.AllowUserToDeleteRows = false;
            this.dtgFaturamentoBlueSoftNotasFiscais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFaturamentoBlueSoftNotasFiscais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgfat_base_empresa,
            this.dtgfat_base_Operacao,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.PedidoClienteCPFCNPJ,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dgtCancelada,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dtgFaturamentoBlueSoftNotasFiscais.Location = new System.Drawing.Point(15, 60);
            this.dtgFaturamentoBlueSoftNotasFiscais.Name = "dtgFaturamentoBlueSoftNotasFiscais";
            this.dtgFaturamentoBlueSoftNotasFiscais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFaturamentoBlueSoftNotasFiscais.Size = new System.Drawing.Size(889, 163);
            this.dtgFaturamentoBlueSoftNotasFiscais.TabIndex = 179;
            this.dtgFaturamentoBlueSoftNotasFiscais.SelectionChanged += new System.EventHandler(this.dtgFaturamentoBlueSoftNotasFiscais_SelectionChanged);
            // 
            // dtgfat_base_empresa
            // 
            this.dtgfat_base_empresa.DataPropertyName = "CdEmpresa";
            this.dtgfat_base_empresa.HeaderText = "Empresa";
            this.dtgfat_base_empresa.Name = "dtgfat_base_empresa";
            this.dtgfat_base_empresa.Width = 25;
            // 
            // dtgfat_base_Operacao
            // 
            this.dtgfat_base_Operacao.DataPropertyName = "CdOperacao";
            this.dtgfat_base_Operacao.HeaderText = "Operação";
            this.dtgfat_base_Operacao.Name = "dtgfat_base_Operacao";
            this.dtgfat_base_Operacao.Width = 25;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "VENDEDOR";
            this.dataGridViewTextBoxColumn10.HeaderText = "Vend Nome";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CLIENTE";
            this.dataGridViewTextBoxColumn12.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // PedidoClienteCPFCNPJ
            // 
            this.PedidoClienteCPFCNPJ.DataPropertyName = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.HeaderText = "CNPJ";
            this.PedidoClienteCPFCNPJ.Name = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.Width = 45;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumeroPedidoBlueSoft";
            this.dataGridViewTextBoxColumn1.HeaderText = "N. Ped";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NumeroNotaFiscal";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nfv N.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 45;
            // 
            // dgtCancelada
            // 
            this.dgtCancelada.DataPropertyName = "statusnotacancelamento";
            this.dgtCancelada.HeaderText = "Cancelada";
            this.dgtCancelada.Name = "dgtCancelada";
            this.dgtCancelada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgtCancelada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgtCancelada.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NumeroNotaFiscalDevolucao";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nfd N.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DataPedido";
            this.dataGridViewTextBoxColumn4.HeaderText = "Data Ped";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DataNotaFiscal";
            this.dataGridViewTextBoxColumn5.HeaderText = "Data Nf";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PedidoStatus";
            this.dataGridViewTextBoxColumn6.HeaderText = "Sit Ped";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PedidoPrazoPagamento";
            this.dataGridViewTextBoxColumn7.HeaderText = "Prazo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VendedorKey";
            this.dataGridViewTextBoxColumn8.HeaderText = "Vkey";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PedidoVendedorCPFCNPJ";
            this.dataGridViewTextBoxColumn9.HeaderText = "VCPF";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 45;
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.Image = global::Pag_Wpf.Properties.Resources.detalhe;
            this.cmdDetalhe.Location = new System.Drawing.Point(727, 226);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(39, 23);
            this.cmdDetalhe.TabIndex = 180;
            this.cmdDetalhe.UseVisualStyleBackColor = true;
            this.cmdDetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // txtNotaFiscalSelecionada
            // 
            this.txtNotaFiscalSelecionada.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtNotaFiscalSelecionada.Enabled = false;
            this.txtNotaFiscalSelecionada.Location = new System.Drawing.Point(772, 228);
            this.txtNotaFiscalSelecionada.Name = "txtNotaFiscalSelecionada";
            this.txtNotaFiscalSelecionada.Size = new System.Drawing.Size(132, 20);
            this.txtNotaFiscalSelecionada.TabIndex = 181;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 182;
            this.label3.Text = "Consultar Nota Fiscal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 184;
            this.label5.Text = "Itens";
            // 
            // txtQtdeItens
            // 
            this.txtQtdeItens.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtQtdeItens.Enabled = false;
            this.txtQtdeItens.Location = new System.Drawing.Point(328, 551);
            this.txtQtdeItens.Name = "txtQtdeItens";
            this.txtQtdeItens.Size = new System.Drawing.Size(53, 20);
            this.txtQtdeItens.TabIndex = 183;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 186;
            this.label6.Text = "Valor Nota Fiscal";
            // 
            // txtValorNotaFiscal
            // 
            this.txtValorNotaFiscal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtValorNotaFiscal.Enabled = false;
            this.txtValorNotaFiscal.Location = new System.Drawing.Point(387, 551);
            this.txtValorNotaFiscal.Name = "txtValorNotaFiscal";
            this.txtValorNotaFiscal.Size = new System.Drawing.Size(132, 20);
            this.txtValorNotaFiscal.TabIndex = 185;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 188;
            this.label7.Text = "Valor Verba";
            // 
            // txtValorVerba
            // 
            this.txtValorVerba.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtValorVerba.Enabled = false;
            this.txtValorVerba.Location = new System.Drawing.Point(528, 551);
            this.txtValorVerba.Name = "txtValorVerba";
            this.txtValorVerba.Size = new System.Drawing.Size(132, 20);
            this.txtValorVerba.TabIndex = 187;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(663, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 190;
            this.label8.Text = "Desconto Financeiro";
            // 
            // txtValorDescontoFinanceiro
            // 
            this.txtValorDescontoFinanceiro.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtValorDescontoFinanceiro.Enabled = false;
            this.txtValorDescontoFinanceiro.Location = new System.Drawing.Point(666, 551);
            this.txtValorDescontoFinanceiro.Name = "txtValorDescontoFinanceiro";
            this.txtValorDescontoFinanceiro.Size = new System.Drawing.Size(132, 20);
            this.txtValorDescontoFinanceiro.TabIndex = 189;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 13);
            this.label9.TabIndex = 192;
            this.label9.Text = "N. de Documentos Fiscais Encontrados";
            // 
            // txtNDocumentosFiscaisEncontrados
            // 
            this.txtNDocumentosFiscaisEncontrados.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtNDocumentosFiscaisEncontrados.Enabled = false;
            this.txtNDocumentosFiscaisEncontrados.Location = new System.Drawing.Point(219, 231);
            this.txtNDocumentosFiscaisEncontrados.Name = "txtNDocumentosFiscaisEncontrados";
            this.txtNDocumentosFiscaisEncontrados.Size = new System.Drawing.Size(132, 20);
            this.txtNDocumentosFiscaisEncontrados.TabIndex = 191;
            // 
            // LBLInfo
            // 
            this.LBLInfo.AutoSize = true;
            this.LBLInfo.Location = new System.Drawing.Point(12, 551);
            this.LBLInfo.Name = "LBLInfo";
            this.LBLInfo.Size = new System.Drawing.Size(0, 13);
            this.LBLInfo.TabIndex = 193;
            // 
            // FrmXFaturamentoBlueSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 579);
            this.Controls.Add(this.LBLInfo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNDocumentosFiscaisEncontrados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtValorDescontoFinanceiro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtValorVerba);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValorNotaFiscal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQtdeItens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNotaFiscalSelecionada);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.dtgFaturamentoBlueSoftNotasFiscais);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.DtpFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpInicial);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtgFaturamentoBlueSoft);
            this.Controls.Add(this.txtCdProdutoTgt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXFaturamentoBlueSoft";
            this.Text = "FrmXFaturamentoBlueSoft";
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFaturamentoBlueSoftNotasFiscais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCdProdutoTgt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgFaturamentoBlueSoft;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker DtpInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.DataGridView dtgFaturamentoBlueSoftNotasFiscais;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.TextBox txtNotaFiscalSelecionada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQtdeItens;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValorNotaFiscal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValorVerba;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorDescontoFinanceiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNDocumentosFiscaisEncontrados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgfat_base_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgfat_base_Operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoClienteCPFCNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgtCancelada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoProdutoKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaFiscalProdutoRelacionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoProdutoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoVolumeFaturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoProdutoKeyUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoUnitarioFatorEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumeUnitarioCalculado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCustoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaFiscalValorBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescontoFinanceiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn VerbaVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentualComissaoVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoPrecoAplicado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoPrecoTabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoEmbalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroNotaFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPedidoBlueSoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroNotaFiscalDevolucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgItens_verba_calculada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgiten_cd_barra;
        private System.Windows.Forms.Label LBLInfo;
    }
}