import F0021_04_ProdutoBlueSoft_gtins_CRUD from '../scriptpg/F0021_02_ProdutoBlueSoft_gTins_CRUD'
import { modelTb } from "../../../model/model";

export default class tbprodutobluesoft_gtins   {
    prbg_cdbarra_pk: string 
    prb_cdprodutobluesoft: number 
    prbg_embalagem: string 
    prbg_embalagemdescricao: string 
    constructor() {
        //super();
        this.prb_cdprodutobluesoft = 0 
        this.prbg_cdbarra_pk = `` 
        this.prbg_embalagem = `` 
        this.prbg_embalagemdescricao = `` 
    }


    async _Db_Pg_script(_stringCommand: string): Promise<string> {
        let sql : string = `` 
        try {
            sql =  `SELECT ${F0021_04_ProdutoBlueSoft_gtins_CRUD.sqlScript_VERSION()}
                (  sqlcommand:= '${_stringCommand}',
                   vprbg_cdbarra_pk:= '${this.prbg_cdbarra_pk}',
                   vprb_cdprodutobluesoft:= ${this.prb_cdprodutobluesoft},
                   vprbg_embalagem:= '${this.prbg_embalagem}',
                   vprbg_embalagemdescricao:= '${this.prbg_embalagemdescricao}', 
                   vcommand_api:= 'true'
                    ); `              
               return sql;                                
            }
        catch(e) {
            throw new Error(` Classe modelProdutoBluesoft
                Método: getApiBluesoftSqlCRUD
                -----------------------------------------------------------
                Script SQL 
                -----------------------------------------------------------
                ${sql}
                -----------------------------------------------------------
                Error ${e} \n 
              `)
        }

    }
}