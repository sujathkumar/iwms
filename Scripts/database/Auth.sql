USE [IWMS]
GO

/****** Object:  Table [dbo].[Auth]    Script Date: 10/11/2015 10:39:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Auth](
	[Id] [uniqueidentifier] NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[ApplicationId] [nvarchar](50) NOT NULL,
	[GCMToken] [nvarchar](500) NULL,
	[REFCODE] [nvarchar](10) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Auth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


