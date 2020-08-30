IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[FI_SP_DelCliente]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [FI_SP_DelCliente]
END
GO

CREATE PROC FI_SP_DelCliente
	@ID BIGINT
AS
BEGIN
	DELETE CLIENTES WHERE ID = @ID
END