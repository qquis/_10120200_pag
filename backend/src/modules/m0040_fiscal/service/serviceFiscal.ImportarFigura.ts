import sql from "msnodesqlv8";
import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_figurafiscal from "../model/modelfc_figurafiscal";
import modelfc_regrafiscal from "../model/modelfc_regrafiscal";
import { Console } from "console";

const myBase = new clsBase();

export default class serviceFiguraFiscalRegraFiscal { 
    static async start() : Promise<void> { 
        try  { 

            clsTools.pagConsole('Modulo M0040 - Fiscal | serviceFiguraFiscalRegraFiscal.start - Iniciando...',false, false);

            let result = await myBase.blueSoftApi.api_get('/fiscal/figurafiscal')


            let iControl = 0 
            let iControlMax = 50;
            let sqlinsert = '';

            //console.log(result.data)

            
            if (result && result.data) {
                for (let itemData of result.data) { 
                    let item = new modelfc_figurafiscal();
                    item.bindingApiBluesoft(itemData);


                    /* Atualiza o cadastro das regras fiscais*/
                    await this.atualizarRegras(item.fc_figurafiscal_cd);
                    
                    
                    sqlinsert = item.script_insert();
                    if (iControl < iControlMax) {
                        await myBase.myDataBase.pag.Execute(sqlinsert);
                        sqlinsert = ''; 
                        iControl = 0
                    }


                    iControl++;
                }
                if (sqlinsert != '') { 
                    await myBase.myDataBase.pag.Execute(sqlinsert);
                }
            }
            

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_Figura', e);
        }

        finally {
            clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.ImportarFigura.atualizarBasePag - Finalizado',false, false);
        }

    }


    static async atualizarRegras(codigoFiguraFISac : number) : Promise<void> {

        try { 

            let result = await myBase.blueSoftApi.api_get(`fiscal/regrafiscal/completa?codigoFiguraFiscal=${codigoFiguraFISac}`)            



            let sqlinsert = '';

            if (result && result.data.data) {
                let lista: any[] = result.data.data;
                for (let itemData of lista) {


                    let item = new modelfc_regrafiscal();
                    await item.bindingApiBluesoft(itemData);

                    sqlinsert += item.scriptSqlRegraFiscal();   
                    sqlinsert += item.ItemIcms.script_insert();
                    
                }
            }

            if (sqlinsert != '') { 
                //console.log(sqlinsert);
                await myBase.myDataBase.pag.Execute(sqlinsert);
            } else { 
                clsTools.pagConsole(`Nenhuma regra fiscal encontrada para a figura fiscal: ${codigoFiguraFISac}`, false, false);
            }
        } catch (e) { 

            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscal_ImportarFigura.atualizarRegras', e);
        }



    }
}