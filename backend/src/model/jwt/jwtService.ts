import jwt from 'jsonwebtoken';
import { clsTools } from '../../model/modelbase'
import 'dotenv/config'


export default class jwtService { 
    
    static get(payload: any, expiresIn: string = '1h'): string {
            //const secret = process.env.JWT_SECRET || 'secret';
            const secret = this.getSecretKey()

        try { 
        

        return jwt.sign(
            { 
                data: payload,
                exp: Math.floor(Date.now() / 1000) + (60 * 60 * 24) // 24 horas
            }, 
            secret
        );

        } catch (error) {
            clsTools.PagErrorException('MODEL BASE - jwtService', 'get', error)
            throw new Error('Erro ao gerar o token JWT');
        }
    }
    
    static check(token: string): any {
        let jwtResult : any
        try {
            //const secret = process.env.JWT_SECRET || 'secret';
            const secret = this.getSecretKey()
            jwtResult = jwt.verify(token, secret);

        } catch (error) {
            jwtResult = null;
        } finally {
            return jwtResult
        }
    }

    private static getSecretKey (): string {
        return process.env.JWT_SECRET_KEY || 'secretOXAN2025!@#$%¨&*'
    }
}