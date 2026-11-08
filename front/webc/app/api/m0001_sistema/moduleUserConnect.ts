import pagApi from '../api'

const url_service_login = '/sistema/service/login'
const url_model_login = '/sistema/model/userconnectget'

type menulist = { 
    sis_ac_gmenu_cd: number
    sis_ac_gmenu: string 
}





export default class moduleUserConnect { 
    sis_id: number
    sis_us_seq: number
    user_name: string
    email_main: string
    cdparticipante: number = 0
    statusLogin: boolean
    nome_razao: string = ''
    cdpessoabluesoft: number = 0
    usuario_login_uuid: string = `` 
    user_credential: string = ``
    user_credential_number: string = ``
    autorizado : number
    

    constructor() {
        this.sis_id = 6
        this.sis_us_seq = 0
        this.user_name = ''
        this.email_main = ''
        this.statusLogin = false
        this.cdpessoabluesoft = 0
        this.cdparticipante = 0
        this.nome_razao = `` 
        this.user_credential = ``
        this.user_credential_number = ``
        this.autorizado = 0
    }

    bindingLogin(item : any) { 
        if (item) { 
            this.sis_us_seq = item?.sis_us_seq
            this.user_name = item?.user_name
            this.email_main = item?.email_main
            this.nome_razao = item?.nome_razao
            this.cdparticipante = item?.cdparticipante
            this.cdpessoabluesoft = item?.cdpessoabluesoft
            this.user_credential = item?.user_credential
            this.user_credential_number = item?.user_credential_number
            this.autorizado = item?.autorizado
        }
    }

    async login_getCredentialNumber(email: string) : Promise<void> {
        this.user_credential_number = ""
        this.email_main = email
        await this.login_post("R", "")
    }

    async login(user_credential_number: string) : Promise<void> {
        this.user_credential_number = user_credential_number
        
        
        this.statusLogin = false
        
        await this.login_post("L", user_credential_number)
        
        if (this.autorizado == 1) {
            this.statusLogin = true
        }
    }


    private async login_post(typeRequest: string, user_credential_number: string) : Promise<void> { 

        let pagApiLoginBodyInfo = { 
            sis_id : "6",
            mail  : this.email_main,
            password : "",
            user_credential_number: user_credential_number,
            user_credential: this.user_credential,
            typeRequest: typeRequest
        }

        try { 
            let pagDadosLogin : any = await pagApi.post('/sistema/service/crmlogin', pagApiLoginBodyInfo)
            if (pagDadosLogin.data) { 

                this.sis_us_seq = pagDadosLogin.data.sis_us_seq
                this.user_name = pagDadosLogin.data.user_name
                this.email_main = pagDadosLogin.data.email_login
                this.cdparticipante = pagDadosLogin.data.cdparticipante
                this.cdpessoabluesoft = pagDadosLogin.data.cdpessoabluesoft
                this.nome_razao = pagDadosLogin.data.nome_razao
                this.usuario_login_uuid = pagDadosLogin.data.usuario_login_uuid
                this.user_credential = pagDadosLogin.data.user_credential
                this.user_credential_number = pagDadosLogin.data.user_credential_number
                this.autorizado = pagDadosLogin.data.autorizado
            
            }

        } catch (e) { 
            this.statusLogin = false
            throw new Error(`moduleUserConnect | login_post _ Error ${e}`)  
            

        }
    }

    



    async get<T>(url : string) : Promise<T> { 
        try { 
            const result = await pagApi.pagApiget<T>(this.usuario_login_uuid, url)
            
            return result

        } catch (e) { 
            throw new Error(`PagAPI | Get _ Error ${e}`)
        }
    }

    async post(url : string , object : object = {}) : Promise<object> { 
        try { 

            const result = await pagApi.pagApipost(this.usuario_login_uuid, url, object)
            return result 

        } catch (e) { 
            throw new Error(`PagAPI | Post _ Error ${e}`)
        }
    }
    /**
     * Converte uma string de data (yyyy-MM-dd) para um objeto Date,
     * ajustando para evitar problemas de fuso horário.
     */
    stringToDate(dateString: string): Date {
         // Divide a string da data em partes
            const parts = dateString.split('-');
            // Cria a data no horário LOCAL (não UTC)
            // Nota: O mês é 0-based (janeiro = 0)
            return new Date(
                parseInt(parts[0]), // ano
                parseInt(parts[1]) - 1, // mês
                parseInt(parts[2]) // dia
            );
    }

    /**
     * Formata um objeto Date para o formato yyyy-MM-dd (usado em inputs type="date"),
     * ajustando para o fuso horário local.
     */
    dateToInputFormat(date: Date): string {
    if (!date) return '';
    
    // Se for string, converte para Date primeiro
    if (typeof date === 'string') {
        date = this.stringToDate(date);
        // Se a conversão falhar, retorna string vazia
        if (!date || isNaN(date.getTime())) return '';
    }
    
    // Agora verifica se é um Date válido
    if (!(date instanceof Date) || isNaN(date.getTime())) return '';
  
    const pad = (num: number) => num.toString().padStart(2, '0');
    
    return [
        date.getFullYear(),
        pad(date.getMonth() + 1),
        pad(date.getDate())
    ].join('-');
    }
}


