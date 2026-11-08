
import axios from 'axios'
import { clsTools } from "../modelbase";



const sorteioExternoApiurl = axios.create(({
    timeout : 14000,
    baseURL : process.env.SORTEIOEXTERNO_API_URL,

}))

const config = {
   headers: { 
         'User-Agent': 'OXAN',
          }
       };

async function sorteioExternoApi_post (url: string, data : object) {
    try {
        const response = await sorteioExternoApiurl.post(url, data, config)
        return response;
  
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

        throw new Error(`modules | VIP API | Error ${e.message}`);

    }

}

export default {sorteioExternoApi_post};


