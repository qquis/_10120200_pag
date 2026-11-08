import tbwhatsapp_send from "../tbs/tbnotificacao_send"

export default class f0210_02_notificacao_send_message_crud {
        item?: tbwhatsapp_send
        constructor(item: tbwhatsapp_send) 
        {
            this.item = item;
        }
        private sqlScript_VERSION(): string {return `f0210_02_1011960_notificacao_send_message_crud`}




}