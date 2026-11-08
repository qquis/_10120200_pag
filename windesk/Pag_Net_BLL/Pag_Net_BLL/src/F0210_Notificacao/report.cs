using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao
{

    public class _indexReport
    {


        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public Pag_Net.src.F0210_Notificacao.interfaces.Filter filter;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DBDataTable __dbList_Notificacao;
        public DBDataTable dbList_Notificacao { 
                get { return __dbList_Notificacao; } 
                set { __dbList_Notificacao = value; 
                        RaisePropertyChanged("dbList_Notificacao"); } }


        private DBDataTable __dbList_NotificacaoParticipante;
        public DBDataTable dbList_NotificacaoParticipante
        {
            get { return __dbList_NotificacaoParticipante; }
            set
            {
                __dbList_NotificacaoParticipante = value;
                RaisePropertyChanged("dbList_NotificacaoParticipante");
            }
        }

        private DBDataTable __dbList_NotificacaoSend;
        public DBDataTable dbList_NotificacaoSend
        {
            get { return __dbList_NotificacaoSend; }
            set
            {
                __dbList_NotificacaoSend = value;
                RaisePropertyChanged("dbList_NotificacaoSend");
            }
        }

        private DBDataTable __dbList_NotificacaoSendMessage;
        public DBDataTable dbList_NotificacaoSendMessage
        {
            get { return __dbList_NotificacaoSendMessage; }
            set
            {
                __dbList_NotificacaoSendMessage = value;
                RaisePropertyChanged("dbList_NotificacaoSendMessage");
            }
        }  

        public _indexReport(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect); }


        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            filter = new interfaces.Filter();

        }
       
        public void filtroClear()
        {

        }
        public void getNotificacao() 
        {
            try 
            {
               dbList_Notificacao = BDCommand.DBDataTableGet(MyConnect, Sql.Notificacao(filter)); 
            } 
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public void getNotificacaoParticipante(int notificacao_cd)
        {
            try
            {
                Pag_Net.src.F0210_Notificacao.interfaces.Filter filterNotificacaoParticipante = new interfaces.Filter();
                filterNotificacaoParticipante.notificacao_cd = notificacao_cd;

                dbList_NotificacaoParticipante = BDCommand.DBDataTableGet(MyConnect, Sql.NotificacaoParticipante(filterNotificacaoParticipante));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void getNotificacaoSend()
        {
            try
            {
                dbList_NotificacaoSend = BDCommand.DBDataTableGet(MyConnect, Sql.NotificacaoSend(this.filter));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void getNotificacaoSendMessage(int notificacao_send_seq)
        {
            try
            {
                dbList_NotificacaoSendMessage = BDCommand.DBDataTableGet(MyConnect, Sql.NotificacaoSendMessageGet(notificacao_send_seq));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class Sql
    {
        public static string Notificacao(Pag_Net.src.F0210_Notificacao.interfaces.Filter filter)
        {
            string sql = "SELECT 		x.notificacao_cd "
                      + "             , x.notificacao_descricao "
                      + "             , x.notificacao_origem_sis_nucleo_prc_Cd  "
                      + "             , x.notificacao_send_tipo_cd "
                      + "             , ts.notificacao_send_tipo_descricao "
                      + "   FROM 		tbnotificacao			x "
                      + "   LEFT JOIN   tbnotificacao_send_tipo ts on ts.notificacao_send_tipo_cd = x.notificacao_send_tipo_cd"
                      
                      + "   where		1 = 1 ";
                      
                      if (filter.notificacao_cd != 0 )
                          sql += " and x.notificacao_cd = " + filter.notificacao_cd.ToString();

                      sql +=  "   ORDER BY x.notificacao_descricao asc ";
            return sql;
        }

        public static string NotificacaoParticipante(Pag_Net.src.F0210_Notificacao.interfaces.Filter filter)
        {
            string sql = "SELECT 		X.notificacao_cd "
                      + "             , p.cdparticipante "
                      + "             , p.nome_razao  "
                      + "             , p.celular_dd "
                      + "             , p.celular_numero  "
                      + "             , p.email_main "
                      + "   FROM 		tbnotificacao_participante	x " 
                      + "   LEFT JOIN   tbparticipante p on p.cdparticipante = x.cdparticipante  " 
                      + "   where		1 = 1 ";

            if (filter.notificacao_cd != 0)
                sql += " and x.notificacao_cd = " + filter.notificacao_cd.ToString();

            sql += " order by 3 asc ";
            return sql;
        }

        public static string NotificacaoSend(Pag_Net.src.F0210_Notificacao.interfaces.Filter filter)
        {
            string sql = "   select 	ns.dtlog_insert " + 
		                 "           ,	ns.dtlog_update " + 
		                 "           ,	ns.notificacao_send_seq  " + 
		                 "           ,	ns.notificacao_cd " +  
		                 "           ,	n.notificacao_descricao " +  
		                 "           ,   ns.notificacao_send_data " +  
		                 "           ,	ns.notificacao_send_tipo_cd " +  
		                 "           ,	st.notificacao_send_tipo_descricao " +  
		                 "           ,	ns.proc_log_seq " +  
		                 "           ,	ns.notificacao_whatsapp " +  
		                 "           ,	ns.notificacao_mail " +  
		                 "           ,	ns.notificacao_celular_dd_numero  " + 
		                 "           ,	ns.notificacao_email " +  
		                 "           ,	ns.notificacao_email_cc " + 
		                 "           ,	ns.notificacao_email_co " +  
		                 "           ,	ns.notificacao_email_subject " +  
		                 "           ,	ns.notificacao_email_title " + 
		                 "           ,	ns.notificacao_whatsapp_gp  " + 
		                 "           ,	ns.notificacao_mk_cd " +  
                         "           ,  ns.notificacao_send_status_cd "  +
                         "           ,  sx.notificacao_send_status_descricao " +
                         "   from 		tbnotificacao_send ns " +  
                         "   left  join 	tbnotificacao			 			n 	on n.notificacao_cd = ns.notificacao_cd  " + 
                         "   left  join  tbnotificacao_send_tipo   			st	on st.notificacao_send_tipo_cd = ns.notificacao_send_tipo_cd  " +
                         "   left join   tbnotificacao_send_status  sx on sx.notificacao_send_status_cd = ns.notificacao_send_status_cd " + 
                         "   where 1 = 1 " ;

            if (filter.notificacao_filter_data)
            {
                sql += "and notificacao_send_data >= " + "'" + filter.notificacao_filter_data_ini.ToString("yyyy-MM-dd") + "'";
                sql += "and notificacao_send_data <= " + "'" + filter.notificacao_filter_data_fim.ToString("yyyy-MM-dd") + "'";
            }


            if (filter.notificacao_cd != 0)
                sql += " and x.notificacao_cd = " + filter.notificacao_cd.ToString();

            sql += " order by 3 asc ";
            return sql;
        }

        public static string NotificacaoSendMessageGet(int notificacao_send_seq)
        {
            return "select notificacao_send_message, notificacao_send_message_seq from tbnotificacao_send_message where notificacao_send_seq = " + notificacao_send_seq.ToString();
        }
    }


    public static class DBDataTables
    {

      

    }

    public static class ArrayTabs
    {


    }
}
