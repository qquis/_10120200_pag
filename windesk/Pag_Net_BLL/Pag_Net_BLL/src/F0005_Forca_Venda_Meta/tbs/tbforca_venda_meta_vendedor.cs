using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.f0005_forca_venda_meta.tbs
{
    public class tbforca_venda_meta_vendedor : Pag_Net.Bll.Tb
    {
        public tbforca_venda_meta_tipo META_TIPO { get; set; } 
        public int fv_meta_cd { get; set; }
        public int fv_meta_cdparticipantevendedor { get; set; }
        public int fv_meta_rq_pos_minimo { get; set; }
        public int fv_meta_rq_pos_maximo { get; set; }
        public int fv_meta_rq_pos { get; set; }
        public double fv_meta_rq_qtde { get; set; }
        public double fv_meta_rq_valor { get; set; }

        public int fv_meta_rz_pos { get; set; }
        public double fv_meta_rz_qtde { get; set; }
        public double fv_meta_rz_valor { get; set; }
        
        public int fv_meta_base_pos { get; set; }
        public double fv_meta_base_qtde { get; set; }
        public double fv_meta_base_valor { get; set; }

        public double fv_meta_bonus_percentual { get; set;  }
        public double fv_meta_bonus_valor { get; set;  }


        public tbforca_venda_meta_vendedor() : base() { _constructor(); }


        public void _constructor()
        {

            tbforca_venda_meta_tipo META_TIPO = new tbforca_venda_meta_tipo();
            fv_meta_cd = 0;
            fv_meta_cdparticipantevendedor = 0;
            fv_meta_rq_pos_minimo = 0;
            fv_meta_rq_pos_maximo = 0;
            fv_meta_rq_pos = 0;
            fv_meta_rq_qtde = 0;
            fv_meta_rq_valor = 0;
            fv_meta_rz_pos = 0;
            fv_meta_rz_qtde = 0;
            fv_meta_rz_valor = 0;
            fv_meta_base_pos = 0;
            fv_meta_base_qtde = 0;
            fv_meta_base_valor = 0;
            fv_meta_bonus_percentual = 0;
            fv_meta_bonus_valor = 0;


        }

        public override void __Binding(DataRow i)
        {
            try
            {
                this.fv_meta_cd = Convert.ToInt32(i["fv_meta_cd"].ToString());
                this.fv_meta_cdparticipantevendedor = Convert.ToInt32(i["fv_meta_cdparticipantevendedor"].ToString());
                this.fv_meta_rq_pos_minimo = Convert.ToInt32(i["fv_meta_rq_pos_minimo"].ToString());
                this.fv_meta_rq_pos_maximo = Convert.ToInt32(i["fv_meta_rq_pos_maximo"].ToString());
                this.fv_meta_rq_pos = Convert.ToInt32(i["fv_meta_rq_pos"].ToString());
                this.fv_meta_rq_qtde = Convert.ToDouble(i["fv_meta_rq_qtde"].ToString());
                this.fv_meta_rq_valor = Convert.ToDouble(i["fv_meta_rq_valor"].ToString());

                this.fv_meta_rz_pos = Convert.ToInt32(i["fv_meta_rz_pos"].ToString());
                this.fv_meta_rz_qtde = Convert.ToDouble(i["fv_meta_rz_qtde"].ToString());
                this.fv_meta_rz_valor = Convert.ToDouble(i["fv_meta_rz_valor"].ToString());

                this.fv_meta_base_pos = Convert.ToInt32(i["fv_meta_base_pos"].ToString());
                this.fv_meta_base_qtde = Convert.ToDouble(i["fv_meta_base_qtde"].ToString());
                this.fv_meta_base_valor = Convert.ToDouble(i["fv_meta_base_valor"].ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override string _Db_Pg_script_Update()
        {
            try
            {
                string SQL = "UPDATE TBFORCA_VENDA_META_VENDEDOR " +
                              "  SET  " +
                              "      fv_meta_rq_pos_minimo = " + this.fv_meta_rq_pos_minimo.ToString() +
                              "   ,  fv_meta_rq_pos_maximo = " + this.fv_meta_rq_pos_maximo.ToString() +
                              "   ,  fv_meta_rq_pos = " + this.fv_meta_rq_pos +
                              "   ,  fv_meta_rq_qtde = " + Tools.StringPag.DoubleToDataBase(this.fv_meta_rq_qtde) +
                              "   ,  fv_meta_rq_valor = " + Tools.StringPag.DoubleToDataBase(this.fv_meta_rq_valor) + 
                              "  WHERE fv_meta_cd = " + this.fv_meta_cd +
                              "    AND fv_meta_cdparticipantevendedor = " + this.fv_meta_cdparticipantevendedor.ToString() + 
                              " ;" ;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override string _Db_Pg_script_Select()
        {
            string SQL = " SELECT 		v.fv_meta_cd  " +
                         "         ,	v.fv_meta_cdparticipantevendedor " +
                         "         ,    c.nome_razao " +
                         "         ,	coalesce( v.fv_meta_rq_pos_minimo, 0) as fv_meta_rq_pos_minimo" +
                         "         ,	coalesce( v.fv_meta_rq_pos_maximo, 0) as fv_meta_rq_pos_maximo " +
                         "         ,	coalesce( v.fv_meta_rq_pos, 0) as fv_meta_rq_pos" +
                         "         ,	coalesce( v.fv_meta_rq_qtde, 0) as fv_meta_rq_qtde" +
                         "         ,	coalesce( v.fv_meta_rq_valor, 0) as fv_meta_rq_valor " +
                         "         ,	coalesce( v.fv_meta_rz_pos, 0)  as fv_meta_rz_pos " +
                         "         ,	coalesce( v.fv_meta_rz_qtde, 0) as fv_meta_rz_qtde " +
                         "         ,	coalesce( v.fv_meta_rz_valor, 0)  as fv_meta_rz_valor " +
                         "         ,	coalesce( v.fv_meta_base_pos, 0)   as fv_meta_base_pos " +
                         "         ,	coalesce( v.fv_meta_base_qtde, 0) as fv_meta_base_qtde " +
                         "         ,	coalesce( v.fv_meta_base_valor, 0) as fv_meta_base_valor " +
                         "         ,	coalesce( v.fv_meta_bonus_percentual, 0) as fv_meta_bonus_percentual " +
                         "         ,	coalesce( v.fv_meta_bonus_valor, 0) as fv_meta_bonus_valor " +
                         "         ,	coalesce( v.fv_meta_resultado_valor, 0) as fv_meta_resultado_valor " +
                         " FROM 		TBFORCA_VENDA_META_VENDEDOR v " + 
                         " INNER JOIN   TBPARTICIPANTE c on c.cdparticipante = v.fv_meta_cdparticipantevendedor " + 
                         " WHERE        fv_meta_cd = "  +  this.fv_meta_cd.ToString() +
                         "   AND        fv_meta_cdparticipantevendedor = "  +  this.fv_meta_cdparticipantevendedor.ToString() + 
                         " ;" ;
            return SQL; 
        }


        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            string POSTGRE_SCRIPT = "";
            try
            {
                return _Db_Pg_script_Update() + _Db_Pg_script_Select();

            }

            catch (Exception ex)
            {
                throw new Exception("tbsistema_batch_run - Error: \n" + ex.Message + "\n" + POSTGRE_SCRIPT);
            }
        }

    }
}
