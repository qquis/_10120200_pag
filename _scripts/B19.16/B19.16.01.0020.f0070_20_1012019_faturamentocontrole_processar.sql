DROP FUNCTION IF EXISTS public.f0070_20_1012019_faturamentocontrole_processar (vdata_processamento date);
CREATE OR REPLACE FUNCTION public.f0070_20_1012019_faturamentocontrole_processar
(   
    vdata_processamento date
    
)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
  declare  NUMERO_seqfaturamento_uuid VARCHAR(12);
  DECLARE  NUMERO_faturamento_controle_seq INT;
begin
          ----- TIPO VENDA INICIAL - VENDA FATURADA 
			insert into   tbfaturamento_controle 
					(
							seqfaturamento_uuid
						,	dataemissao 
						,	datafaturamento 
						,	numeropedido
						,	numeropedido_fv 
						,	df_nf_seq_blue
						,	numeronfe 
						,	sat_ecf 
						,	cupomfiscal 
						,	fat_controle_tipo_cd
						,	seqfaturamento
						,	seqfaturamentoorigem
						,	seqfaturamento_old
						,	seqfaturamento_origem_old
						,	cdpessoabluesoft_cliente
						,   cdpessoabluesoft_vendedor
						,	op_cdoperacao 
                        ,   processamento_pendente
					)
			select 	
				       		cast(gen_random_uuid () as varchar(3)) || TO_CHAR(fa.numeropedido, '0000000')
						,	fa.data_emissao
						,	nf.df_data_emissao as  datafaturamento
						,	fa.numeropedido 
						,	fa.numeropedido_fv
						,	fa.df_nf_seq_blue  
						,	coalesce(nf.df_nf_numero,0) as df_nf_numero 
						,	0 as sat_ecf 
						,	0 as cupomfiscal 
						,	1 as fat_controle_tipo_cd ----- TIPO VENDA INICIAL 
						,	0 as seqfaturamento
						,	0 as seqfaturamentoorigem
						,	0 as seqfaturamento_old
						,	0 as seqfaturamento_origem_old
						,	fa.cdpessoabluesoft_cliente
						,	case when op_cdoperacao = 1 then fa.cdpessoabluesoft_vendedor else 1 end as cdpessoabluesoft_vendedor
						,	fa.op_cdoperacao 
                        ,   1 as processamento_pendente
				from 			tbfaturamento_bluesoft				fa
				inner join 		tbfaturamento_bluesoft_status		st on st.fat_blue_status_cd = fa.fat_blue_status_cd
				inner  join     tbdocumentofiscal 					nf on nf.df_nf_seq_blue = fa.df_nf_seq_blue and nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente
				where	1 = 1
				and		fa.op_cdoperacao in(1,2,4)
				and     nf.df_data_cancelamento = '1900-01-01'
				and     nf.df_cdpessoabluesoft_cancelamento = 0 
				and     nf.df_entrada_saida = 'S'
				and		fa.fat_blue_status_cd 
								in (
										20, -- Aguardando Analise Gerencial
										25, -- Em Analise Gerencial
										27, -- Em Analise de Credito
										30, -- Fechado
										40, -- Em sepracao 
										45, -- Separado
										50, -- Faturando
										55, -- FATURADO POR NOTA FISCAL
										70,  -- ENTREGUE
										90   -- CANCELADO MAS COM NOTA FISCAL EMITIDA. 
				
								)
                and     nf.df_data_emissao = vdata_processamento								
				/*and		coalesce(fa.df_nf_seq_blue_dev,0) = 0*/
				and		not exists ( 	select 1 
										from 	tbfaturamento_controle aa
										where 	aa.numeropedido = fa.numeropedido
										and		aa.numeropedido_fv = fa.numeropedido_fv 
										and		aa.op_cdoperacao = fa.op_cdoperacao 
										and		aa.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
										and     aa.fat_controle_tipo_cd = 1
									)

		;


          ----- RECUSAS 

	insert into   tbfaturamento_controle 
					(
							seqfaturamento_uuid
						,	dataemissao 
						,	datafaturamento 
						,	numeropedido
						,	numeropedido_fv 
						,	df_nf_seq_blue
						,	numeronfe 
						,	sat_ecf 
						,	cupomfiscal 
						,	fat_controle_tipo_cd
						,	seqfaturamento
						,	seqfaturamentoorigem
						,	seqfaturamento_old
						,	seqfaturamento_origem_old
						,	cdpessoabluesoft_cliente
						,   cdpessoabluesoft_vendedor
						,	op_cdoperacao 
                        ,   processamento_pendente
					)
			select 	
				       		cast(gen_random_uuid () as varchar(3)) || TO_CHAR(fa.numeropedido, '0000000')
						,	fa.data_emissao
						,	nf.df_data_emissao as  datafaturamento
						,	fa.numeropedido 
						,	fa.numeropedido_fv
						,	fa.df_nf_seq_blue_dev  
						,	coalesce(nf.df_nf_numero,0) as df_nf_numero 
						,	0 as sat_ecf 
						,	0 as cupomfiscal 
						,	2 as fat_controle_tipo_cd ----- TIPO RECUSA = 2
						,	0 as seqfaturamento
						,	0 as seqfaturamentoorigem
						,	0 as seqfaturamento_old
						,	0 as seqfaturamento_origem_old
						,	fa.cdpessoabluesoft_cliente
						,	case when op_cdoperacao = 1 then fa.cdpessoabluesoft_vendedor else 1 end as cdpessoabluesoft_vendedor
						,	fa.op_cdoperacao 
                        ,   1 as processamento_pendente
				from 			tbfaturamento_bluesoft				fa
				inner join 		tbfaturamento_bluesoft_status		st on st.fat_blue_status_cd = fa.fat_blue_status_cd
				inner  join     tbdocumentofiscal 					nf 
				                                                on nf.df_nf_seq_blue = fa.df_nf_seq_blue_dev --->>> NF DEVOLUÇÃO DO PROCESSAMENTO
																and nf.cdpessoabluesoft = fa.cdpessoabluesoft_cliente
																and nf.df_nf_tipo = 27
				where	1 = 1
				and		fa.op_cdoperacao in(1,2,4)
				and     nf.df_data_cancelamento = '1900-01-01'
				and     nf.df_cdpessoabluesoft_cancelamento = 0 
				and     nf.df_entrada_saida = 'E'
				and		fa.fat_blue_status_cd 
								in (
										20, -- Aguardando Analise Gerencial
										25, -- Em Analise Gerencial
										27, -- Em Analise de Credito
										30, -- Fechado
										40, -- Em sepracao 
										45, -- Separado
										50, -- Faturando
										55, -- FATURADO POR NOTA FISCAL
										70,  -- ENTREGUE
										90   -- CANCELADO MAS COM NOTA FISCAL EMITIDA. 
				
								)
                and     nf.df_data_emissao = vdata_processamento							
				and		not exists ( 	select 1 
										from 	tbfaturamento_controle aa
										where 	aa.numeropedido = fa.numeropedido
										and		aa.numeropedido_fv = fa.numeropedido_fv 
										and		aa.op_cdoperacao = fa.op_cdoperacao 
										and		aa.cdpessoabluesoft_cliente = fa.cdpessoabluesoft_cliente
										and     aa.fat_controle_tipo_cd = 2
									)

		;







































	EXCEPTION
    WHEN OTHERS THEN
        RAISE EXCEPTION 'Erro capturado: %', SQLERRM
	;
end;
$function$
