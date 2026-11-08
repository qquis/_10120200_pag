const bluesoft_api_get = require('./bluesoftapi')


async function estoquebluesoftapi (page, produtokey = 0, data_ultima_alteracao = '') {
    
    const url_produtokey = produtokey || 0
    const url_page = page || 0 
    //const url_data = dtalteracao || dateFormat('1900-01-01',
    let url = `/comercial/estoques?pageSize=100&currentPage=${page}`
    


    if (url_produtokey !== 0)
    {
        url = `/comercial/estoques?pageSize=100&currentPage=${page}&produtoKey=${url_produtokey}`
    }


    if (data_ultima_alteracao !== '')
    {
        url = `/comercial/estoques?pageSize=200&currentPage=${page}&dataAlteracaoInicio=${data_ultima_alteracao}`
    }
    //console.log(`URL Estoque Bluesoft: ${url}`)
    ///console.log(`estoquebluesoftapi.js ${url}`)
    const response = await bluesoft_api_get(url)
    obj =  response.data.data;
    
    return obj
}
module.exports = estoquebluesoftapi
