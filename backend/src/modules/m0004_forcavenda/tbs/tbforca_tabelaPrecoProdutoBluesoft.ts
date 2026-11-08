import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbforca_venda_tabprecoProdutoBluesoft extends clsBase {
					fv_tabelapreco_cd 				: number
					fv_tabelapreco_prod_seq_blue	: number
					prb_cdprodutobluesoft			: number 
					precoEmbalagem 					: number
					precoUnitario 					: number
					descontoMaximo				 	: number
					descontoPadrao 					: number
					acrescimoMaximo 				: number
					fatorPreco  					: number
					fatorEstoque 					: number
					versao 							: number
					precoPromocional 				: number

        constructor() {
            super()
            this.fv_tabelapreco_cd = 0
            this.fv_tabelapreco_prod_seq_blue = 0
            this.prb_cdprodutobluesoft = 0
            this.precoEmbalagem = 0
            this.precoUnitario = 0
            this.descontoMaximo = 0
            this.descontoPadrao = 0
            this.acrescimoMaximo = 0
            this.fatorPreco = 0
            this.fatorEstoque = 0
            this.versao = 0
            this.precoPromocional = 0
            
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.fv_tabelapreco_cd = item?.fv_tabelapreco_cd
                this.fv_tabelapreco_prod_seq_blue = item?.fv_tabelapreco_prod_seq_blue
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
                this.precoEmbalagem = item?.precoEmbalagem
                this.precoUnitario = item?.precoUnitario
                this.descontoMaximo = item?.descontoMaximo
                this.descontoPadrao = item?.descontoPadrao
                this.acrescimoMaximo = item?.acrescimoMaximo
                this.fatorPreco = item?.fatorPreco
                this.fatorEstoque = item?.fatorEstoque
                this.versao = item?.versao
                this.precoPromocional = item?.precoPromocional
            
            }
    }
}