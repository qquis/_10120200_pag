import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_class_trib_ibs_cbs extends clsBase {
        rt_codigo_class_trib_ibs_cbs: string
        rt_descricao_class_trib_ibs_cbs : string

        
        constructor() {
            super()
            this.rt_codigo_class_trib_ibs_cbs= "000"
            this.rt_descricao_class_trib_ibs_cbs= ''
        }
        async binding(item: any): Promise<void> {
                if (item) {
                this.rt_codigo_class_trib_ibs_cbs = item?.rt_codigo_class_trib_ibs_cbs
                this.rt_descricao_class_trib_ibs_cbs = item?.rt_descricao_class_trib_ibs_cbs
                }
        }

        sql_CRUD(): string { 
            
            let sql = this.sql_insert()
                sql+= this.sql_update()

            return sql;
        }

        sql_update(): string {
            let sql = `update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${this.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}';
            `
            return sql;
        }


        sql_insert(): string {
              let sql = `insert into tbfc_class_trib_ibs_cbs
                        (
                                    rt_codigo_class_trib_ibs_cbs      					
                                ,	rt_descricao_class_trib_ibs_cbs                    
            
                        )
                                SELECT  '${this.rt_codigo_class_trib_ibs_cbs}'  
                                ,       '${this.rt_descricao_class_trib_ibs_cbs}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_class_trib_ibs_cbs WHERE rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}' );
                        ;
                        update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${this.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${this.rt_codigo_class_trib_ibs_cbs}';
            `
            return sql;
        }
    
}