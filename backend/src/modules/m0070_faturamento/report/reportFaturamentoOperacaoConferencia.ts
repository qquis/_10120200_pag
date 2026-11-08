import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportFaturamentoStatus {
    public static sql(filter : any) : string {
        let sql = 
        
         `	SELECT 		f.datafaturamento 
                ,       f.em_cdempresa 
                ,       em.em_descricao
                ,	    f.op_cdoperacao
                ,       op.op_descricao  
                ,		sum(I.valortotalfaturamentobase) as valortotalfaturamentobase
                ,		sum(i.valortotalsubsidioscorrentes) as valortotalsubsidioscorrentes
                ,		sum(i.valortotalfaturamento) as valortotalfaturamento
                ,		sum(i.valortotaldescontofinanceiro) as valortotaldescontofinanceiro
                ,		sum(i.valortotalsubsidiosaplicados) as valortotalsubsidiosaplicados
                ,		sum(i.valortotalfaturamentoliquido) as valortotalfaturamentoliquido
            FROM 		TBFATURAMENTO 		f
            inner join 	tbfaturamentoorigem o on o.seqfaturamento = f.seqfaturamento
            inner join  tbfaturamentoitens  i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
            inner join  tboperacao         op on op.op_cdoperacao = f.op_cdoperacao
            inner join  tbempresa          em on em.em_cdempresa = f.em_cdempresa 
            WHERE 		1 = 1
            `

        if (filter.op_cdoperacao && filter.op_cdoperacao > 0) {
            sql += ` AND f.op_cdoperacao = ${filter.op_cdoperacao}`
        }

        if (filter.statusfaturamentoFiltrar && filter.statusfaturamentoFiltrar > 0) {
            sql += ` AND f.statusfaturamento = ${filter.statusfaturamentoFiltrar}`
        }

        if (filter.dataFaturamento_ini ) {
            sql += ` AND f.datafaturamento >= '${filter.dataFaturamento_ini}'`
        }
        if (filter.dataFaturamento_fim) {
            sql += ` AND f.datafaturamento <= '${filter.dataFaturamento_fim}'`
        }


        sql += `
            group by 	f.datafaturamento 
                ,       f.em_cdempresa 
                ,       em.em_descricao
                ,	    f.op_cdoperacao
                ,       op.op_descricao
        `

            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {


            if (!filter.dataFaturamento_ini || !filter.dataFaturamento_fim) {
                throw new Error('Parâmetros de filtro inválidos. dataFaturamento_ini e dataFaturamento_fim são obrigatórios.');
            }

            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoStatus | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
