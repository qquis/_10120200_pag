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
/*
class batch_m4501_45011 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
                myService.servicePrecoAplicado.bluesoftIntegrarPrecosPendentes(sis_batch_run_seq);

                return true;
        } catch(e) {
            return false;
        }
    }
}

class batch_m4502_45021 {
    static async start (sis_batch_run_seq: number) : Promise<boolean> {
        try {
                //await service.BlueSoftIntegrarAll(sis_batch_run_seq)
                return true;
        } catch(e) {
            return false;
        }
    }
}

export  { batch_m4501_45011 , batch_m4502_45021}
*/
const service_1 = __importDefault(require("./service/service"));
class batch_module_m0045 {
    static start(sis_batch_run_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                return true;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e);
                return false;
            }
        });
    }
    static Procedimento(nucleo_procedimento) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!nucleo_procedimento.__atualizado)
                nucleo_procedimento.consultar();
            let status = false;
            try {
                switch (nucleo_procedimento.sis_nucleo_prc_cd) {
                    case 45060:
                        status = yield service_1.default.AplicarPrecos();
                        break;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0080`, `batch_module_m0080.start Error`, e);
                status = false;
            }
            finally {
                return status;
            }
        });
    }
}
exports.default = batch_module_m0045;
