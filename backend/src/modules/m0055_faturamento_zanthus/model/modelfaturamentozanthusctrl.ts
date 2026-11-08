
import tbfaturamentozanthus from "../tbs/tbfaturamentozanthus";
import tbfaturamentozanthus_ctrl from "../tbs/tbfaturamentozanthus_ctrl";
import tbfaturamentozanthusitem from "../tbs/tbfaturamentozanthusitem";
import myTools from "../../../tools/Tools"
import DataBase from "../../../database/DataBase";

import f0055_60_faturamento_cupom_processamento from '../scriptspg/f0055_60_faturamento_cupom_processamento'
import f0055_61_faturamento_cupom_cancelamento from "../scriptspg/f0055_61_faturamento_cupom_cancelamento";
import { ifilter_faturamento } from '../wk'

import Zanthus_Cupom from "../scriptsql/Zanthus_Cupom"
import Zanthus_CupomItem from "../scriptsql/Zanthus_CupomItem"

export default class modelFaturamentozanthus_Ctrl extends tbfaturamentozanthus_ctrl {
    Cupons: tbfaturamentozanthus[]
    constructor () {
        super()
        this.Cupons = []
    }
    public async __CupomProcessar(filter: ifilter_faturamento, CupomProcessamentoInicial? : number) {
        try {
            //let listCUPOM : Array<tbfaturamentozanthus> = await FaturamentoZanthus.TbFaturamento_List(await this.Cupons_Obter(), false);
            //let ListItem: Array<tbfaturamentozanthusitem> = await FaturamentoZanthus.TbFaturamentoItem_List(await this.Itens_Obter(), false)
            
    
            await this.__BaseZanthusCupom_Get(filter, CupomProcessamentoInicial)
            await this.__BaseZanthusCupomItem_Get(filter, CupomProcessamentoInicial);
    
            let scriptSQL: string = "";
            //__DESENVOL await console.log(`Número de Cupons..: ${this.My_List_Cupom.length}`)
            //__DESENVOL await console.log(`Numero de Itens...: ${this.My_List_Cupom_Item.length}`)
            //__DESENVOL await console.log("processando registros...")
    
            const controle_MaxObject: number = this.My_List_Cupom.length - 1
            const controle_block: number = 10
            let control_i: number = 0
            let i = 0;
    
            //for (let i = 0; i <= controle_MaxObject; i++)
            for await (let itemFaturamentoZanthus  of this.My_List_Cupom)
            {
    
                scriptSQL = await scriptSQL + ` ${itemFaturamentoZanthus._Db_Pg_script_Insert()} `
                let ListForCupomItem: Array<tbfaturamentozanthusitem> = await this.__My_List_Cupom_Item_filter(itemFaturamentoZanthus.fat_zanthus_cupomfiscal_m00ad)
    
                //console.log(`teste 20/01/2025 VALOR DO I: ${i}`)
                //console.log(itemFaturamentoZanthus)
    
                //Inserindo os itens dos cupoms 
                for await (let iItem of ListForCupomItem)
                {
                    scriptSQL = await scriptSQL + ` ${iItem._Db_Pg_script_Insert()} `
                }
    
    
                if (i == controle_MaxObject || control_i >= controle_block)
                {
    
                    //__DESENVOL await console.log("Atualizando... ")
                    await this._Db_Pg_DataPost(scriptSQL)
                    scriptSQL = `` 
                    control_i = 0;
                }
                await control_i++;
                await i++;
    
            }
            //__DESENVOL await console.log("Insert Registros finalizados ")
            
    
        } catch (e)
        {
            console.log(`ModelTbFaturamentozanthus_Ctrl | ${e}` )
        }
    }
    
