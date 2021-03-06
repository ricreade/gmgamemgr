USE [master]
GO
/****** Object:  Database [GMGameManagerData]    Script Date: 03/20/2015 23:39:10 ******/
CREATE DATABASE [GMGameManagerData] ON  PRIMARY 
( NAME = N'GMGameManagerData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GMGameManagerData.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GMGameManagerData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GMGameManagerData_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GMGameManagerData] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GMGameManagerData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GMGameManagerData] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GMGameManagerData] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GMGameManagerData] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GMGameManagerData] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GMGameManagerData] SET ARITHABORT OFF
GO
ALTER DATABASE [GMGameManagerData] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [GMGameManagerData] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GMGameManagerData] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GMGameManagerData] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GMGameManagerData] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GMGameManagerData] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GMGameManagerData] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GMGameManagerData] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GMGameManagerData] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GMGameManagerData] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GMGameManagerData] SET  DISABLE_BROKER
GO
ALTER DATABASE [GMGameManagerData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GMGameManagerData] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GMGameManagerData] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GMGameManagerData] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GMGameManagerData] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GMGameManagerData] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GMGameManagerData] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GMGameManagerData] SET  READ_WRITE
GO
ALTER DATABASE [GMGameManagerData] SET RECOVERY FULL
GO
ALTER DATABASE [GMGameManagerData] SET  MULTI_USER
GO
ALTER DATABASE [GMGameManagerData] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GMGameManagerData] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'GMGameManagerData', N'ON'
GO
USE [GMGameManagerData]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attributes](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](max) NOT NULL,
	[AttributeSchemaId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Attributes] ON
INSERT [dbo].[Attributes] ([AttributeId], [Value], [AttributeSchemaId], [PropertyId]) VALUES (1, N'strength', 1, 1)
INSERT [dbo].[Attributes] ([AttributeId], [Value], [AttributeSchemaId], [PropertyId]) VALUES (2, N'4', 2, 1)
INSERT [dbo].[Attributes] ([AttributeId], [Value], [AttributeSchemaId], [PropertyId]) VALUES (3, N'+4 strength bonus', 3, 1)
SET IDENTITY_INSERT [dbo].[Attributes] OFF
/****** Object:  Table [dbo].[Campaigns]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Campaigns](
	[CampaignId] [int] IDENTITY(1,1) NOT NULL,
	[CampaignName] [varchar](max) NOT NULL,
	[GameId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Campaigns] PRIMARY KEY CLUSTERED 
(
	[CampaignId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CampaignObjects]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignObjects](
	[CampaignObjectId] [int] NOT NULL,
	[CampaignId] [int] NOT NULL,
	[GameObjectId] [int] NULL,
	[GameObjectSchemaId] [int] NULL,
	[PropertyId] [int] NULL,
	[PropertySchemaId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributeSchemas]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AttributeSchemas](
	[AttributeSchemaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[Multiplicity] [int] NULL,
	[PropertySchemaId] [int] NOT NULL,
 CONSTRAINT [PK_AttributeSchemas] PRIMARY KEY CLUSTERED 
(
	[AttributeSchemaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AttributeSchemas] ON
INSERT [dbo].[AttributeSchemas] ([AttributeSchemaId], [Name], [IsRequired], [Multiplicity], [PropertySchemaId]) VALUES (1, N'ability', 1, 1, 1)
INSERT [dbo].[AttributeSchemas] ([AttributeSchemaId], [Name], [IsRequired], [Multiplicity], [PropertySchemaId]) VALUES (2, N'bonus', 1, 1, 1)
INSERT [dbo].[AttributeSchemas] ([AttributeSchemaId], [Name], [IsRequired], [Multiplicity], [PropertySchemaId]) VALUES (3, N'description', 0, 1, 1)
INSERT [dbo].[AttributeSchemas] ([AttributeSchemaId], [Name], [IsRequired], [Multiplicity], [PropertySchemaId]) VALUES (4, N'weight', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[AttributeSchemas] OFF
/****** Object:  Table [dbo].[GameObjects]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameObjects](
	[GameObjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[GameObjectSchemaId] [int] NOT NULL,
 CONSTRAINT [PK_GameObjects] PRIMARY KEY CLUSTERED 
(
	[GameObjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GameObjectPropertySchemas]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameObjectPropertySchemas](
	[GameObjectPropertySchemaId] [int] IDENTITY(1,1) NOT NULL,
	[GameObjectSchemaId] [int] NOT NULL,
	[PropertySchemaId] [int] NOT NULL,
 CONSTRAINT [PK_GameObjectPropertySchemas] PRIMARY KEY CLUSTERED 
(
	[GameObjectPropertySchemaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameObjectProperties]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameObjectProperties](
	[GameObjectPropertyId] [int] IDENTITY(1,1) NOT NULL,
	[GameObjectId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_GameObjectProperties] PRIMARY KEY CLUSTERED 
(
	[GameObjectPropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Games](
	[GameId] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GameObjectSchemas]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GameObjectSchemas](
	[GameObjectSchemaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GameObjectSchemas] PRIMARY KEY CLUSTERED 
(
	[GameObjectSchemaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecordObjectPropertyIds]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecordObjectPropertyIds](
	[Id] [int] NULL,
	[ObjectId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecordIds]    Script Date: 03/20/2015 23:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecordIds](
	[Id] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[RecordIds] ([Id]) VALUES (1)
INSERT [dbo].[RecordIds] ([Id]) VALUES (2)
INSERT [dbo].[RecordIds] ([Id]) VALUES (3)
/****** Object:  UserDefinedTableType [dbo].[RecordIdList]    Script Date: 03/20/2015 23:39:13 ******/
CREATE TYPE [dbo].[RecordIdList] AS TABLE(
	[Id] [int] NOT NULL
)
GO
/****** Object:  Table [dbo].[PropertySchemas]    Script Date: 03/20/2015 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertySchemas](
	[PropertySchemaId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsSummaryProperty] [bit] NOT NULL,
 CONSTRAINT [PK_PropertySchemas] PRIMARY KEY CLUSTERED 
(
	[PropertySchemaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Properties]    Script Date: 03/20/2015 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Properties](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PropertySchemaId] [int] NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedTableType [dbo].[ObjectPropertyRelationList]    Script Date: 03/20/2015 23:39:13 ******/
