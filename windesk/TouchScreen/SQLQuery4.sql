CREATE TABLE marketing_cli_ae
	   ( seq					int identity(1,1)	,
		 nome					varchar(60)			,
		 fone_ddd				char(2)				,
		 fone_numero			varchar(10)			,
		 cep					char(8)				,
		 sexo					char(1)				,
		 estado_civil			char(1)				,
         e_mail					varchar(40)			,
         tipo_obs				char(1)				,
         observacao				text				,
		 dt_mov					datetime (getdate()),
		 	
		)
/*
sp_marketing_cli_ae
vw_marketing_cli_ae
*/

CREATE TABLE marketing_cli_tipo_obs 
       (tipo_obs char(1),
		descricao varchar(60)
		)
INSERT INTO marketing_cli_tipo_obs
values ('F' , 'FALTA DE PRODUTO NA LOJA' )

INSERT INTO marketing_cli_tipo_obs
values ('R', 'RECLAMAÇÃO GERAL' )

INSERT INTO marketing_cli_tipo_obs
values ('E', 'ELOGIO')
       
CREATE TABLE estado_civil
	  ( estado_civil char(1)		,
		descricao	 varchar(10)
	  )

INSERT INTO ESTADO_CIVIL VALUES ('S','SOLTEIRO')
INSERT INTO ESTADO_CIVIL VALUES ('C','CASADO')
INSERT INTO ESTADO_CIVIL VALUES ('D','DIVORCIADO')
INSERT INTO ESTADO_CIVIL VALUES ('N','NOIVO')
INSERT INTO ESTADO_CIVIL VALUES ('O','NAMORANDO')
INSERT INTO ESTADO_CIVIL VALUES ('V','VIUVO')


SELECT * FROM ESTADO_CIVIL
SELECT * FROM marketing_cli_ae