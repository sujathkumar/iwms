USE [IWMS]
GO

/****** Object:  Table [dbo].[WardTag]    Script Date: 10/24/2015 1:12:49 PM ******/
DROP TABLE [dbo].[WardTag]
GO

/****** Object:  Table [dbo].[WardTag]    Script Date: 10/24/2015 1:12:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WardTag](
	[Id] [uniqueidentifier] NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[TagNo] [int] NOT NULL,
 CONSTRAINT [PK_WardTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

