USE [IWMS]
GO

/****** Object:  Table [dbo].[Bin]    Script Date: 10/24/2015 1:10:12 PM ******/
DROP TABLE [dbo].[Bin]
GO

/****** Object:  Table [dbo].[Bin]    Script Date: 10/24/2015 1:10:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bin](
	[Id] [uniqueidentifier] NOT NULL,
	[Status] [smallint] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Bin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

