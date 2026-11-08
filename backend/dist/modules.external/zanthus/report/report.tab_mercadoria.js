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
class reportExternalZanthusTabMercadoria {
    static sql(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let data_venda_ini = '1900-01-01';
            let data_venda_fim = '2100-01-01';
            if (filter.filtrar_data_venda) {
                data_venda_ini = filter.data_venda_ini ? filter.data_venda_ini : '1900-01-01';
                data_venda_fim = filter.data_venda_fim ? filter.data_venda_fim : '2100-01-01';
            }
            let sql = `
          select        m.cod_mercadoria
                    ,	m.descricao 
                    ,	m.descricao_abr
                    ,   coalesce(c.regra_count, 0) as regra_count
                    ,   lpad(cast(m.cod_ncm as varchar(8)), 8, '0')  as cod_ncm
                    ,   m.cod_ex
                    ,	m.cod_departamento

                    ,	m.data_cadastro
                    ,	m.data_ultima_alteracao 


                    ,	m.cfop 
                    ,	m.cod_tributacao_mercadoria 

                    ,	m.cod_situacao_tributaria 
                    ,   m.aliquota_interna_icms 
                    ,	m.aliquota_icms
                    ,	m.percentual_reduz_b_calculo


                    ,	m.cod_sit_trib_pis
                    ,	m.aliquota_pis
	                ,	m.perc_reduz_b_calculo_pis                    

                    ,	m.cod_sit_trib_cofins
                    ,	m.aliquota_cofins
                    ,   m.perc_reduz_b_calculo_cofins

                    ,	m.cod_sit_tributaria_ibs_cbs
                    ,	m.cod_class_tributaria_is
                    ,	m.cod_class_tributaria_ibs_cbs
                    ,	m.per_aliquota_is
                    ,	m.per_aliquota_is_especifica 
                    ,	m.per_aliquota_ibs_uf
                    ,	m.per_reducao_aliquota_ibs_uf
                    ,	m.per_diferimento_ibs_uf 
                    ,	m.per_aliquota_ibs_mun 
                    ,	m.per_reducao_aliquota_ibs_mun 
                    ,	m.per_diferimento_ibs_mun 
                    ,	m.per_aliquota_cbs 
                    ,	m.per_diferimento_cbs
                    ,	m.per_reducao_aliquota_cbs
                    ,	m.per_cred_presumido_ibs_mono 
                    ,	m.per_cred_presumido_cbs_mono 
                    ,	m.origem_cadastro           
                    ,   coalesce(m.codigo_beneficio_fiscal, '') as codigo_beneficio_fiscal

                    
from 	tab_mercadoria m
            left join (
                            select cod_mercadoria 
                                ,	count(*) as regra_count
                            from   tab_regras_icms x
                            group by cod_mercadoria

            ) c on c.cod_mercadoria = m.cod_mercadoria 
            WHERE       1 = 1   
              ${filter.cod_mercadoria ? ` AND m.cod_mercadoria = lpad('${filter.cod_mercadoria}', 17, '0') ` : ''}
              ${filter.cod_mercadoria_like ? ` AND m.cod_mercadoria LIKE '%${filter.cod_mercadoria_like}' ` : ''}
              ${filter.descricao ? ` AND m.descricao LIKE '%${filter.descricao}%' ` : ''}
        `;
            if (filter.regra_count && filter.regra_count !== '') {
                sql += ` AND c.regra_count < ${filter.regra_count} `;
            }
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
            sql += ` order by m.cod_mercadoria `;
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
                modelbase_1.clsTools.pagConsole(`M0085 - Zanthus | report.tab_mercadoria.ts | get 
                                OBS..: Retorno vazio do itemConsultado mantido via finally
                                Error: 
                                ${e}    
                                `);
            }
            finally {
                return listResultado;
            }
        });
    }
}
exports.default = reportExternalZanthusTabMercadoria;
