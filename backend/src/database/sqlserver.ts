import 'dotenv/config'
import { promises } from 'msnodesqlv8'
import sql from 'mssql'
import myTools from '../tools/Tools';

let result = {}

const sqlConfig = {
    user: `${process.env.SERVER_SQLSERVER_USER}`,
    password: `${process.env.SERVER_SQLSERVER_PASSWORD}`,
    database: `${process.env.SERVER_SQLSERVER_DATABASE}`,
    server: `${process.env.SERVER_SQLSERVER_HOST}`,
    pool: {
      max: 10,
      min: 0,
      idleTimeoutMillis: 30000, 
    },
    options: {
      encrypt: false, // for azure
      trustServerCertificate: false, // change to true for local dev / self-signed certs
      enableArithAbort: true
    }, 
    requestTimeout: 120000
  }

const sqlserver_pool = {
    DataGet: async (query_string: string): Promise<Object> => {
      let Object_dados = {}
      try {
          await sql.connect(sqlConfig)
          Object_dados = (await sql.query(query_string)).recordset
          return Promise.resolve(Object_dados)
      }
      catch(e){
          myTools.pagConsoleLog(`sqlserver - DataGet | ${e}`, true)
          return Promise.resolve(Object_dados)
      }

    }, 
    
    Execute: async (query_string:string) : Promise<number> => {
        
      let resultROWS : number = 0
      try {
          await sql.connect(sqlConfig)
          let result = await sql.query(query_string)

          if (result)
          resultROWS = parseInt(`${result.rowsAffected[0]}`)

          return resultROWS
      }
      catch(e){
          myTools.pagConsoleLog(`(ERROR) sqlserver - Execute | 
                                 Descricao do Errro 
                                 ${e}
                                 ---------------------------------------------
                                 Script 
                                 ${query_string}
                                 `, true)
          return resultROWS
      }
    },

    test: async () : Promise<string> => {
        try {

          await sqlserver_pool.Execute("insert into DBAMAIN.dbo.tbacessopaglog (dtlog_insert) select getdate()")

          let dados : any = await sqlserver_pool.DataGet("SELECT info = convert(varchar(130), 'Server Name : ' + @@SERVERNAME + ' TimeDataBase: ' + convert(varchar(45), getdate()))")
          const [key] : any = Object.entries(dados)

          let testResult : string = `Connect ok _ ${key[1].info}`

          return testResult
        }
        catch(e) {
           myTools.pagConsoleLog( `Connect Error`, true)
           return Promise.reject(e)    
        }
    }
  }

export default sqlserver_pool;