import { Router, Response, Request } from 'express'; 



const apibluesoft_preco = Router()


apibluesoft_preco.get("/", async(request: Request, response: Response) => {

    const help = [
    { 
        url : "/", 
        info : "Não há possibilidade de executar esta api por ser apenas api post"
    },


]

    return response.send(help)
})

export default apibluesoft_preco