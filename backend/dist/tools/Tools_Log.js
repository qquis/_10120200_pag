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
Object.defineProperty(exports, "__esModule", { value: true });
exports.myTools = void 0;
exports.Tools_Log = pagConsole;
exports.Tools_pagDateTime_getDateStringShort = Tools_Date_toShortDataSelect;
require("dotenv/config");
const { log_file, pagDateTime_getDateStringShort } = require('../../../_resource/js/index');
const Tools = require('../../../tools');
const pjson = require('../../package.json');
class myTools extends Tools {
    static pagConsolex(message_1) {
        const _super = Object.create(null, {
            pagConsoleLog_backend: { get: () => super.pagConsoleLog_backend }
        });
        return __awaiter(this, arguments, void 0, function* (message, consolelog = false) {
            yield _super.pagConsoleLog_backend.call(this, message, consolelog);
        });
    }
}
exports.myTools = myTools;
function pagConsole(message) {
    return new Promise((resolve, reject) => {
        if (message !== '') {
            Tools.pagConsoleLog(message, true);
        }
    });
}
function Tools_Date_toShortDataSelect(_data) {
    return pagDateTime_getDateStringShort(_data);
}
