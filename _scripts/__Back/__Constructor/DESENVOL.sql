delete from tbnotificacao_participante where cdparticipante not in (15206,122338,122463 )
;
update tbparticipante set celular_numero = '994299919'
where cdparticipante in ( select cdparticipante from tbnotificacao_participante )
