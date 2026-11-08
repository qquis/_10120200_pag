import { clsBase, clsTools } from '../../../model/modelbase';


export default class reportProdutoBluesoftList {
    static sql (parametro: any) : string {


        if (parametro.filtrar_entrada_saida && parametro.filtrar_entrada_saida == 1) { 
            if (parametro.filtrar_entrada_saida_numero_mes && parametro.filtrar_entrada_saida_numero_mes > 0) { 
                const data_final = new Date();
                const data_inicial = new Date();
                data_inicial.setMonth( data_final.getMonth() - parametro.filtrar_entrada_saida_numero_mes );
                parametro.filtrar_entrada_saida_data_inicial = data_inicial;
                parametro.filtrar_entrada_saida_data_final = data_final;
            }

            if (parametro.filtrar_entrada_saida_data_inicial && parametro.filtrar_entrada_saida_data_final) { 
                parametro.filtrar_entrada_saida = 1;
            } else { 
                parametro.filtrar_entrada_saida = 0;
            }


        }


        let sql = `  

        select   pb.prb_cdprodutobluesoftunitario
            ,    pr.pr_cdproduto
            ,    un.prb_descricao as prb_descricaounitaria 
            ,    pb.prb_cdprodutobluesoft_pk 
            ,    coalesce(pb.prb_descricao,'') as prb_descricao
            ,    coalesce(pb.prb_pesobruto,0) as prb_pesobruto
            ,    coalesce(pb.prb_pesoliquido,0) as prb_pesoliquido
            ,    coalesce(pb.prb_comprimento,0) as prb_comprimento
            ,    coalesce(pb.prb_largura,0) as prb_largura
            ,    coalesce(pb.prb_altura,0) as prb_altura
            ,    coalesce(pb.prb_pesoaproximado,0) as prb_pesoaproximado
            ,    case when pb.prb_status then 1 else 0 end as prb_status
            ,    pb.prb_embalagemestoque
            ,    pb.dtlog_insert 
            ,    pb.dtlog_update 
            ,    pb.prb_dtupdate_from_api 
            ,    pb.prb_descricao_gondola
            ,    pb.prb_descricao_cupom
            ,    pb.prb_descricao_balanca
            ,    pb.prb_cdpessoabluesoft_fornecedor
            ,    p.nome_razao 
            ,    pb.prb_cdsubgrupo
            ,    sb.prsg_descricao
            ,    g.prg_descricao 
            ,    s.prs_descricao
            ,    d.prd_descricao
            ,    pb.prb_cdbarra_principal
            ,    pb.prb_dt_cadastro 
            ,    pb.prb_dt_ultimaalteracao
            ,    pb.dtlog_insert
            ,    pb.dtlog_update
            ,    pb.prb_dtupdate_from_api
            from        tbprodutobluesoft pb 
            inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
            left join   tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
            left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
            left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
            left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
            left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
            left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario
            where 1 = 1

            `
        
        if (parametro.apenasunitario && parametro.apenasunitario.trim() == '1') {
            sql += ` and pb.prb_cdprodutobluesoftunitario = pb.prb_cdprodutobluesoft_pk`
        }

                
        if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft > 0 ) {
            sql += ` and pb.prb_cdprodutobluesoft_pk = ${parametro.prb_cdprodutobluesoft}`
        }

        if (parametro.prb_cdprodutobluesoftunitario && parametro.prb_cdprodutobluesoftunitario > 0) {
            sql += ` and pb.prb_cdprodutobluesoftunitario = ${parametro.prb_cdprodutobluesoftunitario}`
        }


        if (parametro.prb_cdpessoabluesoft_fornecedor && parseInt(parametro.prb_cdpessoabluesoft_fornecedor) > 0) {
            sql += ` and pb.prb_cdpessoabluesoft_fornecedor = ${parseInt(parametro.prb_cdpessoabluesoft_fornecedor)}`
        }

