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
//import postgre_pool from '../../database/postgre';
const login_1 = require("../../model/login");
const DataBase_1 = __importDefault(require("../../database/DataBase"));
const myDataBase = new DataBase_1.default();
let loginAuthenticate = new login_1.Login(0, 0, '', '', 0);
class LoginAuthenticate {
    start() {
        return __awaiter(this, void 0, void 0, function* () {
            //const QueryResult = await postgre_pool.DataGet("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario where sis_us_seq = 1 limit 10")
            const QueryResult = yield myDataBase.pag.DataGet("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario where sis_us_seq = 1 limit 10");
            if (QueryResult) {
                loginAuthenticate = login_1.Login.NewUsuarioFromRows(QueryResult);
            }
            return loginAuthenticate;
        });
    }
}
exports.default = LoginAuthenticate;
/*
class LoginAuthenticate {
    public async start(): Promise<Login> {
       await pool.connect( (err: Error, client: PoolClient, release) => {
            if (!err)
            {
                   client.query("select sis_us_seq, cdpessoabluesoft, user_name from tbsistema_usuario limit 10",
                        (err: Error, result: QueryResult) => {
                            if (!err)
                            {
                                if (result.rowCount > 0)
                                {
                                    loginAuthenticate =  Login.NewUsuarioFromRows(result.rows[0])
                                }
                            }
    
                        }
                    )
            }
        })
        return loginAuthenticate
    }
}*/
