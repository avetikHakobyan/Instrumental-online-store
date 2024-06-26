USE [master]
GO
/****** Object:  Database [H60Assignment3DB_avh_rc]    Script Date: Nov 03 2023 8:20:19 PM ******/
CREATE DATABASE [H60Assignment3DB_avh_rc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'H60Assignment3DB_avh_rc', FILENAME = N'E:\MSSQL\DATA\H60Assignment3DB_avh_rc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'H60Assignment3DB_avh_rc_log', FILENAME = N'E:\MSSQL\LOGS\H60Assignment3DB_avh_rc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [H60Assignment3DB_avh_rc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ARITHABORT OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET  MULTI_USER 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'H60Assignment3DB_avh_rc', N'ON'
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET QUERY_STORE = OFF
GO
USE [H60Assignment3DB_avh_rc]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: Nov 03 2023 8:20:20 PM ******/
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
/****** Object:  Table [dbo].[CartItem]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[ShoppingCartId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[Province] [nvarchar](2) NULL,
	[CreditCard] [nvarchar](16) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NULL,
	[DateFulfilled] [datetime2](7) NULL,
	[Total] [decimal](10, 2) NULL,
	[Taxes] [decimal](8, 2) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProdCatId] [int] NOT NULL,
	[Description] [varchar](80) NULL,
	[Manufacturer] [varchar](80) NULL,
	[Stock] [int] NOT NULL,
	[BuyPrice] [numeric](8, 2) NULL,
	[SellPrice] [numeric](8, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[ProdCat] [varchar](60) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: Nov 03 2023 8:20:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[ShoppingCartId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230917205846_CreateDB', N'6.0.21')
GO
SET IDENTITY_INSERT [dbo].[CartItem] ON 

INSERT [dbo].[CartItem] ([CartItemId], [ShoppingCartId], [ProductId], [Quantity], [Price]) VALUES (1, 1, 1, 1, CAST(100.00 AS Decimal(8, 2)))
INSERT [dbo].[CartItem] ([CartItemId], [ShoppingCartId], [ProductId], [Quantity], [Price]) VALUES (2, 1, 1, 2, CAST(200.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[CartItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [PhoneNumber], [Province], [CreditCard]) VALUES (1, N'Jayson', N'Brunet', N'jbrunet@gmail.com', N'8191234567', N'QC', N'5110137329543942')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [PhoneNumber], [Province], [CreditCard]) VALUES (2, N'Simon-Olivier', N'Drapeau', N'sodrapeau@gmail.com', N'6131234567', N'ON', N'4716816650033364')
INSERT [dbo].[Customer] ([CustomerId], [FirstName], [LastName], [Email], [PhoneNumber], [Province], [CreditCard]) VALUES (3, N'Richard', N'Chan', N'rchan@gmail.com', N'8731234567', N'QC', N'345942229152050')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [CustomerId], [DateCreated], [DateFulfilled], [Total], [Taxes]) VALUES (1, 1, CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-14T00:00:00.0000000' AS DateTime2), CAST(114.98 AS Decimal(10, 2)), CAST(14.98 AS Decimal(8, 2)))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [DateCreated], [DateFulfilled], [Total], [Taxes]) VALUES (2, 2, CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-16T00:00:00.0000000' AS DateTime2), CAST(200.06 AS Decimal(10, 2)), CAST(26.06 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 1, 1, 1, CAST(100.00 AS Decimal(8, 2)))
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 1, 2, 1, CAST(90.00 AS Decimal(8, 2)))
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (3, 1, 3, 1, CAST(174.75 AS Decimal(8, 2)))
INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 2, 4, 2, CAST(300.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (1, 1, N'Too Deep', N'Roma', 8, CAST(25.00 AS Numeric(8, 2)), CAST(100.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (2, 1, N'No No No', N'Kaddy', 9, CAST(20.00 AS Numeric(8, 2)), CAST(90.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (3, 1, N'Eureka', N'Junkey', 0, CAST(34.95 AS Numeric(8, 2)), CAST(174.75 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (4, 1, N'Winner', N'Storm', 10, CAST(30.00 AS Numeric(8, 2)), CAST(150.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (5, 2, N'Feelings', N'Jurrivh', 13, CAST(14.95 AS Numeric(8, 2)), CAST(74.75 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (6, 2, N'Fuego', N'Encore', 9, CAST(20.00 AS Numeric(8, 2)), CAST(90.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (8, 2, N'I''m fine', N'Storm', 10, CAST(30.00 AS Numeric(8, 2)), CAST(150.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (9, 3, N'Party', N'JustBen', 8, CAST(25.00 AS Numeric(8, 2)), CAST(100.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (10, 3, N'Forever', N'Black Lions', 9, CAST(20.00 AS Numeric(8, 2)), CAST(90.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (11, 3, N'Mine', N'ProducerX', 0, CAST(34.95 AS Numeric(8, 2)), CAST(174.75 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (12, 3, N'Say My Name', N'Anyvibe', 10, CAST(30.00 AS Numeric(8, 2)), CAST(150.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (13, 4, N'Too Deep', N'Horizon', 8, CAST(25.00 AS Numeric(8, 2)), CAST(100.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (14, 4, N'No promises', N'Rob', 9, CAST(20.00 AS Numeric(8, 2)), CAST(90.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (15, 4, N'Answers', N'IVN', 18, CAST(34.95 AS Numeric(8, 2)), CAST(175.95 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (16, 4, N'Texas', N'Classy', 10, CAST(30.00 AS Numeric(8, 2)), CAST(150.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (17, 5, N'Final Chapter', N'Cold Melody', 8, CAST(25.00 AS Numeric(8, 2)), CAST(100.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (18, 5, N'Too late', N'Fantom', 9, CAST(20.00 AS Numeric(8, 2)), CAST(90.00 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (19, 5, N'Energy', N'Shyy', 18, CAST(34.95 AS Numeric(8, 2)), CAST(174.75 AS Numeric(8, 2)))
INSERT [dbo].[Product] ([ProductID], [ProdCatId], [Description], [Manufacturer], [Stock], [BuyPrice], [SellPrice]) VALUES (20, 5, N'Damage', N'JakeAngel', 10, CAST(30.00 AS Numeric(8, 2)), CAST(150.00 AS Numeric(8, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([CategoryID], [ProdCat]) VALUES (1, N'Hip hop')
INSERT [dbo].[ProductCategory] ([CategoryID], [ProdCat]) VALUES (2, N'Pop')
INSERT [dbo].[ProductCategory] ([CategoryID], [ProdCat]) VALUES (3, N'R&B')
INSERT [dbo].[ProductCategory] ([CategoryID], [ProdCat]) VALUES (4, N'Rock')
INSERT [dbo].[ProductCategory] ([CategoryID], [ProdCat]) VALUES (5, N'Reggae')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ShoppingCart] ON 

INSERT [dbo].[ShoppingCart] ([ShoppingCartId], [CustomerId], [DateCreated]) VALUES (1, 1, CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ShoppingCart] OFF
GO
/****** Object:  Index [IX_CartItem_ProductId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItem_ProductId] ON [dbo].[CartItem]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartItem_ShoppingCartId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartItem_ShoppingCartId] ON [dbo].[CartItem]
(
	[ShoppingCartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_CustomerId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_CustomerId] ON [dbo].[Order]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItem_OrderId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItem_OrderId] ON [dbo].[OrderItem]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItem_ProductId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItem_ProductId] ON [dbo].[OrderItem]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ProdCatId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProdCatId] ON [dbo].[Product]
(
	[ProdCatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShoppingCart_CustomerId]    Script Date: Nov 03 2023 8:20:20 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ShoppingCart_CustomerId] ON [dbo].[ShoppingCart]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Product_ProductId]
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_ShoppingCart_ShoppingCartId] FOREIGN KEY([ShoppingCartId])
REFERENCES [dbo].[ShoppingCart] ([ShoppingCartId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_ShoppingCart_ShoppingCartId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer_CustomerId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order_OrderId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProdCatId])
REFERENCES [dbo].[ProductCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCart_Customer_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCart] CHECK CONSTRAINT [FK_ShoppingCart_Customer_CustomerId]
GO
USE [master]
GO
ALTER DATABASE [H60Assignment3DB_avh_rc] SET  READ_WRITE 
GO