CREATE TYPE [dbo].[ObjectPropertyRelationList] AS TABLE(
	[Id] [int] NULL,
	[ObjectId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL
)
GO
/****** Object:  StoredProcedure [dbo].[GetAllRecords]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllRecords] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @tableNames table(
		tableName varchar(20));
	INSERT INTO @tableNames
		VALUES('AttributeSchemas'), 
			  ('Attributes');

    -- Insert statements for procedure here
    SELECT * FROM @tableNames
	SELECT * FROM AttributeSchemas AS "AttributeSchemas"
	SELECT * FROM Attributes AS "Attributes"
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the PropertySchemas table for one data record.
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Upsert] 
	@PropertySchemaId	INT,
	@Name				VARCHAR(MAX),
	@IsSummaryProperty	BIT
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;

    IF (@PropertySchemaId = 0)
		BEGIN
			INSERT INTO dbo.PropertySchemas (Name, IsSummaryProperty)
				VALUES (@Name, @IsSummaryProperty);
			SET @Output = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			UPDATE dbo.PropertySchemas SET
				Name				= @Name,
				IsSummaryProperty	= @IsSummaryProperty
			WHERE PropertySchemaId	= @PropertySchemaId;
			SET @Output = @@ROWCOUNT;
		END
		
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the PropertySchemas table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Read] 
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	SELECT	dbo.PropertySchemas.PropertySchemaId,
			dbo.PropertySchemas.Name,
			dbo.PropertySchemas.IsSummaryProperty
	FROM	dbo.PropertySchemas INNER JOIN dbo.RecordIds
	ON		dbo.PropertySchemas.PropertySchemaId = dbo.RecordIds.Id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the PropertySchemas table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Delete] 
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	DELETE FROM dbo.PropertySchemas
	WHERE dbo.PropertySchemas.PropertySchemaId
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
	
	SET @Output = @@ROWCOUNT;
	
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Property_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the Properties table for one data record.
-- =============================================
CREATE PROCEDURE [dbo].[Property_Upsert] 
	-- Add the parameters for the stored procedure here
	@PropertyId			INT,
	@Name				VARCHAR(MAX),
	@PropertySchemaId	INT
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;
	
	IF (@PropertyId = 0)
		BEGIN
			INSERT INTO dbo.Properties (Name, PropertySchemaId)
				VALUES (@Name, @PropertySchemaId);
			SET @Output = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			UPDATE dbo.Properties SET
				Name				= @Name,
				PropertySchemaId	= @PropertySchemaId
			WHERE PropertyId		= @PropertyId;
			SET @Output = @@ROWCOUNT;
		END

    RETURN @Output;
    
END
GO
/****** Object:  StoredProcedure [dbo].[Property_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the Properties table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[Property_Read]
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;
		
	SELECT	dbo.Properties.PropertyId,
			dbo.Properties.Name
	FROM	dbo.Properties INNER JOIN dbo.RecordIds
	ON		dbo.Properties.PropertyId = dbo.RecordIds.Id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[Property_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the Properties table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[Property_Delete]
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;

	DECLARE @Output INT;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;
	
	DELETE FROM dbo.Properties
	WHERE dbo.Properties.PropertyId
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
		
    SET @Output = @@ROWCOUNT;
    
    RETURN @Output;
    
END
GO
/****** Object:  StoredProcedure [dbo].[GameObjectSchema_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the GameObjectSchemas table for one data record.
-- =============================================
CREATE PROCEDURE [dbo].[GameObjectSchema_Upsert]
	@GameObjectSchemaId		INT,
	@Name					VARCHAR(MAX),
	@PropertyList			ObjectPropertyRelationList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;
	
	TRUNCATE TABLE dbo.RecordObjectPropertyIds;
	
	INSERT INTO dbo.RecordObjectPropertyIds (Id, ObjectId, PropertyId)
		SELECT Id, ObjectId, PropertyId FROM @PropertyList;
	
	IF (@GameObjectSchemaId = 0)
		BEGIN
			INSERT INTO dbo.GameObjectSchemas (Name)
				VALUES (@Name);
				
			SET @Output = SCOPE_IDENTITY();
			
			INSERT INTO dbo.GameObjectPropertySchemas(GameObjectSchemaId, PropertySchemaId)
				SELECT ObjectId, PropertyId FROM dbo.RecordObjectPropertyIds;
		END
	ELSE
		BEGIN
			UPDATE dbo.GameObjectSchemas SET
				Name					= @Name
			WHERE GameObjectSchemaId	= @GameObjectSchemaId;
			
			SET @Output = @@ROWCOUNT;
			
			UPDATE dbo.GameObjectPropertySchemas SET
				GameObjectSchemaId		= dbo.RecordObjectPropertyIds.ObjectId,
				PropertySchemaId		= dbo.RecordObjectPropertyIds.PropertyId
			FROM dbo.GameObjectPropertySchemas, dbo.RecordObjectPropertyIds
			WHERE dbo.GameObjectPropertySchemas.GameObjectPropertySchemaId = dbo.RecordObjectPropertyIds.Id;
		END

    RETURN @Output;
    
END
GO
/****** Object:  StoredProcedure [dbo].[GameObjectSchema_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the GameObjectSchemas table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[GameObjectSchema_Read]
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    SELECT	dbo.GameObjectSchemas.GameObjectSchemaId,
			dbo.GameObjectSchemas.Name
	FROM	dbo.GameObjectSchemas INNER JOIN dbo.RecordIds
	ON		dbo.GameObjectSchemas.GameObjectSchemaId = dbo.RecordIds.Id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GameObjectSchema_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the GameObjectSchemas table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[GameObjectSchema_Delete]
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;
		
	DELETE FROM dbo.GameObjectSchemas
	WHERE dbo.GameObjectSchemas.GameObjectSchemaId
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);

    SET @Output = @@ROWCOUNT;
    
    RETURN @Output;
    
END
GO
/****** Object:  StoredProcedure [dbo].[GameObject_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the GameObjects table for one record.
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Upsert] 
	@GameObjectId		INT,
	@Name				VARCHAR(MAX),
	@GameObjectSchemaId	INT,
	@PropertyList		ObjectPropertyRelationList	READONLY
AS
BEGIN
	
	SET NOCOUNT OFF;
	
	DECLARE @Output INT;
	
	TRUNCATE TABLE dbo.RecordObjectPropertyIds;
	
	INSERT INTO dbo.RecordObjectPropertyIds (Id, ObjectId, PropertyId)
		SELECT Id, ObjectId, PropertyId FROM @PropertyList;

    IF (@GameObjectId = 0)
		BEGIN
			INSERT INTO dbo.GameObjects(Name, GameObjectSchemaId)
				VALUES (@Name, @GameObjectSchemaId);
				
			SET @Output = SCOPE_IDENTITY();
			
			INSERT INTO dbo.GameObjectProperties (GameObjectId, PropertyId)
				SELECT ObjectId, PropertyId FROM dbo.RecordObjectPropertyIds;
		END
	ELSE
		BEGIN
			UPDATE dbo.GameObjects SET
				Name				= @Name,
				GameObjectSchemaId	= @GameObjectSchemaId
			WHERE GameObjectId		= @GameObjectId;
			
			SET @Output = @@ROWCOUNT;
			
			UPDATE dbo.GameObjectProperties SET
				GameObjectId		= dbo.RecordObjectPropertyIds.ObjectId,
				PropertyId			= dbo.RecordObjectPropertyIds.PropertyId
			FROM dbo.GameObjectProperties, dbo.RecordObjectPropertyIds
			WHERE dbo.GameObjectProperties.GameObjectPropertyId = dbo.RecordObjectPropertyIds.Id;
		END
		
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GameObject_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the GameObjects table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Read] 
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	SELECT	dbo.GameObjects.GameObjectId, 
			dbo.GameObjects.GameObjectSchemaId,
			dbo.GameObjects.Name
	FROM	dbo.GameObjects INNER JOIN dbo.RecordIds
	ON		dbo.GameObjects.GameObjectId = dbo.RecordIds.Id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GameObject_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the GameObjects table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Delete] 
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	DELETE FROM dbo.GameObjects
	WHERE dbo.GameObjects.GameObjectId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
		
	SET @Output = @@ROWCOUNT;
	
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the AttributeSchemas table for one data record.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Upsert] 
	@AttributeSchemaId	INT,
	@Name				VARCHAR(MAX),
	@IsRequired			BIT,
	@Multiplicity		INT,
	@PropertySchemaId	INT
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;

    IF (@AttributeSchemaId = 0)
		BEGIN
			INSERT INTO dbo.AttributeSchemas (Name, IsRequired, Multiplicity, PropertySchemaId)
				VALUES (@Name, @IsRequired, @Multiplicity, @PropertySchemaId);
			SET @Output = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			UPDATE dbo.AttributeSchemas SET
				Name				= @Name,
				IsRequired			= @IsRequired,
				Multiplicity		= @Multiplicity,
				PropertySchemaId	= @PropertySchemaId
			WHERE AttributeSchemaId = @AttributeSchemaId;
			SET @Output = @@ROWCOUNT;
		END
		
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the AttributeSchemas table as specified in the record id list.
--				If the record id list is empty, returns all records.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Read] 
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;
		
	IF ((SELECT COUNT(Id) FROM dbo.RecordIds) > 0)
		BEGIN

			SELECT	dbo.AttributeSchemas.AttributeSchemaId,
					dbo.AttributeSchemas.PropertySchemaId,
					dbo.AttributeSchemas.IsRequired,
					dbo.AttributeSchemas.Multiplicity,
					dbo.AttributeSchemas.Name
			FROM	dbo.AttributeSchemas INNER JOIN dbo.RecordIds
			ON		dbo.AttributeSchemas.AttributeSchemaId = dbo.RecordIds.Id;
		
		END
	ELSE
		BEGIN
			SELECT	dbo.AttributeSchemas.AttributeSchemaId,
					dbo.AttributeSchemas.PropertySchemaId,
					dbo.AttributeSchemas.IsRequired,
					dbo.AttributeSchemas.Multiplicity,
					dbo.AttributeSchemas.Name
			FROM	dbo.AttributeSchemas
		END
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the AttributeSchemas table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Delete] 
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	DELETE FROM dbo.AttributeSchemas
	WHERE dbo.AttributeSchemas.AttributeSchemaId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
	
	SET @Output = @@ROWCOUNT;
	
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Upsert]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Performs an upsert on the Attributes table for one data record.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Upsert] 
	@AttributeId		INT,
	@Value				VARCHAR(MAX),
	@AttributeSchemaId	BIT,
	@PropertyId			INT
AS
BEGIN
	SET NOCOUNT OFF;

	DECLARE @Output INT;
	
    IF (@AttributeId = 0)
		BEGIN
			INSERT INTO dbo.Attributes (Value, AttributeSchemaId, PropertyId)
				VALUES (@Value, @AttributeSchemaId, @PropertyId);
			SET @Output = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			UPDATE dbo.Attributes SET
				Value				= @Value,
				AttributeSchemaId	= @AttributeSchemaId,
				PropertyId			= @PropertyId
			WHERE AttributeId		= @AttributeId;
			SET @Output = @@ROWCOUNT;
		END
		
	RETURN @Output;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Read]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Retrieves all records from the Attributes table as specified in the record id list.
--				If the record id list is empty, returns all records.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Read] 
	@IdList dbo.RecordIdList READONLY
AS
BEGIN

	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;
		
	IF ((SELECT COUNT(Id) FROM dbo.RecordIds) > 0)
		BEGIN

			SELECT	dbo.Attributes.AttributeId,
					dbo.Attributes.AttributeSchemaId,
					dbo.Attributes.PropertyId,
					dbo.Attributes.Value
			FROM	dbo.Attributes INNER JOIN dbo.RecordIds
			ON		dbo.Attributes.AttributeId = dbo.RecordIds.Id;
		
		END
	ELSE
		BEGIN
			SELECT	dbo.Attributes.AttributeId,
					dbo.Attributes.AttributeSchemaId,
					dbo.Attributes.PropertyId,
					dbo.Attributes.Value
			FROM	dbo.Attributes
		END
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Delete]    Script Date: 03/20/2015 23:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Richard Reade
-- Create date: Mar 18, 2015
-- Description:	Deletes all records from the Attributes table as specified in the record id list.
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Delete] 
	@IdList			dbo.RecordIdList	READONLY
AS
BEGIN

	SET NOCOUNT OFF;
	
	DECLARE @Output INT;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

	DELETE FROM dbo.Attributes
	WHERE dbo.Attributes.AttributeId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
	
	SET @Output = @@ROWCOUNT;
	
	RETURN @Output;
	
END
GO
