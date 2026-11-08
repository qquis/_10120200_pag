
import axios from 'axios'

import { clsTools } from "../../model/modelbase";

const ENV_VIP_API_TIMEOUT = process.env.VIP_API_TIMEOUT? parseInt(process.env.VIP_API_TIMEOUT) : 14000

const vipApiurl = axios.create(({
    timeout : ENV_VIP_API_TIMEOUT,
    baseURL : process.env.VIP_API_URL,

}))

const config = {
   headers: { 
        'Accept': `${process.env.VIP_API_ACCEPT}`,
        'DomainKey':  `${process.env.VIP_API_DOMAINKEY}`,
        'Authorization':  `${process.env.VIP_API_AUTHORIZATION}`,
        'timeout': ENV_VIP_API_TIMEOUT
          }
       };

async function vip_api_get (url: string) {
    try {
        const response = await vipApiurl.get(url,config)
        return response.data;
    }
    catch (e: any) {
        
        clsTools.pagConsole(`modules | VIP API | Error \n ${e.message}`);

        // Log mais detalhado do erro
        clsTools.pagConsole('=== VIP API ERROR DETAILS ===');
        clsTools.pagConsole('Error message:', e.message);
        clsTools.pagConsole('Error code:', e.code);
        clsTools.pagConsole('Error config:', e.config);
        
        if (e.response) {
            clsTools.pagConsole('Response status:', e.response.status);
            clsTools.pagConsole('Response data:', e.response.data);
            clsTools.pagConsole('Response headers:', e.response.headers);
        } else if (e.request) {
            clsTools.pagConsole('Request made but no response:', e.request);
        }

        throw new Error(`modules | VIP API | Error ${e.message} - url ${url}`);

    }

}

async function vip_api_post (url: string, obj: object) {
    try {
        const response = await vipApiurl.post(url, obj, config)
        return response;    }
    catch (e: any) {
        clsTools.pagConsole(`modules | VIP API  | Error \n ${e}`)

           // Log mais detalhado do erro
        clsTools.pagConsole('=== VIP API ERROR DETAILS ===');
        clsTools.pagConsole('Error message:', e.message);
        clsTools.pagConsole('Error code:', e.code);
        clsTools.pagConsole('Error config:', e.config);
        
        if (e.response) {
            clsTools.pagConsole('Response status:', e.response.status);
            clsTools.pagConsole('Response data:', e.response.data);
            clsTools.pagConsole('Response headers:', e.response.headers);
        } else if (e.request) {
            clsTools.pagConsole('Request made but no response:', e.request);
        }

        throw new Error(`modules | VIP API | Error ${e}`);
    }

}
export default {vip_api_get, vip_api_post};


