USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorGarbageType]    Script Date: 10/15/2015 8:16:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorGarbageType](
	[Id] [uniqueidentifier] NOT NULL,
	[GarbageTypeId] [uniqueidentifier] NOT NULL,
	[CollectorId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO


