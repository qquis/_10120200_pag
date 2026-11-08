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
const modelfc_cbenef_1 = __importDefault(require("./modelfc_cbenef"));
const modelfc_cofins_1 = __importDefault(require("./modelfc_cofins"));
const modelfc_icms_1 = __importDefault(require("./modelfc_icms"));
const modelfc_pis_1 = __importDefault(require("./modelfc_pis"));
const modelfc_regrafiscal_1 = __importDefault(require("./modelfc_regrafiscal"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0040-Fiscal | MODEL BASE";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class model0040_fiscal {
    static fc_cbenef() { return new modelfc_cbenef_1.default(); }
    static fc_cofins() { return new modelfc_cofins_1.default(); }
    static fc_icms() { return new modelfc_icms_1.default(); }
    static fc_pis() { return new modelfc_pis_1.default(); }
    static fc_regrafiscal() { return new modelfc_regrafiscal_1.default(); }
    static scriptAtualizarListaCbenefDoProdutoBluesoft(prb_cdprodutobluesoftunitario, listCBENEF) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ` `;
            try {
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`model0021_ProdutoBluesoft`, `scriptAtualizarListaCbenefDoProdutoBluesoft`, e);
            }
            finally {
                return sql;
            }
        });
    }
    static sqlDELETE_tbfc_cbenef_produtobluesoft_porPRODUTO(prb_cdprodutobluesoftunitario) {
        return `delete from tbfc_cbenef_produtobluesoft where prb_cdprodutobluesoft = ${prb_cdprodutobluesoftunitario};`;
    }
    static sqlUPDATE_tbprodutobluesoft_CBENEF_NULL_PorCBENEF(fc_cbenef_cd) {
        return `update tbprodutobluesoft x 
                    set prb_blue_fc_cbenef_cd = a.fc_cbenef_cd
                      , dtlog_update = current_timestamp
                    from ( 
                                select 		prb.prb_cdprodutobluesoftunitario 
                                    ,  		prn.fc_cbenef_cd 
                                from   		tbfc_cbenef_produtobluesoft prn
                                inner join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = prn.prb_cdprodutobluesoft
                                inner join 	tbfc_cbenef_cst cst on cst.fc_cbenef_cd = prn.fc_cbenef_cd
                                inner join  tbzanthus_tributacao_nfce   n on n.prb_cdprodutobluesoft = prn.prb_cdprodutobluesoft 
                                    and cast(n.icms_cst as varchar(2)) = cast(cst.icms_codigo_tributacao as varchar(2))
                                where       prb.prb_cdprodutobluesoftunitario = prn.prb_cdprodutobluesoft	
                                order by 	prb.prb_cdprodutobluesoftunitario 
                                    ,		prn.prb_cdprodutobluesoft
                            ) a 
                    where 1 = 1
                    and   a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoftunitario 
                    and   a.fc_cbenef_cd =  '${fc_cbenef_cd}'
                    and   a.fc_cbenef_cd != 'SP099999'
                ;`;
    }
    static sqlUPDATE_tbprodutobluesoft_NULL_porCBENEF(fc_cbenef_cd) {
        return `update tbprodutobluesoft set prb_blue_fc_cbenef_cd = null where prb_blue_fc_cbenef_cd = '${fc_cbenef_cd}';`;
    }
    static sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF(fc_cbenef_cd, arrayListaProdutos) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ` `;
            try {
                if (arrayListaProdutos && arrayListaProdutos.length > 0) {
                    const listaProdutosUnica = [...new Set(arrayListaProdutos)];
                    let liststringproduto = listaProdutosUnica.join(',');
                    sql += `insert into tbfc_cbenef_produtobluesoft (fc_cbenef_cd, prb_cdprodutobluesoft)
                            select '${fc_cbenef_cd}', t.prb_cdprodutobluesoft
                            from unnest(array[${liststringproduto}]) as t(prb_cdprodutobluesoft);`;
                }
                else {
                    throw new Error(`Lista de produtos vazia para o Cbenef ${fc_cbenef_cd}`);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modelfc_cbenef`, `sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorCBENEF`, e);
            }
            finally {
                return sql;
            }
        });
    }
    static sqlINSERT_TbFC_CBENEF_PRODUTO_FromList_PorProduto(fc_cbenef_list, prb_cdprodutobluesoft) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                if (fc_cbenef_list && fc_cbenef_list.length > 0) {
                    const listCbenefUnica = [...new Set(fc_cbenef_list)];
                    let listCbenef = listCbenefUnica.join(`','`);
                    sql += `insert into tbfc_cbenef_produtobluesoft (fc_cbenef_cd, prb_cdprodutobluesoft)
                        select t.fc_cbenef_cd, ${prb_cdprodutobluesoft}
                        from unnest(array['${listCbenef}']) as t(fc_cbenef_cd)

                        ;`;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modelfc_cbenef`, `sqlAtualizarList_TabCbenefProdutoBluesoft`, e);
            }
            finally {
                return sql;
            }
        });
    }
    static sqlDELETE_tbfc_cbenef_produtobluesoft_PorCbenef(fc_cbenef_cd) {
        let sql = `delete from tbfc_cbenef_produtobluesoft where fc_cbenef_cd = '${fc_cbenef_cd}';`;
        return sql;
    }
    static sqlDELETE_tbfc_cbenef_produtobluesoft_PorProduto(prb_cdprodutobluesoft) {
        let sql = `delete from tbfc_cbenef_produtobluesoft where prb_cdprodutobluesoft = ${prb_cdprodutobluesoft};`;
        return sql;
    }
    static sqlUpdateALL_CBENEF_TbProduto_ComTbProdutoBluesoft() {
        return ` 
                                update tbproduto  x
                                set    pr_pag_fc_cbenef_cd = a.prb_blue_fc_cbenef_cd
                                from   tbprodutobluesoft a 
                                where  a.prb_cdprodutobluesoftunitario = x.prb_cdprodutobluesoft 
                                and  coalesce(x.pr_pag_fc_cbenef_cd, '') = ''
                                and  coalesce(a.prb_blue_fc_cbenef_cd, '') != coalesce(x.pr_pag_fc_cbenef_cd, '')
            
                        `;
    }
}
exports.default = model0040_fiscal;
