"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class Zanthus_Cupom {
    static getBaseZanthusSQLServer(filter, SatEcf, CupomProcessamentoInicial) {
        var _a, _b, _c, _d, _e, _f, _g, _h;
        return `SELECT 
                fat_zanthus_data_m00af				= A.M00AF  
            ,   fat_zanthus_sat_ecf_m00ac			= A.M00Ac  
            ,   fat_zanthus_cupomfiscal_m00ad			= A.M00Ad  
            ,   fat_zanthus_cupomfiscalid_M00_id_unico		= A.M00_id_unico
            ,   fat_zanthus_cupomfiscal_cancelado_m45bo		= A.M45BO
            ,   fat_zanthus_notafiscal_numnota			= A.M45XD
            ,   fat_zanthus_notafiscal_serie_nf			= isnull(N.serie_nf,0)                                              
            ,   fat_zanthus_notafiscal_chave_m45xb			= a.M45XB                                                           
            ,   fat_zanthus_status_cancelado			=case  
                                                                    when A.M00Ad <> A.M45BO then 9                                  
                                                                    else case when isnull(x.M45BO,0) <> 0 then 1 else 0 end         
                                                                    end   
            ,	fat_zanthus_cupomfiscal_valor_m45ak		= A.M45AK 
            ,	fat_zanthus_cpf_cnpj_m45bv			= A.m45bv 
            ,	fat_zanthus_hora_ini_m45ai			= substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45ai	))) + CONVERT(VARCHAR(4),  A.m45ai)))),1,2) + ':' +  substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45ai	))) + CONVERT(VARCHAR(4),  A.m45ai)))),3,2) + ':00' 
            ,	fat_zanthus_hora_fim_m45au			= substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45au	))) + CONVERT(VARCHAR(4),  A.m45au)))),1,2) + ':' +  substring(rtrim(ltrim(CONVERT(VARCHAR(4), replicate('0', 4- len(CONVERT(VARCHAR(4), A.m45au	))) + CONVERT(VARCHAR(4),  A.m45au)))),3,2) + ':00' 
            ,	fat_zanthus_cod_funcionario_m45ah		= A.M45AH 
            ,	fat_zanthus_voucher_cod_m50ar			= isnull(voucher.M50AR, '')   
            ,	fat_zanthus_voucher_valor_m50at			= isnull(voucher.m50at,0 ) 
            ,	fat_zanthus_voucher_count_m50ag			= isnull(voucher.m50ag,0) 
            ,   fat_zanthus_conferencia                         = 0
            ,   fat_zanthus_processado                          = 0
            ,   fat_zanthus_pag                                 = 0 
            from	        ZEUSRETAIL.DBO.ZAN_M45									A                                                                                               
            left join       ZEUSRETAIL.DBO.ZAN_M45		x on x.m00af = a.M00AF and x.m00ac = a.m00ac and x.M45BO = a.m00ad and  x.M45BO <> x.m00ad                        
            left JOIN	ZEUSRETAIL.dbo.tab_nota_header	n ON	A.M45XD = N.NUMNOTA AND A.M00AC = N.NUMPDV AND A.M45XE = N.SERIE_NF                                         
            left join   (                                               
                    select		m00af                       
                            ,	m00ac                       
                            ,	m00ad                       
                            ,	m50ar = min(m50ar)          
                            ,	m50ag = count(m50ag)        
                            ,	m50at = sum(m50at)          
                    from		ZeusRetail.dbo.Zan_M50 q    
                    where		 1= 1                       
                    AND       Q.M00AF >= '${Tools_1.default.format_Date_toStr_ShortDataBase((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini)}'
                    AND       Q.M00AF <= '${Tools_1.default.format_Date_toStr_ShortDataBase((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim)}'
                    AND       Q.M00AC =  ${SatEcf}
                    AND       Q.M00AD =  CASE WHEN ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.cupom_fiscal} = 0 THEN Q.M00AD ELSE ${(_d = filter.filter) === null || _d === void 0 ? void 0 : _d.cupom_fiscal} END 
                    AND       Q.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN Q.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END 
                    group by m00af, m00ac, m00ad  
            ) voucher on voucher.M00AF = a.m00af and voucher.m00ac = a.m00ac  and voucher.M00AD = a.M00AD   
            WHERE	  1 = 1
            AND       A.M00AF >= '${Tools_1.default.format_Date_toStr_ShortDataBase((_e = filter.filter) === null || _e === void 0 ? void 0 : _e.datafaturamento_ini)}'
            AND       A.M00AF <= '${Tools_1.default.format_Date_toStr_ShortDataBase((_f = filter.filter) === null || _f === void 0 ? void 0 : _f.datafaturamento_fim)}'
            AND       A.M00AC =  ${SatEcf}
            AND       A.M00AD =  CASE WHEN  ${(_g = filter.filter) === null || _g === void 0 ? void 0 : _g.cupom_fiscal} = 0 THEN A.M00AD ELSE ${(_h = filter.filter) === null || _h === void 0 ? void 0 : _h.cupom_fiscal} END 
            AND       A.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN A.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END 
            group by        A.M00AF                
                    ,	A.M00Ac                
                    ,	A.M00Ad                
                    ,	A.M00_id_unico         
                    ,	A.M45BO                
                    ,	A.M45XD                
                    ,	isnull(N.serie_nf,0)   
                    ,	a.M45XB                
                    ,	case when A.M00Ad <> A.M45BO then 9 else case when isnull(x.M45BO,0) <> 0 then 1 else 0 end end     
                                    ,	A.M45AK 
                                    ,	A.m45bv 
                                    ,	A.m45ai 
                                    ,	A.m45au 
                                    ,	A.M45AH 
                                    ,	isnull(voucher.M50AR,'') 
                                    ,	isnull(voucher.m50at,0) 
                                    ,	isnull(voucher.m50ag,0) `;
    }
    static getBaseZanthusPostGre(filter, SatEcf, CupomProcessamentoInicial) {
        /*
                QUERY SELECT ZANTHUS CUPONS PARA INTEGRAÇÃO
        */
        var _a, _b, _c, _d, _e, _f, _g, _h;
        let sql = `
            SELECT 
                       A.M00AF  		                as fat_zanthus_data_m00af						
                   ,   A.M00Ac  		                as fat_zanthus_sat_ecf_m00ac					
                   ,   A.M00Ad  		                as fat_zanthus_cupomfiscal_m00ad				
                   ,   A.M00_id_unico	                as fat_zanthus_cupomfiscalid_M00_id_unico		
                   ,   A.M45BO		                as fat_zanthus_cupomfiscal_cancelado_m45bo		
                   ,   A.M45XD		                as fat_zanthus_notafiscal_numnota				
                   ,   coalesce(N.serie_nf,'0')            as fat_zanthus_notafiscal_serie_nf				                                 
                   ,   a.M45XB                             as fat_zanthus_notafiscal_chave_m45xb			                                 
                   ,   case  																			
                           when A.M00Ad <> A.M45BO then 9                          		
                           else case when coalesce(x.M45BO,0) <> 0 then 1 else 0 end 		
                       end   			        as fat_zanthus_status_cancelado
                   ,   A.M45AK                             as fat_zanthus_cupomfiscal_valor_m45ak			
                   ,   A.m45bv                             as fat_zanthus_cpf_cnpj_m45bv
                   ,   (to_timestamp(substring(lpad(cast(A.m45ai as varchar(4)), 4, '0') from 1 for 2) || ':' || substring(lpad(cast(A.m45ai as varchar(4)), 4, '0') from 3 for 2), 'HH24:MI') :: time)		
                                                           AS fat_zanthus_hora_ini_m45ai
                   ,   (to_timestamp(substring(lpad(cast(A.m45au as varchar(4)), 4, '0') from 1 for 2) || ':' || substring(lpad(cast(A.m45au as varchar(4)), 4, '0') from 3 for 2), 'HH24:MI') :: time)		
                                                           AS fat_zanthus_hora_fim_m45au		
                   ,   A.M45AH                             as fat_zanthus_cod_funcionario_m45ah			
                   ,   coalesce(voucher.M50AR, '')         as fat_zanthus_voucher_cod_m50ar				
                   ,   coalesce(voucher.m50at,0 ) 	        as fat_zanthus_voucher_valor_m50at				
                   ,   coalesce(voucher.m50ag,0) 	        as fat_zanthus_voucher_count_m50ag				
                   ,   0					as fat_zanthus_conferencia                     
                   ,   0					as fat_zanthus_processado                      
                   ,   0 					as fat_zanthus_pag    
                   ,   n.tiponota                               as tiponota
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
                                AND       Q.M00AF >= '${Tools_1.default._datemomentDateToStr((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini, "YYYY-MM-DD")}'
                                AND       Q.M00AF <= '${Tools_1.default._datemomentDateToStr((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim, "YYYY-MM-DD")}'
                                AND       Q.M00AD =  CASE WHEN ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.cupom_fiscal} = 0 THEN Q.M00AD ELSE ${(_d = filter.filter) === null || _d === void 0 ? void 0 : _d.cupom_fiscal} END 
                                AND       Q.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN Q.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END 
                                ${SatEcf && SatEcf !== 0 ? ` AND Q.M00AC = ${SatEcf}` : ``}
                                group by m00af, m00ac, m00ad  
                         ) voucher on voucher.M00AF = a.m00af and voucher.m00ac = a.m00ac  and voucher.M00AD = a.M00AD   
            WHERE	  1 = 1
            AND       A.M00AF >= '${Tools_1.default._datemomentDateToStr((_e = filter.filter) === null || _e === void 0 ? void 0 : _e.datafaturamento_ini, "YYYY-MM-DD")}'
            AND       A.M00AF <= '${Tools_1.default._datemomentDateToStr((_f = filter.filter) === null || _f === void 0 ? void 0 : _f.datafaturamento_fim, "YYYY-MM-DD")}'
            AND       A.M00AD =  CASE WHEN  ${(_g = filter.filter) === null || _g === void 0 ? void 0 : _g.cupom_fiscal} = 0 THEN A.M00AD ELSE ${(_h = filter.filter) === null || _h === void 0 ? void 0 : _h.cupom_fiscal} END 
            AND       A.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN A.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END 
            ${SatEcf && SatEcf !== 0 ? ` AND A.M00AC = ${SatEcf}` : ``}
            group by  A.M00AF                
                    ,	A.M00Ac                
                    ,	A.M00Ad                
                    ,	A.M00_id_unico         
                    ,	A.M45BO                
                    ,	A.M45XD                
                    ,	coalesce(N.serie_nf,'0')   
                    ,	a.M45XB                
                    ,	case when A.M00Ad <> A.M45BO then 9 else case when coalesce(x.M45BO,0) <> 0 then 1 else 0 end end     
                                    ,	A.M45AK 
                                    ,	A.m45bv 
                                    ,	A.m45ai 
                                    ,	A.m45au 
                                    ,	A.M45AH 
                                    ,	coalesce(voucher.M50AR,'') 
                                    ,	coalesce(voucher.m50at,0) 
                                    ,	coalesce(voucher.m50ag,0) 
                                    ,   n.tiponota  
                `;
        return sql;
    }
}
exports.default = Zanthus_Cupom;
