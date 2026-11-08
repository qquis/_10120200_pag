-- FUNCTION: public.f0050_10_1012006_faturamento_bluesoft_crud(character varying, integer, integer, integer, integer, integer, integer, integer, integer, integer, integer, integer, character varying, character varying, date, date, date, integer, numeric, numeric, character varying)

-- DROP FUNCTION IF EXISTS public.f0050_10_1012006_faturamento_bluesoft_crud(character varying, integer, integer, integer, integer, integer, integer, integer, integer, integer, integer, integer, character varying, character varying, date, date, date, integer, numeric, numeric, character varying);




CREATE OR REPLACE 
-- drop 
FUNCTION public.f0051_10_1012017_faturamento_vip_crud(
		sqlcommand character varying
	,	v_id int
	,	v_cliente_id int
	,   v_codigo int 
  	,	v_data_entrega TIMESTAMP
  	,	v_data_entregue TIMESTAMP
  	,	v_data_faturamento TIMESTAMP
	,   v_compra_status_id int
	,   v_tipo_entrega_id int
	,   v_tipo_fiscal varchar(10)
	,   v_qtd_itens int
	,   v_qtd_produtos int
	,   v_volumes_frios int
	,   v_volumes_comuns int
	,   v_tipo_pedido varchar(30)
	,   v_created TIMESTAMP
	,   v_modified TIMESTAMP
	,   v_valor_final numeric(13,2)

	)

    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
begin
		insert into tbfaturamento_vip (
				id 
			,	cliente_id
			,   codigo
			,	data_entrega
			,	data_entregue
			,	data_faturamento
			,   compra_status_id
			,   tipo_entrega_id
			,   tipo_fiscal
			,   qtd_itens
			,   qtd_produtos
			,   volumes_frios
			,   volumes_comuns
			,   tipo_pedido
			,   created
			,   modified
			,   valor_final 
				)
		SELECT  
			v_id
		,	v_cliente_id
		,	v_codigo
		,	v_data_entrega
		,	v_data_entregue	
		,	v_data_faturamento
		,   v_compra_status_id
		,   v_tipo_entrega_id
		,   v_tipo_fiscal
		,   v_qtd_itens
		,   v_qtd_produtos
		,   v_volumes_frios
		,   v_volumes_comuns
		,   v_tipo_pedido	
		,   v_created
		,   v_modified
		,   v_valor_final 
		WHERE NOT EXISTS (SELECT 1 FROM tbfaturamento_vip WHERE id = v_id)
		;
				

		

		UPDATE tbfaturamento_vip
		SET
			cliente_id = v_cliente_id,
			codigo = v_codigo,
			data_entrega = v_data_entrega,
			data_entregue = v_data_entregue,	
			data_faturamento = v_data_faturamento,
			compra_status_id = v_compra_status_id,
			tipo_entrega_id = v_tipo_entrega_id,
			tipo_fiscal = v_tipo_fiscal,
			qtd_itens = v_qtd_itens,
			qtd_produtos = v_qtd_produtos,
			volumes_frios = v_volumes_frios,
			volumes_comuns = v_volumes_comuns,
			tipo_pedido = v_tipo_pedido,
			created = v_created,
			modified = v_modified,
			valor_final = v_valor_final,

			dtlog_update = current_timestamp
		WHERE id = v_id
		
		;



end;
$BODY$;

