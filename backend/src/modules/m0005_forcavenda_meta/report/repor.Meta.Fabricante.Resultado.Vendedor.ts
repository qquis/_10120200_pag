import { clsBase, clsTools } from '../../../model/modelbase';

export default class reportForcaVendaMetaFabricanteResultadoVendedor {
    public static sql(filter : any) : string {
        let sql = 
        
         `	select 	fv_fab_meta_cd
	,	case seqinterface
			when 0 then 'DADOS OXAN'
			when 1 then 'DADOS JOHNSON'
			end
	,   p.nome_razao 
            ,	x.cdparticipantevendedor 
    
	,	sum(case when fv_fab_meta_mix_cd = 2 then qtde_positivacao else 0 end ) as MIX02
	,	sum(case when fv_fab_meta_mix_cd = 7 then qtde_positivacao else 0 end ) as MIX07	
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX17		
	,	sum(case when fv_fab_meta_mix_cd = 17 then qtde_positivacao else 0 end ) as MIX28			

from   tbforca_venda_fab_meta_res_vendedor x
left join tbparticipante_bluesoft p on p.cdparticipante = x.cdparticipantevendedor
`


if (filter.fv_fab_meta_cd) {
    sql += ` where x.fv_fab_meta_cd = ${filter.fv_fab_meta_cd} `
}

if (filter.seqinterface !== undefined) {
    sql += ` and x.seqinterface = ${filter.seqinterface} `
}


sql += `
        group by x.fv_fab_meta_cd
            ,	p.nome_razao 
            ,	case x.seqinterface
                    when 0 then 'DADOS OXAN'
                    when 1 then 'DADOS JOHNSON'
                    end
            ,	x.cdparticipantevendedor 
        order by 1,2,3

        `
            return sql
    }

    public static async get(filter : any) : Promise<object> {
        let result = { }
        try {
            result = await new clsBase().myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportForcaVendaMetaFabricante | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    }   

}
