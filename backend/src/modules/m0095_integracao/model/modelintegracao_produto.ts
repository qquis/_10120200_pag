import tbintegracao_produto from "../tbs/tbintegracao_produto"
import myTools from "../../../tools/Tools";
//import integracaoProduto from "../service/integracao.produto/integracao.produto.service";
import model_zanthus_produto from "../../m0085_zanthus/model/model_zanthus_produto";


export default class modelintegracao_produto extends tbintegracao_produto {

    ItemObjectIntegracao : any
    ApiValidacao : boolean

    model_zanthus_produto: model_zanthus_produto


    constructor(item?: any) { 
        super(); 

        this.ItemObjectIntegracao = item;
        this.ApiValidacao = false;

        this.integracao_tipo_cd = 0;
        this.model_zanthus_produto = new model_zanthus_produto()

        if (item) {
            this.integracao_produto_seq = parseInt( `${item.integracao_produto_seq? item.integracao_produto_seq : 0}` )
            this.integracao_tipo_cd = parseInt( `${item.integracao_tipo_cd? item.integracao_tipo_cd : 0}` )
            this.pr_cdproduto = parseInt( `${item.pr_cdproduto? item.pr_cdproduto : 0}` )
            this.prb_cdprodutobluesoftunitario = parseInt( `${item.prb_cdprodutobluesoftunitario? item.prb_cdprodutobluesoftunitario : 0}` )
            this.prb_cdprodutobluesoft = parseInt( `${item.prb_cdprodutobluesoft? item.prb_cdprodutobluesoft : 0}` )
            
            /*TIPO ZANTHUS*/
            this.model_zanthus_produto.pr_cdproduto = this.pr_cdproduto; 
            this.model_zanthus_produto.prb_cdprodutobluesoft = this.prb_cdprodutobluesoft
        }
    }


    async statusSetAtualizado() { await this._StatusAtualizar(1)}
    async statusSetPendente() { await this._StatusAtualizar(2)}
    async statusSetPreProcessamento() { await this._StatusAtualizar(5)}
    async statusSetError() { await this._StatusAtualizar(9)}
    async statusSetFinalizar() {await this._StatusAtualizar(99)}


    private async _StatusAtualizar(integracao_status_cd: number) {
        try {
                let sql : string = ``
                if (integracao_status_cd !== 99) 
                {
                    sql = ` UPDATE tbintegracao_produto 
                                     set  integracao_status_cd = ${integracao_status_cd}
                                       ,  dtlog_update = current_timestamp
                                     where integracao_produto_seq = ${this.integracao_produto_seq}
                                    `      
                }
                else {
                    sql = ` UPDATE tbintegracao_produto 
                            set  integracao_status_cd = ${integracao_status_cd}
                              ,  dtlog_update = current_timestamp
                            where integracao_produto_seq = ${this.integracao_produto_seq}
                              and integracao_produto_seq != 9
                   `      
                }
                await super._Db_Pg_DataPost(sql)            
            
        } catch (e) {
            myTools.pagConsole(`modelintegracao_produto | StatusAtualizar \n ${e}`)
        }

    }



}