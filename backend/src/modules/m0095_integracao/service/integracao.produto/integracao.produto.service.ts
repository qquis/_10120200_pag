import { clsBase, clsTools } from "../../../../model/modelbase";
import modelService_OLD  from "../../../../model/model.service-OLD";
import myTools from "../../../../tools/Tools";
import modelintegracao_produto from "../../model/modelintegracao_produto";
import modelintegracao_tipo from "../../model/modelintegracao_tipo";
import integracaoProdutoService_default from "./integracao.produto.service_default";



/* Tipo de Integrações disponíveis */
import integracaoProdutoService_20004501_Api_Preco from "./integracao.produto.service_20004501";
import integracaoProdutoService_20004502_Api_PrecoPromocional from "./integracao.produto.service_20004502";
import integracaoProdutoService_20002090_ImporteAPI_Produto from "./integracao.produto.service_20002090";
import integracaoProdutoService_20008501_Zanthus from "./integracao.produto.service_20008501";

const myDATABASE = new clsBase();



export default class integracaoProduto extends modelService_OLD {

    listProdutosPendentes : modelintegracao_produto[]
    myid_log : string 
 
    /* Modelo integração de Produto */
    // ---------------------------------------------------
    myIntegracaoDeProduto: integracaoProdutoService_default
    // ---------------------------------------------------

    constructor() {
        super();
        this.listProdutosPendentes = []
        this.myIntegracaoDeProduto = new integracaoProdutoService_default({})
        this.myid_log = `` 


        
    }

