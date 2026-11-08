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
const modelbase_1 = require("../../../model/modelbase");
const tbfc_regrafiscalNfceProduto_1 = __importDefault(require("../tbs/tbfc_regrafiscalNfceProduto"));
const myBase = new modelbase_1.clsBase();
class modelfc_regrafiscalNfceProduto extends tbfc_regrafiscalNfceProduto_1.default {
    LerDadosDaAPI(item, NFEC_PRODUTO_TIPO_CD = 1) {
        var _a, _b, _c, _d, _e, _f, _g, _h, _j, _k, _l, _m, _o, _p, _q, _r, _s, _t, _u, _v, _w, _x, _y, _z, _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _29, _30, _31, _32, _33, _34, _35, _36, _37, _38, _39, _40, _41, _42, _43, _44, _45, _46, _47, _48, _49, _50, _51, _52, _53, _54, _55, _56, _57, _58, _59, _60, _61, _62, _63, _64, _65, _66, _67, _68, _69, _70, _71, _72, _73, _74, _75, _76, _77;
        if (item) {
            this.LOCAL_STATUS_API = 1;
            this.nfce_produto_tipo_cd = NFEC_PRODUTO_TIPO_CD;
            // CBS - Reforma Tributária
            this.cbs_aliquota_ad_rem = ((_b = (_a = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _a === void 0 ? void 0 : _a.cbs) === null || _b === void 0 ? void 0 : _b.aliquotaAdRem) || 0;
            this.cbs_aliquota_desoneracao = ((_d = (_c = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _c === void 0 ? void 0 : _c.cbs) === null || _d === void 0 ? void 0 : _d.aliquotaDesoneracao) || 0;
            this.cbs_aliquota_efetiva = ((_f = (_e = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _e === void 0 ? void 0 : _e.cbs) === null || _f === void 0 ? void 0 : _f.aliquotaEfetiva) || 0;
            this.cbs_aliquota = ((_h = (_g = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _g === void 0 ? void 0 : _g.cbs) === null || _h === void 0 ? void 0 : _h.aliquota) || 0;
            this.cbs_cd = ((_k = (_j = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _j === void 0 ? void 0 : _j.cbs) === null || _k === void 0 ? void 0 : _k.cbsKey) || 0;
            this.cbs_descricao_abreviada = ((_m = (_l = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _l === void 0 ? void 0 : _l.cbs) === null || _m === void 0 ? void 0 : _m.descricaoAbreviada) || '';
            this.cbs_descricao = ((_p = (_o = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _o === void 0 ? void 0 : _o.cbs) === null || _p === void 0 ? void 0 : _p.descricao) || '';
            this.cbs_percentual_credito_presumido = ((_r = (_q = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _q === void 0 ? void 0 : _q.cbs) === null || _r === void 0 ? void 0 : _r.percentualCreditoPresumido) || 0;
            this.cbs_percentual_credito_presumido_monofasico = ((_t = (_s = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _s === void 0 ? void 0 : _s.cbs) === null || _t === void 0 ? void 0 : _t.percentualCreditoPresumidoMonofasico) || 0;
            this.cbs_percentual_diferimento = ((_v = (_u = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _u === void 0 ? void 0 : _u.cbs) === null || _v === void 0 ? void 0 : _v.percentualDiferimento) || 0;
            this.cbs_percentual_diferimento_monofasico = ((_x = (_w = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _w === void 0 ? void 0 : _w.cbs) === null || _x === void 0 ? void 0 : _x.percentualDiferimentoMonofasico) || 0;
            this.cbs_percentual_reducao = ((_z = (_y = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _y === void 0 ? void 0 : _y.cbs) === null || _z === void 0 ? void 0 : _z.percentualReducao) || 0;
            // CFOP
            this.cfop = (item === null || item === void 0 ? void 0 : item.cfopKey) || 0;
            // Códigos de regra fiscal
            this.codigo_figura_regra_fiscal = (item === null || item === void 0 ? void 0 : item.codigoFiguraRegraFiscal) || 0;
            this.codigo_regra_fiscal = (item === null || item === void 0 ? void 0 : item.codigoRegraFiscal) || 0;
            // COFINS
            this.cofins_aliquota = ((_0 = item === null || item === void 0 ? void 0 : item.cofins) === null || _0 === void 0 ? void 0 : _0.aliquota) || 0;
            this.cofins_cst = ((_1 = item === null || item === void 0 ? void 0 : item.cofins) === null || _1 === void 0 ? void 0 : _1.cst) || 0;
            // Datas
            this.data_hora_geracao = this.myTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.dataHoraGeracao, `YYYY-MM-DDTHH:mm:ss.SSSSSS`);
            this.data_referencia = (item === null || item === void 0 ? void 0 : item.dataReferencia) || '';
            // Sequencial
            this.fc_rf_nfce_seq = (item === null || item === void 0 ? void 0 : item.produtoKey) || 0;
            // IBS - Reforma Tributária
            this.ibs_aliquota_ad_rem = ((_3 = (_2 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _2 === void 0 ? void 0 : _2.ibs) === null || _3 === void 0 ? void 0 : _3.aliquotaAdRem) || 0;
            this.ibs_aliquota_desoneracao = ((_5 = (_4 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _4 === void 0 ? void 0 : _4.ibs) === null || _5 === void 0 ? void 0 : _5.aliquotaDesoneracao) || 0;
            this.ibs_aliquota_efetiva = ((_7 = (_6 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _6 === void 0 ? void 0 : _6.ibs) === null || _7 === void 0 ? void 0 : _7.aliquotaEfetiva) || 0;
            this.ibs_aliquota = ((_9 = (_8 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _8 === void 0 ? void 0 : _8.ibs) === null || _9 === void 0 ? void 0 : _9.aliquota) || 0;
            this.ibs_cd = ((_11 = (_10 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _10 === void 0 ? void 0 : _10.ibs) === null || _11 === void 0 ? void 0 : _11.ibsKey) || 0;
            this.ibs_descricao_abreviada = ((_13 = (_12 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _12 === void 0 ? void 0 : _12.ibs) === null || _13 === void 0 ? void 0 : _13.descricaoAbreviada) || '';
            this.ibs_descricao = ((_15 = (_14 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _14 === void 0 ? void 0 : _14.ibs) === null || _15 === void 0 ? void 0 : _15.descricao) || '';
            this.ibs_percentual_credito_presumido = ((_17 = (_16 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _16 === void 0 ? void 0 : _16.ibs) === null || _17 === void 0 ? void 0 : _17.percentualCreditoPresumido) || 0;
            this.ibs_percentual_credito_presumido_monofasico = ((_19 = (_18 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _18 === void 0 ? void 0 : _18.ibs) === null || _19 === void 0 ? void 0 : _19.percentualCreditoPresumidoMonofasico) || 0;
            this.ibs_percentual_diferimento = ((_21 = (_20 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _20 === void 0 ? void 0 : _20.ibs) === null || _21 === void 0 ? void 0 : _21.percentualDiferimento) || 0;
            this.ibs_percentual_diferimento_monofasico = ((_23 = (_22 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _22 === void 0 ? void 0 : _22.ibs) === null || _23 === void 0 ? void 0 : _23.percentualDiferimentoMonofasico) || 0;
            this.ibs_percentual_reducao = ((_25 = (_24 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _24 === void 0 ? void 0 : _24.ibs) === null || _25 === void 0 ? void 0 : _25.percentualReducao) || 0;
            // IBS - Reforma Tributária Municipal
            this.ibs_mun_aliquota_ad_rem = ((_27 = (_26 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _26 === void 0 ? void 0 : _26.ibsMun) === null || _27 === void 0 ? void 0 : _27.aliquotaAdRem) || 0;
            this.ibs_mun_aliquota_desoneracao = ((_29 = (_28 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _28 === void 0 ? void 0 : _28.ibsMun) === null || _29 === void 0 ? void 0 : _29.aliquotaDesoneracao) || 0;
            this.ibs_mun_aliquota_efetiva = ((_31 = (_30 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _30 === void 0 ? void 0 : _30.ibsMun) === null || _31 === void 0 ? void 0 : _31.aliquotaEfetiva) || 0;
            this.ibs_mun_aliquota = ((_33 = (_32 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _32 === void 0 ? void 0 : _32.ibsMun) === null || _33 === void 0 ? void 0 : _33.aliquota) || 0;
            this.ibs_mun_cd = ((_35 = (_34 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _34 === void 0 ? void 0 : _34.ibsMun) === null || _35 === void 0 ? void 0 : _35.ibsKey) || 0;
            this.ibs_mun_descricao_abreviada = ((_37 = (_36 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _36 === void 0 ? void 0 : _36.ibsMun) === null || _37 === void 0 ? void 0 : _37.descricaoAbreviada) || '';
            this.ibs_mun_descricao = ((_39 = (_38 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _38 === void 0 ? void 0 : _38.ibsMun) === null || _39 === void 0 ? void 0 : _39.descricao) || '';
            this.ibs_mun_percentual_credito_presumido = ((_41 = (_40 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _40 === void 0 ? void 0 : _40.ibsMun) === null || _41 === void 0 ? void 0 : _41.percentualCreditoPresumido) || 0;
            this.ibs_mun_percentual_credito_presumido_monofasico = ((_43 = (_42 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _42 === void 0 ? void 0 : _42.ibsMun) === null || _43 === void 0 ? void 0 : _43.percentualCreditoPresumidoMonofasico) || 0;
            this.ibs_mun_percentual_diferimento = ((_45 = (_44 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _44 === void 0 ? void 0 : _44.ibsMun) === null || _45 === void 0 ? void 0 : _45.percentualDiferimento) || 0;
            this.ibs_mun_percentual_diferimento_monofasico = ((_47 = (_46 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _46 === void 0 ? void 0 : _46.ibsMun) === null || _47 === void 0 ? void 0 : _47.percentualDiferimentoMonofasico) || 0;
            this.ibs_mun_percentual_reducao = ((_49 = (_48 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _48 === void 0 ? void 0 : _48.ibsMun) === null || _49 === void 0 ? void 0 : _49.percentualReducao) || 0;
            // ICMS
            this.icms_aliquota_desoneracao = ((_50 = item === null || item === void 0 ? void 0 : item.icms) === null || _50 === void 0 ? void 0 : _50.aliquotaDesoneracao) || 0;
            this.icms_aliquota_efetiva = ((_51 = item === null || item === void 0 ? void 0 : item.icms) === null || _51 === void 0 ? void 0 : _51.aliquotaEfetiva) || 0;
            this.icms_aliquota_final = ((_52 = item === null || item === void 0 ? void 0 : item.icms) === null || _52 === void 0 ? void 0 : _52.aliquotaFinal) || 0;
            this.icms_aliquota_interna = ((_53 = item === null || item === void 0 ? void 0 : item.icms) === null || _53 === void 0 ? void 0 : _53.aliquotaInterna) || 0;
            this.icms_aliquota = ((_54 = item === null || item === void 0 ? void 0 : item.icms) === null || _54 === void 0 ? void 0 : _54.aliquota) || 0;
            this.icms_codigo_icms = ((_55 = item === null || item === void 0 ? void 0 : item.icms) === null || _55 === void 0 ? void 0 : _55.codigoIcms) || 0;
            this.icms_codigo_origem = ((_56 = item === null || item === void 0 ? void 0 : item.icms) === null || _56 === void 0 ? void 0 : _56.codigoOrigem) || 0;
            this.icms_codigo_tributacao_final = ((_57 = item === null || item === void 0 ? void 0 : item.icms) === null || _57 === void 0 ? void 0 : _57.codigoTributacaoFinal) || 0;
            this.icms_codigo_tributacao = ((_58 = item === null || item === void 0 ? void 0 : item.icms) === null || _58 === void 0 ? void 0 : _58.codigoTributacao) || 0;
            this.icms_csosn = ((_59 = item === null || item === void 0 ? void 0 : item.icms) === null || _59 === void 0 ? void 0 : _59.csosn) || '';
            this.icms_decreto_de_lei = ((_60 = item === null || item === void 0 ? void 0 : item.icms) === null || _60 === void 0 ? void 0 : _60.decretoDeLei) || '';
            this.icms_desconto_icms_desonerado = ((_61 = item === null || item === void 0 ? void 0 : item.icms) === null || _61 === void 0 ? void 0 : _61.descontoIcmsDesonerado) || '';
            this.icms_fcp_agregado = ((_62 = item === null || item === void 0 ? void 0 : item.icms) === null || _62 === void 0 ? void 0 : _62.fcpAgregado) || 0;
            this.icms_fcp_segregado = ((_63 = item === null || item === void 0 ? void 0 : item.icms) === null || _63 === void 0 ? void 0 : _63.fcpSegregado) || 0;
            this.icms_percentual_diferimento = ((_64 = item === null || item === void 0 ? void 0 : item.icms) === null || _64 === void 0 ? void 0 : _64.percentualDiferimento) || 0;
            this.icms_reducao_aliquota_efetiva = ((_65 = item === null || item === void 0 ? void 0 : item.icms) === null || _65 === void 0 ? void 0 : _65.reducaoAliquotaEfetiva) || 0;
            this.icms_reducao = ((_66 = item === null || item === void 0 ? void 0 : item.icms) === null || _66 === void 0 ? void 0 : _66.reducao) || 0;
            // IPI
            this.ipi_aliquota = ((_67 = item === null || item === void 0 ? void 0 : item.ipi) === null || _67 === void 0 ? void 0 : _67.aliquota) || 0;
            this.ipi_cst = ((_68 = item === null || item === void 0 ? void 0 : item.ipi) === null || _68 === void 0 ? void 0 : _68.cst) || 0;
            // NCM
            this.ncm_codigo = ((_69 = item === null || item === void 0 ? void 0 : item.ncm) === null || _69 === void 0 ? void 0 : _69.codigo) || '';
            this.ncm_excecao = ((_70 = item === null || item === void 0 ? void 0 : item.ncm) === null || _70 === void 0 ? void 0 : _70.excecao) || 0;
            this.ncm_variacao = ((_71 = item === null || item === void 0 ? void 0 : item.ncm) === null || _71 === void 0 ? void 0 : _71.variacao) || 0;
            // PIS
            this.pis_aliquota = ((_72 = item === null || item === void 0 ? void 0 : item.pis) === null || _72 === void 0 ? void 0 : _72.aliquota) || 0;
            this.pis_cst = ((_73 = item === null || item === void 0 ? void 0 : item.pis) === null || _73 === void 0 ? void 0 : _73.cst) || 0;
            // Produto
            this.prb_cdprodutobluesoft = (item === null || item === void 0 ? void 0 : item.produtoKey) || 0;
            // Reforma Tributária - CST
            this.rt_codigo_class_trib_ibs_cbs = ((_74 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _74 === void 0 ? void 0 : _74.codigoClassTribIbsCbs) || '';
            this.rt_codigo_cst_ibs_cbs = ((_75 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _75 === void 0 ? void 0 : _75.codigoCstIbsCbs) || '';
            this.rt_descricao_class_trib_ibs_cbs = ((_76 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _76 === void 0 ? void 0 : _76.descricaoClassTribIbsCbs) || '';
            this.rt_descricao_cst_ibs_cbs = ((_77 = item === null || item === void 0 ? void 0 : item.reformaTributaria) === null || _77 === void 0 ? void 0 : _77.descricaoCstIbsCbs) || '';
        }
    }
    script_CRUD() {
        return __awaiter(this, void 0, void 0, function* () {
            let scriptSQL = ``;
            if (this.LOCAL_STATUS_API == 1) {
                return this.sql_CRUD();
            }
            else {
                scriptSQL = `delete from tbfc_regrafiscal_nfce_produto where prb_cdprodutobluesoft = ${this.prb_cdprodutobluesoft};`;
            }
            return scriptSQL;
        });
    }
    ChamadaLeituraApiBlueSoftSatNfcePorProduto(prb_cdprodutobluesoft) {
        return __awaiter(this, void 0, void 0, function* () {
            let sqlscript = ``;
            try {
                let url = `/modulos/fiscal/regra-fiscal/pdv/sat-nfces?lojaKey=1&page=1&produtoKey=${prb_cdprodutobluesoft}`;
                const ItemData = yield myBase.blueSoftApi.api_get(url);
                if (ItemData && ItemData.data && ItemData.data.length > 0) {
                    this.LerDadosDaAPI(ItemData.data[0]);
                }
                else {
                    this.prb_cdprodutobluesoft = prb_cdprodutobluesoft;
                    this.LOCAL_STATUS_API = 0;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'modelfc_regrafiscalNfceProduto.ChamadaLeituraApiBlueSoftSatNfcePorProduto', e);
            }
        });
    }
}
exports.default = modelfc_regrafiscalNfceProduto;
