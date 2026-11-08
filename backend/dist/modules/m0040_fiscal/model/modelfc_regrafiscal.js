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
const tbfc_regrafiscal_1 = __importDefault(require("../tbs/tbfc_regrafiscal"));
const tbfc_regrafiscalOperacao_1 = __importDefault(require("../tbs/tbfc_regrafiscalOperacao"));
const modelfc_icms_1 = __importDefault(require("./modelfc_icms"));
class modelfc_regrafiscal extends tbfc_regrafiscal_1.default {
    constructor() {
        super();
        this.ItemIcms = new modelfc_icms_1.default();
        this.OperacoesFiscais = [];
    }
    bindingApiBluesoft(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item) {
                    /*Impostos complementares*/
                    this.bindingApiBluesoftIcms(item);
                    this.bidingApiBluesoftPisCofins(item);
                    this.cfop = item.cfop ? item.cfop : 0;
                    this.tipo = item.tipo ? item.tipo : 'N/A';
                    this.fc_regrafiscal_cd = item.regraFiscalKey ? item.regraFiscalKey : 0;
                    this.fc_figurafiscal_cd = item.codigoFiguraFiscal ? item.codigoFiguraFiscal : 0;
                    this.vigenciainicial = modelbase_1.clsTools._datemomentDatStrToDate(item.vigenciaInicial, 'DD/MM/YYYY');
                    this.fc_regrafiscal_status = item.ativo ? 1 : 0;
                    this.tipocliente = item.tipoCliente ? item.tipoCliente : '';
                    if (item.codigoOperacoesFiscais) {
                        for (let opItem of item.codigoOperacoesFiscais) {
                            let itemOperacaoFIscal = new tbfc_regrafiscalOperacao_1.default();
                            itemOperacaoFIscal.fc_regrafiscal_cd = this.fc_regrafiscal_cd;
                            itemOperacaoFIscal.df_nf_tipo = opItem ? opItem : 0;
                            this.OperacoesFiscais.push(itemOperacaoFIscal);
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'modelfc_regrafiscal.bindingApiBluesoft', e);
            }
        });
    }
    bindingApiBluesoftIcms(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.ItemIcms = new modelfc_icms_1.default();
                if (item.regraIcmsConsumidorFinal) {
                    this.ItemIcms.bindingApiBluesoft(item.regraIcmsConsumidorFinal.icmsDetalhe);
                }
                if (item.regraIcmsNormal) {
                    this.ItemIcms.bindingApiBluesoft(item.regraIcmsNormal.icmsDetalhe);
                }
                this.icms_cd = this.ItemIcms.icms_cd;
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'modelfc_regrafiscal.bindingApiBluesoftIcms', e);
            }
        });
    }
    bidingApiBluesoftPisCofins(item) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (item.regraPisCofinsLucroReal) {
                    this.regimeincidenciapiscofins = item.regraPisCofinsLucroReal.regimeIncidencia ? item.regraPisCofinsLucroReal.regimeIncidencia : 'N/A';
                    this.pis_cd = item.regraPisCofinsLucroReal.pis ? item.regraPisCofinsLucroReal.pis : 0;
                    this.cofins_cd = item.regraPisCofinsLucroReal.cofins ? item.regraPisCofinsLucroReal.cofins : 0;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('M0040_FISCAL', 'modelfc_regrafiscal.bidingApiBluesoftPisCofins', e);
            }
        });
    }
    scriptSqlRegraFiscal() {
        let sql = ` insert into tbfc_regrafiscal 
        (
            	tipo   
            ,   fc_regrafiscal_cd
            ,   cfop
            ,   fc_figurafiscal_cd
            ,   vigenciainicial
            ,   fc_regrafiscal_status
            ,   icms_cd
            ,   pis_cd
            ,   cofins_cd
            ,   regimeincidenciapiscofins
            ,   tipocliente

         )
            SELECT     '${this.tipo}'
                    ,  ${this.fc_regrafiscal_cd}
                    ,  ${this.cfop}
                    ,  ${this.fc_figurafiscal_cd}
                    ,  '${modelbase_1.clsTools._datemomentDateToStr(this.vigenciainicial, 'YYYY-MM-DD')}'
                    ,  ${this.fc_regrafiscal_status}
                    ,  ${this.icms_cd}           
                    ,  ${this.pis_cd}
                    ,  ${this.cofins_cd}
                    ,  '${this.regimeincidenciapiscofins}' 
                    ,  '${this.tipocliente}'

            WHERE NOT EXISTS (SELECT 1 FROM tbfc_regrafiscal WHERE fc_regrafiscal_cd = ${this.fc_regrafiscal_cd})
            ;

            UPDATE tbfc_regrafiscal
             SET  tipo = '${this.tipo}'
                , cfop =  ${this.cfop}
                , fc_figurafiscal_cd =  ${this.fc_figurafiscal_cd}
                , vigenciainicial =  '${modelbase_1.clsTools._datemomentDateToStr(this.vigenciainicial, 'YYYY-MM-DD')}'
                , fc_regrafiscal_status =  ${this.fc_regrafiscal_status}
                , icms_cd = ${this.icms_cd}
                , pis_cd = ${this.pis_cd}
                , cofins_cd = ${this.cofins_cd}
                , regimeincidenciapiscofins = '${this.regimeincidenciapiscofins}'
                , tipocliente = '${this.tipocliente}'
                , dtlog_update = current_timestamp

            WHERE fc_regrafiscal_cd = ${this.fc_regrafiscal_cd}
            ;

            delete from tbfc_regrafiscal_operacao where fc_regrafiscal_cd = ${this.fc_regrafiscal_cd};

            `;
        for (let op of this.OperacoesFiscais) {
            if (op.df_nf_tipo !== 0) {
                sql += `
                        insert into tbfc_regrafiscal_operacao
                        (
                              fc_regrafiscal_cd
                            , df_nf_tipo
                        )
                        values
                        (
                            ${this.fc_regrafiscal_cd}
                            , ${op.df_nf_tipo}
                        );
                        `;
            }
        }
        return sql;
    }
}
exports.default = modelfc_regrafiscal;
