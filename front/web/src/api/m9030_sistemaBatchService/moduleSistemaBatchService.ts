
import pagApi from "@/api/api"

import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
class moduleSistemaBatchService {
    
    constructor(user: moduleUserConnect) {

    }

    async getSistemaServiceList(filter: any) : Promise<any> {
        let result: any
        
        

        let urlConsulta = `/sistema_batch/report/servicelist`
        try {
            
            result = await pagApi.get(urlConsulta)

        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }
        finally { 
            return result
        }
    }

    async getService(sis_batch_service_cd: number) : Promise<any> {
        let result: any
        
        

        let urlConsulta = `/sistema_batch/model/service?sis_batch_service_cd=${sis_batch_service_cd}`
        try {
            
            result = await pagApi.get(urlConsulta)
            
        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }
        finally { 
            return result
        }
    }

    async getServiceBatch(sis_batch_cd: number) : Promise<any> {
        let result: any
        
        

        let urlConsulta = `/sistema_batch/model/serviceBatch?sis_batch_cd=${sis_batch_cd}`
        try {
            
            result = await pagApi.get(urlConsulta)
            
        } catch (e) {
            console.log(`erro ${e}`)
            throw e
        }
        finally { 
            return result
        }
    }



}


export {moduleSistemaBatchService} 