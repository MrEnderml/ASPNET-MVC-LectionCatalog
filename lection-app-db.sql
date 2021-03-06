USE [master]
GO
/****** Object:  Database [lection-app-db]    Script Date: 30.06.2022 14:02:22 ******/
CREATE DATABASE [lection-app-db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lection-app-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lection-app-db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'lection-app-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lection-app-db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [lection-app-db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lection-app-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lection-app-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lection-app-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lection-app-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lection-app-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lection-app-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [lection-app-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lection-app-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lection-app-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lection-app-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lection-app-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lection-app-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lection-app-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lection-app-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lection-app-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lection-app-db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [lection-app-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lection-app-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lection-app-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lection-app-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lection-app-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lection-app-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lection-app-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lection-app-db] SET RECOVERY FULL 
GO
ALTER DATABASE [lection-app-db] SET  MULTI_USER 
GO
ALTER DATABASE [lection-app-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lection-app-db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lection-app-db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lection-app-db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [lection-app-db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [lection-app-db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'lection-app-db', N'ON'
GO
ALTER DATABASE [lection-app-db] SET QUERY_STORE = OFF
GO
USE [lection-app-db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30.06.2022 14:02:22 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 30.06.2022 14:02:22 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30.06.2022 14:02:22 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30.06.2022 14:02:22 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30.06.2022 14:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30.06.2022 14:02:22 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30.06.2022 14:02:22 ******/
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
	[FullName] [nvarchar](max) NOT NULL,
	[Favorites] [nvarchar](max) NOT NULL,
	[History] [nvarchar](max) NOT NULL,
	[WatchLater] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 30.06.2022 14:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lections]    Script Date: 30.06.2022 14:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[isFavorite] [bit] NOT NULL,
	[isWatchLater] [bit] NOT NULL,
	[Year] [int] NOT NULL,
	[ImageURL] [nvarchar](max) NOT NULL,
	[LinkURL] [nvarchar](max) NOT NULL,
	[Duration] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[Views] [int] NOT NULL,
	[LectionCategory] [int] NOT NULL,
 CONSTRAINT [PK_Lections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lectors]    Script Date: 30.06.2022 14:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[LectorPictureURL] [nvarchar](max) NOT NULL,
	[Bio] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Lectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lectors_Lections]    Script Date: 30.06.2022 14:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectors_Lections](
	[LectionId] [int] NOT NULL,
	[LectorId] [int] NOT NULL,
 CONSTRAINT [PK_Lectors_Lections] PRIMARY KEY CLUSTERED 
(
	[LectorId] ASC,
	[LectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220405140500_Initial', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406152721_Identity_Added', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524070507_AppUserUpdate', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524100819_FixTypeAttrAppUser', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524114617_FixTypeAttrAppUser2', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524125727_FixTypeAttrAppUser3', N'6.0.3')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'338ba62a-55b9-4298-aa6e-9e6ee536c7df', N'User', N'USER', N'57357c1e-e66f-4346-b41c-7f494a2858dd')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'48b46a5e-004d-4677-8735-2326d466b5c9', N'Admin', N'ADMIN', N'49f9a369-b162-4f66-97b9-c59fa7dcaede')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'84a93312-b5aa-4bb5-89b8-df7645d04469', N'338ba62a-55b9-4298-aa6e-9e6ee536c7df')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd1925385-bf3c-4f71-9b02-b67359e6fc6f', N'338ba62a-55b9-4298-aa6e-9e6ee536c7df')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'907a42a8-2a6a-48fb-a95e-936adf6ee842', N'48b46a5e-004d-4677-8735-2326d466b5c9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [Favorites], [History], [WatchLater]) VALUES (N'84a93312-b5aa-4bb5-89b8-df7645d04469', N'ihorTest', N'IHORTEST', N'ihorTest@lCatalog.com', N'IHORTEST@LCATALOG.COM', 0, N'AQAAAAEAACcQAAAAEE3xrX/xTAbhSrbtDv8MsS5v/j+G8ihW1U/GS8UAleOj1TijyIDSlr2n0pJVYdlQAQ==', N'UKTNIVEEABVXFN76HNVO3UULU56FQKKH', N'dd97243c-0806-4886-8cb4-c744f59d6323', NULL, 0, 0, NULL, 1, 0, N'ihorTesttt', N'2 ', N'4 22 23 24 27 25 26 1 ', N'1 25 22 ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [Favorites], [History], [WatchLater]) VALUES (N'907a42a8-2a6a-48fb-a95e-936adf6ee842', N'Admin', N'ADMIN', N'admin@lCatalog.com', N'ADMIN@LCATALOG.COM', 1, N'AQAAAAEAACcQAAAAECip+xC5DQRKnJGeVZ5m1eBoCuptoNjOVgID+i2bPZv9WAI3R72cXkbe/NvtOIbJWA==', N'J5OYKFNB5NF3DARSE4DCXCSKHIPZGYZ3', N'a1b17771-5a6f-4729-b31f-a4e2b939ec49', NULL, 0, 0, NULL, 1, 0, N'Admin User', N'1 ', N'5 30 4 31 32 ', N'1 ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [Favorites], [History], [WatchLater]) VALUES (N'd1925385-bf3c-4f71-9b02-b67359e6fc6f', N'app-User', N'APP-USER', N'user@lCatalog.com', N'USER@LCATALOG.COM', 1, N'AQAAAAEAACcQAAAAEDgP2bOIzeXvzZQg7nGzTBWCwQ+nym33lLgCE2lyyDzy9YJeYQkhNqQZOyLR+gzAOg==', N'EABECLFWRG7UNIVDQ5E3JXQFQWNZ656A', N'90a84387-5ec7-40b4-8704-3ee8a667315b', NULL, 0, 0, NULL, 1, 0, N'Application User', N'6 ', N'23 5 6 ', N'1 23 5 ')
