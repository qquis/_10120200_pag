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
const model_1 = require("../../../model/model");
class tbnotificacao_participante extends model_1.modelTb {
    constructor() {
        super();
        this.cdparticipante = 0;
        this.notificacao_cd = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item != undefined) {
                    this.notificacao_cd = item.notificacao;
                    this.cdparticipante = item === null || item === void 0 ? void 0 : item.cdparticipante;
                }
            }
            catch (e) {
                throw new Error(`Erro ${e}`);
            }
        });
    }
    _Db_Pg_script_Insert() {
        return ` INSERT INTO tbnotificacao_participante 
                        (
                            , cdparticipante 
                            , notificacao_cd 
                        )
                        values 
                        (   
                                ${this.cdparticipante} 
                             ,  ${this.notificacao_cd} 
                        )
        `;
    }
}
exports.default = tbnotificacao_participante;
