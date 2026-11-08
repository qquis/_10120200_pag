import myTools from '../../../../tools/Tools';
import { clsBase, clsTools } from "../../../../model/modelbase"
import { ifilter_faturamento } from '../../wk'
import FaturamentoZanthus from '../faturamentozanthus/faturamentozanthus';
import Zanthus from '../Zanthus/Zanthus'
import modelFaturamentozanthus_Ctrl from '../../model/modelfaturamentozanthusctrl';
import modelsistema_ServiceBatch from '../../../m9030_sistema_batch/model/modelsistema_ServiceBatch';
import integrateZanthusCtrl from './integratezanthusctrl';



export default class integrateZanthusPag {
    //public static async Ctrl_Get (filter: ifilter_faturamentoZanthus): Promise<object> {
    public static async Start (_filter: ifilter_faturamento): Promise<object> {
        try {

            /* Controle de Path */
            let imodelsistema_batch: modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0); 

            //__console.log(`Parâmetro sis_bath_run_seq repassado ${_filter.post_integracao?.sis_batch_run_seq}`)

            if (_filter.post_integracao?.sis_batch_run_seq !== 0 )
                await imodelsistema_batch.modelConsultar(0, parseInt(`${_filter.post_integracao?.sis_batch_run_seq}`))
            
            //__console.log(`M0055_Faturamento - SIS BATCH IDENTIFICADO: ${imodelsistema_batch.sistema_batch.sis_batch_cd}`)

            /*
            if (_filter.post_integracao?.sis_batch_run_seq) {
                imodelsistema_batch.modelConsultar(0, parseInt(`${_filter.post_integracao?.sis_batch_run_seq}`)); 
            
            }*/
    




            /*Lista com Ecfs com dados Pendentes */
            let mylist_ECF_PENDENTES: Array<modelFaturamentozanthus_Ctrl>

            /*Processar dados da ECF*/
            await integrateZanthusCtrl._ECF_Atualizar_Integracao(_filter)

            /*Obter ECFS com dados Pendentes*/
            mylist_ECF_PENDENTES = await integrateZanthusCtrl._ECF_Obter_Pendentes(_filter)


            await myTools.pagConsoleLog(`Faturamento - Integração de Cupons | Numero de ECFS ${mylist_ECF_PENDENTES.length} `) 
            //console.log(`Faturamento - Integração de Cupons | Numero de ECFS ${mylist_ECF_PENDENTES.length} `)
            
            //console.log(mylist_ECF_PENDENTES)


            for await (let iTemECF_PENDENTE of  mylist_ECF_PENDENTES) {


                 await myTools.pagConsoleLog(`Faturamento - Integração de Cupons | Processando ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac}`)
                 //console.log(`Faturamento - Integração de Cupons | Processando ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} VALOR ZANTHUS ${iTemECF_PENDENTE.fz_valor} VALOR PAGA ${iTemECF_PENDENTE.fz_pag_valor}`)

                let NCupomPendente : number = 0 

                /*
                let messagecomparacao = `Comparando dados do ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} \n`
                messagecomparacao += ` ZANTHUS CUPOM ${iTemECF_PENDENTE.fz_cupom_qtde}  \n`
                messagecomparacao += ` ZANTHUS PAG ${iTemECF_PENDENTE.fz_pag_cupom_qtde} \n`
                messagecomparacao += ` PAG ${iTemECF_PENDENTE.fat_cupom_qtde} \n `


                messagecomparacao += `ZANTHUS - VALOR ${iTemECF_PENDENTE.fz_valor} \n`
                messagecomparacao += `ZANTHUS PAG - VALOR ${iTemECF_PENDENTE.fz_pag_valor} \n`
                messagecomparacao += `PAG - VALOR ${iTemECF_PENDENTE.fat_valor}`

                await clsTools.pagConsole(messagecomparacao, true, false)
                */

                // Se as bases estão diferentes então faz o processamento
                if (iTemECF_PENDENTE.fz_cupom_qtde !== iTemECF_PENDENTE.fz_pag_cupom_qtde 
                        ||  iTemECF_PENDENTE.fz_pag_valor !== iTemECF_PENDENTE.fz_valor 
                        ||  iTemECF_PENDENTE.fat_valor !== iTemECF_PENDENTE.fz_valor
                        ||  iTemECF_PENDENTE.fat_cupom_qtde !== iTemECF_PENDENTE.fz_cupom_qtde
                    )
                {

                    if (_filter?.post_integracao?.integracao_registro == "PENDENTE") {
                        if (iTemECF_PENDENTE.fz_pag_cupom_final > 5)
                        NCupomPendente = iTemECF_PENDENTE.fz_pag_cupom_final - 1
                        //console.log(`Numero do cupom que vai processar: ${NCupomPendente}`)
                    }

                    if (imodelsistema_batch.sistema_batch.sis_batch_cd) 
                    {
                        let status : boolean = await imodelsistema_batch.ModelStatus(parseInt(`${_filter.post_integracao?.sis_batch_run_seq}`))

                        if (!status) 
                        {
                            myTools.pagConsoleLog("M0055_Faturamento - Sisbatch está inativo e portando a execução será encerrada")
                            return Promise.resolve(mylist_ECF_PENDENTES);            
                        }
                        else { 
                            await myTools.pagConsoleLog("M0055_Faturamento - Batch irá continuar BATCH ATIVO")
                        }
                    }

        
                    //__console.log(`Processando ECF ${itemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac}`)
        
                    /* ____ PROCESSANDO OS CUPONS ___ */    
                    if (imodelsistema_batch.sistema_batch.sis_batch_cd) 
                        await imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`,`ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Processando`)
                    
                    await iTemECF_PENDENTE.__CupomProcessar(_filter, NCupomPendente);

                    /* ____ FATURANDO OS CUPONS ___ */    
                    if (imodelsistema_batch.sistema_batch.sis_batch_cd)  
                        await imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`,`ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Faturando`)

                    await iTemECF_PENDENTE.__CupomFaturar();


                    /* ____ ESTORNANDO OS CUPONS ___ */    
                    if (imodelsistema_batch.sistema_batch.sis_batch_cd)  
                        await imodelsistema_batch.ModelRegistrarLog(`5501_ZANTHUS`,`ECF ${iTemECF_PENDENTE.fat_zanthus_sat_ecf_m00ac} - Estornando Cancelados`)
                    
                    await iTemECF_PENDENTE.__ProcessarCancelados();

                }
            }

            await integrateZanthusCtrl.CtrlUpdatePagFaturamento(_filter)

            return Promise.resolve(mylist_ECF_PENDENTES);
        }
        catch(e) {
            await myTools.pagConsoleLog(`integrateZanthusPag | ${e}`)
            return Promise.reject({})
        }

    }



}