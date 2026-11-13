/*  CONSTANTES _________________________________________________________________________________*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M0085 ZANTHUS - Service | CARGA NEW 2026 _ VOUCHER PROMOCIONAL *** "
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
    const FLG_DEBUG_FILE_CONSOLE_LOG_TESTE : string = ``
/*  ____________________________________________________________________________________________*/    




import { clsBase, clsTools } from "../../../model/modelbase";
import tbZanthusTabMercadoriaTipoVenda from "../tbs/tbZanthusTabMercadoriaTipoVenda"


export default class serviceAtualizacaoDadosVoucherPromocional {
    static async start(parametros: any = {}) : Promise<void> {
        let i = 0
        let icount = 0 
        let icountTotal = 0
        let ilimite_reg_bloq_update : number = 200
        let sql = ``

        this.__log(`Iniciando processamento de Voucher Promocional`)
        try {
            /* DADOS DO VOUCHER PROMOCIONAL - GERANDO O CODIGO_________________________________________________________ */
            let data_hoje : Date = new Date()
            let cod_voucher : string = clsTools._datemomentDateToStr(data_hoje,  "YYYYMMDD")
            parametros.cod_voucher = cod_voucher
            this.__log(`Código do voucher gerado: ${parametros.cod_voucher}`)

  
            /* Obtendo lista de mercadorias em promoção________________________________________________________________ */
            let listTabTipoVenda : tbZanthusTabMercadoriaTipoVenda[] = []
          


            /* _____________Lista de mercadorias em promoção___________________________________________________________ */
            listTabTipoVenda = await this.getList(parametros)


            /* _____________Array de códigos de mercadoria em promoção_________________________________________________ */
            let listCodMercadoria : string[] = []
            let stringListCodMercadoria: string = ``
            if (listTabTipoVenda.length > 0) {
                for (const item of listTabTipoVenda) {
                    if (item.tab_pre_cd == 2) {
                        listCodMercadoria.push(`'${item.cod_mercadoria}'`)
                    }
                }
                stringListCodMercadoria = listCodMercadoria.join(',')
            }

            /* _____________Limpar dados Promocionais__________________________________________________________________ */
            this.__log(`Limpeza dos dados promocionais`)            
            this.LimpaDadosTipoVendaPromocional({ ListMercadoriaEmPromocao: stringListCodMercadoria })

            if (listTabTipoVenda.length === 0) {
                await this.__log(`ERROR PROMOCIONAL: Nenhuma mercadoria promocional encontrada `)
                throw new Error(`Nenhuma mercadoria promocional encontrada`)
            }
            

            for await (const item of listTabTipoVenda) {
                
                listCodMercadoria.push(`'${item.cod_mercadoria}'`)
                
                sql += item.ZanthusPostGre_CRUD() 
                i++
                icount++
                if (i >= ilimite_reg_bloq_update) {
                    await this.__log(`Atualizando TabTipoVenda - ${icount} / ${icountTotal} registros processados...`)
                    await this.__dbExecuteZanthus(sql)
                    sql = ``
                    i = 0
                }
            }
            if (sql !== ``) {
                await this.__dbExecuteZanthus(sql)
            }


            /* _____________CRIANDO O VOUCHER PROMOCIONAL NA BASE ZANTHUS_________________________________________________ */
            await this.__log(`Iniciando criação do voucher promocional na base Zanthus`)
            await this.__dbExecuteZanthus(this.ScriptProcessarDadosPromocionais(parametros))
            await this.__log(`Finalizada criação do voucher promocional na base Zanthus`)


        } catch (e) {
            await clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
        }
    }


    private static async getList(parametro: any) {
        let listTabTipoVenda : tbZanthusTabMercadoriaTipoVenda[] = []
        try {

            this.__log(`Obtendo lista de mercadorias promocionais`)
            let result : any = await this.__dbGet(this.ScriptListPromocional(parametro))

            for await ( const[key, value] of Object.entries(result)) {
                let itemTbZanthusTabMercadoriaTipoVenda : tbZanthusTabMercadoriaTipoVenda = new tbZanthusTabMercadoriaTipoVenda()
                itemTbZanthusTabMercadoriaTipoVenda.binding(value)
                listTabTipoVenda.push(itemTbZanthusTabMercadoriaTipoVenda)
                
            }
            if (listTabTipoVenda.length === 0) {
                this.__log(`Nenhuma mercadoria promocional encontrada`)
            } else {
                this.__log(`Total de mercadorias promocionais encontradas: ${listTabTipoVenda.length}`)
            }

        } catch (e) {
            await clsTools.PagErrorException(`M0085_Zanthus`, `serviceAtualizacao.Dados.TipoVenda | getList`, e);
        }
        finally {
            return listTabTipoVenda
        }  
         
    }    


