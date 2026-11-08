
import { clsTools, clsBase } from "../model/modelbase";


export default class pagN2011001 {
    static async execute() : Promise<void> { 
        try {
                console.log("Migration _ pagN2011001 - Inicializada")
                let sql = "SELECT sis_us_seq, passwd_web from tbsistema_usuario where coalesce(passwd_web,'') != '' "

                let myBase : clsBase = new clsBase()

                let listuser  = await myBase.myDataBase.pag.DataGet(sql)

                let sqlUpdatePassWord = `` 
                for await ( const[key, value] of Object.entries(listuser)) {
                    sqlUpdatePassWord += `UPDATE tbsistema_usuario set passwd_web = '${myBase.criptString(value.passwd_web)}', dtlog_update = current_timestamp
                                where sis_us_seq =  ${value.sis_us_seq};`
                }

                await myBase.myDataBase.pag.Execute(sqlUpdatePassWord);
                console.log("Migration _ pagN2011001 - Finalizada")

        } catch (e) { 
            clsTools.PagErrorException("migrationUtil","pagN2011001", e);
            throw new Error(`Error ${e}`);
        }
    }
}

