import f0055_13_faturamento_zanthus_item_crud from '../scriptspg/f0055_13_faturamento_zanthus_item'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'


export default class tbfaturamentozanthusitem extends modelTb {
    fat_zanthus_seq: number                                 
    fat_zanthus_data_m00af: Date                 
    fat_zanthus_sat_ecf_m00ac: number               
    fat_zanthus_cupomfiscal_m00ad: number           
    fat_zanthus_item_seq_m43eg: number 	            
    fat_zanthus_item_cdbarra_m43ah: string 
    fat_zanthus_item_cdbarra_M43BK_m43ah: string 
    fat_zanthus_item_qtde_m43ao: number			    
    fat_zanthus_item_valor_m43ap: number			
    fat_zanthus_m43bk: string  					    
    fat_zanthus_m43ah: string 						
    fat_zanthus_Decomp_Insumo: number
    fat_zanthus_val_liquido: number                  
    fat_zanthus_item_valor_desconto_m43aq: number
    fat_zanthus_qtde: number
    

public constructor() 
{
    super()
    this.fat_zanthus_seq = 0
    this.fat_zanthus_data_m00af = new Date('1900-01-01')
    this.fat_zanthus_sat_ecf_m00ac = 0
    this.fat_zanthus_cupomfiscal_m00ad = 0
    this.fat_zanthus_item_seq_m43eg = 0 
    this.fat_zanthus_item_cdbarra_m43ah = `` 
    this.fat_zanthus_item_cdbarra_M43BK_m43ah = `` 
    this.fat_zanthus_item_qtde_m43ao = 0 
    this.fat_zanthus_item_valor_m43ap = 0
    this.fat_zanthus_m43bk = ``   					    
    this.fat_zanthus_m43ah = `` 
    this.fat_zanthus_Decomp_Insumo = 0 
    this.fat_zanthus_val_liquido = 0 
    this.fat_zanthus_item_valor_desconto_m43aq = 0 
    this.fat_zanthus_qtde = 0;

}

_Db_Pg_script(_stringCommand: string): string{
    const script: string = `Select * from ${f0055_13_faturamento_zanthus_item_crud.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${myTools.format_Date_toStr_ShortDataBase(this?.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this?.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this?.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_item_seq_m43eg:= ${this.fat_zanthus_item_seq_m43eg}
            ,   vfat_zanthus_item_cdbarra_m43ah:= '${this.fat_zanthus_item_cdbarra_m43ah}' 
            ,	vfat_zanthus_item_cdbarra_M43BK_m43ah:= '${this.fat_zanthus_item_cdbarra_M43BK_m43ah}' 
            ,   vfat_zanthus_item_qtde_m43ao:= ${this.fat_zanthus_item_qtde_m43ao}  
            ,   vfat_zanthus_item_valor_m43ap:= ${this.fat_zanthus_item_valor_m43ap}  
            ,   vfat_zanthus_item_valor_desconto_m43aq:= ${this.fat_zanthus_item_valor_desconto_m43aq}  
            ,	vfat_zanthus_M43BK:= '${this.fat_zanthus_m43bk}' 
            ,	vfat_zanthus_Decomp_Insumo:= ${this.fat_zanthus_Decomp_Insumo}
            ,	vfat_zanthus_val_liquido:= ${this.fat_zanthus_val_liquido}
            ,	vfat_zanthus_qtde:= ${this.fat_zanthus_qtde}
        );`
   return script; 

}

async binding(item: any){
        try {
            if (item !== undefined) {
                const data_string = item.fat_zanthus_data_m00af
                this.fat_zanthus_data_m00af = myTools.Date_br_timestamp(data_string?data_string:'1900-01-01')
                this.fat_zanthus_sat_ecf_m00ac = item?.fat_zanthus_sat_ecf_m00ac
                this.fat_zanthus_cupomfiscal_m00ad = item?.fat_zanthus_cupomfiscal_m00ad;
                this.fat_zanthus_item_seq_m43eg = item?.fat_zanthus_item_seq_m43eg;
                this.fat_zanthus_item_cdbarra_m43ah = item?.fat_zanthus_item_cdbarra_m43ah;
                this.fat_zanthus_item_cdbarra_M43BK_m43ah = item?.fat_zanthus_item_cdbarra_m43bk_m43ah;
                this.fat_zanthus_item_qtde_m43ao = item?.fat_zanthus_item_qtde_m43ao
                this.fat_zanthus_item_valor_m43ap = item?.fat_zanthus_item_valor_m43ap; 
                this.fat_zanthus_item_valor_desconto_m43aq = item?.fat_zanthus_item_valor_desconto_m43aq
                this.fat_zanthus_m43bk = item?.fat_zanthus_m43bk;
                this.fat_zanthus_m43ah = item?.fat_zanthus_item_cdbarra_m43ah;
                this.fat_zanthus_Decomp_Insumo = item?.fat_zanthus_decomp_insumo;
                this.fat_zanthus_val_liquido = item?.fat_zanthus_val_liquido;
                this.fat_zanthus_qtde = item?.fat_zanthus_qtde
            }
        } catch(e){
            throw `tbfaturamentozanthus | ${e}`        
        }
    }
}