import { clsTools, clsBase } from "../../../model/modelbase";
import modelzanthus_cupom from "../model/modelzanthus_cupom";


export default class reportZanthusCupom { 

    static sql (parametro: any) : string { 

        let sql = ``
        try { 

        let data_inicial = clsTools._datemomentDatStrToDate(parametro.data_cupom_ini, "YYYY-MM-DD")
        let data_final   = clsTools._datemomentDatStrToDate(parametro.data_cupom_fim, "YYYY-MM-DD")

        
        sql = `
            SELECT   
                       A.M00AF  		                    as data
                   ,   A.M00Ac  		                    as ecf
                   ,   A.M00Ad  		                    as numero_cupom
                   ,   A.M00_id_unico	               	    as id
                   ,   A.M45BO		                		as numero_cupom_cancelador
                   ,   A.M45XD		                		as nf_numero
                   ,   coalesce(N.serie_nf,'0')            	as nf_serie
                   ,   a.M45XB                             	as nf_chave
                   ,   case  																			
                           when A.M00Ad <> A.M45BO then 9                          		
                           else case when coalesce(x.M45BO,0) <> 0 then 1 
                                            else  case n.tiponota 
                                                    when 99 then 2
                                                    when 90 then 3
                                                    else 0
                                                  end
                                end
                       end   			        as status_cancelado
                   ,   case  																			
                           when A.M00Ad <> A.M45BO then 'Estorno de Cupom'                          		
                           else case when coalesce(x.M45BO,0) <> 0 then 'Cancelado/Estornado' 
                                            else  case n.tiponota 
                                                    when 99 then 'NF Cancelada (SIS)'
                                                    when 90 then 'NF Inutilizada (SIS)'
                                                    else ''
                                                  end
                                end
                       end   			        as status_cancelado_descricao                        
                   ,   A.M45AK                             as valor
                   ,   case  																			
                           when A.M00Ad <> A.M45BO then 0                          		
                           else case when coalesce(x.M45BO,0) <> 0 then 0 
                                            else  case n.tiponota 
                                                    when 99 then 0
                                                    when 90 then 0
                                                    else A.M45AK
                                                  end
                                end 
                       end  as valor_efetivo 			  
                   ,   A.m45bv                             as cpf_cnpj
                   ,   (to_timestamp(substring(lpad(cast(A.m45ai as varchar(4)), 4, '0') from 1 for 2) || ':' || substring(lpad(cast(A.m45ai as varchar(4)), 4, '0') from 3 for 2), 'HH24:MI') :: time)		
                                                           AS hora_ini
                   ,   (to_timestamp(substring(lpad(cast(A.m45au as varchar(4)), 4, '0') from 1 for 2) || ':' || substring(lpad(cast(A.m45au as varchar(4)), 4, '0') from 3 for 2), 'HH24:MI') :: time)		
                                                           AS hora_fim
                   ,   A.M45AH                             as  operador_codigo
                   ,   coalesce(voucher.M50AR, '')         as  voucher
                   ,   coalesce(voucher.m50at,0 ) 	        as voucher_valor
                   ,   coalesce(voucher.m50ag,0) 	        as voucher_numero_itens
				   ,   n.tiponota as tiponota_codigo
				   ,   case n.tiponota 
				   			when 0   then 'NF DE CUPOM'
							when 1 	 then 'NF DE TROCA'
							when 2 	 then 'NF DE REGISTRO INDEVIDO'
							when 3	 then 'NF REEMBOLSO'
							when 8 	 then 'NFCE'
							when 90  then 'INUTILIZADA'
							when 99  then 'CANCELADA'
							else 'OUTRAS'
					end as tiponota_descricao 							  
				   	, operador.nome as operador_nome
                    , item.qtde_item        as item_qtde 
                    , item.valor            as item_valor
                    , item.desconto         as item_desconto
                    , item.valor_liquido    as item_valor_liquido                 
            from	ZAN_M45         A                                                                                               
            left join   ZAN_M45         x on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad                        
            left JOIN	tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF                                         
            left join   (                                               
                                select		m00af                       
                                        ,	m00ac                       
                                        ,	m00ad                       
                                        ,	min(m50ar)  as m50ar      
                                        ,	count(m50ag)  as m50ag      
                                        ,	sum(m50at) as m50at
                                from		Zan_M50 q    
                                where		 1= 1                       
                                ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_ini)? 
                                    " and q.m00af >= '" + clsTools._datemomentDateToStr(data_inicial, "YYYY-MM-DD ") + "'" : ""  }
                                ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_fim)? 
                                    " and q.m00af <= '" + clsTools._datemomentDateToStr(data_final, "YYYY-MM-DD") + "'" : ""  }   

                                group by m00af, m00ac, m00ad  
                         ) voucher on voucher.M00AF = a.m00af and voucher.m00ac = a.m00ac  and voucher.M00AD = a.M00AD 
            left join (
                select             m00ac
                                    ,   m00ad
                                    ,   m00af
                                    ,   count(m43ah) as qtde_item
                                    ,   sum(m43ap) as valor
                                    ,   sum(m43aq) as desconto
                                    ,   sum(val_liquido) as valor_liquido
                            from        zan_m43 i
                            where       1 = 1
                                ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_ini)? 
                                    " and i.m00af >= '" + clsTools._datemomentDateToStr(data_inicial, "YYYY-MM-DD ") + "'" : ""  }
                                ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_fim)? 
                                    " and i.m00af <= '" + clsTools._datemomentDateToStr(data_final, "YYYY-MM-DD") + "'" : ""  }   
                            group by    m00ac
                                    ,   m00ad
                                    ,   m00af


            )  item on item.m00ac = a.m00ac and item.m00ad = a.m00ad and item.m00af = a.m00af                                 
			left join tab_funcionario operador on operador.cod_funcionario = A.M45AH
            WHERE	  1 = 1
            ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_ini)? 
               " and a.m00af >= '" + clsTools._datemomentDateToStr(data_inicial, "YYYY-MM-DD") + "'" : ""  }
            ${(parametro.filtrar_data_cupom == 1 && parametro.data_cupom_fim)? 
               " and a.m00af <= '" + clsTools._datemomentDateToStr(data_final, "YYYY-MM-DD") + "'" : ""  }   

            ${(parametro.cpf_cnpj && parametro.cpf_cnpj != '' && parametro.cpf_cnpj != '0')? 
               " and LPAD(a.m45bv, 14, '0') = '" + clsTools.document.formatdb(parametro.cpf_cnpj) + "'" : ""  }


            ${(parametro.valor_inicial > 0)? " and a.m45ak >= " + parametro.valor_inicial : "" }
            ${(parametro.valor_final > 0)? " and a.m45ak <= " + parametro.valor_final : "" }  

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

            ${(parametro.com_desconto == 1) ? ` and coalesce(item.desconto,0) > 0 ` : "" }
            ${(parametro.com_voucher == 1) ? ` and coalesce(voucher.m50at,0) > 0 ` : "" }


            ${(parametro.comDescontoSemVoucher == 1) ? ` and (item.desconto > 0 and coalesce(voucher.m50at,0) = 0 )` : "" }
            `



           if (parametro.filtrarValorCupom && parametro.filtrarValorCupom == 1) {
                if (parametro.valor_inicial > 0) {
                    sql += ` and a.m45ak >= ${parametro.valor_inicial} `
                }
                if (parametro.valor_final > 0) {
                    sql += ` and a.m45ak <= ${parametro.valor_final} `
                }
           }

           sql += ` order by 1,2,3,4,5,6 `



        } catch(e) {
            clsTools.pagConsole("Erro ao montar SQL reportZanthusCupom: " + e, true);
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusCupom - sql", e)
        } finally {

            return sql 
        }
    }

    static async get(parametro: any) : Promise<modelzanthus_cupom[]> { 
        let mylist = new Array<modelzanthus_cupom>()
        try { 


            
            let myBase = new clsBase()

            let res = await myBase.myDataBase.zanthusPostgre.DataGet( this.sql(parametro) )
            for (const [key, value] of Object.entries(res)) {
                let item = new modelzanthus_cupom()
                Object.assign(item, value)
                mylist.push(item)
            }

        } 
         catch(e) { 
            clsTools.PagErrorException("M0055_FaturamentoZanthus", "reportZanthusCupom - get", e)
        } finally { 
            return mylist
        }
    }

    

}