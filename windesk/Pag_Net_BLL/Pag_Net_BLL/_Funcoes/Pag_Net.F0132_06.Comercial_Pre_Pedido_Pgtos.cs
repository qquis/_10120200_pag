using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0132_06
{
    public static class RedShift
    {

    }

    public static class Postgre
    {
        public static string Post
            (
                Pag_Net.Bll.F0132_06.Db _db
            )
        {
            string _sql_post = string.Format("SELECT " +
                                             Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0132_06_comercial_pre_pedido_pgtos) +
                                             "   ( 'DBINSERT'  " +
                                             "          ,   {0}         " +
                                             "          ,  '{1}'        " +
                                             "          ,   {2}         )"
                                      , _db.cm_pre_ped_seq
                                      , _db.data_vencimento.ToString("yyyy-MM-dd")
                                      , _db.valor.ToString("0.00").Replace(",", ".")
                                      );

            return _sql_post;

        }


    }

    public class Db
    {
        public int cm_pre_ped_seq { get; set; }
        public int cm_pre_ped_pgto_seq  { get; set; }
        public int cm_pre_ped_pgto_order { get; set; }
        public DateTime data_vencimento { get; set; }
        public double valor { get; set; }

        public Db() { }
        public Db
            (
                  int _cm_pre_ped_seq
                , int _cm_pre_ped_pgto_seq
                , int _cm_pre_ped_pgto_order 
                , DateTime _data_vencimento
                , double _valor
            )
        {
            cm_pre_ped_seq = _cm_pre_ped_seq;
            cm_pre_ped_pgto_seq = _cm_pre_ped_pgto_seq;
            cm_pre_ped_pgto_order = _cm_pre_ped_pgto_order;
            data_vencimento = _data_vencimento;
            valor = _valor;
        }
    }

}