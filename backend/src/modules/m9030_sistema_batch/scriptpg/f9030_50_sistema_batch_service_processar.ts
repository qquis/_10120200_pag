//import  ifilter  from '../interfaces'
import myTools from '../../../tools/Tools';



export default class f9030_50_sistema_batch_service_processar {
                                                        
    private static sqlScript_VERSION(): string {return `f9030_50_1012014_sistema_batch_runs_processar`}
    public static SELECT(sis_batch_service_cd: number): string {
                        let sql = `    SELECT ${this.sqlScript_VERSION()} 
                                    (
                                        vsis_batch_service_cd:= ${sis_batch_service_cd}
                                        
                                    )
                    
                    `
                    return sql 
            }    


}

