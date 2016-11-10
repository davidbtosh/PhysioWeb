CREATE TABLE [dbo].[Question] (
    [Id]                   INT           NOT NULL,
    [QuestionTitle]        VARCHAR (500) NOT NULL,
    [QuestionTypeId]       INT           NULL,
    [QuestionAbbreviation] VARCHAR (50)  NULL,
    [QuestionHint]         VARCHAR (100)  NULL,
    [UIcaption]            VARCHAR (20)  NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY ([QuestionTypeId]) REFERENCES [dbo].[QuestionType] ([Id])
);





