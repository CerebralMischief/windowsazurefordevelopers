CREATE TABLE [dbo].[PersonName] (
    [NameId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]    NVARCHAR (30)    NOT NULL,
    [SexOf]   NCHAR (6)        NOT NULL,
    [Surname] BIT              NOT NULL
);

