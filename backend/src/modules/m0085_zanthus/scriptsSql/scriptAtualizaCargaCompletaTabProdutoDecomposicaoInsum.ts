import myTools from "../../../tools/Tools"




export default class scriptAtualizaCargaCompletaTabProdutoDecomposicaoInsum {
    public static ScriptExecute(myDataBase_SERVER: string) : string {
         let sqlscript = `` 


         if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD()
         }            


         return sqlscript;
    }



    private static ZanthusSQLServer_CRUD() : string {

        return `    DELETE FROM ZEUSRETAIL.DBO.TAB_produto_decomposicao_insum
			        INSERT INTO ZEUSRETAIL.DBO.TAB_produto_decomposicao_insum
			        	(
			        			cod_loja
			        		,	cod_mercadoria
			        		,	cod_insumo
			        		,	usuario
			        		,	data_cadastro
			        		,	data_ultima_alteracao
			        		,	controle
			        		,	percentual_insumo
			        		,	quantidade_insumo
			        	)
			        SELECT		cod_loja
			        		,	cod_mercadoria
			        		,	cod_insumo
			        		,	usuario
			        		,	data_cadastro
			        		,	data_ultima_alteracao
			        		,	'000'
			        		,	percentual_insumo
			        		,	quantidade_insumo
			        FROM	POSTSQL.oxan.[public].tbzanthustab_produto_decomposicao_insum


                
                `
    }    
}