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
//import postgre_pool from "../../database/postgre"
const F0150_01_estatic_processamento_1 = __importDefault(require("./F0150_01_estatic_processamento"));
const DataBase_1 = __importDefault(require("../../database/DataBase"));
const myDataBase = new DataBase_1.default();
class ServiceEstatistica {
    Processamento() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //const result = await postgre_pool.Execute(f0150_estatistica_processamento())
                const result = yield myDataBase.pag.Execute((0, F0150_01_estatic_processamento_1.default)());
                return result;
            }
            catch (e) {
                console.log("Error class guardianticket");
                return 0;
            }
        });
    }
}
exports.default = ServiceEstatistica;
