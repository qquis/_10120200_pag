/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import moduleSistema from "../../m0001_sistema/mdo";

import model_zanthus_carga from "../model/model_zanthus_carga";

import serviceZanthusAtualizacaoDadosPrepararBasePrime from "./serviceAtualizacao.Carga.Dados.PrepararBasePrime";
import serviceAtualizacaoTabMercadoria from "./serviceAtualizacao.Carga.Dados.Mercadoria";
import serviceAtualizacaoTabRegrasFiscais from "./serviceAtualizacao.Carga.Dados.RegrasFiscais";
import serviceZanthusAtualizacaoDadosDecomposicao from "./serviceAtualizacao.Carga.Dados.Decomposicao";
import serviceAtualizacaoDadosVoucherPromocional from "./serviceAtualizacao.Carga.Dados.VoucherPromocional";
import serviceAtualizacaoDadosTipoVenda from "./serviceAtualizacao.Carga.Dados.TipoVendaBasePromocional";
import serviceAtualizacaoDadosTipoVendaQtde from "./serviceAtualizacao.Carga.Dados.TipoVendaBasePromocional";
import serviceAtualizacaoDadosZeusRetailCargaOxan from "./serviceAtualizacao.Carga.Dados.ZeusRetailCargaOxan";


import reportZanthus from "../report/report";

export default class serviceZanthusCarga  {


    static async start (parametro: any) : Promise<any> {




            let resultadoCarga = parametro;


        await clsTools.pagConsole(`${FLG_MODULO} | Processamento Iniciando...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        try { 






            /* Cria uma nova carga */
            let CARGA = await this.cargaDadosZanthusCriar(parametro)


            /* Inicia a carga */
            await this.cargaBaseZanthusPrepararBasePrime(CARGA)

            /* Inicia a carga */
            await this.cargaDadosZanthusIniciar(CARGA)

            /* Gera os produtos pendentes para a carga */
            await this.cargaDadosZanthusGerarProdutosPendentes(CARGA)
            
            /* Executa a carga criada */
            await this.cargaDadosZanthusProcessar(CARGA)
            
            /* Finaliza a carga */
            await this.cargaDadosZanthusFinalizar(CARGA)


            /*CONFERÊNCIAS*/

            await clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let numeroVoucherAtual = parseInt(clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`))

                let result = await reportZanthus.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual })
                let qtdePromocional = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0



            resultadoCarga.integracao_qtde_promocional = qtdePromocional;
            resultadoCarga.numero_voucher_atual = numeroVoucherAtual;


            let infoCarga = await reportZanthus.ZanthusCarga.get({ carga_uuid: CARGA.carga_uuid }) as any[]

            if (infoCarga.length > 0) {


                resultadoCarga.integracao_pendente_qtde = parseInt(infoCarga[0].qtd_unitario)
            }



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO start', e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Processamento finalizado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

            return resultadoCarga;
        }

    }

    static async cargaDadosZanthusCriar(parametro: any) : Promise<model_zanthus_carga> {
        let NovaCarga : model_zanthus_carga = new model_zanthus_carga()
        try { 

            await clsTools.pagConsole(`${FLG_MODULO} | Gerando Registro de Carga`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            
            NovaCarga.carga_uuid = clsTools.uuid(15,true)
            NovaCarga.carga_tipo_cd = parametro?.carga_tipo_cd

            let user_name = parametro.__systemUserConnect.user_name
            if (!user_name) {
                user_name = "sistema"
            }
            let usuario_sistema : any= await moduleSistema.Report.Usuario.getByUserName(user_name)
            
            let sis_us_seq = usuario_sistema.sis_us_seq
            if (!sis_us_seq || sis_us_seq <= 0) {
                sis_us_seq = 3
            }
            NovaCarga.carga_usr_seq_create = sis_us_seq;
            

            await this.__dataPrimeExecute(NovaCarga._Db_Pg_script_Insert())

            await clsTools.pagConsole(`${FLG_MODULO} | Registro de Carga gerado com sucesso UUID ${NovaCarga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO criarCarga', e);
        }
        finally {
            return NovaCarga;
        }
    }

    static async cargaBaseZanthusPrepararBasePrime(carga: model_zanthus_carga) {
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Preparando Base Prime para Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            await serviceZanthusAtualizacaoDadosPrepararBasePrime.start({carga_uuid: carga.carga_uuid})

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO PrepararBasePrime', e);
        }
    }

    static async cargaDadosZanthusIniciar(carga: model_zanthus_carga) { 
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Iniciando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            await this.__dataPrimeExecute(carga.scriptAtualizarStatusIniciar())
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO IniciarCarga', e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Iniciar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }

    }
    static async cargaDadosZanthusGerarProdutosPendentes(carga: model_zanthus_carga) {
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Gerando Produtos Pendentes para Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            await this.__dataPrimeExecute(carga.zanthusCargaProduto.scriptProdutosPendente(carga.carga_uuid, carga.carga_tipo_cd))

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO GerarProdutosPendentes', e);
        }
    }

    static async cargaDadosZanthusProcessar(carga: model_zanthus_carga) {
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Processando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            if (carga.carga_tipo_cd == 1) { 
                await serviceAtualizacaoTabMercadoria.start({carga_uuid: carga.carga_uuid})
                await serviceAtualizacaoTabRegrasFiscais.start({carga_uuid: carga.carga_uuid})
                await serviceZanthusAtualizacaoDadosDecomposicao.start({carga_uuid: carga.carga_uuid})
                await serviceAtualizacaoDadosTipoVenda.start({carga_uuid: carga.carga_uuid})
                await serviceAtualizacaoDadosTipoVendaQtde.start({carga_uuid: carga.carga_uuid})
                await serviceAtualizacaoDadosVoucherPromocional.start({carga_uuid: carga.carga_uuid})
                await serviceAtualizacaoDadosZeusRetailCargaOxan.start({carga_uuid: carga.carga_uuid})
            }

        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO ProcessarCarga', e);
        }
    }

    static async cargaDadosZanthusFinalizar(carga: model_zanthus_carga) { 
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Finalizando Carga UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            await this.__dataPrimeExecute(carga.scriptAtualizarStatusFinalizar())
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO FinalizarCarga', e);
        }
        finally {
            await clsTools.pagConsole(`${FLG_MODULO} | Finalizar Carga finalizada UUID ${carga.carga_uuid}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }

    }




    private static async __dataPrimeExecute(scriptSql: string) {
        try { 

            let myDataBase : clsBase = new clsBase()
            await myDataBase.myDataBase.pag.Execute(scriptSql)

        } 
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO dataBase', e);
        }

    }

}