GO
SET IDENTITY_INSERT [dbo].[Lections] ON 

INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (1, N'Философия / Лекция 1 / Что такое философия?', N'Филосо́фия — особая форма познания мира, вырабатывающая систему знаний о наиболее общих характеристиках, предельно обобщающих понятиях и фундаментальных принципах реальности и познания, бытия человека, об отношении человека и мира', 0, 0, 2013, N'http://img.youtube.com/vi/h5LftnUw-v4/mqdefault.jpg', N'https://www.youtube.com/watch?v=h5LftnUw-v4', 116, 1, 284000, 8)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (2, N'The "everything" formula', N'What is the math and what should you do about it?', 0, 0, 2017, N'http://img.youtube.com/vi/_LXrtnYKPVc/mqdefault.jpg', N'https://www.youtube.com/watch?v=_LXrtnYKPVc', 33, 3, 225000, 1)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (3, N'How many particules in university', N'This is a story about based story', 0, 0, 2016, N'https://i.ytimg.com/vi/lpj0E0a0mlU/hqdefault.jpg?sqp=-oaymwEcCPYBEIoBSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLCYoNwyqNErr9GDqZFFsn841mRwIA', N'https://www.youtube.com/embed/lpj0E0a0mlU', 10, 1, 53000, 2)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (4, N'Foundations of physics', N'This is a story about physical based story', 0, 0, 2012, N'http://img.youtube.com/vi/b1t41Q3xRM8/mqdefault.jpg', N'https://www.youtube.com/embed/b1t41Q3xRM8', 57, 2, 415000, 4)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (5, N'История России', N'Что вы знаете об истории России? О Родине Пушкина, Циолковского, Чайковского? О стране с невероятно красивой природой? Сегодня мы постараемся вкратце поведать о важнейших датах в истории нашего государства, заменив одним роликом пять учебников по этому предмету. Так что, как сказал один из героев этого выпуска - поехали в краткую историю России', 0, 0, 2007, N'http://img.youtube.com/vi/p6n4-Mf2w-I/mqdefault.jpg', N'https://www.youtube.com/embed/p6n4-Mf2w-I', 55, 1, 13000, 8)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (6, N'Существует ли время', N'Можно ли время повернуть вспять? Следуют ли события одно за другим, или прошлое, настоящее и будущее существуют параллельно? 
Является ли "время" основным элементом вселенной или же его вовсе не существует?
Найдите ответы на глобальные вопросы человечества в шоу "Сквозь кротовую нору с Морганом Фрименом"', 0, 0, 2020, N'http://img.youtube.com/vi/ZtD-uNc_mL8/mqdefault.jpg', N'https://www.youtube.com/embed/ZtD-uNc_mL8', 17, 3, 120000, 4)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (7, N'Сквозь время с Морганом Фрименом', N'Можно ли время повернуть вспять? Следуют ли события одно за другим, или прошлое, настоящее и будущее существуют параллельно? 
Является ли "время" основным элементом вселенной или же его вовсе не существует?
Найдите ответы на глобальные вопросы человечества в шоу "Сквозь кротовую нору с Морганом Фрименом"', 0, 0, 2020, N'http://img.youtube.com/vi/wdwbvhz26GQ/mqdefault.jpg', N'https://www.youtube.com/embed/wdwbvhz26GQ', 33, 3, 64000, 9)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (22, N'The Strange Orbit of Earth''s Second Moon', N'NUMBERPHILE
Website: http://www.numberphile.com/', 0, 0, 2021, N'http://img.youtube.com/vi/vU-g6mC1F0g/mqdefault.jpg', N'https://www.youtube.com/watch?v=vU-g6mC1F0g', 7, 3, 808000, 9)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (23, N'The Levine Sequence', N'NUMBERPHILE
Website: http://www.numberphile.com/', 0, 0, 2021, N'http://img.youtube.com/vi/KNjPPFyEeLo/mqdefault.jpg', N'https://www.youtube.com/watch?v=KNjPPFyEeLo', 5, 3, 191000, 9)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (24, N'e (Euler''s Number)', N'Euler''s number is a mathematical expression for the base of the natural logarithm. It is usually represented by the letter e and is commonly used in problems relating to exponential growth or decay.

Another way to interpret Euler''s number is as the base for an exponential function whose value is always equal to its derivative. In other words, e is the only possible number such that ex increases at a rate of ex for every possible x.', 0, 0, 2016, N'http://img.youtube.com/vi/AuA2EAgAegE/mqdefault.jpg', N'https://www.youtube.com/watch?v=AuA2EAgAegE', 11, 3, 4000000, 1)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (25, N'Как устроена Вселенная', N'Когда мы начинаем изучать мир и его устройство? Зачем нам эти знания и стремления разгадать "промысел божий"? 
Наша Вселенная необыкновенно красива и полна загадок. От колоссальных взрывов звезд до крошечных частиц и их движения. Каждое новое открытие рождает новый слой тайн и так далее, бесконечно. Стремление человечества к изучению привело нас от каменного века, к веку цифровому.
Что дальше? Смотрите в шоу "Сквозь кротовую нору с Морганом Фрименом" на канале Discovery!', 0, 0, 2021, N'http://img.youtube.com/vi/R_ndnLs-aj8/mqdefault.jpg', N'https://www.youtube.com/watch?v=R_ndnLs-aj8', 44, 3, 800000, 4)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (26, N'Есть ли границы у Вселенной', N'Космос. Кажется, он безграничен,  но так ли это? В свое время Коперник показал, что Земля не является центром Вселенной. Долгое время Вселенная считалась бесконечной, но сейчас ученые предполагают, что можно найти ее границы и даже форму. 
Если Вселенная бесконечна, то не только в пространстве, но и во времени. Небо должно быть усеяно бесчисленным количеством звезд, и свет от них должен выжечь все живое на Земле?', 0, 0, 2020, N'http://img.youtube.com/vi/YPMU2dsIoEo/mqdefault.jpg', N'https://www.youtube.com/watch?v=YPMU2dsIoEo', 44, 3, 3100000, 9)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (27, N'Алгоритмы на Python 3. Лекция №1', N'курс: Информатика. Алгоритмы и структуры данных на Python 3.
лектор: Хирьянов Тимофей Фёдорович
прочитана 05.09.2017

Темы, рассмотренные на лекции №1:
- Что есть "информатика" и что понимает под этим лектор
- Что значит "уметь программировать"
- Hello, World!
- Концепция присваивания в Python
- Обмен двух переменных значениями через одну временную и две временные переменные.
- Множественное присваивание в кортежи переменных. 
- Обмен значений.
- Арифметические операции. Возведение в степень, деление нацело.
- Цикл while. Инструкции управления циклом.
- Вложенный цикл while
- Условный оператор if
- Цикл for и его особенности в Python.
- Функция range()
- Оператор continue', 0, 0, 2017, N'http://img.youtube.com/vi/KdZ4HF1SrFs/mqdefault.jpg', N'https://www.youtube.com/watch?v=KdZ4HF1SrFs', 120, 1, 4020000, 5)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (28, N'Алгоритмы на Python 3. Лекция №2', N'курс: Информатика. Алгоритмы и структуры данных на Python 3.
прочитана 12.09.2017
лектор: Хирьянов Тимофей Фёдорович

Темы, рассмотренные на лекции №2:
- Основы алгебры логики.
- Таблицы истинности и логически законы.
- Дизъюнктивная нормальная форма.
- Тип данных bool. Константы True, False. Логические операции в Python.
- Проверка последовательности на наличие числа x%10==0.
- Проверка последовательности на то, что все числа делятся на 10.
- Последовательные и вложенные условные инструкции.
- Каскадные условные инструкции, оператор elif.', 0, 0, 2017, N'http://img.youtube.com/vi/ZgSx3yH7sJI/mqdefault.jpg', N'https://www.youtube.com/watch?v=ZgSx3yH7sJI', 120, 1, 995000, 5)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (29, N'Краткая история объединения Руси (часть 1)', N'КНа носу один из главный государственных праздников – День России. Сегодня мы расскажем тебе, с чего все начиналось – от разрозненных племен, воюющих между собой, до щита князя Олега, прозванного Вещим, «на вратах Царьграда». Интриги, завоевания, пиратские набеги – в новом выпуске Краткой истории!', 0, 0, 2022, N'http://img.youtube.com/vi/43SJPVd3Rf0/mqdefault.jpg', N'https://www.youtube.com/watch?v=43SJPVd3Rf0', 6, 1, 10000, 2)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (30, N'Краткая история объединения Руси (часть 2)', N'Мы продолжаем рассказ о первом объединении Руси. Сегодня ты узнаешь, кто и как продолжил дело Рюрика и почему известную историю о смерти Вещего Олега от змеиного укуса описывают в исландской саге! А еще – как греки пытались «замолчать» свои поражения и были обмануты Киевские правители Аскольд и Дир.', 0, 0, 2021, N'http://img.youtube.com/vi/t35HuBp_wJA/mqdefault.jpg', N'https://www.youtube.com/watch?v=t35HuBp_wJA', 6, 1, 12000, 2)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (31, N'Work, Energy, and Power - Basic Introduction', N'This physics video tutorial provides a basic introduction into work, energy, and power.  It discusses the work-energy principle, the relationship between work, force, & displacement as well as kinetic and potential energy.', 0, 0, 2021, N'http://img.youtube.com/vi/_MR1Dp8-F8w/mqdefault.jpg', N'https://www.youtube.com/watch?v=_MR1Dp8-F8w', 54, 3, 670000, 4)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (32, N'Полиглот Английский за 16 часов. Урок 1', N'Полиглот. Выучим английский за 16 часов! Урок №1. Английский с нуля с Дмитрием Петровым. Учим иностранные языки онлайн.', 0, 0, 2013, N'http://img.youtube.com/vi/9blL5gYzsaA/mqdefault.jpg', N'https://www.youtube.com/watch?v=9blL5gYzsaA', 45, 1, 15000000, 3)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (33, N'Полиглот Английский за 16 часов. Урок 2', N'Полиглот Английский за 16 часов. Урок 2
Эффективный практический курс английской разговорной речи по системе ПОЛИГЛОТ Дмитрия Петрова. В уроке будут упражнения сделаны придерживаясь информации которая будет подаваться в Уроках Полиглот Английский за 16 часов. ', 0, 0, 2013, N'http://img.youtube.com/vi/xI1mCIwSJYU/mqdefault.jpg', N'https://www.youtube.com/watch?v=xI1mCIwSJYU', 37, 1, 4700000, 3)
INSERT [dbo].[Lections] ([Id], [Name], [Description], [isFavorite], [isWatchLater], [Year], [ImageURL], [LinkURL], [Duration], [Country], [Views], [LectionCategory]) VALUES (34, N'Полиглот. Выучим немецкий за 16 часов! Урок 1', N'Полиглот. Выучим немецкий за 16 часов! Урок 1. Немецкий с нуля с Дмитрием Петровым. Учим иностранные языки онлайн.', 0, 0, 2014, N'http://img.youtube.com/vi/h5htd9thidY/mqdefault.jpg', N'https://www.youtube.com/watch?v=h5htd9thidY', 45, 3, 24000000, 3)
SET IDENTITY_INSERT [dbo].[Lections] OFF
GO
SET IDENTITY_INSERT [dbo].[Lectors] ON 

INSERT [dbo].[Lectors] ([Id], [FullName], [LectorPictureURL], [Bio]) VALUES (1, N'Numberfile', N'http://dotnethow.net/images/actors/actor-1.jpeg', N'Grigoriy Leps was born in 1987.')
INSERT [dbo].[Lectors] ([Id], [FullName], [LectorPictureURL], [Bio]) VALUES (2, N'Morgan Frimen', N'http://dotnethow.net/images/actors/actor-2.jpeg', N'Grigoriy Leps was born in 1957. He has a great state of playing piano.')
INSERT [dbo].[Lectors] ([Id], [FullName], [LectorPictureURL], [Bio]) VALUES (3, N'Adam Wolter', N'http://dotnethow.net/images/actors/actor-3.jpeg', N'A greate psysic of our world!')
INSERT [dbo].[Lectors] ([Id], [FullName], [LectorPictureURL], [Bio]) VALUES (4, N'Organic Tutor', N'http://dotnethow.net/images/actors/actor-4.jpeg', N'Mark Twen ml was born in 1977. He is a good person.')
INSERT [dbo].[Lectors] ([Id], [FullName], [LectorPictureURL], [Bio]) VALUES (5, N'Александр Валынский', N'http://dotnethow.net/images/actors/actor-5.jpeg', N'He has 3 statement of math category')
SET IDENTITY_INSERT [dbo].[Lectors] OFF
GO
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (1, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (2, 1)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (3, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (4, 4)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (5, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (6, 2)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (7, 2)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (22, 1)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (23, 1)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (24, 1)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (25, 2)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (26, 2)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (27, 5)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (28, 5)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (29, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (30, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (31, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (32, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (33, 3)
INSERT [dbo].[Lectors_Lections] ([LectionId], [LectorId]) VALUES (34, 3)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 30.06.2022 14:02:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 30.06.2022 14:02:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lectors_Lections_LectionId]    Script Date: 30.06.2022 14:02:22 ******/
CREATE NONCLUSTERED INDEX [IX_Lectors_Lections_LectionId] ON [dbo].[Lectors_Lections]
(
	[LectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [FullName]
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
ALTER TABLE [dbo].[Lectors_Lections]  WITH CHECK ADD  CONSTRAINT [FK_Lectors_Lections_Lections_LectionId] FOREIGN KEY([LectionId])
REFERENCES [dbo].[Lections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lectors_Lections] CHECK CONSTRAINT [FK_Lectors_Lections_Lections_LectionId]
GO
ALTER TABLE [dbo].[Lectors_Lections]  WITH CHECK ADD  CONSTRAINT [FK_Lectors_Lections_Lectors_LectorId] FOREIGN KEY([LectorId])
REFERENCES [dbo].[Lectors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lectors_Lections] CHECK CONSTRAINT [FK_Lectors_Lections_Lectors_LectorId]
GO
USE [master]
GO
ALTER DATABASE [lection-app-db] SET  READ_WRITE 
GO
