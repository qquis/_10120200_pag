namespace Pag_Wpf.Forms
{
    partial class FrmXContratosItem
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgContratosItem = new System.Windows.Forms.DataGridView();
            this.cmdSair = new System.Windows.Forms.Button();
            this.txtCdOperacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpInicial = new System.Windows.Forms.DateTimePicker();
            this.txtTipoContrato_Descricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCdParticipante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtParticipante_Nome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumeroPedido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumeroNotaFiscal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSeqContrato = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chartInvestimento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DtgContratosItem_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_PRODUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_VLINVESTIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_VLINVESTIMENTOTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_EMBFATURAMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_DTATUALIZACAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_SEQREFNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_QTDENEGOCIADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_QTDEAPLICADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgContratosItem_VALIDAREMBALAGEM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DtgContratosItem_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DtgContratosItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInvestimento)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgContratosItem
            // 
            this.DtgContratosItem.AllowUserToAddRows = false;
            this.DtgContratosItem.AllowUserToDeleteRows = false;
            this.DtgContratosItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgContratosItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DtgContratosItem_DESCRICAO,
            this.DtgContratosItem_PRODUTO,
            this.DtgContratosItem_VLINVESTIMENTO,
            this.DtgContratosItem_VLINVESTIMENTOTOTAL,
            this.DtgContratosItem_EMBFATURAMENTO,
            this.DtgContratosItem_DTATUALIZACAO,
            this.DtgContratosItem_SEQREFNF,
            this.DtgContratosItem_QTDENEGOCIADA,
            this.DtgContratosItem_QTDEAPLICADA,
            this.DtgContratosItem_VALIDAREMBALAGEM,
            this.DtgContratosItem_SEQ});
            this.DtgContratosItem.Location = new System.Drawing.Point(12, 162);
            this.DtgContratosItem.Name = "DtgContratosItem";
            this.DtgContratosItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgContratosItem.Size = new System.Drawing.Size(468, 280);
            this.DtgContratosItem.TabIndex = 185;
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(691, 448);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 187;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // txtCdOperacao
            // 
            this.txtCdOperacao.Location = new System.Drawing.Point(573, 29);
            this.txtCdOperacao.Name = "txtCdOperacao";
            this.txtCdOperacao.Size = new System.Drawing.Size(66, 20);
            this.txtCdOperacao.TabIndex = 188;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 189;
            this.label1.Text = "Operação";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(12, 29);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(429, 20);
            this.txtDescricao.TabIndex = 190;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 191;
            this.label2.Text = "Descrição do Contrato";
            // 
            // DtpFinal
            // 
            this.DtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFinal.Location = new System.Drawing.Point(447, 70);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(96, 20);
            this.DtpFinal.TabIndex = 195;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 194;
            this.label4.Text = "Data Final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 193;
            this.label3.Text = "Data Inicial";
            // 
            // DtpInicial
            // 
            this.DtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicial.Location = new System.Drawing.Point(345, 70);
            this.DtpInicial.Name = "DtpInicial";
            this.DtpInicial.Size = new System.Drawing.Size(96, 20);
            this.DtpInicial.TabIndex = 192;
            // 
            // txtTipoContrato_Descricao
            // 
            this.txtTipoContrato_Descricao.Location = new System.Drawing.Point(12, 70);
            this.txtTipoContrato_Descricao.Name = "txtTipoContrato_Descricao";
            this.txtTipoContrato_Descricao.Size = new System.Drawing.Size(303, 20);
            this.txtTipoContrato_Descricao.TabIndex = 198;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 199;
            this.label5.Text = "Descrição do Tipo de Contrato";
            // 
            // txtCdParticipante
            // 
            this.txtCdParticipante.Location = new System.Drawing.Point(11, 118);
            this.txtCdParticipante.Name = "txtCdParticipante";
            this.txtCdParticipante.Size = new System.Drawing.Size(66, 20);
            this.txtCdParticipante.TabIndex = 200;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 201;
            this.label7.Text = "Participante";
            // 
            // txtParticipante_Nome
            // 
            this.txtParticipante_Nome.Location = new System.Drawing.Point(83, 118);
            this.txtParticipante_Nome.Name = "txtParticipante_Nome";
            this.txtParticipante_Nome.Size = new System.Drawing.Size(304, 20);
            this.txtParticipante_Nome.TabIndex = 202;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 203;
            this.label8.Text = "Nome do Participante";
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Location = new System.Drawing.Point(393, 118);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroPedido.TabIndex = 204;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(390, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 205;
            this.label9.Text = "Número do Pedido";
            // 
            // txtNumeroNotaFiscal
            // 
            this.txtNumeroNotaFiscal.Location = new System.Drawing.Point(519, 118);
            this.txtNumeroNotaFiscal.Name = "txtNumeroNotaFiscal";
            this.txtNumeroNotaFiscal.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroNotaFiscal.TabIndex = 206;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(516, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 207;
            this.label10.Text = "Número da Nota Fiscal";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(752, 29);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 208;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(697, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 209;
            this.label11.Text = "Buscar";
            // 
            // txtSeqContrato
            // 
            this.txtSeqContrato.Location = new System.Drawing.Point(447, 29);
            this.txtSeqContrato.Name = "txtSeqContrato";
            this.txtSeqContrato.Size = new System.Drawing.Size(120, 20);
            this.txtSeqContrato.TabIndex = 210;
            this.txtSeqContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(444, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 211;
            this.label12.Text = "Sequencial de Contrato";
            // 
            // chartInvestimento
            // 
            this.chartInvestimento.BorderlineColor = System.Drawing.SystemColors.Window;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chartInvestimento.ChartAreas.Add(chartArea1);
            this.chartInvestimento.Location = new System.Drawing.Point(486, 162);
            this.chartInvestimento.Name = "chartInvestimento";
            this.chartInvestimento.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Name = "Investimento Aplicado  por Produto";
            series1.XValueMember = "Produto_Descricao";
            series1.YValueMembers = "ValorInvestimentoTotal";
            this.chartInvestimento.Series.Add(series1);
            this.chartInvestimento.Size = new System.Drawing.Size(305, 280);
            this.chartInvestimento.TabIndex = 212;
            // 
            // DtgContratosItem_DESCRICAO
            // 
            this.DtgContratosItem_DESCRICAO.DataPropertyName = "Produto_Descricao";
            this.DtgContratosItem_DESCRICAO.HeaderText = "Descricao";
            this.DtgContratosItem_DESCRICAO.Name = "DtgContratosItem_DESCRICAO";
            this.DtgContratosItem_DESCRICAO.Width = 150;
            // 
            // DtgContratosItem_PRODUTO
            // 
            this.DtgContratosItem_PRODUTO.DataPropertyName = "CdProduto";
            this.DtgContratosItem_PRODUTO.HeaderText = "Produto";
            this.DtgContratosItem_PRODUTO.Name = "DtgContratosItem_PRODUTO";
            this.DtgContratosItem_PRODUTO.Width = 70;
            // 
            // DtgContratosItem_VLINVESTIMENTO
            // 
            this.DtgContratosItem_VLINVESTIMENTO.DataPropertyName = "ValorInvestimento";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DtgContratosItem_VLINVESTIMENTO.DefaultCellStyle = dataGridViewCellStyle1;
            this.DtgContratosItem_VLINVESTIMENTO.HeaderText = "Vl Invest";
            this.DtgContratosItem_VLINVESTIMENTO.Name = "DtgContratosItem_VLINVESTIMENTO";
            this.DtgContratosItem_VLINVESTIMENTO.Width = 60;
            // 
            // DtgContratosItem_VLINVESTIMENTOTOTAL
            // 
            this.DtgContratosItem_VLINVESTIMENTOTOTAL.DataPropertyName = "ValorInvestimentoTotal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DtgContratosItem_VLINVESTIMENTOTOTAL.DefaultCellStyle = dataGridViewCellStyle2;
            this.DtgContratosItem_VLINVESTIMENTOTOTAL.HeaderText = "Vl Inv. Total";
            this.DtgContratosItem_VLINVESTIMENTOTOTAL.Name = "DtgContratosItem_VLINVESTIMENTOTOTAL";
            this.DtgContratosItem_VLINVESTIMENTOTOTAL.Width = 60;
            // 
            // DtgContratosItem_EMBFATURAMENTO
            // 
            this.DtgContratosItem_EMBFATURAMENTO.DataPropertyName = "EmbalagemFaturamento";
            this.DtgContratosItem_EMBFATURAMENTO.HeaderText = "Emb. Faturamento";
            this.DtgContratosItem_EMBFATURAMENTO.Name = "DtgContratosItem_EMBFATURAMENTO";
            this.DtgContratosItem_EMBFATURAMENTO.Width = 25;
            // 
            // DtgContratosItem_DTATUALIZACAO
            // 
            this.DtgContratosItem_DTATUALIZACAO.DataPropertyName = "DataUltimaAtualizacao";
            this.DtgContratosItem_DTATUALIZACAO.HeaderText = "Dt Atualizacao";
            this.DtgContratosItem_DTATUALIZACAO.Name = "DtgContratosItem_DTATUALIZACAO";
            this.DtgContratosItem_DTATUALIZACAO.Width = 50;
            // 
            // DtgContratosItem_SEQREFNF
            // 
            this.DtgContratosItem_SEQREFNF.DataPropertyName = "SeqItem";
            this.DtgContratosItem_SEQREFNF.HeaderText = "Seq Ref Nf";
            this.DtgContratosItem_SEQREFNF.Name = "DtgContratosItem_SEQREFNF";
            this.DtgContratosItem_SEQREFNF.Width = 60;
            // 
            // DtgContratosItem_QTDENEGOCIADA
            // 
            this.DtgContratosItem_QTDENEGOCIADA.DataPropertyName = "EmbalagemEstoqueQtdeNegociada";
            this.DtgContratosItem_QTDENEGOCIADA.HeaderText = "Qtde Negociada";
            this.DtgContratosItem_QTDENEGOCIADA.Name = "DtgContratosItem_QTDENEGOCIADA";
            this.DtgContratosItem_QTDENEGOCIADA.Visible = false;
            this.DtgContratosItem_QTDENEGOCIADA.Width = 60;
            // 
            // DtgContratosItem_QTDEAPLICADA
            // 
            this.DtgContratosItem_QTDEAPLICADA.DataPropertyName = "EmbalagemEstoqueQtdeAplicada";
            this.DtgContratosItem_QTDEAPLICADA.HeaderText = "Qtde Aplicada";
            this.DtgContratosItem_QTDEAPLICADA.Name = "DtgContratosItem_QTDEAPLICADA";
            this.DtgContratosItem_QTDEAPLICADA.Visible = false;
            this.DtgContratosItem_QTDEAPLICADA.Width = 60;
            // 
            // DtgContratosItem_VALIDAREMBALAGEM
            // 
            this.DtgContratosItem_VALIDAREMBALAGEM.DataPropertyName = "ValidarEmbalagem";
            this.DtgContratosItem_VALIDAREMBALAGEM.HeaderText = "Validar Emb";
            this.DtgContratosItem_VALIDAREMBALAGEM.Name = "DtgContratosItem_VALIDAREMBALAGEM";
            this.DtgContratosItem_VALIDAREMBALAGEM.Width = 70;
            // 
            // DtgContratosItem_SEQ
            // 
            this.DtgContratosItem_SEQ.DataPropertyName = "SeqContratoItem";
            this.DtgContratosItem_SEQ.HeaderText = "Seq";
            this.DtgContratosItem_SEQ.Name = "DtgContratosItem_SEQ";
            this.DtgContratosItem_SEQ.Width = 35;
            // 
            // FrmXContratosItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 481);
            this.Controls.Add(this.chartInvestimento);
            this.Controls.Add(this.txtSeqContrato);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtNumeroNotaFiscal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtParticipante_Nome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCdParticipante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTipoContrato_Descricao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DtpFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpInicial);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCdOperacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.DtgContratosItem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXContratosItem";
            this.Text = "FrmXContratosItem";
            ((System.ComponentModel.ISupportInitialize)(this.DtgContratosItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInvestimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgContratosItem;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.TextBox txtCdOperacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpInicial;
        private System.Windows.Forms.TextBox txtTipoContrato_Descricao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCdParticipante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtParticipante_Nome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumeroPedido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumeroNotaFiscal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSeqContrato;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInvestimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_PRODUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_VLINVESTIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_VLINVESTIMENTOTOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_EMBFATURAMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_DTATUALIZACAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_SEQREFNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_QTDENEGOCIADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_QTDEAPLICADA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DtgContratosItem_VALIDAREMBALAGEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgContratosItem_SEQ;
    }
}