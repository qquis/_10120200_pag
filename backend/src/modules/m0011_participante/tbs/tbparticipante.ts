import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbparticipante extends clsBase {

        cpf_cnpj: string

        bluesoftcliente: number
        bluesoftfabricante: number
        bluesoftfornecedor: number
        bluesoftmotorista: number
        bluesoftvendedor: number
        cdgrupoeconomico: number
        cdparticipante: number
        cdpessoabluesoft: number
        cdpessoabluesoft_vendedor: number
        cdpessoa: number
        celular_dd: number
        celular_numero: number

        dtlog_insert: Date
        dtlog_update: Date
        email_main: string
        erptargetcd_clien: number
        erptargetcd_vend: string
        johnson_cliente_top: number
        nome_abreviado: string
        nome_razao: string
        participante_status: number
        pessoajuridica: number
        tipo_clienteloja: number
        inscricaoestadual: string

        constructor() {
            super()

            this.cpf_cnpj= ''

            this.bluesoftcliente= 0
            this.bluesoftfabricante= 0 
            this.bluesoftfornecedor= 0 
            this.bluesoftmotorista= 0 
            this.bluesoftvendedor= 0 
            this.cdgrupoeconomico= 0
            this.cdparticipante= 0
            this.cdpessoa= 0
            this.cdpessoabluesoft= 0
            this.cdpessoabluesoft_vendedor= 0
            this.celular_dd= 0
            this.celular_numero= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.email_main= ''
            this.erptargetcd_clien= 0
            this.erptargetcd_vend= ''
            this.johnson_cliente_top= 0
            this.nome_abreviado= ''
            this.nome_razao= ''
            this.participante_status= 0 
            this.pessoajuridica= 0 
            this.tipo_clienteloja= 0 
            this.inscricaoestadual= '' 

        }
        async bindingFromRedShift(item: any): Promise<void> {
                if (item) {
                this.bluesoftcliente = item?.bluesoftcliente
                this.bluesoftfabricante = item?.bluesoftfabricante
                this.bluesoftfornecedor = item?.bluesoftfornecedor
                this.bluesoftmotorista = item?.bluesoftmotorista
                this.bluesoftvendedor = item?.bluesoftvendedor
                this.cdgrupoeconomico = item?.cdgrupoeconomico
                this.cdparticipante = item?.cdparticipante
                this.cdpessoabluesoft = item?.cdpessoabluesoft
                this.cdpessoabluesoft_vendedor = item?.cdpessoabluesoft_vendedor
                this.cdpessoa = item?.cdpessoa
                this.celular_dd = item?.celular_dd
                this.celular_numero = item?.celular_numero
                this.cpf_cnpj = item?.cpf_cnpj
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.email_main = item?.email_main
                this.erptargetcd_clien = item?.erptargetcd_clien
                this.erptargetcd_vend = item?.erptargetcd_vend
                this.johnson_cliente_top = item?.johnson_cliente_top
                this.nome_abreviado = item?.nome_abreviado? item?.nome_abreviado.replace("'", "") : ''
                this.nome_razao = item?.nome_razao? item?.nome_razao.replace("'", "") : ''
                this.participante_status = item?.participante_status
                this.pessoajuridica = item?.pessoajuridica
                this.tipo_clienteloja = item?.tipo_clienteloja
                this.inscricaoestadual = item?.inscricaoestadual? item?.inscricaoestadual.replace("'", "") : ''
            }
        }


        async bindingFromBlueSoftAPI(item: any): Promise<void> {
            if (item) {
                    this.cdpessoabluesoft = item?.clienteKey
                    this.nome_razao = item?.nomeRazao? item?.nomeRazao.replace("'", "") : ''
                    this.nome_abreviado = item?.nomeAbreviado? item?.nomeAbreviado.replace("'", "") : ''
                    this.cpf_cnpj = item?.cpfCnpj.padStart(14, '0')
                    this.pessoajuridica = item?.tipo == 'JURIDICA' ? 1 : 0
                    this.inscricaoestadual = item?.inscricaoEstadual? item?.inscricaoEstadual.replace("'", "").replace("'","") : ''
             }
            
        }


    
}