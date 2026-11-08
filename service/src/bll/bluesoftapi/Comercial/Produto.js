const bluesoft_api_get = require('../../../api/bluesoftapi')


async function BlueSoftApiProduto_Get (page, produtokey = 0, data_ultima_alteracao = '') {
    
    const url_produtokey = produtokey || 0
    const url_page = page || 0 
    //const url_data = dtalteracao || dateFormat('1900-01-01',
    let url = `/comercial/produtos?pageSize=100&currentPage=${page}`
    


    if (url_produtokey !== 0)
    {
        url = `/comercial/produtos?pageSize=100&currentPage=${page}&produtoKey=${url_produtokey}`
    }


    if (data_ultima_alteracao !== '')
    {
        url = `/comercial/produtos?pageSize=200&currentPage=${page}&ultimaAlteracao=${data_ultima_alteracao}`
    }
    
    const response = await bluesoft_api_get(url)
    obj =  response.data.data;
    
    /*
    TESTE
    */
    //console.log(obj);
    /*
    TESTE
    */

    return obj
}
module.exports = BlueSoftApiProduto_Get
