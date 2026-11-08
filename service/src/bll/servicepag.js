require ('dotenv/config')
const service_pag_log = require('../tools/servicepag_log')
const datanow = require('../tools/datenow')
const {dateFormat_default} = require('../tools/dateFormat')
const Right = require('../tools/stringLR')
//const addSubtractDate  = require('add-subtract-date')

const Tools = require('../tools/Tools')
const integrationData_ProdutoBluesoft = require('../bll/F0021_ProdutoBlueSoft/index')
const bll_migration_estoque = require('./F0030_EstoqueCusto/migration_estoquebluesoft')
const bll_migration_comercialPedidoBluesoft = require('./F0133_PedidoComercial/migration_comercialpedidobluesoft')

async function servicepag_js () {
    const ched = datanow();
    let data_ultima_alteracao = dateFormat_default() + ' 06:00'

    /*
    if (parseInt(Right(ched,8).substring(0,2)) == '06' ){
        if (Right(ched,5) == '03:00') 
        {
        await Tools.pagConsoleLog(`-`)
        await Tools.pagConsoleLog(`Atualização Diária - Start`)
        await Tools.pagConsoleLog('STEP DIAL INIT')
        await integrationData_ProdutoBluesoft(process_type = "all", data_ultima_alteracao = "")
        await Tools.pagConsoleLog(`Atualização Diária - Fim`)
        }
    }*/

    if (parseInt(Right(ched,8).substring(0,2)) >= '08' ){
        if (Right(ched,4) == '6:00' || Right(ched,4) == '0:00' ) 
        {
            await Tools.pagConsoleLog(`-`)
            await Tools.pagConsoleLog(`Atualização Diária (Dados a partir de ${data_ultima_alteracao})`)
            //await integrationData_ProdutoBluesoft(process_type = "changed", data_ultima_alteracao)
            await bll_migration_estoque(process_type = "changed", data_ultima_alteracao)
            //await bll_migration_comercialPedidoBluesoft(process_type = "all")
            await Tools.pagConsoleLog(`Atualização Diária - Recorrente 5m fim`)
        }
    }

}

module.exports = servicepag_js