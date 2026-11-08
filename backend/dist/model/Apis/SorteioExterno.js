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
const modelbase_1 = require("../modelbase");
const sorteioExternoApiurl = axios_1.default.create(({
    timeout: 14000,
    baseURL: process.env.SORTEIOEXTERNO_API_URL,
}));
const config = {
    headers: {
        'User-Agent': 'OXAN',
    }
};
function sorteioExternoApi_post(url, data) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield sorteioExternoApiurl.post(url, data, config);
            return response;
        }
        catch (e) {
            modelbase_1.clsTools.pagConsole(`modules | VIP API | Error \n ${e.message}`);
            // Log mais detalhado do erro
            modelbase_1.clsTools.pagConsole('=== VIP API ERROR DETAILS ===');
            modelbase_1.clsTools.pagConsole('Error message:', e.message);
            modelbase_1.clsTools.pagConsole('Error code:', e.code);
            modelbase_1.clsTools.pagConsole('Error config:', e.config);
            if (e.response) {
                modelbase_1.clsTools.pagConsole('Response status:', e.response.status);
                modelbase_1.clsTools.pagConsole('Response data:', e.response.data);
                modelbase_1.clsTools.pagConsole('Response headers:', e.response.headers);
            }
            else if (e.request) {
                modelbase_1.clsTools.pagConsole('Request made but no response:', e.request);
            }
            throw new Error(`modules | VIP API | Error ${e.message}`);
        }
    });
}
exports.default = { sorteioExternoApi_post };
