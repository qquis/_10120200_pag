import sqlserver_pool from './sqlserver'
import pagPostgre_pool from './pagPostgre'
import redshift_pool from './redshift'
import zanthusPostgre_pool from './zanthusPostgre'
import { QueryResultRow } from 'pg'
import myTools from '../tools/Tools';
import { clsTools } from "../model/modelbase";

class pag {
    public async DataGet (query_string: string, generateError: boolean = false) : Promise<QueryResultRow> {
        try {
            return await pagPostgre_pool.DataGet(query_string, generateError) 
        } catch (e) {
            
            if (generateError) {
                throw new Error(`DataGet _ SQL Error: ${e}`)
            }
            else {
                await myTools.pagConsoleLog(`Pag.DataBase.DataGet | 
                            -----------------------------------------------------
                            ERROR
                            -----------------------------------------------------  
                            ${e} 
                            QUERY
                            -----------------------------------------------------  
                            ${query_string}`, true)
                return {}            
            }

        }
    }

    public async Execute (query_string: string) : Promise<number> {
        return await pagPostgre_pool.Execute(query_string)
    }    

    public async FunctionNoParameterExecute(nameFunction : string) : Promise<void> {
        await pagPostgre_pool.Execute(`SELECT ${nameFunction} ()`)
    }
}

class zanthusPostgre {
    public async DataGet (query_string: string) : Promise<QueryResultRow> {
        return await zanthusPostgre_pool.DataGet(query_string)
    }

    public async Execute (query_string: string) : Promise<number> {
        try { 
            await zanthusPostgre_pool.Execute(query_string)
            return 1
        } catch (e) {
            let numArquivo = Math.random() * 1000;
            await clsTools.PagErrorException('M0085_ZANTHUS', 'zanthusPostgre.DataBase.Execute', e, false, query_string, `POSTGRE_ERROR_${numArquivo}`);
            return -1            
            /*
            myTools.pagConsoleLog(`ZanthusPostgre.DataBase.Execute | 
                            -----------------------------------------------------
                            ERROR
                            -----------------------------------------------------  
                            ${e} 
                            QUERY
                            -----------------------------------------------------  
                            ${query_string}`, true)
            return -1*/            
        }
    }    

    public async FunctionNoParameterExecute(nameFunction : string) : Promise<void> {
        await zanthusPostgre_pool.Execute(`SELECT ${nameFunction} ()`)
    }
}

class zanthusSQL {
    public async DataGet (query_string: string) : Promise<QueryResultRow> {
        return await sqlserver_pool.DataGet(query_string)
    }

    public async Execute (query_string: string) : Promise<number> {
        return await sqlserver_pool.Execute(query_string)
    }    
}

class redshift {
    public async DataGet (query_string: string) : Promise<QueryResultRow> {
        return await redshift_pool.DataGet(query_string)
    }
}

class DataBase  {
    pag : pag 
    zanthusSQL: zanthusSQL
    redshift: redshift
    zanthusPostgre: zanthusPostgre
    MAX_UPDATE_DEFAULT : number = 200;
    constructor() {
        this.pag = new pag()
        this.zanthusSQL = new zanthusSQL(); 
        this.redshift = new redshift();
        this.zanthusPostgre = new zanthusPostgre()
        this.MAX_UPDATE_DEFAULT = parseInt(process.env.SERVER_DATABASE_MAX_UPDATE_DEFAULT || '200')
    }


    public async test (): Promise<string> {
        return await sqlserver_pool.test()
    }

    public async RecordItem (object: object, indexRecord: number): Promise<object> {
        
        if (object && Object.entries(object).length > 0) {
            return Object.entries(object)[indexRecord][1]
        }
        else { 
            return {}
        }
    }
}

export default DataBase