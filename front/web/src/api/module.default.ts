
import moduleUserConnect from "../api/m0001_sistema/moduleUserConnect"
import pagApi from "./api"

export default class moduleDefault {
    
    user : moduleUserConnect
    SIS_AC_CD: number
    MODULE_URL_BASE : string
    constructor(user: moduleUserConnect, module_url_base: string, sis_ac_cd: number) {
        this.user = user
        this.MODULE_URL_BASE = module_url_base
        this.SIS_AC_CD = sis_ac_cd;
    }

    async _getAPI<T>(url: string, parametros: any = {}) : Promise<T> {
        try {

            let url_parametro = ``
            if (parametros && Object.keys(parametros).length > 0) {
                url_parametro = await this._QueryParametros(url,parametros)
            }
            else { 
                url_parametro = url
            }

            let result = await pagApi.pApiget<T>(this.user, this.MODULE_URL_BASE + url_parametro, this.SIS_AC_CD)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async _postAPI(url: string, object: object = {}, parametros: any = {}) : Promise<any> {
        
        try {
            let url_parametro = ``
            if (parametros && Object.keys(parametros).length > 0) {
                url_parametro = await this._QueryParametros(url,parametros)
            }
            else { 
                url_parametro = url
            }

            let result = await pagApi.pApipost(this.user, this.MODULE_URL_BASE + url_parametro, object, this.SIS_AC_CD)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }       
    }

    async _QueryParametros(url: string,parametros: any) : Promise<string> {
        const query = new URLSearchParams()
        query.set("filter", "1")

        Object.entries(parametros || {}).forEach(([chave, valor]) => {
            if (valor !== undefined && valor !== null && String(valor).trim() !== "") {
                query.append(chave, String(valor))
            }
        })

        let url_parametro = `${url}?${query.toString()}` 
        return url_parametro
    }


    

}