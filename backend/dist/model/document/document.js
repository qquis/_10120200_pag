"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Document {
    static formatdb(doc) {
        return doc.padStart(14, '0');
    }
    static _cleanDocument(doc) {
        return doc.replace(/\D/g, '');
    }
    /**
     * Valida um CPF
     */
    static cpf(cpf) {
        const cleanedCPF = this._cleanDocument(cpf);
        // CPF deve ter 11 dígitos
        if (cleanedCPF.length !== 11)
            return false;
        // Não pode ser uma sequência de números iguais
        if (/^(\d)\1+$/.test(cleanedCPF))
            return false;
        let sum = 0;
        let remainder;
        // Validação do primeiro dígito verificador
        for (let i = 1; i <= 9; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (11 - i);
        }
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11)
            remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(9, 10)))
            return false;
        // Validação do segundo dígito verificador
        sum = 0;
        for (let i = 1; i <= 10; i++) {
            sum += parseInt(cleanedCPF.substring(i - 1, i)) * (12 - i);
        }
        remainder = (sum * 10) % 11;
        if (remainder === 10 || remainder === 11)
            remainder = 0;
        if (remainder !== parseInt(cleanedCPF.substring(10, 11)))
            return false;
        return true;
    }
    /**
     * Valida um CNPJ
     */
    static Cnpj(cnpj) {
        const cleanedCNPJ = this._cleanDocument(cnpj);
        // CNPJ deve ter 14 dígitos
        if (cleanedCNPJ.length !== 14)
            return false;
        // Não pode ser uma sequência de números iguais
        if (/^(\d)\1+$/.test(cleanedCNPJ))
            return false;
        let length = cleanedCNPJ.length - 2;
        let numbers = cleanedCNPJ.substring(0, length);
        const digits = cleanedCNPJ.substring(length);
        let sum = 0;
        let pos = length - 7;
        // Validação do primeiro dígito verificador
        for (let i = length; i >= 1; i--) {
            sum += parseInt(numbers.charAt(length - i)) * pos--;
            if (pos < 2)
                pos = 9;
        }
        let result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result !== parseInt(digits.charAt(0)))
            return false;
        // Validação do segundo dígito verificador
        length = length + 1;
        numbers = cleanedCNPJ.substring(0, length);
        sum = 0;
        pos = length - 7;
        for (let i = length; i >= 1; i--) {
            sum += parseInt(numbers.charAt(length - i)) * pos--;
            if (pos < 2)
                pos = 9;
        }
        result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result !== parseInt(digits.charAt(1)))
            return false;
        return true;
    }
    /**
     * Função principal que identifica e valida CPF ou CNPJ
     */
    static cpf_cnpj(document) {
        const cleaned = this._cleanDocument(document);
        if (cleaned.length === 11) {
            return {
                isValid: this.cpf(cleaned),
                type: 'CPF',
                cleaned
            };
        }
        else if (cleaned.length === 14) {
            return {
                isValid: this.Cnpj(cleaned),
                type: 'CNPJ',
                cleaned
            };
        }
        else {
            return {
                isValid: false,
                type: 'unknown',
                cleaned
            };
        }
    }
}
exports.default = Document;
