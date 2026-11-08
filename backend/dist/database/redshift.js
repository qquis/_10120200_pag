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
Object.defineProperty(exports, "__esModule", { value: true });
require("dotenv/config");
const pg_1 = require("pg");
const modelbase_1 = require("../model/modelbase");
const pool = new pg_1.Pool({
    host: process.env.BLUESOFT_REDSHIFT_HOST,
    user: process.env.BLUESOFT_REDSHIFT_USER,
    database: process.env.BLUESOFT_REDSHIFT_DATABASE,
    password: process.env.BLUESOFT_REDSHIFT_PASSWORD,
    port: Number(process.env.BLUESOFT_REDSHIFT_PORT)
});
let MyQueryResultRow;
const redshift_pool = {
    DataGet: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        try {
            const result = yield pool.query(query_string);
            MyQueryResultRow = result.rows;
            return MyQueryResultRow;
        }
        catch (e) {
            yield modelbase_1.clsTools.PagErrorException(`redshift_pool | DataGet `, "DataGet", e, false, `\n QUERY STRING: ${query_string}`);
            return MyQueryResultRow;
        }
    }),
    Execute: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        try {
            yield pool.query(query_string);
            return 1;
        }
        catch (e) {
            yield modelbase_1.clsTools.PagErrorException(`redshift_pool | Execute `, "Execute", e, false, `\n QUERY STRING: ${query_string}`);
            return 0;
        }
    })
};
exports.default = redshift_pool;
