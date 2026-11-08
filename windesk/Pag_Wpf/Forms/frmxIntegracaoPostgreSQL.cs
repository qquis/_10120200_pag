/* A0003 - Sistema_Nuclue_Procedimentos
 * 
 
 
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Pag_Net.Models;
using Pag_Net.Services;

namespace Pag_Wpf.Forms
{
    public partial class frmxIntegracaoPostgreSQL : Form
    {
        modelSistemaUsuario MyConnect;
        public frmxIntegracaoPostgreSQL(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _fill_datagrid();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSelecionarTodos_Click(object sender, EventArgs e)
        {
            for (int li = 0; li <= DtgIntegracoesPostGre.Rows.Count - 1; li++)
            {
                DtgIntegracoesPostGre.Rows[li].Cells[0].Value = 1;
            }
        }

        private void _fill_datagrid()
        {
            try
            {
                DtgIntegracoesPostGre.AutoGenerateColumns = false;
                DtgIntegracoesPostGre.DataSource = Pag_Net.Services.Bll.Postgre.Tab.List(MyConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
                for (int li = 0; li <= DtgIntegracoesPostGre.Rows.Count - 1; li++)
                {
                    DataGridViewCheckBoxCell Chk = new DataGridViewCheckBoxCell();
                    Chk = (DataGridViewCheckBoxCell)DtgIntegracoesPostGre.Rows[li].Cells[0];
                    if (Convert.ToBoolean(Chk.Value) == true)
                    {
                        Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, (Pag_Net.Services.Models.sistema_nucleo_procedimentos)DtgIntegracoesPostGre.Rows[li].DataBoundItem);
                    }
                }
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Atualizações selecionadas realizadas com sucesso!");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSql_PostGre_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma atualização? Os dados POSTGRE serão atualizados com a BASE SQL SERVER", "Pag - Atualização", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Produto_Clear_Postgre(MyConnect);
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_Produto(MyConnect);
                    Pag_Net.Services.Bll.TEMP.SqlServer_to_PostGreSQL.Update_ProdutoEmbalagem(MyConnect);
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Atualização SQL -> POSTGRE (Produtos) realizada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdPostgre_to_sql_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
                Pag_Net.Services.Bll.Postgre.Procedimentos.Execute(MyConnect, "PSQ05", 18);
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Atualização SQL -> POSTGRE (Produtos) realizada com sucesso!");
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
