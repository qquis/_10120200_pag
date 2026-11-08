import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'


class moduleParticipante extends moduleDefault { 
    
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/participante', sis_ac_cd)    

    }

    async postOperacaoVipImmport(parametros: any = {}) : Promise<void> {
        
            try {
                let url =  `/service/vipimport?filter=1`
                await this._postAPI(url, parametros)
                
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async postOperacaoBluesoftApiImport(parametros: any = {}) : Promise<void> {
        try {
            let url =  `/service/apibluesoftimport?filter=1`

            await this._postAPI(url,{}, parametros)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async postOperacaoGrupoEconomicoImport(parametros: any = {}) : Promise<void> {
        try {
            let url =  `/service/grupoeconomicoimport?filter=1`

            await this._postAPI(url,{}, parametros)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }



    async postOperacaoBluesoftRedshiftImport(parametros: any = {}) : Promise<void> {
        try {
            let url =  `/service/redshiftbluesoftimport?filter=1`
            await this._postAPI(url,{}, parametros)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async postOperacaoBluesoftApiAtualizarStatusCredito(parametros: any = {}) : Promise<void> {
        try {
            let url =  `/service/apibluesoftatualizarstatuscredito?filter=1`
            await this._postAPI(url,{}, parametros)
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async getParticipanteList(parametros: any = {}) : Promise<any[]> {
        
            try {



                let url =  `/report/list?filter=1`
                if(parametros.nome_razao) {
                    url += `&nome_razao=${encodeURIComponent(parametros.nome_razao)}`
                }
                if(parametros.participante_tipo_cd) {
                    url += `&participante_tipo_cd=${encodeURIComponent(parametros.participante_tipo_cd)}`
                }
                if(parametros.bluesoftcliente_creditostatus_cd) {
                    url += `&bluesoftcliente_creditostatus_cd=${encodeURIComponent(parametros.bluesoftcliente_creditostatus_cd)}`
                }

                let result = await this._getAPI<any[]>(url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getParticipanteGrupoEconomicoList(parametros: any = {}) : Promise<any[]> {
        
            try {


                console.log(parametros)
                let url =  `/report/list-participante-grupo-economico?filter=1`
                if(parametros.nome_razao) {
                    url += `&nome_razao=${encodeURIComponent(parametros.nome_razao)}`
                }
                if(parametros.participante_tipo_cd) {
                    url += `&participante_tipo_cd=${encodeURIComponent(parametros.participante_tipo_cd)}`
                }
                if (parametros.bluesoftcliente_creditostatus_cd) {
                    url += `&bluesoftcliente_creditostatus_cd=${parametros.bluesoftcliente_creditostatus_cd}`
                }
                if (parametros.cdparticipante_vendedor) {
                    url += `&cdparticipante_vendedor=${encodeURIComponent(parametros.cdparticipante_vendedor)}`
                }

                if (parametros.forma_pgto_cd_grupo_economico_padrao && parametros.forma_pgto_cd_grupo_economico_padrao !== 0) {
                    url += `&forma_pgto_cd_grupo_economico_padrao=${encodeURIComponent(parametros.forma_pgto_cd_grupo_economico_padrao)}`
                }

                let result = await this._getAPI<any[]>(url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getPagFabricanteList(parametros: any = {}) : Promise<any[]> {
        
            try {



                let url =  `/report/list-pagfabricante?filter=1`
                if(parametros.nome_razao) {
                    url += `&nome_razao=${encodeURIComponent(parametros.nome_razao)}`
                }

                let result = await this._getAPI<any[]>(url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
    async getPagVendedorList(parametros: any = {}) : Promise<any[]> {
        
            try {



                let url =  `/report/list-pagvendedor?filter=1`
                if(parametros.nome_razao) {
                    url += `&nome_razao=${encodeURIComponent(parametros.nome_razao)}`
                }
                if(parametros.participante_tipo_cd) {
                    url += `&participante_tipo_cd=${encodeURIComponent(parametros.participante_tipo_cd)}`
                }

                let result = await this._getAPI<any[]>(url)
                return result
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getParticipanteTipoList() : Promise<any[]> {
        
        try {
            let result = await this._getAPI<any[]>(`/report/tipolist?fiter=1`)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }       
    }

    async getParticipante(parametros: any = {}) : Promise<any> { 
        try {


            let result = await this._getAPI<any[]>(`/model/consultar?cdparticipante=${parametros.cdparticipante}`)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }       

    }
}




export { moduleParticipante }

