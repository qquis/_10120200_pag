const fs = require ('fs')
require('dotenv/config')
const {format} = require('date-fns')
const path = require ('path')
const {utcToZonedTime} = require('date-fns-tz')
const addDays = require('date-fns/addDays')
const { timeStamp } = require('console')

class Tools {
    static format_Participante_CpfCnpj (cpf_cnpj) {
        
        let format_cpf_cnpj = cpf_cnpj
        let stringLentght = cpf_cnpj.length;
        if (stringLentght < 14) {
            format_cpf_cnpj = `0`.repeat(14 - stringLentght) + cpf_cnpj;
        }
        return format_cpf_cnpj;
    }

    
    static format_Date_toStr_ShortDataBase(data)  {
        return this.pagDateTime_getDateStringShort(data);
    }

    static Date_br_timestamp(__date = '', errorInfo = `` ) {
        let dat = new Date('01/01/1900')
        try {
              const __dataX  = new Date(__date);
              let format_string =  __dataX.toISOString().substring(0,10)
              let d = format_string.split("-");
              let dat = new Date(d[0] + '/' + d[1] + '/' + d[2]);
              return dat
          } catch (e) {
              console.log(`Date_br_timestamp Erro | ${e} - Data info: ${__date} - ${errorInfo}`)
              return new Date("01/01/1900");
          }
    }

    static Date_br_current () {
        const __date = new Date().toLocaleString('pt-BR', { timeZoneName: 'longOffset', timeZone: 'America/Sao_Paulo' })
        let dat = '01/01/1900'
        try {
              let d = __date.split("/");
              let dat = new Date(d[2] + '/' + d[1] + '/' + d[0]);
              return dat;  
          } catch (e) {
              console.log(`Date_br_new | ${e}`)
              return new Date("01/01/1900");
          }
      }
    static Date_br_new(__date = ''){
      let dat = '01/01/1900'
      try {
            let d = __date.split("/");
            let dat = new Date(d[2] + '/' + d[1] + '/' + d[0]);
            return dat;  
        } catch (e) {
            console.log(`Date_br_new | ${e}`)
            return new Date("01/01/1900");
        }
    }
    static log_file(message)  {
            console.log(`LOG -> ${message}`)
    }
    static async pagConsoleLog_backend(message, consolelog = false) {await this.pagConsoleX(message, process.env.PATH_FILE_LOG_BACKEND, consolelog)}
    static async pagConsoleLog_fms_adm(message, consolelog = false) {await this.pagConsoleX(message, process.env.PATH_FILE_LOG_FRONT_MS_ADM, consolelog)}    
    static async pagConsoleLog_fms_portaria(message, consolelog = false) {await this.pagConsoleX(message, process.env.PATH_FILE_LOG_FRONT_MS_PORTARIA, consolelog)}    
    static async pagConsoleLog_service(message, consolelog = false) {await this.pagConsoleX(message, process.env.PATH_FILE_LOG_SERVICE, consolelog)}    

    static async pagConsoleLog(message, consolelog = false)
    {
        await this.pagConsoleX(message, process.env.PATH_FILE_LOG, consolelog)
    }


    static async pagConsoleX(messageLOG = "", pathfilename = "", consolelog = false) {
        return new Promise ((resolve, reject) => {
            
            let pathfilenameLog = path.resolve(pathfilename)

            try {

             if (messageLOG !== '') {
                 //_data = new Date().toISOString(); 
                 let _data = new Date()
                 let _dataformat = format(_data, "yyyy-MM-dd HH-mm:ss");

                 switch (messageLOG) {
                    case `-`:
                        messageLOG = "---------------------------------------------" + "\n"
                        break; 
                    default: 
                        messageLOG  = `${_dataformat} ${messageLOG}` + "\n"
                        break;
                 }

                 
                 
                 if (consolelog) {
                    console.log(`-> ${messageLOG}`)
                 }

                 fs.appendFile(pathfilenameLog, messageLOG, (err) => {
                     if (err)
                     {
                         reject(new Error(`Não foi possível gravar o arquivo de Log ${pathfilename} - \n ${err}`))
                     }
                     else {   
                         resolve()
                     }
                 })
     
             }}
             catch(e)
             {
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`Tools | pagConsoleX() \n `)
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`Arquivo informado: ${pathfilename}`)
                 console.log(`ERROR: ${e}`)
             }
         })
    }


    static async pagConsoleTeste( arquivoCodigo = "", valor_variavel) 
    {
        await console.log(`${arquivoCodigo} (TESTE) - Valor da variável ${valor_variavel}`)
    }

    static pagDateTime_getDateStringLong(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "yyyy-MM-dd HH:mm:ss"); }
    static pagDateTime_getDateStringShort(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "yyyy-MM-dd");}
    static pagDateTime_getDateStringShortBr(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "dd-MM-yyyy");}
    static pagDateTime_getDateStringShortBrBarra(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "dd/MM/yyyy");}
    static pagDateTime_getDate(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "yyyy-MM-dd HH:mm:ss");}
    static pagDateTime_getTime(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "HH:mm:ss");}
    static pagDateTime_getTimeSecond(_data) { return format(utcToZonedTime(this.pagGetDate(_data), "America/Sao_Paulo"), "ss");}
    static pagGetDate(_data = "") { if (!_data) {_data = new Date().toISOString()} return _data} 


    

    static MarketingMessage(notificacao_mk_cd)
    {
        let message = ""
        switch (notificacao_mk_cd) {
            case 1: 
message = `Você está convidado a acompanhar nossas promoções através do INSTAGRAM.
https://www.instagram.com/oxanbr`; 
            break; 

            case 2: 
message = `💳 ➡ Seja um cliente OXAN e obtenha descontos especiais: Solicite o cartão OXAN online ou no balcão de atendimento da Loja. 
O Cartão é emitido instantaneamente e você já poderá fazer suas compras (Sujeito à análise de crédito). 
NOVIDADE agora você pode preencher sua proposta online direto pelo WhatsApp. ➡ https://triban.co/wnfdY 📃
_oxan.com.br_
`; 
            break; 
        }
        return message;
    }

    static async TimeWhat(TimeSecond) {
        console.log(`Aguardando Time: ${TimeSecond}`)
        await setTimeout(TimeSecond);
    }


    static Left(str, n){
        if (n <= 0)
            return "";
        else if (n > String(str).length)
            return str;
        else
            return String(str).substring(0,n);
    }
    
    static Right(str, n){
        if (n <= 0)
           return "";
        else if (n > String(str).length)
           return str;
        else {
           var iLen = String(str).length;
           return String(str).substring(iLen, iLen - n);
        }
    }
}

module.exports = Tools;