import tbZanthus_Tab_Mercadoria from "../tbs/tbZanthusTabMercadoria";
import myTools from "../../../tools/Tools";
import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabMercadoriaTipoVenda from "../tbs/tbZanthusTabMercadoriaTipoVenda";
import tbZanthusTabRegrasIcms from "../tbs/tbZanthusTabRegraIcms";
import tbZanthusTabMercadoriaTipoVendaQtde from "../tbs/tbZanthusTabMercadoriaTipoVendaQtde";
import tbZanthusTabProdutoDecomposicao from "../tbs/tbZanthusTabProdutoDecomposicao";
import tbZanthusTabProdutoDecomposicaoInsum from "../tbs/tbZanthusTabProdutoDecomposicaoInsum";

export default class model_zanthus_produto {
    /* CHAVES */
    pr_cdproduto : number
    prb_cdprodutobluesoft : number
    PostGreSqlScriptUpdate : string 
    SqlServerScriptUpdate : string 

    /* CLASSES */
    ListTabMercadoria : tbZanthus_Tab_Mercadoria[] 
    ListTabRegrasIcms : tbZanthusTabRegrasIcms[]
    ListTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda[]
    ListTabMercadoriaTipoVendaQtde : tbZanthusTabMercadoriaTipoVendaQtde[]
    ListTabProdutoDecomposicao : tbZanthusTabProdutoDecomposicao[]
    ListTabProdudoDecomposicaoInsum : tbZanthusTabProdutoDecomposicaoInsum[]

    constructor() {

        this.pr_cdproduto = 0 ; 
        this.prb_cdprodutobluesoft = 0;

        this.ListTabMercadoria = []
        this.ListTabRegrasIcms = []
        this.ListTabMercadoriaTipoVenda = []
        this.ListTabMercadoriaTipoVendaQtde = []
        this.ListTabProdutoDecomposicao = []
        this.ListTabProdudoDecomposicaoInsum = []

        this.PostGreSqlScriptUpdate = `` 
        this.SqlServerScriptUpdate = `` 
    }

    async binding(item: any) : Promise<void> {
        try {
            this.pr_cdproduto = item?.pr_cdproduto
            this.prb_cdprodutobluesoft = item?.prb_cdprodutobluesoft

        } catch (e) {
            await clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `binding`, e)
        }
    }

    async binding_mercadoria(
        listtabmercadoria : tbZanthus_Tab_Mercadoria[],
        listtabRegrasIcms : tbZanthusTabRegrasIcms[],
        listtabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda[],
        listtabMercadoriaTipoVendaQtde : tbZanthusTabMercadoriaTipoVendaQtde[], 
        listtabProdutoDecomposicao : tbZanthusTabProdutoDecomposicao[], 
        listtabProdutoDecomposicaoInsum : tbZanthusTabProdutoDecomposicaoInsum[]
     ) : Promise<void> {
        try {

            for await (const item of listtabmercadoria) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabMercadoria.push(item)
    
                }
            }
                        

            for await (const item of listtabRegrasIcms) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabRegrasIcms.push(item)

                }
            }  


            for await (const item of listtabMercadoriaTipoVenda) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabMercadoriaTipoVenda.push(item)

                }
            }   


            for await (const item of listtabMercadoriaTipoVendaQtde) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabMercadoriaTipoVendaQtde.push(item)

                }
            }           


  
            for await (const item of listtabProdutoDecomposicao) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabProdutoDecomposicao.push(item)

                }
            }



            for await (const item of listtabProdutoDecomposicaoInsum) {
                if (item.pr_cdproduto == this.pr_cdproduto) {
                    this.ListTabProdudoDecomposicaoInsum.push(item)

                }
            }         

    
            await this.montarScriptAtualizacao();

        }
        catch (e) {
            await clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `binding_mercadoria`, e)
        }

    }

    private async montarScriptAtualizacao () {

        
        try {

            /*TAB MERCADORIA */
            this.ListTabMercadoria.forEach(item => {
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()
            });

            /*TAB REGRA ICMS */
            this.ListTabRegrasIcms.forEach(item => {
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()             
            });

            /*TAB TIPO VENDA */
            this.ListTabMercadoriaTipoVenda.forEach(item => {
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()           
            });

            /*TAB TIPO VENDA QTDE */
            this.ListTabMercadoriaTipoVendaQtde.forEach(item => {
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()               
            });


            /*PRODUTO DECOMPOSICAO */
            this.ListTabProdutoDecomposicao.forEach(item => {
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()              
            });     
            
            /*PRODUTO INSUM */
            this.ListTabProdudoDecomposicaoInsum.forEach(item => {
                //console.log(item.ZanthusPostGre_CRUD())
                this.PostGreSqlScriptUpdate  += item.ZanthusPostGre_CRUD()           
            });                 


            await myTools._wait(30);

            

        } catch (e) { 
            await clsTools.PagErrorException(`m0085 | model_zanthus_produto`, `montarScriptAtualizacao`, e)

        }
        
    }


}