"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const reportFaturamentoBluesoftList_1 = __importDefault(require("./reportFaturamentoBluesoftList"));
const reportFaturamentoBluesoftStatus_1 = __importDefault(require("./reportFaturamentoBluesoftStatus"));
const report_faturamentoBluesoft_RedShift_1 = __importDefault(require("./report.faturamentoBluesoft.RedShift"));
const reportFaturamentoBluesoftProcesso_1 = __importDefault(require("./reportFaturamentoBluesoftProcesso"));
const reportFaturamentoBluesoft_SistemaLog_1 = __importDefault(require("./reportFaturamentoBluesoft.SistemaLog"));
const reportFaturamentoBluesoft_FV_PedidoComCorte_1 = __importDefault(require("./reportFaturamentoBluesoft.FV.PedidoComCorte"));
class reportForcaVenda {
}
reportForcaVenda.PedidoComCorte = reportFaturamentoBluesoft_FV_PedidoComCorte_1.default;
class reportFaturamentoBluesoft {
}
reportFaturamentoBluesoft.list = reportFaturamentoBluesoftList_1.default;
reportFaturamentoBluesoft.statusList = reportFaturamentoBluesoftStatus_1.default;
reportFaturamentoBluesoft.redshift_list = report_faturamentoBluesoft_RedShift_1.default;
reportFaturamentoBluesoft.processo = reportFaturamentoBluesoftProcesso_1.default;
reportFaturamentoBluesoft.Log = reportFaturamentoBluesoft_SistemaLog_1.default;
reportFaturamentoBluesoft.ForcaVenda = reportForcaVenda;
exports.default = reportFaturamentoBluesoft;
