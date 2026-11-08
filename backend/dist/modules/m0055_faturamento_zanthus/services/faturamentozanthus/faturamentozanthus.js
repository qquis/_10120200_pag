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
const tbfaturamentozanthus_ctrl_cupom_1 = __importDefault(require("../../tbs/tbfaturamentozanthus_ctrl_cupom"));
const tbfaturamentozanthus_1 = __importDefault(require("../../tbs/tbfaturamentozanthus"));
const tbfaturamentozanthusitem_1 = __importDefault(require("../../tbs/tbfaturamentozanthusitem"));
const model_1 = require("../../../../model/model");
const Tools_1 = __importDefault(require("../../../../tools/Tools"));
/* REPORTS */
const f0055_15_faturamento_zanthus_ctrl_consultar_1 = __importDefault(require("../../scriptspg/f0055_15_faturamento_zanthus_ctrl_consultar"));
const modelfaturamentozanthusctrl_1 = __importDefault(require("../../model/modelfaturamentozanthusctrl"));
class FaturamentoZanthus extends model_1.modelReport {
    static Report_Ctrl_Get(filter) {
        const _super = Object.create(null, {
            Get: { get: () => super.Get }
        });
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield _super.Get.call(this, f0055_15_faturamento_zanthus_ctrl_consultar_1.default.SELECT(filter));
            let list = yield FaturamentoZanthus.Ctrl_List(result, false);
            return Promise.resolve(list);
        });
    }
    static Ctrl_List(DataBaseSelectResult_1) {
        return __awaiter(this, arguments, void 0, function* (DataBaseSelectResult, ToCheck = false) {
            let mylist = new Array();
            for (const [key, value] of Object.entries(DataBaseSelectResult)) {
                let i = new modelfaturamentozanthusctrl_1.default();
                yield i.binding(value);
                if (ToCheck)
                    yield i._Db_Pg_CRUD();
                //console.log(i)
                yield mylist.push(i);
            }
            return Promise.resolve(mylist);
        });
    }
    static Ctrl_Cupom_List(DataBaseSelectResult_1) {
        return __awaiter(this, arguments, void 0, function* (DataBaseSelectResult, ToCheck = false) {
            let mylist = new Array();
            for (const [key, value] of Object.entries(DataBaseSelectResult)) {
                let i = new tbfaturamentozanthus_ctrl_cupom_1.default();
                yield i.binding(value);
                if (ToCheck)
                    yield i._Db_Pg_ToCheck();
                yield mylist.push(i);
            }
            return Promise.resolve(mylist);
        });
    }
    static TbFaturamento_List(DataBaseSelectResult_1) {
        return __awaiter(this, arguments, void 0, function* (DataBaseSelectResult, ToCheck = false) {
            let mylist = new Array();
            for (const [key, value] of Object.entries(DataBaseSelectResult)) {
                let i = new tbfaturamentozanthus_1.default();
                yield i.binding(value);
                if (ToCheck)
                    yield i._Db_Pg_ToCheck();
                yield mylist.push(i);
            }
            return Promise.resolve(mylist);
        });
    }
    static TbFaturamentoItem_List(DataBaseSelectResult_1) {
        return __awaiter(this, arguments, void 0, function* (DataBaseSelectResult, ToCheck = false) {
            let mylist = new Array();
            for (const [key, value] of Object.entries(DataBaseSelectResult)) {
                let i = new tbfaturamentozanthusitem_1.default();
                yield i.binding(value);
                if (ToCheck)
                    yield i._Db_Pg_ToCheck();
                yield mylist.push(i);
            }
            return Promise.resolve(mylist);
        });
    }
    static Ctrl_FaturamentoUpdate(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, _b, _c, _d, _e;
            try {
                let scriptUpdateSqlFaturamentoCrlZanthus = `
                update tbfaturamentozanthus_ctrl a
                set    fat_cupom_qtde 		= x.fat_cupom_qtde
                    ,  fat_cupom_inicial 	= x.fat_cupom_inicial
                    ,  fat_cupom_final 		= x.fat_cupom_final
                    ,  fat_cupom_valor 		= x.fat_cupom_valor
                from 	( 	select 		f.datafaturamento						as fat_zanthus_data_m00af
                                    ,	o.sat_ecf 								as fat_zanthus_sat_ecf_m00ac 
                                    ,	count(distinct(o.cupomfiscal))			as fat_cupom_qtde 
                                    ,	min(o.cupomfiscal)  					as fat_cupom_inicial
                                    ,	max(o.cupomfiscal) 						as fat_cupom_final
                                    ,	sum(i.valortotalfaturamentoliquido) 	as fat_cupom_valor
                            from 		tbfaturamento			 f
                            inner join 	tbfaturamentoorigem 	 o on o.seqfaturamento = f.seqfaturamento 
                            inner join  tbfaturamentoitens      i on i.seqfaturamentoorigem = o.seqfaturamentoorigem 
                            where		1 = 1
                            and			f.datafaturamento >= '${Tools_1.default._datemomentDateToStr((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini, 'YYYY-MM-DD')}'
                            and			f.datafaturamento <= '${Tools_1.default._datemomentDateToStr((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim, 'YYYY-MM-DD')}'
                            ${((_c = filter.filter) === null || _c === void 0 ? void 0 : _c.sat_ecf) && ((_d = filter.filter) === null || _d === void 0 ? void 0 : _d.sat_ecf) !== 0 ? ` and o.sat_ecf = ${(_e = filter.filter) === null || _e === void 0 ? void 0 : _e.sat_ecf}` : ``}
                            group by 	f.datafaturamento	
                                    ,	o.sat_ecf 
                            order by 	f.datafaturamento
                                    ,	o.sat_ecf 
                        ) x 
                where 	a.fat_zanthus_data_m00af = x.fat_zanthus_data_m00af
                and 	a.fat_zanthus_sat_ecf_m00ac = x.fat_zanthus_sat_ecf_m00ac
            
            `;
                yield this.Execute(scriptUpdateSqlFaturamentoCrlZanthus);
            }
            catch (e) {
                Tools_1.default.PagErrorException(`FaturamentoZanthus`, `Ctrl_FaturamentoUpdate`, e, true, `Atualização dos dados de Pag/Faturamento Ctrl/Zanthus`);
            }
        });
    }
}
exports.default = FaturamentoZanthus;
