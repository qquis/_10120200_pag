import 'dotenv/config'

import { clsBase, clsTools, jwtService } from "../../../model/modelbase"
import modelUserLogin from "../model/modelUserLogin";
import f0001_02_sistema_login from "../scriptdb/f0001_02_sistema_login";
import mailLoginLog from "../mail/mail_login_log";
import mailLoginCRMCredentialNumber from "../mail/mail_login_crm_credentialnumber";


const myBase = new clsBase()

export default class serviceSistemaLogin {


    public static async checkWjt(hash: string ) : Promise<modelUserLogin> {
        const mymodelUserConnect : modelUserLogin = new modelUserLogin()
        try {

            mymodelUserConnect.autorizado = 0;

            let loginCheck = await clsTools.jwt.check(hash)

            

            if (loginCheck.data) 
            {
                

                mymodelUserConnect.sis_id = loginCheck.data.sis_id
                mymodelUserConnect.autorizado = 1;
                mymodelUserConnect.sis_us_seq = loginCheck.data.sis_us_seq
                mymodelUserConnect.user_name = loginCheck.data.user_name
                mymodelUserConnect.sis_id = loginCheck.data.sis_id
                mymodelUserConnect.jwtExp = loginCheck.exp
                mymodelUserConnect.jwtIat = loginCheck.iat
                mymodelUserConnect.email_login = loginCheck.data.email_login? loginCheck.data.email_login : ``; 
                mymodelUserConnect.usuario_login_uuid = loginCheck.data.usuario_login_uuid? loginCheck.data.usuario_login_uuid : ``; 
                mymodelUserConnect.user_credential_number = loginCheck.data.user_credential_number

            } else {
                mymodelUserConnect.autorizado = 0;
                mymodelUserConnect.email_login = ``; 
                mymodelUserConnect.usuario_login_uuid = `HASH INVALIDO / EXPIRADO`; 
                mymodelUserConnect.sis_us_seq = 0;
                mymodelUserConnect.user_name = '';
                mymodelUserConnect.sis_id = 0
                throw new Error('Token Inválido ou Expirado')
            }


        }
        catch (e) {
            clsTools.PagErrorException('serviceSistema', 'loginCheck', e)
            throw new Error('serviceSistema.loginCheck')
        }
        finally {
            await this.__consolelogin(mymodelUserConnect)
            return mymodelUserConnect
        }
        
    }
    public static async Userlogin(sis_id: number, mail: string, password: string) : Promise<modelUserLogin> {
        let mymodelUserConnect : modelUserLogin = new modelUserLogin()
        try {

            mymodelUserConnect.email_login = mail; 
            mymodelUserConnect.password = password; 
            mymodelUserConnect.sis_id = sis_id
        



            
            mymodelUserConnect = await this.__dataBaseLogin('DBINSERT', mymodelUserConnect)

            
            if (mymodelUserConnect.autorizado == 1) {

                const jwtPayload = this.__getjwtPayload(mymodelUserConnect)
                let user_credential = clsTools.jwt.get(jwtPayload,'24h')
                mymodelUserConnect.user_credential = user_credential
                await this.__dataBaseLogin('DBUPDATE', mymodelUserConnect)
                
                mymodelUserConnect.user_credential = user_credential
                
                try {
                    await mailLoginLog.start(mymodelUserConnect.email_login)
                } catch (e) { 
                    await clsTools.PagErrorException('SISTEMA LOGIN', 'Envio de E-mail de logiin falhou', e)
                }
            }

            await this.__consolelogin(mymodelUserConnect)


            return mymodelUserConnect

        } catch (e) {
            await clsTools.PagErrorException('serviceSistema', 'login', e)
            //throw new Error('serviceSistema.login')
        }
        finally {
            return mymodelUserConnect
        }
    }

