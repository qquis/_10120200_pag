using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.f0005_forca_venda_meta.tbs
{
    public class tbforca_venda_meta : Pag_Net.Bll.Tb
    {
        public tbforca_venda_meta_tipo META_TIPO { get; set; } 
        public int fv_meta_cd { get; set; }
        public int fv_meta_tipo_cd {get; set; }
        public string fv_meta_descricao {get; set;}
        public DateTime fv_meta_data_ini { get; set;  }
        public DateTime fv_meta_data_fim { get; set; }
        public double fv_meta_bonus_percentual { get; set;  }
        public double fv_meta_bonus_valor { get; set;  }
        public int competencia_cd { get; set;  }
        public double fv_meta_bonus_percentual_proporcional { get; set; }




        public int fv_meta_regra_base_proporcional {get; set; }
        public string LABEL_fv_meta_regra_base_proporcional
        {
            get
            {
                if (this.fv_meta_regra_base_proporcional == 1)
                {
                    return "Sim";
                }
                else
                {
                    return "Não"; 
                }
            }
        }

        public tbforca_venda_meta() : base() { _constructor(); }


        public void _constructor()
        {

            tbforca_venda_meta_tipo META_TIPO = new tbforca_venda_meta_tipo();
            fv_meta_cd = 0;
            fv_meta_tipo_cd = 0;
            fv_meta_descricao = "";
            fv_meta_data_ini = DateTime.Now;
            fv_meta_data_fim = DateTime.Now;
            fv_meta_bonus_percentual = 0;
            fv_meta_bonus_valor = 0;
            competencia_cd = 0;
            fv_meta_bonus_percentual_proporcional = 0;
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
        public override string _Db_Pg_script_Update()
        {
            string SQL = " UPDATE tbforca_venda_meta  " +
                         " set    fv_meta_descricao = '" + this.fv_meta_descricao.ToString() + "'" +
                         "     ,  fv_meta_tipo_cd = " + this.META_TIPO.fv_meta_tipo_cd.ToString() +
                         "     ,  fv_meta_bonus_percentual =  " + Tools.StringPag.DoubleToDataBase(this.fv_meta_bonus_percentual) +
                         "     ,  fv_meta_bonus_valor = " + Tools.StringPag.DoubleToDataBase(this.fv_meta_bonus_valor) +
                         "     ,  fv_meta_bonus_percentual_proporcional = " + Tools.StringPag.DoubleToDataBase(this.fv_meta_bonus_percentual_proporcional) +
                         "  WHERE 1 = 1 " +
                         "    AND fv_meta_cd = " + this.fv_meta_cd.ToString() +
                         " ; ";
            return SQL;
        }
        public override string _Db_Pg_script_Select()
        {
            try
            {
                if (this.fv_meta_cd == 0)
                {
                    throw new Exception("Código da Meta não informado!");
                }
                string SQL = "SELECT   f.fv_meta_cd           " +
                             "       , f.fv_meta_tipo_cd      " +
                             "       , f.fv_meta_descricao    " +
                             "       , f.fv_meta_data_ini     " +
                             "       , f.fv_meta_data_fim     " +
                             "       , t.fv_meta_tipo_descricao " +
                             "       , coalesce(f.fv_meta_bonus_percentual,0) as fv_meta_bonus_percentual " +
                             "       , coalesce(f.fv_meta_bonus_valor,0) as fv_meta_bonus_valor " +
                             "       , competencia_cd " +
                             "       , coalesce(fv_meta_bonus_percentual_proporcional,0) as fv_meta_bonus_percentual_proporcional  " +
                             " FROM         tbforca_venda_meta f " +
                             " INNER JOIN   tbforca_venda_meta_tipo t on t.fv_meta_tipo_cd = f.fv_meta_tipo_cd " +
                             " WHERE 1 = 1 " +
                             " AND   f.fv_meta_cd = " + this.fv_meta_cd.ToString() + 
                             " ; " ;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override void __Binding(DataRow i)
        {
            try
            {

                this.fv_meta_cd = Convert.ToInt32(i["fv_meta_cd"].ToString());
                this.fv_meta_tipo_cd = Convert.ToInt32(i["fv_meta_tipo_cd"].ToString());
                this.fv_meta_descricao = i["fv_meta_descricao"].ToString();
                this.fv_meta_data_ini = Convert.ToDateTime(i["fv_meta_data_ini"].ToString());
                this.fv_meta_data_fim = Convert.ToDateTime(i["fv_meta_data_fim"].ToString());
                this.fv_meta_bonus_percentual = Convert.ToDouble(i["fv_meta_bonus_percentual"].ToString());
                this.fv_meta_bonus_valor =  Convert.ToDouble(i["fv_meta_bonus_valor"].ToString());
                this.competencia_cd = Convert.ToInt32(i["competencia_cd"].ToString());
                this.fv_meta_bonus_percentual_proporcional = Convert.ToDouble(i["fv_meta_bonus_percentual_proporcional"].ToString()); ;

                META_TIPO = new tbforca_venda_meta_tipo();
                META_TIPO.fv_meta_tipo_cd = this.fv_meta_tipo_cd;
                META_TIPO.fv_meta_tipo_descricao = i["fv_meta_tipo_descricao"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}
