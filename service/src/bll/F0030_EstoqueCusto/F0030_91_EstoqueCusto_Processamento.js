/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/

const Tools = require('../../tools/Tools')
const postgre_pool = require('../../database/postgre')

async function F0030_91_EstoqueCusto_Processamento()
{
    //if (item.getOwnPropertyNames !== 'object'){
    try {
            await Tools.pagConsoleLog('API', 'Estoque/Custo Médio (Atualização Alterados) - Inicializado');
            await postgre_pool(`SELECT f0030_91_1011213_estoquecustos_processamento()`);
            await Tools.pagConsoleLog('API', 'Estoque/Custo Médio (Atualização Alterados) - Finalizado');
    }
    catch (e)
    {
        new Error(`P0010_EstoqueCustos_Processamento | Erro: ${e}`)
    }

}

module.exports = F0030_91_EstoqueCusto_Processamento;


