IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[FI_SP_IncBeneficiario]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [FI_SP_IncBeneficiario]
END
GO

CREATE PROC FI_SP_IncBeneficiario
    @NOME          VARCHAR (50) ,
    @IDCLIENTE     BIGINT,
	@CPF		   VARCHAR (15)
AS
BEGIN
	INSERT INTO BENEFICIARIOS (NOME, IDCLIENTE, CPF) 
	VALUES (@NOME, @IDCLIENTE,@CPF)

	SELECT SCOPE_IDENTITY()
END