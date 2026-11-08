using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg_Etapa : TbControle_reg_etapa
    {
        public string controle_etapa_descricao { get; set; }
        public string _DESCRICAO_STATUS_EXECUCAO
        {
            get
            {
                if (this.controle_etapa_em_execucao == 1)
                {
                    return "Em Execução";
                }
                else
                {
                    return "";
                }
            }
        }

        public model_controle_reg_Etapa() : base() { }

        public model_controle_reg_Etapa(DataRow i)
            : base(i)
        {
            controle_etapa_descricao = i["controle_etapa_descricao"].ToString();
        }

        public void Save(Pag_Net.Models.modelSistemaUsuario MyConnect, model_controle_reg __CONTROLE)
        {
            try
            {
                model_controle_reg_Etapa _NEW_ETAPA = new model_controle_reg_Etapa(BDCommand.get_DataTable(MyConnect,
                    F0130_34_Controle_Reg_Etapa_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this)).Rows[0]);
                this.controle_reg_etapa_seq = _NEW_ETAPA.controle_reg_etapa_seq;
                this.proc_log_seq = _NEW_ETAPA.proc_log_seq;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
