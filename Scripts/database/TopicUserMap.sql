USE [IWMS]
GO

/****** Object:  Table [dbo].[TopicUserMap]    Script Date: 10/25/2015 4:08:23 PM ******/
DROP TABLE [dbo].[TopicUserMap]
GO

/****** Object:  Table [dbo].[TopicUserMap]    Script Date: 10/25/2015 4:08:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TopicUserMap](
	[Id] [uniqueidentifier] NOT NULL,
	[TopicId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TopicUserMap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

