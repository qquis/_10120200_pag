using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pag_Wpf.Forms
{
    public partial class FrmXParticipanteBlueSoft : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public FrmXParticipanteBlueSoft (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            dtgParticipantesBlueSoft.AutoGenerateColumns = false;
            dtgParticipantesBlueSoft.ReadOnly = true;
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtgParticipantesBlueSoft.DataSource = Pag_Net.Bll.Participante.BlueSoft_Select.List(MyConnect, TxtNomeParticipante.Text);
                this.Cursor = Cursors.Default;
            }

            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAtualizarBase_Click(object sender, EventArgs e)
        {
        
            try
            {
                cmdAtualizarBase.Enabled = false;
                if (MessageBox.Show("Confirma atualizacao?", "Pag", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    cmdAtualizarBase.Enabled = false;


                    // ServicePag Migration - Redshift_SqlServer | Participantes
                    Pag_Net.Bll.Participante.BlueSoft_Import.Start(MyConnect);

                    // ServicePag Migration - Redshift_SqlServer | TbPessoaBlueSoft
                    //Pag_Net.F0011.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);

                    // ServicePag Migration - Redshift_SqlServer | TbPessoaBlueSoft para TbPessoa (pag)
                    //Pag_Net.F0001.Bll.Migration.Postgres.p0001(MyConnect);


                    /*Postgre - Importação/Exportacao do Reshitft para a Base Postgre | GrupoEconomico*/
                    Pag_Net.F0005.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);

                    /*Postgre - Importação/Exportacao do Reshitft para a Base Postgre | Participante*/
                    Pag_Net.F0002.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);


                    cmdAtualizarBase.Enabled = true;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Base de Participante atualizada com os dados Bluesoft");
                }
            }

            catch (Exception ex)
            {
                cmdAtualizarBase.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
