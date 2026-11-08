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
const model_informe_mailset_1 = __importDefault(require("../model/model.informe_mailset"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 101000020;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M1000-INFORME(service.IF0110.ts - COMISSAO)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceinforme_if0110 {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let par = parametros;
                par.email_subervisao = "distribuicao@oxan.com.br";
                let mailset = new model_informe_mailset_1.default();
                mailset.getDistribuicaoDestinatarios(par);
                par.mail_cc = mailset.mail_cc;
                par.mail_bcc = mailset.mail_bcc;
                par.email_subervisao = mailset.email_subervisao;
                par.seqinterface = 0;
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Inicializando envio de E-MAIL - Coletando Parâmetros`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                par = yield this.getParametros(par);
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Processando VENDA POR VENDEDOR/FABRICANTE`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                par = yield this.getListComissao(par);
                if (par.listComissao.length === 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Processamento VENDA POR VENDEDOR/FABRICANTE Concluído: NÃO HÁ COMISSÃO PARA A COMPETÊNCIA INFORMADA`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    return;
                }
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} - Processamento VENDA POR VENDEDOR/FABRICANTE Concluído _ QTDE DE REG ${par.listComissao.length}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                par = yield this.getListItemComissao(par);
                yield this.sendMailVendedor(par);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "start (service.if0045)", e);
            }
        });
    }
    static getParametros(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let par = parametros;
            try {
                const dataFaturamentoObter = (stringData) => {
                    return modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(stringData, 'YYYY-MM-DD HH:mm:ss'), 'YYYY-MM-DD');
                };
                const dataRelatorio = (stringData) => {
                    return modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(stringData, 'YYYY-MM-DD HH:mm:ss'), 'DD/MM/YYYY');
                };
                if (!par.competencia_cd) {
                    const hoje = new Date();
                    par.competencia_cd = `${hoje.getFullYear()}${String(hoje.getMonth() + 1).padStart(2, '0')}`;
                }
                let sql = `SELECT 	competencia_data_ini
                                ,	competencia_data_fim
                                ,   competencia_cd
                            FROM tbcompetencia 
                            where competencia_cd = ${par.competencia_cd}
                `;
                let result = yield this.__db(sql);
                if (result) {
                    let rowCompetencia = result[0];
                    par.competencia_cd = rowCompetencia.competencia_cd;
                    par.competencia_data_ini = dataFaturamentoObter(rowCompetencia.competencia_data_ini);
                    par.competencia_data_fim = dataFaturamentoObter(rowCompetencia.competencia_data_fim);
                }
                let mailset = new model_informe_mailset_1.default();
                mailset.getDistribuicaoDestinatarios(par);
                par.mail_cc = mailset.mail_cc;
                par.mail_bcc = mailset.mail_bcc;
                par.email_subervisao = mailset.email_subervisao;
                par.periodo_descricao = `${dataRelatorio(par.competencia_data_ini)} a ${dataRelatorio(par.competencia_data_fim)} (CMP ${par.competencia_cd})`;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getParametros (service.if0045)", e);
            }
            return par;
        });
    }
    static getListComissao(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let par = parametros;
            try {
                let sql = `
                   select	
                        ROW_NUMBER() over (order by p.nome_razao asc)                   AS linha
                    ,	fe.cdparticipantevendedor                                       as cdparticipantevendedor				
                    ,	p.cdpessoabluesoft                                              as cdpessoabluesoft
                    ,	p.cpf_cnpj                                                      as cpf_cnpj_vendedor
                    ,	p.nome_razao                                                    as nome_razao_vendedor
                    ,	coalesce(rf.cpf_cnpj, p.cpf_cnpj)                                 as cpf_cnpj_vendedor_faturamento
                    ,	coalesce(rf.nome_razao, p.nome_razao)                             as nome_razao_faturamento
                    ,	fe.fvc_data_lancamento as fvc_data_lancamento
                    ,	fe.fvc_data_fechamento as fvc_data_fechamento
                    ,	fe.fvc_data_periodo_ini as fvc_data_periodo_ini
                    ,	fe.fvc_data_periodo_fim as fvc_data_periodo_fim
                    ,	fe.fvc_competencia as fvc_competencia
                    ,	fe.fvc_comissao_valor_base as fvc_comissao_valor_base
                    ,	fe.fvc_comissao_valor_estorno as fvc_comissao_valor_estorno
                    ,	fe.fvc_comissao_valor as fvc_comissao_valor
                    ,	coalesce(fe.fvc_fat_valor_pgto_premio,0) as fvc_fat_valor_pgto_premio
                    ,	coalesce(fe.fvc_fat_valor_pgto_complemento,0) as fvc_fat_valor_pgto_complemento
                    ,	coalesce(fe.fvc_fat_valor_pgto_impostos,0) as fvc_fat_valor_pgto_impostos
                    ,	coalesce(fe.fvc_fat_valor_pgto_adiantamentos,0) as fvc_fat_valor_pgto_adiantamentos
                    ,	coalesce(fe.fvc_fat_valor_pgto_total,0) as fvc_fat_valor_pgto_total
                    ,	coalesce(fe.fvc_valor_faturamento,0) as fvc_valor_faturamento
                    ,	coalesce(p.email_main, 'suporte@oxan.com.br') as fvc_vendedor_info_email
            from		tbforca_venda_comis fe 
            inner join  tbparticipante								p	on p.cdparticipante = fe.cdparticipantevendedor 
            inner join  tbparticipante_vendedor						i	on i.cdparticipante = fe.cdparticipantevendedor  
            left join   tbparticipante								rf  on rf.cdparticipante = coalesce(i.vendedor_cdparticipante_pj, fe.cdparticipantevendedor )
            where		1 = 1
            and			fe.fvc_competencia = ${parametros.competencia_cd}

						 
            
            `;
                let result = yield this.__db(sql);
                if (result) {
                    par.listComissao = result;
                }
                else {
                    par.listComissao = [];
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "processarRelatorioBaseReal (service.if0045)", e);
            }
            finally {
                return par;
            }
        });
    }
    static getListItemComissao(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let par = parametros;
            try {
                let sql = `
                    select		i.cdparticipantevendedor as cdparticipantevendedor
                            ,	i.cdparticipantecliente as cdparticipantecliente
                            ,	c.cpf_cnpj as cpf_cnpj
                            ,	c.nome_razao as nome_razao
                            ,	i.fvc_it_data_lancamento as fvc_it_data_lancamento
                            ,	nf.df_nf_numero as df_nf_numero
                            ,	nf.df_nf_serie as df_nf_serie
                            ,	nf.df_valor_total as df_valor_total
                            ,	nf.df_entrada_saida as df_entrada_saida
                            ,	coalesce(i.numeropedido ,0) as numeropedido
                            ,	coalesce(pd.fv_tabelapreco_cd ,0) as fv_tabelapreco_cd
                            ,	coalesce(tb.fv_tabelapreco_descricao , 'DEV. CLIENTE') as fv_tabelapreco_descricao
                            ,	i.statusfaturamento as statusfaturamento
                            ,	i.fvc_valor_base as fvc_valor_base
                            ,	i.fvc_percentual as fvc_percentual
                            ,	i.fvc_valor as fvc_valor
                    from		tbforca_venda_comis_item	        i
                    inner join  tbparticipante			            c on  c.cdparticipante = i.cdparticipantecliente 
                    inner join  tbdocumentofiscal			    nf on  nf.df_nf_seq_blue = i.df_nf_seq_blue
                    left join   tbfaturamento_forca_venda       pd on pd.numeropedido = i.numeropedido 
                    left join   tbforca_venda_tabpreco 	        tb on tb.fv_tabelapreco_cd = pd.fv_tabelapreco_cd 
                    WHERE		1 = 1
                    and         i.fvc_competencia = ${parametros.competencia_cd}
                    
            
            `;
                let result = yield this.__db(sql);
                if (result) {
                    par.listItemComissao = result;
                }
                else {
                    par.listItemComissao = [];
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getListItemComissao (service.if0110)", e);
            }
            finally {
                return par;
            }
        });
    }
    static sendMailVendedor(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            const par = parametros;
            try {
                const listaComissao = Array.isArray(par.listComissao) ? par.listComissao : [];
                const listaItens = Array.isArray(par.listItemComissao) ? par.listItemComissao : [];
                if (listaComissao.length === 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | sendMailVendedor | Sem dados para envio`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    return par;
                }
                const num = (value) => {
                    const parsed = Number(value);
                    return Number.isFinite(parsed) ? parsed : 0;
                };
                const fmt = (value, casasDecimais = 2) => num(value).toLocaleString("pt-BR", {
                    minimumFractionDigits: casasDecimais,
                    maximumFractionDigits: casasDecimais,
                });
                const dataBr = (value) => value ? String(modelbase_1.clsTools._datemomentDateToStr(value, "DD/MM/YYYY") || "") : "";
                const escapeHtml = (value) => String(value !== null && value !== void 0 ? value : "")
                    .replace(/&/g, "&amp;")
                    .replace(/</g, "&lt;")
                    .replace(/>/g, "&gt;")
                    .replace(/"/g, "&quot;")
                    .replace(/'/g, "&#39;");
                const TD = `style="border:1px solid #000;padding:2px 4px;font-size:11px;"`;
                const TDR = `style="border:1px solid #000;padding:2px 4px;font-size:11px;text-align:right;"`;
                const TH = `style="border:1px solid #000;padding:3px 4px;font-size:11px;color:#0000cc;text-align:center;font-weight:bold;"`;
                for (const vendedor of listaComissao) {
                    try {
                        const vendedorId = String(vendedor.cdparticipantevendedor);
                        const itensVendedor = listaItens.filter(item => String(item.cdparticipantevendedor) === vendedorId);
                        const nomeVendedor = String(vendedor.nome_razao_vendedor || "").trim();
                        const emailVendedor = String(vendedor.fvc_vendedor_info_email || "").trim();
                        const emailConferencia = String(par.email_conferencia || "").trim();
                        const destinatario = emailConferencia || emailVendedor;
                        if (!destinatario) {
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | sendMailVendedor | Vendedor ${vendedorId} sem e-mail`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            continue;
                        }
                        const valorEstorno = num(vendedor.fvc_comissao_valor_estorno);
                        const subject = `IF0110 | Extrato de Venda / Comissão - ${nomeVendedor} | CMP ${par.competencia_cd}${emailConferencia ? ` (CONFERÊNCIA ${emailConferencia})` : ""}`;
                        const cabecalho = `
                        <table style="border-collapse:collapse;border:1px solid #000;width:100%;">
                            <tr><td colspan="16" ${TH} style="border:1px solid #000;padding:6px;font-size:12px;text-align:center;font-weight:bold;">Dados do Vendedor</td></tr>
                            <tr>
                                <td ${TH}>Cod</td>
                                <td ${TH}>CPF</td>
                                <td ${TH}>Nome</td>
                                <td ${TH}>CNPJ/CPF Contratual</td>
                                <td ${TH}>Data Fechamento</td>
                                <td ${TH}>Data Apuração Inicial</td>
                                <td ${TH}>Data Apuração Final</td>
                                <td ${TH}>Valor Base de Venda</td>
                                <td ${TH}>Comissão (Valor Bruto)</td>
                                <td ${TH}>(-) Estornos</td>
                                <td ${TH}>(-) Valor da Comissão</td>
                                <td ${TH}>(+) Prêmios</td>
                                <td ${TH}>(+) Compl</td>
                                <td ${TH}>(-) Impostos / Ajustes</td>
                                <td ${TH}>(-) Vales</td>
                                <td ${TH}>(-) Valor Líquido</td>
                            </tr>
                            <tr>
                                <td ${TD}>${escapeHtml(vendedor.cdparticipantevendedor)}</td>
                                <td ${TD}>${escapeHtml(vendedor.cpf_cnpj_vendedor)}</td>
                                <td ${TD}>${escapeHtml(nomeVendedor)}</td>
                                <td ${TD}>${escapeHtml(vendedor.cpf_cnpj_vendedor_faturamento)}</td>
                                <td ${TD}>${dataBr(vendedor.fvc_data_fechamento)}</td>
                                <td ${TD}>${dataBr(vendedor.fvc_data_periodo_ini)}</td>
                                <td ${TD}>${dataBr(vendedor.fvc_data_periodo_fim)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_valor_faturamento)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_comissao_valor_base)}</td>
                                <td ${TDR}>${fmt(valorEstorno)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_comissao_valor)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_fat_valor_pgto_premio)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_fat_valor_pgto_complemento)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_fat_valor_pgto_impostos)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_fat_valor_pgto_adiantamentos)}</td>
                                <td ${TDR}>${fmt(vendedor.fvc_fat_valor_pgto_total)}</td>
                            </tr>
                        </table>`;
                        const linhasItens = itensVendedor.map(item => {
                            const tipoLancamento = String(item.df_entrada_saida || "").toUpperCase() === "E" ? "Estorno" : "Venda";
                            return `<tr>
                            <td ${TD}>${escapeHtml(item.cpf_cnpj)}</td>
                            <td ${TD}>${escapeHtml(item.nome_razao)}</td>
                            <td ${TD}>${tipoLancamento}</td>
                            <td ${TD}>${escapeHtml(item.numeropedido)}</td>
                            <td ${TD}>${escapeHtml(item.fv_tabelapreco_descricao)}</td>
                            <td ${TD}>${escapeHtml(item.df_nf_numero)}</td>
                            <td ${TD}>${escapeHtml(item.df_nf_serie)}</td>
                            <td ${TD}>${dataBr(item.fvc_it_data_lancamento)}</td>
                            <td ${TDR}>${fmt(item.df_valor_total)}</td>
                            <td ${TDR}>${fmt(item.fvc_valor_base)}</td>
                            <td ${TDR}>${fmt(item.fvc_percentual)}</td>
                            <td ${TDR}>${fmt(item.fvc_valor)}</td>
                        </tr>`;
                        }).join("");
                        const extrato = `
                        <div style="font-family:Arial,sans-serif;margin-top:16px;font-size:12px;">Lançamentos</div>
                        <table style="border-collapse:collapse;border:1px solid #000;width:100%;margin-top:4px;">
                            <tr><td colspan="12" ${TH} style="border:1px solid #000;padding:6px;font-size:12px;text-align:center;font-weight:bold;">Extrato</td></tr>
                            <tr>
                                <td ${TH}>CNPJ</td>
                                <td ${TH}>Nome</td>
                                <td ${TH}>Tipo Lançamento</td>
                                <td ${TH}>N. Pedido</td>
                                <td ${TH}>Tabela</td>
                                <td ${TH}>NF Venda/Dev</td>
                                <td ${TH}>Série</td>
                                <td ${TH}>Data do Lançamento</td>
                                <td ${TH}>Valor da Venda</td>
                                <td ${TH}>Base Comissão</td>
                                <td ${TH}>Percentual Comissão</td>
                                <td ${TH}>Valor da Comissão</td>
                            </tr>
                            ${linhasItens || `<tr><td ${TD} colspan="12">Nenhum lançamento encontrado para este vendedor.</td></tr>`}
                        </table>`;
                        const html = `<html><body style="font-family:Arial,sans-serif;">
                        <div style="font-size:12px;margin-bottom:12px;">OXAN ATACADISTA LTDA | Extrato de Venda / <strong>Comissão</strong></div>
                        ${cabecalho}${extrato}
                        </body></html>`;
                        yield modelbase_1.clsTools.mail.sendMail(destinatario, subject, html, "ADM", par.mail_cc, par.mail_bcc);
                    }
                    catch (e) {
                        yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `sendMailVendedor vendedor ${vendedor.cdparticipantevendedor} (Service.if0110)`, e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "sendMailVendedor (service.if0110)", e);
            }
            finally {
                return par;
            }
        });
    }
    static __db(string_sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let __db = new modelbase_1.clsBase();
                let result = __db.myDataBase.pag.DataGet(string_sql);
                return result;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "__db (Service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
}
exports.default = serviceinforme_if0110;
