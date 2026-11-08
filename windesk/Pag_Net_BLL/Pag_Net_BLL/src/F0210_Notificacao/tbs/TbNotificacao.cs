using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0210_Notificacao.tbs
{
    public class TbNotificacao : Bll.Tb
    {
        public int notificacao_cd { get; set;  }
        public string notificacao_descricao { get; set; }
        public int notificacao_send_tipo_cd { get; set; }

        public TbNotificacao()
        {
            _constructor();
        }

        private void _constructor()
        {
            notificacao_cd = 0;
            notificacao_descricao = "";
            notificacao_send_tipo_cd = 0;
            
        }

        public override void __Binding(System.Data.DataRow i)
        {
            try
            {
                this.notificacao_cd = Convert.ToInt32(i["notificacao_cd"].ToString());
                this.notificacao_descricao = i["notificacao_descricao"].ToString();
                this.notificacao_send_tipo_cd = Convert.ToInt32(i["notificacao_send_tipo_cd"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               
            }
        }

        public override string _Db_Pg_script_Select()
        {
            string sql = "select notificacao_cd, notificacao_descricao, notificacao_send_tipo_cd " +
                           " from tbnotificacao where notificacao_cd = " + notificacao_cd.ToString();
            return sql;
        }
        public string __Db_Pg_script()
        {
            string sql = "select notificacao_cd, notificacao_descricao, notificacao_send_tipo_cd " + 
                " from tbnotificacao where notificacao_cd = " + notificacao_cd.ToString();
            return sql;
        }
    }
}
