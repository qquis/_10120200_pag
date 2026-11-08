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
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const bluesoftApiurl = axios_1.default.create(({
    timeout: 14000,
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
        'timeout': 5000
    }
};
function api_get(url) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield bluesoftApiurl.get(url, config);
            return response;
        }
        catch (e) {
            Tools_1.default.pagConsole(`modules | bluesofAPI_bluesoftApiurl | Error \n ${e}`);
            throw new Error(`modules | bluesofAPI_bluesoftApiurl | Error ${e}`);
        }
    });
}
function api_post(url, obj) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield bluesoftApiurl.post(url, obj, config);
            return response;
        }
        catch (e) {
            throw e;
        }
    });
}
exports.default = { api_get, api_post };
