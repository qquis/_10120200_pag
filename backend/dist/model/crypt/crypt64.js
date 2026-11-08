"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const crypto_1 = require("crypto");
class Cryptp {
    constructor() {
        this.algorithm = 'aes-256-cbc';
        this.keyString = '141722P';
        this.iv = Buffer.from([0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc]);
        this.key = (0, crypto_1.scryptSync)(this.keyString, '', 32); // 32 bytes = 256 bits
    }
    encrypt(plainText) {
        const cipher = (0, crypto_1.createCipheriv)(this.algorithm, this.key, this.iv);
        let encrypted = cipher.update(plainText, 'utf8', 'base64');
        encrypted += cipher.final('base64');
        return encrypted;
    }
    decrypt(encryptedText) {
        try {
            const decipher = (0, crypto_1.createDecipheriv)(this.algorithm, this.key, this.iv);
            let decrypted = decipher.update(encryptedText, 'base64', 'utf8');
            decrypted += decipher.final('utf8');
            return decrypted;
        }
        catch (error) {
            console.error('Decryption failed:', error);
            return null;
        }
    }
    randomINT(number_init, number_end) {
        return (0, crypto_1.randomInt)(number_init, number_end);
    }
}
exports.default = Cryptp;
// Exemplo de uso:
//const cripto = new Criptp();
//const textoOriginal = "Texto para criptografar";
//const textoCriptografado = cripto.encrypt(textoOriginal);
//console.log("Texto criptografado:", textoCriptografado);
//const textoDescriptografado = cripto.decrypt(textoCriptografado);
//console.log("Texto descriptografado:", textoDescriptografado);
