namespace Pag_Wpf.Cadastro
{
    partial class FrmLocalizaEndereco
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CMDCancelar = new System.Windows.Forms.Button();
            this.CMDSelecionar = new System.Windows.Forms.Button();
            this.LBLParticipanteLocalizaLogradouro = new System.Windows.Forms.Label();
            this.TXTLogradouro = new System.Windows.Forms.TextBox();
            this.LBLParticipanteLocalizaCep = new System.Windows.Forms.Label();
            this.LBLParticipanteLocalizaTituloEndereco = new System.Windows.Forms.Label();
            this.LBLParticipanteLocalizaTituloLocalizar = new System.Windows.Forms.Label();
            this.LNVertical01 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.LNHorizontal01 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.LNHorizontal02 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.LNHorizontal03 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.LBLParticipanteLocalizaAte = new System.Windows.Forms.Label();
            this.CMDLocalizar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridParticipanteLocalizaEndereco = new System.Windows.Forms.DataGridView();
            this.CodEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnCep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnMunicipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTGColumnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uVWRepresentanteFabricanteListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TXTCep = new System.Windows.Forms.TextBox();
            this.TXTCep_Para = new System.Windows.Forms.TextBox();
            this.CMDLimpar = new System.Windows.Forms.Button();
            this.LBLCODEND = new System.Windows.Forms.Label();
            this.LBLCODIGOENDSELEC = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParticipanteLocalizaEndereco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uVWRepresentanteFabricanteListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CMDCancelar
            // 
            this.CMDCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CMDCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDCancelar.Location = new System.Drawing.Point(558, 368);
            this.CMDCancelar.Name = "CMDCancelar";
            this.CMDCancelar.Size = new System.Drawing.Size(100, 30);
            this.CMDCancelar.TabIndex = 5;
            this.CMDCancelar.Text = "&Cancelar";
            this.CMDCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDCancelar.UseVisualStyleBackColor = true;
            this.CMDCancelar.Click += new System.EventHandler(this.CMDCancelar_Click);
            // 
            // CMDSelecionar
            // 
            this.CMDSelecionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CMDSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDSelecionar.Location = new System.Drawing.Point(664, 368);
            this.CMDSelecionar.Name = "CMDSelecionar";
            this.CMDSelecionar.Size = new System.Drawing.Size(100, 30);
            this.CMDSelecionar.TabIndex = 6;
            this.CMDSelecionar.Text = "&Selecionar";
            this.CMDSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDSelecionar.UseVisualStyleBackColor = true;
            this.CMDSelecionar.Click += new System.EventHandler(this.CMDSelecionar_Click);
            // 
            // LBLParticipanteLocalizaLogradouro
            // 
            this.LBLParticipanteLocalizaLogradouro.AutoSize = true;
            this.LBLParticipanteLocalizaLogradouro.BackColor = System.Drawing.Color.Silver;
            this.LBLParticipanteLocalizaLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLParticipanteLocalizaLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLParticipanteLocalizaLogradouro.Location = new System.Drawing.Point(49, 111);
            this.LBLParticipanteLocalizaLogradouro.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLParticipanteLocalizaLogradouro.Name = "LBLParticipanteLocalizaLogradouro";
            this.LBLParticipanteLocalizaLogradouro.Size = new System.Drawing.Size(200, 22);
            this.LBLParticipanteLocalizaLogradouro.TabIndex = 89;
            this.LBLParticipanteLocalizaLogradouro.Text = "Logradouro";
            // 
            // TXTLogradouro
            // 
            this.TXTLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTLogradouro.Location = new System.Drawing.Point(278, 107);
            this.TXTLogradouro.MaxLength = 60;
            this.TXTLogradouro.Name = "TXTLogradouro";
            this.TXTLogradouro.Size = new System.Drawing.Size(332, 26);
            this.TXTLogradouro.TabIndex = 2;
            this.TXTLogradouro.TextChanged += new System.EventHandler(this.TXTLogradouro_TextChanged);
            // 
            // LBLParticipanteLocalizaCep
            // 
            this.LBLParticipanteLocalizaCep.AutoSize = true;
            this.LBLParticipanteLocalizaCep.BackColor = System.Drawing.Color.Silver;
            this.LBLParticipanteLocalizaCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLParticipanteLocalizaCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLParticipanteLocalizaCep.Location = new System.Drawing.Point(49, 78);
            this.LBLParticipanteLocalizaCep.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLParticipanteLocalizaCep.Name = "LBLParticipanteLocalizaCep";
            this.LBLParticipanteLocalizaCep.Size = new System.Drawing.Size(200, 22);
            this.LBLParticipanteLocalizaCep.TabIndex = 86;
            this.LBLParticipanteLocalizaCep.Text = "Cep";
            // 
            // LBLParticipanteLocalizaTituloEndereco
            // 
            this.LBLParticipanteLocalizaTituloEndereco.AutoSize = true;
            this.LBLParticipanteLocalizaTituloEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLParticipanteLocalizaTituloEndereco.ForeColor = System.Drawing.Color.Blue;
            this.LBLParticipanteLocalizaTituloEndereco.Location = new System.Drawing.Point(702, 6);
            this.LBLParticipanteLocalizaTituloEndereco.Name = "LBLParticipanteLocalizaTituloEndereco";
            this.LBLParticipanteLocalizaTituloEndereco.Size = new System.Drawing.Size(75, 16);
            this.LBLParticipanteLocalizaTituloEndereco.TabIndex = 85;
            this.LBLParticipanteLocalizaTituloEndereco.Text = "Endereço";
            // 
            // LBLParticipanteLocalizaTituloLocalizar
            // 
            this.LBLParticipanteLocalizaTituloLocalizar.AutoSize = true;
            this.LBLParticipanteLocalizaTituloLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLParticipanteLocalizaTituloLocalizar.ForeColor = System.Drawing.Color.Blue;
            this.LBLParticipanteLocalizaTituloLocalizar.Location = new System.Drawing.Point(3, 6);
            this.LBLParticipanteLocalizaTituloLocalizar.Name = "LBLParticipanteLocalizaTituloLocalizar";
            this.LBLParticipanteLocalizaTituloLocalizar.Size = new System.Drawing.Size(71, 16);
            this.LBLParticipanteLocalizaTituloLocalizar.TabIndex = 84;
            this.LBLParticipanteLocalizaTituloLocalizar.Text = "Localizar";
            // 
            // LNVertical01
            // 
            this.LNVertical01.BorderColor = System.Drawing.Color.Blue;
            this.LNVertical01.BorderWidth = 3;
            this.LNVertical01.Name = "LNVertical01";
            this.LNVertical01.X1 = 199;
            this.LNVertical01.X2 = 199;
            this.LNVertical01.Y1 = 0;
            this.LNVertical01.Y2 = 25;
            // 
            // LNHorizontal01
            // 
            this.LNHorizontal01.BorderColor = System.Drawing.Color.Blue;
            this.LNHorizontal01.BorderWidth = 5;
            this.LNHorizontal01.Name = "LNHorizontal01";
            this.LNHorizontal01.X1 = 4;
            this.LNHorizontal01.X2 = 773;
            this.LNHorizontal01.Y1 = 29;
            this.LNHorizontal01.Y2 = 29;
            // 
            // LNHorizontal02
            // 
            this.LNHorizontal02.BorderColor = System.Drawing.Color.Blue;
            this.LNHorizontal02.BorderWidth = 5;
            this.LNHorizontal02.Name = "LNHorizontal02";
            this.LNHorizontal02.X1 = 3;
            this.LNHorizontal02.X2 = 772;
            this.LNHorizontal02.Y1 = 175;
            this.LNHorizontal02.Y2 = 175;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.LNHorizontal03,
            this.LNHorizontal02,
            this.LNHorizontal01,
            this.LNVertical01});
            this.shapeContainer1.Size = new System.Drawing.Size(776, 401);
            this.shapeContainer1.TabIndex = 94;
            this.shapeContainer1.TabStop = false;
            // 
            // LNHorizontal03
            // 
            this.LNHorizontal03.BorderColor = System.Drawing.Color.Blue;
            this.LNHorizontal03.BorderWidth = 5;
            this.LNHorizontal03.Name = "LNHorizontal03";
            this.LNHorizontal03.X1 = 4;
            this.LNHorizontal03.X2 = 773;
            this.LNHorizontal03.Y1 = 361;
            this.LNHorizontal03.Y2 = 361;
            // 
            // LBLParticipanteLocalizaAte
            // 
            this.LBLParticipanteLocalizaAte.AutoSize = true;
            this.LBLParticipanteLocalizaAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LBLParticipanteLocalizaAte.Location = new System.Drawing.Point(436, 78);
            this.LBLParticipanteLocalizaAte.Name = "LBLParticipanteLocalizaAte";
            this.LBLParticipanteLocalizaAte.Size = new System.Drawing.Size(18, 20);
            this.LBLParticipanteLocalizaAte.TabIndex = 97;
            this.LBLParticipanteLocalizaAte.Text = "à";
            // 
            // CMDLocalizar
            // 
            this.CMDLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLocalizar.ForeColor = System.Drawing.Color.Black;
            this.CMDLocalizar.Location = new System.Drawing.Point(645, 69);
            this.CMDLocalizar.Name = "CMDLocalizar";
            this.CMDLocalizar.Size = new System.Drawing.Size(100, 32);
            this.CMDLocalizar.TabIndex = 3;
            this.CMDLocalizar.Text = "&Localizar";
            this.CMDLocalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLocalizar.UseVisualStyleBackColor = true;
            this.CMDLocalizar.Click += new System.EventHandler(this.CMDLocalizar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DataGridParticipanteLocalizaEndereco);
            this.panel1.Location = new System.Drawing.Point(12, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 154);
            this.panel1.TabIndex = 99;
            // 
            // DataGridParticipanteLocalizaEndereco
            // 
            this.DataGridParticipanteLocalizaEndereco.AllowUserToAddRows = false;
            this.DataGridParticipanteLocalizaEndereco.AllowUserToDeleteRows = false;
            this.DataGridParticipanteLocalizaEndereco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridParticipanteLocalizaEndereco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridParticipanteLocalizaEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridParticipanteLocalizaEndereco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodEnd,
            this.DTGColumnCep,
            this.DTGColumnLogradouro,
            this.DTGColumnBairro,
            this.DTGColumnMunicipio,
            this.DTGColumnEstado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridParticipanteLocalizaEndereco.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridParticipanteLocalizaEndereco.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGridParticipanteLocalizaEndereco.Location = new System.Drawing.Point(0, 0);
            this.DataGridParticipanteLocalizaEndereco.MultiSelect = false;
            this.DataGridParticipanteLocalizaEndereco.Name = "DataGridParticipanteLocalizaEndereco";
            this.DataGridParticipanteLocalizaEndereco.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridParticipanteLocalizaEndereco.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridParticipanteLocalizaEndereco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridParticipanteLocalizaEndereco.Size = new System.Drawing.Size(752, 154);
            this.DataGridParticipanteLocalizaEndereco.TabIndex = 4;
            this.DataGridParticipanteLocalizaEndereco.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.DataGridParticipanteLocalizaEndereco_CellStateChanged);
            // 
            // CodEnd
            // 
            this.CodEnd.HeaderText = "Codigo End.";
            this.CodEnd.Name = "CodEnd";
            this.CodEnd.ReadOnly = true;
            // 
            // DTGColumnCep
            // 
            this.DTGColumnCep.HeaderText = "CEP";
            this.DTGColumnCep.Name = "DTGColumnCep";
            this.DTGColumnCep.ReadOnly = true;
            // 
            // DTGColumnLogradouro
            // 
            this.DTGColumnLogradouro.HeaderText = "Logradouro";
            this.DTGColumnLogradouro.Name = "DTGColumnLogradouro";
            this.DTGColumnLogradouro.ReadOnly = true;
            // 
            // DTGColumnBairro
            // 
            this.DTGColumnBairro.HeaderText = "Bairro";
            this.DTGColumnBairro.Name = "DTGColumnBairro";
            this.DTGColumnBairro.ReadOnly = true;
            // 
            // DTGColumnMunicipio
            // 
            this.DTGColumnMunicipio.HeaderText = "Municipio";
            this.DTGColumnMunicipio.Name = "DTGColumnMunicipio";
            this.DTGColumnMunicipio.ReadOnly = true;
            // 
            // DTGColumnEstado
            // 
            this.DTGColumnEstado.HeaderText = "UF";
            this.DTGColumnEstado.Name = "DTGColumnEstado";
            this.DTGColumnEstado.ReadOnly = true;
            // 
            // uVWRepresentanteFabricanteListBindingSource
            // 
            this.uVWRepresentanteFabricanteListBindingSource.DataSource = typeof(Pag_Net.Bll.Comercial.UVWRepresentanteFabricanteList);
            // 
            // TXTCep
            // 
            this.TXTCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TXTCep.Location = new System.Drawing.Point(278, 75);
            this.TXTCep.Name = "TXTCep";
            this.TXTCep.Size = new System.Drawing.Size(132, 26);
            this.TXTCep.TabIndex = 102;
            this.TXTCep.TextChanged += new System.EventHandler(this.TXTCep_TextChanged);
            // 
            // TXTCep_Para
            // 
            this.TXTCep_Para.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TXTCep_Para.Location = new System.Drawing.Point(478, 75);
            this.TXTCep_Para.Name = "TXTCep_Para";
            this.TXTCep_Para.Size = new System.Drawing.Size(132, 26);
            this.TXTCep_Para.TabIndex = 103;
            this.TXTCep_Para.TextChanged += new System.EventHandler(this.TXTCep_Para_TextChanged);
            // 
            // CMDLimpar
            // 
            this.CMDLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDLimpar.ForeColor = System.Drawing.Color.Black;
            this.CMDLimpar.Location = new System.Drawing.Point(645, 107);
            this.CMDLimpar.Name = "CMDLimpar";
            this.CMDLimpar.Size = new System.Drawing.Size(100, 32);
            this.CMDLimpar.TabIndex = 104;
            this.CMDLimpar.Text = "L&impar";
            this.CMDLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CMDLimpar.UseVisualStyleBackColor = true;
            this.CMDLimpar.Click += new System.EventHandler(this.CMDLimpar_Click);
            // 
            // LBLCODEND
            // 
            this.LBLCODEND.AutoSize = true;
            this.LBLCODEND.BackColor = System.Drawing.Color.Silver;
            this.LBLCODEND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLCODEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCODEND.Location = new System.Drawing.Point(49, 46);
            this.LBLCODEND.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLCODEND.Name = "LBLCODEND";
            this.LBLCODEND.Size = new System.Drawing.Size(200, 22);
            this.LBLCODEND.TabIndex = 105;
            this.LBLCODEND.Text = "Código End. Sel.";
            // 
            // LBLCODIGOENDSELEC
            // 
            this.LBLCODIGOENDSELEC.AutoSize = true;
            this.LBLCODIGOENDSELEC.BackColor = System.Drawing.Color.Silver;
            this.LBLCODIGOENDSELEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBLCODIGOENDSELEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCODIGOENDSELEC.Location = new System.Drawing.Point(278, 46);
            this.LBLCODIGOENDSELEC.MinimumSize = new System.Drawing.Size(200, 2);
            this.LBLCODIGOENDSELEC.Name = "LBLCODIGOENDSELEC";
            this.LBLCODIGOENDSELEC.Size = new System.Drawing.Size(200, 22);
            this.LBLCODIGOENDSELEC.TabIndex = 106;
            // 
            // FrmLocalizaEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 401);
            this.Controls.Add(this.LBLCODIGOENDSELEC);
            this.Controls.Add(this.LBLCODEND);
            this.Controls.Add(this.CMDLimpar);
            this.Controls.Add(this.TXTCep_Para);
            this.Controls.Add(this.TXTCep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CMDLocalizar);
            this.Controls.Add(this.LBLParticipanteLocalizaAte);
            this.Controls.Add(this.CMDCancelar);
            this.Controls.Add(this.CMDSelecionar);
            this.Controls.Add(this.LBLParticipanteLocalizaLogradouro);
            this.Controls.Add(this.TXTLogradouro);
            this.Controls.Add(this.LBLParticipanteLocalizaCep);
            this.Controls.Add(this.LBLParticipanteLocalizaTituloEndereco);
            this.Controls.Add(this.LBLParticipanteLocalizaTituloLocalizar);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "FrmLocalizaEndereco";
            this.Text = "FrmParticipanteLocalizaEndereco";
            this.Load += new System.EventHandler(this.FrmParticipanteLocalizaEndereco_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridParticipanteLocalizaEndereco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uVWRepresentanteFabricanteListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CMDCancelar;
        private System.Windows.Forms.Button CMDSelecionar;
        private System.Windows.Forms.Label LBLParticipanteLocalizaLogradouro;
        private System.Windows.Forms.TextBox TXTLogradouro;
        private System.Windows.Forms.Label LBLParticipanteLocalizaCep;
        private System.Windows.Forms.Label LBLParticipanteLocalizaTituloEndereco;
        private System.Windows.Forms.Label LBLParticipanteLocalizaTituloLocalizar;
        private Microsoft.VisualBasic.PowerPacks.LineShape LNVertical01;
        private Microsoft.VisualBasic.PowerPacks.LineShape LNHorizontal01;
        private Microsoft.VisualBasic.PowerPacks.LineShape LNHorizontal02;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label LBLParticipanteLocalizaAte;
        private Microsoft.VisualBasic.PowerPacks.LineShape LNHorizontal03;
        private System.Windows.Forms.Button CMDLocalizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridParticipanteLocalizaEndereco;
        private System.Windows.Forms.BindingSource uVWRepresentanteFabricanteListBindingSource;
        private System.Windows.Forms.TextBox TXTCep;
        private System.Windows.Forms.TextBox TXTCep_Para;
        private System.Windows.Forms.Button CMDLimpar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnCep;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnMunicipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTGColumnEstado;
        private System.Windows.Forms.Label LBLCODEND;
        private System.Windows.Forms.Label LBLCODIGOENDSELEC;
    }
}