namespace Pag_Form.forms.Distribuicao
{
    partial class frm_FV_Comissao_Apuracao
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
            this.cmdConsultar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.cmdConsolidar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCompetencia = new System.Windows.Forms.ComboBox();
            this.dtgC = new System.Windows.Forms.DataGridView();
            this.dtgCcdparticipantevendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCnome_razao_vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCfvc_valor_faturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCfvc_comissao_valor_base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdDetalhe = new System.Windows.Forms.Button();
            this.dtgD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDdatafaturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDseqfaturamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDnumeropedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDdf_nf_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDfv_tabelapreco_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDpercentual_comissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.lbl_valortotalfaturamento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_valorbase = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lbl_cdparticipantevendedor = new System.Windows.Forms.Label();
            this.lblinfo_qtde_lancamentos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgD)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdConsultar
            // 
            this.cmdConsultar.BackColor = System.Drawing.Color.White;
            this.cmdConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsultar.Location = new System.Drawing.Point(621, 10);
            this.cmdConsultar.Name = "cmdConsultar";
            this.cmdConsultar.Size = new System.Drawing.Size(100, 30);
            this.cmdConsultar.TabIndex = 678;
            this.cmdConsultar.Text = "Consultar";
            this.cmdConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsultar.UseVisualStyleBackColor = false;
            this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(912, 32);
            this.label12.TabIndex = 677;
            this.label12.Text = "Distribuição | Consolidar Comissão";
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(822, 10);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 679;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            // 
            // cmdConsolidar
            // 
            this.cmdConsolidar.BackColor = System.Drawing.Color.White;
            this.cmdConsolidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsolidar.ForeColor = System.Drawing.Color.Blue;
            this.cmdConsolidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConsolidar.Location = new System.Drawing.Point(722, 10);
            this.cmdConsolidar.Name = "cmdConsolidar";
            this.cmdConsolidar.Size = new System.Drawing.Size(100, 30);
            this.cmdConsolidar.TabIndex = 680;
            this.cmdConsolidar.Text = "Consolidar";
            this.cmdConsolidar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConsolidar.UseVisualStyleBackColor = false;
            this.cmdConsolidar.Click += new System.EventHandler(this.cmdConsolidar_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.SlateGray;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(12, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 22);
            this.label20.TabIndex = 682;
            this.label20.Text = "Comp.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCompetencia
            // 
            this.cmbCompetencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompetencia.FormattingEnabled = true;
            this.cmbCompetencia.Location = new System.Drawing.Point(96, 42);
            this.cmbCompetencia.Name = "cmbCompetencia";
            this.cmbCompetencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCompetencia.Size = new System.Drawing.Size(123, 23);
            this.cmbCompetencia.TabIndex = 681;
            this.cmbCompetencia.Text = "202401";
            // 
            // dtgC
            // 
            this.dtgC.AllowUserToAddRows = false;
            this.dtgC.AllowUserToDeleteRows = false;
            this.dtgC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgCcdparticipantevendedor,
            this.dtgCnome_razao_vendedor,
            this.dtgCfvc_valor_faturamento,
            this.dtgCfvc_comissao_valor_base});
            this.dtgC.Location = new System.Drawing.Point(12, 91);
            this.dtgC.Name = "dtgC";
            this.dtgC.ReadOnly = true;
            this.dtgC.RowHeadersVisible = false;
            this.dtgC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgC.Size = new System.Drawing.Size(491, 154);
            this.dtgC.TabIndex = 683;
            // 
            // dtgCcdparticipantevendedor
            // 
            this.dtgCcdparticipantevendedor.DataPropertyName = "cdparticipantevendedor";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtgCcdparticipantevendedor.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgCcdparticipantevendedor.HeaderText = "Cod. Vend";
            this.dtgCcdparticipantevendedor.Name = "dtgCcdparticipantevendedor";
            this.dtgCcdparticipantevendedor.ReadOnly = true;
            this.dtgCcdparticipantevendedor.Width = 65;
            // 
            // dtgCnome_razao_vendedor
            // 
            this.dtgCnome_razao_vendedor.DataPropertyName = "nome";
            this.dtgCnome_razao_vendedor.FillWeight = 200F;
            this.dtgCnome_razao_vendedor.HeaderText = "Nome";
            this.dtgCnome_razao_vendedor.Name = "dtgCnome_razao_vendedor";
            this.dtgCnome_razao_vendedor.ReadOnly = true;
            this.dtgCnome_razao_vendedor.Width = 150;
            // 
            // dtgCfvc_valor_faturamento
            // 
            this.dtgCfvc_valor_faturamento.DataPropertyName = "valortotalfaturamento";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.dtgCfvc_valor_faturamento.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgCfvc_valor_faturamento.FillWeight = 65F;
            this.dtgCfvc_valor_faturamento.HeaderText = "Faturamento";
            this.dtgCfvc_valor_faturamento.Name = "dtgCfvc_valor_faturamento";
            this.dtgCfvc_valor_faturamento.ReadOnly = true;
            this.dtgCfvc_valor_faturamento.Width = 105;
            // 
            // dtgCfvc_comissao_valor_base
            // 
            this.dtgCfvc_comissao_valor_base.DataPropertyName = "valorbase";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.dtgCfvc_comissao_valor_base.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgCfvc_comissao_valor_base.FillWeight = 65F;
            this.dtgCfvc_comissao_valor_base.HeaderText = "Valor Base";
            this.dtgCfvc_comissao_valor_base.Name = "dtgCfvc_comissao_valor_base";
            this.dtgCfvc_comissao_valor_base.ReadOnly = true;
            this.dtgCfvc_comissao_valor_base.Width = 105;
            // 
            // cmdDetalhe
            // 
            this.cmdDetalhe.BackColor = System.Drawing.Color.White;
            this.cmdDetalhe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDetalhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDetalhe.ForeColor = System.Drawing.Color.Blue;
            this.cmdDetalhe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDetalhe.Location = new System.Drawing.Point(817, 215);
            this.cmdDetalhe.Name = "cmdDetalhe";
            this.cmdDetalhe.Size = new System.Drawing.Size(100, 30);
            this.cmdDetalhe.TabIndex = 684;
            this.cmdDetalhe.Text = "Detalhe";
            this.cmdDetalhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDetalhe.UseVisualStyleBackColor = false;
            this.cmdDetalhe.Click += new System.EventHandler(this.cmdDetalhe_Click);
            // 
            // dtgD
            // 
            this.dtgD.AllowUserToAddRows = false;
            this.dtgD.AllowUserToDeleteRows = false;
            this.dtgD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dtgDdatafaturamento,
            this.dataGridViewTextBoxColumn2,
            this.dtgDseqfaturamento,
            this.dtgDnumeropedido,
            this.dtgDdf_nf_numero,
            this.dtgDfv_tabelapreco_descricao,
            this.dataGridViewTextBoxColumn3,
            this.dtgDpercentual_comissao,
            this.dataGridViewTextBoxColumn4});
            this.dtgD.Location = new System.Drawing.Point(12, 251);
            this.dtgD.Name = "dtgD";
            this.dtgD.ReadOnly = true;
            this.dtgD.RowHeadersVisible = false;
            this.dtgD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgD.Size = new System.Drawing.Size(905, 289);
            this.dtgD.TabIndex = 685;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cdparticipantevendedor";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn1.HeaderText = "Cod. Vend";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dtgDdatafaturamento
            // 
            this.dtgDdatafaturamento.DataPropertyName = "datafaturamento";
            this.dtgDdatafaturamento.HeaderText = "Data";
            this.dtgDdatafaturamento.Name = "dtgDdatafaturamento";
            this.dtgDdatafaturamento.ReadOnly = true;
            this.dtgDdatafaturamento.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nome_razao_vendedor";
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dtgDseqfaturamento
            // 
            this.dtgDseqfaturamento.DataPropertyName = "seqfaturamento";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgDseqfaturamento.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtgDseqfaturamento.HeaderText = "Seq Pag";
            this.dtgDseqfaturamento.Name = "dtgDseqfaturamento";
            this.dtgDseqfaturamento.ReadOnly = true;
            this.dtgDseqfaturamento.Width = 65;
            // 
            // dtgDnumeropedido
            // 
            this.dtgDnumeropedido.DataPropertyName = "numeropedido";
            this.dtgDnumeropedido.HeaderText = "N. Pedido";
            this.dtgDnumeropedido.Name = "dtgDnumeropedido";
            this.dtgDnumeropedido.ReadOnly = true;
            this.dtgDnumeropedido.Width = 65;
            // 
            // dtgDdf_nf_numero
            // 
            this.dtgDdf_nf_numero.DataPropertyName = "df_nf_numero";
            this.dtgDdf_nf_numero.HeaderText = "Nf. Número";
            this.dtgDdf_nf_numero.Name = "dtgDdf_nf_numero";
            this.dtgDdf_nf_numero.ReadOnly = true;
            this.dtgDdf_nf_numero.Width = 65;
            // 
            // dtgDfv_tabelapreco_descricao
            // 
            this.dtgDfv_tabelapreco_descricao.DataPropertyName = "fv_tabelapreco_descricao";
            this.dtgDfv_tabelapreco_descricao.HeaderText = "Tabela";
            this.dtgDfv_tabelapreco_descricao.Name = "dtgDfv_tabelapreco_descricao";
            this.dtgDfv_tabelapreco_descricao.ReadOnly = true;
            this.dtgDfv_tabelapreco_descricao.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "valortotalfaturamento";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn3.FillWeight = 65F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Faturamento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dtgDpercentual_comissao
            // 
            this.dtgDpercentual_comissao.DataPropertyName = "percentual_comissao";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            this.dtgDpercentual_comissao.DefaultCellStyle = dataGridViewCellStyle15;
            this.dtgDpercentual_comissao.HeaderText = "% Comis";
            this.dtgDpercentual_comissao.Name = "dtgDpercentual_comissao";
            this.dtgDpercentual_comissao.ReadOnly = true;
            this.dtgDpercentual_comissao.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "valorbase";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn4.FillWeight = 65F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor Base";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(509, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 35);
            this.label2.TabIndex = 687;
            this.label2.Text = "Vendedor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_nome
            // 
            this.lbl_nome.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome.ForeColor = System.Drawing.Color.White;
            this.lbl_nome.Location = new System.Drawing.Point(601, 91);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(221, 35);
            this.lbl_nome.TabIndex = 686;
            this.lbl_nome.Tag = "nome";
            this.lbl_nome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_valortotalfaturamento
            // 
            this.lbl_valortotalfaturamento.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_valortotalfaturamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_valortotalfaturamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_valortotalfaturamento.ForeColor = System.Drawing.Color.White;
            this.lbl_valortotalfaturamento.Location = new System.Drawing.Point(601, 130);
            this.lbl_valortotalfaturamento.Name = "lbl_valortotalfaturamento";
            this.lbl_valortotalfaturamento.Size = new System.Drawing.Size(107, 22);
            this.lbl_valortotalfaturamento.TabIndex = 688;
            this.lbl_valortotalfaturamento.Tag = "valortotalfaturamento";
            this.lbl_valortotalfaturamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SlateGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(509, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 41);
            this.label3.TabIndex = 689;
            this.label3.Text = "Valor Total do Faturamento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(509, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 38);
            this.label4.TabIndex = 691;
            this.label4.Text = "Comissão Valor Base";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_valorbase
            // 
            this.lbl_valorbase.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_valorbase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_valorbase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_valorbase.ForeColor = System.Drawing.Color.White;
            this.lbl_valorbase.Location = new System.Drawing.Point(601, 176);
            this.lbl_valorbase.Name = "lbl_valorbase";
            this.lbl_valorbase.Size = new System.Drawing.Size(107, 22);
            this.lbl_valorbase.TabIndex = 690;
            this.lbl_valorbase.Tag = "valorbase";
            this.lbl_valorbase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(399, 65);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(104, 20);
            this.dtpFim.TabIndex = 694;
            this.dtpFim.Value = new System.DateTime(2024, 1, 31, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(289, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 21);
            this.label5.TabIndex = 693;
            this.label5.Text = "Data Emissão do Faturamento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(289, 65);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(104, 20);
            this.dtpInicio.TabIndex = 692;
            this.dtpInicio.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // lbl_cdparticipantevendedor
            // 
            this.lbl_cdparticipantevendedor.BackColor = System.Drawing.Color.SlateGray;
            this.lbl_cdparticipantevendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cdparticipantevendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cdparticipantevendedor.ForeColor = System.Drawing.Color.White;
            this.lbl_cdparticipantevendedor.Location = new System.Drawing.Point(828, 91);
            this.lbl_cdparticipantevendedor.Name = "lbl_cdparticipantevendedor";
            this.lbl_cdparticipantevendedor.Size = new System.Drawing.Size(94, 22);
            this.lbl_cdparticipantevendedor.TabIndex = 695;
            this.lbl_cdparticipantevendedor.Tag = "cdparticipantevendedor";
            this.lbl_cdparticipantevendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblinfo_qtde_lancamentos
            // 
            this.lblinfo_qtde_lancamentos.BackColor = System.Drawing.Color.SlateGray;
            this.lblinfo_qtde_lancamentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblinfo_qtde_lancamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo_qtde_lancamentos.ForeColor = System.Drawing.Color.White;
            this.lblinfo_qtde_lancamentos.Location = new System.Drawing.Point(810, 543);
            this.lblinfo_qtde_lancamentos.Name = "lblinfo_qtde_lancamentos";
            this.lblinfo_qtde_lancamentos.Size = new System.Drawing.Size(107, 22);
            this.lblinfo_qtde_lancamentos.TabIndex = 696;
            this.lblinfo_qtde_lancamentos.Tag = "valorbase";
            this.lblinfo_qtde_lancamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SlateGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(601, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 22);
            this.label6.TabIndex = 697;
            this.label6.Text = "Qtde de Lançamentos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_FV_Comissao_Apuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(929, 565);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblinfo_qtde_lancamentos);
            this.Controls.Add(this.lbl_cdparticipantevendedor);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_valorbase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_valortotalfaturamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.dtgD);
            this.Controls.Add(this.cmdDetalhe);
            this.Controls.Add(this.dtgC);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbCompetencia);
            this.Controls.Add(this.cmdConsolidar);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.cmdConsultar);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_FV_Comissao_Apuracao";
            this.Text = "frm_Distribuicao_Comissao_Apuracao";
            ((System.ComponentModel.ISupportInitialize)(this.dtgC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConsultar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Button cmdConsolidar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbCompetencia;
        private System.Windows.Forms.DataGridView dtgC;
        private System.Windows.Forms.Button cmdDetalhe;
        private System.Windows.Forms.DataGridView dtgD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Label lbl_valortotalfaturamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_valorbase;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCcdparticipantevendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCnome_razao_vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCfvc_valor_faturamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCfvc_comissao_valor_base;
        private System.Windows.Forms.Label lbl_cdparticipantevendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDdatafaturamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDseqfaturamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDnumeropedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDdf_nf_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDfv_tabelapreco_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDpercentual_comissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblinfo_qtde_lancamentos;
        private System.Windows.Forms.Label label6;
    }
}