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
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M1000-INFORME(service.if0017.ts)";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
class serviceinforme_if0017 {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let par = yield this.getParametros(parametros);
                par.mail_to = "distribuicao@oxan.com.br";
                par.mail_cc = "jocelio.alves@oxan.com.br;rafael.barreto@oxan.com.br";
                /*Monta a lista basica */
                par = yield this.getDisponibilidade(par);
                /*Consulta os estoques pedentes*/
                par = yield this.getEstoquePendente(par);
                /*Envia o e-mail*/
                yield this.getDadosEstatisticos(par);
                /*Realiza os cálculos*/
                par = yield this.getcalculos(par);
                /*Lista de fornecedores*/
                par = yield this.getListaFornecedores(par);
                par.mail_to = "distribuicao@oxan.com.br";
                par.mail_cc = "jocelio.alves@oxan.com.br;rafael.barreto@oxan.com.br; eliassilva@oxan.com.br";
                /*Envia o e-mail*/
                yield this.sendMail(par);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "start (service.if0017)", e);
            }
        });
    }
    static getParametros(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let par = parametros;
                const data_base = new Date();
                par.data_fat_mes_projetado_01_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth() - 3, 1), "YYYY-MM-DD");
                par.data_fat_mes_projetado_01_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth() - 2, 0), "YYYY-MM-DD");
                par.data_fat_mes_projetado_02_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth() - 2, 1), "YYYY-MM-DD");
                par.data_fat_mes_projetado_02_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth() - 1, 0), "YYYY-MM-DD");
                par.data_fat_mes_projetado_03_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth() - 1, 1), "YYYY-MM-DD");
                par.data_fat_mes_projetado_03_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear() - 1, data_base.getMonth(), 0), "YYYY-MM-DD");
                par.data_fat_mes_01_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth() - 3, 1), "YYYY-MM-DD");
                par.data_fat_mes_01_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth() - 2, 0), "YYYY-MM-DD");
                par.data_fat_mes_02_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth() - 2, 1), "YYYY-MM-DD");
                par.data_fat_mes_02_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth() - 1, 0), "YYYY-MM-DD");
                par.data_fat_mes_03_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth() - 1, 1), "YYYY-MM-DD");
                par.data_fat_mes_03_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth(), 0), "YYYY-MM-DD");
                par.data_fat_mes_corrente_ini = modelbase_1.clsTools._datemomentDateToStr(new Date(data_base.getFullYear(), data_base.getMonth(), 1), "YYYY-MM-DD");
                par.data_fat_mes_corrente_fim = modelbase_1.clsTools._datemomentDateToStr(new Date(), "YYYY-MM-DD");
                return par;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getParametros (service.if0017)", e);
            }
        });
    }
    static getDisponibilidade(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let par = parametros;
            par.list = [];
            try {
                let ListTempTbDisponibilidadeEstoque = [];
                let stringSQL = `select 			ps.cdpessoabluesoft		                        as cdpessoabluesoft	                                                                                                                        				
                                        ,		ps.nome_abreviado		                        as fabricante					
                                        ,		ps.cpf_cnpj					                    as fabricante_cnpj
                                        ,		pr.pr_cdproduto								    as cdproduto
                                        ,		pr.pr_embalagemestoque			                as EmbalagemEstoque
                                        ,		pr.pr_embalagemcompra 			                as EmbalagemCompra
                                        ,		pr.prb_cdprodutobluesoft 		                as cdprodutobluesoft
                                        ,		pr.pr_descricao  				                as descricao
                                        ,		pb.prb_cdbarra_principal		                as prb_cdpbarra_principal
                                        ,		coalesce(pf.prbf_codigo_referencia,'')	        as cdprodutobluesoft_fabricante
                                        ,		case when pb.prb_cdproduto_compra_padrao = 0 
                                                     then pb.prb_cdprodutobluesoft_pk 
                                                     else pb.prb_cdproduto_compra_padrao 
                                                     end 	                                    as cdprodutobluesoft_compra
                                        ,		px.prb_fatorestoque			                    as qtde_unid_cmp
                                        ,		pf.prbf_descricao 				                as cdprodutobluesoft_comprar_Descricao
                                        ,		cast(es.ec_embalagemestoque_qtde / coalesce(px.prb_fatorestoque ,1) as numeric(13,4)) 	
                                                                                                as estoque
                                from 		tbproduto 					pr
                                inner join 	tbprodutobluesoft				pb on pb.prb_cdprodutobluesoft_pk = pr.prb_cdprodutobluesoft
                                inner join  tbprodutobluesoft				px on px.prb_cdprodutobluesoft_pk = case when pb.prb_cdproduto_compra_padrao = 0 then pb.prb_cdprodutobluesoft_pk else pb.prb_cdproduto_compra_padrao end 
                                left  join  tbpessoabluesoft				ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante
                                left join   tbprodutobluesoft_fornecedor	pf on pf.prb_cdprodutobluesoft = case when pb.prb_cdproduto_compra_padrao = 0 then pb.prb_cdprodutobluesoft_pk else pb.prb_cdproduto_compra_padrao 
                                                                                end  and pf.prbf_cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante
                                left join   tbestoquecusto				es on es.pr_cdproduto = pr.pr_cdproduto 
                                where		1 = 1
                                and			( pb.prb_status = 'true' or coalesce(es.ec_embalagemestoque_qtde,0) > 0)
                                and			ps.cdpessoabluesoft in ( select fv_fabricante_cdpessoabluesoft from tbforca_venda_fabricante where coalesce(mail_notificacao_giro,0) = 1  )

                                order by 	ps.nome_razao, pr.pr_descricao asc
            `;
                let result = yield this.__db(stringSQL);
                ListTempTbDisponibilidadeEstoque = result;
                par.list = ListTempTbDisponibilidadeEstoque;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getDisponibilidade (service.if0017)", e);
            }
            finally {
                return par;
            }
        });
    }
    static getEstoquePendente(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let parametros = parametro;
            try {
                let sqlScriptPendente = `
                      select      pr.pr_cdproduto
                                ,   pr.prb_cdprodutobluesoft
                                ,   sum(cast( i.qtde_unitaria_solicitada as numeric(13,2))) as embalagemestoqueqtdepend
                                ,   sum(cast( i.qtde_unitaria_solicitada / pr.pr_embalagemcompra_fator as numeric(13,2))) as embalagemcompraqtdepend

                        from        tbfaturamento_bluesoft_item i
                        inner join  tbfaturamento_bluesoft f    on f.numeropedido = i.numeropedido and f.numeropedido_fv = i.numeropedido_fv
                        inner join  tbprodutobluesoft      pb   on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        inner join  tbproduto              pr   on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario 
                        where   fat_blue_status_cd in (20,25,27,30,40,45,50)
                        and   data_emissao >= current_date - 20
                        group by    pr.pr_cdproduto
                                ,   pr.prb_cdprodutobluesoft
            `;
                let resultPendente = yield this.__db(sqlScriptPendente);
                if (resultPendente) {
                    let listPendente = resultPendente;
                    for (let item of parametros.list) {
                        let pendente = listPendente.find(p => p.prb_cdprodutobluesoft === item.cdprodutobluesoft);
                        if (pendente) {
                            item.embalagemestoqueqtdepend = pendente.embalagemestoqueqtdepend;
                            item.embalagemcompraqtdepend = pendente.embalagemcompraqtdepend;
                        }
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getEstoquePendente (service.if0017)", e);
            }
            finally {
                return parametros; // or return the appropriate result for pending stock
            }
        });
    }
    static getDadosEstatisticos(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sqlScriptEstatistico = `
                SELECT     x.pr_cdproduto 
                         , coalesce(mes_corrente.embalagemcompraqtde	,0) as qtde_venda_mes_corrente
                         , coalesce(mes_01.embalagemcompraqtde,0) as qtde_venda_mes_01
                         , coalesce(mes_02.embalagemcompraqtde,0) as qtde_venda_mes_02
                         , coalesce(mes_03.embalagemcompraqtde,0) as qtde_venda_mes_03
                         , coalesce(mes_projetado_01.embalagemcompraqtde,0) as qtde_venda_mes_projetado_01
                         , coalesce(mes_projetado_02.embalagemcompraqtde,0) as qtde_venda_mes_projetado_02
                         , coalesce(mes_projetado_03.embalagemcompraqtde,0) as qtde_venda_mes_projetado_03

                FROM		tbproduto	x
                inner join 	tbprodutobluesoft				pb on pb.prb_cdprodutobluesoft_pk = x.prb_cdprodutobluesoft
                left  join  tbpessoabluesoft				ps on ps.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fabricante
                
                
                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	    o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_corrente_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_corrente_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_CORRENTE ON MES_CORRENTE.pr_cdproduto = x.pr_cdproduto 
                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_01_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_01_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_01 ON MES_01.pr_cdproduto = x.pr_cdproduto 
                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_02_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_02_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_02 ON MES_02.pr_cdproduto = x.pr_cdproduto 
                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_03_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_03_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_03 ON MES_03.pr_cdproduto = x.pr_cdproduto 


                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_projetado_01_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_projetado_01_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_PROJETADO_01 ON MES_PROJETADO_01.pr_cdproduto = x.pr_cdproduto 


                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_projetado_02_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_projetado_02_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_PROJETADO_02 ON MES_PROJETADO_02.pr_cdproduto = x.pr_cdproduto 
                            

                LEFT JOIN  (	SELECT		I.pr_cdproduto
                                        ,	sum(i.EmbalagemCompraQtde)	EmbalagemCompraQtde
                                FROM		TbFaturamento			f
                                INNER JOIN	TbFaturamentoOrigem	o ON o.SeqFaturamento		=	f.seqfaturamento
                                INNER JOIN	TbFaturamentoitens		i ON i.SeqFaturamentoorigem	=	o.SeqFaturamentoorigem
                                WHERE		f.op_cdoperacao			=	1
                                AND			f.em_cdempresa			=	1
                                AND			f.StatusFaturamento		=	1
                                AND			i.StatusFaturamentoItem	=	1
                                AND			f.datafaturamento >= '${parametros.data_fat_mes_projetado_03_ini}'
                                AND			f.datafaturamento <= '${parametros.data_fat_mes_projetado_03_fim}'
                                GROUP BY	I.pr_cdproduto
                            )	MES_PROJETADO_03 ON MES_PROJETADO_03.pr_cdproduto = x.pr_cdproduto 
               
                            where		1 = 1
                and			ps.cdpessoabluesoft in ( select fv_fabricante_cdpessoabluesoft from tbforca_venda_fabricante where coalesce(mail_notificacao_giro,0) = 1  )                
                                 
            
            
            
            `;
                let result = yield this.__db(sqlScriptEstatistico);
                if (result) {
                    let listDadoEstatisticos = result;
                    for (let item of parametros.list) {
                        let dadoEstatisticoVenda = listDadoEstatisticos.find(p => p.pr_cdproduto === item.cdproduto);
                        if (dadoEstatisticoVenda) {
                            item.qtde_venda_mes_corrente = dadoEstatisticoVenda.qtde_venda_mes_corrente;
                            item.qtde_venda_mes_01 = dadoEstatisticoVenda.qtde_venda_mes_01;
                            item.qtde_venda_mes_02 = dadoEstatisticoVenda.qtde_venda_mes_02;
                            item.qtde_venda_mes_03 = dadoEstatisticoVenda.qtde_venda_mes_03;
                            item.qtde_venda_mes_projetado_01 = dadoEstatisticoVenda.qtde_venda_mes_projetado_01;
                            item.qtde_venda_mes_projetado_02 = dadoEstatisticoVenda.qtde_venda_mes_projetado_02;
                            item.qtde_venda_mes_projetado_03 = dadoEstatisticoVenda.qtde_venda_mes_projetado_03;
                        }
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "DadosEstatisticos (service.if0017)", e);
            }
            finally {
                return parametros; // or return the appropriate result for statistical data
            }
        });
    }
    static getcalculos(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let par = parametros;
            try {
                const toNumber = (v) => Number(v || 0);
                for (let item of par.list) {
                    item.media_venda = (toNumber(item.qtde_venda_mes_01) + toNumber(item.qtde_venda_mes_02) + toNumber(item.qtde_venda_mes_03)) / 3;
                    item.media_venda_futura = (toNumber(item.qtde_venda_mes_projetado_01) + toNumber(item.qtde_venda_mes_projetado_02) + toNumber(item.qtde_venda_mes_projetado_03)) / 3;
                    item.estoque_disponivel = (toNumber(item.estoque) - toNumber(item.embalagemcompraqtdepend));
                    item.dias_disponivel = 0;
                    if (item.estoque_disponivel > 0) {
                        if (toNumber(item.media_venda_futura) > 0) {
                            item.dias_disponivel = item.estoque_disponivel > 0 ? item.estoque_disponivel / (toNumber(item.media_venda_futura) / 30) : 0;
                        }
                        else if (toNumber(item.media_venda) > 0) {
                            item.dias_disponivel = item.estoque_disponivel > 0 ? item.estoque_disponivel / (toNumber(item.media_venda) / 30) : 0;
                        }
                    }
                    item.necessidade = 0;
                    if ((20 - toNumber(item.dias_disponivel)) > 0) {
                        if (toNumber(item.media_venda_futura) > 0) {
                            item.necessidade = (20 - toNumber(item.dias_disponivel)) * (toNumber(item.media_venda_futura) / 30);
                        }
                        else if (toNumber(item.dias_disponivel) > 0 && toNumber(item.media_venda) > 0) {
                            item.necessidade = (20 - toNumber(item.dias_disponivel)) * (toNumber(item.media_venda) / 30);
                        }
                        item.necessidade = item.necessidade;
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "Calculos (service.if0017)", e);
            }
            finally {
                return par; // or return the appropriate result for calculations
            }
        });
    }
    static getListaFornecedores(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let parametros = parametro;
            try {
                let sqlScriptPendente = `
            select 	 	 cast(a.fv_fabricante_cdpessoabluesoft as int)            as cdpessoabluesoft
                    ,    cast(x.cpf_cnpj as varchar(14))                          as cpf_cnpj
                    ,    cast(x.nome_abreviado as varchar(60))                    as nome_razao
                    ,    case when coalesce(a.mail_notificacao_estoque,0) = 1 then 'SIM' else 'NAO' end 
                                                                                 as informacao_por_email
                    ,    coalesce(a.mail_notificacao_estoque_address, '')           as email_endereco
            from		tbforca_venda_fabricante	a 
            left join	tbpessoabluesoft			x on x.cdpessoabluesoft = a.fv_fabricante_cdpessoabluesoft
            WHERE		1 = 1 
            `;
                let resultListaFornecedor = yield this.__db(sqlScriptPendente);
                if (resultListaFornecedor) {
                    let ListaFornecedor = resultListaFornecedor;
                    parametros.ListaFornecedor = ListaFornecedor;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "getEstoquePendente (service.if0017)", e);
            }
            finally {
                return parametros; // or return the appropriate result for pending stock
            }
        });
    }
    static sendMail(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            let list = parametros.list || [];
            try {
                if (!Array.isArray(list) || list.length === 0) {
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | sendMail | Sem dados para envio`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    return;
                }
                const toNumber = (v) => Number(v || 0);
                const numBr = (v, decimals = 2) => toNumber(v).toFixed(decimals).replace(".", ",");
                const dateBr = (v) => v ? String(modelbase_1.clsTools._datemomentDateToStr(v, "DD/MM/YYYY") || "") : "";
                const th = (txt, extra = "") => `<th style='padding: 8px; border: 1px solid #ddd; font-size: 11px; ${extra}'>${txt}</th>`;
                const td = (txt, align = "right", size = 12) => `<td style='padding: 6px; border: 1px solid #ddd; font-size: ${size}px; text-align: ${align};'>${txt !== null && txt !== void 0 ? txt : ""}</td>`;
                // Agrupa por fabricante (equivale ao agrupamento por vendedor do modelo)
                const fabricantes = {};
                for (const row of list) {
                    const key = row.fabricante || "Sem fabricante";
                    (fabricantes[key] = fabricantes[key] || []).push(row);
                }
                const hoje = new Date();
                const meses = [3, 2, 1].map(n => String(new Date(hoje.getFullYear(), hoje.getMonth() - n, 1).getMonth() + 1).padStart(2, "0"));
                const mesesProj = [1, 2, 3].map(n => String(new Date(hoje.getFullYear(), hoje.getMonth() - n, 1).getMonth() + 1).padStart(2, "0"));
                const buildFabricante = (nome, rows) => {
                    let html = "";
                    html += `<h3 style='color: #2c3e50; margin-top: 0; margin-bottom: 12px;'>Fabricante: ${nome}</h3>`;
                    html += "<table style='width: 100%; border-collapse: collapse; background-color: white; margin-bottom: 24px;'>";
                    html += "<thead style='background-color: #34495e; color: white;'>";
                    html += "<tr>";
                    html += th("Cd Pag") + th("Cd Blue") + th("Cd Fabr") + th("C Barra") + th("Descrição") + th("Emb.CMP") + th("Fator");
                    meses.forEach(m => html += th(m));
                    html += th("Mês Atual") + th("MD");
                    mesesProj.forEach(m => html += th(m));
                    html += th("MD Proj.");
                    html += th("Estoque") + th("Pendente (Vol)") + th("Estoq. Disponível") + th("Dias de cobertura");
                    html += th("Necessidade") + th("Data Últ. Venda") + th("Informativo");
                    html += "</tr></thead><tbody>";
                    rows.forEach((r, i) => {
                        const bg = i % 2 === 0 ? "#ffffff" : "#f8f9fa";
                        html += `<tr style='background-color: ${bg};'>`;
                        html += td(r.cdproduto, "right", 10);
                        html += td(r.cdprodutobluesoft, "right", 10);
                        html += td(r.cdprodutobluesoft_fabricante, "right", 10);
                        html += td(r.prb_cdpbarra_principal, "left", 10);
                        html += td(r.descricao, "left", 11);
                        html += td(r.embalagemcompra, "center");
                        html += td(numBr(r.qtde_unid_cmp, 1), "right");
                        html += td(numBr(r.qtde_venda_mes_03));
                        html += td(numBr(r.qtde_venda_mes_02));
                        html += td(numBr(r.qtde_venda_mes_01));
                        html += td(numBr(r.qtde_venda_mes_corrente));
                        html += td(numBr(r.media_venda));
                        html += td(numBr(r.qtde_venda_mes_projetado_01));
                        html += td(numBr(r.qtde_venda_mes_projetado_02));
                        html += td(numBr(r.qtde_venda_mes_projetado_03));
                        html += td(numBr(r.media_venda_futura));
                        html += td(numBr(r.estoque));
                        html += td(numBr(r.embalagemcompraqtdepend));
                        html += `<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right; color: ${toNumber(r.estoque_disponivel) < 0 ? "#c0392b" : "inherit"};'>${numBr(r.estoque_disponivel)}</td>`;
                        html += td(numBr(r.dias_disponivel));
                        html += `<td style='padding: 6px; border: 1px solid #ddd; font-size: 12px; text-align: right; ${toNumber(r.necessidade) > 0 ? "font-weight: bold; color: #c0392b;" : ""}'>${numBr(r.necessidade, 0)}</td>`;
                        html += td(dateBr(r.dt_ult_vda), "center", 10);
                        html += td(r.informativo || "-", "left", 11);
                        html += "</tr>";
                    });
                    html += "</tbody></table>";
                    return html;
                };
                let html = "";
                html += "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
                html += "<h2 style='color: #2c3e50; margin-bottom: 16px;'>Análise de Giro - Disponibilidade de Estoque</h2>";
                html += "<p style='margin-top: 0; margin-bottom: 20px;'>Relatório consolidado por fabricante.</p>";
                if (parametros && parametros.ListaFornecedor && parametros.ListaFornecedor.length > 0) {
                    html += "<h3 style='color:#2c3e50;'>Fornecedores</h3>";
                    html += "<table style='border-collapse:collapse; margin-bottom:24px;'><thead style='background-color:#34495e; color:white;'><tr>";
                    html += th("Cd Blue")
                        + th("CNPJ/CPF")
                        + th("Fornecedor")
                        + th("Notifica?")
                        + th("E-mail");
                    html += "</tr></thead><tbody>";
                    parametros.ListaFornecedor.forEach((f, i) => {
                        const bg = i % 2 === 0 ? "#ffffff" : "#f7f7f7";
                        html += `<tr style='background-color:${bg};'>`;
                        html += td(f.cdpessoabluesoft, "right", 11)
                            + td(f.cpf_cnpj, "left", 11)
                            + td(f.nome_razao, "left", 11)
                            + td(f.informacao_por_email, "center", 11)
                            + td(f.email_endereco || "-", "left", 11);
                        html += "</tr>";
                    });
                    html += "</tbody></table>";
                }
                Object.entries(fabricantes).forEach(([nome, rows], index) => {
                    if (index > 0)
                        html += "<hr style='border: 0; border-top: 1px solid #ddd; margin: 24px 0;' />";
                    html += buildFabricante(nome, rows);
                });
                html += "</div>";
                const subject = "IF0017 | Análise de Giro - Disponibilidade de Estoque";
                yield modelbase_1.clsTools.mail.sendMail(parametros.mail_to, subject, html, "ADM", parametros.mail_cc);
                // Envio individual: somente fornecedores com informacao_por_email = 'SIM'
                const norm = (s) => String(s !== null && s !== void 0 ? s : "").trim().toUpperCase();
                const emailValido = (e) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(String(e !== null && e !== void 0 ? e : "").trim());
                const fornecedorPorNome = new Map((parametros.ListaFornecedor || []).map(f => [norm(f.nome_razao), f]));
                for (const [nome, rows] of Object.entries(fabricantes)) {
                    const f = fornecedorPorNome.get(norm(nome));
                    if (!f || norm(f.informacao_por_email) !== "SIM")
                        continue;
                    try {
                        let htmlForn = "<div style='font-family: Arial, sans-serif; font-size: 12px;'>";
                        htmlForn += "<h2 style='color: #2c3e50; margin-bottom: 16px;'>Análise de Giro - Disponibilidade de Estoque</h2>";
                        htmlForn += `<p style='margin-top: 0; margin-bottom: 20px;'>Relatório do fornecedor ${nome}.</p>`;
                        htmlForn += buildFabricante(nome, rows);
                        htmlForn += "</div>";
                        yield modelbase_1.clsTools.mail.sendMail(String(f.email_endereco).trim(), `${subject} | ${nome}`, htmlForn, "ADM", parametros.mail_cc);
                    }
                    catch (e) {
                        yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `sendMail fornecedor ${nome} (service.if0017)`, e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
                    }
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "sendMail (service.if0017)", e, false, "", FLG_DEBUG_FILE_CONSOLE_LOG);
                throw e;
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
exports.default = serviceinforme_if0017;
