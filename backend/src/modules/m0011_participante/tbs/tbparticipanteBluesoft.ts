import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbparticipanteBluesoft extends clsBase {
        bluesoftcliente_creditolimite_valor: number
        bluesoftcliente_creditolimite_valor_reservado: number
        bluesoftcliente_creditostatus_cd: number
        bluesoftcliente: number
        bluesoftcliente_ramoatividade_cd: number
        bluesoftclientestatus: number
        bluesoftfabricante: number
        bluesoftfornecedor: number
        bluesoftmotorista: number
        bluesoft_pessoa_data_cadastro: Date
        bluesoft_pessoa_status: number
        bluesoftvendedor: number
        cdgrupoeconomico: number
        cdparticipante: number
        cdpessoabluesoft: number
        cdpessoabluesoft_vendedor: number
        cpf_cnpj: string
        dtlog_insert: Date
        dtlog_update: Date
        nome_abreviado: string
        nome_razao: string
        pessoajuridica: number
        constructor() {
            super()
            this.bluesoftcliente= 0 
            this.bluesoftcliente_creditolimite_valor= 0 
            this.bluesoftcliente_creditolimite_valor_reservado= 0 
            this.bluesoftcliente_creditostatus_cd= 0
            this.bluesoftcliente_ramoatividade_cd= 0
            this.bluesoftclientestatus= 0 
            this.bluesoftfabricante= 0 
            this.bluesoftfornecedor= 0 
            this.bluesoftmotorista= 0 
            this.bluesoft_pessoa_data_cadastro= this.__defaultDateNow 
            this.bluesoft_pessoa_status= 0 
            this.bluesoftvendedor= 0 
            this.cdgrupoeconomico= 0
            this.cdparticipante= 0
            this.cdpessoabluesoft= 0
            this.cdpessoabluesoft_vendedor= 0
            this.cpf_cnpj= ''
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.nome_abreviado= ''
            this.nome_razao= ''
            this.pessoajuridica= 0 
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.bluesoftcliente_creditolimite_valor = item?.bluesoftcliente_creditolimite_valor
                this.bluesoftcliente_creditolimite_valor_reservado = item?.bluesoftcliente_creditolimite_valor_reservado
                this.bluesoftcliente_creditostatus_cd = item?.bluesoftcliente_creditostatus_cd
                this.bluesoftcliente = item?.bluesoftcliente
                this.bluesoftcliente_ramoatividade_cd = item?.bluesoftcliente_ramoatividade_cd
                this.bluesoftclientestatus = item?.bluesoftclientestatus
                this.bluesoftfabricante = item?.bluesoftfabricante
                this.bluesoftfornecedor = item?.bluesoftfornecedor
                this.bluesoftmotorista = item?.bluesoftmotorista
                this.bluesoft_pessoa_data_cadastro = item?.bluesoft_pessoa_data_cadastro
                this.bluesoft_pessoa_status = item?.bluesoft_pessoa_status
                this.bluesoftvendedor = item?.bluesoftvendedor
                this.cdgrupoeconomico = item?.cdgrupoeconomico
                this.cdparticipante = item?.cdparticipante
                this.cdpessoabluesoft = item?.cdpessoabluesoft
                this.cdpessoabluesoft_vendedor = item?.cdpessoabluesoft_vendedor
                this.cpf_cnpj = item?.cpf_cnpj
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.nome_abreviado = item?.nome_abreviado.replace("'", "")
                this.nome_razao = item?.nome_razao.replace("'", "")
                this.pessoajuridica = item?.pessoajuridica
        }
        }
}