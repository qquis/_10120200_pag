/*Interfaces -----------------------------------------------------------------------------------------------------*/
interface ifilter {
    notificacao_send_seq?: number
    notificacao_send_data_ini: Date 
    notificacao_send_data_fim: Date 
    notificacao_send_status_cd?: number   
    notificacao_send_tipo_cd?: number	
    notificacao_celular_dd_numero?: string 
    notificacao_email?: string 
    notificacao_whatsapp?: number 
    notificacao_mail?: number
    notificacao_whatsapp_gp?: number 
}



export  {
    ifilter
}