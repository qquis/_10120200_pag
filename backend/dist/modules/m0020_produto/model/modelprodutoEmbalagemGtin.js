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
const tbprodutos_1 = __importDefault(require("../tbs/tbprodutos"));
class modelprodutoEmbalagemGtin extends tbprodutos_1.default {
    constructor() {
        super();
    }
    ConsultarDataQuery(gtin) {
        return __awaiter(this, void 0, void 0, function* () {
            let dataGtin = {};
            try {
                dataGtin = yield this.ConsultarGtinDadosBasicos(gtin);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar gtin', e);
            }
            finally {
                return dataGtin;
            }
        });
    }
    ConsultarGtinDadosBasicos(gtin) {
        return __awaiter(this, void 0, void 0, function* () {
            let gtinDadosBasicos = {};
            const myBase = new modelbase_1.clsBase();
            try {
                let sql = `
            
            select 	g.pr_cdproduto 
                ,	g.prb_cdprodutobluesoft 
                ,	g.preg_cdbarra
                ,   g.pre_embalagem
                ,	gb.prbg_cdbarra_pk
                ,	coalesce(gb.prbg_embalagemdescricao, 'SEM DESCRICAO') as prbg_embalagemdescricao
                ,	pb.prb_cdprodutobluesoftunitario 
                ,	z.zanthus_tributacao_nfce_seq 
                ,	z.api_regra_fiscal	
                ,	z.ncm_codigo
                ,	z.cest
                ,	z.pis_cst
                ,	z.pis_aliquota
                ,	z.cofins_cst
                ,	z.cofins_aliquota
                ,	z.icms_cst
                ,	z.icms_aliquota
                ,	z.icms_reducao 
                ,	z.icms_aliquota_final 
                ,	z.r_cod_sit_tributaria_ibs_cbs

            from 		tbprodutoembalagem_gtins g 					
            left join 	tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = g.prb_cdprodutobluesoft 
            left join   tbprodutobluesoft_gtins gb on gb.prbg_cdbarra_pk = g.preg_cdbarra 
            left join   tbzanthus_tributacao_nfce z on lpad(z.cod_mercadoria, 17, '0') = lpad(g.preg_cdbarra, 17, '0')
            where 1 = 1
            and   lpad(g.preg_cdbarra, 14, '0') = lpad('${gtin}', 14, '0')
                    `;
                gtinDadosBasicos = yield myBase.myDataBase.RecordItem(yield myBase.myDataBase.pag.DataGet(sql), 0);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`M0020 - PRODUTO | modelproduto`, 'consultar embalagens', e);
            }
            finally {
                return gtinDadosBasicos;
            }
        });
    }
}
exports.default = modelprodutoEmbalagemGtin;
