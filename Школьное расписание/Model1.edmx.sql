
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2018 22:15:44
-- Generated from EDMX file: C:\Users\анна\Desktop\Учеба\Практика\Школьное расписание\Школьное расписание\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SchoolSchedule];
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

-- Creating table 'ScheduleSet'
CREATE TABLE [dbo].[ScheduleSet] (
    [Date] datetime  NOT NULL,
    [ChangeDate] datetime  NOT NULL
);
GO

-- Creating table 'LessonSet'
CREATE TABLE [dbo].[LessonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] smallint  NOT NULL,
    [Schedule_Date] datetime  NOT NULL,
    [SClass_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- Creating table 'SClassSet'
CREATE TABLE [dbo].[SClassSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] smallint  NOT NULL,
    [Letter] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SubjectSet'
CREATE TABLE [dbo].[SubjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Room] smallint  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Teacher_Id] int  NOT NULL
);
GO

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SClass_Id] int  NOT NULL,
    [Indiv_plan_Id] int  NULL
);
GO

-- Creating table 'TeacherSet'
CREATE TABLE [dbo].[TeacherSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Indiv_planSet'
CREATE TABLE [dbo].[Indiv_planSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupLesSet'
CREATE TABLE [dbo].[GroupLesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mo] smallint  NOT NULL,
    [Tu] smallint  NOT NULL,
    [We] smallint  NOT NULL,
    [Th] smallint  NOT NULL,
    [Fr] smallint  NOT NULL,
    [Sa] smallint  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- Creating table 'PlanElemSet'
CREATE TABLE [dbo].[PlanElemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mo] smallint  NOT NULL,
    [Tu] smallint  NOT NULL,
    [We] smallint  NOT NULL,
    [Th] smallint  NOT NULL,
    [Fr] smallint  NOT NULL,
    [Sa] smallint  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [SClass_Id] int  NULL,
    [Subject_Id] int  NOT NULL,
    [Indiv_plan_Id] int  NULL
);
GO

-- Creating table 'GroupLesStudent'
CREATE TABLE [dbo].[GroupLesStudent] (
    [GroupLes_Id] int  NOT NULL,
    [Student_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Date] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [PK_ScheduleSet]
    PRIMARY KEY CLUSTERED ([Date] ASC);
GO

-- Creating primary key on [Id] in table 'LessonSet'
ALTER TABLE [dbo].[LessonSet]
ADD CONSTRAINT [PK_LessonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SClassSet'
ALTER TABLE [dbo].[SClassSet]
ADD CONSTRAINT [PK_SClassSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectSet'
ALTER TABLE [dbo].[SubjectSet]
ADD CONSTRAINT [PK_SubjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeacherSet'
ALTER TABLE [dbo].[TeacherSet]
ADD CONSTRAINT [PK_TeacherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Indiv_planSet'
ALTER TABLE [dbo].[Indiv_planSet]
ADD CONSTRAINT [PK_Indiv_planSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupLesSet'
ALTER TABLE [dbo].[GroupLesSet]
ADD CONSTRAINT [PK_GroupLesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanElemSet'
ALTER TABLE [dbo].[PlanElemSet]
ADD CONSTRAINT [PK_PlanElemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [GroupLes_Id], [Student_Id] in table 'GroupLesStudent'
ALTER TABLE [dbo].[GroupLesStudent]
ADD CONSTRAINT [PK_GroupLesStudent]
    PRIMARY KEY CLUSTERED ([GroupLes_Id], [Student_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Schedule_Date] in table 'LessonSet'
ALTER TABLE [dbo].[LessonSet]
ADD CONSTRAINT [FK_ScheduleLesson]
    FOREIGN KEY ([Schedule_Date])
    REFERENCES [dbo].[ScheduleSet]
        ([Date])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleLesson'
CREATE INDEX [IX_FK_ScheduleLesson]
ON [dbo].[LessonSet]
    ([Schedule_Date]);
GO

-- Creating foreign key on [SClass_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_SClassStudent]
    FOREIGN KEY ([SClass_Id])
    REFERENCES [dbo].[SClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SClassStudent'
CREATE INDEX [IX_FK_SClassStudent]
ON [dbo].[StudentSet]
    ([SClass_Id]);
GO

-- Creating foreign key on [SClass_Id] in table 'PlanElemSet'
ALTER TABLE [dbo].[PlanElemSet]
ADD CONSTRAINT [FK_PlanElemSClass]
    FOREIGN KEY ([SClass_Id])
    REFERENCES [dbo].[SClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanElemSClass'
CREATE INDEX [IX_FK_PlanElemSClass]
ON [dbo].[PlanElemSet]
    ([SClass_Id]);
GO

-- Creating foreign key on [SClass_Id] in table 'LessonSet'
ALTER TABLE [dbo].[LessonSet]
ADD CONSTRAINT [FK_SClassLesson]
    FOREIGN KEY ([SClass_Id])
    REFERENCES [dbo].[SClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SClassLesson'
CREATE INDEX [IX_FK_SClassLesson]
ON [dbo].[LessonSet]
    ([SClass_Id]);
GO

-- Creating foreign key on [Teacher_Id] in table 'SubjectSet'
ALTER TABLE [dbo].[SubjectSet]
ADD CONSTRAINT [FK_SubjectTeacher]
    FOREIGN KEY ([Teacher_Id])
    REFERENCES [dbo].[TeacherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectTeacher'
CREATE INDEX [IX_FK_SubjectTeacher]
ON [dbo].[SubjectSet]
    ([Teacher_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'GroupLesSet'
ALTER TABLE [dbo].[GroupLesSet]
ADD CONSTRAINT [FK_SubjectGroupLes]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectGroupLes'
CREATE INDEX [IX_FK_SubjectGroupLes]
ON [dbo].[GroupLesSet]
    ([Subject_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'PlanElemSet'
ALTER TABLE [dbo].[PlanElemSet]
ADD CONSTRAINT [FK_PlanElemSubject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanElemSubject'
CREATE INDEX [IX_FK_PlanElemSubject]
ON [dbo].[PlanElemSet]
    ([Subject_Id]);
GO

-- Creating foreign key on [Subject_Id] in table 'LessonSet'
ALTER TABLE [dbo].[LessonSet]
ADD CONSTRAINT [FK_SubjectLesson]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectLesson'
CREATE INDEX [IX_FK_SubjectLesson]
ON [dbo].[LessonSet]
    ([Subject_Id]);
GO

-- Creating foreign key on [Indiv_plan_Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [FK_Indiv_planStudent]
    FOREIGN KEY ([Indiv_plan_Id])
    REFERENCES [dbo].[Indiv_planSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Indiv_planStudent'
CREATE INDEX [IX_FK_Indiv_planStudent]
ON [dbo].[StudentSet]
    ([Indiv_plan_Id]);
GO

-- Creating foreign key on [Indiv_plan_Id] in table 'PlanElemSet'
ALTER TABLE [dbo].[PlanElemSet]
ADD CONSTRAINT [FK_Indiv_planPlanElem]
    FOREIGN KEY ([Indiv_plan_Id])
    REFERENCES [dbo].[Indiv_planSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Indiv_planPlanElem'
CREATE INDEX [IX_FK_Indiv_planPlanElem]
ON [dbo].[PlanElemSet]
    ([Indiv_plan_Id]);
GO

-- Creating foreign key on [GroupLes_Id] in table 'GroupLesStudent'
ALTER TABLE [dbo].[GroupLesStudent]
ADD CONSTRAINT [FK_GroupLesStudent_GroupLes]
    FOREIGN KEY ([GroupLes_Id])
    REFERENCES [dbo].[GroupLesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Student_Id] in table 'GroupLesStudent'
ALTER TABLE [dbo].[GroupLesStudent]
ADD CONSTRAINT [FK_GroupLesStudent_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupLesStudent_Student'
CREATE INDEX [IX_FK_GroupLesStudent_Student]
ON [dbo].[GroupLesStudent]
    ([Student_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------