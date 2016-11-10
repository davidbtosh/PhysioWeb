CREATE TABLE [dbo].[Patient] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50) NULL,
    [LastName]     VARCHAR (50) NULL,
    [DoB]          DATE         NULL,
    [GenderTypeId] INT          NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Patient_GenderType] FOREIGN KEY ([GenderTypeId]) REFERENCES [dbo].[GenderType] ([Id])
);




