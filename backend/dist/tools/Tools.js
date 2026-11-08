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
require("dotenv/config");
const Tools = require('../../../tools');
const path = require('path');
const fs = require('fs');
const moment_1 = __importDefault(require("moment"));
require("moment/locale/pt-br");
moment_1.default.locale("pt-br");
class myTools extends Tools {
    static _dataMomentoStrToDate(str, strformat) {
        let _data = new Date(1900, 0, 1);
        try {
            const _dataaformatar = strformat ? strformat : "YYYY-MM-DD";
            const dataMOMENT = (0, moment_1.default)(str, _dataaformatar);
            if (str !== undefined)
                _data = dataMOMENT.toDate();
            return _data;
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                             Message Error 
                             ${e} 
                            `);
            throw new Error(`Classe myTools 
                ------------------------------------------
                Method _dataConvertStrtoDate
                ------------------------------------------
                Error 
                ------------------------------------------
                ${e}
              `);
        }
    }
    static _dataConvertStrtoDate(_strFormatoData, errorInfo = "") {
        let _data = new Date(1900, 0, 1);
        try {
            const _dataaformatar = _strFormatoData ? _strFormatoData : "1900-01-01";
            if (_strFormatoData !== undefined)
                _data = (0, moment_1.default)(_strFormatoData, "DD/MM/YYYY").toDate();
            return _data;
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                             Message Error 
                             ${e} 
                            `);
            throw new Error(`Classe myTools 
                ------------------------------------------
                Method _dataConvertStrtoDate
                ------------------------------------------
                Error 
                ------------------------------------------
                ${e}
              `);
        }
    }
    static _dataformatgetDATEtoSTR(_Date, _strformat) {
        try {
            if (_Date)
                return (0, moment_1.default)(_Date.toISOString().slice(0, 10)).format(_strformat);
            else
                return (0, moment_1.default)().format(_strformat);
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                Message Error ${_Date}
                ${e} 
               `);
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _dataformatgetDATEtoSTR
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `);
        }
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
    static _dataformatgetstr(_strFormatoData, _strformat) {
        try {
            if (!_strformat)
                _strformat = "YYYY-MM-DD";
            if (_strFormatoData)
                return (0, moment_1.default)(_strFormatoData).format(_strformat);
            else
                return (0, moment_1.default)().format(_strformat);
        }
        catch (e) {
            this.pagConsole(`ERROR myTools | _dataConvertStrtoDate
                Message Error 
                ${e} 
               `);
            throw new Error(`Classe myTools 
                         ------------------------------------------
                         Method _dataformatgetstr
                         ------------------------------------------
                         Error 
                         ------------------------------------------
                         ${e}
                       `);
        }
    }
    static pagConsole(messageLOG, consolelog, NoPrintTime) {
        return new Promise((resolve, reject) => {
            let pathfilenameLog = path.resolve(process.env.PATH_FILE_LOG);
            try {
                if (messageLOG !== '') {
                    //_data = new Date().toISOString(); 
                    //let _data = new Date()
                    let _dataformat = ``;
                    if (!NoPrintTime)
                        _dataformat = (0, moment_1.default)().format("yyyy-MM-DD HH-mm-ss");
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
                            resolve(``);
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
    }
    static PagErrorException(modulo_1, metodo_1, ex_1) {
        return __awaiter(this, arguments, void 0, function* (modulo, metodo, ex, ErrorExecute = false, obs = "") {
            try {
                let erroMessage = `(ERROR) Módulo ${modulo} _ Metodo ${metodo}
                                  -------------------------------------------------------
                                  Observacao
                                  ${obs}
                                  -------------------------------------------------------
                                  Descricao do ERRO
                                  ${ex}
                                 `;
                this.pagConsole(erroMessage);
                if (ErrorExecute)
                    throw new Error(erroMessage);
                yield this._wait(1);
            }
            catch (e) {
                this.pagConsole(`PagErrorException - Não conseguiu reproduzir o erro ${e}`);
            }
        });
    }
    static _wait() {
        return __awaiter(this, arguments, void 0, function* (tempo = 150) {
            return new Promise(resolve => setTimeout(resolve, tempo));
        });
    }
    static myENV() {
        let pagEnvDados = {
            BASE_ZANTHUS_SQL: parseInt(`${process.env.BASE_ZANTHUS_SQL ? process.env.BASE_ZANTHUS_SQL : 0}`)
        };
        return pagEnvDados;
    }
}
exports.default = myTools;
