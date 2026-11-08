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
const modelbase_1 = require("../model/modelbase");
const pg_1 = require("pg");
const pool = new pg_1.Pool({
    host: process.env.SERVER_POSTGRESQL_HOST,
    user: process.env.SERVER_POSTGRESQL_USER,
    database: process.env.SERVER_POSTGRESQL_DATABASE,
    password: process.env.SERVER_POSTGRESQL_PWD,
    port: parseInt(process.env.SERVER_POSTGRESQL_PORT || '5432')
});
let MyQueryResultRow;
const pagPostgre_pool = {
    DataGet: (query_string_1, ...args_1) => __awaiter(void 0, [query_string_1, ...args_1], void 0, function* (query_string, generateError = false) {
        try {
            if (!query_string) {
                query_string = `null query`;
                throw new Error("query string não informada");
            }
            const result = yield pool.query(query_string);
            MyQueryResultRow = result.rows;
            return MyQueryResultRow;
        }
        catch (e) {
            if (generateError) {
                throw new Error(`DataGet _ SQL Error: ${e}`);
            }
            else {
                yield modelbase_1.clsTools.PagErrorException(`pagPostgre_pool | DataGet `, "DataGet", e, false, `\n QUERY STRING: ${query_string}`);
                return {};
            }
        }
    }),
    Execute: (query_string) => __awaiter(void 0, void 0, void 0, function* () {
        try {
            if (!query_string) {
                throw new Error("query string não informada");
            }
            yield pool.query(query_string);
            return 1;
        }
        catch (e) {
            yield modelbase_1.clsTools.PagErrorException(`pagPostgre_pool | Execute `, "Execute", e, false, `\n QUERY STRING: ${query_string}`);
            return 0;
        }
    })
};
exports.default = pagPostgre_pool;
