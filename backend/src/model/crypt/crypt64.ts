import { createCipheriv, createDecipheriv, scryptSync, randomInt } from 'crypto';

export default class Cryptp {
    private algorithm: string;
    private key: Buffer;
    private iv: Buffer;
    private keyString: string;

    constructor() {
        this.algorithm = 'aes-256-cbc';
        this.keyString = '141722P';
        this.iv = Buffer.from([0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc]);
        this.key = scryptSync(this.keyString, '', 32); // 32 bytes = 256 bits
    }

    public encrypt(plainText: string): string {
        const cipher = createCipheriv(this.algorithm, this.key, this.iv);
        let encrypted = cipher.update(plainText, 'utf8', 'base64');
        encrypted += cipher.final('base64');
        return encrypted;
    }

    public decrypt(encryptedText: string): string | null {
        try {
            const decipher = createDecipheriv(this.algorithm, this.key, this.iv);
            let decrypted = decipher.update(encryptedText, 'base64', 'utf8');
            decrypted += decipher.final('utf8');
            return decrypted;
        } catch (error) {
            console.error('Decryption failed:', error);
            return null;
        }
    }

    public randomINT(number_init: number, number_end: number): number {
        return randomInt(number_init, number_end);
    }

}

// Exemplo de uso:
//const cripto = new Criptp();
//const textoOriginal = "Texto para criptografar";
//const textoCriptografado = cripto.encrypt(textoOriginal);
//console.log("Texto criptografado:", textoCriptografado);

//const textoDescriptografado = cripto.decrypt(textoCriptografado);
//console.log("Texto descriptografado:", textoDescriptografado);