USE [FoodManagement]
GO
INSERT [dbo].[Families] ([Id], [Name]) VALUES (N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'Van den Driessche                                                     ')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'24f2d79d-ffed-4886-af08-11d93eade2f1', N'Chocolat Donut', N'Round patiserie')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'6401aab2-880b-422e-916b-1884ff1a32f1', N'Pommegrenade', N'Tropical Fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'32b58cb8-023b-42e6-90ed-35f0db7a6558', N'Banana', N'Yellow fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'69b1926e-0954-4afa-b945-37c51dfbe0f8', N'Special Star fruit', N'Tropical Fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'00e4f046-fb58-492f-b139-427a93daacc8', N'Kinder Bueno', N'Choclat')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'db4a70da-29c6-461b-a66a-4ca4486cd0ba', N'Coconut', N'Big nut')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'09d2de80-e5a9-448d-aff4-7f0f9379bd41', N'Olive oil', N'Oil')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'629c5cfb-0206-4fe5-b995-8ab52498b889', N'Star fruit', N'Tropical Fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'66e2dedd-68ff-4092-9a5e-904abc5e3b56', N'Burger', NULL)
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'7b1cffdd-e104-4c4d-8fd8-92d7b0b27205', N'Pommegrenat', N'Tropical Fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'5f66c35c-8b07-483c-882b-bd1c05268928', N'Bread', NULL)
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'6a28a26a-15c1-49c3-b88c-c0455d8be849', N'Mango', N'Tropical Fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'b55c004e-1916-4969-ba69-c965662c6cea', N'Donut', N'Round patiserie')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'0b36ca65-dc60-49cc-a8dd-dcd4f513feae', N'Apple', N'Red fruit')
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'bfd63e7b-940c-4796-a6e4-dd96d445d71a', N'Papaya', NULL)
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'5ce5c41b-33bf-4ea6-81dd-f37a5e9a2f2a', N'Umberella', NULL)
GO
INSERT [dbo].[Items] ([Id], [Name], [Description]) VALUES (N'44d8a32e-b8f3-48c9-b381-fd3ea506b07a', N'Pommegrenate', N'Tropical Fruit')
GO
INSERT [dbo].[Stores] ([Id], [Name]) VALUES (N'51132bba-d865-43ac-855d-734ffcd518a1', N'Aldi')
GO
INSERT [dbo].[Stores] ([Id], [Name]) VALUES (N'9be64e83-762c-44a7-8844-91ad619b6db0', N'Lidle')
GO
INSERT [dbo].[Stores] ([Id], [Name]) VALUES (N'3426a11e-e7e8-4754-9489-a64c763a0cf4', N'Delhaize')
GO
INSERT [dbo].[Stores] ([Id], [Name]) VALUES (N'76816d82-2286-467f-a2da-f8b2e2e51150', N'Lidl')
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'b7ae7d4e-cdae-4fa4-8317-64863caf5ad7', 6, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'66e2dedd-68ff-4092-9a5e-904abc5e3b56', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'1e359377-d25d-449a-a9db-7415d4b1f9d9', 8, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'6401aab2-880b-422e-916b-1884ff1a32f1', N'51132bba-d865-43ac-855d-734ffcd518a1')
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'2ae6f4c1-fc3a-48d2-a172-88a17ace9654', 2, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'32b58cb8-023b-42e6-90ed-35f0db7a6558', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'bfd2d824-092c-4b3f-ae4e-9c44950729ae', 4, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'bfd63e7b-940c-4796-a6e4-dd96d445d71a', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'89da4a97-144a-4998-b5a1-a1a0b6e5e0ae', 5, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'09d2de80-e5a9-448d-aff4-7f0f9379bd41', N'76816d82-2286-467f-a2da-f8b2e2e51150')
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'b2824f7f-b460-4058-8f75-a6a9e69e115c', 2, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'db4a70da-29c6-461b-a66a-4ca4486cd0ba', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'6d55e0cc-dcca-4349-86b8-b8ab789b4318', 1, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'5f66c35c-8b07-483c-882b-bd1c05268928', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'4050a814-0970-4a4f-919f-d99c63643c3a', 13, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'24f2d79d-ffed-4886-af08-11d93eade2f1', N'76816d82-2286-467f-a2da-f8b2e2e51150')
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'0a3cf280-f348-405e-a008-dcde47743f34', 1, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'5ce5c41b-33bf-4ea6-81dd-f37a5e9a2f2a', NULL)
GO
INSERT [dbo].[ShoppinglistItems] ([Id], [Amount], [FamilyId], [ItemId], [BuyAtStoreId]) VALUES (N'bd38edb8-3d25-4c44-9277-ee523ea52254', 1, N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a', N'69b1926e-0954-4afa-b945-37c51dfbe0f8', N'3426a11e-e7e8-4754-9489-a64c763a0cf4')
GO
INSERT [dbo].[People] ([Id], [Name], [LastName], [Email], [FamilyId]) VALUES (N'd38a4709-4d0a-434b-905b-1adacb7b015e', N'Jens', N'Van den Driessche', N'vandendriesschejens@msn.com', N'65a5fff3-cd22-4212-8bcf-c8112e3d2b7a')
GO
