-- FUNCTION: public.r0001_0002_1011840_tarefas(integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.r0001_0002_1011840_tarefas(integer, integer, integer);



CREATE OR REPLACE FUNCTION public.f0001_11_1012017_sistema_login_acesso_tarefa(
	vsis_cd integer,
	vsis_us_seq integer,
	vsis_ta_cd integer)
    RETURNS TABLE(sis_ta_cd integer, sis_ta_descricao character varying) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE SqlCommand text:= '';
BEGIN

                /*Manutenção em 19/02/2026
                    Conferir se existe alguma indicação ao campo sis_cd da tabela tbsistema_tarefa, pois este campo 
                    será excluído no futuro. 

                    Uma Tarefa deve servir para quaisquer sistemas

                    A Tarefa será relacoinada ao sistema através da tabeal tbsistema_permissao

                */


   SqlCommand:= '	SELECT 		ta.sis_ta_cd
							,	ta.sis_ta_descricao 
					FROM 		TBSISTEMA_USUARIO 		us
					inner join  tbpessoa				ps on ps.cdpessoabluesoft = us.cdpessoabluesoft
					inner join  tbsistema_funcao 		fc on fc.sis_fc_cd = us.sis_fc_cd
					inner join  tbsistema_permissao     pm on pm.sis_fc_cd = fc.sis_fc_Cd and pm.sis_cd = fc.sis_cd
					inner join  tbsistema_acesso        ac on ac.sis_ac_cd = pm.sis_ac_cd and ac.sis_cd = pm.sis_cd 
					inner join  tbsistema_tarefa        ta on ta.sis_ta_cd = pm.sis_ta_cd  
					WHERE      	1 = 1
					AND 		ta.SIS_TA_CD <> 1
					and			pm.sis_cd = '  || cast(vsis_cd as varchar(10)) || '
					AND			us.sis_us_seq = ' || cast(vsis_us_seq as varchar(10)) || '
					and 		ta.sis_ta_Cd = '  || cast(vsis_ta_cd as varchar(10)) 
					;

   RETURN QUERY 
   EXECUTE SqlCommand;
END;
$BODY$;



