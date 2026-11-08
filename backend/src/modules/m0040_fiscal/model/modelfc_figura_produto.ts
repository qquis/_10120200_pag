import { ca } from "date-fns/locale";
import { clsBase, clsTools } from "../../../model/modelbase";
import tbfc_figurafiscal_produto from "../tbs/tbfc_figurafiscal_produto";
import modelfc_regrafiscalNfceProduto from "./modelfc_regrafiscalNfceProduto";
import { promiseHooks } from "v8";

const myBase = new clsBase();

export default class modelfc_figurafiscal_produto extends tbfc_figurafiscal_produto  { 
    itemNFCE : modelfc_regrafiscalNfceProduto ;
    constructor() { 
        super();
        this.itemNFCE = new modelfc_regrafiscalNfceProduto();
    }
    
    async script_atualizar(): Promise<string> { 

        let sql = `insert into tbfc_figurafiscal_produto 
        (
            	fc_figurafiscal_cd 			
            ,   fc_figurafiscal_versao
            ,   prb_cdprodutobluesoft 
            ,   regrafiscal_nfce					
         )
            SELECT     ${this.fc_figurafiscal_cd}
                    ,  ${this.fc_figurafiscal_versao}
                    ,  ${this.prb_cdprodutobluesoft}
                    ,  0
            WHERE NOT EXISTS ( SELECT 1 FROM tbfc_figurafiscal_produto WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft})
            ;

        UPDATE tbfc_figurafiscal_produto
            SET   fc_figurafiscal_cd = ${this.fc_figurafiscal_cd}
                , fc_figurafiscal_versao = ${this.fc_figurafiscal_versao}
                , dtlog_update = current_timestamp 
            WHERE prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft}
            ;

            `

        
        /* NFCE - SCRIPT DO ITEM NFCE INCLUSAO / EXCLUSÃO*/
        /* ------------------------------------------------------------------------- */
        sql += await this.itemNFCE.script_CRUD()

        /* ------------------------------------------------------------------------- */
        /* ------------------------------------------------------------------------- */

        return sql;
    }

    async bindingAPIbluesoft(prb_cdprodutobluesoft: number) : Promise<void> { 
 
        try { 
            
            let item = await  myBase.blueSoftApi.api_get(`/fiscal/figurafiscal/produto/${prb_cdprodutobluesoft}`, false);
            if (item && item.data) {
                this.fc_figurafiscal_versao = item.data.versao ? item.data.versao : 0;
                this.fc_figurafiscal_cd = item.data.codigoFiguraFiscal ? item.data.codigoFiguraFiscal : 0;
                this.prb_cdprodutobluesoft = prb_cdprodutobluesoft;
                
                await this.itemNFCE.ChamadaLeituraApiBlueSoftSatNfcePorProduto(prb_cdprodutobluesoft)

            }
            /*
            else { 
                clsTools.pagConsole(`F0040_Fiscal  | Atualizacao da figura fiscal do produto ${this.prb_cdprodutobluesoft} | Figura nao encontrada.`, true, false, 'M0040') 
            }*/

        } catch (e) { 
            //clsTools.pagConsole(`F0040 FISCAL _ modelfc_figurafiscal_produto _ bindingAPIbluesoft  | Atualizacao da figura fiscal do produto ${this.prb_cdprodutobluesoft} | Figura nao encontrada.`) 
            return 
    
        }
    }

    async getInsertScriptByProdutoBluesoft(prb_cdprodutobluesoft: number) : Promise<string> { 
        
        let sql = ``
        try { 
            await this.bindingAPIbluesoft(prb_cdprodutobluesoft);

            if (this.fc_figurafiscal_versao !== 0 && this.fc_figurafiscal_cd !== 0)
            {
                sql =  await this.script_atualizar(); 
                
            }
        } catch (e) { 
            sql = ``
        } finally
        {
            return sql;
        }
    }

    async atualizarFiguraFiscalProduto(prb_cdprodutobluesoft: number) : Promise<void> { 
        try { 
            if (!prb_cdprodutobluesoft || prb_cdprodutobluesoft == 0) { 
                throw new Error(`Código do produto bluesoft inválido.`);
            }
            await this.bindingAPIbluesoft(prb_cdprodutobluesoft);
            if (this.fc_figurafiscal_versao !== 0 && this.fc_figurafiscal_cd !== 0) {
                let sql = await this.script_atualizar();
                await myBase.myDataBase.pag.Execute(sql);
            }
        } catch (e) { 
            await clsTools.PagErrorException('M0040_FISCAL', 'modelfc_figurafiscal_produto.atualizarFiguraFiscalProduto', e, false, "", "M0040");
        }
    }
}