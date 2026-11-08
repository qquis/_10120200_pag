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
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const myBase = new modelbase_1.clsBase();
class reportFaturamentoBluesoftProcesso {
    static sql(parametro) {
        let dataInicial = modelbase_1.clsTools._datemomentSubtractDays(new Date(), 5);
        let dataFinal = new Date();
        if (parametro.dataInicial) {
            dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
        }
        if (parametro.dataFinal) {
            dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
        }
        let sql = `
                            select 		xx.fat_blue_processo_seq
                                ,		xt.fat_blue_processo_tipo_cd
                                ,		xt.fat_blue_processo_tipo_descricao
                                ,		xx.op_cdoperacao 
                                ,		xx.numeropedido 
                                ,		xx.numeropedido_fv
                                ,		xx.fat_blue_status_cd 
                                ,		xx.notificacao_cd
                                ,		xx.notificado 
                                ,		fb.valor_pedido 
                                ,		fb.valor_faturamento
                                ,		xi.qtde_itens
                                ,		xi.qtde_itens_corte 	
                                ,		v.nome_razao as vendedor_nome_razao 
                                ,		c.nome_razao as cliente_nome_razao
                                ,		g.descricao as grupo_economico_descricao 
                                ,		fb.data_emissao 
                                ,		fb.data_faturamento 
                                ,		pv.celular_dd
                                ,		pv.celular_numero
                            from 		tbfaturamento_bluesoft_processo xx
                            left join   tbfaturamento_bluesoft_processo_tipo xt on xt.fat_blue_processo_tipo_cd = xx.fat_blue_processo_tipo_cd
                            inner join 	tbfaturamento_bluesoft fb on fb.op_cdoperacao = xx.op_cdoperacao 
                                                                and  fb.numeropedido = xx.numeropedido 
                                                                and  fb.numeropedido_fv = xx.numeropedido_fv 
                            left join   tbparticipante_bluesoft v  on v.cdpessoabluesoft = fb.cdpessoabluesoft_vendedor
                            left join   tbparticipante          pv on pv.cdparticipante = v.cdparticipante 
                            left join   tbparticipante_vendedor vv on vv.cdparticipante = pv.cdparticipante 
                            left join   tbparticipante_bluesoft c on c.cdpessoabluesoft = fb.cdpessoabluesoft_cliente
                            left join   tbgrupoeconomico 		g on g.cdgrupoeconomico = c.cdgrupoeconomico 
                            left join   ( 	select 	i.numeropedido 
                                                ,	i.numeropedido_fv 
                                                ,	i.op_cdoperacao 
                                                ,	count(distinct(i.prb_cdprodutobluesoft)) qtde_itens
                                                ,	count(distinct(case when i.qtde_solicitada > qtde_faturada then i.prb_cdprodutobluesoft else null end )) qtde_itens_corte
                                            from 	tbfaturamento_bluesoft_item i
                                            inner join  tbfaturamento_bluesoft xi on xi.numeropedido = i.numeropedido 
                                            where   1 = 1
                                              and   xi.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                              and   xi.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                            group by i.numeropedido 
                                                ,	i.numeropedido_fv 
                                                ,	i.op_cdoperacao 

                                        ) xi on xi.numeropedido = xx.numeropedido and xi.numeropedido_fv = xi.numeropedido_fv and xi.op_cdoperacao = xx.op_cdoperacao 
                                                                
                            where   1 = 1 
                              and   fb.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                              and   fb.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
         
                `;
        if (parametro.vendedor_status) {
            sql += ` and vv.vendedor_status = ${parametro.vendedor_status} `;
        }
        if (parametro.notificacao_pendente) {
            sql += ` and coalesce(xx.notificado, 0) = 0 
                     and pv.celular_dd is not null and pv.celular_dd != '0'
                     and pv.celular_numero is not null and pv.celular_numero != '0' 
            `;
        }
        if (parametro.numeropedido) {
            sql += ` and xx.numeropedido = ${parametro.numeropedido} `;
        }
        if (parametro.numeropedido_fv) {
            sql += ` and xx.numeropedido_fv = ${parametro.numeropedido_fv} `;
        }
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                result = yield myBase.myDataBase.pag.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
    static getFaturamentoFVNotificacoesPendentes(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                parametro.notificacao_pendente = 1;
                parametro.vendedor_status = 1;
                result = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | getFaturamentoFVNotificacoesPendentes \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoBluesoftProcesso;
