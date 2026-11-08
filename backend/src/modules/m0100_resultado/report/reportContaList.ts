import { clsTools, clsBase} from '../../../model/modelbase';
export default class reportContaList{
    static sql (parametros: any = {}) : string { 
                    let sql = `
                        Select 		c.r_grupo_cd 
                                ,	g.r_grupo_descricao 
                                ,	c.r_conta_cd 
                                ,	c.r_conta_descricao 
                                ,	coalesce(c.r_conta_lancamento_manual,0) as r_conta_lancamento_manual
                                ,	c.debitocredito
                                ,	coalesce(r.r_rateio_cd,0) as r_rateio_cd
                                ,	coalesce(r.r_rateio_descricao, '') as  r_rateio_descricao
                                ,   coalesce(qo.qtde_reg_vinculado,0)  as qtde_reg_vinculado
                        from 		tbresultado_conta	c
                        left join   (   select  count(*) as qtde_reg_vinculado 
                                            ,   r.r_conta_cd
                                        from    tbresultado_conta r
                                        group by r.r_conta_cd
                                     ) as qo on qo.r_conta_cd = c.r_conta_cd
                        inner join  tbresultado_grupo  g on g.r_grupo_cd = c.r_grupo_cd 
                        left join   tbresultado_rateio  r on r.r_rateio_cd = c.r_rateio_cd 
                        where 1 = 1 
                        ${ (parametros?.r_rateio_cd && parseInt(parametros?.r_rateio_cd) > 0 )? " AND r.r_rateio_Cd = " + parametros?.r_rateio_cd: "" }
                        ${ (parametros?.r_grupo_cd && parseInt(parametros?.r_grupo_cd) > 0 )? " AND c.r_grupo_cd = " + parametros?.r_grupo_cd: "" }     
                        ${ (parametros.r_conta_cd && parseInt(parametros.r_conta_cd) > 0 )? " AND c.r_conta_cd = " + parametros?.r_conta_cd: ""}    
                        ${ (parametros?.r_conta_lancamento_manual && parseInt(parametros?.r_conta_lancamento_manual) > 0 )? " AND c.r_conta_lancamento_manual = " + parametros?.r_conta_lancamento_manual: ""}
                        ${ (parametros?.r_conta_descricao)? " AND UPPER(c.r_conta_descricao)  like '%" + parametros?.r_conta_descricao + "%'": ""}
                        
                        ${ (parametros.orderbycolunm && parametros.orderbycolunm !== "")? 
                                " ORDER BY " + parametros.orderbycolunm : "ORDER BY 2, 4, 8"}

            `  
            
            return sql 
    }
    static async get(parametros: any = {}, sql : string = ``) : Promise<any> {
        let sqlQuery = sql || this.sql(parametros);
        const myTools = new clsBase();
        try {
                let result = await myTools.myDataBase.pag.DataGet(sqlQuery)
                if (parametros.r_conta_cd && parametros.r_conta_cd > 0) {
                        return myTools.myDataBase.RecordItem(result,0)
                } else { 
                    return result
                } 
                
        } catch (e) {
            clsTools.PagErrorException(`reportDREContaList`, 'sql', e);
        }
    }

}