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
class modelZanthusCliente {
    constructor(cod_cliente = 0) {
        this.cod_cliente = cod_cliente;
    }
    getData() {
        return __awaiter(this, void 0, void 0, function* () {
            let data = null;
            try {
                let myclsBase = new modelbase_1.clsBase();
                data = yield myclsBase.myDataBase.zanthusPostgre.DataGet(yield this.getSql());
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modules.External | Zanthus`, "getData", e);
            }
            finally {
                return data;
            }
        });
    }
    getSql() {
        return __awaiter(this, void 0, void 0, function* () {
            let sql = "";
            try {
                if (this.cod_cliente == 0) {
                    throw new Error("cod_cliente não pode ser 0");
                }
                sql = `
                    SELECT 
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
                    FROM  tab_cliente 
                    WHERE cod_cliente = ${this.cod_cliente}
                    
                    `;
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(`modules.External | Zanthus`, "sql", e);
            }
            finally {
                return sql;
            }
        });
    }
}
exports.default = modelZanthusCliente;
