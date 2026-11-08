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
/*Constantes */


async function F0045_PrecoBlueSoft_Update() {
    try{
        await service_pag_log(`F0045 Preco BlueSoft Update - INIT`)
        await pag_api(`/preco_bluesoft_update?processamentogeral=0&data=13/01/2023`)
        await service_pag_log(`F0045 Preco BlueSoft Update - END`)        

    }
    catch (e)
    {
        await service_pag_log(`Error | F0045 Preco BlueSoft Update:  ${e}`)
        throw e; 
    }
    finally {
        await service_pag_log(`F0045 Preco BlueSoft Update - OK`)
    }
}

module.exports = F0045_PrecoBlueSoft_Update