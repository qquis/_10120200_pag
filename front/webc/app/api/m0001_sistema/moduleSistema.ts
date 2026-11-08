import pagApi from '../api'
import moduleUserConnect from "./moduleUserConnect"

const MODULE_SISTEMA_URL = '/sistema'

type modelSistemaNucleo = { 
    sis_cd : number
    sis_descricao : string
    sis_nucleo_cd : string 
    sis_nucleo_descricao : string
    sis_nucleo_grupo_id : number
    sis_nucleo_grupo_descricao : string
}


type modelSistemNucleoProcedimento = { 

    sis_nucleo_cd : string
    sis_nucleo_descricao: string        
    sis_nucleo_prc_cd : number
    sis_nucleo_prc_descricao: string
    sis_nucleo_prc_descritivo: string
    sis_nucleo_prc_tipo: number
    data_default_ini: number
    data_default_fim: number
    dateadd_ini: number
    dateadd_fim: number
    data_reprocessamento_ini: Date
    data_reprocessamento_fim: Date
    permite_execucao_manual: number
    sis_batch_cd: number

}

class moduleSistemaNucleo { 
    listSistemaNucleo : modelSistemaNucleo[] = []
    user : moduleUserConnect = new moduleUserConnect()
    constructor(user: moduleUserConnect) {  
        user = user
        this.listSistemaNucleo = []
    }
    async SistemaNucleoListGet(parametros: any = {}) : Promise<modelSistemaNucleo[]> {
        let list : modelSistemaNucleo[] = []
        try {
            let url =  `${MODULE_SISTEMA_URL}/report/nucleo`
            
            
            list = (await pagApi.pagApiget<modelSistemaNucleo[]>(this.user.usuario_login_uuid, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    } 

    async SistemaNucleoListProcedimentoGet(parametros: any = {}) : Promise<modelSistemNucleoProcedimento[]> {
        let list : modelSistemNucleoProcedimento[] = []
        try {
            let url =  `${MODULE_SISTEMA_URL}/report/nucleoprocedimento?sis_nucleo_cd=${parametros.sis_nucleo_cd ?? ''}`
            
            
            list = (await pagApi.pagApiget<modelSistemNucleoProcedimento[]>(this.user.usuario_login_uuid, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    } 
}


class moduleSistema { 
    sistemaNucleo : moduleSistemaNucleo
    constructor(user: moduleUserConnect) { 
        this.sistemaNucleo = new moduleSistemaNucleo(user)

    }

}

export { moduleSistema, type modelSistemaNucleo, type modelSistemNucleoProcedimento }