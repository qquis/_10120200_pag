import { clsBase, clsTools } from "../../../model/modelbase";

export default class reportForcaVendaTabelaPadrao {
    static sql(parametro: any) : string { 



            let sql = `
                        select i.fv_tabelapreco_cd 
                            ,	t.fv_tabelapreco_descricao 
                            ,	i.versao 
							,   v.datainiciovigencia
							,   v.datafimvigencia                            
                            ,	pb.prb_descricao
                            ,	i.dtlog_update 
                            ,	i.prb_cdprodutobluesoft 
                            ,	pb.prb_descricao 
                            ,	i.precoembalagem 
                            ,	i.precounitario 
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 1) as numeric(13,2)) as D07
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 2) as numeric(13,2)) as D14
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 3) as numeric(13,2)) as D21	
                            ,   cast(i.precounitario * ( SELECT coalesce(coefcustofinanceiro,1) from tbforca_venda_prazopgto where listapadraoorder = 4) as numeric(13,2)) as D28		
                            ,   pb.prb_cdbarra_principal 
                            ,   im.link_image 
                            ,   f.icms_descricao 
                            ,   coalesce(f.piscst, cast(fantigo.prbt_pis_saida_cst as int)) as piscst
                            ,   coalesce(f.pisaliquota, fantigo.prbt_pis_saida_aliquota) as pisaliquota
                            ,   coalesce(f.cofinscst, cast(fantigo.prbt_cofins_saida_cst as int)) as cofinscst
                            ,   coalesce(f.cofinsaliquota, fantigo.prbt_cofins_saida_aliquota) as cofinsaliquota
                        from 	tbforca_venda_tabprecoprodutobluesoft i
                        inner join tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        left join tbgtins_imagem im on lpad(im.cdbarra, 14, '0') = lpad(pb.prb_cdbarra_principal, 14, '0') 
                        inner join tbforca_venda_tabpreco t on t.fv_tabelapreco_cd = i.fv_tabelapreco_cd
                        inner join tbforca_venda_tabpreco_versao v on v.fv_tabelapreco_cd = i.fv_tabelapreco_cd and v.versao = i.versao
                        inner join tbprodutobluesoft_tributacao fantigo on fantigo.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario and op_cdoperacao = 2
                        inner join (

							select xx.fv_tabelapreco_cd 
								,  max(xx.versao) as ultima_versao 
								from tbforca_venda_tabpreco_versao xx
								group by fv_tabelapreco_cd 

						) ultima_versao on ultima_versao.fv_tabelapreco_cd = v.fv_tabelapreco_cd and ultima_versao.ultima_versao = v.versao

                        left join (
                        
                                        select 	  pb.prb_cdprodutobluesoft
                                                , r.fc_regrafiscal_cd 
                                                , r.cfop 
                                                , r.pis_cd 
                                                , pis.cst  as piscst
                                                , pis.pisaliquota as pisaliquota
                                                , cofins.cst  as cofinscst
                                                , cofins.cofinsaliquota as cofinsaliquota                                                
                                                , r.cofins_cd
                                                , o.df_nf_tipo
                                                , r.icms_cd 
                                                , i.icms_descricao 
                                                , i.aliquota
                                                , i.reducao 
                                                , i.codigotributacao 


                                            from 	tbfc_figurafiscal_produto pb
                                            inner join tbfc_regrafiscal r on r.fc_figurafiscal_cd = pb.fc_figurafiscal_cd
                                            inner join tbfc_regrafiscal_operacao o on o.fc_regrafiscal_cd = r.fc_regrafiscal_cd
                                            inner join tbfc_icms i on i.icms_cd = r.icms_cd
                                            left join  tbfc_pis pis on pis.pis_cd = r.pis_cd
                                            left join  tbfc_cofins cofins on cofins.cofins_cd = r.cofins_cd                                            
                                            where   1 = 1
                                            and     r.tipo = 'SAIDA'
                                            and     o.df_nf_tipo = 104
                                            and     r.tipocliente = '${parametro.tipo_cliente || 'SEM_INFO'}'
                                    ) f on f.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario 


                        where 1 = 1
                         and pb.prb_status = 'true'  

  
                    `

            if (parametro.mail && parametro.mail == "1") {
                sql += ` and pb.prb_status = 'true' `   
            }

            if (parametro.fv_tabelapreco_descricao) {
                sql +=  ` and upper(t.fv_tabelapreco_descricao) like upper('%${parametro.fv_tabelapreco_descricao}%')`
            }

            if (parametro.fv_tabelapreco_cd) {
                sql +=  ` and v.fv_tabelapreco_cd = ${parametro.fv_tabelapreco_cd}`
            }

            if (parametro.vigencia_inicial) {
                sql +=  ` and v.datafimvigencia >= '${parametro.vigencia_inicial} 00:01:01'`
            }   

            if (parametro.prb_descricao && parametro.prb_descricao.trim() !== '') {
                sql +=  ` and upper(pb.prb_descricao) like upper('%${parametro.prb_descricao}%')`
            }

            if (parametro.prb_cdpessoabluesoft_fabricante && parametro.prb_cdpessoabluesoft_fabricante > 0 ) {
                sql +=  ` and pb.prb_cdpessoabluesoft_fabricante = ${parametro.prb_cdpessoabluesoft_fabricante}`
            }

            if (parametro.prb_cdprodutobluesoft && parametro.prb_cdprodutobluesoft > 0) {
                sql +=  ` and i.prb_cdprodutobluesoft = ${parametro.prb_cdprodutobluesoft}`
            }            
            sql += ` ORDER BY t.fv_tabelapreco_descricao, pb.prb_descricao ASC `



            
            return sql;

            
    }

