import myTools from "../../../tools/Tools"




export default class scriptAtualizaCargaCompletaTipoVenda {
    public static ScriptExecute(myDataBase_SERVER: string) : string {
         let sqlscript = `` 


         if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD()
         }            


         return sqlscript;
    }



    private static ZanthusSQLServer_CRUD() : string {

        return `    	DELETE FROM ZEUSRETAIL.DBO.TAB_MERCADORIA_TIPO_VENDA
                        INSERT INTO	ZEUSRETAIL.DBO.TAB_MERCADORIA_TIPO_VENDA 
                                        (	cod_loja,
                                            controle,
                                            cod_mercadoria,
                                            cod_tipo_venda,
                                            preco_unitario,
                                            percentual_comissao_vendedor,
                                            usuario,
                                            data_cadastro,
                                            data_ultima_alteracao )
                        SELECT			DISTINCT
                                        COD_LOJA = 1
                                    ,	CONTROLE = '000'
                                    ,	COD_MERCADORIA 
                                    ,	COD_TIPO_VENDA 
                                    ,	PRECO_UNITARIO 
                                    ,	PERCENTUAL_COMISSAO_VENDEDOR 
                                    ,	USUARIO 
                                    ,	DATA_CADASTRO = data_cadastro  
                                    ,	DATA_ULTIMA_ALTERACAO = data_ultima_alteracao
                        from POSTSQL.oxan.[public].tbzanthustab_mercadoria_tipo_venda;

                
                `
    }    
}