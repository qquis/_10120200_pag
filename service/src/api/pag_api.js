const axios = require('axios')
require('dotenv/config')


const apiAxiosConfig = {
    headers: {
        'X-Customtoken': "",
        'Cookie': ""
    }, 
    Proxy: true
};

const api = axios.create({
    baseURL: process.env.PAG_API_URL }) // Url está no .env "http://192.168.1.20:57895"


//    const api = axios.create()    

async function pag_api (url, data = {}) {
    const response = await api.get(url,data, apiAxiosConfig)
    return response 

}

module.exports = pag_api


