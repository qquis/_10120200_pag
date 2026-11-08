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
class reportFaturamentoBluesoftRedshiftList {
    static sql(parametro) {
        let sql = ``;
        switch (parametro.tipo_Relatorio) {
            case 'FATURAMENTO_BLUESOFT':
                sql = this.script_faturamentobluesoft(parametro);
                break;
            case 'FATURAMENTO_BLUESOFT_FV':
                sql = this.script_faturamentoBluesoft_fv(parametro);
                break;
        }
        return sql;
    }
    static script_faturamentobluesoft(parametro) {
        let dataProcessamentoIni = parametro.dataProcessamentoIni ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoIni, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let dataProcessamentoFim = parametro.dataProcessamentoFim ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoFim, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let sql = `

                    SELECT            cast(0 as int) as fat_blue_seq
                                  ,   cast(0 as int) as fat_blue_origem_seq 
                                  ,   cast(1 as int)                              as   op_cdoperacao                
                                  ,   cast(coalesce(max(fv.nf_key),0) as int)                       as   df_nf_seq_blue               
                                  ,   cast(coalesce(max(o.nf_key),0) as int)                        as   df_nf_seq_blue_dev           
                                  ,   fv.pedido_forca_venda_cliente_key           as   numeropedido                 
                                  ,   fv.numero_pedido_forca_venda                as   numeropedido_fv              
                                  ,   CASE fv.status_pedido                                                         
                                         WHEN 'Em Digitação'                 THEN 10                                
                                         WHEN 'Aguardando Análise Gerencial' THEN 20                                
                                         WHEN 'Em Análise Gerencial'         THEN 25                                
                                         WHEN 'Em Análise de Crédito'        THEN 27                                
                                         WHEN 'Fechado'                      THEN 30                                
                                         WHEN 'Em Separação'                 THEN 40                                
                                         WHEN 'Separado'                     THEN 45                                
                                         WHEN 'Faturando'                    THEN 50                                
                                         WHEN 'Faturado por Nota Fiscal'     THEN 55                                
                                         WHEN 'Entregue'                     THEN 70                                
                                         WHEN 'Cancelado'                    THEN 90                                
                                         ELSE 99                                                                    
                                              END as fat_blue_status_cd                                             
                               ,   CASE fv.tipo_pedido_venda                                                        
                                         WHEN 'Venda'                 THEN 10                                       
                                         WHEN 'Doação ou Bonificação' THEN 20                                       
                                         WHEN 'Remessa de Troca'      THEN 30                                       
                                         ELSE 99                                                                    
                                              END as fat_blue_tipo_cd                                               
                                ,   coalesce(fv.cliente_key,0)                  as   cdpessoabluesoft_cliente       
                                ,   coalesce(fv.vendedor_key,0)                 as   cdpessoabluesoft_vendedor      
                                ,   coalesce(fv.tabela_preco_venda_key,0)       as   tabelapreco_cd                 
                                ,   coalesce(fv.tabela_preco_venda_versao,0)    as   tabelapreco_versao_cd          
                                ,   cast(0 as int)                              as   fv_prazopgto_cd                
                                ,   coalesce(fv.prazo_pagamento,'')             as   fv_prazopgto_descricao         
                                ,   coalesce(fv.tipo_de_entrega,'')             as   tipo_entrega_descricao         
                                ,   coalesce(fv.origem_pedido,'')               as   origem_pedido                  
                                ,   coalesce(fv.data_solicitacao, '1900-01-01') as   data_solicitacao               
                                ,   coalesce(fv.data_emissao,'1900-01-01')      as   data_emissao                   
                                ,   max(coalesce(fv.data_faturamento,'1900-01-01'))  as   data_faturamento          
                                ,   coalesce(XXX.numero_itens,0)                             as   numero_itens                   
                                ,   coalesce(XXX.valor_pedido,0)                   as   valor_pedido                 
                                ,   sum(coalesce(preco_final,0) * coalesce(volume_faturado,0))          as   valor_faturamento   
                                ,   cast(coalesce(desconto_financeiro,0) as numeric(17,4))      as descontofinanceiro   
                        FROM      FATO_PEDIDO_FORCA_VENDA fv
                        INNER JOIN (
                        
                                    SELECT  AAA.pedido_forca_venda_cliente_key   as   numeropedido                 
                                        ,   AAA.numero_pedido_forca_venda       as    numeropedido_fv 
                                        ,   MAX(coalesce(AAA.nf_key,0))         as    df_nf_seq_blue 
                                        ,   count(distinct(produto_key))                as   numero_itens  
                                        ,   sum(coalesce(AAA.preco_final,0) * coalesce(AAA.volume,0))                   as   valor_pedido                 
                                    FROM    FATO_PEDIDO_FORCA_VENDA AAA 
                                    where  aaa.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                     and   aaa.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'  
                                    GROUP BY AAA.pedido_forca_venda_cliente_key, AAA.numero_pedido_forca_venda
                            
                        ) XXX ON XXX.numeropedido = fv.pedido_forca_venda_cliente_key 
                             and XXX.numeropedido_fv = fv.numero_pedido_forca_venda
                             AND XXX.df_nf_seq_blue = coalesce(fv.nf_key,0)

                        
                        

                       LEFT JOIN  nota_fiscal_origem      o on o.origem_nf_key = fv.nf_key 
                        WHERE     1 = 1                                                                           
                        AND       fv.loja_key = 1
                        AND       FV.pedido_forca_venda_cliente_key  in (                                         
                                                                          select pedido_forca_venda_cliente_key   
                                                                          from   fato_pedido_forca_venda          
                                                                          where  data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                                                            and  data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'     
                                                                          group  by pedido_forca_venda_cliente_key
                                                                          union                                   
                                                                          select  pedido_forca_venda_cliente_key  
                                                                          from    log_pedido_forca_venda          
                                                                          where 1 = 1
                                                                            and data_ocorrencia >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, 'YYYY-MM-DD')}'                      
                                                                            and data_ocorrencia <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, 'YYYY-MM-DD')}'   
                                                                          group by pedido_forca_venda_cliente_key 
                                                                          )                                       
                       GROUP by   fv.loja_key                                         
                             ,   fv.pedido_forca_venda_cliente_key                   
                             ,   fv.numero_pedido_forca_venda                        
                             ,   fv.status_pedido                                    
                             ,   fv.tipo_pedido_venda                                
                             ,   CASE fv.status_pedido                               
                                 WHEN 'Em Digitação'                 THEN 10         
                                 WHEN 'Aguardando Análise Gerencial' THEN 20         
                                 WHEN 'Em Análise Gerencial'         THEN 25         
                                 WHEN 'Em Análise de Crédito'        THEN 27         
                                 WHEN 'Fechado'                      THEN 30         
                                 WHEN 'Em Separação'                 THEN 40         
                                 WHEN 'Separado'                     THEN 45         
                                 WHEN 'Faturando'                    THEN 50         
                                 WHEN 'Faturado por Nota Fiscal'     THEN 55         
                                 WHEN 'Entregue'                     THEN 70         
                                 WHEN 'Cancelado'                    THEN 90         
                                 END                                                 
                             ,   fv.cliente_key                                      
                             ,   fv.vendedor_key                                     
                             ,   fv.tabela_preco_venda_key                           
                             ,   fv.tabela_preco_venda_versao                        
                             ,   fv.prazo_pagamento                                                              
                             ,   fv.tipo_de_entrega                                  
                             ,   fv.origem_pedido                                    
                             ,   fv.data_solicitacao                                 
                             ,   fv.data_emissao         
                             ,   cast(coalesce(desconto_financeiro,0) as numeric(17,4))
                             ,  COALESCE(XXX.numero_itens,0)
                            ,  COALESCE(XXX.valor_pedido,0)
                        UNION  
                        SELECT                              cast(0 as int) as fat_blue_seq                                           
                                             ,   cast(0 as int) as fat_blue_origem_seq                                               
                                             ,   cast(CASE fv.loja_key                                                               
                                                           WHEN  1                                                          
                                                             THEN                                                                    
                                                                CASE fv.tipo_pedido_venda                                            
                                                                     WHEN 'Ecommerce' then 4                                         
                                                                  END                                                                
                                                           WHEN 991                                                 
                                                             THEN                                                                    
                                                                CASE fv.tipo_pedido_venda                                            
                                                                     WHEN 'Venda' then 6                                             
                                                                    END                                                              
                                                           ELSE 99                                                                   
                                                           END                                                                       
                                                      as int)                                as   op_cdoperacao                      
                                             ,   cast(coalesce(nf.nf_key,0) as int)          as   df_nf_seq_blue                     
                                             ,   cast(coalesce(o.nf_key,0) as int)           as   df_nf_seq_blue_dev                 
                                             ,   cast(fv.pedido_venda_key as int)                         as   numeropedido          
                                             ,   cast(CASE fv.loja_key                                                               
                                                           WHEN  1                                                      
                                                             THEN                                                                    
                                                                CASE fv.tipo_pedido_venda                                            
                                                                     WHEN 'Ecommerce' then 10000004                                  
                                                                  END                                                                
                                                           WHEN 991                                                
                                                             THEN                                                                    
                                                                CASE fv.tipo_pedido_venda                                            
                                                                     WHEN 'Venda'     then 10000006                                  
                                                                    END                                                              
                                                           ELSE 99                                                                   
                                                           END                                                                       
                                                      as int)                                   as   numeropedido_fv                 
                                             ,   CASE fv.status_pedido_venda                                                         
                                                    WHEN 'Em Digitação'                 THEN 10                                      
                                                    WHEN 'Aguardando Análise Gerencial' THEN 20                                      
                                                    WHEN 'Em Análise Gerencial'         THEN 25                                      
                                                    WHEN 'Em Análise de Crédito'        THEN 27                                      
                                                    WHEN 'Fechado'                      THEN 30                                      
                                                    WHEN 'Em Separação'                 THEN 40                                      
                                                    WHEN 'Separado'                     THEN 45                                      
                                                    WHEN 'Faturando'                    THEN 50                                      
                                                    WHEN 'Faturado por Nota Fiscal'     THEN 55                                      
                                                    WHEN 'Entregue'                     THEN 70                                      
                                                    WHEN 'Cancelado'                    THEN 90                                      
                                                    ELSE 99                                                                          
                                                         END as fat_blue_status_cd                                                   
                                                                                                                                     
                                          ,   CASE NF.tipo_pedido                                                                    
                                                   WHEN 'Venda'                 THEN 10                                              
                                                   WHEN 'Doação ou Bonificação' THEN 20                                              
                                                   WHEN 'Remessa de Troca'      THEN 30                                              
                                                   WHEN 'Ecommerce'             THEN 10                                              
                                                   ELSE 99                                                                           
                                              END as fat_blue_tipo_cd                                                                
                                                                                                                                     
                                           ,   coalesce(fv.cliente_key,0)                      as   cdpessoabluesoft_cliente         
                                           ,   coalesce(fv.vendedor_key,0)                     as   cdpessoabluesoft_vendedor        
                                           ,   CAST(0 AS INT)                                  as   tabelapreco_cd                   
                                           ,   CAST(0 AS INT)                                  as   tabelapreco_versao_cd            
                                           ,   cast(0 as int)                                  as   fv_prazopgto_cd                  
                                           ,   NULL                                            as   fv_prazopgto_descricao           
                                           ,   NULL                                            as   tipo_entrega_descricao           
                                           ,   coalesce(fv.tipo_pedido_venda,'')               as   origem_pedido                    
                                           ,   coalesce(fv.data_emissao, '1900-01-01')         as   data_solicitacao                 
                                           ,   coalesce(fv.data_emissao,'1900-01-01')          as   data_emissao                     
                                           ,   coalesce(nf.data_emissao,'1900-01-01')          as   data_faturamento                 
                                                                                                                                     
                                           ,   cast(coalesce(it.numero_itens,0) as int) as numero_itens                                                        
                                                                                                                                     
                                           ,   cast(coalesce(fv.total_sem_oferta,0) as numeric(13,2)) as valor_pedido                            
                                           ,   cast(coalesce(fv.total_com_oferta,0) as numeric(13,2)) as valor_faturamento     
                                           ,   cast(0 as numeric(17,4)) as descontofinanceiro
                                   FROM      pedido fv                                                                               
                                   left join ( select     xn.loja_key 
                                                       ,  xn.nf_key                                                                  
                                                       ,  xn.nf_numero                                                               
                                                       ,  xn.pedido_venda_key                                                        
                                                       ,  xn.tipo_pedido                                                             
                                                       ,  n.data_emissao                                                            
                                                       ,  n.fornecedor_key as cdpessoabluesoft_cliente 
                                               from       nota_fiscal_pedido_venda xn                                                
                                               inner join nota_fiscal n on n.nf_key = xn.nf_key  and n.loja_key = xn.loja_key        
                                               group by  xn.loja_key                                                                
                                                         ,  xn.nf_key                                                                
                                                         , xn.nf_numero                                                              
                                                         , xn.pedido_venda_key                                                       
                                                         , xn.tipo_pedido                                                            
                                                         , n.data_emissao                                                           
                                                         , n.fornecedor_key
                                                          )  NF   ON NF.PEDIDO_VENDA_KEY = FV.PEDIDO_VENDA_KEY                       
                                                                  AND NF.loja_key = FV.LOJA_KEY 
                                                                  and nf.data_emissao >= fv.data_emissao                            
                                                                  and nf.cdpessoabluesoft_cliente = coalesce(fv.cliente_key,0)      
                                   LEFT JOIN  nota_fiscal_origem      o on o.origem_nf_key = nf.nf_key and o.loja_key = nf.loja_key 
                                   LEFT JOIN ( SELECT   COUNT (xi.produto_key )  as numero_itens 
                                                      , xi.pedido_venda_key as pedido_venda_key 
                                                      , xi.cliente_key as cliente_key
                                               FROM pedido_venda xi 
                                               GROUP BY xi.pedido_venda_key, xi.cliente_key
                                             ) IT ON IT.pedido_venda_key = fv.pedido_venda_key and it.cliente_key = coalesce(fv.cliente_key,0) 
                                   WHERE     1 = 1                                                                                  
                                   and       coalesce(fv.cliente_key,0) > 0 
                                   AND       fv.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                   AND       fv.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'                             
                                   AND       ( fv.loja_key = 991 
                                                 or  ( fv.loja_key = 1 and fv.tipo_pedido_venda = 'Ecommerce' )                     
                                  )   ;

            `;
        return sql;
    }
    static script_faturamentoBluesoft_fv(parametro) {
        let dataProcessamentoIni = parametro.dataProcessamentoIni ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoIni, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let dataProcessamentoFim = parametro.dataProcessamentoFim ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoFim, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let sql = `select fv.numero_pedido_forca_venda as numeropedido_fv
                            ,     fv.vendedor_key as cdpessoabluesoft_vendedor
                            ,     coalesce(fv.prazo_pagamento,'') as prazo_pagamento
                            ,     coalesce(fv.tipo_prazo_pagamento,'') as tipo_prazo_pagamento
                            ,     coalesce(fv.gerente_cadastro_key,0) as cdpessoabluesoft_gerente 
                            ,     coalesce(fv.supervisor_cadastro_key,0) as cdpessoabluesoft_supervisor
                            ,     coalesce(fv.tabela_preco_venda_key,0) as tabelapreco_cd
                            ,     coalesce(fv.tabela_preco_venda_versao,0) as tabelapreco_versao_cd

                    from fato_pedido_forca_venda fv
                    where 1 = 1
                        AND       FV.pedido_forca_venda_cliente_key  in (                                         
                                                                          select pedido_forca_venda_cliente_key   
                                                                          from   fato_pedido_forca_venda      
                                                                          where  data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                                                            and  data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'     
                                                                          group  by pedido_forca_venda_cliente_key
                                                                          union                                   
                                                                          select  pedido_forca_venda_cliente_key  
                                                                          from    log_pedido_forca_venda  
                                                                          where data_ocorrencia >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                                                          and   data_ocorrencia <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'   
                                                                          group by pedido_forca_venda_cliente_key 
                                                                          )   
                    group by fv.numero_pedido_forca_venda 
                    ,     fv.vendedor_key 
                    ,     fv.prazo_pagamento 
                    ,     fv.tipo_prazo_pagamento 
                    ,     fv.gerente_cadastro_key 
                    ,     fv.supervisor_cadastro_key 
                    ,     fv.tabela_preco_venda_key 
                    ,     fv.tabela_preco_venda_versao 

        `;
        return sql;
    }
    static script_faturamentoBluesoft_fv_cliente(parametro) {
        let dataProcessamentoIni = parametro.dataProcessamentoIni ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoIni, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let dataProcessamentoFim = parametro.dataProcessamentoFim ? modelbase_1.clsTools._datemomentDatStrToDate(parametro.dataProcessamentoFim, "YYYY-MM-DD") : modelbase_1.clsTools._datemomentDatStrToDate("1900-01-01", "YYYY-MM-DD");
        let sql = `
                        select        fv.numero_pedido_forca_venda        as numeropedido_fv
                                ,     fv.pedido_forca_venda_cliente_key   as numeropedido 
                                ,     fv.cliente_key                      as cdpessoabluesoft_cliente
                                ,     fv.status_pedido                       as status_pedido
                        from fato_pedido_forca_venda fv
                        where 1 = 1
                         where 1 = 1
                        AND       FV.pedido_forca_venda_cliente_key  in (                                         
                                                                          select pedido_forca_venda_cliente_key   
                                                                          from   fato_pedido_forca_venda      
                                                                          where  data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                                                            and  data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'     
                                                                          group  by pedido_forca_venda_cliente_key
                                                                          union                                   
                                                                          select  pedido_forca_venda_cliente_key  
                                                                          from    log_pedido_forca_venda  
                                                                          where data_ocorrencia >= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoIni, "YYYY-MM-DD")}'
                                                                          and   data_ocorrencia <= '${modelbase_1.clsTools._datemomentDateToStr(dataProcessamentoFim, "YYYY-MM-DD")}'   
                                                                          group by pedido_forca_venda_cliente_key 
                                                                          )   
                    group by      fv.numero_pedido_forca_venda 
                            ,     fv.pedido_forca_venda_cliente_key
                            ,     fv.cliente_key    
                            ,     fv.status_pedido   

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
                modelbase_1.clsTools.PagErrorException("reportFaturamentoBluesoftRedshiftList", "get", e);
                throw new Error(`${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportFaturamentoBluesoftRedshiftList;
