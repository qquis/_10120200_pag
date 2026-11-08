"use strict";
/*
import model_faturamento from "../model/model_faturamento";
import f0070_20_faturamento_controle_processar from "../scriptdb/pg.f0070_20_faturamento_controle_processar";


import workdb from "../../../database/workdb";

export default class serviceFaturamentoControle {

    static async incluir(itemModelFaturamento : model_faturamento) : Promise<model_faturamento> {
        try {

            

                let sql = `SELECT * from ${f0070_20_faturamento_controle_processar.version()}
                            (
                                vfat_controle_tipo_cd:= ${itemModelFaturamento.faturamento_controle.fat_controle_tipo_cd}
                            ,	vseqfaturamento_uuid:= '${itemModelFaturamento.faturamento_controle.seqfaturamento_uuid}'
                            ,	vop_cdoperacao:= ${itemModelFaturamento.faturamento_controle.op_cdoperacao}
                            ,	vnumeropedido:= ${itemModelFaturamento.faturamento_controle.numeropedido}
                            ,	vdf_nf_seq_blue:= ${itemModelFaturamento.faturamento_controle.df_nf_seq_blue}
                            ,	vsat_ecf:= ${itemModelFaturamento.faturamento_controle.sat_ecf}
                            ,	vcupomfiscal:= ${itemModelFaturamento.faturamento_controle.cupomfiscal}
                            ,	vcdpessoabluesoft_cliente:= ${itemModelFaturamento.faturamento_controle.cdpessoabluesoft_cliente}
                            ) `
                console.log(sql)
                
                await itemModelFaturamento.faturamento_controle.binding(await workdb.pag_DataGet(sql, 0));
                return itemModelFaturamento;
        } catch (e) {
            throw new Error(`service_faturamento_processamento \n Error ${e}`)
        }
    
    }
}*/ 
