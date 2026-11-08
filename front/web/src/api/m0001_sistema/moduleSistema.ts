import pagApi from '@/api/api'
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
            
            
            list = (await pagApi.pagApiget<modelSistemaNucleo[]>(this.user.user_credential, url))
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
            
            
            list = (await pagApi.pagApiget<modelSistemNucleoProcedimento[]>(this.user.user_credential, url))
        } catch(e) {
            throw new Error(`API ERROR: ${e}`);
        } finally {
            return list
        }
    } 
}


class moduleSistema { 
    user : moduleUserConnect
    sistemaNucleo : moduleSistemaNucleo
    constructor(user: moduleUserConnect) { 
        this.user = user
        this.sistemaNucleo = new moduleSistemaNucleo(user)

    }


    async getSistemaList(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `${MODULE_SISTEMA_URL}/report/list?user_name=${this.user.user_name}`
                let result = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getSistemaFuncaoList(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `${MODULE_SISTEMA_URL}/report/funcao?user_name=${this.user.user_name}`
                let result = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getSistemaAcessoList(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `${MODULE_SISTEMA_URL}/report/acesso?user_name=${this.user.user_name}`
                let result = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }    

    async getSistemaTarafaListGet(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `${MODULE_SISTEMA_URL}/report/tarefa?user_name=${this.user.user_name}`
                if (parametros.sis_ta_cd) {
                    url += `&sis_ta_cd=${parametros.sis_ta_cd}`
                }
                if (parametros.sis_ta_descricao) {
                    url += `&sis_ta_descricao=${parametros.sis_ta_descricao}`
                }
                if (parametros.sis_ta_tipo_descricao) {
                    url += `&sis_ta_tipo_descricao=${parametros.sis_ta_tipo_descricao}`
                }
                
                let result = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getSistemaPermissaoListGet(parametros: any = {}) : Promise<any[]> {
        
            try {
                let url =  `${MODULE_SISTEMA_URL}/report/permissao?user_name=${this.user.user_name}&relatorio=1`
                if (parametros.sis_cd) {
                    url += `&sis_cd=${parametros.sis_cd}`
                }
                if (parametros.sis_fc_cd) {
                    url += `&sis_fc_cd=${parametros.sis_fc_cd}`
                }
                if (parametros.sis_ac_cd) {
                    url += `&sis_ac_cd=${parametros.sis_ac_cd}`
                }                                
                if (parametros.sis_ta_cd) {
                    url += `&sis_ta_cd=${parametros.sis_ta_cd}`
                }
                

                //let result = await pagApi.pagApiget<any[]>(this.user.user_credential, url)
                let result = await pagApi.pApiget<any[]>(this.user, url, 0)
                
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async postSistemaInicializacaoDiaria(parametros: any = {}) : Promise<any> {
        try {
            let url =  `/sistema_batch/service/inicializacao-diaria?user_name=${this.user.user_name}`
            let result = await pagApi.post(url, {})
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

}




export { moduleSistema, type modelSistemaNucleo, type modelSistemNucleoProcedimento }