import { clsBase, clsTools } from "../../../model/modelbase";
import reportSistema from "../../m0001_sistema/report/report";
//import reportSistema from "src/modules/m0001_sistema/report/report";

import modelFaturamentoBluesoft_Processo from "../model/modelFaturamentoBluesoft_processo";
import reportFaturamentoBluesoftProcesso from "../report/reportFaturamentoBluesoftProcesso";

const myBase = new clsBase();

export default class serviceFaturamentoBluesoft_Processo_Registrar {

    static async start(parametro : any) { 
       await this.Processo_TIPO_N20_FaturamentoComCorteClienteVarejo(parametro)
       await this.Processo_TIPO_N30_FaturamentoComCorteClienteTop(parametro)

    }

    static async Processo_TIPO_N20_FaturamentoComCorteClienteVarejo(parametro : any) : Promise<void> { 
    
      try { 


            /*      PERMISSÃO VENDEDORES NA TABELA tbnotificacao_vendedor
                    NOTIFICAÇÃO APENAS VAREJO
                    NOTIFICAÇÃO COM VALOR DE CORTE ACIMA DO PARAMETRO 100500010

            */

            let PARAMETRO_VALOR_MINIMO_VAREJO = await reportSistema.Parametro.getParametroValue(100500010)
            
 
            if (!PARAMETRO_VALOR_MINIMO_VAREJO || PARAMETRO_VALOR_MINIMO_VAREJO == '') {
                PARAMETRO_VALOR_MINIMO_VAREJO = "0.05"
            }


            let dataInicial = clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`)
            let dataFinal = clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`)

                let script_registro_processo = `
                        insert into tbfaturamento_bluesoft_processo
                                    (		op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	fat_blue_status_cd
                                        ,	fat_blue_processo_tipo_cd
                                    )
                                        
                                SELECT 		f.op_cdoperacao 
                                    ,		f.numeropedido
                                    ,		f.numeropedido_fv
                                    ,		f.fat_blue_status_cd
                                    ,		20
                                FROM 		tbfaturamento_bluesoft  f
                                
                                inner join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                                inner join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
                                inner join  tbnotificacao_permissao np on np.cdparticipante = pb.cdparticipante and np.notificacao_cd = 1005000010 
                                INNER JOIN  tbparticipante_bluesoft cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente
                                INNER JOIN  tbgrupoeconomico        ge on ge.cdgrupoeconomico = cb.cdgrupoeconomico and coalesce(ge.johnson_cliente_top,0) = 0
                                where	1 = 1
                                and		f.data_emissao >= '${clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                and		f.data_emissao <= '${clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                and		f.op_cdoperacao = 1
                                and		s.fat_blue_status_cd in (55, 70)
                                AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                                AND     (F.VALOR_PEDIDO - F.VALOR_FATURAMENTO) >= ${PARAMETRO_VALOR_MINIMO_VAREJO}
                                and     not exists (select 1 
                                                    from 	tbfaturamento_bluesoft_processo xx
                                                    where	xx.op_cdoperacao = f.op_cdoperacao 
                                                    and   xx.numeropedido = f.numeropedido 
                                                    and   xx.numeropedido_fv = f.numeropedido_fv 
                                                    and   xx.fat_blue_status_cd = f.fat_blue_status_cd
                                                    
                                                    )
                                and coalesce(ge.johnson_cliente_top,0) = 0
                      `
                /*INSERE OS ITENS QUE DEVERÃO SER ENVIADAS AS MENSAGENS*/
                
                await myBase.myDataBase.pag.Execute(script_registro_processo)






        } catch (e) {
            clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "ForcaVendaRegistrarCortes", e);
        }
    }

    static async Processo_TIPO_N30_FaturamentoComCorteClienteTop(parametro : any) : Promise<void> { 
    
   try { 

            /*      PERMISSÃO VENDEDORES NA TABELA tbnotificacao_vendedor
                    NOTIFICAÇÃO APENAS CLIENTE TOP 

            */


            let dataInicial = clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`)
            let dataFinal = clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`)

                let script_registro_processo = `
                        insert into tbfaturamento_bluesoft_processo
                                    (		op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	fat_blue_status_cd
                                        ,	fat_blue_processo_tipo_cd
                                    )
                                        
                                SELECT 		f.op_cdoperacao 
                                    ,		f.numeropedido
                                    ,		f.numeropedido_fv
                                    ,		f.fat_blue_status_cd
                                    ,		30
                                FROM 		tbfaturamento_bluesoft  f
                                
                                inner join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                                inner join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
                                inner join  tbnotificacao_permissao np on np.cdparticipante = pb.cdparticipante and np.notificacao_cd = 1005000010 
                                INNER JOIN  tbparticipante_bluesoft cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente
                                INNER JOIN  tbgrupoeconomico        ge on ge.cdgrupoeconomico = cb.cdgrupoeconomico and coalesce(ge.johnson_cliente_top,0) = 1
                                where	1 = 1
                                and		f.data_emissao >= '${clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                and		f.data_emissao <= '${clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                and		f.op_cdoperacao = 1
                                and		s.fat_blue_status_cd in (55, 70)
                                AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                                and     not exists (select 1 
                                                    from 	tbfaturamento_bluesoft_processo xx
                                                    where	xx.op_cdoperacao = f.op_cdoperacao 
                                                    and   xx.numeropedido = f.numeropedido 
                                                    and   xx.numeropedido_fv = f.numeropedido_fv 
                                                    and   xx.fat_blue_status_cd = f.fat_blue_status_cd
                                                    
                                                    )
                                and coalesce(ge.johnson_cliente_top,0) = 1
                      `
                /*INSERE OS ITENS QUE DEVERÃO SER ENVIADAS AS MENSAGENS*/
                await myBase.myDataBase.pag.Execute(script_registro_processo)






        } catch (e) {
            clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "ForcaVendaRegistrarCortes", e);
        }
    }
    
}