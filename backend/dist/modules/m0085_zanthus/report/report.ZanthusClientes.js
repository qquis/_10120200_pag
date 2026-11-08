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
class reportZanthusClientes {
    static sql(parametro) {
        return `SELECT 		b.cdpessoabluesoft		as cod_cliente
            ,		left(b.nome_razao, 44)    		as des_cliente 
            ,       left(b.nome_abreviado, 35) 		as des_fantasia 
            ,       p.cpf_cnpj              		as num_cgc
            ,		case when b.pessoajuridica = 1
                        then 'S' 
                        else 'N' 
                        end			   	            as flg_empresa
            ,		'S' 							as flg_enviar_carga
            ,		cast(1 as int)          		as loja_cadastro	
            ,		b.bluesoftclientestatus			as status_cliente
            ,		0                       		as origem_cadastro
            ,		'S'                     		as flg_fidelidade
            ,		'' 								as senha_pdv
            ,		cast(1 as int)          		as situacao_cadastro
            ,		cast(1 as int)          		as situacao_cadastro
            ,		'S'								as flg_habilitado_compra
            ,       case 
                        when coalesce(b.tipocliente,'CONSUMIDOR') = 'CONSUMIDOR'
                        then 'N'
                        else 'S'
                        end                    		as flg_revenda
            ,		e.endereco_logradouro      		as des_endereco
            ,		'50308'                   		as id_municipio
            ,       e.endereco_numero          		as numero 
            ,       left(e.endereco_bairro,32)   	as des_bairro

            ,       ''                         		as compl_endereco
            ,       1058                       		as cod_pais 
            ,       e.endereco_municipio       		as des_cidade
            ,       e.endereco_cep             		as num_cep
            ,       e.endereco_uf              		as des_sigla 
            ,       p.inscricaoestadual        		as num_insc_est

            ,       9                          		as flg_tipo_cobranca
            ,       0                          		as des_tratamento	
            ,       0                          		as des_profissao
            ,       0                          		as flg_integracao_01
            ,       0                          		as flg_integracao_02
            ,       coalesce(c.contato_email, 'administrativo@oxan.com.br') as des_email
            ,		1101                           	as eco_cod_loja
            ,		0 							   	as forma_reativar_credito 
            ,		'S' 						   	as flg_gera_evento_financeiro

            ,		'N' 						   	as flg_convenio
            ,		'N' 						   	as micro_empresa
            ,   	0                              	as categoria_cliente
            ,   	''                             	as num_fone
            ,		0                              	as forma_reativar_credito 
            ,		'S'                            	as flg_gera_evento_financeiro
            ,		'N'                            	as flg_convenio
            ,		'N'                            	as micro_empresa
            ,		'99'                           	as flg_sexo
            ,		'99'                           	as flg_est_civil
            ,		0                              	as flg_residencia
            ,		0                              	as flg_profissao
            ,		0                              	as flg_chq_especial
            ,		0                              	as flg_automovel
            ,		0                              	as flg_auto_alienado
            ,		0                              	as tipo_c_credito
            ,		0                              	as usuario
            ,		0                               as cod_banco 
            ,		0                               as flg_orginst
            ,       0                               as val_limite_credito
            ,       0                               as val_credito
            ,       0                               as val_debito
            ,       6                               as opcao_mensagem
            ,       0                               as val_limite_cheque
            ,       0                               as val_limite_cheque_utilizado
            ,       1                               as dia_ini_fatura
            ,       1                               as dia_fim_fatura
            ,       0                               as cod_plano_financeiro
            ,       'S'                             as flg_primeiro_acesso
            ,       '-'                             as cod_conta_sped
            ,       0                               as ctrl_envio_generico
            ,       0                               as flg_estrangeiro
            ,       0                               as flg_sugere_transportadora
            ,       'N'                             as flg_boletim
            ,       'N'                             as flg_crm_resgate_bonus
            ,       'N'                             as flg_crm_resgate_pontos
            ,       0                               as flg_pessoa_autorizada
            ,       'N'                             as flg_cooperado
            ,       'N'                             as flg_permitir_compra_webstore
            ,       'N'                             as flg_impedir_carga
            ,       'N'                             as flg_clube_cadcompleto
            ,       'N'                             as flg_clube_aceite
            ,       'N'                             as flg_telemarketing
            ,       'N'                             as flg_email
            ,       'N'                             as flg_sms
            ,       'N'                             as flg_catalogo
            ,       'N'                             as flg_politicamente_exposto
            ,       'N'                             as flg_terrorista
            ,       0                               as flg_integracao_ecommerce
            ,       0                               as flg_termo_fidelidade
            ,       0                               as flg_email_fidelidade
            ,       0                               as tipo_residencia
            ,       0                               as tipo_construcao
            ,       0                               as status_cheque
            ,       0                               as val_debito_cheque
            ,		case when coalesce(e.ibge_municipio_cd ,'50308') = '' then 
                        '50308'
                        else right(e.ibge_municipio_cd, 5)
                        end                    		as ibge_municipio_format_zanthus
        from 		tbparticipante p
        inner join 	tbparticipante_bluesoft b on p.cdparticipante = b.cdparticipante
        inner join  tbparticipante_endereco e on e.cdparticipante = p.cdparticipante and e.endereco_tipo_cd = 1
        left  join  tbparticipante_contato  c on c.cdparticipante = p.cdparticipante and c.contato_tipo_cd = 3
        WHERE 1 = 1
        and   b.bluesoftclientestatus = 1

        `;
    }
    static get(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let report = {};
            try {
                let myBase = new modelbase_1.clsBase();
                report = yield myBase.myDataBase.pag.DataGet(this.sql(parametro));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException('m0020_produto', 'reportProdutoOperacional', e);
            }
            finally {
                return report;
            }
        });
    }
}
exports.default = reportZanthusClientes;
