using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{

    public class model_controle_reg_fin : tbcontrole_reg_fin
    {
        public int sis_us_seq { get; set; }
        public string user_name { get; set; }
        public string controle_descricao { get; set; }
        public int controle_reg_numero { get; set; }
        public string fin_forma_pgto_descricao { get; set; }
        public string fin_tipo_lancamento { get; set; }
        public model_controle_reg_fin()
            : base()
        {

        }

        public model_controle_reg_fin(
                int _proc_log_seq,
                int _controle_reg_seq,
                int _controle_reg_fin_seq,
                DateTime _controle_reg_fin_data,
                int _autpgto_seq,
                int _fin_tipo_lancamento_cd,
                int _fin_forma_pgto_cd,
                string _controle_reg_fin_descritivo,
                double _controle_reg_fin_valor,
                int _sis_us_seq,
                string _user_name,
                string _controle_descricao,
                int _controle_reg_numero
            )
            : base(_proc_log_seq,
                   _controle_reg_seq,
                   _controle_reg_fin_seq,
                   _controle_reg_fin_data,
                   _autpgto_seq,
                   _fin_tipo_lancamento_cd,
                   _fin_forma_pgto_cd,
                   _controle_reg_fin_descritivo,
                   _controle_reg_fin_valor
            )
        {
            sis_us_seq = _sis_us_seq;
            user_name = _user_name;
            controle_descricao = _controle_descricao;
            controle_reg_numero = _controle_reg_numero;
        }


        public model_controle_reg_fin(DataRow i)
            : base(i)
        {
            try
            {
                sis_us_seq = Convert.ToInt32(i["proc_log_seq"]);
                user_name = i["user_name"].ToString();
                controle_descricao = i["controle_descricao"].ToString();
                controle_reg_numero = Convert.ToInt32(i["controle_reg_numero"]);
                fin_forma_pgto_descricao = i["fin_forma_pgto_descricao"].ToString();
                fin_tipo_lancamento = i["fin_tipo_lancamento"].ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
