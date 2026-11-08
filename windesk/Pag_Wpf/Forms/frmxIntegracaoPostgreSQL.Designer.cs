namespace Pag_Wpf.Forms
{
    partial class frmxIntegracaoPostgreSQL
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
            this.DtgIntegracoesPostGre = new System.Windows.Forms.DataGridView();
            this.DtgIntegracaoCheckBoxAtualizar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtg_col_sis_nucleo_cd_fk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_col_sis_nucleo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtg_col_sis_nucleo_prc_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelecionarTodos = new System.Windows.Forms.Button();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdSql_PostGre = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdPostgre_to_sql = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIntegracoesPostGre)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgIntegracoesPostGre
            // 
            this.DtgIntegracoesPostGre.AllowUserToAddRows = false;
            this.DtgIntegracoesPostGre.AllowUserToDeleteRows = false;
            this.DtgIntegracoesPostGre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIntegracoesPostGre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DtgIntegracaoCheckBoxAtualizar,
            this.dtg_col_sis_nucleo_cd_fk,
            this.dtg_col_sis_nucleo_descricao,
            this.dtg_col_sis_nucleo_prc_cd});
            this.DtgIntegracoesPostGre.Location = new System.Drawing.Point(12, 38);
            this.DtgIntegracoesPostGre.Name = "DtgIntegracoesPostGre";
            this.DtgIntegracoesPostGre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIntegracoesPostGre.Size = new System.Drawing.Size(686, 299);
            this.DtgIntegracoesPostGre.TabIndex = 187;
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
            this.dtg_col_sis_nucleo_cd_fk.Width = 60;
            // 
            // dtg_col_sis_nucleo_descricao
            // 
            this.dtg_col_sis_nucleo_descricao.DataPropertyName = "sis_nucleo_descricao";
            this.dtg_col_sis_nucleo_descricao.HeaderText = "Descrição";
            this.dtg_col_sis_nucleo_descricao.Name = "dtg_col_sis_nucleo_descricao";
            this.dtg_col_sis_nucleo_descricao.Width = 210;
            // 
            // dtg_col_sis_nucleo_prc_cd
            // 
            this.dtg_col_sis_nucleo_prc_cd.DataPropertyName = "sis_nucleo_prc_cd";
            this.dtg_col_sis_nucleo_prc_cd.HeaderText = "Procedimento CD";
            this.dtg_col_sis_nucleo_prc_cd.Name = "dtg_col_sis_nucleo_prc_cd";
            this.dtg_col_sis_nucleo_prc_cd.Width = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Selecionar todos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "Atualizar itens selecionados";
            // 
            // cmdSelecionarTodos
            // 
            this.cmdSelecionarTodos.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdSelecionarTodos.Location = new System.Drawing.Point(471, 9);
            this.cmdSelecionarTodos.Name = "cmdSelecionarTodos";
            this.cmdSelecionarTodos.Size = new System.Drawing.Size(39, 23);
            this.cmdSelecionarTodos.TabIndex = 201;
            this.cmdSelecionarTodos.UseVisualStyleBackColor = true;
            this.cmdSelecionarTodos.Click += new System.EventHandler(this.cmdSelecionarTodos_Click);
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(659, 9);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 200;
            this.cmdAtualizarBase.UseVisualStyleBackColor = true;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(598, 343);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 203;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdSql_PostGre
            // 
            this.cmdSql_PostGre.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdSql_PostGre.Location = new System.Drawing.Point(12, 343);
            this.cmdSql_PostGre.Name = "cmdSql_PostGre";
            this.cmdSql_PostGre.Size = new System.Drawing.Size(39, 23);
            this.cmdSql_PostGre.TabIndex = 204;
            this.cmdSql_PostGre.Text = "|";
            this.cmdSql_PostGre.UseVisualStyleBackColor = true;
            this.cmdSql_PostGre.Click += new System.EventHandler(this.cmdSql_PostGre_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 205;
            this.label2.Text = "Temporário SQL -> Postgre | Produto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 13);
            this.label4.TabIndex = 207;
            this.label4.Text = "Postgre -> Sql (Complemento de Produto)";
            // 
            // cmdPostgre_to_sql
            // 
            this.cmdPostgre_to_sql.Image = global::Pag_Wpf.Properties.Resources.baixo_dupla;
            this.cmdPostgre_to_sql.Location = new System.Drawing.Point(311, 343);
            this.cmdPostgre_to_sql.Name = "cmdPostgre_to_sql";
            this.cmdPostgre_to_sql.Size = new System.Drawing.Size(39, 23);
            this.cmdPostgre_to_sql.TabIndex = 206;
            this.cmdPostgre_to_sql.UseVisualStyleBackColor = true;
            this.cmdPostgre_to_sql.Click += new System.EventHandler(this.cmdPostgre_to_sql_Click);
            // 
            // frmxIntegracaoPostgreSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 374);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdPostgre_to_sql);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSql_PostGre);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSelecionarTodos);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtgIntegracoesPostGre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmxIntegracaoPostgreSQL";
            this.Text = "frmIntegracaoPostgreSQL";
            ((System.ComponentModel.ISupportInitialize)(this.DtgIntegracoesPostGre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgIntegracoesPostGre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSelecionarTodos;
        private System.Windows.Forms.Button cmdAtualizarBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Button cmdSql_PostGre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdPostgre_to_sql;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DtgIntegracaoCheckBoxAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_cd_fk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtg_col_sis_nucleo_prc_cd;
    }
}