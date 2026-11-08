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
const BASE_URL = process.env.PAG_API_URL;
// Função para criar headers dinâmicos, evitando o problema do undefined
const createApiPagHeaders = (userLoginUUID) => ({
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN || '', // Fallback para string vazia
    'UserLoginUUID': userLoginUUID || ''
});
const Api = axios_1.default.create({
    timeout: 0,
    baseURL: BASE_URL,
    headers: createApiPagHeaders()
});
class pagApi {
    static get(url) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                // Verificar se o token existe
                if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                    throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
                }
                const result = yield Api.get(url, { timeout: 0 });
                return result.data;
            }
            catch (e) {
                console.error('Erro na requisição GET:', e);
                throw new Error(`PagAPI | Get _ Error ${e}`);
            }
        });
    }
    static post(url_1) {
        return __awaiter(this, arguments, void 0, function* (url, object = {}) {
            try {
                // Verificar se o token existe
                if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                    throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
                }
                const result = yield Api.post(url, object, { timeout: 0 });
                return result;
            }
            catch (e) {
                console.error('Erro na requisição POST:', e);
                throw new Error(`PagAPI | Post _ Error ${e}`);
            }
        });
    }
    static pagApiget(usuario_login_uuid, url) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                // Verificar se o token existe
                if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                    throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
                }
                const result = yield Api.get(url, {
                    headers: {
                        'usuario_login_uuid': usuario_login_uuid,
                        'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN
                    }
                });
                return result.data;
            }
            catch (e) {
                console.error('Erro na requisição pagApiget:', e);
                throw new Error(`PagAPI | Get _ Error ${e}`);
            }
        });
    }
    static pagApipost(usuario_login_uuid_1, url_1) {
        return __awaiter(this, arguments, void 0, function* (usuario_login_uuid, url, object = {}) {
            try {
                // Verificar se o token existe
                if (!process.env.PUBLIC_CUSTOM_TOKEN) {
                    throw new Error('PUBLIC_CUSTOM_TOKEN não está definido');
                }
                const result = yield Api.post(url, object, {
                    headers: {
                        'usuario_login_uuid': usuario_login_uuid,
                        'x-customtoken': process.env.PUBLIC_CUSTOM_TOKEN
                    }
                });
                return result;
            }
            catch (e) {
                console.error('Erro na requisição pagApipost:', e);
                throw new Error(`PagAPI | Post _ Error ${e}`);
            }
        });
    }
}
exports.default = pagApi;
