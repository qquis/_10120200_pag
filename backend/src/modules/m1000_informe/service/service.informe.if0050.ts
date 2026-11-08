import { clsBase, clsTools } from "../../../model/modelbase";




/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
    const SISTEMA_NUCLEO_PRC_CD = 10050030
    const FLG_DEBUG_CONSOLE_LOG : boolean = false
    const FLG_MODULO : string = "M1000-INFORME(service.if0050.ts) E-MAIL CORTE DE PEDIDO"
    const FLG_DEBUG_FILE_CONSOLE_LOG : string = ``
/*  ------------------------------------------------------------------------------------------- */    



import reportFaturamentoBluesoft from "../../m0050_faturamento_bluesoft/report/report";
import serviceSistemaLog from "../../m9020_sistema_log/service/service.SistemaLog";
import InformeMailset from "../model/model.informe_mailset";


export default class serviceinforme_if0050 {

    static async start(parametros: any) { 
        try { 

            
            let par = parametros

            
            par = await this.getParametros(par)

            if (!par.enviar_email) {
                await clsTools.pagConsole(`E-MAIL não será enviado (E-mail controlado para envio diário)`,FLG_DEBUG_CONSOLE_LOG,false,FLG_DEBUG_FILE_CONSOLE_LOG, FLG_MODULO)
                return
            }

            par = await this.ObterDados(par)


            await this.sendMailVendedor(par)
            await this.sendMailSupervisor(par)



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "start (service.if0050)", e)
        }
    }

    static async getParametros(parametros: any) : Promise<any>{
        let par = parametros
        try {



            par.enviar_email = false;

            if (par.email_forca_envio_email_controlado && par.email_forca_envio_email_controlado == "1") {
                par.enviar_email = true;
            } else { 

                let ProcedimentoExecutadoHoje : boolean = await serviceSistemaLog.Registrar.LogNucleoProcedimentoToday(SISTEMA_NUCLEO_PRC_CD);

                    if (ProcedimentoExecutadoHoje)
                        await this.__sistemaLog(`Procedimento já executado hoje: ${SISTEMA_NUCLEO_PRC_CD}`)
                    else { 
                        par.enviar_email = true;
                    }
            }





            const hoje = new Date();

            let anoRef = hoje.getFullYear();
            let mesRef = hoje.getMonth(); // 0..11

            if (hoje.getDate() === 1) { //SE FOR DIA PRIMEIRO, DEVE PROCESSAR O MES ANTERIOR
                mesRef -= 1;
                if (mesRef < 0) {
                    mesRef = 11;
                    anoRef -= 1;
                }
            }

            const dataFaturamentoIni = new Date(anoRef, mesRef, 1);
            const dataFaturamentoFim = new Date(anoRef, mesRef + 1, 0);


            const dataInicial = new Date(anoRef, mesRef, 1);
            const dataFinal = new Date(anoRef, mesRef + 1, 0);

            par.dataFaturamento_filter = 1;
            par.dataFaturamento_ini = clsTools._datemomentDateToStr(dataInicial, "YYYY-MM-DD");
            par.dataFaturamento_fim = clsTools._datemomentDateToStr(dataFinal, "YYYY-MM-DD");
            par.mail_to = "" // EMAIL DIÁRIO DEVE ENVIAR OBRIGATORIAMENTE PARA CADA VENDEDOR INDIVIDUALMENTE

            let mailset = new InformeMailset()
            mailset.getDistribuicaoDestinatarios(par)
            par.mail_cc = mailset.mail_cc
            par.mail_bcc = mailset.mail_bcc
            par.email_subervisao = mailset.email_subervisao




            return par
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "getParametros (service.if0050)", e)
            throw e
        }
    }


    static async ObterDados(parametros: any) : Promise<any>{
        let par = parametros
        try {
            
            par.view = "DETALHE"
            par.listVendedor = await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.get(par)
            
            
            par.view = "RESUMO_SEMANA";
            par.listResumoSupervisao = await reportFaturamentoBluesoft.ForcaVenda.PedidoComCorte.get(par)



        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "ObterDados (service.if0050)", e)
            throw e
        } finally {
            return par
        }
        
    }

    static async sendMailVendedor(parametros: any) : Promise<void> {
        let par = parametros
        try {


            if (!Array.isArray(par.listVendedor) || par.listVendedor.length === 0) {
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

            for (const row of par.listVendedor) {
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

            if (par.email_conferencia && par.email_conferencia !== "") {
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
                await clsTools.mail.sendMail(par.email_conferencia, subject, html, format);
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

                const subject = `IF0050 | Força de Venda - Corte de Pedido | Vendedor: ${vendedor.nome_razao_vendedor || "Sem nome"}`;
                await clsTools.mail.sendMail(vendedor.email_vendedor, subject, html, format, par.mail_cc, par.mail_bcc);
            }
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "sendMailVendedor (service.if0050)", e)
            throw e
        }
    }

    static async sendMailSupervisor(parametros: any) : Promise<void> {
          let par = parametros;
          try {
        

        
                    if (!Array.isArray(par.listResumoSupervisao) || par.listResumoSupervisao.length === 0) {
                        clsTools.pagConsole("reportFaturamentoBluesoftFV_PedidoComCorte.mail_semanal | Sem dados para envio");
                        return;
                    }
        
                    let html = "";
                    html += "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
                    html += "<h2 style='color: #2c3e50; margin-bottom: 8px;'>Resumo Semanal - Pedidos com Corte de Faturamento</h2>";
                    html += "<h3 style='color: #2c3e50; margin-top: 0; margin-bottom: 20px;'>";
                    html += "Período: " + String(clsTools._datemomentDateToStr(par.dataFaturamento_ini, "DD/MM/YYYY") || "") + " a " + String(clsTools._datemomentDateToStr(par.dataFaturamento_fim, "DD/MM/YYYY") || "");
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
        
                    par.listResumoSupervisao.forEach((row: any, index: number) => {
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
        
                    const totalSemanas = par.listResumoSupervisao.length || 1;
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
        
                    const subject = `IF0050 | Força de Venda - Corte de Pedido - SUPERVISÃO`;
                    const to = par.email_subervisao || "suporte@oxan.com.br";
                    const format = "ADM";
                    await clsTools.mail.sendMail(to, subject, html, format);
        
                } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "sendMailSupervisor (service.if0050)", e)
            throw e
        }
    }   

    static async __sistemaLog(message: string) : Promise<void> {
        try {
            await serviceSistemaLog.Registrar.submit({
                              sis_nucleo_prc_cd: SISTEMA_NUCLEO_PRC_CD,
                              sis_log_tag: "IF0050",
                              sis_log_info: message,
                              sis_batch_run_seq: 0,
                              proc_log_seq: 0,
                              sis_log_seq: 0,
                              uuid_start: "",
                              uuid: ""
              
                          })
        } catch (e) {
            await clsTools.PagErrorException(FLG_MODULO, "__sistemaLog (service.if0050)", e)
            throw e
        }
    }
}