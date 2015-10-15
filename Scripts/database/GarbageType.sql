USE [IWMS]
GO

/****** Object:  Table [dbo].[GarbageType]    Script Date: 10/15/2015 8:17:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GarbageType](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [smallint] NOT NULL,
	[Type] [nchar](10) NOT NULL
) ON [PRIMARY]

GO


