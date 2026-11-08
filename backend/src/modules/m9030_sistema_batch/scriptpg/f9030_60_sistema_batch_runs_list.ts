import ifilter from '../interfaces'
import myTools from '../../../tools/Tools';

export default class f9030_60_sistema_batch_runs_list {

    //private static sqlScript_VERSION(): string {return `f9030_60_1012006_sistema_batch_runs_list`} 
    //private static sqlScript_VERSION(): string {return `f9030_60_1012008_sistema_batch_runs_list`} //Alteração _ 30/04/2025

    private static sqlScript_VERSION(): string {return `f9030_60_1012014_sistema_batch_runs_list`} //Alteração _ 09/09/2025

    

    public static SELECT(filter : ifilter): string {

            try {
                    let SQL = `Select * 
                               from ${f9030_60_sistema_batch_runs_list.sqlScript_VERSION()}
                                        (       vsis_batch_service_cd:= ${filter.sis_batch_service_cd},
                                                vsis_batch_cd:= ${filter.sis_batch_cd}, 
                                                vsis_batch_run_status_cd:= ${filter.sis_batch_run_status_cd}, 
                                                vsis_batch_run_seq:= ${filter.sis_batch_run_seq} 
                                                
                                        )`
                    //console.log(SQL)
                    return SQL; 
                    
                    
            } catch (e){
                    return ``
            }

    }
}
