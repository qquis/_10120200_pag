

export default class f0001_02_sistema_login {              
        public static sqlScript_VERSION(): string {return `f0001_02_1012018_sistema_login`}
        public static get(parametros : any): string {
                let sql =  `SELECT * 
                        FROM   ${this.sqlScript_VERSION()}
                        (       SqlCommand:= '${parametros.SqlCommand == undefined ? 'DBINSERT' : parametros.SqlCommand}',
                                vsis_id:= ${parametros.sis_id? parametros.sis_id : 0},
                                vemail_main:= '${parametros.email_main}',
                                vpasswd:= '${parametros.passwd}', 
                                vusuario_login_uuid:= '${parametros.usuario_login_uuid == undefined ? '' : parametros.usuario_login_uuid}',
                                vuser_credential:= '${parametros.user_credential == undefined ? '' : (parametros.user_credential).substring(0, 14)}', 
                                vuser_credential_number:= '${parametros.user_credential_number == undefined ? '' : parametros.user_credential_number}'

                        ) `
                return sql
        }
}