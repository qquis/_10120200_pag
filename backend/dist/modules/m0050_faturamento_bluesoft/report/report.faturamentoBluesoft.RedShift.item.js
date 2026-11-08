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
class reportFaturamentoBluesoftRedshiftItemList {
    static sql(parametro) {
        let sql = ``;
        switch (parametro.tipo_Relatorio) {
            case 'FATURAMENTOBLUESOFT_ITEM':
                sql = this.script_faturamentobluesoftItem(parametro);
                break;
        }
        return sql;
    }
    static script_faturamentobluesoftItem(parametro) {
        let dataProcessamentoIni = parametro.dataProcessamentoIni ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoIni, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let dataProcessamentoFim = parametro.dataProcessamentoFim ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoFim, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let sql = `

                           
                              SELECT       
                        
                                         cast(0 as int)                              as   fat_blue_origem_seq   
                                     ,   cast(0 as int)                              as   fat_blue_item_seq   
                                          ,   cast(1 as int)                              as   op_cdoperacao   
                                     ,   fv.pedido_forca_venda_cliente_key           as   numeropedido  
                                     ,   fv.numero_pedido_forca_venda                as   numeropedido_fv  
                                     ,   coalesce(fv.nf_key,0)                       as   df_nf_seq_blue        
                                     ,   fv.cliente_key                              as   cdpessoabluesoft_cliente   
                       
                              
                                     ,   fv.PRODUTO_KEY                              as   prb_cdprodutobluesoft  
                                     ,   pr.produto_unitario_key                     as   prb_cdprodutobluesoft_unitario  
                                     ,   case coalesce(pr.embalagem_key,'UN')  
                                              WHEN 'UNIDADE' then 'UN'  
                                              WHEN 'CAIXA'   then 'CX'  
                                              WHEN 'BANDEJA' then 'BD'  
                                              WHEN 'KILO'    then 'KG'  
                                              else 'UN'      end                     as   prb_embalagem  
                                     ,   coalesce(pr.fator_estoque,1)                as   prb_fatorestoque  
                                     ,   coalesce(fv.embalagem,'-')                  as   embalagem_descricao  


                                     ,   cast( fv.volume * coalesce(pr.fator_estoque,0) as numeric(17,4) )   
                                                                                     as   qtde_unitaria_solicitada   
                                     ,   cast( fv.volume_faturado * coalesce(pr.fator_estoque,0) as numeric(17,4) )    
                                                                                     as   qtde_unitaria_faturada   
                                     ,   fv.volume                                   as   qtde_solicitada  
                                     ,   fv.volume_faturado                          as   qtde_faturada  

                           
                                     ,   coalesce(ct.CUSTO_UNITARIO_COM_ICM ,0)      as   valor_custo_com_icm_unit  
                                     ,   coalesce(ct.custo_unitario_com_icm, 0) * fv.volume * coalesce(pr.fator_estoque,0)   
                                                                                     as   valor_custo_com_icm   
                                     ,   coalesce(fv.custo_medio,0)                  as   valor_custo  
                              
                              

                                     ,   coalesce(fv.preco_tabela,0)                 as   valor_preco_tabela  
                                     ,   coalesce(fv.preco_aplicado,0)               as   valor_preco  
                                     ,   coalesce(fv.preco_final,0)                  as   valor_preco_aplicado  


                                     ,   coalesce(fv.valor_unitario_verba_vend,0)    as   valor_verba  
                                     ,   coalesce(fv.valor_unitario_verba_ger,0)     as   valor_verba_gerencia  
                                     ,   coalesce(fv.valor_unitario_verba_sup,0)     as   valor_verba_supervisao   
                                     ,   CAST( (fv.preco_final - fv.preco_aplicado)  * fv.volume_faturado AS NUMERIC(13,2))  
                                                                                     AS valor_verba_calculada   

                                     ,   coalesce(fv.desconto_financeiro,0)          as   percentual_desconto_financeiro   


                                     ,   coalesce(pf.ni_valor_bruto,0)               as   valor_nf_item_bruto  
                                     ,   cast(coalesce(pf.ni_valor_bruto_TOTAL,0) - coalesce(pf.NI_DESCONTO_TOTAL,0) as NUMERIC(17,4))   
                                                                                     as valor_nf_item  
                                     ,   CASE WHEN pf.codigo_operacao_fiscal = '5910' THEN 1 else 0 end  
                                                                                     as item_nf_bonificado   
                             
                               FROM        FATO_PEDIDO_FORCA_VENDA fv  
                               INNER JOIN  PRODUTO_D           pr on pr.produto_key = fv.produto_key   
                               LEFT  JOIN  nota_fiscal         nf on nf.nf_key = fv.nf_key and nf.loja_key = fv.loja_key   
                               LEFT  JOIN  fato_nota_fiscal    pf on pf.nf_key = nf.nf_key and pf.produto_origem_key = fv.produto_key and pf.loja_key = nf.loja_key  
                               LEFT  JOIN  ESTOQUE_DIARIO      ct on ct.produto_key = pr.produto_unitario_key and ct.data = fv.data_emissao  
                               WHERE       1 = 1   
                               AND       FV.pedido_forca_venda_cliente_key  in (                                                       
                                                                                   select pedido_forca_venda_cliente_key               
                                                                                   from   fato_pedido_forca_venda                      
                                                                                   where  data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, 'YYYY-MM-DD')}'                        
                                                                                     and  data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, 'YYYY-MM-DD')}'                        
                                                                                   group  by pedido_forca_venda_cliente_key            
                                                                                   union                                               
                                                                                   select  pedido_forca_venda_cliente_key              
                                                                                   from    log_pedido_forca_venda                      
                                                                                   where 1 = 1
                                                                                     and data_ocorrencia >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, 'YYYY-MM-DD')}'                      
                                                                                     and data_ocorrencia <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, 'YYYY-MM-DD')}'   
                                                                                   group by pedido_forca_venda_cliente_key             
                                                                                   )                                                   
                                                                                                                                        
                               UNION   
                                    SELECT                                                                                                 
                                                                             
                                                    cast(0 as int)                              as   fat_blue_origem_seq                
                                                ,   cast(0 as int)                              as   fat_blue_item_seq                 
                                                     ,   cast(CASE p.loja_key                                                                 
                                                                   WHEN  1                                                            
                                                                     THEN                                                                      
                                                                        CASE p.tipo_pedido_venda                                              
                                                                             WHEN 'Ecommerce' then 4                                           
                                                                          END                                                                  
                                                                   WHEN 991                                                   
                                                                     THEN                                                                      
                                                                        CASE p.tipo_pedido_venda                                              
                                                                             WHEN 'Venda' then 6                                               
                                                                            END                                                                
                                                                   ELSE 99                                                                     
                                                                   END                                                                         
                                                              as int)                                as   op_cdoperacao                          
                                                ,   p.pedido_venda_key                          as   numeropedido                       
                                                ,   cast(CASE p.loja_key                                                                
                                                               WHEN  1                                                       
                                                                 THEN                                                                   
                                                                    CASE p.tipo_pedido_venda                                            
                                                                         WHEN 'Ecommerce' then 10000004                                 
                                                                      END                                                               
                                                               WHEN 991                                                 
                                                                 THEN                                                                   
                                                                    CASE p.tipo_pedido_venda                                            
                                                                         WHEN 'Venda'     then 10000003                                 
                                                                        END                                                             
                                                               ELSE 99                                                                  
                                                               END                                                                      
                                                          as int)                                   as numeropedido_fv                 
                                                 ,   coalesce(nf.nf_key,0)                             as df_nf_seq_blue                  
                                                 ,   p.cliente_key                              as   cdpessoabluesoft_cliente   
                                                                   
                                                 ,   i.produto_key                               as   prb_cdprodutobluesoft             
                                                 ,   pr.produto_unitario_key                     as   prb_cdprodutobluesoft_unitario    
                                                 ,   case coalesce(pr.embalagem_key,'UN')                                               
                                                          WHEN 'UNIDADE' then 'UN'                                                      
                                                          WHEN 'CAIXA'   then 'CX'                                                      
                                                          WHEN 'BANDEJA' then 'BD'                                                      
                                                          WHEN 'KILO'    then 'KG'                                                      
                                                          else 'UN'      end                     as   prb_embalagem                     
                                                 ,   coalesce(pr.fator_estoque,1)                as   prb_fatorestoque                  
                                              ,   coalesce(pr.embalagem_key,'')                  as   embalagem_descricao               
                                                                                                                                        
                                                                                                                                        
                                                                              
                                                 ,   cast( coalesce(i.quantidade_pedida,0) * coalesce(pr.fator_estoque,0) as numeric(17,4) )        
                                                                                                 as   qtde_unitaria_solicitada          
                                                 ,   cast( coalesce(i.quantidade_faturada,0) * coalesce(pr.fator_estoque,0) as numeric(17,4) )      
                                                                                                 as   qtde_unitaria_faturada            
                                                 ,   i.quantidade_pedida                                   as   qtde_solicitada         
                                                 ,   i.quantidade_faturada                          as   qtde_faturada                  
                                                                                                                                        
                                                                                
                                                  ,   cast(coalesce(ct.CUSTO_UNITARIO_COM_ICM ,0) as numeric(13,2))                     
                                                                                                      as   valor_custo_com_icm_unit     
                                                  ,   coalesce(ct.custo_unitario_com_icm, 0) * coalesce(i.quantidade_faturada,0) * coalesce(pr.fator_estoque,0)   
                                                                                                  as   valor_custo_com_icm   
                                                  ,   coalesce(ct.custo_unitario_com_icm, 0) * coalesce(i.quantidade_faturada,0) * coalesce(pr.fator_estoque,0)   
                                                                                                  as   valor_custo                       
                                                                                   
                                                  ,   coalesce(i.preco_venda,0)                         as   valor_preco_tabela          
                                                  ,   coalesce(i.preco_venda,0)                         as   valor_preco                 
                                                  ,   coalesce(i.preco_venda,0)                  as   valor_preco_aplicado               
                                                                                                                                         
                                                                                 
                                                  ,   coalesce(i.preco_venda,0)    as   valor_verba                                      
                                                  ,   cast(0 as numeric(13,2))     as   valor_verba_gerencia                             
                                                  ,   cast(0 as numeric(13,2))     as   valor_verba_supervisao                           
                                                  ,   cast(0 AS NUMERIC(13,2))     AS valor_verba_calculada                              
                                                                     
                                                   ,   cast(0 as numeric(13,2))          as   valor_desconto_financeiro                  
                                                                                                                                         
                                                                       
                                                   ,   coalesce(pf.ni_valor_bruto,0)               as   valor_nf_item_bruto              
                                                   ,   cast(coalesce(pf.ni_valor_bruto_TOTAL,0) - coalesce(pf.NI_DESCONTO_TOTAL,0) as NUMERIC(17,4))             
                                                                                                   as valor_nf_item                      
                                                   ,   CASE WHEN pf.codigo_operacao_fiscal = '5910' THEN 1 else 0 end                    
                                                                                                   as item_nf_bonificado                 
                                                                                                                                         
                                                                                                                                         
                                                                                                                                         
                                 from         pedido_venda     i                                                                         
                                 inner join   pedido           p  on p.pedido_venda_key = i.pedido_venda_key and i.cliente_key = p.cliente_key    
                                 inner join   produto_d        pr on pr.produto_key = i.produto_key                                      
                                 LEFT  JOIN   ESTOQUE_DIARIO    ct on ct.produto_key = pr.produto_unitario_key                           
                                                                                  and ct.data = p.data_emissao                           
                                 LEFT JOIN   (                                                                                           
                                               select   nx.loja_key,                                                                        
                                                        nx.pedido_venda_key,                                                                
                                                        nx.nf_key,                                                                          
                                                        nx.nf_numero,                                                                       
                                                        nx.nf_serie,                                                                         
                                                        nxf.fornecedor_key as cliente_key                                                   
                                               from        nota_fiscal_pedido_venda nx                                                     
                                               inner join  nota_fiscal nxf          on nxf.nf_key = nx.nf_key    
                                               group by  nx.loja_key,                                                                      
                                                        nx.pedido_venda_key,                                                               
                                                        nx.nf_key,                                                                         
                                                        nx.nf_numero,                                                                      
                                                        nx.nf_serie,                                                                        
                                                        nxf.fornecedor_key                                                                         
                                      ) nf on nf.pedido_venda_key = p.pedido_venda_key and nf.loja_key = p.loja_key and nf.cliente_key = p.cliente_key    
                                 LEFT JOIN   fato_nota_fiscal    pf on pf.nf_key = nf.nf_key and pf.produto_origem_key = i.produto_key   
                                                                                                      and pf.loja_key = nf.loja_key     
                                                                                                      and pf.fornecedor_key = nf.cliente_key      
                                 WHERE         1 = 1   
                                   AND       coalesce(p.cliente_key,0) > 0   
                                   AND       p.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, 'YYYY-MM-DD')}'   
                                   AND       p.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, 'YYYY-MM-DD')}'   
                                   AND       (        p.loja_key = 991   
                                               or   ( p.loja_key = 1 and p.tipo_pedido_venda = 'Ecommerce' )   
                                          ) 

            `;
        return sql;
    }
    static get(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let myBase = new modelbase_1.clsBase();
                result = yield myBase.myDataBase.redshift.DataGet(this.sql(filter));
            }
            catch (e) {
                modelbase_1.clsTools.pagConsole(`reportFaturamentoBluesoft | get \n Error: ${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoBluesoftRedshiftItemList;
