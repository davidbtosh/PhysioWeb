CREATE TABLE [dbo].[PatientQuestionnaire] (
    [Id]                INT  IDENTITY (1, 1) NOT NULL,
    [QuestionSetId]     INT  NOT NULL,
    [PatientId]         INT  NOT NULL,
    [QuestionnaireDate] DATE NOT NULL,
    CONSTRAINT [PK_PatientQuestion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PatientQuestionnaire_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient] ([Id]),
    CONSTRAINT [FK_PatientQuestionnaire_QuestionSet] FOREIGN KEY ([QuestionSetId]) REFERENCES [dbo].[QuestionSet] ([Id])
);

