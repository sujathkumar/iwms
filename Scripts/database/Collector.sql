USE [IWMS]
GO

/****** Object:  Table [dbo].[Collector]    Script Date: 10/15/2015 8:15:22 PM ******/
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
	[FrequencyId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

