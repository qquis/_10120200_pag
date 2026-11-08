
import axios from 'axios'
import { clsBase, clsTools } from '../../../../model/modelbase';


const ENV_BLUESOFT_API_TIMEOUT = process.env.BLUESOFT_API_TIMEOUT? parseInt(process.env.BLUESOFT_API_TIMEOUT) : 16000

const bluesoftApiurl = axios.create(({
    timeout : ENV_BLUESOFT_API_TIMEOUT,
    baseURL : process.env.BLUEOSFT_API_URL,
    headers: { 
        'X-Customtoken': `${process.env.BLUEOSFT_API_TOKEN}`,
        'Cookie':  `${process.env.BLUESOFT_API_COOKIE}`
          }
}))

const config = {
   headers: { 
        'X-Customtoken': `${process.env.BLUEOSFT_API_TOKEN}`,
        'Cookie':  `${process.env.BLUESOFT_API_COOKIE}`,
        'timeout': ENV_BLUESOFT_API_TIMEOUT
          }
       };

async function api_get (url: string, ErrorPagConsole: boolean = true) {
    try {
        const response = await bluesoftApiurl.get(url,config)
        return response 
    }
    catch (e) {
        if (ErrorPagConsole) {
            clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_get | Error \n ${e}`, false, false, 'bluesoftApiurl')
        }
        throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_get | URL [${url}] Error ${e}`);
    }

}

async function api_post (url: string, obj: object, ErrorPagConsole: boolean = true) {
    try {
        const response = await bluesoftApiurl.post(url, obj, config)
        return response;    }
    catch (e) {
        if (ErrorPagConsole) {
            clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_post | Error \n ${e}`, false, false, 'bluesoftApiurl')
        }
        throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_post | URL [${url}] Error ${e}`);
    }

}


async function api_put (url: string, obj: object, ErrorPagConsole: boolean = true) {
    try {
        const response = await bluesoftApiurl.put(url, obj, config)
        return response;    }
    catch (e) {
        if (ErrorPagConsole) {
            clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_put | Error \n ${e}`, false, false, 'bluesoftApiurl')
        }
        throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_put | URL [${url}] Error ${e}`);
    }

}
export default {api_get, api_post, api_put};
