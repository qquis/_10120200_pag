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
let myBase = new modelbase_1.clsBase();
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 0;
const FLG_DEBUG_CONSOLE_LOG = false;
const FLG_MODULO = "M0011-Service | ServiceParticipanteBlueSoftAtualizarStatusCredito";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceParticipanteBlueSoftAPIAtualizarStatusCreditoCorrecao {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a;
            try {
                const myclsBase = new modelbase_1.clsBase();
                let sql = `SELECT     x.cdparticipante 
                              ,   b.cdpessoabluesoft 
                              ,   x.inscricaoestadual
                              ,   x.cpf_cnpj
                       FROM   tmp_participante_ie x
                       inner  join tbparticipante_bluesoft b on b.cdparticipante = x.cdparticipante  
                       where  1 = 1 
                       and x.processado = 0
                       order by b.cdpessoabluesoft 
                       limit 5
                       
                       `;
                const result = yield myclsBase.myDataBase.pag.DataGet(sql);
                let list = result;
                for (let itemACorrigir of list) {
                    const url = `/clientes/${encodeURIComponent(itemACorrigir.cdpessoabluesoft)}`;
                    const resposta = yield myclsBase.blueSoftApi.api_get(url);
                    const dadosOriginais = resposta.data;
                    if (!dadosOriginais) {
                        throw new Error('A API BlueSoft não retornou os dados do cliente.');
                    }
                    const limiteAtual = (_a = dadosOriginais.saldosDoCliente) === null || _a === void 0 ? void 0 : _a.creditoLimite;
                    if (typeof limiteAtual !== 'number' || !Number.isFinite(limiteAtual)) {
                        throw new Error('O limite de crédito atual não foi retornado pela API BlueSoft.');
                    }
                    if (!dadosOriginais.nomeRazao ||
                        !dadosOriginais.cpfCnpj ||
                        !dadosOriginais.nomeAbreviado ||
                        !dadosOriginais.dataCadastro ||
                        !dadosOriginais.ultimaAlteracao ||
                        !Array.isArray(dadosOriginais.contatos) ||
                        !Array.isArray(dadosOriginais.enderecos)) {
                        throw new Error('A API BlueSoft não retornou todos os dados necessários para o PUT.');
                    }
                    const dados = {
                        nomeRazao: dadosOriginais.nomeRazao,
                        cpfCnpj: dadosOriginais.cpfCnpj,
                        nomeAbreviado: dadosOriginais.nomeAbreviado,
                        dataCadastro: dadosOriginais.dataCadastro,
                        ultimaAlteracao: dadosOriginais.ultimaAlteracao,
                        contatos: dadosOriginais.contatos,
                        enderecos: dadosOriginais.enderecos,
                        inscricaoEstadual: itemACorrigir.inscricaoestadual,
                        analiseCredito: {
                            limites: [
                                {
                                    tipoLimiteSaldo: 'GERAL',
                                    limite: limiteAtual,
                                    status: 'CREDITO_OK',
                                    podeProtestar: true
                                }
                            ]
                        }
                    };
                    let url_post = `/clientes/${dados.cpfCnpj}`;
                    yield myclsBase.blueSoftApi.api_put(url_post, dados);
                    let sql_status = `update tmp_participante_ie set processado = 1 where cdparticipante = ${itemACorrigir.cdparticipante}`;
                    yield myclsBase.myDataBase.pag.Execute(sql_status);
                    console.log(`codigo blue ${itemACorrigir.cdpessoabluesoft} `);
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, `serviceParticipanteBlueSoftAPIAtualizarStatusCredito.start()`, e, true);
                throw new Error(`modules | Participante | Error ${e.message}`);
            }
        });
    }
}
exports.default = serviceParticipanteBlueSoftAPIAtualizarStatusCreditoCorrecao;
