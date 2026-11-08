import { Router, Response, Request } from 'express'; 
import bluesoftApi from './api';

import apibluesoft_produto from './produto';


const myApi : bluesoftApi = new bluesoftApi()

const bluesoftapi = Router() 

bluesoftapi.use("/produto", apibluesoft_produto)


bluesoftapi.get("/", async(request: Request, response: Response) => {

    const help = { 
        url : "/produto", 
        info : "Informações sobre produto"
    }

    return response.send(help)
})


export default bluesoftapi