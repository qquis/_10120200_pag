import { clsTools, clsBase } from "../../../model/modelbase";
import modelzanthus_cupom from "../model/modelzanthus_cupom";


export default class reportZanthusPagamento { 

    static sql (parametro: any) : string { 

        let sql = ``
        try { 

        let data_inicial = clsTools._datemomentDatStrToDate(parametro.data_cupom_ini, "YYYY-MM-DD")
        let data_final   = clsTools._datemomentDatStrToDate(parametro.data_cupom_fim, "YYYY-MM-DD")

        
        sql = `
            select  pg.m00af                            as datafaturamento
                ,   pg.m00ac                            as ecf 
                ,   pg.m00ad                            as numerocupom
                ,   A.M45XD		                		as nf_numero
                ,   coalesce(N.serie_nf,'0')            as nf_serie
                ,   a.M45XB                             as nf_chave    
                ,   pg.m04ak                            as valor 
                ,   pg.m04aw                            as valor_troco
                ,   pg.m04bx                            as valor_troco_x
                ,   pg.m04ai                            as finalizadora_cd
                ,   f.descricao                         as finalizadora_descricao
                ,   pg.m04azb                           as bandeiracd
                ,   pg.m04ba                            as sitef_codigo_autorizacao
                ,   pg.m04bbc                           as sitef_cartao_bin
                ,   pg.m04cu                            as sitef_transacao
                ,   pg.m04cz                            as sitef_credenciadora_cnpj 
                ,   pg.m04da                            as sitef_bandeira_cartao
                ,   pg.m04dl                            as sitef_tipo_cartao
                ,   pg.m04ah                            as operador_codigo
                ,   fu.nome                             as operador_nome
            from        zan_m04 pg 
            inner join	ZAN_M45         A on a.m00ac = pg.m00ac and a.m00ad = pg.m00ad and a.m00af = pg.m00af                                                                                            
            left join   ZAN_M45         x on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad                        
            left JOIN	tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF  
            left join   tab_finalizadora f on f.cod_finalizadora = pg.m04ai
            left join   tab_funcionario  fu on fu.cod_funcionario = pg.m04ah
            WHERE 1 = 1
            
            ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_ini)? 
               " and a.m00af >= '" + clsTools._datemomentDateToStr(data_inicial, "YYYY-MM-DD") + "'" : ""  }
            ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_fim)? 
               " and a.m00af <= '" + clsTools._datemomentDateToStr(data_final, "YYYY-MM-DD") + "'" : ""  }   

            ${(parametro.cpf_cnpj && parametro.cpf_cnpj != '' && parametro.cpf_cnpj != '0')? 
               " and LPAD(a.m45bv, 14, '0') = '" + clsTools.document.formatdb(parametro.cpf_cnpj) + "'" : ""  }

            ${(parametro.ecf && parametro.ecf != '' && parametro.ecf != '0')? 
               " and a.m00ac = " + parametro.ecf  : ""  }

            ${(parametro.numero_cupom && parametro.numero_cupom != '' && parametro.numero_cupom != '0')? 
               " and a.m00ad = " + parametro.numero_cupom  : ""  }

            ${(parametro.tipo_nota && parametro.tipo_nota != "999")?
                ` and coalesce(N.tiponota,0) = ${parametro.tipo_nota} ` : "" }


            ${(parametro.status_cancelado !== undefined && parametro.status_cancelado !== null && parametro.status_cancelado != "999") ?
                `  and (case  																			
                           when A.M00Ad <> A.M45BO then 9                          		
                           else case when coalesce(x.M45BO,0) <> 0 then 1 
                                            else  case n.tiponota 
                                                    when 99 then 2
                                                    when 90 then 3
                                                    else 0
                                                  end
                                end
                       end)  = ${parametro.status_cancelado} ` : "" }
            `

           if (parametro.filtrarValorCupom && parametro.filtrarValorCupom == 1) {
                if (parametro.valor_inicial > 0) {
                    sql += ` and a.m45ak >= ${parametro.valor_inicial} `
                }
                if (parametro.valor_final > 0) {
                    sql += ` and a.m45ak <= ${parametro.valor_final} `
                }
           }



           if (parametro.filtrarValorPgto && parametro.filtrarValorPgto == 1) {
                if (parametro.valor_pgto_inicial > 0) {
                    sql += ` and pg.m04ak >= ${parametro.valor_pgto_inicial} `
                }
                if (parametro.valor_pgto_final > 0) {
                    sql += ` and pg.m04ak <= ${parametro.valor_pgto_final} `
                }
            }

            if (parametro.finalizadora_cd && parametro.finalizadora_cd != '' && parametro.finalizadora_cd != '0') {
                sql += ` and pg.m04ai = ${parametro.finalizadora_cd} `
            }

            sql += ` order by 1,2,3,4,5,6 `



        } catch(e) {
            clsTools.pagConsole("Erro ao montar SQL reportZanthusCupom: " + e, true);
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusCupom - sql", e)
        } finally {

            return sql 
        }
    }

    static async get(parametro: any) : Promise<any[]> {
        let mylist : any = []
        try { 

          
            let myBase = new clsBase()
            mylist = await myBase.myDataBase.zanthusPostgre.DataGet( this.sql(parametro) )
        } 
         catch(e) { 
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusPagamentos - get", e)
        } finally { 
            return mylist
        }
    }

    

}