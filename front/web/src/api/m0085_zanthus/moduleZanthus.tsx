import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'







class moduleZanthus extends moduleDefault { 


    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/zanthus', sis_ac_cd)


    }


    async postCarga(parametros: any) : Promise<any> {
            try {
 
                let result = await this._postAPI(`/service/carga-processar`,{}, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }


    async postAtualizacaoFiscal(parametros: any) : Promise<any> {
            try {
 
                let result = await this._postAPI(`/service/atualizacao-fiscal`,{}, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async postAtualizacaoCliente(parametros: any) : Promise<any> {
            try {
 
                let result = await this._postAPI(`/service/atualizacao-cliente`,{}, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
    async getReportCarga(parametros: any) : Promise<any> {
            try {
                
                let result = await this._getAPI(`/report/carga`, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
 
}




export { moduleZanthus }


