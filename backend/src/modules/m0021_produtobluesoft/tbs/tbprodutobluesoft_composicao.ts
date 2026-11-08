import F0021_03_ProdutoBlueSoftComposicao_CRUD from '../scriptpg/f0021_03_ProdutobluesoftComposicao_Crud'
import { modelTb } from "../../../model/model";

export default class tbprodutobluesoft_composicao   {
    prb_cdprodutobluesoft: number 
    prb_cdprodutobluesoft_unitario: number 
    prbc_descricao: string 
    prbc_percentual_composicao: number 
    prbc_qtde: number 
    prbc_data: Date
    prbc_bluesoft_seq: number
    gtinPrincipal: string 

    constructor() {
        //super();
        this.prb_cdprodutobluesoft = 0
        this.prb_cdprodutobluesoft_unitario = 0
        this.prbc_descricao = ``
        this.prbc_percentual_composicao = 0
        this.prbc_qtde = 0
        this.prbc_data = new Date()
        this.prbc_bluesoft_seq = 0
        this.gtinPrincipal = ``
    }


    async _Db_Pg_script(_stringCommand: string): Promise<string> {
        let sql : string = `` 
        try {
            sql =  `SELECT ${F0021_03_ProdutoBlueSoftComposicao_CRUD.sqlScript_VERSION()}
                (  sqlcommand:= '${_stringCommand}',
                    vprb_cdprodutobluesoft:= ${this.prb_cdprodutobluesoft},
                    vprb_cdprodutobluesoft_unitario:= ${this.prb_cdprodutobluesoft_unitario},
                    vprbc_qtde:= ${this.prbc_qtde},
                    vprbc_descricao:= '${this.prbc_descricao.substring(0, 30).replace("'", "")}',
                    vprbc_percentual_composicao:= ${this.prbc_percentual_composicao},
                    vgtin_principal:= '${this.gtinPrincipal}',
                    vcommand_api:= 'true'
                    ); `              
               return sql;                                
            }
        catch(e) {
            throw new Error(` ERROR Classe tbprodutobluesoft_composicao ${e} `)
        }

    }
}