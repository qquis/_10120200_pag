namespace Pag_Wpf.Forms
{
    partial class FrmXIntegracao
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
            this.DtgIntegracoes = new System.Windows.Forms.DataGridView();
            this.DtgIntegracoes_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgIntegracoes_Sequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtgIntegracaoCheckBoxAtualizar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.PrgPagAtualizaProduto = new System.Windows.Forms.ProgressBar();
            this.LBL_INFO_PROGRESS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSelecionarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIntegracoes)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgIntegracoes
            // 
            this.DtgIntegracoes.AllowUserToAddRows = false;
            this.DtgIntegracoes.AllowUserToDeleteRows = false;
            this.DtgIntegracoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIntegracoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DtgIntegracoes_Descricao,
            this.DtgIntegracoes_Sequencial,
            this.DtgIntegracaoCheckBoxAtualizar});
            this.DtgIntegracoes.Location = new System.Drawing.Point(12, 33);
            this.DtgIntegracoes.Name = "DtgIntegracoes";
            this.DtgIntegracoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIntegracoes.Size = new System.Drawing.Size(686, 289);
            this.DtgIntegracoes.TabIndex = 186;
            // 
            // DtgIntegracoes_Descricao
            // 
            this.DtgIntegracoes_Descricao.DataPropertyName = "Descricao";
            this.DtgIntegracoes_Descricao.HeaderText = "Descricao";
            this.DtgIntegracoes_Descricao.Name = "DtgIntegracoes_Descricao";
            this.DtgIntegracoes_Descricao.ReadOnly = true;
            this.DtgIntegracoes_Descricao.Width = 400;
            // 
            // DtgIntegracoes_Sequencial
            // 
            this.DtgIntegracoes_Sequencial.DataPropertyName = "SeqIntegracao";
            this.DtgIntegracoes_Sequencial.HeaderText = "Sequencial ";
            this.DtgIntegracoes_Sequencial.Name = "DtgIntegracoes_Sequencial";
            this.DtgIntegracoes_Sequencial.ReadOnly = true;
            // 
            // DtgIntegracaoCheckBoxAtualizar
            // 
            this.DtgIntegracaoCheckBoxAtualizar.HeaderText = "Atualizar";
            this.DtgIntegracaoCheckBoxAtualizar.Name = "DtgIntegracaoCheckBoxAtualizar";
            this.DtgIntegracaoCheckBoxAtualizar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgIntegracaoCheckBoxAtualizar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 189;
            this.label1.Text = "Atualizar itens selecionados";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(598, 327);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 190;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(659, 4);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 191;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // PrgPagAtualizaProduto
            // 
            this.PrgPagAtualizaProduto.Location = new System.Drawing.Point(310, 328);
            this.PrgPagAtualizaProduto.Name = "PrgPagAtualizaProduto";
            this.PrgPagAtualizaProduto.Size = new System.Drawing.Size(282, 23);
            this.PrgPagAtualizaProduto.TabIndex = 196;
            // 
            // LBL_INFO_PROGRESS
            // 
            this.LBL_INFO_PROGRESS.AutoSize = true;
            this.LBL_INFO_PROGRESS.Location = new System.Drawing.Point(11, 328);
            this.LBL_INFO_PROGRESS.Name = "LBL_INFO_PROGRESS";
            this.LBL_INFO_PROGRESS.Size = new System.Drawing.Size(0, 13);
            this.LBL_INFO_PROGRESS.TabIndex = 195;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 198;
            this.label3.Text = "Selecionar todos";
            // 
            // cmdSelecionarTodos
            // 
            this.cmdSelecionarTodos.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdSelecionarTodos.Location = new System.Drawing.Point(441, 4);
            this.cmdSelecionarTodos.Name = "cmdSelecionarTodos";
            this.cmdSelecionarTodos.Size = new System.Drawing.Size(39, 23);
            this.cmdSelecionarTodos.TabIndex = 197;
            this.cmdSelecionarTodos.UseVisualStyleBackColor = true;
            this.cmdSelecionarTodos.Click += new System.EventHandler(this.cmdSelecionarTodos_Click);
            // 
            // FrmXIntegracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 355);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSelecionarTodos);
            this.Controls.Add(this.PrgPagAtualizaProduto);
            this.Controls.Add(this.LBL_INFO_PROGRESS);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtgIntegracoes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXIntegracao";
            this.Text = "FrmXIntegracao";
            ((System.ComponentModel.ISupportInitialize)(this.DtgIntegracoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgIntegracoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.ProgressBar PrgPagAtualizaProduto;
        private System.Windows.Forms.Label LBL_INFO_PROGRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgIntegracoes_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DtgIntegracoes_Sequencial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DtgIntegracaoCheckBoxAtualizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelecionarTodos;
    }
}