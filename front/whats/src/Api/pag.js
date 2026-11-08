const axios = require('axios')
require('dotenv/config')

async function ApiGet (url , data) {
       const apiAxiosConfig = {
            headers: {
                'X-Customtoken': "",
                'Cookie': ""
            }, 
            Proxy: true, 
            data: data 
        };
        const api = axios.create({baseURL: process.env.PAG_API_URL }) 
        const response = await api.get(url,apiAxiosConfig)
        return response 
    }


async function ApiPost (url , data) {
        const apiAxiosConfig = {
             headers: {
                 'X-Customtoken': "",
                 'Cookie': ""
             }, 
             Proxy: true, 
             data: data 
         };
         const api = axios.create({baseURL: process.env.PAG_API_URL }) 
         const response = await api.post(url,apiAxiosConfig)
         return response 
     }

module.exports = {ApiGet, ApiPost}

