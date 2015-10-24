USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorGarbageType]    Script Date: 10/24/2015 1:10:44 PM ******/
DROP TABLE [dbo].[CollectorGarbageType]
GO

/****** Object:  Table [dbo].[CollectorGarbageType]    Script Date: 10/24/2015 1:10:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorGarbageType](
	[Id] [uniqueidentifier] NOT NULL,
	[GarbageTypeId] [uniqueidentifier] NOT NULL,
	[CollectorId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CollectorGarbageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

