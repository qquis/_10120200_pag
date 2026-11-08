/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
*/


/*Requires */
const postgre_pool = require('../../database/postgre')
const F0133_01_API = require('../../api/comercialpedidobluesoftapi')
const TbComercial_PedidoBluesoft = require('../../models/TbComercial_PedidoBluesoft')
const service_pag_log = require('../../tools/servicepag_log')

/*Constantes */
const NUMERO_DE_PAGINAS_API_A_PROCESSAR = 10

/*functions */
async function F0133_01_comercial_pedidobluesoft(obj)
{
    try {
         
        
               obj.map(async item => {
                    if (item.getOwnPropertyNames !== 'object'){
                        const comercial_ped_compra_FromApiBlueSoft = TbComercial_PedidoBluesoft.bluesoftApiConstructor(item)
                        //await service_pag_log(`Processamento do Pedido: ${comercial_ped_compra_FromApiBlueSoft.cm_pedblue_numeropedido}`)
                        await postgre_pool(comercial_ped_compra_FromApiBlueSoft.F0133_01_DBINSERT_API());
                        }
                    }
                )
            }
    catch (e) {
        new Error(`F0133_01_comercial_pedidobluesoft | Error: ${e}`)
    }
}
module.exports = F0133_01_comercial_pedidobluesoft;
