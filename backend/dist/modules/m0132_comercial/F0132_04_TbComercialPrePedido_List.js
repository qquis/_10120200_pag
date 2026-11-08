"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const pagToolsDate_1 = __importDefault(require("../../tools/pagToolsDate"));
const F0132_04_TbComercialPrePedido_List = {
    get_Postgre: (str_to_Date_inicio, str_to_Date_Fim, fabricante_cdpessoabluesoft, controle_status_pedido) => {
        const data_inicio = new Date(pagToolsDate_1.default.getDateFromString(str_to_Date_inicio));
        const data_fim = new Date(pagToolsDate_1.default.getDateFromString(str_to_Date_Fim));
        return `select * from f0132_04_1011872_tbcomercial_pre_pedido_list ('${pagToolsDate_1.default.str_yyyymmdd(data_inicio)}', '${pagToolsDate_1.default.str_yyyymmdd(data_fim)}', ${fabricante_cdpessoabluesoft}, ${controle_status_pedido} )`;
    }
};
exports.default = F0132_04_TbComercialPrePedido_List;
