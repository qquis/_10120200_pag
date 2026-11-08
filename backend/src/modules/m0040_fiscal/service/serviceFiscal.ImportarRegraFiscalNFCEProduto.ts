
import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_regrafiscalNfceProduto from "../model/modelfc_regrafiscalNfceProduto";



import serviceFiscalShare from "./_serviceFiscalShare";
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050011
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0040-Fiscal | ServiceFiscalImportarRegraNfceProduto"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    

const myBase = new clsBase();

export default class serviceFiscalImportarRegraNfceProduto { 
    static async start(parametro: any) : Promise<void> { 

        const ServiceShare = new serviceFiscalShare();
        try  { 
            let isql : string = ``
            
            let ipagCount : number = 1000;
            if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') { 
                ipagCount = 1;
            }

            for (let ipag : number = 1; ipag <= ipagCount; ipag++) {
                await clsTools.pagConsole(`${FLG_MODULO} | Processando Bloco ${ipag}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);

                let url = `/modulos/fiscal/regra-fiscal/pdv/sat-nfces?lojaKey=1&page=${ipag}`;
                if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft != '') { 
                    url += `&produtoKey=${parametro.prb_cdprodutobluesoft}`;
                }


                const report = await myBase.blueSoftApi.api_get(url)
                
                
                if (report.data.length == 0) { 
                    await clsTools.pagConsole(`${FLG_MODULO} | Import DADOS NFCE SEM REGISTRO ${ipag}`, FLG_DEBUG_CONSOLE_LOG, true, FLG_DEBUG_FILE_CONSOLE_LOG);
                    break;
                }
                else { 
                    await clsTools.pagConsole(`${FLG_MODULO} | Import DADOS NFCE Bloco ${ipag} Possui informacoes e sera processado`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    let i : number = 0;
                    let iCount: number = 50

                    for await (const item of report.data) { 

                        
                        const modelItem = new modelfc_regrafiscalNfceProduto();
                        
                        modelItem.LerDadosDaAPI(item);
                        modelItem.LOCAL_STATUS_API = 1;
                        isql += modelItem.sql_CRUD();
                        ServiceShare.Complemento.ProcessarReformaDadosComplementares(item);
                        
                        
                        i++;
                        if (i >= iCount) {
                            await this.dadaBaseProcessar(isql);
                            i = 0;
                            isql = ``;

                        }
                    }
                    await this.dadaBaseProcessar(isql);
                }
            
            }
            await ServiceShare.Complemento.SalvarDadosDosLists();


        } catch (e) { 
            await clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e,false,"",FLG_DEBUG_FILE_CONSOLE_LOG);
        }

        finally {
           await clsTools.pagConsole(`${FLG_MODULO} - Importação NFCE FINALIZADA`,FLG_DEBUG_CONSOLE_LOG,false, FLG_DEBUG_FILE_CONSOLE_LOG);
        }

    }

    static async dadaBaseProcessar(scriptSQL : string) : Promise<void> { 
        try  { 
                if (scriptSQL.length > 0) {
                    await myBase.myDataBase.pag.Execute(scriptSQL);
                }
            
        } catch (e) { 
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalImportarRegraNfceProduto.dadaBaseProcessar', e);
        }       
    }

}