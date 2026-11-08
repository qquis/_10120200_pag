
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import serviceParticipanteBlueSoftAPIImport from './serviceParticipanteBluesoftAPIImport'



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0011-Service | ServiceParticipanteBlueSoftAtualizarStatusCredito"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    
    
export default class serviceParticipanteBlueSoftAPIAtualizarStatusCredito { 
    static async start(parametros: any): Promise<void> {
       try { 


            const myclsBase = new clsBase();

            if (!parametros.cdpessoabluesoft || !parametros.status_credito_cd) {
                throw new Error('Código BlueSoft e status de crédito são obrigatórios.');
            }

            const url = `/clientes/${encodeURIComponent(parametros.cdpessoabluesoft)}`;
            const resposta = await myclsBase.blueSoftApi.api_get(url);
            const dadosOriginais = resposta.data;

            if (!dadosOriginais) {
                throw new Error('A API BlueSoft não retornou os dados do cliente.');
            }

            const limiteAtual = dadosOriginais.saldosDoCliente?.creditoLimite;

            if (typeof limiteAtual !== 'number' || !Number.isFinite(limiteAtual)) {
                throw new Error('O limite de crédito atual não foi retornado pela API BlueSoft.');
            }

            if (
                !dadosOriginais.nomeRazao ||
                !dadosOriginais.cpfCnpj ||
                !dadosOriginais.nomeAbreviado ||
                !dadosOriginais.dataCadastro ||
                !dadosOriginais.ultimaAlteracao ||
                !Array.isArray(dadosOriginais.contatos) ||
                !Array.isArray(dadosOriginais.enderecos)
            ) {
                throw new Error('A API BlueSoft não retornou todos os dados necessários para o PUT.');
            }

            const dados = {
                nomeRazao: dadosOriginais.nomeRazao,
                cpfCnpj: dadosOriginais.cpfCnpj,
                nomeAbreviado: dadosOriginais.nomeAbreviado,
                dataCadastro: dadosOriginais.dataCadastro,
                ultimaAlteracao: dadosOriginais.ultimaAlteracao,
                contatos: dadosOriginais.contatos,
                enderecos: dadosOriginais.enderecos,
                analiseCredito: {
                    limites: [
                        {
                            tipoLimiteSaldo: 'GERAL',
                            limite: limiteAtual,
                            status: parametros.status_credito_cd
                        }
                    ]
                }
            };

            let url_post = `/clientes/${dados.cpfCnpj}`;


            await myclsBase.blueSoftApi.api_put(url_post, dados);

            await serviceParticipanteBlueSoftAPIImport.start({cdpessoabluesoft: parametros.cdpessoabluesoft});
            


     
       } catch (e: any) {
           await clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIAtualizarStatusCredito.start()`, e, true);
           throw new Error(`modules | Participante | Error ${e.message}`);
       }
    }



  

}