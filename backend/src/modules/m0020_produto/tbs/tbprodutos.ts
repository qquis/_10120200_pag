import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbproduto extends clsBase {
        cdparticipante_fabricante: number
        cdpessoabluesoft_fabricante: number
        dtlog_insert: Date
        dtlog_update_api: Date
        dtlog_update: Date
        prb_cdprodutobluesoft: number
        prb_cdproduto_compra_padrao: number
        prbf_seq: number
        pr_cdbarra_principal
        pr_cdproduto: number
        pr_descricao: string
        pr_embalagemcompra
        pr_embalagemcompra_fator: number
        pr_embalagemestoque
        pr_seq: number
        prsg_cdsubgrupo: number
        pr_status: number
        pr_status_comercial_preco_inativo: number


        constructor() {
            super()
            this.cdparticipante_fabricante= 0
            this.cdpessoabluesoft_fabricante= 0
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update_api= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.prb_cdprodutobluesoft= 0
            this.prb_cdproduto_compra_padrao= 0
            this.prbf_seq= 0
            this.pr_cdbarra_principal= ''
            this.pr_cdproduto= 0
            this.pr_descricao= ''
            this.pr_embalagemcompra= ''
            this.pr_embalagemcompra_fator= 0 
            this.pr_embalagemestoque= ''
            this.pr_seq= 0
            this.prsg_cdsubgrupo= 0
            this.pr_status_comercial_preco_inativo= 0 
            this.pr_status= 0


        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.cdparticipante_fabricante = item?.cdparticipante_fabricante
                this.cdpessoabluesoft_fabricante = item?.cdpessoabluesoft_fabricante
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update_api = this.myTools._datemomentDatStrToDate(item?.dtlog_update_api,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
                this.prb_cdproduto_compra_padrao = item?.prb_cdproduto_compra_padrao
                this.prbf_seq = item?.prbf_seq
                this.pr_cdbarra_principal = item?.pr_cdbarra_principal
                this.pr_cdproduto = item?.pr_cdproduto
                this.pr_descricao = item?.pr_descricao
                this.pr_embalagemcompra_fator = item?.pr_embalagemcompra_fator
                this.pr_embalagemcompra = item?.pr_embalagemcompra
                this.pr_embalagemestoque = item?.pr_embalagemestoque
                this.pr_seq = item?.pr_seq
                this.prsg_cdsubgrupo = item?.prsg_cdsubgrupo
                this.pr_status_comercial_preco_inativo = item?.pr_status_comercial_preco_inativo
                this.pr_status = item?.pr_status

        }
    }
}