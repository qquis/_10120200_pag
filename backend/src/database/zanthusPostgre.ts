import 'dotenv/config'
import myTools from '../tools/Tools';
import {Pool, QueryResult, QueryResultRow} from 'pg'
import { clsTools } from '../model/modelbase';


const SERVER_DATABASE_LOG_LIMIT_QUERY_STRING = parseInt(process.env.SERVER_DATABASE_LOG_LIMIT_QUERY_STRING || '150')

const pool = new Pool({

    host: process.env.SERVER_zanthusPOSTGRESQL_HOST,
    user: process.env.SERVER_zanthusPOSTGRESQL_USER,
    database: process.env.SERVER_zanthusPOSTGRESQL_DATABASE,
    password: process.env.SERVER_zanthusPOSTGRESQL_PWD,
    port: parseInt(process.env.SERVER_zanthusPOSTGRESQL_PORT || '5432')
    

})


let MyQueryResultRow : QueryResultRow


const zanthusPostgre_pool = {
    DataGet: async (query_string: string): Promise<QueryResultRow> => {
        try {
                if (!query_string) {
                    throw new Error("query string não informada")
                }

                const result =  await pool.query(query_string)
                MyQueryResultRow = result.rows
                return MyQueryResultRow 
        }  catch(e) {
            myTools.pagConsoleLog( `ZANTHUS POSTGRE - ERROR DATA GET | 
                                    -----------------------------------------------------
                                    ERROR
                                    -----------------------------------------------------  
                                    ${e} 
                                    QUERY
                                    -----------------------------------------------------  
                                    ${query_string.length > SERVER_DATABASE_LOG_LIMIT_QUERY_STRING ? query_string.substring(0, SERVER_DATABASE_LOG_LIMIT_QUERY_STRING) + '...' : query_string}`, true)
            

            return MyQueryResultRow
        }
    }
    ,
    Execute: async (query_string:string) : Promise<number> => {
        
        try {

            if (!query_string) {
                throw new Error("query string não informada")
            }
            
            await pool.query(query_string)
            return 1;
        } catch(e) {
                        let numArquivo = Math.random() * 1000;
            myTools.pagConsoleLog( `ZANTHUS POSTGRE - ERROR EXECUTE | 
                                    -----------------------------------------------------
                                    ERROR
                                    -----------------------------------------------------  
                                    ${e} 
                                    QUERY
                                    -----------------------------------------------------  
                                    ${query_string.length > SERVER_DATABASE_LOG_LIMIT_QUERY_STRING ? query_string.substring(0, SERVER_DATABASE_LOG_LIMIT_QUERY_STRING) + '...' : query_string}`, true)
            
            await clsTools.PagErrorException(`ZANTHUS POSTGRE - ERROR EXECUTE`, `Execute QUERY \n ${query_string}`, e,false, "Erro QUERY", `POSTGRE_ERROR_${numArquivo}` )                                    

            return 0;
        }
    }
}

export default zanthusPostgre_pool
