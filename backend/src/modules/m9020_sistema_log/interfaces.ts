import { Request } from "express"

interface isistemaLog {
    sis_log_seq?: number
    proc_log_seq?: number
    sis_nucleo_prc_cd?: number
    sis_log_tag?: string 
    sis_log_info?: string
    sis_batch_run_seq?: number


}

class isistemaLog_Constructor {
    static byfromRequest (request: Request) : isistemaLog {

        let _isistema_log : isistemaLog; 

        let sis_log_seq: number = 0
        let proc_log_seq: number = 0	
        let sis_nucleo_prc_cd: number = 0 		
        let sis_log_tag: string = `` 
        let sis_log_info: string =  `` 
        let sis_batch_run_seq: number = 0

        if (request.query.sis_log_seq) 
            sis_log_seq = parseInt(`${request.query.sis_log_seq}`)

        if (request.query.proc_log_seq) 
            sis_log_seq = parseInt(`${request.query.proc_log_seq}`)                    

        if (request.query.sis_nucleo_prc_cd) 
            sis_nucleo_prc_cd = parseInt(`${request.query.sis_nucleo_prc_cd}`)  
            
        if (request.query.sis_log_tag) 
            sis_log_tag = request.query.sis_log_tag.toString().replace("'", "")
        
        if (request.query.sis_log_info)
            sis_log_info = request.query.sis_log_info.toString().replace("'", "")

        if (request.query.sis_batch_run_seq)
            sis_batch_run_seq =  parseInt(`${request.query.sis_batch_run_seq}`)  

        _isistema_log = {
                sis_log_seq : sis_log_seq,
                proc_log_seq : proc_log_seq, 
                sis_nucleo_prc_cd: sis_nucleo_prc_cd, 
                sis_log_tag : sis_log_tag,
                sis_log_info : sis_log_info,
                sis_batch_run_seq : sis_batch_run_seq
        }

        return _isistema_log 
    }
}

export { isistemaLog, isistemaLog_Constructor }