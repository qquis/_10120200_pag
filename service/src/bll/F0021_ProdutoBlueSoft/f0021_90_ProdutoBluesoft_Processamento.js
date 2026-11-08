/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo P0005 - Processamento de Produtos
        Analisa as bases tb[bluesoft]... e expora para as tbs tb[pag] (BASE Postgre)
*/


/*Requires */
const Tools = require('../../tools/Tools')
const postgre_pool = require('../../database/postgre')

/*Constantes */

/*functions */
async function f0021_90_ProdutoBlueSoft_Processamento()
{
    
    //VERSAO = 'f0021_90_1011950_produtobluesoft_processamento'


    VERSAO = 'f0021_90_1012006_produtobluesoft_processamento'


    try {
            await Tools.pagConsoleLog('API','Produto (Atualização Alterados) - Inicializado')
            await postgre_pool(`SELECT ${VERSAO} ()`);
            await Tools.pagConsoleLog('API','Produto (Atualização Alterados) - Finalizado')
    }
    catch (e)
    {
        new Error(`f0021_90_ProdutoBlueSoft_Processamento | Erro: ${e}`)
    }

}

module.exports = f0021_90_ProdutoBlueSoft_Processamento;


