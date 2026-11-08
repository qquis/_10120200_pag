
import 'dotenv/config'
import myTools from '../tools/Tools';
import DataBase from '../database/DataBase';
import bluesoft_api from '../modules/Apis/bluesoftApi/url/bluesoftApiUrl'
import vip_api from '../model/Apis/Vip'
import SorteioExterno from './Apis/SorteioExterno';
import apiUrlMape from '../modules/Apis/apiUrlMape/apiUrlMape';

import { Request } from "express";
import momentMy from 'moment'
import 'moment/locale/pt-br'
import { v4 as uuidv4 } from 'uuid';

import Criptp from './crypt/crypt64';
import jwtService from './jwt/jwtService';
import serviceMail from './mail/mailService';
import Document from './document/document';
import responseDefault from './responseDefault/responseDefault';

const path = require ('path')
const fs = require ('fs')

//import modelsistema_nucleo_procedimento from "../../src/modules/m9030_sistema_batch/model/modelsistema_nucleo_procedimento";
 

const myDataBase : DataBase = new DataBase();


type tpConsoleLog = { 
    SISTEMA_NUCLEO_PRC_CD?: number,
    FLG_DEBUG_CONSOLE_LOG?: boolean,
    FLG_MODULO?: string,
    FLG_DEBUG_FILE_CONSOLE_LOG?: string
    FLG_NOPRINT_TIME?: boolean

}



class clsTools {
    static jwt = jwtService
    static mail = serviceMail
    static document = Document
    static responseDefault = responseDefault

    static ENVIRONMENT() : string {
        return `${process.env.ENVIRONMENT}`
    }

    static async pagConsoleFile(messageLOG: string, filenameLog: string) {

        try { 
                 let pathfilenameLog = path.resolve(process.env.PATH_FILE_LOG) + "__" + filenameLog
                                  fs.appendFile(pathfilenameLog, messageLOG + "\n",  { encoding: 'latin1'  }, (err: Error) => {
                     if (err)
                     {
                         throw new Error(`Não foi possível gravar o arquivo de Log ${pathfilenameLog} - \n ${err}`)
                     }
                 })
     

        } catch (e) { 
            console.log('ERROR clsTools | pagConsoleFile()  ')
        }

    }

    static pagLogSet(info: tpConsoleLog) : any {
        let info_return : any = {}
            info_return.SISTEMA_NUCLEO_PRC_CD = info.SISTEMA_NUCLEO_PRC_CD ?? 0
            info_return.FLG_DEBUG_CONSOLE_LOG = info.FLG_DEBUG_CONSOLE_LOG ?? true
            info_return.FLG_MODULO = info.FLG_MODULO ?? "M0071 - Interface ( Johnson Dial Venda )"
            info_return.FLG_DEBUG_FILE_CONSOLE_LOG = info.FLG_DEBUG_FILE_CONSOLE_LOG ?? ``
            info_return.FLG_NOPRINT_TIME = info.FLG_NOPRINT_TIME ?? false

        
        return info_return
    }

    static async pagLogInfo(message: string, info: any): Promise<void> {
        await clsTools.pagConsole(message, info.FLG_DEBUG_CONSOLE_LOG ?? true, info.FLG_NOPRINT_TIME ?? false, info.FLG_DEBUG_FILE_CONSOLE_LOG ?? ``, info.FLG_MODULO ?? "")
    }

