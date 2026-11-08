namespace Pag_Wpf.Forms
{
    partial class FrmXParticipanteBlueSoft
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
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.dtgParticipantesBlueSoft = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoClienteCPFCNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoEconomico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepresentanteFV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.TxtNomeParticipante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantesBlueSoft)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(817, 29);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 191;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(801, 354);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 190;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // dtgParticipantesBlueSoft
            // 
            this.dtgParticipantesBlueSoft.AllowUserToAddRows = false;
            this.dtgParticipantesBlueSoft.AllowUserToDeleteRows = false;
            this.dtgParticipantesBlueSoft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantesBlueSoft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.Nome,
            this.PedidoClienteCPFCNPJ,
            this.GrupoEconomico,
            this.LimiteCredito,
            this.RepresentanteFV,
            this.Fornecedor});
            this.dtgParticipantesBlueSoft.Location = new System.Drawing.Point(12, 57);
            this.dtgParticipantesBlueSoft.Name = "dtgParticipantesBlueSoft";
            this.dtgParticipantesBlueSoft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantesBlueSoft.Size = new System.Drawing.Size(889, 291);
            this.dtgParticipantesBlueSoft.TabIndex = 189;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CdParticipanteBlueSoft";
            this.dataGridViewTextBoxColumn12.HeaderText = "Participante";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 70;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 250;
            // 
            // PedidoClienteCPFCNPJ
            // 
            this.PedidoClienteCPFCNPJ.DataPropertyName = "CNPJCPF";
            this.PedidoClienteCPFCNPJ.HeaderText = "CNPJ / CPF";
            this.PedidoClienteCPFCNPJ.Name = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.Width = 45;
            // 
            // GrupoEconomico
            // 
            this.GrupoEconomico.DataPropertyName = "ClienteGrupoEconomico";
            this.GrupoEconomico.HeaderText = "Grupo Economico";
            this.GrupoEconomico.Name = "GrupoEconomico";
            this.GrupoEconomico.Width = 150;
            // 
            // LimiteCredito
            // 
            this.LimiteCredito.DataPropertyName = "ClienteLimiteCredito";
            this.LimiteCredito.HeaderText = "Lim Crédito";
            this.LimiteCredito.Name = "LimiteCredito";
            this.LimiteCredito.Width = 70;
            // 
            // RepresentanteFV
            // 
            this.RepresentanteFV.DataPropertyName = "ClienteVendedorCNPJ";
            this.RepresentanteFV.HeaderText = "Representante FV";
            this.RepresentanteFV.Name = "RepresentanteFV";
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(862, 28);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 188;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // TxtNomeParticipante
            // 
            this.TxtNomeParticipante.Location = new System.Drawing.Point(12, 31);
            this.TxtNomeParticipante.Name = "TxtNomeParticipante";
            this.TxtNomeParticipante.Size = new System.Drawing.Size(290, 20);
            this.TxtNomeParticipante.TabIndex = 186;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 187;
            this.label1.Text = "Nome";
            // 
            // FrmXParticipanteBlueSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 398);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.dtgParticipantesBlueSoft);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.TxtNomeParticipante);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXParticipanteBlueSoft";
            this.Text = "FrmXParticipanteBlueSoft";
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantesBlueSoft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.DataGridView dtgParticipantesBlueSoft;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox TxtNomeParticipante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoClienteCPFCNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoEconomico;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepresentanteFV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;

    }
}