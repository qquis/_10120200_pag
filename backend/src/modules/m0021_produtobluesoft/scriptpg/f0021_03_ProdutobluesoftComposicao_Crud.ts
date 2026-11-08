import myTools from "../../../tools/Tools"
import tbprodutobluesoft from "../tbs/tbprodutobluesoft";



export default class F0021_03_ProdutoBlueSoftComposicao_CRUD {
    public static sqlScript_VERSION(): string {return `f0021_03_1012019_produtobluesoftcomposicao_crud`}
    public static CRUD(item: any) : string {
                return `SELECT ${this.sqlScript_VERSION()}
                (   sqlcommand:= '${item.sqlcommand}',
                    vprb_cdprodutobluesoft:= ${item.prb_cdprodutobluesoft},
                    vprb_cdprodutobluesoft_unitario:= ${item.prb_cdprodutobluesoft_unitario},
                    vprbc_qtde:= ${item.prbc_qtde},
                    vprbc_descricao:= '${item.prbc_descricao}',
                    vprbc_percentual_composicao:= ${item.prbc_percentual_composicao},
                    vprbc_bluesoft_seq:= ${item.prbc_bluesoft_seq},
                    vprbc_data:= '${item.prbc_data}',
                    vcommand_api:= 'true'
                
                )`

    }
}
