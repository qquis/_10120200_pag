import Tools from '../tools/Tools'
//import {ApiGet, ApiPost} from '../api/pag'
import pagApi from '../api/pag'

export default class ServicePatch {


    public async serviceRun (sis_batch_service_cd: number, sis_batch_service_run_status_shedule: number ) : Promise<object>  {
        try {
            
            //console.log(`FRONT/API/INDEX/m9030cmdservicerun`)
            //console.log(`sis_batch_service_cd =${sis_batch_service_cd}`)
            //console.log(`sis_batch_service_run_status_shedule =${sis_batch_service_run_status_shedule}`)

            return await pagApi.post(`/sistema_batch/service/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {}) 
            //return await ApiPost(`/sistema_batch/service/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {}) 
        } catch (e: any) {
            console.log("erro na chamda da api", e.data)
            throw new Error(`ServicePath ${e}`)
        }
    }

    public async serviceProcess (sis_batch_service_cd: number, sis_batch_service_run_status_shedule: number ) : Promise<object>   { 
        try {

            return await pagApi.post(`/sistema_batch/service/serviceprocessar?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {}) 
            //return await ApiPost(`/sistema_batch/service/serviceprocessar?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`, {})
        } catch (e: any) {
            console.log("erro na chamda da api", e.data)
            throw new Error(`ServicePath ${e}`)
        }
    }

    /* ---- M9030 - BATCHS | /CMD/ServiceRUN ---- */

    status() {
        console.log("ativo")
    }

   
}
