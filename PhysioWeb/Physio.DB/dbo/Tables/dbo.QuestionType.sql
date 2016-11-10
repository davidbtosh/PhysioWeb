CREATE TABLE [dbo].[QuestionType] (
    [Id]          INT          NOT NULL,
    [Code]        VARCHAR (3)  NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

