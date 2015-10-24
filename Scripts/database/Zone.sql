USE [IWMS]
GO

/****** Object:  Table [dbo].[Zone]    Script Date: 10/24/2015 1:12:56 PM ******/
DROP TABLE [dbo].[Zone]
GO

/****** Object:  Table [dbo].[Zone]    Script Date: 10/24/2015 1:12:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Zone](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Zone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

