USE [IWMS]
GO

/****** Object:  Table [dbo].[Topic]    Script Date: 10/25/2015 4:08:03 PM ******/
DROP TABLE [dbo].[Topic]
GO

/****** Object:  Table [dbo].[Topic]    Script Date: 10/25/2015 4:08:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Topic](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Tag] [nvarchar](250) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

