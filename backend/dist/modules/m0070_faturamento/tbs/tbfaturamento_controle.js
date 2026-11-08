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
class tbfaturamento_controle extends modelbase_1.clsBase {
    constructor() {
        super();
        this.seqfaturamento_uuid = ``;
        this.faturamento_controle_seq = 0;
        this.dataemissao = new Date;
        this.datafaturamento = new Date;
        this.numeropedido = 0;
        this.numeropedido_fv = 0;
        this.df_nf_seq_blue = 0;
        this.numeronfe = 0;
        this.sat_ecf = 0;
        this.cupomfiscal = 0;
        this.fat_controle_tipo_cd = 0;
        this.seqfaturamento = 0;
        this.seqfaturamentoorigem = 0;
        this.op_cdoperacao = 0;
        this.cdpessoabluesoft_cliente = 0;
        this.cdpessoabluesoft_vendedor = 0;
    }
    binding(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    this.seqfaturamento_uuid = item === null || item === void 0 ? void 0 : item.seqfaturamento_uuid;
                    this.faturamento_controle_seq = item === null || item === void 0 ? void 0 : item.faturamento_controle_seq;
                    this.dataemissao = item === null || item === void 0 ? void 0 : item.dataemissao; //this.myTools._datemomentDatStrToDate(`${item?.dataemissao}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                    this.datafaturamento = item === null || item === void 0 ? void 0 : item.dataemissao; // this.myTools._datemomentDatStrToDate(`${item?.datafaturamento}`, 'YYYY-MM-DDTHH:mm:ss.SSSZ'), 
                    this.numeropedido = item === null || item === void 0 ? void 0 : item.numeropedido;
                    this.numeropedido_fv = item === null || item === void 0 ? void 0 : item.numeropedido_fv;
                    this.df_nf_seq_blue = item === null || item === void 0 ? void 0 : item.df_nf_seq_blue;
                    this.numeronfe = item === null || item === void 0 ? void 0 : item.numeronfe;
                    this.sat_ecf = item === null || item === void 0 ? void 0 : item.sat_ecf;
                    this.cupomfiscal = item === null || item === void 0 ? void 0 : item.cupomfiscal;
                    this.fat_controle_tipo_cd = item === null || item === void 0 ? void 0 : item.fat_controle_tipo_cd;
                    this.seqfaturamento = item === null || item === void 0 ? void 0 : item.seqfaturamento;
                    this.seqfaturamentoorigem = item === null || item === void 0 ? void 0 : item.seqfaturamentoorigem;
                    this.op_cdoperacao = item === null || item === void 0 ? void 0 : item.op_cdoperacao;
                    this.cdpessoabluesoft_cliente = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_cliente;
                    this.cdpessoabluesoft_vendedor = item === null || item === void 0 ? void 0 : item.cdpessoabluesoft_vendedor;
                }
            }
            catch (e) {
                this.myTools.pagConsole(`\n PAG ERROR ---------------------------------------------------- 
                             \n Class tbfaturamento_controle \n Binding \n Error description \n ${e}`);
                throw new Error(`\n PAG ERROR ---------------------------------------------------- 
                             \n Class tbfaturamento_controle \n Binding \n Error description \n ${e}`);
            }
        });
    }
}
exports.default = tbfaturamento_controle;