    public static async ClienteCrmLogin(tipopost: string, email: string, credentialNumber: string, user_credential: string) : Promise<modelUserLogin> {
        let mymodelUserConnect : modelUserLogin = new modelUserLogin()
        try {

            
            

            if (tipopost === "R") 
            { 
                /*Obter credential number*/
                mymodelUserConnect.user_credential_number = await myBase.criptRandomINT(100000, 999999).toString().padStart(6, '0')

                mymodelUserConnect.sis_id = 6
                mymodelUserConnect.email_login = email
                mymodelUserConnect.autorizado = 0
                mymodelUserConnect.sis_us_seq = 0
                mymodelUserConnect.usuario_login_uuid = ""
                mymodelUserConnect.user_name = "user_crm"


                if (mymodelUserConnect.user_credential_number === "") {
                    throw new Error('Erro ao gerar número de credencial')
                }
                else { 
                    
                    const jwtPayload = this.__getjwtPayload(mymodelUserConnect)
                    mymodelUserConnect.user_credential = clsTools.jwt.get(jwtPayload,'24h')

                    if (process.env.ENVIRONMENT === 'DES') {
                        console.log("Credential Number Generated:", mymodelUserConnect.user_credential_number)
                    }

                    if (mymodelUserConnect.user_credential !== "") {
                        mailLoginCRMCredentialNumber.start(email, mymodelUserConnect.user_credential_number)
                    }
                    else { 
                        throw new Error('Erro ao gerar hash de credencial')
                    }
                    

                }

                


            }

            if (tipopost === "L") 
            { 
                /*Fazer o Login com a credencial*/
                if (user_credential === "" || credentialNumber === "") {
                    throw new Error('Credencial ou número de credencial inválido')
                }
                mymodelUserConnect = await this.checkWjt(user_credential)
                mymodelUserConnect.user_credential = user_credential
                if (mymodelUserConnect.user_credential_number !== credentialNumber) {
                    mymodelUserConnect.autorizado = 0
                    throw new Error('Número de credencial inválido')
                } else { 
                    mymodelUserConnect = await this.__dataBaseLogin('DBINSERT', mymodelUserConnect)
                    mymodelUserConnect.user_credential = user_credential
                }

            }
            

            /*CHAMADA DA SELECT COM A CRIPOGRAFIA DA SENHA*/
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'ClienteCrmLogin', e)
            throw new Error('serviceSistema.ClienteCrmLogin')
        }
        finally {
            await clsTools.pagConsole(`M0001_SISTEMA-CLIENTE-CRM-LOGIN - ${email} - HASH ${mymodelUserConnect.usuario_login_uuid? "ok": "no"}`, false  , false)
            return mymodelUserConnect
        }
    }

    private static async __dataBaseLogin(sqlCommand: string, modelUserConnect: modelUserLogin) : Promise<modelUserLogin> {
        
        let mymodelUserConnect : modelUserLogin = modelUserConnect
        
        try {

            let sql = f0001_02_sistema_login.get(
                { 
                    SqlCommand: sqlCommand,
                    sis_id: modelUserConnect.sis_id,  
                    passwd : myBase.criptString(modelUserConnect.password), 
                    email_main: modelUserConnect.email_login,
                    usuario_login_uuid: modelUserConnect.usuario_login_uuid,
                    user_credential: modelUserConnect.user_credential,
                    user_credential_number: modelUserConnect.user_credential_number
                }
            )

            let result = await myBase.myDataBase.RecordItem(await myBase.myDataBase.pag.DataGet(sql),0)
            
            if (result) {
                mymodelUserConnect.binding(result)
            }

            
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'dataBaseLogin', e)
            throw new Error('serviceSistema.dataBaseLogin')
        }
        finally {
            return modelUserConnect
        }
    }

    private static __getjwtPayload(modelUserConnect: modelUserLogin) : any {
        let jwtPayload: object = {}
        
        
        try { 

            
            jwtPayload = {
                    sis_id: modelUserConnect.sis_id? modelUserConnect.sis_id : 0,    
                    sis_us_seq: modelUserConnect.sis_us_seq,
                    user_name: modelUserConnect.user_name,
                    email_login: modelUserConnect.email_login,
                    user_credential_number: modelUserConnect.user_credential_number,
                    usuario_login_uuid: modelUserConnect.usuario_login_uuid
                    
                };
                

        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'getjwtPayload', e)
            throw new Error('serviceSistema.getjwtPayload')
        } finally {
            return jwtPayload
        }
    
    }

    private static async __consolelogin(modelUserConnect: modelUserLogin) : Promise<void> {
        try {
            await clsTools.pagConsole(`M0001_SISTEMA-LOGIN - ${modelUserConnect.user_name} - ${modelUserConnect.email_login} HASH ${modelUserConnect.usuario_login_uuid? "ok": "no"}`, false  , false)
        } catch (e) {
            clsTools.PagErrorException('serviceSistema', 'consolelogin', e)
            throw new Error('serviceSistema.consolelogin')
        }
    }
}