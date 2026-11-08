import 'dotenv/config'
import {Pool, QueryResult, QueryResultRow} from 'pg'
import { clsTools } from '../model/modelbase'

const pool = new Pool({
    host: process.env.BLUESOFT_REDSHIFT_HOST,
    user: process.env.BLUESOFT_REDSHIFT_USER,
    database: process.env.BLUESOFT_REDSHIFT_DATABASE,
    password: process.env.BLUESOFT_REDSHIFT_PASSWORD,
    port: Number(process.env.BLUESOFT_REDSHIFT_PORT)
})


let MyQueryResultRow : QueryResultRow


const redshift_pool = {
    DataGet: async (query_string: string): Promise<QueryResultRow> => {
        try {
                const result =  await pool.query(query_string)
                MyQueryResultRow = result.rows
                return MyQueryResultRow 
        }  catch(e) {
            await clsTools.PagErrorException(`redshift_pool | DataGet `, "DataGet", e, false, `\n QUERY STRING: ${query_string}`)
            return MyQueryResultRow
        }
    }
    ,
    Execute: async (query_string:string) : Promise<number> => {
        
        try {
            await pool.query(query_string)
            return 1;
        } catch(e) {
            await clsTools.PagErrorException(`redshift_pool | Execute `, "Execute", e, false, `\n QUERY STRING: ${query_string}`)
            return 0;
        }
    }
}

export default redshift_pool
