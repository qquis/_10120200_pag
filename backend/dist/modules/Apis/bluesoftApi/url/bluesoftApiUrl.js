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
const axios_1 = __importDefault(require("axios"));
const modelbase_1 = require("../../../../model/modelbase");
const ENV_BLUESOFT_API_TIMEOUT = process.env.BLUESOFT_API_TIMEOUT ? parseInt(process.env.BLUESOFT_API_TIMEOUT) : 16000;
const bluesoftApiurl = axios_1.default.create(({
    timeout: ENV_BLUESOFT_API_TIMEOUT,
    baseURL: process.env.BLUEOSFT_API_URL,
    headers: {
        'X-Customtoken': `${process.env.BLUEOSFT_API_TOKEN}`,
        'Cookie': `${process.env.BLUESOFT_API_COOKIE}`
    }
}));
const config = {
    headers: {
        'X-Customtoken': `${process.env.BLUEOSFT_API_TOKEN}`,
        'Cookie': `${process.env.BLUESOFT_API_COOKIE}`,
        'timeout': ENV_BLUESOFT_API_TIMEOUT
    }
};
function api_get(url_1) {
    return __awaiter(this, arguments, void 0, function* (url, ErrorPagConsole = true) {
        try {
            const response = yield bluesoftApiurl.get(url, config);
            return response;
        }
        catch (e) {
            if (ErrorPagConsole) {
                modelbase_1.clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_get | Error \n ${e}`, false, false, 'bluesoftApiurl');
            }
            throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_get | URL [${url}] Error ${e}`);
        }
    });
}
function api_post(url_1, obj_1) {
    return __awaiter(this, arguments, void 0, function* (url, obj, ErrorPagConsole = true) {
        try {
            const response = yield bluesoftApiurl.post(url, obj, config);
            return response;
        }
        catch (e) {
            if (ErrorPagConsole) {
                modelbase_1.clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_post | Error \n ${e}`, false, false, 'bluesoftApiurl');
            }
            throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_post | URL [${url}] Error ${e}`);
        }
    });
}
function api_put(url_1, obj_1) {
    return __awaiter(this, arguments, void 0, function* (url, obj, ErrorPagConsole = true) {
        try {
            const response = yield bluesoftApiurl.put(url, obj, config);
            return response;
        }
        catch (e) {
            if (ErrorPagConsole) {
                modelbase_1.clsTools.pagConsole(`modules | bluesofAPI_bluesoftApiurl.api_put | Error \n ${e}`, false, false, 'bluesoftApiurl');
            }
            throw new Error(`modules | bluesofAPI_bluesoftApiurl.api_put | URL [${url}] Error ${e}`);
        }
    });
}
exports.default = { api_get, api_post, api_put };
