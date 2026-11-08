/*
do $$
begin 

end$$	
*/

1) LOGIN 
1.1 O Pag desktop acessa a funcionalidade backend
1.2 A Funcionalidade backend acessa o postgre
1.3 Função postre: f0001_02_1012015_sistema_login

2) COnsulta de Permissoes backend
Query diretamente no backend

3) Consulta de permissoes no DESKTOP 
F0001_10_1012011_sistema_login_acesso_list 

select * from tbparticipante_vip



select 	f.op_cdoperacao 
	,   o.op_descricao 
	,	f.numeropedido 
	,   f.numeropedido_fv 
	,   f.cdpessoabluesoft_cliente 
	,   f.fat_blue_status_cd
	,   f.fat_blue_tipo_cd 
	,   f.cdpessoabluesoft_vendedor
	,   f.data_emissao 
	,   f.data_faturamento

from 	tbfaturamento_bluesoft f
left join tboperacao o on o.op_cdoperacao = f.op_cdoperacao
where   1=1
  and   f.data_faturamento >= '2026-01-13'
  and   f.data_faturamento <= '2026-01-13'

select * from tbfaturamento_bluesoft_status|

select * from tboperacao


select 	op_cdoperacao 
	,	dataemissao 
	,   datafaturamento 
	,   numeropedido 
	,   numeropedido_fv 
	,   df_nf_seq_blue
	,   numeronfe 
	,   sat_ecf 
	,   cupomfiscal 
	,   seqfaturamento 
	,   seqfaturamentoorigem 
	,   *
from 	tbfaturamento_controle 
where 	datafaturamento >= '2025-01-13'
and     datafaturamento <= '2025-01-13'
limit 10

select * from tbfaturamentostatus
select * from tbfaturamentostatusitem limit 10


