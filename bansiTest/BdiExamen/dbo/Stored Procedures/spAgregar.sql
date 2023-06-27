-- =============================================
-- Author:		Kevin A
-- Create date: 26/06/2023
-- Description: Insertar un registro en la tabla tblExamen. 
--				Devuelve un codigo de retorno y su descricion
-- =============================================
CREATE PROCEDURE spAgregar 
	-- Add the parameters for the stored procedure here
	@idExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
	@DescripcionRetorno VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		INSERT INTO tblExamen(idExamen, Nombre, Descripcion)
		VALUES (@idExamen, @Nombre, @Descripcion)

		SET @CodigoRetorno = 0
		SET @DescripcionRetorno = 'Registro insertado satisfactoriamente'
	END TRY
	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER()
		SET @DescripcionRetorno = ERROR_MESSAGE()
	END CATCH
END
