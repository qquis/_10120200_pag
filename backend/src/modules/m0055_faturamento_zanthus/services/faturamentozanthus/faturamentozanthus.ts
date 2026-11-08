import tbfaturamentozanthus_ctrl from '../../tbs/tbfaturamentozanthus_ctrl'
import tbfaturamentozanthus_ctrl_cupom from '../../tbs/tbfaturamentozanthus_ctrl_cupom'
import tbfaturamentozanthus from '../../tbs/tbfaturamentozanthus'
import tbfaturamentozanthusitem from '../../tbs/tbfaturamentozanthusitem'
import { ifilter_faturamento } from '../../wk'
import {modelReport} from '../../../../model/model'
import myTools from "../../../../tools/Tools";



/* REPORTS */
import f0055_15_faturamentozanthus_ctrl_consultar  from '../../scriptspg/f0055_15_faturamento_zanthus_ctrl_consultar'
import modelFaturamentozanthus_Ctrl from '../../model/modelfaturamentozanthusctrl'




export default class FaturamentoZanthus extends modelReport {

    public static async Report_Ctrl_Get(filter: ifilter_faturamento) : Promise<Array<modelFaturamentozanthus_Ctrl>> { 
        const result  = await super.Get(f0055_15_faturamentozanthus_ctrl_consultar.SELECT(filter))

        let list: Array<modelFaturamentozanthus_Ctrl> = await FaturamentoZanthus.Ctrl_List(result, false)
        return Promise.resolve(list)
            
    }
    public static async Ctrl_List(DataBaseSelectResult: Object, ToCheck: boolean = false) : Promise<Array<modelFaturamentozanthus_Ctrl>> {
            let mylist = new Array<modelFaturamentozanthus_Ctrl>(); 
            for (const [key, value] of Object.entries(DataBaseSelectResult)) {
                let i = new modelFaturamentozanthus_Ctrl();
                await i.binding(value)
                if (ToCheck) await i._Db_Pg_CRUD();
                //console.log(i)
                await mylist.push(i)
            }
            return Promise.resolve(mylist);
    }



    public static async Ctrl_Cupom_List(DataBaseSelectResult: Object, ToCheck: boolean = false) : Promise<Array<tbfaturamentozanthus_ctrl_cupom>> {
        let mylist = new Array<tbfaturamentozanthus_ctrl_cupom>(); 
        for (const [key, value] of Object.entries(DataBaseSelectResult)) {
            let i = new tbfaturamentozanthus_ctrl_cupom();
            await i.binding(value)
            if (ToCheck) await i._Db_Pg_ToCheck();
            await mylist.push(i)
        }
        return Promise.resolve(mylist);
    }

    public static async TbFaturamento_List(DataBaseSelectResult: Object, ToCheck: boolean = false) : Promise<Array<tbfaturamentozanthus>> {
        let mylist = new Array<tbfaturamentozanthus>(); 
        for (const [key, value] of Object.entries(DataBaseSelectResult)) {
            let i = new tbfaturamentozanthus();

            await i.binding(value)

            if (ToCheck) await i._Db_Pg_ToCheck();
            await mylist.push(i)
        }
        return Promise.resolve(mylist);
    }

    public static async TbFaturamentoItem_List(DataBaseSelectResult: Object, ToCheck: boolean = false) : Promise<Array<tbfaturamentozanthusitem>> {
 
        let mylist = new Array<tbfaturamentozanthusitem>(); 
        for (const [key, value] of Object.entries(DataBaseSelectResult)) {
            let i = new tbfaturamentozanthusitem();
            await i.binding(value)
            if (ToCheck) await i._Db_Pg_ToCheck();
            await mylist.push(i)
        }
        return Promise.resolve(mylist);
    }    


    public static async Ctrl_FaturamentoUpdate(filter: ifilter_faturamento) : Promise<void> { 
        try {

            let scriptUpdateSqlFaturamentoCrlZanthus = `
                update tbfaturamentozanthus_ctrl a
                set    fat_cupom_qtde 		= x.fat_cupom_qtde
                    ,  fat_cupom_inicial 	= x.fat_cupom_inicial
                    ,  fat_cupom_final 		= x.fat_cupom_final
                    ,  fat_cupom_valor 		= x.fat_cupom_valor
                from 	( 	select 		f.datafaturamento						as fat_zanthus_data_m00af
                                    ,	o.sat_ecf 								as fat_zanthus_sat_ecf_m00ac 
                                    ,	count(distinct(o.cupomfiscal))			as fat_cupom_qtde 
                                    ,	min(o.cupomfiscal)  					as fat_cupom_inicial
                                    ,	max(o.cupomfiscal) 						as fat_cupom_final
                                    ,	sum(i.valortotalfaturamentoliquido) 	as fat_cupom_valor
                            from 		tbfaturamento			 f
                            inner join 	tbfaturamentoorigem 	 o on o.seqfaturamento = f.seqfaturamento 
                            inner join  tbfaturamentoitens      i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
                            where		1 = 1
                            and			f.datafaturamento >= '${myTools._datemomentDateToStr(filter.filter?.datafaturamento_ini, 'YYYY-MM-DD')}'
                            and			f.datafaturamento <= '${myTools._datemomentDateToStr(filter.filter?.datafaturamento_fim, 'YYYY-MM-DD')}'
                            ${filter.filter?.sat_ecf && filter.filter?.sat_ecf !== 0 ? ` and o.sat_ecf = ${filter.filter?.sat_ecf}` : ``}
                            group by 	f.datafaturamento	
                                    ,	o.sat_ecf 
                            order by 	f.datafaturamento
                                    ,	o.sat_ecf 
                        ) x 
                where 	a.fat_zanthus_data_m00af = x.fat_zanthus_data_m00af
                and 	a.fat_zanthus_sat_ecf_m00ac = x.fat_zanthus_sat_ecf_m00ac
            
            `
            await this.Execute(scriptUpdateSqlFaturamentoCrlZanthus)


        } catch (e) {
            myTools.PagErrorException(`FaturamentoZanthus`, `Ctrl_FaturamentoUpdate`, e, true, `Atualização dos dados de Pag/Faturamento Ctrl/Zanthus`)
        }
    }

}


