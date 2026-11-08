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
//import postgre_pool from '../../database/postgre'
const F0132_04_TbComercialPrePedido_List_1 = __importDefault(require("./F0132_04_TbComercialPrePedido_List"));
const DataBase_1 = __importDefault(require("../../database/DataBase"));
const myDataBase = new DataBase_1.default();
let pedidoCompra = [];
const comercial = {
    PedidosPendentes: () => __awaiter(void 0, void 0, void 0, function* () {
        //pedidoCompra =  await postgre_pool.DataGet(F0132_04_TbComercialPrePedido_List.get_Postgre('2022-01-01', '2022-04-29',0,0)) as  TbPedidoCompra[]   
        pedidoCompra = (yield myDataBase.pag.DataGet(F0132_04_TbComercialPrePedido_List_1.default.get_Postgre('2022-01-01', '2022-04-29', 0, 0)));
        return pedidoCompra;
    }),
};
exports.default = comercial;
