/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/


/*Requires */

const comercialpedidobluesoftapi = require('../../api/comercialpedidobluesoftapi')

const TbComercial_PedidoBluesoft = require('./TbComercial_PedidoBluesoft')
const Tools = require('../../tools/Tools')
const postgre_pool = require('../../database/postgre')

/*Constantes */
const NUMERO_DE_PAGINAS_API_A_PROCESSAR = 1

async function comercialpedidobluesoft_migration(process_type = "all") {
    try{
        await Tools.pagConsoleLog(`Comercial Pedido Bluesoft (Inicio)`)
        Numero_de_paginas = NUMERO_DE_PAGINAS_API_A_PROCESSAR
        for (page = 0; page <= Numero_de_paginas; page++){
            dados = await comercialpedidobluesoftapi(page);

            if (Object.entries(dados).length > 0){
                //await F0133_01_comercial_pedidobluesoft(dados)

                await dados.map(async item => {
                    if (item.getOwnPropertyNames !== 'object'){
                        const comercial_ped_compra_FromApiBlueSoft = TbComercial_PedidoBluesoft.bluesoftApiConstructor(item)
                        await postgre_pool(comercial_ped_compra_FromApiBlueSoft.F0133_01_DBINSERT_API());
                        }
                    }
                )


            }
            else {
                break;
            }
 
        }

    }
    catch (e)
    {
        await Tools.pagConsoleLog(`Comercial Pedido Bluesoft | Error:  ${e}`)
    }
    finally {
        await Tools.pagConsoleLog(`Comercial Pedido Bluesoft (fim)`)
    }
}

module.exports = comercialpedidobluesoft_migration