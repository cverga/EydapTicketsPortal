USE [TT_db]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tasks_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tasks]'))
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_Tasks_TaskTypes]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesRoles_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]'))
ALTER TABLE [dbo].[CategoriesRoles] DROP CONSTRAINT [FK_CategoriesRoles_Categories]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [FK_CategoriesFieldsPerTaskType_TaskTypes]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [FK_CategoriesFieldsPerTaskType_Fields]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [FK_CategoriesFieldsPerTaskType_Categories]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Fields]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Categories]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates3]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_FieldStates3]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates2]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_FieldStates2]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_FieldStates1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_Fields]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_DataSourceTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_DataSourceTypes]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [FK_CategoriesFields_Categories]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Tasks_TopothetisiKatagrafikou]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [DF_Tasks_TopothetisiKatagrafikou]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Personnel_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Personnel] DROP CONSTRAINT [DF_Personnel_Active]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_IncidentsRouting_RoutingIsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncidentsRouting] DROP CONSTRAINT [DF_IncidentsRouting_RoutingIsActive]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Incidents_Sector]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Incidents] DROP CONSTRAINT [DF_Incidents_Sector]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Fields_Nullable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] DROP CONSTRAINT [DF_Fields_Nullable]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Fields_Size]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] DROP CONSTRAINT [DF_Fields_Size]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] DROP CONSTRAINT [DF_CategoriesRoles_RowLastUpdated]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] DROP CONSTRAINT [DF_CategoriesRoles_RowInserted]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] DROP CONSTRAINT [DF_CategoriesRoles_RowStatus]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] DROP CONSTRAINT [DF_CategoriesRoles_SortOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowLastUpdated]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowInserted]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowStatus]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutGroupId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutTabId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_SortOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInEditForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] DROP CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInNewForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowLastUpdated]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowInserted]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowStatus]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutGroupId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutTabId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_SortOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_IsMandatoryInEditForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] DROP CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_IsMandatoryInNewForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_RowLastUpdated]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_RowInserted]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_RowStatus]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_LayoutGroupId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_LayoutTabId]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_LayoutOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_SortOrder]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_IsMandatoryInEditForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] DROP CONSTRAINT [DF_CategoriesFields_IsMandatoryInNewForm]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_RowLastUpdated]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_RowInserted]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_RowStatus]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_AllowView]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_AllowView]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_AllowNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_AllowNew]
END