    private static async LimpaDadosTipoVendaPromocional(parametro: any) {
        try { 
            
            await this.__log(`Iniciando limpeza dos dados de TipoVenda Promocional`)

            let sql_delete = `delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2; 
                                delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2; `
                        

            if (parametro.ListMercadoriaEmPromocao && parametro.ListMercadoriaEmPromocao.length > 0) {
                await this.__log(`Uma vez que foram encontrados produtos promocionais, na base PAG/PRIME, será realizada apenas a exclusão dos produtos que não estão mais em promoção`)
                sql_delete = `  delete from tab_mercadoria_tipo_venda where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); 
                                delete from tab_mercadoria_tipo_venda_qtde where cod_tipo_venda = 2 and cod_mercadoria not in(${parametro.ListMercadoriaEmPromocao}); 
                                `
            }
            await this.__dbExecuteZanthus(sql_delete)
            

        } catch (e) {
            await this.__error(`Erro na LimpaDadosTipoVendaPromocional`, e);
        }
    }


    private static ScriptListPromocional(parametro: any = {}) : string {
         let sqlscript : string = `` 
        sqlscript =   
                `select 	a.tab_pre_cd 
                        ,	a.pr_cdproduto				
                        ,	a.prb_cdprodutobluesoft						
                        ,	a.preg_cdbarra								
                        ,	a.cod_loja 									
                        ,	a.controle 									
                        ,	a.cod_mercadoria
                        ,	a.cod_tipo_venda 
                        ,	a.usuario 
                        ,	a.data_cadastro 
                        ,	coalesce(a.data_ultima_alteracao, current_timestamp) as data_ultima_alteracao
                        ,	a.preco_unitario 
                        ,	a.percentual_comissao_vendedor
                        ,   coalesce(a.preco_anterior,0) as preco_anterior
                from 		tbzanthustab_mercadoria_tipo_venda a
                inner join  tbzanthustab_mercadoria  		   me on me.pr_cdproduto = a.pr_cdproduto 
                                                                 and me.prb_cdprodutobluesoft = a.prb_cdprodutobluesoft 
                                                                 and me.cod_mercadoria = a.cod_mercadoria
                inner join  tbproduto 						   pr on pr.pr_cdproduto = me.pr_cdproduto 												
                where		1 = 1 
                  and       a.tab_pre_cd = 2
                `
                
        return sqlscript;

    }


