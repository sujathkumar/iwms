USE [IWMS]
GO

/****** Object:  Table [dbo].[Collector]    Script Date: 10/24/2015 1:10:28 PM ******/
DROP TABLE [dbo].[Collector]
GO

/****** Object:  Table [dbo].[Collector]    Script Date: 10/24/2015 1:10:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Collector](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FrequencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Collector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

