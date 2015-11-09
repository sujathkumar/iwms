USE [IWMS]
GO

/****** Object:  Table [dbo].[Recycler]    Script Date: 11/9/2015 5:05:20 PM ******/
DROP TABLE [dbo].[Recycler]
GO

/****** Object:  Table [dbo].[Recycler]    Script Date: 11/9/2015 5:05:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recycler](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Recycler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

