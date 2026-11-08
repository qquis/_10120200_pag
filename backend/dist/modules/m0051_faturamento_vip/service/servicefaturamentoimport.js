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
const modelbase_1 = require("../../../model/modelbase");
const api_1 = __importDefault(require("../../Apis/vipApi/api"));
const modelparticipanteVip_1 = __importDefault(require("../../m0011_participante/model/modelparticipanteVip"));
const modelfaturamentovip_1 = __importDefault(require("../model/modelfaturamentovip"));
const modelfaturamentovipnotificacao_1 = __importDefault(require("../model/modelfaturamentovipnotificacao"));
class serviceFaturamentoVipImport {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            let resultSucess = 0;
            try {
                modelbase_1.clsTools.pagConsole(`F0051 - Faturamento VIP - Service serviceFaturamentoVipImport - Inicializado`);
                let param = {
                    page: 1,
                    start_created: (() => {
                        const now = new Date();
                        now.setDate(now.getDate() - 10);
                        const yyyy = now.getFullYear();
                        const mm = String(now.getMonth() + 1).padStart(2, '0');
                        const dd = String(now.getDate()).padStart(2, '0');
                        return `${yyyy}-${mm}-${dd} 01:01:01`;
                    })(),
                    end_created: (() => {
                        const now = new Date();
                        const yyyy = now.getFullYear();
                        const mm = String(now.getMonth() + 1).padStart(2, '0');
                        const dd = String(now.getDate()).padStart(2, '0');
                        const hh = String(now.getHours()).padStart(2, '0');
                        const min = String(now.getMinutes()).padStart(2, '0');
                        const ss = String(now.getSeconds()).padStart(2, '0');
                        return `${yyyy}-${mm}-${dd} ${hh}:${min}:${ss}`;
                    })()
                };
                let numeroPaginas = yield api_1.default.faturamentoPedido.pagination(param);
                modelbase_1.clsTools.pagConsole(`F0011 - Participante - Service serviceParticipanteVipImport - Inicializado _ N de Paginas: ${numeroPaginas}`);
                let i = 0;
                let maxInsert = 2;
                let sqlinsertBlock = '';
                for (let p = 1; p <= numeroPaginas; p++) {
                    param.page = p;
                    let result = yield api_1.default.faturamentoPedido.get(param);
                    try {
                        for (var _d = true, _e = (e_1 = void 0, __asyncValues(Object.entries(result))), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                            _c = _f.value;
                            _d = false;
                            const [key, value] = _c;
                            let item = new modelfaturamentovip_1.default();
                            item.binding(value);
                            sqlinsertBlock += item.getCrudSql();
                            if (i >= maxInsert) {
                                yield this.DataBaseExecute(sqlinsertBlock);
                                sqlinsertBlock = '';
                                i = 0;
                            }
                            i++;
                        }
                    }
                    catch (e_1_1) { e_1 = { error: e_1_1 }; }
                    finally {
                        try {
                            if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                        }
                        finally { if (e_1) throw e_1.error; }
                    }
                }
                if (sqlinsertBlock != '') {
                    yield this.DataBaseExecute(sqlinsertBlock);
                    sqlinsertBlock = '';
                }
                //list.map(item => { console.log(item.participante_vip.vip_nome) } )
                modelbase_1.clsTools.pagConsole(`F0051 - Faturamento VIP - Service serviceFaturamentoVipImport | Paginas: ${numeroPaginas} `);
                /* PROCESSAR NOTIFICAÇÕES */
                yield serviceFaturamentoVipImport.Notificar();
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.start()`, e, true);
                throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
            }
        });
    }
    static Notificar() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_2, _b, _c;
            try {
                /* Gerando as notificaçẽos pendentes */
                let sqlNotificacoesPendentes = `
                insert into tbfaturamento_vip_notificacao
                        (
                                id					
                            ,	notificacao_cd		
                            ,	compra_status_id 	
                            ,	notificado

                        )
                        select 			f.id
                                    ,	s.notificacao_cd 
                                    ,	f.compra_status_id
                                    ,	0
                        from 			tbfaturamento_vip f
                        left join 		tbfaturamento_vip_compra_status s on s.compra_status_id = f.compra_status_id
                        where			1 = 1 
                        and             f.created >= date_trunc('day', current_timestamp - interval '1 day') -- primeira hora do dia anterior
                        and				not exists
                                                ( 	select 	1 
                                                    from 	tbfaturamento_vip_notificacao aa
                                                    where	1 = 1
                                                    and     aa.id = f.id
                                                    and     aa.compra_status_id = f.compra_status_id
                                                    and     aa.notificacao_cd = s.notificacao_cd
                                                )
                        and				coalesce(s.notificacao_cd ,0) > 0
                
                
                `;
                let myDATABASE = new modelbase_1.clsBase();
                yield myDATABASE.myDataBase.pag.Execute(sqlNotificacoesPendentes);
                /*Obtendo a lista de notificações pendentes*/
                let sqlNotificacoesPendentesList = `
                                select 	n.id
                                    ,	f.data_entrega
                                    ,	f.qtd_itens
                                    ,	f.qtd_produtos
                                    ,	coalesce(f.valor_final ,0) as valor_final 
                                    ,   n.faturamento_vip_notificacao_seq
                                    ,   n.notificacao_cd
                                    ,   n.compra_status_id
                                    ,   n.notificado
                                    ,   s.compra_status_descricao
                                    ,   f.cliente_id 
                                    ,   p.vip_nome
                            from 	tbfaturamento_vip_notificacao       n
                            inner join tbfaturamento_vip                f on f.id = n.id
                            inner join tbfaturamento_vip_compra_status  s on s.compra_status_id = n.compra_status_id
                            left join  tbparticipante_vip p on p.vip_id = f.cliente_id
                            where  1 = 1
                            and    n.notificado = 0 `;
                let resultListNotificacao = yield myDATABASE.myDataBase.pag.DataGet(sqlNotificacoesPendentesList);
                try {
                    for (var _d = true, _e = __asyncValues(Object.entries(resultListNotificacao)), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const [key, value] = _c;
                        let itemNotificacao = new modelfaturamentovipnotificacao_1.default();
                        itemNotificacao.modelBinding(value);
                        if (itemNotificacao.vip_nome == null || itemNotificacao.vip_nome == '') {
                            let participanteVip = new modelparticipanteVip_1.default();
                            yield participanteVip.getApi(itemNotificacao.cliente_id);
                            itemNotificacao.vip_nome = participanteVip.vip_nome_completo;
                        }
                        yield itemNotificacao.notificar();
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_2) throw e_2.error; }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.Notificar()`, e, true);
                throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
            }
        });
    }
    static DataBaseExecute(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let myDATABASE = new modelbase_1.clsBase();
                yield myDATABASE.myDataBase.pag.Execute(sql);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`F0051 - Faturamento VIP`, `serviceFaturamentoVipImport.DataBaseExecute()`, e, true);
                throw new Error(`modules | Faturamento VIP | Error ${e.message}`);
            }
        });
    }
}
exports.default = serviceFaturamentoVipImport;
