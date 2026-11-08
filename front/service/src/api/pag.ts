import axios, { AxiosResponse } from 'axios'

const BASE_URL = process.env.PAG_API_URL

// Função para criar headers dinâmicos, evitando o problema do undefined
const createApiPagHeaders = (userLoginUUID?: string) => ({
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN || '', // Fallback para string vazia
    'UserLoginUUID': userLoginUUID || ''
})

const Api = axios.create({
    timeout: 0,
    baseURL: BASE_URL,
    headers: createApiPagHeaders()
})

export default class pagApi { 
    static async get<T>(url: string): Promise<T> { 
        try { 
            // Verificar se o token existe
            if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
            }
            
            const result = await Api.get<T>(url, { timeout: 0 })
            return result.data

        } catch (e) { 
            console.error('Erro na requisição GET:', e);
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    static async post(url: string, object: object = {}): Promise<AxiosResponse> { 
        try { 
            // Verificar se o token existe
            if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
            }

            const result = await Api.post(url, object, { timeout: 0 })
            return result 

        } catch (e) { 
            console.error('Erro na requisição POST:', e);
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }

    static async pagApiget<T>(usuario_login_uuid: string, url: string): Promise<T> { 
        try { 
            // Verificar se o token existe
            if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
            }

            const result = await Api.get<T>(url, {
                headers: {
                    'usuario_login_uuid': usuario_login_uuid,
                    'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN
                }
            })
            
            return result.data

        } catch (e) { 
            console.error('Erro na requisição pagApiget:', e);
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    static async pagApipost(usuario_login_uuid: string, url: string, object: object = {}): Promise<AxiosResponse> { 
        try { 
            // Verificar se o token existe
            if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
            }

            const result = await Api.post(url, object, {
                headers: {
                    'usuario_login_uuid': usuario_login_uuid,
                    'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN

                }
            })
            return result 

        } catch (e) { 
            console.error('Erro na requisição pagApipost:', e);
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }
}