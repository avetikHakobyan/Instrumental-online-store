USE [master]
GO
/****** Object:  Database [H60Assignment3Identity_avh_rc]    Script Date: Nov 03 2023 8:21:18 PM ******/
CREATE DATABASE [H60Assignment3Identity_avh_rc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'H60Assignment3Identity_avh_rc', FILENAME = N'E:\MSSQL\DATA\H60Assignment3Identity_avh_rc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'H60Assignment3Identity_avh_rc_log', FILENAME = N'E:\MSSQL\LOGS\H60Assignment3Identity_avh_rc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [H60Assignment3Identity_avh_rc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ARITHABORT OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET  MULTI_USER 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'H60Assignment3Identity_avh_rc', N'ON'
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET QUERY_STORE = OFF
GO
USE [H60Assignment3Identity_avh_rc]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: Nov 03 2023 8:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231014151010_CreateIdentitySchema', N'6.0.23')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'03d31bc9-c1ba-430e-9dcc-18e0775cc919', N'Clerk', N'CLERK', N'32799c4f-e86b-4197-8970-c79e6cdb61f2')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a69553bc-fcb5-414c-a9bf-9d335120191b', N'Manager', N'MANAGER', N'8cc6835f-5eb8-4dcd-8296-6628716b91ea')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'cdb3fd39-b77c-4152-b8c2-c300727699c6', N'Customer', N'CUSTOMER', N'2e5ee05d-c1b7-4e3e-b7bf-462081ff933c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'92dc1d29-9ed4-4152-b837-5bd057979c91', N'03d31bc9-c1ba-430e-9dcc-18e0775cc919')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e2b564a-6cdc-4af4-a466-aeb5ec14d2f0', N'a69553bc-fcb5-414c-a9bf-9d335120191b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0815e5bb-c7d0-46a1-94fb-79c2fc2b859b', N'cdb3fd39-b77c-4152-b8c2-c300727699c6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21078f5b-f73a-4f97-8ddd-7654f7a17f5c', N'cdb3fd39-b77c-4152-b8c2-c300727699c6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'591be25a-e770-4292-a057-91992daa1d60', N'cdb3fd39-b77c-4152-b8c2-c300727699c6')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0815e5bb-c7d0-46a1-94fb-79c2fc2b859b', N'jbrunet@gmail.com', N'JBRUNET@GMAIL.COM', N'jbrunet@gmail.com', N'JBRUNET@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAENuKMUCMk+t//j7j+PpgwiNLn/s2iCsaxonXiZM70QeDY5c3w6W9SBU9vLfpFEzVcw==', N'N2BRM3JFM6NTCZT2MJZZ5VN3LCZGM2Y4', N'492b229b-76f4-4fc8-af68-d8b1438187ff', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'21078f5b-f73a-4f97-8ddd-7654f7a17f5c', N'rchan@gmail.com', N'RCHAN@GMAIL.COM', N'rchan@gmail.com', N'RCHAN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGH1d8Q3QwSnjmY1X5XAbet8sTYuPgbbAiRfBA7sFXlcww5slwDaJWBN2NdB9J49Tw==', N'6BVU3S7UWVK5CCBXWA5IZ6RC4B3UUQ6V', N'929cf022-75a9-48bc-9445-3f7be1a86e90', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'591be25a-e770-4292-a057-91992daa1d60', N'sodrapeau@gmail.com', N'SODRAPEAU@GMAIL.COM', N'sodrapeau@gmail.com', N'SODRAPEAU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEAqw2ljoZgJP/F/qPLvK+ZVHHeU2S6O3vVnpOa/CIaynFnr+VFqUn+UfRAzfpAumdw==', N'LJOE63JXNU6G2SGHIOSLWXZRVCEFH2P4', N'f8522eac-0ad1-49dd-9ac4-80998e6eda1c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'92dc1d29-9ed4-4152-b837-5bd057979c91', N'clerk@avetsbeats.ca', N'CLERK@AVETSBEATS.CA', N'clerk@avetsbeats.ca', N'CLERK@AVETSBEATS.CA', 1, N'AQAAAAEAACcQAAAAEGHmRiY4M0XOOdSKK7N3FiG/leZIAeP1prQbnEiUsxcuUMg4xNm+sLcUbtdOiJqw6A==', N'RQHA44ZVPUE3UELXCXC2RGFI2ZSWVYDN', N'c59d32d7-1bc8-4784-9fd1-2b159bd48e10', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9e2b564a-6cdc-4af4-a466-aeb5ec14d2f0', N'manager@avetsbeats.ca', N'MANAGER@AVETSBEATS.CA', N'manager@avetsbeats.ca', N'MANAGER@AVETSBEATS.CA', 1, N'AQAAAAEAACcQAAAAEP8xczDQEejUyQT1THbJi4CKqC4J7WddHGeijpQVkxOhcJFboarggHr0JiUkep8xZw==', N'XDDMU24CM4GRWE3MHDOXJHZQC25LRVQU', N'b10bd884-421d-4d54-b573-e02960b668f1', NULL, 0, 0, NULL, 1, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: Nov 03 2023 8:21:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [H60Assignment3Identity_avh_rc] SET  READ_WRITE 
GO
