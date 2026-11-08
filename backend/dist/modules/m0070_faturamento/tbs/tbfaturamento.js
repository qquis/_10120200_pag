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
const modelbase_1 = require("../../../model/modelbase");
class tbfaturamento extends modelbase_1.clsBase {
    constructor() {
        super();
        this.seqfaturamento = 0;
        this.datafaturamento = this.__defaultDateNow;
        this.dataemissao = this.__defaultDateNow;
        this.em_cdempresa = 0;
        this.op_cdoperacao = 0;
        this.cdparticipantecliente = 0;
        this.cdparticipantevendedor = 0;
        this.statusfaturamento = 0;
        this.seqfaturamento_uuid = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    this.seqfaturamento = item === null || item === void 0 ? void 0 : item.seqfaturamento;
                    this.datafaturamento = item === null || item === void 0 ? void 0 : item.datafaturamento; //this.myTools._datemomentDatStrToDate(`${item?.datafaturamento}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                    this.dataemissao = item === null || item === void 0 ? void 0 : item.dataemissao; //this.myTools._datemomentDatStrToDate(`${item?.dataemissao}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                    this.em_cdempresa = item === null || item === void 0 ? void 0 : item.em_cdempresa;
                    this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                    this.cdparticipantecliente = item === null || item === void 0 ? void 0 : item.cdparticipantecliente;
                    this.cdparticipantevendedor = item === null || item === void 0 ? void 0 : item.cdparticipantevendedor;
                    this.statusfaturamento = item === null || item === void 0 ? void 0 : item.statusfaturamento;
                    this.seqfaturamento_uuid = item === null || item === void 0 ? void 0 : item.seqfaturamento_uuid;
                }
            }
            catch (e) {
                this.myTools.pagConsole(`tbfaturamento | binding \n Error: ${e}`);
                throw new Error(`tbfaturamento | binding \n Error: ${e}`);
            }
        });
    }
}
exports.default = tbfaturamento;
