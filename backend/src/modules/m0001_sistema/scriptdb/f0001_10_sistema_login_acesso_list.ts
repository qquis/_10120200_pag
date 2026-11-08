
type f0001_02_sistema_login_acesso_list_parametros = {
        sis_id?: number
        email_main?: string 
        vuser_name?: string
        vpasswd?: string 
}

export default class f0001_02_sistema_login_acesso_list {
        public static sqlScript_VERSION(): string {return `f0001_10_1012010_sistema_login_acesso_list`}
        public static get(parametros : f0001_02_sistema_login_acesso_list_parametros): string {
                return `SELECT * 
                        FROM   ${this.sqlScript_VERSION()}
                        (
                                vsis_id:= ${parametros.sis_id},
                                vemail_main:= '${parametros.email_main}',
                                vuser_name:= '${parametros.email_main}',
                                vpasswd:= '${parametros.vpasswd}' 
                        ) `
        }
}