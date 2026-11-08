import tbintegracao_tipo from "../tbs/tbintegracao_tipo";
import myTools from "../../../tools/Tools";
import tbintegracao_tipo_info from "../tbs/tbintegracao_tipo_info";
import DataBase from "../../../database/DataBase";
import { modelbase } from "../../../model/model";


let myDATABASE : DataBase = new DataBase();

export default class modelintegracao_tipo extends modelbase {
    integracao_pendente_qtde: number
    script_select: string 
    integracao_tipo : tbintegracao_tipo
    integracao_tipo_info : tbintegracao_tipo_info
    sis_batch_run_seq : number
    sis_batch_descricao : string 

    constructor(item? : any) {
        super()

        this.integracao_tipo = new tbintegracao_tipo();
        this.integracao_tipo_info = new tbintegracao_tipo_info();


        this.integracao_pendente_qtde= 0;
        this.script_select = ``
        this.sis_batch_run_seq = 0;
        this.sis_batch_descricao = `NAO IDENTIFICADO` 

        if (item) {
            this.integracao_tipo.integracao_cd = item?.integracao_cd
            this.integracao_tipo.integracao_tipo_cd = item?.integracao_tipo_cd
            this.integracao_tipo.integracao_tipo_descricao = item?.integracao_tipo_descricao
            this.integracao_tipo.zanthus = item?.zanthus
            this.integracao_tipo.bluesoft_redshift  = item?.bluesoft_redshift
            this.integracao_tipo.bluesoft_api = item?.bluesoft_api
            this.integracao_tipo.tipo_export = item?.tipo_export

            this.integracao_tipo.sis_batch_cd = item?.sis_batch_cd
            this.integracao_pendente_qtde = item?.integracao_pendente_qtde;
            this.script_select = item?.script_select
            this.sis_batch_descricao = item?.sis_batch_descricao

            if (item?.sis_batch_run_seq !== undefined)
                this.sis_batch_run_seq = item?.sis_batch_run_seq
            

            this.integracao_tipo_info.script_select = item?.script_select
            this.integracao_tipo_info.sis_batch_cd = item?.sis_batch_cd
        }
    }

    async FinalizarTodosIntegracaoDeProdutoPendentes() : Promise<void> {
        try {
                let stringSQL = `UPDATE tbintegracao_produto 
                                set  integracao_status_cd = 1
                                   , dtlog_update = current_timestamp 
                              where  1 = 1
                                and  integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                                and  integracao_status_cd = 2
                            `
                await myDATABASE.pag.Execute(stringSQL)
        } catch (e) {
            myTools.pagConsole(` (ERROR) F0095 | modelintegracao_tipo 
                                 Method FinalizarTodosRegistrosPendentes
                                 ${e}
                                `)
        }
    }

    async GerarPendenciaDePrecos() : Promise<void> {
        try {

            if (this.integracao_tipo.integracao_tipo_cd == 20008501)
            {
               let sql : string = `
                INSERT INTO tbintegracao_produto 	
                            (
                                    pr_cdproduto 
                                ,	prb_cdprodutobluesoftunitario 
                                ,	prb_cdprodutobluesoft
                                ,	integracao_tipo_cd 
                                ,	integracao_status_cd 
                            )
                                SELECT 		pr.pr_cdproduto 
                                        ,	pr.prb_cdprodutobluesoft 
                                        ,	pr.prb_cdprodutobluesoft 
                                        ,	${this.integracao_tipo.integracao_tipo_cd}
                                        ,	2
                                from   		tbpreco_log pl
                                inner join  tbproduto   pr on pr.pr_cdproduto = pl.pr_cdproduto 
                                where       pr.pr_status = 'true'
                                and  		prc_data_aplicacao >= current_date - interval '1 day'
                                and         not exists ( 	select 1 
                                                            from   tbintegracao_produto x
                                                            where  x.pr_cdproduto = pr.pr_cdproduto 
                                                            and  x.prb_cdprodutobluesoftunitario  = pr.prb_cdprodutobluesoft 
                                                            and  x.prb_cdprodutobluesoft = pr.prb_cdprodutobluesoft 		
                                                            and  x.integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                                            )
                                group by    pr.pr_cdproduto 
                                        ,	pr.prb_cdprodutobluesoft

                            ;
                        
                        UPDATE 	tbintegracao_produto XX
                        SET   integracao_status_cd = 2
                            , dtlog_update = current_timestamp
                        FROM (
                                    SELECT 		pr.pr_cdproduto 
                                            ,	pr.prb_cdprodutobluesoft 
                                    from   		tbpreco_log pl
                                    inner join  tbproduto   pr on pr.pr_cdproduto = pl.pr_cdproduto 
                                    where       pr.pr_status = 'true'
                                    and  		prc_data_aplicacao >= current_date - interval '1 day'
                                    group by    pr.pr_cdproduto 
                                    ,	pr.prb_cdprodutobluesoft
                            ) AA
                        WHERE XX.integracao_tipo_cd = ${this.integracao_tipo.integracao_tipo_cd}
                        AND AA.pr_cdproduto = XX.pr_cdproduto 
                        AND AA.prb_cdprodutobluesoft = XX.prb_cdprodutobluesoftunitario 
                        AND AA.prb_cdprodutobluesoft = XX.prb_cdprodutobluesoft 
                    ;	
                `
                await myDATABASE.pag.Execute(sql)
            }

        } catch (e) {
           myTools.PagErrorException("F0095 - modelintegracao_tipo", "GerarPendenciaDePrecos", e, true)
        }

    }



} 