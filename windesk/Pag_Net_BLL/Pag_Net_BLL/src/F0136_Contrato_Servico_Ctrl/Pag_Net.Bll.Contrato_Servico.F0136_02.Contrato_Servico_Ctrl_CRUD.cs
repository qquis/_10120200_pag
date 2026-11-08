using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class F0136_02_Contrato_Servico_Ctrl_CRUD
    {
        private static string _VERSION() { return "f0136_02_1011922_contrato_servico_ctrl_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            model_Contrato_Servico_Ctrl CONTRATO_SERVICO_Ctrl
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, '{4}', '{5}', '{6}', {7})",
                    BDCommnadType.ToString(),
                    CONTRATO_SERVICO_Ctrl.contrato_servico_ctrl_seq.ToString(),
                    CONTRATO_SERVICO_Ctrl.contrato_servico_seq.ToString(),		
                    CONTRATO_SERVICO_Ctrl.controle_reg_seq.ToString(),			
                    CONTRATO_SERVICO_Ctrl.contrato_servico_ctrl_data.ToString("yyyy-MM-dd"),
                    CONTRATO_SERVICO_Ctrl.contrato_servico_ctrl_descritivo.ToString(),	
                    CONTRATO_SERVICO_Ctrl.contrato_servico_ctrl_observacao.ToString(),
                    CONTRATO_SERVICO_Ctrl.CONTROLE_REG.Pessoa_Get(91502).CartaoAcesso.cartao_acesso_seq.ToString()
                    ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
