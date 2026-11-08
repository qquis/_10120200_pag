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
class responseDefault {
    static get(status, message = `OK`, data = {}) {
        return {
            status,
            message,
            data,
            error: status >= 400 ? true : false,
            success: status < 400 ? true : false,
        };
    }
    static send(res_1) {
        return __awaiter(this, arguments, void 0, function* (res, data = {}, message = `Sucesso`, status = 0) {
            if (status == 0) {
                status = 200;
            }
            res.status(status).send(responseDefault.get(status, message, data));
        });
    }
}
exports.default = responseDefault;
