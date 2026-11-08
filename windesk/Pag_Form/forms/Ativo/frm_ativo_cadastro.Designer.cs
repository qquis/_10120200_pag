namespace Pag_Form.forms.Ativo
{
    partial class frm_ativo_cadastro
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
            System.Windows.Forms.TabPage tabinfo_Veiculo;
            this.grpinfo_veiculo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtat_veiculo_placa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.at_veiculo_ano = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdsair = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdconsultar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtat_seq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtat_descricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbat_tipo_descricao = new System.Windows.Forms.ComboBox();
            this.chkat_status = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabinfo = new System.Windows.Forms.TabControl();
            this.cmdEditar = new System.Windows.Forms.Button();
            this.cmdCancela_Alteracao = new System.Windows.Forms.Button();
            this.cmdEfetivar_dados = new System.Windows.Forms.Button();
            this.cmdIncluir = new System.Windows.Forms.Button();
            tabinfo_Veiculo = new System.Windows.Forms.TabPage();
            tabinfo_Veiculo.SuspendLayout();
            this.grpinfo_veiculo.SuspendLayout();
            this.tabinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabinfo_Veiculo
            // 
            tabinfo_Veiculo.AllowDrop = true;
            tabinfo_Veiculo.BackColor = System.Drawing.Color.LightSteelBlue;
            tabinfo_Veiculo.Controls.Add(this.grpinfo_veiculo);
            tabinfo_Veiculo.Controls.Add(this.label4);
            tabinfo_Veiculo.Location = new System.Drawing.Point(4, 25);
            tabinfo_Veiculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabinfo_Veiculo.Name = "tabinfo_Veiculo";
            tabinfo_Veiculo.Size = new System.Drawing.Size(1012, 384);
            tabinfo_Veiculo.TabIndex = 3;
            tabinfo_Veiculo.Text = "Veículo";
            // 
            // grpinfo_veiculo
            // 
            this.grpinfo_veiculo.Controls.Add(this.label7);
            this.grpinfo_veiculo.Controls.Add(this.txtat_veiculo_placa);
            this.grpinfo_veiculo.Controls.Add(this.label5);
            this.grpinfo_veiculo.Controls.Add(this.at_veiculo_ano);
            this.grpinfo_veiculo.Location = new System.Drawing.Point(5, 35);
            this.grpinfo_veiculo.Name = "grpinfo_veiculo";
            this.grpinfo_veiculo.Size = new System.Drawing.Size(1003, 346);
            this.grpinfo_veiculo.TabIndex = 769;
            this.grpinfo_veiculo.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SlateGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(267, 25);
            this.label7.TabIndex = 768;
            this.label7.Text = "Placa";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtat_veiculo_placa
            // 
            this.txtat_veiculo_placa.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtat_veiculo_placa.Enabled = false;
            this.txtat_veiculo_placa.Location = new System.Drawing.Point(282, 19);
            this.txtat_veiculo_placa.Margin = new System.Windows.Forms.Padding(4);
            this.txtat_veiculo_placa.MaxLength = 7;
            this.txtat_veiculo_placa.Name = "txtat_veiculo_placa";
            this.txtat_veiculo_placa.Size = new System.Drawing.Size(137, 22);
            this.txtat_veiculo_placa.TabIndex = 767;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 25);
            this.label5.TabIndex = 764;
            this.label5.Text = "Ano";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // at_veiculo_ano
            // 
            this.at_veiculo_ano.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.at_veiculo_ano.Enabled = false;
            this.at_veiculo_ano.Location = new System.Drawing.Point(282, 50);
            this.at_veiculo_ano.Margin = new System.Windows.Forms.Padding(4);
            this.at_veiculo_ano.Name = "at_veiculo_ano";
            this.at_veiculo_ano.Size = new System.Drawing.Size(137, 22);
            this.at_veiculo_ano.TabIndex = 763;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1003, 27);
            this.label4.TabIndex = 502;
            this.label4.Text = "Informações PAG";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdsair
            // 
            this.cmdsair.BackColor = System.Drawing.Color.White;
            this.cmdsair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsair.ForeColor = System.Drawing.Color.Blue;
            this.cmdsair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdsair.Location = new System.Drawing.Point(890, 10);
            this.cmdsair.Margin = new System.Windows.Forms.Padding(4);
            this.cmdsair.Name = "cmdsair";
            this.cmdsair.Size = new System.Drawing.Size(133, 37);
            this.cmdsair.TabIndex = 297;
            this.cmdsair.Text = "Sair";
            this.cmdsair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdsair.UseVisualStyleBackColor = false;
            this.cmdsair.Click += new System.EventHandler(this.cmdsair_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkOrchid;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Yi Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(7, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1020, 43);
            this.label12.TabIndex = 296;
            this.label12.Text = "Cadastro de Participante";
            // 
            // cmdconsultar
            // 
            this.cmdconsultar.BackColor = System.Drawing.Color.White;
            this.cmdconsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdconsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdconsultar.ForeColor = System.Drawing.Color.Blue;
            this.cmdconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdconsultar.Location = new System.Drawing.Point(755, 10);
            this.cmdconsultar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdconsultar.Name = "cmdconsultar";
            this.cmdconsultar.Size = new System.Drawing.Size(133, 37);
            this.cmdconsultar.TabIndex = 308;
            this.cmdconsultar.Text = "Consultar";
            this.cmdconsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdconsultar.UseVisualStyleBackColor = false;
            this.cmdconsultar.Click += new System.EventHandler(this.cmdconsultar_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SlateGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 63);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 25);
            this.label8.TabIndex = 307;
            this.label8.Text = "Sequencial Pag do Ativo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtat_seq
            // 
            this.txtat_seq.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtat_seq.Location = new System.Drawing.Point(61, 92);
            this.txtat_seq.Margin = new System.Windows.Forms.Padding(4);
            this.txtat_seq.Name = "txtat_seq";
            this.txtat_seq.Size = new System.Drawing.Size(130, 22);
            this.txtat_seq.TabIndex = 306;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SlateGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(199, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 25);
            this.label1.TabIndex = 762;
            this.label1.Text = "Descrição do Ativo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtat_descricao
            // 
            this.txtat_descricao.AutoCompleteCustomSource.AddRange(new string[] {
            "CONTRA FILE"});
            this.txtat_descricao.Enabled = false;
            this.txtat_descricao.Location = new System.Drawing.Point(199, 92);
            this.txtat_descricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtat_descricao.Name = "txtat_descricao";
            this.txtat_descricao.Size = new System.Drawing.Size(500, 22);
            this.txtat_descricao.TabIndex = 761;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SlateGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(706, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 24);
            this.label2.TabIndex = 765;
            this.label2.Text = "Tipo de Registro";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbat_tipo_descricao
            // 
            this.cmbat_tipo_descricao.Enabled = false;
            this.cmbat_tipo_descricao.FormattingEnabled = true;
            this.cmbat_tipo_descricao.Location = new System.Drawing.Point(706, 89);
            this.cmbat_tipo_descricao.Margin = new System.Windows.Forms.Padding(4);
            this.cmbat_tipo_descricao.Name = "cmbat_tipo_descricao";
            this.cmbat_tipo_descricao.Size = new System.Drawing.Size(321, 24);
            this.cmbat_tipo_descricao.TabIndex = 764;
            this.cmbat_tipo_descricao.SelectionChangeCommitted += new System.EventHandler(this.cmbat_tipo_descricao_SelectionChangeCommitted);
            // 
            // chkat_status
            // 
            this.chkat_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkat_status.Enabled = false;
            this.chkat_status.Location = new System.Drawing.Point(840, 121);
            this.chkat_status.Margin = new System.Windows.Forms.Padding(4);
            this.chkat_status.Name = "chkat_status";
            this.chkat_status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkat_status.Size = new System.Drawing.Size(187, 71);
            this.chkat_status.TabIndex = 766;
            this.chkat_status.Text = "Status válido para as operações do Pag (Ativo)";
            this.chkat_status.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1020, 27);
            this.label3.TabIndex = 768;
            this.label3.Text = "Informações Por Tipo de Ativo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabinfo
            // 
            this.tabinfo.AllowDrop = true;
            this.tabinfo.Controls.Add(tabinfo_Veiculo);
            this.tabinfo.Location = new System.Drawing.Point(7, 235);
            this.tabinfo.Margin = new System.Windows.Forms.Padding(1);
            this.tabinfo.Name = "tabinfo";
            this.tabinfo.SelectedIndex = 0;
            this.tabinfo.Size = new System.Drawing.Size(1020, 413);
            this.tabinfo.TabIndex = 769;
            // 
            // cmdEditar
            // 
            this.cmdEditar.BackColor = System.Drawing.Color.White;
            this.cmdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEditar.ForeColor = System.Drawing.Color.Blue;
            this.cmdEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEditar.Location = new System.Drawing.Point(627, 10);
            this.cmdEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(39, 37);
            this.cmdEditar.TabIndex = 772;
            this.cmdEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEditar.UseVisualStyleBackColor = false;
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdCancela_Alteracao
            // 
            this.cmdCancela_Alteracao.BackColor = System.Drawing.Color.White;
            this.cmdCancela_Alteracao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCancela_Alteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancela_Alteracao.ForeColor = System.Drawing.Color.Blue;
            this.cmdCancela_Alteracao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancela_Alteracao.Location = new System.Drawing.Point(669, 10);
            this.cmdCancela_Alteracao.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancela_Alteracao.Name = "cmdCancela_Alteracao";
            this.cmdCancela_Alteracao.Size = new System.Drawing.Size(39, 37);
            this.cmdCancela_Alteracao.TabIndex = 771;
            this.cmdCancela_Alteracao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancela_Alteracao.UseVisualStyleBackColor = false;
            this.cmdCancela_Alteracao.Click += new System.EventHandler(this.cmdCancela_Alteracao_Click);
            // 
            // cmdEfetivar_dados
            // 
            this.cmdEfetivar_dados.BackColor = System.Drawing.Color.White;
            this.cmdEfetivar_dados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEfetivar_dados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEfetivar_dados.ForeColor = System.Drawing.Color.Blue;
            this.cmdEfetivar_dados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEfetivar_dados.Location = new System.Drawing.Point(711, 10);
            this.cmdEfetivar_dados.Margin = new System.Windows.Forms.Padding(4);
            this.cmdEfetivar_dados.Name = "cmdEfetivar_dados";
            this.cmdEfetivar_dados.Size = new System.Drawing.Size(39, 37);
            this.cmdEfetivar_dados.TabIndex = 770;
            this.cmdEfetivar_dados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEfetivar_dados.UseVisualStyleBackColor = false;
            this.cmdEfetivar_dados.Click += new System.EventHandler(this.cmdEfetivar_Click);
            // 
            // cmdIncluir
            // 
            this.cmdIncluir.BackColor = System.Drawing.Color.White;
            this.cmdIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIncluir.ForeColor = System.Drawing.Color.Blue;
            this.cmdIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdIncluir.Location = new System.Drawing.Point(585, 10);
            this.cmdIncluir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdIncluir.Name = "cmdIncluir";
            this.cmdIncluir.Size = new System.Drawing.Size(39, 37);
            this.cmdIncluir.TabIndex = 773;
            this.cmdIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdIncluir.UseVisualStyleBackColor = false;
            this.cmdIncluir.Click += new System.EventHandler(this.cmdIncluir_Click);
            // 
            // frm_ativo_cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1036, 662);
            this.Controls.Add(this.cmdIncluir);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.cmdCancela_Alteracao);
            this.Controls.Add(this.cmdEfetivar_dados);
            this.Controls.Add(this.tabinfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkat_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbat_tipo_descricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtat_descricao);
            this.Controls.Add(this.cmdconsultar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtat_seq);
            this.Controls.Add(this.cmdsair);
            this.Controls.Add(this.label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ativo_cadastro";
            this.Text = "m4351 | Ativo";
            tabinfo_Veiculo.ResumeLayout(false);
            this.grpinfo_veiculo.ResumeLayout(false);
            this.grpinfo_veiculo.PerformLayout();
            this.tabinfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdsair;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdconsultar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtat_seq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtat_descricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbat_tipo_descricao;
        private System.Windows.Forms.CheckBox chkat_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabinfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtat_veiculo_placa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox at_veiculo_ano;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpinfo_veiculo;
        private System.Windows.Forms.Button cmdEditar;
        private System.Windows.Forms.Button cmdCancela_Alteracao;
        private System.Windows.Forms.Button cmdEfetivar_dados;
        private System.Windows.Forms.Button cmdIncluir;
    }
}