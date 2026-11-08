
import DataBase from './DataBase';



const myDataBase : DataBase = new DataBase();



export default class modeldb {
    static async pag_Execute(scriptSQL: string) {
        await myDataBase.pag.Execute(scriptSQL)
    }
    static async pag_DataGet(scriptSQL: string, indexRecord : number = -1) : Promise<object> {
        let listOrObjectItem : object = {}
        
        try {
        
            if (indexRecord < 0) {
                listOrObjectItem =  await myDataBase.pag.DataGet(scriptSQL)
            } else { 
                listOrObjectItem = Object.entries(await myDataBase.pag.DataGet(scriptSQL))[indexRecord][1]

            }
        
        return listOrObjectItem

        } catch (e) { 
            return listOrObjectItem 
        }


    }
}
