"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.responseDefault = exports.jwtService = exports.checkDocument = exports.clsBase = exports.clsTools = void 0;
require("dotenv/config");
const Tools_1 = __importDefault(require("../tools/Tools"));
const DataBase_1 = __importDefault(require("../database/DataBase"));
const bluesoftApiUrl_1 = __importDefault(require("../modules/Apis/bluesoftApi/url/bluesoftApiUrl"));
const Vip_1 = __importDefault(require("../model/Apis/Vip"));
const SorteioExterno_1 = __importDefault(require("./Apis/SorteioExterno"));
const apiUrlMape_1 = __importDefault(require("../modules/Apis/apiUrlMape/apiUrlMape"));
const moment_1 = __importDefault(require("moment"));
require("moment/locale/pt-br");
const uuid_1 = require("uuid");
const crypt64_1 = __importDefault(require("./crypt/crypt64"));
const jwtService_1 = __importDefault(require("./jwt/jwtService"));
exports.jwtService = jwtService_1.default;
const mailService_1 = __importDefault(require("./mail/mailService"));
const document_1 = __importDefault(require("./document/document"));
const responseDefault_1 = __importDefault(require("./responseDefault/responseDefault"));
exports.responseDefault = responseDefault_1.default;
const path = require('path');
const fs = require('fs');
//import modelsistema_nucleo_procedimento from "../../src/modules/m9030_sistema_batch/model/modelsistema_nucleo_procedimento";
const myDataBase = new DataBase_1.default();
class clsTools {
    static ENVIRONMENT() {
        return `${process.env.ENVIRONMENT}`;
    }
    static pagConsoleFile(messageLOG, filenameLog) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let pathfilenameLog = path.resolve(process.env.PATH_FILE_LOG) + "__" + filenameLog;
                fs.appendFile(pathfilenameLog, messageLOG + "\n", { encoding: 'latin1' }, (err) => {
                    if (err) {
                        throw new Error(`Não foi possível gravar o arquivo de Log ${pathfilenameLog} - \n ${err}`);
                    }
                });
            }
            catch (e) {
                console.log('ERROR clsTools | pagConsoleFile()  ');
            }
        });
    }
    static pagLogSet(info) {
        var _a, _b, _c, _d, _e;
        let info_return = {};
        info_return.SISTEMA_NUCLEO_PRC_CD = (_a = info.SISTEMA_NUCLEO_PRC_CD) !== null && _a !== void 0 ? _a : 0;
        info_return.FLG_DEBUG_CONSOLE_LOG = (_b = info.FLG_DEBUG_CONSOLE_LOG) !== null && _b !== void 0 ? _b : true;
        info_return.FLG_MODULO = (_c = info.FLG_MODULO) !== null && _c !== void 0 ? _c : "M0071 - Interface ( Johnson Dial Venda )";
        info_return.FLG_DEBUG_FILE_CONSOLE_LOG = (_d = info.FLG_DEBUG_FILE_CONSOLE_LOG) !== null && _d !== void 0 ? _d : ``;
        info_return.FLG_NOPRINT_TIME = (_e = info.FLG_NOPRINT_TIME) !== null && _e !== void 0 ? _e : false;
        return info_return;
    }
    static pagLogInfo(message, info) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, _b, _c, _d;
            yield clsTools.pagConsole(message, (_a = info.FLG_DEBUG_CONSOLE_LOG) !== null && _a !== void 0 ? _a : true, (_b = info.FLG_NOPRINT_TIME) !== null && _b !== void 0 ? _b : false, (_c = info.FLG_DEBUG_FILE_CONSOLE_LOG) !== null && _c !== void 0 ? _c : ``, (_d = info.FLG_MODULO) !== null && _d !== void 0 ? _d : "");
        });
    }
    static pagConsole(messageLOG_1, consolelog_1, NoPrintTime_1) {
        return __awaiter(this, arguments, void 0, function* (messageLOG, consolelog, NoPrintTime, fileLogModule = "", modulo = "") {
            return new Promise((resolve, reject) => {
                var _a;
                let dataHoje = (0, moment_1.default)().format('YYYY-MM-DD');
                let baseLogPath = (_a = process.env.PATH_FILE_LOG) !== null && _a !== void 0 ? _a : 'log';
                /*se tiver extensão, vamos retirar para adicionar depois das tratativas */
                baseLogPath = baseLogPath.replace(".txt", "");
                baseLogPath = baseLogPath.replace(".TXT", "");
                let pathfilenameLog = `${path.resolve(baseLogPath)}.${dataHoje}`;
                if (fileLogModule !== '') {
                    pathfilenameLog = pathfilenameLog + "__" + fileLogModule.toUpperCase();
                }
                pathfilenameLog = pathfilenameLog + ".txt";
                try {
                    if (modulo !== '') {
                        messageLOG = `${modulo} | ${messageLOG}`;
                    }
                    if (messageLOG !== '') {
                        /*Retirar Acentos*/
                        messageLOG = messageLOG.normalize('NFD')
                            .replace(/[\u0300-\u036f]/g, '')
                            .replace(/ç/g, 'c')
                            .replace(/Ç/g, 'C');
                        //_data = new Date().toISOString(); 
                        //let _data = new Date()
                        let _dataformat = ``;
                        if (!NoPrintTime)
                            _dataformat = (0, moment_1.default)().format("yyyy-MM-DD HH-mm-ss.SSS");
                        switch (messageLOG) {
                            case `-`:
                                messageLOG = "---------------------------------------------" + "\n";
                                break;
                            default:
                                messageLOG = `${_dataformat} ${messageLOG}` + "\n";
                                break;
                        }
                        if (consolelog) {
                            console.log(`${messageLOG}`);
                        }
                        fs.appendFile(pathfilenameLog, messageLOG, { encoding: 'latin1' }, (err) => {
                            if (err) {
                                reject(new Error(`Não foi possível gravar o arquivo de Log ${pathfilenameLog} - \n ${err}`));
                            }
                            else {
                                resolve();
                            }
                        });
                    }
                }
                catch (e) {
                    console.log(`------------------------------------------------------------------------------`);
                    console.log(`------------------------------------------------------------------------------`);
                    console.log(`Tools | pagConsoleX() \n `);
                    console.log(`------------------------------------------------------------------------------`);
                    console.log(`Arquivo informado: ${pathfilenameLog}`);
                    console.log(`ERROR: ${e}`);
                }
            });
        });
    }
    static PagErrorException(modulo_1, metodo_1, ex_1) {
        return __awaiter(this, arguments, void 0, function* (modulo, metodo, ex, ErrorExecute = false, obs = "", fileLogModule = "") {
            let ErrorObject = {
                error: `PagErrorException - Módulo ${modulo} _ Método ${metodo} - ${ex}`
            };
            try {
                let erroMessage = ` * * * ERROR * * *  Módulo: ${modulo} _ Metodo: ${metodo} _ Observacao: ${obs} _ Descricao do ERRO ${ex} `;
                this.pagConsole(erroMessage, true, false, fileLogModule);
                if (ErrorExecute)
                    throw new Error(erroMessage);
                yield this._wait(1);
                return ErrorObject;
            }
            catch (e) {
                this.pagConsole(`PagErrorException - Não conseguiu reproduzir o erro ${e}`);
                return ErrorObject;
            }
        });
    }
    static _wait() {
        return __awaiter(this, arguments, void 0, function* (tempo = 150) {
            return new Promise(resolve => setTimeout(resolve, tempo));
        });
    }
    static _datemomentDateToStr(_Date, _strformat) {
        let mydate = new Date();
        if (_Date)
            mydate = _Date;
        try {
            return (0, moment_1.default)(mydate).format(_strformat ? _strformat : "yyyy-MM-dd hh:mm:ss");
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _datemomentDateToStr
                    Message Error 
                    ${e} 
                   `);
            throw new Error(`Classe myTools 
                             ------------------------------------------
                             Method _datemomentDateToStr
                             ------------------------------------------
                             Error 
                             ------------------------------------------
                             ${e}
                           `);
        }
    }
    static _datemomentDatStrToDate(_dataString, _strformat) {
        try {
            //_dataString = _dataString.trim()
            return (0, moment_1.default)(_dataString, _strformat ? _strformat : "yyyy-MM-dd hh:mm:ss").toDate();
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _datemomentDateToStr
                Message Error 
                ${e} 
               `);
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _datemomentDateToStr
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `);
        }
    }
    static _formatNumberToStr(value, decimals = 2, decimalSeparator = ",", thousandSeparator = ".", moneySymbol = "") {
        var _a;
        const numericValue = Number(value);
        if (!Number.isFinite(numericValue)) {
            return moneySymbol + "0" + decimalSeparator + "00";
        }
        const fixedValue = numericValue.toFixed(decimals);
        const parts = fixedValue.split(".");
        let integerPart = parts[0];
        const decimalPart = (_a = parts[1]) !== null && _a !== void 0 ? _a : "";
        integerPart = integerPart.replace(/\B(?=(\d{3})+(?!\d))/g, thousandSeparator);
        return moneySymbol + integerPart + decimalSeparator + decimalPart;
    }
    static _dateSemanasGetMes(dataBase = new Date()) {
        const ano = dataBase.getFullYear();
        const mes = dataBase.getMonth(); // 0-11
        const primeiroDiaMes = new Date(ano, mes, 1);
        const ultimoDiaMes = new Date(ano, mes + 1, 0);
        const toYmd = (d) => {
            const y = d.getFullYear();
            const m = String(d.getMonth() + 1).padStart(2, "0");
            const day = String(d.getDate()).padStart(2, "0");
            return `${y}-${m}-${day}`;
        };
        const clone = (d) => new Date(d.getFullYear(), d.getMonth(), d.getDate());
        // Domingo da semana que contém o dia 1 do mês
        let cursorDomingo = clone(primeiroDiaMes);
        cursorDomingo.setDate(cursorDomingo.getDate() - cursorDomingo.getDay());
        const semanas = [];
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
    static _datemomentSubtractDays(dateInput, days, formatOut) {
        try {
            const m = (0, moment_1.default)(dateInput);
            if (!m.isValid()) {
                throw new Error(`Data inválida: ${dateInput}`);
            }
            const result = m.subtract(days, 'days');
            // Padrão: retorna Date
            return result.toDate();
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _dateSubtractDays
                Message Error
                ${e}
            `);
            throw e;
        }
    }
    static getUserRequest(request) {
        let user = 0;
        if (request.headers['sis_us_seq']) {
            user = parseInt(`${request.headers['sis_us_seq']}`);
        }
        return user;
    }
    static uuid(lenght = 0, data = false) {
        let localLenght = 0;
        if (lenght !== 0) {
            localLenght = lenght;
        }
        else {
            localLenght = 10;
        }
        const dataFormatada = (0, moment_1.default)().format('YYMMDDHHmmss');
        let numeroUUID = ``;
        if (data) {
            numeroUUID = (dataFormatada + (0, uuid_1.v4)()).substring(0, localLenght);
        }
        else {
            numeroUUID = (0, uuid_1.v4)().substring(0, localLenght);
        }
        return numeroUUID;
    }
    static stringToDabase(str) {
        return str.replace(/'/g, "''");
    }
    static PagDataBaseGet(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            let myBase = new clsBase();
            try {
                let result = yield myBase.myDataBase.pag.DataGet(sql);
                return result;
            }
            catch (e) {
                clsTools.PagErrorException('ClsTools.PagDataBaseGet', 'get', e);
                throw new Error('Error in PagDataBaseGet.get');
            }
        });
    }
}
exports.clsTools = clsTools;
clsTools.jwt = jwtService_1.default;
clsTools.mail = mailService_1.default;
clsTools.document = document_1.default;
clsTools.responseDefault = responseDefault_1.default;
class clsBase {
    constructor(sis_usr_seq = 0) {
        this.blueSoftApi = bluesoftApiUrl_1.default;
        this.vipApi = Vip_1.default;
        this.sorteioExternoApi = SorteioExterno_1.default;
        this.apiUrlMape = apiUrlMape_1.default;
        this.myTools = clsTools;
        this.SIS_USR_SEQ = 0;
        this.__atualizado = false;
        this.myDataBase = new DataBase_1.default();
        this.ENVIRONMENT_CLASS = this.myTools.ENVIRONMENT();
        this.__defaultDateNow = Tools_1.default.pagDateTime_getDate();
        this.__atualizado = false;
        this.__dataZERO = new Date('1900-01-01T00:00:00Z');
    }
    criptString(str) {
        try {
            const cript = new crypt64_1.default();
            return cript.encrypt(str);
        }
        catch (e) {
            return ``;
        }
    }
    criptDString(str) {
        try {
            const cript = new crypt64_1.default();
            return cript.decrypt(str);
        }
        catch (e) {
            return ``;
        }
    }
    criptRandomINT(min = 100000, max = 999999) {
        try {
            const cript = new crypt64_1.default();
            return cript.randomINT(min, max);
        }
        catch (e) {
            return 0;
        }
    }
    ProcessoLogGerar(proc_tipo_cd, sis_usr_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let proc_log_seq = 0;
            try {
                const numeroUUID = (0, uuid_1.v4)().substring(0, 10);
                let sql = ` SELECT  proc_log_seq 
                        from    f9050_10_1012008_processo_log  
                        (
                              vproc_tipo_cd:= ${proc_tipo_cd}
                            , vsis_us_seq:= ${sis_usr_seq}
                            , vuuid_user_seq:= '${numeroUUID}'
                        ) 
                        `;
                let registro = yield myDataBase.RecordItem(yield myDataBase.pag.DataGet(sql), 0);
                if (registro) {
                    proc_log_seq = parseInt(`${registro.proc_log_seq}`);
                }
            }
            catch (e) {
                this.myTools.pagConsole(`ERROR myTools | processoLogRegister
                Message Error 
                ${e} 
               `);
            }
            finally {
                return proc_log_seq;
            }
        });
    }
}
exports.clsBase = clsBase;
class checkDocument {
    static formatdb(doc) {
        return doc.padStart(14, '0');
    }
    static _cleanDocument(doc) {
        return doc.replace(/\D/g, '');
    }
    /**
     * Valida um CPF
     */
    static cpf(cpf) {
        const cleanedCPF = this._cleanDocument(cpf);
        // CPF deve ter 11 dígitos
        if (cleanedCPF.length !== 11)
            return false;
        // Não pode ser uma sequência de números iguais
        if (/^(\d)\1+$/.test(cleanedCPF))
            return false;
        let sum = 0;
        let remainder;
        // Validação do primeiro dígito verificador
        for (let i = 1; i <= 9; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (11 - i);
        }
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11)
            remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(9, 10)))
            return false;
        // Validação do segundo dígito verificador
        sum = 0;
        for (let i = 1; i <= 10; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (12 - i);
        }
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11)
            remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(10, 11)))
            return false;
        return true;
    }
    /**
     * Valida um CNPJ
     */
    static Cnpj(cnpj) {
        const cleanedCNPJ = this._cleanDocument(cnpj);
        // CNPJ deve ter 14 dígitos
        if (cleanedCNPJ.length !== 14)
            return false;
        // Não pode ser uma sequência de números iguais
        if (/^(\d)\1+$/.test(cleanedCNPJ))
            return false;
        let length = cleanedCNPJ.length - 2;
        let numbers = cleanedCNPJ.substring(0, length);
        const digits = cleanedCNPJ.substring(length);
        let sum = 0;
        let pos = length - 7;
        // Validação do primeiro dígito verificador
        for (let i = length; i >= 1; i--) {
            sum += parseInt(numbers.charAt(length - i)) * pos--;
            if (pos < 2)
                pos = 9;
        }
        let result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result !== parseInt(digits.charAt(0)))
            return false;
        // Validação do segundo dígito verificador
        length = length + 1;
        numbers = cleanedCNPJ.substring(0, length);
        sum = 0;
        pos = length - 7;
        for (let i = length; i >= 1; i--) {
            sum += parseInt(numbers.charAt(length - i)) * pos--;
            if (pos < 2)
                pos = 9;
        }
        result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result !== parseInt(digits.charAt(1)))
            return false;
        return true;
    }
    /**
     * Função principal que identifica e valida CPF ou CNPJ
     */
    static cpf_cnpj(document) {
        const cleaned = this._cleanDocument(document);
        if (cleaned.length === 11) {
            return {
                isValid: this.cpf(cleaned),
                type: 'CPF',
                cleaned
            };
        }
        else if (cleaned.length === 14) {
            return {
                isValid: this.Cnpj(cleaned),
                type: 'CNPJ',
                cleaned
            };
        }
        else {
            return {
                isValid: false,
                type: 'unknown',
                cleaned
            };
        }
    }
}
exports.checkDocument = checkDocument;
