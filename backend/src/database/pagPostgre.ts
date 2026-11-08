import 'dotenv/config'
import myTools from '../tools/Tools';
import { clsTools} from '../model/modelbase';
import {Pool, QueryResult, QueryResultRow} from 'pg'


const pool = new Pool({

    host: process.env.SERVER_POSTGRESQL_HOST,
    user: process.env.SERVER_POSTGRESQL_USER,
    database: process.env.SERVER_POSTGRESQL_DATABASE,
    password: process.env.SERVER_POSTGRESQL_PWD,
    port: parseInt(process.env.SERVER_POSTGRESQL_PORT || '5432')
    

})


let MyQueryResultRow : QueryResultRow


const pagPostgre_pool = {
    DataGet: async (query_string: string, generateError: boolean = false): Promise<QueryResultRow> => {
        try {
                if (!query_string) {
                    query_string = `null query`
                    throw new Error("query string não informada")
                }

                const result =  await pool.query(query_string)
                MyQueryResultRow = result.rows
                return MyQueryResultRow 
        }  catch(e) {
            if (generateError) {
                throw new Error(`DataGet _ SQL Error: ${e}`)
            }
            else {
                await clsTools.PagErrorException(`pagPostgre_pool | DataGet `, "DataGet", e, false, `\n QUERY STRING: ${query_string}`) 
                return {}
            }
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
            await clsTools.PagErrorException(`pagPostgre_pool | Execute `, "Execute", e, false, `\n QUERY STRING: ${query_string}`)
            return 0;
        }
    }
}

export default pagPostgre_pool
