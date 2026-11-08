import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbprodutoembalagem_gtins extends clsBase {
        dtlog_insert: Date
        dtlog_update_api: Date
        dtlog_update: Date
        prb_cdprodutobluesoft: number
        pr_cdproduto: number
        pre_embalagem
        preg_cdbarra

        constructor() {
            super()
            this.dtlog_insert= this.__defaultDateNow 
            this.dtlog_update_api= this.__defaultDateNow 
            this.dtlog_update= this.__defaultDateNow 
            this.prb_cdprodutobluesoft= 0
            this.pr_cdproduto= 0
            this.pre_embalagem= ''
            this.preg_cdbarra= ''

        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.dtlog_insert = this.myTools._datemomentDatStrToDate(item?.dtlog_insert,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update_api = this.myTools._datemomentDatStrToDate(item?.dtlog_update_api,`YYYY-MM-DD HH:mm:ss`)
                this.dtlog_update = this.myTools._datemomentDatStrToDate(item?.dtlog_update,`YYYY-MM-DD HH:mm:ss`)
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
                this.pr_cdproduto = item?.pr_cdproduto
                this.pre_embalagem = item?.pre_embalagem
                this.preg_cdbarra = item?.preg_cdbarra

        }
    }
}