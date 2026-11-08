import axios, { Axios, AxiosResponse } from 'axios'

// Agora aponta para o proxy interno em vez da API externa
const BASE_URL = '/api/proxy'

const ApiPagHeaders = {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'UserLoginUUID': ''
        }
    

const Api = axios.create(({
    timeout : 48000,
    baseURL : BASE_URL,
    headers: ApiPagHeaders
}))


export default class pagApi { 
    static async get<T>(url : string) : Promise<T> { 
        try { 
            const result = await Api.get<T>(url)
            return result.data

        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }
    
    static async post(url : string , object : object = {}) : Promise<object> { 
        try { 
            const result = await Api.post(url, object)
            return result 

        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }
    
    static async pagApiget<T>(usuario_login_uuid: string, url : string) : Promise<T> { 
        try { 
            const result = await Api.get<T>(url, {
                        headers: {
                            'usuario_login_uuid': `${usuario_login_uuid}` // Header dinâmico
                        }
                        })
            
            return result.data

        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }
    
    static async pagApipost(usuario_login_uuid: string, url : string , object : object = {}) : Promise<AxiosResponse> { 
        try { 
            ApiPagHeaders.UserLoginUUID = usuario_login_uuid
            const result = await Api.post(url, object, {
                        headers: {
                            'usuario_login_uuid': `${usuario_login_uuid}` // Header dinâmico
                        }
                        })
            return result 

        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }
}    


/*
async function ApiGet<T>(url: string, data : object) {
    try {
    const apiAxiosConfig = {
        withCredentials: false,
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        }, 
        params: data,
        
    };

    const api = axios.create({baseURL: "http://localhost:57895" }) 
    const response = await api.get<T>(url, apiAxiosConfig)
    return response 

    } catch (e) {
        throw new Error(`Erro ao buscar dados: ${e}`)
        console.log(`ERROR AXIOS ${e}`)
    }

}



    

export { ApiGet }; */