    async integrar(myIntegracaoProcessamento : modelintegracao_tipo, sis_batch_run_seq: number = 0, uuid_start: string = ``) 
    {

        if (uuid_start !== ``) this.serviceLoguuidStart = uuid_start;

        this.serviceSis_Batch_Run_Seq = sis_batch_run_seq;
        
        try {

            this.serviceLogTAG = `M0095_IntegCtrl_(2000)_B.CD_${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd}/SQ_${sis_batch_run_seq}/T_${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`
            
            this.myid_log = `M0095_IntegCtrl_(2000)_${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd}/${sis_batch_run_seq}/${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`
            await this._serviceLogRegister(`M0095_IntegCtrl_(2000)_ INFORMAÇÕES | Sis Batch Cd: ${myIntegracaoProcessamento.integracao_tipo.sis_batch_cd} / RUN SEQ ${sis_batch_run_seq} / TIPO ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`)

            // DEFINIÇÃO DO TIPO DE INTEGRAÇÃO
            await this.ProdutoServiceSetTipo(myIntegracaoProcessamento)


            // START 
            await this.myIntegracaoDeProduto.openstart(this)    

            
            
            if (!this._serviceBatchStatus())                 
                    return;
            
            


            /* OBTER PRODUTOS PENDENTES */
            await this._serviceLogRegister(`${this.myid_log} _ Produtos Pendentes (localizando)...`)
            this.listProdutosPendentes =  await this.myIntegracaoDeProduto.obterProdutosPendentes(this);
            myIntegracaoProcessamento.integracao_pendente_qtde = this.listProdutosPendentes.length
            



            /* PROCESSAR */
            await this._serviceLogRegister(`${this.myid_log} _ Produtos Pendentes Qtde : ${this.listProdutosPendentes.length}`)
            this.myIntegracaoDeProduto.integracao_pendente_qtde = this.listProdutosPendentes.length

            if (this.listProdutosPendentes.length > 0)
            {
                /*INICIALIZAÇÃO _ APENAS SE TIVER PRODUTOS PENDENTE ------------------------------------*/
                await this._serviceLogRegister(`${this.myid_log} _ Inicialização`)  
                await this.myIntegracaoDeProduto.Inicializar()
                
                //await this.ProdutoServiceGetTipoMetodo(myIntegracaoProcessamento)
                
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ Exportação para API/BLUE | Processando ...`)
                    await this.Export_toApiBluesoft()
                }

                /* ____________ Exportações para ZANTHUS ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.zanthus == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ Exportação para ZANTHUS | Processando ...`)
                    await this.Export_toZanthus()
                }                    

                /* ____________ Importações ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 0 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ Importando da API BLUE | Processando ...`)                            
                    await  this.Import()
                }
                
                
                await this._serviceLogRegister(`${this.myid_log} _ Finalização`)  
                await this.myIntegracaoDeProduto.Finalizar();

            }
            else {
                this._serviceLogRegister(`${this.myid_log} _ Sem Pendências/Registros a serem processadas`)
            }
            await this._serviceLogRegister(`${this.myid_log} _ Concluído`)
        }
        catch (e) {
            await myTools.pagConsole(`(ERROR) M0095 _ Integração integrar | Integracao.produto.service
                                      Method Integrar 
                                      Error Message \n ${e}`, true)
            await this._serviceLogRegister(`${this.myid_log} _ (ERROR) ${e}`)
            throw new Error()
        }
    }

    async CachClear(integracao_tipo_cd: number) : Promise<void> { 
        try { 

            if (!integracao_tipo_cd || integracao_tipo_cd == 0) {
                throw new Error(`M0095 | integracaoProduto | CachClear | O código do tipo de integração deve ser informado`)
            }

            

            let sql = `delete from tbintegracao_produto where integracao_tipo_cd = ${integracao_tipo_cd} and integracao_status_cd = 1`
            await myDATABASE.myDataBase.pag.Execute(sql);

        } catch (e) {
            clsTools.PagErrorException(`M0095 | integracaoProduto | CachClear`, 'DBPAG DELETE', e);
            throw new Error(`M0095 | integracaoProduto | CachClear | ${e}`)
        }
        finally {
            clsTools.pagConsole(`M0095 | integracaoProduto CachClear da integração ${integracao_tipo_cd} executado`)
        }
    }

    private async Export_toApiBluesoft() {
        try {

          
           // console.log(`QUANTIDADE DE ITEM A EXPORTAR ${this.listProdutosPendentes.length}` )

            for (let i = 0; i < this.listProdutosPendentes.length; i++) {

                try {
                   
                    if (await this.myIntegracaoDeProduto.ApiItemValidar(this.listProdutosPendentes[i])) {
                        await this.myIntegracaoDeProduto.ApiItemProcessar(this.listProdutosPendentes[i].ItemObjectIntegracao)
                        await this.listProdutosPendentes[i].statusSetAtualizado()
                    } else {
                        await this.listProdutosPendentes[i].statusSetFinalizar();
                    } 
                } catch (e) {
                    await this.listProdutosPendentes[i].statusSetError();
                }


            }
        }
        catch (e) {
            await this._serviceLogRegister(`Service integracaoProduto _ ProcessarExportacoesAPI | Error \n ${e}`)
            await myTools.pagConsole(`Service integracaoProduto _ ProcessarExportacoesAPI | Error \n ${e}`, true)
        }
    }

    private async Export_toZanthus() {
        try {
            await this.myIntegracaoDeProduto.processamentoLocal(this.listProdutosPendentes, this);
    }
        catch (e) {
            await this._serviceLogRegister(`Service integracaoProduto _ Export_toZanthus | Error \n ${e}`)
            await myTools.pagConsole(`Service integracaoProduto _ Export_toZanthus | Error \n ${e}`, true)
        }
        
    }

    private async Import() {
        try {
            //DEFINE EM QUAL BASE SERÁ LANÇADA 
            this.myDataBase_SERVER = "PAG" 
            this.serviceRegistroTotal = this.listProdutosPendentes.length - 1


            for await (const produto of this.listProdutosPendentes) {
                if (!await super._processPushScript(await this.myIntegracaoDeProduto.getStrCRUDPostGre(produto.ItemObjectIntegracao))) {
                    await this._serviceLogRegister(`Integração INTERROMPIDA - Status RUN FINALIZADO`)
                    break
                }
            }
            await super._processCheck(true);
        }
        catch (e) {
            await this._serviceLogRegister(`Service integracaoProduto _ ProcessarImportacao | Error \n ${e}`)
            await myTools.pagConsole(`Service integracaoProduto _ ProcessarImportacao | Error \n ${e}`, true)
        }
    }

      

    private async ProdutoServiceSetTipo(myIntegracaoProcessamento : modelintegracao_tipo) : Promise<void> {
        await this._serviceLogRegister(`${this.myid_log} _ constructor ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd}`)
        switch (myIntegracaoProcessamento.integracao_tipo.integracao_tipo_cd) {
            case 20004501: 
                this.myIntegracaoDeProduto = new integracaoProdutoService_20004501_Api_Preco(myIntegracaoProcessamento.integracao_tipo)
                break;
            case 20004502: 
                this.myIntegracaoDeProduto = new integracaoProdutoService_20004502_Api_PrecoPromocional(myIntegracaoProcessamento.integracao_tipo)
                break; 
            case 20008501: 
                this.myIntegracaoDeProduto = new integracaoProdutoService_20008501_Zanthus(myIntegracaoProcessamento.integracao_tipo)
                break;  
            case 20002090: 
                this.myIntegracaoDeProduto = new integracaoProdutoService_20002090_ImporteAPI_Produto(myIntegracaoProcessamento.integracao_tipo)
                break;                                                           
            default:
                this.myIntegracaoDeProduto = new integracaoProdutoService_default(myIntegracaoProcessamento.integracao_tipo)
                break;
        }

        this.myIntegracaoDeProduto.integracao_tipo_info.script_select = myIntegracaoProcessamento.integracao_tipo_info.script_select;
        this.myIntegracaoDeProduto.integracao_tipo_info.sis_batch_cd = myIntegracaoProcessamento.integracao_tipo_info.sis_batch_cd;

        //await this._serviceLogRegister(`${this.myid_log} _ Processando Tipo ${myIntegracaoProcessamento.integracao_tipo.integracao_tipo_descricao} (Batch) ${myIntegracaoProcessamento.sis_batch_descricao}`)
    }

    private async ProdutoServiceGetTipoMetodo(myIntegracaoProcessamento : modelintegracao_tipo) : Promise<void> {
        
        let TipoMetodo : Promise<void> = Promise.resolve();
        
        try {
                /* ____________ Exportações para API ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo EXportação | Processando ...`)
                    TipoMetodo =  this.Export_toApiBluesoft()
                }

                /* ____________ Exportações para ZANTHUS ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 1 && this.myIntegracaoDeProduto.integracao_tipo.zanthus == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo EXportação | Processando ...`)
                    TipoMetodo =  this.Export_toZanthus()
                }                    

                /* ____________ Importações ______________________________________*/
                if (this.myIntegracaoDeProduto.integracao_tipo.tipo_export == 0 && this.myIntegracaoDeProduto.integracao_tipo.bluesoft_api == 1) {
                    await this._serviceLogRegister(`${this.myid_log} _ A integração é do tipo IMportação | Processando ...`)                            
                    TipoMetodo =  this.Import()
                }

                return TipoMetodo
        } catch (e) { 
            return TipoMetodo;
        }
    }

}

