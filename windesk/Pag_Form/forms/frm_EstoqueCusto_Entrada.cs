using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_EstoqueCusto_Entrada : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        DataTable _DataTable_Entradas;
        public frm_EstoqueCusto_Entrada(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _Screen_load();
        }

        public frm_EstoqueCusto_Entrada(Pag_Net.Models.modelSistemaUsuario _myConnect, int prb_cdprodutobluesoft)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            
            if (prb_cdprodutobluesoft != 0)
            {
                txtcdprodutobluesoft.Text = prb_cdprodutobluesoft.ToString();
            }
            _Screen_load();
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");
            
            txtcdproduto.TextChanged += new EventHandler(_Screen_changed);
            txtcdprodutobluesoft.TextChanged += new EventHandler(_Screen_changed);
            txtdescricao.TextChanged += new EventHandler(_Screen_changed);
            
            dtg_Nota_Fiscal_Entrada.AutoGenerateColumns = false;


            dtp_Custo_Entrada_Data_Inicial.Value = DateTime.Now.AddDays(-30);
            dtp_Custo_Entrada_Data_Final.Value = DateTime.Now;

            if (txtcdprodutobluesoft.Text != "")
            {
                _binding();
            }
        }

        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "Label") {}
                if (sender.GetType().Name == "TextBox"){}
                if (sender.GetType().Name == "DateTimePicker") { }
                if (sender.GetType().Name == "CheckBox") { }
                if (sender.GetType().Name == "ComboBox") { }
            }

            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
            }
        }
        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }
        private void _binding()
        {

            int pr_cdproduto = 0;
            int prb_cdprodutobluesoft = 0;
            int ece_nf_numero = 0;

            if (txtcdproduto.Text != "") pr_cdproduto = Convert.ToInt32(txtcdproduto.Text);
            if (txtcdprodutobluesoft.Text != "") prb_cdprodutobluesoft = Convert.ToInt32(txtcdprodutobluesoft.Text);
            if (txtece_nf_numero.Text != "") ece_nf_numero = Convert.ToInt32(txtece_nf_numero.Text);

            _DataTable_Entradas = Pag_Net.Bll.EstoqueCusto.Entradas.List(
                MyConnect, new Pag_Net.Bll.R0031_01.Parametros(
                dtp_Custo_Entrada_Data_Inicial.Value,
                dtp_Custo_Entrada_Data_Final.Value,
                pr_cdproduto,
                prb_cdprodutobluesoft,
                txtdescricao.Text.ToString().TrimEnd().Replace("'", ""),
                ece_nf_numero,
                txtnome_razao.Text.ToString().TrimEnd().Replace("'", ""))  );
            
            dtg_Nota_Fiscal_Entrada.DataSource = _DataTable_Entradas;
            chart_entrada_dia_custo.DataSource = null;
            chart_entrada_dia_custo.DataSource = _DataTable_Entradas;
            if (_DataTable_Entradas.Rows.Count > 10)
                chart_entrada_dia_custo.Series[0].IsValueShownAsLabel = false;
            chart_entrada_dia_custo.DataBind();


        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);
                _binding();
                _Screen_wait(cmdAtualiza, false);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

}
