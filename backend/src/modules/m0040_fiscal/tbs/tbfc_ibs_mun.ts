import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_ibs_mun extends clsBase {
        ibs_mun_cd: number
        ibs_mun_descricao : string
        ibs_mun_descricao_abreviada : string
        
        constructor() {
            super()
            this.ibs_mun_cd= 0
            this.ibs_mun_descricao= ''
            this.ibs_mun_descricao_abreviada= ''
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.ibs_mun_cd = item?.ibs_cd
                this.ibs_mun_descricao = item?.ibs_descricao
                this.ibs_mun_descricao_abreviada = item?.ibs_descricao_abreviada
            }
        
        }
        sql_CRUD(): string { 
            
            let sql = this.sql_insert()
                sql+= this.sql_update()

            return sql;
        }
        sql_update(): string {
            let sql = ``;
            sql += `update tbfc_ibs_mun
                        set 
                                    ibs_mun_descricao = '${this.ibs_mun_descricao}'					
                                ,	ibs_mun_descricao_abreviada = '${this.ibs_mun_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where ibs_mun_cd = ${this.ibs_mun_cd};
            `
            return sql;
        }
        sql_insert(): string {
            let sql = ``;
            sql += `insert into tbfc_ibs_mun
                        (
                                    ibs_mun_cd      					
                                ,	ibs_mun_descricao					
                                ,	ibs_mun_descricao_abreviada			
            
                        )
                                SELECT  ${this.ibs_mun_cd}  
                                ,       '${this.ibs_mun_descricao}'
                                ,       '${this.ibs_mun_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs_mun WHERE ibs_mun_cd = ${this.ibs_mun_cd} );
                        ;
            `
            return sql;
        }
}