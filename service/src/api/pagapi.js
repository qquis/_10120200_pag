/* SERVIÇO ANTIGO | CONFIGURAÇÃO API PAG */


const axios = require('axios')
require('dotenv/config')


const apiAxiosConfig = {
    headers: {
        'x-customtoken': process.env.PAG_API_TOKEN,
        'Cookie': ""
    }, 
    Proxy: true
};

/*st api = axios.create({
    baseURL:"http//localhost:3333"})
*/

    const api = axios.create()    

async function pag_api (url) {
    const response = await api.get("http://192.168.1.20:3333/faturamentoprocessar",apiAxiosConfig)
    return response 

}

module.exports = pag_api


