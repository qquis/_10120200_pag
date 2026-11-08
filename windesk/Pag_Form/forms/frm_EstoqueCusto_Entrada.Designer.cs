namespace Pag_Form.forms
{
    partial class frm_EstoqueCusto_Entrada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.cmdAtualiza = new System.Windows.Forms.Button();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtg_Nota_Fiscal_Entrada = new System.Windows.Forms.DataGridView();
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_CFOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_pr_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_Fator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcdprodutobluesoft = new System.Windows.Forms.TextBox();
            this.txtcdproduto = new System.Windows.Forms.TextBox();
            this.txtdescricao = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.dtp_Custo_Entrada_Data_Final = new System.Windows.Forms.DateTimePicker();
            this.dtp_Custo_Entrada_Data_Inicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtece_nf_numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnome_razao = new System.Windows.Forms.TextBox();
            this.chart_entrada_dia_custo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Nota_Fiscal_Entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_entrada_dia_custo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAtualiza
            // 
            this.cmdAtualiza.BackColor = System.Drawing.Color.AliceBlue;
            this.cmdAtualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAtualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdAtualiza.ForeColor = System.Drawing.Color.Blue;
            this.cmdAtualiza.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAtualiza.Location = new System.Drawing.Point(855, 8);
            this.cmdAtualiza.Name = "cmdAtualiza";
            this.cmdAtualiza.Size = new System.Drawing.Size(100, 30);
            this.cmdAtualiza.TabIndex = 241;
            this.cmdAtualiza.Text = "Pesquisar";
            this.cmdAtualiza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAtualiza.UseVisualStyleBackColor = false;
            this.cmdAtualiza.Click += new System.EventHandler(this.cmdAtualiza_Click);
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(956, 8);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 240;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1058, 35);
            this.label12.TabIndex = 239;
            this.label12.Text = "Estoque / Custo de Produtos | Entradas";
            // 
            // dtg_Nota_Fiscal_Entrada
            // 
            this.dtg_Nota_Fiscal_Entrada.AllowUserToAddRows = false;
            this.dtg_Nota_Fiscal_Entrada.AllowUserToDeleteRows = false;
            this.dtg_Nota_Fiscal_Entrada.AllowUserToResizeRows = false;
            this.dtg_Nota_Fiscal_Entrada.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_Nota_Fiscal_Entrada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_Nota_Fiscal_Entrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Nota_Fiscal_Entrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto,
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft,
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero,
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie,
            this.dtg_Nota_Fiscal_Entrada_CFOP,
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao,
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento,
            this.dtg_Nota_Fiscal_Entrada_pr_descricao,
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde,
            this.dtg_Nota_Fiscal_Entrada_Fator,
            this.dtg_Nota_Fiscal_Entrada_Valor,
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto,
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_Nota_Fiscal_Entrada.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtg_Nota_Fiscal_Entrada.Location = new System.Drawing.Point(4, 91);
            this.dtg_Nota_Fiscal_Entrada.Name = "dtg_Nota_Fiscal_Entrada";
            this.dtg_Nota_Fiscal_Entrada.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_Nota_Fiscal_Entrada.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtg_Nota_Fiscal_Entrada.RowHeadersVisible = false;
            this.dtg_Nota_Fiscal_Entrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_Nota_Fiscal_Entrada.Size = new System.Drawing.Size(1048, 228);
            this.dtg_Nota_Fiscal_Entrada.TabIndex = 242;
            // 
            // dtg_Nota_Fiscal_Entrada_pr_cdproduto
            // 
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.DataPropertyName = "pr_cdproduto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.HeaderText = "Cód Pag";
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.Name = "dtg_Nota_Fiscal_Entrada_pr_cdproduto";
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_pr_cdproduto.Width = 50;
            // 
            // dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft
            // 
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.DataPropertyName = "prb_cdprodutobluesoft";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.HeaderText = "Cód Blue";
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.Name = "dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft";
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft.Width = 50;
            // 
            // dtg_Nota_Fiscal_Entrada_ece_nf_numero
            // 
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero.DataPropertyName = "ece_nf_numero";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero.HeaderText = "Nota Fiscal";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero.Name = "dtg_Nota_Fiscal_Entrada_ece_nf_numero";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_ece_nf_numero.Width = 80;
            // 
            // dtg_Nota_Fiscal_Entrada_ece_nf_serie
            // 
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie.DataPropertyName = "ece_nf_serie";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie.HeaderText = "S";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie.Name = "dtg_Nota_Fiscal_Entrada_ece_nf_serie";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_ece_nf_serie.Width = 30;
            // 
            // dtg_Nota_Fiscal_Entrada_CFOP
            // 
            this.dtg_Nota_Fiscal_Entrada_CFOP.DataPropertyName = "ece_nf_cfop";
            this.dtg_Nota_Fiscal_Entrada_CFOP.HeaderText = "CFOP";
            this.dtg_Nota_Fiscal_Entrada_CFOP.Name = "dtg_Nota_Fiscal_Entrada_CFOP";
            this.dtg_Nota_Fiscal_Entrada_CFOP.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_CFOP.Width = 50;
            // 
            // dtg_Nota_Fiscal_Entrada_Nome_Razao
            // 
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao.DataPropertyName = "nome_razao";
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao.HeaderText = "Razão Social";
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao.Name = "dtg_Nota_Fiscal_Entrada_Nome_Razao";
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_Nome_Razao.Width = 120;
            // 
            // dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento
            // 
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento.DataPropertyName = "ece_nf_datarecebimento";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento.HeaderText = "Data";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento.Name = "dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento";
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento.Width = 70;
            // 
            // dtg_Nota_Fiscal_Entrada_pr_descricao
            // 
            this.dtg_Nota_Fiscal_Entrada_pr_descricao.DataPropertyName = "pr_descricao";
            this.dtg_Nota_Fiscal_Entrada_pr_descricao.HeaderText = "Descrição";
            this.dtg_Nota_Fiscal_Entrada_pr_descricao.Name = "dtg_Nota_Fiscal_Entrada_pr_descricao";
            this.dtg_Nota_Fiscal_Entrada_pr_descricao.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_pr_descricao.Width = 280;
            // 
            // dtg_Nota_Fiscal_Entrada_ece_i_qtde
            // 
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.DataPropertyName = "df_nf_i_qtde";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.HeaderText = "Nf Qtde";
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.Name = "dtg_Nota_Fiscal_Entrada_ece_i_qtde";
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_ece_i_qtde.Width = 50;
            // 
            // dtg_Nota_Fiscal_Entrada_Fator
            // 
            this.dtg_Nota_Fiscal_Entrada_Fator.DataPropertyName = "df_nf_i_fator_estoque";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            this.dtg_Nota_Fiscal_Entrada_Fator.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtg_Nota_Fiscal_Entrada_Fator.HeaderText = "Fator";
            this.dtg_Nota_Fiscal_Entrada_Fator.Name = "dtg_Nota_Fiscal_Entrada_Fator";
            this.dtg_Nota_Fiscal_Entrada_Fator.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_Fator.Width = 50;
            // 
            // dtg_Nota_Fiscal_Entrada_Valor
            // 
            this.dtg_Nota_Fiscal_Entrada_Valor.DataPropertyName = "df_nf_i_valor";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.dtg_Nota_Fiscal_Entrada_Valor.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtg_Nota_Fiscal_Entrada_Valor.HeaderText = "Nf Valor";
            this.dtg_Nota_Fiscal_Entrada_Valor.Name = "dtg_Nota_Fiscal_Entrada_Valor";
            this.dtg_Nota_Fiscal_Entrada_Valor.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_Valor.Width = 70;
            // 
            // dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto
            // 
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.DataPropertyName = "ece_i_custo_bruto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N4";
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.HeaderText = "Vl Ult Entrada";
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.Name = "dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto";
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.ReadOnly = true;
            this.dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto.Width = 60;
            // 
            // dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento
            // 
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento.DataPropertyName = "ret_TipoProcessamento";
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento.HeaderText = "Tipo Processamento";
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento.Name = "dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento";
            this.dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(498, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 21);
            this.label8.TabIndex = 248;
            this.label8.Text = "Descrição";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(401, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 247;
            this.label6.Text = "Código BlueSoft";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(311, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 21);
            this.label5.TabIndex = 246;
            this.label5.Text = "Código Pag";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcdprodutobluesoft
            // 
            this.txtcdprodutobluesoft.Location = new System.Drawing.Point(401, 66);
            this.txtcdprodutobluesoft.Name = "txtcdprodutobluesoft";
            this.txtcdprodutobluesoft.Size = new System.Drawing.Size(94, 20);
            this.txtcdprodutobluesoft.TabIndex = 244;
            this.txtcdprodutobluesoft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcdproduto
            // 
            this.txtcdproduto.AcceptsTab = true;
            this.txtcdproduto.Location = new System.Drawing.Point(311, 66);
            this.txtcdproduto.Name = "txtcdproduto";
            this.txtcdproduto.Size = new System.Drawing.Size(86, 20);
            this.txtcdproduto.TabIndex = 243;
            this.txtcdproduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtdescricao
            // 
            this.txtdescricao.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtdescricao.Location = new System.Drawing.Point(497, 66);
            this.txtdescricao.Name = "txtdescricao";
            this.txtdescricao.Size = new System.Drawing.Size(282, 20);
            this.txtdescricao.TabIndex = 245;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.SlateGray;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(107, 63);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 21);
            this.label28.TabIndex = 263;
            this.label28.Text = "à";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_Custo_Entrada_Data_Final
            // 
            this.dtp_Custo_Entrada_Data_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Custo_Entrada_Data_Final.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Custo_Entrada_Data_Final.Location = new System.Drawing.Point(135, 64);
            this.dtp_Custo_Entrada_Data_Final.Name = "dtp_Custo_Entrada_Data_Final";
            this.dtp_Custo_Entrada_Data_Final.Size = new System.Drawing.Size(84, 21);
            this.dtp_Custo_Entrada_Data_Final.TabIndex = 262;
            // 
            // dtp_Custo_Entrada_Data_Inicial
            // 
            this.dtp_Custo_Entrada_Data_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Custo_Entrada_Data_Inicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Custo_Entrada_Data_Inicial.Location = new System.Drawing.Point(4, 63);
            this.dtp_Custo_Entrada_Data_Inicial.Name = "dtp_Custo_Entrada_Data_Inicial";
            this.dtp_Custo_Entrada_Data_Inicial.Size = new System.Drawing.Size(100, 21);
            this.dtp_Custo_Entrada_Data_Inicial.TabIndex = 261;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 21);
            this.label1.TabIndex = 264;
            this.label1.Text = "Descrição";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(223, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 266;
            this.label2.Text = "Nota Fiscal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtece_nf_numero
            // 
            this.txtece_nf_numero.AcceptsTab = true;
            this.txtece_nf_numero.Location = new System.Drawing.Point(223, 65);
            this.txtece_nf_numero.Name = "txtece_nf_numero";
            this.txtece_nf_numero.Size = new System.Drawing.Size(85, 20);
            this.txtece_nf_numero.TabIndex = 265;
            this.txtece_nf_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(812, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 21);
            this.label3.TabIndex = 268;
            this.label3.Text = "Fornecedor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnome_razao
            // 
            this.txtnome_razao.AcceptsTab = true;
            this.txtnome_razao.Location = new System.Drawing.Point(812, 66);
            this.txtnome_razao.Name = "txtnome_razao";
            this.txtnome_razao.Size = new System.Drawing.Size(240, 20);
            this.txtnome_razao.TabIndex = 267;
            // 
            // chart_entrada_dia_custo
            // 
            this.chart_entrada_dia_custo.BorderSkin.BorderWidth = 0;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 10;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Rotation = 20;
            chartArea1.Name = "ChartArea1";
            this.chart_entrada_dia_custo.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_entrada_dia_custo.Legends.Add(legend1);
            this.chart_entrada_dia_custo.Location = new System.Drawing.Point(4, 325);
            this.chart_entrada_dia_custo.Name = "chart_entrada_dia_custo";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "N2";
            series1.Legend = "Legend1";
            series1.Name = "Valor";
            series1.XValueMember = "ece_nf_datarecebimento";
            series1.YValueMembers = "ece_i_custo_bruto";
            this.chart_entrada_dia_custo.Series.Add(series1);
            this.chart_entrada_dia_custo.Size = new System.Drawing.Size(1048, 204);
            this.chart_entrada_dia_custo.TabIndex = 269;
            this.chart_entrada_dia_custo.Text = "Variação Custo Unitário";
            title1.Name = "Title1";
            title1.Text = "Custo Unitário";
            this.chart_entrada_dia_custo.Titles.Add(title1);
            // 
            // frm_EstoqueCusto_Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.cmdsair;
            this.ClientSize = new System.Drawing.Size(1064, 541);
            this.Controls.Add(this.chart_entrada_dia_custo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnome_razao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtece_nf_numero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dtp_Custo_Entrada_Data_Final);
            this.Controls.Add(this.dtp_Custo_Entrada_Data_Inicial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtcdprodutobluesoft);
            this.Controls.Add(this.txtcdproduto);
            this.Controls.Add(this.txtdescricao);
            this.Controls.Add(this.dtg_Nota_Fiscal_Entrada);
            this.Controls.Add(this.cmdAtualiza);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EstoqueCusto_Entrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[0000] Estoque Custos Entrada";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Nota_Fiscal_Entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_entrada_dia_custo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAtualiza;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtg_Nota_Fiscal_Entrada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcdprodutobluesoft;
        private System.Windows.Forms.TextBox txtcdproduto;
        private System.Windows.Forms.TextBox txtdescricao;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dtp_Custo_Entrada_Data_Final;
        private System.Windows.Forms.DateTimePicker dtp_Custo_Entrada_Data_Inicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtece_nf_numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnome_razao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_entrada_dia_custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_pr_cdproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_prb_cdprodutobluesoft;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ece_nf_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ece_nf_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_CFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_Nome_Razao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ece_nf_datarecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_pr_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ece_i_qtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_Fator;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ece_i_custo_bruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_Nota_Fiscal_Entrada_ret_TipoProcessamento;
    }
}