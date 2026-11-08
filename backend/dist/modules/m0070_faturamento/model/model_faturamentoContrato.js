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
const LOGINFO = {
    SISTEMA_NUCLEO_PRC_CD: 0,
    FLG_DEBUG_CONSOLE_LOG: true,
    FLG_MODULO: "M0070 FaturamentoContrato | MODEL CONTRATO",
    FLG_NOPRINT_TIME: false,
    FLG_DEBUG_FILE_CONSOLE_LOG: ``
};
const modelbase_1 = require("../../../model/modelbase");
class model_faturamentoContrato {
    static post(dados) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = {};
            try {
                let dadosContrato = dados;
                dadosContrato = yield this.constratoInserirAtualizar(dadosContrato);
                dadosContrato = yield this.contratoProdutoInserirAtualizar(dadosContrato);
                return dadosContrato;
            }
            catch (e) {
                throw new Error(e);
            }
        });
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const contrato_seq = Number(parametro === null || parametro === void 0 ? void 0 : parametro.contrato_seq);
                if (!(contrato_seq > 0)) {
                    throw new Error("contrato_seq não informado");
                }
                const contrato = yield this.consultarContrato({ contrato_seq });
                if (!contrato) {
                    throw new Error(`Contrato ${contrato_seq} não encontrado`);
                }
                contrato.itens = yield this.consultarContratoItens(contrato_seq);
                return contrato;
            }
            catch (e) {
                yield this.__log(`Erro ao consultar contrato ${e}`);
                throw new Error(e);
            }
        });
    }
    static consultarContratoItens(contrato_seq) {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = `
            SELECT  i.contrato_seq
            ,    i.pr_cdproduto
            ,    i.prb_cdprodutobluesoft
            ,    pb.prb_descricao as descricao
            ,    pb.prb_embalagemestoque
            ,    i.valor_unitario
            FROM tbfaturamentocontrato_produto i
            inner join  tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
            WHERE i.contrato_seq = ${Number(contrato_seq)}
            `;
            return yield this.__databaseGet(sql);
        });
    }
    static consultarContrato(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = parametro;
            try {
                let sql = `	select f.contrato_seq
                ,  f.contrato_descricao 
                ,  f.contrato_data
                ,  f.contrato_tipo_cd
                ,  f.contrato_data_val_ini
                ,  f.contrato_data_val_fim
                ,  f.op_cdoperacao
                ,  f.cdparticipante_contratante
                ,  f.seqfaturamento
                ,  f.seqfaturamentoorigem
                ,  f.faturamento_controle_seq
                ,  f.contrato_valor
                ,  f.contrato_uuid
                ,  l.numeropedido_fv
                ,  l.numeropedido
                ,  l.numeronfe
            from   tbfaturamentocontrato f
            left join tbfaturamento_controle l 
                    on l.faturamento_controle_seq = f.faturamento_controle_seq
            where 1 = 1
              and f.contrato_seq = ${Number(dados.contrato_seq)}
            `;
                let result = yield this.__databaseGet(sql);
                return Array.isArray(result) ? result[0] : result;
            }
            catch (e) {
                yield this.__log(e);
                throw new Error(e);
            }
        });
    }
    static constratoInserirAtualizar(dadosContrato) {
        return __awaiter(this, void 0, void 0, function* () {
            let dados = dadosContrato;
            let dataBase = new modelbase_1.clsBase();
            try {
                if (!dados) {
                    throw new Error("Dados do contrato não informados");
                }
                const txt = (v) => modelbase_1.clsTools.stringToDabase(String(v !== null && v !== void 0 ? v : ''));
                const num = (v, def = 'null') => {
                    const n = Number(v);
                    return v === undefined || v === null || v === '' || isNaN(n) ? def : String(n);
                };
                const data = (v) => {
                    if (!/^\d{4}-\d{2}-\d{2}/.test(String(v !== null && v !== void 0 ? v : ''))) {
                        throw new Error(`Data inválida: ${v}`);
                    }
                    return String(v).substring(0, 10);
                };
                const contrato_uuid = dados.contrato_uuid ? txt(dados.contrato_uuid) : modelbase_1.clsTools.uuid(32).replace(/-/g, '').substring(0, 10).toUpperCase();
                if (contrato_uuid.length > 10) {
                    throw new Error('contrato_uuid excede 10 caracteres');
                }
                let sql_insert = `
                insert into tbfaturamentocontrato  (
                            contrato_uuid
                        ,   contrato_descricao 
                        ,   contrato_data
                        ,   contrato_data_val_ini
                        ,   contrato_data_val_fim
                        ,   contrato_valor  
                        ,   seqfaturamento
                        ,   seqfaturamentoorigem
                        ,   contrato_tipo_cd 
                        ,   op_cdoperacao
                        ,   cdparticipante_contratante
                    )
                    SELECT '${contrato_uuid}'
                        ,  '${txt(dados.contrato_descricao)}'
                        ,  '${data(dados.contrato_data)}'
                        ,  '${data(dados.contrato_data_val_ini)}'
                        ,  '${data(dados.contrato_data_val_fim)}'
                        ,   ${num(dados.contrato_valor, '0')}
                        ,   ${num(dados.seqfaturamento)}
                        ,   ${num(dados.seqfaturamentoorigem)}
                        ,   ${num(dados.contrato_tipo_cd)}
                        ,   ${num(dados.op_cdoperacao)}
                        ,   ${num(dados.cdparticipante_contratante)}
                    where not exists (select 1 from tbfaturamentocontrato xx where xx.contrato_uuid = '${contrato_uuid}')
            `;
                yield dataBase.myDataBase.pag.Execute(sql_insert);
                let scriptConferirSeqContato = `select contrato_seq from tbfaturamentocontrato where contrato_uuid = '${contrato_uuid}'`;
                let dadoRegistroContrato = yield dataBase.myDataBase.pag.DataGet(scriptConferirSeqContato);
                if (dadoRegistroContrato) {
                    let contrato_seq = dadoRegistroContrato[0].contrato_seq;
                    dados.contrato_seq = contrato_seq;
                }
                else {
                    throw new Error('Contrato não inserido');
                }
                return dados;
            }
            catch (e) {
                yield this.__log(`Erro ao inserir contrato ${e}`);
                throw new Error(e);
            }
        });
    }
    static contratoProdutoInserirAtualizar(dados) {
        return __awaiter(this, void 0, void 0, function* () {
            let dataBase = new modelbase_1.clsBase();
            try {
                let script_atualizacao = `
                
                                update tbfaturamentocontrato_produto
                                  set  valor_unitario = 0 
                                  where contrato_seq = ${dados.contrato_seq}
                                ;
                
                                `;
                if (dados && dados.itens && dados.itens.length > 0) {
                    for (const item of dados.itens) {
                        script_atualizacao += `
                        
                                insert into tbfaturamentocontrato_produto 
                                (
                                        contrato_seq
                                    ,   pr_cdproduto 
                                    ,   prb_cdprodutobluesoft 
                                    ,   valor_unitario
                                )
                                select ${dados.contrato_seq}
                                        , ${item.pr_cdproduto}
                                        , ${item.prb_cdprodutobluesoft} 
                                        , ${item.valor_unitario}
                                        
                                        ;
                                        
                                update tbfaturamentocontrato_produto
                                   set valor_unitario = ${item.valor_unitario}
                                   where contrato_seq = ${dados.contrato_seq}
                                   and pr_cdproduto = ${item.pr_cdproduto}
                                   and prb_cdprodutobluesoft = ${item.prb_cdprodutobluesoft}
                        
                                ;
                                 
                                 
                                 `;
                    }
                }
                yield dataBase.myDataBase.pag.Execute(script_atualizacao);
            }
            catch (e) {
                yield this.__log(`Erro ao inserir produto do contrato ${dados.contrato_seq} ${e}`);
            }
        });
    }
    static consultarContratoProdutoItensFornecedor(dados) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `
                
                      SELECT     ${dados.contrato_seq > 0 ? dados.contrato_seq : 0} as contrato_seq
                            ,    pr.pr_cdproduto
                            ,    pb.prb_cdprodutobluesoft_pk 
                            ,    un.prb_descricao as descricao 
                            ,    pb.prb_embalagemestoque
                            ,    cast(0 as numeric(13,2)) as valor_unitario

                       from        tbprodutobluesoft pb 
                       inner join  tbprodutobluesoft un on un.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
                       left join   tbparticipante_bluesoft p on p.cdpessoabluesoft = pb.prb_cdpessoabluesoft_fornecedor
                       left join   tbproduto_subgrupo sb on sb.prsg_cdsubgrupo = pb.prb_cdsubgrupo
                       left join   tbproduto_grupo g on g.prg_cdgrupo = sb.prg_cdgrupo
                       left join   tbproduto_secao s on s.prs_cdsecao = g.prs_cdsecao 
                       left join   tbproduto_departamento d on d.prd_cddepartamento = s.prd_cddepartamento
                       left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario
                       where 1 = 1
                       AND  pb.prb_cdpessoabluesoft_fornecedor = ${dados.prb_cdpessoabluesoft_fornecedor}
                       and  pb.prb_cdprodutobluesoft_pk = pb.prb_cdprodutobluesoftunitario
                       and  pb.prb_status = true


                       `;
                if (dados.contrato_seq && dados.contrato_seq > 0) {
                    sql += `
                        UNION 

                        SELECT  i.contrato_seq
                        ,    i.pr_cdproduto
                        ,    i.prb_cdprodutobluesoft
                        ,    pb.prb_descricao as descricao
                        ,    pb.prb_embalagemestoque               
                        ,    i.valor_unitario 
                        FROM tbfaturamentocontrato_produto i
                        inner join  tbprodutobluesoft pb on pb.prb_cdprodutobluesoft_pk = i.prb_cdprodutobluesoft
                        left join   tbproduto pr on pr.prb_cdprodutobluesoft = pb.prb_cdprodutobluesoftunitario             
                        WHERE CONTRATO_SEQ = ${dados.contrato_seq}
                        `;
                }
                let result = yield this.__databaseGet(sql);
                return result;
            }
            catch (e) {
                yield this.__log(`Erro ao consultar itens do fornecedor ${e}`);
            }
        });
    }
    static __log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagLogInfo(message, LOGINFO);
        });
    }
    static __databaseGet(sql) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let mydb = new modelbase_1.clsBase();
                let dados = yield mydb.myDataBase.pag.DataGet(sql);
                return dados;
            }
            catch (e) {
                yield this.__log(`Erro ao consultar banco de dados ${e}`);
                throw new Error(e);
            }
        });
    }
}
exports.default = model_faturamentoContrato;
