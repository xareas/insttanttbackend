SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
GO
SET DATEFORMAT YMD
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION

PRINT(N'Drop constraints from [dbo].[WorkflowStepField]')
ALTER TABLE [dbo].[WorkflowStepField] NOCHECK CONSTRAINT [FK_WorkflowStepField_Field]
ALTER TABLE [dbo].[WorkflowStepField] NOCHECK CONSTRAINT [FK_WorkflowStepField_WorkflowStep]

PRINT(N'Drop constraints from [dbo].[WorkflowStep]')
ALTER TABLE [dbo].[WorkflowStep] NOCHECK CONSTRAINT [FK_WorkflowStep_Step]
ALTER TABLE [dbo].[WorkflowStep] NOCHECK CONSTRAINT [FK_WorkflowStep_Workflow]

PRINT(N'Add 6 rows to [dbo].[Field]')
SET IDENTITY_INSERT [dbo].[Field] ON
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (1, 'F-001', 'Primer nombre')
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (2, 'F-002', 'Segundo nombre')
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (3, 'F-003', 'Primer apellido')
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (5, 'F-004', 'Segundo apellido')
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (6, 'F-005', 'Tipo de documento')
INSERT INTO [dbo].[Field] ([Id], [Code], [Name]) VALUES (7, 'F-006', 'Numero de documento')
SET IDENTITY_INSERT [dbo].[Field] OFF

PRINT(N'Add 4 rows to [dbo].[Step]')
SET IDENTITY_INSERT [dbo].[Step] ON
INSERT INTO [dbo].[Step] ([Id], [Code], [Name]) VALUES (1, 'STP-001', 'Paso 1')
INSERT INTO [dbo].[Step] ([Id], [Code], [Name]) VALUES (2, 'STP-002', 'Paso 2')
INSERT INTO [dbo].[Step] ([Id], [Code], [Name]) VALUES (3, 'STP-003', 'Paso 3')
INSERT INTO [dbo].[Step] ([Id], [Code], [Name]) VALUES (4, 'STP-004', 'Paso 4')
SET IDENTITY_INSERT [dbo].[Step] OFF

PRINT(N'Add 2 rows to [dbo].[Workflow]')
SET IDENTITY_INSERT [dbo].[Workflow] ON
INSERT INTO [dbo].[Workflow] ([Id], [code], [name]) VALUES (1, 'WKF-001', 'Captura de datos')
INSERT INTO [dbo].[Workflow] ([Id], [code], [name]) VALUES (2, 'WFK-002', 'Captura Asincrona')
SET IDENTITY_INSERT [dbo].[Workflow] OFF

PRINT(N'Add 6 rows to [dbo].[WorkflowStep]')
SET IDENTITY_INSERT [dbo].[WorkflowStep] ON
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (1, 1, 1, 1, 1, 0)
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (2, 1, 2, 2, 2, 1)
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (3, 1, 3, 3, 0, 2)
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (4, 2, 1, 1, 1, 0)
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (5, 2, 2, 2, 2, 1)
INSERT INTO [dbo].[WorkflowStep] ([Id], [WorkFlowId], [StepId], [StepNumber], [After], [Before]) VALUES (6, 2, 3, 3, 0, 2)
SET IDENTITY_INSERT [dbo].[WorkflowStep] OFF

PRINT(N'Add 12 rows to [dbo].[WorkflowStepField]')
SET IDENTITY_INSERT [dbo].[WorkflowStepField] ON
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (1, 1, 1, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (2, 1, 2, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (3, 2, 3, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (4, 2, 5, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (5, 3, 6, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (6, 3, 7, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (7, 4, 1, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (8, 4, 2, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (9, 5, 3, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (10, 5, 5, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (11, 6, 6, NULL, 0)
INSERT INTO [dbo].[WorkflowStepField] ([Id], [WorkflowStepId], [FieldId], [SetValue], [Output]) VALUES (12, 6, 7, NULL, 0)
SET IDENTITY_INSERT [dbo].[WorkflowStepField] OFF

PRINT(N'Add constraints to [dbo].[WorkflowStepField]')
ALTER TABLE [dbo].[WorkflowStepField] WITH CHECK CHECK CONSTRAINT [FK_WorkflowStepField_Field]
ALTER TABLE [dbo].[WorkflowStepField] WITH CHECK CHECK CONSTRAINT [FK_WorkflowStepField_WorkflowStep]

PRINT(N'Add constraints to [dbo].[WorkflowStep]')
ALTER TABLE [dbo].[WorkflowStep] WITH CHECK CHECK CONSTRAINT [FK_WorkflowStep_Step]
ALTER TABLE [dbo].[WorkflowStep] WITH CHECK CHECK CONSTRAINT [FK_WorkflowStep_Workflow]
COMMIT TRANSACTION
GO
