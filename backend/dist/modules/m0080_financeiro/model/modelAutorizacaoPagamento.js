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
exports.modelAutorizacaoPagamentoRouter = exports.modelAutorizacaoPagamento = void 0;
const express_1 = require("express");
// class tools
const Tools_1 = __importDefault(require("../../../tools/Tools"));
const modelbase_1 = require("../../../model/modelbase");
// Class tbs
const TbAutorizacaoPagamento_1 = __importDefault(require("../tbs/TbAutorizacaoPagamento"));
const tbautorizacaopagamento_abatimento_1 = __importDefault(require("../tbs/tbautorizacaopagamento_abatimento"));
// Class scripts
const f0080_01_autorizacaopagamento_integ_1 = __importDefault(require("../scriptpg/f0080_01_autorizacaopagamento_integ"));
const scriptSelectAutorizacaoPgto_1 = __importDefault(require("../scriptpg/scriptSelectAutorizacaoPgto"));
const myClsBase = new modelbase_1.clsBase();
const modelAutorizacaoPagamentoRouter = (0, express_1.Router)();
exports.modelAutorizacaoPagamentoRouter = modelAutorizacaoPagamentoRouter;
modelAutorizacaoPagamentoRouter.get("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let item = new modelAutorizacaoPagamento();
    let itemResult = {};
    try {
        if (req.query) {
            if (req.query.autpgto_seq_pk) {
                itemResult = yield item.select({ autpgto_seq_pk: req.query.autpgto_seq_pk });
            }
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "modelAutorizacaoPagamentoRouter", e);
    }
    finally {
        return res.send(itemResult);
    }
}));
modelAutorizacaoPagamentoRouter.post("/", (req, res) => __awaiter(void 0, void 0, void 0, function* () {
    let item = new modelAutorizacaoPagamento();
    let itemResult = {};
    try {
        if (req.query) {
            if (req.query.autpgto_seq_pk) {
                console.log("Parâmetros recebidos: ", req.query);
                yield item.atualizarDadosPag(req.query);
                console.log("itemResult: ", itemResult);
            }
        }
    }
    catch (e) {
        modelbase_1.clsTools.PagErrorException("M0080", "modelAutorizacaoPagamentoRouter", e);
    }
    finally {
        return res.send(itemResult);
    }
}));
class modelAutorizacaoPagamento extends TbAutorizacaoPagamento_1.default {
    constructor() {
        super();
        this.abatimentoList = [];
    }
    select(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            //Por enquanto não retornaremos o próprio objeto, mas sim o resultado da consulta. Posteriomente
            //poderemos retornar o objeto já preenchido com os dados da consulta.
            let resultItem = {};
            try {
                const myTools = new modelbase_1.clsBase();
                let result = yield myTools.myDataBase.pag.DataGet(scriptSelectAutorizacaoPgto_1.default.sql({ autpgto_seq_pk: parametros.autpgto_seq_pk }, false));
                resultItem = myTools.myDataBase.RecordItem(result, 0);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelAutorizacaoPagamento`, 'consultar', e);
            }
            finally {
                return resultItem;
            }
        });
    }
    atualizarDadosPag(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                console.log(parametros);
                if (!parametros.autpgto_seq_pk || parametros.autpgto_seq_pk == 0) {
                    throw new Error("Parâmetros inválidos para vincular conta de pagamento.");
                }
                let sql = ` update tbautorizacaopagamento set dtlog_update = current_timestamp where autpgto_seq_pk = ${parametros.autpgto_seq_pk} ;`;
                if (parametros.competencia_cd && parseInt(parametros.competencia_cd) !== 0) {
                    console.log("Atualizando competência na autorização de pagamento: ", parametros.competencia_cd);
                    sql += `  update tbautorizacaopagamento 
                            set competencia_cd = ${parametros.competencia_cd}
                            where autpgto_seq_pk = ${parametros.autpgto_seq_pk}    
                        ; `;
                }
                yield myClsBase.myDataBase.pag.Execute(sql);
                console.log("dados atualizados com sucesso.");
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelAutorizacaoPagamento`, 'vincularContaPag', e);
            }
        });
    }
    getSqlBlueSoftIntegrar() {
        let sql = `select  ${f0080_01_autorizacaopagamento_integ_1.default.sqlScript_VERSION()}
        (   sqlcommand:= 'INTEG_API' 
          , vautpgto_seq_pk:= ${this.autpgto_seq_pk} 
          , vautpgto_cdpessoabluesoft:= ${this.autpgto_cdpessoabluesoft}
          , vautpgto_tipo:= '${this.autpgto_tipo}'
          , vautpgto_dataemissao:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this === null || this === void 0 ? void 0 : this.autpgto_dataemissao)}'        
          , vautpgto_datavencimento:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_datavencimento)}' 
          , vautpgto_dataquitacao:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_dataquitacao)}' 
          , vautpgto_valorfatura:= ${this.autpgto_valorfatura}
          , vautpgto_valortotal:= ${this.autpgto_valortotal}
          , vautpgto_valorpago:= ${this.autpgto_valorpago}
          , vautpgto_nf_numero:= '${this.autpgto_nf_numero}'
          , vautpgto_valordescontofinanceiro:= ${this.autpgto_valorDescontoFinanceiro}  
          , vautpgto_numeroparcela:= ${this.autpgto_numeroparcela}   
          , vautpgto_datapagamento:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_datapagamento)}' 
          , vautpgto_nf_dataemissao:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_nf_dataemissao)}' 
          , vautpgto_valorliquido:= ${this.autpgto_valorliquido}   
          , vautpgto_datacriacao:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_datacriacao)}' 
          , vautpgto_datacancelamento:= '${Tools_1.default.format_Date_toStr_ShortDataBase(this.autpgto_datacancelamento)}'
          , vautpgto_dtlog_update_redshift:= '${Tools_1.default.pagDateTime_getDateStringLong(this.__defaultDateNow)}'
          , vautpgto_status_bluesoft_cd:= 99
          , vdescritivo:= '${this.descritivo.length > 115 ? this.descritivo.substring(0, 115) : this.descritivo}'
          , vautpgto_cancelada:= ${this.autpgto_cancelada} 
          , vautpgto_codigobarra:= '${this.autpgto_codigobarra}'
          , vcompetencia_cd:= 202405 
          , vplc_conta_cd:= ${this.plc_conta_cd} 
          , vplc_conta_cd_destino:= ${this.plc_conta_cd_destino}  
          , vbordero_seq:= ${this.bordero_seq}   
          , vautpgto_juro_diario:= ${this.autpgto_juro_diario}   
          , vautpgto_valor_multa:= ${this.autpgto_valor_multa}   
          , vautpgto_valor_abatimento:= ${this.autpgto_valor_abatimento}   
          , vautpgto_valor_juros:= ${this.autpgto_valor_juros}   
          , vautpgto_valor_juros_fixo:= ${this.autpgto_valor_juros_fixo}   
          , vem_cdempresa:= ${this.em_cdempresa}  
          , vcontrato_bluesoft_seq:= ${this.contrato_bluesoft_seq}
          , vem_cdpessoabluesoft:= ${this.em_cdpessoabluesoft} 
          );`;
        if (this.abatimentoList.length > 0) {
            let sqlitemabatimento = ``;
            this.abatimentoList.forEach((abatimento) => {
                sqlitemabatimento += `INSERT INTO tbautorizacaopagamento_abatimento (autpgto_seq_pk, autpgto_seq_pk_origem, autpgto_ab_valor)
                        SELECT ${abatimento.autpgto_seq_pk}, ${abatimento.autpgto_seq_pk_origem}, ${abatimento.autpgto_ab_valor}
                        WHERE NOT EXISTS (SELECT 1 FROM tbautorizacaopagamento_abatimento WHERE autpgto_seq_pk_origem = ${abatimento.autpgto_seq_pk_origem});
                        `;
            });
            sql = sqlitemabatimento + sql;
            /*OBS
              Incluir sempre os abatimentos primeiro para posteriormente o registro da duplicata em si,
              já que no processamento da duplicata, iremos fazer a leitura dos possíveis abatimentos.
              
            */
        }
        return sql;
    }
    bindingBlueSoftApi(item) {
        return __awaiter(this, void 0, void 0, function* () {
            if (item != undefined) {
                this.em_cdpessoabluesoft = item.lojaKey != undefined ? parseInt(`${item.lojaKey}`) : 0;
                this.autpgto_seq_pk = item.duplicataKey != undefined ? parseInt(`${item.duplicataKey}`) : 0;
                this.autpgto_cdpessoabluesoft = parseInt(`${item.especie == "PAGAMENTO" ? item.cedenteKey : item.sacadoKey}`);
                this.autpgto_tipo = item.especie == "PAGAMENTO" ? "P" : "R";
                this.descritivo = item.descritivo != "" ? `${item.descritivo}`.replace("'", "") : "";
                this.autpgto_dataemissao = Tools_1.default._dataConvertStrtoDate(`${item.dataEmissao ? item.dataEmissao : "01/01/1900"}`, `item.dataEmissao`);
                this.autpgto_datavencimento = Tools_1.default._dataConvertStrtoDate(`${item.dataVencimento ? item.dataVencimento : "01/01/1900"}`, `item.dataVencimento`);
                //this.autpgto_dataquitacao = myTools.Date_br_timestamp(`${item.dataQuitacao? item.dataQuitacao : "01/01/1900"}`) 
                this.autpgto_valorfatura = parseFloat(`${item.valorNominal}`);
                this.autpgto_valortotal = 0;
                this.autpgto_valorpago = parseFloat(`${item.valorPago}`);
                if (item.notaFiscal)
                    this.autpgto_nf_numero = `${item.notaFiscal.numeroNfe ? item.notaFiscal.numeroNfe : "0"}`;
                this.autpgto_valorDescontoFinanceiro = parseFloat(`${item.valorDesconto}`);
                this.autpgto_numeroparcela = parseInt(`${item.numeroParcelas}`);
                this.autpgto_datapagamento = Tools_1.default._dataConvertStrtoDate(`${item.autpgto_datapagamento ? item.autpgto_datapagamento : "01/01/1900"}`);
                this.autpgto_nf_dataemissao = Tools_1.default._dataConvertStrtoDate(`${item.dataEmissao ? item.dataEmissao : "01/01/1900"}`);
                this.autpgto_valorliquido = parseFloat(`${item.valorLiquido ? item.valorLiquido : 0}`);
                this.autpgto_datacriacao = Tools_1.default._dataConvertStrtoDate(`${item.dataCriacao}`);
                this.autpgto_datacancelamento = Tools_1.default._dataConvertStrtoDate(`${item.dataCancelamento ? item.dataCancelamento : "01/01/1900"}`);
                this.autpgto_DtLog_update_redshift = this.__defaultDateNow;
                this.autpgto_status_cd = 0;
                this.autpgto_cancelada = item.dataCancelamento ? 1 : 0;
                this.autpgto_codigobarra = item.codigoBarras ? item.codigoBarras : "";
                this.competencia_cd = 0;
                this.plc_conta_cd = parseInt(`${item.contaContabilKey}`);
                this.plc_conta_cd_destino = 0;
                this.bordero_seq = 0;
                this.autpgto_juro_diario = 0;
                this.autpgto_valor_multa = 0;
                this.autpgto_valor_abatimento = 0;
                this.autpgto_valor_juros = 0;
                this.autpgto_valor_juros_fixo = 0;
                if (item.abatimentos) {
                    item.abatimentos.forEach((ab) => {
                        const abatimento = new tbautorizacaopagamento_abatimento_1.default();
                        abatimento.autpgto_seq_pk = item.duplicataKey; /*Numero da propria duplicata*/
                        abatimento.autpgto_seq_pk_origem = ab.duplicataKey; /*Numero da duplicata original*/
                        abatimento.autpgto_ab_valor = ab.valor;
                        this.abatimentoList.push(abatimento);
                    });
                }
            }
        });
    }
}
exports.modelAutorizacaoPagamento = modelAutorizacaoPagamento;
