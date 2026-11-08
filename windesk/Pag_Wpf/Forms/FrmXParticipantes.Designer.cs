namespace Pag_Wpf.Forms
{
    partial class FrmXParticipantes
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
            this.dtgParticipantes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoClienteCPFCNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdAtualizarBase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgParticipantes
            // 
            this.dtgParticipantes.AllowUserToAddRows = false;
            this.dtgParticipantes.AllowUserToDeleteRows = false;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.PedidoClienteCPFCNPJ});
            this.dtgParticipantes.Location = new System.Drawing.Point(12, 47);
            this.dtgParticipantes.Name = "dtgParticipantes";
            this.dtgParticipantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantes.Size = new System.Drawing.Size(889, 291);
            this.dtgParticipantes.TabIndex = 183;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CLIENTE";
            this.dataGridViewTextBoxColumn12.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // PedidoClienteCPFCNPJ
            // 
            this.PedidoClienteCPFCNPJ.DataPropertyName = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.HeaderText = "CNPJ";
            this.PedidoClienteCPFCNPJ.Name = "PedidoClienteCPFCNPJ";
            this.PedidoClienteCPFCNPJ.Width = 45;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::Pag_Wpf.Properties.Resources.atualiza;
            this.cmdBuscar.Location = new System.Drawing.Point(862, 18);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(39, 23);
            this.cmdBuscar.TabIndex = 182;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(12, 21);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(215, 20);
            this.txtDescricao.TabIndex = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Nome";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(801, 344);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(100, 23);
            this.cmdSair.TabIndex = 184;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            // 
            // cmdAtualizarBase
            // 
            this.cmdAtualizarBase.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cmdAtualizarBase.Location = new System.Drawing.Point(817, 19);
            this.cmdAtualizarBase.Name = "cmdAtualizarBase";
            this.cmdAtualizarBase.Size = new System.Drawing.Size(39, 23);
            this.cmdAtualizarBase.TabIndex = 185;
            this.cmdAtualizarBase.Text = "B";
            this.cmdAtualizarBase.UseVisualStyleBackColor = false;
            this.cmdAtualizarBase.Click += new System.EventHandler(this.cmdAtualizarBase_Click);
            // 
            // FrmXParticipantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 379);
            this.Controls.Add(this.cmdAtualizarBase);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.dtgParticipantes);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXParticipantes";
            this.Text = "Participantes";
            ((System.ComponentModel.ISupportInitialize)(this.dtgParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgParticipantes;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidoClienteCPFCNPJ;
        private System.Windows.Forms.Button cmdAtualizarBase;
    }
}