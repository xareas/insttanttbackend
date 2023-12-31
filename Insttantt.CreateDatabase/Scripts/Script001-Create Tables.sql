
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Step]'
GO
CREATE TABLE [dbo].[Step]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Code] [varchar] (50) NOT NULL,
[Name] [varchar] (150) NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Steps] on [dbo].[Step]'
GO
ALTER TABLE [dbo].[Step] ADD CONSTRAINT [PK_Steps] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[WorkflowStep]'
GO
CREATE TABLE [dbo].[WorkflowStep]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[WorkFlowId] [int] NOT NULL,
[StepId] [int] NOT NULL,
[StepNumber] [int] NOT NULL CONSTRAINT [DF_WorkflowStep_StepNumber] DEFAULT ((0)),
[After] [int] NOT NULL CONSTRAINT [DF_WorkflowStep_After] DEFAULT ((0)),
[Before] [int] NOT NULL CONSTRAINT [DF_WorkflowStep_Before] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_WorkFlowStep] on [dbo].[WorkflowStep]'
GO
ALTER TABLE [dbo].[WorkflowStep] ADD CONSTRAINT [PK_WorkFlowStep] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_WorkflowStep] on [dbo].[WorkflowStep]'
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkflowStep] ON [dbo].[WorkflowStep] ([WorkFlowId], [StepId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Workflow]'
GO
CREATE TABLE [dbo].[Workflow]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[code] [varchar] (50) NOT NULL,
[name] [varchar] (150) NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_workflow] on [dbo].[Workflow]'
GO
ALTER TABLE [dbo].[Workflow] ADD CONSTRAINT [PK_workflow] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Field]'
GO
CREATE TABLE [dbo].[Field]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Code] [varchar] (50) NOT NULL,
[Name] [varchar] (150) NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Field] on [dbo].[Field]'
GO
ALTER TABLE [dbo].[Field] ADD CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[WorkflowStepField]'
GO
CREATE TABLE [dbo].[WorkflowStepField]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[WorkflowStepId] [int] NOT NULL,
[FieldId] [int] NOT NULL,
[SetValue] [varchar] (250) NULL,
[Output] [bit] NOT NULL CONSTRAINT [DF_WorkflowStepField_Output] DEFAULT ((0))
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_WorkflowStepField] on [dbo].[WorkflowStepField]'
GO
ALTER TABLE [dbo].[WorkflowStepField] ADD CONSTRAINT [PK_WorkflowStepField] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_WorkflowStepField] on [dbo].[WorkflowStepField]'
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_WorkflowStepField] ON [dbo].[WorkflowStepField] ([WorkflowStepId], [FieldId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[WorkflowStepField]'
GO
ALTER TABLE [dbo].[WorkflowStepField] ADD CONSTRAINT [FK_WorkflowStepField_Field] FOREIGN KEY ([FieldId]) REFERENCES [dbo].[Field] ([Id])
GO
ALTER TABLE [dbo].[WorkflowStepField] ADD CONSTRAINT [FK_WorkflowStepField_WorkflowStep] FOREIGN KEY ([WorkflowStepId]) REFERENCES [dbo].[WorkflowStep] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[WorkflowStep]'
GO
ALTER TABLE [dbo].[WorkflowStep] ADD CONSTRAINT [FK_WorkflowStep_Step] FOREIGN KEY ([StepId]) REFERENCES [dbo].[Step] ([Id])
GO
ALTER TABLE [dbo].[WorkflowStep] ADD CONSTRAINT [FK_WorkflowStep_Workflow] FOREIGN KEY ([WorkFlowId]) REFERENCES [dbo].[Workflow] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO

DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'Base de datos Actualizada'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'Fallo al intentar actualizar'
END
GO
