IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [tbCampaign] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Start] datetime2 NOT NULL,
    [End] datetime2 NOT NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_tbCampaign] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tbPerson] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Birth] datetime2 NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Mobile] nvarchar(max) NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_tbPerson] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [tbQuestion] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [CampaignId] int NOT NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_tbQuestion] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tbQuestion_tbCampaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [tbCampaign] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tbForm] (
    [Id] int NOT NULL IDENTITY,
    [CampaignId] int NOT NULL,
    [PersonId] int NOT NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_tbForm] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tbForm_tbCampaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [tbCampaign] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tbForm_tbPerson_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [tbPerson] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [tbAnswer] (
    [Id] int NOT NULL IDENTITY,
    [QuestionId] int NOT NULL,
    [FormId] int NOT NULL,
    [AnswerDescription] nvarchar(max) NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_tbAnswer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tbAnswer_tbForm_FormId] FOREIGN KEY ([FormId]) REFERENCES [tbForm] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tbAnswer_tbQuestion_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [tbQuestion] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_tbAnswer_FormId] ON [tbAnswer] ([FormId]);
GO

CREATE INDEX [IX_tbAnswer_QuestionId] ON [tbAnswer] ([QuestionId]);
GO

CREATE INDEX [IX_tbForm_CampaignId] ON [tbForm] ([CampaignId]);
GO

CREATE INDEX [IX_tbForm_PersonId] ON [tbForm] ([PersonId]);
GO

CREATE INDEX [IX_tbQuestion_CampaignId] ON [tbQuestion] ([CampaignId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221002001221_Initial', N'6.0.9');
GO

COMMIT;
GO

