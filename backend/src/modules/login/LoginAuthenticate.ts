//import postgre_pool from '../../database/postgre';
import { Login } from '../../model/login'
import DataBase from '../../database/DataBase';

const myDataBase : DataBase = new DataBase();

let loginAuthenticate : Login = new Login(0,0,'','',0)

class LoginAuthenticate {
    public async start(): Promise<Login> {
        //const QueryResult = await postgre_pool.DataGet("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario where sis_us_seq = 1 limit 10")
        const QueryResult = await myDataBase.pag.DataGet("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario where sis_us_seq = 1 limit 10")
        if (QueryResult){
            loginAuthenticate =  Login.NewUsuarioFromRows(QueryResult)
        }
        return loginAuthenticate
    }

}


export default LoginAuthenticate


/*
class LoginAuthenticate {
    public async start(): Promise<Login> {
       await pool.connect( (err: Error, client: PoolClient, release) => {
            if (!err)
            {
                   client.query("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario limit 10",
                        (err: Error, result: QueryResult) => {
                            if (!err)
                            {
                                if (result.rowCount > 0)
                                {
                                    loginAuthenticate =  Login.NewUsuarioFromRows(result.rows[0])
                                }
                            } 
    
                        }
                    )
            }
        })
        return loginAuthenticate
    }
}*/
