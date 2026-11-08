"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const service_1 = __importDefault(require("./service/service"));
const report_1 = __importDefault(require("./report/report"));
class m0071interface {
}
m0071interface.service = service_1.default;
m0071interface.report = report_1.default;
exports.default = m0071interface;
