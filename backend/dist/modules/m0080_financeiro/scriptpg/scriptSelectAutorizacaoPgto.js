"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
class scriptSQLSelectAutorizacaoPgto {
    static sql(parametros = {}, list = true) {
        try {
            let tipovisualizacao = parametros.tipovisualizacao || 'DP';
            let sql = `select `;
            switch (tipovisualizacao) {
                case 'DP': // Detalhado por Participante
                    sql += `
                                                pg.autpgto_seq_pk 
                                        ,       pg.autpgto_cdpessoabluesoft
                                        ,       p.cdparticipante as cdparticipante
                                        ,       ps.nome_razao
                                        ,       pg.autpgto_dataemissao
                                        ,       pg.autpgto_datavencimento
                                        ,       pg.autpgto_dataquitacao
                                        ,       pg.autpgto_datapagamento
                                        ,       coalesce(r.r_conta_cd,0) as r_conta_cd
                                        ,       coalesce(r.r_conta_descricao, '') as r_conta_descricao
                                        ,       cp.competencia_descricao
                                        ,       cx.competencia_descricao as competencia_bluesoft_descricao
                                        ,       cv.competencia_descricao as competencia_vencimento_descricao 
                                        ,       coalesce(pg.autpgto_valorfatura,0) as autpgto_valorfatura
                                        ,       coalesce(pg.autpgto_valortotal,0) as autpgto_valortotal
                                        ,       coalesce(pg.autpgto_valorpago,0) as autpgto_valorpago 
                                        ,       coalesce(pg.autpgto_valordescontofinanceiro,0) as autpgto_valordescontofinanceiro
                                        ,       coalesce(pg.autpgto_valor_multa,0) as autpgto_valor_multa
                                        ,	    coalesce(pg.autpgto_valor_abatimento,0) as autpgto_valor_abatimento
                                        ,	    coalesce(pg.autpgto_valor_juros,0) as autpgto_valor_juros    
                                        ,	    coalesce(pg.autpgto_valor_juros_fixo,0) as autpgto_valor_juros_fixo 
                                        ,	    coalesce(pg.autpgto_valorliquido,0) as autpgto_valorliquido

                             ${!list ? ",       pg.autpgto_nf_numero " : ""}
                             ${!list ? ",       pg.autpgto_numeroparcela" : ""}
                             ${!list ? ",       pg.autpgto_status_cd" : ""}
                             ${!list ? ",       st.autpgto_status_descricao" : ""}
                             ${!list ? ",       pg.autpgto_status_bluesoft_cd" : ""}
                             ${!list ? ",       sb.autpgto_status_bluesoft_descricao" : ""}                                 
                             ${!list ? ",       pg.plc_conta_cd" : ""}
                             ${!list ? ",       pg.plc_conta_cd_destino" : ""}
                             ${!list ? ",       coalesce(r.r_conta_cd,0) as r_conta_cd" : ""}
                             ${!list ? ",       coalesce(r.r_conta_descricao, '') as r_conta_descricao" : ""}
                             ${!list ? ",       pg.em_cdempresa" : ""}
                             ${!list ? ",       pg.bluesoft_competencia_cd" : ""}
                             ${!list ? ",       pg.autpgto_cancelada" : ""}
                             ${!list ? ",       pg.autpgto_tipo" : ""}
                             ${!list ? ",       pg.competencia_cd" : ""}
                             ${!list ? ",       cp.competencia_descricao" : ""} 
                             ${!list ? ",       pg.bluesoft_competencia_cd" : ""}
                             ${!list ? ",       cx.competencia_descricao as competencia_bluesoft_descricao " : ""}
                        `;
                    break;
                case 'CP': // Agrupado por competência Pag
                    sql += `
                                                cast(0 as int) as autpgto_seq_pk 
                                        ,       cast(0 as int) as autpgto_cdpessoabluesoft
                                        ,       cast(0 as int) as nome_razao
                                        ,       cast('1900-01-01' as date ) as autpgto_dataemissao
                                        ,       cast('1900-01-01' as date ) autpgto_datavencimento
                                        ,       cast('1900-01-01' as date ) autpgto_dataquitacao
                                        ,       cast('1900-01-01' as date ) autpgto_datapagamento
                                        ,       '' as r_conta_cd
                                        ,       '' as r_conta_descricao
                                        ,       cp.competencia_descricao
                                        ,       '' as competencia_bluesoft_descricao
                                        ,       '' as competencia_vencimento_descricao                                         
                                        ,       sum(coalesce(pg.autpgto_valorfatura,0)) as autpgto_valorfatura
                                        ,       sum(coalesce(pg.autpgto_valortotal,0)) as autpgto_valortotal
                                        ,       sum(coalesce(pg.autpgto_valorpago,0)) as autpgto_valorpago 
                                        ,       sum(coalesce(pg.autpgto_valordescontofinanceiro,0)) as autpgto_valordescontofinanceiro
                                        ,       sum(coalesce(pg.autpgto_valor_multa,0)) as autpgto_valor_multa
                                        ,	    sum(coalesce(pg.autpgto_valor_abatimento,0)) as autpgto_valor_abatimento
                                        ,	    sum(coalesce(pg.autpgto_valor_juros,0)) as autpgto_valor_juros    
                                        ,	    sum(coalesce(pg.autpgto_valor_juros_fixo,0)) as autpgto_valor_juros_fixo 
                                        ,	    sum(coalesce(pg.autpgto_valorliquido,0)) as autpgto_valorliquido
                        `;
                    break;
                case 'CB': // Agrupado por competência BlueSoft
                    sql += `
                                                cast(0 as int) as autpgto_seq_pk 
                                        ,       cast(0 as int) as autpgto_cdpessoabluesoft
                                        ,       cast(0 as int) as nome_razao
                                        ,       cast('1900-01-01' as date ) as autpgto_dataemissao
                                        ,       cast('1900-01-01' as date ) autpgto_datavencimento
                                        ,       cast('1900-01-01' as date ) autpgto_dataquitacao
                                        ,       cast('1900-01-01' as date ) autpgto_datapagamento
                                        ,       '' as r_conta_cd
                                        ,       '' as r_conta_descricao
                                        ,       '' as competencia_descricao
                                        ,       cx.competencia_descricao as competencia_bluesoft_descricao
                                        ,       '' as competencia_vencimento_descricao                                                                                 
                                        ,       sum(coalesce(pg.autpgto_valorfatura,0)) as autpgto_valorfatura
                                        ,       sum(coalesce(pg.autpgto_valortotal,0)) as autpgto_valortotal
                                        ,       sum(coalesce(pg.autpgto_valorpago,0)) as autpgto_valorpago 
                                        ,       sum(coalesce(pg.autpgto_valordescontofinanceiro,0)) as autpgto_valordescontofinanceiro
                                        ,       sum(coalesce(pg.autpgto_valor_multa,0)) as autpgto_valor_multa
                                        ,	    sum(coalesce(pg.autpgto_valor_abatimento,0)) as autpgto_valor_abatimento
                                        ,	    sum(coalesce(pg.autpgto_valor_juros,0)) as autpgto_valor_juros    
                                        ,	    sum(coalesce(pg.autpgto_valor_juros_fixo,0)) as autpgto_valor_juros_fixo 
                                        ,	    sum(coalesce(pg.autpgto_valorliquido,0)) as autpgto_valorliquido
                        `;
                    break;
                case 'CD': // Agrupado por competência + Data Vencimento
                    sql += `
                                                cast(0 as int) as autpgto_seq_pk 
                                        ,       cast(0 as int) as autpgto_cdpessoabluesoft
                                        ,       cast(0 as int) as nome_razao
                                        ,       cast('1900-01-01' as date ) as autpgto_dataemissao
                                        ,       cast('1900-01-01' as date ) as autpgto_datavencimento
                                        ,       cast('1900-01-01' as date ) as autpgto_dataquitacao
                                        ,       cast('1900-01-01' as date ) as autpgto_datapagamento
                                        ,       '' as r_conta_cd
                                        ,       '' as r_conta_descricao
                                        
                                        ,       cp.competencia_descricao
                                        ,       '' as competencia_bluesoft_descricao
                                        ,       cv.competencia_descricao as competencia_vencimento_descricao    

                                        ,       sum(coalesce(pg.autpgto_valorfatura,0)) as autpgto_valorfatura
                                        ,       sum(coalesce(pg.autpgto_valortotal,0)) as autpgto_valortotal
                                        ,       sum(coalesce(pg.autpgto_valorpago,0)) as autpgto_valorpago 
                                        ,       sum(coalesce(pg.autpgto_valordescontofinanceiro,0)) as autpgto_valordescontofinanceiro
                                        ,       sum(coalesce(pg.autpgto_valor_multa,0)) as autpgto_valor_multa
                                        ,	    sum(coalesce(pg.autpgto_valor_abatimento,0)) as autpgto_valor_abatimento
                                        ,	    sum(coalesce(pg.autpgto_valor_juros,0)) as autpgto_valor_juros    
                                        ,	    sum(coalesce(pg.autpgto_valor_juros_fixo,0)) as autpgto_valor_juros_fixo 
                                        ,	    sum(coalesce(pg.autpgto_valorliquido,0)) as autpgto_valorliquido
                        `;
                    break;
            }
            sql += `    
                        from            tbautorizacaopagamento pg
                        left join       tbautorizacaopagamento_status st on st.autpgto_status_cd = pg.autpgto_status_cd
                        left join       tbautorizacaopagamento_status_bluesoft sb on sb.autpgto_status_bluesoft_cd = pg.autpgto_status_bluesoft_cd
                        left join       tbpessoabluesoft ps on ps.cdpessoabluesoft = pg.autpgto_cdpessoabluesoft
                        left join       tbparticipante_bluesoft p on p.cdpessoabluesoft = ps.cdpessoabluesoft
                        left join       tbcompetencia cp on cp.competencia_cd = pg.competencia_cd
                        left join       tbcompetencia cx on cx.competencia_cd = pg.bluesoft_competencia_cd
                        left join       tbcompetencia cv on pg.autpgto_datavencimento >= cv.competencia_data_ini 
                                                        and pg.autpgto_datavencimento <= cv.competencia_data_fim
                        left join       tbresultado_conta_origem ro on ro.plc_conta_cd = pg.plc_conta_cd
                                                                   and ro.contrato_bluesoft_seq = pg.contrato_bluesoft_seq
                                                                   and ro.cdparticipante = p.cdparticipante
                        left join       tbresultado_conta r on r.r_conta_cd = ro.r_conta_cd         

                        where 1 = 1
                          and pg.em_cdempresa = 1
                        ${(parametros.autpgto_seq_pk && parseInt(parametros.autpgto_seq_pk) > 0) ? " and pg.autpgto_seq_pk = " + parametros.autpgto_seq_pk : ""}
                        ${(parametros.autpgto_tipo && parametros.autpgto_tipo !== "") ? " and pg.autpgto_tipo = '" + parametros.autpgto_tipo + "'" : ""}
                        


                        ${(parametros.filtrar_dataemissao == 1 && parametros.autpgto_dataemissao_ini) ?
                " and pg.autpgto_dataemissao >= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_dataemissao_ini, "YYYY-MM-DD") + "'" : ""} 
                        ${(parametros.filtrar_dataemissao == 1 && parametros.autpgto_dataemissao_fim) ?
                " and pg.autpgto_dataemissao <= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_dataemissao_fim, "YYYY-MM-DD") + "'" : ""} 

                        ${(parametros.filtrar_datavencimento == 1 && parametros.autpgto_datavencimento_ini) ?
                " and pg.autpgto_datavencimento >= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_datavencimento_ini, "YYYY-MM-DD") + "'" : ""} 
                        ${(parametros.filtrar_datavencimento == 1 && parametros.autpgto_datavencimento_fim) ?
                " and pg.autpgto_datavencimento <= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_datavencimento_fim, "YYYY-MM-DD") + "'" : ""}                             

                        ${(parametros.filtrar_datapagamento == 1 && parametros.autpgto_datapagamento_ini) ?
                " and pg.autpgto_datapagamento >= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_datapagamento_ini, "YYYY-MM-DD") + "'" : ""} 
                        ${(parametros.filtrar_datapagamento == 1 && parametros.autpgto_datapagamento_fim) ?
                " and pg.autpgto_datapagamento <= '" + modelbase_1.clsTools._datemomentDateToStr(parametros.autpgto_datapagamento_fim, "YYYY-MM-DD") + "'" : ""} 

                        ${(parametros.r_conta_cd && parseInt(parametros.r_conta_cd) > 0) ? "and r.r_conta_cd=" + parametros.r_conta_cd : ""}



                        ${(parametros.cancelado && parseInt(parametros.cancelado) == 1) ? "and pg.autpgto_cancelada in (1,0) " : "and pg.autpgto_cancelada = 0"}

                        ${(parametros.filterdespesabluesoft && parseInt(parametros.filterdespesabluesoft) == 1) ? "and pg.autpgto_tipo = 'P' and	pg.plc_conta_cd <> 2110" : ""}
                        
                        ${(parametros.bluesoft_competencia_cd && parseInt(parametros.bluesoft_competencia_cd) > 0) ? "and pg.bluesoft_competencia_cd =" + parametros.bluesoft_competencia_cd : ""}
                        ${(parametros.competencia_cd && parseInt(parametros.competencia_cd) > 0) ? "and x.competencia_cd =" + parametros.competencia_cd : ""}

                `;
            switch (tipovisualizacao) {
                case 'CP': // Agrupado por competência Pag
                    sql += `   group by    cp.competencia_cd
                                       ,   cp.competencia_descricao
                        `;
                    break;
                case 'CB': // Agrupado por competência BlueSoft
                    sql += `   group by    cx.competencia_cd
                                       ,   cx.competencia_descricao
                        `;
                    break;
                case 'CD': // Agrupado por competência + Data Vencimento
                    sql += `   group by    cp.competencia_cd
                                       ,   cp.competencia_descricao
                                       ,   cv.competencia_descricao
                        `;
                    break;
            }
            sql += ` 

                     ORDER BY 1

                     `;
            return sql;
        }
        catch (e) {
            modelbase_1.clsTools.PagErrorException(`reportFinanceiroPagList`, 'sql', e);
            return '';
        }
    }
}
exports.default = scriptSQLSelectAutorizacaoPgto;
