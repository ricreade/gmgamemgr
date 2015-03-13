USE [master]
GO
/****** Object:  Database [GMGameManagerData]    Script Date: 03/12/2015 22:04:39 ******/
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
/****** Object:  Table [dbo].[Attributes]    Script Date: 03/12/2015 22:04:41 ******/
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
/****** Object:  Table [dbo].[AttributeSchemas]    Script Date: 03/12/2015 22:04:41 ******/
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
SET IDENTITY_INSERT [dbo].[AttributeSchemas] OFF
/****** Object:  Table [dbo].[RecordIds]    Script Date: 03/12/2015 22:04:41 ******/
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
/****** Object:  UserDefinedTableType [dbo].[RecordIdList]    Script Date: 03/12/2015 22:04:42 ******/
CREATE TYPE [dbo].[RecordIdList] AS TABLE(
	[Id] [int] NOT NULL
)
GO
/****** Object:  Table [dbo].[PropertySchemas]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  Table [dbo].[GameObjectSchemas]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  Table [dbo].[GameObjects]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  Table [dbo].[GameObjectPropertySchemas]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  Table [dbo].[GameObjectProperties]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  Table [dbo].[Properties]    Script Date: 03/12/2015 22:04:42 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllRecords]    Script Date: 03/12/2015 22:04:44 ******/
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
/****** Object:  StoredProcedure [dbo].[GameObject_Upsert]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Upsert] 
	-- Add the parameters for the stored procedure here
	@GameObjectId		INT				= NULL,
	@Name				VARCHAR(MAX),
	@GameObjectSchemaId	INT,
	@RowsAffected		INT				OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    IF (@GameObjectId IS NULL)
		INSERT INTO dbo.GameObjects(Name, GameObjectSchemaId)
			VALUES (@Name, @GameObjectSchemaId)
	ELSE
		BEGIN
			UPDATE dbo.GameObjects SET
				Name				= @Name,
				GameObjectSchemaId	= @GameObjectSchemaId
			WHERE GameObjectId = @GameObjectId
		END
		
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GameObject_Read]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Read] 
	-- Add the parameters for the stored procedure here
	@IdList dbo.RecordIdList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	SELECT dbo.GameObjects.GameObjectId, 
		   dbo.GameObjects.GameObjectSchemaId,
		   dbo.GameObjects.Name
	FROM dbo.GameObjects INNER JOIN dbo.RecordIds
	ON dbo.GameObjects.GameObjectId = dbo.RecordIds.Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[GameObject_Delete]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GameObject_Delete] 
	-- Add the parameters for the stored procedure here
	@IdList			dbo.RecordIdList	READONLY,
	@RowsAffected	INT					OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	DELETE FROM dbo.GameObjects
	WHERE dbo.GameObjects.GameObjectId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
	
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Upsert]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Upsert] 
	-- Add the parameters for the stored procedure here
	@PropertySchemaId	INT				= NULL,
	@Name				VARCHAR(MAX),
	@IsSummaryProperty	BIT,
	@RowsAffected		INT				OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    IF (@PropertySchemaId IS NULL)
		INSERT INTO dbo.PropertySchemas (Name, IsSummaryProperty)
			VALUES (@Name, @IsSummaryProperty)
	ELSE
		BEGIN
			UPDATE dbo.PropertySchemas SET
				Name				= @Name,
				IsSummaryProperty	= @IsSummaryProperty
			WHERE PropertySchemaId = @PropertySchemaId
		END
		
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Read]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Read] 
	-- Add the parameters for the stored procedure here
	@IdList dbo.RecordIdList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	SELECT dbo.PropertySchemas.PropertySchemaId,
		   dbo.PropertySchemas.Name,
		   dbo.PropertySchemas.IsSummaryProperty
	FROM dbo.PropertySchemas INNER JOIN dbo.RecordIds
	ON dbo.PropertySchemas.PropertySchemaId = dbo.RecordIds.Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[PropertySchema_Delete]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PropertySchema_Delete] 
	-- Add the parameters for the stored procedure here
	@IdList			dbo.RecordIdList	READONLY,
	@RowsAffected	INT					OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	DELETE FROM dbo.PropertySchemas
	WHERE dbo.PropertySchemas.PropertySchemaId
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds)
	
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Upsert]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Upsert] 
	-- Add the parameters for the stored procedure here
	@AttributeSchemaId	INT				= NULL,
	@Name				VARCHAR(MAX),
	@IsRequired			BIT,
	@Multiplicity		INT,
	@PropertySchemaId	INT,
	@RowsAffected		INT				OUTPUT
AS
BEGIN

	SET NOCOUNT OFF;

    IF (@AttributeSchemaId IS NULL)
		INSERT INTO dbo.AttributeSchemas (Name, IsRequired, Multiplicity, PropertySchemaId)
			VALUES (@Name, @IsRequired, @Multiplicity, @PropertySchemaId)
	ELSE
		BEGIN
			UPDATE dbo.AttributeSchemas SET
				Name				= @Name,
				IsRequired			= @IsRequired,
				Multiplicity		= @Multiplicity,
				PropertySchemaId	= @PropertySchemaId
			WHERE AttributeSchemaId = @AttributeSchemaId
		END
		
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Read]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Read] 
	-- Add the parameters for the stored procedure here
	@IdList dbo.RecordIdList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	SELECT dbo.AttributeSchemas.AttributeSchemaId,
		   dbo.AttributeSchemas.PropertySchemaId,
		   dbo.AttributeSchemas.IsRequired,
		   dbo.AttributeSchemas.Multiplicity,
		   dbo.AttributeSchemas.Name
	FROM dbo.AttributeSchemas INNER JOIN dbo.RecordIds
	ON dbo.AttributeSchemas.AttributeSchemaId = dbo.RecordIds.Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeSchema_Delete]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeSchema_Delete] 
	-- Add the parameters for the stored procedure here
	@IdList			dbo.RecordIdList	READONLY,
	@RowsAffected	INT					OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	
	TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	DELETE FROM dbo.AttributeSchemas
	WHERE dbo.AttributeSchemas.AttributeSchemaId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds);
	
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Upsert]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Upsert] 
	-- Add the parameters for the stored procedure here
	@AttributeId		INT				= NULL,
	@Value				VARCHAR(MAX),
	@AttributeSchemaId	BIT,
	@PropertyId			INT,
	@RowsAffected		INT				OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    IF (@AttributeId IS NULL)
		INSERT INTO dbo.Attributes (Value, AttributeSchemaId, PropertyId)
			VALUES (@Value, @AttributeSchemaId, @PropertyId)
	ELSE
		BEGIN
			UPDATE dbo.Attributes SET
				Value				= @Value,
				AttributeSchemaId	= @AttributeSchemaId,
				PropertyId			= @PropertyId
			WHERE AttributeId		= @AttributeId
		END
		
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Read]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Read] 
	-- Add the parameters for the stored procedure here
	@IdList dbo.RecordIdList READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	TRUNCATE TABLE dbo.RecordIds
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	SELECT dbo.Attributes.AttributeId,
		   dbo.Attributes.AttributeSchemaId,
		   dbo.Attributes.PropertyId,
		   dbo.Attributes.Value
	FROM dbo.Attributes INNER JOIN dbo.RecordIds
	ON dbo.Attributes.AttributeId = dbo.RecordIds.Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[AttributeItem_Delete]    Script Date: 03/12/2015 22:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttributeItem_Delete] 
	-- Add the parameters for the stored procedure here
	@IdList			dbo.RecordIdList	READONLY,
	@RowsAffected	INT					OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    TRUNCATE TABLE dbo.RecordIds;
	
	INSERT INTO dbo.RecordIds (Id)
		SELECT Id FROM @IdList;

    -- Insert statements for procedure here
	DELETE FROM dbo.Attributes
	WHERE dbo.Attributes.AttributeId 
		IN (SELECT dbo.RecordIds.Id FROM dbo.RecordIds)
	
	SET @RowsAffected = @@ROWCOUNT;
	
END
GO
