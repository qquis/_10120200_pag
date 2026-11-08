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
class reportExternalZanthusTabRegraIcms {
    static sql(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let data_venda_ini = '1900-01-01';
            let data_venda_fim = '2100-01-01';
            if (filter.filtrar_data_venda) {
                data_venda_ini = filter.data_venda_ini ? filter.data_venda_ini : '1900-01-01';
                data_venda_fim = filter.data_venda_fim ? filter.data_venda_fim : '2100-01-01';
            }
            let sql = `
         select 	r.cod_regras_icms
                ,   r.descricao as regra_descricao
                ,	r.cod_mercadoria 
                ,	m.descricao 
                ,	c.regra_count

                ,	r.flg_tipo_imposto
                ,   CASE r.flg_tipo_imposto
                         WHEN '0' THEN 'Icms'
                         WHEN '1' THEN 'Pis'
                         WHEN '2' THEN 'Cofins'
                         WHEN 'D' THEN 'CBS'
                         WHEN 'A' THEN 'Ibs UF'
                         WHEN 'B' THEN 'Ibs Municipal'
                    End as tipo_imposto_descricao
                ,	r.flg_revenda 
                ,	r.aliquota
                ,	r.cst
                ,	r.perc_reducao 
                ,	r.dta_val_inicial
                ,	r.dta_val_final
                ,	r.cst_orig
                ,	r.tipo_documento
                ,	r.cod_class_tributaria
                ,	r.per_cred_presumido_ibs_mono
                ,	r.per_cred_presumido_cbs_mono
                ,	r.cod_ncm_ini
                ,	r.cod_ncm_final
                ,	coalesce(r.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal
            from 	tab_regras_icms r
            left join tab_mercadoria m on m.cod_mercadoria = r.cod_mercadoria 
            left join (
                            select cod_mercadoria 
                                ,	count(*) as regra_count
                            from   tab_regras_icms x
                            group by cod_mercadoria

            ) c on c.cod_mercadoria = r.cod_mercadoria 
            WHERE       1 = 1   
              ${filter.cod_mercadoria ? ` AND m.cod_mercadoria = lpad('${filter.cod_mercadoria}', 17, '0') ` : ''}
              ${filter.cod_mercadoria_like ? ` AND m.cod_mercadoria LIKE '%${filter.cod_mercadoria_like}' ` : ''}
              ${filter.descricao ? ` AND m.descricao LIKE '%${filter.descricao}%' ` : ''}
        `;
            if (filter.filtrar_data_venda) {
                sql += ` and m.cod_mercadoria in (
                        select lpad(i.m43ah, 17, '0') 
                        from       zan_m43  i
                        left join  ZAN_M45          A on a.m00af = i.m00af and a.m00ad = i.m00ad and a.m00ac = i.m00ac
                        left JOIN	tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF    
                        where  1 = 1
                        and    i.m00af >= '${data_venda_ini}' 
                        and    i.m00af <= '${data_venda_fim}'
                        ${filter.numero_cupom && filter.numero_cupom !== '' ? ` AND i.m00ad = '${filter.numero_cupom}' ` : ''}
                        ${filter.ecf && filter.ecf !== '' ? ` AND i.m00ac = '${filter.ecf}' ` : ''}
                        ${filter.numero_nf && filter.numero_nf !== '' ? ` AND A.M45XD = '${filter.numero_nf}' ` : ''}
                        )
                        
                        `;
            }
            sql += ` order by m.cod_mercadoria, r.flg_revenda, r.flg_tipo_imposto `;
            return sql;
        });
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let listResultado;
            try {
                let myclassBase = new modelbase_1.clsBase();
                listResultado = yield myclassBase.myDataBase.zanthusPostgre.DataGet(yield this.sql(filter));
            }
            catch (e) {
                yield modelbase_1.clsTools.pagConsole(`M0085 - Zanthus | report.tab_regra_icms.ts | get OBS..: Retorno vazio do itemConsultado mantido via finally ERROR: ${e}`);
            }
            finally {
                return listResultado;
            }
        });
    }
}
exports.default = reportExternalZanthusTabRegraIcms;
