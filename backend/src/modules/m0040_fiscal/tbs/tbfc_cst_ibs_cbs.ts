import { clsTools, clsBase} from '../../../model/modelbase'
export default class tbfc_cst_ibs_cbs extends clsBase {
    rt_codigo_cst_ibs_cbs: string
    cst_ibs_cbs_descricao : string
    
    constructor() {
        super()
        this.rt_codigo_cst_ibs_cbs= ''
        this.cst_ibs_cbs_descricao= ''
    }
    async binding(item: any): Promise<void> {
            if (item) {
            this.rt_codigo_cst_ibs_cbs = item?.rt_codigo_cst_ibs_cbs
            this.cst_ibs_cbs_descricao = item?.cst_ibs_cbs_descricao
        }
    }
    sql_CRUD() { 
        return this.sql_insert() + this.sql_update();
    }
    sql_insert() {
        return `insert into tbfc_cst_ibs_cbs
                    (
                                rt_codigo_cst_ibs_cbs      					
                            ,	cst_ibs_cbs_descricao                    
        
                    )
                            SELECT  '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}'  
                            ,       '${this.cst_ibs_cbs_descricao.replace("'", "''")}'
                    WHERE NOT EXISTS (SELECT 1 
                                    FROM tbfc_cst_ibs_cbs 
                                    WHERE rt_codigo_cst_ibs_cbs = '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}' );`
                    
    }   
    sql_update() { 
        return `update tbfc_cst_ibs_cbs
        set 
                cst_ibs_cbs_descricao = '${this.cst_ibs_cbs_descricao.replace("'", "''")}'                    
            ,   dtlog_update = CURRENT_TIMESTAMP			
        where rt_codigo_cst_ibs_cbs = '${this.rt_codigo_cst_ibs_cbs.replace("'", "''")}';
        `;
    }
}
