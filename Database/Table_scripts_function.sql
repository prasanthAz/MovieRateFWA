USE [MovieRating]
GO
/****** Object:  UserDefinedFunction [dbo].[fnCalculateMovieAverageRating]    Script Date: 05-12-2021 14:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnCalculateMovieAverageRating]
(
	@MovieId int
)
RETURNS decimal(4,2)
AS
BEGIN
	return (SELECT  cast (round(rating * 2, 0) / 2 as decimal(4,1))
			FROM	MovieRating
			WHERE	MovieId = @MovieId)
			END

GO
/****** Object:  Table [dbo].[Genre]    Script Date: 05-12-2021 14:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [smallint] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 05-12-2021 14:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[YearOfRelease] [smallint] NOT NULL,
	[GenreId] [smallint] NOT NULL,
	[RunningTime] [tinyint] NOT NULL,
	[AverageRating] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieRating]    Script Date: 05-12-2021 14:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieRating](
	[MovieId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Rating] [decimal](4, 2) NULL,
 CONSTRAINT [PK_MovieRating] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05-12-2021 14:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movie]  WITH NOCHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Movie] NOCHECK CONSTRAINT [FK_Movie_Genre]
GO
ALTER TABLE [dbo].[MovieRating]  WITH NOCHECK ADD  CONSTRAINT [FK_MoveiRating_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[MovieRating] NOCHECK CONSTRAINT [FK_MoveiRating_Movie]
GO
ALTER TABLE [dbo].[MovieRating]  WITH CHECK ADD  CONSTRAINT [FK_MovieRating_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MovieRating] CHECK CONSTRAINT [FK_MovieRating_User]
GO
