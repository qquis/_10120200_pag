const axios = require('axios')
require('dotenv/config')


const apiAxiosConfig = {
    headers: {
        'X-Customtoken': process.env.BLUEOSFT_API_TOKEN,
        'Cookie': process.env.BLUESOFT_API_COOKIE,
        'X-Api-Custom-Token': process.env.API_CUSTOM_TOKEN
    }
};

const api = axios.create({
    baseURL:"https://erp.bluesoft.com.br/oxan/api"})

async function api_get (url) {
    const response = await api.get(url,apiAxiosConfig)
    return response 

}

module.exports = api_get