    static async pagConsole(messageLOG: string, consolelog?: boolean, NoPrintTime?: boolean, fileLogModule: string = "", modulo: string = "") : Promise<void> {
        return new Promise ((resolve, reject) => {
            
            let dataHoje = momentMy().format('YYYY-MM-DD');
            let baseLogPath = process.env.PATH_FILE_LOG ?? 'log';

            /*se tiver extensão, vamos retirar para adicionar depois das tratativas */
            baseLogPath = baseLogPath.replace(".txt", "")
            baseLogPath = baseLogPath.replace(".TXT", "")

            let pathfilenameLog = `${path.resolve(baseLogPath)}.${dataHoje}`

            if (fileLogModule !== '') {
                pathfilenameLog = pathfilenameLog + "__" + fileLogModule.toUpperCase()
            }

            pathfilenameLog = pathfilenameLog + ".txt"

            try {


                if (modulo !== '') {
                    messageLOG = `${modulo} | ${messageLOG}`
                }

             if (messageLOG !== '') {

                /*Retirar Acentos*/
                messageLOG = messageLOG.normalize('NFD')
                            .replace(/[\u0300-\u036f]/g, '')
                            .replace(/ç/g, 'c')
                            .replace(/Ç/g, 'C');

                 //_data = new Date().toISOString(); 
                 //let _data = new Date()
                 let _dataformat : string = `` 
                 if (!NoPrintTime)
                    _dataformat = momentMy().format("yyyy-MM-DD HH-mm-ss.SSS");


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
                 console.log(`Arquivo informado: ${pathfilenameLog}`)
                 console.log(`ERROR: ${e}`)
             }
         })
    }
    static async PagErrorException(modulo: string, metodo: string, ex : any, ErrorExecute : boolean = false, obs : string = "", fileLogModule: string = "") : Promise<object> {
        let ErrorObject : object = {
            error: `PagErrorException - Módulo ${modulo} _ Método ${metodo} - ${ex}`
        }        
        try {

                let erroMessage : string  = ` * * * ERROR * * *  Módulo: ${modulo} _ Metodo: ${metodo} _ Observacao: ${obs} _ Descricao do ERRO ${ex} ` 
                this.pagConsole(erroMessage, true, false, fileLogModule)

                if (ErrorExecute)
                    throw new Error(erroMessage)
                
                await this._wait(1)
                return ErrorObject

        } catch (e) {
                this.pagConsole(`PagErrorException - Não conseguiu reproduzir o erro ${e}`)
                return ErrorObject
        }
    }
    static async _wait(tempo : number = 150) : Promise<void> {
        return new Promise(resolve => setTimeout(resolve, tempo));
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
    static _datemomentDatStrToDate(_dataString: string, _strformat? : string) : Date { 


        try {

            //_dataString = _dataString.trim()

            return momentMy(_dataString, _strformat? _strformat: "yyyy-MM-dd hh:mm:ss").toDate()
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

    static _formatNumberToStr(
        value: any,
        decimals: number = 2,
        decimalSeparator: string = ",",
        thousandSeparator: string = ".",
        moneySymbol: string = ""
    ): string {
        const numericValue = Number(value);

        if (!Number.isFinite(numericValue)) {
            return moneySymbol + "0" + decimalSeparator + "00";
        }

        const fixedValue = numericValue.toFixed(decimals);
        const parts = fixedValue.split(".");
        let integerPart = parts[0];
        const decimalPart = parts[1] ?? "";

        integerPart = integerPart.replace(/\B(?=(\d{3})+(?!\d))/g, thousandSeparator);

        return moneySymbol + integerPart + decimalSeparator + decimalPart;
    }

    public static _dateSemanasGetMes(dataBase: Date = new Date()): Array<{
        semana: number;
        inicio: string; // YYYY-MM-DD
        fim: string;    // YYYY-MM-DD
            }> 
    {
        const ano = dataBase.getFullYear();
        const mes = dataBase.getMonth(); // 0-11

        const primeiroDiaMes = new Date(ano, mes, 1);
        const ultimoDiaMes = new Date(ano, mes + 1, 0);

        const toYmd = (d: Date): string => {
            const y = d.getFullYear();
            const m = String(d.getMonth() + 1).padStart(2, "0");
            const day = String(d.getDate()).padStart(2, "0");
            return `${y}-${m}-${day}`;
        };

        const clone = (d: Date): Date => new Date(d.getFullYear(), d.getMonth(), d.getDate());

        // Domingo da semana que contém o dia 1 do mês
        let cursorDomingo = clone(primeiroDiaMes);
        cursorDomingo.setDate(cursorDomingo.getDate() - cursorDomingo.getDay());

        const semanas: Array<{ semana: number; inicio: string; fim: string }> = [];
        let numeroSemana = 1;

        while (cursorDomingo <= ultimoDiaMes) {
            const fimSemana = clone(cursorDomingo);
            fimSemana.setDate(fimSemana.getDate() + 6); // sábado

            // Limita a semana aos limites do mês corrente
            const inicioIntervalo = cursorDomingo < primeiroDiaMes ? clone(primeiroDiaMes) : clone(cursorDomingo);
            const fimIntervalo = fimSemana > ultimoDiaMes ? clone(ultimoDiaMes) : clone(fimSemana);

            if (inicioIntervalo <= fimIntervalo) {
                semanas.push({
                    semana: numeroSemana++,
                    inicio: toYmd(inicioIntervalo),
                    fim: toYmd(fimIntervalo),
                });
            }

            cursorDomingo.setDate(cursorDomingo.getDate() + 7);
        }

        return semanas;
    }

    static _datemomentSubtractDays(dateInput: Date | string, days: number, formatOut?: string): Date {
        try {
            const m = momentMy(dateInput);

            if (!m.isValid()) {
                throw new Error(`Data inválida: ${dateInput}`);
            }

            const result = m.subtract(days, 'days');

            // Padrão: retorna Date
            return result.toDate();
        } catch (e) {
            this.pagConsole(`ERROR myTools | _dateSubtractDays
                Message Error
                ${e}
            `);
            throw e;
        }
    }

    static getUserRequest(request : Request) : number {
        let user = 0
        if (request.headers['sis_us_seq']) {
            user = parseInt(`${request.headers['sis_us_seq']}`)
        }
        return user
    }

    static uuid(lenght: number = 0, data : boolean = false) : string { 
        let localLenght = 0 
        if (lenght !== 0)
        {
            localLenght = lenght
        }
        else {
            localLenght = 10
        }
        const dataFormatada = momentMy().format('YYMMDDHHmmss');
        let numeroUUID : string  = `` 
             if(data)       
             {
                numeroUUID = (dataFormatada + uuidv4()).substring(0,localLenght);
             } else {
                numeroUUID = uuidv4().substring(0,localLenght);
             }
        return numeroUUID;
    }

    static stringToDabase(str: string) : string  { 
        return str.replace(/'/g, "''");
    }
    public static async PagDataBaseGet(sql: string) : Promise<any> {
        let myBase = new clsBase()
        try {
            let result = await myBase.myDataBase.pag.DataGet(sql) 
            return result
        } catch (e) {
            clsTools.PagErrorException('ClsTools.PagDataBaseGet', 'get', e)
            throw new Error('Error in PagDataBaseGet.get')
        }

    } 
}

class clsBase {
    public blueSoftApi = bluesoft_api
    public vipApi = vip_api
    public sorteioExternoApi = SorteioExterno
    public apiUrlMape = apiUrlMape
    protected myTools = clsTools
    ENVIRONMENT_CLASS : string     
    SIS_USR_SEQ : number = 0
    myDataBase : DataBase
    __defaultDateNow : Date 
    __dataZERO : Date 

    __atualizado : boolean = false


    constructor(sis_usr_seq: number = 0) {
        this.myDataBase = new DataBase()
        this.ENVIRONMENT_CLASS = this.myTools.ENVIRONMENT()
        this.__defaultDateNow = myTools.pagDateTime_getDate();
        this.__atualizado = false;
        this.__dataZERO = new Date('1900-01-01T00:00:00Z')

    }

    public criptString(str: string ) : string {
        try {
            const  cript : Criptp = new Criptp()
            return cript.encrypt(str)
        } catch (e) {
            return ``    
        }
    }

    public criptDString(str: string ) : string | null  {
        try {
            const  cript : Criptp = new Criptp()
            return cript.decrypt(str)
        } catch (e) {
            return ``    
        }
    }

    public criptRandomINT(min: number = 100000, max: number = 999999) : number {
        try {
            const  cript : Criptp = new Criptp()
            return cript.randomINT(min, max)
        } catch (e) {
            return 0    
        }
    }


    public async ProcessoLogGerar(proc_tipo_cd: number, sis_usr_seq : number ) : Promise<number> {
        let proc_log_seq = 0 
        
        try {
            const numeroUUID : string  = uuidv4().substring(0,10);

            let sql = ` SELECT  proc_log_seq 
                        from    f9050_10_1012008_processo_log  
                        (
                              vproc_tipo_cd:= ${proc_tipo_cd}
                            , vsis_us_seq:= ${sis_usr_seq}
                            , vuuid_user_seq:= '${numeroUUID}'
                        ) 
                        `
            
            let registro : any = await  myDataBase.RecordItem(await myDataBase.pag.DataGet(sql), 0)

            if (registro) {
                proc_log_seq = parseInt(`${registro.proc_log_seq}`)
            }
        }
        catch (e){
            this.myTools.pagConsole(`ERROR myTools | processoLogRegister
                Message Error 
                ${e} 
               `)

        }
        finally {
            return proc_log_seq
        }
    }

    


}

class checkDocument {


    static formatdb(doc: string): string { 
        return doc.padStart(14, '0');
    }

    static _cleanDocument(doc: string): string {
            return doc.replace(/\D/g, '');
        }

    /**
     * Valida um CPF
     */
    static cpf(cpf: string): boolean {
        const cleanedCPF = this._cleanDocument(cpf);
        
        // CPF deve ter 11 dígitos
        if (cleanedCPF.length !== 11) return false;
        
        // Não pode ser uma sequência de números iguais
        if (/^(\d)\1+$/.test(cleanedCPF)) return false;
        
        let sum = 0;
        let remainder: number;
        
        // Validação do primeiro dígito verificador
        for (let i = 1; i <= 9; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (11 - i);
        }
        
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11) remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(9, 10))) return false;
        
        // Validação do segundo dígito verificador
        sum = 0;
        for (let i = 1; i <= 10; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (12 - i);
        }
        
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11) remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(10, 11))) return false;
        
