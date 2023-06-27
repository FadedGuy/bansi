-- =============================================
-- Author:		Kevin A
-- Create date: 26/06/2023
-- Description:	Actualizar un registro de la tabla tblExamen.
--				Devuelve un codigo de retorno y su descripcion
-- =============================================
CREATE PROCEDURE spActualizar 
	@idExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
	@DescripcionRetorno VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		UPDATE tblExamen
		SET Nombre = @Nombre,
			Descripcion = @Descripcion
		WHERE idExamen = @idExamen

		SET @CodigoRetorno = 0
		SET @DescripcionRetorno = 'Registro actualizado satisfactoriamente'
	END TRY
	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER()
		SET @DescripcionRetorno = ERROR_MESSAGE()
	END CATCH
END

