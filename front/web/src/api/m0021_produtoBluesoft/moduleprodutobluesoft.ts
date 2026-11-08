import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from "../module.default"


type moduleProdutoBluesoftParametro = {
    numeroDiasUltimaAlteracao?: number,
    AtualizaLog: number
    produtoKey: string
    NaoProcessarBasePag?: number
}

type tpProdutoBluesoftEmbalagemPadrao = { 
    prb_embalagemfiltro: string
    prb_embalagemfiltro_descricao: string
}


class moduleProdutoBluesoft extends moduleDefault { 
    listEmbalagemPadrao : tpProdutoBluesoftEmbalagemPadrao[] = []
    

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/produtobluesoft', sis_ac_cd)   
        this.listEmbalagemPadrao.push({ prb_embalagemfiltro: '', prb_embalagemfiltro_descricao: 'Todos' })
        this.listEmbalagemPadrao.push({ prb_embalagemfiltro: 'UN', prb_embalagemfiltro_descricao: 'UN' })
        this.listEmbalagemPadrao.push({ prb_embalagemfiltro: 'KG', prb_embalagemfiltro_descricao: 'KG' })
        this.listEmbalagemPadrao.push({ prb_embalagemfiltro: 'XX', prb_embalagemfiltro_descricao: 'Outros' })

  
    }

     async postImportList(parametros: any) : Promise<any> {
        try {
            const result = await this._postAPI(`/service/importarprodutolist`, parametros)
            return result
        } catch (e) {
             console.log(`moduleProdutoBluesoft.importarList Error ${e}`)
             throw new Error(`moduleProdutoBluesoft.importarList Error ${e}`)
        }
    }

    async postIntegrarBluePag(parametros: any) : Promise<any> {
        try {
            const result = await this._postAPI(`/service/processar-integracao-bluepag`, parametros)
            return result
        } catch (e) {
             console.log(`moduleProdutoBluesoft.postIntegrarBluePag Error ${e}`)
             throw new Error(`moduleProdutoBluesoft.postIntegrarBluePag Error ${e}`)
        }
    }

    async getList(parametros: any) : Promise<any> {
        try {
            const query = new URLSearchParams()
            query.set("filter", "1")

            Object.entries(parametros || {}).forEach(([chave, valor]) => {
                if (valor !== undefined && valor !== null && String(valor).trim() !== "") {
                    query.append(chave, String(valor))
                }
            })

            let url = `/report/list?${query.toString()}`


            const result : any = await this._getAPI(url)
            return Array.isArray(result) ? result : result?.data

        } catch (e) {
            console.log(`moduleProdutoBluesoft.getList Error ${e}`)
            throw new Error(`moduleProdutoBluesoft.getList Error ${e}`)
        }
    }
    

}

export 
{  
    moduleProdutoBluesoft,
    type moduleProdutoBluesoftParametro
        
}


