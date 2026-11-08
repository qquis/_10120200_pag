
import { clsBase, clsTools } from "../../../model/modelbase";
import modelfc_regrafiscalNfceProduto from "../model/modelfc_regrafiscalNfceProduto";
const myBase = new clsBase();



import tbfc_cbs from "../tbs/tbfc_cbs";
import tbfc_ibs from "../tbs/tbfc_ibs";
import tbfc_class_trib_ibs_cbs from "../tbs/tbfc_class_trib_ibs_cbs";
import tbfc_cst_ibs_cbs from "../tbs/tbfc_cst_ibs_cbs";

export default class serviceFiscalImportarRegraComplemento { 
    

    static async dadaBaseProcessar(scriptSQL : string) : Promise<void> { 
        try  { 
                if (scriptSQL.length > 0) {
                    await myBase.myDataBase.pag.Execute(scriptSQL);
                }
            
        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.dadaBaseProcessar', e);
        }       
    }


    static async IbsAddList(item: any, listIBS: tbfc_ibs[]) : Promise<tbfc_ibs[]> { 
        let list : tbfc_ibs[] = listIBS;
        try { 

            if (item.reformaTributaria.ibs.ibsKey && item.reformaTributaria.ibs.ibsKey > 0) {
                let itemIBS: tbfc_ibs = new tbfc_ibs();
                itemIBS.ibs_cd = item.reformaTributaria.ibs.ibsKey;
                itemIBS.ibs_descricao = item.reformaTributaria.ibs.descricao;
                itemIBS.ibs_descricao_abreviada = item.reformaTributaria.ibs.descricaoAbreviada;

                if (!list.find(x => x.ibs_cd == itemIBS.ibs_cd)) {
                    list.push(itemIBS);
                }
                
            }   
        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.IbsAddList', e);
        }
        return list;
    }

    static async CbsAddList(item: any, listCBS: tbfc_cbs[]) : Promise<tbfc_cbs[]> { 
        let list : tbfc_cbs[] = listCBS;
        try { 

            if (item.reformaTributaria.cbs.cbsKey && item.reformaTributaria.cbs.cbsKey > 0) {
                let itemCBS: tbfc_cbs = new tbfc_cbs();
                itemCBS.cbs_cd = item.reformaTributaria.cbs.cbsKey;
                itemCBS.cbs_descricao = item.reformaTributaria.cbs.descricao;
                itemCBS.cbs_descricao_abreviada = item.reformaTributaria.cbs.descricaoAbreviada;

                if (await !list.find(x => x.cbs_cd == itemCBS.cbs_cd)) {
                    list.push(itemCBS);
                }
                
            }


        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsAddList', e);
        }
        return list;
    }
    
    static async CbsListaUpdate(listCBS: tbfc_cbs[] ) : Promise<void> { 
        try { 

            let i : number = 0;
            let iCount: number = 50
            let sql : string = ``;

            for await (const item of listCBS) { 
                sql += `insert into tbfc_cbs
                        (
                                    cbs_cd      					
                                ,	cbs_descricao					
                                ,	cbs_descricao_abreviada			
            
                        )
                                SELECT  ${item.cbs_cd}  
                                ,       '${item.cbs_descricao}'
                                ,       '${item.cbs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_cbs WHERE cbs_cd = ${item.cbs_cd} );
                        ;
                        update tbfc_cbs
                        set 
                                    cbs_descricao = '${item.cbs_descricao}'					
                                ,	cbs_descricao_abreviada = '${item.cbs_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where cbs_cd = ${item.cbs_cd};
            `

                i++;
                if (i >= iCount) { 
                    await this.dadaBaseProcessar(sql);
                    i = 0;
                    sql = ``;

                }
            }
            if (sql.length > 0) {
                await this.dadaBaseProcessar(sql);
            }

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsListaUpdate', e);
        }
    }

    static async IbsListaUpdate(listIBS: tbfc_ibs[] ) : Promise<void> { 
        try { 

            let i : number = 0;
            let iCount: number = 50
            let sql : string = ``;

            for await (const item of listIBS) { 
                sql += `insert into tbfc_ibs
                        (
                                    ibs_cd      					
                                ,	ibs_descricao					
                                ,	ibs_descricao_abreviada			
            
                        )
                                SELECT  ${item.ibs_cd}  
                                ,       '${item.ibs_descricao}'
                                ,       '${item.ibs_descricao_abreviada}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_ibs WHERE ibs_cd = ${item.ibs_cd} );
                        ;
                        update tbfc_ibs
                        set 
                                    ibs_descricao = '${item.ibs_descricao}'					
                                ,	ibs_descricao_abreviada = '${item.ibs_descricao_abreviada}'			
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where ibs_cd = ${item.ibs_cd};
            `

                i++;
                if (i >= iCount) { 
                    await this.dadaBaseProcessar(sql);
                    i = 0;
                    sql = ``;

                }
            }
            if (sql.length > 0) {
                await this.dadaBaseProcessar(sql);
            }

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CbsListaUpdate', e);
        }
    }

