/*
    Autor.........: Elias da Silva
    Data..........: 23/12/2020
    Alteração.....: 20/06/2023
    OBS.: 
        Modulo 0021 - produtobluesoft
        Busca dados da API Bluesoft e exporta para a base PostGreOXAN
        20/06/2023 Alteração significativa: reagrupamento de codigos
*/


const Tools = require('../../tools/Tools')

/*Requires */
const BlueSoftApi_Comercial_Produto = require('../bluesoftapi/Comercial/Produto')
const produtobluesoft = require('./modelProdutoBluesoft')
const produtobluesoftGtins = require('./modelProdutoBluesoftGtins')
const produtobluesoft_tributacao = require('./modelProdutoBlueSoftTributacao')
const f0021_90_ProdutoBlueSoft_Processamento = require('./f0021_90_ProdutoBluesoft_Processamento')
const postgre_pool = require('../../database/postgre')


const service_pag_log = require('../../tools/servicepag_log')


/*Constantes */
const NUMERO_DE_PAGINAS_API_A_PROCESSAR = 536

async function integrationData_ProdutoBluesoft(process_type = "all", data_ultima_alteracao) {
    try
    {
        await Tools.pagConsoleLog('Produto BlueSoft _ F0021 | Integração BlueAPI / Base Pag')
        await Tools.pagConsoleLog(`Produto (Inicio)`)
        await Tools.pagConsoleLog(`Produto (Dados) Tipo: ${process_type}`)
        await Tools.pagConsoleLog(`Produto (Dados) Data: ${data_ultima_alteracao}`)
        Numero_de_paginas = NUMERO_DE_PAGINAS_API_A_PROCESSAR
        //if (process_type == "changed")
        //{
        //Numero_de_paginas = 0 
        //}
        for (page = 0; page <= Numero_de_paginas; page++){

            dados = await BlueSoftApi_Comercial_Produto(page, produtokey = 0, data_ultima_alteracao);

            if (Object.entries(dados).length > 0 ){
                
                /*Importa Cadastro de Produtos*/
                //console.log(`PRODUTO [Numero da Página] ${page}`)
                /*TESTE*/
                //console.log(dados);
                await Tools.pagConsoleLog(`PRODUTO [Numero da Página] ${page}`)
                
                /*datasheet | Produto */
                //await bll_F021_produtobluesoft(dados)
                //->>> 
                dados.map(async item => {
                    if (item.getOwnPropertyNames !== 'object'){
                        const _produtodb = produtobluesoft.bluesoftApiConstructor(item)
                        await Tools.pagConsoleLog(`Produto: ${_produtodb.prb_cdprodutobluesoft_pk}`)
                        await postgre_pool(_produtodb.F0021_01_ProdutoBlueSoft_CRUD());
                        }
                    }
                )

                /*datasheet | ProdutoGtins */
                //await bll_F021_produtobluesoft(dados)
                //->>> 
                dados.map(async item => {
                    if (item.getOwnPropertyNames !== 'object'){
                        const list_gtins = item.gtins 
                        list_gtins.map(async x => {
                        const _produtobluesoftgtins = new produtobluesoftGtins(
                                x,
                                item.produtoKey,
                                item.embalagemKey, 
                                'Descricao GTIN API nao informado'
                            )
                        await postgre_pool(_produtobluesoftgtins.F0021_02_ProdutoBlueSoftGtins_CRUD());
                        })
                    }
                }     
                )

                /*datasheet | Produto Tributacao */
                //await bll_F023_produtobluesoft_tributacao(dados)

                dados.map(async item => {
                    if (item.getOwnPropertyNames !== 'object'){
                            
                        let vprb_cdprodutobluesoft = item.produtoKey 
                        let vprbt_pis_saida_cst = '000'
                        let vprbt_pis_saida_aliquota = 0.0
                        let vprbt_cofins_saida_cst = '000'
                        let vprbt_cofins_saida_aliquota = 0.0
                        let vprbt_icms_saida_cst = '000'
                        let vprbt_icms_aliquota_interna = 0.0
                        let vprbt_icms_reducao = 0.0 
                        let vprbt_ncm = item.ncm || '00000000'
                        let vprbt_cest = item.cest || '0000000'
        
                        const tributacao  = item.tributacaoEstadual
                        tributacao.map(x => {
                            const icmsDeSaidaClienteFinal = x.icmsDeSaidaClienteFinal
                            let numero = `${icmsDeSaidaClienteFinal.cst}`
                            vprbt_icms_saida_cst = numero.length == 2? `0${icmsDeSaidaClienteFinal.cst}` : numero.length == 1? `00${icmsDeSaidaClienteFinal.cst}`:icmsDeSaidaClienteFinal.cst
                            vprbt_icms_aliquota_interna = icmsDeSaidaClienteFinal.aliquota 
                            vprbt_icms_reducao = icmsDeSaidaClienteFinal.reducao 
                        
                        })
        
                        pisCofinsSaida = item.pisCofinsSaidaNaoCumulativo
                        vprbt_pis_saida_cst = pisCofinsSaida.cst 
                        vprbt_pis_saida_aliquota = pisCofinsSaida.pisAliquota 
                        vprbt_cofins_saida_cst = pisCofinsSaida.cst 
                        vprbt_cofins_saida_aliquota = pisCofinsSaida.cofinsAliquota
        
                        const produtotributacao = {
                            prb_cdprodutobluesoft : vprb_cdprodutobluesoft,
                            prbt_pis_saida_cst : vprbt_pis_saida_cst,
                            prbt_pis_saida_aliquota : vprbt_pis_saida_aliquota,
                            prbt_cofins_saida_cst : vprbt_cofins_saida_cst,
                            prbt_cofins_saida_aliquota : vprbt_cofins_saida_aliquota,
                            prbt_icms_saida_cst : vprbt_icms_saida_cst,
                            prbt_icms_aliquota_interna : vprbt_icms_aliquota_interna,
                            prbt_icms_reducao  : vprbt_icms_reducao,
                            prbt_ncm : vprbt_ncm,
                            prbt_cest : vprbt_cest
                        }
        
                        const _produtoBlueSoftTributacao = produtobluesoft_tributacao.bluesoftApiConstructor(produtotributacao)
                        //console.log(iprodutobluesoft_tributacao.F0023_DBINSERT_API()) 
                        await postgre_pool(_produtoBlueSoftTributacao.F0023_01_ProdutoBluesoft_Tributacao());
    
                        }
                    }
                )
            }
            else {
                break
            }

        }
        
        await Tools.pagConsoleLog(`Produto (F0021_90 - Processamento de Produtos)`)
        await f0021_90_ProdutoBlueSoft_Processamento()
        await Tools.pagConsoleLog(`Produto (F0021_90 - Processamento de Produtos - FINALIZADO)`)

    }
    catch (e)
    {
        await Tools.pagConsoleLog(`PRODUTO | Error:  ${e}`)
    }

    finally {
        await Tools.pagConsoleLog(`PRODUTO (fim)`)

    }

}

module.exports = integrationData_ProdutoBluesoft