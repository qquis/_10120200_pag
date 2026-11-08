import myTools from "../../../tools/Tools";
import { ifilter_faturamento } from '../wk'
export default class Zanthus_Ctrl {
        public static get  ( filter: ifilter_faturamento, BaseDeDados : string = ``): string 
        {
          let select: string = `` 
          
          if(BaseDeDados == "ZANTHUSSQLSERVER") 
          {
              select  =  `select	    fat_zanthus_sat_ecf_m00ac	= a.m00ac
                        ,		fat_zanthus_data_m00af		    = a.m00af 
                        ,		fz_cupom_qtde				          = count(a.m00ad)			 
                        ,		fz_cupom_inicial			        = min(isnull(a.m00ad,0))
                        ,		fz_cupom_final				        = max(isnull(a.m00ad,0))
                        ,		fz_valor					            = sum(isnull(a.m45ak,0))
                        ,   fz_pag_cupom_qtde             = 0 
                        ,   fz_pag_cupom_inicial          = 0 
                        ,   fz_pag_cupom_final            = 0 
                        ,   fz_pag_valor                  = 0
                    from		ZEUSRETAIL.DBO.ZAN_M45 a
                    where		1 = 1 
                      and       a.m00af >= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_ini)}'
                      and       a.m00af <= '${myTools.format_Date_toStr_ShortDataBase(filter.filter?.datafaturamento_fim)}'
                    group by	a.m00ac, a.m00af `
          }
          if(BaseDeDados == "ZANTHUSPOSTGRE") 
            {
                select  =  `select	  a.m00ac                           as fat_zanthus_sat_ecf_m00ac	
                                  ,		a.m00af                           as fat_zanthus_data_m00af		
                                  ,		count(coalesce(a.m00ad,0))        as fz_cupom_qtde				     
                                  ,		min(coalesce(a.m00ad,0))          as fz_cupom_inicial	
                                  ,		max(coalesce(a.m00ad,0))          as fz_cupom_final		
                                  ,   sum(case  																			
                                          when A.M00Ad <> A.M45BO then 0                          		
                                          else case when coalesce(x.M45BO,0) <> 0 then 0 
                                                            else  case n.tiponota 
                                                                    when 99 then 0
                                                                    when 90 then 0
                                                                    else A.M45AK
                                                                  end
                                                end 
                                      end)  as fz_valor 	                                  
                                  ,   cast(0 as int)                    as fz_pag_cupom_qtde        
                                  ,   cast(0 as int)                    as fz_pag_cupom_inicial     
                                  ,   cast(0 as int)                    as fz_pag_cupom_final       
                                  ,   cast(0 as numeric(13,2))          as fz_pag_valor      
                                  ,   cast(0 as int)                    as fat_cupom_qtde 
                                  ,   cast(0 as int)                    as fat_cupom_inicial
                                  ,   cast(0 as int)                    as fat_cupom_final
                                  ,   cast(0 as numeric(13,2))          as fat_valor                                                                                                               
                      from		ZAN_M45 a
                      left join   ZAN_M45       x on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad
                      left JOIN	tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF                       
                      where		1 = 1 
                        and       a.m00af >= '${myTools._datemomentDateToStr(filter.filter?.datafaturamento_ini, "YYYY-MM-DD")}'
                        and       a.m00af <= '${myTools._datemomentDateToStr(filter.filter?.datafaturamento_fim, "YYYY-MM-DD")}'
                      group by	a.m00ac, a.m00af `
            }          
              
                  return select;

        }
}