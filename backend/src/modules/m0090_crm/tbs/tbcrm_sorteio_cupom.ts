import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbcrm_sorteio_cupom extends clsBase {
        cdparticipante: number


        crm_so_cupom_seq: number
        crm_so_temp_cd: number
        
        numero_cupom: number
        numero_pedido: number

        data_emissao: Date
        data_emissao_hora: Date
        sat_ecf: number

        nf_numero: number
        nf_chave: string
        nf_data_emissao: Date
        valor: number


        cpf_cnpj: string
        crm_so_cpf: string

        crm_so_qtde_numero_sorteio: number

        crm_so_registrado: number
        crm_so_log_registro: Date

        crm_so_externo_enviado: number
        crm_so_externo_enviado_data: Date

        constructor() {
            super()
            this.cdparticipante= 0
            
            this.cpf_cnpj= ''
            this.crm_so_cpf= ''
            this.crm_so_cupom_seq= 0
            this.crm_so_temp_cd= 0
            this.data_emissao= this.__dataZERO
            this.data_emissao_hora= this.__dataZERO
            this.numero_cupom= 0
            this.numero_pedido= 0
            this.nf_numero= 0
            this.nf_chave= ''
            this.nf_data_emissao= this.__dataZERO
            this.sat_ecf= 0
            this.valor= 0 

            this.crm_so_qtde_numero_sorteio = 0;
            this.crm_so_registrado = 0;
            this.crm_so_log_registro = this.__dataZERO;

            this.crm_so_externo_enviado = 0;
            this.crm_so_externo_enviado_data = this.__dataZERO;
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.cdparticipante = item?.cdparticipante
                
                this.cpf_cnpj = item?.cpf_cnpj
                this.crm_so_cpf = item?.crm_so_cpf
                this.crm_so_cupom_seq = item?.crm_so_cupom_seq
                this.crm_so_temp_cd = item?.crm_so_temp_cd
                this.data_emissao = item?.data_emissao
                this.data_emissao_hora = item?.data_emissao_hora

                this.numero_cupom = item?.numero_cupom
                this.nf_numero = item?.nf_numero
                this.nf_chave = item?.nf_chave
                this.nf_data_emissao = item?.nf_data_emissao
                this.numero_pedido = item?.numero_pedido
                this.sat_ecf = item?.sat_ecf
                this.valor = item?.valor
                this.crm_so_qtde_numero_sorteio = item?.crm_so_qtde_numero_sorteio;
                this.crm_so_registrado = item?.crm_so_registrado;
                this.crm_so_log_registro = item?.crm_so_log_registro;
                this.crm_so_externo_enviado = item?.crm_so_externo_enviado;
                this.crm_so_externo_enviado_data = item?.crm_so_externo_enviado_data;
        }
    }
}