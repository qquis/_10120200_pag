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
class reportParticipanteBluesoftRedshift {
    static sql(parametro) {
        let sql = ``;
        sql = ` SELECT      PS.PESSOA_KEY                                                                                     as cdpessoabluesoft  
                      ,     PS.CPF_CNPJ                                                                                       as cpf_cnpj 
                      ,     REPLACE(COALESCE(insc_estadual, ''), '''', '')                                                    as inscricaoestadual 
                      ,     PS.NOME_RAZAO                                                                                     as nome_razao  
                      ,     PS.NOME_ABREVIADO                                                                                 as nome_abreviado  
                      ,     CASE WHEN COALESCE(PS.FISICA,'0') = 0 THEN 1 ELSE 0 END                                           as pessoajuridica  
                      ,     left(ISNULL(email_comercial, ''),60)                                                              as email_main  
                      ,     COALESCE(PS.DATA_CADASTRO, '1900-01-01')                                                          AS bluesoftpessoa_data_cadastro  

                      ,     CASE WHEN TRIM(COALESCE(sexo,'M')) = '' THEN 'M' ELSE COALESCE(sexo,'M') END                      as sexo   
                      ,     COALESCE(data_nascimento, '1900-01-01')                                                           as data_nascimento  

                      ,     COALESCE(PS.CEP, 0 )                                                                              AS endereco_cep  
                      ,     COALESCE(PS.ENDERECO_RUA, '' )                                                                    AS endereco_logradouro  
                      ,     COALESCE(PS.ENDERECO_NUMERO, '0')                                                                 AS endereco_numero  
                      ,     COALESCE(PS.ENDERECO_COMPLEMENTO, '' )                                                            AS endereco_complemento  
                      ,     COALESCE(PS.BAIRRO, '' )                                                                          AS endereco_bairro  
                      ,     COALESCE(PS.MUNICIPIO, '' )                                                                       AS endereco_municipio  
                      ,     COALESCE(PS.ESTADO_SIGLA, '' )                                                                    AS endereco_uf  
                      ,     ISNULL(latitude,0)                                                                                as endereco_latitude  
                      ,     ISNULL(longitude,0)                                                                               as endereco_longitude         


                      ,     CASE WHEN COALESCE(CL.CLIENTE_KEY,0) <> 0 THEN 1 else 0    end                                    as bluesoftcliente   
                      ,     CASE WHEN COALESCE(VE.VENDEDOR_EXTERNO_KEY,0) <> 0 THEN 1 else 0 end                              as bluesoftvendedor       
                      ,     CASE WHEN COALESCE(FO.FORNECEDOR_KEY,0) <> 0 THEN 1 else 0 end                                    as bluesoftfornecedor  
                      ,     CASE WHEN COALESCE(FA.FABRICANTE_KEY,0) <> 0 THEN 1 else 0 end                                    as bluesoftfabricante 
                      ,     COALESCE(GRUPO_ECONOMICO.GRUPO_ECONOMICO_KEY,0)                                                   AS cdgrupoeconomico  
                      ,     COALESCE(CLIENTE.VENDEDOR_EXTERNO_KEY,0)                                                          AS cdpessoabluesoft_vendedor 
                      ,     COALESCE(CL.bluesoftclientestatus,0)                                                              as bluesoftclientestatus  
                      ,     COALESCE(PS.STATUS,0)                                                                             AS bluesoftpessoastatus  
                      ,     COALESCE(CL.bluesoftcliente_creditolimite_valor,0)                                                AS bluesoftcliente_creditolimite_valor  
                      ,     COALESCE(CL.bluesoftcliente_creditolimite_valor_reservado,0)                                      AS bluesoftcliente_creditolimite_valor_reservado  
                      ,     COALESCE(CL.bluesoftcliente_creditostatus_cd,0)                                                   AS bluesoftcliente_creditostatus_cd  
                      ,     COALESCE(CL.bluesoftcliente_ramoatividade_cd,0)                                                   AS bluesoftcliente_ramoatividade_cd  
                      ,     COALESCE(MT.motorista_key,0)                                                                      AS bluesoftmotorista
                FROM        PESSOA PS 
                LEFT JOIN   (     SELECT    FORNECEDOR_KEY        AS FORNECEDOR_KEY  
                                  FROM      FORNECEDOR_PRODUTO  
                                  GROUP BY  FORNECEDOR_KEY 
                            ) FO ON FO.FORNECEDOR_KEY = PS.PESSOA_KEY  
                LEFT JOIN   (     SELECT    FABRICANTE_KEY        AS FABRICANTE_KEY 
                                  FROM      PRODUTO_D 
                                  GROUP BY  FABRICANTE_KEY 
                            ) FA ON FA.FABRICANTE_KEY = PS.PESSOA_KEY  
                LEFT JOIN   (     SELECT    PESSOA_KEY        AS CLIENTE_KEY  
                                        ,   cast(CASE WHEN COALESCE(STATUS,'INATIVO') = 'INATIVO' THEN 0 ELSE 1 END as int) AS bluesoftclientestatus  
                                        ,   COALESCE(credito_limite,0)       AS bluesoftcliente_creditolimite_valor  
                                        ,   COALESCE(credito_usado,0)        AS bluesoftcliente_creditolimite_valor_reservado  
                                        ,   COALESCE(status_credito,0)       AS bluesoftcliente_creditostatus_cd  
                                        ,   COALESCE(ramo_atividade_key,0)   AS bluesoftcliente_ramoatividade_cd  
                                  FROM      CLIENTE 

                            ) CL ON CL.CLIENTE_KEY = PS.PESSOA_KEY  
                LEFT JOIN   (   select VENDEDOR_EXTERNO_KEY  as VENDEDOR_EXTERNO_KEY FROM GRUPO_ECONOMICO_COMISSAO GROUP BY VENDEDOR_EXTERNO_KEY ) VE ON VE.VENDEDOR_EXTERNO_KEY = PS.PESSOA_KEY  
                LEFT JOIN  ( SELECT      PS.PESSOA_KEY                   AS CLIENTE_KEY  
                                     ,   CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY  
                                     ,   MIN(GM.VENDEDOR_EXTERNO_KEY)    AS VENDEDOR_EXTERNO_KEY  
                             FROM        PESSOA  PS  
                             INNER JOIN  CLIENTE_GRUPO_ECONOMICO     CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY  
                             INNER JOIN  GRUPO_ECONOMICO_COMISSAO    GM ON GM.CLIENTE_GRUPO_ECONOMICO_KEY = CG.CLIENTE_GRUPO_ECONOMICO_KEY  
                             GROUP BY    PS.PESSOA_KEY  
                                     ,   CG.GRUPO_ECONOMICO_KEY  
                           ) CLIENTE ON CLIENTE.CLIENTE_KEY = PS.PESSOA_KEY  
                LEFT JOIN  ( SELECT       PS.PESSOA_KEY                   AS CLIENTE_KEY  
                                      ,   CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY  
                             FROM        PESSOA  PS  
                             INNER JOIN  CLIENTE_GRUPO_ECONOMICO     CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY  
                             GROUP BY    PS.PESSOA_KEY                                          ,   CG.GRUPO_ECONOMICO_KEY  
                            ) GRUPO_ECONOMICO ON GRUPO_ECONOMICO.CLIENTE_KEY = PS.PESSOA_KEY      
                LEFT JOIN  (    SELECT motorista_key 
                                FROM roteiro_entrega 
                                WHERE data_criacao >= CURRENT_DATE - 100
                                group by motorista_key 
                            ) MT ON mt.motorista_key = PS.PESSOA_KEY                             
                 WHERE 1 = 1  
                   AND ps.pessoa_key <> 0  
                   AND coalesce( ps.cpf_cnpj, '') != ''  
                   AND coalesce( ps.cpf_cnpj, '') != '0'  
                   AND coalesce( ps.cpf_cnpj, '') != '00000000000000'  
                   AND coalesce( ps.cpf_cnpj, '') != '00000000000'  
                  


            `;
        if (parametro.cdpessoabluesoft) {
            sql += ` AND PS.cdpessoabluesoft = ${parametro.cdpessoabluesoft} `;
        }
        if (parametro.cpf_cnpj) {
            sql += ` AND PS.CPF_CNPJ = '${parametro.cpf_cnpj}' `;
        }
        if (parametro.nome_razao) {
            sql += ` AND PS.NOME_RAZAO LIKE '%${parametro.nome_razao}%' `;
        }
        if (parametro.data_cadastro_ini) {
            sql += ` AND PS.DATA_CADASTRO >= '${parametro.data_cadastro_ini}' `;
        }
        if (parametro.data_cadastro_fim) {
            sql += ` AND PS.DATA_CADASTRO <= '${parametro.data_cadastro_fim}' `;
        }
        sql += ` ORDER BY PS.PESSOA_KEY ASC ; `;
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
                modelbase_1.clsTools.PagErrorException("ReportParticipanteBluesoftRedshift", "get", e);
                throw new Error(`${e}`);
            }
            finally {
                return result;
            }
        });
    }
}
exports.default = reportParticipanteBluesoftRedshift;
