/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/


/*Requires */
const postgre_pool = require('../../database/postgre')
const F0024_API = require('../../api/estoquebluesoftapi')
const TbEstoqueCustoBlueSoft = require('../../models/TbEstoqueCustoBlueSoft')

/*Constantes */
const NUMERO_DE_PAGINAS_API_A_PROCESSAR = 536

/*functions */
async function F0024_estoquebluesoft(obj)
{
    //if (item.getOwnPropertyNames !== 'object'){
    try {
            obj.map(async item => {
                if (item.getOwnPropertyNames !== 'object') {    
                    const estoquebluesoftfromapi = TbEstoqueCustoBlueSoft.bluesoftApiConstructor(item)
                    //console.log(estoquebluesoftfromapi.F0024_DBINSERT_API())
                    await postgre_pool(estoquebluesoftfromapi.DBInsert());
                }
            }
        )
    }
    catch (e)
    {
        console.log(e)
        new Error(`F0024_EstoqueCustoBlueSoft | Erro: ${e}`)
    }

}

module.exports = F0024_estoquebluesoft;
