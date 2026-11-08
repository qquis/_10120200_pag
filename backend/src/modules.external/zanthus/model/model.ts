

import { clsBase, clsTools } from "../../../model/modelbase";
import modelZanthusCliente from "./modelcliente";
import modelZanthusMercadoria from "./modelMercadoria";

export default class modelExternalZanthusBase {
    static async obterDadosDoCliente(parametro: any) { 
        let dadosDoCliente : any = null;
        try { 

            if (!parametro || !parametro.cod_cliente) {
                throw new Error("Parâmetro inválido: cod_cliente é obrigatório");
            }

            let cliente = new modelZanthusCliente(parseInt(`${parametro.cod_cliente}`));
            dadosDoCliente = await cliente.getData();
      
        } catch (e) {
            clsTools.PagErrorException(`modules.External | Zanthus`,"obterDadosDoCliente",e)
        }
        finally {
            return dadosDoCliente;
        }
    }
    static async obterDadosMercadoria(parametro: any) : Promise<any> {
        let dadosDaMercadoria : any = null;
        try { 

                let mercadoriaModal : modelZanthusMercadoria = new modelZanthusMercadoria();

                dadosDaMercadoria = await mercadoriaModal.getinfoAllMercadoria(parametro.cod_mercadoria as string);
                

            } catch (e) {
                await clsTools.PagErrorException(`modules.External | Zanthus`,"obterDadosMercadoria",e)
            }
        finally {
            return dadosDaMercadoria;
        }
    }
}