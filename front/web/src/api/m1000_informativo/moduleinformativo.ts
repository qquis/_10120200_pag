import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from "../module.default"


class moduleInformativo extends moduleDefault { 
    

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/informativo', sis_ac_cd)   

  
    }

     async email(parametros: any) : Promise<any> {
        try {

            let url = ``

                    url = `/service/${parametros.tipo}?filtro=1`

                if (parametros.email_conferencia && parametros.email_conferencia.trim() !== "") {
                    url += `&email_conferencia=${parametros.email_conferencia}`
                }
                if (parametros.email_forca_envio_email_controlado) {
                    url += `&email_forca_envio_email_controlado=${parametros.email_forca_envio_email_controlado}`
                }

                if (parametros.competencia_cd ) {
                    url += `&competencia_cd=${parametros.competencia_cd}`
                }
                if (parametros.data_processamento_ini) { 
                    url += `&data_processamento_ini=${parametros.data_processamento_ini}`
                }
                if (parametros.data_processamento_fim) { 
                    url += `&data_processamento_fim=${parametros.data_processamento_fim}`
                }

                

            const result = await this._postAPI(url, parametros)
            return result
        } catch (e) {
             console.log(`moduleInformativo.postImportList Error ${e}`)
             throw new Error(`moduleInformativo.postImportList Error ${e}`)
        }
    }
}

export {moduleInformativo}

