import 'dotenv/config'
import myTools from '../tools/Tools';
import {v4 as uuidv4} from 'uuid'
import DataBase from '../database/DataBase';
import { EventEmitter } from 'events'






const myDataBase : DataBase = new DataBase();



enum BDCommand {
    DBSELECT = `DBSELECT`, 
    DBUPDATE = `DBUPDATE`,
    DBINSERT = `DBINSERT`, 
    DBCRUD = `DBCRUD`,
    DBINSERT_API = `DBINSERT_API`
}


class modelbase extends EventEmitter {
    ENVIRONMENT : string 
    constructor() {
        super();
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`
    }
}

class modelTb {


    private ENVIRONMENT : string | undefined
    __defaultDateNow : Date 

    id_insert : string 
    dtlog_insert: Date 
    dtlog_update: Date 
    

    constructor() {

        

        this.ENVIRONMENT = process.env.ENVIRONMENT
        this.__defaultDateNow = myTools.pagDateTime_getDate();
        this.id_insert = `` 
        this.dtlog_update = this.__defaultDateNow; 
        this.dtlog_insert = this.__defaultDateNow; 

    }

    /* SCRIPT POSTGRE */
    _Db_Pg_script_Select(): string {return this._Db_Pg_script("DBSELECT")} 
    _Db_Pg_script_Insert(): string {return this._Db_Pg_script("DBINSERT")} 
    _Db_Pg_script_Update(): string {return this._Db_Pg_script("DBUPDATE")} 
    _Db_Pg_script_ToCheck(): string {return this._Db_Pg_script("TOCHECK")} 
    _Db_Pg_script_CRUD(): string {return this._Db_Pg_script("CRUD")} 
    _Db_Pg_script_DBCRUD(): string {return this._Db_Pg_script("DBCRUD")}     
    
    

    _myScriptBDCommand(_BDCommand : BDCommand = BDCommand.DBINSERT): string{
        return this._Db_Pg_script(_BDCommand)}

    _Db_Pg_script(_stringCommand: string): string{return ''}


    /* DATA BINDING */
    async binding(item: any){}
    async bindingBlueSoftApi(item: any){}



    /* Data Sql Commands */

    async _uuid() : Promise<string> {
        return `${uuidv4().substring(0,10)}`
    }





    /* Data PostGre Comands */
    async _Db_Pg_ToCheck(){this._Db_Pg_DataBinding(this._Db_Pg_script_ToCheck())}
    async _Db_Pg_INSERT() {this._Db_Pg_DataPost(this._Db_Pg_script_Insert())}
    async _Db_Pg_UPDATE() {this._Db_Pg_DataPost(this._Db_Pg_script_Update())}
    async _Db_Pg_CRUD() {
        try {
                const result = await this._Db_Pg_DataGet(this._Db_Pg_script_CRUD())
                await this.binding(result[0])
        }
        catch (e) {
            console.log(`modelTb (extends) | _CRUD Method \n Error --->>  ${e}`)
        }

    }

    /* New Events */
    async __Consultar()  {
        try {
                const result = await this._Db_Pg_DataGet(this._Db_Pg_script_Select())
                await this.binding(result[0])
        }
        catch (e) {
            console.log(`modelTb (extends) | __Consultar Method \n Error --->>  ${e}`)
        }

    }

    async __Atualizar() {
        try {
            const result = await this._Db_Pg_DataGet(this._Db_Pg_script_DBCRUD())
            if (!result[0])
            {
                myTools.pagConsoleLog(`MODELDB | Atualizar(): \n Return Record 0 from UPDATE Process `, true) 
            }
            await this.binding(result[0])
            }
            catch (e) {
                console.log(`modelTb (extends) | __Atualizar Method \n Error --->>  ${e}`)
            }

    }

    async __INSERT() {this._Db_Pg_DataPost(this._Db_Pg_script_Insert())}
    async __UPDATE() {this._Db_Pg_DataPost(this._Db_Pg_script_Update())}
    async __CRUD() {
        try {
                const result = await this._Db_Pg_DataGet(this._Db_Pg_script_DBCRUD())
                await this.binding(result[0])
        }
        catch (e) {
            console.log(`modelTb (extends) | _CRUD Method \n Error --->>  ${e}`)
        }

    }


    async _Db_Pg_DataGetResult(scriptSQL: string){
        try {
                const result = await myDataBase.pag.DataGet(scriptSQL)
                return result[0]
        } catch(e){
            myTools.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true) 
            return {}
        }
    }

    async _Db_Pg_DataPost (scriptSQL: string){
        try {
            await this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataPost / Var scriptSQL \n ${scriptSQL} `) 
            await myDataBase.pag.Execute(scriptSQL);
        } catch (e){
            myTools.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true) 
        }
    }
    async _Db_Pg_DataGet(scriptSQL: string){
        try {
                await this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataGet / Var scriptSQL \n ${scriptSQL} `) 
                return await myDataBase.pag.DataGet(scriptSQL)
        } catch(e){
            myTools.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true) 
            return {}
        }
    }
    async _Db_Pg_DataBinding(scriptSQL: string){
        try {
            /* 16/12/2023 Method que será excluído em breve */
            await this._DEBUG(`ENVIRONMENT | DES: _Db_Pg_DataBinding / Var scriptSQL \n ${scriptSQL} `) 
            const result = await myDataBase.pag.DataGet(this._Db_Pg_script(scriptSQL))
            await this.binding(result[0])
        } catch(e){
            myTools.pagConsoleLog(`MODELDB | Script SQL Erro: \n ${scriptSQL}`, true) 
            throw `MODELDB | ERRO ${e} \n SCRIPT SQL \n ${scriptSQL}`
        }
    }

    private async _DEBUG(stringMessage: string ){
        if (this.ENVIRONMENT == "DEB") 
            myTools.pagConsoleLog(stringMessage, true) 

    }


    public async ZanthusSQL_DataGet(scriptSQL: string ){
        try {
                let dados = {}
                //dados = await sqlserver_pool.DataGet(scriptSQL) 26/09/2024

                dados = await myDataBase.zanthusSQL.DataGet(scriptSQL);
                return Promise.resolve(dados);
        } catch(e){
            console.log(`modelTb (extends) | Sql Server Data Get \n Error --->> ${e}`)
            return {}
        }
        
    }

    public async ZanthusPostgre_DataGet(scriptSQL: string ){
        try {
                let dados = {}
                //dados = await sqlserver_pool.DataGet(scriptSQL) 26/09/2024

                dados = await myDataBase.zanthusSQL.DataGet(scriptSQL);
                return Promise.resolve(dados);
        } catch(e){
            console.log(`modelTb (extends) | Sql Server Data Get \n Error --->> ${e}`)
            return {}
        }
    }
}



class modelReport {
    ENVIRONMENT : string 
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`
    }
    public static async Get(DataResultFunction: string): Promise<object> {
        try {
        const result = await myDataBase.pag.DataGet(DataResultFunction)
                return result
            } catch(e){
                throw `modelTb ERROR | ${e}`
            }
    }

    public static async Execute(DataExecuteFunction: string) : Promise<boolean> {
        try {
            await myDataBase.pag.Execute(DataExecuteFunction); 
            return true;

    } catch (e) {
        throw `Execute Error: | ${e}`
    }

    }
}

