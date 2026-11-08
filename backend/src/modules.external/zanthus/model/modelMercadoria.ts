import { Console } from "console";
import { clsBase, clsTools } from "../../../model/modelbase";
export default class modelZanthusMercadoria  { 

    async getinfoAllMercadoria(cod_mercadoria: string) : Promise<any> {

        let mercadoriaInfoAll : any = {}
        
        try {

            mercadoriaInfoAll = await this.getMercadoria(cod_mercadoria)
            if (mercadoriaInfoAll) {
                mercadoriaInfoAll.regrasIcms = []
                mercadoriaInfoAll.regrasIcms = await this.getRegraICMS(cod_mercadoria)

                mercadoriaInfoAll.tipoVenda = []
                mercadoriaInfoAll.tipoVenda = await this.gettipoVenda(cod_mercadoria)

                mercadoriaInfoAll.voucherList = []
                mercadoriaInfoAll.voucherList = await this.getVoucherList(cod_mercadoria)   
                
                mercadoriaInfoAll.composicao = {}
                mercadoriaInfoAll.composicao = await this.getComposicao(cod_mercadoria)
            }
     


        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.getinfoAllMercadoria
                                Error:
                                ${e}    
                                `);
            throw e
        }
        finally {
            
            return mercadoriaInfoAll
        }
    }
    
    
    async getMercadoria (cod_mercadoria: string) : Promise<any> {
        let mercadoriaInfoAll : any = {}
        
        try {
        let mDataBase : clsBase = new clsBase()
   

                   let sql = `
          select       m.cod_mercadoria
                    ,	m.descricao 
                    ,	m.descricao_abr
                    ,	m.cod_departamento

                    ,	m.data_cadastro
                    ,	m.data_ultima_alteracao 


                    ,	m.cfop 
                    ,	m.cod_tributacao_mercadoria 

                    ,	m.cod_situacao_tributaria 
                    ,	m.aliquota_icms
                    ,	m.percentual_reduz_b_calculo


                    ,	m.cod_sit_trib_pis
                    ,	m.aliquota_pis
	                ,	m.perc_reduz_b_calculo_pis                    

                    ,	m.cod_sit_trib_cofins
                    ,	m.aliquota_cofins
                    ,   m.perc_reduz_b_calculo_cofins

                    ,	m.cod_sit_tributaria_ibs_cbs
                    ,	m.cod_class_tributaria_is
                    ,	m.cod_class_tributaria_ibs_cbs
                    ,	m.per_aliquota_is
                    ,	m.per_aliquota_is_especifica 
                    ,	m.per_aliquota_ibs_uf
                    ,	m.per_reducao_aliquota_ibs_uf
                    ,	m.per_diferimento_ibs_uf 
                    ,	m.per_aliquota_ibs_mun 
                    ,	m.per_reducao_aliquota_ibs_mun 
                    ,	m.per_diferimento_ibs_mun 
                    ,	m.per_aliquota_cbs 
                    ,	m.per_diferimento_cbs
                    ,	m.per_reducao_aliquota_cbs
                    ,	m.per_cred_presumido_ibs_mono 
                    ,	m.per_cred_presumido_cbs_mono 
                    ,	m.origem_cadastro     
                    ,   m.codigo_beneficio_fiscal             
	
            from 	tab_mercadoria m
            WHERE       1 = 1   
            AND m.cod_mercadoria = lpad('${cod_mercadoria}', 17, '0')`

            mercadoriaInfoAll = await mDataBase.myDataBase.RecordItem(await mDataBase.myDataBase.zanthusPostgre.DataGet(sql), 0) 



        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.getinfoAllMercadoria
                                Error:
                                ${e}    
                                `);
            throw e
        }
        finally {
            return mercadoriaInfoAll
        }

    }

    async getRegraICMS (cod_mercadoria: string) : Promise<any> {
        let listregraICMS : any = []
        
        try {
            let mDataBase : clsBase = new clsBase()
            let sql = `select 
                                 cod_regras_icms
                            ,    descricao
                            ,    flg_tipo_imposto
                            ,    flg_revenda
                            ,    cod_ncm_ini
                            ,    cod_ncm_final
                            ,    uf_origem
                            ,    uf_destino
                            ,    aliquota
                            ,    cst
                            ,   perc_reducao 
                            ,   data_cadastro
                            ,   data_ultima_alteracao
                        
                        from tab_regras_icms 
                        where 1 = 1
                        AND cod_mercadoria = lpad('${cod_mercadoria}', 17, '0')
                        order by flg_revenda, flg_tipo_imposto asc`
            listregraICMS = await mDataBase.myDataBase.zanthusPostgre.DataGet(sql)
        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.getRegraICMS
                                Error:
                                ${e}    
                                `);
            throw e
        } finally {
            return listregraICMS
        }

                
    }

    async gettipoVenda (cod_mercadoria: string) : Promise<any> {
        let listregraICMS : any = []
        
        try {
            let mDataBase : clsBase = new clsBase()
            let sql = `select 	m.cod_mercadoria
                        , 		m.cod_tipo_venda
                        , 		m.preco_unitario
                        , 		m.preco_anterior
                        , 		m.data_cadastro
                        , 		m.data_ultima_alteracao 
                        from tab_mercadoria_tipo_venda m
                        where 1 = 1
                        AND m.cod_mercadoria = lpad('${cod_mercadoria}', 17, '0')
                        order by m.cod_tipo_venda asc`
            listregraICMS = await mDataBase.myDataBase.zanthusPostgre.DataGet(sql)
        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.gettipoVenda
                                Error:
                                ${e}    
                                `);
            throw e
        } finally {
            return listregraICMS
        }

                
    }

    async getVoucherList (cod_mercadoria: string) : Promise<any> {
 
        let itemVoucherList : any = []
        
        try {
            let mDataBase : clsBase = new clsBase()
            let sql = `select  	v.cod_voucher
                                ,	v.descricao_parceiro 
                                ,	v.validade_inicial
                                ,	v.validade_final
                                ,	v.minimo_venda 
                                ,	v.tipo_desconto
                                ,	v.tipo_utilizacao
                                ,	v.tipo_aplicacao 
                                
                                ,	vp.cod_produto
                                ,	vp.qtd_maxima
                                ,	vp.tipo_aplicacao 
                                ,	vp.valor_aplicacao 
                                ,	vp.dth_inclusao 
                                ,	vp.dth_alteracao 
                        from		tab_voucher_promocional_prod vp
                        inner join 	tab_voucher_promocional v on v.cod_voucher = vp.cod_voucher
                        where   1 = 1
                        AND     vp.cod_produto = lpad('${cod_mercadoria}', 17, '0')
                        order by v.cod_voucher DESC
                        LIMIT 3
                        `
            itemVoucherList = await mDataBase.myDataBase.zanthusPostgre.DataGet(sql)
        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.getVoucher
                                Error:
                                ${e}    
                                `);
            throw e
        } finally {
            return itemVoucherList
        }
    }

    async getComposicao(cod_mercadoria: string) : Promise<any> {
     let itemComposicao : any = []
     itemComposicao.itens = []
        
        try {
            let mDataBase : clsBase = new clsBase()
            let sql = `select 		c.cod_mercadoria 
                                ,	c.forma_decomposicao 
                                ,	c.tipo_decomposicao 
                                ,	c.data_cadastro
                                ,	c.data_ultima_alteracao 
                        from tab_produto_decomposicao c
                        where   1 = 1
                        AND     c.cod_mercadoria = lpad('${cod_mercadoria}', 17, '0')
                        `
            itemComposicao = await mDataBase.myDataBase.RecordItem(await mDataBase.myDataBase.zanthusPostgre.DataGet(sql), 0)


            let sqlinsumo = `select i.cod_mercadoria 
                                ,	i.cod_insumo 
                                ,	i.percentual_insumo 
                                ,	i.quantidade_insumo 
                                ,	i.preco_unitario_insumo 
                                ,	i.data_cadastro 
                                ,	i.data_ultima_alteracao 
                            from 	tab_produto_decomposicao_insum i
                            where   1 = 1

                            ${itemComposicao.cod_mercadoria ? 
                                ` AND i.cod_mercadoria = lpad('${itemComposicao.cod_mercadoria}', 17, '0')` 
                            
                                : ` AND i.cod_insumo = lpad('${cod_mercadoria}', 17, '0')` }
                            `




            itemComposicao.itens = await mDataBase.myDataBase.zanthusPostgre.DataGet(sqlinsumo)





        } catch (e) {
            clsTools.pagConsole(`M0085 - Zanthus | model/modelMercadoria.ts | modelZanthusMercadoria.getVoucher
                                Error:
                                ${e}    
                                `);
            throw e
        } finally {
            return itemComposicao
        }
    }
}