
import { clsBase, clsTools } from '../../../model/modelbase';
import reportFiguraFiscalProdutoFilter from './reportTypeFIguraFiscalProdutoFIlter';

const myBase = new clsBase();


export default class reportFiguraFiscal { 
    public static async sql(parametro: any) : Promise<string> { 


        let sql = ` `
        
        sql =  ` select 	f.dtlog_insert 
                        ,	f.dtlog_update
                        ,	f.fc_figurafiscal_cd 
                        ,	f.fc_figurafiscal_descricao 
                        ,	f.fc_figurafiscal_codigo
                        ,	f.fc_figurafiscal_base
                        ,	f.fc_figurafiscal_versao
                        ,	coalesce(e.qtde_regra,0) as entrada_qtde
                        ,	coalesce(rx.qtde_regra,0) as saida_qtde
                        ,	coalesce(op.operacao_qtde,0) as saida_operacao_qtde
                    from 	tbfc_figurafiscal f
                    left  join  (    select 	fc_figurafiscal_cd 
                                    ,	count(*) as qtde_regra 
                                    from 	 tbfc_regrafiscal 
                                    where  fc_regrafiscal_status = 1 
                                      and  tipo = 'ENTRADA'
                                    group by fc_figurafiscal_cd 
                            ) e on e.fc_figurafiscal_cd  = f.fc_figurafiscal_cd                     
                    left  join  (    select 	fc_figurafiscal_cd 
                                            ,	count(*) as qtde_regra 
                                    from 	 tbfc_regrafiscal rs 
                                    where  rs.fc_regrafiscal_status = 1 
                                      and  rs.tipo = 'SAIDA'                                    
                                    group by rs.fc_figurafiscal_cd 
                            ) rx on rx.fc_figurafiscal_cd  = f.fc_figurafiscal_cd 
                    left  join  (   select      of.fc_figurafiscal_cd 
                                           ,	 count(*) as operacao_qtde  
                                    from 	   tbfc_regrafiscal_operacao  ox 
                                    inner join tbfc_regrafiscal of on of.fc_regrafiscal_cd = ox.fc_regrafiscal_cd
                                    where       of.fc_regrafiscal_status = 1
                                      and  of.tipo = 'SAIDA'                                    
                                    group by of.fc_figurafiscal_cd 
                            ) op on op.fc_figurafiscal_cd  = f.fc_figurafiscal_cd                              
                     where      1 = 1
                     ${ parametro.fc_figurafiscal_cd ? ` and f.fc_figurafiscal_cd = ${parametro.fc_figurafiscal_cd} ` : '' }
                     ${ parametro.fc_figurafiscal_descricao ? ` and f.fc_figurafiscal_descricao like '%${parametro.fc_figurafiscal_descricao}%' ` : '' }
                     ${ parametro.filterQtdeRegraFiscal  && parametro.filterQtdeRegraFiscal == 1 ? ` and coalesce(op.operacao_qtde,0) >= ${parametro.filterQtdeRegraFiscalIni}  and coalesce(op.operacao_qtde,0) <= ${parametro.filterQtdeRegraFiscalFim} ` : '' }
                     
          

            `

            sql += ` order by f.fc_figurafiscal_descricao asc  `;    


        
        return sql;
    }

    public static async get(parametro: reportFiguraFiscalProdutoFilter) : Promise<object> { 
        
        let report = {}
        try { 

            report = await myBase.myDataBase.pag.DataGet( await this.sql(parametro) )


        } catch (e) {
            clsTools.PagErrorException('m0040_fiscal', 'reportFiguraFiscalProduto', e);
        }

        finally {
            return report
        }
    }


}