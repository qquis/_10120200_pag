using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Pag_Net.src.f0005_forca_venda_meta.tbs
{
    public class tbforca_venda_meta_composicao_tipo : Pag_Net.Bll.Tb
    {
        public int fv_meta_composicao_tipo_cd { get; set; }
        public string fv_meta_composicao_tipo_descricao { get; set; }

        public tbforca_venda_meta_composicao_tipo() : base() { _constructor(); }


        public void _constructor()
        {
            this.fv_meta_composicao_tipo_cd = 0;
            this.fv_meta_composicao_tipo_descricao = "";


        }

        public override void __Binding(DataRow i)
        {
            try
            {
                this.fv_meta_composicao_tipo_cd = Convert.ToInt32(i["fv_meta_composicao_tipo_cd"].ToString());
                this.fv_meta_composicao_tipo_descricao = i["fv_meta_composicao_tipo_descricao"].ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public override string __Db_Pg_script(BDCommandTypes BDCommnadType)
        {
            string POSTGRE_SCRIPT = "";
            try
            {
                /*
                POSTGRE_SCRIPT = "Select * from " + F0138_10_Recurso_Ctrl_CRUD._VERSION() + "( " +
                        "   vcommand_db:=  '" + BDCommnadType.ToString() + "'" +
                        " , vrecurso_ctrl_seq:= " + this.recurso_ctrl_seq.ToString() +
                        " , vcontrole_reg_seq:= " + this.controle_reg_seq.ToString() +
                        " , vrecurso_ctrl_utiliza_ativo:= " + this.recurso_ctrl_utiliza_ativo.ToString() +
                        " , vat_seq:= " + this.at_seq.ToString() +
                        " , vrecurso_ctrl_observacao:= '" + this.recurso_ctrl_observacao.ToString() + "'" +
                        ")";
                return POSTGRE_SCRIPT;*/
                return "";
            }

            catch (Exception ex)
            {
                throw new Exception("tbsistema_batch_run - Error: \n" + ex.Message + "\n" + POSTGRE_SCRIPT);
            }
        }

    }
}
