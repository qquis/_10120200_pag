import myTools from "../../../../tools/Tools";
import modelintegracao_tipo from "../../model/modelintegracao_tipo";
import modelintegracao_produto from "../../model/modelintegracao_produto";
import modelService_OLD from "../../../../model/model.service-OLD";


export default class integracaoProdutoService_default extends modelintegracao_tipo {

    constructor(item : any) {
        super(item)

        if (this.integracao_tipo_info.script_select == `` )
            this.integracao_tipo_info.script_select = item.integracao_tipo_info.script_select;

    }

    async openstart(service : modelService_OLD) : Promise<void> {}

    async Inicializar() : Promise<void> {}

    async obterProdutosPendentes(service : modelService_OLD) : Promise<modelintegracao_produto[]> 
        {   
            let mylist: modelintegracao_produto[] = []
           
            try {

                /*  Obter produtos pendentes PADRÃO 
                
                    TIPO_EXPORT = 1 -> EXPORTAÇÃO PAG PARA OUTROS SISTEMAS
                    TIPO_EXPORT = 0 -> IMPORTACAO DE DADOS DE OUTROS SISTEMA PARA O PAG
                
                */
                if (this.integracao_tipo.tipo_export == 1) { 

                    await service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Get`);    
                    const result : object = await this.integracao_tipo._Db_Pg_DataGet(this.integracao_tipo_info.script_select); 
                    await service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Map`);    
                    for await ( const[key, value] of Object.entries(result)) {
                        let myitem : modelintegracao_produto = new modelintegracao_produto(value)            
                        mylist.push(myitem)
                    }
                    await service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) Map ok`);    
                }

            }
            catch (e) {
                await service._serviceLogRegister(`M0095_IControl - Produtos pendentes (Consulta Padronizada) _ Error`);    
                myTools.pagConsole(`M0095_IControl - Produtos pendentes (Consulta Padronizada) _ Error \n ${e}`, true)    
            }
            finally {
                return mylist;
            }
        }
    async ApiItemProcessar(item : modelintegracao_produto) {
            myTools.pagConsole(`Processando Integração de Produto de tipo não definido no case ${this.integracao_tipo.integracao_tipo_cd} - Produto ${item.pr_cdproduto}`, true)
    }
    async ApiItemValidar(item: modelintegracao_produto) : Promise<boolean> {
        return false;
    }
    async getStrCRUDPostGre(item: modelintegracao_produto) : Promise<string> { return `` }
    async getStrCRUDZANTHUSPostGre(item: modelintegracao_produto) : Promise<string> { return `` }

    async processamentoLocal (ProdutosAProcessar: modelintegracao_produto[], service : modelService_OLD) : Promise<void> {
        
    }

    async Finalizar() { }
    
}