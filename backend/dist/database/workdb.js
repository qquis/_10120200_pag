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
const DataBase_1 = __importDefault(require("./DataBase"));
const myDataBase = new DataBase_1.default();
class modeldb {
    static pag_Execute(scriptSQL) {
        return __awaiter(this, void 0, void 0, function* () {
            yield myDataBase.pag.Execute(scriptSQL);
        });
    }
    static pag_DataGet(scriptSQL_1) {
        return __awaiter(this, arguments, void 0, function* (scriptSQL, indexRecord = -1) {
            let listOrObjectItem = {};
            try {
                if (indexRecord < 0) {
                    listOrObjectItem = yield myDataBase.pag.DataGet(scriptSQL);
                }
                else {
                    listOrObjectItem = Object.entries(yield myDataBase.pag.DataGet(scriptSQL))[indexRecord][1];
                }
                return listOrObjectItem;
            }
            catch (e) {
                return listOrObjectItem;
            }
        });
    }
}
exports.default = modeldb;
