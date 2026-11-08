
import 'dotenv/config'
import { clsBase, clsTools } from "../../../../model/modelbase";
import integracaoProdutoService_default from "./integracao.produto.service_default";
import myTools from "../../../../tools/Tools";
import modelintegracao_produto from "../../model/modelintegracao_produto";
import DataBase from "../../../../database/DataBase";
import reportZanthusProduto from "../../../m0085_zanthus/report/report.ZanthusTab";
import zanthusService from "../../../../modules/m0085_zanthus/service/service";
import modelService_OLD from "../../../../model/model.service-OLD";






const myDATABASE = new DataBase(); 

let myZanthuService : zanthusService = new zanthusService(); 


export default class integracaoProdutoService_20008501_Zanthus extends integracaoProdutoService_default {



    constructor(item : any) {
        super(item)
        
    }
  
    async openstart(service : modelService_OLD): Promise<void> {
        try {

            await service._serviceLogRegister(`_ Carga OpenStart | Carga de Banco Iniciando... `)

            await myZanthuService.PrepararDadosZanthusNaBasePag();
       
       
       
        } catch(e) {
           myTools.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                               Método: Inicializar
                               ${e}
                             `)
           throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                               Método: Inicializar
                               ${e}
                             `)
       }        
    }

    async Inicializar(): Promise<void> {
        try {
                myTools.pagConsole(`integracaoProdutoService_20008501_Zanthus inicializado `)
        } catch(e) {
            myTools.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                Método: Inicializar
                                ${e}
                              `)
            throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                Método: Inicializar
                                ${e}
                              `)
        }
    }

    async obterProdutosPendentes(service : modelService_OLD): Promise<modelintegracao_produto[]> {
  
        let mylist : modelintegracao_produto[] = []
        try {
            let myreportZanthusProduto : reportZanthusProduto  = new reportZanthusProduto()


            //console.log(`Tipo de processo de carga escolhido ${this.integracao_tipo.sis_batch_cd}`)
 
            
            /*
                Definindo o Select de Produtos Pendentes ou não de acordo com o código da carga
                Carga Completa........... Cod. 85001
                
                Carga Produto Pendente... Cod. 85002
            */
            let myProdutosPendentes: boolean = false; 
            if (this.integracao_tipo.sis_batch_cd == 85001) myProdutosPendentes = false;
            if (this.integracao_tipo.sis_batch_cd == 85002) myProdutosPendentes = true;
           
           
            await myreportZanthusProduto.Select({ProdutosPendentesDeIntegracao : myProdutosPendentes})

 
 
 
            let script_PRODUTOS : string = `
                        SELECT      pr.pr_cdproduto
                                ,   pr.prb_cdprodutobluesoft 
                                ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                ,   pr.pr_descricao 
                                ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                ,   cast(20008501 as int) as integracao_tipo_cd 
                        from tbproduto pr
                        left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                                          and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                                          and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                                          and ix.integracao_tipo_cd = 20008501
                        where 1 = 1 `

                        if (this.integracao_tipo.sis_batch_cd == 85001) {
                             // selects any product regardless of whether it is in the "integration table"
                             script_PRODUTOS += `
                                    and pr.pr_cdproduto > 0  `
                        }

                        if (this.integracao_tipo.sis_batch_cd == 85002) {
                            // select only the products that are in the integration table

                            script_PRODUTOS += `
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `
                            
                        }


            script_PRODUTOS += `union 



                         select 	  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  as prb_cdprodutobluesoftunitario
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0) as integracao_produto_seq
                                    ,   cast(20008501 as int) as integracao_tipo_cd 
                            from 		tbproduto_composicao cp 
                            inner join 	tbproduto pr on pr.prb_cdprodutobluesoft = cp.prb_cdprodutobluesoft_unitario
                            left join  tbintegracao_produto ix on ix.pr_cdproduto = pr.pr_cdproduto 
                                    and ix.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft
                                    and ix.prb_cdprodutobluesoftunitario = pr.prb_cdprodutobluesoft
                                    and ix.integracao_tipo_cd = 20008501
                            where 1 = 1 `

                        if (this.integracao_tipo.sis_batch_cd == 85002) {
                            // select only the products that are in the integration table

                            script_PRODUTOS += `
                                and coalesce(ix.integracao_produto_seq, 0) <> 0 
                                and ix.integracao_status_cd = 2
                                `
                            
                        }                            
            script_PRODUTOS += `
                            group by  pr.pr_cdproduto
                                    ,   pr.prb_cdprodutobluesoft 
                                    ,   pr.prb_cdprodutobluesoft  
                                    ,   pr.pr_descricao 
                                    ,   coalesce(ix.integracao_produto_seq, 0)
                                    ,   cast(20008501 as int) 

                `





            script_PRODUTOS += " order by 1 asc "

            //console.log(script_PRODUTOS)

            let resultPRODUTO : any = await myDATABASE.pag.DataGet(script_PRODUTOS)

            if (myreportZanthusProduto.listTabMercadoria.length > 0 ){
                for await ( const[key, value] of Object.entries(resultPRODUTO)) {
                    let myitem : modelintegracao_produto = new modelintegracao_produto(value)            
                    await myitem.model_zanthus_produto.binding_mercadoria(
                        myreportZanthusProduto.listTabMercadoria, 
                        myreportZanthusProduto.listTabRegrasIcms,
                        myreportZanthusProduto.listTabMercadoriaTipoVenda,
                        myreportZanthusProduto.listTabMercadoriaTipoVendaQtde, 
                        myreportZanthusProduto.listTabProdutoDecomposicao, 
                        myreportZanthusProduto.listTabProdutoDecomposicaoInsum
                    )
                    mylist.push(myitem)
                } 
            }


           await myTools._wait(15)
           return mylist;
        }
        catch (e) {
            myTools.pagConsole(`(ERROR) m0095 | integracao.produto.service_20008501
                                Metodo..: obterProdutosPendentes
                                Message.: \n ${e}
                                `)
            return mylist;
        }

    }


    async processamentoLocal(ProdutosAProcessar: modelintegracao_produto[], service : modelService_OLD): Promise<void> {
        try {


            service.serviceRegistroTotal = ProdutosAProcessar.length;
            service.serviceContadorNumeroMaxUpdate = 100;

            // Carga Banco de dados Postgre
            await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Inicializando... `)
            await this.processamentoCargaPostGre(ProdutosAProcessar, service);


    
            
        } catch (e) {
            myTools.PagErrorException("F0095/integracao.produto.service_2000851"
                                , "processamentoLocal"
                                , e
                                , false
                                , "Processamento dos Registros" )
        }
    }

    async Finalizar(): Promise<void> {
        try {

                myZanthuService.serviceLogTAG = "M0095_INT_PROD_20008501"
                await myTools.pagConsole(`Atualizando TAB VOUCHERS`)
                await myZanthuService.AtualizarVoucherPromocionais();
                
                await myTools.pagConsole(`zanthus.carga loja`)
                await myZanthuService.ZeusRetailCargaOxan();


                myTools.pagConsole(`Finalizando produtos pendentes`)
                await this.FinalizarTodosIntegracaoDeProdutoPendentes();


                    
        } catch(e) {
            await myTools.pagConsole(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus ${e}`)
        }
    }

    async Event(message : string) {
        this.emit('processamentoLocal', (message))
    }


    private async processamentoCargaPostGre(ProdutosAProcessar: modelintegracao_produto[], service : modelService_OLD) : Promise<void> {
        try {


            let ZANTHUS_TIPO_CARGA_LOG : boolean = false;
            if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                ZANTHUS_TIPO_CARGA_LOG = true;
                clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) | Tipo de Log de Carga Ativado: ${ZANTHUS_TIPO_CARGA_LOG} `)
            }

            //CARGA POSTGRE COMPLETA
            if (this.integracao_tipo.sis_batch_cd == 85001) {
                // CARGA COMPLETA BATCH 85001
                await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Completa] Excluindo Registros `)
                let scriptExclusaoDadosPOST = `
                       delete from tab_mercadoria; 
                       delete from tab_mercadoria_tipo_venda; 
                       delete from tab_mercadoria_tipo_venda_qtde; 
                       delete from tab_regras_icms;
                       `
               await myDATABASE.zanthusPostgre.Execute(scriptExclusaoDadosPOST);
               await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Completa] Processando`)

            } 



            //CARGA POSTGRE PENDENTE
            if (this.integracao_tipo.sis_batch_cd == 85002) {
                // CARGA COMPLETA BATCH 85001
                await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [PENDENTE] Excluindo Promocionais `)
                let scriptExclusaoDadosPOST = `
                       delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; 
                       delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; 
                       `
               await myDATABASE.zanthusPostgre.Execute(scriptExclusaoDadosPOST);
               await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando`)
            }             

            
            service.myDataBase_SERVER = "ZANTHUSPOSTGRE"
            service.serviceRegistroAtual = 0;
            service.serviceContadorNumeroLinhaAtual = 0;       


            let sqlScript : string = ``
            let numeroMaximo : number = 100
            let numeroCONTROLE_ITEM: number = 0;
            let numeroBloco: number = 1;
            let numeroTotalBloco: number = Math.ceil(ProdutosAProcessar.length / numeroMaximo);

            for await( let myitem  of ProdutosAProcessar) {
                if (this.integracao_tipo.sis_batch_cd == 85002) {
                   if(ZANTHUS_TIPO_CARGA_LOG) {
                       await clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.model_zanthus_produto.pr_cdproduto}`)
                   }
                }


                if (myitem.model_zanthus_produto.PostGreSqlScriptUpdate.trim() !== ``) {
                    sqlScript += myitem.model_zanthus_produto.PostGreSqlScriptUpdate;
                }
                else { 
                   await clsTools.pagConsole(`_ Carga ZANTHUS(POSTGRE) [Pendente] Processando _ Produto ${myitem.model_zanthus_produto.pr_cdproduto} NÃO POSSUI DADOS PARA ATUALIZAR`)
                }
                
                numeroCONTROLE_ITEM += 1;

                if (numeroCONTROLE_ITEM >= numeroMaximo) {
                    await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Proc Bloco ${numeroBloco}/${numeroTotalBloco} `, true)
                    if (sqlScript.trim() !== ``) {
                         await myDATABASE.zanthusPostgre.Execute(sqlScript);
                    }
                    sqlScript = ``;
                    numeroCONTROLE_ITEM = 0;
                    numeroBloco += 1;

                }

                await myTools._wait(1);

                
            }

            if (sqlScript.trim() !== ``) {

                await service._serviceLogRegister(`_ Carga ZANTHUS(POSTGRE) Proc Bloco (REST...) ${numeroBloco}/${numeroTotalBloco} `, true)
                await myDATABASE.zanthusPostgre.Execute(sqlScript);

                sqlScript = ``;
                numeroCONTROLE_ITEM = 0;
            }

            await service._processCheck(true);
        } 
        catch (e) {
                await clsTools.PagErrorException("F0095/integracao.produto.service_2000851"
                , "processamentoCargaPostGre"
                , e
                , false
                , "Processamento dos Registros" )
                throw new Error(`(ERROR) M0095 - Integracao | integracaoProdutoService_20008501_Zanthus 
                                    Método: processamentoCargaPostGre
                                    ${e}
                                  `)
        }
    }



}