        if (parametro.prb_cdpessoabluesoft_fabricante && parseInt(parametro.prb_cdpessoabluesoft_fabricante) > 0) {
            sql += ` and pb.prb_cdpessoabluesoft_fabricante = ${parseInt(parametro.prb_cdpessoabluesoft_fabricante)}`
        }

        if (parametro.prb_descricao && parametro.prb_descricao.trim() !== '') {
            sql += ` and UPPER(pb.prb_descricao) like UPPER('%${parametro.prb_descricao}%')`
        }

        if (parametro.prb_cdbarra_principal && parametro.prb_cdbarra_principal.trim() !== '') {
            sql += ` and pb.prb_cdbarra_principal = '${parametro.prb_cdbarra_principal}'`
        }


        if (parametro.dtlog_insert_filter && parametro.dtlog_insert_filter.trim() == '1') {

            if (parametro.dtlog_insert_ini && parametro.dtlog_insert_ini.trim() !== '') {
                sql += ` and pb.dtlog_insert >= '${parametro.dtlog_insert_ini} 01:01:01'`
            }

            if (parametro.dtlog_insert_fim && parametro.dtlog_insert_fim.trim() !== '') {
                sql += ` and pb.dtlog_insert <= '${parametro.dtlog_insert_fim} 23:59:59'`
            }

        }



        if (parametro.dtlog_update_filter && parametro.dtlog_update_filter.trim() == '1') {

            if (parametro.dtlog_update_ini && parametro.dtlog_update_ini.trim() !== '') {
                sql += ` and pb.dtlog_update >= '${parametro.dtlog_update_ini} 01:01:01'`
            }

            if (parametro.dtlog_update_fim && parametro.dtlog_update_fim.trim() !== '') {
                sql += ` and pb.dtlog_update <= '${parametro.dtlog_update_fim} 23:59:59'`
            }

        }


        if (parametro.prb_dtupdate_from_api_filter && parametro.prb_dtupdate_from_api_filter.trim() == '1') {

            if (parametro.prb_dtupdate_from_api_ini && parametro.prb_dtupdate_from_api_ini.trim() !== '') {
                sql += ` and pb.prb_dtupdate_from_api >= '${parametro.prb_dtupdate_from_api_ini} 01:01:01'`
            }

            if (parametro.prb_dtupdate_from_api_fim && parametro.prb_dtupdate_from_api_fim.trim() !== '') {
                sql += ` and pb.prb_dtupdate_from_api <= '${parametro.prb_dtupdate_from_api_fim} 23:59:59'`
            }

        }

        if (parametro.prb_status && parametro.prb_status.trim() !== '') {
            if (parametro.prb_status.trim() == '0') {
                sql += ` and pb.prb_status = 'false'`
            }
            if (parametro.prb_status.trim() == '1') {
                sql += ` and pb.prb_status = 'true'`
            }
        }

        if (parametro.informacao_checkout_filter && parametro.informacao_checkout_filter.trim() == '1') {

            if (parametro.informacao_checkout && parametro.informacao_checkout.trim() !== '0') {    

            sql += ` and  (    coalesce(pb.prb_pesobruto,0) = 0 
                            or coalesce(pb.prb_pesoliquido,0) = 0
                            or coalesce(pb.prb_comprimento,0) = 0
                            or coalesce(pb.prb_largura,0) = 0
                            or coalesce(pb.prb_altura,0) = 0
                            or coalesce(pb.prb_pesoaproximado,0) = 0
                        )`
            }
            else { 
                sql += ` and  (    coalesce(pb.prb_pesobruto,0) > 0
                            and coalesce(pb.prb_pesoliquido,0) > 0
                            and coalesce(pb.prb_comprimento,0) > 0
                            and coalesce(pb.prb_largura,0) > 0
                            and coalesce(pb.prb_altura,0) > 0
                            and coalesce(pb.prb_pesoaproximado,0) > 0
                        )`
            }
          }


        if (parametro.prb_embalagemfiltro != "") { 
            switch (parametro.prb_embalagemfiltro) {
                case "UN" : 
                    sql += ` and pb.prb_embalagemestoque = 'UN'`
                    break;
                case "KG" : 
                    sql += ` and pb.prb_embalagemestoque = 'KG'`
                    break;
                case "XX":
                    sql += ` and pb.prb_embalagemestoque not in ('UN','KG')`
                    break;
            }
        }

