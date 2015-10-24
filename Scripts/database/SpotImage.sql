USE [IWMS]
GO

/****** Object:  Table [dbo].[SpotImage]    Script Date: 10/24/2015 1:12:06 PM ******/
DROP TABLE [dbo].[SpotImage]
GO

/****** Object:  Table [dbo].[SpotImage]    Script Date: 10/24/2015 1:12:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SpotImage](
	[Id] [uniqueidentifier] NOT NULL,
	[Latitude] [nchar](10) NOT NULL,
	[Longitude] [nchar](10) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[WardId] [uniqueidentifier] NULL,
	[UserAddress] [nvarchar](250) NULL,
	[Verified] [bit] NOT NULL,
	[ImagePath] [nvarchar](50) NOT NULL,
	[UploadedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SpotImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

