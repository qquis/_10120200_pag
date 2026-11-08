import { cp } from "fs";
import pagApi from "../api";
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"

const urlmodule = `/crm`;


type TpCrmSorteioTemporada = { 
    crm_so_temp_cd: number
    crm_so_temp_descricao: string
    crm_so_temp_valor_minimo: number
    crm_so_temp_data_ini: Date
    crm_so_temp_data_fim: Date
    crm_so_temp_status: number
}

type TpCrmSorteioCupom = {
    crm_so_temp_cd: number
    numero_cupom: number
    numero_pedido: number
    data_emissao: Date
    sat_ecf: number
    nf_numero: number
    nf_data_emissao: Date
    nf_chave: string
    valor: number
    cpf_cnpj: string
    crm_so_cpf: string
    cdparticipante: number
    crm_so_qtde_numero_sorteio: number
}


type TpCrmSorteioNumero = {
    crm_so_temp_cd: number
    crm_so_numero_seq: number	
    crm_so_numero_ordem: number
    crm_so_cupom_seq: number
    numero: number

    numero_cupom: number
    numero_pedido: number
    data_emissao: Date
    nf_data_emissao: Date
    nf_numero: number
    nf_chave: string
    valor: number
    cpf_cnpj: string
    crm_so_cpf: string
    
}


class moduleCRM {

    SorteioTemporada : TpCrmSorteioTemporada
    cpf_user : string 
    user: moduleUserConnect
    constructor(user: moduleUserConnect) { 
        
        this.user = user
        this.SorteioTemporada = { 
            crm_so_temp_cd: 0,
            crm_so_temp_descricao: '',
            crm_so_temp_valor_minimo: 0,
            crm_so_temp_data_ini: new Date('1900-01-01'),
            crm_so_temp_data_fim: new Date('1900-01-01'),
            crm_so_temp_status: 0
        }
        this.cpf_user = ''
        
    }




    async ConsultarTemporadaAtiva(parametro: any) : Promise<TpCrmSorteioTemporada> {
        try { 

            let temporada : TpCrmSorteioTemporada = await pagApi.pagApiget<TpCrmSorteioTemporada>(``, `${urlmodule}/report/sorteio/temporada`)
            this.SorteioTemporada = temporada

        } catch(e) {
            throw e
        } finally {
            return this.SorteioTemporada
        }
    }


    async ConsultarCupomDisponivel(parametro: any) : Promise<TpCrmSorteioCupom[]> {
        try {

            let url = `${urlmodule}/report/sorteio/cupom?consultaCupomDisponivel=1`
            if (this.cpf_user){ 
                url += `&cpf_cnpj=${this.cpf_user}`
            }
            if (parametro.nf_chave) {
                url += `&nf_chave=${parametro.nf_chave}`
            }
            if (parametro.crm_so_cpf) {
                url += `&crm_so_cpf=${parametro.crm_so_cpf}`
            }

            if (parametro.nf_numero) {
                url += `&nf_numero=${parametro.nf_numero}`
            }
            if (parametro.data_emissao) {
                url += `&data_emissao=${parametro.data_emissao}`
            }

            if (parametro.sat_ecf) {
                url += `&ecf_sat=${parametro.sat_ecf}`
            }

            let cupons : TpCrmSorteioCupom[] = await pagApi.pagApiget<TpCrmSorteioCupom[]>(this.user.usuario_login_uuid, url)
            
            return cupons
        } catch(e) {
            throw e
        }
    }



    async consultarCupom(parametro: any) : Promise<TpCrmSorteioCupom[]> {
        try {

            let url = `${urlmodule}/report/sorteio/cupom?validacpfcrm=1`
            if (this.cpf_user){ 
                url += `&cpf_cnpj=${this.cpf_user}`
            }
            if (parametro.nf_chave) {
                url += `&nf_chave=${parametro.nf_chave}`
            }
            if (parametro.crm_so_cpf) {
                url += `&crm_so_cpf=${parametro.crm_so_cpf}`
            }

            let cupons : TpCrmSorteioCupom[] = await pagApi.pagApiget<TpCrmSorteioCupom[]>(this.user.usuario_login_uuid, url)
            return cupons
        } catch(e) {
            throw e
        }
    }

    async RegistrarCupom(TpCrmSorteioCupom: TpCrmSorteioCupom) : Promise<object> {
        try {
            let url = `${urlmodule}/model/sorteio/registrarCupom?info=1`
            
            if(TpCrmSorteioCupom.nf_chave) { 
                url += `&nf_chave=${TpCrmSorteioCupom.nf_chave}`
            }

            console.log('CPF USER', this.cpf_user)
            if(TpCrmSorteioCupom.crm_so_cpf) { 
                url += `&crm_so_cpf=${TpCrmSorteioCupom.crm_so_cpf}`
            }

            console.log('URL', url)


            let result  = await pagApi.pagApiget<TpCrmSorteioCupom>(this.user.usuario_login_uuid, url)
            return result
        } catch(e) {
            throw e
        }
    }
    async consultarNumero(parametro: any) : Promise<TpCrmSorteioNumero[]> {
        try {

            let url = `${urlmodule}/report/sorteio/numero?info=1`
            if (parametro.nf_chave) {
                url += `&nf_chave=${parametro.nf_chave}`
            }
            if (parametro.crm_so_cpf) {
                url += `&crm_so_cpf=${parametro.crm_so_cpf}`
            }

            let numeros : TpCrmSorteioNumero[] = await pagApi.pagApiget<TpCrmSorteioNumero[]>(this.user.usuario_login_uuid,url)

            console.log(`NUMERO DE REGISTROS  ${numeros.length}`)
            return numeros
        } catch(e) {
            throw e
        }
    }

}

export { moduleCRM, type TpCrmSorteioTemporada, type TpCrmSorteioCupom, type TpCrmSorteioNumero }