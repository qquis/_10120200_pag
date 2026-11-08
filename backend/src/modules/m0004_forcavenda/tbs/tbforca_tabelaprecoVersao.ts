import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbforca_venda_tabprecoVersao extends clsBase {
            fv_tabelapreco_cd: number
            versao: number
			descontomaximo: number
			descontopadrao: number
			acrescimomaximo: number
			datainiciovigencia: Date
			datafimvigencia: Date
			ativo: number
			tabelareferencia: number 
            publicada : number

        constructor() {
            super()

            this.fv_tabelapreco_cd= 0
            this.versao= 0
            this.descontomaximo= 0
            this.descontopadrao= 0
            this.acrescimomaximo= 0
            this.datainiciovigencia= new Date()
            this.datafimvigencia= new Date()
            this.ativo= 0
            this.tabelareferencia = 0
            this.publicada = 0
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fv_tabelapreco_cd = item?.fv_tabelapreco_cd
                this.versao = item?.versao
                this.descontomaximo = item?.descontomaximo
                this.descontopadrao = item?.descontopadrao
                this.acrescimomaximo = item?.acrescimomaximo
                this.datainiciovigencia = item?.datainiciovigencia
                this.datafimvigencia = item?.datafimvigencia
                this.ativo = item?.ativo
                this.tabelareferencia = item?.tabelareferencia
                this.publicada = item?.publicada
            
            }
    }
}