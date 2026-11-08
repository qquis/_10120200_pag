const bluesoft_api_get = require('./bluesoftapi')


async function comercialpedidobluesoftapi (page) {
    const url_page = page || 0 

    var date_pedido = new Date();
    date_pedido.setDate(date_pedido.getDate() -7);
    var year = date_pedido.getFullYear()
    var month = (date_pedido.getMonth() + 101).toString().substring(1);
    var day = (date_pedido.getDate() + 100).toString().substring(1);
    var hours = (date_pedido.getHours() + 100).toString().substring(1);
    var minutes = (date_pedido.getMinutes() + 100).toString().substring(1);
    var sec = (date_pedido.getSeconds() + 100).toString().substring(1);

    var date_pedido_str = `${day}/${month}/${year} 00:01`

    
    //const url_data = dtalteracao || dateFormat('1900-01-01',
    let url = `compras/pedidos-de-compra?pageSize=500&ataAtualizacaoInicial=${date_pedido_str}@currentPage==${page}`
/*
    if (url_produtokey !== 0)
    {
        url = `/comercial/produtos?pageSize=100&currentPage=${page}&produtoKey=${url_produtokey}`
    }
*/
   
    const response = await bluesoft_api_get(url)
    obj =  response.data.data;
    return obj
}
module.exports = comercialpedidobluesoftapi
