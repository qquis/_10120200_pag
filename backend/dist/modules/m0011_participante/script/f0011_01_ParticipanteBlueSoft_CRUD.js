"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class f0011_01_ParticipanteBlueSoft_CRUD {
    static sqlScript_VERSION() { return `f0011_90_1012019_tbparticipante_bluesoft_integ`; }
    static get(Participante, sqlCommand) {
        let sql = `SELECT ${this.sqlScript_VERSION()}
                      (    sqlcommand:=  '${sqlCommand}' 
                           , vcdpessoabluesoft:=  ${Participante.cdpessoabluesoft}
                           , vcpf_cnpj:= '${Participante.cpf_cnpj}'
                           , vnome_razao:= '${Participante.nome_razao ? Participante.nome_razao : ''}'
                           , vpessoajuridica:= ${Participante.pessoajuridica}
                           , vemail_main:= '${Participante.email_main ? Participante.email_main : ''}'
                           , vnome_abreviado:= '${Participante.nome_abreviado ? Participante.nome_abreviado : ''}'
                           , vpf_sexo:= '${Participante.sexo ? Participante.sexo : ''}'
                           , vpf_data_nascimento:= '${Participante.data_nascimento ? Participante.data_nascimento : ''}'
                           , vendereco_cep:= ${Participante.endereco_cep}
                           , vendereco_logradouro:= '${Participante.endereco_logradouro ? Participante.endereco_logradouro : ''}'
                           , vendereco_numero:= '${Participante.endereco_numero ? Participante.endereco_numero : ''}'
                           , vendereco_complemento:= '${Participante.endereco_complemento ? Participante.endereco_complemento : ''}'
                           , vendereco_bairro:= '${Participante.endereco_bairro ? Participante.endereco_bairro : ''}'
                           , vendereco_municipio:= '${Participante.endereco_municipio ? Participante.endereco_municipio : ''}'
                           , vendereco_uf:= '${Participante.endereco_uf ? Participante.endereco_uf : ''}'
                           , vendereco_latitude:= ${Participante.endereco_latitude}
                           , vendereco_longitude:= ${Participante.endereco_longitude}
                           , vbluesoft_pessoa_status:= ${Participante.bluesoft_pessoa_status}
                           , vbluesoft_pessoa_data_cadastro:= '${Participante.bluesoft_pessoa_data_cadastro ? Participante.bluesoft_pessoa_data_cadastro : ''}'
                           , vbluesoftcliente:= ${Participante.bluesoftcliente ? Participante.bluesoftcliente : 0}
                           , vbluesoftvendedor:= ${Participante.bluesoftvendedor ? Participante.bluesoftvendedor : 0}
                           , vbluesoftfornecedor:= ${Participante.bluesoftfornecedor ? Participante.bluesoftfornecedor : 0}
                           , vbluesoftfabricante:= ${Participante.bluesoftfabricante ? Participante.bluesoftfabricante : 0}
                           , vbluesoftmotorista:= ${Participante.bluesoftmotorista ? Participante.bluesoftmotorista : 0}
                           , vcdgrupoeconomico:= ${Participante.cdgrupoeconomico ? Participante.cdgrupoeconomico : 0}
                           , vcdpessoabluesoft_vendedor:= ${Participante.cdpessoabluesoft_vendedor ? Participante.cdpessoabluesoft_vendedor : 0}
                           , vbluesoftclientestatus:= ${Participante.bluesoftclientestatus ? Participante.bluesoftclientestatus : 0}
                           , vbluesoftcliente_creditolimite_valor:= ${Participante.bluesoftcliente_creditolimite_valor ? Participante.bluesoftcliente_creditolimite_valor : 0}
                           , vbluesoftcliente_creditolimite_valor_reservado:= ${Participante.bluesoftcliente_creditolimite_valor_reservado ? Participante.bluesoftcliente_creditolimite_valor_reservado : 0}
                           , vbluesoftcliente_creditostatus_cd:= ${Participante.bluesoftcliente_creditostatus_cd ? Participante.bluesoftcliente_creditostatus_cd : 0}
                           , vbluesoftcliente_ramoatividade_cd:= ${Participante.bluesoftcliente_ramoatividade_cd ? Participante.bluesoftcliente_ramoatividade_cd : 0}
                           , vtipocliente:= '${Participante.tipocliente ? Participante.tipocliente : ''}'
                           , vibge_municipio_cd:= '${Participante.ibge_municipio_cd ? Participante.ibge_municipio_cd : ''}'
                           , vinscricaoestadual:= '${Participante.inscricaoestadual ? Participante.inscricaoestadual : ''}'
                         );`;
        return sql;
    }
}
exports.default = f0011_01_ParticipanteBlueSoft_CRUD;
/*
import { version } from "uuid";
import pagToolsDate from "../../../tools/pagToolsDate"
import {Tools_pagDateTime_getDateStringShort} from "../../../tools/Tools_Log";
import Tools from '../../../tools/Tools'

import TbParticipante from "../tbs/tbparticipante";


export default class f0011_02_ParticipanteBlueSoft_Crud {

    private static sqlScript_VERSION(): string {return `f0011_02_1011960_tbparticipante_pessoabluesoft_grud`}

    static sqlScript_INSERT(participanteBlueSoft: TbParticipante ): string{return this.sqlScriptPg("DBINSERT", participanteBlueSoft)}
    
    static sqlScript_UPDATE(participanteBlueSoft: TbParticipante ): string{return this.sqlScriptPg("DBUPDATE", participanteBlueSoft)}

    private static sqlScriptPg(_stringCommand: string, participanteBlueSoft: TbParticipante): string
    {
        const script: string = `Select * from ${this.sqlScript_VERSION()}
        (  '${_stringCommand}',
            '${participanteBlueSoft.cpf_cnpj}',
            ${participanteBlueSoft.cdpessoabluesoft},
            '${participanteBlueSoft.nome_razao.replace(`'`, ``)}',
            ${participanteBlueSoft.pessoajuridica},
            '${participanteBlueSoft.email_main.replace(`'`, ``)}',
            ${participanteBlueSoft.bluesoftcliente},
            ${participanteBlueSoft.bluesoftvendedor},
            ${participanteBlueSoft.bluesoftfornecedor},
            ${participanteBlueSoft.bluesoftfabricante},
            ${participanteBlueSoft.cdgrupoeconomico},
            ${participanteBlueSoft.cdpessoabluesoft_vendedor},
            '${participanteBlueSoft.Pessoa.sexo}',
            '${Tools.format_Date_toStr_ShortDataBase(participanteBlueSoft.Pessoa.data_nascimento)}',
            ${participanteBlueSoft.Pessoa.endereco_cep},
            '${participanteBlueSoft.Pessoa.endereco_logradouro.replace(`'`, ``)}',
            '${participanteBlueSoft.Pessoa.endereco_bairro.replace(`'`, ``)}',
            '${participanteBlueSoft.Pessoa.endereco_municipio.replace(`'`, ``)}',
            '${participanteBlueSoft.Pessoa.endereco_numero}',
            '${participanteBlueSoft.Pessoa.endereco_uf}',
            '${participanteBlueSoft.Pessoa.endereco_complemento.replace(`'`, ``)}',
             ${participanteBlueSoft.Pessoa.latitude},
             ${participanteBlueSoft.Pessoa.longitude},
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftclientestatus},
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftpessoastatus},
            '${Tools.format_Date_toStr_ShortDataBase(participanteBlueSoft.PessoaBlueSoft.bluesoftpessoa_data_cadastro)}',
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftcliente_creditolimite_valor},
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftcliente_creditolimite_valor_reservado},
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftcliente_creditostatus_cd},
            ${participanteBlueSoft.PessoaBlueSoft.bluesoftcliente_ramoatividade_cd},
            '${participanteBlueSoft.nome_abreviado}'
            )`
            return script;
    
    }

    static _RedShift_Select() : string {
    return  ` SELECT                PS.PESSOA_KEY                                                                  as cdpessoabluesoft
                              ,     PS.NOME_RAZAO                                                                  as nome_razao
                              ,     CASE WHEN COALESCE(PS.FISICA,'0') = 0 THEN 1 ELSE 0 END                        as pessoajuridica
                              ,     PS.NOME_ABREVIADO                                                              as nome_abreviado
                              ,     PS.CPF_CNPJ                                                                    as cpf_cnpj
                              ,     case when trim(coalesce(sexo,'M')) = '' then 'M' else coalesce(sexo,'M') end   as sexo
                              ,     coalesce(data_nascimento, '1900-01-01')                                        as data_nascimento
                              ,     left(coalesce(email_comercial, ''),60)                                         as email_main
                              ,     coalesce(latitude,0)                                                           as latitude
                              ,     coalesce(longitude,0)                                                          as longitude
                              ,     CASE WHEN COALESCE(CL.CLIENTE_KEY,0) <> 0 THEN 1 else 0    end                 as bluesoftcliente
                              ,     CASE WHEN COALESCE(VE.VENDEDOR_EXTERNO_KEY,0) <> 0 THEN 1 else 0 end           as bluesoftvendedor
                              ,     CASE WHEN COALESCE(FO.FORNECEDOR_KEY,0) <> 0 THEN 1 else 0 end                 as bluesoftfornecedor
                              ,     CASE WHEN COALESCE(FA.FABRICANTE_KEY,0) <> 0 THEN 1 else 0 end                 as bluesoftfabricante
                              ,     COALESCE(GRUPO_ECONOMICO.GRUPO_ECONOMICO_KEY,0)                                as cdgrupoeconomico
                              ,     COALESCE(CLIENTE.VENDEDOR_EXTERNO_KEY,0) AS cdpessoabluesoft_vendedor
                              ,     COALESCE(CL.bluesoftclientestatus,0)     as bluesoftclientestatus
                              ,     COALESCE(PS.STATUS,0)                         AS bluesoftpessoastatus
                              ,     COALESCE(PS.DATA_CADASTRO, '1900-01-01')  AS bluesoftpessoa_data_cadastro
                              ,     COALESCE(CL.bluesoftcliente_creditolimite_valor,0)           AS bluesoftcliente_creditolimite_valor
                              ,     COALESCE(CL.bluesoftcliente_creditolimite_valor_reservado,0) AS bluesoftcliente_creditolimite_valor_reservado
                              ,     COALESCE(CL.bluesoftcliente_creditostatus_cd,0)              AS bluesoftcliente_creditostatus_cd
                              ,     COALESCE(CL.bluesoftcliente_ramoatividade_cd,0)              AS bluesoftcliente_ramoatividade_cd
                              ,     COALESCE(PS.CEP, 0 )                                         AS endereco_cep
                              ,     COALESCE(PS.ENDERECO_RUA, '' )                               AS endereco_logradouro
                              ,     COALESCE(PS.ENDERECO_COMPLEMENTO, '' )                       AS endereco_complemento
                              ,     COALESCE(PS.BAIRRO, '' )                            AS endereco_bairro
                              ,     COALESCE(PS.MUNICIPIO, '' )                         AS endereco_municipio
                              ,     COALESCE(PS.ESTADO_SIGLA, '' )                      AS endereco_uf
                              ,     COALESCE(PS.ENDERECO_NUMERO, '0')                            AS endereco_numero
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
                       WHERE CAST(PS.CPF_CNPJ AS NUMERIC(14,0)) > 0
                         AND ps.pessoa_key <> 0
                       ORDER BY PS.PESSOA_KEY ASC limit 210 `
    }

}*/ 
