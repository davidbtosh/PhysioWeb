CREATE TABLE [dbo].[GenderType] (
    [Id]          INT         NOT NULL,
    [Code]        VARCHAR (3) NULL,
    [Description] VARCHAR (6) NOT NULL,
    CONSTRAINT [PK_GenderType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

