USE [IWMS]
GO

/****** Object:  Table [dbo].[GarbageType]    Script Date: 10/24/2015 1:11:47 PM ******/
DROP TABLE [dbo].[GarbageType]
GO

/****** Object:  Table [dbo].[GarbageType]    Script Date: 10/24/2015 1:11:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GarbageType](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [smallint] NOT NULL,
	[Type] [nchar](20) NOT NULL,
 CONSTRAINT [PK_GarbageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

