import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'




class moduleforcaVendaMetaFabricante extends moduleDefault {
    constructor(user: moduleUserConnect, sis_ac_cd: number) {
        super(user, '/forca-venda-meta', sis_ac_cd)
    }

    getListMetaFabricante(parametro: any) : Promise<any> {
        
        try { 
            return this._getAPI('/report/meta-fabricante', parametro) }
        catch(e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }

    getListMetaFabricanteResultadoVendedor(parametro: any) : Promise<any> {
        try {
            return this._getAPI('/report/meta-fabricante-resultado-vendedor', parametro)
        }
        catch(e) {
            throw new Error(`API ERROR: ${e}`);
        }
    }

}



class moduleforcavendameta extends moduleDefault { 
    fabricante: moduleforcaVendaMetaFabricante

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/forca-venda-meta', sis_ac_cd)

        this.fabricante = new moduleforcaVendaMetaFabricante(user, sis_ac_cd)

        
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