    static async ClassTribAddList(item: any, listClassTribIbsCbs: tbfc_class_trib_ibs_cbs[]) : Promise<tbfc_class_trib_ibs_cbs[]> { 
        let list : tbfc_class_trib_ibs_cbs[] = listClassTribIbsCbs;
        try { 

            if (item.reformaTributaria.codigoClassTribIbsCbs && item.reformaTributaria.codigoClassTribIbsCbs !== '') {
                let itemClassTribIbsCbs: tbfc_class_trib_ibs_cbs = new tbfc_class_trib_ibs_cbs();
                itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs = item?.reformaTributaria?.codigoClassTribIbsCbs || '';
                itemClassTribIbsCbs.rt_descricao_class_trib_ibs_cbs = item?.reformaTributaria?.descricaoCstIbsCbs || ''
                if (itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs.length > 0) {
                    if (!list.find(x => x.rt_codigo_class_trib_ibs_cbs == itemClassTribIbsCbs.rt_codigo_class_trib_ibs_cbs)) {
                        list.push(itemClassTribIbsCbs);
                    }
                }
                
            }
        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.ClassTribAddList', e);
        }
        return list;
    }

    static async ClassTribListaUpdate(listClassTribIbsCbs: tbfc_class_trib_ibs_cbs[] ) : Promise<void> { 
        try { 

            let i : number = 0;
            let iCount: number = 50
            let sql : string = ``;

            for await (const item of listClassTribIbsCbs) { 
                sql += `insert into tbfc_class_trib_ibs_cbs
                        (
                                    rt_codigo_class_trib_ibs_cbs      					
                                ,	rt_descricao_class_trib_ibs_cbs                    
            
                        )
                                SELECT  '${item.rt_codigo_class_trib_ibs_cbs}'  
                                ,       '${item.rt_descricao_class_trib_ibs_cbs}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_class_trib_ibs_cbs WHERE rt_codigo_class_trib_ibs_cbs = '${item.rt_codigo_class_trib_ibs_cbs}' );
                        ;
                        update tbfc_class_trib_ibs_cbs
                        set 
                                    rt_descricao_class_trib_ibs_cbs = '${item.rt_descricao_class_trib_ibs_cbs}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_class_trib_ibs_cbs = '${item.rt_codigo_class_trib_ibs_cbs}';
            `

                i++;
                if (i >= iCount) { 
                    await this.dadaBaseProcessar(sql);
                    i = 0;
                    sql = ``;

                }
            }
            if (sql.length > 0) {
            await this.dadaBaseProcessar(sql);
            }

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.ClassTribListaUpdate', e);
        }
    }       

    static async CstAddList(item: any, listCstIbsCbs: tbfc_cst_ibs_cbs[]) : Promise<tbfc_cst_ibs_cbs[]> { 
        let list : tbfc_cst_ibs_cbs[] = listCstIbsCbs;
        try { 

            if (item.reformaTributaria.codigoCstIbsCbs && item.reformaTributaria.codigoCstIbsCbs !== '') {
                let itemCstIbsCbs: tbfc_cst_ibs_cbs = new tbfc_cst_ibs_cbs();
                itemCstIbsCbs.rt_codigo_cst_ibs_cbs = item?.reformaTributaria?.codigoCstIbsCbs || ''
                itemCstIbsCbs.cst_ibs_cbs_descricao = item?.reformaTributaria?.descricaoCstIbsCbs || ''

                if (itemCstIbsCbs.rt_codigo_cst_ibs_cbs.length > 0) {
                    if (!list.find(x => x.rt_codigo_cst_ibs_cbs == itemCstIbsCbs.rt_codigo_cst_ibs_cbs)) {
                        list.push(itemCstIbsCbs);
                    }
                }
            }
        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CstAddList', e);
        }
        return list;
    }

    static async CstListaUpdate(listCstIbsCbs: tbfc_cst_ibs_cbs[] ) : Promise<void> { 
        try { 

            let i : number = 0;
            let iCount: number = 50
            let sql : string = ``;

            for await (const item of listCstIbsCbs) { 
                sql += `insert into tbfc_cst_ibs_cbs
                        (
                                    rt_codigo_cst_ibs_cbs      					
                                ,	cst_ibs_cbs_descricao                    
            
                        )
                                SELECT  '${item.rt_codigo_cst_ibs_cbs}'  
                                ,       '${item.cst_ibs_cbs_descricao}'
                        WHERE NOT EXISTS (SELECT 1 FROM tbfc_cst_ibs_cbs WHERE rt_codigo_cst_ibs_cbs = '${item.rt_codigo_cst_ibs_cbs}' );
                        ;
                        update tbfc_cst_ibs_cbs
                        set 
                                    cst_ibs_cbs_descricao = '${item.cst_ibs_cbs_descricao}'                    
                                , dtlog_update = CURRENT_TIMESTAMP			
                        where rt_codigo_cst_ibs_cbs = '${item.rt_codigo_cst_ibs_cbs}';
            `

                i++;
                if (i >= iCount) { 
                    await this.dadaBaseProcessar(sql);
                    i = 0;
                    sql = ``;

                }
            }
            if (sql.length > 0) {
                await this.dadaBaseProcessar(sql);
            }

        } catch (e) { 
            clsTools.PagErrorException('M0040_FISCAL', 'serviceFiscalImportarRegraNfceProduto.CstListaUpdate', e);
        }
    }
            

}