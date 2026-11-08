using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante
{
    public class TbParticipanteFuncionario : Pag_Net.Bll.Tb
    {
        public Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato TipoContrato { get; set; }
        public Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional SetorOperacional { get; set; }
        public int cdparticipante { get; set; }
        public int rh_seq { get; set; }
        public int rh_funcionario_cd { get; set;  }
        public int rh_funcionario_dv { get; set;  }
        public DateTime data_admissao { get; set;  }
        public DateTime data_rescisao { get; set; }
        public int rh_status { get; set;  }

        public int dtm_situacao_cd { get; set;  }
        public int dtm_cargo_cd { get; set; }
        public int dtm_setor_cd { get; set; }
        public int dtm_secao_cd { get; set; }

        public double rh_vl_contrato_bruto { get; set; }
        public double rh_vl_contrato_liq { get; set; }
        public double rh_vl_salario { get; set; }
        public double rh_vl_salario_liq { get; set; }
        public double rh_vl_pj { get; set; }
        public double rh_vl_outros { get; set; }



        public bool funcinario_status_LOCAL
        {
            get
            {
                if (rh_status == 1)
                    return true;
                else
                    return false;
            }
        }
        public string funcinario_status_LOCAL_DESCRICAO
        {
            get
            {
                if (rh_status == 1)
                    return "Ativo";
                else
                    return "Inativo";
            }
        }

        public string dtm_situacao_descricao { get; set; }
        public string dtm_cargo_descricao { get; set;  }
        public string dtm_setor_descricao { get; set; }
        public string dtm_secao_descricao{ get; set; }
        


        public string rh_setor_operacional_descricao
        {
            get
            {
                return SetorOperacional.rh_setor_operacional_descricao;
            }
        }

        public string rh_tipo_contrato_descricao
        {
            get
            {
                return TipoContrato.rh_tipo_contrato_descricao;
            }
        }

        public TbParticipanteFuncionario() { _constructor(); }


        public void _constructor()
        {
            TipoContrato = new F0141_Rh.TbRh_Tipo_Contrato();
            SetorOperacional = new F0141_Rh.TbRh_Setor_Operacional();
            this.cdparticipante = 0;
            this.rh_seq = 0;
            this.rh_funcionario_cd = 0;
            this.rh_funcionario_dv = 0;
            this.data_admissao = Convert.ToDateTime("1900-01-01");
            this.data_rescisao = Convert.ToDateTime("1900-01-01");
            this.rh_status = 0;
            this.dtm_cargo_descricao = "";
            this.dtm_setor_descricao = "";
            this.dtm_secao_descricao = "";
            this.dtm_situacao_descricao = "";
            this.rh_vl_contrato_bruto = 0;
            this.rh_vl_contrato_liq = 0;
            this.rh_vl_salario = 0;
            this.rh_vl_salario_liq = 0;
            this.rh_vl_pj = 0;
            this.rh_vl_outros = 0;
        
        }
        public override void __Binding(DataRow i)
        {
            try
            {
                _constructor();
                this.cdparticipante = Convert.ToInt32(i["cdparticipante"].ToString());
                this.rh_seq = Convert.ToInt32(i["rh_seq"].ToString());
                this.rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
                this.rh_funcionario_dv = Convert.ToInt32(i["rh_funcionario_dv"].ToString());
                this.data_admissao = Convert.ToDateTime(i["data_admissao"].ToString());
                this.data_rescisao = Convert.ToDateTime(i["data_rescisao"].ToString());
                this.rh_status = Convert.ToInt32(i["rh_status"].ToString());
                this.dtm_situacao_descricao = i["dtm_situacao_descricao"].ToString();
                this.dtm_cargo_descricao = i["dtm_cargo_descricao"].ToString();
                this.dtm_setor_descricao = i["dtm_setor_descricao"].ToString();
                this.dtm_secao_descricao = i["dtm_secao_descricao"].ToString();

                this.SetorOperacional.rh_setor_operacional_cd = Convert.ToInt32(i["rh_setor_operacional_cd"].ToString());
                this.SetorOperacional.rh_setor_operacional_descricao = i["rh_setor_operacional_descricao"].ToString();
                this.TipoContrato.rh_tipo_contrato_cd = Convert.ToInt32(i["rh_tipo_contrato_cd"].ToString());
                this.TipoContrato.rh_tipo_contrato_descricao = i["rh_tipo_contrato_descricao"].ToString();

                this.rh_vl_contrato_bruto = Convert.ToDouble(i["rh_vl_contrato_bruto"].ToString());
                this.rh_vl_contrato_liq = Convert.ToDouble(i["rh_vl_contrato_liq"].ToString());
                this.rh_vl_salario = Convert.ToDouble(i["rh_vl_salario"].ToString());
                this.rh_vl_salario_liq = Convert.ToDouble(i["rh_vl_salario_liq"].ToString());
                this.rh_vl_pj = Convert.ToDouble(i["rh_vl_pj"].ToString());
                this.rh_vl_outros = Convert.ToDouble(i["rh_vl_outros"].ToString());

             }
            catch (Exception ex)
            {
                throw new Exception("TbParticipante_Tipo | Error \n " + ex.Message);
            }

        }
        public override string __Db_Pg_script(BDCommandTypes __BDCommnadType)
        {

            
            string __Db_Pg_script = "";

            __Db_Pg_script = string.Format("select * from " + F0011_Participante.F0011_08_ParticipanteFuncionario._VERSION() + 
                " (		sqlcommand:= '" + __BDCommnadType.ToString()  + "'" + 
	            "     ,	vcdparticipante:= " + this.cdparticipante.ToString() +
                "     ,	vrh_seq:= 0 " +
                "     , vrh_funcionario_cd:= " + this.rh_funcionario_cd.ToString() +
                "     , vrh_funcionario_dv:= " + this.rh_funcionario_dv.ToString() +
                "     , vdata_admissao:= '" + this.data_admissao.ToString("yyyy-MM-dd") + "'" +
                "     , vdata_rescisao:= '" + this.data_rescisao.ToString("yyyy-MM-dd") + "'" +
                "     , vrh_status:= " + this.rh_status.ToString() +
                "     , vdtm_situacao_cd:= " + this.dtm_situacao_cd.ToString() +
                "     , vdtm_cargo_cd:= " + this.dtm_cargo_cd.ToString() +
                "     , vdtm_setor_cd:= " + this.dtm_setor_cd.ToString() +
                "     , vdtm_secao_cd:= " + this.dtm_secao_cd.ToString() + 
                "     , vrh_tipo_contrato_cd:= " + this.TipoContrato.rh_tipo_contrato_cd.ToString() +
                "     , vrh_setor_operacional_cd:= " + this.SetorOperacional.rh_setor_operacional_cd.ToString() + 	
                "     , vrh_vl_contrato_bruto:= " + this.rh_vl_contrato_bruto.ToString("0.00").Replace(",", ".") +
                "     , vrh_vl_contrato_liq:= " + this.rh_vl_contrato_liq.ToString("0.00").Replace(",", ".") +
                "     , vrh_vl_salario:= " + this.rh_vl_salario.ToString("0.00").Replace(",", ".") +
                "     , vrh_vl_salario_liq:= " + this.rh_vl_salario_liq.ToString("0.00").Replace(",", ".") +
                "     , vrh_vl_pj:= " + this.rh_vl_pj.ToString("0.00").Replace(",", ".") +
                "     , vrh_vl_outros:= " + this.rh_vl_outros.ToString("0.00").Replace(",", ".") + 
                " ) "); 
            return __Db_Pg_script;
        }

        public void New(Pag_Net.Models.modelSistemaUsuario MyConnect, int cdParticipante)
        {
            try
            {
                this._constructor();
                this.cdparticipante = cdParticipante;
                this.rh_funcionario_cd = 99000000 + cdParticipante;
                this.rh_funcionario_dv = 999;

                string SQLVerificaParticipantePag = "Select rh_funcionario_cd from tbparticipante_funcionario where cdparticipante = " + this.cdparticipante.ToString() + " and rh_funcionario_cd = " + this.rh_funcionario_dv.ToString();
                if (BDCommand.get_DataTable(MyConnect, SQLVerificaParticipantePag).Rows.Count > 0)
                {
                    throw new Exception("Já existe um funcionário Pag para este participante!");
                }


                this._DBINSERT(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
