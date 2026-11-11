
import { clsTools, clsBase} from '../../../model/modelbase'

let myBase = new clsBase()

import serviceParticipanteBlueSoftAPIImport from './serviceParticipanteBluesoftAPIImport'



/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0011-Service | ServiceParticipanteBlueSoftAtualizarStatusCredito"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    
    
export default class serviceParticipanteBlueSoftAPIAtualizarStatusCreditoCorrecao { 
    static async start(parametros: any): Promise<void> {
       try { 


            const myclsBase = new clsBase();

            let sql = `SELECT     x.cdparticipante 
                              ,   b.cdpessoabluesoft 
                              ,   x.inscricaoestadual
                              ,   x.cpf_cnpj
                       FROM   tmp_participante_ie x
                       inner  join tbparticipante_bluesoft b on b.cdparticipante = x.cdparticipante  
                       where  1 = 1 
                       and x.processado = 0
                       order by b.cdpessoabluesoft 
                       limit 5
                       
                       `

            const result = await myclsBase.myDataBase.pag.DataGet(sql)
            
            let list : any[] = result as any[]



            for (let itemACorrigir of list) {

                const url = `/clientes/${encodeURIComponent(itemACorrigir.cdpessoabluesoft)}`;
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
                    inscricaoEstadual: itemACorrigir.inscricaoestadual, 
                    analiseCredito: {
                        limites: [
                            {
                                tipoLimiteSaldo: 'GERAL',
                                limite: limiteAtual,
                                status: 'CREDITO_OK',
                                podeProtestar: true
                            }
                        ]
                    }
                };




                let url_post = `/clientes/${dados.cpfCnpj}`;


                await myclsBase.blueSoftApi.api_put(url_post, dados);

                let sql_status = `update tmp_participante_ie set processado = 1 where cdparticipante = ${itemACorrigir.cdparticipante}`;
                await myclsBase.myDataBase.pag.Execute(sql_status);
                console.log(`codigo blue ${itemACorrigir.cdpessoabluesoft} `)

            }

            

     
       } catch (e: any) {
           await clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIAtualizarStatusCredito.start()`, e, true);
           throw new Error(`modules | Participante | Error ${e.message}`);
       }
    }



  

}