import myTools from "../../../tools/Tools";
import { ifilter_faturamento } from '../wk'
export default class Zanthus_Ctrl_Cupom {
        public static get  ( filter: ifilter_faturamento): string 
        {
                let select =  `Select	fat_zanthus_data_m00af = A.M00AF                      
                                ,	fat_zanthus_sat_ecf_m00ac = A.M00AC                   
                                ,	fat_zanthus_cupomfiscal_m00ad = A.M00AD               
                                ,	fat_zanthus_conferencia = convert(int, 0 )
                                ,	fat_zanthus_processado = convert(int, 0 )
                                ,   fat_zanthus_pag = convert(int, 0 )
                                from		ZEUSRETAIL.DBO.ZAN_M45	A                             
                                WHERE		1 = 1                                              
                                AND A.M00AF >= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_ini)}'
                                AND A.M00AF <= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_fim)}'
                                AND A.M00AC = ${filter.filter?.sat_ecf}  
                                `
                console.log(select)
                return select

                //`${result['color 5'] ? 'color 5 exists!' : 'color 5 does not exist!'}`
        }
}