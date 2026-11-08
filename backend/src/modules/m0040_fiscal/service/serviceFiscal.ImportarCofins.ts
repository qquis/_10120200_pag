import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_cofins from "../model/modelfc_cofins";

export default class serviceFiscalImportarCofins { 
    static async start() { 
        try  { 

            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins.start - Iniciando...',false, false);

            let myBase = new clsBase();


            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Processando COFINS DE SAIDA',false, false);
            let resultCofinsTipoSaida = await myBase.blueSoftApi.api_get('/fiscal/cofins?tipo=SAIDA')
            await this.ProcessarDadosDaApi(resultCofinsTipoSaida.data, 'SAIDA')

            
            await clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Processando COFINS DE ENTRADA',false, false);
            let resultCofinsTipoEntrada = await myBase.blueSoftApi.api_get('/fiscal/cofins?tipo=ENTRADA')
            await this.ProcessarDadosDaApi(resultCofinsTipoEntrada.data, 'ENTRADA')
            

            

            

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarCofins', e);
        }

        finally {
            clsTools.pagConsole('Modulo M0040 - Fiscal | ServiceFiscal.serviceFiscalImportarCofins - Finalizado',false, false);
        }

    }

    static async ProcessarDadosDaApi(DadosApi: any, tipo: string) {
        try {

            let myBase = new clsBase();


            let i: number = 0;
            let iMaxExecute: number = 50;
            let sql = ``

            for await (const item of DadosApi) {
                let itemCofins : modelfc_cofins = new modelfc_cofins();
                itemCofins.bindingApiBluesoft_urlFiscalCofins(item);

                itemCofins.tipo_entrada = 0;
                if (tipo == 'ENTRADA') {
                    itemCofins.tipo_entrada = 1
                } 
                
                sql += itemCofins.script_insert();
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
            clsTools.PagErrorException('M0040_FISCAL', 'Service serviceFiscalImportarCofins.ProcessarDadosDaApi', e);
        }
    }

}