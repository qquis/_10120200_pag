SELECT f0011_90_1012019_tbparticipante_bluesoft_integ
                      (    sqlcommand:=  'REDSHIFT' 
                           , vcdpessoabluesoft:=  133507
                           , vcpf_cnpj:= '13430346800'
                           , vnome_razao:= 'ELIANA MARIA DA SILVA'
                           , vpessoajuridica:= 0
                           , vemail_main:= ''
                           , vnome_abreviado:= 'ELIANA MARIA DA SILV'
                           , vpf_sexo:= 'M'
                           , vpf_data_nascimento:= '1970-11-11'
                           , vendereco_cep:= 3585010
                           , vendereco_logradouro:= 'Rua Alfeneiro'
                           , vendereco_numero:= '269'
                           , vendereco_complemento:= ''
                           , vendereco_bairro:= 'Jardim Brasilia (Zona Leste)'
                           , vendereco_municipio:= 'Sao Paulo'
                           , vendereco_uf:= 'SP'
                           , vendereco_latitude:= -23.5606663
                           , vendereco_longitude:= -46.4898990
                           , vbluesoft_pessoa_status:= 1
                           , vbluesoft_pessoa_data_cadastro:= '2026-08-27'
                           , vbluesoftcliente:= 1
                           , vbluesoftvendedor:= 0
                           , vbluesoftfornecedor:= 0
                           , vbluesoftfabricante:= 0
                           , vbluesoftmotorista:= 0
                           , vcdgrupoeconomico:= 0
                           , vcdpessoabluesoft_vendedor:= 0
                           , vbluesoftclientestatus:= 0
                           , vbluesoftcliente_creditolimite_valor:= 0
                           , vbluesoftcliente_creditolimite_valor_reservado:= 0
                           , vbluesoftcliente_creditostatus_cd:= 0
                           , vbluesoftcliente_ramoatividade_cd:= 0
                           , vtipocliente:= ''
                           , vibge_municipio_cd:= ''
                           , vinscricaoestadual:= ''
                         );
select * from tbparticipante_bluesoft 	where cpf_cnpj like '%13430346800'					 