import { clsTools, clsBase} from '../../../model/modelbase'

import tbgrupoeconomico from '../tbs/tbgrupoeconomico'

export default class modelGrupoEconomico  { 
    itemGrupoEconomico: tbgrupoeconomico

    dadosApi: any
 
    
    constructor(filter: any) {
        this.itemGrupoEconomico = new tbgrupoeconomico()
        this.dadosApi = {}

    }

    async lerApiBluesoft(itemApi: any) : Promise<void> {
        if (itemApi) {

            this.dadosApi.dados = itemApi
            this.dadosApi.cdgrupoeconomico = itemApi?.grupoEconomicoKey
            this.dadosApi.descricao = itemApi?.descricao.slice(0, 80).replace("'","")
            await this.lerApiBluesoftTiposPgto()
            
            

        }
    }

    private async lerApiBluesoftTiposPgto(): Promise<void> {
        this.dadosApi.forma_pgto_ref_blue_padrao = `NAO DEFINIDA`
        this.dadosApi.formaPgtos = []
        if (this.dadosApi.dados) {
            
            if (this.dadosApi.dados) {
                let formaPgtos : any[] = []
                if (this.dadosApi.dados.tiposDePagamento && this.dadosApi.dados.tiposDePagamento.length > 0) {
                    for (let itemFormaPgto of this.dadosApi.dados.tiposDePagamento as any[]) {
                        let item = {
                            forma_pgto_ref_blue: itemFormaPgto?.descricaoTipoPagamento,
                            forma_pgto_padrao: itemFormaPgto?.tipoPagamentoPadrao
                        }
                        if (item.forma_pgto_padrao) {
                            this.dadosApi.forma_pgto_ref_blue_padrao = item.forma_pgto_ref_blue
                        } 
                        formaPgtos.push(item)
                    }
                    this.dadosApi.formaPgtos = formaPgtos
                }
            }
            
        }
        
    }

    script_update_from_api(): string {
     let sql = `
                WITH forma_pgto_lookup AS (
                    SELECT 
                        forma_pgto_cd
                    FROM tbforma_pgto_bluesoft
                    WHERE forma_pgto_descricao = '${this.dadosApi.forma_pgto_ref_blue_padrao}'
                    LIMIT 1
                )
                UPDATE tbgrupoeconomico x
                SET 
                        descricao = '${this.dadosApi.descricao.replace("'","")}'
                    ,   forma_pgto_cd_padrao = (SELECT forma_pgto_cd FROM forma_pgto_lookup)
                    ,   dtlog_update = current_timestamp
                WHERE 
                    x.cdgrupoeconomico = '${this.dadosApi.cdgrupoeconomico}'
                ;
     
     `
     return sql;
    }

}
