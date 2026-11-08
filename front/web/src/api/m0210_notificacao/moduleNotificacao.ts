import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'





class moduleNotificacao extends moduleDefault { 


    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/notificacao', sis_ac_cd)   

   
    }
    async postTeste(parametros: any = {}) : Promise<any[]> {
       
            try {
        
                let urlConsulta = `/service/teste?notificacao_send_tipo_cd=${parametros.notificacao_send_tipo_cd}`
                urlConsulta += `&notificacao_celular_dd_numero=${parametros.notificacao_celular_dd_numero}`
                urlConsulta += `&notificacao_send_message=${parametros.notificacao_send_message}`

                let result = await this._postAPI(urlConsulta, parametros)
                return result
                
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }


}




export { moduleNotificacao }


