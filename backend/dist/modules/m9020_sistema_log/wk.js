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
const modelsistema_log_1 = __importDefault(require("./model/modelsistema_log"));
class wk {
    static ProcessarLog(_isistema_log) {
        return __awaiter(this, void 0, void 0, function* () {
            let modelSistema_Log;
            modelSistema_Log = new modelsistema_log_1.default();
            modelSistema_Log.binding(_isistema_log);
            yield modelSistema_Log.ProcessarLog();
            return modelSistema_Log;
        });
    }
}
exports.default = wk;
