import { reportFilter } from "../types";
import { clsBase, clsTools } from "../../../model/modelbase";

const REPORT_ID = 'IF050.30'

const myBase : clsBase = new clsBase();

export default class reportFaturamentoBluesoftFV_PedidoComCorte {
    public static sql(parametro : any) : string {

        if (!parametro.view || parametro.view == "") {
            parametro.view = "DETALHE"
        }





        let sql =  ` `

        if (parametro.view == "DETALHE") {
            sql =
        
                `
                                    SELECT 		f.op_cdoperacao 
                                            ,		f.numeropedido
                                            ,		f.numeropedido_fv
                                            ,		f.fat_blue_status_cd
                                            ,		S.fat_blue_status_descricao 
                                            ,		v.cdpessoabluesoft as cdpessoabluesoft_vendedor
                                            ,		vv.nome_razao as nome_razao_vendedor
                                            ,		c.cdpessoabluesoft as cdpessoabluesoft_cliente
                                            ,		cc.nome_razao as nome_razao_cliente
                                            ,		F.VALOR_PEDIDO 
                                            ,		F.VALOR_FATURAMENTO 
                                            ,	    i.prb_cdprodutobluesoft
                                            ,	    prb.prb_descricao 
                                            ,	    i.prb_cdprodutobluesoft_unitario 
                                            ,	    i.qtde_solicitada
                                            ,	    i.qtde_faturada 
                                            ,	    cast(i.valor_preco_aplicado * i.qtde_solicitada as numeric(13,2)) as valor_item_pedido
                                            ,	    cast(i.valor_preco_aplicado * i.qtde_faturada as numeric(13,2)) as valor_item_faturamento
                                            ,	    i.valor_nf_item 
                                            ,	    i.item_nf_bonificado 	
                                            ,       coalesce(vv.email_main, 'suporte@oxan.com.br') as email_vendedor 
                                            ,       f.data_emissao
                                            ,       f.data_faturamento
                                            , (
                                                (
                                                    extract(day from f.data_faturamento)::int - 1
                                                    + extract(dow from date_trunc('month', f.data_faturamento))::int
                                                ) / 7
                                            ) + 1 as semana_mes

                        `
        }
        
        
        if (parametro.view == "RESUMO_SEMANA") {
        
            const dataBase = clsTools._datemomentDatStrToDate(
                `${parametro.dataFaturamento_ini}`,
                "YYYY-MM-DD"
            );

            const inicioMes = new Date(dataBase.getFullYear(), dataBase.getMonth(), 1);
            const fimMes = new Date(dataBase.getFullYear(), dataBase.getMonth() + 1, 0);

            parametro.dataFaturamento_ini = clsTools._datemomentDateToStr(inicioMes, "YYYY-MM-DD");
            parametro.dataFaturamento_fim = clsTools._datemomentDateToStr(fimMes, "YYYY-MM-DD");
        
        
            sql = `
                     SELECT  (
                              (
                                  extract(day from f.data_faturamento)::int - 1
                                  + extract(dow from date_trunc('month', f.data_faturamento))::int
                              ) / 7
                          ) + 1 as semana_mes
                        , count(distinct f.numeropedido) as total_pedidos
                        , count(distinct (case when i.qtde_solicitada > i.qtde_faturada then f.numeropedido else null end)) as total_pedidos_corte
                        , count(distinct i.prb_cdprodutobluesoft) as total_itens
                        , COUNT(DISTINCT (case when i.qtde_solicitada > i.qtde_faturada then i.prb_cdprodutobluesoft else null end)) as total_itens_corte
                        , sum(i.valor_preco_aplicado * i.qtde_solicitada) as VALOR_PEDIDO
                        , sum(i.valor_preco_aplicado * i.qtde_faturada)   as VALOR_FATURAMENTO


                
                `
        
        }
        sql += `  
                FROM 		tbfaturamento_bluesoft  f
                     left join  tbfaturamento_bluesoft_item i on i.numeropedido = f.numeropedido and i.numeropedido_fv = f.numeropedido_fv and i.op_cdoperacao = f.op_cdoperacao 
                     left join  tbprodutobluesoft prb on prb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft 
                     left join  tbparticipante_bluesoft v on v.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
                     left join  tbparticipante vv on vv.cdparticipante = v.cdparticipante 
                     left join  tbparticipante_bluesoft c on c.cdpessoabluesoft = f.cdpessoabluesoft_cliente
                     left join  tbparticipante cc on cc.cdparticipante = c.cdparticipante 
                     left join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                where	1 = 1 
        `
           
        if (parametro.em_cdempresa) { 
            sql += ` and em.em_cdempresa = ${parametro.em_cdempresa}`
         }

        if (parametro.op_cdoperacao) { 
            sql += ` and f.op_cdoperacao = ${parametro.op_cdoperacao}`
         }


        if (parametro.statusfaturamentoFiltrar) {
            /* Se existir o statusfaturamentoparametro */

            if (parseInt(parametro.statusfaturamentoFiltrar) === 1) {

                if (parametro.statusfaturamento) { 
                    sql += ` and st.statusfaturamento = ${parametro.statusfaturamento}`
                }

                if (parametro.fat_blue_status_cd && parametro.fat_blue_status_cd != 0) {
                    sql += ` and f.fat_blue_status_cd = ${parametro.fat_blue_status_cd}`
                } 
            } else if (parseInt(parametro.statusfaturamentoFiltrar) === 0) {
                sql += ` and st.statusfaturamento in (0,1) `
            }
         }


         if (parametro.numeropedido && parametro.numeropedido != 0) {
            sql += ` and f.numeropedido = ${parametro.numeropedido}`
         }
         else { 
            if (parametro.dataFaturamento_filter && parametro.dataFaturamento_filter == 1) { 
                let dataFaturamento_ini = clsTools._datemomentDatStrToDate(`${parametro.dataFaturamento_ini}`, `YYYY-MM-DD`)
                let dataFaturamento_fim = clsTools._datemomentDatStrToDate(`${parametro.dataFaturamento_fim}`, `YYYY-MM-DD`)
                sql += ` and f.data_faturamento >= '${clsTools._datemomentDateToStr(dataFaturamento_ini, `YYYY-MM-DD`)}'
                        and f.data_faturamento <= '${clsTools._datemomentDateToStr(dataFaturamento_fim, `YYYY-MM-DD`)}'
                    ` 
            }

            if (parametro.dataPedidoEmissao_filter && parametro.dataPedidoEmissao_filter == 1) { 
                let dataPedidoEmissao_ini = clsTools._datemomentDatStrToDate(`${parametro.dataPedidoEmissao_ini}`, `YYYY-MM-DD`)
                let dataPedidoEmissao_fim = clsTools._datemomentDatStrToDate(`${parametro.dataPedidoEmissao_fim}`, `YYYY-MM-DD`)
                sql += ` and f.data_emissao >= '${clsTools._datemomentDateToStr(dataPedidoEmissao_ini, `YYYY-MM-DD`)}'
                        and f.data_emissao <= '${clsTools._datemomentDateToStr(dataPedidoEmissao_fim, `YYYY-MM-DD`)}'
                    ` 
            }

            if (parametro.descricaogrupoeconomico && parametro.descricaogrupoeconomico != "") {
                sql += ` and UPPER(gr.descricao) like '%${parametro.descricaogrupoeconomico.toUpperCase()}%'`
            }
         }


         if (parametro.cdparticipantevendedor) {
            sql += ` and vv.cdparticipante = ${parametro.cdparticipantevendedor}`
         }


        /*Apenas Pedidos com corte de faturamento */

        if (parametro.view == "DETALHE") {
        sql += `
                            and		s.fat_blue_status_cd in (55, 70)
                            AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                            and		i.qtde_solicitada > i.qtde_faturada  `
        }
        
        if (parametro.view == "DETALHE") {
            sql += `
                            order by 			vv.nome_razao 	    asc
                                        ,		f.data_faturamento  desc
                                        ,       prb.prb_descricao   asc
            
            `
        }

        if (parametro.view == "RESUMO_SEMANA") {
            sql += `
                            group by semana_mes
                            order by semana_mes asc
            
            `
        }

         return sql 

    }

