"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class Zanthus_CupomItem {
    static getBaseZanthusSQLServer(filter, SatEcf, CupomProcessamentoInicial) {
        var _a, _b, _c, _d;
        let SELECT = `
                select	  	fat_zanthus_data_m00af					=			a.m00af 									     
                         ,	fat_zanthus_sat_ecf_m00ac				=			a.M00AC                                        
                         ,	fat_zanthus_cupomfiscal_m00ad			        =			a.M00AD                                          
                         ,	fat_zanthus_item_seq_m43eg				=			i.M43EG                                          
                         ,	fat_zanthus_item_cdbarra_m43ah			        =			replicate('0', 14 - len(convert(varchar(14), m43ah))) + convert(varchar(14), m43ah) 
                         ,	fat_zanthus_item_cdbarra_m43bk_m43ah	                =			replicate('0', 14 - len(convert(varchar(14) ,  case when isnull(M43BK,'0') != '0' then isnull(M43BK,'0') else  i.m43ah end  ))) + convert(varchar(14) ,  case when isnull(M43BK,'0') != '0' then isnull(M43BK,'0') else  i.m43ah end  ) 
                         ,	fat_zanthus_item_qtde_m43ao				=			isnull(M43AO,0)                                 
                         ,	fat_zanthus_item_valor_m43ap			        =			ISNULL(i.M43AP,0)                              
                         ,	fat_zanthus_item_valor_desconto_m43aq	                =			ISNULL(i.M43Aq,0)                              
                         ,	fat_zanthus_m43bk					=			isnull(M43BK,'0')                              
                         ,	fat_zanthus_decomp_insumo				=			isnull(DECOMP.percentual_insumo,0)             
                         ,	fat_zanthus_val_liquido					=			ISNULL(i.val_liquido,0)                        
                         ,	fat_zanthus_qtde					=			convert(numeric(17,4), case when isnull(M43BK,'0') != '0' then (DECOMP.percentual_insumo / 100) * M43AO else  i.m43ao end ) 
                     from		zeusretail.dbo.zan_m43								i with (nolock)  
                     inner join  ZEUSretail.dbo.zan_m45								a on a.m00af = i.m00af and a.m00ac = i.m00ac and a.m00ad = i.m00ad  
                     LEFT JOIN	ZeusRetail.DBO.tab_produto_decomposicao_insum DECOMP ON CONVERT(NUMERIC(14,0) , DECOMP.cod_insumo) = CONVERT(NUMERIC(14,0), I.M43AH)  
                                                 and CONVERT(NUMERIC(14,0) , DECOMP.cod_mercadoria) = CONVERT(NUMERIC(14,0), I.M43BK) 
                     WHERE	1 = 1 
                     AND     A.M00AF >= '${Tools_1.default.format_Date_toStr_ShortDataBase((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini)}' 
                     AND     A.M00AF <= '${Tools_1.default.format_Date_toStr_ShortDataBase((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim)}' 
                     AND     A.M00AC = ${SatEcf}
                     AND     A.M00AD =  CASE WHEN ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.cupom_fiscal} = 0 THEN A.M00AD ELSE ${(_d = filter.filter) === null || _d === void 0 ? void 0 : _d.cupom_fiscal} END 
                     AND     A.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN A.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END                      
                     order by a.m00ad, 	i.M43EG 
                  
                  `;
        return SELECT;
    }
    static getBaseZanthusPostGre(filter, SatEcf, CupomProcessamentoInicial) {
        var _a, _b, _c, _d;
        let SELECT = `
                     select	  	a.m00af 	as fat_zanthus_data_m00af																     
                         	,	a.M00AC     as fat_zanthus_sat_ecf_m00ac							                                   
                         	,	a.M00AD     as fat_zanthus_cupomfiscal_m00ad			    		                                     
                         	,	i.M43EG     as fat_zanthus_item_seq_m43eg							                                     
                         	,	lpad(coalesce(m43ah,'0'), 14, '0') as fat_zanthus_item_cdbarra_m43ah
                         	,	lpad(coalesce(CASE WHEN COALESCE(M43BK,'0') = '0' THEN coalesce(m43ah,'0') ELSE COALESCE(M43BK,'0') END     ,'0'), 14, '0') as fat_zanthus_item_cdbarra_m43bk_m43ah	   
                         	,	coalesce(M43AO,0)          				as fat_zanthus_item_qtde_m43ao						                       
                         	,	coalesce(i.M43AP,0)        				as fat_zanthus_item_valor_m43ap			    			                      
                         	,	coalesce(i.M43Aq,0)        				as fat_zanthus_item_valor_desconto_m43aq	    			                      
                         	,	coalesce(M43BK,'0')        				as fat_zanthus_m43bk										                      
                         	,	coalesce(DECOMP.percentual_insumo,0)  	as fat_zanthus_decomp_insumo
                         	,	coalesce(i.val_liquido,0)				as fat_zanthus_val_liquido
							,	cast(case when coalesce(M43BK,'0') != '0' then (DECOMP.percentual_insumo / 100) * M43AO else  i.m43ao end as numeric(17,4))
																		as fat_zanthus_qtde
							
                         	--,	convert(numeric(17,4), case when isnull(M43BK,'0') != '0' then (DECOMP.percentual_insumo / 100) * M43AO else  i.m43ao end )  
							--										as fat_zanthus_qtde					
                     from		zan_m43								i 
                     inner join zan_m45								a on a.m00af = i.m00af and a.m00ac = i.m00ac and a.m00ad = i.m00ad  
                     LEFT JOIN	tab_produto_decomposicao_insum DECOMP ON cast(DECOMP.cod_insumo as NUMERIC(14,0)) = cast(I.M43AH as NUMERIC(14,0))  
                                                 and cast( DECOMP.cod_mercadoria as NUMERIC(14,0)) = cast(I.M43BK as NUMERIC(14,0)) 
                     WHERE	1 = 1 
                     AND     A.M00AF >= '${Tools_1.default._datemomentDateToStr((_a = filter.filter) === null || _a === void 0 ? void 0 : _a.datafaturamento_ini, "YYYY-MM-DD")}' 
                     AND     A.M00AF <= '${Tools_1.default._datemomentDateToStr((_b = filter.filter) === null || _b === void 0 ? void 0 : _b.datafaturamento_fim, "YYYY-MM-DD")}' 
                     AND     A.M00AC = ${SatEcf}
                     AND     A.M00AD =  CASE WHEN ${(_c = filter.filter) === null || _c === void 0 ? void 0 : _c.cupom_fiscal} = 0 THEN A.M00AD ELSE ${(_d = filter.filter) === null || _d === void 0 ? void 0 : _d.cupom_fiscal} END 
                     AND     A.M00AD >= CASE WHEN ${(CupomProcessamentoInicial ? CupomProcessamentoInicial : 0)} = 0 THEN A.M00AD ELSE ${CupomProcessamentoInicial ? CupomProcessamentoInicial : 0} END                      
                     order by a.m00ad, 	i.M43EG 
                  
                  `;
        return SELECT;
    }
}
exports.default = Zanthus_CupomItem;
