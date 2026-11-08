import { clsBase, clsTools } from "../../../model/modelbase";
import modelService_OLD from "../../../model/model.service-OLD";
import modelintegracao_tipo from "../model/modelintegracao_tipo";
import integracaoProduto from "./integracao.produto/integracao.produto.service";
import myTools from "../../../tools/Tools";

import zanthusService from "../../../modules/m0085_zanthus/service/service";
let myZanthusService : zanthusService = new zanthusService();

export default class serviceIntegracao extends modelService_OLD {
    myListIntegracaoTipo : modelintegracao_tipo[] 

    constructor() {
        super()
        this.serviceLogTAG = "M0095_IntegCtrl"
        this.myListIntegracaoTipo = []
    }

    public async processar(sis_batch_cd : number, sis_batch_run_seq : number, uuid_start: string = ``, sis_nucleo_prc_cd : number = 0) : Promise<Array<modelintegracao_tipo>> {
        try {
        
            if (uuid_start !== ``) this.serviceLoguuidStart = uuid_start;
            this.serviceSis_Batch_Run_Seq = sis_batch_run_seq;

            await this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} Run Seq ${sis_batch_run_seq} | Init`);
            
            
            /*Buscar a lista de modelintegracao e atualizar o this.myListIntegracaoTipo */
            await this.ObterTipoDeIntegracao(sis_batch_cd, sis_batch_run_seq, sis_nucleo_prc_cd)

            await this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} Run Seq ${sis_batch_run_seq} | N. de Batchs detectados ${this.myListIntegracaoTipo.length}`);

  

