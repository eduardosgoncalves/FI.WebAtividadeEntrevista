﻿IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[FI_SP_IncClienteV3]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [FI_SP_IncClienteV3]
END
GO

CREATE PROC FI_SP_IncClienteV3
    @NOME          VARCHAR (50) ,
    @SOBRENOME     VARCHAR (255),
    @NACIONALIDADE VARCHAR (50) ,
    @CEP           VARCHAR (9)  ,
    @ESTADO        VARCHAR (2)  ,
    @CIDADE        VARCHAR (50) ,
    @LOGRADOURO    VARCHAR (500),
    @EMAIL         VARCHAR (2079),
    @TELEFONE      VARCHAR (15),
	@CPF		   VARCHAR (15)
AS
BEGIN
	INSERT INTO CLIENTES (NOME, SOBRENOME, NACIONALIDADE, CEP, ESTADO, CIDADE, LOGRADOURO, EMAIL, TELEFONE, CPF) 
	VALUES (@NOME, @SOBRENOME,@NACIONALIDADE,@CEP,@ESTADO,@CIDADE,@LOGRADOURO,@EMAIL,@TELEFONE,@CPF)

	SELECT SCOPE_IDENTITY()
END