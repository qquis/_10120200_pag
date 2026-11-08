import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbparticipanteVip extends clsBase {
        vip_id: number
        vip_cliente_id : string 
        vip_cpf_cnpj: string 
        vip_cpf: string 
        vip_cnpj: string
        vip_data_nascimento: Date
        vip_email: string
        vip_nome: string
        vip_sobre_nome: string
        vip_nome_completo: string
        vip_telefone_celular: string
        constructor() {
            super()
            this.vip_id = 0
            this.vip_cliente_id = ''
            this.vip_cpf_cnpj = ''
            this.vip_cpf= ''
            this.vip_cnpj= ''
            this.vip_data_nascimento = clsTools._datemomentDateToStr(this.__defaultDateNow, "YYYY-MM-DD") as unknown as Date
            this.vip_email= ''
            this.vip_nome= ''
            this.vip_sobre_nome= ''
            this.vip_telefone_celular= ''
            this.vip_nome_completo = ''
        }
        async binding(item: any): Promise<void> {
            /*
                Le as informações do banco de dados 
            */
            if (item) {
                this.vip_id = item?.vip_id
                this.vip_cliente_id = item?.vip_cliente_id
                this.vip_cpf_cnpj = item?.vip_cpf_cnpj 
                this.vip_cnpj = item?.vip_cnpj
                this.vip_cpf = item?.vip_cpf
                this.vip_data_nascimento = item?.vip_data_nascimento
                this.vip_email = item?.vip_email
                this.vip_nome = item?.vip_nome
                this.vip_sobre_nome = item?.sobre_nome
                this.vip_telefone_celular = item?.vip_telefone_celular
                this.vip_nome_completo = item?.vip_nome_completo

            } 
    }
}