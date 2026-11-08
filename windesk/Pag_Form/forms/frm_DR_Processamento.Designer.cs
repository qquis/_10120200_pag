namespace Pag_Form.forms
{
    partial class frm_DR_Processamento
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
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdefetivar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompetencia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(786, 11);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(100, 30);
            this.cmdsair.TabIndex = 241;
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
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(884, 35);
            this.label12.TabIndex = 240;
            this.label12.Text = "Demonstrativo de Resultado Operacional";
            // 
            // cmdefetivar
            // 
            this.cmdefetivar.Location = new System.Drawing.Point(640, 189);
            this.cmdefetivar.Name = "cmdefetivar";
            this.cmdefetivar.Size = new System.Drawing.Size(39, 30);
            this.cmdefetivar.TabIndex = 243;
            this.cmdefetivar.UseVisualStyleBackColor = true;
            this.cmdefetivar.Click += new System.EventHandler(this.cmdefetivar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(339, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 21);
            this.label2.TabIndex = 248;
            this.label2.Text = "Processar competência";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(339, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 250;
            this.label1.Text = "Competência ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCompetencia
            // 
            this.cmbCompetencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompetencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompetencia.FormattingEnabled = true;
            this.cmbCompetencia.Location = new System.Drawing.Point(339, 142);
            this.cmbCompetencia.Name = "cmbCompetencia";
            this.cmbCompetencia.Size = new System.Drawing.Size(193, 24);
            this.cmbCompetencia.TabIndex = 249;
            // 
            // frm_DR_Processamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(904, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCompetencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdefetivar);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DR_Processamento";
            this.Text = "Processamento";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdefetivar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompetencia;
    }
}