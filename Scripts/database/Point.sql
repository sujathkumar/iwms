USE [IWMS]
GO

/****** Object:  Table [dbo].[Point]    Script Date: 10/25/2015 4:07:29 PM ******/
DROP TABLE [dbo].[Point]
GO

/****** Object:  Table [dbo].[Point]    Script Date: 10/25/2015 4:07:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Point](
	[Id] [uniqueidentifier] NOT NULL,
	[Point] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Point] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

