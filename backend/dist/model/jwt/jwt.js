"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsonwebtoken_1 = __importDefault(require("jsonwebtoken"));
class jwtService {
    static generateJWT(payload, expiresIn = '24h') {
        const secret = process.env.JWT_SECRET || 'seu-secret-super-seguro-aqui-com-minimo-32-chars';
        // Método alternativo se o sign continuar com erro
        return jsonwebtoken_1.default.sign({
            data: payload,
            exp: Math.floor(Date.now() / 1000) + (60 * 60 * 24) // 24 horas
        }, secret);
    }
    static verifyJWT(token) {
        try {
            const secret = process.env.JWT_SECRET || 'seu-secret-super-seguro-aqui';
            return jsonwebtoken_1.default.verify(token, secret);
        }
        catch (error) {
            throw new Error('Token inválido');
        }
    }
}
exports.default = jwtService;
