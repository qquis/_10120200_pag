/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/


/*Requires */
const pag_api = require('../../api/pag_api')
const service_pag_log = require('../../tools/servicepag_log')
const {dateFormat_default} = require('../../tools/dateFormat')
/*Constantes */


async function F0150_Estatistica_Processamento() {
    try{
        await service_pag_log(`F0150_Estatistica_Processamento - INIT`)
        await pag_api(`/estatistica_processamento`)
        await service_pag_log(`F0150_Estatistica_Processamento - END`)        

    }
    catch (e)
    {
        await service_pag_log(`Error | F0150_Estatistica_Processamento:  ${e}`)
        throw e; 
    }
    finally {
        await service_pag_log(`F0150_Estatistica_Processamento`)
    }
}

module.exports = F0150_Estatistica_Processamento