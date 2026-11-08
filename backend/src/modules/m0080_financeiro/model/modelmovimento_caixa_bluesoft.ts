import { clsBase, clsTools } from '../../../model/modelbase'
import {Request, Response, Router} from 'express'
import tbmovimento_caixa_bluesoft from '../tbs/tbmovimento_caixa_bluesoft';


import f0080_02_movimento_caixa_bluesoft_integ from '../scriptpg/f0080_02_movimento_caixa_bluesoft_integ'

const myClsBase = new clsBase();



const modelmovimentocaixabluesoftRouter = Router()




modelmovimentocaixabluesoftRouter.get("/", async (req: Request, res: Response) => {
    let item : modelmovimento_caixa_bluesoft =  new modelmovimento_caixa_bluesoft()
    try {
    
        if (req.query)
        {
            if (req.query.aut_pgto_pag_seq) 
            {
                await item.select({aut_pgto_pag_seq : req.query.aut_pgto_pag_seq})
            }
        } else { 
            await item.new()
        }
        
    } catch (e) { 
        clsTools.PagErrorException("M0080", "modelautorizacaoPagamentoPagRouter", e)
    } finally {
        return res.send(item)
    }

})

modelmovimentocaixabluesoftRouter.post("/", async (req: Request, res: Response) => { 
    const modelmovimento_caixa_bluesoftPost = new modelmovimento_caixa_bluesoft()
    await modelmovimento_caixa_bluesoftPost.update(req.body)
    return res.send(modelmovimento_caixa_bluesoftPost)


})


class modelmovimento_caixa_bluesoft extends tbmovimento_caixa_bluesoft
{

    constructor() { 
        super()
        this.new();
    }

    async new ()
    {

    

    }

    async update(DataBory: any) { 
        let sql = `` 
        try {
        } catch (e) { 
            clsTools.PagErrorException("M0080-Financeiro", "FinanceiroPag/Insert", e)
        }
    }

    async select(filtros: any) { 
        let sql = ``
                let result = await myClsBase.myDataBase.pag.DataGet(sql)

            let dataItem : any = await myClsBase.myDataBase.RecordItem(result,0) 
            if (dataItem)
            {
                this.binding( dataItem)
            }   

    }

    integSql_get() : string { 
            return f0080_02_movimento_caixa_bluesoft_integ.get(this);
    }
}

export { modelmovimentocaixabluesoftRouter, modelmovimento_caixa_bluesoft}