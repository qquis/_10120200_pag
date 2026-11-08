

import { ifilter_faturamento } from '../wk'

import myTools from '../../../tools/Tools';
import {modelTb} from '../../../model/model'


import f0055_10_faturamentozanthus_ctrl from '../scriptspg/f0055_10_faturamentozanthus_ctrl'
import f0055_60_faturamento_cupom_processamento from '../scriptspg/f0055_60_faturamento_cupom_processamento'

import tbfaturamentozanthus from './tbfaturamentozanthus'
import tbfaturamentozanthusitem from './tbfaturamentozanthusitem'

import Zanthus_Cupom from "../scriptsql/Zanthus_Cupom"
import Zanthus_CupomItem from "../scriptsql/Zanthus_CupomItem"


export default class tbfaturamentozanthus_ctrl extends modelTb {
    My_List_Cupom: Array<tbfaturamentozanthus>
    My_List_Cupom_Item: Array<tbfaturamentozanthusitem>
    dtlog_insert: Date
    dtlog_update: Date 
    fat_zanthus_sat_ecf_m00ac: number
    fat_zanthus_data_m00af: Date
    fz_cupom_qtde: number
    fz_cupom_inicial: number
    fz_cupom_final: number
    fz_valor: number
    fz_pag_cupom_qtde: number
    fz_pag_cupom_inicial: number
    fz_pag_cupom_final: number
    fz_pag_valor: number

    fat_cupom_qtde : number 
    fat_cupom_inicial : number
    fat_cupom_final : number
    fat_valor : number


public constructor() 
{
    super()
    this.dtlog_insert = new Date(); 
    this.dtlog_update = new Date(); 
    this.fat_zanthus_sat_ecf_m00ac = 0
    this.fat_zanthus_data_m00af = new Date();  
    this.fz_cupom_qtde = 0 
    this.fz_cupom_inicial = 0
    this.fz_cupom_final= 0
    this.fz_valor = 0
    this.fz_pag_cupom_qtde= 0 
    this.fz_pag_cupom_inicial = 0
    this.fz_pag_cupom_final = 0
    this.fz_pag_valor = 0

    this.fat_cupom_qtde = 0
    this.fat_cupom_inicial = 0
    this.fat_cupom_final = 0
    this.fat_valor = 0;


    this.My_List_Cupom = []
    this.My_List_Cupom_Item = []

}

_Db_Pg_script (_stringCommandExecute: string): string
{
    let script: string = `` 
    script = `Select * from ${f0055_10_faturamentozanthus_ctrl.sqlScript_VERSION()}
    (           sqlcommand:= '${_stringCommandExecute}'
            ,	vfat_zanthus_sat_ecf_m00ac:= ${this?.fat_zanthus_sat_ecf_m00ac}
            ,	vfat_zanthus_data_m00af:= '${myTools.format_Date_toStr_ShortDataBase(this?.fat_zanthus_data_m00af)}'
            ,	vfz_cupom_qtde:= ${this?.fz_cupom_qtde}
            ,	vfz_cupom_inicial:=	${this?.fz_cupom_inicial}
            ,	vfz_cupom_final:= ${this?.fz_cupom_final}
            ,	vfz_valor:= ${this?.fz_valor}
            ,	vfz_pag_cupom_qtde:= ${this?.fz_pag_cupom_qtde}
            ,	vfz_pag_cupom_inicial:=	${this?.fz_pag_cupom_inicial}
            ,	vfz_pag_cupom_final:= ${this?.fz_pag_cupom_final}
            ,	vfz_pag_valor:= ${this?.fz_pag_valor}
        )`
        return script; 
        
        
}

async binding(item: any)
{

    try {
        if (item !== undefined) {

            //console.log(`DATA SELECIONADA ${new Date(item.fat_zanthus_data_m00af).toLocaleDateString()} FORMATADA: ${Tools.Date_br_new(`${new Date(item.fat_zanthus_data_m00af).toLocaleDateString()}`)}`)
            
            this.fat_zanthus_sat_ecf_m00ac = item.fat_zanthus_sat_ecf_m00ac
            const data_string = item.fat_zanthus_data_m00af
            this.fat_zanthus_data_m00af = myTools.Date_br_timestamp(data_string)
            this.fz_cupom_qtde = item.fz_cupom_qtde
            this.fz_cupom_inicial = item.fz_cupom_inicial
            this.fz_cupom_final= item.fz_cupom_final
            this.fz_valor = item.fz_valor
            this.fz_pag_cupom_qtde= item.fz_pag_cupom_qtde
            this.fz_pag_cupom_inicial = item.fz_pag_cupom_inicial
            this.fz_pag_cupom_final = item.fz_pag_cupom_final
            this.fz_pag_valor = item.fz_pag_valor

            this.fat_cupom_qtde = item.fat_cupom_qtde; 
            this.fat_cupom_inicial = item.fat_cupom_inicial;
            this.fat_cupom_final = item.fat_cupom_final;
            this.fat_valor = item?.fat_valor;

            //console.log(`Data ITEM ${item.fat_zanthus_data_m00af} - X - Data Objeto ${this.fat_zanthus_data_m00af}`)
        }
    } catch(e){
        throw `tbnotificacao_send | ${e}`        
    }

}




}