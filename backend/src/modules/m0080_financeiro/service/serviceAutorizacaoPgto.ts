import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";
import bluesoft_api from '../../Apis/bluesoftApi/url/bluesoftApiUrl'
import {modelAutorizacaoPagamento} from "../model/modelAutorizacaoPagamento";
import { modelReport } from "../../../model/model";
import modelsistema_ServiceBatch from '../../m9030_sistema_batch/model/modelsistema_ServiceBatch';


export default class serviceAutorizacaoPgto {

    public static async Atualizar(sis_batch_run_seq: number) : Promise<object> {
        
        let listTbAutorizacaoPagamento: modelAutorizacaoPagamento[] = []
        try {
            

            /*Controle Batch ---------------------------------------------------------------------- */
            let imodelsistema_batch: modelsistema_ServiceBatch = new modelsistema_ServiceBatch(0); 
            if (sis_batch_run_seq !== 0)
                await imodelsistema_batch.modelConsultar(0, parseInt(`${sis_batch_run_seq}`))
            /*--------------------------------------------------------------------------------------*/
    

            let TipoPagamentoTotal = 1 //0 ate 1
            let TipoPagamentoItem = 0
            for (TipoPagamentoItem = 0; TipoPagamentoItem <= TipoPagamentoTotal; TipoPagamentoItem++) {

                let PaginaNumeroTotal : number = 30;
                let PaginaNumeroAtual : number = 0;
        
                let stringSqlPostregInteg = `` 
                for (PaginaNumeroAtual = 0;  PaginaNumeroAtual <= PaginaNumeroTotal; PaginaNumeroAtual++) {
                    //console.log(`Processando a pagina de N. ${PaginaNumeroAtual}`)
                    
                    let TipoCobranca = TipoPagamentoItem == 0? `COBRANCA` : `PAGAMENTO` 
                    //console.log(`Atualizando a ${TipoCobranca}`)
                    
                    let result = await bluesoft_api.api_get(`financeiro/duplicatas?especie=${TipoCobranca}&dataAtualizacaoInicial=${myTools.pagDateTime_getDateStringShortBrBarra()} 00:01:01&exibirDuplicatasCanceladas=true&currentPage=${PaginaNumeroAtual}`);

                    if (result) 
                    {
                        stringSqlPostregInteg = ``
                        let myObject = Object.entries(result.data.data)
                        for (const [Key, value] of myObject) {
                            let registroAutorizacaoPagamento : modelAutorizacaoPagamento  = new modelAutorizacaoPagamento();
                            registroAutorizacaoPagamento.bindingBlueSoftApi(value)
                            stringSqlPostregInteg += registroAutorizacaoPagamento.getSqlBlueSoftIntegrar()
                            listTbAutorizacaoPagamento.push(registroAutorizacaoPagamento)
                        }
                        if (stringSqlPostregInteg !== ``)
                        {
                            await modelReport.Execute(stringSqlPostregInteg);
                        }
                            
                        
                        if (sis_batch_run_seq !== 0) { 

                            let status : boolean = await imodelsistema_batch.ModelStatus(parseInt(`${sis_batch_run_seq}`))
                            imodelsistema_batch.ModelRegistrarLog(`M0080_FIN_IMP`, `M0080_FIN_IMP ${PaginaNumeroAtual}/${PaginaNumeroTotal}` )
                            if (!status) {
                                clsTools.pagConsole("M0080_Financeiro - Sisbatch está inativo e portando a execução será encerrada ")
                                imodelsistema_batch.ModelRegistrarLog(`M0080_Financeiro_${sis_batch_run_seq}`, `Sisbatch está inativo e portando a execução será encerrada`)
                                return listTbAutorizacaoPagamento    
                            } 
                        }
                    }
                }

            }
            return listTbAutorizacaoPagamento
        }
        catch (e) {
            clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | Atualizar`, e)
            return listTbAutorizacaoPagamento;
        }
    } 

    public static async AtualizarDuplicata(parametros: any) : Promise<object> { 

        let myDataBase = new clsBase()
        
        let registroAutorizacaoPagamento : modelAutorizacaoPagamento  = new modelAutorizacaoPagamento();
        try {
        
        let resultBlueSoft = await bluesoft_api.api_get(`financeiro/duplicatas?exibirDuplicatasCanceladas=true&duplicataKey=${parametros.autpgto_seq_pk}`)
        
        let item : any = await myDataBase.myDataBase.RecordItem(resultBlueSoft.data.data,0)


        if (item) {
            await registroAutorizacaoPagamento.bindingBlueSoftApi(item)
            await myDataBase.myDataBase.pag.Execute(registroAutorizacaoPagamento.getSqlBlueSoftIntegrar());
        }
        } catch (e) { 
            clsTools.PagErrorException(`M0080`, `ServiceFinanceiro | AtualizarDuplicata`, e)
            
        }
        finally {
            return registroAutorizacaoPagamento 
        }
    }
}


