USE [MovieRating]
GO
INSERT [dbo].[Genre] ([Id], [Description]) VALUES (1, N'Action')
INSERT [dbo].[Genre] ([Id], [Description]) VALUES (2, N'Comedy')
INSERT [dbo].[Genre] ([Id], [Description]) VALUES (3, N'Horror')
INSERT [dbo].[Genre] ([Id], [Description]) VALUES (4, N'Science Fiction')
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([Id], [Title], [YearOfRelease], [GenreId], [RunningTime], [AverageRating]) VALUES (43, N'Movie1', 2021, 1, 110, CAST(4.30 AS Decimal(4, 2)))
INSERT [dbo].[Movie] ([Id], [Title], [YearOfRelease], [GenreId], [RunningTime], [AverageRating]) VALUES (44, N'Movie2', 2021, 1, 110, CAST(4.40 AS Decimal(4, 2)))
INSERT [dbo].[Movie] ([Id], [Title], [YearOfRelease], [GenreId], [RunningTime], [AverageRating]) VALUES (45, N'Movie3', 2021, 2, 110, CAST(4.00 AS Decimal(4, 2)))
INSERT [dbo].[Movie] ([Id], [Title], [YearOfRelease], [GenreId], [RunningTime], [AverageRating]) VALUES (46, N'Movie4', 2020, 2, 140, CAST(4.80 AS Decimal(4, 2)))
INSERT [dbo].[Movie] ([Id], [Title], [YearOfRelease], [GenreId], [RunningTime], [AverageRating]) VALUES (47, N'Movie5', 2020, 2, 140, CAST(4.50 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name]) VALUES (1, N'FWA1')
INSERT [dbo].[User] ([Id], [Name]) VALUES (2, N'FWA2')
INSERT [dbo].[User] ([Id], [Name]) VALUES (3, N'FWA3')
INSERT [dbo].[User] ([Id], [Name]) VALUES (4, N'FWA4')
INSERT [dbo].[User] ([Id], [Name]) VALUES (5, N'FWA5')
INSERT [dbo].[User] ([Id], [Name]) VALUES (6, N'FWA6')
INSERT [dbo].[User] ([Id], [Name]) VALUES (7, N'FWA7')
INSERT [dbo].[User] ([Id], [Name]) VALUES (8, N'FWA8')
INSERT [dbo].[User] ([Id], [Name]) VALUES (9, N'FWA9')
INSERT [dbo].[User] ([Id], [Name]) VALUES (10, N'FWA10')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[MovieRating] ([MovieId], [UserId], [Rating]) VALUES (45, 1, CAST(4.20 AS Decimal(4, 2)))
GO