    static async get(parametro: any): Promise<any> {
        try { 
            let myBase : clsBase = new clsBase()
            let result = await myBase.myDataBase.pag.DataGet(this.sql(parametro))
            
            return result

        } catch (e) {
            clsTools.pagConsole(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error \n ${e}`, false, false)
            throw new Error(`modules | m0104_ForcaVenda | report | reportForcaVendaTabela.result | Error ${e}`);
        }
    }


     static async mail(parametro: any): Promise<void> {
        try { 


            let data = await this.get(parametro)




            let html = `
                <div style="font-family: Arial, sans-serif; font-size: 12px;">
                    <h2 style="color: #2c3e50; margin-bottom: 20px;">Lista de Produtos</h2>
                    <h3 style="color: #2c3e50; margin-bottom: 20px;">Preço Básico | Consulte outras oportunidades de negociação com o nosso representante</h3>
                    
                    <table style="width: 100%; border-collapse: collapse; background-color: white;">
                        <thead style="background-color: #34495e; color: white;">
                            <tr>
                                <th style="padding: 8px; border: 1px solid #ddd;">Tabela</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">Produto</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">Cód. Barra</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">Preço Base</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">Validade</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">PIS/COFINS</th>
                                <th style="padding: 8px; border: 1px solid #ddd;">ICMS</th>
                            </tr>
                        </thead>
                        <tbody>`;

            data.forEach((item : any, index : number) => {
                const bgColor = index % 2 === 0 ? '#f8f9fa' : 'white';
                html += `
                    <tr style="background-color: ${bgColor};">
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 10px;">
                            <strong>${item.fv_tabelapreco_descricao || ''}</strong><br>
                            <small>Cód: ${item.fv_tabelapreco_cd || ''} | V: ${item.versao || ''}</small>
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 10px;">
                            <strong>${item.prb_descricao || ''}</strong><br>
                            <small>Cód: ${item.prb_cdprodutobluesoft || ''}</small>
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 10px; text-align: center;">
                            ${item.prb_cdbarra_principal || ''}
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 10px; text-align: right; background-color: #e17055;">
                            R$ ${parseFloat(item.d28 || 0).toFixed(2).replace('.', ',')}
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 9px;">
                            ${item.datafimvigencia ? new Date(item.datafimvigencia).toLocaleDateString('pt-BR') : ''}
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 9px;">
                            PIS | Cst ${item.piscst || ''.padStart(2, '0')} -  ${item.pisaliquota ? item.pisaliquota : ''} 
                            COFINS | Cst ${item.cofinscst || ''.padStart(2, '0')} -  ${item.cofinsaliquota ? item.cofinsaliquota : ''}
                        </td>
                        <td style="padding: 6px; border: 1px solid #ddd; font-size: 9px;">
                            ${item.icms_descricao || ''}
                        </td>                        
                    </tr>`;
            });

            html += `
                        </tbody>
                    </table>
                    
                    <div style="margin-top: 15px; padding: 10px; background-color: #ecf0f1; border-radius: 4px; font-size: 10px;">
                        <strong>Legenda:</strong> D07, D14, D21, D28 = Preços com coeficiente financeiro para 7, 14, 21 e 28 dias respectivamente.
                    </div>
                </div>`;

            
            let format = "ADM"


            
            await clsTools.mail.sendMail(parametro.email_address, `Distribuição | Lista de Produtos`, html, format)
            



        } catch (e) {
            clsTools.PagErrorException('notificacaoMailTabelaPrecoPadrao', 'montarHtmlEmail', e)
            throw new Error('notificacaoMailTabelaPrecoPadrao.montarHtmlEmail') 
        }
    }

}