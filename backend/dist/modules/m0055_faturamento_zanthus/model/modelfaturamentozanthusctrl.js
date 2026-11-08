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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const tbfaturamentozanthus_1 = __importDefault(require("../tbs/tbfaturamentozanthus"));
const tbfaturamentozanthus_ctrl_1 = __importDefault(require("../tbs/tbfaturamentozanthus_ctrl"));
const tbfaturamentozanthusitem_1 = __importDefault(require("../tbs/tbfaturamentozanthusitem"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const DataBase_1 = __importDefault(require("../../../database/DataBase"));
const f0055_60_faturamento_cupom_processamento_1 = __importDefault(require("../scriptspg/f0055_60_faturamento_cupom_processamento"));
const f0055_61_faturamento_cupom_cancelamento_1 = __importDefault(require("../scriptspg/f0055_61_faturamento_cupom_cancelamento"));
const Zanthus_Cupom_1 = __importDefault(require("../scriptsql/Zanthus_Cupom"));
const Zanthus_CupomItem_1 = __importDefault(require("../scriptsql/Zanthus_CupomItem"));
class modelFaturamentozanthus_Ctrl extends tbfaturamentozanthus_ctrl_1.default {
    constructor() {
        super();
        this.Cupons = [];
    }
    __CupomProcessar(filter, CupomProcessamentoInicial) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            try {
                //let listCUPOM : Array<tbfaturamentozanthus> = await FaturamentoZanthus.TbFaturamento_List(await this.Cupons_Obter(), false);
                //let ListItem: Array<tbfaturamentozanthusitem> = await FaturamentoZanthus.TbFaturamentoItem_List(await this.Itens_Obter(), false)
                yield this.__BaseZanthusCupom_Get(filter, CupomProcessamentoInicial);
                yield this.__BaseZanthusCupomItem_Get(filter, CupomProcessamentoInicial);
                let scriptSQL = "";
                //__DESENVOL await console.log(`Número de Cupons..: ${this.My_List_Cupom.length}`)
                //__DESENVOL await console.log(`Numero de Itens...: ${this.My_List_Cupom_Item.length}`)
                //__DESENVOL await console.log("processando registros...")
                const controle_MaxObject = this.My_List_Cupom.length - 1;
                const controle_block = 10;
                let control_i = 0;
                let i = 0;
                try {
                    //for (let i = 0; i <= controle_MaxObject; i++)
                    for (var _g = true, _h = __asyncValues(this.My_List_Cupom), _j; _j = yield _h.next(), _a = _j.done, !_a; _g = true) {
                        _c = _j.value;
                        _g = false;
                        let itemFaturamentoZanthus = _c;
                        scriptSQL = (yield scriptSQL) + ` ${itemFaturamentoZanthus._Db_Pg_script_Insert()} `;
                        let ListForCupomItem = yield this.__My_List_Cupom_Item_filter(itemFaturamentoZanthus.fat_zanthus_cupomfiscal_m00ad);
                        try {
                            //console.log(`teste 20/01/2025 VALOR DO I: ${i}`)
                            //console.log(itemFaturamentoZanthus)
                            //Inserindo os itens dos cupoms 
                            for (var _k = true, ListForCupomItem_1 = (e_2 = void 0, __asyncValues(ListForCupomItem)), ListForCupomItem_1_1; ListForCupomItem_1_1 = yield ListForCupomItem_1.next(), _d = ListForCupomItem_1_1.done, !_d; _k = true) {
                                _f = ListForCupomItem_1_1.value;
                                _k = false;
                                let iItem = _f;
                                scriptSQL = (yield scriptSQL) + ` ${iItem._Db_Pg_script_Insert()} `;
                            }
                        }
                        catch (e_2_1) { e_2 = { error: e_2_1 }; }
                        finally {
                            try {
                                if (!_k && !_d && (_e = ListForCupomItem_1.return)) yield _e.call(ListForCupomItem_1);
                            }
                            finally { if (e_2) throw e_2.error; }
                        }
                        if (i == controle_MaxObject || control_i >= controle_block) {
                            //__DESENVOL await console.log("Atualizando... ")
                            yield this._Db_Pg_DataPost(scriptSQL);
                            scriptSQL = ``;
                            control_i = 0;
                        }
                        yield control_i++;
                        yield i++;
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_g && !_a && (_b = _h.return)) yield _b.call(_h);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                //__DESENVOL await console.log("Insert Registros finalizados ")
            }
            catch (e) {
                console.log(`ModelTbFaturamentozanthus_Ctrl | ${e}`);
            }
        });
    }
    __CupomFaturar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                //await console.log("Faturando ecf...");
                let script = `select ${f0055_60_faturamento_cupom_processamento_1.default.sqlScript_VERSION()}
                        (   vdata_processamento:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.fat_zanthus_data_m00af)}'
                        ,   vsat_ecf:= ${this.fat_zanthus_sat_ecf_m00ac}
                        ,   vcupomfiscal:= 0
                        )`;
                yield this._Db_Pg_DataPost(script);
            }
            catch (e) {
                throw new Error(`ModelTbFaturamentozanthus_Ctrl | Error \n ${e}`);
            }
        });
    }
    __BaseZanthusCupom_Get(filter, CupomProcessamentoInicial) {
        return __awaiter(this, void 0, void 0, function* () {
            //let mylist = new Array<tbfaturamentozanthus>(); 
            try {
                //await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaCupons(this.My_List_Cupom, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSSQLSERVER")
                yield modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaCupons(this.My_List_Cupom, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial, "ZANTHUSPOSTGRE");
                /*
                let DataObject : Object =  await this.ZanthusSQL_DataGet(Zanthus_Cupom.getBaseZanthusSQLServer(filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                let mylist = new Array<tbfaturamentozanthus>();
                for (const [key, value] of Object.entries(DataObject)) {
                    let i = new tbfaturamentozanthus();
                    await i.binding(value)
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    await mylist.push(i)
                }
                this.My_List_Cupom = mylist;*/
                return Promise.resolve(this.My_List_Cupom);
            }
            catch (e) {
                Tools_1.default.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais");
                return Promise.reject(this.My_List_Cupom);
            }
        });
    }
    __BaseZanthusCupomItem_Get(filter, CupomProcessamentoInicial) {
        return __awaiter(this, void 0, void 0, function* () {
            //let mylist = new Array<tbfaturamentozanthusitem>(); 
            try {
                //await modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaItem(this.My_List_Cupom_Item, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial,"ZANTHUSSQLSERVER")
                yield modelFaturamentozanthus_complementary.__BaseZanthusCupom_PreencherListaItem(this.My_List_Cupom_Item, filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial, "ZANTHUSPOSTGRE");
                /*

                let DataObject = await this.ZanthusSQL_DataGet(Zanthus_CupomItem.getBaseZanthusSQLServer(filter, this.fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                
                for (const [key, value] of Object.entries(DataObject)) {
                    let i = new tbfaturamentozanthusitem();
                    await i.binding(value)
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    await mylist.push(i)
                }
                this.My_List_Cupom_Item = mylist; */
                return Promise.resolve(this.My_List_Cupom_Item);
            }
            catch (e) {
                return Promise.reject(this.My_List_Cupom_Item);
            }
        });
    }
    __My_List_Cupom_Item_filter(fat_zanthus_cupomfiscal_m00ad) {
        return __awaiter(this, void 0, void 0, function* () {
            let list = new Array();
            try {
                list = yield this.My_List_Cupom_Item.filter(ListaCupom => (ListaCupom.fat_zanthus_cupomfiscal_m00ad == fat_zanthus_cupomfiscal_m00ad));
                return list;
            }
            catch (e) {
                return Promise.reject(list);
            }
        });
    }
    __ProcessarCancelados() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this._Db_Pg_DataPost(`select ${f0055_61_faturamento_cupom_cancelamento_1.default.sqlScript_VERSION()}
            (   vdata_processamento:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.fat_zanthus_data_m00af)}')`);
        });
    }
}
exports.default = modelFaturamentozanthus_Ctrl;
class modelFaturamentozanthus_complementary {
    static __BaseZanthusCupom_PreencherListaCupons(ListaDeCuponsAPreencher_1, filter_1, fat_zanthus_sat_ecf_m00ac_1, CupomProcessamentoInicial_1) {
        return __awaiter(this, arguments, void 0, function* (ListaDeCuponsAPreencher, filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial, BaseDeDados = "") {
            try {
                const myDataBase = new DataBase_1.default();
                let DataObjectListaCUPOM = new Object();
                //if (BaseDeDados == "ZANTHUSSQLSERVER")
                //    DataObjectListaCUPOM = await myDataBase.zanthusSQL.DataGet(Zanthus_Cupom.getBaseZanthusSQLServer(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                if (BaseDeDados == "ZANTHUSPOSTGRE")
                    DataObjectListaCUPOM = yield myDataBase.zanthusPostgre.DataGet(Zanthus_Cupom_1.default.getBaseZanthusPostGre(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial));
                for (const [key, value] of Object.entries(DataObjectListaCUPOM)) {
                    let i = new tbfaturamentozanthus_1.default();
                    yield i.binding(value);
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    yield ListaDeCuponsAPreencher.push(i);
                }
            }
            catch (e) {
                Tools_1.default.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais");
            }
        });
    }
    static __BaseZanthusCupom_PreencherListaItem(ListaDeCuponsAPreencher_1, filter_1, fat_zanthus_sat_ecf_m00ac_1, CupomProcessamentoInicial_1) {
        return __awaiter(this, arguments, void 0, function* (ListaDeCuponsAPreencher, filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial, BaseDeDados = "") {
            try {
                const myDataBase = new DataBase_1.default();
                let DataObject = new Object();
                //if (BaseDeDados == "ZANTHUSSQLSERVER")
                //    DataObject = await myDataBase.zanthusSQL.DataGet(Zanthus_CupomItem.getBaseZanthusSQLServer(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial))
                if (BaseDeDados == "ZANTHUSPOSTGRE")
                    DataObject = yield myDataBase.zanthusPostgre.DataGet(Zanthus_CupomItem_1.default.getBaseZanthusPostGre(filter, fat_zanthus_sat_ecf_m00ac, CupomProcessamentoInicial));
                for (const [key, value] of Object.entries(DataObject)) {
                    let i = new tbfaturamentozanthusitem_1.default();
                    yield i.binding(value);
                    //if (ToCheck) await i._Db_Pg_ToCheck();
                    yield ListaDeCuponsAPreencher.push(i);
                }
            }
            catch (e) {
                Tools_1.default.PagErrorException("M0055", "modelfaturamentozanthusctrl", e, false, "Leitura e Processamento de Cupons Fiscais");
            }
        });
    }
}
