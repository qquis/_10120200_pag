const {ApiGet, ApiPost} = require('./src/Api/pag')

class PagApi {
    
    
    /* ---- M9030 - BATCHS | /CMD/ServiceRUN ---- */
    async m9030cmdservicerun (sis_batch_service_cd, sis_batch_service_run_status_shedule ) {
        try {
            
            //console.log(`FRONT/API/INDEX/m9030cmdservicerun`)
            //console.log(`sis_batch_service_cd =${sis_batch_service_cd}`)
            //console.log(`sis_batch_service_run_status_shedule =${sis_batch_service_run_status_shedule}`)


            return await ApiPost(`/sistema_batch/cmd/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`) 
        } catch (e) {
            throw Error(e)
        }
    }

    async m9030cmdserviceprocessar (sis_batch_service_cd, sis_batch_service_run_status_shedule ) { 
        try {

            return await ApiPost(`/sistema_batch/cmd/serviceprocessar?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_run_status_shedule=${sis_batch_service_run_status_shedule}`) 
        } catch (e) {
            throw Error(e)
        }
    }

    /* ---- M9030 - BATCHS | /CMD/ServiceRUN ---- */

    status() {
        console.log("ativo")
    }
}



module.exports = PagApi

