import myTools from "../../../tools/Tools"




export default class scriptAtualizaCargaCompletaTipoVendaQtde {
    public static ScriptExecute(myDataBase_SERVER: string) : string {
         let sqlscript = `` 


         if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD()
         }            


         return sqlscript;
    }



    private static ZanthusSQLServer_CRUD() : string {

        return `    		DELETE FROM ZEUSRETAIL.DBO.TAB_Mercadoria_Tipo_Venda_qtde
                            INSERT INTO ZEUSRETAIL.DBO.TAB_Mercadoria_Tipo_Venda_qtde
                                (		cod_loja
                                    ,	cod_mercadoria
                                    ,	cod_tipo_venda
                                    ,	qtde_venda
                                    ,	flag_geral
                                    ,	preco_unitario
                                    ,	perc_desconto
                                    ,	flag_ativo
                                    ,	Dth_inclusao
                                    ,	Dth_alteracao
                                    ,	Idt_usuario_alteracao
                                )
                                SELECT	cod_loja
                                    ,	cod_mercadoria
                                    ,	cod_tipo_venda
                                    ,	qtde_venda
                                    ,	0
                                    ,	preco_unitario
                                    ,	perc_desconto
                                    ,	'S'
                                    ,	Dth_inclusao
                                    ,	Dth_alteracao
                                    ,	Idt_usuario_alteracao 
                                FROM POSTSQL.oxan.[public].tbzanthustab_mercadoria_tipo_venda_qtde;


                
                `
    }    
}