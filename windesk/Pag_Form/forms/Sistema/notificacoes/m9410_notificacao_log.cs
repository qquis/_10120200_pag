using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Sistema.notificacoes
{
    public partial class m9410_notificacao_log : Form
    {

        //private static int _SIS_AC_CD = 0;

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0210_Notificacao._index SRC;


        public m9410_notificacao_log(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();
        }

        private void _Screen_load()
        {
            SRC = new Pag_Net.src.F0210_Notificacao._index(MyConnect);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdConsultarMensagem, UserTools.PagButtonsIcons.Detalhe);
            UserTools._Screen_Form_Format_DataGridView(dtg);
            SRC.report.PropertyChanged += _databinding;


            //COMBOBOX EMPRESA OPERACAO -------------------------------------------------------------------


        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (e.PropertyName == "dbList_NotificacaoSend")
                {
                    dtg.DataSource = SRC.report.dbList_NotificacaoSend.List;
                    //lbldtg_total.Text = SRC.report.dbList_Notificacao.Count.ToString();

                    UserTools._Screen_DataBinding_Set(lbl_notificacao_send_seq, dtg.DataSource, "notificacao_send_seq");
                    UserTools._Screen_DataBinding_Set(lbl_notificacao_descricao, dtg.DataSource, "notificacao_descricao");
                    UserTools._Screen_DataBinding_Set(lbl_dtlog_insert, dtg.DataSource, "dtlog_insert");
                    UserTools._Screen_DataBinding_Set(lbl_notificacao_celular_dd_numero, dtg.DataSource, "notificacao_celular_dd_numero");
                    UserTools._Screen_DataBinding_Set(lbl_notificacao_email, dtg.DataSource, "notificacao_email");
                    //UserTools._Screen_DataBinding_Set(lbl_notificacao_descricao, dtg.DataSource, "notificacao_descricao");
                }
                if (e.PropertyName == "dbList_NotificacaoParticipante")
                {
                    //dtgp.DataSource = SRC.report.dbList_NotificacaoParticipante.List;
                    //lbldtgp_total.Text = SRC.report.dbList_NotificacaoParticipante.Count.ToString();
                    //UserTools._Screen_DataBinding_Set(lbl_cdparticipante, dtgp.DataSource, "cdparticipante");
                    //UserTools._Screen_DataBinding_Set(lbl_nome_razao, dtgp.DataSource, "nome_razao");
                }
                if (e.PropertyName == "dbList_NotificacaoSendMessage")
                {
                    lbl_notificacaosendMessage.Text = SRC.report.dbList_NotificacaoSendMessage.List.Rows[0]["notificacao_send_message"].ToString();
                }

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                SRC.report.filter.notificacao_filter_data = chkDatafilter.Checked;
                SRC.report.filter.notificacao_filter_data_ini = dtpdata_ini.Value;
                SRC.report.filter.notificacao_filter_data_fim = dtpdata_fim.Value;
                UserTools._Screen_Wait(this);
                SRC.report.getNotificacaoSend();
                UserTools._Screen_Wait(this);
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

        private void cmdConsultarMensagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_notificacao_send_seq.Text == "") 
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Selecione uma notificação");
                    return;
                }
                UserTools._Screen_Wait(this);
                SRC.report.getNotificacaoSendMessage(Convert.ToInt32(lbl_notificacao_send_seq.Text));
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
