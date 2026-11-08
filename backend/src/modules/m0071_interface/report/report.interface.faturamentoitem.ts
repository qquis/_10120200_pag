import { clsBase, clsTools } from "../../../model/modelbase";



const FLG_INFO : any = clsTools.pagLogSet(
    {       SISTEMA_NUCLEO_PRC_CD: 0
        ,   FLG_DEBUG_CONSOLE_LOG: true
        ,   FLG_MODULO: "M0071_INTERFACE - Report Interface Item ( report.interface.faturamentoitem.ts )"
        ,   FLG_DEBUG_FILE_CONSOLE_LOG: ``
})



export default class reportInterfaceItem {
    private static sql(parametro: any) : string { 

            let sql : string = ``

            if (parametro.tipo_relatorio === 'DETALHE')
            {
               sql = `
                            select  
                            i.seqinterface
                    ,       i.datafaturamento 
                    ,       i.cdoperacao 
                    ,       i.seqfaturamento
                    ,       i.seqfaturamentoorigem
                    ,       i.sat_ecf
                    ,       i.cupomfiscal
                    ,       i.numeropedido
                    ,       i.pr_cdproduto 
                    ,       i.embalagemestoque
                    ,       i.embalagemestoqueqtde 
                    ,       i.embalagemcompra 
                    ,       i.embalagemcompraqtde 
                    ,       i.cdparticipantecliente 
                    ,       c.nome_razao 
                    ,       g.cdgrupoeconomico 
                    ,       g.descricao 
                    ,       i.cdparticipantevendedor
                    ,       i.seqprocessamentoitemdocumento 
                    ,       i.valortotalfaturamento
                `  
            


            } else { 

                    if (parametro.tipo_relatorio === 'RESUMO_DATA')
                    {
                    sql = `
                                    select  
                                    i.seqinterface  AS  seqinterface
                            ,       i.datafaturamento as datafaturamento
                        
                        `  
                    


                    }  
                    
                    if (parametro.tipo_relatorio === 'RESUMO')
                    {
                    sql = `
                                    select  
                                    i.seqinterface  AS  seqinterface
                            
                        `  
                    


                    }  

                    if (parametro.tipo_relatorio === 'RESUMO_COMPETENCIA')
                    {
                    sql = `
                                    select  
                                    i.seqinterface  AS  seqinterface
                            ,       TO_CHAR(i.datafaturamento, 'YYYYMM') as datafaturamento
                            ,       cp.competencia_descricao `
                    


                    }             


                    sql += `                    
                            ,       count(distinct(i.cdoperacao)) as cdoperacao 
                            ,       count(distinct(i.seqfaturamento)) as seqfaturamento
                            ,       count(distinct(i.seqfaturamentoorigem)) as seqfaturamentoorigem
                            ,       count(distinct(i.sat_ecf)) as sat_ecf
                            ,       count(distinct(i.cupomfiscal)) as cupomfiscal
                            ,       count(distinct(i.numeropedido)) as numeropedido
                            ,       count(distinct(i.pr_cdproduto)) as pr_cdproduto 
                            ,       count(distinct(i.embalagemestoque)) as embalagemestoque
                            ,       sum(i.embalagemestoqueqtde) as embalagemestoqueqtde 
                            ,       count(distinct(i.embalagemcompra)) as embalagemcompra 
                            ,       sum(cast(i.embalagemcompraqtde as numeric(13,4))) as embalagemcompraqtde 
                            ,       count(distinct(i.cdparticipantecliente)) as cdparticipantecliente 
                            ,       count(distinct(i.cdparticipantecliente_original)) as cdparticipantecliente_original
                            ,       count(distinct(c.nome_razao)) as nome_razao 
                            ,       count(distinct(g.cdgrupoeconomico)) as cdgrupoeconomico 
                            ,       count(distinct(g.descricao)) as descricao 
                            ,       count(distinct(i.cdparticipantevendedor)) as cdparticipantevendedor
                            ,       count(distinct(i.cdparticipantevendedor_original)) as cdparticipantevendedor_original
                            ,       count(distinct(i.seqprocessamentoitemdocumento)) as   seqprocessamentoitemdocumento 
                            ,       sum(i.valortotalfaturamento) as valortotalfaturamento
                            ,       sum(case when  i.seqinterfacefaturamentoagendamentosimuladoinfoitem > 0 then cast(i.embalagemcompraqtde as numeric(13,4)) else 0 end ) as simulado_embalagemcompraqtde 
                            ,       count(distinct(case when i.seqinterfacefaturamentoagendamentosimuladoinfoitem > 0 then i.cdparticipantecliente else null end)) as simulado_cdparticipantecliente                     
                        `  
            }

            sql += `
                    from        tbinterfacefaturamentoinfoitem i
                    left join   tbparticipante_bluesoft c on c.cdparticipante = i.cdparticipantecliente
                    left join   tbgrupoeconomico        g on g.cdgrupoeconomico = c.cdgrupoeconomico
                    `
            if (parametro.tipo_relatorio === 'RESUMO_COMPETENCIA')
            {
                sql += ` left join tbcompetencia cp on cp.competencia_cd = cast(TO_CHAR(i.datafaturamento, 'YYYYMM') as integer) `
            }


            sql +=  `
                    where       1 = 1
                    and		    i.datafaturamento	>=	'${clsTools._datemomentDateToStr(parametro.data_processamento_ini, "YYYY-MM-DD")}'
                    and		    i.datafaturamento	<=	'${clsTools._datemomentDateToStr(parametro.data_processamento_fim, "YYYY-MM-DD")}'
                    and		    i.seqinterface	=	1
            `


            if (parametro.tipo_relatorio === 'RESUMO_DATA') { 
                sql += `
                    group by i.seqinterface, i.datafaturamento
                `;
            }

 
            if (parametro.tipo_relatorio === 'RESUMO')
            {
                sql += `
                    group by i.seqinterface
                `;
            }

            if (parametro.tipo_relatorio === 'RESUMO_COMPETENCIA')
            {
                sql += `
                    group by i.seqinterface, TO_CHAR(i.datafaturamento, 'YYYYMM'), cp.competencia_descricao
                `;
            }

            sql += `order by 1 asc`
		 

               
                    

                    
                    return sql 
    }

    static async get(parametro: any): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro), true)
            return result
        } catch (e) {

            await clsTools.PagErrorException(FLG_INFO.FLG_MODULO,"get",e,false,"",FLG_INFO.FLG_DEBUG_FILE_CONSOLE_LOG)
            throw new Error(`${e}`)
        }
    }



}