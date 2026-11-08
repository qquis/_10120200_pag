
import api from '../../api/api';
const url = '/crm'
import moduleUserConnect from "../m0001_sistema/moduleUserConnect"




type tpTemporada = { 
        crm_so_temp_cd: number
        crm_so_temp_descricao: string
        crm_so_temp_valor_minimo: number
        crm_so_temp_data_ini: Date
        crm_so_temp_data_fim: Date
        crm_so_temp_status: number
}

type tpsorteio_numero_cupom = { 
    crm_so_temp_cd: number
    crm_so_numero_seq: number
    crm_so_numero_ordem: number
    numero: number
    crm_so_cupom_seq: number
    numero_cupom: number
    numero_pedido: number
    data_emissao: Date
    sat_ecf: string
    nf_numero: string
    nf_data_emissao: Date
    nf_chave: string
    valor: number
    cpf_cnpj: string
    cdparticipante: string
    crm_so_cpf: string
    crm_so_qtde_numero_sorteio: number
    crm_so_externo_enviado: number
    crm_so_externo_enviado_data: Date
}

type tpParticipante_Crm = {

        crm_seq : number
        crm_status_cd : number 
        crm_email: string 
        crm_dt_cadastro: Date
        cpf: string 
        nome: string 
        sobre_nome: string 
        data_nascimento: Date
        pf_sexo : string
}

type tpSorteio = { 
        crm_numero_oficial: number
        crm_so_cd: number
        crm_so_data_fim: Date
        crm_so_data_ini: Date
        crm_so_data_sorteio: Date
        crm_so_descricao: string
        crm_so_seq: number
        crm_so_temp_cd: number
        crm_so_temp_descricao: string
        crm_so_tipo_cd: number
        dtlog_insert: Date
        dtlog_update: Date
}


class modulecrmSorteio { 
        user: moduleUserConnect

    constructor(user: moduleUserConnect) {
        this.user = user
    }
    async getTemporada(parametros: any) : Promise<tpTemporada[]> {
        try {
            
            const response = await api.pagApiget<tpTemporada[]>(this.user.usuario_login_uuid,  `${url}/report/sorteio/temporada`)
            return response


        } catch (e) {
            throw e
        }
    }

    async getSorteios(parametros: any) : Promise<tpSorteio[]> {
        try {
            let urlsorteio = `${url}/report/sorteio/list?crm_so_temp_cd=${parametros.crm_so_temp_cd}`
            const response = await api.pagApiget<tpSorteio[]>(this.user.usuario_login_uuid,  urlsorteio)
            return response     
        } catch (e) {
            throw e
        }
    }

    async getConsultarCupom(parametros: any) : Promise<tpsorteio_numero_cupom[]> {
        try {
            let urlsorteio = `${url}/report/sorteio/cupom?crm_so_temp_cd=${parametros.crm_so_temp_cd}`
            
            if (parametros.status_envio_sorteio) {
                urlsorteio += `&status_envio_sorteio=${parametros.status_envio_sorteio}`
            }

            if (parametros.cpf_cnpj && parametros.cpf_cnpj != '') {
                urlsorteio += `&cpf_cnpj=${parametros.cpf_cnpj}`
            }

            if (parametros.numero_cupom && parametros.numero_cupom != '') {
                urlsorteio += `&numero_cupom=${parametros.numero_cupom}`
            }

            if (parametros.nf_chave && parametros.nf_chave != '') {
                urlsorteio += `&nf_chave=${parametros.nf_chave}`
            }

            if (parametros.limit && parametros.limit > 0) {
                urlsorteio += `&limit=${parametros.limit}`
            }

            if (parametros.crm_so_cpf && parametros.crm_so_cpf != '') {
                urlsorteio += `&crm_so_cpf=${parametros.crm_so_cpf}`
            }
            
            if (parametros.data && parametros.data != '') {
                urlsorteio += `&data_emissao=${parametros.data}`
            }

            const response = await api.pagApiget<tpsorteio_numero_cupom[]>(this.user.usuario_login_uuid,  urlsorteio)
            return response     
        } catch (e) {
            throw e
        }
    }

    async ExportarCupons(parametros: any) : Promise<{success: boolean, message: string}> {
        let result: {success: boolean, message: string} = { success: false, message: "" }
        try {

            let urlprocessamento = `${url}/service/sorteio/exportar`
            if (parametros.data_emissao && parametros.data_emissao != '') {
                urlprocessamento += `?data_emissao=${parametros.data_emissao}`
            }

            if (parametros.crm_so_cupom_seq && parametros.crm_so_cupom_seq != '') {
                urlprocessamento += `&crm_so_cupom_seq=${parametros.crm_so_cupom_seq}`
            }

            let resultAPI = await api.pagApipost(this.user.usuario_login_uuid,  urlprocessamento, {})
            if (resultAPI && typeof resultAPI === 'object' && 'status' in result) {
                if (resultAPI.status === 200) {
                    result = { success: true, message: "Números de sorteios gerados com sucesso." }
                }

            }
        } catch (error) {
            result = { success: false, message: "Erro ao gerar números de sorteios." }
        }
        finally { 
            return result
        }
    }

    async TemporadaAtivaAtualizarBase(parametros: any) : Promise<{success: boolean, message: string}> {
        let result: {success: boolean, message: string} = { success: false, message: "" }
        try {
            console.log(parametros)


            let urlprocessamento = `${url}/service/sorteio/atualizar`
            if (parametros.data_emissao && parametros.data_emissao != '') {
                urlprocessamento += `?data_emissao=${parametros.data_emissao}`
            }





            let resultAPI = await api.pagApipost(this.user.usuario_login_uuid,  urlprocessamento, {})
            if (resultAPI && typeof resultAPI === 'object' && 'status' in result) {
                if (resultAPI.status === 200) {
                    result = { success: true, message: "Números de sorteios gerados com sucesso." }
                }

            }
        } catch (error) {
            result = { success: false, message: "Erro ao gerar números de sorteios." }
        }
        finally { 
            return result
        }
    }

}



class modulecrm { 
    user: moduleUserConnect
    AdmSorteio : modulecrmSorteio

    constructor(user: moduleUserConnect) {
        this.user = user
        this.AdmSorteio = new modulecrmSorteio(user)
    }



    async getcliente(parametros: any) : Promise<tpParticipante_Crm[]> {
        try {
            const response = await api.pagApiget<tpParticipante_Crm[]>(this.user.usuario_login_uuid,  `${url}/report/clientes`)
            return response

        } catch (e) {
            throw e
        }
    }   
}

export { modulecrm , type tpParticipante_Crm , type tpTemporada, type tpSorteio, type tpsorteio_numero_cupom }