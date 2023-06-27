-- =============================================
-- Author:		Kevin A
-- Create date: 26/06/2023
-- Description:	Elimina un registro de la tabla tblExamen
--				Devuelve un codigo retorno y su descripcion
-- =============================================
CREATE PROCEDURE spEliminar
	-- Add the parameters for the stored procedure here
	@idExamen INT,
	@CodigoRetorno INT OUTPUT,
	@DescripcionRetorno VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		DELETE FROM tblExamen
		WHERE idExamen = @idExamen

		SET @CodigoRetorno = 0
		SET @DescripcionRetorno = 'Registro eliminado satisfactoriamente'
	END TRY
	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER()
		SET @DescripcionRetorno = ERROR_MESSAGE()
	END CATCH
END