class mdoReport {
    constructor() {}
    public async dataPag_get(DataResultFunction: string) {
        try {
            const result = await myDataBase.pag.DataGet(DataResultFunction)
                    return result
                } catch(e){
                    throw `modelTb ERROR | ${e}`
                }
    }

    public async dataPag_execute(DataResultFunction: string) {
        try {
            await myDataBase.pag.Execute(DataResultFunction); 
            return true;

        } catch (e) {
            throw `Execute Error: | ${e}`
        }
    }


    public async dataZanthus_get(DataResultFunction: string) {
        try {
            const result = await myDataBase.zanthusSQL.DataGet(DataResultFunction)
                    return result
                } catch(e){
                    throw `modelTb ERROR | ${e}`
                }
    }


    filterset(request: any) {}
}


class clsBase {
    ENVIRONMENT : string 
    myTools : typeof myTools
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`
        this.myTools = new myTools()
    }
}

class clsBasicReport {
    ENVIRONMENT : string 
    myTools : typeof myTools
    myDataBase : DataBase
    constructor() {
        this.ENVIRONMENT = `${process.env.ENVIRONMENT}`
        this.myTools = new myTools()
        this.myDataBase = new DataBase()
    }
}


export {modelTb , modelReport, mdoReport, modelbase, clsBasicReport, clsBase}