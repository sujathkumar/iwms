USE [IWMS]
GO

/****** Object:  Table [dbo].[Suggestion]    Script Date: 11/9/2015 5:06:09 PM ******/
DROP TABLE [dbo].[Suggestion]
GO

/****** Object:  Table [dbo].[Suggestion]    Script Date: 11/9/2015 5:06:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Suggestion](
	[Id] [uniqueidentifier] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[Description] [ntext] NOT NULL,
	[ReferenceNumber] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Suggestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


