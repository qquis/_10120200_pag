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
const mdNotificacaoSend_1 = __importDefault(require("../model/mdNotificacaoSend"));
class NF1004500010_PrecoAlteracaoMail {
    static GerarEnvio(ObjectResult, modelNotificacao, ParticipanteDestinatario) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let item = new mdNotificacaoSend_1.default(0);
                item.notificacao_email_subject = "Lista de Produtos alterados";
                item.notificacao_email_title = "Lista de Produtos Alterados hoje";
                item.notificacao_cd = modelNotificacao.notificacao.notificacao_cd;
                item.notificacao_send_tipo_cd = 110;
                item.notificacao_email = ParticipanteDestinatario.email_main;
                item.notificacao_email_cc = ``;
                item.notificacao_email_co = ``;
                item.SetMessage(JSON.stringify(ObjectResult));
                return item;
            }
            catch (e) {
                //PagErrorException("m0210", "NF1004500010_PrecoAlteracaoMail", e);
                throw e;
            }
        });
    }
    static sql(parametors, Destinatario) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = ``;
            try {
                sql = `select 	
                          'eliassilva@oxan.com.br'  as notificacao_email
                        , 'eliassilva@oxan.com.br'  as notificacao_email_cc
                        , 'eliassilva@oxan.com.br'  as notificacao_email_co
                        ,	u.sis_us_seq              as sis_us_seq
                        ,	u.user_name               as user_name
                        ,	l.proc_tipo_cd            as proc_tipo_cd
                        ,	tp.proc_tipo_descricao    as proc_tipo_descricao
                        ,	l.proc_log_seq            as proc_log_seq
                        ,	coalesce(lp.prca_dt_validade_agendamento , cast(l.dtlog_insert as date)) 
                                                    as dataaplicacaoprevista
                        ,	lp.pr_cdproduto           as pr_cdproduto
                        ,	p.pr_descricao            as pr_descricao
                        ,	pb.prb_cdprodutobluesoft_pk
                                                    as prb_cdprodutobluesoft  
                        ,	pb.prb_descricao          as prb_descricao
                        , pb.prb_embalagemestoque   as prb_embalagemestoque
                        ,	lp.prc_valor              as prc_valor
                        ,	cast(lp.prc_qtde_promocional as numeric(13,2))   
                                                    as prc_qtde_promocional


                    from 		tbpreco_log 		lp
                    inner join  tbproduto 			p on p.pr_cdproduto = lp.pr_cdproduto 
                    inner join  tbprodutobluesoft  pb on pb.prb_cdprodutobluesoft_pk = lp.prb_cdprodutobluesoft
                    inner join  tbprocesso_log 		l on l.proc_log_seq = lp.proc_log_seq 
                    inner join  tbsistema_usuario  u on u.sis_us_seq = l.sis_us_seq 
                    inner join  tbprocesso_tipo		tp on tp.proc_tipo_cd = l.proc_tipo_cd 
                    where		1 = 1
                    and			cast(l.dtlog_insert as date) >= current_date
                    AND     (      ( p.pr_embalagemestoque = 'UN' and pb.prb_embalagemestoque = 'UN')
                                or ( p.pr_embalagemestoque = 'KG' )
                            )
                    order by 	l.proc_tipo_cd 
                        ,	tp.proc_tipo_descricao 
                        ,	l.proc_log_seq 
                        ,	p.pr_descricao
                        , 	pb.prb_descricao asc `;
                return sql;
            }
            catch (e) {
                //clsTools.PagErrorException("m0210", "NF1004500010_PrecoAlteracaoMail", e);
                throw e;
            }
        });
    }
}
exports.default = NF1004500010_PrecoAlteracaoMail;
