import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'





class moduleforcavendameta extends moduleDefault { 
   

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/forca-venda-meta', sis_ac_cd)

   

        
    }



    async postProcessarMeta(parametro: any) : Promise<any> {
            try {
                let url =  `/service/forca-venda-meta-processar?filtrox=1`
                let result = await this._postAPI(url, parametro)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }


}




export { moduleforcavendameta }


