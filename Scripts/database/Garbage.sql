USE [IWMS]
GO

/****** Object:  Table [dbo].[Garbage]    Script Date: 10/24/2015 1:11:35 PM ******/
DROP TABLE [dbo].[Garbage]
GO

/****** Object:  Table [dbo].[Garbage]    Script Date: 10/24/2015 1:11:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Garbage](
	[Id] [uniqueidentifier] NOT NULL,
	[Tag] [nvarchar](50) NOT NULL,
	[BinId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Garbage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

