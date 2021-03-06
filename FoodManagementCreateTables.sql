USE [FoodManagement]
GO
/****** Object:  Table [dbo].[Families]    Script Date: 15/11/2016 15:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Families](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](70) NULL,
 CONSTRAINT [PK_Families] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 15/11/2016 15:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[People]    Script Date: 15/11/2016 15:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](70) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FamilyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShoppinglistItems]    Script Date: 15/11/2016 15:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppinglistItems](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [int] NULL,
	[FamilyId] [uniqueidentifier] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[BuyAtStoreId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ShoppingListItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stores]    Script Date: 15/11/2016 15:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stores](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_People]    Script Date: 15/11/2016 15:32:43 ******/
CREATE NONCLUSTERED INDEX [IX_People] ON [dbo].[People]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Families] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Families] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Families]
GO
ALTER TABLE [dbo].[ShoppinglistItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingListItems_Families] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Families] ([Id])
GO
ALTER TABLE [dbo].[ShoppinglistItems] CHECK CONSTRAINT [FK_ShoppingListItems_Families]
GO
ALTER TABLE [dbo].[ShoppinglistItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingListItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ShoppinglistItems] CHECK CONSTRAINT [FK_ShoppingListItems_Items]
GO
ALTER TABLE [dbo].[ShoppinglistItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingListItems_Store] FOREIGN KEY([BuyAtStoreId])
REFERENCES [dbo].[Stores] ([Id])
GO
ALTER TABLE [dbo].[ShoppinglistItems] CHECK CONSTRAINT [FK_ShoppingListItems_Store]
GO
USE [master]
GO
ALTER DATABASE [FoodManagement] SET  READ_WRITE 
GO