        if (parametro.prd_cddepartamento && parametro.prd_cddepartamento != "0") {
            sql += ` and d.prd_cddepartamento = '${parametro.prd_cddepartamento}'`
        }

        if (parametro.prs_cdsecao && parametro.prs_cdsecao != "0") {
            sql += ` and s.prs_cdsecao = '${parametro.prs_cdsecao}'`
        }

        /* ENTRADA */
        if (parametro.filtrar_entrada_saida 
                && parametro.filtrar_entrada_saida == 1 
                && parametro.filtrar_entrada_saida_data_inicial 
                && parametro.filtrar_entrada_saida_data_final
                && parametro.filtrar_entrada_saida_tipo === 'ENTRADA' ) {
                sql += `
                        and pb.prb_cdprodutobluesoftunitario ${parametro.filtrar_entrada_saida_zero && parametro.filtrar_entrada_saida_zero == 1 ? "not " : ""} in (   select      i.prb_cdprodutobluesoft 
                                                    from        tbdocumentofiscalitem I 
                                                    INNER JOIN  tbdocumentofiscal     n on n.df_nf_seq_blue = i.df_nf_seq_blue
                                                    where       coalesce(n.df_data_cancelamento, '1900-01-01') = '1900-01-01'
                                                    and         coalesce(df_cdpessoabluesoft_cancelamento,0) = 0 
                                                    and         n.df_data_emissao >= '${ clsTools._datemomentDateToStr( parametro.filtrar_entrada_saida_data_inicial, 'YYYY-MM-DD' ) }'
                                                    and         n.df_data_emissao <= '${ clsTools._datemomentDateToStr( parametro.filtrar_entrada_saida_data_final, 'YYYY-MM-DD' ) }'  
                                                    and n.df_entrada_saida = 'E' 
                                                    ${ parametro.filtrar_entrada_saida_tipo === 'SAIDA' ? ` and n.df_entrada_saida = 'S'` : `` }
                                                    group by    i.prb_cdprodutobluesoft
                                                                )

                        `
                }

        /* SAIDA */
        if (parametro.filtrar_entrada_saida 
                && parametro.filtrar_entrada_saida == 1 
                && parametro.filtrar_entrada_saida_data_inicial 
                && parametro.filtrar_entrada_saida_data_final
                && parametro.filtrar_entrada_saida_tipo === 'SAIDA' ) {
                sql += `
                        and pr.pr_cdproduto
                           ${parametro.filtrar_entrada_saida_zero && parametro.filtrar_entrada_saida_zero == 1 ? "not " : ""}  in (   select i.pr_cdproduto
                                    from tbfaturamento f
                                    inner join tbfaturamentoorigem o on o.seqfaturamento = f.seqfaturamento
                                    inner join tbfaturamentoitens i on i.seqfaturamentoorigem = o.seqfaturamentoorigem
                                    where 1 = 1
                                    and   i.statusfaturamentoitem = 1
                                    and   f.statusfaturamento = 1
                                    and   f.datafaturamento >= '${ clsTools._datemomentDateToStr( parametro.filtrar_entrada_saida_data_inicial, 'YYYY-MM-DD' ) }'
                                    and   f.datafaturamento <= '${ clsTools._datemomentDateToStr( parametro.filtrar_entrada_saida_data_final, 'YYYY-MM-DD' ) }'
                                    and   f.seqfaturamento > 1
                                    group by i.pr_cdproduto )

                        `
                }                



        sql += ` order by un.prb_descricao, pb.prb_descricao asc `

        return sql;
    }

    static async get(parametro: any) : Promise<any> {
        let result : any = { }
        try {
            let myBase : clsBase = new clsBase();
            result = await myBase.myDataBase.pag.DataGet( this.sql(parametro));

        } catch (e) {
            clsTools.pagConsole(`reportCbenefProduto | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }   
    }   

}

