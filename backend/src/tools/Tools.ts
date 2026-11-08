import 'dotenv/config'

const Tools = require('../../../tools')
const path = require ('path')
const fs = require ('fs')

import momentMy from 'moment'
import 'moment/locale/pt-br'



type pagENV = {
    BASE_ZANTHUS_SQL : number;
}

momentMy.locale("pt-br")

export default class myTools extends Tools 
{
    static _dataMomentoStrToDate(str : string, strformat: string) {
        let _data : Date = new Date(1900,0,1)
        try {
            
            const _dataaformatar : string = strformat? strformat : "YYYY-MM-DD";
            const dataMOMENT = momentMy(str, _dataaformatar)

            if(str !== undefined)
                _data  = dataMOMENT.toDate()
            return _data 

        }
        catch (e)
        {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                             Message Error 
                             ${e} 
                            `)

            throw new Error(`Classe myTools 
                ------------------------------------------
                Method _dataConvertStrtoDate
                ------------------------------------------
                Error 
                ------------------------------------------
                ${e}
              `)
        }
    }

    static _dataConvertStrtoDate(_strFormatoData: string, errorInfo: string = "" ) : Date {
        let _data : Date = new Date(1900,0,1)
        try {
            
            const _dataaformatar : string = _strFormatoData? _strFormatoData : "1900-01-01";


            if(_strFormatoData !== undefined)
            
            _data  = momentMy(_strFormatoData, "DD/MM/YYYY").toDate();
            return _data 

        }
        catch (e)
        {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                             Message Error 
                             ${e} 
                            `)

            throw new Error(`Classe myTools 
                ------------------------------------------
                Method _dataConvertStrtoDate
                ------------------------------------------
                Error 
                ------------------------------------------
                ${e}
              `)
        }

    }

    static _dataformatgetDATEtoSTR(_Date : Date, _strformat? : string) : string  {
        try {            
            if (_Date)
                return momentMy(_Date.toISOString().slice(0, 10)).format(_strformat) 
            else 
                return momentMy().format(_strformat)


        } catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                Message Error ${_Date}
                ${e} 
               `)
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _dataformatgetDATEtoSTR
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `)
        }
       

    }


    static _datemomentDateToStr( _Date? : Date, _strformat? : string) : string { 
        let mydate : Date = new Date()
        if (_Date) 
            mydate = _Date
        try {
            return momentMy(mydate).format(_strformat? _strformat: "yyyy-MM-dd hh:mm:ss")
        } catch (e) {
            this.pagConsole(`ERROR myTools | _datemomentDateToStr
                Message Error 
                ${e} 
               `)
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _datemomentDateToStr
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `)
        }
    }
    
    static _dataformatgetstr(_strFormatoData : string, _strformat? : string) : string  {
        try {
            if (!_strformat)
                _strformat = "YYYY-MM-DD"

            if (_strFormatoData)
                return momentMy(_strFormatoData).format(_strformat) 
            else 
                return momentMy().format(_strformat)


        } catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                Message Error 
                ${e} 
               `)
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _dataformatgetstr
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `)
        }
       

    }

    static pagConsole(messageLOG: string, consolelog?: boolean, NoPrintTime?: boolean  ) {
        return new Promise ((resolve, reject) => {
            
 
            let pathfilenameLog = path.resolve(process.env.PATH_FILE_LOG)

            try {

                

             if (messageLOG !== '') {
                 //_data = new Date().toISOString(); 
                 //let _data = new Date()
                 let _dataformat : string = `` 
                 if (!NoPrintTime)
                    _dataformat = momentMy().format("yyyy-MM-DD HH-mm-ss");


                 switch (messageLOG) {
                    case `-`:
                        messageLOG = "---------------------------------------------" + "\n"
                        break; 
                    default: 
                        messageLOG  = `${_dataformat} ${messageLOG}` + "\n"
                        break;
                 }

                 
                 
                 if (consolelog) {
                    console.log(`${messageLOG}`)
                 }

                 fs.appendFile(pathfilenameLog, messageLOG,  { encoding: 'latin1'  }, (err: Error) => {
                     if (err)
                     {
                         reject(new Error(`Não foi possível gravar o arquivo de Log ${pathfilenameLog} - \n ${err}`))
                     }
                     else {   
                         resolve(``)
                     }
                 })
     
             }}
             catch(e)
             {
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`Tools | pagConsoleX() \n `)
                 console.log(`------------------------------------------------------------------------------`)
                 console.log(`Arquivo informado: ${pathfilenameLog}`)
                 console.log(`ERROR: ${e}`)
             }
         })
    }


    static async PagErrorException(modulo: string, metodo: string, ex : any, ErrorExecute : boolean = false, obs : string = "") : Promise<void> {
        try {

                let erroMessage : string  = `(ERROR) Módulo ${modulo} _ Metodo ${metodo}
                                  -------------------------------------------------------
                                  Observacao
                                  ${obs}
                                  -------------------------------------------------------
                                  Descricao do ERRO
                                  ${ex}
                                 ` 
                this.pagConsole(erroMessage)

                if (ErrorExecute)
                    throw new Error(erroMessage)
                
                await this._wait(1)

        } catch (e) {
                this.pagConsole(`PagErrorException - Não conseguiu reproduzir o erro ${e}`)
        }
    }


    static async _wait(tempo : number = 150) : Promise<void> {
        return new Promise(resolve => setTimeout(resolve, tempo));
    }

    static  myENV() : pagENV { 
        let pagEnvDados : pagENV = { 
            BASE_ZANTHUS_SQL : parseInt(`${process.env.BASE_ZANTHUS_SQL? process.env.BASE_ZANTHUS_SQL : 0 }`)
        }
        return pagEnvDados;

    }

}