    public static async get(filter : reportFilter) : Promise<object> {
        let result = { }
        try {
            result = await myBase.myDataBase.pag.DataGet( this.sql(filter));
            
        } catch (e) {
            clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
        
        } finally {
            
            return result
        }
    } 

    public static async mail(parametro: any): Promise<void> {
        try {

            if (!parametro.view) {
                parametro.view = "DETALHE"
            }

            if (parametro.view == "DETALHE") {
                await this.mail_vendedor(parametro)
            }

            if (parametro.view == "RESUMO_SEMANA") {
                await this.mail_semanal(parametro)
            }

        } catch (e) {
            clsTools.PagErrorException("reportFaturamentoBluesoftFV_PedidoComCorte", "mail", e);
        }


    }

    public static async mail_vendedor(parametro: any): Promise<void> {
        try {
            parametro.view = "DETALHE"
            const result = await this.get(parametro) as any[];

            if (!Array.isArray(result) || result.length === 0) {
                clsTools.pagConsole("reportFaturamentoBluesoftFV_PedidoComCorte.mail | Sem dados para envio");
                return;
            }

            const toNumber = (value: any): number => Number(value || 0);
            const moneyBr = (value: any): string => "R$ " + toNumber(value).toFixed(2).replace(".", ",");
            const qtyBr = (value: any): string => toNumber(value).toFixed(2).replace(".", ",");

            const vendedores: Record<string, {
                cdpessoabluesoft_vendedor: number;
                nome_razao_vendedor: string;
                email_vendedor: string;
                pedidos: Record<string, any[]>;
            }> = {};

            for (const row of result) {
                const vendedorId = Number(row.cdpessoabluesoft_vendedor || 0);
                const vendedorKey = String(vendedorId);

                if (!vendedores[vendedorKey]) {
                    vendedores[vendedorKey] = {
                        cdpessoabluesoft_vendedor: vendedorId,
                        nome_razao_vendedor: row.nome_razao_vendedor || "",
                        email_vendedor: (row.email_vendedor || "").trim(),
                        pedidos: {}
                    };
                }

                const pedidoKey =
                    String(row.op_cdoperacao || 0) + "-" +
                    String(row.numeropedido_fv || 0) + "-" +
                    String(row.numeropedido || 0);

                if (!vendedores[vendedorKey].pedidos[pedidoKey]) {
                    vendedores[vendedorKey].pedidos[pedidoKey] = [];
                }

                vendedores[vendedorKey].pedidos[pedidoKey].push(row);
            }

            const format = "ADM";
            const mail_TO = String(parametro?.mail_to || "").trim();

            const buildVendedorSection = (vendedor: {
                cdpessoabluesoft_vendedor: number;
                nome_razao_vendedor: string;
                email_vendedor: string;
                pedidos: Record<string, any[]>;
            }): string => {
                let html = "";

                html += "<h3 style='color: #2c3e50; margin-top: 0; margin-bottom: 12px;'>";
                html += "Vendedor: " + (vendedor.nome_razao_vendedor || "Sem nome");
                html += " | Código: " + String(vendedor.cdpessoabluesoft_vendedor);
                html += " | E-mail: " + (vendedor.email_vendedor || "Não informado");
                html += "</h3>";

                html += "<table style='width: 100%; border-collapse: collapse; background-color: white; margin-bottom: 24px;'>";
                html += "<thead style='background-color: #34495e; color: white;'>";
                html += "<tr>";
                html += "<th style='padding: 8px; border: 1px solid #ddd;'>Produto</th>";
                html += "<th style='padding: 8px; border: 1px solid #ddd;'>Cód Produto</th>";
                html += "<th style='padding: 8px; border: 1px solid #ddd;'>Qtd Solicitada</th>";
                html += "<th style='padding: 8px; border: 1px solid #ddd;'>Qtd Faturada</th>";
                html += "<th style='padding: 8px; border: 1px solid #ddd;'>Vl Item NF</th>";
                html += "</tr>";
                html += "</thead>";
                html += "<tbody>";

                const pedidoKeys = Object.keys(vendedor.pedidos).sort();

                for (const pedidoKey of pedidoKeys) {
                    const itens = vendedor.pedidos[pedidoKey];
                    if (!itens || itens.length === 0) continue;

                    const head = itens[0];

                    html += "<tr style='background-color: #ecf0f1;'>";
                    html += "<td colspan='9' style='padding: 8px; border: 1px solid #ddd; font-size: 12px;'>";
                    html += "<strong>Cliente: </strong>" + (head.nome_razao_cliente || "") + " ";
                    html += "<strong>Pedido: </strong> " + String(head.numeropedido || 0);
                    html += " | <strong>Pedido FV:</strong> " + String(head.numeropedido_fv || 0);
                    html += " | <strong>Status:</strong> " + String(head.fat_blue_status_descricao || 0);
                    html += " | <strong>Valor do Pedido:</strong> " + moneyBr(head.valor_pedido || 0);
                    html += " | <strong>Valor do Faturado:</strong> " + moneyBr(head.valor_faturamento || 0);
                    html += " | <strong>Data Emissão:</strong> " + String(clsTools._datemomentDateToStr(head.data_emissao, "DD/MM/YYYY") || "");
                    html += " | <strong>Data Faturamento:</strong> " + String(clsTools._datemomentDateToStr(head.data_faturamento, "DD/MM/YYYY") || "");
                    html += "</td>";
                    html += "</tr>";

                    itens.forEach((item: any, index: number) => {
                        const bgColor = index % 2 === 0 ? "#f8f9fa" : "white";

                        html += "<tr style='background-color: " + bgColor + ";'>";
                        html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px;'>" + (item.prb_descricao || "") + "</td>";
                        html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 10px; text-align: right;'>" + String(item.prb_cdprodutobluesoft || "") + "</td>";
                        html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + qtyBr(item.qtde_solicitada) + "</td>";
                        html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + qtyBr(item.qtde_faturada) + "</td>";
                        html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 10px; text-align: right;'>" + moneyBr(item.valor_nf_item) + "</td>";
                        html += "</tr>";
                    });
                }

                html += "</tbody>";
                html += "</table>";

                return html;
            };

            const listaVendedores = Object.values(vendedores);

            if (mail_TO) {
                let html = "";
                html += "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
                html += "<h2 style='color: #2c3e50; margin-bottom: 16px;'>Pedidos com Corte de Faturamento</h2>";
                html += "<p style='margin-top: 0; margin-bottom: 20px;'>Relatório consolidado por vendedor.</p>";

                listaVendedores.forEach((vendedor, index) => {
                    if (index > 0) {
                        html += "<hr style='border: 0; border-top: 1px solid #ddd; margin: 24px 0;' />";
                    }
                    html += buildVendedorSection(vendedor);
                });

                html += "</div>";

                const subject = "IF0050.030 | Força de Venda - Pedidos com Cortes no Faturamento (Consolidado por Vendedor)";
                await clsTools.mail.sendMail(mail_TO, subject, html, format);
                return;
            }

            for (const vendedor of listaVendedores) {
                if (!vendedor.email_vendedor) {
                    clsTools.pagConsole(
                        "reportFaturamentoBluesoftFV_PedidoComCorte.mail | Vendedor sem e-mail: " +
                        String(vendedor.cdpessoabluesoft_vendedor)
                    );
                    continue;
                }

                let html = "";
                html += "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
                html += "<h2 style='color: #2c3e50; margin-bottom: 8px;'>Pedidos com Corte de Faturamento</h2>";
                html += buildVendedorSection(vendedor);
                html += "</div>";

                const subject = `${REPORT_ID} | Força de Venda - Pedidos com Cortes no Faturamento - ${vendedor.nome_razao_vendedor || "Sem nome"}`;
                await clsTools.mail.sendMail(vendedor.email_vendedor, subject, html, format,"", "rafael.barreto@oxan.com.br; jocelio.alves@oxan.com.br; eliassilva@oxan.com.br");
            }
        } catch (e) {
            clsTools.PagErrorException("reportFaturamentoBluesoftFV_PedidoComCorte", "mail", e);
            throw e;
        }
    }

