/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA VIA DESKTOP"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    





import { clsBase, clsTools } from "../../../model/modelbase";


import reportZanthus from "../report/report";

import serviceZanthusCargaOld from "./serviceAtualizacao.Carga.Processar.old";
import serviceZanthusCarga from "./serviceAtualizacao.Carga.Processar.new";


export default class serviceAtualizacaoDeskTop  {

    static async start(parametros: any) : Promise<any> {

        let resultadoCarga : any;
          
          
                parametros.integracao_tipo_cd = 0,
                parametros.integracao_tipo_descricao = "NÃO IDENTIFICADA",
                parametros.tipoCarga = parametros.TipoCompleta ? `COMPLETA` : `PARCIAL`,
                parametros.integracao_pendente_qtde = 0,
                parametros.integracao_qtde_promocional = 0,
                parametros.numero_voucher_atual = 0,
                parametros.carga_tipo_cd = 1



        try { 

            await clsTools.pagConsole(`${FLG_MODULO} - **** CARGA DE DESKTOP INICIADA ****`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await clsTools.pagConsole(`${FLG_MODULO} - ***********************************`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            await clsTools.pagConsole(`${FLG_MODULO} - TIPO DE CARGA SELECIONADA NO .ENV ${process.env.ZANTHUS_TIPO_CARGA}`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)

            if (process.env.ZANTHUS_TIPO_CARGA === "REFORMA_TRIBUTARIA") {
                await clsTools.pagConsole(`${FLG_MODULO} - CARGA REFORMA_TRIBUTARIA - OLD`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                await serviceZanthusCargaOld.start(parametros)
                parametros.integracao_tipo_descricao = "CARGA TIPO REFORMA_TRIBUTARIA OLD"
            }

            
            if (process.env.ZANTHUS_TIPO_CARGA === "REFORMA_TRIBUTARIA_NEW") {
                await clsTools.pagConsole(`${FLG_MODULO} - CARGA REFORMA_TRIBUTARIA - NEW`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
                await serviceZanthusCarga.start(parametros)
                parametros.integracao_tipo_descricao = "CARGA TIPO REFORMA_TRIBUTARIA NEW.2026"
            }



            
            parametros.integracao_qtde_promocional = await this.conferirVoucher(parametros);

            
            

        }
        catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
           
        }


        finally {
            await clsTools.pagConsole(`${FLG_MODULO} - FIM DO PROCESSO DE CARGA`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            return parametros;
        }

    }
    private static async conferirVoucher(resultadoCarga: any) : Promise<number> {
        try { 
            await clsTools.pagConsole(`${FLG_MODULO} - Conferindo o Voucher`, false, false, FLG_DEBUG_FILE_CONSOLE_LOG)
            let numeroVoucherAtual = parseInt(clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`))

            let result = await reportZanthus.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual })
            let qtdePromocional = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0

 
            return qtdePromocional;
        }
        catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'conferirVoucher', e, false, "ERRO AO CONFERIR VOUCHER", FLG_DEBUG_FILE_CONSOLE_LOG);
            return 0;
        }
    }



}