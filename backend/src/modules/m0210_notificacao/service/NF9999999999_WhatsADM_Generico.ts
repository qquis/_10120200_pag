import { clsTools } from "../../../model/modelbase";
import mdNotificacaoSendMessage from "../model/mdNotificacaoSend";
import modelNotificacao from "../model/_ModelNotificacao";
import mdNotificacaoParticipante from "../model/mdNotificacaoParticipante";



export default class NF1004500010_PrecoAlteracaoMail{
    public static async GerarEnvio(ObjectResult: object, modelNotificacao: modelNotificacao, ParticipanteDestinatario: mdNotificacaoParticipante): 
                Promise<mdNotificacaoSendMessage> {
      try {


        let item : mdNotificacaoSendMessage = new mdNotificacaoSendMessage(0)
        item.notificacao_email_subject = "Lista de Produtos alterados"
        item.notificacao_email_title = "Lista de Produtos Alterados hoje"
        item.notificacao_cd = modelNotificacao.notificacao.notificacao_cd
        item.notificacao_send_tipo_cd = 110 
        item.notificacao_email = ParticipanteDestinatario.email_main
        item.notificacao_email_cc = ``
        item.notificacao_email_co = `` 
        item.notificacao_celular_dd_numero = `` 
        item.SetMessage(JSON.stringify(ObjectResult))
        return item

      } catch (e) {
         //PagErrorException("m0210", "NF1004500010_PrecoAlteracaoMail", e);
        throw e;
      }
  }

  public static async sql(parametors : any, Destinatario : mdNotificacaoParticipante ) : Promise<string> { 
      let sql : string = ``
    
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
                        , 	pb.prb_descricao asc `

        return sql;

      } catch (e) {
          //clsTools.PagErrorException("m0210", "NF1004500010_PrecoAlteracaoMail", e);
          throw e;
      }
  }
}