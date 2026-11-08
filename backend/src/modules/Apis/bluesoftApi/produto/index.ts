import { Router, Response, Request } from 'express'; 
import blueSoftApiProduto from './blueSoftApiProduto';


const apibluesoft_produto = Router()

const myApiProduto = new blueSoftApiProduto();

apibluesoft_produto.get("/all", async(request: Request, response: Response) => {
    return response.send(await myApiProduto.listall())
})

apibluesoft_produto.get("/ultimaalteracao", async(request: Request, response: Response) => {
    return response.send(await myApiProduto.listUltAlteracaoD1())
})


apibluesoft_produto.get("/", async(request: Request, response: Response) => {

    const help = [
    { 
        url : "/all", 
        info : "listagem geral de produtos (Numero de Paginas 100/650"
    },

    { 
        url : "/ultimaalteracao", 
        info : "listagem geral de produtos considerando a data da ultima alteracao"
    }

]

    return response.send(help)
})

export default apibluesoft_produto