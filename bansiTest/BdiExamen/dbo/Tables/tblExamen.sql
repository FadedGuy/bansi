CREATE TABLE [dbo].[tblExamen] (
    [idExamen]    INT           NOT NULL,
    [Nombre]      VARCHAR (255) NULL,
    [Descripcion] VARCHAR (255) NULL,
    CONSTRAINT [PK_tblExamen] PRIMARY KEY CLUSTERED ([idExamen] ASC)
);

