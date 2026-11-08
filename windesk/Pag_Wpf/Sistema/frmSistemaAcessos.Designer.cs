namespace Pag_Wpf.Sistema
{
    partial class frmSistemaAcessos
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
            this.TXTCdFormulario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CMBFuncao = new System.Windows.Forms.ComboBox();
            this.LBLDocumento = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTValor = new System.Windows.Forms.TextBox();
            this.TXTDescricaoFormulario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmdCancela = new System.Windows.Forms.Button();
            this.cmdEfetiva = new System.Windows.Forms.Button();
            this.CMBTarefa = new System.Windows.Forms.ComboBox();
            this.CMBParametro = new System.Windows.Forms.ComboBox();
            this.TXTParametro = new System.Windows.Forms.TextBox();
            this.TXTTarefa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TXTCdFormulario
            // 
            this.TXTCdFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTCdFormulario.Enabled = false;
            this.TXTCdFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCdFormulario.Location = new System.Drawing.Point(251, 23);
            this.TXTCdFormulario.MaxLength = 14;
            this.TXTCdFormulario.Name = "TXTCdFormulario";
            this.TXTCdFormulario.Size = new System.Drawing.Size(80, 26);
            this.TXTCdFormulario.TabIndex = 119;
            this.TXTCdFormulario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 96);
            this.label5.MinimumSize = new System.Drawing.Size(200, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 22);
            this.label5.TabIndex = 118;
            this.label5.Text = "Função";
            // 
            // CMBFuncao
            // 
            this.CMBFuncao.DropDownHeight = 150;
            this.CMBFuncao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBFuncao.FormattingEnabled = true;
            this.CMBFuncao.IntegralHeight = false;
            this.CMBFuncao.Location = new System.Drawing.Point(251, 96);
            this.CMBFuncao.Name = "CMBFuncao";
            this.CMBFuncao.Size = new System.Drawing.Size(420, 28);
            this.CMBFuncao.TabIndex = 117;
            // 
            // LBLDocumento
            // 
            this.LBLDocumento.AutoSize = true;
            this.LBLDocumento.BackColor = System.Drawing.Color.Silver;
            this.LBLDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDocumento.Location = new System.Drawing.Point(36, 23);
            this.LBLDocumento.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLDocumento.Name = "LBLDocumento";
            this.LBLDocumento.Size = new System.Drawing.Size(200, 22);
            this.LBLDocumento.TabIndex = 116;
            this.LBLDocumento.Text = "Formulário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 242);
            this.label4.MinimumSize = new System.Drawing.Size(200, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 22);
            this.label4.TabIndex = 115;
            this.label4.Text = "Parametro";
            // 
            // TXTValor
            // 
            this.TXTValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTValor.Location = new System.Drawing.Point(251, 372);
            this.TXTValor.MaxLength = 60;
            this.TXTValor.Name = "TXTValor";
            this.TXTValor.Size = new System.Drawing.Size(420, 26);
            this.TXTValor.TabIndex = 114;
            // 
            // TXTDescricaoFormulario
            // 
            this.TXTDescricaoFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTDescricaoFormulario.Enabled = false;
            this.TXTDescricaoFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDescricaoFormulario.Location = new System.Drawing.Point(337, 23);
            this.TXTDescricaoFormulario.MaximumSize = new System.Drawing.Size(500, 100);
            this.TXTDescricaoFormulario.MaxLength = 14;
            this.TXTDescricaoFormulario.MinimumSize = new System.Drawing.Size(4, 52);
            this.TXTDescricaoFormulario.Multiline = true;
            this.TXTDescricaoFormulario.Name = "TXTDescricaoFormulario";
            this.TXTDescricaoFormulario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXTDescricaoFormulario.Size = new System.Drawing.Size(334, 67);
            this.TXTDescricaoFormulario.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 130);
            this.label1.MinimumSize = new System.Drawing.Size(200, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 22);
            this.label1.TabIndex = 122;
            this.label1.Text = "Tarefa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 372);
            this.label2.MinimumSize = new System.Drawing.Size(200, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 22);
            this.label2.TabIndex = 124;
            this.label2.Text = "Valor";
            // 
            // CmdCancela
            // 
            this.CmdCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancela.Location = new System.Drawing.Point(596, 404);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(75, 33);
            this.CmdCancela.TabIndex = 126;
            this.CmdCancela.Text = "Cancela";
            this.CmdCancela.UseVisualStyleBackColor = true;
            this.CmdCancela.Click += new System.EventHandler(this.CmdCancela_Click);
            // 
            // cmdEfetiva
            // 
            this.cmdEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetiva.Location = new System.Drawing.Point(515, 404);
            this.cmdEfetiva.Name = "cmdEfetiva";
            this.cmdEfetiva.Size = new System.Drawing.Size(75, 33);
            this.cmdEfetiva.TabIndex = 125;
            this.cmdEfetiva.Text = "Efetiva";
            this.cmdEfetiva.UseVisualStyleBackColor = true;
            this.cmdEfetiva.Click += new System.EventHandler(this.cmdEfetiva_Click);
            // 
            // CMBTarefa
            // 
            this.CMBTarefa.DropDownHeight = 150;
            this.CMBTarefa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBTarefa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBTarefa.FormattingEnabled = true;
            this.CMBTarefa.IntegralHeight = false;
            this.CMBTarefa.ItemHeight = 20;
            this.CMBTarefa.Location = new System.Drawing.Point(251, 130);
            this.CMBTarefa.Name = "CMBTarefa";
            this.CMBTarefa.Size = new System.Drawing.Size(420, 28);
            this.CMBTarefa.TabIndex = 127;
            this.CMBTarefa.SelectedIndexChanged += new System.EventHandler(this.CMBTarefa_SelectedIndexChanged);
            // 
            // CMBParametro
            // 
            this.CMBParametro.DropDownHeight = 150;
            this.CMBParametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CMBParametro.FormattingEnabled = true;
            this.CMBParametro.IntegralHeight = false;
            this.CMBParametro.ItemHeight = 20;
            this.CMBParametro.Location = new System.Drawing.Point(251, 242);
            this.CMBParametro.Name = "CMBParametro";
            this.CMBParametro.Size = new System.Drawing.Size(420, 28);
            this.CMBParametro.TabIndex = 128;
            this.CMBParametro.SelectedIndexChanged += new System.EventHandler(this.CMBParametro_SelectedIndexChanged);
            // 
            // TXTParametro
            // 
            this.TXTParametro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTParametro.Enabled = false;
            this.TXTParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTParametro.Location = new System.Drawing.Point(251, 276);
            this.TXTParametro.MaximumSize = new System.Drawing.Size(500, 100);
            this.TXTParametro.MaxLength = 14;
            this.TXTParametro.MinimumSize = new System.Drawing.Size(4, 52);
            this.TXTParametro.Multiline = true;
            this.TXTParametro.Name = "TXTParametro";
            this.TXTParametro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXTParametro.Size = new System.Drawing.Size(420, 67);
            this.TXTParametro.TabIndex = 129;
            // 
            // TXTTarefa
            // 
            this.TXTTarefa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTTarefa.Enabled = false;
            this.TXTTarefa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTTarefa.Location = new System.Drawing.Point(251, 164);
            this.TXTTarefa.MaximumSize = new System.Drawing.Size(500, 100);
            this.TXTTarefa.MaxLength = 14;
            this.TXTTarefa.MinimumSize = new System.Drawing.Size(4, 52);
            this.TXTTarefa.Multiline = true;
            this.TXTTarefa.Name = "TXTTarefa";
            this.TXTTarefa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TXTTarefa.Size = new System.Drawing.Size(420, 67);
            this.TXTTarefa.TabIndex = 130;
            // 
            // frmSistemaAcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 449);
            this.Controls.Add(this.TXTTarefa);
            this.Controls.Add(this.TXTParametro);
            this.Controls.Add(this.CMBParametro);
            this.Controls.Add(this.CMBTarefa);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.cmdEfetiva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTDescricaoFormulario);
            this.Controls.Add(this.TXTCdFormulario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CMBFuncao);
            this.Controls.Add(this.LBLDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TXTValor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSistemaAcessos";
            this.Text = "frmSistemaAcessos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTCdFormulario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMBFuncao;
        private System.Windows.Forms.Label LBLDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTValor;
        private System.Windows.Forms.TextBox TXTDescricaoFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CmdCancela;
        private System.Windows.Forms.Button cmdEfetiva;
        private System.Windows.Forms.ComboBox CMBTarefa;
        private System.Windows.Forms.ComboBox CMBParametro;
        private System.Windows.Forms.TextBox TXTParametro;
        private System.Windows.Forms.TextBox TXTTarefa;
    }
}