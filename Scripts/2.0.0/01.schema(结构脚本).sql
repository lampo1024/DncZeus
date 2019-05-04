USE [DncZeus]
GO
/****** Object:  Table [dbo].[DncIcon]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncIcon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Size] [nvarchar](20) NULL,
	[Color] [nvarchar](50) NULL,
	[Custom] [nvarchar](60) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedByUserGuid] [uniqueidentifier] NOT NULL,
	[CreatedByUserName] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
	[ModifiedByUserGuid] [uniqueidentifier] NULL,
	[ModifiedByUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_DncIcon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncMenu]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncMenu](
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](255) NULL,
	[Alias] [nvarchar](255) NULL,
	[Icon] [nvarchar](128) NULL,
	[ParentGuid] [uniqueidentifier] NULL,
	[ParentName] [nvarchar](max) NULL,
	[Level] [int] NOT NULL,
	[Description] [nvarchar](800) NULL,
	[Sort] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[IsDefaultRouter] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedByUserGuid] [uniqueidentifier] NOT NULL,
	[CreatedByUserName] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
	[ModifiedByUserGuid] [uniqueidentifier] NULL,
	[ModifiedByUserName] [nvarchar](max) NULL,
	[Component] [nvarchar](255) NULL,
	[HideInMenu] [int] NULL,
	[NotCache] [int] NULL,
	[BeforeCloseFun] [nvarchar](255) NULL,
 CONSTRAINT [PK_DncMenu] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncPermission]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncPermission](
	[Code] [nvarchar](20) NOT NULL,
	[MenuGuid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ActionCode] [nvarchar](80) NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[CreatedByUserGuid] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedByUserName] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
	[ModifiedByUserGuid] [uniqueidentifier] NULL,
	[ModifiedByUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_DncPermission] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncRole]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncRole](
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedByUserGuid] [uniqueidentifier] NOT NULL,
	[CreatedByUserName] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
	[ModifiedByUserGuid] [uniqueidentifier] NULL,
	[ModifiedByUserName] [nvarchar](max) NULL,
	[IsSuperAdministrator] [bit] NOT NULL,
	[IsBuiltin] [bit] NOT NULL,
 CONSTRAINT [PK_DncRole] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncRolePermissionMapping]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncRolePermissionMapping](
	[RoleCode] [nvarchar](50) NOT NULL,
	[PermissionCode] [nvarchar](20) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DncRolePermissionMapping] PRIMARY KEY CLUSTERED 
(
	[RoleCode] ASC,
	[PermissionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncUser]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncUser](
	[Guid] [uniqueidentifier] NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NULL,
	[Avatar] [nvarchar](255) NULL,
	[UserType] [int] NOT NULL,
	[IsLocked] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedByUserGuid] [uniqueidentifier] NOT NULL,
	[CreatedByUserName] [nvarchar](max) NULL,
	[ModifiedOn] [datetime2](7) NULL,
	[ModifiedByUserGuid] [uniqueidentifier] NULL,
	[ModifiedByUserName] [nvarchar](max) NULL,
	[Description] [nvarchar](800) NULL,
 CONSTRAINT [PK_DncUser] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DncUserRoleMapping]    Script Date: 2019-05-04 22:37:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DncUserRoleMapping](
	[UserGuid] [uniqueidentifier] NOT NULL,
	[RoleCode] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DncUserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[UserGuid] ASC,
	[RoleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DncPermission]  WITH CHECK ADD  CONSTRAINT [FK_DncPermission_DncMenu_MenuGuid] FOREIGN KEY([MenuGuid])
REFERENCES [dbo].[DncMenu] ([Guid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DncPermission] CHECK CONSTRAINT [FK_DncPermission_DncMenu_MenuGuid]
GO
ALTER TABLE [dbo].[DncRolePermissionMapping]  WITH CHECK ADD  CONSTRAINT [FK_DncRolePermissionMapping_DncPermission_PermissionCode] FOREIGN KEY([PermissionCode])
REFERENCES [dbo].[DncPermission] ([Code])
GO
ALTER TABLE [dbo].[DncRolePermissionMapping] CHECK CONSTRAINT [FK_DncRolePermissionMapping_DncPermission_PermissionCode]
GO
ALTER TABLE [dbo].[DncRolePermissionMapping]  WITH CHECK ADD  CONSTRAINT [FK_DncRolePermissionMapping_DncRole_RoleCode] FOREIGN KEY([RoleCode])
REFERENCES [dbo].[DncRole] ([Code])
GO
ALTER TABLE [dbo].[DncRolePermissionMapping] CHECK CONSTRAINT [FK_DncRolePermissionMapping_DncRole_RoleCode]
GO
ALTER TABLE [dbo].[DncUserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_DncUserRoleMapping_DncRole_RoleCode] FOREIGN KEY([RoleCode])
REFERENCES [dbo].[DncRole] ([Code])
GO
ALTER TABLE [dbo].[DncUserRoleMapping] CHECK CONSTRAINT [FK_DncUserRoleMapping_DncRole_RoleCode]
GO
ALTER TABLE [dbo].[DncUserRoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_DncUserRoleMapping_DncUser_UserGuid] FOREIGN KEY([UserGuid])
REFERENCES [dbo].[DncUser] ([Guid])
GO
ALTER TABLE [dbo].[DncUserRoleMapping] CHECK CONSTRAINT [FK_DncUserRoleMapping_DncUser_UserGuid]
GO
