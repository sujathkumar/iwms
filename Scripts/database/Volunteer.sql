USE [IWMS]
GO

/****** Object:  Table [dbo].[Volunteer]    Script Date: 10/25/2015 4:08:37 PM ******/
DROP TABLE [dbo].[Volunteer]
GO

/****** Object:  Table [dbo].[Volunteer]    Script Date: 10/25/2015 4:08:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Volunteer](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[WardId] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Volunteer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

