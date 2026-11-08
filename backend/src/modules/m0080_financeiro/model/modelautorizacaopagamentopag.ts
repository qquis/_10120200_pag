import { clsBase, clsTools } from '../../../model/modelbase'
import {Request, Response, Router} from 'express'
import tbautorizacaopagamentopag from "../tbs/tbautorizacaopagamentopag"
import { DateTime } from 'msnodesqlv8';

const myClsBase = new clsBase();

const modelautorizacaoPagamentoPagRouter = Router()

modelautorizacaoPagamentoPagRouter.get("/", async (req: Request, res: Response) => {
    let item : modelautorizacaopagamentopag =  new modelautorizacaopagamentopag()
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

modelautorizacaoPagamentoPagRouter.post("/", async (req: Request, res: Response) => { 
    const modelautorizacaopagamentopagPost = new modelautorizacaopagamentopag()
    await modelautorizacaopagamentopagPost.update(req.body)
    return res.send(modelautorizacaopagamentopagPost)


})


class modelautorizacaopagamentopag extends tbautorizacaopagamentopag
{
    descritivo : string 
    nome_razao : string 
    r_conta_descricao : string 
    user_name : string
    user_name_cancelador : string
    competencia_descricao : string
    constructor() { 
        super()
        this.nome_razao = `` 
        this.descritivo = `` 
        this.r_conta_descricao = `` 
        this.user_name = ``
        this.user_name_cancelador = ``
        this.competencia_descricao = ``
        this.new();
    }

    async new ()
    {
        this.aut_pgto_pag_uuid = clsTools.uuid(10, false);
    

    }

    async update(DataBory: any) { 
        let sql = `` 
        try {
            this.binding(DataBory)
            if (this.aut_pgto_pag_seq == 0) { 
                sql = `insert into tbautorizacaopagamentopag
                            (	sis_us_seq	
                            ,   aut_pgto_pag_uuid	
                            ,	competencia_cd 			
                            ,	em_cdempresa		
                            ,   r_conta_cd 	
                            ,	aut_pgto_pag_data 		
                            ,	cdparticipante			
                            ,	aut_pgto_pag_data_pgto  
                            ,	aut_pgto_pag_valor		
                            ,   aut_pgto_pag_obs
                            ,   debitocredito
                            ,   aut_pgto_pag_tipo_cd 
                            )
                        SELECT 
                                ${this.sis_us_seq}
                            ,   '${this.aut_pgto_pag_uuid}'     
                            ,   ${this.competencia_cd}
                            ,   ${this.em_cdempresa}
                            ,   ${this.r_conta_cd}
                            ,   '${clsTools._datemomentDateToStr(this.aut_pgto_pag_data, "YYYY-MM-DD")}'
                            ,   ${this.cdparticipante}
                            ,   '${clsTools._datemomentDateToStr(this.aut_pgto_pag_data_pgto, "YYYY-MM-DD")}'
                            ,   ${this.aut_pgto_pag_valor}
                            ,   '${this.aut_pgto_pag_obs}'
                            ,   ${this.debitocredito}
                            ,   '${this.aut_pgto_pag_tipo_cd}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbautorizacaopagamentopag WHERE aut_pgto_pag_uuid = '${this.aut_pgto_pag_uuid}')
                        `
            } else {
                sql = `UPDATE tbautorizacaopagamentopag 
                        set   aut_pgto_pag_obs = '${this.aut_pgto_pag_obs}' 
                            where aut_pgto_pag_seq = ${this.aut_pgto_pag_seq}    
                        ` 
                if (this.aut_pgto_pag_cancelado == 1)
                {
                    sql = `update tbautorizacaopagamentopag 
                                set  aut_pgto_pag_cancelado = ${this.aut_pgto_pag_cancelado}
                                ,    aut_pgto_pag_cancelado_data = current_timestamp 
                                ,    aut_pgto_pag_cancelado_sis_us_seq = ${this.aut_pgto_pag_cancelado_sis_us_seq}
                                ,    aut_pgto_pag_obs = '${this.aut_pgto_pag_obs}' 
                            where aut_pgto_pag_seq = ${this.aut_pgto_pag_seq}
                        `
                }
            }

            await myClsBase.myDataBase.pag.Execute(sql)
            await this.select({aut_pgto_pag_uuid : this.aut_pgto_pag_uuid})
        } catch (e) { 
            clsTools.PagErrorException("M0080-Financeiro", "FinanceiroPag/Insert", e)
        }
    }

    async select(filtros: any) { 
        let sql = `SELECT   x.dtlog_insert 
                        ,   x.aut_pgto_pag_seq 
                        ,   x.sis_us_seq
                        ,   x.aut_pgto_pag_uuid	
                        ,	x.competencia_cd 			
                        ,	x.em_cdempresa		
                        ,   x.r_conta_cd 	
                        ,	x.aut_pgto_pag_data 		
                        ,	x.cdparticipante			
                        ,	x.aut_pgto_pag_data_pgto  
                        ,	x.aut_pgto_pag_valor	
                        ,   coalesce(r.r_conta_descricao,'') as r_conta_descricao 
                        ,   coalesce(p.nome_razao , '') as nome_razao 
                        ,   coalesce(x.aut_pgto_pag_cancelado,0) as aut_pgto_pag_cancelado
                        ,   coalesce(x.aut_pgto_pag_cancelado_data, current_timestamp) as aut_pgto_pag_cancelado_data
                        ,   coalesce(x.aut_pgto_pag_cancelado_sis_us_seq,0) as aut_pgto_pag_cancelado_sis_us_seq
                        ,   coalesce(aut_pgto_pag_obs, '') as aut_pgto_pag_obs
                   FROM         tbautorizacaopagamentopag x
                   LEFT JOIN    tbresultado_conta r on r.r_conta_cd = x.r_conta_cd 
                   LEFT JOIN    tbparticipante p on p.cdparticipante = x.cdparticipante 
                   where 1 = 1
                   ${(filtros.aut_pgto_pag_uuid)? " and x.aut_pgto_pag_uuid = '" + filtros.aut_pgto_pag_uuid + "'": ""  }
                   ${(filtros.aut_pgto_pag_seq)? " and x.aut_pgto_pag_seq = " + filtros.aut_pgto_pag_seq: ""  }        
                `
                let result = await myClsBase.myDataBase.pag.DataGet(sql)

            let dataItem : any = await myClsBase.myDataBase.RecordItem(result,0) 
            if (dataItem)
            {
                this.binding( dataItem)
                this.nome_razao = dataItem?.nome_razao
                this.r_conta_descricao = dataItem?.r_conta_descricao
                this.user_name = dataItem?.user_name || ''
                this.user_name_cancelador = dataItem?.user_name_cancelador || ''
                this.competencia_descricao = dataItem?.competencia_descricao || ''
            }   
    }
}

export { modelautorizacaoPagamentoPagRouter, modelautorizacaopagamentopag}