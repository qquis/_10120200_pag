using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0095_Integracao
{

    public enum integracaoTipoCd
    {
        i20004501_export_api_produto_preco_padrao = 20004501,
        i20004502_export_api_produto_preco_promocional = 20004502,
        i20008501_export_zanthus_produto = 20008501,
        i20002090_import_api_produto = 20002090
    }

    public class _index 
    {
        
        public _indexReport reports; 
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        public model.modelintegracao_produto modelIntegracaoProduto;

        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect) { _constructor(_MyConnect, 0); }
        public _index(Pag_Net.Models.modelSistemaUsuario _MyConnect, int integracao_cd) { _constructor(_MyConnect, integracao_cd); }

        private void _constructor(Pag_Net.Models.modelSistemaUsuario _MyConnect, int integracao_cd)
        {
            MyConnect = _MyConnect;
            reports = new _indexReport(MyConnect, integracao_cd);
            modelIntegracaoProduto = new model.modelintegracao_produto();
        }

        public void selecionarIntegracaoProduto(int integracao_produto_seq)
        {
            try
            {
                modelIntegracaoProduto.integracao_produto_seq = integracao_produto_seq;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GerarPendenciaPrecoD1(int integracao_tipo_cd)
        {
            try
            {
                RESTAPI.post(MyConnect.PAG_API + "/integracao/service/atualizarPendenciaPrecoD1?integracao_tipo_cd=" + integracao_tipo_cd.ToString(), null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
