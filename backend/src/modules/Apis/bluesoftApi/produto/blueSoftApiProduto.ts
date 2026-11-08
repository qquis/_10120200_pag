
import { clsBase, clsTools } from '../../../../model/modelbase';

import bluesoftApi from "../url/bluesoftApiUrl"


const moduleLog = 'blueApi';


export default class blueSoftApiProduto {
    dataUltimaAlteracao : Date
    constructor() {
        this.dataUltimaAlteracao = clsTools._datemomentDatStrToDate("01/01/1900", "DD/MM/YYYY")
    }

    async listall() : Promise<any> {
        return await this.list();
    } 

    async listUltAlteracaoD1() : Promise<any> {

        try { 

            return await this.listalteracaoDX(1)
        } catch (e) {

            await clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listUltAlteracaoD1`, e, false, ``, moduleLog)
        }

    }

    async listUltAlteracao15() : Promise<any> {
        try { 
            return await this.listalteracaoDX(15)
        } catch (e) {
            clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listUltAlteracao15`, e, false, ``, moduleLog)

            
        }
    }

    async listalteracaoDX(NumDia: number) : Promise<any> {
        try { 
            const dataOntem = new Date(); 
            if (NumDia -1 > 0) { 
                NumDia = NumDia - 1;
                dataOntem.setDate(((new Date()).getDate() - NumDia))
            }


            return await this.list(true, clsTools._datemomentDateToStr(dataOntem, "DD/MM/YYYY"))

        } catch (e) {
            await clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listalteracaoDX`, e, false, ``, moduleLog)
        }
    }

    async listPendenteHoje() : Promise<any> {
        try { 
            const dataHoje = new Date();
            return await this.list(true, clsTools._datemomentDateToStr(dataHoje, "DD/MM/YYYY"))
        } catch (e) {
            await clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - listPendenteHoje`, e, false, ``, moduleLog)
        }
    }


    private async list(UltimaAlteracao : boolean = false, data_alteracao : string = "") : Promise<any> {
        try {

            


            let resultobject : any[] = []

            let result : any 

            let numPag = 0; 
            let numPagMax = 10000; 

            const pagSize : number = 200

            /*
            if (UltimaAlteracao) 
                numPagMax = 5;
            */  

            for (numPag = 0; numPag <= numPagMax; numPag++) {
                
                //console.log(`processando a pagina ${numPag}`)
                await clsTools.pagConsole(`ser.Prd.blue.imp _ list | Processando a página ${numPag}`,false, false, moduleLog)
                
                result = {}
                let url = `` 

                if (UltimaAlteracao){
                    url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}&ultimaAlteracao=${data_alteracao}`
                } else {
                    url = `/comercial/produtos?pageSize=${pagSize}&currentPage=${numPag}`
                }
                
                await clsTools.pagConsole(`ser.Prd.blue.imp _ list | Buscando produtos ${UltimaAlteracao ? `a partir de ${data_alteracao}` : '(sem filtro de última alteracao) url ' + url} `,false, false, moduleLog)       

                result = await bluesoftApi.api_get(url)

                if (result.data && result.data.data.length > 0) {
                   for await (const[key, value] of Object.entries(result.data.data)) 
                            {
                                resultobject.push(value)
                            } 
                }
                else { 
                    break;
                }

                
            }

            await clsTools.pagConsole(`ser.Prd.blue.imp _ list | Finalizando listagem de produtos`,false, false, moduleLog)
            return resultobject
            
    }
    catch (e) {
            await clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - list`, e, false, ``, moduleLog)

        }
    }

    async getProduto(produtoKey : number) : Promise<any> {
        try {
            let url = `/comercial/produtos?produtoKey=${produtoKey}`
            const result =  await bluesoftApi.api_get(url)
            

            return result; 
        }
        catch (e) {
            await clsTools.PagErrorException(`Modules APIS _ BluesoftAPI`, ` bluesoftApiProduto - getProduto`, e, false, ``, moduleLog)
        }
    }
}