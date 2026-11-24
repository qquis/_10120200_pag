"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const FLG_INFO = modelbase_1.clsTools.pagLogSet({ SISTEMA_NUCLEO_PRC_CD: 0,
    FLG_DEBUG_CONSOLE_LOG: true,
    FLG_MODULO: "M0071_INTERFACE MTRIX ",
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
});
class modelInterfaceMTRIX {
    static get(parametros) {
    }
    static __log(message) {
        if (FLG_INFO.FLG_DEBUG_CONSOLE_LOG) {
            modelbase_1.clsTools.pagLogInfo(message, FLG_INFO);
        }
    }
    static __logError(ex) {
        if (FLG_INFO.FLG_DEBUG_CONSOLE_LOG) {
            modelbase_1.clsTools.PagErrorException(FLG_INFO.FLG_MODULO, "MTRIX", ex, false, "", FLG_INFO.FLG_DEBUG_CONSOLE_LOG);
        }
    }
}
exports.default = modelInterfaceMTRIX;
