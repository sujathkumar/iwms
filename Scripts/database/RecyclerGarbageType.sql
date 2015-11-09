USE [IWMS]
GO

/****** Object:  Table [dbo].[RecyclerGarbageType]    Script Date: 11/9/2015 5:05:48 PM ******/
DROP TABLE [dbo].[RecyclerGarbageType]
GO

/****** Object:  Table [dbo].[RecyclerGarbageType]    Script Date: 11/9/2015 5:05:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecyclerGarbageType](
	[Id] [uniqueidentifier] NOT NULL,
	[GarbageTypeId] [uniqueidentifier] NOT NULL,
	[RecyclerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RecyclerGarbageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

