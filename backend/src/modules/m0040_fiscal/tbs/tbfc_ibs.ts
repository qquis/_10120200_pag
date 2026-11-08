import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_ibs extends clsBase {
        ibs_cd: number
        ibs_descricao : string
        ibs_descricao_abreviada : string
        
        constructor() {
            super()
            this.ibs_cd= 0
            this.ibs_descricao= ''
            this.ibs_descricao_abreviada= ''
        }
        async binding(item: any): Promise<void> {
            if (item) {
                this.ibs_cd = item?.ibs_cd
                this.ibs_descricao = item?.ibs_descricao
                this.ibs_descricao_abreviada = item?.cbs_descricao_abreviada
            }       
        }
        sql_CRUD(): string { 
            
            let sql = this.sql_insert()
                sql+= this.sql_update()

            return sql;
        }
        sql_update(): string {
            let sql = ``;
            sql += `update tbfc_ibs
                        set 
                                    ibs_descricao = '${this.ibs_descricao}'					
                                ,	ibs_descricao_abreviada = '${this.ibs_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where ibs_cd = ${this.ibs_cd};
            `
            return sql;
        }
        sql_insert(): string {
            let sql = ``;
            sql += `insert into tbfc_ibs
                        (
                                    ibs_cd      					
                                ,	ibs_descricao					
                                ,	ibs_descricao_abreviada			
            
                        )
                                SELECT  ${this.ibs_cd}  
                                ,       '${this.ibs_descricao}'
                                ,       '${this.ibs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs WHERE ibs_cd = ${this.ibs_cd} );
                        ;
            `
            return sql;
        }
    }
