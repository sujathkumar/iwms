USE [IWMS]
GO

/****** Object:  Table [dbo].[City]    Script Date: 10/24/2015 1:10:20 PM ******/
DROP TABLE [dbo].[City]
GO

/****** Object:  Table [dbo].[City]    Script Date: 10/24/2015 1:10:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[City](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](10) NOT NULL,
	[Server] [nvarchar](50) NOT NULL,
	[GCMSenderId] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

