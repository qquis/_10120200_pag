import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_icms extends clsBase {
            icms_cd: number
			codigoOrigem: number
			codigoTributacao: number
			icms_descricao: string
			sigla: string
			aliquota: number
			reducao: number
			porcentagemDiferimento: number

        constructor() {
            super()
            this.icms_cd= 0
            this.codigoOrigem= 0
            this.codigoTributacao= 0
            this.icms_descricao= ''
            this.sigla= ''
            this.aliquota= 0
            this.reducao= 0
            this.porcentagemDiferimento= 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.icms_cd = item?.icms_cd
                this.codigoOrigem = item?.codigoOrigem
                this.codigoTributacao = item?.codigoTributacao
                this.icms_descricao = item?.icms_descricao
                this.sigla = item?.sigla
                this.aliquota = item?.aliquota
                this.reducao = item?.reducao
                this.porcentagemDiferimento = item?.porcentagemDiferimento
        }
    }
}