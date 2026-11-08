"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class tbfc_cbenef {
    constructor() {
        this.fc_cbenef_cd = '';
        this.fc_cbenef_bluesoft_cd = 0;
        this.fc_cbenef_dispositivo = '';
        this.fc_cbenef_objetivo = '';
        this.fc_cbenef_bluesoft_dispositivo = '';
        this.fc_cbenef_bluesoft_objetivo = '';
        this.fc_cbenef_bluesoft = 0;
    }
    binding(item) {
        if (item) {
            this.fc_cbenef_cd = item === null || item === void 0 ? void 0 : item.fc_cbenef_cd;
            this.fc_cbenef_bluesoft_cd = item === null || item === void 0 ? void 0 : item.fc_cbenef_bluesoft_cd;
            this.fc_cbenef_dispositivo = item === null || item === void 0 ? void 0 : item.fc_cbenef_dispositivo;
            this.fc_cbenef_objetivo = item === null || item === void 0 ? void 0 : item.fc_cbenef_objetivo;
            this.fc_cbenef_bluesoft_dispositivo = item === null || item === void 0 ? void 0 : item.fc_cbenef_bluesoft_dispositivo;
            this.fc_cbenef_bluesoft_objetivo = item === null || item === void 0 ? void 0 : item.fc_cbenef_bluesoft_objetivo;
            this.fc_cbenef_bluesoft = item === null || item === void 0 ? void 0 : item.fc_cbenef_bluesoft;
        }
    }
}
exports.default = tbfc_cbenef;
