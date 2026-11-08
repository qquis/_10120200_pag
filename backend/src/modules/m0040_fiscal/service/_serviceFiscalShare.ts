import { clsBase, clsTools } from "../../../model/modelbase";

import modelfc_ibs from "../model/modelfc_ibs";
import modelfc_ibs_mun from "../model/modelfc_ibs_mun";
import modelfc_class_trib_ibs_cbs from "../model/modelfc_class_trib_ibs_cbs";
import modelfc_cbs from "../model/modelfc_cbs";
import modelfc_cst_ibs_cbs from "../model/modelfc_cst_ibs_cbs";

/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 0
    const FLG_DEBUG_CONSOLE_LOG : boolean = true
    const FLG_MODULO : string = "M0040-Fiscal | SHARE (Funções Service Fiscal Compartilhadas)"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    






export default class serviceFiscalShare {
    Complemento: serviceFiscalShareComplemento
    constructor() { 
        this.Complemento = new serviceFiscalShareComplemento();
    }


}


//CLASS COMPLEMENTARES

class serviceFiscalShareComplemento { 
    Ibs : serviceFiscalShareIBS
    IbsMun: serviceFiscalShareIBSMun
    ClassTribIbsCbs: serviceFiscalShareClassTribIbsCbs
    Cbs: serviceFiscalShareCbs
    cstIBSCBS: serviceFiscalShareCstIbsCbs
    constructor() { 
        this.Ibs = new serviceFiscalShareIBS();
        this.IbsMun = new serviceFiscalShareIBSMun();
        this.ClassTribIbsCbs = new serviceFiscalShareClassTribIbsCbs();
        this.Cbs = new serviceFiscalShareCbs();
        this.cstIBSCBS = new serviceFiscalShareCstIbsCbs();
    }

    async ProcessarReformaDadosComplementares(ItemAPI: any) { 
        this.Ibs.ibsAdicionarShareListFromAPI(ItemAPI);
        this.IbsMun.ibsMunAdicionarShareListFromAPI(ItemAPI);
        this.ClassTribIbsCbs.classTribAdicionarShareListFromAPI(ItemAPI);
        this.Cbs.cbsAdicionarShareListFromAPI(ItemAPI);
        this.cstIBSCBS.cstIbsCbsAdicionarShareListFromAPI(ItemAPI);
    }

    async SalvarDadosDosLists() { 
        await this.Ibs.ibsSalvar();
        await this.IbsMun.ibsMunSalvar();
        await this.ClassTribIbsCbs.classTribSalvar();
        await this.Cbs.cbsSalvar();
        await this.cstIBSCBS.cstIbsCbsSalvar();
    }
}

class serviceFiscalShareIBS { 
    listIBS : modelfc_ibs[] = [];
    constructor() { 
        this.listIBS = [];
    }


    ibsAdicionarShareListFromAPI(ItemAPI : any) {


        const item = new modelfc_ibs();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);

        if (item && item.ibs_cd && item.ibs_cd > 0) {
            if (!this.listIBS.find(x => x.ibs_cd == item.ibs_cd)) {
                this.listIBS.push(item);
            }
        }
    }

    async ibsSalvar()  {
        
        try { 
            let sql : string = ``;
            for (const item of this.listIBS) {
                sql += item.sql_CRUD();
            }
            if (sql.length > 0) {
                await this.shareDataBaseProcessar(sql);
            }
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.ibsSalvar', e);
        }
    }
    private async shareDataBaseProcessar(scriptSQL : string) : Promise<void> { 
        const myBase = new clsBase();
        try  { 
                    if (scriptSQL.length > 0) {
                        await myBase.myDataBase.pag.Execute(scriptSQL);
                    }
                
            } catch (e) { 
                await clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }       
    }
}

class serviceFiscalShareIBSMun { 
    listIBSMun : modelfc_ibs_mun[] = [];
    constructor() { 
        this.listIBSMun = [];
    }


    ibsMunAdicionarShareListFromAPI(ItemAPI : any) {


        const item = new modelfc_ibs_mun();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);

        if (item && item.ibs_mun_cd && item.ibs_mun_cd > 0) {
            if (!this.listIBSMun.find(x => x.ibs_mun_cd == item.ibs_mun_cd)) {
                this.listIBSMun.push(item);
            }
        }
    }

    async ibsMunSalvar()  {
        
        try { 
            let sql : string = ``;
            for (const item of this.listIBSMun) {
                sql += item.sql_CRUD();
            }
            if (sql.length > 0) {
                await this.shareDataBaseProcessar(sql);
            }
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.ibsMunSalvar', e);
        }
    }
    private async shareDataBaseProcessar(scriptSQL : string) : Promise<void> { 
        const myBase = new clsBase();
        try  { 
                    if (scriptSQL.length > 0) {
                        await myBase.myDataBase.pag.Execute(scriptSQL);
                    }
                
            } catch (e) { 
                await clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }       
    }
}