            if (this.myListIntegracaoTipo.length > 0 )
            {
                for await (const integracaoTipo of this.myListIntegracaoTipo) {
                    await this._serviceLogRegister(`M0095_IntegCtrl Ctl B.Cd ${sis_batch_cd} RS ${sis_batch_run_seq} | Start ${integracaoTipo.integracao_tipo.integracao_tipo_cd}_${integracaoTipo.integracao_tipo.integracao_tipo_descricao}`);
                    switch(integracaoTipo.integracao_tipo.integracao_cd) {
                        case 1000: 
                            break;
                        case 2000: 
                            
                            const IntegracaoTipoProduto = new integracaoProduto()
                            
                            await IntegracaoTipoProduto.integrar(integracaoTipo, sis_batch_run_seq, this.serviceLoguuidStart)
                            break;                        
                    }                      
                }
            }   
            await this._serviceLogRegister(`Control sis_batch_cd ${sis_batch_cd} sis_batch_run_seq ${sis_batch_run_seq} | Encerrado`);
            return this.myListIntegracaoTipo;    

        } catch (e) {
            myTools.pagConsole(`Reports | Error \n ${e}`, true)    
            throw new Error(`M0095 | Error \n ${e}`)   
        } 
    }

    public async ClearCache(integracao_tipo_cd: number, ) : Promise<void> {
        try { 
          
            //Por enquanto serão processadas apenas clearcach de integração do tipo de produtos
        
            const IntegracaoTipoProduto = new integracaoProduto()
            await IntegracaoTipoProduto.CachClear(integracao_tipo_cd)
   

        } catch (e) {   
            clsTools.PagErrorException(`M0095 | integracaoProduto | CachClear`, 'CachClear', e);
            throw new Error(`M0095 | integracaoProduto | CachClear | ${e}`)
        } finally {
            clsTools.pagConsole(`M0095 | integracaoProduto CachClear da integração ${integracao_tipo_cd} executado`)
        }

    }
    
    public async ObterTipoDeIntegracao(sis_batch_cd : number, sis_batch_run_seq : number, sis_nucleo_prc_cd: number = 0, integracao_tipo_cd : number = 0 ) : Promise<void> {
        let mylistIntegracaoTipo : modelintegracao_tipo[] = []
        try {
            let sql: string = ` select      tp.integracao_tipo_cd
                                        ,   tp.integracao_cd
                                        ,   tp.integracao_tipo_descricao
                                        ,   tp.zanthus 
                                        ,   tp.bluesoft_redshift
                                        ,   tp.bluesoft_api
                                        ,   tp.tipo_export
                                        ,   tp.tipo_import
                                        ,   x.sis_batch_cd
                                        ,   cast(0 as int) as integracao_pendente_qtde
                                        ,   x.script_select 
                                        ,   b.sis_batch_descricao 
                                from        tbintegracao_tipo       tp 
                                inner join  tbintegracao_tipo_info  x  on x.integracao_tipo_cd = tp.integracao_tipo_cd
                                left  join  tbsistema_batch         b  on b.sis_batch_cd = x.sis_batch_cd
                                where    1 = 1  
                                ${(sis_batch_run_seq !== 0 ?  ` and x.sis_batch_cd in 
                                                                       ( select xx.sis_batch_cd 
                                                                         from   tbsistema_batch_run xx 
                                                                         where  1 = 1
                                                                         and    xx.sis_batch_run_seq = ${sis_batch_run_seq} ) 
                                                                         `  
                                                         : ``)}  
                                                               
                                ${(sis_batch_cd !== 0 ? ` and x.sis_batch_cd = ${sis_batch_cd} ` : ``)} 

                                ${(sis_nucleo_prc_cd !== 0 ? ` and x.sis_nucleo_prc_cd = ${sis_nucleo_prc_cd} ` : ``)}

                                ${(integracao_tipo_cd !== 0 ? ` and tp.integracao_tipo_cd = ${integracao_tipo_cd} ` : ``)}

                                order by tp.integracao_tipo_cd asc `
            
            let result = await this.DataGet(sql)


            for await (const[key, value] of Object.entries(result)) {
                let itemModelIntegracao_Tipo : modelintegracao_tipo = new modelintegracao_tipo(value)
                await mylistIntegracaoTipo.push(itemModelIntegracao_Tipo)
            }
            
            this.myListIntegracaoTipo = mylistIntegracaoTipo

        } catch (e) {
            myTools.pagConsole(`Reports | Error \n ${e}`, true) 
            throw new Error(`M0095 | Error \n ${e}`)          
        }
    }

    public async CargaLoja(TipoCompleta : boolean = false) : Promise<any> {
        
        let modelIntegracaoTipo : modelintegracao_tipo = new modelintegracao_tipo()


        let resultadoCarga = { 
                integracao_tipo_cd: 0,
                integracao_tipo_descricao: "NÃO IDENTIFICADA",
                tipoCarga: TipoCompleta ? `COMPLETA` : `PARCIAL`,
                integracao_pendente_qtde: 0,
                integracao_qtde_promocional: 0
            }

        try { 

            let sis_batch_cd : number = 85002; /*CARHA PARCIAL*/

            if (TipoCompleta) 
                sis_batch_cd = 85001; /*CARGA COMPLETA*/

            let sis_batch_run_seq : number = 0;


            let result : any = await this.processar(sis_batch_cd, sis_batch_run_seq)

            if (result.length > 0)
                modelIntegracaoTipo = result[0] 
            
            resultadoCarga.integracao_tipo_cd =  modelIntegracaoTipo.integracao_tipo.integracao_tipo_cd
            resultadoCarga.integracao_tipo_descricao = modelIntegracaoTipo.integracao_tipo.integracao_tipo_descricao
            resultadoCarga.tipoCarga =  TipoCompleta ? `COMPLETA` : `PARCIAL`
            resultadoCarga.integracao_pendente_qtde =  modelIntegracaoTipo.integracao_pendente_qtde

            let qtdePromocional = await myZanthusService.ZeusRetailConferirVoucher()

            resultadoCarga.integracao_qtde_promocional = qtdePromocional;


        } catch(e) {
            clsTools.pagConsole(`Reports | Error \n ${e}`, true)    
            throw new Error(`M0095 | Error \n ${e}`)

        } finally { 
            return resultadoCarga
        }
    
    }
}


