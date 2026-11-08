import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_cbs extends clsBase {
    cbs_cd: number
    cbs_descricao : string
    cbs_descricao_abreviada : string
    
    constructor() {
        super()
        this.cbs_cd= 0
        this.cbs_descricao= ''
        this.cbs_descricao_abreviada= ''
    }
    async binding(item: any): Promise<void> {
            if (item) {
            this.cbs_cd = item?.cbs_cd
            this.cbs_descricao = item?.cbs_descricao
            this.cbs_descricao_abreviada = item?.cbs_descricao_abreviada
            }
    }

    sql_CRUD(): string { 
        return this.sql_insert() + ' ' + this.sql_update();
    }

    sql_insert(): string {
         let sql: string = `insert into tbfc_cbs
                    (
                                cbs_cd      					
                            ,	cbs_descricao					
                            ,	cbs_descricao_abreviada			
        
                    )
                            SELECT  ${this.cbs_cd}  
                            ,       '${this.cbs_descricao}'
                            ,       '${this.cbs_descricao_abreviada}'
                    WHERE NOT EXISTS (SELECT 1 FROM tbfc_cbs WHERE cbs_cd = ${this.cbs_cd} );
                    `
        return sql;
    }
    sql_update(): string {
        let sql: string = `update tbfc_cbs
                           set cbs_descricao = '${this.cbs_descricao}',
                               cbs_descricao_abreviada = '${this.cbs_descricao_abreviada}'
                           where cbs_cd = ${this.cbs_cd};`
        return sql;
    }
}
