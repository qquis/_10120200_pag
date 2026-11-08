import f0055_12_faturamento_zanthus_crud from '../scriptspg/f0055_12_faturamento_zanthus'
import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'



export default class tbfaturamentozanthus extends modelTb {
    dtlog_insert: Date
    dtlog_update: Date
    fat_zanthus_seq: number
    fat_zanthus_data_m00af:Date 
    fat_zanthus_sat_ecf_m00ac:number
    fat_zanthus_cupomfiscal_m00ad:number
    fat_zanthus_cupomfiscalid_M00_id_unico: string
    fat_zanthus_cupomfiscal_cancelado_m45bo:number
    fat_zanthus_notafiscal_numnota: number
    fat_zanthus_notafiscal_serie_nf: number
    fat_zanthus_notafiscal_chave_m45xb: String   
    fat_zanthus_status_cancelado: number
    fat_zanthus_cpf_cnpj_m45bv: String 
    fat_zanthus_hora_ini_m45ai:Date
    fat_zanthus_hora_fim_m45au:Date 
    fat_zanthus_cupomfiscal_valor_m45ak:number
    fat_zanthus_cod_funcionario_m45ah:number
    fat_zanthus_voucher_cod_m50ar: String    
    fat_zanthus_voucher_valor_m50at:number
    fat_zanthus_voucher_count_m50ag:number
    fat_zanthus_conferencia: number
    fat_zanthus_processado: number  
    fat_zanthus_pag: number 
    tiponota: number	

public constructor() 
{
    super()
    this.dtlog_insert =  new Date('1900-01-01')
    this.dtlog_update =  new Date('1900-01-01')
    this.fat_zanthus_seq = 0
    this.fat_zanthus_data_m00af = new Date('1900-01-01')
    this.fat_zanthus_sat_ecf_m00ac = 0
    this.fat_zanthus_cupomfiscal_m00ad = 0
    this.fat_zanthus_cupomfiscalid_M00_id_unico =  ``
    this.fat_zanthus_cupomfiscal_cancelado_m45bo = 0 
    this.fat_zanthus_notafiscal_numnota = 0
    this.fat_zanthus_notafiscal_serie_nf = 0 
    this.fat_zanthus_notafiscal_chave_m45xb = `` 
    this.fat_zanthus_status_cancelado = 0 
    this.fat_zanthus_cpf_cnpj_m45bv = `` 
    this.fat_zanthus_hora_ini_m45ai = new Date(`1900-01-01`)
    this.fat_zanthus_hora_fim_m45au = new Date(`1900-01-01`)
    this.fat_zanthus_cupomfiscal_valor_m45ak = 0 
    this.fat_zanthus_cod_funcionario_m45ah = 0 
    this.fat_zanthus_voucher_cod_m50ar = `` 
    this.fat_zanthus_voucher_valor_m50at = 0 
    this.fat_zanthus_voucher_count_m50ag = 0 
    this.fat_zanthus_conferencia = 0 
    this.fat_zanthus_processado = 0  
    this.fat_zanthus_pag = 0  		
    this.tiponota = 0
}

_Db_Pg_script(_stringCommand: string): string{

    const script: string = `Select * from ${f0055_12_faturamento_zanthus_crud.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommand}'
            ,	vfat_zanthus_data_m00af:= '${myTools.format_Date_toStr_ShortDataBase(this?.fat_zanthus_data_m00af)}'        
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this?.fat_zanthus_sat_ecf_m00ac}
            ,   vfat_zanthus_cupomfiscal_m00ad:= ${this?.fat_zanthus_cupomfiscal_m00ad}
            ,   vfat_zanthus_cupomfiscalid_M00_id_unico:= '${this?.fat_zanthus_cupomfiscalid_M00_id_unico}'
            ,   vfat_zanthus_cupomfiscal_cancelado_m45bo:= ${this?.fat_zanthus_cupomfiscal_cancelado_m45bo}
            ,   vfat_zanthus_notafiscal_numnota:= ${this?.fat_zanthus_notafiscal_numnota}
            ,   vfat_zanthus_notafiscal_serie_nf:= ${this?.fat_zanthus_notafiscal_serie_nf}
            ,   vfat_zanthus_notafiscal_chave_m45xb:= '${this?.fat_zanthus_notafiscal_chave_m45xb}'
            ,   vfat_zanthus_status_cancelado:= ${this?.fat_zanthus_status_cancelado}
            ,   vfat_zanthus_cpf_cnpj_m45bv:= '${this?.fat_zanthus_cpf_cnpj_m45bv}'
            ,   vfat_zanthus_hora_ini_m45ai:= '${this?.fat_zanthus_hora_ini_m45ai}'
            ,   vfat_zanthus_hora_fim_m45au:= '${this?.fat_zanthus_hora_fim_m45au}'
            ,   vfat_zanthus_cupomfiscal_valor_m45ak:= ${this?.fat_zanthus_cupomfiscal_valor_m45ak}
            ,   vfat_zanthus_cod_funcionario_m45ah:= ${this?.fat_zanthus_cod_funcionario_m45ah}
            ,   vfat_zanthus_voucher_cod_m50ar:= '${this?.fat_zanthus_voucher_cod_m50ar}'
            ,   vfat_zanthus_voucher_valor_m50at:= ${this?.fat_zanthus_voucher_valor_m50at}
            ,   vfat_zanthus_voucher_count_m50ag:= ${this?.fat_zanthus_voucher_count_m50ag}
            ,   vfat_zanthus_conferencia:= ${this?.fat_zanthus_conferencia}
            ,   vfat_zanthus_processado:= ${this?.fat_zanthus_processado}
            ,   vfat_zanthus_pag:= ${this?.fat_zanthus_pag}
            ,   vtiponota:= ${this?.tiponota}
        ); `
   return script; 

}

async binding(item: any){
        try {
            if (item !== undefined) {


                //console.log(`Fat ZANTHUS PAG ${item?.fat_zanthus_pag}`)

                const data_string = item.fat_zanthus_data_m00af
                this.fat_zanthus_data_m00af = myTools.Date_br_timestamp(data_string?data_string:'1900-01-01')
                this.fat_zanthus_sat_ecf_m00ac = item?.fat_zanthus_sat_ecf_m00ac
                this.fat_zanthus_cupomfiscal_m00ad = item?.fat_zanthus_cupomfiscal_m00ad;
                this.fat_zanthus_cupomfiscalid_M00_id_unico =  item?.fat_zanthus_cupomfiscalid_M00_id_unico;
                this.fat_zanthus_cupomfiscal_cancelado_m45bo = item?.fat_zanthus_cupomfiscal_cancelado_m45bo;
                this.fat_zanthus_notafiscal_numnota = item?.fat_zanthus_notafiscal_numnota;
                this.fat_zanthus_notafiscal_serie_nf = item?.fat_zanthus_notafiscal_serie_nf;
                this.fat_zanthus_notafiscal_chave_m45xb = item?.fat_zanthus_notafiscal_chave_m45xb;
                this.fat_zanthus_status_cancelado = item?.fat_zanthus_status_cancelado;
                this.fat_zanthus_cpf_cnpj_m45bv = item?.fat_zanthus_cpf_cnpj_m45bv;
                this.fat_zanthus_hora_ini_m45ai = item?.fat_zanthus_hora_ini_m45ai;
                this.fat_zanthus_hora_fim_m45au = item?.fat_zanthus_hora_fim_m45au;
                this.fat_zanthus_cupomfiscal_valor_m45ak = item?.fat_zanthus_cupomfiscal_valor_m45ak;
                this.fat_zanthus_cod_funcionario_m45ah = item?.fat_zanthus_cod_funcionario_m45ah; 
                this.fat_zanthus_voucher_cod_m50ar = item?.fat_zanthus_voucher_cod_m50ar
                this.fat_zanthus_voucher_valor_m50at = item?.fat_zanthus_voucher_valor_m50at 
                this.fat_zanthus_voucher_count_m50ag = item?.fat_zanthus_voucher_count_m50ag
                this.fat_zanthus_conferencia = item?.fat_zanthus_conferencia
                this.fat_zanthus_processado = item?.fat_zanthus_processado 
                this.fat_zanthus_pag = item?.fat_zanthus_pag
                this.tiponota = item?.tiponota
            }
        } catch(e){
            throw `tbfaturamentozanthus | ${e}`        
        }
    }
}