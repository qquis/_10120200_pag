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
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const report_ZanthusClientes_1 = __importDefault(require("../report/report.ZanthusClientes"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 10050011;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0085-ZANTHUS-Service | ServiceAtualizacaoClientes";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceAtualizacaoGeralCliente {
    static start(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c;
            try {
                let reportZanthusType = {
                    Base: 'Zanthus',
                    ProdutosPendentesDeIntegracao: parametros.ProdutosPendentesDeIntegracao ? true : false,
                    AlteracaoTributaria: "0",
                    integracao_tipo_cd: parametros.integracao_tipo_cd || 20008501
                };
                let result = yield report_ZanthusClientes_1.default.get(parametros);
                let listCliente = result;
                let myDataBase = new modelbase_1.clsBase();
                let i = 0;
                let iprocessados = 0;
                let ibloco = 100;
                let sql = "";
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Inicializando atualização de clientes Zanthus`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                try {
                    for (var _d = true, listCliente_1 = __asyncValues(listCliente), listCliente_1_1; listCliente_1_1 = yield listCliente_1.next(), _a = listCliente_1_1.done, !_a; _d = true) {
                        _c = listCliente_1_1.value;
                        _d = false;
                        let cliente = _c;
                        sql += this.sqlscriptInsert(cliente);
                        sql += this.sqlscriptUpdate(cliente);
                        i++;
                        iprocessados++;
                        if (i >= ibloco) {
                            // Execute the SQL batch here
                            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando ${iprocessados}/${listCliente.length} registros`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                            yield myDataBase.myDataBase.zanthusPostgre.Execute(sql);
                            i = 0;
                            sql = "";
                        }
                    }
                }
                catch (e_1_1) { e_1 = { error: e_1_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = listCliente_1.return)) yield _b.call(listCliente_1);
                    }
                    finally { if (e_1) throw e_1.error; }
                }
                if (sql !== "") {
                    // Execute the remaining SQL batch here
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Atualizando ${iprocessados}/${listCliente.length} registros`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myDataBase.myDataBase.zanthusPostgre.Execute(sql);
                    sql = "";
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`${FLG_MODULO}`, 'start', e);
            }
            finally {
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Finalizando execução do start`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
            }
        });
    }
    static sqlscriptInsert(cliente) {
        let sql = `
        INSERT INTO tab_cliente
        (
              cod_cliente
            , des_cliente
            , des_fantasia
            , num_cgc
            , flg_empresa
            , flg_enviar_carga
            , loja_cadastro
            , status_cliente
            , origem_cadastro
            , flg_fidelidade
            , senha_pdv
            , situacao_cadastro
            , flg_habilitado_compra
            , flg_revenda
            , des_endereco
            , id_municipio
            , numero
            , des_bairro
            , compl_endereco
            , cod_pais
            , des_cidade
            , num_cep
            , des_sigla
            , num_insc_est
            , flg_tipo_cobranca
            , des_tratamento
            , des_profissao
            , flg_integracao_01
            , flg_integracao_02
            , des_email
            , eco_cod_loja
            , forma_reativar_credito
            , flg_gera_evento_financeiro
            , flg_convenio
            , micro_empresa
            , categoria_cliente
            , num_fone
            , flg_sexo
            , flg_est_civil
            , flg_residencia
            , flg_profissao
            , flg_chq_especial
            , flg_automovel
            , flg_auto_alienado
            , tipo_c_credito
            , usuario
            , cod_banco
            , flg_orginst
            , val_limite_credito
            , val_credito
            , val_debito
            , opcao_mensagem
            , val_limite_cheque
            , val_limite_cheque_utilizado
            , dia_ini_fatura
            , dia_fim_fatura
            , cod_plano_financeiro
            , flg_primeiro_acesso
            , cod_conta_sped
            , ctrl_envio_generico
            , flg_estrangeiro
            , flg_sugere_transportadora
            , flg_boletim
            , flg_crm_resgate_bonus
            , flg_crm_resgate_pontos
            , flg_pessoa_autorizada
            , flg_cooperado
            , flg_permitir_compra_webstore
            , flg_impedir_carga
            , flg_clube_cadcompleto
            , flg_clube_aceite
            , flg_telemarketing
            , flg_email
            , flg_sms
            , flg_catalogo
            , flg_politicamente_exposto
            , flg_terrorista
            , flg_integracao_ecommerce
            , flg_termo_fidelidade
            , flg_email_fidelidade
            , tipo_residencia
            , tipo_construcao
            , status_cheque
            , val_debito_cheque
            , dta_cadastro 
        )
        SELECT 
                    ${cliente.cod_cliente}
                    , '${cliente.des_cliente}'
                    , '${cliente.des_fantasia}'
                    , '${cliente.flg_empresa == "N" ? cliente.num_cgc.slice(-12).padStart(12, "0") : cliente.num_cgc}'
                    , '${cliente.flg_empresa}'
                    , '${cliente.flg_enviar_carga}'
                    , ${cliente.loja_cadastro}
                    , ${cliente.status_cliente}
                    , ${cliente.origem_cadastro}
                    , '${cliente.flg_fidelidade}'
                    , '${cliente.senha_pdv}'
                    , ${cliente.situacao_cadastro}
                    , '${cliente.flg_habilitado_compra}'
                    , '${cliente.flg_revenda}'
                    , '${cliente.des_endereco}'
                    , m.id_municipio
                    , '${cliente.numero}'
                    , '${cliente.des_bairro}'
                    , '${cliente.compl_endereco}'
                    , ${cliente.cod_pais}
                    , '${cliente.des_cidade}'
                    , '${cliente.num_cep}'
                    , '${cliente.des_sigla}'
                    , '${cliente.num_insc_est}'
                    , ${cliente.flg_tipo_cobranca}
                    , ${cliente.des_tratamento}
                    , ${cliente.des_profissao}
                    , ${cliente.flg_integracao_01}
                    , ${cliente.flg_integracao_02}
                    , '${cliente.des_email}'
                    , ${cliente.eco_cod_loja}
                    , ${cliente.forma_reativar_credito}
                    , '${cliente.flg_gera_evento_financeiro}'
                    , '${cliente.flg_convenio}'
                    , '${cliente.micro_empresa}'
                    , ${cliente.categoria_cliente}
                    , '${cliente.num_fone}'
                    , '${cliente.flg_sexo}'
                    , '${cliente.flg_est_civil}'
                    , ${cliente.flg_residencia}
                    , ${cliente.flg_profissao}
                    , ${cliente.flg_chq_especial}
                    , ${cliente.flg_automovel}
                    , ${cliente.flg_auto_alienado}
                    , ${cliente.tipo_c_credito}
                    , ${cliente.usuario}
                    , ${cliente.cod_banco}
                    , ${cliente.flg_orginst}
                    , ${cliente.val_limite_credito}
                    , ${cliente.val_credito}
                    , ${cliente.val_debito}
                    , ${cliente.opcao_mensagem}
                    , ${cliente.val_limite_cheque}
                    , ${cliente.val_limite_cheque_utilizado}
                    , ${cliente.dia_ini_fatura}
                    , ${cliente.dia_fim_fatura}
                    , ${cliente.cod_plano_financeiro}
                    , '${cliente.flg_primeiro_acesso}'
                    , '${cliente.cod_conta_sped}'
                    , ${cliente.ctrl_envio_generico}
                    , ${cliente.flg_estrangeiro}
                    , ${cliente.flg_sugere_transportadora}
                    , '${cliente.flg_boletim}'
                    , '${cliente.flg_crm_resgate_bonus}'
                    , '${cliente.flg_crm_resgate_pontos}'
                    , ${cliente.flg_pessoa_autorizada}
                    , '${cliente.flg_cooperado}'
                    , '${cliente.flg_permitir_compra_webstore}'
                    , '${cliente.flg_impedir_carga}'
                    , '${cliente.flg_clube_cadcompleto}'
                    , '${cliente.flg_clube_aceite}'
                    , '${cliente.flg_telemarketing}'
                    , '${cliente.flg_email}'
                    , '${cliente.flg_sms}'
                    , '${cliente.flg_catalogo}'
                    , '${cliente.flg_politicamente_exposto}'
                    , '${cliente.flg_terrorista}'
                    , ${cliente.flg_integracao_ecommerce}
                    , ${cliente.flg_termo_fidelidade}
                    , ${cliente.flg_email_fidelidade}
                    , ${cliente.tipo_residencia}
                    , ${cliente.tipo_construcao}
                    , ${cliente.status_cheque}
                    , ${cliente.val_debito_cheque}
                    , current_timestamp
        FROM tab_municipio m 
        WHERE 1 = 1 
        AND m.cod_ibge = '${cliente.ibge_municipio_format_zanthus}'
        AND m.id_uf = '${cliente.des_sigla}'
        AND NOT EXISTS
        (
            SELECT 1
            FROM tab_cliente
            WHERE cod_cliente = ${cliente.cod_cliente}
        );
    `;
        return sql;
    }
    static sqlscriptUpdate(cliente) {
        let sql = `
        UPDATE tab_cliente
        SET     des_cliente = '${cliente.des_cliente}'
           ,    des_fantasia = '${cliente.des_fantasia}'
           ,    num_cgc = '${cliente.flg_empresa == "N" ? cliente.num_cgc.slice(-11).padStart(11, "0") : cliente.num_cgc}'
           ,    flg_empresa = '${cliente.flg_empresa}'
           ,    des_email = '${cliente.des_email}'
           ,    status_cliente = ${cliente.status_cliente}
           ,    flg_revenda = '${cliente.flg_revenda}'
           ,    num_insc_est = '${cliente.num_insc_est}'
           ,    dta_alteracao = current_timestamp
        WHERE cod_cliente = ${cliente.cod_cliente};
    `;
        return sql;
    }
}
exports.default = serviceAtualizacaoGeralCliente;
