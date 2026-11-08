/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service (Básico PRINCIPAL) "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    




import 'dotenv/config'
import { clsBase, clsTools } from "../../../model/modelbase";
import modelService_OLD from "../../../model/model.service-OLD";
import DataBase from "../../../database/DataBase";
import myTools from "../../../tools/Tools";



import f0085_10_zanthusprocessamento from "../scriptsPg/f0085_10_zanthusprocessamento";
import f0085_50_zanthus_carga_decomposicao from "../scriptsPg/f0085_50_zanthus_carga_decomposicao";
import f0085_51_zanthus_carga_tributacao from "../scriptsPg/f0085_51_zanthus_carga_basetributaria";
import f0085_52_zanthus_carga_log from "../scriptsPg/f0085_52_zanthus_carga_log";
import f0085_53_zanthus_carga_regra_icms from "../scriptsPg/f0085_53_zanthus_carga_tabregra_icms";
import f0085_54_zanthus_carga_tabmercadoria from "../scriptsPg/f0085_54_zanthus_carga_mercadoria";
import f0085_55_zanthus_carga_preco_voucher from "../scriptsPg/f0085_55_zanthus_carga_preco_voucher";


import reportZanthus from "../report/report";
import scriptUpdateZanthusVoucherPromocional from "../scriptsPg/scriptUpdateZanthusVoucherPromocional";
import zeusRetailOxanCarga from "../scriptsPg/scriptUpdateZanthusZeusRetailOxanCarga";






let myDATABASE : DataBase = new DataBase(); 

export default class zanthusService extends modelService_OLD {
    constructor() {
        super();
    }

    async PrepararDadosZanthusNaBasePag(AtualizacaDadosBasicos : boolean = false) : Promise<void> {
        try {


                //CARGA DECOMPOSIÇÃO
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_50_zanthus_carga_decomposicao.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.pag.Execute(f0085_50_zanthus_carga_decomposicao.ScriptExecute())

                //CARGA TRIBUTAÇÃO
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_51_zanthus_carga_tributacao.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.pag.Execute(f0085_51_zanthus_carga_tributacao.ScriptExecute())

                //CARGA LOG
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_52_zanthus_carga_log.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.pag.Execute(f0085_52_zanthus_carga_log.ScriptExecute())

                //CARGA REGRA ICMS
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_53_zanthus_carga_regra_icms.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.pag.Execute(f0085_53_zanthus_carga_regra_icms.ScriptExecute())

                //CARGA TAB MERCADORIA
                await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_54_zanthus_carga_tabmercadoria.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await myDATABASE.pag.Execute(f0085_54_zanthus_carga_tabmercadoria.ScriptExecute())
                
                /*  DADOS BASICOS (Padrão FALSE)
                    Não sendo atualização de dados básicos será atualizado preços também.
                */
                if (!AtualizacaDadosBasicos) {
                    //CARGA PREÇO VOUCHER
                    await clsTools.pagConsole(`${FLG_MODULO} | Executando script ${f0085_55_zanthus_carga_preco_voucher.sqlScript_VERSION()}`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                    await myDATABASE.pag.Execute(f0085_55_zanthus_carga_preco_voucher.ScriptExecute())
                }
     
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'PrepararDadosZanthusNaBasePag', e);
            throw new Error( `F0085 | zanthusService Metodo: atualizarBaseZanthus() ${e}`)
        }

    }


    async AtualizarVoucherPromocionais() : Promise<void> {
        try {

                await clsTools.pagConsole(`${FLG_MODULO} | ATUALIZANDO VOUCHER`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
                await this._serviceLogRegister(`${FLG_MODULO} | Gerando VOUCHER na base ZANTHUS`, false)

                let MyDataBASE : DataBase = new DataBase();
                let script : string = await  scriptUpdateZanthusVoucherPromocional.ScriptExecute(`ZANTHUSPOSTGRE`)
                
                await MyDataBASE.zanthusPostgre.Execute(script)
                
                await this._serviceLogRegister(`Finalizado VOUCHER na base ZANTHUS`, true)


        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'AtualizarVoucherPromocionais', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            throw new Error( `F0085 | zanthusService Metodo: AtualizarVoucherPromocionais() ${e} `)
        }
    }

    async ZeusRetailCargaOxan() : Promise<void> {
        try {

            await clsTools.pagConsole(`${FLG_MODULO} | Executando ZeusRetailCargaOxan na base ZEUSRETAIL`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
            
            await this._serviceLogRegister(`${FLG_MODULO} | Zanthus.CargaLoja() Prod. de Conf ini`, false)
            await myDATABASE.zanthusPostgre.Execute(zeusRetailOxanCarga.ScriptExecute(`ZANTHUSPOSTGRE`))
            await this._serviceLogRegister(`${FLG_MODULO} | Zanthus.CargaLoja() Prod. de Conf fim`, false)
        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'ZeusRetailCargaOxan', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            throw new Error( `F0085 | zanthusService Metodo: ZeusRetailCargaOxan() ${e} `)
        }
    }

    async ZeusRetailConferirVoucher(parametros: any = {}) : Promise<number> {
        await clsTools.pagConsole(`${FLG_MODULO} | Executando ZeusRetailConferirVoucher na base ZEUSRETAIL`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG);
        let qtdeVouchers : number = 0 
        try {
                let numeroVoucherAtual = parametros.cod_voucher || clsTools._datemomentDateToStr(new Date(), `YYYYMMDD`)

                let result = await reportZanthus.ZeusVoucherQtdeProdutos({ cod_voucher: numeroVoucherAtual })
                qtdeVouchers = Array.isArray(result) ? result[0].qtde_voucher_promocional_prd : 0
            
        } catch (e) {
            await clsTools.PagErrorException(`${FLG_MODULO}`, 'ZeusRetailConferirVoucher', e, false, "PROCESSO DE CARGA COM ERRO", FLG_DEBUG_FILE_CONSOLE_LOG);
            throw new Error( `F0085 | zanthusService Metodo: ZeusRetailConferirVoucher() ${e}`) 
        } finally { 
            return qtdeVouchers
        }

    }


}