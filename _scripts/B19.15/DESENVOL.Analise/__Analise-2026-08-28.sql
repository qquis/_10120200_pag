/*
	flg_enviar_carga	= 'S'
	loja_cadastro		= 1
	cod_cliente			= 'CAMPO'


	
	status_cliente		= 1 
	origem_cadastro		= 0 
	flg_fidelidade		= 'S'
	senha_pdv			= VER O QUE E 
	situacao_cadastro	= 1
	flg_habilitado_compra = 'S'	
	flg_revenda			= CONSULTA NO BANCO
	id_municipio		= ANALISE 
	numero				= 
	flg_tipo_cobranca	= 
	categoria_cliente	=
	compl_endereco		= 
,	cod_pais = 1058	
,	num_insc_est		= INSCRICAO ESTADUAL 
,	num_fone			=
,	des_cidade			= 
,	num_cep				= 
,	des_bairro			=	
,	num_cgc				=
,	des_endereco		=

,	num_fone_num		= 
,	des_tratamento		= 0
,	des_profissao		= 0 
,	flg_integracao_01	= 0 
,	flg_integracao_02	= 0 

,	forma_reativar_credito	= 0 
,	flg_gera_evento_financeiro	'S'
,	flg_empresa 		= 'S'
,	flg_convenio		= 'N'
,	des_sigla			= 'SP'
,	micro_empresa		= 'N'
,	des_fantasia		= 'CAMPO'
,	des_email			= 'CAMPO'
,	flg_sexo			= '99'
,	flg_est_civil		= '99'
,	flg_residencia		= 0 
,	flg_profissao		= 0 
,	flg_chq_especial	= 0
,	flg_automovel		= 0 
,	flg_auto_alienado	= 0 
,	tipo_c_credito		= 0 
,	usuario				= 0 
,	dta_alteracao		= DATA ATUAL 
,	dta_cadastro		= DATA ATUAL 
,	cod_banco			= 0 
,	flg_orginst			= 0 
,	val_limite_credito	= 0 
,	val_credito			= 0 
,	val_debito			= 0 
, 	opcao_mensagem		= 6 
,	val_limite_cheque	= 0 
,	val_limite_cheque_utilizado = 0 
,	dia_ini_fatura		= 1
,	dia_fim_fatura		= 1
,	cod_plano_financeiro = 0 
,	flg_primeiro_acesso = 'S'
,	cod_conta_sped = '-'
,	ctrl_envio_generico = 0 
,	flg_estrangeiro = 0 
,	flg_sugere_transportadora = 0 
,	flg_boletim = 'N'
,	flg_crm_resgate_bonus = 'N'	
,	flg_crm_resgate_pontos = 'N'	
,	flg_pessoa_autorizada = 0
,	flg_cooperado= 'N'			
,	flg_permitir_compra_webstore = 'N'			
,	flg_impedir_carga = 'N'
,	flg_clube_cadcompleto = 'N'
,	flg_clube_aceite = 'N'
,	flg_telemarketing	= 'N'
,	flg_email			= 'N'
,	flg_sms				= 'N'
,	flg_catalogo		= 'N'
,	flg_politicamente_exposto = 'N'
,	flg_terrorista = 'N'
,	flg_integracao_ecommerce	= 0
,	flg_termo_fidelidade		= 0
,	flg_email_fidelidade		= 0
,	tipo_residencia				= 0
,	tipo_construcao				= 0
,	eco_cod_loja = 1101		
,	status_cheque			= 0
,	val_debito_cheque		= 0

*/

select * from tbparticipante_bluesoft where tipocliente is not null

SELECT 		b.cdpessoabluesoft				as cod_cliente
	,		b.nome_razao            		as des_cliente 
	,       b.nome_abreviado        		as des_fantasia 
	,       p.cpf_cnpj              		as num_cgc
	,		case when p.pessoajuridica = 1
	             then 'S' 
				 else 'N' 
				 end			   			as flg_empresa
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
	,		e.ibge_municipio_cd        		as id_municipio
	,       e.endereco_numero          		as numero 
	,       e.endereco_bairro          		as des_bairro

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
	,		'S'                            	as flg_empresa
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

from 		tbparticipante p
inner join 	tbparticipante_bluesoft b on p.cdparticipante = b.cdparticipante
inner join  tbparticipante_endereco e on e.cdparticipante = p.cdparticipante and e.endereco_tipo_cd = 1
left  join  tbparticipante_contato  c on c.cdparticipante = p.cdparticipante and c.contato_tipo_cd = 3


select * from tbparticipante_endereco_tipo limit 10
select * from tbparticipante_endereco limit 10
select * from tbparticipante_contato limit 10
select * from tbparticipante_contato_tipo limit 10
