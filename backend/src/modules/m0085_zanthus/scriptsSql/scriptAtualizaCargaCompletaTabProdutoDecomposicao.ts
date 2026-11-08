import myTools from "../../../tools/Tools"




export default class scriptAtualizaCargaCompletaTabProdutoDecomposicao {
    public static ScriptExecute(myDataBase_SERVER: string) : string {
         let sqlscript = `` 


         if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD()
         }            


         return sqlscript;
    }



    private static ZanthusSQLServer_CRUD() : string {

        return `    	DELETE FROM		ZEUSRETAIL.DBO.TAB_produto_decomposicao
                        INSERT INTO		ZEUSRETAIL.DBO.TAB_produto_decomposicao
                        (	
                                cod_loja 
                            ,	controle 
                            ,	cod_mercadoria 
                            ,	forma_decomposicao 
                            ,	tipo_decomposicao 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
                        )

                        SELECT 
                                cod_loja 
                            ,	'000'
                            ,	cod_mercadoria 
                            ,	forma_decomposicao 
                            ,	tipo_decomposicao 
                            ,	usuario 
                            ,	data_cadastro 
                            ,	data_ultima_alteracao 
                        FROM	POSTSQL.oxan.[public].tbzanthustab_produto_decomposicao


                
                `
    }    
}