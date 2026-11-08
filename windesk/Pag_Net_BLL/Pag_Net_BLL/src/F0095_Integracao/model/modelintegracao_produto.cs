using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao.model
{
 
    public class modelintegracao_produto : tbs.TbIntegracaoProduto
    {
        public modelintegracao_produto()
            : base()
        {

        }

        public void AtualizarStatusParaPendente(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            try
            {
                
                if (this.integracao_produto_seq == 0)
                {
                    throw new Exception("Seq de Integração de Produto não indicado"); 
                }
                this.integracao_status_cd = 2;
                string sql = "UPDATE TbIntegracao_Produto " +
                         "   set integracao_status_cd = " + this.integracao_status_cd.ToString() +
                         "   ,   dtlog_update = current_timestamp " + 
                         " WHERE integracao_produto_seq = " + this.integracao_produto_seq.ToString();
                this.__DataPost(_MyConnect, sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetScriptSqlCRUDPendente(integracaoTipoCd tipoIntegracao)
        {
            string scriptSQL = "";
            try
            {
     

                if (this.pr_cdproduto == 0 || this.prb_cdprodutobluesoft == 0 || this.prb_cdprodutobluesoftunitario == 0)
                    throw new Exception("Erro: Não foi informado todos os códigos dos produtos pr, prb_unit, prb_");


                this.integracao_tipo_cd = Convert.ToInt32(tipoIntegracao);

                if (   tipoIntegracao == integracaoTipoCd.i20004501_export_api_produto_preco_padrao 
                    || tipoIntegracao == integracaoTipoCd.i20008501_export_zanthus_produto)
                    this.prb_cdprodutobluesoft = this.prb_cdprodutobluesoftunitario;
                
                return scripts.f0095_15_integracaoProduto_CRUD.Get(Models.BDCommandTypes.DBINSERT, this);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
