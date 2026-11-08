import pagToolsDate from '../../tools/pagToolsDate'
import tbguardian_ticket from './tbguardian_ticket'
import myTools from '../../tools/Tools';



const f0062_01_guardian_ticket_crud = {
    post :(     
                tbguardian_ticket: tbguardian_ticket
    ): string => {

        try {
       const query: string =  `select * from f0062_01_guardianticket_crud
                (   '${tbguardian_ticket.gtk_uuid}'
                ,    ${tbguardian_ticket.gtk_seq}
                ,    ${tbguardian_ticket.gtk_numero}
                ,   '${tbguardian_ticket.gtk_placa}'
                ,   '${pagToolsDate.getStringDateToPostgre(tbguardian_ticket.gtk_data)}'
                ,   '${pagToolsDate.getStringDateTimeToPostgre(tbguardian_ticket.gtk_pesagemInicialHora)}'
                ,   '${pagToolsDate.getStringDateTimeToPostgre(tbguardian_ticket.gtk_pesagemFinalHora)}'
                ,    ${tbguardian_ticket.gtk_pesagemInicialPeso}
                ,    ${tbguardian_ticket.gtk_pesagemFinalPeso}
                ,    ${tbguardian_ticket.gtk_pesagemPesoLiquido}
                  )  `
            
                  return query
        }
        catch(e)
        {
            console.log("Error f0062_01_guardian_ticket_crud")
            return ''
        }

    }
}
export default f0062_01_guardian_ticket_crud;