    public static async mail_semanal(parametro: any): Promise<void> {
        try {

            parametro.view = "RESUMO_SEMANA";
            const result = await this.get(parametro) as any[];

            if (!Array.isArray(result) || result.length === 0) {
                clsTools.pagConsole("reportFaturamentoBluesoftFV_PedidoComCorte.mail_semanal | Sem dados para envio");
                return;
            }

            let html = "";
            html += "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
            html += "<h2 style='color: #2c3e50; margin-bottom: 8px;'>Resumo Semanal - Pedidos com Corte de Faturamento</h2>";
            html += "<h3 style='color: #2c3e50; margin-top: 0; margin-bottom: 20px;'>";
            html += "Período: " + String(clsTools._datemomentDateToStr(parametro.dataFaturamento_ini, "DD/MM/YYYY") || "") + " a " + String(clsTools._datemomentDateToStr(parametro.dataFaturamento_fim, "DD/MM/YYYY") || "");
            html += "</h3>";

            html += "<table style='width: 100%; border-collapse: collapse; background-color: white;'>";
            html += "<thead style='background-color: #34495e; color: white;'>";
            html += "<tr>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>Semana do Mês</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>N. de Pedidos</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>N. de Pedidos Com corte</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>N. de Itens</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>N. de Itens Com corte</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>Valor </th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>Valor Faturado</th>";
            html += "<th style='padding : 8px; border: 1px solid #ddd;'>Corte</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";

            let somaValorPedido = 0;
            let somaValorFaturado = 0;
            let somaCorte = 0;

            result.forEach((row: any, index: number) => {
                const bgColor = index % 2 === 0 ? "#f8f9fa" : "white";
                const valorPedido = Number(row.valor_pedido || 0);

                const valorFaturado = Number(row.valor_faturamento || 0);
                const corte = valorPedido - valorFaturado;

                somaValorPedido += valorPedido;
                somaValorFaturado += valorFaturado;
                somaCorte += corte;

                html += "<tr style='background-color: " + bgColor + ";'>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + String(row.semana_mes || "") + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + String(row.total_pedidos || "") + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + String(row.total_pedidos_corte || "") + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + String(row.total_itens || "") + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + String(row.total_itens_corte || "") + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(valorPedido) + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(valorFaturado) + "</td>";
                html += "<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(corte) + "</td>";
                html += "</tr>";
            });

            const totalSemanas = result.length || 1;
            const mediaValorPedido = somaValorPedido / totalSemanas;
            const mediaValorFaturado = somaValorFaturado / totalSemanas;
            const mediaCorte = somaCorte / totalSemanas;

            html += "<tr style='background-color: #dfe6e9; font-weight: bold;'>";
            html += "<td colspan='5' style='padding: 8px; border: 1px solid #ddd; font-size: 12px; text-align: center;'>MÉDIA</td>";
            html += "<td style='padding: 8px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(mediaValorPedido) + "</td>";
            html += "<td style='padding: 8px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(mediaValorFaturado) + "</td>";
            html += "<td style='padding: 8px; border: 1px solid #ddd; font-size: 12px; text-align: right;'>" + clsTools._formatNumberToStr(mediaCorte) + "</td>";
            html += "</tr>";
            html += "</tbody>";
            html += "</table>";
            html += "</div>";

            const subject = `${REPORT_ID} | Força de Venda - Resumo Semanal de Pedidos com Cortes no Faturamento`;
            const to = parametro?.mail_to || "suporte@oxan.com.br";
            const format = "ADM";
            await clsTools.mail.sendMail(to, subject, html, format);

        } catch (e) {
            clsTools.PagErrorException("reportFaturamentoBluesoftFV_PedidoComCorte", "mail_semanal", e);
            throw e;
        }
    }

}