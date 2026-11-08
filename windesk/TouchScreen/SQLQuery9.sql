ALTER PROC sp_marketing_cli_ae 
	   @TYPE_STEP		CHAR(6)				,
	   @NOME			VARCHAR(60)			,
	   @FONE_DDD		CHAR(2)				,
	   @FONE_NUMERO		VARCHAR(10)			,
	   @CEP				CHAR(8)				,
	   @SEXO			CHAR(1)				,
	   @ESTADO_CIVIL	VARCHAR(10)			,
	   @E_MAIL			VARCHAR(40)			,
	   @TIPO_OBS		CHAR(60)			,
	   @OBSERVACAO		TEXT				
   	
AS

	DECLARE @TIPO_OBS_CODIGO CHAR(1)
	DECLARE @ESTADO_CIVIL_CODIGO CHAR(1)
	
	SELECT  @TIPO_OBS_CODIGO = ( SELECT TIPO_OBS 
										FROM marketing_cli_tipo_obs 
										WHERE descricao = @TIPO_OBS );

	SELECT  @ESTADO_CIVIL_CODIGO   = ( SELECT estado_civil  
										FROM estado_civil 
										WHERE descricao = @ESTADO_CIVIL );										
	


	SELECT @TYPE_STEP = UPPER(@TYPE_STEP)
	IF ( @TYPE_STEP = 'INSERT' )
	BEGIN
		INSERT INTO marketing_cli_ae
		   ( nome, 
			 fone_ddd, 
			 fone_numero,
			 cep, 
			 sexo,
			 estado_civil,
			 e_mail,
			 tipo_obs,
			 observacao )
			
		VALUES  ( @NOME						,
				  @FONE_DDD					,
				  @FONE_NUMERO				,
				  @CEP						,		
				  @SEXO						,
			      @ESTADO_CIVIL_CODIGO 		,
				  @E_MAIL					,
				  @TIPO_OBS_CODIGO 			,
				  @OBSERVACAO	
                )
	END


/*
EXEC sp_marketing_cli_ae 'INSERT' ,'ELIAS DA SILVA', '11','27489072','08285250','M','S','eliassilva@uol.com.br','E','LOJA MUITO BOA'
EXEC sp_marketing_cli_ae 'INSERT' ,'ELIAS teste 1', NULL,'27489072','08285250','M','S','eliassilva@uol.com.br','E','teste 1'
SELECT * FROM marketing_cli_ae
DELETE FROM marketing_cli_ae WHERE seq = 3
*/