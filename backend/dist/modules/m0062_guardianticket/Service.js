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
const F0062_01_guardian_ticket_crud_1 = __importDefault(require("./F0062_01_guardian_ticket_crud"));
const DataBase_1 = __importDefault(require("../../database/DataBase"));
const myDataBase = new DataBase_1.default();
class guardianTicket {
    IncluirNovoTicket(tbguardian_ticket_item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //const Result = await postgre_pool.DataGet(f0062_01_guardian_ticket_crud.post(tbguardian_ticket_item))
                const Result = yield myDataBase.pag.DataGet(F0062_01_guardian_ticket_crud_1.default.post(tbguardian_ticket_item));
                if (Result[0]) {
                    const { gtk_seq } = Result[0];
                    tbguardian_ticket_item.gtk_seq = gtk_seq;
                    //tbguardian_ticket_item = Result[0]
                }
                return tbguardian_ticket_item;
            }
            catch (e) {
                console.log("Error class guardianticket");
                return tbguardian_ticket_item;
            }
        });
    }
}
exports.default = guardianTicket;