class serviceFiscalShareClassTribIbsCbs { 
    listClassTribIbsCbs : modelfc_class_trib_ibs_cbs[] = [];
    constructor() { 
        this.listClassTribIbsCbs = [];
    }


    classTribAdicionarShareListFromAPI(ItemAPI : any) {


        const item = new modelfc_class_trib_ibs_cbs();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);

        if (item && item.rt_codigo_class_trib_ibs_cbs && item.rt_codigo_class_trib_ibs_cbs !== '') {
            if (!this.listClassTribIbsCbs.find(x => x.rt_codigo_class_trib_ibs_cbs == item.rt_codigo_class_trib_ibs_cbs)) {
                this.listClassTribIbsCbs.push(item);
            }
        }
    }

    async classTribSalvar()  {
        
        try { 
            let sql : string = ``;
            for (const item of this.listClassTribIbsCbs) {
                sql += item.sql_CRUD();
            }
            if (sql.length > 0) {
                await this.shareDataBaseProcessar(sql);
            }
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.classTribSalvar', e);
        }
    }
    private async shareDataBaseProcessar(scriptSQL : string) : Promise<void> { 
        const myBase = new clsBase();
        try  { 
                    if (scriptSQL.length > 0) {
                        await myBase.myDataBase.pag.Execute(scriptSQL);
                    }
                
            } catch (e) { 
                await clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }       
    }
}

class serviceFiscalShareCbs { 
    listCbs : modelfc_cbs[] = [];
    constructor() { 
        this.listCbs = [];
    }


    cbsAdicionarShareListFromAPI(ItemAPI : any) {


        const item = new modelfc_cbs();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);

        if (item && item.cbs_cd && item.cbs_cd !== 0) {
            if (!this.listCbs.find(x => x.cbs_cd == item.cbs_cd)) {
                this.listCbs.push(item);
            }
        }
    }

    async cbsSalvar()  {
        
        try { 
            let sql : string = ``;
            for (const item of this.listCbs) {
                sql += item.sql_CRUD();
            }
            if (sql.length > 0) {
                await this.shareDataBaseProcessar(sql);
            }
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.cbsSalvar', e);
        }
    }
    private async shareDataBaseProcessar(scriptSQL : string) : Promise<void> { 
        const myBase = new clsBase();
        try  { 
                    if (scriptSQL.length > 0) {
                        await myBase.myDataBase.pag.Execute(scriptSQL);
                    }
                
            } catch (e) { 
                await clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }       
    }
}

class serviceFiscalShareCstIbsCbs {

    listCstIbsCbs : modelfc_cst_ibs_cbs[] = [];
    constructor() { 
        this.listCstIbsCbs = [];
    }


    cstIbsCbsAdicionarShareListFromAPI(ItemAPI : any) {


        const item = new modelfc_cst_ibs_cbs();
        item.ObterDadosAPIBluesoft_NFCE_PorProduto(ItemAPI);

        if (item && item.rt_codigo_cst_ibs_cbs && item.rt_codigo_cst_ibs_cbs !== '') {
            if (!this.listCstIbsCbs.find(x => x.rt_codigo_cst_ibs_cbs == item.rt_codigo_cst_ibs_cbs)) {
                this.listCstIbsCbs.push(item);
            }
        }
    }

    async cstIbsCbsSalvar()  {
        
        try { 
            let sql : string = ``;
            for (const item of this.listCstIbsCbs) {
                sql += item.sql_CRUD();
            }
            if (sql.length > 0) {
                await this.shareDataBaseProcessar(sql);
            }
        }
        catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, 'serviceFiscalShare.cstIbsCbsSalvar', e);
        }
    }
    private async shareDataBaseProcessar(scriptSQL : string) : Promise<void> { 
        const myBase = new clsBase();
        try  { 
                    if (scriptSQL.length > 0) {
                        await myBase.myDataBase.pag.Execute(scriptSQL);
                    }
                
            } catch (e) { 
                await clsTools.PagErrorException(FLG_MODULO, 'shareDataBaseProcessar', e);
            }       
    }
}