    private static ScriptProcessarDadosPromocionais(parametro: any) : string {

            let sql =  ` 

                DELETE FROM tab_voucher_promocional_prod WHERE cod_voucher = '${parametro.cod_voucher}'
                ;

                INSERT INTO tab_voucher_promocional 
                    (
                            cod_voucher
                        ,	descricao_parceiro
                        ,	validade_inicial 
                        ,	validade_final
                        ,	minimo_venda
                        ,	tipo_desconto 
                        ,	tipo_utilizacao 
                        ,	tipo_aplicacao 
                        ,	valor_aplicacao
                        ,	flg_status --- >> 0 
                        ,	flg_ativo
                        ,	Dth_inclusao 
                        ,	Dth_alteracao 
                        ,	Idt_usuario_alteracao 
                        ,	limite_utilizacao 
                        ,	limite_utilizado 
                        ,	tipo_comportamento 
                        ,	limite_por_cliente
                        ,	cod_voucher_alternativo
                        ,	flg_fornecedor
                        ,	flags_manager
                        ,	tipo_venda 
                    )

                select		'${parametro.cod_voucher}'                           as cod_voucher				 
                        ,	'PROMOCAO DIA '  || '${parametro.cod_voucher}'     as descricao_parceiro		
                        ,	current_date                             as validade_inicial 		 
                        ,	current_date                             as validade_final			 
                        ,	1.00                                     as minimo_venda			 
                        ,	1                                        as tipo_desconto 			 
                        ,	0                                        as tipo_utilizacao			 
                        ,	1                                        as tipo_aplicacao			 
                        ,	NULL                                     as valor_aplicacao			 
                        ,	0                                        as flg_status				 
                        ,	'S'                                      as flg_ativo				 
                        ,	current_timestamp                        as Dth_inclusao			 
                        ,	current_timestamp                        as Dth_alteracao			     
                        ,	100                                      as Idt_usuario_alteracao	 
                        ,	0                                        as limite_utilizacao		     
                        ,	NULL                                     as limite_utilizado		     
                        ,	2                                        as tipo_comportamento		         
                        ,	0                                        as limite_por_cliente		         
                        ,	NULL                                     as cod_voucher_alternativo          
                        ,	'N'                                      as flg_fornecedor			         
                        ,	NULL                                     as flags_manager			             
                        ,	1                                        as tipo_venda				                         
                    WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional  WHERE cod_voucher  = '${parametro.cod_voucher}')
                ;

                INSERT INTO tab_voucher_promocional_prod
                        (
                                cod_voucher 
                            ,	cod_produto 
                            ,	qtd_maxima 
                            ,	tipo_aplicacao 
                            ,	valor_aplicacao 
                            ,	flg_ativo 
                            ,	Dth_inclusao 
                            ,	Dth_alteracao 
                            ,	Idt_usuario_alteracao 
                        )
                    select		
                                    '${parametro.cod_voucher}'                                                 as cod_voucher				 
                                ,	m.cod_mercadoria                                               as cod_produto				 
                                ,	0                                                              as qtd_maxima				     
                                ,	1                                                              as tipo_aplicacao			 
                                ,	cast(v1.preco_unitario - v2.preco_unitario as numeric(13,2))   as valor_aplicacao			 
                                ,	'S'                                                            as flg_ativo				 
                                ,	current_timestamp                                              as Dth_inclusao			  
                                ,	current_timestamp                                              as Dth_alteracao			     
                                ,	current_timestamp                                              as Idt_usuario_alteracao	     
                    from		tab_mercadoria				m
                    left join	tab_mercadoria_tipo_venda	v1 on v1.cod_mercadoria = m.cod_mercadoria and v1.cod_tipo_venda = '1'
                    left join   tab_mercadoria_tipo_venda	v2 on v2.cod_mercadoria = m.cod_mercadoria and v2.cod_tipo_venda = '2'
                    where		1 = 1
                    and		    cast(v1.preco_unitario as numeric(13,2)) > cast(v2.preco_unitario as numeric(13,2))

                ;
                
                INSERT INTO tab_voucher_promocional_loja
                        ( cod_voucher, cod_loja , flg_ativo, Dth_inclusao, Dth_alteracao, Idt_usuario_alteracao )
                        select '${parametro.cod_voucher}', 1, 'S', current_date, current_date, 100  
                                WHERE NOT EXISTS (SELECT 1 FROM tab_voucher_promocional_loja  WHERE cod_voucher = '${parametro.cod_voucher}')
                ;
                
                ` 

                return sql 
    }

    private static async __dbGet(sql: string) : Promise<any> {
        let result: any;
        try { 
                let myClsBase : clsBase = new clsBase()
                result = await myClsBase.myDataBase.pag.DataGet(sql) 
                

        } catch (e) {
            
            await this.__error(`Erro ao executar query: ${sql}`, e)
            
        }
        finally {
            return result
        }
    }

    private static async __dbExecute(sql: string) : Promise<void> {
        try {
            let myClsBase : clsBase = new clsBase()
            await myClsBase.myDataBase.pag.Execute(sql)
        } catch (e) {
            await this.__error(`Erro ao executar query na base Zanthus: ${sql}`, e)
        }
    }

    private static async __dbExecuteZanthus(sql: string) : Promise<void> {
        try {
            let myClsBase : clsBase = new clsBase()
            await myClsBase.myDataBase.zanthusPostgre.Execute(sql)
        } catch (e) {
            await this.__error(`Erro ao executar query na base Zanthus: ${sql}`, e)
        }
    }

    private static async __error(message: string, e: any) {
        await clsTools.PagErrorException(FLG_MODULO, message, e);
    }
    private static async __log(message: string) {
        await clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG)
    }
}

