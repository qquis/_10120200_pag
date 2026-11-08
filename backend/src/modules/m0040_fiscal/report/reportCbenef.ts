import { clsBase, clsTools } from '../../../model/modelbase';


export default class reportCbenef {
    static sql (parametro: any) : string {

        let sql = `  select 		x.fc_cbenef_cd 
                                ,	x.fc_cbenef_dispositivo
                                ,	x.fc_cbenef_objetivo 
                                ,	coalesce(pag.qtde,0) as pag_qtde 
                                ,	coalesce(blue.qtde,0) as blue_qtde
                                ,	x.fc_cbenef_observacao
                                ,   x.fc_cbenef_bluesoft_cd
                                ,   x.fc_cbenef_bluesoft_dispositivo
                                ,   x.fc_cbenef_bluesoft_objetivo

                from tbfc_cbenef x
                left join ( 
                                select 	pr_pag_fc_cbenef_cd 
                                        ,	count(*) as qtde 
                                    from 	tbproduto
                                        where pr_pag_fc_cbenef_cd is not null
                                    group by pr_pag_fc_cbenef_cd 
                            ) pag on pag.pr_pag_fc_cbenef_cd = x.fc_cbenef_cd 
                left join ( 
                                select 	pb.prb_blue_fc_cbenef_cd  
                                        ,	count(*) as qtde 
                                    from 	tbproduto px
                                    inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = px.prb_cdprodutobluesoft
                                        where pb.prb_blue_fc_cbenef_cd   is not null
                                    group by pb.prb_blue_fc_cbenef_cd  
                            ) blue on blue.prb_blue_fc_cbenef_cd = x.fc_cbenef_cd 			 
                where 1 = 1
                `
        if (parametro.fc_cbenef_cd && parametro.fc_cbenef_cd.trim() !== '') {
            sql += ` and fc_cbenef_cd like '%${parametro.fc_cbenef_cd}%'`
        }
        if (parametro.fc_cbenef_dispositivo && parametro.fc_cbenef_dispositivo.trim() !== '') {
            sql += ` and UPPER(fc_cbenef_dispositivo) like UPPER('%${parametro.fc_cbenef_dispositivo}%')`
        }

                if (parametro.fc_cbenef_objetivo && parametro.fc_cbenef_objetivo.trim() !== '') {
            sql += ` and UPPER(fc_cbenef_objetivo) like UPPER('%${parametro.fc_cbenef_objetivo}%')`
        }
        if (parametro.fc_cbenef_bluesoftFilter && parametro.fc_cbenef_bluesoftFilter !== 0) {
            sql += ` and coalesce(fc_cbenef_bluesoft_cd, 0) != 0 `
        }

        if (parametro.fc_cbenef_pag_qtde_Filter && parametro.fc_cbenef_pag_qtde_Filter !== 0) {
            sql += ` and coalesce(pag.qtde,0) >= ${parametro.fc_cbenef_pag_qtde_Filter} `
        }

        if (parametro.fc_cbenef_blue_qtde_Filter && parametro.fc_cbenef_blue_qtde_Filter !== 0) {
            sql += ` and coalesce(blue.qtde,0) >= ${parametro.fc_cbenef_blue_qtde_Filter} `
        }

        sql += ` order by fc_cbenef_cd asc `

        return sql;
    }

    static async get(parametro: any) : Promise<any> {
        let result : any = { }
        try {
            let myBase : clsBase = new clsBase();
            result = await myBase.myDataBase.pag.DataGet( this.sql(parametro));

        } catch (e) {
            clsTools.pagConsole(`reportCbenefProduto | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }   
    }   

}

