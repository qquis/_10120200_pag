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
const modelbase_1 = require("../../model/modelbase");
const service_1 = __importDefault(require("./service/service"));
class batch_module_m1000 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let status = false;
            try {
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0040`, `batch_module_m0040 - FISCAL | Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
    static AtualizacaoDiaria() {
        return __awaiter(this, void 0, void 0, function* () {
            let status = false;
            try {
                yield service_1.default.if0017.start({});
                yield service_1.default.if0045.start({});
                yield service_1.default.if0100.start({});
                yield service_1.default.if0050.start({});
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M1000`, `batch_module_m1000.AtualizacaoDiaria Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
}
exports.default = batch_module_m1000;
