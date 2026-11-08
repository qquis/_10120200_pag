export default class tbnotificacao_send_message {
        dtlog_insert?: Date
    	notificacao_send_seq: number			     
    	notificacao_send_message_seq: number	       
    	notificacao_send_message: string 
        
    constructor (
        dtlog_insert: Date
    ,	notificacao_send_seq: number			     
    ,	notificacao_send_message_seq: number	       
    ,	notificacao_send_message: string 
    )
    {
        this.dtlog_insert = dtlog_insert; 
        this.notificacao_send_seq = notificacao_send_seq; 
        this.notificacao_send_message_seq = notificacao_send_message_seq; 
        this.notificacao_send_message = notificacao_send_message; 
        
    }
    binding(item:any) 
    {
        try {
            if (item !== undefined )
            {
                this.dtlog_insert = item.dtlog_insert
                this.notificacao_send_seq = item.notificacao_send_seq
                this.notificacao_send_message_seq = item.notificacao_send_message_seq
                this.notificacao_send_message = item.notificacao_send_message
            }

        }
        catch(e){

        }
    }

}