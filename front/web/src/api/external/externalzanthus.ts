import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'

let url_base = `external/zanthus/`




class moduleExternalZanthus extends moduleDefault {

    user: moduleUserConnect
    constructor(user: moduleUserConnect, sis_ac_cd: number) {
        super(user, 'external/zanthus/', sis_ac_cd)
        this.user = user
    }


    async getlistTabMercadoria (parametros: any) : Promise<any> { 
        try { 

            let urlConsulta = `report/tab_mercadoria?filtros=1`
            if (parametros.cod_mercadoria) urlConsulta += `&cod_mercadoria=${parametros.cod_mercadoria}`
            if (parametros.descricao && parametros.descricao !== '') urlConsulta += `&descricao=${parametros.descricao}`

            if (parametros.filtrar_data_venda) {
                urlConsulta += `&filtrar_data_venda=1`
                if (parametros.data_venda_ini) urlConsulta += `&data_venda_ini=${parametros.data_venda_ini}`
                if (parametros.data_venda_fim) urlConsulta += `&data_venda_fim=${parametros.data_venda_fim}`
                if (parametros.ecf ) urlConsulta += `&ecf=${parametros.ecf}`
                if (parametros.numero_cupom) urlConsulta += `&numero_cupom=${parametros.numero_cupom}`
                if (parametros.numero_nf) urlConsulta += `&numero_nf=${parametros.numero_nf}`
            }

            if (parametros.regra_count) urlConsulta += `&regra_count=${parametros.regra_count}`

            let result = await pagApi.pagApiget(this.user.usuario_login_uuid, url_base + urlConsulta)
            return result


        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }

    }

    async getlistTabVoucher (parametros: any) : Promise<any> {
        let result : any = {}
        try {
            let url =  `/report/listvoucher?filter=1`
            result = await this._getAPI<any>(url, parametros)
            return result
        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }

    }


    async getlistTabRegraIcms (parametros: any) : Promise<any> { 
        try { 

            let urlConsulta = `report/tab_regra_icms?filtros=1`
            if (parametros.cod_mercadoria) urlConsulta += `&cod_mercadoria=${parametros.cod_mercadoria}`
            if (parametros.descricao && parametros.descricao !== '') urlConsulta += `&descricao=${parametros.descricao}`

            if (parametros.filtrar_data_venda) {
                urlConsulta += `&filtrar_data_venda=1`
                if (parametros.data_venda_ini) urlConsulta += `&data_venda_ini=${parametros.data_venda_ini}`
                if (parametros.data_venda_fim) urlConsulta += `&data_venda_fim=${parametros.data_venda_fim}`
                if (parametros.ecf ) urlConsulta += `&ecf=${parametros.ecf}`
                if (parametros.numero_cupom) urlConsulta += `&numero_cupom=${parametros.numero_cupom}`
                if (parametros.numero_nf) urlConsulta += `&numero_nf=${parametros.numero_nf}`
            }

            let result = await pagApi.pagApiget(this.user.usuario_login_uuid, url_base + urlConsulta)
            return result


        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }

    }

    async getInfoAllMercadoria(cod_mercadoria: string) : Promise<any> {
        let mercadoria: any
        
        

        let urlConsulta = `model/mercadoria?cod_mercadoria=${cod_mercadoria}`
        try {
            mercadoria  = await pagApi.pagApiget(this.user.usuario_login_uuid, url_base + urlConsulta)

        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }
        finally { 
            return mercadoria
        }
    }

    async getlistTabFinalizadora (parametros: any) : Promise<any> {
        try {

            let urlConsulta = `report/tab_finalizadora?filtros=1`
            let result = await pagApi.pagApiget(this.user.usuario_login_uuid, url_base + urlConsulta)
            return result

        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }

    }

    async getlistTabCliente (parametros: any) : Promise<any> {
        try {

            let urlConsulta = `report/tab_cliente?filtros=1`
            if (parametros.cod_cliente) urlConsulta += `&cod_cliente=${parametros.cod_cliente}`
            
            if (parametros.filtrar_data_alteracao && parametros.filtrar_data_alteracao == "1") 
            {
                urlConsulta += `&filtrar_data_alteracao=1`
                if (parametros.data_alteracao_ini) urlConsulta += `&data_alteracao_ini=${parametros.data_alteracao_ini}`
                if (parametros.data_alteracao_fim) urlConsulta += `&data_alteracao_fim=${parametros.data_alteracao_fim}`
            }

            if (parametros.filtrar_data_cadastro && parametros.filtrar_data_cadastro == "1") {
                urlConsulta += `&filtrar_data_cadastro=1`
                if (parametros.data_cadastro_ini) urlConsulta += `&data_cadastro_ini=${parametros.data_cadastro_ini}`
                if (parametros.data_cadastro_fim) urlConsulta += `&data_cadastro_fim=${parametros.data_cadastro_fim}`
            }

            if (parametros.des_cliente) urlConsulta += `&des_cliente=${parametros.des_cliente}`

            let result = await pagApi.pagApiget(this.user.usuario_login_uuid, url_base + urlConsulta)
            return result

        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }

    }
  


}

export {  moduleExternalZanthus   }
