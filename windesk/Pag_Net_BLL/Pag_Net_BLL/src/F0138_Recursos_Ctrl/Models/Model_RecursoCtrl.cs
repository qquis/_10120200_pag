using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0138_Recurso_Ctrl;

namespace Pag_Net.Bll.F0138_Recurso_Ctrl
{
    public class Model_RecursoCtrl : TbRecurso_Ctrl
    {
        public Pag_Net.Bll.F0035_Ativo.Models.Model_TbAtivo ATIVO;
        public Model_RecursoCtrl()
            : base()
        {
            _modelConstructor();
        }

        private void _modelConstructor()
        {
            ATIVO = new F0035_Ativo.Models.Model_TbAtivo();
        }

        public void Registrar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                this.CONTROLE_REG.Update(MyConnect);
                CONTROLE_REG.Update_Etapa(MyConnect, CONTROLE_REG.Etapa_Atual_Get().controle_etapa_cd, CONTROLE_REG.Etapa_Proxima_Get().controle_etapa_cd, 1);
                this.__Atualizar(MyConnect);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                this.CONTROLE_REG.Binding(MyConnect, CONTROLE_REG.Controle);
                base.__Consultar(MyConnect);
                if (this.at_seq != 0)
                {
                    ATIVO.at_seq = this.at_seq;
                    ATIVO.__ModelConsultar(MyConnect);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void _Etapa_Step(Pag_Net.Models.modelSistemaUsuario MyConnect, int Etapa_a_CONSIDERAR)
        {
            try
            {
                //CONTROLE_REG.Etapa_Atual_Get();
                int SEQ_ETAPA = CONTROLE_REG.Etapa_Proxima_Get().controle_reg_etapa_seq ;

                int STATUS_ATUAL = this.CONTROLE_REG.controle_status_cd;

                if (Etapa_a_CONSIDERAR == 0)
                    Etapa_a_CONSIDERAR = this.CONTROLE_REG.Local_controle_etapa_cd_proxima;

                if (Etapa_a_CONSIDERAR > this.CONTROLE_REG.controle_etapa_cd_final) throw new Exception("Não há mais etapa a ser processada");

                if (Etapa_a_CONSIDERAR == 12006)
                {
                    if (STATUS_ATUAL == 1)
                        STATUS_ATUAL = 2;
                }


                if (Etapa_a_CONSIDERAR == 12004)
                {
                    if (this.ATIVO.at_seq != 0 && this.recurso_ctrl_utiliza_ativo == 1)
                    {
                        this.at_seq = this.ATIVO.at_seq;
                        this.__Atualizar(MyConnect); /* Atualização do código do ativo no CONTROLE */ 
                        this.ATIVO.__Consultar(MyConnect);
                        this.ATIVO.__ModelRegistros_Incluir(MyConnect, SEQ_ETAPA, F0035_Ativo.enumTipoMovimentacao.SAIDA, "Controle: " + this.CONTROLE_REG.controle_reg_seq.ToString() + " SAÍDA ");
                    }
                }

                if (Etapa_a_CONSIDERAR == 12005)
                {
                    if (this.ATIVO.at_seq != 0 && this.recurso_ctrl_utiliza_ativo == 1)
                    {
                        this.at_seq = this.ATIVO.at_seq;
                        this.__Atualizar(MyConnect); /* Atualização do código do ativo no CONTROLE */
                        this.ATIVO.__Consultar(MyConnect);
                        this.ATIVO.__ModelRegistros_Incluir(MyConnect, SEQ_ETAPA, F0035_Ativo.enumTipoMovimentacao.ENTRADA, "Controle: " + this.CONTROLE_REG.controle_reg_seq.ToString() + " RETORNO ");
                    }
                }

                this.CONTROLE_REG.Update_Etapa(MyConnect, this.CONTROLE_REG.controle_etapa_cd_atual, Etapa_a_CONSIDERAR, STATUS_ATUAL);
                base.__Atualizar(MyConnect);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
