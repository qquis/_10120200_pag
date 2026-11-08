
import { clsBase, clsTools } from '../../../model/modelbase';


export default class serviceFiscal_Cbenef_AtualizarProdutoPag { 
    static async start(parametro: any) : Promise<number> {
        try {
          
            
          
            if (parametro.fc_cbenef_cd == null || parametro.fc_cbenef_cd.trim() === '') {
                throw new Error('Código do Cbenef é obrigatório')
            }

            if (parametro.lista_produtos == null || parametro.lista_produtos.length === 0) {
                throw new Error('Lista de produtos é obrigatória')
            }

            let sql = `UPDATE tbproduto 
                        set  pr_pag_fc_cbenef_cd = '${parametro.fc_cbenef_cd === "X"? "": parametro.fc_cbenef_cd }' 
                        where prb_cdprodutobluesoft in (${parametro.lista_produtos})
                        ` 


                    
            let myBase : clsBase = new clsBase();
            await myBase.myDataBase.pag.Execute(sql)
            


        } catch (e) {
            clsTools.pagConsole(`serviceFiscal_Cbenef_AtualizarProdutoPag | start \n Error: ${e}`);
        
        } finally {
            
            return 1 
        }   
    }   

    
}

