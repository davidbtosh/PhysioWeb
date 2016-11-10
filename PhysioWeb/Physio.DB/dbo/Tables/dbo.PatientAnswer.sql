CREATE TABLE [dbo].[PatientAnswer] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [PatientId]       INT           NOT NULL,
    [QuestionId]      INT           NOT NULL,
    [QuestionnaireId] INT           NOT NULL,
    [Answer]          VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_QuestionAnswers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PatientAnswer_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK_PatientAnswer_PatientQuestionnaire] FOREIGN KEY ([QuestionnaireId]) REFERENCES [dbo].[PatientQuestionnaire] ([Id]),
    CONSTRAINT [FK_PatientAnswer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

