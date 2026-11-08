

import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from "../module.default"






class moduleForcaVenda extends moduleDefault { 


    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/forcavenda', sis_ac_cd)   
  
    }

     async getPrazoPgto() : Promise<any> {
        try {
            const result = await this._getAPI(`/report/prazo-pgto`)
            return result
        } catch (e) {
            console.log(`moduleForcaVenda.getPrazoPgto Error ${e}`)
             throw new Error(`moduleForcaVenda.getPrazoPgto Error ${e}`)
        }
    }

    async getTabela(parametro: any) : Promise<any> {
        try {
            let url = `/report/tabela?filter=1`

            if (parametro && parametro.fv_tabelapreco_descricao) {
                url += `&fv_tabelapreco_descricao=${parametro.fv_tabelapreco_descricao}`
            }
            if (parametro && parametro.statusversao == 1) { 
                url += `&statusversao=1`
            }

            const result = await this._getAPI(url)
            return result

        } catch (e) {
            console.log(`moduleForcaVenda.getTabela Error ${e}`)
             throw new Error(`moduleForcaVenda.getTabela Error ${e}`)
        }
    }

    async getTabelaVersao(parametro: any) : Promise<any> {
        try {
            let url = `/report/tabela-versao?filter=1`

            if (parametro && parametro.fv_tabelapreco_cd) {
                url += `&fv_tabelapreco_cd=${parametro.fv_tabelapreco_cd}`
            }

            if (parametro && parametro.vigencia_inicial) { 
                url += `&vigencia_inicial=${parametro.vigencia_inicial}`
            }

            if (parametro && parametro.fv_tabelapreco_descricao) {
                url += `&fv_tabelapreco_descricao=${parametro.fv_tabelapreco_descricao}`
            }

            const result = await this._getAPI(url)
            return result
            
        } catch (e) {
            console.log(`moduleForcaVenda.getTabelaVersao Error ${e}`)
             throw new Error(`moduleForcaVenda.getTabelaVersao Error ${e}`)
        }
    }


    async getTabelaProduto(parametro: any) : Promise<any> {
        try {
            let url = `/report/tabela-produto?filter=1`

            if (parametro && parametro.fv_tabelapreco_cd) {
                url += `&fv_tabelapreco_cd=${parametro.fv_tabelapreco_cd}`
            }

            if (parametro && parametro.vigencia_inicial) { 
                url += `&vigencia_inicial=${parametro.vigencia_inicial}`
            }

            if (parametro && parametro.fv_tabelapreco_descricao) {
                url += `&fv_tabelapreco_descricao=${parametro.fv_tabelapreco_descricao}`
            }

            if (parametro && parametro.prb_descricao) {
                url += `&prb_descricao=${parametro.prb_descricao}`
            }
                        if (parametro && parametro.prb_cdpessoabluesoft_fabricante) {
                url += `&prb_cdpessoabluesoft_fabricante=${parametro.prb_cdpessoabluesoft_fabricante}`
            }


            const result = await this._getAPI(url)
            return result
            
        } catch (e) {
            console.log(`moduleForcaVenda.getTabelaProduto Error ${e}`)
             throw new Error(`moduleForcaVenda.getTabelaProduto Error ${e}`)
        }
    }

    async getTabelaPadrao(parametro: any) : Promise<any> {
        try {
            let url = `/report/tabela-padrao?filter=1`

            if (parametro && parametro.fv_tabelapreco_cd) {
                url += `&fv_tabelapreco_cd=${parametro.fv_tabelapreco_cd}`
            }

            if (parametro && parametro.vigencia_inicial) { 
                url += `&vigencia_inicial=${parametro.vigencia_inicial}`
            }

            if (parametro && parametro.fv_tabelapreco_descricao) {
                url += `&fv_tabelapreco_descricao=${parametro.fv_tabelapreco_descricao}`
            }

            if (parametro && parametro.prb_descricao) {
                url += `&prb_descricao=${parametro.prb_descricao}`
            }

            if (parametro && parametro.prb_cdpessoabluesoft_fabricante) {
                url += `&prb_cdpessoabluesoft_fabricante=${parametro.prb_cdpessoabluesoft_fabricante}`
            }

            if (parametro.tipo_cliente) {
                url += `&tipo_cliente=${parametro.tipo_cliente}`
            }

            if (parametro.mail) {
                url += `&mail=${parametro.mail}`
                url += `&email_address=${parametro.email_address}`
            }

            const result = await this._getAPI(url)
            return result
            
        } catch (e) {
            console.log(`moduleForcaVenda.getTabelaProduto Error ${e}`)
             throw new Error(`moduleForcaVenda.getTabelaProduto Error ${e}`)
        }
    }    

    async getFabricanteFv(parametro: any) : Promise<any> {
        try {
            let url = `/report/fabricante-fv?filter=1`

            if (parametro && parametro.fv_fabricante_status == 1) {
                url += `&fv_fabricante_status=${parametro.fv_fabricante_status}`
            }



            const result = await this._getAPI(url)
            return result
            
        } catch (e) {
            console.log(`moduleForcaVenda.getFabricanteFv Error ${e}`)
             throw new Error(`moduleForcaVenda.getFabricanteFv Error ${e}`)
        }   
    }

    async postAtualizarBaseGeral() : Promise<any> {
        try { 
            const result = await this._postAPI(`/service/importar-baseGeralPreco`)

        } catch (e) {
            console.log(`moduleForcaVenda.postAtualizarBasePrazoPgto Error ${e}`)
             throw new Error(`moduleForcaVenda.postAtualizarBasePrazoPgto Error ${e}`)
        }
    
    }
}

export 
{  
    moduleForcaVenda
        
}
