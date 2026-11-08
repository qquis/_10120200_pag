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
const pagN2011001_1 = __importDefault(require("./console/pagN2011001"));
const argsProcessService = process.argv.slice(1);
const backConsole = (ExecucaoNumero) => __awaiter(void 0, void 0, void 0, function* () {
    if (ExecucaoNumero == "2011001")
        yield pagN2011001_1.default.execute();
});
backConsole(argsProcessService[1])
    .then((result) => { console.log("Executado com sucesso"); })
    .catch((error) => { console.log(error); process.exit(1); })
    .finally(() => { console.log("Execução finalizada"); process.exit(1); });
