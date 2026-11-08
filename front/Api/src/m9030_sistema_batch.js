const Tools = require ("../../../tools/index")
const {ApiGet, ApiPost} = require("./Api/pag") 

class m9030_sistema_batch {
    
    url_obterBatchsRunsPendentes () {
        return '/sistema_batch/reports/pendentes'
    }
    url_ExecutarRun (sis_batch_run_seq) {
        return `/sistema_batch/cmd/executarrun?sis_batch_run_seq=${sis_batch_run_seq}`
    }
    url_FinalizarRun (sis_batch_run_seq) {
        return `/sistema_batch/cmd/finalizarrun?sis_batch_run_seq=${sis_batch_run_seq}`
    }
    url_FinalizarRunErro (sis_batch_run_seq) {
        return `/sistema_batch/cmd/finalizarrunerror?sis_batch_run_seq=${sis_batch_run_seq}`
    }

    url_servicerun (sis_batch_service_cd,sis_batch_service_run_status_shedule ) {
        return `/sistema_batch/cmd/servicerun?sis_batch_service_cd=${sis_batch_service_cd}&sis_batch_service_cd=${sis_batch_service_run_status_shedule}`
    }
    

    constructor() {
      
    }

    /*
    async obterListagemDeNotificacoes() {
        const dados = await ApiGet(this.url_notificacao_list_get(), this.filterList)
        const list = dados.data
        return list
    }*/

    async ObterRunListPendente () {

        const dados = await ApiGet(`${this.url_obterBatchsRunsPendentes()}`, null)
        const list = dados.data
        return list


        /*
        try {
        const dados = await ApiGet(`${this.url_obterBatchsRunsPendentes()}`)
        const list = dados.data
        return list
        } catch (e) {
            throw Error(e)
        }*/
    }

    async executarRun (item) {
        try {

            console.log(`${this.url_ExecutarRun(item.sistema_batch_run.sis_batch_run_seq)}`)

            const dados = await ApiPost(`${this.url_ExecutarRun(item.sistema_batch_run.sis_batch_run_seq)}`, null )
            const list = dados.data
            return list
        } catch (e) {
            throw Error(e)
        }
    }

    async FinalizarRun (item) {
        try {
            const dados = await ApiPost(`${this.url_FinalizarRun(item.sistema_batch_run.sis_batch_run_seq)}`, null )
            const list = dados.data
            return list
        } catch (e) {
            throw Error(e)
        }
    }

    async FinalizarRunError (item) {
        try {
            const dados = await ApiPost(`${this.url_FinalizarRunErro(item.sistema_batch_run.sis_batch_run_seq)}`, null )
            const list = dados.data
            return list
        } catch (e) {
            throw Error(e)
        }
    
    }

    async ServiceRun (runShedule) {
        try {

            let stringApi = `${this.url_servicerun()}?sis_batch_service_cd=1&sis_batch_service_run_status_shedule=${runShedule}`
            await ApiPost(stringApi)
        } catch (e) {
            throw Error(e)
        }
    
    }


    
}

module.exports = m9030_sistema_batch;
