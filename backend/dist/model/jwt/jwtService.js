"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsonwebtoken_1 = __importDefault(require("jsonwebtoken"));
const modelbase_1 = require("../../model/modelbase");
require("dotenv/config");
class jwtService {
    static get(payload, expiresIn = '1h') {
        //const secret = process.env.JWT_SECRET || 'secret';
        const secret = this.getSecretKey();
        try {
            return jsonwebtoken_1.default.sign({
                data: payload,
                exp: Math.floor(Date.now() / 1000) + (60 * 60 * 24) // 24 horas
            }, secret);
        }
        catch (error) {
            modelbase_1.clsTools.PagErrorException('MODEL BASE - jwtService', 'get', error);
            throw new Error('Erro ao gerar o token JWT');
        }
    }
    static check(token) {
        let jwtResult;
        try {
            //const secret = process.env.JWT_SECRET || 'secret';
            const secret = this.getSecretKey();
            jwtResult = jsonwebtoken_1.default.verify(token, secret);
        }
        catch (error) {
            jwtResult = null;
        }
        finally {
            return jwtResult;
        }
    }
    static getSecretKey() {
        return process.env.JWT_SECRET_KEY || 'secretOXAN2025!@#$%¨&*';
    }
}
exports.default = jwtService;