        return true;
    }

    /**
     * Valida um CNPJ
     */
    static Cnpj(cnpj: string): boolean {
    const cleanedCNPJ = this._cleanDocument(cnpj);
    
    // CNPJ deve ter 14 dígitos
    if (cleanedCNPJ.length !== 14) return false;
    
    // Não pode ser uma sequência de números iguais
    if (/^(\d)\1+$/.test(cleanedCNPJ)) return false;
    
    let length = cleanedCNPJ.length - 2;
    let numbers = cleanedCNPJ.substring(0, length);
    const digits = cleanedCNPJ.substring(length);
    let sum = 0;
    let pos = length - 7;
    
    // Validação do primeiro dígito verificador
    for (let i = length; i >= 1; i--) {
        sum += parseInt(numbers.charAt(length - i)) * pos--;
        if (pos < 2) pos = 9;
    }
    
    let result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
    if (result !== parseInt(digits.charAt(0))) return false;
    
    // Validação do segundo dígito verificador
    length = length + 1;
    numbers = cleanedCNPJ.substring(0, length);
    sum = 0;
    pos = length - 7;
    
    for (let i = length; i >= 1; i--) {
        sum += parseInt(numbers.charAt(length - i)) * pos--;
        if (pos < 2) pos = 9;
    }
    
    result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
    if (result !== parseInt(digits.charAt(1))) return false;
    
    return true;
    }

    /**
     * Função principal que identifica e valida CPF ou CNPJ
     */
    static cpf_cnpj(document: string): {
    isValid: boolean;
    type: 'CPF' | 'CNPJ' | 'unknown';
    cleaned: string;
    } {
    const cleaned = this._cleanDocument(document);
    
    if (cleaned.length === 11) {
        return {
        isValid: this.cpf(cleaned),
        type: 'CPF',
        cleaned
        };
    } else if (cleaned.length === 14) {
        return {
        isValid: this.Cnpj(cleaned),
        type: 'CNPJ',
        cleaned
        };
    } else {
        return {
        isValid: false,
        type: 'unknown',
        cleaned
        };
    }
    }
}




export { clsTools, clsBase, checkDocument, jwtService, responseDefault}