"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class scriptAtualizaCargaCompletaTabMercadoria {
    static ScriptExecute(myDataBase_SERVER) {
        let sqlscript = ``;
        if (myDataBase_SERVER == 'ZANTHUSSQLSERVER') {
            sqlscript = this.ZanthusSQLServer_CRUD();
        }
        return sqlscript;
    }
    static ZanthusSQLServer_CRUD() {
        let data_hoje = new Date();
        let cod_voucher = Tools_1.default._datemomentDateToStr(data_hoje, "YYYYMMDD");
        return `
                    DELETE FROM ZeusRetail.DBO.Tab_MERCADORIA;
                    INSERT INTO		ZeusRetail.DBO.Tab_MERCADORIA
                        (		cod_loja													
                            ,	controle 													
                            ,	cod_mercadoria 												
                            ,	descricao 													
                            ,	cod_departamento 											
                            ,	cod_tributacao_mercadoria									
                            ,	cod_tecla 													
                            ,	percentual_desc_venda										
                            ,	permissao_venda  											
                            ,	percentual_reduz_b_calculo									
                            ,	indica_merc_peso_variavel									
                            ,	custo_unitario 												
                            ,	grupo_garantia												
                            ,	fator_seguranca_venda_estoque								
                            ,	unidade_venda												
                                                
                            ,	margem_mercadoria 											
                            ,	quantidade_embalagem 										
                            ,	cod_fornecedor												
                            ,	custo_moeda_estavel											
                            ,	aliquota_icms 												
                            ,	quantidade_bonus_venda										
                            ,	quantidade_max_preco_promo 									
                            ,	valor_total_preco_promocao 									
                            ,	custo_contabil 												
                            ,	quantidade_maxima_venda 									
                            ,	multiplica_pontos_valor_liq 								
                            ,	quantidade_pontos_venda 									
                            ,	cod_situacao_tributaria 									
                            ,   data_cadastro 												
                            ,	data_ultima_alteracao 										
                            ,	cod_ncm														
                            ,	flg_troca_reembolso											
                            ,	fator_preco_etiqueta										
                            ,	texto_fator_preco_etiqueta									
                            ,	qtd_etiqueta												
                            ,	flag_serie_pdv
                            ,	flag_controle_consumidor
                            ,	flg_confere_kit
                            ,	imprime_codigo_barras
                            ,	flg_confere_peso
                            ,	flg_venda_exclusiva
                            ,	flg_duplo_check
                            ,	flg_mobile
                            ,	flg_item_premiado
                            ,	flg_prod_patrocinado
                            ,	flg_rastrear
                            ,	flg_integracao_01
                            ,	flg_integracao_02
                            ,	alternativo_especial
                            ,	flg_proibe_fidelizacao_selo
                            ,	flg_fidelizacao_patrocinado
                            ,	flg_fidelizacao_marca_propria
                            ,	flg_artigos_promocionais
                            ,	flg_proibe_selfcheckout
                            ,	flg_converte_estoque
                            ,	flg_forma_decomposicao
                            ,	flg_combustivel
                            ,	flg_rastreamento
                            ,	indice_vinculado_finalizadora
                            ,	flg_premiacao
                            ,	flg_webstore
                            ,	flg_sem_gtin
                            ,	flg_venda_totem
                            ,	flg_comanda
                            ,	flg_certificado
                            ,	data_modo_preco 		
                            ,	modo_preco 
                            ,	CEST 
                            )
            SELECT			DISTINCT
                                COD_LOJA 
                            ,	CONTROLE 
                            ,	COD_MERCADORIA 
                            ,	DESCRICAO 
                            ,	COD_DEPARTAMENTO
                            ,	COD_TRIBUTACAO_MERCADORIA
                            ,	COD_TECLA
                            ,	PERCENTUAL_DESC_VENDA
                            ,	PERMISSAO_VENDA 
                            ,	PERCENTUAL_REDUZ_B_CALCULO
                            ,	INDICA_MERC_PESO_VARIAVEL 
                            ,	CUSTO_UNITARIO 
                            ,	GRUPO_GARANTIA 
                            ,	FATOR_SEGURANCA_VENDA_ESTOQUE 
                            ,	UNIDADE_VENDA 
                            ,	MARGEM_MERCADORIA
                            ,	QUANTIDADE_EMBALAGEM
                            ,	COD_FORNECEDOR 
                            ,	CUSTO_MOEDA_ESTAVEL
                            ,   ALIQUOTA_ICMS 
                            ,	QUANTIDADE_BONUS_VENDA 
                            ,	QUANTIDADE_MAX_PRECO_PROMO
                            ,	VALOR_TOTAL_PRECO_PROMOCAO
                            ,	CUSTO_CONTABIL 
                            ,	QUANTIDADE_MAXIMA_VENDA
                            ,	MULTIPLICA_PONTOS_VALOR_LIQ
                            ,	QUANTIDADE_PONTOS_VENDA 
                            ,	COD_SITUACAO_TRIBUTARIA 
                            ,	DATA_CADASTRO 
                            ,	DATA_ULTIMA_ALTERACAO 
                            ,	COD_NCM
                            ,	flg_troca_reembolso						=	'S'
                            ,	fator_preco_etiqueta					=	1
                            ,	texto_fator_preco_etiqueta				=	1
                            ,	qtd_etiqueta							=	1
                            ,	flag_serie_pdv							=	0	
                            ,	flag_controle_consumidor				=	0
                            ,	flg_confere_kit							=	0
                            ,	imprime_codigo_barras					=	0
                            ,	flg_confere_peso						=	0
                            ,	flg_venda_exclusiva						=	0
                            ,	flg_duplo_check							=	0
                            ,	flg_mobile								=	0
                            ,	flg_item_premiado						=	0
                            ,	flg_prod_patrocinado					=	0
                            ,	flg_rastrear							=	0
                            ,	flg_integracao_01						=	0
                            ,	flg_integracao_02						=	0
                            ,	alternativo_especial					=	0
                            ,	flg_proibe_fidelizacao_selo				=	0
                            ,	flg_fidelizacao_patrocinado				=	0
                            ,	flg_fidelizacao_marca_propria			=	0
                            ,	flg_artigos_promocionais				=	0
                            ,	flg_proibe_selfcheckout					=	0
                            ,	flg_converte_estoque					=	0
                            ,	flg_forma_decomposicao					=	0
                            ,	flg_combustivel							=	0
                            ,	flg_rastreamento						=	0
                            ,	indice_vinculado_finalizadora			=	0
                            ,	flg_premiacao							=	0
                            ,	flg_webstore							=	0
                            ,	flg_sem_gtin							=	0
                            ,	flg_venda_totem							=	'N'
                            ,	flg_comanda								=	'N'
                            ,	flg_certificado							=	'N'
                            ,	DATA_MODO_PRECO							= NULL  
                            ,	modo_preco								= '1'
                            ,	CEST 
                            
                    from POSTSQL.oxan.[public].tbzanthustab_mercadoria	
                    where		cod_mercadoria		 not in ( 	select cod_mercadoria from ZeusRetail.DBO.Tab_MERCADORIA )	
                
                `;
    }
}
exports.default = scriptAtualizaCargaCompletaTabMercadoria;
