import { Console } from "console";
import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_pis from "../model/modelfc_pis";

const LOG_FILE_NAME = 'M0041';


export default class serviceFiscalImportarPis { 
    static async start() { 
        try  { 

            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarPis.start - Iniciando...',false, false, LOG_FILE_NAME);

            let myBase = new clsBase();
            
            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarPis - Processando PIS DE SAIDA',false, false, LOG_FILE_NAME);
            let resultPisTipoSaida = await myBase.blueSoftApi.api_get('/fiscal/pis?tipo=SAIDA')
            await this.ProcessarDadosDaApi(resultPisTipoSaida.data, 'SAIDA')


            
            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarPis - Processando PIS DE ENTRADA',false, false, LOG_FILE_NAME);
            let resultPisTipoEntrada = await myBase.blueSoftApi.api_get('/fiscal/pis?tipo=ENTRADA')
            await this.ProcessarDadosDaApi(resultPisTipoEntrada.data, 'ENTRADA')
            

            

            

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarPis', e);
        }

        finally {
            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarPis - Finalizado',false, false);
        }

    }

    static async ProcessarDadosDaApi(DadosApi: any, tipo: string) {
        try {

            let myBase = new clsBase();


            let i: number = 0;
            let iMaxExecute: number = 50;
            let sql = ``

            for await (const item of DadosApi) {
                let itemPis : modelfc_pis = new modelfc_pis();
                itemPis.bindingApiBluesoft_urlFiscalPis(item);

                itemPis.tipo_entrada = 0;
                if (tipo == 'ENTRADA') {
                    itemPis.tipo_entrada = 1
                } 

                sql += itemPis.script_insert();
                i++;
                if (i >= iMaxExecute) {
                    await myBase.myDataBase.pag.Execute(sql);
                    sql = ``;
                    i = 0;
                }
                
            }

            if (sql.trim() != '') {
                await myBase.myDataBase.pag.Execute(sql);
            }

            
            
        } catch(e) {
            clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarPis.ProcessarDadosDaApi', e);
        }
    }

}