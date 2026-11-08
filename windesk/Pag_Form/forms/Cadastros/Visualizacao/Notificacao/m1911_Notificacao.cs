using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Cadastros.Visualizacao.Notificacao
{
    public partial class m1911_Notificacao : Form
    {

        //private static int _SIS_AC_CD = 0;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0210_Notificacao._index SRC;




        public m1911_Notificacao(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }
        private void _Screen_load()
        {
            SRC = new Pag_Net.src.F0210_Notificacao._index(MyConnect);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdDetalheNotificacao, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_ButtonImage(cmdExcluir, UserTools.PagButtonsIcons.DeleteError);
            UserTools._Screen_ButtonImage(cmdAdicionar, UserTools.PagButtonsIcons.Novo);

            UserTools._Screen_Form_Format_DataGridView(dtg);

            SRC.report.PropertyChanged += _databinding;


            //COMBOBOX EMPRESA OPERACAO -------------------------------------------------------------------


        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                SRC.report.getNotificacao();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_Notificacao")
                {
                    dtg.DataSource = SRC.report.dbList_Notificacao.List;
                    lbldtg_total.Text = SRC.report.dbList_Notificacao.Count.ToString();

                    UserTools._Screen_DataBinding_Set(lbl_notificacao_cd, dtg.DataSource, "notificacao_cd");
                    UserTools._Screen_DataBinding_Set(lbl_notificacao_descricao, dtg.DataSource, "notificacao_descricao");
                }
                if (e.PropertyName == "dbList_NotificacaoParticipante")
                {
                    dtgp.DataSource = SRC.report.dbList_NotificacaoParticipante.List;
                    lbldtgp_total.Text = SRC.report.dbList_NotificacaoParticipante.Count.ToString();
                    UserTools._Screen_DataBinding_Set(lbl_cdparticipante, dtgp.DataSource, "cdparticipante");
                    UserTools._Screen_DataBinding_Set(lbl_nome_razao, dtgp.DataSource, "nome_razao");
                }

                
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDetalheNotificacao_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);

                if (lbl_notificacao_cd.Text == "") 
                {
                    UserTools._Screen_MessageBox(this,UserTools.PagTipoMessageBox.Atencao, "Selecione uma Notificação");
                    return;
                }

                SRC.report.getNotificacaoParticipante(Convert.ToInt32(lbl_notificacao_cd.Text));
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAdicionar_Click(object sender, EventArgs e)
        {
            try 
            {
                using (frm_Pessoa_List frm = new frm_Pessoa_List(MyConnect, Pag_Net.Bll.F0011_Participante.enumParticipanteTipoCd.adm_usuario))
                {
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        NotificacaoParticipante(frm.ParticipateSelecionado.cdparticipante.ToString(), false);
                    }
                }
            }
            catch (Exception ex) { UserTools._Screen_MessageBox(this, ex); }
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma exclusão do Registro?"))
                    NotificacaoParticipante(lbl_cdparticipante.Text, true);

            }
            catch (Exception ex) { UserTools._Screen_MessageBox(this, ex); }
        }

        private void NotificacaoParticipante(string cdparticipante, bool excluir)
        {
            try
            {
                SRC.NotificacaoParticipante(lbl_notificacao_cd.Text, cdparticipante, excluir);
                SRC.report.getNotificacaoParticipante(Convert.ToInt32(lbl_notificacao_cd.Text));
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }


        private void lbl_notificacao_cd_TextChanged(object sender, EventArgs e)
        {
            dtgp.DataSource = null;
        }


    }



}