    public async __CupomFaturar() {
        try {
    
                //await console.log("Faturando ecf...");
                

                let script = `select ${f0055_60_faturamento_cupom_processamento.sqlScript_VERSION()}
                        (   vdata_processamento:= '${myTools.format_Date_toStr_ShortDataBase(this.fat_zanthus_data_m00af)}'
                        ,   vsat_ecf:= ${this.fat_zanthus_sat_ecf_m00ac}
                        ,   vcupomfiscal:= 0
                        )`
                await this._Db_Pg_DataPost(script)
          
        }
    
        catch(e) {
            throw new Error( `ModelTbFaturamentozanthus_Ctrl | Error \n ${e}`)
        }
    }
    public async __BaseZanthusCupom_Get(filter: ifilter_faturamento,  CupomProcessamentoInicial? : number): Promise<Array<tbfaturamentozanthus>> {        
        //let mylist = new Array<tbfaturamentozanthus>(); 
        try {
                

                //await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaCupons(this.My_List_Cupom, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSSQLSERVER")
                await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaCupons(this.My_List_Cupom, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSPOSTGRE")

                /*
                let DataObject : Object =  await this.ZanthusSQL_DataGet(Zanthus_Cupom.getBaseZanthusSQLServer(filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                let mylist = new Array<tbfaturamentozanthus>(); 
                for (const [key, value] of Object.entries(DataObject)) {
                    let i = new tbfaturamentozanthus();
                    await i.binding(value)
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    await mylist.push(i)
                }
                this.My_List_Cupom = mylist;*/
                return Promise.resolve(this.My_List_Cupom);
        } 
        catch(e){
            myTools.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais")
            return Promise.reject(this.My_List_Cupom)
        }
    }    
    
    public async __BaseZanthusCupomItem_Get(filter: ifilter_faturamento,  CupomProcessamentoInicial? : number): Promise<Array<tbfaturamentozanthusitem>>  {        
    
        //let mylist = new Array<tbfaturamentozanthusitem>(); 
        try {

                //await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaItem(this.My_List_Cupom_Item, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSSQLSERVER")

                await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaItem(this.My_List_Cupom_Item, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSPOSTGRE")

                /*

                let DataObject = await this.ZanthusSQL_DataGet(Zanthus_CupomItem.getBaseZanthusSQLServer(filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial)) 
                
                for (const [key, value] of Object.entries(DataObject)) {
                    let i = new tbfaturamentozanthusitem();
                    await i.binding(value)
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    await mylist.push(i)
                }
                this.My_List_Cupom_Item = mylist; */

                return Promise.resolve(this.My_List_Cupom_Item);            
                }
        catch(e){
            return Promise.reject(this.My_List_Cupom_Item)
        }
    }    
   
    public async __My_List_Cupom_Item_filter(fat_zanthus_cupomfiscal_m00ad: Number): Promise<Array<tbfaturamentozanthusitem>> {        
    
        let list = new Array<tbfaturamentozanthusitem>();    
    
        try {       
                list = await this.My_List_Cupom_Item.filter(ListaCupom => (ListaCupom.fat_zanthus_cupomfiscal_m00ad == fat_zanthus_cupomfiscal_m00ad))
                return list;
        }
        catch(e){
            return Promise.reject(list)
        }
    }    
    
    public async __ProcessarCancelados(){
        await this._Db_Pg_DataPost(`select ${f0055_61_faturamento_cupom_cancelamento.sqlScript_VERSION()}
            (   vdata_processamento:= '${myTools.format_Date_toStr_ShortDataBase(this.fat_zanthus_data_m00af)}')`
        )
    }

}


class modelFaturamentozanthus_complementary {
    static async __BaseZanthusCupom_PreencherListaCupons(ListaDeCuponsAPreencher: tbfaturamentozanthus[],  
                        filter: ifilter_faturamento,  
                        fat_zanthus_sat_ecf_m00ac: number,  
                        CupomProcessamentoInicial? : number, 
                        BaseDeDados : string = "") {
        try {
            const myDataBase : DataBase = new DataBase();
            
            let DataObjectListaCUPOM : Object = new Object()
            //if (BaseDeDados == "ZANTHUSSQLSERVER")
            //    DataObjectListaCUPOM = await myDataBase.zanthusSQL.DataGet(Zanthus_Cupom.getBaseZanthusSQLServer(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
            
            if (BaseDeDados == "ZANTHUSPOSTGRE")
                DataObjectListaCUPOM = await myDataBase.zanthusPostgre.DataGet(Zanthus_Cupom.getBaseZanthusPostGre(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                
            for (const [key, value] of Object.entries(DataObjectListaCUPOM)) {
                let i = new tbfaturamentozanthus();
                await i.binding(value)
                //if (ToCheck) await i._Db_Pg_ToCheck();
                await ListaDeCuponsAPreencher.push(i)
            } 
        } catch (e) {
            myTools.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais")
        }
    } 


    static async __BaseZanthusCupom_PreencherListaItem(ListaDeCuponsAPreencher: tbfaturamentozanthusitem[],  
                        filter: ifilter_faturamento,  
                        fat_zanthus_sat_ecf_m00ac: number,  
                        CupomProcessamentoInicial? : number, 
                        BaseDeDados : string = "") {
        try {
            const myDataBase : DataBase = new DataBase();
            
            let DataObject : Object = new Object()
            //if (BaseDeDados == "ZANTHUSSQLSERVER")
            //    DataObject = await myDataBase.zanthusSQL.DataGet(Zanthus_CupomItem.getBaseZanthusSQLServer(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
            
            if (BaseDeDados == "ZANTHUSPOSTGRE")
                DataObject = await myDataBase.zanthusPostgre.DataGet(Zanthus_CupomItem.getBaseZanthusPostGre(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))

            for (const [key, value] of Object.entries(DataObject)) {
                let i = new tbfaturamentozanthusitem();
                await i.binding(value)
                //if (ToCheck) await i._Db_Pg_ToCheck();
                await ListaDeCuponsAPreencher.push(i)
            } 
        } catch (e) {
            myTools.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais")
        }
    }     
    
}