GO
/****** Object:  Index [IX_Fields]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND name = N'IX_Fields')
DROP INDEX [IX_Fields] ON [dbo].[Fields]
GO
/****** Object:  Index [IX_DepartmentsToTasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentsToTasks]') AND name = N'IX_DepartmentsToTasks')
DROP INDEX [IX_DepartmentsToTasks] ON [dbo].[DepartmentsToTasks]
GO
/****** Object:  View [dbo].[vCategoriesHierarchy]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCategoriesHierarchy]'))
DROP VIEW [dbo].[vCategoriesHierarchy]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Visits]') AND type in (N'U'))
DROP TABLE [dbo].[Visits]
GO
/****** Object:  Table [dbo].[VisitEquipment]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VisitEquipment]') AND type in (N'U'))
DROP TABLE [dbo].[VisitEquipment]
GO
/****** Object:  Table [dbo].[VisitCrew]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VisitCrew]') AND type in (N'U'))
DROP TABLE [dbo].[VisitCrew]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vehicles]') AND type in (N'U'))
DROP TABLE [dbo].[Vehicles]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[TaskTypes]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TaskTypes]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
DROP TABLE [dbo].[Tasks]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sectors]') AND type in (N'U'))
DROP TABLE [dbo].[Sectors]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personnel]') AND type in (N'U'))
DROP TABLE [dbo].[Personnel]
GO
/****** Object:  Table [dbo].[IncidentsRouting]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IncidentsRouting]') AND type in (N'U'))
DROP TABLE [dbo].[IncidentsRouting]
GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incidents]') AND type in (N'U'))
DROP TABLE [dbo].[Incidents]
GO
/****** Object:  Table [dbo].[FormsToBeDeleted]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormsToBeDeleted]') AND type in (N'U'))
DROP TABLE [dbo].[FormsToBeDeleted]
GO
/****** Object:  Table [dbo].[FieldStates]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FieldStates]') AND type in (N'U'))
DROP TABLE [dbo].[FieldStates]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND type in (N'U'))
DROP TABLE [dbo].[Fields]
GO
/****** Object:  Table [dbo].[DepartmentsToTasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentsToTasks]') AND type in (N'U'))
DROP TABLE [dbo].[DepartmentsToTasks]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
DROP TABLE [dbo].[Departments]
GO
/****** Object:  Table [dbo].[DataSourceTypes]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataSourceTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DataSourceTypes]
GO
/****** Object:  Table [dbo].[CategoriesRoles]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesRoles]
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerTaskType]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFieldsPerTaskType]
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerApplicationRole]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFieldsPerApplicationRole]
GO
/****** Object:  Table [dbo].[CategoriesFields]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFields]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFields]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationRoles]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationRoles]
GO
/****** Object:  Table [dbo].[_1022Problems]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022Problems]') AND type in (N'U'))
DROP TABLE [dbo].[_1022Problems]
GO
/****** Object:  Table [dbo].[_1022EidosProblems]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022EidosProblems]') AND type in (N'U'))
DROP TABLE [dbo].[_1022EidosProblems]
GO
/****** Object:  Table [dbo].[_1022Egkatastasi]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022Egkatastasi]') AND type in (N'U'))
DROP TABLE [dbo].[_1022Egkatastasi]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__MigrationHistory]
GO
/****** Object:  UserDefinedFunction [dbo].[fnMapDataTypeToUIControlType]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnMapDataTypeToUIControlType]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnMapDataTypeToUIControlType]
GO
/****** Object:  StoredProcedure [dbo].[GetSectorIncidents]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSectorIncidents]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSectorIncidents]
GO
/****** Object:  StoredProcedure [dbo].[GetSectorIncidents]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSectorIncidents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSectorIncidents]
	-- Add the parameters for the stored procedure here
	@SectorID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select * from Incidents where Sector = @SectorID

    -- Insert statements for procedure here
	
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnMapDataTypeToUIControlType]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnMapDataTypeToUIControlType]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION [dbo].[fnMapDataTypeToUIControlType] 
(
	-- Add the parameters for the function here
	@dataType nvarchar(128)
)
RETURNS nvarchar(50)
AS
BEGIN
	DECLARE @controlType nvarchar(50)
	IF (@dataType = ''bit'')
		SELECT @controlType = ''checkbox''
	ELSE IF (@dataType = ''datetime'')
		SELECT @controlType = ''datetime''
	ELSE
		SELECT @controlType = ''textbox''
	RETURN @controlType

END

' 
END

GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[_1022Egkatastasi]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022Egkatastasi]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[_1022Egkatastasi](
	[EgkatastasiId] [int] IDENTITY(1,1) NOT NULL,
	[EgkatastasiCode] [nvarchar](24) NULL,
	[EgkatastasiDescription] [nchar](128) NOT NULL,
 CONSTRAINT [PK_1022InstallationTypes] PRIMARY KEY CLUSTERED 
(
	[EgkatastasiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[_1022EidosProblems]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022EidosProblems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[_1022EidosProblems](
	[EidosProblemsId] [int] IDENTITY(1,1) NOT NULL,
	[EidosProblemsCode] [nvarchar](24) NULL,
	[EidosProblemsDescription] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_1022ProblemTypes] PRIMARY KEY CLUSTERED 
(
	[EidosProblemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[_1022Problems]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_1022Problems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[_1022Problems](
	[ProblemsId] [int] IDENTITY(1,1) NOT NULL,
	[ProblemsCode] [nvarchar](24) NULL,
	[ProblemsDescription] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_1022Problems] PRIMARY KEY CLUSTERED 
(
	[ProblemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationRoles](
	[Id] [int] NOT NULL,
	[ApplicationRoleName] [nvarchar](400) NOT NULL,
	[RoleType] [nvarchar](50) NULL,
	[TaskTypeId] [int] NULL,
 CONSTRAINT [PK_ApplicationRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[ParentCategoryId] [int] NULL,
	[AllowNew] [bit] NOT NULL,
	[AllowView] [bit] NOT NULL,
	[Alias] [nvarchar](250) NULL,
	[JSUrl] [varchar](250) NULL,
	[RowStatus] [int] NOT NULL,
	[RowInserted] [datetime] NOT NULL,
	[RowLastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriesFields]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CategoriesFields](
	[CategoryId] [int] NOT NULL,
	[FieldId] [uniqueidentifier] NOT NULL,
	[Entity] [nvarchar](128) NOT NULL,
	[FieldExtensionId] [int] NOT NULL,
	[InternalName] [nvarchar](250) NOT NULL,
	[FieldStateInNewForm] [int] NOT NULL,
	[FieldStateInViewForm] [int] NOT NULL,
	[FieldStateInEditForm] [int] NOT NULL,
	[ControlTypeInNewForm] [nvarchar](50) NULL,
	[ControlTypeInViewForm] [nvarchar](50) NULL,
	[ControlTypeInEditForm] [nvarchar](50) NULL,
	[IsMandatoryInNewForm] [bit] NOT NULL,
	[IsMandatoryInEditForm] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[LayoutOrder] [int] NOT NULL,
	[LayoutTabId] [int] NOT NULL,
	[LayoutGroupId] [int] NOT NULL,
	[AllowedValues] [nvarchar](max) NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ValidationJSScript] [nvarchar](max) NULL,
	[ValidationServerSide] [nvarchar](max) NULL,
	[ValidationWSUrl] [nvarchar](250) NULL,
	[DocumentReadyJSScript] [nvarchar](max) NULL,
	[DataSourceTypeId] [int] NOT NULL,
	[DataSource] [nvarchar](250) NULL,
	[FieldExtension1] [nvarchar](50) NULL,
	[FieldExtension2] [nvarchar](50) NULL,
	[FieldExtension3] [nvarchar](50) NULL,
	[FieldExtension4] [nvarchar](50) NULL,
	[FieldExtension5] [nvarchar](50) NULL,
	[FieldExtension6] [nvarchar](50) NULL,
	[NameLocale1] [nvarchar](255) NULL,
	[NameLocale2] [nvarchar](255) NULL,
	[NameLocale3] [nvarchar](255) NULL,
	[NameLocale4] [nvarchar](255) NULL,
	[NameLocale5] [nvarchar](255) NULL,
	[NameLocale6] [nvarchar](255) NULL,
	[NameLocale7] [nvarchar](255) NULL,
	[NameLocale8] [nvarchar](255) NULL,
	[NameLocale9] [nvarchar](255) NULL,
	[RowStatus] [int] NOT NULL,
	[RowInserted] [datetime] NOT NULL,
	[RowLastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoriesFields] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[FieldId] ASC,
	[Entity] ASC,
	[FieldExtensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerApplicationRole]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CategoriesFieldsPerApplicationRole](
	[CategoryId] [int] NOT NULL,
	[FieldId] [uniqueidentifier] NOT NULL,
	[Entity] [nvarchar](128) NOT NULL,
	[ApplicationRoleId] [int] NOT NULL,
	[InternalName] [nvarchar](250) NOT NULL,
	[FieldStateInNewForm] [int] NOT NULL,
	[FieldStateInViewForm] [int] NOT NULL,
	[FieldStateInEditForm] [int] NOT NULL,
	[ControlTypeInNewForm] [nvarchar](50) NULL,
	[ControlTypeInViewForm] [nvarchar](50) NULL,
	[ControlTypeInEditForm] [nvarchar](50) NULL,
	[IsMandatoryInNewForm] [bit] NOT NULL,
	[IsMandatoryInEditForm] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[LayoutOrder] [int] NOT NULL,
	[LayoutTabId] [int] NOT NULL,
	[LayoutGroupId] [int] NOT NULL,
	[AllowedValues] [nvarchar](max) NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ValidationJSScript] [nvarchar](max) NULL,
	[ValidationServerSide] [nvarchar](max) NULL,
	[ValidationWSUrl] [nvarchar](250) NULL,
	[DocumentReadyJSScript] [nvarchar](max) NULL,
	[DataSourceTypeId] [int] NULL,
	[DataSource] [nvarchar](250) NULL,
	[FieldExtension1] [nvarchar](50) NULL,
	[FieldExtension2] [nvarchar](50) NULL,
	[FieldExtension3] [nvarchar](50) NULL,
	[FieldExtension4] [nvarchar](50) NULL,
	[FieldExtension5] [nvarchar](50) NULL,
	[FieldExtension6] [nvarchar](50) NULL,
	[NameLocale1] [nvarchar](255) NULL,
	[NameLocale2] [nvarchar](255) NULL,
	[NameLocale3] [nvarchar](255) NULL,
	[NameLocale4] [nvarchar](255) NULL,
	[NameLocale5] [nvarchar](255) NULL,
	[NameLocale6] [nvarchar](255) NULL,
	[NameLocale7] [nvarchar](255) NULL,
	[NameLocale8] [nvarchar](255) NULL,
	[NameLocale9] [nvarchar](255) NULL,
	[RowStatus] [int] NOT NULL,
	[RowInserted] [datetime] NOT NULL,
	[RowLastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoriesFieldsPerApplicationRole] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[FieldId] ASC,
	[Entity] ASC,
	[ApplicationRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerTaskType]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CategoriesFieldsPerTaskType](
	[CategoryId] [int] NOT NULL,
	[FieldId] [uniqueidentifier] NOT NULL,
	[Entity] [nvarchar](128) NOT NULL,
	[TaskType] [int] NOT NULL,
	[InternalName] [nvarchar](250) NOT NULL,
	[FieldStateInNewForm] [int] NOT NULL,
	[FieldStateInViewForm] [int] NOT NULL,
	[FieldStateInEditForm] [int] NOT NULL,
	[ControlTypeInNewForm] [nvarchar](50) NULL,
	[ControlTypeInViewForm] [nvarchar](50) NULL,
	[ControlTypeInEditForm] [nvarchar](50) NULL,
	[IsMandatoryInNewForm] [bit] NOT NULL,
	[IsMandatoryInEditForm] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[LayoutOrder] [int] NOT NULL,
	[LayoutTabId] [int] NOT NULL,
	[LayoutGroupId] [int] NOT NULL,
	[AllowedValues] [nvarchar](max) NULL,
	[DefaultValue] [nvarchar](max) NULL,
	[ValidationJSScript] [nvarchar](max) NULL,
	[ValidationServerSide] [nvarchar](max) NULL,
	[ValidationWSUrl] [nvarchar](250) NULL,
	[DocumentReadyJSScript] [nvarchar](max) NULL,
	[DataSourceTypeId] [int] NULL,
	[DataSource] [nvarchar](250) NULL,
	[FieldExtension1] [nvarchar](50) NULL,
	[FieldExtension2] [nvarchar](50) NULL,
	[FieldExtension3] [nvarchar](50) NULL,
	[FieldExtension4] [nvarchar](50) NULL,
	[FieldExtension5] [nvarchar](50) NULL,
	[FieldExtension6] [nvarchar](50) NULL,
	[NameLocale1] [nvarchar](255) NULL,
	[NameLocale2] [nvarchar](255) NULL,
	[NameLocale3] [nvarchar](255) NULL,
	[NameLocale4] [nvarchar](255) NULL,
	[NameLocale5] [nvarchar](255) NULL,
	[NameLocale6] [nvarchar](255) NULL,
	[NameLocale7] [nvarchar](255) NULL,
	[NameLocale8] [nvarchar](255) NULL,
	[NameLocale9] [nvarchar](255) NULL,
	[RowStatus] [int] NOT NULL,
	[RowInserted] [datetime] NOT NULL,
	[RowLastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoriesFieldsPerTaskType] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[FieldId] ASC,
	[Entity] ASC,
	[TaskType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CategoriesRoles]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CategoriesRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ApplicationRoleId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[StageLevel] [int] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CategoryConfigId] [int] NULL,
	[RowStatus] [int] NOT NULL,
	[RowInserted] [datetime] NOT NULL,
	[RowLastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_CategoriesRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CategoriesRoles] UNIQUE NONCLUSTERED 
(
	[CategoryId] ASC,
	[ApplicationRoleId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DataSourceTypes]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataSourceTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DataSourceTypes](
	[Id] [int] NOT NULL,
	[DataSourceTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DataSourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](50) NOT NULL,
	[DepartmentName] [nvarchar](128) NOT NULL,
	[SectorId] [int] NOT NULL,
 CONSTRAINT [PK_DDYDepartments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DepartmentsToTasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentsToTasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DepartmentsToTasks](
	[ID] [uniqueidentifier] NOT NULL,
	[SectorID] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentsToTasks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Fields](
	[Id] [uniqueidentifier] NOT NULL,
	[Entity] [nvarchar](128) NOT NULL,
	[FieldName] [nvarchar](255) NOT NULL,
	[FieldType] [nvarchar](50) NOT NULL,
	[Size] [int] NOT NULL,
	[Nullable] [bit] NOT NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Entity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FieldStates]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FieldStates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FieldStates](
	[Id] [int] NOT NULL,
	[State] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_FieldStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FormsToBeDeleted]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormsToBeDeleted]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FormsToBeDeleted](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[FormCode] [nvarchar](50) NOT NULL,
	[FormDescription] [nvarchar](250) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Incidents]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incidents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Incidents](
	[TT_Id] [uniqueidentifier] NOT NULL,
	[ID1022] [nchar](100) NULL,
	[Customer_Name] [nvarchar](250) NULL,
	[Customer_Phone] [nvarchar](250) NULL,
	[Customer_Email] [nvarchar](250) NULL,
	[Municipality] [nvarchar](250) NULL,
	[Street_Name] [nvarchar](250) NULL,
	[Street_Number] [nvarchar](5) NULL,
	[Comments] [nvarchar](1500) NULL,
	[Sector] [int] NOT NULL,
 CONSTRAINT [PK_Incidents] PRIMARY KEY CLUSTERED 
(
	[TT_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[IncidentsRouting]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IncidentsRouting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IncidentsRouting](
	[RecId] [int] IDENTITY(1,1) NOT NULL,
	[RoutingSectorId] [int] NULL,
	[RoutingSectorName] [nvarchar](50) NULL,
	[ComesFromTTDeptName] [nvarchar](50) NULL,
	[ProblemD04] [nchar](10) NULL,
	[FromWorkingDay] [datetime] NULL,
	[ToWorkingDay] [datetime] NULL,
	[FromWeekendDay] [datetime] NULL,
	[ToWeekendDay] [datetime] NULL,
	[RouteToDepartmentId] [int] NULL,
	[RouteToDepartmentName] [nvarchar](50) NULL,
	[RoutingIsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_IncidentsRouting] PRIMARY KEY CLUSTERED 
(
	[RecId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personnel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Personnel](
	[PersonnelID] [int] IDENTITY(1,1) NOT NULL,
	[PersonnelName] [nvarchar](150) NOT NULL,
	[PersonnelSurName] [nvarchar](150) NOT NULL,
	[PersonnelType] [int] NOT NULL,
	[PersonnelAM] [int] NOT NULL,
	[PersonnelSectorId] [int] NOT NULL,
	[PersonnelDepartmentID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Personnel] PRIMARY KEY CLUSTERED 
(
	[PersonnelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sectors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sectors](
	[SectorId] [int] IDENTITY(1,1) NOT NULL,
	[SectorCode] [nvarchar](50) NOT NULL,
	[SectorDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DDYSectors] PRIMARY KEY CLUSTERED 
(
	[SectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[Task_Id] [uniqueidentifier] NOT NULL,
	[Task_Description] [nvarchar](250) NOT NULL,
	[Comments] [nvarchar](500) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[TaskTypeId] [int] NOT NULL,
	[Incident_Id] [uniqueidentifier] NOT NULL,
	[SynergeioEpemvasis] [nvarchar](max) NULL,
	[SynergeioElegxou] [nvarchar](max) NULL,
	[SynergeioApomonosis] [nvarchar](max) NULL,
	[SynergeioEpanaforas] [nvarchar](max) NULL,
	[ControlDate] [datetime] NULL,
	[ControlTime] [datetime] NULL,
	[Epemvasi_VardiaSynergeiou] [nvarchar](10) NULL,
	[Epemvasi_ArithmosAtomonSynergeiou] [smallint] NULL,
	[Porisma] [nvarchar](max) NULL,
	[Energeies] [nvarchar](max) NULL,
	[PositionOfGeotrisi] [nvarchar](50) NULL,
	[ResultsOfChemeio] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[MAP] [nvarchar](50) NULL,
	[VanaDiametros] [nvarchar](50) NULL,
	[AgogosDiametros] [nvarchar](50) NULL,
	[MetritisDiametros] [nvarchar](50) NULL,
	[PyrosvestikiParoxiDiametros] [nvarchar](50) NULL,
	[ZoniPiesis] [nvarchar](50) NULL,
	[Zoni] [nvarchar](50) NULL,
	[Eidopoiisi] [nvarchar](30) NULL,
	[HmerominiaApomonosis] [datetime] NULL,
	[OraApomonosis] [datetime] NULL,
	[EkplisiTermatos] [nvarchar](50) NULL,
	[PyrosvestikouGeranouDiametros] [nvarchar](50) NULL,
	[Apomonosi_HmerominiaAnaxorisis] [datetime] NULL,
	[Apomonosi_OraAnaxorisis] [datetime] NULL,
	[Apomonosi_HmerominiaAfixis] [datetime] NULL,
	[Apomonosi_OraAfixis] [datetime] NULL,
	[Apomonosi_HmerominiaEpistrofis] [datetime] NULL,
	[Apomonosi_OraEpistrofis] [datetime] NULL,
	[HmerominiaEpanaforas] [datetime] NULL,
	[OraEpanaforas] [datetime] NULL,
	[EidosEpanaforas] [nvarchar](20) NULL,
	[Epanafora_HmerominiaAnaxorisis] [datetime] NULL,
	[Epanafora_OraAnaxorisis] [datetime] NULL,
	[Epanafora_HmerominiaAfixis] [datetime] NULL,
	[Epanafora_OraAfixis] [datetime] NULL,
	[Epanafora_HmerominiaEpistrofis] [datetime] NULL,
	[Epanafora_OraEpistrofis] [datetime] NULL,
	[Apomonosi_ArithmosAtomonSynergeiou] [smallint] NULL,
	[Epanafora_ArithmosAtomonSynergeiou] [smallint] NULL,
	[Apomonosi_VardiaSynergeiou] [nvarchar](10) NULL,
	[Epanafora_VardiaSynergeiou] [nvarchar](10) NULL,
	[Apomonosi_ArirthosVanonPouXeiristikan] [smallint] NULL,
	[Apomonosi_KatastasiVanonPouXeiristikan] [nvarchar](50) NULL,
	[Apomonosi_ThesiVanonPouXeiristikan] [nvarchar](50) NULL,
	[SyntetagmenesVlavis] [nvarchar](50) NULL,
	[AgogosYliko] [nvarchar](50) NULL,
	[TopothetisiKatagrafikou] [bit] NULL,
	[GnomateusiThesi] [nvarchar](50) NULL,
	[GnomateusiMikos] [float] NULL,
	[GnomateusiDiametros] [float] NULL,
	[GnomateusiYliko] [nvarchar](50) NULL,
	[TaskAttachments] [nvarchar](max) NULL,
	[Epanafora_ArirthosVanonPouXeiristikan] [smallint] NULL,
	[Epanafora_KatastasiVanonPouXeiristikan] [nvarchar](50) NULL,
	[Epanafora_ThesiVanonPouXeiristikan] [nvarchar](50) NULL,
	[Oximata] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Task_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TaskTypes]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskTypes](
	[TaskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaskCode] [nvarchar](50) NOT NULL,
	[TaskDescription] [nvarchar](250) NOT NULL,
	[IsActive] [int] NOT NULL,
 CONSTRAINT [PK_TaskTypes] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_TaskTypes] UNIQUE NONCLUSTERED 
(
	[TaskCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[SectorId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserEmail] [nvarchar](50) NULL,
	[IsActive] [int] NOT NULL,
	[AM] [int] NOT NULL,
	[Name] [nchar](150) NOT NULL,
	[SurName] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[AM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vehicles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleSector] [int] NOT NULL,
	[VehicleDepartment] [int] NOT NULL,
	[VehicleRegNumber] [nchar](15) NOT NULL,
	[VehicleType] [int] NOT NULL,
	[IsEydap] [bit] NULL,
	[OwnerName] [nchar](100) NULL,
	[OwnerSurName] [nchar](100) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VisitCrew]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VisitCrew]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VisitCrew](
	[ID] [uniqueidentifier] NOT NULL,
	[VisitID] [uniqueidentifier] NOT NULL,
	[VisitCrewName] [nvarchar](250) NOT NULL,
	[VisitCrewSurname] [nvarchar](50) NOT NULL,
	[VisitCrewAM] [int] NOT NULL,
 CONSTRAINT [PK_VisitCrew] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VisitEquipment]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VisitEquipment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VisitEquipment](
	[ID] [uniqueidentifier] NOT NULL,
	[VisitID] [uniqueidentifier] NOT NULL,
	[VehileType] [nvarchar](150) NOT NULL,
	[VehicleNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VisitEquipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Visits]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Visits](
	[AssignmentId] [uniqueidentifier] NOT NULL,
	[DateOfAssignment] [datetime] NOT NULL,
	[DateOfCompletion] [datetime] NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Task_Id] [uniqueidentifier] NOT NULL,
	[Comments] [nvarchar](250) NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[vCategoriesHierarchy]    Script Date: 29/6/2016 3:12:49 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCategoriesHierarchy]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vCategoriesHierarchy]
AS
WITH CTE AS (
	SELECT Id, CategoryName, ParentCategoryId, AllowNew, AllowView, JSUrl, 1 AS HierarchyLevel, 
			CONVERT(nvarchar, N'''') AS Parents, CONVERT(nvarchar(MAX), CategoryName) AS FullPath
        FROM dbo.Categories AS TopLevel
        WHERE (ParentCategoryId IS NULL) AND (RowStatus = 0 OR RowStatus = - 100)
    UNION ALL
    SELECT LowLevel.Id, LowLevel.CategoryName, LowLevel.ParentCategoryId, LowLevel.AllowNew, LowLevel.AllowView, LowLevel.JSUrl, 
            CTE_2.HierarchyLevel + 1 AS HierarchyLevel, CONVERT(nvarchar, CTE_2.Parents + '','' + CONVERT(nvarchar, CTE_2.Id)) AS Parents,
			(CTE_2.FullPath + '' / '' + CONVERT(nvarchar(MAX), LowLevel.CategoryName)) AS FullPath
		FROM dbo.Categories AS LowLevel INNER JOIN
			CTE AS CTE_2 ON LowLevel.ParentCategoryId = CTE_2.Id
		WHERE (LowLevel.ParentCategoryId IS NOT NULL) AND (LowLevel.RowStatus = 0)
)
SELECT     ISNULL(Id, - 1) AS Id, CategoryName, ParentCategoryId, AllowNew, AllowView, JSUrl, HierarchyLevel, Parents, FullPath
	FROM CTE AS CTE_1


' 
GO
/****** Object:  Index [IX_DepartmentsToTasks]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentsToTasks]') AND name = N'IX_DepartmentsToTasks')
CREATE NONCLUSTERED INDEX [IX_DepartmentsToTasks] ON [dbo].[DepartmentsToTasks]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Fields]    Script Date: 29/6/2016 3:12:49 μμ ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND name = N'IX_Fields')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Fields] ON [dbo].[Fields]
(
	[FieldName] ASC,
	[Entity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_AllowNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_AllowNew]  DEFAULT ((1)) FOR [AllowNew]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_AllowView]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_AllowView]  DEFAULT ((1)) FOR [AllowView]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_RowInserted]  DEFAULT (getdate()) FOR [RowInserted]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Categories_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_RowLastUpdated]  DEFAULT (getdate()) FOR [RowLastUpdated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_IsMandatoryInNewForm]  DEFAULT ((0)) FOR [IsMandatoryInNewForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_IsMandatoryInEditForm]  DEFAULT ((0)) FOR [IsMandatoryInEditForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_LayoutOrder]  DEFAULT ((0)) FOR [LayoutOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_LayoutTabId]  DEFAULT ((0)) FOR [LayoutTabId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_LayoutGroupId]  DEFAULT ((0)) FOR [LayoutGroupId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_RowInserted]  DEFAULT (getdate()) FOR [RowInserted]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFields_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFields] ADD  CONSTRAINT [DF_CategoriesFields_RowLastUpdated]  DEFAULT (getdate()) FOR [RowLastUpdated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_IsMandatoryInNewForm]  DEFAULT ((0)) FOR [IsMandatoryInNewForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_IsMandatoryInEditForm]  DEFAULT ((0)) FOR [IsMandatoryInEditForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutOrder]  DEFAULT ((0)) FOR [LayoutOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutTabId]  DEFAULT ((0)) FOR [LayoutTabId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_LayoutGroupId]  DEFAULT ((0)) FOR [LayoutGroupId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowInserted]  DEFAULT (getdate()) FOR [RowInserted]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerApplicationRole_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] ADD  CONSTRAINT [DF_CategoriesFieldsPerApplicationRole_RowLastUpdated]  DEFAULT (getdate()) FOR [RowLastUpdated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_IsMandatoryInNewForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInNewForm]  DEFAULT ((0)) FOR [IsMandatoryInNewForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_IsMandatoryInEditForm]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInEditForm]  DEFAULT ((0)) FOR [IsMandatoryInEditForm]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutOrder]  DEFAULT ((0)) FOR [LayoutOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutTabId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutTabId]  DEFAULT ((0)) FOR [LayoutTabId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_LayoutGroupId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutGroupId]  DEFAULT ((0)) FOR [LayoutGroupId]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowInserted]  DEFAULT (getdate()) FOR [RowInserted]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesFieldsPerTaskType_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] ADD  CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowLastUpdated]  DEFAULT (getdate()) FOR [RowLastUpdated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_SortOrder]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] ADD  CONSTRAINT [DF_CategoriesRoles_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowStatus]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] ADD  CONSTRAINT [DF_CategoriesRoles_RowStatus]  DEFAULT ((0)) FOR [RowStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowInserted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] ADD  CONSTRAINT [DF_CategoriesRoles_RowInserted]  DEFAULT (getdate()) FOR [RowInserted]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CategoriesRoles_RowLastUpdated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CategoriesRoles] ADD  CONSTRAINT [DF_CategoriesRoles_RowLastUpdated]  DEFAULT (getdate()) FOR [RowLastUpdated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Fields_Size]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] ADD  CONSTRAINT [DF_Fields_Size]  DEFAULT ((0)) FOR [Size]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Fields_Nullable]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] ADD  CONSTRAINT [DF_Fields_Nullable]  DEFAULT ((0)) FOR [Nullable]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Incidents_Sector]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Incidents] ADD  CONSTRAINT [DF_Incidents_Sector]  DEFAULT ((1)) FOR [Sector]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_IncidentsRouting_RoutingIsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncidentsRouting] ADD  CONSTRAINT [DF_IncidentsRouting_RoutingIsActive]  DEFAULT ((1)) FOR [RoutingIsActive]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Personnel_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Personnel] ADD  CONSTRAINT [DF_Personnel_Active]  DEFAULT ((1)) FOR [IsActive]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Tasks_TopothetisiKatagrafikou]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tasks] ADD  CONSTRAINT [DF_Tasks_TopothetisiKatagrafikou]  DEFAULT ((0)) FOR [TopothetisiKatagrafikou]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_DataSourceTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_DataSourceTypes] FOREIGN KEY([DataSourceTypeId])
REFERENCES [dbo].[DataSourceTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_DataSourceTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_DataSourceTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_Fields] FOREIGN KEY([FieldId], [Entity])
REFERENCES [dbo].[Fields] ([Id], [Entity])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_Fields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_FieldStates1] FOREIGN KEY([FieldStateInEditForm])
REFERENCES [dbo].[FieldStates] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_FieldStates1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates2]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_FieldStates2] FOREIGN KEY([FieldStateInNewForm])
REFERENCES [dbo].[FieldStates] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates2]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_FieldStates2]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates3]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFields_FieldStates3] FOREIGN KEY([FieldStateInViewForm])
REFERENCES [dbo].[FieldStates] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFields_FieldStates3]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFields]'))
ALTER TABLE [dbo].[CategoriesFields] CHECK CONSTRAINT [FK_CategoriesFields_FieldStates3]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] CHECK CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Fields] FOREIGN KEY([FieldId], [Entity])
REFERENCES [dbo].[Fields] ([Id], [Entity])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerApplicationRole_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]'))
ALTER TABLE [dbo].[CategoriesFieldsPerApplicationRole] CHECK CONSTRAINT [FK_CategoriesFieldsPerApplicationRole_Fields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFieldsPerTaskType_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] CHECK CONSTRAINT [FK_CategoriesFieldsPerTaskType_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFieldsPerTaskType_Fields] FOREIGN KEY([FieldId], [Entity])
REFERENCES [dbo].[Fields] ([Id], [Entity])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_Fields]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] CHECK CONSTRAINT [FK_CategoriesFieldsPerTaskType_Fields]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesFieldsPerTaskType_TaskTypes] FOREIGN KEY([TaskType])
REFERENCES [dbo].[TaskTypes] ([TaskTypeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesFieldsPerTaskType_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]'))
ALTER TABLE [dbo].[CategoriesFieldsPerTaskType] CHECK CONSTRAINT [FK_CategoriesFieldsPerTaskType_TaskTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesRoles_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]'))
ALTER TABLE [dbo].[CategoriesRoles]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesRoles_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoriesRoles_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]'))
ALTER TABLE [dbo].[CategoriesRoles] CHECK CONSTRAINT [FK_CategoriesRoles_Categories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tasks_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tasks]'))
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_TaskTypes] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[TaskTypes] ([TaskTypeId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tasks_TaskTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tasks]'))
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_TaskTypes]
GO
