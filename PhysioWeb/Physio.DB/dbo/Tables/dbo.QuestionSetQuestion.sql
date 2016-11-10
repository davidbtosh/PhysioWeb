CREATE TABLE [dbo].[QuestionSetQuestion] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [QuestionSetId] INT NOT NULL,
    [QuestionId]    INT NOT NULL,
    CONSTRAINT [PK_QuestionSetQuestion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QuestionSetQuestion_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]),
    CONSTRAINT [FK_QuestionSetQuestion_QuestionSet] FOREIGN KEY ([QuestionSetId]) REFERENCES [dbo].[QuestionSet] ([Id])
);

