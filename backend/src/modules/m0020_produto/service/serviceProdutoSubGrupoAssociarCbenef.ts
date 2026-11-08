
import { clsBase, clsTools } from '../../../model/modelbase';


export default class serviceProdutoSubGrupoAssociarCbenef { 
    static async start(parametro: any) : Promise<any> {
        let result : any = { }
        try {
          
            if (!parametro.prsg_cdsubgrupo || parametro.prsg_cdsubgrupo === 0) {
                throw new Error('Subgrupo é obrigatório')
            }   

            if (!parametro.fc_cbenef_cd || parametro.fc_cbenef_cd.trim() === '') {
                throw new Error('Código do Cbenef é obrigatório')
            }

            let sql = `UPDATE tbproduto_subgrupo set fc_cbenef_cd = '${parametro.fc_cbenef_cd}' 
                        where prsg_cdsubgrupo = ${parametro.prsg_cdsubgrupo}
                        
                        ` 
            let myBase : clsBase = new clsBase();
            await myBase.myDataBase.pag.Execute(sql)


        } catch (e) {
            clsTools.pagConsole(`serviceProdutoSubGrupoAssociarCbenef | start \n Error: ${e}`);
        
        } finally {
            
            return result
        }   
    }   

    
}

