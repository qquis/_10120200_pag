import { ifilter_faturamento } from '../wk'
import myTools from '../../../tools/Tools';
export default class f0055_15_faturamentozanthus_ctrl_consultar {
        public static sqlScript_VERSION(): string {return `f0055_15_1012007_faturamentozanthus_ctrl_consultar`}

        public static SELECT(filter : ifilter_faturamento): string {

                try {
                        let SQL = `select * from ${f0055_15_faturamentozanthus_ctrl_consultar.sqlScript_VERSION()} ( 
                                vdatafaturamento_ini:= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_ini)}'
                             ,  vdatafaturamento_fim:= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_fim)}'
                             ,  vsat_ecf:= ${filter.filter?.sat_ecf}
                             ,  vdiferenca:= 0 
                        )`
                        return SQL; 
                        
                } catch (e){
                        console.log(`f0055_15_faturamentozanthus_ctrl_consultar | ${e}`)
                        return ``
                }

        }

}