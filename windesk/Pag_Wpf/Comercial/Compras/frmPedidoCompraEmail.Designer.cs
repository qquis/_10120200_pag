namespace Pag_Wpf.Comercial.Compras
{
    partial class frmPedidoCompraEmail
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
            this.TXTPedidoCompra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTFornecedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTemail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.CMDEfetiva = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXTPedidoCompra
            // 
            this.TXTPedidoCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTPedidoCompra.Enabled = false;
            this.TXTPedidoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTPedidoCompra.Location = new System.Drawing.Point(291, 33);
            this.TXTPedidoCompra.MaxLength = 0;
            this.TXTPedidoCompra.Name = "TXTPedidoCompra";
            this.TXTPedidoCompra.Size = new System.Drawing.Size(230, 26);
            this.TXTPedidoCompra.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 33);
            this.label5.MinimumSize = new System.Drawing.Size(230, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 22);
            this.label5.TabIndex = 107;
            this.label5.Text = "Pedido de Compra";
            // 
            // TXTFornecedor
            // 
            this.TXTFornecedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTFornecedor.Enabled = false;
            this.TXTFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTFornecedor.Location = new System.Drawing.Point(291, 63);
            this.TXTFornecedor.MaxLength = 0;
            this.TXTFornecedor.Name = "TXTFornecedor";
            this.TXTFornecedor.Size = new System.Drawing.Size(435, 26);
            this.TXTFornecedor.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 63);
            this.label1.MinimumSize = new System.Drawing.Size(230, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 22);
            this.label1.TabIndex = 109;
            this.label1.Text = "Fornecedor";
            // 
            // TXTemail
            // 
            this.TXTemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTemail.Location = new System.Drawing.Point(291, 93);
            this.TXTemail.MaxLength = 0;
            this.TXTemail.Name = "TXTemail";
            this.TXTemail.Size = new System.Drawing.Size(435, 26);
            this.TXTemail.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 93);
            this.label2.MinimumSize = new System.Drawing.Size(230, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 22);
            this.label2.TabIndex = 111;
            this.label2.Text = "E-mail";
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(550, 125);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(85, 32);
            this.CMDCancelar.TabIndex = 114;
            this.CMDCancelar.Text = "Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            this.CMDCancelar.Click += new System.EventHandler(this.CMDCancelar_Click);
            // 
            // CMDEfetiva
            // 
            this.CMDEfetiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDEfetiva.Location = new System.Drawing.Point(641, 125);
            this.CMDEfetiva.Name = "CMDEfetiva";
            this.CMDEfetiva.Size = new System.Drawing.Size(85, 32);
            this.CMDEfetiva.TabIndex = 113;
            this.CMDEfetiva.Text = "Enviar";
            this.CMDEfetiva.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDEfetiva.UseVisualStyleBackColor = true;
            this.CMDEfetiva.Click += new System.EventHandler(this.CMDEfetiva_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(31, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 115;
            this.label4.Text = "Pedido de Compra - E-mail";
            // 
            // frmPedidoCompraEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 171);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDEfetiva);
            this.Controls.Add(this.TXTemail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXTFornecedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTPedidoCompra);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidoCompraEmail";
            this.Text = "frmPedidoCompraEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTPedidoCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTemail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.Button CMDEfetiva;
        private System.Windows.Forms.Label label4;
    }
}