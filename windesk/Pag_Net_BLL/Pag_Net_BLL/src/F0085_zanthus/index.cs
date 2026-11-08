using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F0085_zanthus
{
    public class _index
    {

    }

    public static class AtualizacaoPrecoZanthus
    {

        public static object AtualizarDadosGerais(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                object resultado;

                resultado = Pag_Net.Bll.RESTAPI.post(string.Format("{0}/integracao/service/integrar?sis_batch_cd=85001&sis_batch_run_seq=0", MyConnect.PAG_API), null);

                return resultado;


                //throw new Exception(MyConnect.PAG_API + " -- \n" + resultado.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static Pag_Net.src.F0085_zanthus.model.modelResultadoCarga CargaLoja(Pag_Net.Models.modelSistemaUsuario MyConnect, bool completa)
        {
            try
            {



                Pag_Net.src.F0085_zanthus.model.modelResultadoCarga carga = new Pag_Net.src.F0085_zanthus.model.modelResultadoCarga();
                
                int sis_batch_cd = 85002;

                if (completa)
                   sis_batch_cd = 85001;

                carga = Pag_Net.src.F0085_zanthus.model.modelResultadoCarga.getJson(Pag_Net.Bll.RESTAPI.post(string.Format("{0}/zanthus/service/atualizacao-geral", MyConnect.PAG_API, sis_batch_cd.ToString()), null, MyConnect.sis_us_seq, MyConnect.user_name).ToString());

                //resultado = Pag_Net.Bll.RESTAPI.post(string.Format("{0}/integracao/service/integrar?sis_batch_cd={1}&sis_batch_run_seq=0", MyConnect.PAG_API, sis_batch_cd.ToString()), null);
                
                //if (completa)
                //{
                 //   carga = C
                //}
                //else
                //{
                //    carga = Pag_Net.src.F0085_zanthus.model.modelResultadoCarga.getJson(Pag_Net.Bll.RESTAPI.post(string.Format("{0}/integracao/service/cargaLojaParcial", MyConnect.PAG_API, sis_batch_cd.ToString()), null).ToString());
                //}

                return carga;
                //throw new Exception(MyConnect.PAG_API + " -- \n" + resultado.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        public static void CargaLojaLimparCachProduto(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                Pag_Net.Bll.RESTAPI.post(string.Format("{0}/integracao/service/cacheClear?integracao_tipo_cd=20008501", MyConnect.PAG_API), null);

                //throw new Exception(MyConnect.PAG_API + " -- \n" + resultado.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

    }
}
