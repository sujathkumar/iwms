USE [IWMS]
GO

/****** Object:  Table [dbo].[Cordinate]    Script Date: 10/11/2015 10:40:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cordinate](
	[Id] [uniqueidentifier] NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[Latitude] [nvarchar](50) NOT NULL,
	[Longitude] [nvarchar](50) NOT NULL,
	[Rank] [int] NOT NULL,
 CONSTRAINT [PK_Cordinate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


