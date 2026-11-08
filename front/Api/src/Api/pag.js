const axios = require('axios');
const { request } = require('express');
require('dotenv/config')

const TOKEN = process.env.API_PAG_TOKEN;

const createApiPagHeaders = (userLoginUUID) => ({
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'User-Agent': 'Axios - Pag Front API',
    'x-customtoken': process.env.API_PAG_TOKEN || '', // Fallback para string vazia
    'UserLoginUUID': userLoginUUID || ''
})

const Api = axios.create({
    timeout: 48000,
    headers: createApiPagHeaders()
})

const axiosHeaders = { 
        'x-customtoken': TOKEN,
        'Cookie': "",
        'sis_us_seq': 3, 
        'User-Agent': 'Axios - Pag Front API'
    }

async function ApiGet (url , data) {
       const apiAxiosConfig = {
            headers: createApiPagHeaders(""),
            Proxy: true, 
            data: data 
        };


        const api = axios.create({baseURL: process.env.PAG_API_URL }) 
        const response = await api.get(url,apiAxiosConfig)
        return response 
    }

async function ApiPost (url , data) {
        const apiAxiosConfig = {
             headers: createApiPagHeaders(""),
             Proxy: true 
         };
         
         const api = axios.create({baseURL: process.env.PAG_API_URL }) 
         const response = await api.post(url, data, apiAxiosConfig)


         return response 
     }

module.exports = {ApiGet, ApiPost}