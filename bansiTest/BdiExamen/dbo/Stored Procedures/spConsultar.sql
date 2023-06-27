-- =============================================
-- Author:		Kevin A
-- Create date: 26/06/2023
-- Description:	Busca los campos que cumplan con el nombre y descripcion dada
--				Devuelve la informacion que cumpla los criterios
-- =============================================
CREATE PROCEDURE spConsultar
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255)
AS
BEGIN
	SELECT * 
	FROM tblExamen
	WHERE Nombre = @Nombre
	  AND Descripcion = @Descripcion; 
END
