/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/


/*Requires */

const estoquebluesoftapi = require('../../api/estoquebluesoftapi')
const F0030_EstoqueCusto_Processamento = require('./F0030_91_EstoqueCusto_Processamento')

const TbEstoqueCustoBlueSoft = require('./TbEstoqueCustoBlueSoft')
const postgre_pool = require('../../database/postgre')

const Tools = require('../../tools/Tools')

/*Constantes */
const NUMERO_DE_PAGINAS_API_A_PROCESSAR = 536

async function produtobluesoft_migration(process_type = "all", data_ultima_alteracao) {
    try{
        await Tools.pagConsoleLog(`ESTOQUE (Inicio)`)
        await Tools.pagConsoleLog(`ESTOQUE (Dados) Tipo: ${process_type}`)
        await Tools.pagConsoleLog(`ESTOQUE (Dados) Data: ${data_ultima_alteracao}`)
        Numero_de_paginas = NUMERO_DE_PAGINAS_API_A_PROCESSAR

        for (page = 0; page <= Numero_de_paginas; page++){
            dados = await estoquebluesoftapi(page, produtokey = 0, data_ultima_alteracao);
            //console.log(`Página ${page} - Registros: ${Object.entries(dados).length}`)

            if (Object.entries(dados).length > 0){
                //await bll_F024_estoquebluesoft(dados)
                
                await dados.map(async item => {
                    if (item.getOwnPropertyNames !== 'object') {    
                        const estoquebluesoftfromapi = TbEstoqueCustoBlueSoft.bluesoftApiConstructor(item)
                        await postgre_pool(estoquebluesoftfromapi.DBInsert());
                    }
                })


            }
            else {
                break;
            }
 
        }
        await Tools.pagConsoleLog(`ESTOQUE (P0010 - Processamento Geral da Base Estoque)`)
        await F0030_EstoqueCusto_Processamento()
        await Tools.pagConsoleLog(`ESTOQUE (P0010 - Processamento Geral da Base Estoque - FINALIZADO)`)
    }
    catch (e)
    {
        await Tools.pagConsoleLog(`ESTOQUE | Error:  ${e}`)
    }
    finally {
        await Tools.pagConsoleLog(`ESTOQUE (fim)`)
    }
}

module.exports = produtobluesoft_migration