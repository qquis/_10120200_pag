import axios, { AxiosResponse } from 'axios'

// Mudança principal: agora aponta para o proxy interno
const BASE_URL = '/api/proxy'
import moduleUserConnect from "../api/m0001_sistema/moduleUserConnect"
import { headers } from 'next/headers'



const ApiPagHeaders = {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    // Removido x-customtoken e UserLoginUUID - serão tratados no servidor
}

const Api = axios.create({
    timeout: 0, /*  ALTERAÇÃO EM 2024-06-18: 
                    Sem timeout 
                    BRANCH 20.19
                
                */
    baseURL: BASE_URL,
    headers: ApiPagHeaders
})

export default class pagApi { 
    private static extractData<T>(responseData: any): T {
        if (
            responseData !== null &&
            typeof responseData === 'object' &&
            'status' in responseData &&
            'message' in responseData &&
            'data' in responseData
        ) {
            return responseData.data as T;
        }

        return responseData as T;
    }


    
    static async get<T>(url: string): Promise<T> { 
        try { 
           const result = await Api.get(url)
            return this.extractData<T>(result.data)
        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    static async post(url: string, object: object = {}): Promise<object> { 
        try { 

            const result = await Api.post(url, object)
            return result 
        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }

    static async pagApiget<T>(usuario_login_uuid: string, url: string): Promise<T> { 
        try { 
            const result = await Api.get<T>(url, {
                headers: {
                    'usuario-login-uuid': usuario_login_uuid,

                }
            })
            return result.data
        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    static async pagApipost(usuario_login_uuid: string, url: string, object: object = {}): Promise<AxiosResponse> { 
        try { 
            const result = await Api.post(url, object, {
                headers: {
                    'usuario-login-uuid': usuario_login_uuid
                }
            })
            return result 
        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }


    static async pApiget<T>(UserConnect: moduleUserConnect, url: string, sis_ac_cd: number): Promise<T> { 
        try { 
            /*
            const result = await Api.get<T>(url, {
                headers: {
                    'usuario_login_uuid': UserConnect.usuario_login_uuid,
                    "user_name": UserConnect.user_name,
                    "user_credential": UserConnect.user_credential,
                    "sis_ac_cd": sis_ac_cd


                }
                                
            })*/

            let head = this.getHeader(UserConnect, url, {}, sis_ac_cd)

            
            const result = await Api.get<T>(url, {
                headers: head
            })

            return this.extractData<T>(result.data)
            //return result.data
        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    static async pApipost(UserConnect: moduleUserConnect, url: string, object: object = {}, sis_ac_cd: number): Promise<AxiosResponse> { 
        try { 
            
            
            
            /*const result = await Api.post(url, object, {
                headers: {
                    'usuario_login_uuid': UserConnect.usuario_login_uuid,
                    "user_name": UserConnect.user_name,
                    "user_credential": UserConnect.user_credential,
                    "sis_ac_cd": sis_ac_cd
                }
            })*/

            let head = this.getHeader(UserConnect, url, object, sis_ac_cd)
            const result = await Api.post(url, object, {
                headers: head
            })

            return result 
        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }

    static  getHeader(UserConnect: moduleUserConnect, url: string, object: object = {}, sis_ac_cd: number) : object { 

        return { 
                'usuario-login-uuid': UserConnect.usuario_login_uuid,
                'user-name': UserConnect.user_name,
                'user-credential': UserConnect.user_credential,
                'sis-ac-cd': sis_ac_cd
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