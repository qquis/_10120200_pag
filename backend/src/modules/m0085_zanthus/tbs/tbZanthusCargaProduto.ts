import { modelTb } from "../../../model/model"
import myTools from "../../../tools/Tools";

export default class tbzanthus_carga_produto extends modelTb {
            carga_uuid: string
            carga_produto_seq: number
            pr_cdproduto: number
            prb_cdprodutobluesoftunitario: number
            prb_cdprodutobluesoft: number
            cod_mercadoria: string  
        constructor() {
            super();
            this.carga_uuid = ``
            this.carga_produto_seq = 0
            this.pr_cdproduto = 0
            this.prb_cdprodutobluesoftunitario = 0
            this.prb_cdprodutobluesoft = 0
            this.cod_mercadoria = ``
        } 

        async binding(item: any): Promise<void> {
            try { 

                this.carga_uuid = item?.carga_uuid
                this.carga_produto_seq = parseInt(item?.carga_produto_seq)
                this.pr_cdproduto = item?.pr_cdproduto
                this.prb_cdprodutobluesoftunitario = item?.prb_cdprodutobluesoftunitario
                this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft
                this.cod_mercadoria = item?.cod_mercadoria
                    


            } catch (e) { 
                myTools.pagConsole(`M0085 _ Zanthus | tbZanthusCargaProduto.binding 
                    Error: 
                    ${e}    
                    `)
            }
        }

        ZanthusPostGre_CRUD(): string {
            try { 

                let scriptSQL = `
                INSERT INTO		tb_zanthus_carga_produto (
                                            carga_uuid
                                        ,	pr_cdproduto
                                        ,	prb_cdprodutobluesoftunitario
                                        ,	prb_cdprodutobluesoft
                                        ,	cod_mercadoria      
                                        )
    
                            SELECT			DISTINCT
                                            '${this.carga_uuid}'
                                        ,	${this.pr_cdproduto}
                                        ,	${this.prb_cdprodutobluesoftunitario}
                                        ,	${this.prb_cdprodutobluesoft}
                                        ,	'${this.cod_mercadoria}'
                            WHERE NOT EXISTS (
                                            SELECT 1
                                            FROM tb_zanthus_carga_produto
                                            WHERE carga_uuid = '${this.carga_uuid}'
                                              AND cod_mercadoria = '${this.cod_mercadoria}'
                                        );

                            
                            ;   
                `
            


                return scriptSQL; 


            } catch (e) {
                myTools.pagConsole(`M0085_ZANTHUS | tbZanthusCarga - ZanthusPostGre_CRUD
                                    Item ${this.carga_uuid} 
                                    Error \n ${e}
                                   `)
                return ``
            }
        }



}

