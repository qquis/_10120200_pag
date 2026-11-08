import { clsBase, clsTools } from "../../../model/modelbase";
import reportContaList from "../report/reportContaList";
import reportContaOrigemList from "../report/reportContaOrigemList";
import tbresultado_conta from "../tbs/tbresultado_conta";
import modelResultaContaOrigem from "./moderesultado_conta_origem";


const myclsBase : clsBase = new clsBase();

export default class modelResultaConta extends tbresultado_conta{ 
    r_grupo_descricao : string 
    r_rateio_descricao: string 
    resultadoContaOrigemList: modelResultaContaOrigem[]
    constructor() { 
        super()
        this.r_grupo_descricao = ``
        this.r_rateio_descricao = `` 
        this.resultadoContaOrigemList = []
    }
    
    async modelBinding(item: any) { 
        if (item) { 
            super.binding(item)
            this.r_grupo_descricao = item?.r_grupo_descricao
            this.r_rateio_descricao = item?.r_rateio_descricao
        }

    }

    async modelGet(r_conta_cd: number) : Promise<void> { 
        try { 
            let result = await reportContaList.get({r_conta_cd})
            await this.modelBinding(result)
            await this.getInfoResultadoContaOrigem(r_conta_cd)
        } catch (e) { 
            clsTools.PagErrorException('modelResultadoConta', "modelPost", e)
        }
    }
    async modelPost(dados: any) : Promise<void> { 
        try { 
            if (this.r_conta_cd)
            {
                let sql = `UPDATE tbresultado_conta 
                            set r_conta_descricao = '${dados.r_conta_descricao}' 
                            ,   r_conta_lancamento_manual = ${dados.r_conta_lancamento_manual}
                            ,   debitocredito = ${dados.debitocredito}
                            ,   r_rateio_cd = ${dados.r_rateio_cd}
                    WHERE r_conta_cd = ${this.r_conta_cd}
                        `
                await myclsBase.myDataBase.pag.Execute(sql)
            }
            await this.modelGet(this.r_conta_cd)
        } catch (e) { 
            clsTools.PagErrorException('modelResultadoConta', "modelPost", e)
        }

    }

    async getInfoResultadoContaOrigem(r_conta_cd: number) { 
        try { 
            let result = await reportContaOrigemList.get({r_conta_cd})
            for (const [key, value] of Object.entries(result)) { 
                let item : modelResultaContaOrigem = new modelResultaContaOrigem() 
                await item.modelBinding(value)
                this.resultadoContaOrigemList.push(item)
            }
        } catch (e) { 
            clsTools.PagErrorException('modelResultadoConta', "getInfoResultadoContaOrigem", e)
        }
    }

    async atualizarCodigoRateio ( r_rateio_cd: number ) { 
        try { 
            
            let sql = `UPDATE tbresultado_conta SET r_rateio_cd = ${r_rateio_cd}
                       WHERE r_conta_cd = ${this.r_conta_cd}  
                    `

        } catch (e) { 
            clsTools.PagErrorException('modelResultadoConta', "atualizarCodigoRteio", e)
        }
    } 
}