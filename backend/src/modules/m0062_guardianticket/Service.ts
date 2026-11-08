//import postgre_pool from "../../database/postgre"
import f0062_01_guardian_ticket_crud from "./F0062_01_guardian_ticket_crud"
import tbguardian_ticket from "./tbguardian_ticket";

import DataBase from "../../database/DataBase";

const myDataBase = new DataBase();
class guardianTicket  {
    public async IncluirNovoTicket (tbguardian_ticket_item: tbguardian_ticket): Promise<tbguardian_ticket> {
        try {

                //const Result = await postgre_pool.DataGet(f0062_01_guardian_ticket_crud.post(tbguardian_ticket_item))

                const Result = await myDataBase.pag.DataGet(f0062_01_guardian_ticket_crud.post(tbguardian_ticket_item))
                
                if (Result[0])
                {
                    const {gtk_seq} = Result[0]
                    tbguardian_ticket_item.gtk_seq = gtk_seq

                    //tbguardian_ticket_item = Result[0]
                }
                return tbguardian_ticket_item;
            }

            catch(e){
                console.log("Error class guardianticket")
                return tbguardian_ticket_item;
            }

    }
}

export default guardianTicket
