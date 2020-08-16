
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/16/2020 21:23:59
-- Generated from EDMX file: D:\Users\Dobi\Documents\Visual Studio 2019\Projects\EmployeeSurvey\EmployeeSurvey.Data\Model\EmployeeSurveyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EmployeeSurvey];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameFirst] nvarchar(max)  NOT NULL,
    [NameLast] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SurveySet'
CREATE TABLE [dbo].[SurveySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExperienceYears] int  NOT NULL,
    [CurrentPosition] nvarchar(max)  NOT NULL,
    [SeniorityLevel] int  NOT NULL,
    [EmployeeSurvey_Survey_Id] int  NULL
);
GO

-- Creating table 'ProgrammingLanguageSet'
CREATE TABLE [dbo].[ProgrammingLanguageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KnownLanguageSet'
CREATE TABLE [dbo].[KnownLanguageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProgrammingLanguage_Id] int  NULL,
    [Survey_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SurveySet'
ALTER TABLE [dbo].[SurveySet]
ADD CONSTRAINT [PK_SurveySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgrammingLanguageSet'
ALTER TABLE [dbo].[ProgrammingLanguageSet]
ADD CONSTRAINT [PK_ProgrammingLanguageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KnownLanguageSet'
ALTER TABLE [dbo].[KnownLanguageSet]
ADD CONSTRAINT [PK_KnownLanguageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeSurvey_Survey_Id] in table 'SurveySet'
ALTER TABLE [dbo].[SurveySet]
ADD CONSTRAINT [FK_EmployeeSurvey]
    FOREIGN KEY ([EmployeeSurvey_Survey_Id])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeSurvey'
CREATE INDEX [IX_FK_EmployeeSurvey]
ON [dbo].[SurveySet]
    ([EmployeeSurvey_Survey_Id]);
GO

-- Creating foreign key on [ProgrammingLanguage_Id] in table 'KnownLanguageSet'
ALTER TABLE [dbo].[KnownLanguageSet]
ADD CONSTRAINT [FK_KnownLanguageProgrammingLanguage]
    FOREIGN KEY ([ProgrammingLanguage_Id])
    REFERENCES [dbo].[ProgrammingLanguageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnownLanguageProgrammingLanguage'
CREATE INDEX [IX_FK_KnownLanguageProgrammingLanguage]
ON [dbo].[KnownLanguageSet]
    ([ProgrammingLanguage_Id]);
GO

-- Creating foreign key on [Survey_Id] in table 'KnownLanguageSet'
ALTER TABLE [dbo].[KnownLanguageSet]
ADD CONSTRAINT [FK_KnownLanguageSurvey]
    FOREIGN KEY ([Survey_Id])
    REFERENCES [dbo].[SurveySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnownLanguageSurvey'
CREATE INDEX [IX_FK_KnownLanguageSurvey]
ON [dbo].[KnownLanguageSet]
    ([Survey_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------