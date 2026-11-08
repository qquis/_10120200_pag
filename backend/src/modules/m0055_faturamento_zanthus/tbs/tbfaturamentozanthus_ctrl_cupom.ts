import f0055_11_faturamentozanthus_ctrl_cupom from '../scriptspg/f0055_11_faturamentozanthus_ctrl_cupom'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'


export default class tbfaturamentozanthus_ctrl_cupom extends modelTb {
    dtlog_insert: Date
    dtlog_update: Date 
    fat_zanthus_sat_ecf_m00ac: number
    fat_zanthus_data_m00af: Date
    fat_zanthus_cupomfiscal_m00ad: number 
    fat_zanthus_conferencia: number 
    fat_zanthus_processado: number 
    fat_zanthus_pag: number 


public constructor() 
{
    super()
    this.dtlog_insert = new Date(); 
    this.dtlog_update = new Date(); 
    this.fat_zanthus_sat_ecf_m00ac = 0;
    this.fat_zanthus_data_m00af = new Date();  
    this.fat_zanthus_cupomfiscal_m00ad = 0;
    this.fat_zanthus_conferencia = 0;
    this.fat_zanthus_processado = 0;
    this.fat_zanthus_pag = 0;

}

_Db_Pg_script(_stringCommand: string): string{
    const script: string = `Select * from ${f0055_11_faturamentozanthus_ctrl_cupom.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${myTools.format_Date_toStr_ShortDataBase(this?.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this?.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this?.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_conferencia:= ${this?.fat_zanthus_conferencia}
            ,   vfat_zanthus_processado:= ${this?.fat_zanthus_processado}
            ,   vfat_zanthus_pag:= ${this?.fat_zanthus_pag}
        )`
   return script; 

}

async binding(item: any){
        try {
            if (item !== undefined) {
                const data_string = item.fat_zanthus_data_m00af
                this.fat_zanthus_data_m00af = myTools.Date_br_timestamp(data_string)
                this.fat_zanthus_sat_ecf_m00ac = item.fat_zanthus_sat_ecf_m00ac
                this.fat_zanthus_cupomfiscal_m00ad = item.fat_zanthus_cupomfiscal_m00ad;
                this.fat_zanthus_conferencia = item.fat_zanthus_conferencia;
                this.fat_zanthus_processado = item.fat_zanthus_processado;
                this.fat_zanthus_pag = item.fat_zanthus_pag;
            }
        } catch(e){
            throw `tbfaturamentozanthus_ctrl_cupom | ${e}`        
        }
    }
}