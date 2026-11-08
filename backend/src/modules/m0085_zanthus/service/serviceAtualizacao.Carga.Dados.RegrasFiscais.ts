/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ TABREGRASFISCAIS (JS ServiceAtualizacao.tabRegrasFiscais)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabRegraFiscal from "../tbs/tbZanthusTabRegraIcms";


export default class serviceZanthusAtualizacaoDadosRegraFiscal
  {


    static async start (parametro: any) {

        let i = 0
             let icount = 0 
             let icountTotal = 0
             let ilimite_reg_bloq_update : number = 200
             let sql = ``
    
             try {
                let myclsBase : clsBase = new clsBase()
    
    
                await clsTools.pagConsole(`${FLG_MODULO} | Iniciando processamento ${parametro?.carga_uuid !== '' ? `| Código da Carga ${parametro.carga_uuid}` : ''}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)    

    
                let listTabREGRAICMS = await this.getList(parametro)
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizando TabRegrasIcms Total de itens para processamento: ${listTabREGRAICMS.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    
    
                i = 0
                icount = 0 
                icountTotal = listTabREGRAICMS.length
                ilimite_reg_bloq_update =  myclsBase.myDataBase.MAX_UPDATE_DEFAULT
                sql = ``
    
                clsTools.pagConsole(`${FLG_MODULO} | Atualização TabRegrasIcms MAX UPDATE: ${ilimite_reg_bloq_update} registros por bloco...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)


                for await (const item of listTabREGRAICMS) {
                    
                    sql += item.ZanthusPostGre_CRUD() 
                    i++
                    icount++
                    if (i >= ilimite_reg_bloq_update) {
                        await clsTools.pagConsole(`${FLG_MODULO} | Atualizando  atualizaTabRegrasIcms | - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)

                        await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                        sql = ``
                        i = 0
                    }
                }
            
            if (sql !== ``) {
                await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
            }
    
                if (sql !== ``) {
                    await myclsBase.myDataBase.zanthusPostgre.Execute(sql)
                }
    
            } catch (e) {
                await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO Tab Regra ICMS', e);
            }
            finally {
                await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao Tab Regra ICMS finalizada - ${icount} / ${icountTotal} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
    }

    static async getList(parametro: any) {
        let listTAB_REGRA_ICMS: tbZanthusTabRegraFiscal[] = []
        try { 
                let myDataBase: clsBase = new clsBase()



                let resultTabRegraIcms = await myDataBase.myDataBase.pag.DataGet(this.scriptSql(parametro))


            for await ( const[key, value] of Object.entries(resultTabRegraIcms)) {
                let itemTbZanthusTab_Mercadoria : tbZanthusTabRegraFiscal = new tbZanthusTabRegraFiscal()
                itemTbZanthusTab_Mercadoria.binding(value)
                listTAB_REGRA_ICMS.push(itemTbZanthusTab_Mercadoria)

                if (process.env.ZANTHUS_TIPO_CARGA_LOG && process.env.ZANTHUS_TIPO_CARGA_LOG == "1") {
                   await clsTools.pagConsole(`${FLG_MODULO} | Produto: ${itemTbZanthusTab_Mercadoria.pr_cdproduto} - ${itemTbZanthusTab_Mercadoria.descricao}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG_TESTE)
                }
                
            }

            
         } catch (e) {
             await clsTools.PagErrorException(FLG_MODULO, 'MÉTODO getList', e);
         }

         finally {
             await clsTools.pagConsole(`${FLG_MODULO} | Atualizacao - ${listTAB_REGRA_ICMS.length} registros processados...`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
             return listTAB_REGRA_ICMS;
         }
    }

    static scriptSql (parametro: any) { 
        let sqlscript : string = `` 
        sqlscript =    ` select     a.pr_cdproduto
                                ,   a.prb_cdprodutobluesoft
                                ,   a.cod_regras_icms             as  cod_regras_icms
                                ,	a.cod_loja 
                                ,	a.descricao 
                                ,	a.prioridade 
                                ,	a.flg_registro 
                                ,	a.cod_ncm_ini                 as  cod_ncm_ini
                                ,	a.cod_ncm_fim                 as  cod_ncm_final
                                ,	a.cod_mercadoria 
                                ,	a.uf_origem 
                                ,	a.uf_destino 
                                ,	coalesce(a.aliquota,0) as aliquota
                                ,	a.cst
                                ,	a.perc_substituicao 
                                ,	coalesce(a.perc_reducao,0) as perc_reducao 
                                ,	a.flg_tipo_imposto 
                                ,	a.flg_revenda 
                                ,	a.dta_val_inicial 
                                ,	a.dta_val_final 
                                ,	a.cst_orig
                                ,	a.usuario 
                                ,	a.data_cadastro 
                                ,	a.data_ultima_alteracao 
                                ,	a.aliquota_interestadual 
                                ,	a.valor_imposto 
                                ,	a.tipo_lista_st 
                                ,	a.perc_reducao_st 
                                ,	a.perc_diferimento 
                                ,	a.exigibilidade_iss 
                                ,	a.flg_incentivo_fiscal_iss 
                                ,	a.tipo_documento
                                ,   a.codigo_beneficio_fiscal
                                ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                                ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                                ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 `


                if (parametro.cod_mercadoria && parametro.cod_mercadoria != '') {
                    sqlscript += ` and me.cod_mercadoria = '${parametro.cod_mercadoria}' `
                }

                if (parametro.carga_uuid && parametro.carga_uuid != '') {
                    sqlscript += ` and  me.cod_mercadoria in (select cod_mercadoria from tbzanthus_carga_produto where carga_uuid = '${parametro.carga_uuid}') `
                }


                sqlscript += ` UNION `

                /* PRODUTOS CESTA */
                sqlscript += `select     a.pr_cdproduto
                                ,   a.prb_cdprodutobluesoft
                                ,   a.cod_regras_icms             as  cod_regras_icms
                                ,	a.cod_loja 
                                ,	a.descricao 
                                ,	a.prioridade 
                                ,	a.flg_registro 
                                ,	a.cod_ncm_ini                 as  cod_ncm_ini
                                ,	a.cod_ncm_fim                 as  cod_ncm_final
                                ,	a.cod_mercadoria 
                                ,	a.uf_origem 
                                ,	a.uf_destino 
                                ,	coalesce(a.aliquota,0) as aliquota
                                ,	a.cst
                                ,	a.perc_substituicao 
                                ,	coalesce(a.perc_reducao,0) as perc_reducao 
                                ,	a.flg_tipo_imposto 
                                ,	a.flg_revenda 
                                ,	a.dta_val_inicial 
                                ,	a.dta_val_final 
                                ,	a.cst_orig
                                ,	a.usuario 
                                ,	a.data_cadastro 
                                ,	a.data_ultima_alteracao 
                                ,	a.aliquota_interestadual 
                                ,	a.valor_imposto 
                                ,	a.tipo_lista_st 
                                ,	a.perc_reducao_st 
                                ,	a.perc_diferimento 
                                ,	a.exigibilidade_iss 
                                ,	a.flg_incentivo_fiscal_iss 
                                ,	a.tipo_documento
                                ,   a.codigo_beneficio_fiscal
                                ,   coalesce(a.cod_class_tributaria,0) as cod_class_tributaria
                                ,   coalesce(a.per_cred_presumido_ibs_mono,0) as per_cred_presumido_ibs_mono
                                ,   coalesce(a.per_cred_presumido_cbs_mono,0) as per_cred_presumido_cbs_mono
                from 		tbzanthustab_regra_icms            a
										
                where		1 = 1 
                  and       a.cod_mercadoria in (select cod_insumo from TbZanthustab_produto_decomposicao_insum)
                
                `


        return sqlscript;
    }

}