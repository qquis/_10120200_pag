import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbparticipanteCrm extends clsBase {
        crm_seq : number
        crm_status_cd : number 
        crm_email: string 
        crm_dt_cadastro: Date
        cpf: string 
        nome: string 
        sobre_nome: string 
        data_nascimento: Date
        pf_sexo : string

        
        constructor() {
            super()
            this.crm_seq = 0
            this.crm_status_cd = 0
            this.crm_email= ''
            this.cpf = ''
            this.nome= ''
            this.sobre_nome= ''
            this.crm_dt_cadastro = clsTools._datemomentDatStrToDate('1900-01-01')
            this.data_nascimento = clsTools._datemomentDatStrToDate('1900-01-01')
            this.pf_sexo = 'N'

        }
        async binding(item: any): Promise<void> {
            /*
                Le as informações do banco de dados 
            */

            if (item) {
                this.crm_seq = item?.crm_seq
                this.crm_status_cd = item?.crm_status_cd 
                this.crm_email = item?.crm_email
                this.cpf = item?.cpf
                this.nome = item?.nome
                this.sobre_nome = item?.sobre_nome
                this.data_nascimento = item?.data_nascimento
                this.crm_dt_cadastro = item?.crm_dt_cadastro
                this.pf_sexo = item?.pf_sexo
            } 
    }

}