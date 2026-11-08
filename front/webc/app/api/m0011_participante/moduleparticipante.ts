import pagApi from "../api";

const urlParticipante = `/participante/model/crm`

type participante_sexo = { 
    pf_sexo : string
    pf_sexo_descricao : string
}

type TpParticipanteCRM = {
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

class moduleParticipanteCrm {
    tipo_sexo : participante_sexo[]
    constructor() {
        this.tipo_sexo = [
            { pf_sexo : 'M', pf_sexo_descricao : 'Masculino' },
            { pf_sexo : 'F', pf_sexo_descricao : 'Feminino' },
            { pf_sexo : 'O', pf_sexo_descricao : 'Outros' },
            { pf_sexo : 'N', pf_sexo_descricao : 'Não Informado' }
        ]

    }

    async new() : Promise<TpParticipanteCRM> {
        let clientecrm : TpParticipanteCRM = { 
            crm_seq : 0,
            crm_status_cd : 0,
            crm_email: '',
            cpf: '',
            nome: '',
            sobre_nome: '',
            data_nascimento: new Date('1900-01-01'),
            pf_sexo : 'N',
            crm_dt_cadastro: new Date('1900-01-01')
        }
        return clientecrm
    }

    async consultar(parametro: any) : Promise<TpParticipanteCRM> {
        
        let clientecrm : TpParticipanteCRM = await this.new()
        try { 
                clientecrm = await pagApi.pagApiget<TpParticipanteCRM>(``, `${urlParticipante}/consultar?crm_email=${parametro.crm_email}`)
        } catch(e) { 
            throw e
        }
        finally {
            return clientecrm
        }
    }


    async incluir(parametro: TpParticipanteCRM) : Promise<TpParticipanteCRM> {
        
        let clientecrm : TpParticipanteCRM = await this.new()
        try { 
     
            let result = await pagApi.pagApipost(``,`${urlParticipante}/incluir`, parametro)
            
            clientecrm = result.data as TpParticipanteCRM



        } catch(e) { 
            throw e
        }

        finally {
            return clientecrm
        }
    }

}


export { moduleParticipanteCrm, type TpParticipanteCRM}