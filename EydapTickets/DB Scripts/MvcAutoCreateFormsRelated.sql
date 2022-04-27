USE [TT_db]
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
/****** Object:  Index [IX_Fields]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND name = N'IX_Fields')
DROP INDEX [IX_Fields] ON [dbo].[Fields]
GO
/****** Object:  View [dbo].[vCategoriesHierarchy]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCategoriesHierarchy]'))
DROP VIEW [dbo].[vCategoriesHierarchy]
GO
/****** Object:  Table [dbo].[FieldStates]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FieldStates]') AND type in (N'U'))
DROP TABLE [dbo].[FieldStates]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND type in (N'U'))
DROP TABLE [dbo].[Fields]
GO
/****** Object:  Table [dbo].[DataSourceTypes]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DataSourceTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DataSourceTypes]
GO
/****** Object:  Table [dbo].[CategoriesRoles]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesRoles]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesRoles]
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerTaskType]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerTaskType]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFieldsPerTaskType]
GO
/****** Object:  Table [dbo].[CategoriesFieldsPerApplicationRole]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFieldsPerApplicationRole]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFieldsPerApplicationRole]
GO
/****** Object:  Table [dbo].[CategoriesFields]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesFields]') AND type in (N'U'))
DROP TABLE [dbo].[CategoriesFields]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationRoles]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationRoles]
GO
/****** Object:  UserDefinedFunction [dbo].[fnMapDataTypeToUIControlType]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnMapDataTypeToUIControlType]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnMapDataTypeToUIControlType]
GO
/****** Object:  UserDefinedFunction [dbo].[fnMapDataTypeToUIControlType]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
	[AllowNew] [bit] NOT NULL CONSTRAINT [DF_Categories_AllowNew]  DEFAULT ((1)),
	[AllowView] [bit] NOT NULL CONSTRAINT [DF_Categories_AllowView]  DEFAULT ((1)),
	[Alias] [nvarchar](250) NULL,
	[JSUrl] [varchar](250) NULL,
	[RowStatus] [int] NOT NULL CONSTRAINT [DF_Categories_RowStatus]  DEFAULT ((0)),
	[RowInserted] [datetime] NOT NULL CONSTRAINT [DF_Categories_RowInserted]  DEFAULT (getdate()),
	[RowLastUpdated] [datetime] NOT NULL CONSTRAINT [DF_Categories_RowLastUpdated]  DEFAULT (getdate()),
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriesFields]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
	[IsMandatoryInNewForm] [bit] NOT NULL CONSTRAINT [DF_CategoriesFields_IsMandatoryInNewForm]  DEFAULT ((0)),
	[IsMandatoryInEditForm] [bit] NOT NULL CONSTRAINT [DF_CategoriesFields_IsMandatoryInEditForm]  DEFAULT ((0)),
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_CategoriesFields_SortOrder]  DEFAULT ((0)),
	[LayoutOrder] [int] NOT NULL CONSTRAINT [DF_CategoriesFields_LayoutOrder]  DEFAULT ((0)),
	[LayoutTabId] [int] NOT NULL CONSTRAINT [DF_CategoriesFields_LayoutTabId]  DEFAULT ((0)),
	[LayoutGroupId] [int] NOT NULL CONSTRAINT [DF_CategoriesFields_LayoutGroupId]  DEFAULT ((0)),
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
	[RowStatus] [int] NOT NULL CONSTRAINT [DF_CategoriesFields_RowStatus]  DEFAULT ((0)),
	[RowInserted] [datetime] NOT NULL CONSTRAINT [DF_CategoriesFields_RowInserted]  DEFAULT (getdate()),
	[RowLastUpdated] [datetime] NOT NULL CONSTRAINT [DF_CategoriesFields_RowLastUpdated]  DEFAULT (getdate()),
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
/****** Object:  Table [dbo].[CategoriesFieldsPerApplicationRole]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  Table [dbo].[CategoriesFieldsPerTaskType]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
	[IsMandatoryInNewForm] [bit] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInNewForm]  DEFAULT ((0)),
	[IsMandatoryInEditForm] [bit] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_IsMandatoryInEditForm]  DEFAULT ((0)),
	[SortOrder] [int] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_SortOrder]  DEFAULT ((0)),
	[LayoutOrder] [int] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutOrder]  DEFAULT ((0)),
	[LayoutTabId] [int] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutTabId]  DEFAULT ((0)),
	[LayoutGroupId] [int] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_LayoutGroupId]  DEFAULT ((0)),
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
	[RowStatus] [int] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowStatus]  DEFAULT ((0)),
	[RowInserted] [datetime] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowInserted]  DEFAULT (getdate()),
	[RowLastUpdated] [datetime] NOT NULL CONSTRAINT [DF_CategoriesFieldsPerTaskType_RowLastUpdated]  DEFAULT (getdate()),
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
/****** Object:  Table [dbo].[CategoriesRoles]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  Table [dbo].[DataSourceTypes]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  Table [dbo].[Fields]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
	[Size] [int] NOT NULL CONSTRAINT [DF_Fields_Size]  DEFAULT ((0)),
	[Nullable] [bit] NOT NULL CONSTRAINT [DF_Fields_Nullable]  DEFAULT ((0)),
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Entity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FieldStates]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
/****** Object:  View [dbo].[vCategoriesHierarchy]    Script Date: 29/6/2016 2:27:45 μμ ******/
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
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Fields]    Script Date: 29/6/2016 2:27:45 μμ ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND name = N'IX_Fields')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Fields] ON [dbo].[Fields]
(
	[FieldName] ASC,
	[Entity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
